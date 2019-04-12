using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iRacingSdkWrapper;
using iRacingSdkWrapper.Bitfields;
using IniParser;
using IniParser.Model;

namespace IrFuelCalc
{
    public partial class Form1 : Form
    {
        private static readonly NLog.Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        private const string CONFIG_FILE_S = "config.ini";

        private int m_estimatedLaps = 0;
        private int m_estimatedStops = 0;
        private double m_fuelPerLap = 0.0;
        private double m_fuelLastLap = 0.0;
        private double m_totalFuelRequired = 0.0;
        private int m_fuelToAdd = 0;
        private double m_maxFuel = 0.0;
        private bool m_isGreen = false;

        private readonly SdkWrapper m_wrapper;

        private bool m_inPits = true;
        private double m_lastFuelLevel;
        private double m_averageLapTime = 0;
        private int m_lastLapCompleted= 0;
        private double m_sessionRemainingTime = 0;

        private readonly List<double> m_lapTimes = new List<double>();
        private readonly List<double> m_fuelUsages = new List<double>();
        private bool m_autoFuel = false;

        public Form1()
        {
            InitializeComponent();

            m_logger.Debug( "Initializing iR SDK Wrapper" );

            m_wrapper = new SdkWrapper();
            m_wrapper.SessionInfoUpdated += OnSessionInfoUpdated;
            m_wrapper.TelemetryUpdated += OnTelemetryUpdated;

            m_logger.Debug( "Starting iR SDK Wrapper" );
            m_wrapper.Start();
            m_logger.Debug( "Wrapper Started" );

            m_tooltip.SetToolTip( nudFuelMult, "Sets the multiplier to the fuel rate used during the calculation for fuel needed." );
            m_tooltip.SetToolTip( nudLapOffset, "Adds this number of laps to the race length during fuel calculation." );
            m_tooltip.SetToolTip( cbOnlyGreen, "When enabled, only laps done in a race under green flag conditions are logged. Useful if you expect a lot of cautions." );
            m_tooltip.SetToolTip( btnEnableAutoFuel, "If enabled, will automatically set the pitstop fuel amount when you cross the yellow cones.\nIf disabled, will only monitor." );

            UpdateLabels();

            OpenConfig();
        }

        private void OpenConfig()
        {
            if( File.Exists( CONFIG_FILE_S ) )
            {
                m_logger.Debug( "Reading config" );
                var parser = new FileIniDataParser();
                var data = parser.ReadFile( CONFIG_FILE_S );
                var greenFlag = data["settings"]["green_flag"];
                var lapOffset = data["settings"]["lap_offset"];
                var fuelMult = data["settings"]["fuel_mult"];
                var spreadFuel = data["settings"].ContainsKey( "spread_fuel" ) ? data["settings"]["spread_fuel"] : "False";

                cbOnlyGreen.Checked = bool.Parse( greenFlag.Trim() );
                cbSpreadFuel.Checked = bool.Parse( spreadFuel.Trim() );
                nudLapOffset.Value = decimal.Parse( lapOffset.Trim(), CultureInfo.InvariantCulture );
                nudFuelMult.Value = decimal.Parse( fuelMult.Trim(), CultureInfo.InvariantCulture );
            }
        }

