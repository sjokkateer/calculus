﻿namespace eXpressionParsing
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.expressionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.parseRbtn = new System.Windows.Forms.RadioButton();
            this.differentiateRbtn = new System.Windows.Forms.RadioButton();
            this.textResultGrpBox = new System.Windows.Forms.GroupBox();
            this.areaLb = new System.Windows.Forms.Label();
            this.derivativeLb = new System.Windows.Forms.Label();
            this.expressionLb = new System.Windows.Forms.Label();
            this.expressionTbx = new System.Windows.Forms.TextBox();
            this.expressionInputLb = new System.Windows.Forms.Label();
            this.processBtn = new System.Windows.Forms.Button();
            this.integralRbtn = new System.Windows.Forms.RadioButton();
            this.stepSizeLb = new System.Windows.Forms.Label();
            this.riemannIntervalTb = new System.Windows.Forms.TextBox();
            this.intervalLb = new System.Windows.Forms.Label();
            this.intervalALb = new System.Windows.Forms.Label();
            this.intervalBTbx = new System.Windows.Forms.TextBox();
            this.intervalATbx = new System.Windows.Forms.TextBox();
            this.mcLaurinGrpBox = new System.Windows.Forms.GroupBox();
            this.nPolynomialTbx = new System.Windows.Forms.TextBox();
            this.nPolynomiallb = new System.Windows.Forms.Label();
            this.btnQuotientMcLaurin = new System.Windows.Forms.Button();
            this.btnAnalyticalMcLaurin = new System.Windows.Forms.Button();
            this.intervalGrpBox = new System.Windows.Forms.GroupBox();
            this.yMaxTbx = new System.Windows.Forms.TextBox();
            this.yMinTbx = new System.Windows.Forms.TextBox();
            this.xMaxTbx = new System.Windows.Forms.TextBox();
            this.xMinTbx = new System.Windows.Forms.TextBox();
            this.yMaxLb = new System.Windows.Forms.Label();
            this.yMinLb = new System.Windows.Forms.Label();
            this.xMaxLb = new System.Windows.Forms.Label();
            this.xMinLb = new System.Windows.Forms.Label();
            this.intergralGroupBox = new System.Windows.Forms.GroupBox();
            this.nPolynomialGroupBox = new System.Windows.Forms.GroupBox();
            this.coordinatesListBox = new System.Windows.Forms.ListBox();
            this.coordinatesBtn = new System.Windows.Forms.Button();
            this.polynomialInputPanel = new System.Windows.Forms.Panel();
            this.polynomialCoordinatesPanel = new System.Windows.Forms.Panel();
            this.coordinatesXTbx = new System.Windows.Forms.TextBox();
            this.coordinatesYLb = new System.Windows.Forms.Label();
            this.coordinatesYTbx = new System.Windows.Forms.TextBox();
            this.coordinatesXLb = new System.Windows.Forms.Label();
            this.addCoordinateBtn = new System.Windows.Forms.Button();
            this.plotPolynomialBtn = new System.Windows.Forms.Button();
            this.cursorXLb = new System.Windows.Forms.Label();
            this.cursorYLb = new System.Windows.Forms.Label();
            this.rescaleChartAxisBtn = new System.Windows.Forms.Button();
            this.differenceQuotientBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.textResultGrpBox.SuspendLayout();
            this.mcLaurinGrpBox.SuspendLayout();
            this.intervalGrpBox.SuspendLayout();
            this.intergralGroupBox.SuspendLayout();
            this.nPolynomialGroupBox.SuspendLayout();
            this.polynomialInputPanel.SuspendLayout();
            this.polynomialCoordinatesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // expressionChart
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.Maximum = 10D;
            chartArea1.AxisX.Minimum = -10D;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.Interval = 2D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = -10D;
            chartArea1.Name = "ChartArea1";
            this.expressionChart.ChartAreas.Add(chartArea1);
            this.expressionChart.Location = new System.Drawing.Point(416, 304);
            this.expressionChart.Margin = new System.Windows.Forms.Padding(4);
            this.expressionChart.Name = "expressionChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Name = "PlaceHolder";
            dataPoint1.IsEmpty = true;
            series1.Points.Add(dataPoint1);
            this.expressionChart.Series.Add(series1);
            this.expressionChart.Size = new System.Drawing.Size(1268, 908);
            this.expressionChart.TabIndex = 4;
            this.expressionChart.Text = "Expression Chart";
            this.expressionChart.Paint += new System.Windows.Forms.PaintEventHandler(this.expressionChart_Paint);
            this.expressionChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.expressionChart_MouseClick);
            this.expressionChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.expressionChart_MouseMove);
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Location = new System.Drawing.Point(1692, 304);
            this.graphPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(2500, 2000);
            this.graphPictureBox.TabIndex = 5;
            this.graphPictureBox.TabStop = false;
            // 
            // parseRbtn
            // 
            this.parseRbtn.AutoSize = true;
            this.parseRbtn.Checked = true;
            this.parseRbtn.Location = new System.Drawing.Point(26, 15);
            this.parseRbtn.Margin = new System.Windows.Forms.Padding(4);
            this.parseRbtn.Name = "parseRbtn";
            this.parseRbtn.Size = new System.Drawing.Size(99, 29);
            this.parseRbtn.TabIndex = 0;
            this.parseRbtn.TabStop = true;
            this.parseRbtn.Text = "Parse";
            this.parseRbtn.UseVisualStyleBackColor = true;
            this.parseRbtn.CheckedChanged += new System.EventHandler(this.parseRbtn_CheckedChanged);
            // 
            // differentiateRbtn
            // 
            this.differentiateRbtn.AutoSize = true;
            this.differentiateRbtn.Location = new System.Drawing.Point(26, 54);
            this.differentiateRbtn.Margin = new System.Windows.Forms.Padding(4);
            this.differentiateRbtn.Name = "differentiateRbtn";
            this.differentiateRbtn.Size = new System.Drawing.Size(159, 29);
            this.differentiateRbtn.TabIndex = 1;
            this.differentiateRbtn.Text = "Differentiate";
            this.differentiateRbtn.UseVisualStyleBackColor = true;
            this.differentiateRbtn.CheckedChanged += new System.EventHandler(this.differentiateRbtn_CheckedChanged);
            // 
            // textResultGrpBox
            // 
            this.textResultGrpBox.Controls.Add(this.areaLb);
            this.textResultGrpBox.Controls.Add(this.derivativeLb);
            this.textResultGrpBox.Controls.Add(this.expressionLb);
            this.textResultGrpBox.Location = new System.Drawing.Point(416, 1215);
            this.textResultGrpBox.Margin = new System.Windows.Forms.Padding(4);
            this.textResultGrpBox.Name = "textResultGrpBox";
            this.textResultGrpBox.Padding = new System.Windows.Forms.Padding(4);
            this.textResultGrpBox.Size = new System.Drawing.Size(1268, 313);
            this.textResultGrpBox.TabIndex = 12;
            this.textResultGrpBox.TabStop = false;
            this.textResultGrpBox.Text = "Text results";
            // 
            // areaLb
            // 
            this.areaLb.AutoSize = true;
            this.areaLb.Location = new System.Drawing.Point(28, 133);
            this.areaLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.areaLb.Name = "areaLb";
            this.areaLb.Size = new System.Drawing.Size(168, 25);
            this.areaLb.TabIndex = 21;
            this.areaLb.Text = "Estimated area: ";
            // 
            // derivativeLb
            // 
            this.derivativeLb.AutoSize = true;
            this.derivativeLb.Location = new System.Drawing.Point(24, 90);
            this.derivativeLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.derivativeLb.Name = "derivativeLb";
            this.derivativeLb.Size = new System.Drawing.Size(120, 25);
            this.derivativeLb.TabIndex = 1;
            this.derivativeLb.Text = "Derivative: ";
            // 
            // expressionLb
            // 
            this.expressionLb.AutoSize = true;
            this.expressionLb.Location = new System.Drawing.Point(24, 46);
            this.expressionLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.expressionLb.Name = "expressionLb";
            this.expressionLb.Size = new System.Drawing.Size(131, 25);
            this.expressionLb.TabIndex = 0;
            this.expressionLb.Text = "Expression: ";
            // 
            // expressionTbx
            // 
            this.expressionTbx.Location = new System.Drawing.Point(228, 42);
            this.expressionTbx.Margin = new System.Windows.Forms.Padding(4);
            this.expressionTbx.Name = "expressionTbx";
            this.expressionTbx.Size = new System.Drawing.Size(716, 31);
            this.expressionTbx.TabIndex = 3;
            // 
            // expressionInputLb
            // 
            this.expressionInputLb.AutoSize = true;
            this.expressionInputLb.Location = new System.Drawing.Point(224, 10);
            this.expressionInputLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.expressionInputLb.Name = "expressionInputLb";
            this.expressionInputLb.Size = new System.Drawing.Size(176, 25);
            this.expressionInputLb.TabIndex = 10;
            this.expressionInputLb.Text = "Input expression:";
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(224, 83);
            this.processBtn.Margin = new System.Windows.Forms.Padding(4);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(720, 48);
            this.processBtn.TabIndex = 4;
            this.processBtn.Text = "Process Expression";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // integralRbtn
            // 
            this.integralRbtn.AutoSize = true;
            this.integralRbtn.Location = new System.Drawing.Point(26, 92);
            this.integralRbtn.Margin = new System.Windows.Forms.Padding(4);
            this.integralRbtn.Name = "integralRbtn";
            this.integralRbtn.Size = new System.Drawing.Size(193, 29);
            this.integralRbtn.TabIndex = 2;
            this.integralRbtn.TabStop = true;
            this.integralRbtn.Text = "Definite integral";
            this.integralRbtn.UseVisualStyleBackColor = true;
            this.integralRbtn.CheckedChanged += new System.EventHandler(this.integralRbtn_CheckedChanged);
            // 
            // stepSizeLb
            // 
            this.stepSizeLb.Location = new System.Drawing.Point(224, 56);
            this.stepSizeLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stepSizeLb.Name = "stepSizeLb";
            this.stepSizeLb.Size = new System.Drawing.Size(232, 42);
            this.stepSizeLb.TabIndex = 0;
            this.stepSizeLb.Text = "Number of intervals:";
            // 
            // riemannIntervalTb
            // 
            this.riemannIntervalTb.Location = new System.Drawing.Point(228, 87);
            this.riemannIntervalTb.Margin = new System.Windows.Forms.Padding(4);
            this.riemannIntervalTb.Name = "riemannIntervalTb";
            this.riemannIntervalTb.Size = new System.Drawing.Size(188, 31);
            this.riemannIntervalTb.TabIndex = 2;
            // 
            // intervalLb
            // 
            this.intervalLb.Location = new System.Drawing.Point(6, 92);
            this.intervalLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.intervalLb.Name = "intervalLb";
            this.intervalLb.Size = new System.Drawing.Size(64, 35);
            this.intervalLb.TabIndex = 3;
            this.intervalLb.Text = "b:";
            // 
            // intervalALb
            // 
            this.intervalALb.Location = new System.Drawing.Point(6, 40);
            this.intervalALb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.intervalALb.Name = "intervalALb";
            this.intervalALb.Size = new System.Drawing.Size(56, 31);
            this.intervalALb.TabIndex = 6;
            this.intervalALb.Text = "a:";
            // 
            // intervalBTbx
            // 
            this.intervalBTbx.Location = new System.Drawing.Point(44, 88);
            this.intervalBTbx.Margin = new System.Windows.Forms.Padding(4);
            this.intervalBTbx.Name = "intervalBTbx";
            this.intervalBTbx.Size = new System.Drawing.Size(152, 31);
            this.intervalBTbx.TabIndex = 1;
            // 
            // intervalATbx
            // 
            this.intervalATbx.Location = new System.Drawing.Point(44, 40);
            this.intervalATbx.Margin = new System.Windows.Forms.Padding(4);
            this.intervalATbx.Name = "intervalATbx";
            this.intervalATbx.Size = new System.Drawing.Size(152, 31);
            this.intervalATbx.TabIndex = 0;
            // 
            // mcLaurinGrpBox
            // 
            this.mcLaurinGrpBox.Controls.Add(this.nPolynomialTbx);
            this.mcLaurinGrpBox.Controls.Add(this.nPolynomiallb);
            this.mcLaurinGrpBox.Controls.Add(this.btnQuotientMcLaurin);
            this.mcLaurinGrpBox.Controls.Add(this.btnAnalyticalMcLaurin);
            this.mcLaurinGrpBox.Location = new System.Drawing.Point(26, 485);
            this.mcLaurinGrpBox.Margin = new System.Windows.Forms.Padding(4);
            this.mcLaurinGrpBox.Name = "mcLaurinGrpBox";
            this.mcLaurinGrpBox.Padding = new System.Windows.Forms.Padding(4);
            this.mcLaurinGrpBox.Size = new System.Drawing.Size(374, 223);
            this.mcLaurinGrpBox.TabIndex = 18;
            this.mcLaurinGrpBox.TabStop = false;
            this.mcLaurinGrpBox.Text = "Maclaurin Polynomial";
            // 
            // nPolynomialTbx
            // 
            this.nPolynomialTbx.Location = new System.Drawing.Point(164, 42);
            this.nPolynomialTbx.Margin = new System.Windows.Forms.Padding(4);
            this.nPolynomialTbx.Name = "nPolynomialTbx";
            this.nPolynomialTbx.Size = new System.Drawing.Size(192, 31);
            this.nPolynomialTbx.TabIndex = 0;
            this.nPolynomialTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nPolynomialTbx_KeyPress);
            // 
            // nPolynomiallb
            // 
            this.nPolynomiallb.AutoSize = true;
            this.nPolynomiallb.Location = new System.Drawing.Point(16, 46);
            this.nPolynomiallb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nPolynomiallb.Name = "nPolynomiallb";
            this.nPolynomiallb.Size = new System.Drawing.Size(141, 25);
            this.nPolynomiallb.TabIndex = 30;
            this.nPolynomiallb.Text = "n Polynomial:";
            // 
            // btnQuotientMcLaurin
            // 
            this.btnQuotientMcLaurin.Location = new System.Drawing.Point(28, 156);
            this.btnQuotientMcLaurin.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuotientMcLaurin.Name = "btnQuotientMcLaurin";
            this.btnQuotientMcLaurin.Size = new System.Drawing.Size(318, 48);
            this.btnQuotientMcLaurin.TabIndex = 2;
            this.btnQuotientMcLaurin.Text = "By Newton\'s Quotient";
            this.btnQuotientMcLaurin.UseVisualStyleBackColor = true;
            this.btnQuotientMcLaurin.Click += new System.EventHandler(this.btnQuotientMcLaurin_Click);
            // 
            // btnAnalyticalMcLaurin
            // 
            this.btnAnalyticalMcLaurin.Location = new System.Drawing.Point(28, 90);
            this.btnAnalyticalMcLaurin.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalyticalMcLaurin.Name = "btnAnalyticalMcLaurin";
            this.btnAnalyticalMcLaurin.Size = new System.Drawing.Size(318, 48);
            this.btnAnalyticalMcLaurin.TabIndex = 1;
            this.btnAnalyticalMcLaurin.Text = "Analytical";
            this.btnAnalyticalMcLaurin.UseVisualStyleBackColor = true;
            this.btnAnalyticalMcLaurin.Click += new System.EventHandler(this.btnAnalyticalMcLaurin_Click);
            // 
            // intervalGrpBox
            // 
            this.intervalGrpBox.Controls.Add(this.rescaleChartAxisBtn);
            this.intervalGrpBox.Controls.Add(this.yMaxTbx);
            this.intervalGrpBox.Controls.Add(this.yMinTbx);
            this.intervalGrpBox.Controls.Add(this.xMaxTbx);
            this.intervalGrpBox.Controls.Add(this.xMinTbx);
            this.intervalGrpBox.Controls.Add(this.yMaxLb);
            this.intervalGrpBox.Controls.Add(this.yMinLb);
            this.intervalGrpBox.Controls.Add(this.xMaxLb);
            this.intervalGrpBox.Controls.Add(this.xMinLb);
            this.intervalGrpBox.Location = new System.Drawing.Point(26, 162);
            this.intervalGrpBox.Margin = new System.Windows.Forms.Padding(4);
            this.intervalGrpBox.Name = "intervalGrpBox";
            this.intervalGrpBox.Padding = new System.Windows.Forms.Padding(4);
            this.intervalGrpBox.Size = new System.Drawing.Size(374, 315);
            this.intervalGrpBox.TabIndex = 22;
            this.intervalGrpBox.TabStop = false;
            this.intervalGrpBox.Text = "Interval";
            // 
            // yMaxTbx
            // 
            this.yMaxTbx.Location = new System.Drawing.Point(98, 194);
            this.yMaxTbx.Margin = new System.Windows.Forms.Padding(4);
            this.yMaxTbx.Name = "yMaxTbx";
            this.yMaxTbx.Size = new System.Drawing.Size(258, 31);
            this.yMaxTbx.TabIndex = 3;
            // 
            // yMinTbx
            // 
            this.yMinTbx.Location = new System.Drawing.Point(98, 144);
            this.yMinTbx.Margin = new System.Windows.Forms.Padding(4);
            this.yMinTbx.Name = "yMinTbx";
            this.yMinTbx.Size = new System.Drawing.Size(258, 31);
            this.yMinTbx.TabIndex = 2;
            // 
            // xMaxTbx
            // 
            this.xMaxTbx.Location = new System.Drawing.Point(98, 88);
            this.xMaxTbx.Margin = new System.Windows.Forms.Padding(4);
            this.xMaxTbx.Name = "xMaxTbx";
            this.xMaxTbx.Size = new System.Drawing.Size(258, 31);
            this.xMaxTbx.TabIndex = 1;
            // 
            // xMinTbx
            // 
            this.xMinTbx.Location = new System.Drawing.Point(98, 38);
            this.xMinTbx.Margin = new System.Windows.Forms.Padding(4);
            this.xMinTbx.Name = "xMinTbx";
            this.xMinTbx.Size = new System.Drawing.Size(258, 31);
            this.xMinTbx.TabIndex = 0;
            // 
            // yMaxLb
            // 
            this.yMaxLb.AutoSize = true;
            this.yMaxLb.Location = new System.Drawing.Point(24, 198);
            this.yMaxLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yMaxLb.Name = "yMaxLb";
            this.yMaxLb.Size = new System.Drawing.Size(75, 25);
            this.yMaxLb.TabIndex = 28;
            this.yMaxLb.Text = "y max:";
            // 
            // yMinLb
            // 
            this.yMinLb.AutoSize = true;
            this.yMinLb.Location = new System.Drawing.Point(24, 148);
            this.yMinLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yMinLb.Name = "yMinLb";
            this.yMinLb.Size = new System.Drawing.Size(69, 25);
            this.yMinLb.TabIndex = 27;
            this.yMinLb.Text = "y min:";
            // 
            // xMaxLb
            // 
            this.xMaxLb.AutoSize = true;
            this.xMaxLb.Location = new System.Drawing.Point(16, 92);
            this.xMaxLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xMaxLb.Name = "xMaxLb";
            this.xMaxLb.Size = new System.Drawing.Size(75, 25);
            this.xMaxLb.TabIndex = 26;
            this.xMaxLb.Text = "x max:";
            // 
            // xMinLb
            // 
            this.xMinLb.AutoSize = true;
            this.xMinLb.Location = new System.Drawing.Point(16, 40);
            this.xMinLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xMinLb.Name = "xMinLb";
            this.xMinLb.Size = new System.Drawing.Size(69, 25);
            this.xMinLb.TabIndex = 25;
            this.xMinLb.Text = "x min:";
            // 
            // intergralGroupBox
            // 
            this.intergralGroupBox.Controls.Add(this.riemannIntervalTb);
            this.intergralGroupBox.Controls.Add(this.intervalATbx);
            this.intergralGroupBox.Controls.Add(this.intervalBTbx);
            this.intergralGroupBox.Controls.Add(this.intervalALb);
            this.intergralGroupBox.Controls.Add(this.intervalLb);
            this.intergralGroupBox.Controls.Add(this.stepSizeLb);
            this.intergralGroupBox.Location = new System.Drawing.Point(416, 162);
            this.intergralGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.intergralGroupBox.Name = "intergralGroupBox";
            this.intergralGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.intergralGroupBox.Size = new System.Drawing.Size(448, 137);
            this.intergralGroupBox.TabIndex = 22;
            this.intergralGroupBox.TabStop = false;
            this.intergralGroupBox.Text = "Definite Integral";
            this.intergralGroupBox.Visible = false;
            // 
            // nPolynomialGroupBox
            // 
            this.nPolynomialGroupBox.Controls.Add(this.cursorYLb);
            this.nPolynomialGroupBox.Controls.Add(this.polynomialInputPanel);
            this.nPolynomialGroupBox.Controls.Add(this.coordinatesBtn);
            this.nPolynomialGroupBox.Controls.Add(this.cursorXLb);
            this.nPolynomialGroupBox.Location = new System.Drawing.Point(26, 715);
            this.nPolynomialGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.nPolynomialGroupBox.Name = "nPolynomialGroupBox";
            this.nPolynomialGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.nPolynomialGroupBox.Size = new System.Drawing.Size(374, 813);
            this.nPolynomialGroupBox.TabIndex = 23;
            this.nPolynomialGroupBox.TabStop = false;
            this.nPolynomialGroupBox.Text = "Polynomial Construction";
            // 
            // coordinatesListBox
            // 
            this.coordinatesListBox.FormattingEnabled = true;
            this.coordinatesListBox.ItemHeight = 25;
            this.coordinatesListBox.Location = new System.Drawing.Point(14, 221);
            this.coordinatesListBox.Name = "coordinatesListBox";
            this.coordinatesListBox.Size = new System.Drawing.Size(335, 379);
            this.coordinatesListBox.TabIndex = 0;
            // 
            // coordinatesBtn
            // 
            this.coordinatesBtn.Location = new System.Drawing.Point(29, 43);
            this.coordinatesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.coordinatesBtn.Name = "coordinatesBtn";
            this.coordinatesBtn.Size = new System.Drawing.Size(318, 48);
            this.coordinatesBtn.TabIndex = 19;
            this.coordinatesBtn.Text = "Place Points";
            this.coordinatesBtn.UseVisualStyleBackColor = true;
            this.coordinatesBtn.Click += new System.EventHandler(this.coordinatesBtn_Click);
            // 
            // polynomialInputPanel
            // 
            this.polynomialInputPanel.Controls.Add(this.polynomialCoordinatesPanel);
            this.polynomialInputPanel.Controls.Add(this.coordinatesListBox);
            this.polynomialInputPanel.Location = new System.Drawing.Point(7, 181);
            this.polynomialInputPanel.Name = "polynomialInputPanel";
            this.polynomialInputPanel.Size = new System.Drawing.Size(360, 614);
            this.polynomialInputPanel.TabIndex = 0;
            this.polynomialInputPanel.Visible = false;
            // 
            // polynomialCoordinatesPanel
            // 
            this.polynomialCoordinatesPanel.Controls.Add(this.coordinatesXTbx);
            this.polynomialCoordinatesPanel.Controls.Add(this.plotPolynomialBtn);
            this.polynomialCoordinatesPanel.Controls.Add(this.coordinatesYLb);
            this.polynomialCoordinatesPanel.Controls.Add(this.coordinatesYTbx);
            this.polynomialCoordinatesPanel.Controls.Add(this.coordinatesXLb);
            this.polynomialCoordinatesPanel.Controls.Add(this.addCoordinateBtn);
            this.polynomialCoordinatesPanel.Location = new System.Drawing.Point(7, 3);
            this.polynomialCoordinatesPanel.Name = "polynomialCoordinatesPanel";
            this.polynomialCoordinatesPanel.Size = new System.Drawing.Size(342, 212);
            this.polynomialCoordinatesPanel.TabIndex = 33;
            // 
            // coordinatesXTbx
            // 
            this.coordinatesXTbx.Location = new System.Drawing.Point(91, 4);
            this.coordinatesXTbx.Margin = new System.Windows.Forms.Padding(4);
            this.coordinatesXTbx.Name = "coordinatesXTbx";
            this.coordinatesXTbx.Size = new System.Drawing.Size(192, 31);
            this.coordinatesXTbx.TabIndex = 2;
            // 
            // coordinatesYLb
            // 
            this.coordinatesYLb.AutoSize = true;
            this.coordinatesYLb.Location = new System.Drawing.Point(54, 53);
            this.coordinatesYLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.coordinatesYLb.Name = "coordinatesYLb";
            this.coordinatesYLb.Size = new System.Drawing.Size(29, 25);
            this.coordinatesYLb.TabIndex = 40;
            this.coordinatesYLb.Text = "y:";
            // 
            // coordinatesYTbx
            // 
            this.coordinatesYTbx.Location = new System.Drawing.Point(91, 53);
            this.coordinatesYTbx.Margin = new System.Windows.Forms.Padding(4);
            this.coordinatesYTbx.Name = "coordinatesYTbx";
            this.coordinatesYTbx.Size = new System.Drawing.Size(192, 31);
            this.coordinatesYTbx.TabIndex = 3;
            // 
            // coordinatesXLb
            // 
            this.coordinatesXLb.AutoSize = true;
            this.coordinatesXLb.Location = new System.Drawing.Point(54, 4);
            this.coordinatesXLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.coordinatesXLb.Name = "coordinatesXLb";
            this.coordinatesXLb.Size = new System.Drawing.Size(29, 25);
            this.coordinatesXLb.TabIndex = 36;
            this.coordinatesXLb.Text = "x:";
            // 
            // addCoordinateBtn
            // 
            this.addCoordinateBtn.Location = new System.Drawing.Point(59, 92);
            this.addCoordinateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addCoordinateBtn.Name = "addCoordinateBtn";
            this.addCoordinateBtn.Size = new System.Drawing.Size(228, 48);
            this.addCoordinateBtn.TabIndex = 4;
            this.addCoordinateBtn.Text = "Add Coordinate";
            this.addCoordinateBtn.UseVisualStyleBackColor = true;
            this.addCoordinateBtn.Click += new System.EventHandler(this.addCoordinateBtn_Click);
            // 
            // plotPolynomialBtn
            // 
            this.plotPolynomialBtn.Location = new System.Drawing.Point(17, 155);
            this.plotPolynomialBtn.Margin = new System.Windows.Forms.Padding(4);
            this.plotPolynomialBtn.Name = "plotPolynomialBtn";
            this.plotPolynomialBtn.Size = new System.Drawing.Size(318, 48);
            this.plotPolynomialBtn.TabIndex = 5;
            this.plotPolynomialBtn.Text = "Interpolate Polynomial";
            this.plotPolynomialBtn.UseVisualStyleBackColor = true;
            this.plotPolynomialBtn.Click += new System.EventHandler(this.plotPolynomialBtn_Click);
            // 
            // cursorXLb
            // 
            this.cursorXLb.AutoSize = true;
            this.cursorXLb.Location = new System.Drawing.Point(34, 101);
            this.cursorXLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cursorXLb.Name = "cursorXLb";
            this.cursorXLb.Size = new System.Drawing.Size(29, 25);
            this.cursorXLb.TabIndex = 41;
            this.cursorXLb.Text = "x:";
            // 
            // cursorYLb
            // 
            this.cursorYLb.AutoSize = true;
            this.cursorYLb.Location = new System.Drawing.Point(34, 143);
            this.cursorYLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cursorYLb.Name = "cursorYLb";
            this.cursorYLb.Size = new System.Drawing.Size(29, 25);
            this.cursorYLb.TabIndex = 42;
            this.cursorYLb.Text = "y:";
            // 
            // rescaleChartAxisBtn
            // 
            this.rescaleChartAxisBtn.Location = new System.Drawing.Point(10, 257);
            this.rescaleChartAxisBtn.Name = "rescaleChartAxisBtn";
            this.rescaleChartAxisBtn.Size = new System.Drawing.Size(346, 51);
            this.rescaleChartAxisBtn.TabIndex = 4;
            this.rescaleChartAxisBtn.Text = "Rescale Chart Axis";
            this.rescaleChartAxisBtn.UseVisualStyleBackColor = true;
            this.rescaleChartAxisBtn.Click += new System.EventHandler(this.clearNRescaleAxis_Click);
            // 
            // differenceQuotientBtn
            // 
            this.differenceQuotientBtn.Location = new System.Drawing.Point(952, 82);
            this.differenceQuotientBtn.Margin = new System.Windows.Forms.Padding(4);
            this.differenceQuotientBtn.Name = "differenceQuotientBtn";
            this.differenceQuotientBtn.Size = new System.Drawing.Size(360, 48);
            this.differenceQuotientBtn.TabIndex = 24;
            this.differenceQuotientBtn.Text = "By Difference Quotient";
            this.differenceQuotientBtn.UseVisualStyleBackColor = true;
            this.differenceQuotientBtn.Visible = false;
            this.differenceQuotientBtn.Click += new System.EventHandler(this.differenceQuotientBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2286, 1096);
            this.Controls.Add(this.differenceQuotientBtn);
            this.Controls.Add(this.nPolynomialGroupBox);
            this.Controls.Add(this.intergralGroupBox);
            this.Controls.Add(this.intervalGrpBox);
            this.Controls.Add(this.mcLaurinGrpBox);
            this.Controls.Add(this.integralRbtn);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.textResultGrpBox);
            this.Controls.Add(this.expressionInputLb);
            this.Controls.Add(this.differentiateRbtn);
            this.Controls.Add(this.parseRbtn);
            this.Controls.Add(this.graphPictureBox);
            this.Controls.Add(this.expressionChart);
            this.Controls.Add(this.expressionTbx);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.textResultGrpBox.ResumeLayout(false);
            this.textResultGrpBox.PerformLayout();
            this.mcLaurinGrpBox.ResumeLayout(false);
            this.mcLaurinGrpBox.PerformLayout();
            this.intervalGrpBox.ResumeLayout(false);
            this.intervalGrpBox.PerformLayout();
            this.intergralGroupBox.ResumeLayout(false);
            this.intergralGroupBox.PerformLayout();
            this.nPolynomialGroupBox.ResumeLayout(false);
            this.nPolynomialGroupBox.PerformLayout();
            this.polynomialInputPanel.ResumeLayout(false);
            this.polynomialCoordinatesPanel.ResumeLayout(false);
            this.polynomialCoordinatesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart expressionChart;
        private System.Windows.Forms.PictureBox graphPictureBox;
        private System.Windows.Forms.RadioButton parseRbtn;
        private System.Windows.Forms.RadioButton differentiateRbtn;
        private System.Windows.Forms.GroupBox textResultGrpBox;
        private System.Windows.Forms.Label derivativeLb;
        private System.Windows.Forms.Label expressionLb;
        private System.Windows.Forms.TextBox expressionTbx;
        private System.Windows.Forms.Label expressionInputLb;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.RadioButton integralRbtn;
        private System.Windows.Forms.Label intervalLb;
        private System.Windows.Forms.Label intervalALb;
        private System.Windows.Forms.TextBox intervalBTbx;
        private System.Windows.Forms.TextBox intervalATbx;
        private System.Windows.Forms.Label areaLb;
        private System.Windows.Forms.Label stepSizeLb;
        private System.Windows.Forms.TextBox riemannIntervalTb;
        private System.Windows.Forms.GroupBox mcLaurinGrpBox;
        private System.Windows.Forms.Button btnQuotientMcLaurin;
        private System.Windows.Forms.Button btnAnalyticalMcLaurin;
        private System.Windows.Forms.TextBox nPolynomialTbx;
        private System.Windows.Forms.Label nPolynomiallb;
        private System.Windows.Forms.GroupBox intervalGrpBox;
        private System.Windows.Forms.TextBox yMaxTbx;
        private System.Windows.Forms.TextBox yMinTbx;
        private System.Windows.Forms.TextBox xMaxTbx;
        private System.Windows.Forms.TextBox xMinTbx;
        private System.Windows.Forms.Label yMaxLb;
        private System.Windows.Forms.Label yMinLb;
        private System.Windows.Forms.Label xMaxLb;
        private System.Windows.Forms.Label xMinLb;
        private System.Windows.Forms.GroupBox intergralGroupBox;
        private System.Windows.Forms.GroupBox nPolynomialGroupBox;
        private System.Windows.Forms.Button coordinatesBtn;
        private System.Windows.Forms.ListBox coordinatesListBox;
        private System.Windows.Forms.Panel polynomialInputPanel;
        private System.Windows.Forms.Panel polynomialCoordinatesPanel;
        private System.Windows.Forms.TextBox coordinatesXTbx;
        private System.Windows.Forms.Label coordinatesYLb;
        private System.Windows.Forms.TextBox coordinatesYTbx;
        private System.Windows.Forms.Label coordinatesXLb;
        private System.Windows.Forms.Button addCoordinateBtn;
        private System.Windows.Forms.Button plotPolynomialBtn;
        private System.Windows.Forms.Label cursorYLb;
        private System.Windows.Forms.Label cursorXLb;
        private System.Windows.Forms.Button rescaleChartAxisBtn;
        private System.Windows.Forms.Button differenceQuotientBtn;
    }
}

