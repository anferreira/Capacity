/*********************************************************************** 
File Name:               FormMain.cs
Created By:              Eric zhong
Created Date:            08/03/2004
***********************************************************************/


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.WinForms.M1;
using Nujit.NujitERP.WinForms.Demo;
using Nujit.NujitERP.WinForms.Schedule;
using Nujit.NujitERP.WinForms.Master; 
using Nujit.NujitERP.WinForms.Screens  ;
using Nujit.NujitERP.WinForms.Schedule.HotList;
using Nujit.NujitERP.WinForms.Schedule.LoadUpLoad;
using Nujit.NujitERP.WinForms.GeneralLedger;
using Nujit.NujitERP.WinForms.OrderEntry.Invoice;
using Nujit.NujitERP.WinForms.Reports.ShortageReport;
using Nujit.NujitERP.WinForms.Reports.HotList_Report;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.ExcelReports;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms.Production;

using GridScheduling.gui;

using GridScheduling.gui.schedule;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.Common;

using Nujit.NujitERP.WinForms.Orders;
using Nujit.NujitERP.WinForms.InventoryLayout;


namespace Nujit.NujitERP.WinForms{

	/// <summary>
	/// MDI parent form.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		#region Variables
   		public static User Operator;
		private WaitForm wait = new WaitForm();
   		#endregion Variables

		private AppUpdater.AppUpdater appUpdater1 = null;
		private bool userUpdate = false;
		internal static int returnCode = 0;

		#region Controls
		private System.Windows.Forms.MainMenu mainMenuMain;
		private System.Windows.Forms.ToolBar toolBarMain;
		public System.Windows.Forms.StatusBar statusBarMain;
		public System.Windows.Forms.StatusBarPanel statusBarPanelMessage;
		private System.Windows.Forms.StatusBarPanel statusBarPanelDate;
		private System.Windows.Forms.MenuItem menuItemTopSaleAnalysis;
		private System.Windows.Forms.MenuItem menuItemClose;
		private System.Windows.Forms.MenuItem menuItemCloseAll;
		private System.Windows.Forms.MenuItem menuItemCascade;
		private System.Windows.Forms.MenuItem menuItemHoriz;
		private System.Windows.Forms.MenuItem menuItemVert;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItemMax;
		private System.Windows.Forms.MenuItem menuItemMin;
		private System.Windows.Forms.MenuItem menuItemTopTools;
		private System.Windows.Forms.MenuItem menuItemUserManagement;
		private System.Windows.Forms.MenuItem menuItemPassword;
		private System.Windows.Forms.StatusBarPanel statusBarPanelUser;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemTopView;
		private System.Windows.Forms.MenuItem menuItemShowToolBar;
		private System.Windows.Forms.MenuItem menuItemShowStatusBar;
		private System.Windows.Forms.TabControl ctlTab;
		private System.Windows.Forms.Panel pnlWindowsBar;

		private System.Windows.Forms.ImageList imageListTabPage;
		private System.Windows.Forms.MenuItem menuItemShowReportBar;
		private System.Windows.Forms.MenuItem menuItemTopFile;
		private System.Windows.Forms.MenuItem menuItemTopWindows;
		private System.Windows.Forms.MenuItem menuItemShowChildForm;
		private System.Windows.Forms.MenuItem menuItemSchedule;
		private System.Windows.Forms.MenuItem menuItemTopSchedule;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItemLoad;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem45;
		private System.Windows.Forms.MenuItem menuItem46;
		private System.Windows.Forms.MenuItem menuItem47;
		private System.Windows.Forms.MenuItem menuItem48;
		private System.Windows.Forms.MenuItem menuItem49;
		private System.Windows.Forms.MenuItem menuItem50;
		private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem menuItem52;
		private System.Windows.Forms.MenuItem menuItem53;
		private System.Windows.Forms.MenuItem menuItem54;
		private System.Windows.Forms.MenuItem menuItem55;
		private System.Windows.Forms.MenuItem menuItem56;
		private System.Windows.Forms.MenuItem menuItem1DataTables;
		private System.Windows.Forms.MenuItem menuItem1UploadSchedule;
		private System.Windows.Forms.MenuItem menuItemCapacity;
		private System.Windows.Forms.MenuItem menuItemDridSchedule;
		private System.Windows.Forms.MenuItem menuItemReports;
		private System.Windows.Forms.MenuItem menuItemHotListReport;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemTopInventory;
		private System.Windows.Forms.MenuItem menuItemFutureInventory;
		private System.Windows.Forms.MenuItem menuItem1PastInventory;
		private System.Windows.Forms.MenuItem menuItem1topPLC;
		private System.Windows.Forms.MenuItem menuItem1RealTimeShopFloor;
		private System.Windows.Forms.MenuItem menuItemTopHelp;
		private System.Windows.Forms.MenuItem menuItemRegister;
        private System.Windows.Forms.MenuItem menuItem82;
        private System.Windows.Forms.MenuItem menuItem83;
        private System.Windows.Forms.MenuItem menuItem90;
        private System.Windows.Forms.MenuItem menuItem91;
        private System.Windows.Forms.MenuItem menuItem95;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem reportsMenuItem;
		private System.Windows.Forms.MenuItem queryMenuItem;
		private System.Windows.Forms.MenuItem maintenanceMenuItem;
		private System.Windows.Forms.MenuItem prodSchedulingMenuItem;
		private System.ComponentModel.IContainer components;
		#endregion 

		#region Constructors

		public FormMain()
		{
			this.companyName = Configuration.CompanyName;

			this.Text = "ImageView.NET";
			this.ClientSize = new Size(640, 480);
			this.IsMdiContainer = true;

			//The first control is the MDI background...
			//this.Controls[0].Paint += new PaintEventHandler(MdiBackground_Paint);
			this.Controls[0].Resize += new EventHandler(MdiBackground_Resize);

			InitializeComponent();
			InitializeControls();
		}
		

		private void InitializeControls()
		{
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5 && Environment.OSVersion.Version.Minor >= 1)
			{
				this.pnlWindowsBar.Height = 27;
				ctlTab.Location = new Point(0, 3);
			}
			else
			{
				this.pnlWindowsBar.Height = 23;
				ctlTab.Location = new Point(-2, 1);
			}

			ctlTab.Appearance = TabAppearance.FlatButtons;
			ctlTab.HotTrack = true;
			ctlTab.ImageList = imageListTabPage;
			ctlTab.ShowToolTips = true;
			ctlTab.Padding = new Point(3, 3);
			ctlTab.MouseUp += new MouseEventHandler(ctlTab_MouseUp); 
	
