using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Charts;
using Nujit.NujitERP.WinForms.Charts.HotListHoursChart;
using ChartDirector;


namespace Nujit.NujitERP.WinForms.Master.ChartsReports{


public 
class FormChartProductionHistory : System.Windows.Forms.Form{


private System.Windows.Forms.Button btnRefresh;
private System.Windows.Forms.Button btnClose;
private System.Windows.Forms.TreeView chartTypeTree;
private System.Windows.Forms.TextBox textBoxDateEnd;
private System.Windows.Forms.TextBox textBoxDateStart;
private System.Windows.Forms.MonthCalendar monthCalendarEnd;
private System.Windows.Forms.MonthCalendar monthCalendarStart;

private System.ComponentModel.Container components = null;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private ArrayList arrayListReport = null;
private DataTable reportDataTable = new DataTable();
private System.Windows.Forms.RadioButton downTimeradio;
private System.Windows.Forms.RadioButton setupTimeradio;
private System.Windows.Forms.RadioButton runTimeradio;
private System.Windows.Forms.DataGrid dgCollection;
private TypeReport typeReport = TypeReport.REPORT_PLANT;
private System.Windows.Forms.Button chartButton;

private PrHistComplScrappedChart prHistComplScrappedChart = null;

private TreeNode treeNodeRoot = null;
private TreeNode treeNodeDepartment = null;
private TreeNode treeNodeShift = null;
private TreeNode treeNodeMachine = null;
private TreeNode treeNodePlant = null;
private TreeNode treeNodePart = null;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button button1;
private TreeNode treeNodeSeq = null;
private TreeNode Root = null;
private System.Windows.Forms.Button allChartsButton;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.Button allDetailedScrapButton;
private TreeNode lastSelected = null;


public 
enum TypeReport : int{
	REPORT_COMPANY = 0,
	REPORT_PLANT = 1,
	REPORT_SHIFT = 2,
	REPORT_DEPT = 3,
	REPORT_MACHINE = 4,
	REPORT_PART = 5,
	REPORT_PART_SEQ = 6
}

public 
FormChartProductionHistory(){
	InitializeComponent();
	setDefaultValues();
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
	this.btnRefresh = new System.Windows.Forms.Button();
	this.btnClose = new System.Windows.Forms.Button();
	this.chartTypeTree = new System.Windows.Forms.TreeView();
	this.textBoxDateEnd = new System.Windows.Forms.TextBox();
	this.textBoxDateStart = new System.Windows.Forms.TextBox();
	this.monthCalendarEnd = new System.Windows.Forms.MonthCalendar();
	this.monthCalendarStart = new System.Windows.Forms.MonthCalendar();
	this.downTimeradio = new System.Windows.Forms.RadioButton();
	this.setupTimeradio = new System.Windows.Forms.RadioButton();
	this.runTimeradio = new System.Windows.Forms.RadioButton();
	this.dgCollection = new System.Windows.Forms.DataGrid();
	this.chartButton = new System.Windows.Forms.Button();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.allChartsButton = new System.Windows.Forms.Button();
	this.button1 = new System.Windows.Forms.Button();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.allDetailedScrapButton = new System.Windows.Forms.Button();
	((System.ComponentModel.ISupportInitialize)(this.dgCollection)).BeginInit();
	this.groupBox1.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.groupBox3.SuspendLayout();
	this.SuspendLayout();
	// 
	// btnRefresh
	// 
	this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
	this.btnRefresh.Location = new System.Drawing.Point(640, 160);
	this.btnRefresh.Name = "btnRefresh";
	this.btnRefresh.Size = new System.Drawing.Size(104, 23);
	this.btnRefresh.TabIndex = 66;
	this.btnRefresh.Text = "Refresh Grid";
	this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
	// 
	// btnClose
	// 
	this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
	this.btnClose.Location = new System.Drawing.Point(824, 528);
	this.btnClose.Name = "btnClose";
	this.btnClose.Size = new System.Drawing.Size(72, 24);
	this.btnClose.TabIndex = 62;
	this.btnClose.Text = "Close";
	this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
	// 
	// chartTypeTree
	// 
	this.chartTypeTree.ImageIndex = -1;
	this.chartTypeTree.Location = new System.Drawing.Point(8, 0);
	this.chartTypeTree.Name = "chartTypeTree";
	this.chartTypeTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																			  new System.Windows.Forms.TreeNode("Server")});
	this.chartTypeTree.SelectedImageIndex = -1;
	this.chartTypeTree.Size = new System.Drawing.Size(208, 520);
	this.chartTypeTree.TabIndex = 61;
	this.chartTypeTree.DoubleClick += new System.EventHandler(this.chartTypeTree_DoubleClick);
	// 
	// textBoxDateEnd
	// 
	this.textBoxDateEnd.Location = new System.Drawing.Point(472, 8);
	this.textBoxDateEnd.Name = "textBoxDateEnd";
	this.textBoxDateEnd.TabIndex = 59;
	this.textBoxDateEnd.Text = "";
	// 
	// textBoxDateStart
	// 
	this.textBoxDateStart.Location = new System.Drawing.Point(272, 8);
	this.textBoxDateStart.Name = "textBoxDateStart";
	this.textBoxDateStart.TabIndex = 58;
	this.textBoxDateStart.Text = "";
	// 
	// monthCalendarEnd
	// 
	this.monthCalendarEnd.Location = new System.Drawing.Point(440, 32);
	this.monthCalendarEnd.Name = "monthCalendarEnd";
	this.monthCalendarEnd.TabIndex = 57;
	this.monthCalendarEnd.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarEnd_DateChanged);
	// 
	// monthCalendarStart
	// 
	this.monthCalendarStart.Location = new System.Drawing.Point(240, 32);
	this.monthCalendarStart.Name = "monthCalendarStart";
	this.monthCalendarStart.TabIndex = 56;
	this.monthCalendarStart.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarStart_DateChanged);
	// 
	// downTimeradio
	// 
	this.downTimeradio.Location = new System.Drawing.Point(16, 96);
	this.downTimeradio.Name = "downTimeradio";
	this.downTimeradio.Size = new System.Drawing.Size(88, 24);
	this.downTimeradio.TabIndex = 65;
	this.downTimeradio.Text = "Down Time";
	// 
	// setupTimeradio
	// 
	this.setupTimeradio.Location = new System.Drawing.Point(16, 64);
	this.setupTimeradio.Name = "setupTimeradio";
	this.setupTimeradio.Size = new System.Drawing.Size(88, 24);
	this.setupTimeradio.TabIndex = 64;
	this.setupTimeradio.Text = "Setup Time";
	// 
	// runTimeradio
	// 
	this.runTimeradio.Location = new System.Drawing.Point(16, 32);
	this.runTimeradio.Name = "runTimeradio";
	this.runTimeradio.Size = new System.Drawing.Size(88, 24);
	this.runTimeradio.TabIndex = 63;
	this.runTimeradio.Text = "Run Time";
	// 
	// dgCollection
	// 
	this.dgCollection.CaptionText = "Capacity";
	this.dgCollection.CaptionVisible = false;
	this.dgCollection.DataMember = "";
	this.dgCollection.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.dgCollection.Location = new System.Drawing.Point(224, 192);
	this.dgCollection.Name = "dgCollection";
	this.dgCollection.Size = new System.Drawing.Size(680, 328);
	this.dgCollection.TabIndex = 60;
	// 
	// chartButton
	// 
	this.chartButton.Location = new System.Drawing.Point(8, 16);
	this.chartButton.Name = "chartButton";
	this.chartButton.Size = new System.Drawing.Size(104, 23);
	this.chartButton.TabIndex = 67;
	this.chartButton.Text = "Normal Chart";
	this.chartButton.Click += new System.EventHandler(this.chartButton_Click);
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.runTimeradio);
	this.groupBox1.Controls.Add(this.setupTimeradio);
	this.groupBox1.Controls.Add(this.downTimeradio);
	this.groupBox1.Location = new System.Drawing.Point(632, 16);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(120, 128);
	this.groupBox1.TabIndex = 68;
	this.groupBox1.TabStop = false;
	this.groupBox1.Text = "Chart Type";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.allChartsButton);
	this.groupBox2.Controls.Add(this.chartButton);
	this.groupBox2.Location = new System.Drawing.Point(768, 16);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(120, 80);
	this.groupBox2.TabIndex = 69;
	this.groupBox2.TabStop = false;
	this.groupBox2.Text = "Normal";
	// 
	// allChartsButton
	// 
	this.allChartsButton.Location = new System.Drawing.Point(8, 48);
	this.allChartsButton.Name = "allChartsButton";
	this.allChartsButton.Size = new System.Drawing.Size(104, 23);
	this.allChartsButton.TabIndex = 69;
	this.allChartsButton.Text = "Print All Graphs";
	this.allChartsButton.Click += new System.EventHandler(this.allChartsButton_Click);
	// 
	// button1
	// 
	this.button1.Location = new System.Drawing.Point(8, 16);
	this.button1.Name = "button1";
	this.button1.Size = new System.Drawing.Size(104, 23);
	this.button1.TabIndex = 68;
	this.button1.Text = "Detailed Scrap";
	this.button1.Click += new System.EventHandler(this.button1_Click);
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.allDetailedScrapButton);
	this.groupBox3.Controls.Add(this.button1);
	this.groupBox3.Location = new System.Drawing.Point(768, 104);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(120, 80);
	this.groupBox3.TabIndex = 70;
	this.groupBox3.TabStop = false;
	this.groupBox3.Text = "Detailed Scrap";
	// 
	// allDetailedScrapButton
	// 
	this.allDetailedScrapButton.Location = new System.Drawing.Point(8, 48);
	this.allDetailedScrapButton.Name = "allDetailedScrapButton";
	this.allDetailedScrapButton.Size = new System.Drawing.Size(104, 23);
	this.allDetailedScrapButton.TabIndex = 70;
	this.allDetailedScrapButton.Text = "Print All Graphs";
	this.allDetailedScrapButton.Click += new System.EventHandler(this.allDetailedScrapButton_Click);
	// 
	// FormChartProductionHistory
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(912, 558);
	this.Controls.Add(this.groupBox3);
	this.Controls.Add(this.groupBox2);
	this.Controls.Add(this.groupBox1);
	this.Controls.Add(this.btnClose);
	this.Controls.Add(this.chartTypeTree);
	this.Controls.Add(this.dgCollection);
	this.Controls.Add(this.textBoxDateEnd);
	this.Controls.Add(this.textBoxDateStart);
	this.Controls.Add(this.monthCalendarEnd);
	this.Controls.Add(this.monthCalendarStart);
	this.Controls.Add(this.btnRefresh);
	this.Name = "FormChartProductionHistory";
	this.Text = "Chart: Production History";
	((System.ComponentModel.ISupportInitialize)(this.dgCollection)).EndInit();
	this.groupBox1.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private 
