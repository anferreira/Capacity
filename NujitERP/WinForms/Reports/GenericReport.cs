using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Nujit.NujitERP.WinForms.Util;


namespace Nujit.NujitERP.WinForms.Reports{

public abstract
class GenericReport : Form{

private System.ComponentModel.Container components = null;
private DataSet dataSet;
private DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport;
private System.Windows.Forms.Button button1;
private System.Windows.Forms.Button exportButton;
private DataDynamics.ActiveReports.Export.Html.HtmlExport htmlExport;
private System.Windows.Forms.RadioButton pdfRadioButton;
private System.Windows.Forms.RadioButton htmlRadioButton;
private System.Windows.Forms.RadioButton xlsRadioButton;
private DataDynamics.ActiveReports.Export.Xls.XlsExport xlsExport;
private System.Windows.Forms.GroupBox gBoxReportFormat;
private DataDynamics.ActiveReports.Viewer.Viewer viewer;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Panel panel2;
private System.Windows.Forms.Panel panel3;
private System.Windows.Forms.Panel panel4;
private DataDynamics.ActiveReports.Export.Rtf.RtfExport rtfExport;
private System.Windows.Forms.RadioButton rBtnRtf;
private System.Windows.Forms.Button emailButton;
private System.Windows.Forms.SaveFileDialog saveFileDialog1;
private System.Windows.Forms.Button chLocButton;
private ActiveReport3 activeReport;
private string filename = "";


public 
GenericReport(DataSet dataSet, bool lessDays){

	InitializeComponent();

	this.dataSet = dataSet;
	buildReport(lessDays);
}

public 
GenericReport(DataSet dataSet, string text, bool lessDays){
	InitializeComponent();

	this.Text = text;
	this.dataSet = dataSet;
	buildReport(lessDays);
}
	
protected override 
void Dispose(bool disposing){
	if (disposing){
		if (components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}

#region Windows Form Designer generated code

private 
void InitializeComponent(){
	this.pdfExport = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
	this.htmlExport = new DataDynamics.ActiveReports.Export.Html.HtmlExport();
	this.button1 = new System.Windows.Forms.Button();
	this.exportButton = new System.Windows.Forms.Button();
	this.emailButton = new System.Windows.Forms.Button();
	this.pdfRadioButton = new System.Windows.Forms.RadioButton();
	this.htmlRadioButton = new System.Windows.Forms.RadioButton();
	this.xlsRadioButton = new System.Windows.Forms.RadioButton();
	this.xlsExport = new DataDynamics.ActiveReports.Export.Xls.XlsExport();
	this.gBoxReportFormat = new System.Windows.Forms.GroupBox();
	this.chLocButton = new System.Windows.Forms.Button();
	this.rBtnRtf = new System.Windows.Forms.RadioButton();
	this.viewer = new DataDynamics.ActiveReports.Viewer.Viewer();
	this.panel1 = new System.Windows.Forms.Panel();
	this.panel4 = new System.Windows.Forms.Panel();
	this.panel3 = new System.Windows.Forms.Panel();
	this.panel2 = new System.Windows.Forms.Panel();
	this.rtfExport = new DataDynamics.ActiveReports.Export.Rtf.RtfExport();
	this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
	this.gBoxReportFormat.SuspendLayout();
	this.panel1.SuspendLayout();
	this.panel4.SuspendLayout();
	this.panel3.SuspendLayout();
	this.panel2.SuspendLayout();
	this.SuspendLayout();
	// 
	// button1
	// 
	this.button1.Location = new System.Drawing.Point(176, 24);
	this.button1.Name = "button1";
	this.button1.Size = new System.Drawing.Size(104, 23);
	this.button1.TabIndex = 4;
	this.button1.Text = "Close";
	this.button1.Click += new System.EventHandler(this.button1_Click);
	// 
	// exportButton
	// 
	this.exportButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
	this.exportButton.Location = new System.Drawing.Point(216, 16);
	this.exportButton.Name = "exportButton";
	this.exportButton.Size = new System.Drawing.Size(88, 23);
	this.exportButton.TabIndex = 6;
	this.exportButton.Text = "Export";
	this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
	// 
	// emailButton
	// 
	this.emailButton.Location = new System.Drawing.Point(424, 16);
	this.emailButton.Name = "emailButton";
	this.emailButton.Size = new System.Drawing.Size(88, 23);
	this.emailButton.TabIndex = 7;
	this.emailButton.Text = "Send Email";
	this.emailButton.Click += new System.EventHandler(this.emailButton_Click);
	// 
	// pdfRadioButton
	// 
	this.pdfRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
	this.pdfRadioButton.Checked = true;
	this.pdfRadioButton.Location = new System.Drawing.Point(8, 16);
	this.pdfRadioButton.Name = "pdfRadioButton";
	this.pdfRadioButton.Size = new System.Drawing.Size(40, 18);
	this.pdfRadioButton.TabIndex = 8;
	this.pdfRadioButton.TabStop = true;
	this.pdfRadioButton.Text = "Pdf";
	this.pdfRadioButton.CheckedChanged += new System.EventHandler(this.pdfRadioButton_CheckedChanged);
	// 
	// htmlRadioButton
	// 
	this.htmlRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
	this.htmlRadioButton.Location = new System.Drawing.Point(56, 16);
	this.htmlRadioButton.Name = "htmlRadioButton";
	this.htmlRadioButton.Size = new System.Drawing.Size(48, 18);
	this.htmlRadioButton.TabIndex = 9;
	this.htmlRadioButton.Text = "Html";
	this.htmlRadioButton.CheckedChanged += new System.EventHandler(this.htmlRadioButton_CheckedChanged);
	// 
	// xlsRadioButton
	// 
	this.xlsRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
	this.xlsRadioButton.Location = new System.Drawing.Point(112, 16);
	this.xlsRadioButton.Name = "xlsRadioButton";
	this.xlsRadioButton.Size = new System.Drawing.Size(40, 18);
	this.xlsRadioButton.TabIndex = 10;
	this.xlsRadioButton.Text = "Xls";
	this.xlsRadioButton.CheckedChanged += new System.EventHandler(this.xlsRadioButton_CheckedChanged);
	// 
	// xlsExport
	// 
	this.xlsExport.Tweak = 0;
	// 
	// gBoxReportFormat
	// 
	this.gBoxReportFormat.Controls.Add(this.chLocButton);
	this.gBoxReportFormat.Controls.Add(this.rBtnRtf);
	this.gBoxReportFormat.Controls.Add(this.xlsRadioButton);
	this.gBoxReportFormat.Controls.Add(this.pdfRadioButton);
	this.gBoxReportFormat.Controls.Add(this.htmlRadioButton);
	this.gBoxReportFormat.Controls.Add(this.emailButton);
	this.gBoxReportFormat.Controls.Add(this.exportButton);
	this.gBoxReportFormat.Location = new System.Drawing.Point(24, 16);
	this.gBoxReportFormat.Name = "gBoxReportFormat";
	this.gBoxReportFormat.Size = new System.Drawing.Size(520, 48);
	this.gBoxReportFormat.TabIndex = 11;
	this.gBoxReportFormat.TabStop = false;
	this.gBoxReportFormat.Text = "Report Format";
	// 
	// chLocButton
	// 
	this.chLocButton.Location = new System.Drawing.Point(320, 16);
	this.chLocButton.Name = "chLocButton";
	this.chLocButton.Size = new System.Drawing.Size(88, 23);
	this.chLocButton.TabIndex = 12;
	this.chLocButton.Text = "Change Loc";
	this.chLocButton.Click += new System.EventHandler(this.chLocButton_Click);
	// 
	// rBtnRtf
	// 
	this.rBtnRtf.Anchor = System.Windows.Forms.AnchorStyles.Left;
	this.rBtnRtf.Location = new System.Drawing.Point(160, 16);
	this.rBtnRtf.Name = "rBtnRtf";
	this.rBtnRtf.Size = new System.Drawing.Size(40, 18);
	this.rBtnRtf.TabIndex = 11;
	this.rBtnRtf.Text = "Rtf";
	this.rBtnRtf.CheckedChanged += new System.EventHandler(this.rBtnRtf_CheckedChanged);
	// 
	// viewer
	// 
	this.viewer.BackColor = System.Drawing.SystemColors.Control;
	this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
	this.viewer.Location = new System.Drawing.Point(0, 0);
	this.viewer.Name = "viewer";
	this.viewer.ReportViewer.CurrentPage = 0;
	this.viewer.ReportViewer.MultiplePageCols = 3;
	this.viewer.ReportViewer.MultiplePageRows = 2;
	this.viewer.Size = new System.Drawing.Size(912, 486);
	this.viewer.TabIndex = 0;
	this.viewer.TableOfContents.Text = "Contents";
	this.viewer.TableOfContents.Width = 200;
	this.viewer.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	// 
	// panel1
	// 
	this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.panel1.Controls.Add(this.panel4);
	this.panel1.Controls.Add(this.panel3);
	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
	this.panel1.Location = new System.Drawing.Point(0, 486);
	this.panel1.Name = "panel1";
	this.panel1.Size = new System.Drawing.Size(912, 72);
	this.panel1.TabIndex = 12;
	// 
	// panel4
	// 
	this.panel4.Controls.Add(this.gBoxReportFormat);
	this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
	this.panel4.Location = new System.Drawing.Point(0, 0);
	this.panel4.Name = "panel4";
	this.panel4.Size = new System.Drawing.Size(564, 68);
	this.panel4.TabIndex = 1;
	// 
	// panel3
	// 
	this.panel3.AutoScroll = true;
	this.panel3.Controls.Add(this.button1);
	this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
	this.panel3.Location = new System.Drawing.Point(564, 0);
	this.panel3.Name = "panel3";
	this.panel3.Size = new System.Drawing.Size(344, 68);
	this.panel3.TabIndex = 0;
	// 
	// panel2
	// 
	this.panel2.Controls.Add(this.viewer);
	this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
	this.panel2.Location = new System.Drawing.Point(0, 0);
	this.panel2.Name = "panel2";
	this.panel2.Size = new System.Drawing.Size(912, 486);
	this.panel2.TabIndex = 13;
	// 
	// GenericReport
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(912, 558);
	this.Controls.Add(this.panel2);
	this.Controls.Add(this.panel1);
	this.MinimumSize = new System.Drawing.Size(920, 592);
	this.Name = "GenericReport";
	this.gBoxReportFormat.ResumeLayout(false);
	this.panel1.ResumeLayout(false);
	this.panel4.ResumeLayout(false);
	this.panel3.ResumeLayout(false);
	this.panel2.ResumeLayout(false);
	this.ResumeLayout(false);

}

#endregion

private 
void exportButton_Click(object sender, System.EventArgs e){
	generateReport();
	filename = "";
}

private 
void generateReport(){
	if (filename.Equals(""))
		filename = Configuration.ReportPath + "\\" + activeReport.DataMember +
			DateUtil.formatCompleteDate(System.DateTime.Now, DateUtil.MMDDYYYY);
	
	if (pdfRadioButton.Checked){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".pdf")))
			filename += ".pdf";
		this.pdfExport.Export(activeReport.Document, filename);
		this.pdfExport.Dispose();
	}

