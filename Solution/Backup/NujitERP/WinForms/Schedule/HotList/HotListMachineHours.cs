using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Reports.HotList_Report;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Charts;
using Nujit.NujitERP.WinForms.Charts.HotListHoursChart;


namespace Nujit.NujitERP.WinForms.Schedule.HotList{


public 
class HotListMachineHours : System.Windows.Forms.Form{

private System.Windows.Forms.DataGrid gridHotList;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private FormMain formMainParent;
private System.Windows.Forms.Button button3;
private System.Windows.Forms.Button optimizeButton;
private System.Windows.Forms.GroupBox groupBox1;
private HotListHourContainer hotListHourContainer;
private System.Windows.Forms.RadioButton barRadioButton;
private System.Windows.Forms.RadioButton areaRadioButton;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.NumericUpDown daysUpDown;
	private System.Windows.Forms.Button closeButton;
	private System.Windows.Forms.Button dailiyChartButton;
	private System.Windows.Forms.Button weeklyChartButton;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.GroupBox groupBox3;
	private System.Windows.Forms.GroupBox groupBox4;
	private System.Windows.Forms.GroupBox groupBox5;
	
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

public 
HotListMachineHours(FormMain formParent){
	InitializeComponent();
	
	this.hotListHourContainer = UtilCoreFactory.createCoreFactory().getHotListHoursDays(0);//CM 11/10/2005
	this.MdiParent = formParent;
	this.formMainParent = formParent;

	loadGridHotList(false);
	setStyles();

	this.Refresh();
}

public 
HotListMachineHours(){
	InitializeComponent();
	
	this.hotListHourContainer = UtilCoreFactory.createCoreFactory().getHotListHoursDays(0);//CM 11/10/2005

	loadGridHotList(false);
	setStyles();

	this.Refresh();
}

private 
bool hotLisBlocked(){
	return this.coreFactory.isHotListBlocked();
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
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
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private 
void InitializeComponent(){
	this.optimizeButton = new System.Windows.Forms.Button();
	this.button3 = new System.Windows.Forms.Button();
	this.gridHotList = new System.Windows.Forms.DataGrid();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.groupBox5 = new System.Windows.Forms.GroupBox();
	this.groupBox4 = new System.Windows.Forms.GroupBox();
	this.dailiyChartButton = new System.Windows.Forms.Button();
	this.daysUpDown = new System.Windows.Forms.NumericUpDown();
	this.label1 = new System.Windows.Forms.Label();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.weeklyChartButton = new System.Windows.Forms.Button();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.barRadioButton = new System.Windows.Forms.RadioButton();
	this.areaRadioButton = new System.Windows.Forms.RadioButton();
	this.closeButton = new System.Windows.Forms.Button();
	((System.ComponentModel.ISupportInitialize)(this.gridHotList)).BeginInit();
	this.groupBox1.SuspendLayout();
	this.groupBox5.SuspendLayout();
	this.groupBox4.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.daysUpDown)).BeginInit();
	this.groupBox3.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.SuspendLayout();
	// 
	// optimizeButton
	// 
	this.optimizeButton.Location = new System.Drawing.Point(56, 16);
	this.optimizeButton.Name = "optimizeButton";
	this.optimizeButton.Size = new System.Drawing.Size(112, 23);
	this.optimizeButton.TabIndex = 5;
	this.optimizeButton.Text = "Optimize All";
	this.optimizeButton.Click += new System.EventHandler(this.optimizeButton_Click);
	// 
	// button3
	// 
	this.button3.Location = new System.Drawing.Point(56, 48);
	this.button3.Name = "button3";
	this.button3.Size = new System.Drawing.Size(112, 23);
	this.button3.TabIndex = 4;
	this.button3.Text = "Refresh Grid";
	this.button3.Click += new System.EventHandler(this.button3_Click);
	// 
	// gridHotList
	// 
	this.gridHotList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.gridHotList.DataMember = "";
	this.gridHotList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.gridHotList.Location = new System.Drawing.Point(16, 144);
	this.gridHotList.Name = "gridHotList";
	this.gridHotList.ReadOnly = true;
	this.gridHotList.Size = new System.Drawing.Size(896, 280);
	this.gridHotList.TabIndex = 1;
	this.gridHotList.Click += new System.EventHandler(this.gridHotList_Click);
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.groupBox5);
	this.groupBox1.Controls.Add(this.groupBox4);
	this.groupBox1.Controls.Add(this.groupBox3);
	this.groupBox1.Controls.Add(this.groupBox2);
	this.groupBox1.Location = new System.Drawing.Point(16, 16);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(896, 120);
	this.groupBox1.TabIndex = 6;
	this.groupBox1.TabStop = false;
	// 
	// groupBox5
	// 
	this.groupBox5.Controls.Add(this.optimizeButton);
	this.groupBox5.Controls.Add(this.button3);
	this.groupBox5.Location = new System.Drawing.Point(640, 24);
	this.groupBox5.Name = "groupBox5";
	this.groupBox5.Size = new System.Drawing.Size(224, 80);
	this.groupBox5.TabIndex = 16;
	this.groupBox5.TabStop = false;
	// 
	// groupBox4
	// 
	this.groupBox4.Controls.Add(this.dailiyChartButton);
	this.groupBox4.Controls.Add(this.daysUpDown);
	this.groupBox4.Controls.Add(this.label1);
	this.groupBox4.Location = new System.Drawing.Point(216, 24);
	this.groupBox4.Name = "groupBox4";
	this.groupBox4.Size = new System.Drawing.Size(208, 80);
	this.groupBox4.TabIndex = 15;
	this.groupBox4.TabStop = false;
	// 
	// dailiyChartButton
	// 
	this.dailiyChartButton.Location = new System.Drawing.Point(24, 16);
	this.dailiyChartButton.Name = "dailiyChartButton";
	this.dailiyChartButton.Size = new System.Drawing.Size(112, 23);
	this.dailiyChartButton.TabIndex = 6;
	this.dailiyChartButton.Text = "Daily Chart";
	this.dailiyChartButton.Click += new System.EventHandler(this.chartButton_Click);
	// 
	// daysUpDown
	// 
	this.daysUpDown.Location = new System.Drawing.Point(72, 56);
	this.daysUpDown.Maximum = new System.Decimal(new int[] {
															   60,
															   0,
															   0,
															   0});
	this.daysUpDown.Minimum = new System.Decimal(new int[] {
															   1,
															   0,
															   0,
															   0});
	this.daysUpDown.Name = "daysUpDown";
	this.daysUpDown.Size = new System.Drawing.Size(56, 20);
	this.daysUpDown.TabIndex = 9;
	this.daysUpDown.Value = new System.Decimal(new int[] {
															 15,
															 0,
															 0,
															 0});
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(24, 56);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(32, 16);
	this.label1.TabIndex = 10;
	this.label1.Text = "Days";
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.weeklyChartButton);
	this.groupBox3.Location = new System.Drawing.Point(432, 24);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(200, 80);
	this.groupBox3.TabIndex = 14;
	this.groupBox3.TabStop = false;
	// 
	// weeklyChartButton
	// 
	this.weeklyChartButton.Location = new System.Drawing.Point(40, 32);
	this.weeklyChartButton.Name = "weeklyChartButton";
	this.weeklyChartButton.Size = new System.Drawing.Size(112, 23);
	this.weeklyChartButton.TabIndex = 12;
	this.weeklyChartButton.Text = "Weekly Chart";
	this.weeklyChartButton.Click += new System.EventHandler(this.weeklyChartButton_Click);
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.barRadioButton);
	this.groupBox2.Controls.Add(this.areaRadioButton);
	this.groupBox2.Location = new System.Drawing.Point(40, 24);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(168, 80);
	this.groupBox2.TabIndex = 13;
	this.groupBox2.TabStop = false;
	this.groupBox2.Text = "Chart Type";
	// 
	// barRadioButton
	// 
	this.barRadioButton.Checked = true;
	this.barRadioButton.Location = new System.Drawing.Point(24, 24);
	this.barRadioButton.Name = "barRadioButton";
	this.barRadioButton.Size = new System.Drawing.Size(72, 16);
	this.barRadioButton.TabIndex = 7;
	this.barRadioButton.TabStop = true;
	this.barRadioButton.Text = "Bars";
	// 
	// areaRadioButton
	// 
	this.areaRadioButton.Location = new System.Drawing.Point(24, 48);
	this.areaRadioButton.Name = "areaRadioButton";
	this.areaRadioButton.Size = new System.Drawing.Size(64, 16);
	this.areaRadioButton.TabIndex = 8;
	this.areaRadioButton.Text = "Area";
	// 
	// closeButton
	// 
	this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.closeButton.Location = new System.Drawing.Point(784, 432);
	this.closeButton.Name = "closeButton";
	this.closeButton.Size = new System.Drawing.Size(112, 23);
	this.closeButton.TabIndex = 11;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// HotListMachineHours
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(926, 462);
	this.Controls.Add(this.groupBox1);
	this.Controls.Add(this.gridHotList);
	this.Controls.Add(this.closeButton);
	this.Name = "HotListMachineHours";
	this.Text = "Hot List Machine Hours";
	this.Closing += new System.ComponentModel.CancelEventHandler(this.HotListMachineHours_Closing);
	this.Closed += new System.EventHandler(this.OnClose);
	((System.ComponentModel.ISupportInitialize)(this.gridHotList)).EndInit();
	this.groupBox1.ResumeLayout(false);
	this.groupBox5.ResumeLayout(false);
	this.groupBox4.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.daysUpDown)).EndInit();
	this.groupBox3.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion


