using System;
using Nujit.NujitERP.ClassLib.Util;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Data.SqlClient;

namespace Nujit.NujitERP.WinForms.Reports.SchedulingView
{
public class rptSchedulingReport : ActiveReport	{
		private const int DAYS = 14;
		private const int HORA_0 = 0;
		private const int HORA_8 = 8;
		private const int HORA_16 = 16;
		private const int HORAS_T = 8;
		private const int TURNO_1 = 1;
		private const int TURNO_2 = 2;
		private const int TURNO_3 = 3;
		private bool  firstTime;
		private string machAnt;
		
			
public rptSchedulingReport(){	
			InitializeReport();
			this.TextBox1.Text = DateUtil.getDateRepresentation(System.DateTime.Today,DateUtil.DDMMYYYY);
			this.TextBox2.Text = DateUtil.getDateRepresentation(System.DateTime.Today.AddDays(DAYS),DateUtil.DDMMYYYY);
			
			string[] theDays = getDays();
			this.day1.Text= theDays[0];
			this.day2.Text= theDays[1];
			this.day3.Text= theDays[2];
			this.day4.Text= theDays[3];
			this.day5.Text= theDays[4];
			this.day6.Text= theDays[5];
			this.day7.Text= theDays[6];
			this.day8.Text= theDays[7];
			this.day9.Text= theDays[8];
			this.day10.Text= theDays[9];
			this.day11.Text= theDays[10];
			this.day12.Text= theDays[11];
			this.day13.Text= theDays[12];
			this.day14.Text= theDays[13];
			firstTime = true;
		
	
		}

		
public void setLabels(){
}

private void Detail_Format(object sender, System.EventArgs eArgs){
	DateTime smh_TmStart = new DateTime();
	decimal smh_HrPr;
	if ((string)this.txtMachine.Value == null || (string)this.txtMachine.Value =="" ){
		this.txtBEmpty.Text = "There is no information to display";
		
	}else{
	smh_TmStart = DateUtil.parseCompleteDate(tBSMHTmStart.Text.Substring(0,18),DateUtil.MMDDYYYY);
    smh_HrPr =decimal.Parse(this.tBSMHHrPr.Text);
		if (firstTime){
			firstTime = false;	
			machAnt = (string)this.txtMachine.Value;

			DateTime dateEnd;
			dateEnd = smh_TmStart.AddHours((double)smh_HrPr);
			setTurnos(smh_TmStart,dateEnd);
		} else{
			if (machAnt == (string)this.txtMachine.Value){
				DateTime dateEnd;
				dateEnd = smh_TmStart.AddHours((double)smh_HrPr);
				clearTurnos();
				setTurnos(smh_TmStart,dateEnd);
			}else {
				machAnt = (string)this.txtMachine.Value;
				DateTime dateEnd;
				dateEnd = smh_TmStart.AddHours((double)smh_HrPr);
				clearTurnos();
				setTurnos(smh_TmStart,dateEnd);
			}
		}
	}	
}


private void clearTurnos(){
	this.txtD1T1.Text = "";
	this.txtD1T2.Text = "";
	this.txtD1T3.Text = "";
	this.txtD1T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD2T1.Text = "";
	this.txtD2T2.Text = "";
	this.txtD2T3.Text = "";
	this.txtD2T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD3T1.Text = "";
	this.txtD3T2.Text = "";
	this.txtD3T3.Text = "";
	this.txtD3T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD4T1.Text = "";
	this.txtD4T2.Text = "";
	this.txtD4T3.Text = "";
	this.txtD4T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD5T1.Text = "";
	this.txtD5T2.Text = "";
	this.txtD5T3.Text = "";
	this.txtD5T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD6T1.Text = "";
	this.txtD6T2.Text = "";
	this.txtD6T3.Text = "";
	this.txtD6T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD7T1.Text = "";
	this.txtD7T2.Text = "";
	this.txtD7T3.Text = "";
	this.txtD7T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD8T1.Text = "";
	this.txtD8T2.Text = "";
	this.txtD8T3.Text = "";
	this.txtD8T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD9T1.Text = "";
	this.txtD9T2.Text = "";
	this.txtD9T3.Text = "";
	this.txtD9T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD10T1.Text = "";
	this.txtD10T2.Text = "";
	this.txtD10T3.Text = "";
	this.txtD10T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD11T1.Text = "";
	this.txtD11T2.Text = "";
	this.txtD11T3.Text = "";
	this.txtD11T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD12T1.Text = "";
	this.txtD12T2.Text = "";
	this.txtD12T3.Text = "";
	this.txtD12T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD13T1.Text = "";
	this.txtD13T2.Text = "";
	this.txtD13T3.Text = "";
	this.txtD13T3.BackColor = System.Drawing.Color.Gainsboro;
	this.txtD14T1.Text = "";
	this.txtD14T2.Text = "";
	this.txtD14T3.Text = "";
	this.txtD14T3.BackColor = System.Drawing.Color.Gainsboro;
	
}
private void setTurnos(DateTime dateIni, DateTime dateEnd){
	int hour,turn,day;
	int turnF,dayF;

	hour = dateIni.Hour;
	turn = getTurn(hour);
	day =  dateIni.DayOfYear - System.DateTime.Today.DayOfYear;
	turnF = getTurn(dateEnd.Hour);
	dayF = dateEnd.DayOfYear - System.DateTime.Today.DayOfYear;

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
		}//end wihile
		turn = TURNO_1;
	}
}