void btnClose_Click(object sender, System.EventArgs e){
	Dispose();
}

private 
void btnRefresh_Click(object sender, System.EventArgs e){
	refreshGrid();
}

private 
void refreshGrid(){
	string smode = "R";
	DateTime dateBefore, dateAfter;
	string splant = null;
	string sshift = null;
	string sdept = null;
	string sresource = null;
	string spart = null;
	int seq = 0;
	TreeNode node = null, nodeAux = null;
	int ilevelSelected = 0;
	typeReport	= TypeReport.REPORT_COMPANY;
			
	this.Cursor = Cursors.WaitCursor;

	try{
		if (chartTypeTree != null && chartTypeTree.GetNodeCount(true) > 0){
			node = chartTypeTree.SelectedNode;
			if (node != null){
													
				typeReport = getReportType();
				ilevelSelected = (int)typeReport;
				nodeAux = node;

				//get the id values
				do{
					switch(ilevelSelected){
					case 1:						
						splant = (string) nodeAux.Tag;
						break;
					case 2:
						sshift = (string) nodeAux.Tag;
						break;
					case 3:
						sdept = (string) nodeAux.Tag;
						break;
					case 4:
						sresource = (string)nodeAux.Tag;
						break;
					case 5:
						spart = (string)nodeAux.Tag;
						break;
					case 6:
						seq = int.Parse((string)nodeAux.Tag);
						break;
					}					
					nodeAux = nodeAux.Parent;
					ilevelSelected--;
				}while(nodeAux != null);
			}
		}

		if (!validateDataSelected())
			return;

		if (downTimeradio.Checked)
			smode = "D";
		if	(setupTimeradio.Checked) 
			smode = "S";
		if (runTimeradio.Checked)
			smode = "R";

		dateBefore = DateUtil.parseDate(textBoxDateStart.Text,DateUtil.MMDDYYYY);
		dateAfter = DateUtil.parseDate(textBoxDateEnd.Text,DateUtil.MMDDYYYY);
								
		arrayListReport = coreFactory.generateDeptsPrHist(smode, dateBefore, dateAfter, splant,
							sshift, sdept, sresource, spart, seq);

		processDataResult();

		this.lastSelected = chartTypeTree.SelectedNode;
		this.Cursor = Cursors.Default;

		if (arrayListReport.Count == 0)
			MessageBox.Show("No Data Found !!!");
	}catch(NujitException nex){
		FormException fe = new FormException(nex);
		fe.ShowDialog();
	}catch(Exception ex){
		FormException fe = new FormException(ex);
		fe.ShowDialog();
	}
}