			this.SetButtons();
		
		}

        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#endregion Constructors

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
			this.mainMenuMain = new System.Windows.Forms.MainMenu();
			this.menuItemTopFile = new System.Windows.Forms.MenuItem();
			this.menuItemClose = new System.Windows.Forms.MenuItem();
			this.menuItemCloseAll = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItemTopView = new System.Windows.Forms.MenuItem();
			this.menuItemShowToolBar = new System.Windows.Forms.MenuItem();
			this.menuItemShowStatusBar = new System.Windows.Forms.MenuItem();
			this.menuItemShowReportBar = new System.Windows.Forms.MenuItem();
			this.menuItemTopSchedule = new System.Windows.Forms.MenuItem();
			this.menuItemLoad = new System.Windows.Forms.MenuItem();
			this.menuItem1DataTables = new System.Windows.Forms.MenuItem();
			this.menuItem1UploadSchedule = new System.Windows.Forms.MenuItem();
			this.menuItemDridSchedule = new System.Windows.Forms.MenuItem();
			this.menuItemCapacity = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItemReports = new System.Windows.Forms.MenuItem();
			this.menuItemHotListReport = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.prodSchedulingMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItemTopInventory = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem95 = new System.Windows.Forms.MenuItem();
			this.menuItemFutureInventory = new System.Windows.Forms.MenuItem();
			this.menuItem1PastInventory = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem50 = new System.Windows.Forms.MenuItem();
			this.menuItem51 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem82 = new System.Windows.Forms.MenuItem();
			this.menuItem83 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem47 = new System.Windows.Forms.MenuItem();
			this.menuItem48 = new System.Windows.Forms.MenuItem();
			this.menuItem49 = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuItem52 = new System.Windows.Forms.MenuItem();
			this.menuItem53 = new System.Windows.Forms.MenuItem();
			this.menuItem54 = new System.Windows.Forms.MenuItem();
			this.menuItem55 = new System.Windows.Forms.MenuItem();
			this.menuItem56 = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem39 = new System.Windows.Forms.MenuItem();
			this.menuItem1topPLC = new System.Windows.Forms.MenuItem();
			this.menuItem1RealTimeShopFloor = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem90 = new System.Windows.Forms.MenuItem();
			this.menuItem91 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.menuItem41 = new System.Windows.Forms.MenuItem();
			this.menuItem42 = new System.Windows.Forms.MenuItem();
			this.menuItem43 = new System.Windows.Forms.MenuItem();
			this.menuItem44 = new System.Windows.Forms.MenuItem();
			this.menuItem45 = new System.Windows.Forms.MenuItem();
			this.menuItem46 = new System.Windows.Forms.MenuItem();
			this.menuItemTopSaleAnalysis = new System.Windows.Forms.MenuItem();
			this.menuItemSchedule = new System.Windows.Forms.MenuItem();
			this.menuItemShowChildForm = new System.Windows.Forms.MenuItem();
			this.reportsMenuItem = new System.Windows.Forms.MenuItem();
			this.queryMenuItem = new System.Windows.Forms.MenuItem();
			this.maintenanceMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItemTopTools = new System.Windows.Forms.MenuItem();
			this.menuItemUserManagement = new System.Windows.Forms.MenuItem();
			this.menuItemPassword = new System.Windows.Forms.MenuItem();
			this.menuItemTopWindows = new System.Windows.Forms.MenuItem();
			this.menuItemCascade = new System.Windows.Forms.MenuItem();
			this.menuItemHoriz = new System.Windows.Forms.MenuItem();
			this.menuItemVert = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItemMax = new System.Windows.Forms.MenuItem();
			this.menuItemMin = new System.Windows.Forms.MenuItem();
			this.menuItemTopHelp = new System.Windows.Forms.MenuItem();
			this.menuItemRegister = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.toolBarMain = new System.Windows.Forms.ToolBar();
			this.statusBarMain = new System.Windows.Forms.StatusBar();
			this.statusBarPanelMessage = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelUser = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
			this.pnlWindowsBar = new System.Windows.Forms.Panel();
			this.ctlTab = new System.Windows.Forms.TabControl();
			this.imageListTabPage = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelUser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDate)).BeginInit();
			this.pnlWindowsBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuMain
			// 
			this.mainMenuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemTopFile,
																						 this.menuItemTopView,
																						 this.menuItemTopSchedule,
																						 this.menuItemTopInventory,
																						 this.menuItem4,
																						 this.menuItem82,
																						 this.menuItem6,
																						 this.menuItem7,
																						 this.menuItem1topPLC,
																						 this.menuItem8,
																						 this.menuItem9,
																						 this.menuItemTopSaleAnalysis,
																						 this.reportsMenuItem,
																						 this.menuItemTopTools,
																						 this.menuItemTopWindows,
																						 this.menuItemTopHelp});
			// 
			// menuItemTopFile
			// 
			this.menuItemTopFile.Index = 0;
			this.menuItemTopFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemClose,
																							this.menuItemCloseAll,
																							this.menuItemExit});
			this.menuItemTopFile.Text = "File";
			// 
			// menuItemClose
			// 
			this.menuItemClose.Index = 0;
			this.menuItemClose.Text = "Close";
			this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
			// 
			// menuItemCloseAll
			// 
			this.menuItemCloseAll.Index = 1;
			this.menuItemCloseAll.Text = "Close All";
			this.menuItemCloseAll.Click += new System.EventHandler(this.menuItemCloseAll_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 2;
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// menuItemTopView
			// 
			this.menuItemTopView.Index = 1;
			this.menuItemTopView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemShowToolBar,
																							this.menuItemShowStatusBar,
																							this.menuItemShowReportBar});
			this.menuItemTopView.Text = "View ";
			// 
			// menuItemShowToolBar
			// 
			this.menuItemShowToolBar.Index = 0;
			this.menuItemShowToolBar.Text = "Toolbar";
			this.menuItemShowToolBar.Click += new System.EventHandler(this.menuItemShowToolBar_Click);
			// 
			// menuItemShowStatusBar
			// 
			this.menuItemShowStatusBar.Checked = true;
			this.menuItemShowStatusBar.Index = 1;
			this.menuItemShowStatusBar.Text = "Status Bar";
			this.menuItemShowStatusBar.Click += new System.EventHandler(this.menuItemShowStatusBar_Click);
			// 
			// menuItemShowReportBar
			// 
			this.menuItemShowReportBar.Checked = true;
			this.menuItemShowReportBar.Index = 2;
			this.menuItemShowReportBar.Text = "Report Bar";
			this.menuItemShowReportBar.Click += new System.EventHandler(this.menuItemShowReportBar_Click);
			// 
			// menuItemTopSchedule
			// 
			this.menuItemTopSchedule.Index = 2;
			this.menuItemTopSchedule.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.menuItemLoad,
																								this.menuItemDridSchedule,
																								this.menuItemCapacity,
																								this.menuItem11,
																								this.menuItemReports,
																								this.menuItem13,
																								this.prodSchedulingMenuItem});
			this.menuItemTopSchedule.Text = "Schedule";
			// 
			// menuItemLoad
			// 
			this.menuItemLoad.Index = 0;
			this.menuItemLoad.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1DataTables,
																						 this.menuItem1UploadSchedule});
			this.menuItemLoad.Text = "Load/Upload";
			// 
			// menuItem1DataTables
			// 
			this.menuItem1DataTables.Index = 0;
			this.menuItem1DataTables.Text = "Load Data Tables";
			this.menuItem1DataTables.Click += new System.EventHandler(this.menuItem1DataTables_Click);
			// 
			// menuItem1UploadSchedule
			// 
			this.menuItem1UploadSchedule.Index = 1;
			this.menuItem1UploadSchedule.Text = "Upload Scedule";
			// 
			// menuItemDridSchedule
			// 
			this.menuItemDridSchedule.Index = 1;
			this.menuItemDridSchedule.Text = "Schedule";
			this.menuItemDridSchedule.Click += new System.EventHandler(this.menuItemDridSchedule_Click);
			// 
			// menuItemCapacity
			// 
			this.menuItemCapacity.Index = 2;
			this.menuItemCapacity.Text = "Capacity";
			this.menuItemCapacity.Click += new System.EventHandler(this.menuItemCapacity_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "View Plant Floor";
			// 
			// menuItemReports
			// 
			this.menuItemReports.Index = 4;
			this.menuItemReports.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemHotListReport});
			this.menuItemReports.Text = "Reports";
			// 
			// menuItemHotListReport
			// 
			this.menuItemHotListReport.Index = 0;
			this.menuItemHotListReport.Text = "Hot_List Report";
			this.menuItemHotListReport.Click += new System.EventHandler(this.menuItemHotListReport_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 5;
			this.menuItem13.Text = "Schedule Analysis";
			// 
			// prodSchedulingMenuItem
			// 
			this.prodSchedulingMenuItem.Index = 6;
			this.prodSchedulingMenuItem.Text = "Job Cards";
			this.prodSchedulingMenuItem.Click += new System.EventHandler(this.prodSchedulingMenuItem_Click);
			// 
			// menuItemTopInventory
			// 
			this.menuItemTopInventory.Index = 3;
			this.menuItemTopInventory.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.menuItem16,
																								 this.menuItem17,
																								 this.menuItemFutureInventory,
																								 this.menuItem1PastInventory,
																								 this.menuItem2});
			this.menuItemTopInventory.Text = "Inventory";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 0;
			this.menuItem16.Text = "Days On Hand";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 1;
			this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem95});
			this.menuItem17.Text = "Reports";
			// 
			// menuItem95
			// 
			this.menuItem95.Index = 0;
			this.menuItem95.Text = "Shortage Report";
			this.menuItem95.Click += new System.EventHandler(this.menuItem95_Click);
			// 
			// menuItemFutureInventory
			// 
			this.menuItemFutureInventory.Index = 2;
			this.menuItemFutureInventory.Text = "Future Inventory";
			this.menuItemFutureInventory.Click += new System.EventHandler(this.menuItemFutureInventory_Click);
			// 
			// menuItem1PastInventory
			// 
			this.menuItem1PastInventory.Index = 3;
			this.menuItem1PastInventory.Text = "Past Inventory";
			this.menuItem1PastInventory.Click += new System.EventHandler(this.menuItem1PastInventory_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 4;
			this.menuItem2.Text = "Protected Inventory";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem18,
																					  this.menuItem19,
																					  this.menuItem20,
																					  this.menuItem21,
																					  this.menuItem22,
																					  this.menuItem23});
			this.menuItem4.Text = "Demand";
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 0;
			this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem24,
																					   this.menuItem25,
																					   this.menuItem26,
																					   this.menuItem27,
																					   this.menuItem28});
			this.menuItem18.Text = "Load";
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 0;
			this.menuItem24.Text = "Load All";
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 1;
			this.menuItem25.Text = "Load 862";
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 2;
			this.menuItem26.Text = "Load 830";
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 3;
			this.menuItem27.Text = "Load Forecast";
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 4;
			this.menuItem28.Text = "Review and Use";
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 1;
			this.menuItem19.Text = "View";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 2;
			this.menuItem20.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem50,
																					   this.menuItem51});
			this.menuItem20.Text = "Profile";
			// 
			// menuItem50
			// 
			this.menuItem50.Index = 0;
			this.menuItem50.Text = "Part Defaults";
			// 
			// menuItem51
			// 
			this.menuItem51.Index = 1;
			this.menuItem51.Text = "Customer";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 3;
			this.menuItem21.Text = "Forecast";
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 4;
			this.menuItem22.Text = "Demand Analyzer";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 5;
			this.menuItem23.Text = "Customer Contracts";
			// 
			// menuItem82
			// 
			this.menuItem82.Index = 5;
			this.menuItem82.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem83});
			this.menuItem82.Text = "Sales";
			// 
			// menuItem83
			// 
			this.menuItem83.Index = 0;
			this.menuItem83.Text = "Sales Analysis";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 6;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem29,
																					  this.menuItem30,
																					  this.menuItem31,
																					  this.menuItem32,
																					  this.menuItem33,
																					  this.menuItem34});
			this.menuItem6.Text = "Labour";
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 0;
			this.menuItem29.Text = "Load EMP.data";
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 1;
			this.menuItem30.Text = "Update Org Chart";
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 2;
			this.menuItem31.Text = "Update OT info";
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 3;
			this.menuItem32.Text = "Define Temp Labour";
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 4;
			this.menuItem33.Text = "Review Labour Departments";
			// 
			// menuItem34
			// 
			this.menuItem34.Index = 5;
			this.menuItem34.Text = "Shift info";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 7;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem35,
																					  this.menuItem36,
																					  this.menuItem37,
																					  this.menuItem38,
																					  this.menuItem39});
			this.menuItem7.Text = "Master";
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 0;
			this.menuItem35.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem47,
																					   this.menuItem48,
																					   this.menuItem49});
			this.menuItem35.Text = "Inventory";
			// 
			// menuItem47
			// 
			this.menuItem47.Index = 0;
			this.menuItem47.Text = "Partmaster";
			// 
			// menuItem48
			// 
			this.menuItem48.Index = 1;
			this.menuItem48.Text = "Container Info";
			// 
			// menuItem49
			// 
			this.menuItem49.Index = 2;
			this.menuItem49.Text = "Part Categories";
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 1;
			this.menuItem36.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem52,
																					   this.menuItem53,
																					   this.menuItem54,
																					   this.menuItem55,
																					   this.menuItem56});
			this.menuItem36.Text = "Production";
			// 
			// menuItem52
			// 
			this.menuItem52.Index = 0;
			this.menuItem52.Text = "Plants";
			// 
			// menuItem53
			// 
			this.menuItem53.Index = 1;
			this.menuItem53.Text = "Departments";
			// 
			// menuItem54
			// 
			this.menuItem54.Index = 2;
			this.menuItem54.Text = "Locations";
			// 
			// menuItem55
			// 
			this.menuItem55.Index = 3;
			this.menuItem55.Text = "Product BOM/Routings";
			// 
			// menuItem56
			// 
			this.menuItem56.Index = 4;
			this.menuItem56.Text = "Tools";
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 2;
			this.menuItem37.Text = "Activities";
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 3;
			this.menuItem38.Text = "Shipping";
			// 
			// menuItem39
			// 
			this.menuItem39.Index = 4;
			this.menuItem39.Text = "Reload Master File";
			// 
			// menuItem1topPLC
			// 
			this.menuItem1topPLC.Index = 8;
			this.menuItem1topPLC.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem1RealTimeShopFloor});
			this.menuItem1topPLC.Text = "PLC";
			// 
			// menuItem1RealTimeShopFloor
			// 
			this.menuItem1RealTimeShopFloor.Index = 0;
			this.menuItem1RealTimeShopFloor.Text = "Real Time Shop Floor ";
			this.menuItem1RealTimeShopFloor.Click += new System.EventHandler(this.menuItem1RealTimeShopFloor_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 9;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem90,
																					  this.menuItem91});
			this.menuItem8.Text = "Financials";
			// 
			// menuItem90
			// 
			this.menuItem90.Index = 0;
			this.menuItem90.Text = "Currency";
			this.menuItem90.Click += new System.EventHandler(this.menuItem90_Click);
			// 
			// menuItem91
			// 
			this.menuItem91.Index = 1;
			this.menuItem91.Text = "Dayly Exchange";
			this.menuItem91.Click += new System.EventHandler(this.menuItem91_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 10;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem40,
																					  this.menuItem41,
																					  this.menuItem42,
																					  this.menuItem43,
																					  this.menuItem44,
																					  this.menuItem45,
																					  this.menuItem46});
			this.menuItem9.Text = "Options";
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 0;
			this.menuItem40.Text = "Schedule Control";
			// 
			// menuItem41
			// 
			this.menuItem41.Index = 1;
			this.menuItem41.Text = "Part Controls";
			// 
			// menuItem42
			// 
			this.menuItem42.Index = 2;
			this.menuItem42.Text = "Machine Groups";
			// 
			// menuItem43
			// 
			this.menuItem43.Index = 3;
			this.menuItem43.Text = "Tools";
			// 
			// menuItem44
			// 
			this.menuItem44.Index = 4;
			this.menuItem44.Text = "Colours";
			// 
			// menuItem45
			// 
			this.menuItem45.Index = 5;
			this.menuItem45.Text = "Capacity Rules";
			// 
			// menuItem46
			// 
			this.menuItem46.Index = 6;
			this.menuItem46.Text = "Schedule Rulls";
			// 
			// menuItemTopSaleAnalysis
			// 
			this.menuItemTopSaleAnalysis.Index = 11;
			this.menuItemTopSaleAnalysis.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									this.menuItemSchedule,
																									this.menuItemShowChildForm});
			this.menuItemTopSaleAnalysis.Text = "Actions";
			// 
			// menuItemSchedule
			// 
			this.menuItemSchedule.Index = 0;
			this.menuItemSchedule.Text = "Schedule";
			this.menuItemSchedule.Click += new System.EventHandler(this.menuItemSchedule_Click);
			// 
			// menuItemShowChildForm
			// 
			this.menuItemShowChildForm.Index = 1;
			this.menuItemShowChildForm.Text = "Show Child Form";
			this.menuItemShowChildForm.Click += new System.EventHandler(this.menuItemShowChildForm_Click);
			// 
			// reportsMenuItem
			// 
			this.reportsMenuItem.Index = 12;
			this.reportsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.queryMenuItem,
																							this.maintenanceMenuItem});
			this.reportsMenuItem.Text = "Reports";
			// 
			// queryMenuItem
			// 
			this.queryMenuItem.Index = 0;
			this.queryMenuItem.Text = "Query";
			this.queryMenuItem.Click += new System.EventHandler(this.queryMenuItem_Click);
			// 
			// maintenanceMenuItem
			// 
			this.maintenanceMenuItem.Index = 1;
			this.maintenanceMenuItem.Text = "Maintenance";
			this.maintenanceMenuItem.Click += new System.EventHandler(this.maintenanceMenuItem_Click);
			// 
			// menuItemTopTools
			// 
			this.menuItemTopTools.Index = 13;
			this.menuItemTopTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuItemUserManagement,
																							 this.menuItemPassword});
			this.menuItemTopTools.Text = "Tools";
			// 
			// menuItemUserManagement
			// 
			this.menuItemUserManagement.Index = 0;
			this.menuItemUserManagement.Text = "User Management";
			this.menuItemUserManagement.Click += new System.EventHandler(this.menuItemUserManagement_Click);
			// 
			// menuItemPassword
			// 
			this.menuItemPassword.Index = 1;
			this.menuItemPassword.Text = "Change Password";
			this.menuItemPassword.Click += new System.EventHandler(this.menuItemPassword_Click);
			// 
			// menuItemTopWindows
			// 
			this.menuItemTopWindows.Index = 14;
			this.menuItemTopWindows.MdiList = true;
			this.menuItemTopWindows.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.menuItemCascade,
																							   this.menuItemHoriz,
																							   this.menuItemVert,
																							   this.menuItem5,
																							   this.menuItemMax,
																							   this.menuItemMin});
			this.menuItemTopWindows.MergeOrder = 100;
			this.menuItemTopWindows.Text = "Windows";
			// 
			// menuItemCascade
			// 
			this.menuItemCascade.Index = 0;
			this.menuItemCascade.Text = "Cascade";
			this.menuItemCascade.Click += new System.EventHandler(this.menuItemCascade_Click);
			// 
			// menuItemHoriz
			// 
			this.menuItemHoriz.Index = 1;
			this.menuItemHoriz.Text = "Tile &Horizontally";
			this.menuItemHoriz.Click += new System.EventHandler(this.menuItemHoriz_Click);
			// 
			// menuItemVert
			// 
			this.menuItemVert.Index = 2;
			this.menuItemVert.Text = "Tile &Vertically";
			this.menuItemVert.Click += new System.EventHandler(this.menuItemVert_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// menuItemMax
			// 
			this.menuItemMax.Index = 4;
			this.menuItemMax.Text = "Maximize All";
			this.menuItemMax.Click += new System.EventHandler(this.menuItemMax_Click);
			// 
			// menuItemMin
			// 
			this.menuItemMin.Index = 5;
			this.menuItemMin.Text = "Minimize All";
			this.menuItemMin.Click += new System.EventHandler(this.menuItemMin_Click);
			// 
			// menuItemTopHelp
			// 
			this.menuItemTopHelp.Index = 15;
			this.menuItemTopHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemRegister,
																							this.menuItem1});
			this.menuItemTopHelp.Text = "Help";
			// 
			// menuItemRegister
			// 
			this.menuItemRegister.Index = 0;
			this.menuItemRegister.Text = "Register NujitERP ...";
			this.menuItemRegister.Click += new System.EventHandler(this.menuItemRegister_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "Update ";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click_1);
			// 
			// toolBarMain
			// 
			this.toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBarMain.ButtonSize = new System.Drawing.Size(32, 32);
			this.toolBarMain.DropDownArrows = true;
			this.toolBarMain.Location = new System.Drawing.Point(0, 0);
			this.toolBarMain.Name = "toolBarMain";
			this.toolBarMain.ShowToolTips = true;
			this.toolBarMain.Size = new System.Drawing.Size(1012, 38);
			this.toolBarMain.TabIndex = 0;
			this.toolBarMain.Visible = false;
			// 
			// statusBarMain
			// 
			this.statusBarMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.statusBarMain.Location = new System.Drawing.Point(0, 651);
			this.statusBarMain.Name = "statusBarMain";
			this.statusBarMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																							 this.statusBarPanelMessage,
																							 this.statusBarPanelUser,
																							 this.statusBarPanelDate});
			this.statusBarMain.ShowPanels = true;
			this.statusBarMain.Size = new System.Drawing.Size(1012, 24);
			this.statusBarMain.TabIndex = 2;
			// 
			// statusBarPanelMessage
			// 
			this.statusBarPanelMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelMessage.MinWidth = 100;
			this.statusBarPanelMessage.Text = "Message";
			this.statusBarPanelMessage.Width = 796;
			// 
			// statusBarPanelUser
			// 
			this.statusBarPanelUser.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanelUser.MinWidth = 100;
			// 
			// statusBarPanelDate
			// 
			this.statusBarPanelDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanelDate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.statusBarPanelDate.MinWidth = 100;
			this.statusBarPanelDate.Text = "Date";
			// 
			// pnlWindowsBar
			// 
			this.pnlWindowsBar.Controls.Add(this.ctlTab);
			this.pnlWindowsBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlWindowsBar.Location = new System.Drawing.Point(0, 619);
			this.pnlWindowsBar.Name = "pnlWindowsBar";
			this.pnlWindowsBar.Size = new System.Drawing.Size(1012, 32);
			this.pnlWindowsBar.TabIndex = 5;
			// 
			// ctlTab
			// 
			this.ctlTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.ctlTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlTab.Location = new System.Drawing.Point(0, 0);
			this.ctlTab.Name = "ctlTab";
			this.ctlTab.SelectedIndex = 0;
			this.ctlTab.Size = new System.Drawing.Size(1012, 32);
			this.ctlTab.TabIndex = 0;
			// 
			// imageListTabPage
			// 
			this.imageListTabPage.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListTabPage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabPage.ImageStream")));
			this.imageListTabPage.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1012, 675);
			this.Controls.Add(this.pnlWindowsBar);
			this.Controls.Add(this.statusBarMain);
			this.Controls.Add(this.toolBarMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenuMain;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nujit Utility";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.OnClosing);
			this.MdiChildActivate += new System.EventHandler(this.FormMain_MdiChildActivate);
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelUser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDate)).EndInit();
			this.pnlWindowsBar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		
		#endregion
	
		private string companyName;

		[STAThread]
