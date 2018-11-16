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
            this.expressionTbx = new System.Windows.Forms.TextBox();
            this.parseBtn = new System.Windows.Forms.Button();
            this.humanReadableLbl = new System.Windows.Forms.Label();
            this.expressionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // expressionTbx
            // 
            this.expressionTbx.Location = new System.Drawing.Point(26, 85);
            this.expressionTbx.Name = "expressionTbx";
            this.expressionTbx.Size = new System.Drawing.Size(671, 31);
            this.expressionTbx.TabIndex = 0;
            // 
            // parseBtn
            // 
            this.parseBtn.Location = new System.Drawing.Point(712, 78);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(194, 44);
            this.parseBtn.TabIndex = 1;
            this.parseBtn.Text = "Parse Expression";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.parseBtn_Click);
            // 
            // humanReadableLbl
            // 
            this.humanReadableLbl.AutoSize = true;
            this.humanReadableLbl.Location = new System.Drawing.Point(21, 35);
            this.humanReadableLbl.Name = "humanReadableLbl";
            this.humanReadableLbl.Size = new System.Drawing.Size(0, 25);
            this.humanReadableLbl.TabIndex = 2;
            // 
            // expressionChart
            // 
            this.expressionChart.BackColor = System.Drawing.Color.Transparent;
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
            this.graphPictureBox.Location = new System.Drawing.Point(1273, 175);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(955, 854);
            this.graphPictureBox.TabIndex = 5;
            this.graphPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2251, 1079);
            this.Controls.Add(this.graphPictureBox);
            this.Controls.Add(this.expressionChart);
            this.Controls.Add(this.humanReadableLbl);
            this.Controls.Add(this.parseBtn);
            this.Controls.Add(this.expressionTbx);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.expressionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expressionTbx;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.Label humanReadableLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart expressionChart;
        private System.Windows.Forms.PictureBox graphPictureBox;
    }
}