private 
bool validateDataSelected(){
	if (!DateUtil.isValidDate(this.textBoxDateStart.Text,DateUtil.MMDDYYYY)){
		MessageBox.Show("Not a valid start date, please select another.");
		return false;
	}

	if (!DateUtil.isValidDate(this.textBoxDateEnd.Text,DateUtil.MMDDYYYY)){
		MessageBox.Show("Not a valid end date, please select another.");
		return false;
	}

	if (this.textBoxDateStart.Text.Length < 1){
		MessageBox.Show("Please, select the start date.");
		return false;
	}

	if (this.textBoxDateEnd.Text.Length < 1){
		MessageBox.Show("Please, select the end date.");
		return false;
	}

	if (!this.downTimeradio.Checked && !this.setupTimeradio.Checked && !this.runTimeradio.Checked){
		MessageBox.Show("Please, select the mode of the production.");
		return false;
	}
	return true;
}

private 
void setDefaultValues(){
	//set today date
	DateTime dateTime = DateTime.Now;				
	this.textBoxDateStart.Text = DateUtil.getDateRepresentation(dateTime,DateUtil.MMDDYYYY);				
	this.textBoxDateEnd.Text = DateUtil.getDateRepresentation(dateTime,DateUtil.MMDDYYYY);
	this.runTimeradio.Checked = true;				
}

private 
bool processDataResult(){
	bool bresult = false;
	int isizeData = arrayListReport.Count;

	string sactualField = "";
	
	string slabel = "";
	string shistoryPlant = "";
	string shistoryShift = "";
	string shistoryDepartment = "";
	string shistoryMachine = "";
	string shistoryPart = "";
	string shistorySeq = "";

	string sdescPlant = "";
	string sdescShift = "";
	string sdescDepartment = "";
	string sdescMachine = "";
	string sdescPart = "";
	string sdescSeq = "";
	
	intializeDataGrid();
	initializeTree();

	 if (isizeData > 0){
		treeNodeRoot = chartTypeTree.GetNodeAt(0, 0);
						
		//process all the rows
		foreach (ProductionHistory prHist in arrayListReport){
			switch (typeReport){
			case TypeReport.REPORT_COMPANY://company
				sactualField = prHist.getPlant();	
				break;
			case TypeReport.REPORT_PLANT://plant
				sactualField = prHist.getDept();
				break;
			case TypeReport.REPORT_SHIFT://shift
				sactualField = prHist.getShft().ToString();
				break;
			case TypeReport.REPORT_DEPT://dept
				sactualField = prHist.getResr();
				break;
			case TypeReport.REPORT_MACHINE://resource
				sactualField = prHist.getPart();
				break;
			case TypeReport.REPORT_PART://product
				sactualField = prHist.getPart();
				break;
			case TypeReport.REPORT_PART_SEQ://product
				sactualField = prHist.getSeqn().ToString();
				break;
			default:
				break;
			}

			DataRow dataRow = reportDataTable.NewRow();
			dataRow[0] = DateUtil.getDateRepresentation(prHist.getDate(),DateUtil.MMDDYYYY);
			
			//quantity
			dataRow[5] = prHist.getQtyc();	
			dataRow[6] = prHist.getQtys();	
			dataRow[7] = prHist.getSeqn();
			dataRow[8] = prHist.getTime();
		
			reportDataTable.Rows.Add(dataRow);

			if (!shistoryPlant.Equals(prHist.getPlant())){
				//get the plant description
				sdescPlant = "";
				if (coreFactory.existsPlant(prHist.getPlant())){
					Plant plant = coreFactory.readPlant(prHist.getPlant());
					sdescPlant = plant.getName();								
				}
				sdescPlant+= " " + prHist.getPlant().Trim();

				//new node
				treeNodePlant = addNode(treeNodeRoot, prHist.getPlant(), sdescPlant);
				shistoryPlant = prHist.getPlant();

				//changes
				shistoryShift = "";
				shistoryDepartment = "";
				shistoryMachine = "";
				shistoryPart = "";
				shistorySeq = "";
				
				//get the description to the chart
				if (typeReport == TypeReport.REPORT_COMPANY)
					slabel = sdescPlant;	
			}

			if (!shistoryShift.Equals(prHist.getShft().ToString())){
				sdescShift = " " + prHist.getShft().ToString();

				//new node
				treeNodeShift = addNode(treeNodePlant, prHist.getShft().ToString(), sdescShift);
				shistoryShift = prHist.getShft().ToString();

				//changes
				shistoryDepartment = "";
				shistoryMachine = "";
				shistoryPart = "";	
				shistorySeq = "";
				
				//get the description to the chart
				if (typeReport == TypeReport.REPORT_SHIFT)
					slabel = sdescShift;												
			}

			if (!shistoryDepartment.Equals(prHist.getDept())){
				//get department description
				sdescDepartment = "";
				if (coreFactory.existsByDept(prHist.getDept())){
					sdescDepartment = coreFactory.getDepartamentDescription(prHist.getDept());
				}
				sdescDepartment += " " + prHist.getDept().Trim();

				//new node
				treeNodeDepartment = addNode(treeNodeShift, prHist.getDept(), sdescDepartment);
				shistoryDepartment = prHist.getDept();

				//changes
				shistoryMachine = "";
				shistoryPart = "";	
				shistorySeq = "";
				
				//get the description to the chart
				if (typeReport == TypeReport.REPORT_DEPT)
					slabel = sdescDepartment;												
			}

			if (!shistoryMachine.Equals(prHist.getResr())){
				sdescMachine = prHist.getResr().Trim() + "";

				//new node
				treeNodeMachine = addNode(treeNodeDepartment, prHist.getResr(), sdescMachine);
				shistoryMachine = prHist.getResr();

				//change
				shistoryPart = "";			
				shistorySeq = "";

				//get the description to the chart
				if (typeReport == TypeReport.REPORT_MACHINE)
					slabel = sdescMachine;												
			}

			if (!shistoryPart.Equals(prHist.getPart())){
				sdescPart = "";
				if (coreFactory.existsProduct(prHist.getPart())){
					Product product = coreFactory.readProduct(prHist.getPart());							
					sdescPart = product.getDes1();								
				}						
				sdescPart += " " + prHist.getPart().Trim() +"";

				//new node
				treeNodePart = addNode(treeNodeMachine, prHist.getPart(), sdescPart);
				shistoryPart = prHist.getPart();

				shistorySeq = "";

				//get the description to the chart
				if (typeReport == TypeReport.REPORT_PART)
					slabel = sdescPart;												
			}

			if (!shistorySeq.Equals(prHist.getSeqn().ToString())){
				sdescSeq = " " + prHist.getSeqn().ToString();

				//new node
				treeNodeSeq = addNode(treeNodePart, prHist.getSeqn().ToString(), sdescSeq);
				shistorySeq = prHist.getSeqn().ToString();

				//get the description to the chart
				if (typeReport == TypeReport.REPORT_PART_SEQ)
					slabel = sdescSeq;
			}					

			//show descriptions in the grid
			dataRow[1] = sdescShift;
			dataRow[2] = sdescDepartment;
			dataRow[3] = sdescMachine;
			dataRow[4] = sdescPart;
			dataRow[7] = sdescSeq;
		}	//end for

		//select the appropiate node
		switch (typeReport){
		case TypeReport.REPORT_COMPANY://company
			if (treeNodeRoot != null)
				this.chartTypeTree.SelectedNode = treeNodeRoot;
			break;
		case TypeReport.REPORT_PLANT://plant
			if (treeNodePlant != null)
				this.chartTypeTree.SelectedNode = treeNodePlant;
			break;
		case TypeReport.REPORT_SHIFT://shift
			if (treeNodeShift != null)
				this.chartTypeTree.SelectedNode = treeNodeShift;
			break;
		case TypeReport.REPORT_DEPT://dept
			if (treeNodeDepartment != null)
				this.chartTypeTree.SelectedNode = treeNodeDepartment;
			break;
		case TypeReport.REPORT_MACHINE://resource
			if (treeNodeMachine != null)
				this.chartTypeTree.SelectedNode = treeNodeMachine;
			break;
		case TypeReport.REPORT_PART://product
			if (treeNodePart != null)
				this.chartTypeTree.SelectedNode = treeNodePart;
			break;
		case TypeReport.REPORT_PART_SEQ://product
			if (treeNodePart != null)
				this.chartTypeTree.SelectedNode = treeNodeSeq;
			break;
		default:
			break;
		}
		
		//show the values un the grid
		DataView dataView = new DataView(reportDataTable);
		dataView.AllowEdit = false;
		dataView.AllowDelete = false;
	
		dgCollection.DataSource = dataView;
		dgCollection.PreferredColumnWidth = 70;
		dgCollection.RowHeadersVisible = false;
		dgCollection.Refresh();
	
		reportDataTable = null;
	}

	return bresult;
}