//		static void Main() 
//		{
//			Configuration.OnApplicationStart();
//			Application.Run(new FormMain());
//		}
		
		#region Tab and Logo

//		private void MdiBackground_Paint(Object s, PaintEventArgs e)
//		{
//			Control c = (Control)s;
//
//			Rectangle r1 = c.ClientRectangle;
//			r1.Width -= 4;
//			r1.Height -= 4;
//
//			Rectangle r2 = r1;
//			r2.Width -= 1;
//			r2.Height -= 1;
//
//			Font f = new Font("Tahoma", 8);
//
//			String str = "Nujit Utility --- 2004 Nujit.Com";
//
//			StringFormat sf = new StringFormat();
//			sf.Alignment = StringAlignment.Far;
//			sf.LineAlignment = StringAlignment.Far;
//
//			e.Graphics.DrawString(str, f, new SolidBrush(SystemColors.ControlDarkDark), r1, sf);
//			e.Graphics.DrawString(str, f, new SolidBrush(SystemColors.ControlLight), r2, sf);
//		}


		private void MdiBackground_Resize(Object s, EventArgs e)
		{
			Control c = (Control)s;
			c.Invalidate();
		}

		private void ctlTab_MouseUp(Object s, MouseEventArgs e)
		{
			Form frm = (Form)ctlTab.SelectedTab.Tag;
			frm.Activate();
		}

		public void RemoveTab(Object o)
		{
			TabPage tp = (TabPage)o;
			ctlTab.TabPages.Remove(tp);
		}
		

		#endregion Tab and Logo

		#region framework functions

		private void menuItemClose_Click(object sender, System.EventArgs e)
		{
			CloseActiveForm();
		}
		private void CloseActiveForm()
		{
			try
			{
				//Gets the currently active MDI child window.
				Form activeForm = this.ActiveMdiChild;
				//Close the MDI child window
				activeForm.Close();
			}
			catch{};
		}


		private void menuItemCloseAll_Click(object sender, System.EventArgs e)
		{
			CloseAllForms();
		}

		private void CloseAllForms()
		{

			Form [] formChilden= this.MdiChildren;

			foreach (Form chform in formChilden)
				chform.Close();
		}

				
		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
		public void SetButtons()
		{
			//Active forms exist?
			Form [] formChilden= this.MdiChildren;

			int childCounter =0;

			childCounter = formChilden.Length;

			if (childCounter == 0 || this.ActiveMdiChild == null)
			{
				this.menuItemCascade.Enabled	=false;
				this.menuItemHoriz.Enabled		=false;
				this.menuItemVert.Enabled		=false;
				this.menuItemMax.Enabled		=false;
				this.menuItemMin.Enabled		=false;
				this.menuItemClose.Enabled		=false;
				this.menuItemCloseAll.Enabled	=false;
			}
			else if (childCounter == 1) 
			{
				this.menuItemCascade.Enabled	=false;
				this.menuItemHoriz.Enabled		=false;
				this.menuItemVert.Enabled		=false;
				this.menuItemMax.Enabled		=true;
				this.menuItemMin.Enabled		=true;
				this.menuItemClose.Enabled		=true;
				this.menuItemCloseAll.Enabled	=true;
				
			}else
			{
				this.menuItemCascade.Enabled	=true;
				this.menuItemHoriz.Enabled		=true;
				this.menuItemVert.Enabled		=true;
				this.menuItemMax.Enabled		=true;
				this.menuItemMin.Enabled		=true;
				this.menuItemClose.Enabled		=true;
				this.menuItemCloseAll.Enabled	=true;
			}

			return;
		
		}
		

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			this.statusBarMain.Visible      = true;
			this.statusBarPanelDate.Text    = System.DateTime.Now.ToShortDateString();
			this.statusBarPanelMessage.Text = "Ready";
			this.ShowFormMaster();

			launchUpdater();
		    this.statusBarPanelUser.Text    = Operator.getLoginName();
		}


		private void FormMain_MdiChildActivate(object sender, System.EventArgs e)
		{
			OnMdiChildActivate();
		}

		private void OnMdiChildActivate()
		{	
			if (this.MdiChildren.Length > 0 && this.ActiveMdiChild != null)
			{
				this.statusBarPanelMessage.Text = ((Form)this.ActiveMdiChild).Text;

				TabPage tp =  (TabPage)this.ActiveMdiChild.Tag;
				ctlTab.SelectedTab = tp;
			}
			else
				this.statusBarPanelMessage.Text = "Ready";

			this.SetButtons();
		}

		private 
		void OnClosing(object sender, System.ComponentModel.CancelEventArgs e){
			if (FormMain.returnCode == 0){
				DialogResult exitConfirm = MessageBox.Show("\n       Do you really want to exit?            \n\n\n","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if (exitConfirm == DialogResult.No){
					e.Cancel = true;
				}else{
					this.CloseAllForms();
					Engine.getInstance().stop();
					Application.Exit();
				}
			}else{
				this.CloseAllForms();
				Application.Exit();
			}
		}
			

		#endregion framework functions

		#region Windows layout

		private void menuItemCascade_Click(object sender, System.EventArgs e)
		{
			//Cascade all child forms.
			this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
		}
		private void menuItemHoriz_Click(object sender, System.EventArgs e)
		{
			//Tile all child forms horizontally.
			this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
		}

		private void menuItemVert_Click(object sender, System.EventArgs e)
		{			
			//Tile all child forms vertically.
			this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
		}

		private void menuItemMax_Click(object sender, System.EventArgs e)
		{
			//Gets forms that represent the MDI child forms 
			//that are parented to this form in an array
			Form [] formChilden= this.MdiChildren;

			//for each child form set the window state to Maximized
			foreach (Form chform in formChilden)
			
				chform.WindowState=FormWindowState.Maximized;
		}

		private void menuItemMin_Click(object sender, System.EventArgs e)
		{
			//Gets forms that represent the MDI child forms 
			//that are parented to this form in an array
			Form [] formChilden= this.MdiChildren;

			//for each child form set the window state to Minimized
			foreach (Form chform in formChilden)
				chform.WindowState=FormWindowState.Minimized;
		}


		#endregion Windows layout
		
		#region View Top level Menu

		private void menuItemShowToolBar_Click(object sender, System.EventArgs e)
		{
			this.toolBarMain.Visible = menuItemShowToolBar.Checked = !this.toolBarMain.Visible;
		}

		private void menuItemShowStatusBar_Click(object sender, System.EventArgs e)
		{
			this.statusBarMain.Visible = this.menuItemShowStatusBar.Checked =!this.statusBarMain.Visible;
		}

		private void menuItemShowReportBar_Click(object sender, System.EventArgs e)
		{
			this.pnlWindowsBar.Visible = this.menuItemShowReportBar.Checked = !this.pnlWindowsBar.Visible;
		}


		#endregion View Top level Menu

		#region ChildForm

		private void menuItemShowChildForm_Click(object sender, System.EventArgs e)
		{
			FormChildForm form = new FormChildForm();
			
			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm.GetType().IsInstanceOfType(form))
				{
					objForm.Activate();
			
					return;
				}
			}

			//foreach (Form objForm in this)
			ShowChildForm();
		}

		private void ShowChildForm()
		{
			FormChildForm form = new FormChildForm(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Child Form";//strFileName;
			ctlPage.Text        = "Child Form "; //strShortName + " ";
			ctlPage.ImageIndex  = 0;
			ctlPage.Tag         = form;
			form.Tag            = ctlPage;
			ctlTab.TabPages.Add(ctlPage);

			form.Show();
		}

		
		#endregion ChildForm

		private void menuItemSchedule_Click(object sender, System.EventArgs e)
		{
			//ShowFormSchedule();
		}

//		private void ShowFormSchedule()
//		{
//			foreach (Form objForm in this.MdiChildren)
//			{
//				if (objForm is FormSchedule)
//				{
//					objForm.Activate();
//			
//					return;
//				}
//			}
//
//			FormSchedule form = new FormSchedule(this);
//
//			form.MdiParent      = this;
//
//			TabPage ctlPage     = new TabPage();
//			ctlPage.ToolTipText = "Schedule";//strFileName;
//			ctlPage.Text        = "Schedule "; //strShortName + " ";
//			ctlPage.ImageIndex  = 0;
//			ctlPage.Tag         = form;
//			form.Tag            = ctlPage;
//			ctlTab.TabPages.Add(ctlPage);
//			form.Show();
//			
//		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
		
		}

		public void ShowFormSearchOrder()
		{
			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is FormOrderSearch)
				{
					objForm.Activate();
			
					return;
				}
			}

			FormOrderSearch form = new FormOrderSearch(this, Operator.getLoginName());

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Order Entry";//strFileName;
			ctlPage.Text        = "Order Entry  "; //strShortName + " ";
			ctlPage.ImageIndex  = 2;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();
			
		}

		private void ShowFormDemo()
		{
			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is FormDemo)
				{
					objForm.Activate();
			
					return;
				}
			}

			FormDemo form = new FormDemo(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Demo";//strFileName;
			ctlPage.Text        = "Demo "; //strShortName + " ";
			ctlPage.ImageIndex  = 0;
			ctlPage.Tag         = form;
			form.Tag            = ctlPage;
			ctlTab.TabPages.Add(ctlPage);
			form.Show();
			
		}


		public void ShowFormUpLoadHotList()
		{
//			foreach (Form objForm in this.MdiChildren)
//			{
//				if (objForm is FormUpLoadHotList)
//				{
//					objForm.Activate();
//			
//					return;
//				}
//			}
//
//			FormUpLoadHotList form = new FormUpLoadHotList(this);
//
//			form.MdiParent      = this;
//
//			TabPage ctlPage     = new TabPage();
//			ctlPage.ToolTipText = "Cms Transfer";//strFileName;
//			ctlPage.Text        = "Cms Transfer"; //strShortName + " ";
//			ctlPage.ImageIndex  = 0;
//			ctlPage.Tag         = form;
//
//			form.Tag            = ctlPage;
//
//			ctlTab.TabPages.Add(ctlPage);
//			form.Show();

			DataTransfer dt = new DataTransfer();
			dt.Show();
			
		}


		private void menuItem1DataTables_Click(object sender, System.EventArgs e)
		{
		     ShowFormUpLoadHotList();
		}

		private void menuItemCapacity_Click(object sender, System.EventArgs e)
		{
			ShowFormMaster();
		}
		private void ShowFormMaster()
		{
			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is FormMaster)
				{
					objForm.Activate();
			
					return;
				}
			}

			FormMaster form = new FormMaster(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Capacity Configurator";//strFileName;
			ctlPage.Text        = "Cap. config  "; //strShortName + " ";
			ctlPage.ImageIndex  = 2;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();
			
		}

		private void menuItemDridSchedule_Click(object sender, System.EventArgs e)	{
			ShowSchedule();
		}

		public void ShowSchedule() 	{
			foreach (Form objForm in this.MdiChildren){
				if (objForm is GridForm){
					objForm.Activate();
					return;
				}
			}

			GridForm form = new GridForm(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Scheduling";//strFileName;
			ctlPage.Text        = "Schedule "; //strShortName + " ";
			ctlPage.ImageIndex  = 1;
			ctlPage.Tag         = form;
			form.Tag            = ctlPage;
			ctlTab.TabPages.Add(ctlPage);
			form.Show();
		}


		private void menuItemHotListReport_Click(object sender, System.EventArgs e)
		{
			HotListReportCaller formHotListReportCaller = new HotListReportCaller("Report", false, false);
			formHotListReportCaller.ShowDialog();
			formHotListReportCaller.Dispose();
			
		}

		

		#region User Management

		private void menuItemUserManagement_Click(object sender, System.EventArgs e)
		{
			ShowUserAdmForm();
		}

		private void menuItemPassword_Click(object sender, System.EventArgs e)
		{
			ShowChangePasswordForm();
		}

		public void ShowUserAdmForm()
		{
			if (Operator.getType().ToUpper() == "ADMIN" || Operator.getType().ToUpper() == "NUJIT") 
			{
				FormUserAdm objForm = new FormUserAdm();
				//objForm.Operator  = Operator ;
				objForm.ShowDialog();
				objForm.Dispose();
			}
		}

	

		private void ShowChangePasswordForm()
		{
			if (Operator != null)
			{
				FormChangePassword objFormChangePassword = new FormChangePassword();
				FormChangePassword.Operator            = Operator;
				objFormChangePassword.ShowDialog();
				objFormChangePassword.Dispose();
			}
		}


		#endregion User Management

		private void menuItemFutureInventory_Click(object sender, System.EventArgs e)
		{
/*			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is FutureInventory)
				{
					objForm.Activate();
			
					return;
				}
			}

			FutureInventory form = new FutureInventory(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Future Inventory";//strFileName;
			ctlPage.Text        = "FutureInventory "; //strShortName + " ";
			ctlPage.ImageIndex  = 3;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();
*/
		
			FutureInventory form = new FutureInventory();
			form.Show();
		}

		private void menuItem1PastInventory_Click(object sender, System.EventArgs e)
		{
/*			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is PastInventory)
				{
					objForm.Activate();
			
					return;
				}
			}

			PastInventory form = new PastInventory(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Past Inventory";
			ctlPage.Text        = "Past Inventory "; 
			ctlPage.ImageIndex  = 4;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();
*/
			PastInventory form = new PastInventory();
			form.Show();
		}

		private void menuItem1RealTimeShopFloor_Click(object sender, System.EventArgs e)
		{
	
			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is RealTimePress)
				{
					objForm.Activate();
						
					return;
				}
			}

			RealTimePress form = new RealTimePress(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Past Inventory";
			ctlPage.Text        = "Past Inventory "; 
			ctlPage.ImageIndex  = 5;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();
	  }


		private 
		void menuItem19_Click(object sender, System.EventArgs e){
    		foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is CustomerDemandForm)
				{
					objForm.Activate();
			
					return;
				}
			}

			CustomerDemandForm form = new CustomerDemandForm(this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Customer Demand";//strFileName;
			ctlPage.Text        = "Customer Demand "; //strShortName + " ";
			ctlPage.ImageIndex  = 3;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();
//			CustomerDemandForm form = new CustomerDemandForm();
//			form.Show();
		}

		private 
		void menuItem16_Click(object sender, System.EventArgs e){
			
/*			foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is DaysOnHandForm)
				{
					objForm.Activate();
			
					return;
				}
			}

			DaysOnHandForm form = new DaysOnHandForm();

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Days on hand";//strFileName;
			ctlPage.Text        = "Days on hand "; //strShortName + " ";
			ctlPage.ImageIndex  = 3;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();
*/			
//			

			DaysOnHandForm form = new DaysOnHandForm();
			form.Show();
		}

		private 
		void menuItem22_Click(object sender, System.EventArgs e){

      		foreach (Form objForm in this.MdiChildren)
			{
				if (objForm is MatReleaseHistoricalForm )
				{
					objForm.Activate();
			
					return;
				}
			}

			MatReleaseHistoricalForm  form = new MatReleaseHistoricalForm (this);

			form.MdiParent      = this;

			TabPage ctlPage     = new TabPage();
			ctlPage.ToolTipText = "Demand";
			ctlPage.Text        = "Demand "; 
			ctlPage.ImageIndex  = 6;
			ctlPage.Tag         = form;

			form.Tag            = ctlPage;

			ctlTab.TabPages.Add(ctlPage);
			form.Show();

//			MatReleaseHistoricalForm form = new MatReleaseHistoricalForm();
//			form.Show();
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void menuItemRegister_Click(object sender, System.EventArgs e)
		{
			Nujit.NujitERP.WinForms.Register.FormRegister formRegister = new Nujit.NujitERP.WinForms.Register.FormRegister();
			formRegister.ShowDialog();
			formRegister.Close();
		}
	
public void ShowItemsForm() {
	foreach (Form objForm in this.MdiChildren){
		if (objForm is FormItems){
			objForm.Activate();
			return;
		}
	}

	FormItems form = new FormItems(this);
	form.MdiParent      = this;
	TabPage ctlPage     = new TabPage();
	ctlPage.ToolTipText = "Items";//strFileName;
	ctlPage.Text        = "Items "; //strShortName + " ";
	ctlPage.ImageIndex  = 1;
	ctlPage.Tag         = form;
	form.Tag            = ctlPage;
	ctlTab.TabPages.Add(ctlPage);
	form.Show();
			
}

// add by Claudia Melo
public void ShowNewHotList() {
	foreach (Form objForm in this.MdiChildren){
		if (objForm is HotListForm){
			objForm.Activate();
			return;
		}
	}

	HotListForm form = new HotListForm(this);
	form.MdiParent      = this;
	TabPage ctlPage     = new TabPage();
	ctlPage.ToolTipText = "HotList";//strFileName;
	ctlPage.Text        = "Hot List "; //strShortName + " ";
	ctlPage.ImageIndex  = 1;
	ctlPage.Tag         = form;
	form.Tag            = ctlPage;
	ctlTab.TabPages.Add(ctlPage);
	form.Show();
	
			
}//end
public void ShowChartsAndReports() {
	foreach (Form objForm in this.MdiChildren){
		if (objForm is FormItems){
			objForm.Activate();
			return;
		}
	}

	FormChartsAndReports form = new FormChartsAndReports(this);
	form.MdiParent      = this;
	TabPage ctlPage     = new TabPage();
	ctlPage.ToolTipText = "Chart and Reports";//strFileName;
	ctlPage.Text        = "Chart and Reports"; //strShortName + " ";
	ctlPage.ImageIndex  = 1;
	ctlPage.Tag         = form;
	form.Tag            = ctlPage;
	ctlTab.TabPages.Add(ctlPage);
	form.Show();
			
}

	private void menuItem57_Click_1(object sender, System.EventArgs e)
	{
	
	}

	private void menuItem89_Click(object sender, System.EventArgs e)
	{
		//FormEditLabVariables formEditLabVariables = new FormEditLabVariables();

		//formEditLabVariables.ShowDialog();
	}

    private void menuItem90_Click(object sender, System.EventArgs e){
        CurrencyEditForm currencyEditForm= new CurrencyEditForm();
        currencyEditForm.ShowDialog();
        
    }

    private void menuItem91_Click(object sender, System.EventArgs e)    {
        CurrencyDlyExcEditForm currencyDlyExcEditForm = new CurrencyDlyExcEditForm(Operator.getLoginName());
        currencyDlyExcEditForm.ShowDialog();
    }

        private void menuItem95_Click(object sender, System.EventArgs e)
        {
            GenReportForm genReportForm = new GenReportForm();
            genReportForm.ShowDialog();
        }


private
void launchUpdater(){
#if !DEBUG
	try{
		this.appUpdater1 = new AppUpdater.AppUpdater(this.components);
		this.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.appUpdater1)).BeginInit();
		this.appUpdater1.AutoFileLoad = true;
		this.appUpdater1.Poller.DownloadOnDetection = false;
		this.appUpdater1.Poller.PollInterval = 3600;
		this.appUpdater1.Downloader.DownloadRetryAttempts = 1;
		this.appUpdater1.Downloader.UpdateRetryAttempts = 1;
		this.appUpdater1.UpdateUrl = "http://www.nujit.com/Nujit_WebService/WebService/UpdateService.asmx";
		this.appUpdater1.OnCheckForUpdate += new AppUpdater.AppUpdater.CheckForUpdateEventHandler(this.appUpdater1_OnCheckForUpdate);
		this.appUpdater1.OnUpdateDetected += new AppUpdater.AppUpdater.UpdateDetectedEventHandler(this.appUpdater1_OnUpdateDetected);
		this.appUpdater1.OnUpdateComplete += new AppUpdater.AppUpdater.UpdateCompleteEventHandler(this.appUpdater1_OnUpdateComplete);
		((System.ComponentModel.ISupportInitialize)(this.appUpdater1)).EndInit();
		this.ResumeLayout();
	}catch(Exception ex){
		using (FormException frmEx = new FormException(ex))
			frmEx.ShowDialog();
	}
