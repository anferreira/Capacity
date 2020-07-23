
namespace Nujit.Utilities.Util{

partial 
class NujitCustomMessageBox{

private System.ComponentModel.IContainer components = null;

protected override 
void Dispose(bool disposing){
    if (disposing && (components != null)){
        components.Dispose();
    }
    base.Dispose(disposing);
}

#region Windows Form Designer generated code

private 
void InitializeComponent(){
    this.btnCancel = new System.Windows.Forms.Button();
    this.btnOk = new System.Windows.Forms.Button();
    this.lblMessage = new System.Windows.Forms.Label();
    this.lblTimer = new System.Windows.Forms.Label();
    this.SuspendLayout();
    // 
    // btnCancel
    // 
    this.btnCancel.Location = new System.Drawing.Point(307, 86);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.Size = new System.Drawing.Size(84, 27);
    this.btnCancel.TabIndex = 1;
    this.btnCancel.Text = "Cancel";
    this.btnCancel.UseVisualStyleBackColor = true;
    this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
    // 
    // btnOk
    // 
    this.btnOk.Location = new System.Drawing.Point(217, 86);
    this.btnOk.Name = "btnOk";
    this.btnOk.Size = new System.Drawing.Size(84, 27);
    this.btnOk.TabIndex = 0;
    this.btnOk.Text = "OK";
    this.btnOk.UseVisualStyleBackColor = true;
    this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
    // 
    // lblMessage
    // 
    this.lblMessage.AutoSize = true;
    this.lblMessage.Location = new System.Drawing.Point(9, 7);
    this.lblMessage.Name = "lblMessage";
    this.lblMessage.Size = new System.Drawing.Size(35, 13);
    this.lblMessage.TabIndex = 2;
    this.lblMessage.Text = "label1";
    // 
    // lblTimer
    // 
    this.lblTimer.AutoSize = true;
    this.lblTimer.Location = new System.Drawing.Point(9, 100);
    this.lblTimer.Name = "lblTimer";
    this.lblTimer.Size = new System.Drawing.Size(0, 13);
    this.lblTimer.TabIndex = 3;
    // 
    // NujitMessageBox
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(392, 116);
    this.Controls.Add(this.lblTimer);
    this.Controls.Add(this.lblMessage);
    this.Controls.Add(this.btnCancel);
    this.Controls.Add(this.btnOk);
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
    this.Name = "NujitMessageBox";
    this.ShowInTaskbar = false;
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.Text = "NujitMessageBox";
    this.Load += new System.EventHandler(this.NujitMessageBox_Load);
    this.ResumeLayout(false);
    this.PerformLayout();

}

#endregion

private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnOk;
private System.Windows.Forms.Label lblMessage;
private System.Windows.Forms.Label lblTimer;


}
}