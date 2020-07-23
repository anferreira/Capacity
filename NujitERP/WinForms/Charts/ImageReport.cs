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

using Nujit.NujitERP.WinForms.Master;


namespace Nujit.NujitERP.WinForms.Charts{

public 
class ImageReport : Form{

private System.ComponentModel.Container components = null;
private DataSet dataSet;
private System.Windows.Forms.Button button1;
private DataDynamics.ActiveReports.Viewer.Viewer viewer;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Panel panel2;
private System.Windows.Forms.Panel panel3;
private ActiveReport3 activeReport;
private System.Windows.Forms.RichTextBox leyendRichTextBox;
private System.Windows.Forms.Button refreshButton;
private System.Windows.Forms.Label label1;
//private System.Drawing.Image image;
private System.Drawing.Image[] images;


public 
ImageReport(string text, System.Drawing.Image image){
	InitializeComponent();

	this.Text = text;
	this.dataSet = new DataSet();

	DataTable dataTable = new DataTable();
	dataTable.TableName = "CLOTY";
	dataTable.Columns.Add("A");
	DataRow dataRow = dataTable.NewRow();
	dataRow[0] = "";
	dataTable.Rows.Add(dataRow);

	dataSet.Tables.Add(dataTable);

	this.images = new System.Drawing.Image[1];
	this.images[0] = image;

	buildReport();
}

public 
ImageReport(string text, System.Drawing.Image[] images){
	InitializeComponent();

	this.Text = text;
	this.dataSet = new DataSet();

	DataTable dataTable = new DataTable();
	dataTable.TableName = "CLOTY";
	dataTable.Columns.Add("A");
	
	int to = 1;
	
	if (images.Length != 1)
		to = decimal.ToInt32(images.Length / 3);

	for(int i = 0; i < to; i++){
		DataRow dataRow = dataTable.NewRow();
		dataRow[0] = "";
		dataTable.Rows.Add(dataRow);
	}

	dataSet.Tables.Add(dataTable);

	this.images = images;

	buildReport();
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
	this.button1 = new System.Windows.Forms.Button();
	this.viewer = new DataDynamics.ActiveReports.Viewer.Viewer();
	this.panel1 = new System.Windows.Forms.Panel();
	this.label1 = new System.Windows.Forms.Label();
	this.leyendRichTextBox = new System.Windows.Forms.RichTextBox();
	this.panel3 = new System.Windows.Forms.Panel();
	this.refreshButton = new System.Windows.Forms.Button();
	this.panel2 = new System.Windows.Forms.Panel();
	this.panel1.SuspendLayout();
	this.panel3.SuspendLayout();
	this.panel2.SuspendLayout();
	this.SuspendLayout();
	// 
	// button1
	// 
	this.button1.Location = new System.Drawing.Point(168, 32);
	this.button1.Name = "button1";
	this.button1.Size = new System.Drawing.Size(104, 23);
	this.button1.TabIndex = 4;
	this.button1.Text = "Close";
	this.button1.Click += new System.EventHandler(this.button1_Click);
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
	this.viewer.Size = new System.Drawing.Size(912, 470);
	this.viewer.TabIndex = 0;
	this.viewer.TableOfContents.Text = "Contents";
	this.viewer.TableOfContents.Width = 200;
	this.viewer.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	// 
	// panel1
	// 
	this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.panel1.Controls.Add(this.label1);
	this.panel1.Controls.Add(this.leyendRichTextBox);
	this.panel1.Controls.Add(this.panel3);
	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
	this.panel1.Location = new System.Drawing.Point(0, 470);
	this.panel1.Name = "panel1";
	this.panel1.Size = new System.Drawing.Size(912, 88);
	this.panel1.TabIndex = 12;
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(120, 8);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 16);
	this.label1.TabIndex = 3;
	this.label1.Text = "Add text here";
	// 
	// leyendRichTextBox
	// 
	this.leyendRichTextBox.Location = new System.Drawing.Point(32, 24);
	this.leyendRichTextBox.Name = "leyendRichTextBox";
	this.leyendRichTextBox.Size = new System.Drawing.Size(520, 50);
	this.leyendRichTextBox.TabIndex = 1;
	this.leyendRichTextBox.Text = "";
	// 
	// panel3
	// 
	this.panel3.AutoScroll = true;
	this.panel3.Controls.Add(this.button1);
	this.panel3.Controls.Add(this.refreshButton);
	this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
	this.panel3.Location = new System.Drawing.Point(564, 0);
	this.panel3.Name = "panel3";
	this.panel3.Size = new System.Drawing.Size(344, 84);
	this.panel3.TabIndex = 0;
	// 
	// refreshButton
	// 
	this.refreshButton.Location = new System.Drawing.Point(64, 32);
	this.refreshButton.Name = "refreshButton";
	this.refreshButton.Size = new System.Drawing.Size(96, 23);
	this.refreshButton.TabIndex = 2;
	this.refreshButton.Text = "Refresh Report";
	this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
	// 
	// panel2
	// 
	this.panel2.Controls.Add(this.viewer);
	this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
	this.panel2.Location = new System.Drawing.Point(0, 0);
	this.panel2.Name = "panel2";
	this.panel2.Size = new System.Drawing.Size(912, 470);
	this.panel2.TabIndex = 13;
	// 
	// ImageReport
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(912, 558);
	this.Controls.Add(this.panel2);
	this.Controls.Add(this.panel1);
	this.MinimumSize = new System.Drawing.Size(920, 592);
	this.Name = "ImageReport";
	this.panel1.ResumeLayout(false);
	this.panel3.ResumeLayout(false);
	this.panel2.ResumeLayout(false);
	this.ResumeLayout(false);

}

#endregion


private 
void buildReport(){
	activeReport = new rptChartReport(images);
	activeReport.SetLicense("Mauricio Della-Quercia,Nujit Inc.,DD-ARN-10-E000241, CXATZQQXKZ3J5Q2542Q9");
	activeReport.DataSource = dataSet;
	activeReport.DataMember = "CLOTY";
	viewer.Document = activeReport.Document;
	activeReport.Run();
}

private 
void button1_Click(object sender, System.EventArgs e){
	Close();
}

private 
void addTextButton_Click(object sender, System.EventArgs e){
}

private 
void refreshButton_Click(object sender, System.EventArgs e){
	this.dataSet = new DataSet();

	DataTable dataTable = new DataTable();
	dataTable.TableName = "CLOTY";
	dataTable.Columns.Add("A");

	for(int i = 0; i < images.Length; i++){
		DataRow dataRow = dataTable.NewRow();
		dataRow[0] = leyendRichTextBox.Text;
		dataTable.Rows.Add(dataRow);
	}

	dataSet.Tables.Add(dataTable);

//	this.image = image;
	buildReport();
}




	

}//end Class

}//end namespace
