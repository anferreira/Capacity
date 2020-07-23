using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AGVBN20;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms;
using Nujit.NujitERP.WinForms.CapacityModule;
using GridScheduling.gui.Model;
using Nujit.NujitERP.ClassLib.ErpException;
using NujitERP.WinForms.Reports.SchedulingView;
using System.Data;
using System.Threading;

namespace GridScheduling.gui.schedule{

/// <summary>
/// Summary description for GridForm.
/// </summary>

public 
class GridForm : System.Windows.Forms.Form{

private ScheduleModel model = null;
private CoreFactory core;
private DateTime today = DateTime.Today;
private DateTime dtStart = DateTime.Today;
private DateTime dtEnd = DateTime.Today;
private Schedule gridSch = null;
private ShiftContainer shifts;
private int fila=1;
private int selectedItemIndex;

private System.ComponentModel.IContainer components;
private ActiveGanttVBNCtl grid;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.ComboBox plantComboBox;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.ToolBar toolBar1;
private System.Windows.Forms.ToolBarButton expand;
private System.Windows.Forms.ToolBarButton reduce;
private System.Windows.Forms.ToolBarButton refresh;
private System.Windows.Forms.ToolBarButton print;
private System.Windows.Forms.ToolBarButton sendToCms;
private System.Windows.Forms.ToolBarButton add;
private System.Windows.Forms.ToolBarButton stats;
private System.Windows.Forms.ToolBarButton shortage;
private System.Windows.Forms.ToolBarButton chVersion;
private System.Windows.Forms.ToolBarButton close;
private System.Windows.Forms.ImageList imageList1;
private System.Windows.Forms.DateTimePicker fromDateTimePicker;
private System.Windows.Forms.DateTimePicker toDateTimePicker;
private System.Windows.Forms.DateTimePicker currentDateTimePicker;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Button schView1Button;
private System.Windows.Forms.Button matRecButton;
private System.Windows.Forms.TextBox txtProdId;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Label label8;
private System.Windows.Forms.Label label9;
private System.Windows.Forms.Label label10;
private System.Windows.Forms.Label label11;
private System.Windows.Forms.TextBox txtSeq;
private System.Windows.Forms.TextBox txtUtilPer;
private System.Windows.Forms.TextBox txtDrs;
private System.Windows.Forms.TextBox txtRunStd;
private System.Windows.Forms.TextBox txtHrPr;
private System.Windows.Forms.Label label12;
private System.Windows.Forms.Label label13;
private System.Windows.Forms.TextBox txtMinQtyReq;
private System.Windows.Forms.TextBox txtSchQty;
private System.Windows.Forms.ToolBarButton sep1;
private System.Windows.Forms.ToolBarButton sep2;
private System.Windows.Forms.ToolBarButton sep3;
private System.Windows.Forms.Button button1;
private System.Windows.Forms.Button button2;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.Button matButton;
private FormMain formMainParent;
private System.Windows.Forms.ComboBox versionComboBox;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.Panel detailPanel;
private System.Windows.Forms.ContextMenu contextMenu1;
private System.Windows.Forms.Panel panelLeyends;
private System.Windows.Forms.GroupBox groupBoxTimeScope;
private System.Windows.Forms.Panel demandPanel;
private System.Windows.Forms.Label demandTitleLabel;
private System.Windows.Forms.Label label14;
private System.Windows.Forms.Label label15;
private System.Windows.Forms.Label label16;
private System.Windows.Forms.Label label17;
private System.Windows.Forms.Label label18;
private System.Windows.Forms.Label label19;
private System.Windows.Forms.Label label20;
private System.Windows.Forms.Label label21;
private System.Windows.Forms.Label label22;
private System.Windows.Forms.Label label23;
private System.Windows.Forms.Label label24;
private System.Windows.Forms.Label label25;
private System.Windows.Forms.TextBox orderIDTextBox;
private System.Windows.Forms.TextBox itemIDTextBox;
private System.Windows.Forms.TextBox releaseIDTextBox;
private System.Windows.Forms.TextBox dateShipTextBox;
private System.Windows.Forms.TextBox dateReadyTextBox;
private System.Windows.Forms.TextBox descriptionTextBox;
private System.Windows.Forms.TextBox seqTextBox;
private System.Windows.Forms.TextBox prodIDTextBox;
private System.Windows.Forms.TextBox custIDTextBox;
private System.Windows.Forms.TextBox nameTextBox;
private System.Windows.Forms.TextBox qtyTextBox;
private System.Windows.Forms.Label label26;
	private System.Windows.Forms.ContextMenu gridContextMenu;
	private System.Windows.Forms.MenuItem addMenuItem;
	private System.Windows.Forms.MenuItem removeMenuItem;
	private System.Windows.Forms.MenuItem sepMenuItem;
	private System.Windows.Forms.MenuItem clearMenuItem;
	private System.Windows.Forms.MenuItem fromDemandMenuItem;
	private System.Windows.Forms.ToolBarButton save;
private System.Windows.Forms.CheckBox demandCheckBox;




public 
GridForm(FormMain formParent){
	InitializeComponent();

	this.MdiParent = formParent;
	this.formMainParent = formParent;
}

public 
GridForm(){
	InitializeComponent();
	detailPanel.Visible = false;
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
	this.components = new System.ComponentModel.Container();
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GridForm));
	this.grid = new AGVBN20.ActiveGanttVBNCtl();
	this.label1 = new System.Windows.Forms.Label();
	this.plantComboBox = new System.Windows.Forms.ComboBox();
	this.label2 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.toolBar1 = new System.Windows.Forms.ToolBar();
	this.expand = new System.Windows.Forms.ToolBarButton();
	this.reduce = new System.Windows.Forms.ToolBarButton();
	this.sep1 = new System.Windows.Forms.ToolBarButton();
	this.refresh = new System.Windows.Forms.ToolBarButton();
	this.print = new System.Windows.Forms.ToolBarButton();
	this.sendToCms = new System.Windows.Forms.ToolBarButton();
	this.sep2 = new System.Windows.Forms.ToolBarButton();
	this.add = new System.Windows.Forms.ToolBarButton();
	this.stats = new System.Windows.Forms.ToolBarButton();
	this.shortage = new System.Windows.Forms.ToolBarButton();
	this.chVersion = new System.Windows.Forms.ToolBarButton();
	this.sep3 = new System.Windows.Forms.ToolBarButton();
	this.close = new System.Windows.Forms.ToolBarButton();
	this.imageList1 = new System.Windows.Forms.ImageList(this.components);
	this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
	this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
	this.currentDateTimePicker = new System.Windows.Forms.DateTimePicker();
	this.label4 = new System.Windows.Forms.Label();
	this.schView1Button = new System.Windows.Forms.Button();
	this.matRecButton = new System.Windows.Forms.Button();
	this.detailPanel = new System.Windows.Forms.Panel();
	this.matButton = new System.Windows.Forms.Button();
	this.txtMinQtyReq = new System.Windows.Forms.TextBox();
	this.txtSchQty = new System.Windows.Forms.TextBox();
	this.label13 = new System.Windows.Forms.Label();
	this.label12 = new System.Windows.Forms.Label();
	this.txtHrPr = new System.Windows.Forms.TextBox();
	this.txtRunStd = new System.Windows.Forms.TextBox();
	this.txtDrs = new System.Windows.Forms.TextBox();
	this.txtUtilPer = new System.Windows.Forms.TextBox();
	this.txtSeq = new System.Windows.Forms.TextBox();
	this.label11 = new System.Windows.Forms.Label();
	this.label10 = new System.Windows.Forms.Label();
	this.label9 = new System.Windows.Forms.Label();
	this.label8 = new System.Windows.Forms.Label();
	this.label6 = new System.Windows.Forms.Label();
	this.label5 = new System.Windows.Forms.Label();
	this.txtProdId = new System.Windows.Forms.TextBox();
	this.button1 = new System.Windows.Forms.Button();
	this.button2 = new System.Windows.Forms.Button();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.versionComboBox = new System.Windows.Forms.ComboBox();
	this.label7 = new System.Windows.Forms.Label();
	this.contextMenu1 = new System.Windows.Forms.ContextMenu();
	this.panelLeyends = new System.Windows.Forms.Panel();
	this.groupBoxTimeScope = new System.Windows.Forms.GroupBox();
	this.demandPanel = new System.Windows.Forms.Panel();
	this.qtyTextBox = new System.Windows.Forms.TextBox();
	this.label26 = new System.Windows.Forms.Label();
	this.custIDTextBox = new System.Windows.Forms.TextBox();
	this.nameTextBox = new System.Windows.Forms.TextBox();
	this.prodIDTextBox = new System.Windows.Forms.TextBox();
	this.seqTextBox = new System.Windows.Forms.TextBox();
	this.descriptionTextBox = new System.Windows.Forms.TextBox();
	this.dateReadyTextBox = new System.Windows.Forms.TextBox();
	this.dateShipTextBox = new System.Windows.Forms.TextBox();
	this.releaseIDTextBox = new System.Windows.Forms.TextBox();
	this.itemIDTextBox = new System.Windows.Forms.TextBox();
	this.orderIDTextBox = new System.Windows.Forms.TextBox();
	this.label25 = new System.Windows.Forms.Label();
	this.label24 = new System.Windows.Forms.Label();
	this.label23 = new System.Windows.Forms.Label();
	this.label22 = new System.Windows.Forms.Label();
	this.label21 = new System.Windows.Forms.Label();
	this.label20 = new System.Windows.Forms.Label();
	this.label18 = new System.Windows.Forms.Label();
	this.label19 = new System.Windows.Forms.Label();
	this.label17 = new System.Windows.Forms.Label();
	this.label16 = new System.Windows.Forms.Label();
	this.label15 = new System.Windows.Forms.Label();
	this.label14 = new System.Windows.Forms.Label();
	this.demandTitleLabel = new System.Windows.Forms.Label();
	this.demandCheckBox = new System.Windows.Forms.CheckBox();
	this.gridContextMenu = new System.Windows.Forms.ContextMenu();
	this.addMenuItem = new System.Windows.Forms.MenuItem();
	this.removeMenuItem = new System.Windows.Forms.MenuItem();
	this.sepMenuItem = new System.Windows.Forms.MenuItem();
	this.clearMenuItem = new System.Windows.Forms.MenuItem();
	this.fromDemandMenuItem = new System.Windows.Forms.MenuItem();
	this.save = new System.Windows.Forms.ToolBarButton();
	this.detailPanel.SuspendLayout();
	this.groupBox1.SuspendLayout();
	this.groupBoxTimeScope.SuspendLayout();
	this.demandPanel.SuspendLayout();
	this.SuspendLayout();
	// 
	// grid
	// 
	this.grid.AddMode = AGVBN20.Globals.E_ADDMODE.AT_GANTTITEMADD;
	this.grid.AllowAdd = true;
	this.grid.AllowEdit = true;
	this.grid.AllowFixedColumnSize = true;
	this.grid.AllowRowHeadingSize = true;
	this.grid.AllowRowHeadingSwap = true;
	this.grid.AllowRowSize = true;
	this.grid.AllowRowSwap = true;
	this.grid.AllowTimeLineScroll = true;
	this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.grid.AprilBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
	this.grid.AprilForeColor = System.Drawing.Color.Black;
	this.grid.AugustBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
	this.grid.AugustForeColor = System.Drawing.Color.Black;
	this.grid.AutomaticRedraw = true;
	this.grid.AutoScroll = true;
	this.grid.BorderStyle = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
	this.grid.ButtonStyle = AGVBN20.Globals.GRE_BUTTONSTYLE.BT_NORMALWINDOWS;
	this.grid.CurrentLayer = "0";
	this.grid.CurrentView = "";
	this.grid.DayFormat = "d ";
	this.grid.DayFormatZoom0 = "dddd d";
	this.grid.DayFormatZoom1 = "dddd d";
	this.grid.DayFormatZoom2 = "dddd d";
	this.grid.DayFormatZoom3 = "dddd d";
	this.grid.DayFormatZoom4 = "dddd d";
	this.grid.DayFormatZoom5 = "dddd d";
	this.grid.DayFormatZoom6 = "dddd d";
	this.grid.DayFormatZoom7 = "ddd d";
	this.grid.DayFormatZoom8 = "ddd d";
	this.grid.DayFormatZoom9 = "ddd d";
	this.grid.DecemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
	this.grid.DecemberForeColor = System.Drawing.Color.Black;
	this.grid.DetectConflicts = true;
	this.grid.DividerAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
	this.grid.EditMode = AGVBN20.Globals.E_EDITMODE.ET_GANTTMILESTONE;
	this.grid.EnableObjects = AGVBN20.Globals.E_ENABLEOBJECTS.EO_CURRENTLAYERONLY;
	this.grid.ErrorReports = AGVBN20.Globals.E_REPORTERRORS.RE_MSGBOX;
	this.grid.FebruaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
	this.grid.FebruaryForeColor = System.Drawing.Color.Black;
	this.grid.FirstVisibleRow = 1;
	this.grid.FixedColumnWidth = 125;
	this.grid.FridayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(95)), ((System.Byte)(109)), ((System.Byte)(231)));
	this.grid.FridayForeColor = System.Drawing.Color.Black;
	this.grid.GridInterval = "15n";
	this.grid.GridLinesColor = System.Drawing.SystemColors.Control;
	this.grid.HorizontalGridLinesVisible = true;
	this.grid.HorizontalScrollBarEnabled = false;
	this.grid.HorizontalScrollBarFactor = 60;
	this.grid.HorizontalScrollBarInterval = "n";
	this.grid.HorizontalScrollBarLargeChange = 10;
	this.grid.HorizontalScrollBarMax = 100;
	this.grid.HorizontalScrollBarSmallChange = 1;
	this.grid.HorizontalScrollBarStart = new System.DateTime(2004, 2, 25, 0, 0, 0, 0);
	this.grid.HorizontalScrollBarValue = 0;
	this.grid.JanuaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
	this.grid.JanuaryForeColor = System.Drawing.Color.Black;
	this.grid.JulyBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
	this.grid.JulyForeColor = System.Drawing.Color.Black;
	this.grid.JuneBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
	this.grid.JuneForeColor = System.Drawing.Color.Black;
	this.grid.Location = new System.Drawing.Point(8, 136);
	this.grid.LowerStripeFactor = 9;
	this.grid.LowerStripeFont = new System.Drawing.Font("Arial", 8F);
	this.grid.LowerStripeHeight = 18;
	this.grid.LowerStripeInterval = "h";
	this.grid.MarchBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
	this.grid.MarchForeColor = System.Drawing.Color.Black;
	this.grid.MayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
	this.grid.MayForeColor = System.Drawing.Color.Black;
	this.grid.MilestoneSelectionOffset = 5;
	this.grid.MinRowHeadingWidth = 5;
	this.grid.MinRowHeight = 5;
	this.grid.MondayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(114)), ((System.Byte)(115)), ((System.Byte)(191)));
	this.grid.MondayForeColor = System.Drawing.Color.Black;
	this.grid.MonthFormatZoom0 = "MMMM yyyy";
	this.grid.MonthFormatZoom1 = "MMMM yyyy";
	this.grid.MonthFormatZoom10 = "MMMM";
	this.grid.MonthFormatZoom11 = "MMMM";
	this.grid.MonthFormatZoom12 = "MMMM";
	this.grid.MonthFormatZoom13 = "MMM";
	this.grid.MonthFormatZoom14 = "MMM";
	this.grid.MonthFormatZoom2 = "MMMM yyyy";
	this.grid.MonthFormatZoom3 = "MMMM yyyy";
	this.grid.MonthFormatZoom4 = "MMMM yyyy";
	this.grid.MonthFormatZoom5 = "MMMM yyyy";
	this.grid.MonthFormatZoom6 = "MMMM yyyy";
	this.grid.MonthFormatZoom7 = "MMMM yyyy";
	this.grid.MonthFormatZoom8 = "MMMM yyyy";
	this.grid.MonthFormatZoom9 = "MMMM yyyy";
	this.grid.Name = "grid";
	this.grid.NonContainerRowBackColor = System.Drawing.SystemColors.Control;
	this.grid.NotchesAreaHeight = 23;
	this.grid.NotchFont = new System.Drawing.Font("Arial", 8F);
	this.grid.NotchTextOffset = 13;
	this.grid.NovemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
	this.grid.NovemberForeColor = System.Drawing.Color.Black;
	this.grid.OctoberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
	this.grid.OctoberForeColor = System.Drawing.Color.Black;
	this.grid.Quarter1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
	this.grid.Quarter1ForeColor = System.Drawing.Color.Black;
	this.grid.Quarter2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
	this.grid.Quarter2ForeColor = System.Drawing.Color.Black;
	this.grid.Quarter3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
	this.grid.Quarter3ForeColor = System.Drawing.Color.Black;
	this.grid.Quarter4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
	this.grid.Quarter4ForeColor = System.Drawing.Color.Black;
	this.grid.QuarterFormatZoom10 = "\'Q\' yyyy";
	this.grid.QuarterFormatZoom11 = "\'Q\' yyyy";
	this.grid.QuarterFormatZoom12 = "\'Q\' yyyy";
	this.grid.QuarterFormatZoom13 = "\'Q\' yyyy";
	this.grid.QuarterFormatZoom14 = "\'Q\' yyyy";
	this.grid.QuarterFormatZoom15 = "\'Q\'";
	this.grid.RowHeadingWidth = 125;
	this.grid.RowHeight = 40;
	this.grid.SaturdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(124)), ((System.Byte)(131)), ((System.Byte)(191)));
	this.grid.SaturdayForeColor = System.Drawing.Color.Black;
	this.grid.ScrollBarBehaviour = AGVBN20.Globals.E_SCROLLBEHAVIOUR.SB_HIDE;
	this.grid.ScrollBarsVisible = true;
	this.grid.SelectedGanttItemIndex = 0;
	this.grid.SelectedMilestoneIndex = 0;
	this.grid.SelectedRowHeadingIndex = 0;
	this.grid.SelectedRowIndex = 0;
	this.grid.SelectedRowValueIndex = 0;
	this.grid.SeptemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
	this.grid.SeptemberForeColor = System.Drawing.Color.Black;
	this.grid.ShowLowerStripe = true;
	this.grid.ShowTimeLineNotches = true;
	this.grid.ShowUpperStripe = true;
	this.grid.Size = new System.Drawing.Size(936, 472);
	this.grid.SnapToGrid = false;
	this.grid.SnapToGridWhenSelecting = true;
	this.grid.SundayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(147)), ((System.Byte)(145)), ((System.Byte)(250)));
	this.grid.SundayForeColor = System.Drawing.Color.Black;
	this.grid.TabIndex = 2;
	this.grid.ThursdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(64)), ((System.Byte)(164)));
	this.grid.ThursdayForeColor = System.Drawing.Color.White;
	this.grid.TimeBlockBehaviour = AGVBN20.Globals.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS;
	this.grid.TimeFormat = "h:mm tt";
	this.grid.TimeLineAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
	this.grid.TimeLineBackColor = System.Drawing.SystemColors.Control;
	this.grid.TimeLineForeColor = System.Drawing.Color.Black;
	this.grid.TimeLineMarkerColor = System.Drawing.Color.Red;
	this.grid.TimeLineMarkerDate = new System.DateTime(2004, 4, 2, 18, 56, 22, 320);
	this.grid.TimeLineMarkerLength = AGVBN20.Globals.E_TIMELINEMARKERLENGTH.TLMA_NOTCHAREA;
	this.grid.TimeLineMarkerType = AGVBN20.Globals.E_TIMELINEMARKERTYPE.TLMT_SYSTEMTIME;
	this.grid.TimeLineStyleIndex = "0";
	this.grid.ToolTipFormatZoom0To9 = "h:mm:ss tt";
	this.grid.ToolTipFormatZoom10To15 = "M/d/yy h:mm tt";
	this.grid.ToolTipsVisible = true;
	this.grid.TrimTimeFormat = true;
	this.grid.TuesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(140)));
	this.grid.TuesdayForeColor = System.Drawing.Color.White;
	this.grid.UpperStripeFactor = 0;
	this.grid.UpperStripeFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.grid.UpperStripeHeight = 14;
	this.grid.UpperStripeInterval = "";
	this.grid.UseViews = false;
	this.grid.VerticalGridLinesVisible = true;
	this.grid.WednesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(104)), ((System.Byte)(109)), ((System.Byte)(152)));
	this.grid.WednesdayForeColor = System.Drawing.Color.White;
	this.grid.Year0BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
	this.grid.Year0ForeColor = System.Drawing.Color.Black;
	this.grid.Year1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
	this.grid.Year1ForeColor = System.Drawing.Color.Black;
	this.grid.Year2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
	this.grid.Year2ForeColor = System.Drawing.Color.Black;
	this.grid.Year3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
	this.grid.Year3ForeColor = System.Drawing.Color.Black;
	this.grid.Year4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
	this.grid.Year4ForeColor = System.Drawing.Color.Black;
	this.grid.Year5BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
	this.grid.Year5ForeColor = System.Drawing.Color.Black;
	this.grid.Year6BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
	this.grid.Year6ForeColor = System.Drawing.Color.Black;
	this.grid.Year7BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
	this.grid.Year7ForeColor = System.Drawing.Color.Black;
	this.grid.Year8BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
	this.grid.Year8ForeColor = System.Drawing.Color.Black;
	this.grid.Year9BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
	this.grid.Year9ForeColor = System.Drawing.Color.Black;
	this.grid.YearFormatZoom15 = "yyyy";
	this.grid.ZoomFactor = 5;
	this.grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grid_MouseUp);
	this.grid.GanttItemDblClick += new AGVBN20.ActiveGanttVBNCtl.GanttItemDblClickEventHandler(this.grid_GanttItemDblClick);
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(16, 64);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(68, 20);
	this.label1.TabIndex = 14;
	this.label1.Text = "Plant:";
	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	// 
	// plantComboBox
	// 
	this.plantComboBox.Location = new System.Drawing.Point(88, 64);
	this.plantComboBox.Name = "plantComboBox";
	this.plantComboBox.Size = new System.Drawing.Size(152, 21);
	this.plantComboBox.TabIndex = 15;
	this.plantComboBox.SelectedValueChanged += new System.EventHandler(this.plantComboBox_SelectedValueChanged);
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(200, 24);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(24, 20);
	this.label2.TabIndex = 21;
	this.label2.Text = "To:";
	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(24, 24);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(36, 20);
	this.label3.TabIndex = 22;
	this.label3.Text = "From:";
	this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// toolBar1
	// 
	this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
	this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																				this.expand,
																				this.reduce,
																				this.sep1,
																				this.refresh,
																				this.print,
																				this.sendToCms,
																				this.sep2,
																				this.add,
																				this.stats,
																				this.shortage,
																				this.chVersion,
																				this.sep3,
																				this.save,
																				this.close});
	this.toolBar1.ButtonSize = new System.Drawing.Size(24, 24);
	this.toolBar1.DropDownArrows = true;
	this.toolBar1.ImageList = this.imageList1;
	this.toolBar1.Location = new System.Drawing.Point(0, 0);
	this.toolBar1.Name = "toolBar1";
	this.toolBar1.ShowToolTips = true;
	this.toolBar1.Size = new System.Drawing.Size(952, 36);
	this.toolBar1.TabIndex = 25;
	this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
	// 
	// expand
	// 
	this.expand.ImageIndex = 0;
	this.expand.Tag = "expand";
	this.expand.ToolTipText = "Expand chart";
	// 
	// reduce
	// 
	this.reduce.ImageIndex = 1;
	this.reduce.Tag = "reduce";
	this.reduce.ToolTipText = "Reduce chart";
	// 
	// sep1
	// 
	this.sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
	// 
	// refresh
	// 
	this.refresh.ImageIndex = 2;
	this.refresh.Tag = "refresh";
	this.refresh.ToolTipText = "Refresh chart";
	// 
	// print
	// 
	this.print.ImageIndex = 3;
	this.print.Tag = "print";
	this.print.ToolTipText = "Print Report";
	// 
	// sendToCms
	// 
	this.sendToCms.ImageIndex = 4;
	this.sendToCms.Tag = "sendToCms";
	this.sendToCms.ToolTipText = "Send to CMS";
	// 
	// sep2
	// 
	this.sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
	// 
	// add
	// 
	this.add.ImageIndex = 5;
	this.add.Tag = "add";
	this.add.ToolTipText = "Add";
	// 
	// stats
	// 
	this.stats.ImageIndex = 6;
	this.stats.Tag = "stats";
	this.stats.ToolTipText = "Review Machine stats";
	// 
	// shortage
	// 
	this.shortage.ImageIndex = 7;
	this.shortage.Tag = "shortage";
	this.shortage.ToolTipText = "Review Shortage List";
	// 
	// chVersion
	// 
	this.chVersion.ImageIndex = 8;
	this.chVersion.Tag = "chVersion";
	this.chVersion.ToolTipText = "New Version";
	// 
	// sep3
	// 
	this.sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
	// 
	// close
	// 
	this.close.ImageIndex = 9;
	this.close.Tag = "close";
	this.close.ToolTipText = "Exit";
	// 
	// imageList1
	// 
	this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
	this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
	this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
	this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
	// 
	// fromDateTimePicker
	// 
	this.fromDateTimePicker.Location = new System.Drawing.Point(64, 24);
	this.fromDateTimePicker.Name = "fromDateTimePicker";
	this.fromDateTimePicker.Size = new System.Drawing.Size(136, 20);
	this.fromDateTimePicker.TabIndex = 26;
	this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.fromDateTimePicker_ValueChanged);
	// 
	// toDateTimePicker
	// 
	this.toDateTimePicker.Location = new System.Drawing.Point(224, 24);
	this.toDateTimePicker.Name = "toDateTimePicker";
	this.toDateTimePicker.Size = new System.Drawing.Size(136, 20);
	this.toDateTimePicker.TabIndex = 27;
	this.toDateTimePicker.ValueChanged += new System.EventHandler(this.toDateTimePicker_ValueChanged);
	// 
	// currentDateTimePicker
	// 
	this.currentDateTimePicker.Location = new System.Drawing.Point(152, 56);
	this.currentDateTimePicker.Name = "currentDateTimePicker";
	this.currentDateTimePicker.Size = new System.Drawing.Size(136, 20);
	this.currentDateTimePicker.TabIndex = 28;
	this.currentDateTimePicker.Leave += new System.EventHandler(this.currentDateTimePicker_Leave);
	this.currentDateTimePicker.ValueChanged += new System.EventHandler(this.currentDateTimePicker_ValueChanged);
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(116, 56);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(32, 20);
	this.label4.TabIndex = 29;
	this.label4.Text = "View:";
	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// schView1Button
	// 
	this.schView1Button.Location = new System.Drawing.Point(456, 8);
	this.schView1Button.Name = "schView1Button";
	this.schView1Button.Size = new System.Drawing.Size(120, 23);
	this.schView1Button.TabIndex = 30;
	this.schView1Button.Text = "Alternate View";
	this.schView1Button.Visible = false;
	this.schView1Button.Click += new System.EventHandler(this.schView1Button_Click);
	// 
	// matRecButton
	// 
	this.matRecButton.Location = new System.Drawing.Point(576, 8);
	this.matRecButton.Name = "matRecButton";
	this.matRecButton.Size = new System.Drawing.Size(120, 23);
	this.matRecButton.TabIndex = 31;
	this.matRecButton.Text = " Material Recs";
	this.matRecButton.Visible = false;
	this.matRecButton.Click += new System.EventHandler(this.matRecButton_Click);
	// 
	// detailPanel
	// 
	this.detailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.detailPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.detailPanel.Controls.Add(this.matButton);
	this.detailPanel.Controls.Add(this.txtMinQtyReq);
	this.detailPanel.Controls.Add(this.txtSchQty);
	this.detailPanel.Controls.Add(this.label13);
	this.detailPanel.Controls.Add(this.label12);
	this.detailPanel.Controls.Add(this.txtHrPr);
	this.detailPanel.Controls.Add(this.txtRunStd);
	this.detailPanel.Controls.Add(this.txtDrs);
	this.detailPanel.Controls.Add(this.txtUtilPer);
	this.detailPanel.Controls.Add(this.txtSeq);
	this.detailPanel.Controls.Add(this.label11);
	this.detailPanel.Controls.Add(this.label10);
	this.detailPanel.Controls.Add(this.label9);
	this.detailPanel.Controls.Add(this.label8);
	this.detailPanel.Controls.Add(this.label6);
	this.detailPanel.Controls.Add(this.label5);
	this.detailPanel.Controls.Add(this.txtProdId);
	this.detailPanel.Location = new System.Drawing.Point(8, 536);
	this.detailPanel.Name = "detailPanel";
	this.detailPanel.Size = new System.Drawing.Size(936, 120);
	this.detailPanel.TabIndex = 32;
	this.detailPanel.Visible = false;
	// 
	// matButton
	// 
	this.matButton.Location = new System.Drawing.Point(832, 80);
	this.matButton.Name = "matButton";
	this.matButton.Size = new System.Drawing.Size(96, 24);
	this.matButton.TabIndex = 18;
	this.matButton.Text = "Materials";
	this.matButton.Click += new System.EventHandler(this.matButton_Click);
	// 
	// txtMinQtyReq
	// 
	this.txtMinQtyReq.Enabled = false;
	this.txtMinQtyReq.Location = new System.Drawing.Point(712, 16);
	this.txtMinQtyReq.Name = "txtMinQtyReq";
	this.txtMinQtyReq.Size = new System.Drawing.Size(184, 20);
	this.txtMinQtyReq.TabIndex = 17;
	this.txtMinQtyReq.Text = "MinQtyReq";
	// 
	// txtSchQty
	// 
	this.txtSchQty.Enabled = false;
	this.txtSchQty.Location = new System.Drawing.Point(712, 48);
	this.txtSchQty.Name = "txtSchQty";
	this.txtSchQty.Size = new System.Drawing.Size(184, 20);
	this.txtSchQty.TabIndex = 16;
	this.txtSchQty.Text = "SchQty";
	// 
	// label13
	// 
	this.label13.Location = new System.Drawing.Point(640, 16);
	this.label13.Name = "label13";
	this.label13.Size = new System.Drawing.Size(72, 16);
	this.label13.TabIndex = 15;
	this.label13.Text = "Min Qty Req:";
	// 
	// label12
	// 
	this.label12.Location = new System.Drawing.Point(640, 48);
	this.label12.Name = "label12";
	this.label12.Size = new System.Drawing.Size(56, 16);
	this.label12.TabIndex = 14;
	this.label12.Text = "Sch Qty:";
	// 
	// txtHrPr
	// 
	this.txtHrPr.Enabled = false;
	this.txtHrPr.Location = new System.Drawing.Point(400, 72);
	this.txtHrPr.Name = "txtHrPr";
	this.txtHrPr.Size = new System.Drawing.Size(184, 20);
	this.txtHrPr.TabIndex = 13;
	this.txtHrPr.Text = "Hr Pr";
	// 
	// txtRunStd
	// 
	this.txtRunStd.Enabled = false;
	this.txtRunStd.Location = new System.Drawing.Point(400, 40);
	this.txtRunStd.Name = "txtRunStd";
	this.txtRunStd.Size = new System.Drawing.Size(184, 20);
	this.txtRunStd.TabIndex = 12;
	this.txtRunStd.Text = "Run Std";
	// 
	// txtDrs
	// 
	this.txtDrs.Enabled = false;
	this.txtDrs.Location = new System.Drawing.Point(400, 8);
	this.txtDrs.Name = "txtDrs";
	this.txtDrs.Size = new System.Drawing.Size(184, 20);
	this.txtDrs.TabIndex = 10;
	this.txtDrs.Text = "Drs";
	// 
	// txtUtilPer
	// 
	this.txtUtilPer.Enabled = false;
	this.txtUtilPer.Location = new System.Drawing.Point(80, 80);
	this.txtUtilPer.Name = "txtUtilPer";
	this.txtUtilPer.Size = new System.Drawing.Size(184, 20);
	this.txtUtilPer.TabIndex = 9;
	this.txtUtilPer.Text = "Util Per";
	// 
	// txtSeq
	// 
	this.txtSeq.Enabled = false;
	this.txtSeq.Location = new System.Drawing.Point(80, 40);
	this.txtSeq.Name = "txtSeq";
	this.txtSeq.Size = new System.Drawing.Size(184, 20);
	this.txtSeq.TabIndex = 8;
	this.txtSeq.Text = "Seq";
	// 
	// label11
	// 
	this.label11.Location = new System.Drawing.Point(336, 72);
	this.label11.Name = "label11";
	this.label11.Size = new System.Drawing.Size(56, 16);
	this.label11.TabIndex = 7;
	this.label11.Text = "Hrs. Req: ";
	// 
	// label10
	// 
	this.label10.Location = new System.Drawing.Point(336, 40);
	this.label10.Name = "label10";
	this.label10.Size = new System.Drawing.Size(56, 16);
	this.label10.TabIndex = 6;
	this.label10.Text = "Pcs Hr:";
	// 
	// label9
	// 
	this.label9.Location = new System.Drawing.Point(16, 80);
	this.label9.Name = "label9";
	this.label9.Size = new System.Drawing.Size(56, 16);
	this.label9.TabIndex = 5;
	this.label9.Text = "Util factor:";
	// 
	// label8
	// 
	this.label8.Location = new System.Drawing.Point(328, 8);
	this.label8.Name = "label8";
	this.label8.Size = new System.Drawing.Size(64, 16);
	this.label8.TabIndex = 4;
	this.label8.Text = "Oper Type:";
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(16, 48);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(56, 16);
	this.label6.TabIndex = 2;
	this.label6.Text = "Seq:";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(16, 16);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(56, 16);
	this.label5.TabIndex = 1;
	this.label5.Text = "Prod Id: ";
	// 
	// txtProdId
	// 
	this.txtProdId.Enabled = false;
	this.txtProdId.Location = new System.Drawing.Point(80, 8);
	this.txtProdId.Name = "txtProdId";
	this.txtProdId.Size = new System.Drawing.Size(184, 20);
	this.txtProdId.TabIndex = 0;
	this.txtProdId.Text = "ProdId";
	// 
	// button1
	// 
	this.button1.Location = new System.Drawing.Point(32, 24);
	this.button1.Name = "button1";
	this.button1.Size = new System.Drawing.Size(120, 23);
	this.button1.TabIndex = 33;
	this.button1.Text = "View 1";
	this.button1.Visible = false;
	this.button1.Click += new System.EventHandler(this.button1_Click);
	// 
	// button2
	// 
	this.button2.Location = new System.Drawing.Point(32, 56);
	this.button2.Name = "button2";
	this.button2.Size = new System.Drawing.Size(120, 23);
	this.button2.TabIndex = 34;
	this.button2.Text = "View 2";
	this.button2.Visible = false;
	this.button2.Click += new System.EventHandler(this.button2_Click);
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.button2);
	this.groupBox1.Controls.Add(this.button1);
	this.groupBox1.Location = new System.Drawing.Point(792, 24);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(176, 96);
	this.groupBox1.TabIndex = 36;
	this.groupBox1.TabStop = false;
	this.groupBox1.Text = "Colour Scheduling";
	this.groupBox1.Visible = false;
	// 
	// versionComboBox
	// 
	this.versionComboBox.Location = new System.Drawing.Point(88, 88);
	this.versionComboBox.Name = "versionComboBox";
	this.versionComboBox.Size = new System.Drawing.Size(152, 21);
	this.versionComboBox.TabIndex = 37;
	this.versionComboBox.SelectedValueChanged += new System.EventHandler(this.versionComboBox_SelectedValueChanged);
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(16, 88);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(68, 20);
	this.label7.TabIndex = 38;
	this.label7.Text = "Version:";
	this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	// 
	// panelLeyends
	// 
	this.panelLeyends.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	this.panelLeyends.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.panelLeyends.Location = new System.Drawing.Point(8, 624);
	this.panelLeyends.Name = "panelLeyends";
	this.panelLeyends.Size = new System.Drawing.Size(56, 32);
	this.panelLeyends.TabIndex = 39;
	this.panelLeyends.Visible = false;
	// 
	// groupBoxTimeScope
	// 
	this.groupBoxTimeScope.Controls.Add(this.fromDateTimePicker);
	this.groupBoxTimeScope.Controls.Add(this.toDateTimePicker);
	this.groupBoxTimeScope.Controls.Add(this.currentDateTimePicker);
	this.groupBoxTimeScope.Controls.Add(this.label4);
	this.groupBoxTimeScope.Controls.Add(this.label2);
	this.groupBoxTimeScope.Controls.Add(this.label3);
	this.groupBoxTimeScope.Location = new System.Drawing.Point(256, 40);
	this.groupBoxTimeScope.Name = "groupBoxTimeScope";
	this.groupBoxTimeScope.Size = new System.Drawing.Size(384, 88);
	this.groupBoxTimeScope.TabIndex = 40;
	this.groupBoxTimeScope.TabStop = false;
	this.groupBoxTimeScope.Text = "Time Scope";
	// 
	// demandPanel
	// 
	this.demandPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.demandPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.demandPanel.Controls.Add(this.qtyTextBox);
	this.demandPanel.Controls.Add(this.label26);
	this.demandPanel.Controls.Add(this.custIDTextBox);
	this.demandPanel.Controls.Add(this.nameTextBox);
	this.demandPanel.Controls.Add(this.prodIDTextBox);
	this.demandPanel.Controls.Add(this.seqTextBox);
	this.demandPanel.Controls.Add(this.descriptionTextBox);
	this.demandPanel.Controls.Add(this.dateReadyTextBox);
	this.demandPanel.Controls.Add(this.dateShipTextBox);
	this.demandPanel.Controls.Add(this.releaseIDTextBox);
	this.demandPanel.Controls.Add(this.itemIDTextBox);
	this.demandPanel.Controls.Add(this.orderIDTextBox);
	this.demandPanel.Controls.Add(this.label25);
	this.demandPanel.Controls.Add(this.label24);
	this.demandPanel.Controls.Add(this.label23);
	this.demandPanel.Controls.Add(this.label22);
	this.demandPanel.Controls.Add(this.label21);
	this.demandPanel.Controls.Add(this.label20);
	this.demandPanel.Controls.Add(this.label18);
	this.demandPanel.Controls.Add(this.label19);
	this.demandPanel.Controls.Add(this.label17);
	this.demandPanel.Controls.Add(this.label16);
	this.demandPanel.Controls.Add(this.label15);
	this.demandPanel.Controls.Add(this.label14);
	this.demandPanel.Controls.Add(this.demandTitleLabel);
	this.demandPanel.Location = new System.Drawing.Point(8, 536);
	this.demandPanel.Name = "demandPanel";
	this.demandPanel.Size = new System.Drawing.Size(936, 120);
	this.demandPanel.TabIndex = 33;
	this.demandPanel.Visible = false;
	// 
	// qtyTextBox
	// 
	this.qtyTextBox.Location = new System.Drawing.Point(336, 80);
	this.qtyTextBox.Name = "qtyTextBox";
	this.qtyTextBox.ReadOnly = true;
	this.qtyTextBox.Size = new System.Drawing.Size(160, 20);
	this.qtyTextBox.TabIndex = 24;
	this.qtyTextBox.Text = "";
	// 
	// label26
	// 
	this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
	this.label26.Location = new System.Drawing.Point(264, 80);
	this.label26.Name = "label26";
	this.label26.Size = new System.Drawing.Size(72, 20);
	this.label26.TabIndex = 23;
	this.label26.Text = "Qty:";
	this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// custIDTextBox
	// 
	this.custIDTextBox.Location = new System.Drawing.Point(808, 32);
	this.custIDTextBox.Name = "custIDTextBox";
	this.custIDTextBox.ReadOnly = true;
	this.custIDTextBox.Size = new System.Drawing.Size(160, 20);
	this.custIDTextBox.TabIndex = 22;
	this.custIDTextBox.Text = "";
	// 
	// nameTextBox
	// 
	this.nameTextBox.Location = new System.Drawing.Point(808, 56);
	this.nameTextBox.Name = "nameTextBox";
	this.nameTextBox.ReadOnly = true;
	this.nameTextBox.Size = new System.Drawing.Size(160, 20);
	this.nameTextBox.TabIndex = 21;
	this.nameTextBox.Text = "";
	// 
	// prodIDTextBox
	// 
	this.prodIDTextBox.Location = new System.Drawing.Point(584, 32);
	this.prodIDTextBox.Name = "prodIDTextBox";
	this.prodIDTextBox.ReadOnly = true;
	this.prodIDTextBox.Size = new System.Drawing.Size(160, 20);
	this.prodIDTextBox.TabIndex = 20;
	this.prodIDTextBox.Text = "";
	// 
	// seqTextBox
	// 
	this.seqTextBox.Location = new System.Drawing.Point(584, 56);
	this.seqTextBox.Name = "seqTextBox";
	this.seqTextBox.ReadOnly = true;
	this.seqTextBox.Size = new System.Drawing.Size(160, 20);
	this.seqTextBox.TabIndex = 19;
	this.seqTextBox.Text = "";
	// 
	// descriptionTextBox
	// 
	this.descriptionTextBox.Location = new System.Drawing.Point(584, 80);
	this.descriptionTextBox.Name = "descriptionTextBox";
	this.descriptionTextBox.ReadOnly = true;
	this.descriptionTextBox.Size = new System.Drawing.Size(160, 20);
	this.descriptionTextBox.TabIndex = 18;
	this.descriptionTextBox.Text = "";
	// 
	// dateReadyTextBox
	// 
	this.dateReadyTextBox.Location = new System.Drawing.Point(336, 56);
	this.dateReadyTextBox.Name = "dateReadyTextBox";
	this.dateReadyTextBox.ReadOnly = true;
	this.dateReadyTextBox.Size = new System.Drawing.Size(160, 20);
	this.dateReadyTextBox.TabIndex = 17;
	this.dateReadyTextBox.Text = "";
	// 
	// dateShipTextBox
	// 
	this.dateShipTextBox.Location = new System.Drawing.Point(336, 32);
	this.dateShipTextBox.Name = "dateShipTextBox";
	this.dateShipTextBox.ReadOnly = true;
	this.dateShipTextBox.Size = new System.Drawing.Size(160, 20);
	this.dateShipTextBox.TabIndex = 16;
	this.dateShipTextBox.Text = "";
	// 
	// releaseIDTextBox
	// 
	this.releaseIDTextBox.Location = new System.Drawing.Point(80, 80);
	this.releaseIDTextBox.Name = "releaseIDTextBox";
	this.releaseIDTextBox.ReadOnly = true;
	this.releaseIDTextBox.Size = new System.Drawing.Size(160, 20);
	this.releaseIDTextBox.TabIndex = 15;
	this.releaseIDTextBox.Text = "";
	// 
	// itemIDTextBox
	// 
	this.itemIDTextBox.Location = new System.Drawing.Point(80, 56);
	this.itemIDTextBox.Name = "itemIDTextBox";
	this.itemIDTextBox.ReadOnly = true;
	this.itemIDTextBox.Size = new System.Drawing.Size(160, 20);
	this.itemIDTextBox.TabIndex = 14;
	this.itemIDTextBox.Text = "";
	// 
	// orderIDTextBox
	// 
	this.orderIDTextBox.Location = new System.Drawing.Point(80, 32);
	this.orderIDTextBox.Name = "orderIDTextBox";
	this.orderIDTextBox.ReadOnly = true;
	this.orderIDTextBox.Size = new System.Drawing.Size(160, 20);
	this.orderIDTextBox.TabIndex = 13;
	this.orderIDTextBox.Text = "";
	// 
	// label25
	// 
	this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
	this.label25.Location = new System.Drawing.Point(264, 56);
	this.label25.Name = "label25";
	this.label25.Size = new System.Drawing.Size(72, 20);
	this.label25.TabIndex = 12;
	this.label25.Text = "Date Ready:";
	this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label24
	// 
	this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
	this.label24.Location = new System.Drawing.Point(264, 32);
	this.label24.Name = "label24";
	this.label24.Size = new System.Drawing.Size(72, 20);
	this.label24.TabIndex = 11;
	this.label24.Text = "Date Ship:";
	this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label23
	// 
	this.label23.Location = new System.Drawing.Point(520, 80);
	this.label23.Name = "label23";
	this.label23.Size = new System.Drawing.Size(72, 20);
	this.label23.TabIndex = 10;
	this.label23.Text = "Description:";
	this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label22
	// 
	this.label22.Location = new System.Drawing.Point(520, 56);
	this.label22.Name = "label22";
	this.label22.Size = new System.Drawing.Size(72, 20);
	this.label22.TabIndex = 9;
	this.label22.Text = "Seq:";
	this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label21
	// 
	this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
	this.label21.Location = new System.Drawing.Point(520, 32);
	this.label21.Name = "label21";
	this.label21.Size = new System.Drawing.Size(72, 20);
	this.label21.TabIndex = 8;
	this.label21.Text = "ID:";
	this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label20
	// 
	this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label20.Location = new System.Drawing.Point(520, 8);
	this.label20.Name = "label20";
	this.label20.Size = new System.Drawing.Size(72, 20);
	this.label20.TabIndex = 7;
	this.label20.Text = "Product";
	this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label18
	// 
	this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
	this.label18.Location = new System.Drawing.Point(768, 32);
	this.label18.Name = "label18";
	this.label18.Size = new System.Drawing.Size(72, 20);
	this.label18.TabIndex = 6;
	this.label18.Text = "ID:";
	this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label19
	// 
	this.label19.Location = new System.Drawing.Point(768, 56);
	this.label19.Name = "label19";
	this.label19.Size = new System.Drawing.Size(72, 20);
	this.label19.TabIndex = 5;
	this.label19.Text = "Name:";
	this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label17
	// 
	this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label17.Location = new System.Drawing.Point(768, 8);
	this.label17.Name = "label17";
	this.label17.Size = new System.Drawing.Size(72, 20);
	this.label17.TabIndex = 4;
	this.label17.Text = "Customer";
	this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label16
	// 
	this.label16.Location = new System.Drawing.Point(16, 80);
	this.label16.Name = "label16";
	this.label16.Size = new System.Drawing.Size(72, 20);
	this.label16.TabIndex = 3;
	this.label16.Text = "Release ID:";
	this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label15
	// 
	this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
	this.label15.Location = new System.Drawing.Point(16, 32);
	this.label15.Name = "label15";
	this.label15.Size = new System.Drawing.Size(72, 20);
	this.label15.TabIndex = 2;
	this.label15.Text = "Order ID:";
	this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label14
	// 
	this.label14.Location = new System.Drawing.Point(16, 56);
	this.label14.Name = "label14";
	this.label14.Size = new System.Drawing.Size(72, 20);
	this.label14.TabIndex = 1;
	this.label14.Text = "Item ID:";
	this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// demandTitleLabel
	// 
	this.demandTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.demandTitleLabel.Location = new System.Drawing.Point(16, 8);
	this.demandTitleLabel.Name = "demandTitleLabel";
	this.demandTitleLabel.Size = new System.Drawing.Size(72, 20);
	this.demandTitleLabel.TabIndex = 0;
	this.demandTitleLabel.Text = "Demand";
	this.demandTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// demandCheckBox
	// 
	this.demandCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.demandCheckBox.Checked = true;
	this.demandCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
	this.demandCheckBox.Location = new System.Drawing.Point(808, 616);
	this.demandCheckBox.Name = "demandCheckBox";
	this.demandCheckBox.Size = new System.Drawing.Size(144, 24);
	this.demandCheckBox.TabIndex = 41;
	this.demandCheckBox.Text = "Enable demand popup";
	// 
	// gridContextMenu
	// 
	this.gridContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.addMenuItem,
																					this.removeMenuItem,
																					this.sepMenuItem,
																					this.clearMenuItem,
																					this.fromDemandMenuItem});
	// 
	// addMenuItem
	// 
	this.addMenuItem.Enabled = false;
	this.addMenuItem.Index = 0;
	this.addMenuItem.Text = "Add";
	this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
	// 
	// removeMenuItem
	// 
	this.removeMenuItem.Enabled = false;
	this.removeMenuItem.Index = 1;
	this.removeMenuItem.Text = "Remove";
	this.removeMenuItem.Click += new System.EventHandler(this.removeMenuItem_Click);
	// 
	// sepMenuItem
	// 
	this.sepMenuItem.Index = 2;
	this.sepMenuItem.Text = "-";
	// 
	// clearMenuItem
	// 
	this.clearMenuItem.Index = 3;
	this.clearMenuItem.Text = "Clear";
	this.clearMenuItem.Click += new System.EventHandler(this.clearMenuItem_Click);
	// 
	// fromDemandMenuItem
	// 
	this.fromDemandMenuItem.Index = 4;
	this.fromDemandMenuItem.Text = "From Demand";
	this.fromDemandMenuItem.Click += new System.EventHandler(this.fromDemandMenuItem_Click);
	// 
	// save
	// 
	this.save.ImageIndex = 11;
	this.save.Tag = "save";
	this.save.ToolTipText = "Save";
	// 
	// GridForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(952, 661);
	this.Controls.Add(this.demandCheckBox);
	this.Controls.Add(this.panelLeyends);
	this.Controls.Add(this.label7);
	this.Controls.Add(this.versionComboBox);
	this.Controls.Add(this.groupBox1);
	this.Controls.Add(this.matRecButton);
	this.Controls.Add(this.schView1Button);
	this.Controls.Add(this.toolBar1);
	this.Controls.Add(this.plantComboBox);
	this.Controls.Add(this.label1);
	this.Controls.Add(this.grid);
	this.Controls.Add(this.groupBoxTimeScope);
	this.Controls.Add(this.demandPanel);
	this.Controls.Add(this.detailPanel);
	this.Name = "GridForm";
	this.Text = "Grid Scheduling";
	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
	this.Load += new System.EventHandler(this.GridForm_Load);
	this.Closed += new System.EventHandler(this.OnClosed);
	this.detailPanel.ResumeLayout(false);
	this.groupBox1.ResumeLayout(false);
	this.groupBoxTimeScope.ResumeLayout(false);
	this.demandPanel.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private 