private void setDayTurn(int turn, int day){
	switch (day){
		case 0: switch (turn){
					case 1: this.txtD1T1.Text = "x";
							break;
					case 2: this.txtD1T2.Text = "x";
							break;
					case 3: this.txtD1T3.Text = "x";
							this.txtD1T3.BackColor = System.Drawing.Color.Transparent;
							break;
					
				}break;
		case 1: switch (turn){
					case 1 : this.txtD2T1.Text = "x";
							 break;
					case 2 : this.txtD2T2.Text = "x";
							 break;
					case 3 : this.txtD2T3.Text = "x";
							 this.txtD2T3.BackColor = System.Drawing.Color.Transparent;
							 break;	
				}break;
		case 2: switch (turn){
					case 1:this.txtD3T1.Text = "x";
							break;
					case 2:this.txtD3T2.Text = "x";
							break;
					case 3: this.txtD3T3.Text = "x";
							this.txtD3T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 3: switch (turn){
					case 1:this.txtD4T1.Text = "x";
							break;
					case 2:this.txtD4T2.Text = "x";
							break;
					case 3:this.txtD4T3.Text = "x";
						   this.txtD4T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 4: switch (turn){
					case 1:this.txtD5T1.Text = "x";
							break;
					case 2:this.txtD5T2.Text = "x";
							break;
					case 3:this.txtD5T3.Text = "x";
							this.txtD5T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 5: switch (turn){
					case 1:this.txtD6T1.Text = "x";
							break;
					case 2:this.txtD6T2.Text = "x";
							break;
					case 3:this.txtD6T3.Text = "x";
							this.txtD6T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 6: switch (turn){
					case 1:this.txtD7T1.Text = "x";
							break;
					case 2:this.txtD7T2.Text = "x";
							break;
					case 3:this.txtD7T3.Text = "x";
						   this.txtD7T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 7: switch (turn){
					case 1:this.txtD8T1.Text = "x";
							break;
					case 2:this.txtD8T2.Text = "x";
							break;
					case 3:this.txtD8T3.Text = "x";
							this.txtD8T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 8: switch (turn){
					case 1:this.txtD9T1.Text = "x";
							break;
					case 2:this.txtD9T2.Text = "x";
							break;
					case 3:this.txtD9T3.Text = "x";
						   this.txtD9T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 9: switch (turn){
					case 1:this.txtD10T1.Text = "x";
							break;
					case 2:this.txtD10T2.Text = "x";
							break;
					case 3:this.txtD10T3.Text = "x";
						   this.txtD10T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 10: switch (turn){
					case 1:this.txtD11T1.Text = "x";
							break;
					case 2:this.txtD11T2.Text = "x";
							break;
					case 3:this.txtD11T3.Text = "x";
							this.txtD11T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 11: switch (turn){
					case 1:this.txtD12T1.Text = "x";
							break;
					case 2:this.txtD12T2.Text = "x";
							break;
					case 3:this.txtD12T3.Text = "x";
							this.txtD12T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 12: switch (turn){
					case 1:this.txtD13T1.Text = "x";
							break;
					case 2:this.txtD13T2.Text = "x";
							break;
					case 3:this.txtD13T3.Text = "x";
							this.txtD13T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
		case 13: switch (turn){
					case 1:this.txtD14T1.Text = "x";
							break;
					case 2:this.txtD14T2.Text = "x";
							break;
					case 3:this.txtD14T3.Text = "x";
							this.txtD14T3.BackColor = System.Drawing.Color.Transparent;
							break;
				}break;
	}

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

	

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label6;
		private DataDynamics.ActiveReports.TextBox TextBox1;
		private DataDynamics.ActiveReports.TextBox TextBox2;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.Label Label9;
		private DataDynamics.ActiveReports.Label Label10;
		private DataDynamics.ActiveReports.Label Label11;
		private DataDynamics.ActiveReports.Label Label12;
		private DataDynamics.ActiveReports.Label Label13;
		private DataDynamics.ActiveReports.Label Label14;
		private DataDynamics.ActiveReports.Label Label15;
		private DataDynamics.ActiveReports.Label day1;
		private DataDynamics.ActiveReports.Label day2;
		private DataDynamics.ActiveReports.Label day3;
		private DataDynamics.ActiveReports.Label day4;
		private DataDynamics.ActiveReports.Label day5;
		private DataDynamics.ActiveReports.Label day6;
		private DataDynamics.ActiveReports.Label day7;
		private DataDynamics.ActiveReports.Label day8;
		private DataDynamics.ActiveReports.Label day9;
		private DataDynamics.ActiveReports.Label day10;
		private DataDynamics.ActiveReports.Label day11;
		private DataDynamics.ActiveReports.Label day12;
		private DataDynamics.ActiveReports.Label day13;
		private DataDynamics.ActiveReports.Label day14;
		private DataDynamics.ActiveReports.Label Label16;
		private DataDynamics.ActiveReports.Label Label17;
		private DataDynamics.ActiveReports.Label Label18;
		private DataDynamics.ActiveReports.Label Label19;
		private DataDynamics.ActiveReports.Label Label20;
		private DataDynamics.ActiveReports.Label Label21;
		private DataDynamics.ActiveReports.Label Label22;
		private DataDynamics.ActiveReports.Label Label23;
		private DataDynamics.ActiveReports.Label Label24;
		private DataDynamics.ActiveReports.Label Label25;
		private DataDynamics.ActiveReports.Label Label26;
		private DataDynamics.ActiveReports.Label Label27;
		private DataDynamics.ActiveReports.Label Label28;
		private DataDynamics.ActiveReports.Label Label29;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1;
		private DataDynamics.ActiveReports.TextBox PDM_Mach1;
		private DataDynamics.ActiveReports.Detail Detail;
		public DataDynamics.ActiveReports.TextBox txtPart;
		private DataDynamics.ActiveReports.TextBox txtSeq;
		private DataDynamics.ActiveReports.TextBox txtStat;
		private DataDynamics.ActiveReports.TextBox txtMinQtyReq;
		private DataDynamics.ActiveReports.TextBox txtSchQty;
		private DataDynamics.ActiveReports.TextBox txtPcsHr;
		private DataDynamics.ActiveReports.TextBox txtHrsUtil;
		private DataDynamics.ActiveReports.TextBox txtBoxes;
		private DataDynamics.ActiveReports.TextBox txtD1T1;
		private DataDynamics.ActiveReports.TextBox txtD1T2;
		private DataDynamics.ActiveReports.TextBox txtD1T3;
		private DataDynamics.ActiveReports.TextBox txtD2T1;
		private DataDynamics.ActiveReports.TextBox txtD2T2;
		private DataDynamics.ActiveReports.TextBox txtD2T3;
		private DataDynamics.ActiveReports.TextBox txtD3T1;
		private DataDynamics.ActiveReports.TextBox txtD3T2;
		private DataDynamics.ActiveReports.TextBox txtD3T3;
		private DataDynamics.ActiveReports.TextBox txtD4T1;
		private DataDynamics.ActiveReports.TextBox txtD4T2;
		private DataDynamics.ActiveReports.TextBox txtD4T3;
		private DataDynamics.ActiveReports.TextBox txtD5T1;
		private DataDynamics.ActiveReports.TextBox txtD5T2;
		private DataDynamics.ActiveReports.TextBox txtD5T3;
		private DataDynamics.ActiveReports.TextBox txtD6T1;
		private DataDynamics.ActiveReports.TextBox txtD6T2;
		private DataDynamics.ActiveReports.TextBox txtD6T3;
		private DataDynamics.ActiveReports.TextBox txtD7T1;
		private DataDynamics.ActiveReports.TextBox txtD7T2;
		private DataDynamics.ActiveReports.TextBox txtD7T3;
		private DataDynamics.ActiveReports.TextBox txtD8T1;
		private DataDynamics.ActiveReports.TextBox txtD8T2;
		private DataDynamics.ActiveReports.TextBox txtD8T3;
		private DataDynamics.ActiveReports.TextBox txtD9T1;
		private DataDynamics.ActiveReports.TextBox txtD9T2;
		private DataDynamics.ActiveReports.TextBox txtD9T3;
		private DataDynamics.ActiveReports.TextBox txtD10T1;
		private DataDynamics.ActiveReports.TextBox txtD10T2;
		private DataDynamics.ActiveReports.TextBox txtD10T3;
		private DataDynamics.ActiveReports.TextBox txtD11T1;
		private DataDynamics.ActiveReports.TextBox txtD11T2;
		private DataDynamics.ActiveReports.TextBox txtD11T3;
		private DataDynamics.ActiveReports.TextBox txtD12T1;
		private DataDynamics.ActiveReports.TextBox txtD12T2;
		private DataDynamics.ActiveReports.TextBox txtD12T3;
		private DataDynamics.ActiveReports.TextBox txtD13T1;
		private DataDynamics.ActiveReports.TextBox txtD13T2;
		private DataDynamics.ActiveReports.TextBox txtD13T3;
		private DataDynamics.ActiveReports.TextBox txtD14T1;
		private DataDynamics.ActiveReports.TextBox txtD14T2;
		private DataDynamics.ActiveReports.TextBox txtD14T3;
		private DataDynamics.ActiveReports.TextBox tBSMHTmStart;
		private DataDynamics.ActiveReports.TextBox tBSMHHrPr;
		private DataDynamics.ActiveReports.TextBox txtMachine;
		private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.TextBox TextBox4;
		private DataDynamics.ActiveReports.TextBox TextBox5;
		private DataDynamics.ActiveReports.TextBox TextBox6;
		private DataDynamics.ActiveReports.TextBox TextBox7;
		private DataDynamics.ActiveReports.TextBox TextBox8;
		private DataDynamics.ActiveReports.TextBox TextBox9;
		private DataDynamics.ActiveReports.TextBox TextBox10;
		private DataDynamics.ActiveReports.TextBox TextBox11;
		private DataDynamics.ActiveReports.TextBox TextBox12;
		private DataDynamics.ActiveReports.TextBox TextBox13;
		private DataDynamics.ActiveReports.TextBox TextBox14;
		private DataDynamics.ActiveReports.TextBox TextBox15;
		private DataDynamics.ActiveReports.TextBox TextBox16;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1;
		private DataDynamics.ActiveReports.TextBox txtBEmpty;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.SchedulingView.rptSchedulingReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[1]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[2]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[3]));
			this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[4]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.day1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.day2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.day3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.day4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.day5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.day6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.day7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.day8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
			this.day9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.day10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[18]));
			this.day11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
			this.day12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[20]));
			this.day13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[21]));
			this.day14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[22]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[23]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[24]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[25]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[26]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[27]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[28]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[29]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[30]));
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[31]));
			this.Label25 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[32]));
			this.Label26 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[33]));
			this.Label27 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[34]));
			this.Label28 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[35]));
			this.Label29 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[36]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[37]));
			this.PDM_Mach1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[0]));
			this.txtPart = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtSeq = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.txtStat = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.txtMinQtyReq = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.txtSchQty = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.txtPcsHr = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.txtHrsUtil = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.txtBoxes = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.txtD1T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.txtD1T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.txtD1T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.txtD2T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.txtD2T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.txtD2T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.txtD3T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.txtD3T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.txtD3T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.txtD4T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			this.txtD4T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[18]));
			this.txtD4T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[19]));
			this.txtD5T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[20]));
			this.txtD5T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[21]));
			this.txtD5T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[22]));
			this.txtD6T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[23]));
			this.txtD6T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[24]));
			this.txtD6T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[25]));
			this.txtD7T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[26]));
			this.txtD7T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[27]));
			this.txtD7T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[28]));
			this.txtD8T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[29]));
			this.txtD8T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[30]));
			this.txtD8T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[31]));
			this.txtD9T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[32]));
			this.txtD9T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[33]));
			this.txtD9T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[34]));
			this.txtD10T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[35]));
			this.txtD10T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[36]));
			this.txtD10T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[37]));
			this.txtD11T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[38]));
			this.txtD11T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[39]));
			this.txtD11T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[40]));
			this.txtD12T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[41]));
			this.txtD12T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[42]));
			this.txtD12T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[43]));
			this.txtD13T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[44]));
			this.txtD13T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[45]));
			this.txtD13T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[46]));
			this.txtD14T1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[47]));
			this.txtD14T2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[48]));
			this.txtD14T3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[49]));
			this.tBSMHTmStart = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[50]));
			this.tBSMHHrPr = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[51]));
			this.txtMachine = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[52]));
			this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[53]));
			this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[54]));
			this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[55]));
			this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[56]));
			this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[57]));
			this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[58]));
			this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[59]));
			this.TextBox10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[60]));
			this.TextBox11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[61]));
			this.TextBox12 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[62]));
			this.TextBox13 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[63]));
			this.TextBox14 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[64]));
			this.TextBox15 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[65]));
			this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[66]));
			this.txtBEmpty = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[0]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.PageFooter.Controls[0]));
			// Attach Report Events
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
		}

		#endregion
	
private string[] getDays(){
	//Array with 14 days including today
	string[] days = new string[DAYS];
	for(int i=0;i< days.Length;i++){
		if (i==0){
			days[i] = DateUtil.getNameDayOfWeek(DateTime.Today);
		} else {
			days[i] = DateUtil.getNextDayOfWeek(days[i-1]);
		}
	}
	return days;	
}

}
}