private 
void gridHotList_Click(object sender, System.EventArgs e){
	if (gridHotList.TableStyles.Count > 0){
		gridHotList.PreferredRowHeight = 10;
		DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
		dgdtblStyle = gridHotList.TableStyles[0];
		dgdtblStyle.PreferredRowHeight = 10;
	}
}

public
void loadGridHotList(bool charge){
	lock(this){
		if (charge)
			hotListHourContainer = UtilCoreFactory.createCoreFactory().getHotListHoursDays(0);//CM 11/10/2005

		DataSet dsHotList = LoadHotListGrid.generateHotListHoursDataSet(hotListHourContainer);

		if (dsHotList != null && dsHotList.Tables.Count >0 ){
			this.gridHotList.DataSource = dsHotList.Tables[0];

			int numRows = 0;
			if (dsHotList.Tables.Count>0)
				numRows = dsHotList.Tables[0].Rows.Count;

			string[] v = coreFactory.getHotListLogData();
			
			gridHotList.CaptionText = numRows.ToString() + " records generated, " + 
				"Hotlist Generated on : " + v[0] + ", Material Explosion on : " + v[1];

			gridHotList = LoadHotListGrid.initializeItemsGridHours(dsHotList, gridHotList);

			gridHotList.Refresh();
		}
		else{
			this.gridHotList.DataSource = null;
			MessageBox.Show("HotList is empty or something wrong");
		}
		this.Cursor = Cursors.Default;
	}
}//end loadGridHotList

