namespace IrFuelCalc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValueEstimatedLaps = new System.Windows.Forms.Label();
            this.lblValueEstimatedStops = new System.Windows.Forms.Label();
            this.lblValueFuelLastLap = new System.Windows.Forms.Label();
            this.lblValueFuelPerLap = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblValueFuelToAdd = new System.Windows.Forms.Label();
            this.lblValueFuelReqTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblValueFuelMax = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnEnableAutoFuel = new System.Windows.Forms.Button();
            this.cbOnlyGreen = new System.Windows.Forms.CheckBox();
            this.nudLapOffset = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.nudFuelMult = new System.Windows.Forms.NumericUpDown();
            this.cbUnits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLapOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuelMult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Est. Laps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Est. Stops";
            // 
            // lblValueEstimatedLaps
            // 
            this.lblValueEstimatedLaps.AutoSize = true;
            this.lblValueEstimatedLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueEstimatedLaps.Location = new System.Drawing.Point(12, 38);
            this.lblValueEstimatedLaps.Name = "lblValueEstimatedLaps";
            this.lblValueEstimatedLaps.Size = new System.Drawing.Size(83, 44);
            this.lblValueEstimatedLaps.TabIndex = 2;
            this.lblValueEstimatedLaps.Text = "999";
            // 
            // lblValueEstimatedStops
            // 
            this.lblValueEstimatedStops.AutoSize = true;
            this.lblValueEstimatedStops.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueEstimatedStops.Location = new System.Drawing.Point(227, 38);
            this.lblValueEstimatedStops.Name = "lblValueEstimatedStops";
            this.lblValueEstimatedStops.Size = new System.Drawing.Size(83, 44);
            this.lblValueEstimatedStops.TabIndex = 3;
            this.lblValueEstimatedStops.Text = "999";
            // 
            // lblValueFuelLastLap
            // 
            this.lblValueFuelLastLap.AutoSize = true;
            this.lblValueFuelLastLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueFuelLastLap.Location = new System.Drawing.Point(227, 122);
            this.lblValueFuelLastLap.Name = "lblValueFuelLastLap";
            this.lblValueFuelLastLap.Size = new System.Drawing.Size(83, 44);
            this.lblValueFuelLastLap.TabIndex = 7;
            this.lblValueFuelLastLap.Text = "999";
            // 
            // lblValueFuelPerLap
            // 
            this.lblValueFuelPerLap.AutoSize = true;
            this.lblValueFuelPerLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueFuelPerLap.Location = new System.Drawing.Point(12, 122);
            this.lblValueFuelPerLap.Name = "lblValueFuelPerLap";
            this.lblValueFuelPerLap.Size = new System.Drawing.Size(83, 44);
            this.lblValueFuelPerLap.TabIndex = 6;
            this.lblValueFuelPerLap.Text = "999";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(226, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fuel Last Lap";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "Avg. Per Lap";
            // 
            // lblValueFuelToAdd
            // 
            this.lblValueFuelToAdd.AutoSize = true;
            this.lblValueFuelToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueFuelToAdd.Location = new System.Drawing.Point(227, 206);
            this.lblValueFuelToAdd.Name = "lblValueFuelToAdd";
            this.lblValueFuelToAdd.Size = new System.Drawing.Size(83, 44);
            this.lblValueFuelToAdd.TabIndex = 11;
            this.lblValueFuelToAdd.Text = "999";
            // 
            // lblValueFuelReqTotal
            // 
            this.lblValueFuelReqTotal.AutoSize = true;
            this.lblValueFuelReqTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueFuelReqTotal.Location = new System.Drawing.Point(12, 206);
            this.lblValueFuelReqTotal.Name = "lblValueFuelReqTotal";
            this.lblValueFuelReqTotal.Size = new System.Drawing.Size(83, 44);
            this.lblValueFuelReqTotal.TabIndex = 10;
            this.lblValueFuelReqTotal.Text = "999";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(225, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 29);
            this.label11.TabIndex = 9;
            this.label11.Text = "Fuel To Add";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 29);
            this.label12.TabIndex = 8;
            this.label12.Text = "Req. Fuel";
            // 
            // lblValueFuelMax
            // 
            this.lblValueFuelMax.AutoSize = true;
            this.lblValueFuelMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueFuelMax.Location = new System.Drawing.Point(12, 290);
            this.lblValueFuelMax.Name = "lblValueFuelMax";
            this.lblValueFuelMax.Size = new System.Drawing.Size(83, 44);
            this.lblValueFuelMax.TabIndex = 13;
            this.lblValueFuelMax.Text = "999";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 261);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 29);
            this.label14.TabIndex = 12;
            this.label14.Text = "Max Fuel";
            // 
            // btnEnableAutoFuel
            // 
            this.btnEnableAutoFuel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnableAutoFuel.Location = new System.Drawing.Point(255, 412);
            this.btnEnableAutoFuel.Name = "btnEnableAutoFuel";
            this.btnEnableAutoFuel.Size = new System.Drawing.Size(124, 50);
            this.btnEnableAutoFuel.TabIndex = 14;
            this.btnEnableAutoFuel.Text = "Enable AutoFuel";
            this.btnEnableAutoFuel.UseVisualStyleBackColor = true;
            this.btnEnableAutoFuel.Click += new System.EventHandler(this.btnEnableAutoFuel_Click);
            // 
            // cbOnlyGreen
            // 
            this.cbOnlyGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOnlyGreen.AutoSize = true;
            this.cbOnlyGreen.Location = new System.Drawing.Point(16, 393);
            this.cbOnlyGreen.Name = "cbOnlyGreen";
            this.cbOnlyGreen.Size = new System.Drawing.Size(117, 17);
            this.cbOnlyGreen.TabIndex = 15;
            this.cbOnlyGreen.Text = "Log Only On Green";
            this.cbOnlyGreen.UseVisualStyleBackColor = true;
            // 
            // nudLapOffset
            // 
            this.nudLapOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudLapOffset.Location = new System.Drawing.Point(116, 416);
            this.nudLapOffset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLapOffset.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudLapOffset.Name = "nudLapOffset";
            this.nudLapOffset.Size = new System.Drawing.Size(50, 20);
            this.nudLapOffset.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Lap Offset:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fuel Rate Multiplier";
            // 
            // nudFuelMult
            // 
            this.nudFuelMult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudFuelMult.DecimalPlaces = 2;
            this.nudFuelMult.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudFuelMult.Location = new System.Drawing.Point(116, 442);
            this.nudFuelMult.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFuelMult.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudFuelMult.Name = "nudFuelMult";
            this.nudFuelMult.Size = new System.Drawing.Size(50, 20);
            this.nudFuelMult.TabIndex = 18;
            this.nudFuelMult.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbUnits
            // 
            this.cbUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbUnits.FormattingEnabled = true;
            this.cbUnits.Items.AddRange(new object[] {
            "Automatic",
            "US Customary",
            "Metric"});
            this.cbUnits.Location = new System.Drawing.Point(54, 366);
            this.cbUnits.Name = "cbUnits";
            this.cbUnits.Size = new System.Drawing.Size(121, 21);
            this.cbUnits.TabIndex = 20;
            this.cbUnits.SelectedIndexChanged += new System.EventHandler(this.CbUnits_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Units:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 474);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbUnits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudFuelMult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudLapOffset);
            this.Controls.Add(this.cbOnlyGreen);
            this.Controls.Add(this.btnEnableAutoFuel);
            this.Controls.Add(this.lblValueFuelMax);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblValueFuelToAdd);
            this.Controls.Add(this.lblValueFuelReqTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblValueFuelLastLap);
            this.Controls.Add(this.lblValueFuelPerLap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblValueEstimatedStops);
            this.Controls.Add(this.lblValueEstimatedLaps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "iRacing Fuel Calculator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudLapOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuelMult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValueEstimatedLaps;
        private System.Windows.Forms.Label lblValueEstimatedStops;
        private System.Windows.Forms.Label lblValueFuelLastLap;
        private System.Windows.Forms.Label lblValueFuelPerLap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblValueFuelToAdd;
        private System.Windows.Forms.Label lblValueFuelReqTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblValueFuelMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnEnableAutoFuel;
        private System.Windows.Forms.CheckBox cbOnlyGreen;
        private System.Windows.Forms.NumericUpDown nudLapOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudFuelMult;
        private System.Windows.Forms.ComboBox cbUnits;
        private System.Windows.Forms.Label label5;
    }
}