private 
void makeNormalChart(){
	if ((arrayListReport == null) || (arrayListReport.Count == 0)){
		MessageBox.Show("No Data Found !!!");
		return;
	}

	int isizeData = arrayListReport.Count;
	int i = 0;
	double dTotCompleted = 0;
	double dTotScrapped = 0;
	double dTotScrappedQty = 0;

	string slabel = "";

	ArrayList arrayCompleted = new ArrayList();
	ArrayList arrayScrapped	= new ArrayList();
	ArrayList arrayScrappedQty	= new ArrayList();
	ArrayList arrayLabels = new ArrayList();		

	if (isizeData > 0){
		for(int x = 0; x < arrayListReport.Count; x++){
			ProductionHistory prHist = (ProductionHistory)arrayListReport[x];
			dTotCompleted += prHist.getQtyc();
			dTotScrapped += prHist.getQtys() * decimal.ToDouble(prHist.getCost());
			dTotScrappedQty += prHist.getQtys();
		}	//end for
		
		arrayCompleted.Add(dTotCompleted); //completed
		arrayScrapped.Add(dTotScrapped); //scrapped
		arrayScrappedQty.Add(dTotScrappedQty);//scrapped
		arrayLabels.Add(slabel); //field

		treeNodeRoot = chartTypeTree.GetNodeAt(0,0);
	}

	isizeData = 1;//quantity of totals

	double[] dataCompleted = null;
	double[] dataScrapped = null;
	double[] dataScrappedQty = null;
	string[] labels = null;
	string[] labelsOfBars = null;

	string[][] downCodes = null;
	double[] downCodesValues = null;

	if (downTimeradio.Checked){
		downCodes = coreFactory.getAllDownCodes();
		downCodesValues = new double[downCodes.Length];

		foreach (ProductionHistory prHist in arrayListReport){
			int pos = 0;
			for(int x = 0; x < downCodes.Length; x++){
				if (downCodes[x].Equals(prHist.getRef())){
					pos = x;
					break;
				}
			}
			downCodesValues[pos] += decimal.ToDouble(prHist.getCost());
		}

		int labelsOk = 0;
		labelsOfBars = new string[downCodes.Length];
		for(int z = 0; z < labelsOfBars.Length; z++){
			if (downCodesValues[z] != 0){
				labelsOfBars[z] = downCodes[z][0] + "-" + downCodes[z][1];
				labelsOk++;
			}else{
				labelsOfBars[z] = "";
			}
		}

		double[] newDownCodesValues = new double[labelsOk];
		string[] newLabelsOfBars = new string[labelsOk];
		int newPos = 0;

		for(int z = 0; z < labelsOfBars.Length; z++){
			if (!labelsOfBars[z].Equals("")){
				newDownCodesValues[newPos] = downCodesValues[z];
				newLabelsOfBars[newPos] = labelsOfBars[z];
				newPos++;
			}
		}

		if (labelsOk > 0){
			prHistComplScrappedChart = new PrHistComplScrappedChart(newDownCodesValues, newLabelsOfBars, 
						newLabelsOfBars, GenericChart.XY_CHART, getReportTitle());
			prHistComplScrappedChart.ShowDialog();
		}else{
			MessageBox.Show("There is no data !!!");
		}
	}else{
		double[] theData = new double[2];
		dataCompleted = new double[isizeData];
		dataScrapped = new double[isizeData];
		dataScrappedQty = new double[isizeData];
		labels = new string[isizeData];

		for (i=0; i < isizeData;i++){
			dataCompleted[i] = (double)arrayCompleted[i];
			dataScrapped[i] = (double)arrayScrapped[i];
			dataScrappedQty[i] = (double)arrayScrappedQty[i];
			labels[i] = (string)arrayLabels[i];
		}

		labelsOfBars = new string[2];
		labelsOfBars[0] = "Completed Qty : " + dataCompleted[0].ToString();
		labelsOfBars[1] = "Scrapped Qty : " + dataScrappedQty[0].ToString();

		theData[0] = dataCompleted[0];
		theData[1] = dataScrappedQty[0];

		string[] infLabels = new string[2];
		infLabels[0] = "";
		infLabels[1] = "Total Scrap = $ " + dataScrapped[0].ToString("########0.#0");

		if (prHistComplScrappedChart != null)//if was active, close the window
			prHistComplScrappedChart.Dispose();

		prHistComplScrappedChart = new PrHistComplScrappedChart(theData, infLabels, labelsOfBars,
										GenericChart.XY_CHART, getReportTitle());
		prHistComplScrappedChart.Show();
	}
}