void GridForm_Load(object sender, System.EventArgs e){

	model = new ScheduleModel();

	today = DateTime.Today;
	dtStart = today.AddDays(-2);
	dtEnd = today.AddDays(10);

	fromDateTimePicker.Value = today.AddDays(-2);
	currentDateTimePicker.Value = today;
	toDateTimePicker.Value = today.AddDays(10);
	
	core = UtilCoreFactory.createCoreFactory();

	string[] plants = core.getPlantCodes();
	for(int i = 0; i < plants.Length; i++)
		plantComboBox.Items.Add(plants[i]);

	plantComboBox.Sorted = true;

	plantComboBox.SelectedIndex = -1;
	
	grid.SaturdayBackColor = Color.Beige;
	grid.SundayBackColor = Color.Beige;

	grid.PositionTimeLine(dtStart);

	grid.HorizontalScrollBarEnabled = true;

	setGanttTimeScope();

	grid.AllowRowHeadingSwap = false;
	grid.AllowRowSwap = false;
	grid.AllowTimeLineScroll = false;
	grid.AllowDrop = false;
	grid.AllowAdd = false;
	grid.AllowEdit = false;
	grid.AllowFixedColumnSize = false;
	grid.AllowRowSize = false;
}

public void setGanttTimeScope()
{
	today = currentDateTimePicker.Value.Date;
	dtStart = fromDateTimePicker.Value.Date;
	dtEnd = toDateTimePicker.Value.Date;

	grid.HorizontalScrollBarStart = dtStart;
	grid.HorizontalScrollBarFactor = 1;
	grid.HorizontalScrollBarInterval = "h";
	grid.HorizontalScrollBarLargeChange = 10;
	grid.HorizontalScrollBarMax = (int)dtEnd.Subtract(dtStart).TotalHours;
	grid.HorizontalScrollBarValue = (int)today.Subtract(dtStart).TotalHours;
}

