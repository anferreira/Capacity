/*********************************************************************** 
File Name:               FormException.cs
Created By:              Eric zhong
Created Date:            21/04/2003
***********************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Nujit.NujitERP.WinForms{


public 
class FormException : System.Windows.Forms.Form{


private System.Windows.Forms.Label label1;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Button btnClose;
private Exception m_exException;
private System.Windows.Forms.TextBox tbxSource;
private System.Windows.Forms.RichTextBox tbxStackTrace;
private System.Windows.Forms.RichTextBox tbxMessage;
private System.ComponentModel.Container components = null;


public 
FormException(){
	InitializeComponent();
}

public 
FormException(Exception exException){
	InitializeComponent();
	m_exException = exException;
	ViewExceptionInWindow();
}


protected override 
void Dispose( bool disposing ){
	if (disposing){
		if (components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}


public 
void ViewExceptionInWindow(){
	if (m_exException==null){
		// no exception loaded
		tbxMessage.Text = "No exception loaded into window: can't visualize exception";
		return;
	}

	// visualize the exception.
	tbxStackTrace.SelectionBullet=true;
	tbxMessage.SelectionBullet=true;
	tbxMessage.Text += m_exException.Message + Environment.NewLine;
	tbxSource.Text += m_exException.Source + Environment.NewLine;
	tbxStackTrace.Text += m_exException.StackTrace + Environment.NewLine;

	// go into the inner exceptions.
	for(Exception exInnerException = m_exException.InnerException;
			exInnerException!=null;exInnerException = exInnerException.InnerException){
		
		tbxMessage.Text += exInnerException.Message + Environment.NewLine;
		tbxSource.Text += exInnerException.Source + Environment.NewLine;
		tbxStackTrace.Text += exInnerException.StackTrace + Environment.NewLine;
	}

	// strip extra newline from boxes
	tbxMessage.Text = tbxMessage.Text.Substring(0,tbxMessage.Text.Length-2);
	tbxSource.Text = tbxSource.Text.Substring(0,tbxSource.Text.Length-2);
	tbxStackTrace.Text = tbxStackTrace.Text.Substring(0,tbxStackTrace.Text.Length-2);
}


private 
void InitializeComponent(){
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormException));
	this.label1 = new System.Windows.Forms.Label();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.tbxMessage = new System.Windows.Forms.RichTextBox();
	this.tbxStackTrace = new System.Windows.Forms.RichTextBox();
	this.tbxSource = new System.Windows.Forms.TextBox();
	this.label6 = new System.Windows.Forms.Label();
	this.label5 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.btnClose = new System.Windows.Forms.Button();
	this.groupBox1.SuspendLayout();
	this.SuspendLayout();
	// 
	// label1
	// 
	this.label1.BackColor = System.Drawing.Color.White;
	this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label1.Location = new System.Drawing.Point(4, 8);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(412, 32);
	this.label1.TabIndex = 0;
	this.label1.Text = "An exception occured. Below is the general information about this exception. Clic" +
		"k Close to close this window to resume.";
	// 
	// groupBox1
	// 
	this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.groupBox1.Controls.Add(this.tbxMessage);
	this.groupBox1.Controls.Add(this.tbxStackTrace);
	this.groupBox1.Controls.Add(this.tbxSource);
	this.groupBox1.Controls.Add(this.label6);
	this.groupBox1.Controls.Add(this.label5);
	this.groupBox1.Controls.Add(this.label4);
	this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
	this.groupBox1.Location = new System.Drawing.Point(4, 54);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(486, 434);
	this.groupBox1.TabIndex = 1;
	this.groupBox1.TabStop = false;
	this.groupBox1.Text = ".NET Exception information";
	// 
	// tbxMessage
	// 
	this.tbxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.tbxMessage.BulletIndent = 10;
	this.tbxMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.tbxMessage.Location = new System.Drawing.Point(8, 36);
	this.tbxMessage.Name = "tbxMessage";
	this.tbxMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
	this.tbxMessage.Size = new System.Drawing.Size(472, 76);
	this.tbxMessage.TabIndex = 2;
	this.tbxMessage.Text = "";
	// 
	// tbxStackTrace
	// 
	this.tbxStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.tbxStackTrace.BulletIndent = 10;
	this.tbxStackTrace.CausesValidation = false;
	this.tbxStackTrace.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.tbxStackTrace.Location = new System.Drawing.Point(8, 136);
	this.tbxStackTrace.Name = "tbxStackTrace";
	this.tbxStackTrace.ReadOnly = true;
	this.tbxStackTrace.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
	this.tbxStackTrace.Size = new System.Drawing.Size(472, 216);
	this.tbxStackTrace.TabIndex = 3;
	this.tbxStackTrace.Text = "";
	// 
	// tbxSource
	// 
	this.tbxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.tbxSource.BackColor = System.Drawing.SystemColors.Window;
	this.tbxSource.Location = new System.Drawing.Point(8, 373);
	this.tbxSource.Multiline = true;
	this.tbxSource.Name = "tbxSource";
	this.tbxSource.ReadOnly = true;
	this.tbxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
	this.tbxSource.Size = new System.Drawing.Size(470, 52);
	this.tbxSource.TabIndex = 4;
	this.tbxSource.Text = "";
	// 
	// label6
	// 
	this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
	this.label6.Location = new System.Drawing.Point(8, 357);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(60, 16);
	this.label6.TabIndex = 4;
	this.label6.Text = "Source";
	// 
	// label5
	// 
	this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
	this.label5.Location = new System.Drawing.Point(8, 120);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(188, 16);
	this.label5.TabIndex = 2;
	this.label5.Text = "Stack trace";
	// 
	// label4
	// 
	this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
	this.label4.Location = new System.Drawing.Point(8, 20);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(64, 16);
	this.label4.TabIndex = 0;
	this.label4.Text = "Message";
	// 
	// label3
	// 
	this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.label3.BackColor = System.Drawing.Color.White;
	this.label3.Location = new System.Drawing.Point(0, 0);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(496, 48);
	this.label3.TabIndex = 3;
	// 
	// btnClose
	// 
	this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
	this.btnClose.Location = new System.Drawing.Point(390, 498);
	this.btnClose.Name = "btnClose";
	this.btnClose.Size = new System.Drawing.Size(96, 24);
	this.btnClose.TabIndex = 5;
	this.btnClose.Text = "Close";
	this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
	// 
	// FormException
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(496, 528);
	this.Controls.Add(this.btnClose);
	this.Controls.Add(this.label1);
	this.Controls.Add(this.label3);
	this.Controls.Add(this.groupBox1);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.MaximizeBox = false;
	this.MinimizeBox = false;
	this.MinimumSize = new System.Drawing.Size(416, 392);
	this.Name = "FormException";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Exception Viewer";
	this.Load += new System.EventHandler(this.FormException_Load);
	this.groupBox1.ResumeLayout(false);
	this.ResumeLayout(false);

}

private 
void btnClose_Click(object sender, System.EventArgs e){
	this.Close();
}

private 
void FormException_Load(object sender, System.EventArgs e){
	this.ViewExceptionInWindow();
}
		
}

}