private 
string getReportTitle(){
	TypeReport aux = getReportType();
	
	switch(aux){
	case TypeReport.REPORT_COMPANY://company
		return "Production History";
	case TypeReport.REPORT_PLANT://plant
		return "Plant Production History (" + (string)chartTypeTree.SelectedNode.Tag + ")";
	case TypeReport.REPORT_SHIFT://dept
		return "Shift Production History (" + (string)chartTypeTree.SelectedNode.Tag + ")";
	case TypeReport.REPORT_DEPT://dept
		return "Department Production History (" + (string)chartTypeTree.SelectedNode.Tag + ")";
	case TypeReport.REPORT_MACHINE://resource
		return "Machine Production History (" + (string)chartTypeTree.SelectedNode.Tag + ")";
	case TypeReport.REPORT_PART://product
		return "Part Production History (" + "Mach " + 
			(string)chartTypeTree.SelectedNode.Parent.Tag + " - " +
			(string)chartTypeTree.SelectedNode.Tag + ")";
	case TypeReport.REPORT_PART_SEQ://product
		string aditional = 
			"Shft " + (string)chartTypeTree.SelectedNode.Parent.Parent.Parent.Parent.Tag + " - " + 
			"Dept " + (string)chartTypeTree.SelectedNode.Parent.Parent.Parent.Tag + " - " + 
			"Mach " + (string)chartTypeTree.SelectedNode.Parent.Parent.Tag + " - " + 
			(string)chartTypeTree.SelectedNode.Parent.Tag + " - " + 
			(string)chartTypeTree.SelectedNode.Tag;
		return "Part/Seq Production History (" + aditional + ")";
	default:
		return "";
	}
}

private	
void intializeDataGrid(){
	reportDataTable = new DataTable();
	reportDataTable.Columns.Add(new DataColumn("Date", typeof(string)));
	reportDataTable.Columns.Add(new DataColumn("Shift", typeof(string)));
	reportDataTable.Columns.Add(new DataColumn("Department", typeof(string)));
	reportDataTable.Columns.Add(new DataColumn("Machine", typeof(string)));
	reportDataTable.Columns.Add(new DataColumn("Part", typeof(string)));
	reportDataTable.Columns.Add(new DataColumn("Completed", typeof(double)));
	reportDataTable.Columns.Add(new DataColumn("Scrapped", typeof(double)));
	reportDataTable.Columns.Add(new DataColumn("Sequential", typeof(string)));
	reportDataTable.Columns.Add(new DataColumn("Time", typeof(double)));
}

private 
void monthCalendarStart_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e){
	string	sdate;						
	getDate(out sdate,(this.monthCalendarStart.SelectionStart.ToShortDateString()));
	this.textBoxDateStart.Text = sdate;
}

private 
void monthCalendarEnd_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e){
	string	sdate;						
	getDate(out sdate,(this.monthCalendarEnd.SelectionStart.ToShortDateString()));
	this.textBoxDateEnd.Text = sdate;			
}

private 
void getDate(out string sdate,string sdateMMDDYYYY){
	DateTime	dateTime = DateTime.Now;
	dateTime = DateUtil.parseDate(sdateMMDDYYYY,DateUtil.MMDDYYYY);						
	sdate	= DateUtil.getDateRepresentation(dateTime,DateUtil.MMDDYYYY);
}

private 
void initializeTree(){
	this.Refresh();
	chartTypeTree.Nodes.Clear();
	chartTypeTree.BeginUpdate();
	Cursor.Current = Cursors.WaitCursor;

	this.Root = null;

	this.Root = new TreeNode("Company");
	this.Root.Tag = (object)"";

	chartTypeTree.Nodes.Add(this.Root);

	chartTypeTree.ExpandAll();
	if (chartTypeTree.Nodes.Count > 0) {
		chartTypeTree.Nodes[0].EnsureVisible();
		chartTypeTree.SelectedNode = chartTypeTree.Nodes[0];
	}
	chartTypeTree.EndUpdate();
	Cursor.Current = Cursors.Arrow;			
}


private 
TreeNode addNode(TreeNode parentNode, string sobj, string sdesc){
	TreeNode treeNewNode = new TreeNode(sdesc);
	treeNewNode.Tag = (object)(sobj);
	parentNode.Nodes.Add(treeNewNode);				
	return treeNewNode;
}

private 
void chartButton_Click(object sender, System.EventArgs e){
	if (this.lastSelected != chartTypeTree.SelectedNode)
		refreshGrid();
	makeNormalChart();
}