private
void setIconsToolBar(){
	toolBar1.ImageList = this.imageList1;
}

private
void setGridStyles(){

	grid.Styles.Clear();
	
	grid.Styles.Add("blank");
	clsStyle blankStyle = grid.Styles.get_Item(grid.Styles.Count.ToString());
	blankStyle.BackColor = System.Drawing.Color.White;
	blankStyle.ForeColor = System.Drawing.Color.Black;

	grid.Styles.Add("defaultStyleItem");
	clsStyle style = grid.Styles.get_Item(grid.Styles.Count.ToString());
	style.SelectionRectangleVisible = false;
	style.BackColor = System.Drawing.Color.Aquamarine; // default style

	grid.Styles.Add("selectedStyleItem");
	style = grid.Styles.get_Item(grid.Styles.Count.ToString());
	style.SelectionRectangleVisible = false;
	style.BackColor = System.Drawing.Color.Firebrick; // selected style

	grid.Styles.Add("RowMachine");
	grid.Styles.get_Item("RowMachine").CaptionXMargin = 5;
	grid.Styles.get_Item("RowMachine").Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

	grid.Styles.Add("RowTask");
	grid.Styles.get_Item("RowTask").CaptionXMargin = 25;
	grid.Styles.get_Item("RowTask").Font = new Font("Microsoft Sans Serif", 8);
	grid.Styles.get_Item("RowTask").BackColor = Color.White;
	grid.Styles.get_Item("RowTask").BorderColor = grid.GridLinesColor;
	grid.Styles.get_Item("RowTask").Font = new Font("Microsoft Sans Serif", 7, FontStyle.Regular);

	grid.Styles.Add("RowHeadings");
	grid.Styles.get_Item("RowHeadings").CaptionYMargin = 5;
	grid.Styles.get_Item("RowHeadings").Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

	grid.Styles.Add("RowCapacity");
	grid.Styles.get_Item("RowCapacity").Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

	grid.Styles.Add("RowDepartment");
	grid.Styles.get_Item("RowDepartment").Appearance = Globals.E_STYLEAPPEARANCE.SA_FLAT;
	grid.Styles.get_Item("RowDepartment").BorderStyle = Globals.E_STYLEBORDER.SBR_NONE;
	grid.Styles.get_Item("RowDepartment").BorderColor = Color.Black;
	grid.Styles.get_Item("RowDepartment").BackColor = Color.Black;
	grid.Styles.get_Item("RowDepartment").ForeColor = Color.White;
	grid.Styles.get_Item("RowDepartment").Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

	setTimeTypeStyles();
}