	if (htmlRadioButton.Checked){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".html")))
			filename += ".html";
		this.htmlExport.Export(activeReport.Document, filename);
		this.htmlExport.Dispose();
	}

	if (xlsRadioButton.Checked){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".xls")))
			filename += ".xls";
		this.xlsExport.Export(activeReport.Document, filename);
		this.xlsExport.Dispose();
	}
	if (rBtnRtf.Checked){
		string ext = filename.Substring(filename.Length - 4, 4);
		if ((filename.Length <= 4) || (!ext.Equals(".rtf")))
			filename += ".rtf";
		this.rtfExport.Export(activeReport.Document, filename);
		this.rtfExport.Dispose();
	}
	
	ShellLib.ShellExecute shellExec  = new ShellLib.ShellExecute();
	shellExec.Path = @filename;
	shellExec.Execute();	
}

private 
void buildReport(bool lessDays){
	activeReport = getActiveReport(lessDays);
	activeReport.SetLicense("Mauricio Della-Quercia,Nujit Inc.,DD-ARN-10-E000241,CXATZQQXKZ3J5Q2542Q9");
	activeReport.DataSource = dataSet;
	viewer.Document = activeReport.Document;
}

private 
void button1_Click(object sender, System.EventArgs e){
	Close();
}


protected abstract void runReport();
protected abstract ActiveReport3 getActiveReport(bool lessDays);

	
private 
void emailButton_Click(object sender, System.EventArgs e){
	string reportName = Configuration.ReportPath + activeReport.DataMember +
		DateUtil.formatCompleteDate(System.DateTime.Now, DateUtil.MMDDYYYY);
	
	if (pdfRadioButton.Checked){
		reportName += ".pdf";
		this.pdfExport.Export(activeReport.Document, reportName);
		this.pdfExport.Dispose();
	}

	if (htmlRadioButton.Checked){
		reportName += ".html";
		this.htmlExport.Export(activeReport.Document, reportName);
		this.htmlExport.Dispose();
	}

	if (xlsRadioButton.Checked){
		reportName += ".xls";
		this.xlsExport.Export(activeReport.Document, reportName);
		this.xlsExport.Dispose();
	}
	if (rBtnRtf.Checked){
		reportName += ".rtf";
		this.rtfExport.Export(activeReport.Document, reportName);
		this.rtfExport.Dispose();
	}

	MailForm mailForm = new MailForm(reportName);
	mailForm.Show();

//	if (File.Exists(reportName))
//		File.Delete(reportName);
}

private 
void chLocButton_Click(object sender, System.EventArgs e){
	if (pdfRadioButton.Checked)
		saveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";

	if (htmlRadioButton.Checked)
		saveFileDialog1.Filter = "Htlm files (*.html)|*.html";

	if (xlsRadioButton.Checked)
		saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";

	if (rBtnRtf.Checked)
		saveFileDialog1.Filter = "Rtf files (*.rtf)|*.rtf";

	saveFileDialog1.Title = "Select an Excel file to import";
	saveFileDialog1.ShowDialog();

	if (saveFileDialog1.ValidateNames){
		filename = saveFileDialog1.FileName;
	}
}

private 
void pdfRadioButton_CheckedChanged(object sender, System.EventArgs e){
	filename = "";
}

private 
void htmlRadioButton_CheckedChanged(object sender, System.EventArgs e){
	filename = "";
}

private 
void xlsRadioButton_CheckedChanged(object sender, System.EventArgs e){
	filename = "";
}

private 
void rBtnRtf_CheckedChanged(object sender, System.EventArgs e){
	filename = "";
}


}//end Class

}//end namespace
