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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.bin1Lb = new System.Windows.Forms.Label();
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
            this.lambdaLb.Location = new System.Drawing.Point(25, 68);
            this.lambdaLb.Name = "lambdaLb";
            this.lambdaLb.Size = new System.Drawing.Size(95, 25);
            this.lambdaLb.TabIndex = 0;
            this.lambdaLb.Text = "Lambda:";
            // 
            // numbTrialsLb
            // 
            this.numbTrialsLb.AutoSize = true;
            this.numbTrialsLb.Location = new System.Drawing.Point(25, 120);
            this.numbTrialsLb.Name = "numbTrialsLb";
            this.numbTrialsLb.Size = new System.Drawing.Size(180, 25);
            this.numbTrialsLb.TabIndex = 1;
            this.numbTrialsLb.Text = "Number Of Trials:";
            // 
            // interArrivalLb
            // 
            this.interArrivalLb.AutoSize = true;
            this.interArrivalLb.Location = new System.Drawing.Point(25, 182);
            this.interArrivalLb.Name = "interArrivalLb";
            this.interArrivalLb.Size = new System.Drawing.Size(121, 25);
            this.interArrivalLb.TabIndex = 2;
            this.interArrivalLb.Text = "Interval (T):";
            // 
            // lambdaTbx
            // 
            this.lambdaTbx.Location = new System.Drawing.Point(231, 58);
            this.lambdaTbx.Name = "lambdaTbx";
            this.lambdaTbx.Size = new System.Drawing.Size(223, 31);
            this.lambdaTbx.TabIndex = 3;
            // 
            // numbOfTrialsTbx
            // 
            this.numbOfTrialsTbx.Location = new System.Drawing.Point(231, 114);
            this.numbOfTrialsTbx.Name = "numbOfTrialsTbx";
            this.numbOfTrialsTbx.Size = new System.Drawing.Size(223, 31);
            this.numbOfTrialsTbx.TabIndex = 4;
            // 
            // interArrivalTbx
            // 
            this.interArrivalTbx.Location = new System.Drawing.Point(231, 176);
            this.interArrivalTbx.Name = "interArrivalTbx";
            this.interArrivalTbx.Size = new System.Drawing.Size(223, 31);
            this.interArrivalTbx.TabIndex = 5;
            // 
            // exponentialDistributionChart
            // 
            chartArea4.Name = "ChartArea1";
            this.exponentialDistributionChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.exponentialDistributionChart.Legends.Add(legend4);
            this.exponentialDistributionChart.Location = new System.Drawing.Point(12, 864);
            this.exponentialDistributionChart.Name = "exponentialDistributionChart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Exponential Distribution";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Exponential PMF";
            this.exponentialDistributionChart.Series.Add(series7);
            this.exponentialDistributionChart.Series.Add(series8);
            this.exponentialDistributionChart.Size = new System.Drawing.Size(2220, 534);
            this.exponentialDistributionChart.TabIndex = 9;
            this.exponentialDistributionChart.Text = "chart2";
            // 
            // simulationChart
            // 
            chartArea5.Name = "ChartArea1";
            this.simulationChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.simulationChart.Legends.Add(legend5);
            this.simulationChart.Location = new System.Drawing.Point(12, 1413);
            this.simulationChart.Name = "simulationChart";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Simulation";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "Simulation PMF";
            this.simulationChart.Series.Add(series9);
            this.simulationChart.Series.Add(series10);
            this.simulationChart.Size = new System.Drawing.Size(2220, 534);
            this.simulationChart.TabIndex = 10;
            this.simulationChart.Text = "chart3";
            // 
            // poissonDistributionBtn
            // 
            this.poissonDistributionBtn.Location = new System.Drawing.Point(28, 52);
            this.poissonDistributionBtn.Name = "poissonDistributionBtn";
            this.poissonDistributionBtn.Size = new System.Drawing.Size(311, 49);
            this.poissonDistributionBtn.TabIndex = 11;
            this.poissonDistributionBtn.Text = "Poisson";
            this.poissonDistributionBtn.UseVisualStyleBackColor = true;
            this.poissonDistributionBtn.Click += new System.EventHandler(this.poissonDistributionBtn_Click);
            // 
            // exponentialDistributionBtn
            // 
            this.exponentialDistributionBtn.Location = new System.Drawing.Point(28, 119);
            this.exponentialDistributionBtn.Name = "exponentialDistributionBtn";
            this.exponentialDistributionBtn.Size = new System.Drawing.Size(311, 49);
            this.exponentialDistributionBtn.TabIndex = 12;
            this.exponentialDistributionBtn.Text = "Exponential";
            this.exponentialDistributionBtn.UseVisualStyleBackColor = true;
            this.exponentialDistributionBtn.Click += new System.EventHandler(this.exponentialDistributionBtn_Click);
            // 
            // simulationBtn
            // 
            this.simulationBtn.Location = new System.Drawing.Point(28, 188);
            this.simulationBtn.Name = "simulationBtn";
            this.simulationBtn.Size = new System.Drawing.Size(311, 49);
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
            this.distributionInputGrpbox.Location = new System.Drawing.Point(370, 12);
            this.distributionInputGrpbox.Name = "distributionInputGrpbox";
            this.distributionInputGrpbox.Size = new System.Drawing.Size(497, 250);
            this.distributionInputGrpbox.TabIndex = 14;
            this.distributionInputGrpbox.TabStop = false;
            this.distributionInputGrpbox.Text = "Distribution Input";
            // 
            // poissonToStringListBox
            // 
            this.poissonToStringListBox.FormattingEnabled = true;
            this.poissonToStringListBox.ItemHeight = 25;
            this.poissonToStringListBox.Location = new System.Drawing.Point(2252, 314);
            this.poissonToStringListBox.Name = "poissonToStringListBox";
            this.poissonToStringListBox.Size = new System.Drawing.Size(543, 529);
            this.poissonToStringListBox.TabIndex = 17;
            // 
            // poissonToStringLb
            // 
            this.poissonToStringLb.Location = new System.Drawing.Point(0, 0);
            this.poissonToStringLb.Name = "poissonToStringLb";
            this.poissonToStringLb.Size = new System.Drawing.Size(100, 23);
            this.poissonToStringLb.TabIndex = 20;
            // 
            // poissonDistributionChart
            // 
            chartArea6.Name = "ChartArea1";
            this.poissonDistributionChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.poissonDistributionChart.Legends.Add(legend6);
            this.poissonDistributionChart.Location = new System.Drawing.Point(12, 314);
            this.poissonDistributionChart.Name = "poissonDistributionChart";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Poisson distribution";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "Poisson PMF";
            this.poissonDistributionChart.Series.Add(series11);
            this.poissonDistributionChart.Series.Add(series12);
            this.poissonDistributionChart.Size = new System.Drawing.Size(2220, 534);
            this.poissonDistributionChart.TabIndex = 6;
            this.poissonDistributionChart.Text = "chart1";
            // 
            // exponentialToStringListBox
            // 
            this.exponentialToStringListBox.FormattingEnabled = true;
            this.exponentialToStringListBox.ItemHeight = 25;
            this.exponentialToStringListBox.Location = new System.Drawing.Point(2252, 869);
            this.exponentialToStringListBox.Name = "exponentialToStringListBox";
            this.exponentialToStringListBox.Size = new System.Drawing.Size(543, 529);
            this.exponentialToStringListBox.TabIndex = 18;
            // 
            // simulationToStringListBox
            // 
            this.simulationToStringListBox.FormattingEnabled = true;
            this.simulationToStringListBox.ItemHeight = 25;
            this.simulationToStringListBox.Location = new System.Drawing.Point(2252, 1418);
            this.simulationToStringListBox.Name = "simulationToStringListBox";
            this.simulationToStringListBox.Size = new System.Drawing.Size(543, 529);
            this.simulationToStringListBox.TabIndex = 19;
            // 
            // scalingTrackBar
            // 
            this.scalingTrackBar.LargeChange = 10;
            this.scalingTrackBar.Location = new System.Drawing.Point(904, 91);
            this.scalingTrackBar.Maximum = 4;
            this.scalingTrackBar.Minimum = 1;
            this.scalingTrackBar.Name = "scalingTrackBar";
            this.scalingTrackBar.Size = new System.Drawing.Size(436, 90);
            this.scalingTrackBar.TabIndex = 21;
            this.scalingTrackBar.Value = 1;
            // 
            // exponentialInfoLb
            // 
            this.exponentialInfoLb.AutoSize = true;
            this.exponentialInfoLb.Location = new System.Drawing.Point(983, 32);
            this.exponentialInfoLb.Name = "exponentialInfoLb";
            this.exponentialInfoLb.Size = new System.Drawing.Size(279, 25);
            this.exponentialInfoLb.TabIndex = 22;
            this.exponentialInfoLb.Text = "Exponential bin incrementer";
            // 
            // binIncrementTooltip
            // 
            this.binIncrementTooltip.BackColor = System.Drawing.Color.Transparent;
            this.binIncrementTooltip.ShowAlways = true;
            // 
            // bin1Lb
            // 
            this.bin1Lb.AutoSize = true;
            this.bin1Lb.Location = new System.Drawing.Point(917, 184);
            this.bin1Lb.Name = "bin1Lb";
            this.bin1Lb.Size = new System.Drawing.Size(24, 25);
            this.bin1Lb.TabIndex = 23;
            this.bin1Lb.Text = "1";
            // 
            // bin10Lb
            // 
            this.bin10Lb.AutoSize = true;
            this.bin10Lb.Location = new System.Drawing.Point(1039, 184);
            this.bin10Lb.Name = "bin10Lb";
            this.bin10Lb.Size = new System.Drawing.Size(36, 25);
            this.bin10Lb.TabIndex = 24;
            this.bin10Lb.Text = "10";
            // 
            // bin100Lb
            // 
            this.bin100Lb.AutoSize = true;
            this.bin100Lb.Location = new System.Drawing.Point(1162, 184);
            this.bin100Lb.Name = "bin100Lb";
            this.bin100Lb.Size = new System.Drawing.Size(48, 25);
            this.bin100Lb.TabIndex = 25;
            this.bin100Lb.Text = "100";
            // 
            // bin1000Lb
            // 
            this.bin1000Lb.AutoSize = true;
            this.bin1000Lb.Location = new System.Drawing.Point(1291, 184);
            this.bin1000Lb.Name = "bin1000Lb";
            this.bin1000Lb.Size = new System.Drawing.Size(60, 25);
            this.bin1000Lb.TabIndex = 26;
            this.bin1000Lb.Text = "1000";
            // 
            // poissonStatisticsLb
            // 
            this.poissonStatisticsLb.AutoSize = true;
            this.poissonStatisticsLb.BackColor = System.Drawing.Color.Transparent;
            this.poissonStatisticsLb.Location = new System.Drawing.Point(1840, 420);
            this.poissonStatisticsLb.Name = "poissonStatisticsLb";
            this.poissonStatisticsLb.Size = new System.Drawing.Size(89, 25);
            this.poissonStatisticsLb.TabIndex = 28;
            this.poissonStatisticsLb.Text = "Poisson";
            // 
            // exponentialStatisticsLb
            // 
            this.exponentialStatisticsLb.AutoSize = true;
            this.exponentialStatisticsLb.Location = new System.Drawing.Point(1840, 973);
            this.exponentialStatisticsLb.Name = "exponentialStatisticsLb";
            this.exponentialStatisticsLb.Size = new System.Drawing.Size(125, 25);
            this.exponentialStatisticsLb.TabIndex = 29;
            this.exponentialStatisticsLb.Text = "Exponential";
            // 
            // simulationStatisticsLb
            // 
            this.simulationStatisticsLb.AutoSize = true;
            this.simulationStatisticsLb.Location = new System.Drawing.Point(1895, 1516);
            this.simulationStatisticsLb.Name = "simulationStatisticsLb";
            this.simulationStatisticsLb.Size = new System.Drawing.Size(112, 25);
            this.simulationStatisticsLb.TabIndex = 30;
            this.simulationStatisticsLb.Text = "Simulation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2807, 1959);
            this.Controls.Add(this.simulationStatisticsLb);
            this.Controls.Add(this.exponentialStatisticsLb);
            this.Controls.Add(this.poissonStatisticsLb);
            this.Controls.Add(this.bin1000Lb);
            this.Controls.Add(this.bin100Lb);
            this.Controls.Add(this.bin10Lb);
            this.Controls.Add(this.bin1Lb);
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
            this.Name = "Form1";
            this.Text = "\"Complex Statistical Distribution\'s Application\"";
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
        private System.Windows.Forms.Label bin1Lb;
        private System.Windows.Forms.Label bin10Lb;
        private System.Windows.Forms.Label bin100Lb;
        private System.Windows.Forms.Label bin1000Lb;
        private System.Windows.Forms.Label poissonStatisticsLb;
        private System.Windows.Forms.Label exponentialStatisticsLb;
        private System.Windows.Forms.Label simulationStatisticsLb;
    }
}