private 
TypeReport getReportType(){
	TreeNode node = null, nodeAux = null;
	int ilevelSelected = 0;

	if (chartTypeTree != null && chartTypeTree.GetNodeCount(true) > 0){
		node = chartTypeTree.SelectedNode;
		if (node != null){
			nodeAux = node;

			while(nodeAux.Parent != null){
				nodeAux = nodeAux.Parent;
				ilevelSelected++;
			}

			return (TypeReport) ilevelSelected;
		}
	}

	return TypeReport.REPORT_COMPANY;
}

private 
void getDataForDetailedScrap(out double[] values, out string[] labelsOfBarSup, out string[] labelsOfBarInf){
	Hashtable hashValuesQty = new Hashtable();
	Hashtable hashValuesCost = new Hashtable();
	double runQty = 0;

	foreach (ProductionHistory prHist in arrayListReport){
		runQty += prHist.getQtyc();
		
		if (prHist.getQtys() != 0){
			string key = prHist.getScrapCode() + " " + prHist.getScrapDescription();
			
			if (hashValuesQty.ContainsKey(key)){
				double oldQty = (double)hashValuesQty[key];
				oldQty += prHist.getQtys();
				hashValuesQty[key] = oldQty;

				double oldCost = (double)hashValuesCost[key];
				oldCost += prHist.getQtys() * decimal.ToDouble(prHist.getCost());
				hashValuesCost[key] = oldCost;
			}else{
				double scrapQty = prHist.getQtys();
				hashValuesQty.Add(key, scrapQty);

				double scrapCost = prHist.getQtys() * decimal.ToDouble(prHist.getCost());
				hashValuesCost.Add(key, scrapCost);
			}
		}
	}

	values = new double[hashValuesQty.Count + 1];
	labelsOfBarSup = new string[hashValuesQty.Count + 1];
	labelsOfBarInf = new string[hashValuesQty.Count + 1];
	
	values[0] = runQty;
	labelsOfBarSup[0] = "Completed Qty : " + runQty.ToString();
	
	labelsOfBarInf[0] = "";

	int i = 1;
	for(IEnumerator en = hashValuesQty.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry entry = (DictionaryEntry)en.Current;
		double qty = (double)entry.Value;
		values[i] = qty;

		labelsOfBarSup[i] = "Scrap Qty : " + qty.ToString();

		double cost = (double)hashValuesCost[entry.Key];
		string auxLabel = entry.Key.ToString();
		if (auxLabel.Length > 10)
			auxLabel = auxLabel.Substring(0, 10);
		labelsOfBarInf[i] = auxLabel + " = $ " + cost.ToString("########0.#0");

		i++;
	}
}

private 
void button1_Click(object sender, System.EventArgs e){
	if (this.lastSelected != chartTypeTree.SelectedNode)
		this.refreshGrid();

	if (!runTimeradio.Checked){
		MessageBox.Show("This chart is only for Runtime type !!");
		return;
	}

	if ((arrayListReport == null) || (arrayListReport.Count == 0)){
		MessageBox.Show("No Data found !!");
		return;
	}

	double[] data;
	string[] labelsOfBarSup;
	string[] labelsOfBarInf;
	
	getDataForDetailedScrap(out data, out labelsOfBarSup, out labelsOfBarInf);

	if (prHistComplScrappedChart != null)//if was active, close the window
		prHistComplScrappedChart.Dispose();

	prHistComplScrappedChart = new PrHistComplScrappedChart(data, labelsOfBarInf, labelsOfBarSup,
									GenericChart.XY_CHART, getReportTitle());
	prHistComplScrappedChart.Show();
}

private 
void chartTypeTree_DoubleClick(object sender, System.EventArgs e){
	if (chartTypeTree.SelectedNode != null){
		refreshGrid();
	}
}

private 
Image getImageForNormalChart(double[] data, double cost, string shft, string dept, string mach, 
			string part, string seq){

	double totalCost = data[1] * cost;
	string[] infLabels = new string[2];
	infLabels[0] = "";
	infLabels[1] = "Total Scrap = $ " + totalCost.ToString("########0.#0");

	string[] labelsOfBars = new string[2];
	labelsOfBars[0] = "Completed Qty : " + data[0].ToString();
	labelsOfBars[1] = "Scrapped Qty : " + data[1].ToString();

	string title = "Part/Seq Production History (Shft " + shft + " Dept " + dept + " Mach " + mach + " - " + 
		part + " - " + seq + ") " + textBoxDateStart.Text + "-" + textBoxDateEnd.Text;

	int width = 600;
	int height = 180;
	return getXYChart(infLabels, labelsOfBars, data, title, width, height, 8);
}

private
Image getXYChart(string[] labels, string[] labelsOfBars, double[] data, string title,
			int width, int height, int fontSize){
//	int width = 300; // 900
//	int height = 500;
	string ytitle = "";

    XYChart c = new XYChart(width, height);

    c.setPlotArea(50, 40, width - 60, height - 80);

	//Configure the axis as according to the input parameter
    c.addTitle(title, "timesbi.ttf", fontSize, Chart.CColor(Color.Blue));

    //Set the labels on the x axis
    c.xAxis().setLabels(labels); // -----------ojo aca-----------

	double gradeTextLabels = 0;
	c.xAxis().setLabels(labels).setFontAngle(gradeTextLabels);

    //Add a color bar layer using the given data. Use a 1 pixel 3D border for the
    //bars.
	Color[] colors = new Color[2];
	colors[0] = Color.Gray;
	colors[1] = Color.Red;

	if (colors.Length > 0){
		int[] colors2 = new int[colors.Length];
		for(int k = 0; k < colors.Length; k++)
			colors2[k] = Chart.CColor(colors[k]);

		c.addBarLayer3(data, colors2).setBorderColor(-1, 1);
	}else{
		c.addBarLayer3(data).setBorderColor(-1, 1);
	}

	//background color
//	c.setBackground(c.gradientColor(Chart.greenMetalGradient), -1, 2);

	//y title
	c.yAxis().setTitle(ytitle, "arialbd.ttf", 7, 0);
	c.yAxis().setLabelStyle("arialbd.ttf", 7,0);
	
	for(int z = 0; z < labelsOfBars.Length; z++)
		c.xAxis2().addLabel(z, labelsOfBars[z]);

    return c.makeImage();
}

private 
void allChartsButton_Click(object sender, System.EventArgs e){
	generateAllReports();
}

