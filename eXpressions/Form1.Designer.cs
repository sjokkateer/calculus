namespace eXpressions
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
            this.parseExpressionBtn = new System.Windows.Forms.Button();
            this.expressionLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // expressionTbx
            // 
            this.expressionTbx.Location = new System.Drawing.Point(24, 23);
            this.expressionTbx.Margin = new System.Windows.Forms.Padding(6);
            this.expressionTbx.Name = "expressionTbx";
            this.expressionTbx.Size = new System.Drawing.Size(1146, 31);
            this.expressionTbx.TabIndex = 0;
            // 
            // parseExpressionBtn
            // 
            this.parseExpressionBtn.Location = new System.Drawing.Point(1186, 17);
            this.parseExpressionBtn.Margin = new System.Windows.Forms.Padding(6);
            this.parseExpressionBtn.Name = "parseExpressionBtn";
            this.parseExpressionBtn.Size = new System.Drawing.Size(256, 44);
            this.parseExpressionBtn.TabIndex = 2;
            this.parseExpressionBtn.Text = "Parse Expression";
            this.parseExpressionBtn.UseVisualStyleBackColor = true;
            this.parseExpressionBtn.Click += new System.EventHandler(this.parseExpressionBtn_Click);
            // 
            // expressionLb
            // 
            this.expressionLb.AutoSize = true;
            this.expressionLb.Location = new System.Drawing.Point(84, 127);
            this.expressionLb.Name = "expressionLb";
            this.expressionLb.Size = new System.Drawing.Size(70, 25);
            this.expressionLb.TabIndex = 3;
            this.expressionLb.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 1285);
            this.Controls.Add(this.expressionLb);
            this.Controls.Add(this.parseExpressionBtn);
            this.Controls.Add(this.expressionTbx);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expressionTbx;
        private System.Windows.Forms.Button parseExpressionBtn;
        private System.Windows.Forms.Label expressionLb;
    }
}

