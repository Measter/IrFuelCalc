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
            this.lblEstimatedLaps = new System.Windows.Forms.Label();
            this.lblEstimatedStops = new System.Windows.Forms.Label();
            this.lblFuelLastLap = new System.Windows.Forms.Label();
            this.lblFuelPerLap = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFuelToAdd = new System.Windows.Forms.Label();
            this.lblFuelReqTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFuelMax = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnEnableAutoFuel = new System.Windows.Forms.Button();
            this.cbOnlyGreen = new System.Windows.Forms.CheckBox();
            this.nudLapOffset = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.nudFuelMult = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudLapOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuelMult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Est. Laps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Est. Stops";
            // 
            // lblEstimatedLaps
            // 
            this.lblEstimatedLaps.AutoSize = true;
            this.lblEstimatedLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedLaps.Location = new System.Drawing.Point(12, 46);
            this.lblEstimatedLaps.Name = "lblEstimatedLaps";
            this.lblEstimatedLaps.Size = new System.Drawing.Size(105, 55);
            this.lblEstimatedLaps.TabIndex = 2;
            this.lblEstimatedLaps.Text = "999";
            // 
            // lblEstimatedStops
            // 
            this.lblEstimatedStops.AutoSize = true;
            this.lblEstimatedStops.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedStops.Location = new System.Drawing.Point(227, 46);
            this.lblEstimatedStops.Name = "lblEstimatedStops";
            this.lblEstimatedStops.Size = new System.Drawing.Size(105, 55);
            this.lblEstimatedStops.TabIndex = 3;
            this.lblEstimatedStops.Text = "999";
            // 
            // lblFuelLastLap
            // 
            this.lblFuelLastLap.AutoSize = true;
            this.lblFuelLastLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelLastLap.Location = new System.Drawing.Point(227, 148);
            this.lblFuelLastLap.Name = "lblFuelLastLap";
            this.lblFuelLastLap.Size = new System.Drawing.Size(105, 55);
            this.lblFuelLastLap.TabIndex = 7;
            this.lblFuelLastLap.Text = "999";
            // 
            // lblFuelPerLap
            // 
            this.lblFuelPerLap.AutoSize = true;
            this.lblFuelPerLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelPerLap.Location = new System.Drawing.Point(12, 148);
            this.lblFuelPerLap.Name = "lblFuelPerLap";
            this.lblFuelPerLap.Size = new System.Drawing.Size(105, 55);
            this.lblFuelPerLap.TabIndex = 6;
            this.lblFuelPerLap.Text = "999";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(226, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 37);
            this.label7.TabIndex = 5;
            this.label7.Text = "Last Lap";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 37);
            this.label8.TabIndex = 4;
            this.label8.Text = "L/Lap";
            // 
            // lblFuelToAdd
            // 
            this.lblFuelToAdd.AutoSize = true;
            this.lblFuelToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelToAdd.Location = new System.Drawing.Point(227, 250);
            this.lblFuelToAdd.Name = "lblFuelToAdd";
            this.lblFuelToAdd.Size = new System.Drawing.Size(105, 55);
            this.lblFuelToAdd.TabIndex = 11;
            this.lblFuelToAdd.Text = "999";
            // 
            // lblFuelReqTotal
            // 
            this.lblFuelReqTotal.AutoSize = true;
            this.lblFuelReqTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelReqTotal.Location = new System.Drawing.Point(12, 250);
            this.lblFuelReqTotal.Name = "lblFuelReqTotal";
            this.lblFuelReqTotal.Size = new System.Drawing.Size(105, 55);
            this.lblFuelReqTotal.TabIndex = 10;
            this.lblFuelReqTotal.Text = "999";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(225, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 37);
            this.label11.TabIndex = 9;
            this.label11.Text = "L. To Add";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 37);
            this.label12.TabIndex = 8;
            this.label12.Text = "Req. Fuel";
            // 
            // lblFuelMax
            // 
            this.lblFuelMax.AutoSize = true;
            this.lblFuelMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelMax.Location = new System.Drawing.Point(12, 352);
            this.lblFuelMax.Name = "lblFuelMax";
            this.lblFuelMax.Size = new System.Drawing.Size(105, 55);
            this.lblFuelMax.TabIndex = 13;
            this.lblFuelMax.Text = "999";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 315);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 37);
            this.label14.TabIndex = 12;
            this.label14.Text = "Max Fuel";
            // 
            // btnEnableAutoFuel
            // 
            this.btnEnableAutoFuel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnableAutoFuel.Location = new System.Drawing.Point(255, 491);
            this.btnEnableAutoFuel.Name = "btnEnableAutoFuel";
            this.btnEnableAutoFuel.Size = new System.Drawing.Size(124, 50);
            this.btnEnableAutoFuel.TabIndex = 14;
            this.btnEnableAutoFuel.Text = "Enable AutoFuel";
            this.btnEnableAutoFuel.UseVisualStyleBackColor = true;
            this.btnEnableAutoFuel.Click += new System.EventHandler(this.btnEnableAutoFuel_Click);
            // 
            // cbOnlyGreen
            // 
            this.cbOnlyGreen.AutoSize = true;
            this.cbOnlyGreen.Location = new System.Drawing.Point(16, 472);
            this.cbOnlyGreen.Name = "cbOnlyGreen";
            this.cbOnlyGreen.Size = new System.Drawing.Size(117, 17);
            this.cbOnlyGreen.TabIndex = 15;
            this.cbOnlyGreen.Text = "Log Only On Green";
            this.cbOnlyGreen.UseVisualStyleBackColor = true;
            // 
            // nudLapOffset
            // 
            this.nudLapOffset.Location = new System.Drawing.Point(116, 495);
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
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Lap Offset:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fuel Rate Multiplier";
            // 
            // nudFuelMult
            // 
            this.nudFuelMult.DecimalPlaces = 2;
            this.nudFuelMult.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudFuelMult.Location = new System.Drawing.Point(116, 521);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 553);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudFuelMult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudLapOffset);
            this.Controls.Add(this.cbOnlyGreen);
            this.Controls.Add(this.btnEnableAutoFuel);
            this.Controls.Add(this.lblFuelMax);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblFuelToAdd);
            this.Controls.Add(this.lblFuelReqTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblFuelLastLap);
            this.Controls.Add(this.lblFuelPerLap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblEstimatedStops);
            this.Controls.Add(this.lblEstimatedLaps);
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
        private System.Windows.Forms.Label lblEstimatedLaps;
        private System.Windows.Forms.Label lblEstimatedStops;
        private System.Windows.Forms.Label lblFuelLastLap;
        private System.Windows.Forms.Label lblFuelPerLap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFuelToAdd;
        private System.Windows.Forms.Label lblFuelReqTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFuelMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnEnableAutoFuel;
        private System.Windows.Forms.CheckBox cbOnlyGreen;
        private System.Windows.Forms.NumericUpDown nudLapOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudFuelMult;
    }
}