private void setTimeTypeStyles(){
	TimeCode[] timeCodes = Nujit.NujitERP.WinForms.CapacityModule.TimeCodes.getInstance().getMachinesCodes();

	System.Drawing.Color[] colorArray = new System.Drawing.Color[10];
	colorArray[0] = System.Drawing.Color.Red;
	colorArray[1] = System.Drawing.Color.Blue;
	colorArray[2] = System.Drawing.Color.Green;
	colorArray[3] = System.Drawing.Color.Yellow;
	colorArray[4] = System.Drawing.Color.Beige;
	colorArray[5] = System.Drawing.Color.Brown;
	colorArray[6] = System.Drawing.Color.Coral;
	colorArray[7] = System.Drawing.Color.Aquamarine;
	colorArray[8] = System.Drawing.Color.Cyan;
	colorArray[9] = System.Drawing.Color.DarkOrange;
	int colorIndex = 0;

	ShiftContainer shifts = core.readShiftsByPlt(this.plantComboBox.Text);
	for(IEnumerator en = shifts.GetEnumerator(); en.MoveNext(); )
	{
		Shift shift = (Shift)en.Current;

		for (int i=0; i<timeCodes.Length; i++)
		{
			this.grid.Styles.Add(shift.getDept() + "-" + shift.getShf() + "-" + timeCodes[i].getTmType());
			clsStyle style  = this.grid.Styles.get_Item(this.grid.Styles.Count.ToString());

			Color col = Nujit.NujitERP.WinForms.CapacityModule.TimeCodes.getInstance().getColor(timeCodes[i]);
			style.CaptionAlignmentVertical = (AGVBN20.Globals.GRE_VERTICALALIGNMENT)1;
			style.CaptionYMargin = 4;
			style.Appearance = AGVBN20.Globals.E_STYLEAPPEARANCE.SA_GRAPHICAL;
			style.UseMask = false;

			Color borderColor = Color.White;
			if (colorIndex < 10) 
				borderColor = colorArray[colorIndex];
			else
				borderColor = System.Drawing.Color.Red;

			ImageList il = new ImageList();
			Bitmap bmMiddle = new Bitmap(16,16);
			for (int x=0; x<16; x++)
			{
				for (int y=2; y<4; y++)
				{
					bmMiddle.SetPixel (x,y,borderColor);
					bmMiddle.SetPixel (x,14-y,borderColor);
				}
				bmMiddle.SetPixel (x,0,enlighten(2,borderColor));
				bmMiddle.SetPixel (x,1,enlighten(1,borderColor));
				bmMiddle.SetPixel (x,13,endarken(1,borderColor));
				bmMiddle.SetPixel (x,14,endarken(2,borderColor));
			}

			for (int x=0; x<16; x++)
			{
				for (int y=4; y<11; y++)
				{
					bmMiddle.SetPixel(x,y,TimeCodes.getInstance().getColor(timeCodes[i]));
				}
			}

			Bitmap bmStart = new Bitmap(bmMiddle);

			for (int y=0; y < 4; y++)
			{
				bmStart.SetPixel (0,y,enlighten(2,borderColor));
				if (y!=0)
					bmStart.SetPixel (1,y,enlighten(1,borderColor));
			}
			for (int y=4; y < 11; y++)
			{
				bmStart.SetPixel (0,y,enlighten(2,TimeCodes.getInstance().getColor(timeCodes[i])));
				bmStart.SetPixel (1,y,enlighten(1,TimeCodes.getInstance().getColor(timeCodes[i])));
			}
			for (int y=11; y < 14; y++)
			{
				bmStart.SetPixel (0,y,enlighten(2,borderColor));
				if (y != 13)
					bmStart.SetPixel (1,y,enlighten(1,borderColor));
			}

			Bitmap bmEnd = new Bitmap(bmMiddle);

			for (int y=1; y < 4; y++)
			{
				if (y!=1)
					bmEnd.SetPixel (14,y,endarken(1,borderColor));
				bmEnd.SetPixel (15,y,endarken(2,borderColor));
			}
			for (int y=4; y < 11; y++)
			{
				bmEnd.SetPixel (14,y,endarken(1,TimeCodes.getInstance().getColor(timeCodes[i])));
				bmEnd.SetPixel (15,y,endarken(2,TimeCodes.getInstance().getColor(timeCodes[i])));
			}
			for (int y=11; y < 15; y++)
			{
				if (y != 14)
					bmEnd.SetPixel (14,y,endarken(1,borderColor));
				bmEnd.SetPixel (15,y,endarken(2,borderColor));
			}

			il.Images.Add (bmStart);
			il.Images.Add (bmMiddle);
			il.Images.Add (bmEnd);
			style.ImageList = il;
			style.StartPictureIndex = 0;
			style.MiddlePictureIndex = 1;
			style.EndPictureIndex = 2;
			style.SelectionRectangleVisible = false;

			style.ForeColor = Color.Green;
		}
		colorIndex++;
	}
}