private 
void allDetailedScrapButton_Click(object sender, System.EventArgs e){
	generateAllReportsDetScrapped();
}

private 
void getDataForDetailedScrapForproduct(out double[] values, out string[] labelsOfBarSup, 
		out string[] labelsOfBarInf, string plant, string dept, string shft,
		string mach, string part, string seq){

	Hashtable hashValuesQty = new Hashtable();
	Hashtable hashValuesCost = new Hashtable();
	double runQty = 0;

	foreach (ProductionHistory prHist in arrayListReport){
		if ((!plant.Equals(prHist.getPlant())) || (!dept.Equals(prHist.getDept())) ||
				(!shft.Equals(prHist.getShft().ToString())) || (!mach.Equals(prHist.getResr())) ||
				(!part.Equals(prHist.getPart())) || (!seq.Equals(prHist.getSeqn().ToString())))
			continue;
		
		runQty += prHist.getQtyc();
		
		if (prHist.getQtys() != 0){
			string key = prHist.getScrapCode() + " " + prHist.getScrapDescription();
			
			if (hashValuesQty.ContainsKey(key)){
				double oldQty = (double)hashValuesQty[key];
				oldQty += prHist.getQtys();
				hashValuesQty[key] = oldQty;

				double oldCost = (double)hashValuesCost[key];
				oldCost += prHist.getQtys() * decimal.ToDouble(prHist.getCost());
				hashValuesCost[key] = oldCost;
			}else{
				double scrapQty = prHist.getQtys();
				hashValuesQty.Add(key, scrapQty);

				double scrapCost = prHist.getQtys() * decimal.ToDouble(prHist.getCost());
				hashValuesCost.Add(key, scrapCost);
			}
		}
	}

	values = new double[hashValuesQty.Count + 1];
	labelsOfBarSup = new string[hashValuesQty.Count + 1];
	labelsOfBarInf = new string[hashValuesQty.Count + 1];
	
	values[0] = runQty;
	labelsOfBarSup[0] = "Completed Qty : " + runQty.ToString();
	
	labelsOfBarInf[0] = "";

	int i = 1;
	for(IEnumerator en = hashValuesQty.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry entry = (DictionaryEntry)en.Current;
		double qty = (double)entry.Value;
		values[i] = qty;

		labelsOfBarSup[i] = "Scrap Qty : " + qty.ToString();

		double cost = (double)hashValuesCost[entry.Key];
		string auxLabel = entry.Key.ToString();
		if (auxLabel.Length > 10)
			auxLabel = auxLabel.Substring(0, 10);
		labelsOfBarInf[i] = auxLabel + " = $ " + cost.ToString("########0.#0");

		i++;
	}
}

private
void generateAllReportsDetScrapped(){
	if ((arrayListReport == null) || (this.lastSelected != chartTypeTree.SelectedNode))
		this.refreshGrid();

	Hashtable hash = new Hashtable();
	Hashtable hashImages = new Hashtable();
	
	foreach(ProductionHistory prHist in arrayListReport){
		string plant = prHist.getPlant();
		string dept = prHist.getDept();
		string shft = prHist.getShft().ToString();
		string mach = prHist.getResr();
		string part = prHist.getPart();
		string seq = prHist.getSeqn().ToString();
		
		double[] values;
		string[] labelsOfBarSup;
		string[] labelsOfBarInf;

		if ((prHist.getQtys() == 0) && (prHist.getQtyc() == 0))
			continue;

		string key1 = plant + "_" + dept + "_" + shft + "_" + mach + "_" + part + "_" + seq;
		if (!hash.ContainsKey(key1)){ // only for not repeat
			hash.Add(key1, key1);

			getDataForDetailedScrapForproduct(out values, out labelsOfBarSup,
				out labelsOfBarInf, plant, dept, shft, mach, part, seq);

			string aditional = "Shft " + shft + " Dept " + dept + " Mach " + mach + "-" + part + "-" + seq;
			string title = "Part/Seq Prod. History(" + aditional + ") " +
				textBoxDateStart.Text + "-" + textBoxDateEnd.Text;

			int width = 300 * values.Length;
			if (width == 300)
				width = 600;
			int height = 180;

			Image image = getXYChart(labelsOfBarInf, labelsOfBarSup, values, title, width, height, 8);
			Image[] imagesShifts = null;

			string key2 = plant + "_" + dept + "_" + mach + "_" + part + "_" + seq;
			
			if (!hashImages.ContainsKey(key2)){ 
				imagesShifts = new Image[3];
				imagesShifts[0] = image;
				imagesShifts[1] = null;
				imagesShifts[2] = null;
				hashImages.Add(key2, imagesShifts);
			}else{
				imagesShifts = (Image[]) hashImages[key2];
				if (imagesShifts[0] == null){
					imagesShifts[0] = image;
				}else{
					if (imagesShifts[1] == null){
						imagesShifts[1] = image;
					}else{
						if (imagesShifts[2] == null){
							imagesShifts[2] = image;
						}
					}
				}
			}
		}
	}

	Image[] images = new Image[hashImages.Count * 3];
	for(int i = 0; i < images.Length; i++)
		images[i] = null;

	int k = 0;
	Image[][] forOrderImages = new Image[hashImages.Count][];
	string[] forOrderKeys = new string[hashImages.Count];

	for(IEnumerator en = hashImages.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry entry = (DictionaryEntry)en.Current;
		Image[] imageVector = (Image[])entry.Value;

		forOrderImages[k] = imageVector;
		forOrderKeys[k] = entry.Key.ToString();

		k++;
	}

	for(int i = 0; i < forOrderKeys.Length; i++){
		for(int x = i; x < forOrderKeys.Length; x++){
			string key1Order = forOrderKeys[i];
			string key2Order = forOrderKeys[x];

			if (key2Order.CompareTo(key1Order) < 0){ // key2 less than key1
				Image[] imageVectorSwap = forOrderImages[i];
				string keySwap = forOrderKeys[i];
				
				forOrderImages[i] = forOrderImages[x];
				forOrderImages[x] = imageVectorSwap;

				forOrderKeys[i] = forOrderKeys[x];
				forOrderKeys[x] = keySwap;

			}
		}
	}

	int lastIndex = 0;
	for(int indexPrint = 0; indexPrint < forOrderImages.Length; indexPrint++){
		Image[] imageVector = forOrderImages[indexPrint];

		images[lastIndex] = imageVector[0];
		lastIndex++;

		images[lastIndex] = imageVector[1];
		lastIndex++;

		images[lastIndex] = imageVector[2];
		lastIndex++;
	}

	ImageReport imageReport = new ImageReport("All Detailed Scrap", images);
	imageReport.ShowDialog();
}