        private void OnSessionInfoUpdated( object sender, SdkWrapper.SessionInfoUpdatedEventArgs e )
        {
            if( Math.Abs( m_maxFuel ) > 0.01 )
                return;

            var rawMaxFuel = e.SessionInfo["DriverInfo"]["DriverCarFuelMaxLtr"].Value;
            if( !double.TryParse( rawMaxFuel, out double maxFuel ) )
            {
                m_logger.Error( "Error parsing max fuel: {0}", rawMaxFuel );
                return;
            }

            var rawMaxFuelPerc = e.SessionInfo["DriverInfo"]["DriverCarMaxFuelPct"].Value;
            if( !double.TryParse(rawMaxFuelPerc, out double maxFuelPerc) )
            {
                m_logger.Error( "Error parsing max fuel percent: {0}", rawMaxFuelPerc );
                return;
            }

            m_logger.Debug( "Max Fuel tank found to be: {0}", maxFuel );
            m_logger.Debug( "Max Fuel percent found to be: {0}", maxFuelPerc );
            m_maxFuel = maxFuel * maxFuelPerc;
            m_logger.Debug( "Max Fuel is: {0}", m_maxFuel );

            var numSessionsString = e.SessionInfo["SessionInfo"]["NumSessions"].Value;
            if( Int32.TryParse( numSessionsString, out int numSessions ) )
            {
                m_logger.Error( "Error parsing number of sessions: {0}", numSessionsString );
                return;
            }

            m_logger.Debug( "Number of Sessions: {0}", numSessions );

            for( int i = 0; i < numSessions; i++ )
            {
                var sessionTime = e.SessionInfo["SessionInfo"]["Sessions", i]["SessionLaps"].Value;
                var sessionType = e.SessionInfo["SessionInfo"]["Sessions", i]["SessionLaps"].Value;
                var sessionLaps = e.SessionInfo["SessionInfo"]["Sessions", i]["SessionLaps"].Value;

                m_logger.Debug( "Session Info: " );
                m_logger.Debug( "\t- Session Time: {0}", sessionTime );
                m_logger.Debug( "\t- Session Type: {0}", sessionType );
                m_logger.Debug( "\t- Session Laps: {0}", sessionLaps );
            }

            UpdateLabels();
        }

        
        private void OnTelemetryUpdated( object sender, SdkWrapper.TelemetryUpdatedEventArgs e )
        {
            if( m_maxFuel < 0.1 )
                m_wrapper.RequestSessionInfoUpdate();

            var inPits = m_wrapper.GetTelemetryValue<bool>( "OnPitRoad" ).Value;
            var sessionState = e.TelemetryInfo.SessionState.Value;
            var lastLapId = e.TelemetryInfo.LapCompleted.Value;

            var flag = e.TelemetryInfo.SessionFlags.Value;
            if( flag.Contains( SessionFlags.Green ) && !m_isGreen )
            {
                m_isGreen = true;
                m_logger.Debug( "Green Flag!" );
            } else if( flag.Contains( SessionFlags.Caution ) || flag.Contains( SessionFlags.CautionWaving ) && m_isGreen )
            {
                m_isGreen = false;
                m_logger.Debug( "Caution Flag!" );
            }

            m_sessionRemainingTime = e.TelemetryInfo.SessionTimeRemain.Value;
            UpdateFuelCalc( e );

            if( lastLapId > 0 && m_lastLapCompleted != lastLapId )
            {
                m_lastLapCompleted = lastLapId;
                OnNewLap( e, inPits, sessionState );
            }

            if( m_inPits != inPits )
            {
                OnPitEntry( e, inPits, sessionState );
            }

            UpdateLabels();
        }

        private void UpdateFuelCalc( SdkWrapper.TelemetryUpdatedEventArgs e )
        {
            var avgFuel = m_fuelPerLap * (double)nudFuelMult.Value;

            m_estimatedLaps = (int)Math.Ceiling( m_sessionRemainingTime / m_averageLapTime );
            m_totalFuelRequired = avgFuel * ( m_estimatedLaps + (int)nudLapOffset.Value ) - e.TelemetryInfo.FuelLevel.Value;

            if( m_totalFuelRequired > 0.0 )
            {
                m_estimatedStops = (int)Math.Ceiling( m_totalFuelRequired / m_maxFuel );

                if( cbSpreadFuel.Checked )
                {
                    var totalFuelThisStop = m_totalFuelRequired / m_estimatedStops;
                    m_fuelToAdd = (int)Math.Ceiling( totalFuelThisStop - e.TelemetryInfo.FuelLevel.Value );
                }
                else if( ( m_totalFuelRequired + e.TelemetryInfo.FuelLevel.Value ) <= m_maxFuel )
                {
                    m_fuelToAdd = (int)Math.Ceiling( m_totalFuelRequired * (double)nudFuelMult.Value - e.TelemetryInfo.FuelLevel.Value );
                }
                else
                {
                    m_fuelToAdd = (int)Math.Ceiling( m_maxFuel - e.TelemetryInfo.FuelLevel.Value );
                }
            }
            else
            {
                m_estimatedStops = 0;
                m_fuelToAdd = 0;
            }
        }

        private void OnPitEntry( SdkWrapper.TelemetryUpdatedEventArgs e, bool inPits, SessionStates sessionState )
        {
            var oldInPits = m_inPits;
            m_inPits = inPits;

            if( !oldInPits )
            {
                // Entering pit, send off command to set fuel.
                m_logger.Debug( "Entering Pits" );
                m_logger.Debug( "\t- Current fuel: {0}", e.TelemetryInfo.FuelLevel );

                if( m_sessionRemainingTime > 0 && sessionState == SessionStates.Racing && m_fuelToAdd > 0.0 )
                {
                    m_logger.Debug( "\t- Adding {0} litres of fuel", m_fuelToAdd );

                    if( m_autoFuel )
                    {
                        m_logger.Debug( "\t- AutoFuel enabled." );
                        m_wrapper.PitCommands.AddFuel( m_fuelToAdd );
                    }
                    else
                    {
                        m_logger.Debug( "\t- AutoFuel disabled." );
                    }
                }
            }
        }

