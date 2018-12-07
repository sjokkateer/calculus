namespace eXpressionParsing
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
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
            this.interalBLb = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.textResultGrpBox.SuspendLayout();
            this.mcLaurinGrpBox.SuspendLayout();
            this.intervalGrpBox.SuspendLayout();
            this.intergralGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // expressionChart
            // 
            chartArea4.Name = "ChartArea1";
            this.expressionChart.ChartAreas.Add(chartArea4);
            this.expressionChart.Location = new System.Drawing.Point(417, 360);
            this.expressionChart.Name = "expressionChart";
            this.expressionChart.Size = new System.Drawing.Size(1268, 907);
            this.expressionChart.TabIndex = 4;
            this.expressionChart.Text = "Expression Chart";
            this.expressionChart.Paint += new System.Windows.Forms.PaintEventHandler(this.expressionChart_Paint);
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Location = new System.Drawing.Point(1691, 360);
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
            this.parseRbtn.Name = "parseRbtn";
            this.parseRbtn.Size = new System.Drawing.Size(99, 29);
            this.parseRbtn.TabIndex = 8;
            this.parseRbtn.TabStop = true;
            this.parseRbtn.Text = "Parse";
            this.parseRbtn.UseVisualStyleBackColor = true;
            this.parseRbtn.CheckedChanged += new System.EventHandler(this.parseRbtn_CheckedChanged);
            // 
            // differentiateRbtn
            // 
            this.differentiateRbtn.AutoSize = true;
            this.differentiateRbtn.Location = new System.Drawing.Point(26, 53);
            this.differentiateRbtn.Name = "differentiateRbtn";
            this.differentiateRbtn.Size = new System.Drawing.Size(159, 29);
            this.differentiateRbtn.TabIndex = 9;
            this.differentiateRbtn.Text = "Differentiate";
            this.differentiateRbtn.UseVisualStyleBackColor = true;
            this.differentiateRbtn.CheckedChanged += new System.EventHandler(this.differentiateRbtn_CheckedChanged);
            // 
            // textResultGrpBox
            // 
            this.textResultGrpBox.Controls.Add(this.areaLb);
            this.textResultGrpBox.Controls.Add(this.derivativeLb);
            this.textResultGrpBox.Controls.Add(this.expressionLb);
            this.textResultGrpBox.Location = new System.Drawing.Point(417, 1273);
            this.textResultGrpBox.Name = "textResultGrpBox";
            this.textResultGrpBox.Size = new System.Drawing.Size(1268, 314);
            this.textResultGrpBox.TabIndex = 12;
            this.textResultGrpBox.TabStop = false;
            this.textResultGrpBox.Text = "Text results";
            // 
            // areaLb
            // 
            this.areaLb.AutoSize = true;
            this.areaLb.Location = new System.Drawing.Point(29, 133);
            this.areaLb.Name = "areaLb";
            this.areaLb.Size = new System.Drawing.Size(168, 25);
            this.areaLb.TabIndex = 21;
            this.areaLb.Text = "Estimated area: ";
            // 
            // derivativeLb
            // 
            this.derivativeLb.AutoSize = true;
            this.derivativeLb.Location = new System.Drawing.Point(25, 90);
            this.derivativeLb.Name = "derivativeLb";
            this.derivativeLb.Size = new System.Drawing.Size(120, 25);
            this.derivativeLb.TabIndex = 1;
            this.derivativeLb.Text = "Derivative: ";
            // 
            // expressionLb
            // 
            this.expressionLb.AutoSize = true;
            this.expressionLb.Location = new System.Drawing.Point(25, 47);
            this.expressionLb.Name = "expressionLb";
            this.expressionLb.Size = new System.Drawing.Size(131, 25);
            this.expressionLb.TabIndex = 0;
            this.expressionLb.Text = "Expression: ";
            // 
            // expressionTbx
            // 
            this.expressionTbx.Location = new System.Drawing.Point(229, 42);
            this.expressionTbx.Name = "expressionTbx";
            this.expressionTbx.Size = new System.Drawing.Size(715, 31);
            this.expressionTbx.TabIndex = 0;
            // 
            // expressionInputLb
            // 
            this.expressionInputLb.AutoSize = true;
            this.expressionInputLb.Location = new System.Drawing.Point(224, 10);
            this.expressionInputLb.Name = "expressionInputLb";
            this.expressionInputLb.Size = new System.Drawing.Size(176, 25);
            this.expressionInputLb.TabIndex = 10;
            this.expressionInputLb.Text = "Input expression:";
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(225, 83);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(719, 49);
            this.processBtn.TabIndex = 13;
            this.processBtn.Text = "Process Expression";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // integralRbtn
            // 
            this.integralRbtn.AutoSize = true;
            this.integralRbtn.Location = new System.Drawing.Point(26, 93);
            this.integralRbtn.Name = "integralRbtn";
            this.integralRbtn.Size = new System.Drawing.Size(193, 29);
            this.integralRbtn.TabIndex = 14;
            this.integralRbtn.TabStop = true;
            this.integralRbtn.Text = "Definite integral";
            this.integralRbtn.UseVisualStyleBackColor = true;
            this.integralRbtn.CheckedChanged += new System.EventHandler(this.integralRbtn_CheckedChanged);
            // 
            // stepSizeLb
            // 
            this.stepSizeLb.Location = new System.Drawing.Point(228, 27);
            this.stepSizeLb.Name = "stepSizeLb";
            this.stepSizeLb.Size = new System.Drawing.Size(233, 42);
            this.stepSizeLb.TabIndex = 0;
            this.stepSizeLb.Text = "Number of intervals:";
            // 
            // riemannIntervalTb
            // 
            this.riemannIntervalTb.Location = new System.Drawing.Point(233, 58);
            this.riemannIntervalTb.Name = "riemannIntervalTb";
            this.riemannIntervalTb.Size = new System.Drawing.Size(188, 31);
            this.riemannIntervalTb.TabIndex = 1;
            // 
            // intervalLb
            // 
            this.intervalLb.Location = new System.Drawing.Point(6, 110);
            this.intervalLb.Name = "intervalLb";
            this.intervalLb.Size = new System.Drawing.Size(65, 34);
            this.intervalLb.TabIndex = 3;
            this.intervalLb.Text = "b:";
            // 
            // interalBLb
            // 
            this.interalBLb.Location = new System.Drawing.Point(298, 133);
            this.interalBLb.Name = "interalBLb";
            this.interalBLb.Size = new System.Drawing.Size(100, 23);
            this.interalBLb.TabIndex = 5;
            // 
            // intervalALb
            // 
            this.intervalALb.Location = new System.Drawing.Point(6, 58);
            this.intervalALb.Name = "intervalALb";
            this.intervalALb.Size = new System.Drawing.Size(56, 31);
            this.intervalALb.TabIndex = 6;
            this.intervalALb.Text = "a:";
            // 
            // intervalBTbx
            // 
            this.intervalBTbx.Location = new System.Drawing.Point(45, 107);
            this.intervalBTbx.Name = "intervalBTbx";
            this.intervalBTbx.Size = new System.Drawing.Size(152, 31);
            this.intervalBTbx.TabIndex = 4;
            // 
            // intervalATbx
            // 
            this.intervalATbx.Location = new System.Drawing.Point(45, 58);
            this.intervalATbx.Name = "intervalATbx";
            this.intervalATbx.Size = new System.Drawing.Size(152, 31);
            this.intervalATbx.TabIndex = 2;
            // 
            // mcLaurinGrpBox
            // 
            this.mcLaurinGrpBox.Controls.Add(this.nPolynomialTbx);
            this.mcLaurinGrpBox.Controls.Add(this.nPolynomiallb);
            this.mcLaurinGrpBox.Controls.Add(this.btnQuotientMcLaurin);
            this.mcLaurinGrpBox.Controls.Add(this.btnAnalyticalMcLaurin);
            this.mcLaurinGrpBox.Location = new System.Drawing.Point(26, 484);
            this.mcLaurinGrpBox.Name = "mcLaurinGrpBox";
            this.mcLaurinGrpBox.Size = new System.Drawing.Size(374, 224);
            this.mcLaurinGrpBox.TabIndex = 18;
            this.mcLaurinGrpBox.TabStop = false;
            this.mcLaurinGrpBox.Text = "Maclaurin Polynomial";
            // 
            // nPolynomialTbx
            // 
            this.nPolynomialTbx.Location = new System.Drawing.Point(164, 43);
            this.nPolynomialTbx.Name = "nPolynomialTbx";
            this.nPolynomialTbx.Size = new System.Drawing.Size(192, 31);
            this.nPolynomialTbx.TabIndex = 31;
            this.nPolynomialTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nPolynomialTbx_KeyPress);
            // 
            // nPolynomiallb
            // 
            this.nPolynomiallb.AutoSize = true;
            this.nPolynomiallb.Location = new System.Drawing.Point(17, 46);
            this.nPolynomiallb.Name = "nPolynomiallb";
            this.nPolynomiallb.Size = new System.Drawing.Size(141, 25);
            this.nPolynomiallb.TabIndex = 30;
            this.nPolynomiallb.Text = "n Polynomial:";
            // 
            // btnQuotientMcLaurin
            // 
            this.btnQuotientMcLaurin.Location = new System.Drawing.Point(28, 156);
            this.btnQuotientMcLaurin.Name = "btnQuotientMcLaurin";
            this.btnQuotientMcLaurin.Size = new System.Drawing.Size(318, 49);
            this.btnQuotientMcLaurin.TabIndex = 21;
            this.btnQuotientMcLaurin.Text = "By Newton\'s Quotient";
            this.btnQuotientMcLaurin.UseVisualStyleBackColor = true;
            this.btnQuotientMcLaurin.Click += new System.EventHandler(this.btnQuotientMcLaurin_Click);
            // 
            // btnAnalyticalMcLaurin
            // 
            this.btnAnalyticalMcLaurin.Location = new System.Drawing.Point(28, 91);
            this.btnAnalyticalMcLaurin.Name = "btnAnalyticalMcLaurin";
            this.btnAnalyticalMcLaurin.Size = new System.Drawing.Size(318, 49);
            this.btnAnalyticalMcLaurin.TabIndex = 19;
            this.btnAnalyticalMcLaurin.Text = "Analytical";
            this.btnAnalyticalMcLaurin.UseVisualStyleBackColor = true;
            this.btnAnalyticalMcLaurin.Click += new System.EventHandler(this.btnAnalyticalMcLaurin_Click);
            // 
            // intervalGrpBox
            // 
            this.intervalGrpBox.Controls.Add(this.yMaxTbx);
            this.intervalGrpBox.Controls.Add(this.yMinTbx);
            this.intervalGrpBox.Controls.Add(this.xMaxTbx);
            this.intervalGrpBox.Controls.Add(this.xMinTbx);
            this.intervalGrpBox.Controls.Add(this.yMaxLb);
            this.intervalGrpBox.Controls.Add(this.yMinLb);
            this.intervalGrpBox.Controls.Add(this.xMaxLb);
            this.intervalGrpBox.Controls.Add(this.xMinLb);
            this.intervalGrpBox.Location = new System.Drawing.Point(26, 161);
            this.intervalGrpBox.Name = "intervalGrpBox";
            this.intervalGrpBox.Size = new System.Drawing.Size(374, 308);
            this.intervalGrpBox.TabIndex = 22;
            this.intervalGrpBox.TabStop = false;
            this.intervalGrpBox.Text = "Interval";
            // 
            // yMaxTbx
            // 
            this.yMaxTbx.Location = new System.Drawing.Point(98, 258);
            this.yMaxTbx.Name = "yMaxTbx";
            this.yMaxTbx.Size = new System.Drawing.Size(258, 31);
            this.yMaxTbx.TabIndex = 32;
            // 
            // yMinTbx
            // 
            this.yMinTbx.Location = new System.Drawing.Point(98, 208);
            this.yMinTbx.Name = "yMinTbx";
            this.yMinTbx.Size = new System.Drawing.Size(258, 31);
            this.yMinTbx.TabIndex = 31;
            // 
            // xMaxTbx
            // 
            this.xMaxTbx.Location = new System.Drawing.Point(98, 89);
            this.xMaxTbx.Name = "xMaxTbx";
            this.xMaxTbx.Size = new System.Drawing.Size(258, 31);
            this.xMaxTbx.TabIndex = 30;
            // 
            // xMinTbx
            // 
            this.xMinTbx.Location = new System.Drawing.Point(98, 38);
            this.xMinTbx.Name = "xMinTbx";
            this.xMinTbx.Size = new System.Drawing.Size(258, 31);
            this.xMinTbx.TabIndex = 29;
            // 
            // yMaxLb
            // 
            this.yMaxLb.AutoSize = true;
            this.yMaxLb.Location = new System.Drawing.Point(23, 261);
            this.yMaxLb.Name = "yMaxLb";
            this.yMaxLb.Size = new System.Drawing.Size(75, 25);
            this.yMaxLb.TabIndex = 28;
            this.yMaxLb.Text = "y max:";
            // 
            // yMinLb
            // 
            this.yMinLb.AutoSize = true;
            this.yMinLb.Location = new System.Drawing.Point(23, 211);
            this.yMinLb.Name = "yMinLb";
            this.yMinLb.Size = new System.Drawing.Size(69, 25);
            this.yMinLb.TabIndex = 27;
            this.yMinLb.Text = "y min:";
            // 
            // xMaxLb
            // 
            this.xMaxLb.AutoSize = true;
            this.xMaxLb.Location = new System.Drawing.Point(17, 93);
            this.xMaxLb.Name = "xMaxLb";
            this.xMaxLb.Size = new System.Drawing.Size(75, 25);
            this.xMaxLb.TabIndex = 26;
            this.xMaxLb.Text = "x max:";
            // 
            // xMinLb
            // 
            this.xMinLb.AutoSize = true;
            this.xMinLb.Location = new System.Drawing.Point(17, 41);
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
            this.intergralGroupBox.Controls.Add(this.interalBLb);
            this.intergralGroupBox.Controls.Add(this.intervalALb);
            this.intergralGroupBox.Controls.Add(this.intervalLb);
            this.intergralGroupBox.Controls.Add(this.stepSizeLb);
            this.intergralGroupBox.Location = new System.Drawing.Point(417, 161);
            this.intergralGroupBox.Name = "intergralGroupBox";
            this.intergralGroupBox.Size = new System.Drawing.Size(449, 186);
            this.intergralGroupBox.TabIndex = 22;
            this.intergralGroupBox.TabStop = false;
            this.intergralGroupBox.Text = "Definite Integral";
            this.intergralGroupBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2251, 1435);
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
        private System.Windows.Forms.Label interalBLb;
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
    }
}