private
void generateAllReports(){
	if ((lastSelected == null) || (this.lastSelected != chartTypeTree.SelectedNode))
		this.refreshGrid();

	string plantAnt = "";
	string deptAnt = "";
	string shftAnt = "";
	string machAnt = "";
	string partAnt = "";
	string seqAnt = "";

	string plant = "";
	string dept = "";
	string shft = "";
	string mach = "";
	string part = "";
	string seq = "";

	double[] data = new double[2];
	data[0] = 0;
	data[1] = 0;

	double cost = 0;

	Image[] imagesShifts = null;
	Hashtable hashImages = new Hashtable();
	Image image = null;
	string key2 = null;

	foreach (ProductionHistory prHist in arrayListReport){
		plant = prHist.getPlant();
		dept = prHist.getDept();
		shft = prHist.getShft().ToString();
		mach = prHist.getResr();
		part = prHist.getPart();
		seq = prHist.getSeqn().ToString();

		if ((prHist.getQtys() == 0) && (prHist.getQtyc() == 0))
			continue;

		if (	((!plantAnt.Equals("")) && (!plantAnt.Equals(plant))) ||
				((!deptAnt.Equals("")) && (!deptAnt.Equals(dept))) ||
				((!shftAnt.Equals("")) && (!shftAnt.Equals(shft))) ||
				((!machAnt.Equals("")) && (!machAnt.Equals(mach))) ||
				((!partAnt.Equals("")) && (!partAnt.Equals(part))) ||
				((!seqAnt.Equals("")) && (!seqAnt.Equals(seq)))   )
		{
			image = getImageForNormalChart(data, cost, shft, dept, mach, part, seq);

			key2 = plant + "_" + dept + "_" + mach + "_" + part + "_" + seq;
			if (!hashImages.ContainsKey(key2)){ 
				imagesShifts = new Image[3];
				imagesShifts[0] = image;
				imagesShifts[1] = null;
				imagesShifts[2] = null;
				hashImages.Add(key2, imagesShifts);
			}else{
				imagesShifts = (Image[]) hashImages[key2];
				if (imagesShifts[0] == null)
					imagesShifts[0] = image;
				else if (imagesShifts[1] == null)
						imagesShifts[1] = image;
					  else if (imagesShifts[2] == null){
							imagesShifts[2] = image;
				}
			}

			data[0] = prHist.getQtyc();
			data[1] = prHist.getQtys();
		}else{
			data[0] += prHist.getQtyc();
			data[1] += prHist.getQtys();
		}

		plantAnt = prHist.getPlant();
		deptAnt = prHist.getDept();
		shftAnt = prHist.getShft().ToString();
		machAnt = prHist.getResr();
		partAnt = prHist.getPart();
		seqAnt = prHist.getSeqn().ToString();

		cost = decimal.ToDouble(prHist.getCost());
	}

	image = getImageForNormalChart(data, cost, shft, dept, mach, part, seq);

	key2 = plant + "_" + dept + "_" + mach + "_" + part + "_" + seq;
	if (!hashImages.ContainsKey(key2)){ 
		imagesShifts = new Image[3];
		imagesShifts[0] = image;
		imagesShifts[1] = null;
		imagesShifts[2] = null;
		hashImages.Add(key2, imagesShifts);
	}else{
		imagesShifts = (Image[]) hashImages[key2];
		if (imagesShifts[0] == null)
			imagesShifts[0] = image;
		else if (imagesShifts[1] == null)
				imagesShifts[1] = image;
				else if (imagesShifts[2] == null){
					imagesShifts[2] = image;
		}
	}

//	Image[] images = new Image[hashImages.Count * 3];
//	for(int i = 0; i < images.Length; i++)
//		images[i] = null;
//
//	int index = 0;
//	for(IEnumerator en = hashImages.GetEnumerator(); en.MoveNext(); ){
//		DictionaryEntry entry = (DictionaryEntry)en.Current;
//		Image[] imageVector = (Image[])entry.Value;
//
//		images[index] = imageVector[0];
//		index++;
//
//		images[index] = imageVector[1];
//		index++;
//
//		images[index] = imageVector[2];
//		index++;
//	}
	Image[] images = new Image[hashImages.Count * 3];
	for(int i = 0; i < images.Length; i++)
		images[i] = null;

	int k = 0;
	Image[][] forOrderImages = new Image[hashImages.Count][];
	string[] forOrderKeys = new string[hashImages.Count];

	for(IEnumerator en = hashImages.GetEnumerator(); en.MoveNext(); ){
		DictionaryEntry entry = (DictionaryEntry)en.Current;
		Image[] imageVector = (Image[])entry.Value;

		forOrderImages[k] = imageVector;
		forOrderKeys[k] = entry.Key.ToString();

		k++;
	}

	for(int indexI = 0; indexI < forOrderKeys.Length; indexI++){
		for(int indexX = indexI + 1; indexX < forOrderKeys.Length; indexX++){
			string keyOrder1 = forOrderKeys[indexI];
			string keyOrder2 = forOrderKeys[indexX];

			if (keyOrder2.CompareTo(keyOrder1) < 0){ // key2 less than key1
				Image[] imageVectorSwap = forOrderImages[indexI];
				string keySwap = forOrderKeys[indexI];
				
				forOrderImages[indexI] = forOrderImages[indexX];
				forOrderImages[indexX] = imageVectorSwap;

				forOrderKeys[indexI] = forOrderKeys[indexX];
				forOrderKeys[indexX] = keySwap;

			}
		}
	}

	int lastIndex = 0;
	for(int indexPrint = 0; indexPrint < forOrderImages.Length; indexPrint++){
		Image[] imageVector = forOrderImages[indexPrint];

		images[lastIndex] = imageVector[0];
		lastIndex++;

		images[lastIndex] = imageVector[1];
		lastIndex++;

		images[lastIndex] = imageVector[2];
		lastIndex++;
	}

	ImageReport imageReport = new ImageReport("All Normal charts", images);
	imageReport.ShowDialog();
}

} // class

} // namespace
