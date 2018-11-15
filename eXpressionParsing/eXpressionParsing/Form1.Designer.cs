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
            this.expressionTbx = new System.Windows.Forms.TextBox();
            this.parseBtn = new System.Windows.Forms.Button();
            this.humanReadableLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // expressionTbx
            // 
            this.expressionTbx.Location = new System.Drawing.Point(12, 12);
            this.expressionTbx.Name = "expressionTbx";
            this.expressionTbx.Size = new System.Drawing.Size(1522, 31);
            this.expressionTbx.TabIndex = 0;
            // 
            // parseBtn
            // 
            this.parseBtn.Location = new System.Drawing.Point(1540, 12);
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
            this.humanReadableLbl.Location = new System.Drawing.Point(26, 70);
            this.humanReadableLbl.Name = "humanReadableLbl";
            this.humanReadableLbl.Size = new System.Drawing.Size(70, 25);
            this.humanReadableLbl.TabIndex = 2;
            this.humanReadableLbl.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1746, 1060);
            this.Controls.Add(this.humanReadableLbl);
            this.Controls.Add(this.parseBtn);
            this.Controls.Add(this.expressionTbx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expressionTbx;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.Label humanReadableLbl;
    }
}