private 
void button3_Click(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
	if (formMainParent != null)
		formMainParent.statusBarPanelMessage.Text	= "Loading grid...";
	
	loadGridHotList(true);
	
	this.Cursor = System.Windows.Forms.Cursors.Default;
	if (formMainParent != null)
		formMainParent.statusBarPanelMessage.Text	= "Done!";
}

private 
void OnClose(object sender, System.EventArgs e){
	if (this.formMainParent != null){
		this.formMainParent.RemoveTab(this.Tag);
		this.formMainParent.SetButtons();
	}
	this.coreFactory = null;
}

private 
void setStyles(){
	if (gridHotList.TableStyles.Count > 0){
		gridHotList.PreferredRowHeight = 10;
		DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
		dgdtblStyle = gridHotList.TableStyles[0];
		dgdtblStyle.PreferredRowHeight = 10;
	}
}

private 
void optimizeButton_Click(object sender, System.EventArgs e){
	hotListHourContainer.optimize();
	loadGridHotList(false);
}

private 
void chartButton_Click(object sender, System.EventArgs e){
	int rowNumber = gridHotList.CurrentCell.RowNumber;
	if (rowNumber < 0){
		DialogResult deleteConfirm = MessageBox.Show("You have to select a row before !!");
		return;
	}

	HotListHour hotListHour = hotListHourContainer.getHotListHour(gridHotList[rowNumber, 0].ToString());
	int dayCounter = decimal.ToInt32(daysUpDown.Value);

	decimal[] demand = hotListHour.getDemandDays();
	double[] newDemand = new double[dayCounter + 1];
	for(int i = 0; i < dayCounter + 1; i++)
		newDemand[i] = decimal.ToDouble(decimal.Round(demand[i] * -1, 2));

	decimal[] capacity = hotListHour.getCapacityDays();
	double[] newCapacity = new double[dayCounter + 1];
	for(int i = 0; i < dayCounter + 1; i++)
		newCapacity[i] = decimal.ToDouble(decimal.Round(capacity[i], 2));

	double[][] dataOfData = new double[2][];
	dataOfData[0] = newDemand;
	dataOfData[1] = newCapacity;

	string[] labelsOfBars = {"Demand", "Capacity"};

	string[] labels = new string[dayCounter + 1];
	string[] v = coreFactory.getHotListLogData();
	DateTime today = DateUtil.parseDate(v[0].Substring(0, 10), DateUtil.MMDDYYYY);
	labels[0] = "Past Due";
	for(int i = 1; i < dayCounter + 1; i++){
		labels[i] = DateUtil.getDateRepresentation(today, DateUtil.MMDDYYYY).Substring(0, 5);
		today = today.AddDays(1);
	}

	string title = "Hot List Hours By Configuration (" + gridHotList[rowNumber, 0].ToString() + ")";
	HotListHoursChart hotListHoursChart = null;
	if (this.areaRadioButton.Checked)
		hotListHoursChart = new HotListHoursChart(dataOfData, labels, labelsOfBars, GenericChart.AREA_CHART, title);
	else	
		hotListHoursChart = new HotListHoursChart(dataOfData, labels, labelsOfBars, GenericChart.XY_MULTI_CHART, title);	
	hotListHoursChart.Show();
}

