using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ClassLib.Core;
using ClassLib.DataAccess.Persistence;
using ClassLib.util;
using ClassLib.Exception;
using AxOWC10;
using NujitERP.WinForms.Reports.SchedulingView;
using System.Data;
namespace GridScheduling.gui.schedule
{
	/// <summary>
	/// Summary description for SchedulingView1Form.
	/// </summary>
	public class SchedulingView1Form : System.Windows.Forms.Form
	{
		private CoreFactory core;
		private DateTime today = DateTime.Today;
		private DateTime dateEnd;
		private Schedule schedule = null;
		private int desdeFila = ROW_INI;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox deptComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox plantComboBox;
		public const int HORA_0 = 0;
		public const int HORA_8 = 8;
		public const int HORA_16 = 16;
		public const int HORAS_T = 8;
		public const int TURNO_1 = 1;
		public const int TURNO_2 = 2;
		public const int TURNO_3 = 3;
		public const int ROW_INI = 3;
		public const int DAYS = 14;
		

		private AxOWC10.AxSpreadsheet axSpreadsheet2;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton refresh;
		private System.Windows.Forms.ToolBarButton print;
		private System.Windows.Forms.ToolBarButton add;
		private System.Windows.Forms.ToolBarButton stats;
		private System.Windows.Forms.ToolBarButton chVersion;
		private System.Windows.Forms.ToolBarButton close;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ImageList imageList2;
		private System.ComponentModel.IContainer components;

public SchedulingView1Form(string plant, string depto){

	dateEnd = today.AddDays(DAYS); 
	InitializeComponent();
	initializeaxSpreadsheet2();// estos metodos van aca??ver
	loadSchedule(plant,depto);
}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
protected override void Dispose( bool disposing ){
	if( disposing )	{
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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SchedulingView1Form));
			this.label1 = new System.Windows.Forms.Label();
			this.deptComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.plantComboBox = new System.Windows.Forms.ComboBox();
			this.axSpreadsheet2 = new AxOWC10.AxSpreadsheet();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.refresh = new System.Windows.Forms.ToolBarButton();
			this.print = new System.Windows.Forms.ToolBarButton();
			this.add = new System.Windows.Forms.ToolBarButton();
			this.stats = new System.Windows.Forms.ToolBarButton();
			this.chVersion = new System.Windows.Forms.ToolBarButton();
			this.close = new System.Windows.Forms.ToolBarButton();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.axSpreadsheet2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Department";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// deptComboBox
			// 
			this.deptComboBox.Location = new System.Drawing.Point(128, 80);
			this.deptComboBox.Name = "deptComboBox";
			this.deptComboBox.Size = new System.Drawing.Size(128, 21);
			this.deptComboBox.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Plant";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// plantComboBox
			// 
			this.plantComboBox.Location = new System.Drawing.Point(128, 56);
			this.plantComboBox.Name = "plantComboBox";
			this.plantComboBox.Size = new System.Drawing.Size(128, 21);
			this.plantComboBox.TabIndex = 8;
			// 
			// axSpreadsheet2
			// 
			this.axSpreadsheet2.DataSource = null;
			this.axSpreadsheet2.Enabled = true;
			this.axSpreadsheet2.Location = new System.Drawing.Point(16, 120);
			this.axSpreadsheet2.Name = "axSpreadsheet2";
			this.axSpreadsheet2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSpreadsheet2.OcxState")));
			this.axSpreadsheet2.Size = new System.Drawing.Size(888, 304);
			this.axSpreadsheet2.TabIndex = 9;
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.refresh,
																						this.print,
																						this.add,
																						this.stats,
																						this.chVersion,
																						this.close});
			this.toolBar1.ButtonSize = new System.Drawing.Size(30, 30);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList2;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(920, 36);
			this.toolBar1.TabIndex = 26;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick_1);
			// 
			// refresh
			// 
			this.refresh.ImageIndex = 0;
			this.refresh.Tag = "refresh";
			this.refresh.ToolTipText = "Refresh chart";
			// 
			// print
			// 
			this.print.ImageIndex = 1;
			this.print.Tag = "print";
			this.print.ToolTipText = "Print Report";
			// 
			// add
			// 
			this.add.ImageIndex = 2;
			this.add.Tag = "add";
			this.add.ToolTipText = "Add";
			// 
			// stats
			// 
			this.stats.ImageIndex = 3;
			this.stats.Tag = "stats";
			this.stats.ToolTipText = "Review Machine stats";
			// 
			// chVersion
			// 
			this.chVersion.ImageIndex = 5;
			this.chVersion.Tag = "chVersion";
			this.chVersion.ToolTipText = "Change Version";
			// 
			// close
			// 
			this.close.ImageIndex = 6;
			this.close.Tag = "close";
			this.close.ToolTipText = "Exit";
			// 
			// imageList2
			// 
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList2.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(392, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(344, 24);
			this.label3.TabIndex = 27;
			this.label3.Text = "text";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(392, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(344, 24);
			this.label4.TabIndex = 28;
			this.label4.Text = "text";
			// 
			// SchedulingView1Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(920, 438);
			this.Controls.Add(this.axSpreadsheet2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.plantComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.deptComboBox);
			this.Controls.Add(this.label1);
			this.Name = "SchedulingView1Form";
			this.Text = "Scheduling View 1";
			this.Load += new System.EventHandler(this.SchedulingView1Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.axSpreadsheet2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


private void SchedulingView1Form_Load(object sender, System.EventArgs e){
	
		
	
}//end SchedulingView1Form_Load


private void loadSchedule(string plantCode,string deptCode){
	
	core = CoreFactory.getInstance();
	string[] plants = core.getPlantCodes();
	for(int i = 0; i < plants.Length; i++)
			plantComboBox.Items.Add(plants[i]);

	string[] departaments = core.getDepartamentCodes();
	for(int i = 0; i < departaments.Length; i++)
		deptComboBox.Items.Add(departaments[i]);
	
	deptComboBox.Sorted = true;
	plantComboBox.Sorted = true;

	int index = this.plantComboBox.FindStringExact(plantCode);
	if (index < 0)
		plantComboBox.SelectedIndex = 0;
	else
		plantComboBox.SelectedIndex = index;

	index = this.deptComboBox.FindStringExact(deptCode);
	if (index < 0)
		deptComboBox.SelectedIndex = 0;
	else
		deptComboBox.SelectedIndex = index;


	this.label3.Text = DateUtil.getDateRepresentation(this.today,DateUtil.DDMMYYYY) +
					   " to " + DateUtil.getDateRepresentation(this.dateEnd,DateUtil.DDMMYYYY);
	this.label4.Text = "Time Span " +DAYS+ " days.";
	
	if (plantCode.Equals(""))
		return;
	if (deptCode.Equals(""))
		return;
	schedule = null;
	
	try{
		schedule = core.readSchedule(plantCode, deptCode);
	}catch(NujitException ne){
		MessageBox.Show(ne.Message);
		Dispose();
	}

	SortedList machines = schedule.getUsedMachines();
	
	for (IEnumerator en = machines.GetEnumerator(); en.MoveNext(); ){
			string machineCode = (string) ((DictionaryEntry)en.Current).Value;
			string[][] returnParts = schedule.getSchPrFmHrForMachine(machineCode);
			string oldProdId = "";
			string minQtyReq = "N/A";
			string schQty = "N/A";
			axSpreadsheet2.get_Range("A"+this.desdeFila,"A"+this.desdeFila).Value2 = machineCode;
									
			for (int p = 0; p < returnParts.Length; p++){
				string[] parts = returnParts[p];
				string prodId = parts[0]+" "; 
				int seq = int.Parse(parts[1]);
				decimal hrsReq = decimal.Parse(parts[10]);
				decimal pcsHr = decimal.Parse(parts[11]);

				if (!oldProdId.Equals(prodId)) { // adds entries for prodId
						
					axSpreadsheet2.get_Range("B"+this.desdeFila,"B"+this.desdeFila).Value2 = prodId.ToString();
					axSpreadsheet2.get_Range("B"+this.desdeFila,"B"+this.desdeFila).AutoFit();
					axSpreadsheet2.get_Range("C"+this.desdeFila,"C"+this.desdeFila).Value2 = seq.ToString();
					axSpreadsheet2.get_Range("G"+this.desdeFila,"G"+this.desdeFila).Value2 = pcsHr.ToString();
					axSpreadsheet2.get_Range("H"+this.desdeFila,"H"+this.desdeFila).Value2 = hrsReq.ToString();
									
					string[] oldQtyInfo = schedule.getSMOInfo(oldProdId, parts[6],parts[7], seq);
									
					if (oldQtyInfo.Length > 0) {
						schQty = oldQtyInfo[1];
						minQtyReq= oldQtyInfo[0];
					}
					axSpreadsheet2.get_Range("F"+this.desdeFila,"F"+this.desdeFila).Value2 = schQty;
					axSpreadsheet2.get_Range("E"+this.desdeFila,"E"+this.desdeFila).Value2 = minQtyReq;
					
				}else{
					
					axSpreadsheet2.get_Range("B"+this.desdeFila,"B"+this.desdeFila).Value2 = prodId;
					axSpreadsheet2.get_Range("B"+this.desdeFila,"B"+this.desdeFila).AutoFit();
					axSpreadsheet2.get_Range("C"+this.desdeFila,"C"+this.desdeFila).Value2 = seq.ToString();
					axSpreadsheet2.get_Range("G"+this.desdeFila,"G"+this.desdeFila).Value2 = pcsHr.ToString();
					axSpreadsheet2.get_Range("H"+this.desdeFila,"H"+this.desdeFila).Value2 = hrsReq.ToString();
					axSpreadsheet2.get_Range("F"+this.desdeFila,"F"+this.desdeFila).Value2 = schQty;
					axSpreadsheet2.get_Range("E"+this.desdeFila,"E"+this.desdeFila).Value2 = minQtyReq;
					
					
					decimal hrPr = decimal.Parse(parts[11]);
					decimal hrPrAnterior = 0;//Decimal.Parse(newRow.RowValue(10).Caption);
					decimal hrPrSubTot = hrPr + hrPrAnterior;
						
				}
									
				decimal machOrdNum = decimal.Parse(parts[8]);
				DateTime[] d = schedule.getNodeInfo(machOrdNum, machineCode, this.today, this.dateEnd);
				int hour, turn, day;
				int turnF, dayF;
				DateTime lastDay;
					
				if (d.Length >0){
	
					hour = d[0].Hour;
					turn = getTurn(hour); //Turn wil be, 1,2 or 3.
					day = d[0].DayOfYear - this.today.DayOfYear ; 
					lastDay = d[0].AddHours((double)hrsReq);
					turnF = getTurn(lastDay.Hour);
					dayF = lastDay.DayOfYear - this.today.DayOfYear;
					if (dayF > DAYS){
						dayF = DAYS;	//el ultimo dia del rango
						turnF = 3;	// el ultimo turno de ese dia.
					}
					bool fin;
					for (int j= day; j<=dayF; j++){
						fin = false;
						while (! fin){ //Marcamos los turnos para el dia j
							if (j == day){
								setDayTurn(turn,day);
								if ((turn == TURNO_3)|((day ==dayF)&(turn == turnF)))
									fin = true;
								else
									turn +=1;
							}else{	
								if (j==dayF){
									setDayTurn(turn,dayF);
									if (turn == turnF)
										fin = true;
									else
										turn +=1;
								} else {// el dia a setear no es ni el primero ni el ultimo
									setDayTurn(turn,j);
									if (turn == TURNO_3)
										fin = true;
									else	turn +=1;
								}
							}
						}	//end while
						turn = TURNO_1;
					}//end For
				}
				oldProdId = prodId;
				this.desdeFila +=1; //nos movemos un fila hacia abajo
			}
			this.desdeFila +=2; //nos movemos otra fila, ya que la maquina cambio.
		}
}//end loadSchedule


private void OkButton_Click(object sender, System.EventArgs e){
	loadSchedule(plantComboBox.Text,deptComboBox.Text);
}

private void cancelButton_Click(object sender, System.EventArgs e){
	this.Dispose();
}

private void initializeaxSpreadsheet2(){
  	axSpreadsheet2.get_Range("A2","A2").Value2 = "Machine";
	axSpreadsheet2.get_Range("A2","A2").AutoFit();
	axSpreadsheet2.get_Range("B2","B2").Value2 = "Part #";
	axSpreadsheet2.get_Range("B2","B2").AutoFit();
	axSpreadsheet2.get_Range("C2","C2").Value2 = "Seq";
	axSpreadsheet2.get_Range("C2","C2").AutoFit();
	axSpreadsheet2.get_Range("D2","D2").Value2 = "Stat";
	axSpreadsheet2.get_Range("D1","D1").AutoFit();
	axSpreadsheet2.get_Range("E1","E1").Value2 = "Min";
	axSpreadsheet2.get_Range("E2","E2").Value2 = "Qty Req";
	axSpreadsheet2.get_Range("E2","E2").AutoFit();
	axSpreadsheet2.get_Range("F1","F1").Value2 = "Sch.";
	axSpreadsheet2.get_Range("F2","F2").Value2 = "Qty";
	axSpreadsheet2.get_Range("F1","F1").AutoFit();
	axSpreadsheet2.get_Range("G2","G2").Value2 = "Pcs/Hr";
	axSpreadsheet2.get_Range("G2","G2").AutoFit();
	axSpreadsheet2.get_Range("H1","H1").Value2 = "Hrs";
    axSpreadsheet2.get_Range("H2","H2").Value2 = "Req";
	axSpreadsheet2.get_Range("H2","H2").AutoFit();
	axSpreadsheet2.get_Range("I1","I1").Value2 = "Hrs";
	axSpreadsheet2.get_Range("I2","I2").Value2 = "Util";
	axSpreadsheet2.get_Range("I2","I2").AutoFit();
	axSpreadsheet2.get_Range("J2","J2").Value2 = "Boxes";
	axSpreadsheet2.get_Range("J2","J2").AutoFit();
	
	string[] theDays = getDays();

	axSpreadsheet2.get_Range("K1","K1").Value2 = theDays[0];
	axSpreadsheet2.get_Range("K1","K1").AutoFit();

	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("K2","K2").Value2 = "1";
	axSpreadsheet2.get_Range("K2","K2").AutoFit();
	axSpreadsheet2.get_Range("L2","L2").Value2 = "2";
	axSpreadsheet2.get_Range("L2","L2").AutoFit();
	axSpreadsheet2.get_Range("M2","M2").Value2 = "3";
	axSpreadsheet2.get_Range("M2","M2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("N1","N1").Value2 = theDays[1];
	axSpreadsheet2.get_Range("N1","N1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("N2","N2").Value2 = "1";
	axSpreadsheet2.get_Range("N2","N2").AutoFit();
	axSpreadsheet2.get_Range("O2","O2").Value2 = "2";
	axSpreadsheet2.get_Range("O2","O2").AutoFit();
	axSpreadsheet2.get_Range("P2","P2").Value2 = "3";
	axSpreadsheet2.get_Range("P2","P2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("Q1","Q1").Value2 = theDays[2];
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("Q2","Q2").Value2 = "1";
	axSpreadsheet2.get_Range("Q2","Q2").AutoFit();
	axSpreadsheet2.get_Range("R2","R2").Value2 = "2";
	axSpreadsheet2.get_Range("R2","R2").AutoFit();
	axSpreadsheet2.get_Range("S2","S2").Value2 = "3";
	axSpreadsheet2.get_Range("S2","S2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("T1","T1").Value2 = theDays[3];
	axSpreadsheet2.get_Range("T1","T1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("T2","T2").Value2 = "1";
	axSpreadsheet2.get_Range("T2","T2").AutoFit();
	axSpreadsheet2.get_Range("U2","U2").Value2 = "2";
	axSpreadsheet2.get_Range("U2","U2").AutoFit();
	axSpreadsheet2.get_Range("V2","V2").Value2 = "3";
	axSpreadsheet2.get_Range("V2","V2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("W1","W1").Value2 = theDays[4];
	axSpreadsheet2.get_Range("W1","W1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("W2","W2").Value2 = "1";
	axSpreadsheet2.get_Range("W2","W2").AutoFit();
	axSpreadsheet2.get_Range("X2","X2").Value2 = "2";
	axSpreadsheet2.get_Range("X2","X2").AutoFit();
	axSpreadsheet2.get_Range("Y2","Y2").Value2 = "3";
	axSpreadsheet2.get_Range("Y2","Y2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("Z1","Z1").Value2 = theDays[5];
	axSpreadsheet2.get_Range("Z1","Z1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("Z2","Z2").Value2 = "1";
	axSpreadsheet2.get_Range("Z2","Z2").AutoFit();
	axSpreadsheet2.get_Range("AA2","AA2").Value2 = "2";
	axSpreadsheet2.get_Range("AA2","AA2").AutoFit();
	axSpreadsheet2.get_Range("AB2","AB2").Value2 = "3";
	axSpreadsheet2.get_Range("AB2","AB2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("AC1","AC1").Value2 = theDays[6];
	axSpreadsheet2.get_Range("AC1","AC1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AC2","AC2").Value2 = "1";
	axSpreadsheet2.get_Range("AC2","AC2").AutoFit();
	axSpreadsheet2.get_Range("AD2","AD2").Value2 = "2";
	axSpreadsheet2.get_Range("AD2","AD2").AutoFit();
	axSpreadsheet2.get_Range("AE2","AE2").Value2 = "3";
	axSpreadsheet2.get_Range("AE2","AE2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("AF1","AF1").Value2 = theDays[7];
	axSpreadsheet2.get_Range("AF1","AF1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AF2","AF2").Value2 = "1";
	axSpreadsheet2.get_Range("AF2","AF2").AutoFit();
	axSpreadsheet2.get_Range("AG2","AG2").Value2 = "2";
	axSpreadsheet2.get_Range("AG2","AG2").AutoFit();
	axSpreadsheet2.get_Range("AH2","AH2").Value2 = "3";
	axSpreadsheet2.get_Range("AH2","AH2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("AI1","AI1").Value2 = theDays[8];
	axSpreadsheet2.get_Range("AI1","AI1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AI2","AI2").Value2 = "1";
	axSpreadsheet2.get_Range("AI2","AI2").AutoFit();
	axSpreadsheet2.get_Range("AJ2","AJ2").Value2 = "2";
	axSpreadsheet2.get_Range("AJ2","AJ2").AutoFit();
	axSpreadsheet2.get_Range("AK2","AK2").Value2 = "3";
	axSpreadsheet2.get_Range("AK2","AK2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("AL1","AL1").Value2 = theDays[9];
	axSpreadsheet2.get_Range("AL1","AL1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AL2","AL2").Value2 = "1";
	axSpreadsheet2.get_Range("AL2","AL2").AutoFit();
	axSpreadsheet2.get_Range("AM2","AM2").Value2 = "2";
	axSpreadsheet2.get_Range("AM2","AM2").AutoFit();
	axSpreadsheet2.get_Range("AN2","AN2").Value2 = "3";
	axSpreadsheet2.get_Range("AN2","AN2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("AO1","AO1").Value2 = theDays[10];
	axSpreadsheet2.get_Range("AO1","AO1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AO2","AO2").Value2 = "1";
	axSpreadsheet2.get_Range("AO2","AO2").AutoFit();
	axSpreadsheet2.get_Range("AP2","AP2").Value2 = "2";
	axSpreadsheet2.get_Range("AP2","AP2").AutoFit();
	axSpreadsheet2.get_Range("AQ2","AQ2").Value2 = "3";
	axSpreadsheet2.get_Range("AQ2","AQ2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("AR1","AR1").Value2 = theDays[11];
	axSpreadsheet2.get_Range("AR1","AR1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AR2","AR2").Value2 = "1";
	axSpreadsheet2.get_Range("AR2","AR2").AutoFit();
	axSpreadsheet2.get_Range("AS2","AS2").Value2 = "2";
	axSpreadsheet2.get_Range("AS2","AS2").AutoFit();
	axSpreadsheet2.get_Range("AT2","AT2").Value2 = "3";
	axSpreadsheet2.get_Range("AT2","AT2").AutoFit();
//---------------------
	axSpreadsheet2.get_Range("AU1","AU1").Value2 = theDays[12];
	axSpreadsheet2.get_Range("AU1","AU1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AU2","AU2").Value2 = "1";
	axSpreadsheet2.get_Range("AU2","AU2").AutoFit();
	axSpreadsheet2.get_Range("AV2","AV2").Value2 = "2";
	axSpreadsheet2.get_Range("AV2","AV2").AutoFit();
	axSpreadsheet2.get_Range("AW2","AW2").Value2 = "3";
	axSpreadsheet2.get_Range("AW2","AW2").AutoFit();
//-----------
	axSpreadsheet2.get_Range("AX1","AX1").Value2 = theDays[13];
	axSpreadsheet2.get_Range("AX1","AX1").AutoFit();
	//Los campos de los tres turnos se quedan fijos.
	axSpreadsheet2.get_Range("AX2","AX2").Value2 = "1";
	axSpreadsheet2.get_Range("AX2","AX2").AutoFit();
	axSpreadsheet2.get_Range("AY2","AY2").Value2 = "2";
	axSpreadsheet2.get_Range("AY2","AY2").AutoFit();
	axSpreadsheet2.get_Range("AZ2","AZ2").Value2 = "3";
	axSpreadsheet2.get_Range("AZ2","AZ2").AutoFit();
	
}

private string[] getDays(){
	//Array with 14 days including today
	string[] days = new string[DAYS];
	for(int i=0;i< days.Length;i++){
		if (i==0){
			days[i] = DateUtil.getNameDayOfWeek(today);
		} else {
			days[i] = DateUtil.getNextDayOfWeek(days[i-1]);
		}
	}
	return days;	
}


private int getTurn(int hour){
	if ((HORA_0 <= hour)&(hour<=HORA_8)){
		return 1;
	} else 
	if ((HORA_8 <= hour)&(hour<=HORA_16)){
		return 2;
	} else
		return 3;
}

private void setDayTurn(int turn, int day){
	switch (day){
		case 0: switch (turn){
					case 1: axSpreadsheet2.get_Range("K"+this.desdeFila,"K"+this.desdeFila).Value2 = "X";
							break;
					case 2: axSpreadsheet2.get_Range("L"+this.desdeFila,"L"+this.desdeFila).Value2 = "X";
							break;
					case 3: axSpreadsheet2.get_Range("M"+this.desdeFila,"M"+this.desdeFila).Value2 = "X";
							break;
					
				}break;
		case 1: switch (turn){
					case 1 : axSpreadsheet2.get_Range("N"+this.desdeFila,"N"+this.desdeFila).Value2 = "X";
							 break;
					case 2 : axSpreadsheet2.get_Range("O"+this.desdeFila,"O"+this.desdeFila).Value2 = "X";
							 break;
					case 3 : axSpreadsheet2.get_Range("P"+this.desdeFila,"P"+this.desdeFila).Value2 = "X";
							 break;	
				}break;
		case 2: switch (turn){
					case 1:axSpreadsheet2.get_Range("Q"+this.desdeFila,"Q"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("R"+this.desdeFila,"R"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("S"+this.desdeFila,"S"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 3: switch (turn){
					case 1:axSpreadsheet2.get_Range("T"+this.desdeFila,"T"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("U"+this.desdeFila,"U"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("V"+this.desdeFila,"V"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 4: switch (turn){
					case 1:axSpreadsheet2.get_Range("W"+this.desdeFila,"W"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("X"+this.desdeFila,"X"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("Y"+this.desdeFila,"Y"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 5: switch (turn){
					case 1:axSpreadsheet2.get_Range("Z"+this.desdeFila,"Z"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AA"+this.desdeFila,"AA"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AB"+this.desdeFila,"AB"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 6: switch (turn){
					case 1:axSpreadsheet2.get_Range("AC"+this.desdeFila,"AC"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AD"+this.desdeFila,"AD"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AE"+this.desdeFila,"AE"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 7: switch (turn){
					case 1:axSpreadsheet2.get_Range("AF"+this.desdeFila,"AF"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AG"+this.desdeFila,"AG"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AH"+this.desdeFila,"AH"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 8: switch (turn){
					case 1:axSpreadsheet2.get_Range("AI"+this.desdeFila,"AI"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AJ"+this.desdeFila,"AJ"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AK"+this.desdeFila,"AK"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 9: switch (turn){
					case 1:axSpreadsheet2.get_Range("AL"+this.desdeFila,"AL"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AM"+this.desdeFila,"AM"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AN"+this.desdeFila,"AN"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 10: switch (turn){
					case 1:axSpreadsheet2.get_Range("AO"+this.desdeFila,"AO"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AP"+this.desdeFila,"AP"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AQ"+this.desdeFila,"AQ"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 11: switch (turn){
					case 1:axSpreadsheet2.get_Range("AR"+this.desdeFila,"AR"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AS"+this.desdeFila,"AS"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AT"+this.desdeFila,"AT"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 12: switch (turn){
					case 1:axSpreadsheet2.get_Range("AU"+this.desdeFila,"AU"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AV"+this.desdeFila,"AV"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AW"+this.desdeFila,"AW"+this.desdeFila).Value2 = "X";
							break;
				}break;
		case 13: switch (turn){
					case 1:axSpreadsheet2.get_Range("AX"+this.desdeFila,"AX"+this.desdeFila).Value2 = "X";
							break;
					case 2:axSpreadsheet2.get_Range("AY"+this.desdeFila,"AY"+this.desdeFila).Value2 = "X";
							break;
					case 3:axSpreadsheet2.get_Range("AZ"+this.desdeFila,"AZ"+this.desdeFila).Value2 = "X";
							break;
				}break;
	}	
}//end setDayTurn

private void clearExcel(){
	
	axSpreadsheet2.get_Range("A"+ROW_INI,"A"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("B"+ROW_INI,"B"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("C"+ROW_INI,"C"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("D"+ROW_INI,"D"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("E"+ROW_INI,"E"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("F"+ROW_INI,"F"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("G"+ROW_INI,"G"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("H"+ROW_INI,"H"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("I"+ROW_INI,"I"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("J"+ROW_INI,"J"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("K"+ROW_INI,"K"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("L"+ROW_INI,"L"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("M"+ROW_INI,"M"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("N"+ROW_INI,"N"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("O"+ROW_INI,"O"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("P"+ROW_INI,"P"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("Q"+ROW_INI,"Q"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("R"+ROW_INI,"R"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("S"+ROW_INI,"S"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("T"+ROW_INI,"T"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("U"+ROW_INI,"U"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("V"+ROW_INI,"V"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("W"+ROW_INI,"W"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("X"+ROW_INI,"X"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("Y"+ROW_INI,"Y"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("Z"+ROW_INI,"Z"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AA"+ROW_INI,"AA"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AB"+ROW_INI,"AB"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AC"+ROW_INI,"AC"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AD"+ROW_INI,"AD"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AE"+ROW_INI,"AE"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AF"+ROW_INI,"AF"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AG"+ROW_INI,"AG"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AH"+ROW_INI,"AH"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AI"+ROW_INI,"AI"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AJ"+ROW_INI,"AJ"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AK"+ROW_INI,"AK"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AL"+ROW_INI,"AL"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AM"+ROW_INI,"AM"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AN"+ROW_INI,"AN2"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AO"+ROW_INI,"AO"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AP"+ROW_INI,"AP"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AQ"+ROW_INI,"AQ"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AR"+ROW_INI,"AR"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AS"+ROW_INI,"AS"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AT"+ROW_INI,"AT"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AU"+ROW_INI,"AU"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AV"+ROW_INI,"AV"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AW"+ROW_INI,"AW"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AX"+ROW_INI,"AX"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AY"+ROW_INI,"AY"+this.desdeFila).ClearContents();
	axSpreadsheet2.get_Range("AZ"+ROW_INI,"AZ"+this.desdeFila).ClearContents();

	this.desdeFila = ROW_INI;

}


private void toolBar1_ButtonClick_1(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e){
	switch(e.Button.Tag.ToString()){
		case "refresh": 
			clearExcel();
			loadSchedule(this.plantComboBox.Text,this.deptComboBox.Text);
			break;
		case "add":
			AddForm addForm = new AddForm(this.plantComboBox.Text,
				this.deptComboBox.Text);
			addForm.ShowDialog();
			clearExcel();
			loadSchedule(this.plantComboBox.Text,this.deptComboBox.Text); 
			break;
		case "close":
			this.Dispose();
			break;
		case "print":
			DataSet dataSet=this.generateReportDataSet(plantComboBox.Text,deptComboBox.Text);
			SchedulingViewReport schedulingViewReport = new SchedulingViewReport(dataSet);
			schedulingViewReport.ShowDialog();
			break;
		}
}

		

private DataSet generateReportDataSet(string plantCode,string deptCode){
	DataTable dataTable = new DataTable();
	DataRow dataRow;
	
	dataTable.TableName = "schedule";	
						
	dataTable.Columns.Add(new DataColumn("SPH_ProdID",typeof(string)));
	dataTable.Columns.Add(new DataColumn("SPH_Seq",typeof(int)));
	dataTable.Columns.Add(new DataColumn("SPH_HrPr",typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("SPH_UtilPer",typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("SPH_MachOrdNum",typeof(int)));
	dataTable.Columns.Add(new DataColumn("PDM_Mach",typeof(string)));
	dataTable.Columns.Add(new DataColumn("SMH_TmStart",typeof(DateTime)));
	dataTable.Columns.Add(new DataColumn("SMH_HrPr",typeof(decimal)));
	
	CoreFactory coreFactory =CoreFactory.getInstance();
	string[][] vec = coreFactory.getScheduleForReport(plantCode, deptCode);
	
	for(int x = 0; x < vec.Length; x++){
		if (vec[x]!=null){
			dataRow = dataTable.NewRow();
			dataRow[0]= vec[x][0];
			dataRow[1]= int.Parse(vec[x][1]);
			dataRow[2]= decimal.Parse(vec[x][2]);
			dataRow[3]= decimal.Parse(vec[x][3]);
			dataRow[4]= int.Parse(vec[x][4]);
			dataRow[5]= vec[x][5];
			dataRow[6]= DateUtil.parseCompleteDate(vec[x][6],DateUtil.MMDDYYYY);
			dataRow[7]= decimal.Parse(vec[x][7]);
			dataTable.Rows.Add(dataRow);
		}
	}

	DataSet scheduleReportDataSet = new DataSet();
	scheduleReportDataSet.Tables.Add(dataTable);
	
	return scheduleReportDataSet;
}
		

		

		
		


		
}// end class
}//en namespace