private 
Color enlighten (int degree, Color color)
{
	int channelR = color.R + (((255 - color.R) / 3) * degree);
	int channelG = color.G + (((255 - color.G) / 3) * degree);
	int channelB = color.B + (((255 - color.B) / 3) * degree);
	return Color.FromArgb (channelR, channelG, channelB);
}

private 
Color endarken (int degree, Color color)
{
	int channelR = color.R - ((color.R / 3) * degree);
	int channelG = color.G - ((color.G / 3) * degree);
	int channelB = color.B - ((color.B / 3) * degree);
	return Color.FromArgb (channelR, channelG, channelB);
}

private 
void loadSchedule(){

	string plantCode = plantComboBox.Text;
	string version = versionComboBox.Text;

	if (plantCode.Equals("") || (plantComboBox.SelectedIndex == -1))
		return;
	if (version.Equals("") || (versionComboBox.SelectedIndex == -1))
		return;

	this.panelLeyends.Tag = null;
	this.panelLeyends.Controls.Clear();

	grid.AutomaticRedraw = false;
	cleanGrid();
	try
	{
		if (!model.demandsAreLoaded())
			loadDemands();
		loadCapacityAndMachines (plantCode, version);
	}
	catch(NujitException ne)
	{
		MessageBox.Show(ne.Message);
		Dispose();
	}

	loadGanttFromModel();
}

