using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Nujit.NujitERP.WinForms.Util;
using ChartDirector;


namespace Nujit.NujitERP.WinForms.Charts{

public abstract
class GenericChart : Form{

private System.ComponentModel.Container components = null;
private System.Windows.Forms.Button button1;
private System.Windows.Forms.Button exportButton;
private System.Windows.Forms.GroupBox gBoxReportFormat;
private System.Windows.Forms.PictureBox viewer;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Panel panel2;
private System.Windows.Forms.Panel panel3;
private System.Windows.Forms.Panel panel4;
private System.Windows.Forms.Button emailButton;
private System.Windows.Forms.SaveFileDialog saveFileDialog1;
private System.Windows.Forms.Button chLocButton;
private string filename = "";
private int chartType;
private double[] data;
private double[][] dataOfData;
private string[] labels;
private string[] labelsOfBars;
private string title = "";
private string ytitle = "";
private int gradeTextLabels = 0;

//legend
private int		xlegend=100;
private	int		ylegend=100; 
private	bool	verticalLegend=true;
private string	fontNameLegend="timesbi.ttf";
private	int		fontSizeLegend=9;	

public const int PIE_CHART = 100;
public const int XY_CHART = 200;
public const int XY_MULTI_CHART = 300;
private System.Windows.Forms.Button button2;
public const int AREA_CHART = 400;

public 
GenericChart(int chartType,  string title, double[] data, string[] labels){
	this.chartType = chartType;
	this.data = data;
	this.labels = labels;
	this.title = title;

	InitializeComponent();
	buildChart();
}

public 
GenericChart(int chartType, string title, string sytitle, double[][] dataOfData, string[] labels, 
		int gradeTextLabels, string[] labelsOfBars){
	
	this.chartType = chartType;
	this.dataOfData = dataOfData;
	this.labels = labels;
	this.labelsOfBars = labelsOfBars;
	this.title = title;
	this.ytitle = ytitle;
	this.gradeTextLabels = gradeTextLabels;

	InitializeComponent();
	buildChart();
}

public 
GenericChart(string title, int chartType, double[] data, string[] labels, int gradeTextLabels, string[] labelsOfBars){
	this.chartType = chartType;
	this.data = data;
	this.labels = labels;
	this.title = title;
	this.gradeTextLabels = gradeTextLabels;
	this.labelsOfBars = labelsOfBars;

	InitializeComponent();
	buildChart();
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
	this.exportButton = new System.Windows.Forms.Button();
	this.emailButton = new System.Windows.Forms.Button();
	this.gBoxReportFormat = new System.Windows.Forms.GroupBox();
	this.button2 = new System.Windows.Forms.Button();
	this.chLocButton = new System.Windows.Forms.Button();
	this.viewer = new System.Windows.Forms.PictureBox();
	this.panel1 = new System.Windows.Forms.Panel();
	this.panel4 = new System.Windows.Forms.Panel();
	this.panel3 = new System.Windows.Forms.Panel();
	this.panel2 = new System.Windows.Forms.Panel();
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
	// gBoxReportFormat
	// 
	this.gBoxReportFormat.Controls.Add(this.button2);
	this.gBoxReportFormat.Controls.Add(this.chLocButton);
	this.gBoxReportFormat.Controls.Add(this.emailButton);
	this.gBoxReportFormat.Controls.Add(this.exportButton);
	this.gBoxReportFormat.Location = new System.Drawing.Point(24, 16);
	this.gBoxReportFormat.Name = "gBoxReportFormat";
	this.gBoxReportFormat.Size = new System.Drawing.Size(520, 48);
	this.gBoxReportFormat.TabIndex = 11;
	this.gBoxReportFormat.TabStop = false;
	this.gBoxReportFormat.Text = "Chart Format";
	// 
	// button2
	// 
	this.button2.Location = new System.Drawing.Point(112, 16);
	this.button2.Name = "button2";
	this.button2.Size = new System.Drawing.Size(88, 23);
	this.button2.TabIndex = 13;
	this.button2.Text = "Print";
	this.button2.Click += new System.EventHandler(this.button2_Click);
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
	// viewer
	// 
	this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
	this.viewer.Location = new System.Drawing.Point(0, 0);
	this.viewer.Name = "viewer";
	this.viewer.Size = new System.Drawing.Size(912, 550);
	this.viewer.TabIndex = 0;
	this.viewer.TabStop = false;
	// 
	// panel1
	// 
	this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.panel1.Controls.Add(this.panel4);
	this.panel1.Controls.Add(this.panel3);
	this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
	this.panel1.Location = new System.Drawing.Point(0, 550);
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
	this.panel2.Size = new System.Drawing.Size(912, 550);
	this.panel2.TabIndex = 13;
	// 
	// GenericChart
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(912, 622);
	this.Controls.Add(this.panel2);
	this.Controls.Add(this.panel1);
	this.MinimumSize = new System.Drawing.Size(920, 592);
	this.Name = "GenericChart";
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
	generateChart();
	filename = "";
}

private 
void generateChart(){ // solo para exportar
	if (filename.Equals(""))
		filename = Configuration.ReportPath + "\\" + "chart" +
			DateUtil.formatCompleteDate(System.DateTime.Now, DateUtil.MMDDYYYY);
	
	viewer.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);

