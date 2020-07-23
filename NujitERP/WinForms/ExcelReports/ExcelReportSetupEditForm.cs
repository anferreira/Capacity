using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using  Nujit.NujitERP.ClassLib.Core;
using  Nujit.NujitERP.WinForms.Util;
using  Nujit.NujitERP.ClassLib.Core.ExcelReports;
using  Nujit.NujitERP.ClassLib.Common;


namespace  Nujit.NujitERP.WinForms.ExcelReports{

public 
class ExcelReportSetupEditForm : System.Windows.Forms.Form{

private System.ComponentModel.Container components = null;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();


private System.Windows.Forms.ErrorProvider error;
private bool flgEdit;
private System.Windows.Forms.GroupBox botonesGroupBox;
private System.Windows.Forms.Button closeButton;
private System.Windows.Forms.Button okButton;
private System.Windows.Forms.TextBox pathTextBox;
private System.Windows.Forms.TextBox reportNameTextBox;
private System.Windows.Forms.TextBox sqlSentenceTextBox;
private System.Windows.Forms.TextBox fileNameTextBox;
private System.Windows.Forms.Label pathLabel;
private System.Windows.Forms.Label reportNameLabel;
private System.Windows.Forms.Label sqlSentenceLabel;
private System.Windows.Forms.Label fileNameLabel;
private ExcelReportSetup excelReportSetup;
private System.Windows.Forms.OpenFileDialog openFileDialog;
private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
private System.Windows.Forms.Button pathbutton;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Button pivotTablebutton;
private System.Windows.Forms.TextBox pivotTabletextBox;
private string type = "";

public 
ExcelReportSetupEditForm(string type){
	InitializeComponent();
	
	flgEdit = false;
	try {
		excelReportSetup = coreFactory.createExcelReportSetup();
	}catch(Exception ex){				
		FormException frmEx = new FormException (ex);
		frmEx.ShowDialog(this);
	}
	this.type = type;
}

public 
ExcelReportSetupEditForm(ExcelReportSetup excelReportSetup){
	InitializeComponent();
	this.excelReportSetup = excelReportSetup;
	flgEdit = true;
	objectToScreen();
	disableKeyControls();
}

protected override 
void Dispose( bool disposing ){
	if( disposing ){
		if(components != null){
			components.Dispose();
		}
	}
	base.Dispose( disposing );
}

#region Windows Form Designer generated code
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private
void InitializeComponent(){
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ExcelReportSetupEditForm));
	this.pathTextBox = new System.Windows.Forms.TextBox();
	this.reportNameTextBox = new System.Windows.Forms.TextBox();
	this.pathLabel = new System.Windows.Forms.Label();
	this.reportNameLabel = new System.Windows.Forms.Label();
	this.error = new System.Windows.Forms.ErrorProvider();
	this.botonesGroupBox = new System.Windows.Forms.GroupBox();
	this.closeButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.sqlSentenceTextBox = new System.Windows.Forms.TextBox();
	this.sqlSentenceLabel = new System.Windows.Forms.Label();
	this.fileNameTextBox = new System.Windows.Forms.TextBox();
	this.fileNameLabel = new System.Windows.Forms.Label();
	this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
	this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
	this.pathbutton = new System.Windows.Forms.Button();
	this.label1 = new System.Windows.Forms.Label();
	this.pivotTablebutton = new System.Windows.Forms.Button();
	this.pivotTabletextBox = new System.Windows.Forms.TextBox();
	this.botonesGroupBox.SuspendLayout();
	this.SuspendLayout();
	// 
	// pathTextBox
	// 
	this.pathTextBox.Enabled = false;
	this.pathTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.pathTextBox.Location = new System.Drawing.Point(104, 56);
	this.pathTextBox.MaxLength = 255;
	this.pathTextBox.Name = "pathTextBox";
	this.pathTextBox.Size = new System.Drawing.Size(384, 20);
	this.pathTextBox.TabIndex = 1;
	this.pathTextBox.Text = "";
	// 
	// reportNameTextBox
	// 
	this.reportNameTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.reportNameTextBox.Location = new System.Drawing.Point(104, 8);
	this.reportNameTextBox.MaxLength = 50;
	this.reportNameTextBox.Name = "reportNameTextBox";
	this.reportNameTextBox.Size = new System.Drawing.Size(312, 20);
	this.reportNameTextBox.TabIndex = 0;
	this.reportNameTextBox.Text = "";
	// 
	// pathLabel
	// 
	this.pathLabel.Location = new System.Drawing.Point(8, 56);
	this.pathLabel.Name = "pathLabel";
	this.pathLabel.Size = new System.Drawing.Size(68, 20);
	this.pathLabel.TabIndex = 5;
	this.pathLabel.Text = "Path";
	this.pathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// reportNameLabel
	// 
	this.reportNameLabel.Location = new System.Drawing.Point(8, 8);
	this.reportNameLabel.Name = "reportNameLabel";
	this.reportNameLabel.Size = new System.Drawing.Size(72, 24);
	this.reportNameLabel.TabIndex = 4;
	this.reportNameLabel.Text = "Report Name";
	this.reportNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// error
	// 
	this.error.ContainerControl = this;
	// 
	// botonesGroupBox
	// 
	this.botonesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.botonesGroupBox.Controls.Add(this.closeButton);
	this.botonesGroupBox.Controls.Add(this.okButton);
	this.botonesGroupBox.Location = new System.Drawing.Point(8, 304);
	this.botonesGroupBox.Name = "botonesGroupBox";
	this.botonesGroupBox.Size = new System.Drawing.Size(600, 48);
	this.botonesGroupBox.TabIndex = 4;
	this.botonesGroupBox.TabStop = false;
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(104, 16);
	this.closeButton.Name = "closeButton";
	this.closeButton.Size = new System.Drawing.Size(88, 24);
	this.closeButton.TabIndex = 1;
	this.closeButton.Text = "Close ";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// okButton
	// 
	this.okButton.Location = new System.Drawing.Point(8, 16);
	this.okButton.Name = "okButton";
	this.okButton.Size = new System.Drawing.Size(88, 24);
	this.okButton.TabIndex = 0;
	this.okButton.Text = "OK";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// sqlSentenceTextBox
	// 
	this.sqlSentenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.sqlSentenceTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.sqlSentenceTextBox.Location = new System.Drawing.Point(104, 104);
	this.sqlSentenceTextBox.Multiline = true;
	this.sqlSentenceTextBox.Name = "sqlSentenceTextBox";
	this.sqlSentenceTextBox.Size = new System.Drawing.Size(504, 200);
	this.sqlSentenceTextBox.TabIndex = 3;
	this.sqlSentenceTextBox.Text = "";
	// 
	// sqlSentenceLabel
	// 
	this.sqlSentenceLabel.Location = new System.Drawing.Point(8, 104);
	this.sqlSentenceLabel.Name = "sqlSentenceLabel";
	this.sqlSentenceLabel.Size = new System.Drawing.Size(88, 20);
	this.sqlSentenceLabel.TabIndex = 8;
	this.sqlSentenceLabel.Text = "SQL Sentence";
	this.sqlSentenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// fileNameTextBox
	// 
	this.fileNameTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.fileNameTextBox.Location = new System.Drawing.Point(104, 80);
	this.fileNameTextBox.MaxLength = 50;
	this.fileNameTextBox.Name = "fileNameTextBox";
	this.fileNameTextBox.Size = new System.Drawing.Size(312, 20);
	this.fileNameTextBox.TabIndex = 2;
	this.fileNameTextBox.Text = "";
	// 
	// fileNameLabel
	// 
	this.fileNameLabel.Location = new System.Drawing.Point(8, 80);
	this.fileNameLabel.Name = "fileNameLabel";
	this.fileNameLabel.Size = new System.Drawing.Size(88, 20);
	this.fileNameLabel.TabIndex = 10;
	this.fileNameLabel.Text = "File Name";
	this.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// openFileDialog
	// 
	this.openFileDialog.DefaultExt = "*.xls";
	this.openFileDialog.Filter = "EXCEL Files (*.xls)|*.xls|All files (*.*)|*.*";
	this.openFileDialog.RestoreDirectory = true;
	// 
	// folderBrowserDialog
	// 
	this.folderBrowserDialog.Description = "Please, select a folder for the output file.";
	// 
	// pathbutton
	// 
	this.pathbutton.Location = new System.Drawing.Point(496, 56);
	this.pathbutton.Name = "pathbutton";
	this.pathbutton.Size = new System.Drawing.Size(16, 20);
	this.pathbutton.TabIndex = 16;
	this.pathbutton.Click += new System.EventHandler(this.pathbutton_Click);
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(8, 32);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(88, 20);
	this.label1.TabIndex = 22;
	this.label1.Text = "Pivot Table";
	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// pivotTablebutton
	// 
	this.pivotTablebutton.Location = new System.Drawing.Point(496, 32);
	this.pivotTablebutton.Name = "pivotTablebutton";
	this.pivotTablebutton.Size = new System.Drawing.Size(16, 20);
	this.pivotTablebutton.TabIndex = 21;
	this.pivotTablebutton.Click += new System.EventHandler(this.pivotTableButton_Click);
	// 
	// pivotTabletextBox
	// 
	this.pivotTabletextBox.Enabled = false;
	this.pivotTabletextBox.Location = new System.Drawing.Point(104, 32);
	this.pivotTabletextBox.Name = "pivotTabletextBox";
	this.pivotTabletextBox.Size = new System.Drawing.Size(384, 20);
	this.pivotTabletextBox.TabIndex = 20;
	this.pivotTabletextBox.Text = "";
	// 
	// ExcelReportSetupEditForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(624, 365);
	this.Controls.Add(this.label1);
	this.Controls.Add(this.pivotTablebutton);
	this.Controls.Add(this.pivotTabletextBox);
	this.Controls.Add(this.fileNameTextBox);
	this.Controls.Add(this.sqlSentenceTextBox);
	this.Controls.Add(this.pathTextBox);
	this.Controls.Add(this.reportNameTextBox);
	this.Controls.Add(this.pathbutton);
	this.Controls.Add(this.fileNameLabel);
	this.Controls.Add(this.sqlSentenceLabel);
	this.Controls.Add(this.botonesGroupBox);
	this.Controls.Add(this.reportNameLabel);
	this.Controls.Add(this.pathLabel);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.MaximizeBox = false;
	this.Name = "ExcelReportSetupEditForm";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Excel Report Setup";
	this.botonesGroupBox.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private 
void objectToScreen(){
	if (excelReportSetup == null)
		return;
	this.reportNameTextBox.Text = excelReportSetup.getReportName();
	this.pathTextBox.Text = excelReportSetup.getPath();
	this.fileNameTextBox.Text = excelReportSetup.getFileName();
	this.sqlSentenceTextBox.Text = excelReportSetup.getSqlSentence();
	this.type = excelReportSetup.getType();
	this.pivotTabletextBox.Text = excelReportSetup.getPivotTablePath();
}

private 
void screenToObject(){
	if (excelReportSetup == null)
		excelReportSetup = coreFactory.createExcelReportSetup();
	excelReportSetup.setReportName(this.reportNameTextBox.Text);
	excelReportSetup.setPath(this.pathTextBox.Text);
	excelReportSetup.setFileName(this.fileNameTextBox.Text);
	excelReportSetup.setSqlSentence(this.sqlSentenceTextBox.Text );
	excelReportSetup.setType(type);
	excelReportSetup.setPivotTablePath(this.pivotTabletextBox.Text);
}

private
void disableKeyControls(){
	this.reportNameTextBox.Enabled = false;
}

private 
void okButton_Click(object sender, System.EventArgs e){
	if (save()){
		this.DialogResult = DialogResult.OK;
		this.Close();
	}
}


private 
void closeButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel; 
    this.Close();
}	
   