private void loadGanttFromModel()
{
	grid.AutomaticRedraw = false;
	cleanGrid();

	SortedList machines = model.getUsedMachines();

	string currentDept = "";
	for (IEnumerator en = machines.GetEnumerator(); en.MoveNext(); )
	{
		string machineDept = ((string[])((DictionaryEntry)en.Current).Value)[0];
		string machineCode = ((string[])((DictionaryEntry)en.Current).Value)[1];

		if (!currentDept.Equals(machineDept))
		{
			currentDept = machineDept;
			grid.Rows.Add("KDep"+fila, "Department: " + currentDept, true, false, "RowDepartment", "");
			grid.Rows.get_Item("KDep"+fila).Tag = "Department";
			grid.Rows.get_Item("KDep"+fila).Height = 22;
		}

		grid.Rows.Add("K"+fila, "Machine: " + machineCode, true, false, "RowMachine", "");
		grid.Rows.get_Item("K"+fila).Tag = "Machine";
		grid.Rows.get_Item("K"+fila).Height = 20;

		fila += 1;

		CapacityNode capNode = model.getFirstCapacityNode (currentDept, machineCode);

		string shiftKey = "key_shift_machine_" + machineCode + "_dept_" + currentDept;
		grid.Rows.Add(shiftKey, "Shifts", true, true, "RowCapacity", "");
		clsRow shiftRow = grid.Rows.get_Item(shiftKey);
		shiftRow.Height = 15;

		while (capNode != null){
			this.addLeyend (currentDept, capNode.getSh());

			DateTime detailDate = capNode.getDt().Date;

			string startTime = capNode.getTmStart();
			string endTime = capNode.getTmEnd();

			DateTime date1 = capNode.getStartDate();
			DateTime date2 = capNode.getEndDate();

			string itemKey = shiftRow.Key + "_gantItem_" +
				capNode.getSh() + "_" + detailDate.Year + "_" + 
				detailDate.Month + "_" + detailDate.Day + "_" +
				startTime + "_" + endTime;

			grid.GanttItems.Add("", shiftRow.Key, date1, date2, 
				itemKey, currentDept + "-" + capNode.getSh() + "-" + capNode.getTmType(), "", "0");
			
			capNode = (CapacityNode)capNode.getNext();
		}

		string separatorKey = "key_separator_" + currentDept + "_" + machineCode;
		grid.Rows.Add(separatorKey, "", true, false, "RowDepartment", "");
		grid.Rows.get_Item(separatorKey).Height = 3;

		ArrayList prodTasks = model.getProductsTasks(currentDept, machineCode);

		IEnumerator enuProds = prodTasks.GetEnumerator();

		while (enuProds.MoveNext())
		{
			ArrayList tasksList = (ArrayList)enuProds.Current;

			string prodId = ((TaskNode)tasksList[0]).getDemand().getProdID();

			grid.Rows.Add(prodId + "-" + fila, prodId, true, true, "RowTask", "");
			clsRow prodRow = grid.Rows.get_Item(prodId + "-" + fila);
			prodRow.Tag = "Part";						
			prodRow.Height = 16;

			IEnumerator enuTasks = tasksList.GetEnumerator();
			int p=0;

			while (enuTasks.MoveNext())
			{
				TaskNode taskNode = (TaskNode)enuTasks.Current;

				grid.GanttItems.Add("", prodRow.Key, taskNode.getStartDate(), taskNode.getEndDate(), 
					prodRow.Key + "_gantItem" + p.ToString(), 
					"defaultStyleItem", "", "0");
				clsGanttItem item = grid.GanttItems.get_Item(prodRow.Key + "_gantItem" + p.ToString());
				item.Tag = taskNode.getDemand().getOrderID().ToString() + "_" + taskNode.getDemand().getItemID().ToString() + "_" + taskNode.getDemand().getReleaseID();
				p++;
			}

		}
		fila +=1;
	}

	grid.AutomaticRedraw = true;
	grid.Refresh();
}

private 
void refreshGrid(){
	dtStart = fromDateTimePicker.Value;
	dtEnd = toDateTimePicker.Value;

	TimeSpan timeSpan = dtEnd.Subtract(dtStart);

	grid.HorizontalScrollBarMax = (int)timeSpan.TotalHours;
	
	DateTime aux = dtStart;
	this.grid.HorizontalScrollBarStart = aux;
	this.grid.TimeLineMarkerDate = dtStart;

	loadGanttFromModel();
}

private
void cleanGrid(){
	grid.RowHeadings.Clear();
	grid.Rows.Clear();
	grid.GanttItems.Clear();

	grid.RowHeadings.Add("SCHEDULING", 150, "RowHeadings", "");
}

private 
void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e){
	switch(e.Button.Tag.ToString()){
	case "expand": 
		this.grid.ZoomFactor--;
		grid.Redraw();
		break;
	case "reduce": 
		this.grid.ZoomFactor++;
		grid.Redraw();
		break;
	case "refresh": 
		refreshGrid();
		break;
	case "add":
		modifyItems();
		break;
	case "close":
		Close();
		break;
	case "save":
		saveModel();
		break;
	case "print":
		if (!plantComboBox.Text.Equals("") && !versionComboBox.Text.Equals(""))
		{
			DepartmentMachineForm dpFrm = new DepartmentMachineForm();
			dpFrm.setValues (model.getUsedMachines());
			dpFrm.ShowDialog (this);
			if (dpFrm.DialogResult == DialogResult.OK)
			{
				DataSet dataSet = model.getScheduleInMachineReportDataSet (dpFrm.getDepartment(), dpFrm.getMachine());
				ScheduleInMachineReport report = new ScheduleInMachineReport(dataSet, model.getTimeScopeFrom(), model.getTimeScopeTo(), versionComboBox.Text, plantComboBox.Text, dpFrm.getDepartment(), dpFrm.getMachine());
				report.ShowDialog();
			}
		}
		break;
//		DataSet dataSet = generateReportDataSet(plantComboBox.Text,deptComboBox.Text);
//		SchedulingViewReport schedulingViewReport = new SchedulingViewReport(dataSet);
//		schedulingViewReport.ShowDialog();
//		break;
	case "chVersion":
		addNewVersion();
		break;
	}
}

