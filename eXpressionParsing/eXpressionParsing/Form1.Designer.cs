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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.parseBtn = new System.Windows.Forms.Button();
            this.expressionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.differentiateBtn = new System.Windows.Forms.Button();
            this.parseRbtn = new System.Windows.Forms.RadioButton();
            this.differentiateRbtn = new System.Windows.Forms.RadioButton();
            this.textResultGrpBox = new System.Windows.Forms.GroupBox();
            this.expressionLb = new System.Windows.Forms.Label();
            this.derivativeLb = new System.Windows.Forms.Label();
            this.expressionTbx = new System.Windows.Forms.TextBox();
            this.expressionInputLb = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.processBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.textResultGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // parseBtn
            // 
            this.parseBtn.Location = new System.Drawing.Point(205, 93);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(194, 37);
            this.parseBtn.TabIndex = 1;
            this.parseBtn.Text = "Parse Expression";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.parseBtn_Click);
            // 
            // expressionChart
            // 
            chartArea1.Name = "ChartArea1";
            this.expressionChart.ChartAreas.Add(chartArea1);
            this.expressionChart.Location = new System.Drawing.Point(26, 147);
            this.expressionChart.Name = "expressionChart";
            this.expressionChart.Size = new System.Drawing.Size(1268, 907);
            this.expressionChart.TabIndex = 4;
            this.expressionChart.Text = "Expression Chart";
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Location = new System.Drawing.Point(1300, 147);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(2500, 2000);
            this.graphPictureBox.TabIndex = 5;
            this.graphPictureBox.TabStop = false;
            // 
            // differentiateBtn
            // 
            this.differentiateBtn.Location = new System.Drawing.Point(405, 93);
            this.differentiateBtn.Name = "differentiateBtn";
            this.differentiateBtn.Size = new System.Drawing.Size(265, 37);
            this.differentiateBtn.TabIndex = 6;
            this.differentiateBtn.Text = "Differentiate Expression";
            this.differentiateBtn.UseVisualStyleBackColor = true;
            this.differentiateBtn.Click += new System.EventHandler(this.differentiateBtn_Click);
            // 
            // parseRbtn
            // 
            this.parseRbtn.AutoSize = true;
            this.parseRbtn.Checked = true;
            this.parseRbtn.Location = new System.Drawing.Point(26, 12);
            this.parseRbtn.Name = "parseRbtn";
            this.parseRbtn.Size = new System.Drawing.Size(99, 29);
            this.parseRbtn.TabIndex = 8;
            this.parseRbtn.TabStop = true;
            this.parseRbtn.Text = "Parse";
            this.parseRbtn.UseVisualStyleBackColor = true;
            // 
            // differentiateRbtn
            // 
            this.differentiateRbtn.AutoSize = true;
            this.differentiateRbtn.Location = new System.Drawing.Point(26, 50);
            this.differentiateRbtn.Name = "differentiateRbtn";
            this.differentiateRbtn.Size = new System.Drawing.Size(159, 29);
            this.differentiateRbtn.TabIndex = 9;
            this.differentiateRbtn.Text = "Differentiate";
            this.differentiateRbtn.UseVisualStyleBackColor = true;
            // 
            // textResultGrpBox
            // 
            this.textResultGrpBox.Controls.Add(this.derivativeLb);
            this.textResultGrpBox.Controls.Add(this.expressionLb);
            this.textResultGrpBox.Location = new System.Drawing.Point(26, 1060);
            this.textResultGrpBox.Name = "textResultGrpBox";
            this.textResultGrpBox.Size = new System.Drawing.Size(1268, 314);
            this.textResultGrpBox.TabIndex = 12;
            this.textResultGrpBox.TabStop = false;
            this.textResultGrpBox.Text = "Text results";
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
            // derivativeLb
            // 
            this.derivativeLb.AutoSize = true;
            this.derivativeLb.Location = new System.Drawing.Point(25, 90);
            this.derivativeLb.Name = "derivativeLb";
            this.derivativeLb.Size = new System.Drawing.Size(120, 25);
            this.derivativeLb.TabIndex = 1;
            this.derivativeLb.Text = "Derivative: ";
            // 
            // expressionTbx
            // 
            this.expressionTbx.Location = new System.Drawing.Point(205, 42);
            this.expressionTbx.Name = "expressionTbx";
            this.expressionTbx.Size = new System.Drawing.Size(671, 31);
            this.expressionTbx.TabIndex = 0;
            // 
            // expressionInputLb
            // 
            this.expressionInputLb.AutoSize = true;
            this.expressionInputLb.Location = new System.Drawing.Point(204, 10);
            this.expressionInputLb.Name = "expressionInputLb";
            this.expressionInputLb.Size = new System.Drawing.Size(176, 25);
            this.expressionInputLb.TabIndex = 10;
            this.expressionInputLb.Text = "Input expression:";
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(903, 42);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(276, 73);
            this.processBtn.TabIndex = 13;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2251, 1435);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.textResultGrpBox);
            this.Controls.Add(this.expressionInputLb);
            this.Controls.Add(this.differentiateRbtn);
            this.Controls.Add(this.parseRbtn);
            this.Controls.Add(this.differentiateBtn);
            this.Controls.Add(this.graphPictureBox);
            this.Controls.Add(this.expressionChart);
            this.Controls.Add(this.parseBtn);
            this.Controls.Add(this.expressionTbx);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.textResultGrpBox.ResumeLayout(false);
            this.textResultGrpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart expressionChart;
        private System.Windows.Forms.PictureBox graphPictureBox;
        private System.Windows.Forms.Button differentiateBtn;
        private System.Windows.Forms.RadioButton parseRbtn;
        private System.Windows.Forms.RadioButton differentiateRbtn;
        private System.Windows.Forms.GroupBox textResultGrpBox;
        private System.Windows.Forms.Label derivativeLb;
        private System.Windows.Forms.Label expressionLb;
        private System.Windows.Forms.TextBox expressionTbx;
        private System.Windows.Forms.Label expressionInputLb;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button processBtn;
    }
}