	ShellLib.ShellExecute shellExec  = new ShellLib.ShellExecute();
	shellExec.Path = @filename;
	shellExec.Execute();	
}

private 
void buildChart(){
	switch(chartType){
	case PIE_CHART:
		viewer.Image = pieChart();
		break;
	case XY_CHART:
		viewer.Image = xyChart();
		break;
	case XY_MULTI_CHART:
		viewer.Image = xyMultiChart();
		break;
	case AREA_CHART:
		viewer.Image = areaChart();
		break;
	}
}

private 
void button1_Click(object sender, System.EventArgs e){
	Close();
}

private 
void emailButton_Click(object sender, System.EventArgs e){
	string expfileName = Configuration.ReportPath + "chart" +
		DateUtil.formatCompleteDate(System.DateTime.Now, DateUtil.MMDDYYYY);
		expfileName += ".png";
	
	if (File.Exists(expfileName))
		File.Delete(expfileName);

	viewer.Image.Save(expfileName, System.Drawing.Imaging.ImageFormat.Png);

	MailForm mailForm = new MailForm(expfileName);
	mailForm.Show();
}

private 
void chLocButton_Click(object sender, System.EventArgs e){
	saveFileDialog1.Filter = "Png files (*.png)|*.png";

	saveFileDialog1.Title = "Select an Image file to export";
	saveFileDialog1.ShowDialog();

	if (saveFileDialog1.ValidateNames){
		filename = saveFileDialog1.FileName;
	}
}

private
System.Drawing.Image pieChart(){
    //query string to determine the starting angle and direction
    int angle = 0;
	int i=0;
    bool clockwise = true;

    //Create a PieChart object of size 280 x 240 pixels
    PieChart c = new PieChart(getChartWidth(), getChartHeight());

    //Set the center of the pie at (140, 130) and the radius to 80 pixels
    c.setPieSize(getX(), getY(), getR());	 
		
    //Add a title to the pie
    c.addTitle(title,this.getFontName(),this.getFontSize());

    //Set the pie start angle and direction
    c.setStartAngle(angle, clockwise);

    //Draw the pie in 3D
	c.set3D(-1, getPieChartGrade());
	c.set3D(getPieChartDeptht());

	//if there are a lot of depths , we can use the depth for each sector
	double[] depths = getPieChartDepthts();
	if (depths.Length > 0)
		c.set3D2(depths);
	
	if (getIfSmallSector())
		c.setLabelStyle().setBackground(Chart.SameAsMainColor, Chart.Transparent, 1);

    //Set the pie data and the pie labels
    c.setData(data, labels);

	c.setLabelFormat(getLabelFormat());

	if  (getIfAddLegend(out xlegend,out ylegend, out verticalLegend,out fontNameLegend,out fontSizeLegend))
		c.addLegend(xlegend, ylegend, verticalLegend, fontNameLegend, fontSizeLegend);			    

	//get the pos in pixel , from de center of the pie chart
	c.setLabelPos(this.getPieChartLabelPos());

    //explode the sector
	bool[] explodeSector = getPieChartExplodeSector();
	for (i=0; i < explodeSector.Length;i++){
		if (explodeSector[i])
			c.setExplode(i);
	}		    

	//background color
	c.setBackground(c.gradientColor(getBackgroundGradientColor()), -1, 2);

    //output the chart
    return c.makeImage();
}

private
System.Drawing.Image xyChart(){
    XYChart c = new XYChart(getChartWidth(), getChartHeight());

    c.setPlotArea(50, 40, viewer.Width - 60, viewer.Height - 80);

    //Configure the axis as according to the input parameter
    c.addTitle(title, getFontName(), getFontSize(), Chart.CColor(getTitleFontColor()));

    //Set the labels on the x axis
    c.xAxis().setLabels(labels);

	if  (getIfAddLegend(out xlegend,out ylegend, out verticalLegend,out fontNameLegend,out fontSizeLegend))
		c.addLegend(xlegend, ylegend, verticalLegend, fontNameLegend, fontSizeLegend);			    

	c.xAxis().setLabels(labels).setFontAngle(gradeTextLabels);

    //Add a color bar layer using the given data. Use a 1 pixel 3D border for the
    //bars.
	Color[] colors = getColors();
	if (colors.Length > 0){
		int[] colors2 = new int[colors.Length];
		for(int k = 0; k < colors.Length; k++)
			colors2[k] = Chart.CColor(colors[k]);

		c.addBarLayer3(data, colors2).setBorderColor(-1, 1);
	}else{
		c.addBarLayer3(data).setBorderColor(-1, 1);
	}

	//background color
	if (isBackgroundEnable())
		c.setBackground(c.gradientColor(getBackgroundGradientColor()), -1, 2);

	//y title
	c.yAxis().setTitle(ytitle, "arialbd.ttf", 7, 0);
	c.yAxis().setLabelStyle("arialbd.ttf", 7,0);

	for(int z = 0; z < labelsOfBars.Length; z++)
		c.xAxis2().addLabel(z, labelsOfBars[z]);

    return c.makeImage();
}

private
System.Drawing.Image xyMultiChart(){
    XYChart c = new XYChart(getChartWidth(), getChartHeight());

    //Set the plot area at (30, 20) and of size of the viewer
//    c.setPlotArea(30, 20, viewer.Width - 30, viewer.Height - 20);
    c.setPlotArea(50, 20, viewer.Width - 60, viewer.Height - 100);

	c.addTitle(title,this.getFontName(),this.getFontSize());

    //Set the labels on the x axis    
	c.xAxis().setLabels(labels).setFontAngle(this.gradeTextLabels);

	if  (getIfAddLegend(out xlegend,out ylegend, out verticalLegend,out fontNameLegend,out fontSizeLegend))
		c.addLegend(xlegend, ylegend, verticalLegend, fontNameLegend, fontSizeLegend);			    

    //Add a color bar layer using the given data. Use a 1 pixel 3D border for the

	c.addLegend(45, 20, false, "", 8).setBackground(Chart.Transparent);
	c.yAxis().setTopMargin(20);

	Color[] colors = getColors();

	if (!getIfDephtBarChart()){
		Layer layer = c.addBarLayer2(Chart.Side, 2); 	
		for(int i = 0; i < labelsOfBars.Length; i++){
			if (colors.Length > 0)
				layer.addDataSet(dataOfData[i], Chart.CColor(colors[i]), labelsOfBars[i]);
			else
				layer.addDataSet(dataOfData[i], -1, labelsOfBars[i]);
		}
		layer.setAggregateLabelFormat(this.getLabelFormat());		
	}
	else
	{
		for(int i = 0; i < labelsOfBars.Length; i++)
		{
			if (colors.Length > 0)
				c.addBarLayer(dataOfData[i], Chart.CColor(colors[i]), labelsOfBars[i], 5);				
			else
				c.addBarLayer(dataOfData[i], -1, labelsOfBars[i], 5);
		}
	}


	//background color
	if (isBackgroundEnable())
		c.setBackground(c.gradientColor(getBackgroundGradientColor()), -1, 2);

	//y title
	c.yAxis().setTitle(ytitle, "arialbd.ttf", 7, 0);
	c.yAxis().setLabelStyle("arialbd.ttf", 7,0);
	
    //output the chart
    return c.makeImage();
}

private
System.Drawing.Image areaChart(){
    XYChart c = new XYChart(getChartWidth(), getChartHeight());

    //Set the plot area at (30, 20) and of size of the viewer
	//    c.setPlotArea(30, 20, viewer.Width - 30, viewer.Height - 20);    
	c.setPlotArea(30, 20, viewer.Width - 60, viewer.Height - 60);	

    c.addTitle(title,this.getFontName(),this.getFontSize());

    //Set the labels on the x axis
    c.xAxis().setLabels(labels);

	if (getIfAddLegend(out xlegend,out ylegend, out verticalLegend,out fontNameLegend,out fontSizeLegend))
		c.addLegend(xlegend, ylegend, verticalLegend, fontNameLegend, fontSizeLegend);			    

	c.addLegend(55, 0, false, "", 8).setBackground(Chart.Transparent);

	//Add a title to the x axis
	c.xAxis().setTitle("");	

	//Add a title to the y axis
	c.yAxis().setTitle("");

	c.xAxis().setLabels(labels);
	
	Layer layer = c.addBarLayer2(Chart.Side, 2);

 	Color[] colors = getColors();
	for(int i = 0; i < labelsOfBars.Length; i++){
		if (colors.Length > 0)
			c.addAreaLayer(dataOfData[i], Chart.CColor(colors[i]), labelsOfBars[i], 3);
		else
			c.addAreaLayer(dataOfData[i], -1, labelsOfBars[i], 3);
	}	

	//background color
	if (isBackgroundEnable())
		c.setBackground(c.gradientColor(getBackgroundGradientColor()), -1, 2);

    //output the chart
    return c.makeImage();	
}

public 
void setGradeTextLabels(int gradeTextLabels){
	this.gradeTextLabels = gradeTextLabels;
}

public 
void setYTitle(string  ytitle){
	this.ytitle = ytitle;	
}

public 
int getX(){ 
	return viewer.Width / 2; 
}//x center in the form

public 
int getY(){ 
	return viewer.Height / 2; 
}//y center in the form

public 
int getR(){ 
	return viewer.Width / 4; 
}//radio o the pie chart

public virtual 
Color[] getColors(){ return new Color[0]; }

public virtual 
Color getTitleFontColor(){ 
	return Color.Black;
}

public virtual 
int[] getBackgroundGradientColor(){ 
	return Chart.goldGradient;
}

//title
public virtual 
int getFontSize(){ 
	return 13; 
}

public virtual 
string getFontName(){ 
	return "timesbi.ttf";
}

//multi char 	
public virtual 
bool getIfDephtBarChart(){
	return false;
}

public virtual 
string getLabelFormat(){ //format for the labels
	if (chartType == PIE_CHART)
		return "{label} %{value}";

	return "{value}";
}

//pie chart
public virtual 
int getPieChartGrade(){ 
	return 45;
}//inclined angle

public virtual 
int getPieChartDeptht(){ 
	return 40;
}//depth 

public virtual 
bool getIfSmallSector(){
	return false;
}//small sectors with the same color as the chart

public virtual 
double[] getPieChartDepthts(){
	return new double[0];
}//depths by sector

public virtual 
bool[] getPieChartExplodeSector(){
	return new bool[0];
}//explode any sector, true,false

public virtual 
int getPieChartLabelPos(){
	return 20;
}//pie char label pos from the perimeter of the pie , negative to inside the pie chart

public virtual 
bool getIfAddLegend(out int x,out int y, out bool vertical,out string fontName,out int fontSize){
	x = 100;
	y =  100;
	vertical = true;
	fontName = "timesbi.ttf";
	fontSize = 9;	

	return false;
}

private 
void button2_Click(object sender, System.EventArgs e){
	ImageReport imageReport = new ImageReport("Print : " + title, viewer.Image);
	imageReport.Show();
}

public virtual 
int getChartWidth(){
	return viewer.Width;
}

public virtual 
int getChartHeight(){
	return viewer.Height;
}

public virtual 
bool isBackgroundEnable(){
	return false;
}//small sectors with the same color as the chart


}//end Class

}//end namespace