private
void modifyItems(){
	if (this.versionComboBox.SelectedIndex >= 0){
		AddForm addForm = new AddForm(plantComboBox.Text, versionComboBox.Text, model);
		addForm.ShowDialog();
		
		if (addForm.DialogResult == DialogResult.OK)
		{
			model = addForm.getModel();
			refreshGrid();
		}
	}else
		MessageBox.Show("Must Select a version before modify items");
}

private
void addNewVersion(){
	NewVersion newVersion = new NewVersion((string)plantComboBox.SelectedItem);
	newVersion.ShowDialog();

	if (newVersion.DialogResult == DialogResult.OK){
		object item = versionComboBox.SelectedItem;
		
		versionComboBox.Items.Clear();
		string[][] versions = core.getActiveCapacityVersions((string)plantComboBox.SelectedItem);
		for(int i = 0; i < versions.Length; i++)
			versionComboBox.Items.Add(versions[i][0]);
		
		versionComboBox.SelectedItem = item;
	}
}

private 
void plantComboBox_SelectedValueChanged(object sender, System.EventArgs e){
	string plt = plantComboBox.Text;
	if (plt == null)
		plt = (string)plantComboBox.SelectedItem;

	versionComboBox.Items.Clear();

	string[][] versions = core.getActiveCapacityVersions((string)plantComboBox.SelectedItem);
	for(int i = 0; i < versions.Length; i++)
		versionComboBox.Items.Add(versions[i][0]);
		
	versionComboBox.SelectedIndex = -1;
}

private void versionComboBox_SelectedValueChanged(object sender, System.EventArgs e)
{
	model.disposeVersion();
	setGridStyles();
	loadSchedule();
}

private 
void currentDateTimePicker_ValueChanged(object sender, System.EventArgs e){
	DateTime date1 = currentDateTimePicker.Value.Date;

	if ((DateTime.Compare(date1,dtStart)< 0)||(DateTime.Compare(dtEnd,date1))<0){
	
		MessageBox.Show("Date view must be between "+ DateUtil.getDateRepresentation(dtStart,DateUtil.MMDDYYYY) +
						" and " + DateUtil.getDateRepresentation(dtEnd,DateUtil.MMDDYYYY));
		return;
	}
	
	this.setGanttTimeScope();
}

private 
void fromDateTimePicker_ValueChanged(object sender, System.EventArgs e){
	DateTime dateFrom = this.fromDateTimePicker.Value;
	DateTime dateTo = this.toDateTimePicker.Value;
	
	if (DateTime.Compare(dateTo, dateFrom) < 0){
		MessageBox.Show("Date From can't be after Date To, Date From will be reset");
		fromDateTimePicker.Value = dtStart;
		return;
	}

	setGanttTimeScope();
}

private 
void toDateTimePicker_ValueChanged(object sender, System.EventArgs e){
	DateTime dateFrom = this.fromDateTimePicker.Value;
	DateTime dateTo = this.toDateTimePicker.Value;
	
	if (DateTime.Compare(dateTo, dateFrom) < 0){
		MessageBox.Show("Date To can't be before Date From, Date To will be reset");
		toDateTimePicker.Value = dtEnd;
		return;
	}

	setGanttTimeScope();
}

#region Must Have
private 
void OnClosed(object sender, System.EventArgs e){
	if (this.formMainParent != null){
		this.formMainParent.RemoveTab(this.Tag);
		this.formMainParent.SetButtons();
	}	
}
#endregion Must Have

private 
void schView1Button_Click(object sender, System.EventArgs e){
	
//	string dept = this.deptComboBox.SelectedItem.ToString();
//	string plant = this.plantComboBox.SelectedItem.ToString();
//	SchedulingView1Form schedulingView1Form = new SchedulingView1Form(plant,dept);
//	schedulingView1Form.ShowDialog();
}

private 
void matRecButton_Click(object sender, System.EventArgs e){
	this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
	this.matRecButton.Enabled=false;
	core.generateMaterialRecords();
	this.matRecButton.Enabled=true;
	this.Cursor = System.Windows.Forms.Cursors.Default;
}		

private void grid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e){
	
	Point location = grid.PointToClient(Cursor.Position);
	int Index = -1;
	for (int i=1; (i <= grid.Rows.Count) && (Index == -1); i++)
	{
		clsRow row = grid.Rows.get_Item (i.ToString());
		if ((location.X >= row.Left) && (location.X <= row.Right) &&
			(location.Y >= row.Top)  && (location.Y <= row.Bottom))
			Index = row.Index;
	}
	if (Index >= 0)
	{
		if (grid.Rows.get_Item(Index.ToString()).Tag.Equals("Part"))
			showDetailPanel (Index);
		return;
	}

	Index = -1;
	for (int i=1; (i <= grid.GanttItems.Count) && (Index == -1); i++)
	{
		clsGanttItem item = grid.GanttItems.get_Item (i.ToString());
		string tag = grid.Rows.get_Item(item.RowKey).Tag;
		if ((location.X >= item.Left) && (location.X <= item.Right) &&
			(location.Y >= item.Top)  && (location.Y <= item.Bottom) &&
			tag.Equals ("Part"))
			Index = item.Index;
	}

	if (Index >= 0)
	{
		if ((e.Button == MouseButtons.Left) && (demandCheckBox.Checked))
		{
			ganttItemSelected(Index);
			if (grid.GanttItems.get_Item(Index.ToString()).StyleIndex.Equals("selectedStyleItem"))
				showDemandPanel (Index);
			return;
		}
		else  if ((e.Button == MouseButtons.Right) && (plantComboBox.SelectedIndex != -1) && (versionComboBox.SelectedIndex != -1))
		{
			selectedItemIndex = Index;
			showMenu (new Point (e.X, e.Y));
			return;
		}
	}

	if ((e.Button == MouseButtons.Right) && (plantComboBox.SelectedIndex != -1) && (versionComboBox.SelectedIndex != -1))
	{
		selectedItemIndex = -1;
		showMenu (new Point (e.X, e.Y));
	}
}

public void showMenu (Point pos)
{
	bool itemSelected = (selectedItemIndex >= 0);
	removeMenuItem.Visible = itemSelected;
	gridContextMenu.Show (grid, pos);
}

private
void showDemandPanel (int Index)
{
	if (model == null)
		return;

	string tag = grid.GanttItems.get_Item (Index.ToString()).Tag;
	int firstPos = tag.IndexOf("_");
	int secondPos = tag.IndexOf ("_", firstPos + 1);
	decimal ordID = decimal.Parse(tag.Substring (0,firstPos));
	decimal itemID = decimal.Parse(tag.Substring (firstPos + 1,secondPos - firstPos - 1));
	string relID = tag.Substring (secondPos + 1);

	string[] info = model.getDemandInfo (ordID, itemID, relID);
	if (info == null)
		return;

	orderIDTextBox.Text = ordID.ToString();
	itemIDTextBox.Text = itemID.ToString();
	releaseIDTextBox.Text = relID;
	dateShipTextBox.Text = info[3];
	dateReadyTextBox.Text = info[4];
	qtyTextBox.Text = info[2];
	prodIDTextBox.Text = info[0];
	seqTextBox.Text = info[1];
	descriptionTextBox.Text = core.readProduct(info[0]).getDes1();
	custIDTextBox.Text = info [5];
	Person[] personVec = core.readPersonsById(info[5]);
	if (personVec != null)
		nameTextBox.Text = personVec[0].getName();

	HidePanel.setHideTick(Environment.TickCount + 2900);
	if (!demandPanel.Visible)
	{
		demandPanel.BringToFront();
		demandPanel.Visible = true;

		HidePanel hidePanel = new HidePanel(demandPanel);
		Thread thread = new Thread(new ThreadStart(hidePanel.hidePanel));
		thread.Start();
	}
}

private
void showDetailPanel (int Index)
{
	string seekedMac = "";
	string seekedDept = "";
	for(int i = Index; i > 0; i--)
	{
		string mach = grid.Rows.get_Item(i.ToString()).Tag;

		if (mach.Equals("Machine"))
		{
			seekedMac = grid.Rows.get_Item(i.ToString()).Caption;
			break;
		}
	}

	for(int i = Index; i > 0; i--)
	{
		string mach = grid.Rows.get_Item(i.ToString()).Tag;

		if (mach.Equals("Department"))
		{
			seekedDept = grid.Rows.get_Item(i.ToString()).Caption;
			break;
		}
	}

	string prodId =grid.Rows.get_Item(Index.ToString()).Caption;
	string machineCode = seekedMac.Substring (9);
	string deptCode = seekedDept.Substring (12);
	string[][] returnParts = model.getSchPrFmHrForMachine(machineCode, deptCode);
	int seq = 0;
	decimal utilPer = 0;
	string drs = "";
	string prOrdMas = "";
	decimal machOrdNum = 0;
	decimal runStd = 0;
	decimal hrPr = 0;
	string minQtyReq="N/A";
	string schQty ="N/A";
	bool first = true;
	
	for (int i=0;i<returnParts.Length;i++)
	{
		string parte = returnParts[i][0];
		if (prodId.Equals(returnParts[i][0]))
		{
			if (first == true)
			{
				seq = int.Parse(returnParts[i][1]);
				utilPer =decimal.Parse(returnParts[i][3]);
				drs = returnParts[i][4];
				prOrdMas =returnParts[i][7];
				machOrdNum =decimal.Parse(returnParts[i][8]);
				runStd =decimal.Parse(returnParts[i][9]);
				
				string[] oldQtyInfo =             // SPH_SchVersion    SPH_MasOrd()
					model.getSMOInfo(prodId, returnParts[i][6], returnParts[i][7], seq);
			
				if (oldQtyInfo.Length > 0) 
				{
					minQtyReq = oldQtyInfo[1];
					schQty = oldQtyInfo[0];
				}
			}
			hrPr = decimal.Parse(returnParts[i][10]) + hrPr;
		}			
	}//end for
		
	this.txtProdId.Text = prodId.ToString();
	this.txtSeq.Text = seq.ToString();
	this.txtUtilPer.Text = utilPer.ToString() + " %";
	this.txtHrPr.Text = hrPr.ToString();
	this.txtMinQtyReq.Text = minQtyReq;
	this.txtSchQty.Text = schQty;
	this.txtDrs.Text = drs;
	this.txtRunStd.Text = runStd.ToString();
		
	HidePanel.setHideTick(Environment.TickCount + 2900);
	if (!detailPanel.Visible)
	{
		detailPanel.BringToFront();
		detailPanel.Visible = true;

		HidePanel hidePanel = new HidePanel(detailPanel);
		Thread thread = new Thread(new ThreadStart(hidePanel.hidePanel));
		thread.Start();
	}
}

private 
void button1_Click(object sender, System.EventArgs e){
	PaintForPartForm paintForPartForm = new PaintForPartForm();
	paintForPartForm.ShowDialog();
}

private 
void button2_Click(object sender, System.EventArgs e){
	GridPaintOrders gridPaintOrders = new GridPaintOrders();
	gridPaintOrders.ShowDialog();
}

