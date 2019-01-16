namespace Distributions
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series29 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series30 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lambdaLb = new System.Windows.Forms.Label();
            this.numbTrialsLb = new System.Windows.Forms.Label();
            this.interArrivalLb = new System.Windows.Forms.Label();
            this.lambdaTbx = new System.Windows.Forms.TextBox();
            this.numbOfTrialsTbx = new System.Windows.Forms.TextBox();
            this.interArrivalTbx = new System.Windows.Forms.TextBox();
            this.exponentialDistributionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.simulationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.poissonDistributionBtn = new System.Windows.Forms.Button();
            this.exponentialDistributionBtn = new System.Windows.Forms.Button();
            this.simulationBtn = new System.Windows.Forms.Button();
            this.distributionInputGrpbox = new System.Windows.Forms.GroupBox();
            this.poissonToStringListBox = new System.Windows.Forms.ListBox();
            this.poissonToStringLb = new System.Windows.Forms.Label();
            this.poissonDistributionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.exponentialToStringListBox = new System.Windows.Forms.ListBox();
            this.simulationToStringListBox = new System.Windows.Forms.ListBox();
            this.scalingTrackBar = new System.Windows.Forms.TrackBar();
            this.exponentialInfoLb = new System.Windows.Forms.Label();
            this.binIncrementTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.bin10Lb = new System.Windows.Forms.Label();
            this.bin100Lb = new System.Windows.Forms.Label();
            this.bin1000Lb = new System.Windows.Forms.Label();
            this.poissonStatisticsLb = new System.Windows.Forms.Label();
            this.exponentialStatisticsLb = new System.Windows.Forms.Label();
            this.simulationStatisticsLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.exponentialDistributionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationChart)).BeginInit();
            this.distributionInputGrpbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poissonDistributionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lambdaLb
            // 
            this.lambdaLb.AutoSize = true;
            this.lambdaLb.Location = new System.Drawing.Point(12, 35);
            this.lambdaLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lambdaLb.Name = "lambdaLb";
            this.lambdaLb.Size = new System.Drawing.Size(48, 13);
            this.lambdaLb.TabIndex = 0;
            this.lambdaLb.Text = "Lambda:";
            // 
            // numbTrialsLb
            // 
            this.numbTrialsLb.AutoSize = true;
            this.numbTrialsLb.Location = new System.Drawing.Point(12, 62);
            this.numbTrialsLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numbTrialsLb.Name = "numbTrialsLb";
            this.numbTrialsLb.Size = new System.Drawing.Size(89, 13);
            this.numbTrialsLb.TabIndex = 1;
            this.numbTrialsLb.Text = "Number Of Trials:";
            // 
            // interArrivalLb
            // 
            this.interArrivalLb.AutoSize = true;
            this.interArrivalLb.Location = new System.Drawing.Point(12, 95);
            this.interArrivalLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.interArrivalLb.Name = "interArrivalLb";
            this.interArrivalLb.Size = new System.Drawing.Size(61, 13);
            this.interArrivalLb.TabIndex = 2;
            this.interArrivalLb.Text = "Interval (T):";
            // 
            // lambdaTbx
            // 
            this.lambdaTbx.Location = new System.Drawing.Point(116, 30);
            this.lambdaTbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lambdaTbx.Name = "lambdaTbx";
            this.lambdaTbx.Size = new System.Drawing.Size(114, 20);
            this.lambdaTbx.TabIndex = 3;
            this.lambdaTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lambdaTbx_KeyPress);
            // 
            // numbOfTrialsTbx
            // 
            this.numbOfTrialsTbx.Location = new System.Drawing.Point(116, 59);
            this.numbOfTrialsTbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numbOfTrialsTbx.Name = "numbOfTrialsTbx";
            this.numbOfTrialsTbx.Size = new System.Drawing.Size(114, 20);
            this.numbOfTrialsTbx.TabIndex = 4;
            this.numbOfTrialsTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbOfTrialsTbx_KeyPress);
            // 
            // interArrivalTbx
            // 
            this.interArrivalTbx.Location = new System.Drawing.Point(116, 92);
            this.interArrivalTbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.interArrivalTbx.Name = "interArrivalTbx";
            this.interArrivalTbx.Size = new System.Drawing.Size(114, 20);
            this.interArrivalTbx.TabIndex = 5;
            this.interArrivalTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.interArrivalTbx_KeyPress);
            // 
            // exponentialDistributionChart
            // 
            chartArea13.Name = "ChartArea1";
            this.exponentialDistributionChart.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.exponentialDistributionChart.Legends.Add(legend13);
            this.exponentialDistributionChart.Location = new System.Drawing.Point(6, 431);
            this.exponentialDistributionChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exponentialDistributionChart.Name = "exponentialDistributionChart";
            series25.ChartArea = "ChartArea1";
            series25.Legend = "Legend1";
            series25.Name = "Exponential Distribution";
            series26.ChartArea = "ChartArea1";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series26.Legend = "Legend1";
            series26.Name = "Exponential PMF";
            this.exponentialDistributionChart.Series.Add(series25);
            this.exponentialDistributionChart.Series.Add(series26);
            this.exponentialDistributionChart.Size = new System.Drawing.Size(1110, 278);
            this.exponentialDistributionChart.TabIndex = 9;
            this.exponentialDistributionChart.Text = "chart2";
            // 
            // simulationChart
            // 
            chartArea14.Name = "ChartArea1";
            this.simulationChart.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.simulationChart.Legends.Add(legend14);
            this.simulationChart.Location = new System.Drawing.Point(6, 716);
            this.simulationChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simulationChart.Name = "simulationChart";
            series27.ChartArea = "ChartArea1";
            series27.Legend = "Legend1";
            series27.Name = "Simulation";
            series28.ChartArea = "ChartArea1";
            series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series28.Legend = "Legend1";
            series28.Name = "Simulation PMF";
            this.simulationChart.Series.Add(series27);
            this.simulationChart.Series.Add(series28);
            this.simulationChart.Size = new System.Drawing.Size(1110, 278);
            this.simulationChart.TabIndex = 10;
            this.simulationChart.Text = "chart3";
            // 
            // poissonDistributionBtn
            // 
            this.poissonDistributionBtn.Location = new System.Drawing.Point(14, 27);
            this.poissonDistributionBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.poissonDistributionBtn.Name = "poissonDistributionBtn";
            this.poissonDistributionBtn.Size = new System.Drawing.Size(156, 25);
            this.poissonDistributionBtn.TabIndex = 11;
            this.poissonDistributionBtn.Text = "Poisson";
            this.poissonDistributionBtn.UseVisualStyleBackColor = true;
            this.poissonDistributionBtn.Click += new System.EventHandler(this.poissonDistributionBtn_Click);
            // 
            // exponentialDistributionBtn
            // 
            this.exponentialDistributionBtn.Location = new System.Drawing.Point(14, 62);
            this.exponentialDistributionBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exponentialDistributionBtn.Name = "exponentialDistributionBtn";
            this.exponentialDistributionBtn.Size = new System.Drawing.Size(156, 25);
            this.exponentialDistributionBtn.TabIndex = 12;
            this.exponentialDistributionBtn.Text = "Exponential";
            this.exponentialDistributionBtn.UseVisualStyleBackColor = true;
            this.exponentialDistributionBtn.Click += new System.EventHandler(this.exponentialDistributionBtn_Click);
            // 
            // simulationBtn
            // 
            this.simulationBtn.Location = new System.Drawing.Point(14, 98);
            this.simulationBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simulationBtn.Name = "simulationBtn";
            this.simulationBtn.Size = new System.Drawing.Size(156, 25);
            this.simulationBtn.TabIndex = 13;
            this.simulationBtn.Text = "Simulation";
            this.simulationBtn.UseVisualStyleBackColor = true;
            this.simulationBtn.Click += new System.EventHandler(this.simulationBtn_Click);
            // 
            // distributionInputGrpbox
            // 
            this.distributionInputGrpbox.Controls.Add(this.numbOfTrialsTbx);
            this.distributionInputGrpbox.Controls.Add(this.lambdaLb);
            this.distributionInputGrpbox.Controls.Add(this.numbTrialsLb);
            this.distributionInputGrpbox.Controls.Add(this.interArrivalLb);
            this.distributionInputGrpbox.Controls.Add(this.lambdaTbx);
            this.distributionInputGrpbox.Controls.Add(this.interArrivalTbx);
            this.distributionInputGrpbox.Location = new System.Drawing.Point(185, 6);
            this.distributionInputGrpbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.distributionInputGrpbox.Name = "distributionInputGrpbox";
            this.distributionInputGrpbox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.distributionInputGrpbox.Size = new System.Drawing.Size(248, 130);
            this.distributionInputGrpbox.TabIndex = 14;
            this.distributionInputGrpbox.TabStop = false;
            this.distributionInputGrpbox.Text = "Distribution Input";
            // 
            // poissonToStringListBox
            // 
            this.poissonToStringListBox.FormattingEnabled = true;
            this.poissonToStringListBox.Location = new System.Drawing.Point(1126, 145);
            this.poissonToStringListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.poissonToStringListBox.Name = "poissonToStringListBox";
            this.poissonToStringListBox.Size = new System.Drawing.Size(274, 277);
            this.poissonToStringListBox.TabIndex = 17;
            // 
            // poissonToStringLb
            // 
            this.poissonToStringLb.Location = new System.Drawing.Point(0, 0);
            this.poissonToStringLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.poissonToStringLb.Name = "poissonToStringLb";
            this.poissonToStringLb.Size = new System.Drawing.Size(50, 12);
            this.poissonToStringLb.TabIndex = 20;
            // 
            // poissonDistributionChart
            // 
            chartArea15.Name = "ChartArea1";
            this.poissonDistributionChart.ChartAreas.Add(chartArea15);
            legend15.Name = "Legend1";
            this.poissonDistributionChart.Legends.Add(legend15);
            this.poissonDistributionChart.Location = new System.Drawing.Point(6, 145);
            this.poissonDistributionChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.poissonDistributionChart.Name = "poissonDistributionChart";
            series29.ChartArea = "ChartArea1";
            series29.Legend = "Legend1";
            series29.Name = "Poisson distribution";
            series30.ChartArea = "ChartArea1";
            series30.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series30.Legend = "Legend1";
            series30.Name = "Poisson PMF";
            this.poissonDistributionChart.Series.Add(series29);
            this.poissonDistributionChart.Series.Add(series30);
            this.poissonDistributionChart.Size = new System.Drawing.Size(1110, 278);
            this.poissonDistributionChart.TabIndex = 6;
            this.poissonDistributionChart.Text = "chart1";
            // 
            // exponentialToStringListBox
            // 
            this.exponentialToStringListBox.FormattingEnabled = true;
            this.exponentialToStringListBox.Location = new System.Drawing.Point(1126, 433);
            this.exponentialToStringListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exponentialToStringListBox.Name = "exponentialToStringListBox";
            this.exponentialToStringListBox.Size = new System.Drawing.Size(274, 277);
            this.exponentialToStringListBox.TabIndex = 18;
            // 
            // simulationToStringListBox
            // 
            this.simulationToStringListBox.FormattingEnabled = true;
            this.simulationToStringListBox.Location = new System.Drawing.Point(1126, 719);
            this.simulationToStringListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simulationToStringListBox.Name = "simulationToStringListBox";
            this.simulationToStringListBox.Size = new System.Drawing.Size(274, 277);
            this.simulationToStringListBox.TabIndex = 19;
            // 
            // scalingTrackBar
            // 
            this.scalingTrackBar.LargeChange = 10;
            this.scalingTrackBar.Location = new System.Drawing.Point(452, 47);
            this.scalingTrackBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scalingTrackBar.Maximum = 3;
            this.scalingTrackBar.Minimum = 1;
            this.scalingTrackBar.Name = "scalingTrackBar";
            this.scalingTrackBar.Size = new System.Drawing.Size(218, 45);
            this.scalingTrackBar.TabIndex = 21;
            this.scalingTrackBar.Value = 1;
            // 
            // exponentialInfoLb
            // 
            this.exponentialInfoLb.AutoSize = true;
            this.exponentialInfoLb.Location = new System.Drawing.Point(492, 17);
            this.exponentialInfoLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.exponentialInfoLb.Name = "exponentialInfoLb";
            this.exponentialInfoLb.Size = new System.Drawing.Size(126, 13);
            this.exponentialInfoLb.TabIndex = 22;
            this.exponentialInfoLb.Text = "Exponential bin accuracy";
            // 
            // binIncrementTooltip
            // 
            this.binIncrementTooltip.BackColor = System.Drawing.Color.Transparent;
            this.binIncrementTooltip.ShowAlways = true;
            // 
            // bin10Lb
            // 
            this.bin10Lb.AutoSize = true;
            this.bin10Lb.Location = new System.Drawing.Point(456, 98);
            this.bin10Lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bin10Lb.Name = "bin10Lb";
            this.bin10Lb.Size = new System.Drawing.Size(19, 13);
            this.bin10Lb.TabIndex = 24;
            this.bin10Lb.Text = "10";
            // 
            // bin100Lb
            // 
            this.bin100Lb.AutoSize = true;
            this.bin100Lb.Location = new System.Drawing.Point(548, 98);
            this.bin100Lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bin100Lb.Name = "bin100Lb";
            this.bin100Lb.Size = new System.Drawing.Size(25, 13);
            this.bin100Lb.TabIndex = 25;
            this.bin100Lb.Text = "100";
            // 
            // bin1000Lb
            // 
            this.bin1000Lb.AutoSize = true;
            this.bin1000Lb.Location = new System.Drawing.Point(646, 96);
            this.bin1000Lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bin1000Lb.Name = "bin1000Lb";
            this.bin1000Lb.Size = new System.Drawing.Size(31, 13);
            this.bin1000Lb.TabIndex = 26;
            this.bin1000Lb.Text = "1000";
            // 
            // poissonStatisticsLb
            // 
            this.poissonStatisticsLb.AutoSize = true;
            this.poissonStatisticsLb.BackColor = System.Drawing.Color.Transparent;
            this.poissonStatisticsLb.Location = new System.Drawing.Point(920, 218);
            this.poissonStatisticsLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.poissonStatisticsLb.Name = "poissonStatisticsLb";
            this.poissonStatisticsLb.Size = new System.Drawing.Size(44, 13);
            this.poissonStatisticsLb.TabIndex = 28;
            this.poissonStatisticsLb.Text = "Poisson";
            // 
            // exponentialStatisticsLb
            // 
            this.exponentialStatisticsLb.AutoSize = true;
            this.exponentialStatisticsLb.Location = new System.Drawing.Point(920, 506);
            this.exponentialStatisticsLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.exponentialStatisticsLb.Name = "exponentialStatisticsLb";
            this.exponentialStatisticsLb.Size = new System.Drawing.Size(62, 13);
            this.exponentialStatisticsLb.TabIndex = 29;
            this.exponentialStatisticsLb.Text = "Exponential";
            // 
            // simulationStatisticsLb
            // 
            this.simulationStatisticsLb.AutoSize = true;
            this.simulationStatisticsLb.Location = new System.Drawing.Point(948, 788);
            this.simulationStatisticsLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.simulationStatisticsLb.Name = "simulationStatisticsLb";
            this.simulationStatisticsLb.Size = new System.Drawing.Size(55, 13);
            this.simulationStatisticsLb.TabIndex = 30;
            this.simulationStatisticsLb.Text = "Simulation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1404, 989);
            this.Controls.Add(this.simulationStatisticsLb);
            this.Controls.Add(this.exponentialStatisticsLb);
            this.Controls.Add(this.poissonStatisticsLb);
            this.Controls.Add(this.bin1000Lb);
            this.Controls.Add(this.bin100Lb);
            this.Controls.Add(this.bin10Lb);
            this.Controls.Add(this.exponentialInfoLb);
            this.Controls.Add(this.scalingTrackBar);
            this.Controls.Add(this.simulationToStringListBox);
            this.Controls.Add(this.exponentialToStringListBox);
            this.Controls.Add(this.poissonToStringListBox);
            this.Controls.Add(this.poissonToStringLb);
            this.Controls.Add(this.distributionInputGrpbox);
            this.Controls.Add(this.simulationBtn);
            this.Controls.Add(this.exponentialDistributionBtn);
            this.Controls.Add(this.poissonDistributionBtn);
            this.Controls.Add(this.simulationChart);
            this.Controls.Add(this.exponentialDistributionChart);
            this.Controls.Add(this.poissonDistributionChart);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Complex Statistical Distribution\'s Application";
            ((System.ComponentModel.ISupportInitialize)(this.exponentialDistributionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationChart)).EndInit();
            this.distributionInputGrpbox.ResumeLayout(false);
            this.distributionInputGrpbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poissonDistributionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lambdaLb;
        private System.Windows.Forms.Label numbTrialsLb;
        private System.Windows.Forms.Label interArrivalLb;
        private System.Windows.Forms.TextBox lambdaTbx;
        private System.Windows.Forms.TextBox numbOfTrialsTbx;
        private System.Windows.Forms.TextBox interArrivalTbx;
        private System.Windows.Forms.DataVisualization.Charting.Chart exponentialDistributionChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart simulationChart;
        private System.Windows.Forms.Button poissonDistributionBtn;
        private System.Windows.Forms.Button exponentialDistributionBtn;
        private System.Windows.Forms.Button simulationBtn;
        private System.Windows.Forms.GroupBox distributionInputGrpbox;
        private System.Windows.Forms.ListBox poissonToStringListBox;
        private System.Windows.Forms.Label poissonToStringLb;
        private System.Windows.Forms.DataVisualization.Charting.Chart poissonDistributionChart;
        private System.Windows.Forms.ListBox exponentialToStringListBox;
        private System.Windows.Forms.ListBox simulationToStringListBox;
        private System.Windows.Forms.TrackBar scalingTrackBar;
        private System.Windows.Forms.Label exponentialInfoLb;
        private System.Windows.Forms.ToolTip binIncrementTooltip;
        private System.Windows.Forms.Label bin10Lb;
        private System.Windows.Forms.Label bin100Lb;
        private System.Windows.Forms.Label bin1000Lb;
        private System.Windows.Forms.Label poissonStatisticsLb;
        private System.Windows.Forms.Label exponentialStatisticsLb;
        private System.Windows.Forms.Label simulationStatisticsLb;
    }
}

