﻿using System;
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
        
        private const int Unit_Automatic = 0;
        private const int Unit_UsCustomary = 1;
        private const int Unit_Metric = 2;

        private const double LitresPerGallon = 3.785412534;

        private int m_estimatedLaps = 0;
        private int m_estimatedStops = 0;
        private int m_telemLaps = 0;
        private int m_lapsRemaining = 0;
        private double m_fuelPerLap = 0.0;
        private double m_fuelLastLap = 0.0;
        private double m_totalFuelRequired = 0.0;
        private int m_fuelToAdd = 0;
        private double m_maxFuel = 0.0;
        private bool m_isGreen = false;
        private bool m_is_metric_units = true;

        private string m_lastTrackId = "";
        private string m_lastCarId = "";

        private readonly SdkWrapper m_wrapper;

        private bool m_inPits = true;
        private double m_lastFuelLevel;
        private double m_averageLapTime = 0;
        private int m_lastLapCompleted = 0;
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
            m_tooltip.SetToolTip( cbUnits, "Selects which units to use when displaying and calculating fuel. Automatic will try to use what the game does." );

            OpenConfig();

            if( cbUnits.SelectedIndex == -1 )
                cbUnits.SelectedIndex = 0;

            UpdateLabels();
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

                if( data["settings"].ContainsKey( "units" ) )
                {
                    switch( data["settings"]["units"].ToLower() )
                    {
                        case "metric":
                            cbUnits.SelectedIndex = Unit_Metric;
                            break;
                        case "us customary":
                            cbUnits.SelectedIndex = Unit_UsCustomary;
                            break;
                        case "automatic":
                        default:
                            cbUnits.SelectedIndex = Unit_Automatic;
                            break;
                    }

                }

                cbOnlyGreen.Checked = bool.Parse( greenFlag.Trim() );
                nudLapOffset.Value = decimal.Parse( lapOffset.Trim(), CultureInfo.InvariantCulture );
                nudFuelMult.Value = decimal.Parse( fuelMult.Trim(), CultureInfo.InvariantCulture );
            }
        }

        private void OnSessionInfoUpdated( object sender, SdkWrapper.SessionInfoUpdatedEventArgs e )
        {
            var rawMaxFuel = e.SessionInfo["DriverInfo"]["DriverCarFuelMaxLtr"].Value;
            if( !double.TryParse( rawMaxFuel, out double maxFuel ) )
            {
                m_logger.Error( "Error parsing max fuel: {0}", rawMaxFuel );
                return;
            }

            var rawMaxFuelPerc = e.SessionInfo["DriverInfo"]["DriverCarMaxFuelPct"].Value;
            if( !double.TryParse( rawMaxFuelPerc, out double maxFuelPerc ) )
            {
                m_logger.Error( "Error parsing max fuel percent: {0}", rawMaxFuelPerc );
                return;
            }

            if( Math.Abs(m_maxFuel - maxFuel * maxFuelPerc) > 0.1 )
            {
                m_maxFuel = maxFuel * maxFuelPerc;
                m_logger.Debug( "Max Fuel tank found to be: {0}", maxFuel );
                m_logger.Debug( "Max Fuel percent found to be: {0}%", maxFuelPerc * 100 );
                m_logger.Debug( "Max Fuel is: {0}", m_maxFuel );
            }

            var trackId = e.SessionInfo["WeekendInfo"]["TrackID"].Value;
            var trackDisplayName = e.SessionInfo["WeekendInfo"]["TrackDisplayName"].Value;

            var carIdx = int.Parse(e.SessionInfo["DriverInfo"]["DriverCarIdx"].Value);
            var carScreenName = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarScreenName"].Value;
            var carId = e.SessionInfo["DriverInfo"]["Drivers"]["CarIdx", carIdx]["CarID"].Value;

            if( m_lastTrackId != trackId || m_lastCarId != carId )
            {
                // Track and/or car has changed, so reset everything.
                m_logger.Debug("Track: {0} - {1}", trackId, trackDisplayName);
                m_logger.Debug("Car: {0} - {1}", carId, carScreenName);

                m_lastCarId = carId;
                m_lastTrackId = trackId;

                m_lastFuelLevel = 0.0;
                m_averageLapTime = 0.0;
                m_lastLapCompleted = 0;
                m_sessionRemainingTime = 0.0;
                m_fuelToAdd = 0;
                m_totalFuelRequired = 0.0;
                m_fuelLastLap = 0.0;
                m_fuelPerLap = 0.0;
                m_estimatedStops = 0;
                m_estimatedLaps = 0;
                m_telemLaps = 0;
                m_lapTimes.Clear();
                m_fuelUsages.Clear();
            }

            UpdateLabels();
        }

        private void OnTelemetryUpdated( object sender, SdkWrapper.TelemetryUpdatedEventArgs e )
        {
            if( m_maxFuel < 0.1 )
                m_wrapper.RequestSessionInfoUpdate();

            var inPits = m_wrapper.GetTelemetryValue<bool>( "OnPitRoad" ).Value;
            m_is_metric_units = m_wrapper.GetTelemetryValue<int>( "DisplayUnits" ).Value == 1;
            var sessionState = e.TelemetryInfo.SessionState.Value;
            var lastLapId = e.TelemetryInfo.LapCompleted.Value;

            var flag = e.TelemetryInfo.SessionFlags.Value;
            if( flag.Contains( SessionFlags.Green ) && !m_isGreen )
            {
                m_isGreen = true;
                m_logger.Debug( "Green Flag!" );
            }
            else if( flag.Contains( SessionFlags.Caution ) || flag.Contains( SessionFlags.CautionWaving ) && m_isGreen )
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
            var avgFuel = m_fuelPerLap * (double) nudFuelMult.Value;

            m_estimatedLaps = Math.Max((int) Math.Ceiling( m_sessionRemainingTime / m_averageLapTime ), 0);

            m_lapsRemaining = Math.Min( m_estimatedLaps, m_telemLaps );

            m_totalFuelRequired = avgFuel * ( m_lapsRemaining + (int) nudLapOffset.Value ) - e.TelemetryInfo.FuelLevel.Value;

            if( m_totalFuelRequired > 0.0 )
            {
                m_estimatedStops = (int) Math.Ceiling( m_totalFuelRequired / m_maxFuel );

                if( ( m_totalFuelRequired + e.TelemetryInfo.FuelLevel.Value ) <= m_maxFuel )
                {
                    m_fuelToAdd = (int) Math.Ceiling( m_totalFuelRequired );
                }
                else
                {
                    m_fuelToAdd = (int) Math.Ceiling( m_maxFuel - e.TelemetryInfo.FuelLevel.Value );
                }

                if( (cbUnits.SelectedIndex == Unit_Automatic && !m_is_metric_units) || cbUnits.SelectedIndex == Unit_UsCustomary )
                {
                    m_fuelToAdd = (int)Math.Ceiling(Math.Ceiling(m_fuelToAdd / LitresPerGallon) * LitresPerGallon);
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
            m_telemLaps = m_wrapper.GetTelemetryValue<int>( "SessionLapsRemain" ).Value;

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

                    m_fuelUsages.Sort();
                    m_lapTimes.Sort();
                }

                m_fuelLastLap = fuelDelta;
                m_averageLapTime = GetAvg( m_lapTimes.Where( l => l > 0.0 ) );
                m_fuelPerLap = GetAvg( m_fuelUsages );

                m_logger.Debug( "\t- Fuel Delta: {0}", fuelDelta );
                m_logger.Debug( "\t- Avg Laptime: {0}", m_averageLapTime );
                m_logger.Debug( "\t- Avg Fuel Delta: {0}", m_fuelPerLap );

                m_logger.Debug( "\t- Estimated Laps Remaining: {0}", m_estimatedLaps );
                m_logger.Debug( "\t- Telemetry Laps Remaining: {0}", m_telemLaps );
                m_logger.Debug( "\t- Total Fuel Required: {0}", m_totalFuelRequired );
                m_logger.Debug( "\t- Stops Remaining: {0}", m_estimatedStops );
            }

            m_lastFuelLevel = fuelLevel;
        }

        private void UpdateLabels()
        {
            lblValueEstimatedLaps.Text = m_lapsRemaining.ToString();
            lblValueEstimatedStops.Text = m_estimatedStops.ToString();

            double divisor;
            string unit;

            if( (cbUnits.SelectedIndex == Unit_Automatic && m_is_metric_units) || cbUnits.SelectedIndex == Unit_Metric )
            {
                divisor = 1;
                unit = "L";
            } else
            {
                divisor = LitresPerGallon;
                unit = "G";
            }

            lblValueFuelLastLap.Text = $"{m_fuelLastLap/divisor:0.00} {unit}";
            lblValueFuelMax.Text = $"{m_maxFuel/divisor:0.00} {unit}";
            lblValueFuelPerLap.Text = $"{m_fuelPerLap/divisor:0.00} {unit}";
            lblValueFuelReqTotal.Text = $"{m_totalFuelRequired/divisor:0.00} {unit}";
            lblValueFuelToAdd.Text = $"{m_fuelToAdd/divisor:0} {unit}";
        }

        private static double GetAvg( IEnumerable<double> data )
        {
            if( !data.Any() )
                return 1;

            var top = (data.Count() * 19) / 20; // 95%
            var bottom = (data.Count() * 2) / 5; // 40%

            var avg = data.Take( Math.Max(top, 1) ).Skip( bottom ).Average();

            return avg;
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
            data["settings"]["units"] = cbUnits.SelectedItem.ToString();
            data["settings"]["lap_offset"] = nudLapOffset.Value.ToString( CultureInfo.InvariantCulture );
            data["settings"]["fuel_mult"] = nudFuelMult.Value.ToString( CultureInfo.InvariantCulture );

            var parser = new FileIniDataParser();
            parser.WriteFile( CONFIG_FILE_S, data );
        }

        private void CbUnits_SelectedIndexChanged( object sender, EventArgs e )
        {
            m_logger.Debug( "Selected units changed to: {0}", cbUnits.SelectedItem.ToString() );
        }
    }
}