private 
bool save(){
	if (dataOk()){
		screenToObject();
		try {
			if (flgEdit){ // is an update
				coreFactory.updateExcelReportSetup(excelReportSetup);
				return true;
			}
			else{ // is a new record
				if (coreFactory.existsExcelReportSetup(this.excelReportSetup.getReportName())){
					MessageBox.Show("Exists Record","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return false;
				}else{
					coreFactory.writeExcelReportSetup(excelReportSetup);
					return true;
				}
			}
		}catch(Exception ex){				
			FormException frmEx = new FormException (ex);
			frmEx.ShowDialog(this);
			return false;
		}
	} 
	else
		return false;
}

private 
bool dataOk(){
    
    if (this.reportNameTextBox.Text.Length == 0){
        MessageBox.Show("Report Name Needed");
        return false;
    }
	if (this.pathTextBox.Text.Length == 0){
		MessageBox.Show("Path Needed");
        return false;
    }
	if (this.fileNameTextBox.Text.Length == 0){
        MessageBox.Show("File Name Needed");
        return false;
    }
	if (this.sqlSentenceTextBox.Text.Length == 0){
        MessageBox.Show("Sql Sentence Needed");
        return false;
    }
	if (this.sqlSentenceTextBox.Text.Length<6 || !this.sqlSentenceTextBox.Text.Substring(0,6).ToLower().Equals("select")){
        MessageBox.Show("Only Select Statements Allowed");
        return false;
    }
    return true;
}
   


private 
void pivotTableButton_Click(object sender, System.EventArgs e){
	
	if (openFileDialog.ShowDialog() == DialogResult.OK){
		
		this.pivotTabletextBox.Text = this.openFileDialog.FileName;
		string path = this.openFileDialog.FileName;
		int i = path.LastIndexOf("\\") + 1;
		this.fileNameTextBox.Text = path.Substring(i,path.Length - i);
		this.fileNameTextBox.Enabled=false;
	}
}

private 
void pathbutton_Click(object sender, System.EventArgs e){
	this.folderBrowserDialog.SelectedPath = @"C:\";
	if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK){
		this.pathTextBox.Text = this.folderBrowserDialog.SelectedPath;
	}
}


}
}
