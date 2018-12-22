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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            ((System.ComponentModel.ISupportInitialize)(this.exponentialDistributionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationChart)).BeginInit();
            this.distributionInputGrpbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poissonDistributionChart)).BeginInit();
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
            chartArea1.Name = "ChartArea1";
            this.exponentialDistributionChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.exponentialDistributionChart.Legends.Add(legend1);
            this.exponentialDistributionChart.Location = new System.Drawing.Point(12, 864);
            this.exponentialDistributionChart.Name = "exponentialDistributionChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Exponential Distribution";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Exponential PMF";
            this.exponentialDistributionChart.Series.Add(series1);
            this.exponentialDistributionChart.Series.Add(series2);
            this.exponentialDistributionChart.Size = new System.Drawing.Size(2220, 534);
            this.exponentialDistributionChart.TabIndex = 9;
            this.exponentialDistributionChart.Text = "chart2";
            // 
            // simulationChart
            // 
            chartArea2.Name = "ChartArea1";
            this.simulationChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.simulationChart.Legends.Add(legend2);
            this.simulationChart.Location = new System.Drawing.Point(12, 1413);
            this.simulationChart.Name = "simulationChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Simulation";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Simulation PMF";
            this.simulationChart.Series.Add(series3);
            this.simulationChart.Series.Add(series4);
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
            this.poissonToStringLb.AutoSize = true;
            this.poissonToStringLb.Location = new System.Drawing.Point(1810, 388);
            this.poissonToStringLb.Name = "poissonToStringLb";
            this.poissonToStringLb.Size = new System.Drawing.Size(0, 25);
            this.poissonToStringLb.TabIndex = 6;
            this.poissonToStringLb.Click += new System.EventHandler(this.poissonToStringLb_Click);
            // 
            // poissonDistributionChart
            // 
            chartArea3.Name = "ChartArea1";
            this.poissonDistributionChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.poissonDistributionChart.Legends.Add(legend3);
            this.poissonDistributionChart.Location = new System.Drawing.Point(12, 314);
            this.poissonDistributionChart.Name = "poissonDistributionChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Poisson distribution";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Poisson PMF";
            this.poissonDistributionChart.Series.Add(series5);
            this.poissonDistributionChart.Series.Add(series6);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2807, 1959);
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
    }
}

