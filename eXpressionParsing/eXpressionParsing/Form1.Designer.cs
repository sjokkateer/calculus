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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
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
            this.integralInputPanel = new System.Windows.Forms.Panel();
            this.intervalLb = new System.Windows.Forms.Label();
            this.interalBLb = new System.Windows.Forms.Label();
            this.intervalALb = new System.Windows.Forms.Label();
            this.intervalBTbx = new System.Windows.Forms.TextBox();
            this.intervalATbx = new System.Windows.Forms.TextBox();
            this.riemannIntervalTb = new System.Windows.Forms.TextBox();
            this.stepSizeLb = new System.Windows.Forms.Label();
            this.axisPanel = new System.Windows.Forms.Panel();
            this.xMinLb = new System.Windows.Forms.Label();
            this.xMaxLb = new System.Windows.Forms.Label();
            this.yMaxLb = new System.Windows.Forms.Label();
            this.yMinLb = new System.Windows.Forms.Label();
            this.xMinTbx = new System.Windows.Forms.TextBox();
            this.xMaxTbx = new System.Windows.Forms.TextBox();
            this.yMinTbx = new System.Windows.Forms.TextBox();
            this.yMaxTbx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.textResultGrpBox.SuspendLayout();
            this.integralInputPanel.SuspendLayout();
            this.axisPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // expressionChart
            // 
            chartArea3.Name = "ChartArea1";
            this.expressionChart.ChartAreas.Add(chartArea3);
            this.expressionChart.Location = new System.Drawing.Point(26, 147);
            this.expressionChart.Name = "expressionChart";
            this.expressionChart.Size = new System.Drawing.Size(1268, 907);
            this.expressionChart.TabIndex = 4;
            this.expressionChart.Text = "Expression Chart";
            this.expressionChart.Paint += new System.Windows.Forms.PaintEventHandler(this.expressionChart_Paint);
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Location = new System.Drawing.Point(1300, 147);
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
            this.textResultGrpBox.Location = new System.Drawing.Point(26, 1060);
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
            this.expressionTbx.Location = new System.Drawing.Point(225, 42);
            this.expressionTbx.Name = "expressionTbx";
            this.expressionTbx.Size = new System.Drawing.Size(719, 31);
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
            // integralInputPanel
            // 
            this.integralInputPanel.Controls.Add(this.stepSizeLb);
            this.integralInputPanel.Controls.Add(this.riemannIntervalTb);
            this.integralInputPanel.Controls.Add(this.intervalLb);
            this.integralInputPanel.Controls.Add(this.interalBLb);
            this.integralInputPanel.Controls.Add(this.intervalALb);
            this.integralInputPanel.Controls.Add(this.intervalBTbx);
            this.integralInputPanel.Controls.Add(this.intervalATbx);
            this.integralInputPanel.Location = new System.Drawing.Point(1488, 15);
            this.integralInputPanel.Name = "integralInputPanel";
            this.integralInputPanel.Size = new System.Drawing.Size(581, 122);
            this.integralInputPanel.TabIndex = 15;
            this.integralInputPanel.Visible = false;
            // 
            // intervalLb
            // 
            this.intervalLb.AutoSize = true;
            this.intervalLb.Location = new System.Drawing.Point(16, 7);
            this.intervalLb.Name = "intervalLb";
            this.intervalLb.Size = new System.Drawing.Size(142, 25);
            this.intervalLb.TabIndex = 19;
            this.intervalLb.Text = "Interval [a, b]:";
            // 
            // interalBLb
            // 
            this.interalBLb.AutoSize = true;
            this.interalBLb.Location = new System.Drawing.Point(16, 81);
            this.interalBLb.Name = "interalBLb";
            this.interalBLb.Size = new System.Drawing.Size(30, 25);
            this.interalBLb.TabIndex = 18;
            this.interalBLb.Text = "b:";
            // 
            // intervalALb
            // 
            this.intervalALb.AutoSize = true;
            this.intervalALb.Location = new System.Drawing.Point(16, 44);
            this.intervalALb.Name = "intervalALb";
            this.intervalALb.Size = new System.Drawing.Size(30, 25);
            this.intervalALb.TabIndex = 16;
            this.intervalALb.Text = "a:";
            // 
            // intervalBTbx
            // 
            this.intervalBTbx.Location = new System.Drawing.Point(52, 81);
            this.intervalBTbx.Name = "intervalBTbx";
            this.intervalBTbx.Size = new System.Drawing.Size(205, 31);
            this.intervalBTbx.TabIndex = 17;
            this.intervalBTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intervalBTbx_KeyPress);
            // 
            // intervalATbx
            // 
            this.intervalATbx.Location = new System.Drawing.Point(52, 41);
            this.intervalATbx.Name = "intervalATbx";
            this.intervalATbx.Size = new System.Drawing.Size(205, 31);
            this.intervalATbx.TabIndex = 16;
            this.intervalATbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intervalATbx_KeyPress);
            // 
            // riemannIntervalTb
            // 
            this.riemannIntervalTb.Location = new System.Drawing.Point(273, 39);
            this.riemannIntervalTb.Name = "riemannIntervalTb";
            this.riemannIntervalTb.Size = new System.Drawing.Size(205, 31);
            this.riemannIntervalTb.TabIndex = 20;
            // 
            // stepSizeLb
            // 
            this.stepSizeLb.AutoSize = true;
            this.stepSizeLb.Location = new System.Drawing.Point(273, 7);
            this.stepSizeLb.Name = "stepSizeLb";
            this.stepSizeLb.Size = new System.Drawing.Size(210, 25);
            this.stepSizeLb.TabIndex = 21;
            this.stepSizeLb.Text = "Number of intervals: ";
            // 
            // axisPanel
            // 
            this.axisPanel.Controls.Add(this.yMaxTbx);
            this.axisPanel.Controls.Add(this.yMinTbx);
            this.axisPanel.Controls.Add(this.xMaxTbx);
            this.axisPanel.Controls.Add(this.xMinTbx);
            this.axisPanel.Controls.Add(this.yMaxLb);
            this.axisPanel.Controls.Add(this.yMinLb);
            this.axisPanel.Controls.Add(this.xMaxLb);
            this.axisPanel.Controls.Add(this.xMinLb);
            this.axisPanel.Location = new System.Drawing.Point(960, 15);
            this.axisPanel.Name = "axisPanel";
            this.axisPanel.Size = new System.Drawing.Size(522, 122);
            this.axisPanel.TabIndex = 17;
            // 
            // xMinLb
            // 
            this.xMinLb.AutoSize = true;
            this.xMinLb.Location = new System.Drawing.Point(11, 27);
            this.xMinLb.Name = "xMinLb";
            this.xMinLb.Size = new System.Drawing.Size(69, 25);
            this.xMinLb.TabIndex = 17;
            this.xMinLb.Text = "x min:";
            // 
            // xMaxLb
            // 
            this.xMaxLb.AutoSize = true;
            this.xMaxLb.Location = new System.Drawing.Point(11, 65);
            this.xMaxLb.Name = "xMaxLb";
            this.xMaxLb.Size = new System.Drawing.Size(75, 25);
            this.xMaxLb.TabIndex = 18;
            this.xMaxLb.Text = "x max:";
            // 
            // yMaxLb
            // 
            this.yMaxLb.AutoSize = true;
            this.yMaxLb.Location = new System.Drawing.Point(265, 62);
            this.yMaxLb.Name = "yMaxLb";
            this.yMaxLb.Size = new System.Drawing.Size(75, 25);
            this.yMaxLb.TabIndex = 20;
            this.yMaxLb.Text = "y max:";
            // 
            // yMinLb
            // 
            this.yMinLb.AutoSize = true;
            this.yMinLb.Location = new System.Drawing.Point(265, 24);
            this.yMinLb.Name = "yMinLb";
            this.yMinLb.Size = new System.Drawing.Size(69, 25);
            this.yMinLb.TabIndex = 19;
            this.yMinLb.Text = "y min:";
            // 
            // xMinTbx
            // 
            this.xMinTbx.Location = new System.Drawing.Point(92, 24);
            this.xMinTbx.Name = "xMinTbx";
            this.xMinTbx.Size = new System.Drawing.Size(157, 31);
            this.xMinTbx.TabIndex = 21;
            // 
            // xMaxTbx
            // 
            this.xMaxTbx.Location = new System.Drawing.Point(92, 61);
            this.xMaxTbx.Name = "xMaxTbx";
            this.xMaxTbx.Size = new System.Drawing.Size(157, 31);
            this.xMaxTbx.TabIndex = 22;
            // 
            // yMinTbx
            // 
            this.yMinTbx.Location = new System.Drawing.Point(340, 21);
            this.yMinTbx.Name = "yMinTbx";
            this.yMinTbx.Size = new System.Drawing.Size(156, 31);
            this.yMinTbx.TabIndex = 23;
            // 
            // yMaxTbx
            // 
            this.yMaxTbx.Location = new System.Drawing.Point(340, 59);
            this.yMaxTbx.Name = "yMaxTbx";
            this.yMaxTbx.Size = new System.Drawing.Size(156, 31);
            this.yMaxTbx.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2251, 1435);
            this.Controls.Add(this.axisPanel);
            this.Controls.Add(this.integralInputPanel);
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
            this.integralInputPanel.ResumeLayout(false);
            this.integralInputPanel.PerformLayout();
            this.axisPanel.ResumeLayout(false);
            this.axisPanel.PerformLayout();
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
        private System.Windows.Forms.Panel integralInputPanel;
        private System.Windows.Forms.Label intervalLb;
        private System.Windows.Forms.Label interalBLb;
        private System.Windows.Forms.Label intervalALb;
        private System.Windows.Forms.TextBox intervalBTbx;
        private System.Windows.Forms.TextBox intervalATbx;
        private System.Windows.Forms.Label areaLb;
        private System.Windows.Forms.Label stepSizeLb;
        private System.Windows.Forms.TextBox riemannIntervalTb;
        private System.Windows.Forms.Panel axisPanel;
        private System.Windows.Forms.TextBox yMaxTbx;
        private System.Windows.Forms.TextBox yMinTbx;
        private System.Windows.Forms.TextBox xMaxTbx;
        private System.Windows.Forms.TextBox xMinTbx;
        private System.Windows.Forms.Label yMaxLb;
        private System.Windows.Forms.Label yMinLb;
        private System.Windows.Forms.Label xMaxLb;
        private System.Windows.Forms.Label xMinLb;
    }
}