#endif
}

private 
bool appUpdater1_OnCheckForUpdate(object sender, System.EventArgs e){
	try{
		bool updateAvailable;
		string updateUrl;

		NujitWebService.UpdateService updateService = new NujitWebService.UpdateService();
		updateService.Url = "http://www.nujit.com/Nujit_WebService/WebService/UpdateService.asmx";
		updateAvailable = updateService.CheckForUpdateERP(AppUpdater.AppUpdater.GetLatestInstalledVersion().ToString(), companyName, out updateUrl);
		if (updateAvailable == true)
			appUpdater1.UpdateUrl = updateUrl;

		return updateAvailable;
	}catch(Exception ex){
		if (userUpdate){
			FormException frmEx = new FormException(ex);
			frmEx.ShowDialog();
		}
		return false;
	}
}

private 
void appUpdater1_OnUpdateComplete(object sender, AppUpdater.UpdateCompleteEventArgs e){
	try{
		wait.Close();
		wait.Dispose();

		if (e.UpdateSucceeded){
			string message = "An update was completed. Do you want to start using the new udpate now?";

			if (MessageBox.Show(message,"Update Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes){
				FormMain.returnCode = AppUpdater.AppUpdater.RestartAppReturnValue;
				this.Close();
			}
		}else{
			string message = "An attempt to udpate this application failed.  This applicaiton will attempt to update itself the next time the app is run.";
			MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}catch(Exception ex){
		FormException frmEx = new FormException(ex);
		frmEx.ShowDialog();
	}
}

private 
void appUpdater1_OnUpdateDetected(object sender, System.EventArgs e){
	try{
		string message = "An update was detected. Do you want to download the udpate now?";

		if (MessageBox.Show(message,"Update Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes){
			appUpdater1.DownloadUpdate();
			wait.ShowDialog();
		}
	}catch(Exception ex){
		FormException frmEx = new FormException(ex);
		frmEx.ShowDialog();
	}
}

private 
void menuItem1_Click_1(object sender, System.EventArgs e){
	userUpdate = true;
	if (!appUpdater1.CheckForUpdates())
		MessageBox.Show("There aren't updates.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
	userUpdate = false;
}

private 
void queryMenuItem_Click(object sender, System.EventArgs e){
	ShowReportsQueryExcelForm();
}

private 
void maintenanceMenuItem_Click(object sender, System.EventArgs e){
	ShowReportsMaintenanceForm();
}

public 
void ShowReportsQueryExcelForm(){
	ExcelReportsQueryForm form = new ExcelReportsQueryForm();
	form.Show();
}

public 
void ShowReportsMaintenanceForm(){
	ExcelReportsMaintenanceForm form = new ExcelReportsMaintenanceForm();
	form.Show();
}

private 
void prodSchedulingMenuItem_Click(object sender, System.EventArgs e){
	SchLogSearchForm form = new SchLogSearchForm();
	form.ShowDialog();
}


}
}