private 
void closeButton_Click(object sender, System.EventArgs e){
	this.coreFactory = null;
	Close();
}

private 
void weeklyChartButton_Click(object sender, System.EventArgs e){
	int rowNumber = gridHotList.CurrentCell.RowNumber;
	if (rowNumber < 0){
		DialogResult deleteConfirm = MessageBox.Show("You have to select a row before !!");
		return;
	}

	HotListHour hotListHour = hotListHourContainer.getHotListHour(gridHotList[rowNumber, 0].ToString());
	
	decimal[] demand = hotListHour.getDemandDays();
	double[] newDemand = new double[10];
	for(int i = 0; i < demand.Length; i++){
		if (i == 0){
			newDemand[0] = decimal.ToDouble(decimal.Round(demand[0] * -1, 2)); // past due
			continue;
		}
		if (i < 8){
			newDemand[1] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 15){
			newDemand[2] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 22){
			newDemand[3] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 29){
			newDemand[4] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 36){
			newDemand[5] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 43){
			newDemand[6] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 50){
			newDemand[7] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 57){
			newDemand[8] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
		if (i < 64){
			newDemand[9] += decimal.ToDouble(decimal.Round(demand[i] * -1, 2));
			continue;
		}
	}

	decimal[] capacity = hotListHour.getCapacityDays();
	double[] newCapacity = new double[10];

	for(int i = 0; i < capacity.Length; i++){
		if (i == 0){
			newCapacity[0] = decimal.ToDouble(decimal.Round(capacity[0], 2)); // past due
			continue;
		}
		if (i < 8){
			newCapacity[1] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 15){
			newCapacity[2] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 22){
			newCapacity[3] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 29){
			newCapacity[4] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 36){
			newCapacity[5] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 43){
			newCapacity[6] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 50){
			newCapacity[7] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 57){
			newCapacity[8] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
		if (i < 64){
			newCapacity[9] += decimal.ToDouble(decimal.Round(capacity[i], 2));
			continue;
		}
	}

	double[][] dataOfData = new double[2][];
	dataOfData[0] = newDemand;
	dataOfData[1] = newCapacity;

	string[] labelsOfBars = {"Demand", "Capacity"};

	string[] v = coreFactory.getHotListLogData();
	DateTime today = DateUtil.parseDate(v[0].Substring(0, 10), DateUtil.MMDDYYYY);

	string[] labels = new string[10];
	labels[0] = "Past Due";
	labels[1] = today.ToString("MM/dd") + " - " + today.AddDays(6).ToString("MM/dd");
	labels[2] = today.AddDays(7).ToString("MM/dd") + " - " + today.AddDays(13).ToString("MM/dd");
	labels[3] = today.AddDays(14).ToString("MM/dd") + " - " + today.AddDays(20).ToString("MM/dd");
	labels[4] = today.AddDays(21).ToString("MM/dd") + " - " + today.AddDays(27).ToString("MM/dd");
	labels[5] = today.AddDays(28).ToString("MM/dd") + " - " + today.AddDays(34).ToString("MM/dd");
	labels[6] = today.AddDays(35).ToString("MM/dd") + " - " + today.AddDays(41).ToString("MM/dd");
	labels[7] = today.AddDays(42).ToString("MM/dd") + " - " + today.AddDays(48).ToString("MM/dd");
	labels[8] = today.AddDays(49).ToString("MM/dd") + " - " + today.AddDays(55).ToString("MM/dd");
	labels[9] = today.AddDays(56).ToString("MM/dd") + " - " + today.AddDays(62).ToString("MM/dd");

	string title = "Hot List Hours By Configuration (" + gridHotList[rowNumber, 0].ToString() + ")";
	HotListHoursChart hotListHoursChart = null;
	if (this.areaRadioButton.Checked)
		hotListHoursChart = new HotListHoursChart(dataOfData, labels, labelsOfBars, GenericChart.AREA_CHART, title);
	else
		hotListHoursChart = new HotListHoursChart(dataOfData, labels, labelsOfBars, GenericChart.XY_MULTI_CHART, title);	

	hotListHoursChart.Show();
}

private 
void HotListMachineHours_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.coreFactory = null;
}



}//end class

} // namespace