private 
void matButton_Click(object sender, System.EventArgs e){
	MaterialsGridForm materialsGridForm = new MaterialsGridForm(txtProdId.Text, 
			txtSeq.Text, txtSchQty.Text);
	materialsGridForm.ShowDialog();
}


private string[][] columnsNames(){
string[][] vec = new String[8][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
        case "0":
            v[0] = "SPH_ProdID";
            v[1] = "0";
            break;
        case "1":
            v[0] = "SPH_Seq";
            v[1] = "0";
            break;
        case "2":
            v[0] = "SPH_HrPr";
            v[1] = "0";
            break;
        case "3":
            v[0] = "SPH_UtilPer";
            v[1] = "0";
            break;
        case "4":
            v[0] = "SPH_MachOrdNum";
            v[1] = "0";
            break;
        case "5":
            v[0] = "PDM_Mach";
            v[1] = "0";
            break;
        case "6":
            v[0] = "SMH_TmStart";
            v[1] = "0";
            break;
        case "7":
            v[0] = "SMH_HrPr";		
            v[1] = "0";
            break;
		}
	    vec[i]=v;
		i++;	
	}
	return vec;
}
private 
DataSet generateReportDataSet(string plantCode,string deptCode){
	DataTable dataTable = new DataTable();
	DataRow dataRow;
	
	string tableName = "schedule";	
	string[][] columns = columnsNames();

	Grid.addColumns(columns,tableName,dataTable);
	
	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
	string[][] vec = coreFactory.getScheduleForReport(plantCode, deptCode);
	
	for(int x = 0; x < vec.Length; x++){
		if (vec[x]!=null){
			dataRow = dataTable.NewRow();
			dataRow[0] = vec[x][0];
			dataRow[1] = int.Parse(vec[x][1]);
			dataRow[2] = decimal.Parse(vec[x][2]);
			dataRow[3] = decimal.Parse(vec[x][3]);
			dataRow[4] = int.Parse(vec[x][4]);
			dataRow[5] = vec[x][5];
			dataRow[6] = DateUtil.parseCompleteDate(vec[x][6], DateUtil.MMDDYYYY);
			dataRow[7] = decimal.Parse(vec[x][7]);
			dataTable.Rows.Add(dataRow);
		}
	}

	DataSet scheduleReportDataSet = new DataSet();
	scheduleReportDataSet.Tables.Add(dataTable);
	
	return scheduleReportDataSet;
}

private
void addLeyend (string dept, string shift){

	if (panelLeyends.Tag == null)
		panelLeyends.Tag = new Hashtable();

	Hashtable htLeyends = (Hashtable)panelLeyends.Tag;

	if (!htLeyends.ContainsKey(dept + "_" + shift))
		htLeyends.Add (dept + "_" + shift, null);
	else
		return;

	int count = htLeyends.Count - 1;

	Label leyend = new Label();
	Label deptLabel = new Label();
	Panel panelColor = new Panel();

	this.panelLeyends.Controls.Add(leyend);
	this.panelLeyends.Controls.Add(deptLabel);
	this.panelLeyends.Controls.Add(panelColor);

	deptLabel.Location = new System.Drawing.Point(35 + (count * 110), 0);
	deptLabel.Size = new System.Drawing.Size(80, 14);
	deptLabel.Text = "Dept: " + dept;
	deptLabel.Font = new Font ("Ms Sans Serif", 7, FontStyle.Regular);
	deptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

	leyend.Location = new System.Drawing.Point(35 + (count * 110), 14);
	leyend.Size = new System.Drawing.Size(80, 14);
	leyend.Text = "Shift: " + shift;
	leyend.Font = new Font ("Ms Sans Serif", 7, FontStyle.Regular);
	leyend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

	panelColor.BackColor = ((Bitmap)grid.Styles.get_Item(dept + "-" + shift + "-RUNTIME").ImageList.Images[0]).GetPixel(2,2);
	panelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	panelColor.Location = new System.Drawing.Point(8 + (count * 110), 5);
	panelColor.Size = new System.Drawing.Size(20, 20);

	this.panelLeyends.Visible = true;
	this.panelLeyends.Width = 126 + (count * 110);
}

private void grid_GanttItemDblClick(int Index, System.Drawing.Point Position, System.Windows.Forms.MouseButtons Button)
{
	if (!Button.Equals(MouseButtons.Left))
		return;

	clsGanttItem item = grid.GanttItems.get_Item (Index.ToString());
	string prodId = item.RowKey.Substring(0,item.RowKey.LastIndexOf ("-"));

	string[][] vec = this.gridSch.getSchPrMasStr();

	int i = 0;
	while ((i < vec.Length) && ((!vec[i][2].Equals(prodId)) || (!DateUtil.parseCompleteDate(vec[i][13],DateUtil.MMDDYYYY).Equals(item.StartDate))))
		i++;

	if (i >= vec.Length)
		return;

	EditItem edit = new EditItem(gridSch.getPlant(), vec[i][23], prodId, vec[i][4], vec[i][6], vec[i][24], vec[i][15], vec[i][13], vec[i][14], gridSch, core.isFamilyPart(vec[i][2]));
	edit.ShowDialog();
}

private void ganttItemSelected(int Index)
{
	string tag = grid.Rows.get_Item(grid.GanttItems.get_Item(Index.ToString()).RowKey).Tag;
	if (!tag.Equals("Part"))
		return;

	if (grid.GanttItems.get_Item(Index.ToString()).StyleIndex.Equals("selectedStyleItem"))
	{
		for (int i=1; i <= grid.GanttItems.Count; i++)
		{
			clsGanttItem item = grid.GanttItems.get_Item(i.ToString());
			if (item.StyleIndex.Equals("selectedStyleItem"))
				item.StyleIndex = "defaultStyleItem";
		}
	}
	else
	{
		tag = grid.GanttItems.get_Item(Index.ToString()).Tag;
		for (int i=1; i <= grid.GanttItems.Count; i++)
		{
			clsGanttItem item = grid.GanttItems.get_Item(i.ToString());
			if (item.StyleIndex.Equals("selectedStyleItem"))
				item.StyleIndex = "defaultStyleItem";
			if (item.Tag.Equals(tag))
				item.StyleIndex = "selectedStyleItem";
		}
	}
}

private void loadDemands()
{
	BusyForm busyForm = new BusyForm(model, BusyForm.LOAD_DEMANDS);
	busyForm.ShowDialog();
}

private void loadCapacityAndMachines (string plantCode, string version)
{
	BusyForm busyForm = new BusyForm(model, BusyForm.LOAD_CAPACITY_MACHINES);
	object[] par = new object[2];
	par[0] = plantCode;
	par[1] = version;
	busyForm.setParameters(par);
	busyForm.ShowDialog();
}

private void demButton_Click(object sender, System.EventArgs e)
{

}

private void currentDateTimePicker_Leave(object sender, System.EventArgs e)
{
	if (!today.Equals(currentDateTimePicker.Value))
		currentDateTimePicker.Value = today;
}

private string[] getDeptMacProdFromItem(int Index)
{
	clsGanttItem item = grid.GanttItems.get_Item (Index.ToString());
	int i = 1;
	string macCode = "";
	string deptCode = "";
	string prodCode = "";

	while ((i <= grid.Rows.Count) && (prodCode.Equals("")))
	{
		clsRow row = grid.Rows.get_Item(i.ToString());
		if (row.Tag.Equals("Department"))
			deptCode = row.Caption.Substring (12);
		if (row.Tag.Equals("Machine"))
			macCode = row.Caption.Substring (9);
		if (row.Tag.Equals("Part") &&
			(row.Top == item.Top))
			prodCode = row.Caption;

		i++;
	}

	if (prodCode.Equals(""))
		return null;
	else
	{
		string[] vec = new string[3];
		vec[0] = deptCode;
		vec[1] = macCode;
		vec[2] = prodCode;
		return vec;
	}
}

private void addMenuItem_Click(object sender, System.EventArgs e)
{

}

private void removeMenuItem_Click(object sender, System.EventArgs e)
{
	clsGanttItem item = grid.GanttItems.get_Item (selectedItemIndex.ToString());
	string[] info = getDeptMacProdFromItem (selectedItemIndex);

	if (model.removeTask (info[0], info[1], item.StartDate))
		loadGanttFromModel();
}

private void clearMenuItem_Click(object sender, System.EventArgs e)
{
	model.removeAllTasks();
	loadGanttFromModel();
}

private void fromDemandMenuItem_Click(object sender, System.EventArgs e)
{
	BusyForm busyForm = new BusyForm(model, BusyForm.LOAD_TASKS_FROM_DEMAND);
	busyForm.ShowDialog (this);
	loadGanttFromModel();
	if (!model.allDemandsAdded())
	{
		if (MessageBox.Show ("Not all demands could be schedulled.\nDo you wish to see which ones remain unscheduled?", "Demands not added", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			DataSet dataSet = model.getNotScheuledDemands ();
			NotScheduledDemands report = new NotScheduledDemands(dataSet, model.getTimeScopeFrom(), model.getTimeScopeTo(), versionComboBox.Text, plantComboBox.Text);
			report.ShowDialog();
		}
	}
}

private void saveModel()
{
	Schedule schedule = model.getSchedule();
	ArrayList vec = model.getTasksAddedFromDemandAsString();
	string[][] addVec = new string[vec.Count][];
	
	for (int i=0; i<vec.Count; i++)
	{
		addVec[i] = new string[15];
		object[] item = (object[])vec[i];

		addVec[i][0] = item[0].ToString();
		addVec[i][1] = item[2].ToString();
		addVec[i][2] = item[3].ToString();
		addVec[i][3] = item[4].ToString();
		addVec[i][4] = item[5].ToString();
		addVec[i][5] = item[6].ToString();
		addVec[i][6] = item[7].ToString();
		addVec[i][7] = item[8].ToString();
		addVec[i][8] = item[9].ToString();
		addVec[i][9] = item[10].ToString();
		addVec[i][10] = item[11].ToString();
		addVec[i][11] = item[12].ToString();
		addVec[i][12] = item[13].ToString();
		addVec[i][13] = item[14].ToString();
		addVec[i][14] = item[15].ToString();
	}

	schedule.addAllItems (this.plantComboBox.Text, addVec);
	core.updateSchedule(schedule);

	MessageBox.Show ("Schedule saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
}

private
class HidePanel{

private Panel panel;
private static int hideTick;

public
HidePanel(Panel panel){
	this.panel = panel;
}

public static void setHideTick(int tick)
{
	hideTick = tick;
}

public
void hidePanel(){
	if ((hideTick - Environment.TickCount) > 0)
		Thread.Sleep((hideTick - Environment.TickCount) + 100);
	else
		Thread.Sleep(100);
	Point mouseClientsPosition = panel.PointToClient(Cursor.Position);
	if ((Environment.TickCount > hideTick) &&
		((mouseClientsPosition.X < 0) || (mouseClientsPosition.Y < 0) ||
		(mouseClientsPosition.X > panel.Width) || (mouseClientsPosition.Y > panel.Height)))
		panel.Visible = false;
	else
		hidePanel();
}

} // HidePanel


} // class


} // namespace
