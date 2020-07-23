namespace Nujit.NujitERP.WinForms.Util
{
    partial class NujitMessageTimerForm
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
            this.messLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messLabel
            // 
            this.messLabel.AutoSize = true;
            this.messLabel.Location = new System.Drawing.Point(3, 42);
            this.messLabel.Name = "messLabel";
            this.messLabel.Size = new System.Drawing.Size(328, 13);
            this.messLabel.TabIndex = 0;
            this.messLabel.Text = "                                                                                 " +
    "                          ";
            this.messLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(112, 106);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // NujitMessageTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 158);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.messLabel);
            this.Name = "NujitMessageTimerForm";
            this.Text = "Message";
            this.Load += new System.EventHandler(this.NujitMessageTimerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messLabel;
        private System.Windows.Forms.Button okButton;
    }
}