        private void OnNewLap( SdkWrapper.TelemetryUpdatedEventArgs e, bool inPits, SessionStates sessionState )
        {
            var fuelLevel = e.TelemetryInfo.FuelLevel.Value;
            var laptime = m_wrapper.GetTelemetryValue<float>( "LapLastLapTime" ).Value;
            var flag = e.TelemetryInfo.SessionFlags.Value;

            m_logger.Debug( "Lap Completed {0}", m_lastLapCompleted );
            m_logger.Debug( "\t- Time: {0}", laptime );
            m_logger.Debug( "\t- Fuel Level: {0}", fuelLevel );

            if( m_lastFuelLevel >= fuelLevel && !inPits )
            {
                var fuelDelta = m_lastFuelLevel - fuelLevel;
                if( !cbOnlyGreen.Checked || ( cbOnlyGreen.Checked && sessionState == SessionStates.Racing && m_isGreen ) )
                {
                    m_lapTimes.Add( laptime );
                    m_fuelUsages.Add( fuelDelta );
                }

                m_fuelLastLap = fuelDelta;
                m_averageLapTime = GetAvg( m_lapTimes.Where( l => l > 0.0 ) );
                m_fuelPerLap = GetAvg( m_fuelUsages );

                m_logger.Debug( "\t- Fuel Delta: {0}", fuelDelta );
                m_logger.Debug( "\t- Avg Laptime: {0}", m_averageLapTime );
                m_logger.Debug( "\t- Avg Fuel Delta: {0}", m_fuelPerLap );

                m_logger.Debug( "\t- Laps Remaining: {0}", m_estimatedLaps );
                m_logger.Debug( "\t- Total Fuel Required: {0}", m_totalFuelRequired );
                m_logger.Debug( "\t- Stops Remaining: {0}", m_estimatedStops );
            }

            m_lastFuelLevel = fuelLevel;
        }

        private void UpdateLabels()
        {
            lblFuelLastLap.Text = m_fuelLastLap.ToString( "0.00", CultureInfo.InvariantCulture );
            lblEstimatedLaps.Text = m_estimatedLaps.ToString();
            lblEstimatedStops.Text = m_estimatedStops.ToString();
            lblFuelMax.Text = m_maxFuel.ToString( "0.00", CultureInfo.InvariantCulture );
            lblFuelPerLap.Text = m_fuelPerLap.ToString( "0.00", CultureInfo.InvariantCulture );
            lblFuelReqTotal.Text = m_totalFuelRequired.ToString( "0.00", CultureInfo.InvariantCulture );
            lblFuelToAdd.Text = m_fuelToAdd.ToString();
        }

        private static double GetAvg(IEnumerable<double> data)
        {
            if( !data.Any() )
                return 1;
            
            var avg = data.Average();
            var sum = data.Sum( d => Math.Pow( d - avg, 2 ) );
            var stdDev = Math.Sqrt( sum / ( data.Count() - 1 ) );

            var min = avg - stdDev;
            var max = avg + stdDev;

            var filtered = data.Where( l => l >= min && l <= max );

            if( !filtered.Any() )
                return 1;

            return filtered.Average();
        }

        private void btnEnableAutoFuel_Click( object sender, EventArgs e )
        {
            m_autoFuel = !m_autoFuel;

            if( m_autoFuel )
            {
                m_logger.Debug( "Disabling AutoFuel" );
                btnEnableAutoFuel.Text = "Disable AutoFuel";
            }
            else
            {
                m_logger.Debug( "Enabling AutoFuel" );
                btnEnableAutoFuel.Text = "Enable AutoFuel";
            }
        }

        private void Form1_FormClosed( object sender, FormClosedEventArgs e )
        {
            m_logger.Debug( "Stopping iR SDK Wrapper" );
            m_wrapper.Stop();
            m_logger.Debug( "Wrapper Stopped" );

            m_logger.Debug( "Saving config" );
            var data = new IniData();
            data["settings"]["green_flag"] = cbOnlyGreen.Checked.ToString();
            data["settings"]["spread_fuel"] = cbSpreadFuel.Checked.ToString();
            data["settings"]["lap_offset"] = nudLapOffset.Value.ToString( CultureInfo.InvariantCulture );
            data["settings"]["fuel_mult"] = nudFuelMult.Value.ToString( CultureInfo.InvariantCulture );

            var parser = new FileIniDataParser();
            parser.WriteFile( CONFIG_FILE_S, data );
        }
    }
}
