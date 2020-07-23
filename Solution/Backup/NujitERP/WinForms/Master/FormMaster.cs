using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.CustomDataGrid; 
//using Nujit.NujitERP.ClassLib.Master;
using Nujit.NujitERP.WinForms.CustomControls;
using Nujit.NujitERP.WinForms;
using Nujit.NujitERP.WinForms.Master.Production;
using GridScheduling.gui.schedule;
using Nujit.NujitERP.WinForms.Schedule;
using Nujit.NujitERP.WinForms.Schedule.LoadUpLoad;
using Nujit.NujitERP.WinForms.Schedule.HotList;
using Nujit.NujitERP.WinForms.CapacityModule;

namespace Nujit.NujitERP.WinForms.Master
{
/// <summary>
/// Summary description for FormMaster.
/// </summary>
	public class FormMaster : System.Windows.Forms.Form
	{
		private enum Result
		{
			NOTHING = 0,
			DELETED = 1,
			UPDATED = 2
		}

	#region Vars

	private System.Windows.Forms.Panel pnlLeftTree;
	private System.Windows.Forms.Panel pnlRightBottom;
	private System.Windows.Forms.Splitter splitterLeftRight;

//	private System.Windows.Forms.Splitter splitterRightMiddleBottom;
	
	private System.Windows.Forms.TreeView treeViewLeft;
	private System.Windows.Forms.MenuItem menuItem10;
	private System.Windows.Forms.ContextMenu cxMenuTree;
	private System.Windows.Forms.MenuItem cMnuItemAddDept;
	private System.Windows.Forms.MenuItem cMnuItemEditDept;
	private System.Windows.Forms.MenuItem cMnuItemDeleteDept;
	private System.Windows.Forms.MenuItem cMnuItemAddMac;
	private System.Windows.Forms.MenuItem cMnuItemEditMac;
	private System.Windows.Forms.MenuItem cMnuItemDeleteMac;
	private System.Windows.Forms.MenuItem cMnuItemRefesh;
	private System.Windows.Forms.MenuItem cMnuItemAddPlt;
	private System.Windows.Forms.MenuItem cMnuItemEditPlant;
	private System.Windows.Forms.MenuItem cMnuItemDeletePlant;
	private System.Windows.Forms.MenuItem menuItem1;
	private System.Windows.Forms.MenuItem menuItem2;

	private System.Windows.Forms.MenuItem menuItem6;
	private System.Windows.Forms.MenuItem cMnuItemAddCfg;
	private System.Windows.Forms.MenuItem cMnuItemEditCfg;
	private System.Windows.Forms.MenuItem cMnuItemDeleteCfg;
	private System.Windows.Forms.MenuItem cMnuItemAddRemoveMachFromCfg;
	private System.ComponentModel.IContainer components;
	private System.Windows.Forms.MenuItem cMnuItemAddShift;
	private System.Windows.Forms.MenuItem cMnuItemEditShift;
	private System.Windows.Forms.MenuItem cMnuItemCopyShift;
	private System.Windows.Forms.MenuItem cMnuItemMoveShift;
	private System.Windows.Forms.PictureBox picBoxScheduling;
	private System.Windows.Forms.PictureBox picBoxCapacity;
	private System.Windows.Forms.PictureBox picBoxUsers;
	private System.Windows.Forms.PictureBox picBoxShifts;
	private System.Windows.Forms.PictureBox picBoxDataTransfer;
	private System.Windows.Forms.ToolTip toolTip1;
	private System.Windows.Forms.ImageList imageList1;
	private System.Windows.Forms.ToolTip toolTip2;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.MenuItem cMnuItemMacCapacity;
	private System.Windows.Forms.PictureBox pictureBox1;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.PictureBox pictureBox2;
	private System.Windows.Forms.PictureBox pictureBoxProduction;
	private System.Windows.Forms.PictureBox pictureBoxChartReports;
	private System.Windows.Forms.Label labelChart;
	private System.Windows.Forms.PictureBox pictureBox3;
	private System.Windows.Forms.MenuItem menuItemSep;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Label labelOrders;
		private System.Windows.Forms.Label labelProduction;
		private System.Windows.Forms.Label labelItems;
		private System.Windows.Forms.Label labelDataTransfer;
		private System.Windows.Forms.Label labelShifts;
		private System.Windows.Forms.Label labelPersons;
		private System.Windows.Forms.Label labelUsers;

	private FormMain formMainParent;

	#endregion Vars

	#region Constructors 

public FormMaster(FormMain formParent){
	InitializeComponent();

	this.MdiParent = formParent;
	this.formMainParent = formParent;
}

public FormMaster(){
	InitializeComponent();

	// TODO: Add any constructor code after InitializeComponent call
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
protected override void Dispose( bool disposing )
{
	if( disposing )
	{
		if(components != null)
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
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMaster));
		this.pnlLeftTree = new System.Windows.Forms.Panel();
		this.treeViewLeft = new System.Windows.Forms.TreeView();
		this.cxMenuTree = new System.Windows.Forms.ContextMenu();
		this.cMnuItemAddPlt = new System.Windows.Forms.MenuItem();
		this.cMnuItemEditPlant = new System.Windows.Forms.MenuItem();
		this.cMnuItemDeletePlant = new System.Windows.Forms.MenuItem();
		this.menuItem1 = new System.Windows.Forms.MenuItem();
		this.cMnuItemAddDept = new System.Windows.Forms.MenuItem();
		this.cMnuItemEditDept = new System.Windows.Forms.MenuItem();
		this.cMnuItemDeleteDept = new System.Windows.Forms.MenuItem();
		this.menuItem2 = new System.Windows.Forms.MenuItem();
		this.cMnuItemAddCfg = new System.Windows.Forms.MenuItem();
		this.cMnuItemEditCfg = new System.Windows.Forms.MenuItem();
		this.cMnuItemDeleteCfg = new System.Windows.Forms.MenuItem();
		this.cMnuItemAddRemoveMachFromCfg = new System.Windows.Forms.MenuItem();
		this.menuItem6 = new System.Windows.Forms.MenuItem();
		this.cMnuItemAddMac = new System.Windows.Forms.MenuItem();
		this.cMnuItemEditMac = new System.Windows.Forms.MenuItem();
		this.cMnuItemDeleteMac = new System.Windows.Forms.MenuItem();
		this.cMnuItemMacCapacity = new System.Windows.Forms.MenuItem();
		this.menuItem10 = new System.Windows.Forms.MenuItem();
		this.cMnuItemAddShift = new System.Windows.Forms.MenuItem();
		this.cMnuItemEditShift = new System.Windows.Forms.MenuItem();
		this.cMnuItemCopyShift = new System.Windows.Forms.MenuItem();
		this.cMnuItemMoveShift = new System.Windows.Forms.MenuItem();
		this.menuItemSep = new System.Windows.Forms.MenuItem();
		this.cMnuItemRefesh = new System.Windows.Forms.MenuItem();
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.splitterLeftRight = new System.Windows.Forms.Splitter();
		this.pnlRightBottom = new System.Windows.Forms.Panel();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.labelOrders = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.labelProduction = new System.Windows.Forms.Label();
		this.labelChart = new System.Windows.Forms.Label();
		this.pictureBoxChartReports = new System.Windows.Forms.PictureBox();
		this.pictureBoxProduction = new System.Windows.Forms.PictureBox();
		this.labelItems = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label6 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.labelDataTransfer = new System.Windows.Forms.Label();
		this.labelShifts = new System.Windows.Forms.Label();
		this.labelPersons = new System.Windows.Forms.Label();
		this.labelUsers = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.picBoxDataTransfer = new System.Windows.Forms.PictureBox();
		this.picBoxShifts = new System.Windows.Forms.PictureBox();
		this.picBoxUsers = new System.Windows.Forms.PictureBox();
		this.picBoxCapacity = new System.Windows.Forms.PictureBox();
		this.picBoxScheduling = new System.Windows.Forms.PictureBox();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
		this.pnlLeftTree.SuspendLayout();
		this.pnlRightBottom.SuspendLayout();
		this.SuspendLayout();
		// 
		// pnlLeftTree
		// 
		this.pnlLeftTree.Controls.Add(this.treeViewLeft);
		this.pnlLeftTree.Dock = System.Windows.Forms.DockStyle.Left;
		this.pnlLeftTree.Location = new System.Drawing.Point(0, 0);
		this.pnlLeftTree.Name = "pnlLeftTree";
		this.pnlLeftTree.Size = new System.Drawing.Size(180, 725);
		this.pnlLeftTree.TabIndex = 0;
		// 
		// treeViewLeft
		// 
		this.treeViewLeft.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.treeViewLeft.ContextMenu = this.cxMenuTree;
		this.treeViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
		this.treeViewLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.treeViewLeft.ImageList = this.imageList1;
		this.treeViewLeft.Location = new System.Drawing.Point(0, 0);
		this.treeViewLeft.Name = "treeViewLeft";
		this.treeViewLeft.Size = new System.Drawing.Size(180, 725);
		this.treeViewLeft.TabIndex = 0;
		this.toolTip2.SetToolTip(this.treeViewLeft, "Click on the rigth boton to modify the item");
		this.treeViewLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewLeft_MouseDown);
		this.treeViewLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLeft_AfterSelect);
		// 
		// cxMenuTree
		// 
		this.cxMenuTree.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.cMnuItemAddPlt,
																				   this.cMnuItemEditPlant,
																				   this.cMnuItemDeletePlant,
																				   this.menuItem1,
																				   this.cMnuItemAddDept,
																				   this.cMnuItemEditDept,
																				   this.cMnuItemDeleteDept,
																				   this.menuItem2,
																				   this.cMnuItemAddCfg,
																				   this.cMnuItemEditCfg,
																				   this.cMnuItemDeleteCfg,
																				   this.cMnuItemAddRemoveMachFromCfg,
																				   this.menuItem6,
																				   this.cMnuItemAddMac,
																				   this.cMnuItemEditMac,
																				   this.cMnuItemDeleteMac,
																				   this.cMnuItemMacCapacity,
																				   this.menuItem10,
																				   this.cMnuItemAddShift,
																				   this.cMnuItemEditShift,
																				   this.cMnuItemCopyShift,
																				   this.cMnuItemMoveShift,
																				   this.menuItemSep,
																				   this.cMnuItemRefesh});
		// 
		// cMnuItemAddPlt
		// 
		this.cMnuItemAddPlt.Index = 0;
		this.cMnuItemAddPlt.Text = "Add New Plant";
		this.cMnuItemAddPlt.Click += new System.EventHandler(this.cMnuItemAddPlt_Click);
		// 
		// cMnuItemEditPlant
		// 
		this.cMnuItemEditPlant.Index = 1;
		this.cMnuItemEditPlant.Text = "Edit Plant";
		this.cMnuItemEditPlant.Click += new System.EventHandler(this.cMnuItemEditPlant_Click);
		// 
		// cMnuItemDeletePlant
		// 
		this.cMnuItemDeletePlant.Index = 2;
		this.cMnuItemDeletePlant.Text = "Delete Plant";
		this.cMnuItemDeletePlant.Click += new System.EventHandler(this.cMnuItemDeletePlant_Click);
		// 
		// menuItem1
		// 
		this.menuItem1.Index = 3;
		this.menuItem1.Text = "-";
		// 
		// cMnuItemAddDept
		// 
		this.cMnuItemAddDept.Index = 4;
		this.cMnuItemAddDept.Text = "Add New Department";
		this.cMnuItemAddDept.Click += new System.EventHandler(this.cMnuItemAddDept_Click);
		// 
		// cMnuItemEditDept
		// 
		this.cMnuItemEditDept.Index = 5;
		this.cMnuItemEditDept.Text = "Edit Department";
		this.cMnuItemEditDept.Click += new System.EventHandler(this.cMnuItemEditDept_Click);
		// 
		// cMnuItemDeleteDept
		// 
		this.cMnuItemDeleteDept.Index = 6;
		this.cMnuItemDeleteDept.Text = "Delete Department";
		this.cMnuItemDeleteDept.Click += new System.EventHandler(this.cMnuItemDeleteDept_Click);
		// 
		// menuItem2
		// 
		this.menuItem2.Index = 7;
		this.menuItem2.Text = "-";
		// 
		// cMnuItemAddCfg
		// 
		this.cMnuItemAddCfg.Index = 8;
		this.cMnuItemAddCfg.Text = "Add Configuration";
		this.cMnuItemAddCfg.Click += new System.EventHandler(this.cMnuItemAddCfg_Click);
		// 
		// cMnuItemEditCfg
		// 
		this.cMnuItemEditCfg.Index = 9;
		this.cMnuItemEditCfg.Text = "Edit Configuration";
		this.cMnuItemEditCfg.Click += new System.EventHandler(this.cMnuItemEditCfg_Click);
		// 
		// cMnuItemDeleteCfg
		// 
		this.cMnuItemDeleteCfg.Index = 10;
		this.cMnuItemDeleteCfg.Text = "Delete Configuration";
		this.cMnuItemDeleteCfg.Click += new System.EventHandler(this.cMnuItemDeleteCfg_Click);
		// 
		// cMnuItemAddRemoveMachFromCfg
		// 
		this.cMnuItemAddRemoveMachFromCfg.Index = 11;
		this.cMnuItemAddRemoveMachFromCfg.Text = "Add or Remove Mach. ";
		this.cMnuItemAddRemoveMachFromCfg.Click += new System.EventHandler(this.cMnuItemAddRemoveMachFromCfg_Click);
		// 
		// menuItem6
		// 
		this.menuItem6.Index = 12;
		this.menuItem6.Text = "-";
		// 
		// cMnuItemAddMac
		// 
		this.cMnuItemAddMac.Index = 13;
		this.cMnuItemAddMac.Text = "Add machine";
		this.cMnuItemAddMac.Click += new System.EventHandler(this.cMnuItemAddMac_Click);
		// 
		// cMnuItemEditMac
		// 
		this.cMnuItemEditMac.Index = 14;
		this.cMnuItemEditMac.Text = "Edit Machine";
		this.cMnuItemEditMac.Click += new System.EventHandler(this.cMnuItemEditMac_Click);
		// 
		// cMnuItemDeleteMac
		// 
		this.cMnuItemDeleteMac.Index = 15;
		this.cMnuItemDeleteMac.Text = "Delete Machine";
		this.cMnuItemDeleteMac.Click += new System.EventHandler(this.cMnuItemDeleteMac_Click);
		// 
		// cMnuItemMacCapacity
		// 
		this.cMnuItemMacCapacity.Index = 16;
		this.cMnuItemMacCapacity.Text = "Capacity";
		this.cMnuItemMacCapacity.Click += new System.EventHandler(this.cMnuItemMacCapacity_Click);
		// 
		// menuItem10
		// 
		this.menuItem10.Index = 17;
		this.menuItem10.Text = "-";
		// 
		// cMnuItemAddShift
		// 
		this.cMnuItemAddShift.Index = 18;
		this.cMnuItemAddShift.Text = "Add Shift";
		this.cMnuItemAddShift.Click += new System.EventHandler(this.cMnuItemAddShift_Click);
		// 
		// cMnuItemEditShift
		// 
		this.cMnuItemEditShift.Index = 19;
		this.cMnuItemEditShift.Text = "Edit/Delete Shift";
		this.cMnuItemEditShift.Click += new System.EventHandler(this.cMnuItemEditShift_Click);
		// 
		// cMnuItemCopyShift
		// 
		this.cMnuItemCopyShift.Enabled = false;
		this.cMnuItemCopyShift.Index = 20;
		this.cMnuItemCopyShift.Text = "Copy Shift to Dept.";
		this.cMnuItemCopyShift.Click += new System.EventHandler(this.cMnuItemCopyShift_Click);
		// 
		// cMnuItemMoveShift
		// 
		this.cMnuItemMoveShift.Enabled = false;
		this.cMnuItemMoveShift.Index = 21;
		this.cMnuItemMoveShift.Text = "Move Shift to Dept.";
		this.cMnuItemMoveShift.Click += new System.EventHandler(this.cMnuItemMoveShift_Click);
		// 
		// menuItemSep
		// 
		this.menuItemSep.Index = 22;
		this.menuItemSep.Text = "-";
		// 
		// cMnuItemRefesh
		// 
		this.cMnuItemRefesh.Index = 23;
		this.cMnuItemRefesh.Text = "Refresh";
		this.cMnuItemRefesh.Click += new System.EventHandler(this.cMnuItemRefesh_Click);
		// 
		// imageList1
		// 
		this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
		this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		// 
		// splitterLeftRight
		// 
		this.splitterLeftRight.BackColor = System.Drawing.SystemColors.Control;
		this.splitterLeftRight.Location = new System.Drawing.Point(180, 0);
		this.splitterLeftRight.Name = "splitterLeftRight";
		this.splitterLeftRight.Size = new System.Drawing.Size(3, 725);
		this.splitterLeftRight.TabIndex = 1;
		this.splitterLeftRight.TabStop = false;
		// 
		// pnlRightBottom
		// 
		this.pnlRightBottom.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.pnlRightBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.pnlRightBottom.Controls.Add(this.pictureBox4);
		this.pnlRightBottom.Controls.Add(this.labelOrders);
		this.pnlRightBottom.Controls.Add(this.pictureBox3);
		this.pnlRightBottom.Controls.Add(this.labelProduction);
		this.pnlRightBottom.Controls.Add(this.labelChart);
		this.pnlRightBottom.Controls.Add(this.pictureBoxChartReports);
		this.pnlRightBottom.Controls.Add(this.pictureBoxProduction);
		this.pnlRightBottom.Controls.Add(this.labelItems);
		this.pnlRightBottom.Controls.Add(this.pictureBox2);
		this.pnlRightBottom.Controls.Add(this.label6);
		this.pnlRightBottom.Controls.Add(this.pictureBox1);
		this.pnlRightBottom.Controls.Add(this.labelDataTransfer);
		this.pnlRightBottom.Controls.Add(this.labelShifts);
		this.pnlRightBottom.Controls.Add(this.labelPersons);
		this.pnlRightBottom.Controls.Add(this.labelUsers);
		this.pnlRightBottom.Controls.Add(this.label1);
		this.pnlRightBottom.Controls.Add(this.picBoxDataTransfer);
		this.pnlRightBottom.Controls.Add(this.picBoxShifts);
		this.pnlRightBottom.Controls.Add(this.picBoxUsers);
		this.pnlRightBottom.Controls.Add(this.picBoxCapacity);
		this.pnlRightBottom.Controls.Add(this.picBoxScheduling);
		this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pnlRightBottom.Location = new System.Drawing.Point(183, 0);
		this.pnlRightBottom.Name = "pnlRightBottom";
		this.pnlRightBottom.Size = new System.Drawing.Size(833, 725);
		this.pnlRightBottom.TabIndex = 6;
		// 
		// pictureBox4
		// 
		this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
		this.pictureBox4.Location = new System.Drawing.Point(0, 0);
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.Size = new System.Drawing.Size(832, 88);
		this.pictureBox4.TabIndex = 21;
		this.pictureBox4.TabStop = false;
		// 
		// labelOrders
		// 
		this.labelOrders.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelOrders.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.labelOrders.ForeColor = System.Drawing.SystemColors.ControlText;
		this.labelOrders.Image = ((System.Drawing.Image)(resources.GetObject("labelOrders.Image")));
		this.labelOrders.Location = new System.Drawing.Point(504, 560);
		this.labelOrders.Name = "labelOrders";
		this.labelOrders.Size = new System.Drawing.Size(56, 16);
		this.labelOrders.TabIndex = 20;
		this.labelOrders.Click += new System.EventHandler(this.labelOrders_Click);
		// 
		// pictureBox3
		// 
		this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
		this.pictureBox3.Location = new System.Drawing.Point(360, 528);
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.Size = new System.Drawing.Size(130, 92);
		this.pictureBox3.TabIndex = 19;
		this.pictureBox3.TabStop = false;
		this.toolTip1.SetToolTip(this.pictureBox3, "Charts and Reports");
		this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
		// 
		// labelProduction
		// 
		this.labelProduction.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelProduction.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.labelProduction.ForeColor = System.Drawing.SystemColors.ControlText;
		this.labelProduction.Image = ((System.Drawing.Image)(resources.GetObject("labelProduction.Image")));
		this.labelProduction.Location = new System.Drawing.Point(440, 456);
		this.labelProduction.Name = "labelProduction";
		this.labelProduction.Size = new System.Drawing.Size(120, 16);
		this.labelProduction.TabIndex = 18;
		this.labelProduction.Click += new System.EventHandler(this.labelProduction_Click);
		// 
		// labelChart
		// 
		this.labelChart.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelChart.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.labelChart.ForeColor = System.Drawing.Color.Transparent;
		this.labelChart.Image = ((System.Drawing.Image)(resources.GetObject("labelChart.Image")));
		this.labelChart.Location = new System.Drawing.Point(16, 552);
		this.labelChart.Name = "labelChart";
		this.labelChart.Size = new System.Drawing.Size(152, 16);
		this.labelChart.TabIndex = 17;
		this.labelChart.Click += new System.EventHandler(this.labelChart_Click);
		// 
		// pictureBoxChartReports
		// 
		this.pictureBoxChartReports.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxChartReports.Image")));
		this.pictureBoxChartReports.Location = new System.Drawing.Point(176, 520);
		this.pictureBoxChartReports.Name = "pictureBoxChartReports";
		this.pictureBoxChartReports.Size = new System.Drawing.Size(130, 92);
		this.pictureBoxChartReports.TabIndex = 16;
		this.pictureBoxChartReports.TabStop = false;
		this.toolTip1.SetToolTip(this.pictureBoxChartReports, "Charts and Reports");
		this.pictureBoxChartReports.Click += new System.EventHandler(this.pictureBoxChartReports_Click);
		// 
		// pictureBoxProduction
		// 
		this.pictureBoxProduction.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxProduction.Image")));
		this.pictureBoxProduction.Location = new System.Drawing.Point(304, 416);
		this.pictureBoxProduction.Name = "pictureBoxProduction";
		this.pictureBoxProduction.Size = new System.Drawing.Size(130, 92);
		this.pictureBoxProduction.TabIndex = 15;
		this.pictureBoxProduction.TabStop = false;
		this.toolTip1.SetToolTip(this.pictureBoxProduction, "Production");
		this.pictureBoxProduction.Click += new System.EventHandler(this.pictureBoxProduction_Click);
		// 
		// labelItems
		// 
		this.labelItems.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelItems.Image = ((System.Drawing.Image)(resources.GetObject("labelItems.Image")));
		this.labelItems.Location = new System.Drawing.Point(520, 264);
		this.labelItems.Name = "labelItems";
		this.labelItems.Size = new System.Drawing.Size(56, 16);
		this.labelItems.TabIndex = 14;
		this.labelItems.Click += new System.EventHandler(this.labelItems_Click);
		// 
		// pictureBox2
		// 
		this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
		this.pictureBox2.Location = new System.Drawing.Point(384, 208);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(130, 92);
		this.pictureBox2.TabIndex = 13;
		this.pictureBox2.TabStop = false;
		this.toolTip1.SetToolTip(this.pictureBox2, "Items");
		this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
		// 
		// label6
		// 
		this.label6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
		this.label6.Location = new System.Drawing.Point(560, 160);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(72, 16);
		this.label6.TabIndex = 11;
		this.label6.Click += new System.EventHandler(this.label6_Click);
		// 
		// pictureBox1
		// 
		this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
		this.pictureBox1.Location = new System.Drawing.Point(424, 104);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(130, 92);
		this.pictureBox1.TabIndex = 10;
		this.pictureBox1.TabStop = false;
		this.toolTip1.SetToolTip(this.pictureBox1, "HotList");
		this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
		// 
		// labelDataTransfer
		// 
		this.labelDataTransfer.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelDataTransfer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.labelDataTransfer.ForeColor = System.Drawing.SystemColors.ControlText;
		this.labelDataTransfer.Image = ((System.Drawing.Image)(resources.GetObject("labelDataTransfer.Image")));
		this.labelDataTransfer.Location = new System.Drawing.Point(488, 352);
		this.labelDataTransfer.Name = "labelDataTransfer";
		this.labelDataTransfer.Size = new System.Drawing.Size(120, 16);
		this.labelDataTransfer.TabIndex = 9;
		this.labelDataTransfer.Click += new System.EventHandler(this.label5_Click);
		// 
		// labelShifts
		// 
		this.labelShifts.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelShifts.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.labelShifts.ForeColor = System.Drawing.SystemColors.ControlText;
		this.labelShifts.Image = ((System.Drawing.Image)(resources.GetObject("labelShifts.Image")));
		this.labelShifts.Location = new System.Drawing.Point(64, 464);
		this.labelShifts.Name = "labelShifts";
		this.labelShifts.Size = new System.Drawing.Size(56, 16);
		this.labelShifts.TabIndex = 8;
		this.labelShifts.Click += new System.EventHandler(this.labelShifts_Click);
		// 
		// labelPersons
		// 
		this.labelPersons.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelPersons.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.labelPersons.ForeColor = System.Drawing.SystemColors.ControlText;
		this.labelPersons.Image = ((System.Drawing.Image)(resources.GetObject("labelPersons.Image")));
		this.labelPersons.Location = new System.Drawing.Point(104, 256);
		this.labelPersons.Name = "labelPersons";
		this.labelPersons.Size = new System.Drawing.Size(72, 16);
		this.labelPersons.TabIndex = 7;
		this.labelPersons.Click += new System.EventHandler(this.labelPersons_Click);
		// 
		// labelUsers
		// 
		this.labelUsers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.labelUsers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.labelUsers.ForeColor = System.Drawing.SystemColors.ControlText;
		this.labelUsers.Image = ((System.Drawing.Image)(resources.GetObject("labelUsers.Image")));
		this.labelUsers.Location = new System.Drawing.Point(104, 360);
		this.labelUsers.Name = "labelUsers";
		this.labelUsers.Size = new System.Drawing.Size(49, 16);
		this.labelUsers.TabIndex = 6;
		this.labelUsers.Click += new System.EventHandler(this.label2_Click);
		// 
		// label1
		// 
		this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
		this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
		this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
		this.label1.Location = new System.Drawing.Point(160, 160);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(88, 16);
		this.label1.TabIndex = 5;
		this.label1.Click += new System.EventHandler(this.label1_Click);
		// 
		// picBoxDataTransfer
		// 
		this.picBoxDataTransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picBoxDataTransfer.Image = ((System.Drawing.Image)(resources.GetObject("picBoxDataTransfer.Image")));
		this.picBoxDataTransfer.Location = new System.Drawing.Point(352, 312);
		this.picBoxDataTransfer.Name = "picBoxDataTransfer";
		this.picBoxDataTransfer.Size = new System.Drawing.Size(130, 92);
		this.picBoxDataTransfer.TabIndex = 4;
		this.picBoxDataTransfer.TabStop = false;
		this.toolTip1.SetToolTip(this.picBoxDataTransfer, "Data Transfer");
		this.picBoxDataTransfer.Click += new System.EventHandler(this.picBoxDataTransfer_Click);
		// 
		// picBoxShifts
		// 
		this.picBoxShifts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picBoxShifts.Image = ((System.Drawing.Image)(resources.GetObject("picBoxShifts.Image")));
		this.picBoxShifts.Location = new System.Drawing.Point(128, 408);
		this.picBoxShifts.Name = "picBoxShifts";
		this.picBoxShifts.Size = new System.Drawing.Size(130, 92);
		this.picBoxShifts.TabIndex = 3;
		this.picBoxShifts.TabStop = false;
		this.toolTip1.SetToolTip(this.picBoxShifts, "Shifts");
		this.picBoxShifts.Click += new System.EventHandler(this.picBoxShifts_Click);
		// 
		// picBoxUsers
		// 
		this.picBoxUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picBoxUsers.Image = ((System.Drawing.Image)(resources.GetObject("picBoxUsers.Image")));
		this.picBoxUsers.Location = new System.Drawing.Point(160, 304);
		this.picBoxUsers.Name = "picBoxUsers";
		this.picBoxUsers.Size = new System.Drawing.Size(130, 92);
		this.picBoxUsers.TabIndex = 2;
		this.picBoxUsers.TabStop = false;
		this.toolTip1.SetToolTip(this.picBoxUsers, "Users");
		this.picBoxUsers.Click += new System.EventHandler(this.picBoxUsers_Click);
		// 
		// picBoxCapacity
		// 
		this.picBoxCapacity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picBoxCapacity.Image = ((System.Drawing.Image)(resources.GetObject("picBoxCapacity.Image")));
		this.picBoxCapacity.Location = new System.Drawing.Point(184, 200);
		this.picBoxCapacity.Name = "picBoxCapacity";
		this.picBoxCapacity.Size = new System.Drawing.Size(130, 92);
		this.picBoxCapacity.TabIndex = 1;
		this.picBoxCapacity.TabStop = false;
		this.toolTip1.SetToolTip(this.picBoxCapacity, "Capacity");
		this.picBoxCapacity.Click += new System.EventHandler(this.picBoxCapacity_Click);
		// 
		// picBoxScheduling
		// 
		this.picBoxScheduling.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxScheduling.BackgroundImage")));
		this.picBoxScheduling.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picBoxScheduling.Location = new System.Drawing.Point(256, 96);
		this.picBoxScheduling.Name = "picBoxScheduling";
		this.picBoxScheduling.Size = new System.Drawing.Size(130, 92);
		this.picBoxScheduling.TabIndex = 0;
		this.picBoxScheduling.TabStop = false;
		this.toolTip1.SetToolTip(this.picBoxScheduling, "Scheduling");
		this.picBoxScheduling.Click += new System.EventHandler(this.picBoxScheduling_Click);
		// 
		// toolTip1
		// 
		this.toolTip1.AutomaticDelay = 100;
		this.toolTip1.AutoPopDelay = 1000;
		this.toolTip1.InitialDelay = 100;
		this.toolTip1.ReshowDelay = 20;
		// 
		// FormMaster
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(1016, 725);
		this.Controls.Add(this.pnlRightBottom);
		this.Controls.Add(this.splitterLeftRight);
		this.Controls.Add(this.pnlLeftTree);
		this.Name = "FormMaster";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Capacity Configurator";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.Load += new System.EventHandler(this.FormMaster_Load);
		this.Closed += new System.EventHandler(this.OnClosed);
		this.pnlLeftTree.ResumeLayout(false);
		this.pnlRightBottom.ResumeLayout(false);
		this.ResumeLayout(false);

	}
	#endregion

	#region Methods

	private void BindTree()
	{	
		try
		{
			this.treeViewLeft.BeginUpdate();
			this.treeViewLeft.Nodes.Clear();

			TypedTreeNode rootTreeNode = new TypedTreeNode();

			rootTreeNode.Type = TreeNodeType.PLANT_GROUP_ROOT;

			rootTreeNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			rootTreeNode.Text = "Plants  ";  
			rootTreeNode.ImageIndex = 0;
			rootTreeNode.SelectedImageIndex = 1;
			treeViewLeft.Nodes.Add(rootTreeNode);
			
			int indexRootNode = treeViewLeft.Nodes.IndexOf(rootTreeNode);
	
			CoreFactory core = UtilCoreFactory.createCoreFactory();
			PlantContainer plantContainer = core.readAllPlants();

 			#region Plant
				for(IEnumerator en = plantContainer.GetEnumerator(); en.MoveNext(); )
				{
					Plant plant = (Plant)en.Current;
		
					//Add tree node
					TypedTreeNode currentTreeNode = new TypedTreeNode();
						
					currentTreeNode.Type = TreeNodeType.PLANT;
					currentTreeNode.Content = plant;
					currentTreeNode.refresh();
					
					treeViewLeft.Nodes[indexRootNode].Nodes.Add(currentTreeNode);

					int indexCurrentNode = treeViewLeft.Nodes[indexRootNode].Nodes.IndexOf(currentTreeNode);

					
					TypedTreeNode depRootTreeNode = new TypedTreeNode();
					depRootTreeNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					depRootTreeNode.Type = TreeNodeType.DEPARTMENT_GROUP_ROOT;
					depRootTreeNode.Text = "Departments     ";
					depRootTreeNode.ImageIndex = 0;
					depRootTreeNode.SelectedImageIndex = 1;
					

					//DEPARTMENTS
					treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes.Add(depRootTreeNode);

					int indexDepRootTreeNode = treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes.IndexOf(depRootTreeNode);
		        
					DepartamentContainer departamentContainer = core.readDepartamentsByPlt(plant.getPlt());
				             
					#region Department
						for(IEnumerator enDept = departamentContainer.GetEnumerator(); enDept.MoveNext(); )
						{
							Departament departament = (Departament)enDept.Current;
			                
							TypedTreeNode deptNode = new TypedTreeNode();

							deptNode.Type = TreeNodeType.DEPARTMENT;
							deptNode.Content = departament;
							deptNode.refresh();
							deptNode.ImageIndex = 0;
	
							treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes[indexDepRootTreeNode].Nodes.Add(deptNode);
							int indexDeptNode = treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes[indexDepRootTreeNode].Nodes.IndexOf(deptNode);
							
							TreeNodeCollection deptNodesCollection = treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes[indexDepRootTreeNode].Nodes[indexDeptNode].Nodes;

							#region Configration root node and configurstion nodes
								TypedTreeNode cfgRootNode = new TypedTreeNode();
								cfgRootNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
								
								cfgRootNode.Text  = "Configurations    ";
								cfgRootNode.ImageIndex =0;
								cfgRootNode.SelectedImageIndex = 1;
								cfgRootNode.Type = TreeNodeType.CONFIGURATION_GROUP_ROOT;

								TreeNodeCollection depChildNodesCollection = treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes[indexDepRootTreeNode].Nodes[indexDeptNode].Nodes;

								int indexCfgRootNode = depChildNodesCollection.Add(cfgRootNode);

								this.insertConfigurationsIntoTree(depChildNodesCollection[indexCfgRootNode].Nodes, plant, departament, core);	

							#endregion Configration root node and configurstion nodes
									
							#region Machine Root Node and machine nodes

								TypedTreeNode depMacRootNode = new TypedTreeNode();

								depMacRootNode.Type = TreeNodeType.MACHINE_GROUP_ROOT;

								depMacRootNode.Text = "Machines    ";  
								depMacRootNode.ImageIndex = 0;
								depMacRootNode.SelectedImageIndex = 1;
								depMacRootNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

								treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes[indexDepRootTreeNode].Nodes[indexDeptNode].Nodes.Add(depMacRootNode);
								int indexMacRootNode = treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes[indexDepRootTreeNode].Nodes[indexDeptNode].Nodes.IndexOf(depMacRootNode);
							
						
					
								this.insertMachinesIntoDepartment(treeViewLeft.Nodes[indexRootNode].Nodes[indexCurrentNode].Nodes[indexDepRootTreeNode].Nodes[indexDeptNode].Nodes[indexMacRootNode].Nodes, plant, departament, core);
								
						

							#endregion Machine Root Node aand machine nodes

							#region Shift Root Node and shift nodes

							TypedTreeNode shiftHdrRootNode = new TypedTreeNode();

							shiftHdrRootNode.Type = TreeNodeType.SHIFTHDR_GROUP_ROOT;
							shiftHdrRootNode.Text = "Shifts    "; 
							shiftHdrRootNode.SelectedImageIndex = 1;
							shiftHdrRootNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
						
							int indexOfShiftHdrRoot = deptNodesCollection.Add(shiftHdrRootNode)	;
						
							TreeNodeCollection shiftHdrNodesCollection = deptNodesCollection[indexOfShiftHdrRoot].Nodes;

							ShiftContainer shiftContainer = core.readShiftsByPltDept(Configuration.DftDataBase, Configuration.DftCompany, plant.getPlt(), departament.getDept());
							IEnumerator shiftEnu = shiftContainer.GetEnumerator();
							while (shiftEnu.MoveNext())
							{
								TypedTreeNode shiftHdrNode  = new TypedTreeNode();
								shiftHdrNode.Type = TreeNodeType.SHIFTHDR;
								shiftHdrNode.Content = shiftEnu.Current;
								shiftHdrNode.refresh();
								shiftHdrNode.SelectedImageIndex = 1;

								shiftHdrNodesCollection.Add(shiftHdrNode);
							}

							#endregion Shift Root Node and shift nodes
					
							}
						#endregion Department
					}
				#endregion Plant

			rootTreeNode.Expand();
			treeViewLeft.EndUpdate();
		}
		catch (Exception ex)
		{
			FormException formEx = new FormException(ex);
			formEx.ShowDialog();
		}
	}

	private void insertConfigurationsIntoTree (TreeNodeCollection cfgNodesCollection, Plant plant, Departament departament, CoreFactory core)
	{
		//Add configuration	
		MacConfiguration[] confs = core.readAllConfigurations (plant.getPlt(), departament.getDept());
					       
		foreach (MacConfiguration conf in confs)
		{
			TypedTreeNode cfgNode  = new TypedTreeNode();
			cfgNode.Type = TreeNodeType.CONFIGURATION;
			cfgNode.Content = conf;
			cfgNode.refresh();
			cfgNode.ImageIndex = 0;
			cfgNode.SelectedImageIndex = 1;
									
			int indexCfgNode = cfgNodesCollection.IndexOf(cfgNode);

			Machine[] macsInConf = core.getMachinesFromConfiguration (plant.getPlt(), departament.getDept(), conf.getCfg());

			if (macsInConf.Length > 0)
			{
				TypedTreeNode depMacCfgRootNode = new TypedTreeNode();

				depMacCfgRootNode.Type = TreeNodeType.MACHINEINCONFIGURATION_GROUP_ROOT;

				depMacCfgRootNode.Text = "Machines    ";  
				depMacCfgRootNode.ImageIndex = 0;
				depMacCfgRootNode.SelectedImageIndex = 1;
				depMacCfgRootNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

				cfgNode.Nodes.Add(depMacCfgRootNode);
								
				TreeNodeCollection  macsUnderCfgNodesCollection = depMacCfgRootNode.Nodes;

				foreach (Machine machine in macsInConf)
				{
					TypedTreeNode machNode = new TypedTreeNode();
					machNode.Type = TreeNodeType.MACHINEINCONFIGURATION;
					machNode.Content = machine;
					machNode.ObjectLoaded = false;
					machNode.refresh();

					macsUnderCfgNodesCollection.Add(machNode);
				}
				depMacCfgRootNode.Expand();
			}
			cfgNodesCollection.Add (cfgNode);
		}
	}

	private void insertMachinesIntoDepartment(TreeNodeCollection macNodesCollection, Plant plant, Departament departament, CoreFactory core)
	{
		Machine[] macs = core.getMachinesNotInAnyConfiguration(plant.getPlt(), departament.getDept());
		foreach (Machine machine in macs)
		{
			TypedTreeNode macNode = new TypedTreeNode();
			macNode.Type = TreeNodeType.MACHINE;
			macNode.Content = machine;
			macNode.ObjectLoaded = false;
			macNode.refresh();

			macNodesCollection.Add(macNode);
		}	
	}

	private void refreshTree()
	{
		IEnumerator enu = this.treeViewLeft.Nodes.GetEnumerator();
		while (enu.MoveNext())
		{
			refreshTree ((TypedTreeNode)enu.Current);
		}
	}

	private void refreshTree(TypedTreeNode treeNode)
	{
		IEnumerator enu = treeNode.Nodes.GetEnumerator();
		while (enu.MoveNext())
			this.refreshTree ((TypedTreeNode)enu.Current);
		treeNode.refresh();
	}


	private void SetupCxMenuItems(System.Windows.Forms.TreeViewEventArgs e)
	{
		TypedTreeNode selectNode = (TypedTreeNode)treeViewLeft.SelectedNode;
		
		HideCXMenuItems();
		
		if (selectNode == null) return; 

		switch (selectNode.Type)
		{
			case (TreeNodeType.PLANT_GROUP_ROOT):
			{
				
				this.cMnuItemAddPlt.Visible = true;
				break;
			}
			case (TreeNodeType.PLANT):
			{
				this.cMnuItemDeletePlant.Visible = true;
				this.cMnuItemEditPlant.Visible = true;
				break;
			}
			case (TreeNodeType.DEPARTMENT_GROUP_ROOT):
			{
				this.cMnuItemAddDept.Visible = true;
				break;
			}
			case (TreeNodeType.DEPARTMENT):
			{
				this .cMnuItemDeleteDept.Visible = this.cMnuItemEditDept.Visible = true;
				break;
			}
			case (TreeNodeType.MACHINE_GROUP_ROOT):
			{
				this.cMnuItemAddMac.Visible = true;  
				break;
			}
			case (TreeNodeType.MACHINE):
			{
				this.cMnuItemDeleteMac.Visible = this.cMnuItemEditMac.Visible = this.cMnuItemMacCapacity.Visible = true; 
				break;
			}
			case (TreeNodeType.MACHINEINCONFIGURATION):
			{
				this.cMnuItemDeleteMac.Visible = this.cMnuItemEditMac.Visible = this.cMnuItemMacCapacity.Visible = true; 
				break;
			}
			case (TreeNodeType.MACHINEINCONFIGURATION_GROUP_ROOT):
			{
				this.cMnuItemAddRemoveMachFromCfg.Visible = true; 
				break;
			}
			case (TreeNodeType.CONFIGURATION_GROUP_ROOT):
			{
				this.cMnuItemAddCfg.Visible = true;   
				break;
			}
			case (TreeNodeType.CONFIGURATION):
			{
				this.cMnuItemDeleteCfg.Visible = this.cMnuItemEditCfg.Visible = this.cMnuItemAddRemoveMachFromCfg.Visible = true; 
				break;
			}
			case (TreeNodeType.SHIFTHDR_GROUP_ROOT):
			{
				this.cMnuItemAddShift.Visible      = true;   
				break;
			}
			case (TreeNodeType.SHIFTHDR):
			{
				this.cMnuItemEditShift.Visible 		= this.cMnuItemCopyShift.Visible
													= this.cMnuItemMoveShift.Visible
													= true; 
				break;
			}
		}
		this.cMnuItemRefesh.Visible = true;
	}

	private void HideCXMenuItems()
	{
		foreach (MenuItem item  in this.cxMenuTree.MenuItems)
		{			
			item.Visible = false;
		}
		menuItemSep.Visible = true;
	}

	
	
	private void AddNewPlt()
	{
		FormEditPlt form = null; 
		try
		{
			form = new FormEditPlt();
			form.IsInsert = true;
			form.ShowDialog();
			// FN 01.28.2005
			if (form.DialogResult == DialogResult.OK)
			{
				TypedTreeNode currentTreeNode = new TypedTreeNode();
				
				Plant plant = form.SavedPlant;
				currentTreeNode.Type = TreeNodeType.PLANT;
				currentTreeNode.Content = plant;
				currentTreeNode.refresh();

				treeViewLeft.SelectedNode.Nodes.Add(currentTreeNode);

				TypedTreeNode depRootTreeNode = new TypedTreeNode();
				depRootTreeNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				depRootTreeNode.Type = TreeNodeType.DEPARTMENT_GROUP_ROOT;
				depRootTreeNode.Text = "Departments     ";
				depRootTreeNode.ImageIndex = 0;
				depRootTreeNode.SelectedImageIndex = 1;
				currentTreeNode.Nodes.Add (depRootTreeNode);

				currentTreeNode.Expand();
				if (!currentTreeNode.Parent.IsExpanded)
					currentTreeNode.Parent.Expand();
			}
			// End FN
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		}
	}

	private bool EditPlt()
	{
		bool hasUpdated = false;
		//Add by Claudia Melo, when the node is not over the tree the aplication crash.
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.PLANT) 
				return false;
		}catch{
			return false;
		}

		FormEditPlt form = null; 

		Plant plant = (Plant)((TypedTreeNode)this.treeViewLeft.SelectedNode).Content;
		try	{
			form = new FormEditPlt(plant);
			form.IsUpdate = true;
			form.ShowDialog();
			hasUpdated = (form.DialogResult == DialogResult.OK);
			if (hasUpdated)
				((TypedTreeNode)this.treeViewLeft.SelectedNode).Content = form.SavedPlant;
			form.Dispose();
		}
		catch(Exception ex)	{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
		return hasUpdated;
	}
	private bool EditCapMacCfg()
	{
		bool hasUpdated = false;
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.CONFIGURATION) 
				return false;
		}catch{
			return false;
		}		

		MacConfiguration conf = (MacConfiguration)((TypedTreeNode)this.treeViewLeft.SelectedNode).Content;
		FormEditCapMacCfg form = null; 
		try
		{
			form = new FormEditCapMacCfg();
			form.Configuration = conf;
			form.IsUpdate   = true;
			form.ShowDialog();
			hasUpdated = (form.DialogResult == DialogResult.OK);
			if (hasUpdated)
				((TypedTreeNode)this.treeViewLeft.SelectedNode).Content = form.SavedConfiguration;
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}

		return hasUpdated;
	}

	private void EditMachCfgRelationship()
	{
		TypedTreeNode selectedNode = (TypedTreeNode)this.treeViewLeft.SelectedNode;
		try{
			if (selectedNode.Type != TreeNodeType.CONFIGURATION)
			{
				if (selectedNode.Type == TreeNodeType.MACHINEINCONFIGURATION_GROUP_ROOT)
					selectedNode = (TypedTreeNode)selectedNode.Parent;
				else
					return;
			}
		}catch{
			return;
		}	

		MacConfiguration conf = (MacConfiguration)selectedNode.Content;
		FormAddMacToCfg form = null; 

		try
		{
			form = new FormAddMacToCfg();
			form.Configuration = conf;
			form.ShowDialog();
			if (form.DialogResult == DialogResult.OK)
			{
				Plant plant = (Plant)((TypedTreeNode)selectedNode.Parent.Parent.Parent.Parent).Content;
				Departament departament = (Departament)((TypedTreeNode)selectedNode.Parent.Parent).Content;
				TypedTreeNode confNode = (TypedTreeNode)selectedNode.Parent;

				bool[] blTreeStatus = new bool[confNode.Nodes.Count];
				MacConfiguration[] cfTreeStatus = new MacConfiguration[confNode.Nodes.Count];

				for (int i=0; i<confNode.Nodes.Count; i++)
				{
					blTreeStatus[i] = confNode.Nodes[i].IsExpanded;
					cfTreeStatus[i] = (MacConfiguration)((TypedTreeNode)confNode.Nodes[i]).Content;
				}

                confNode.Nodes.Clear();
				CoreFactory core = UtilCoreFactory.createCoreFactory();
				this.insertConfigurationsIntoTree (confNode.Nodes,plant,departament,core);
				
				foreach (TypedTreeNode node in confNode.Nodes)
				{
					MacConfiguration auxConf = (MacConfiguration)node.Content;
					if ((getIndex(auxConf, cfTreeStatus) != -1) && blTreeStatus[getIndex(auxConf, cfTreeStatus)])
						node.Expand();
				}

				TypedTreeNode macNode = null;
				IEnumerator enu = confNode.Parent.Nodes.GetEnumerator();
				while (enu.MoveNext()){
					if (((TypedTreeNode)enu.Current).Type == TreeNodeType.MACHINE_GROUP_ROOT)
						macNode = (TypedTreeNode)enu.Current;
				}
				if (macNode != null)
				{
					macNode.Nodes.Clear();
					this.insertMachinesIntoDepartment (macNode.Nodes,plant,departament,core);
				}	
			}
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}


	}
	//()

	private int getIndex (MacConfiguration conf, MacConfiguration[] list)
	{
		int index = -1;
        int i=0;
		while ((i < list.Length) && (index == -1))
		{
			if (conf.getCfg().Equals(list[i].getCfg()))
				index = i;
			i++;
		}
		return index;
	}

	//EditPltDeptMach
	private bool EditPltDeptMach()
	{
		bool hasUpdated = false;
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.MACHINE &&
				((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.MACHINEINCONFIGURATION) 
				return false;
		}catch{
			return false;
		}	
		
		Machine machine = (Machine)((TypedTreeNode)this.treeViewLeft.SelectedNode).Content;


		if (!((TypedTreeNode)this.treeViewLeft.SelectedNode).ObjectLoaded)
			machine = UtilCoreFactory.createCoreFactory().readMachine(machine.getPlt(),machine.getDept(),machine.getMach());

		FormEditMac form = null; 
	
		try
		{
			form = new FormEditMac();
			form.IsUpdate = true;
			form.machine = machine;

			form.ShowDialog();
			hasUpdated = (form.DialogResult == DialogResult.OK);
			if (hasUpdated)
				((TypedTreeNode)treeViewLeft.SelectedNode).Content = form.SavedMachine;
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
		return hasUpdated;
	}

	//DeletePltDeptMach()
	private bool DeletePltDeptMach()
	{
		bool wasRemoved = false;
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.MACHINE &&
				((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.MACHINEINCONFIGURATION) 
				return wasRemoved;
		}catch{
			return wasRemoved;
		}

		FormEditMac form = null; 
		Machine machine = (Machine)((TypedTreeNode)treeViewLeft.SelectedNode).Content;

		try
		{
			form = new FormEditMac();
			form.IsDelete = true;
			form.machine = machine;

			form.ShowDialog();
			wasRemoved = (form.DialogResult == DialogResult.OK);
			form.Dispose();
		}
		catch(Exception ex)
		{
		
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
		return wasRemoved;
	}

	private void ConfigurateMachCapacity()
	{
		if ((((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.MACHINE) && (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.MACHINEINCONFIGURATION))
			return;
		
		Machine machine = (Machine)((TypedTreeNode)this.treeViewLeft.SelectedNode).Content;

		FormABMCapacity form = null; 

		try{
			form = new FormABMCapacity(machine);
			form.ShowDialog();
			form.Dispose();
		}catch(Exception ex){
			FormException formException = new FormException(ex);
			formException.Show(); 
		}
	}

	private void AddDepartment()
	{

		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.DEPARTMENT_GROUP_ROOT) 
				return;
		}catch{
			return;
		}
		
		Departament departament = new Departament();
		
		departament.setPlt (((Plant)((TypedTreeNode)treeViewLeft.SelectedNode.Parent).Content).getPlt());

		FormEditPltDept form = null; 
	    
		try	{
            form = new FormEditPltDept(departament);
			form.IsInsert = true;
			form.ShowDialog();

			// FN 01.31.05
			if (form.DialogResult == DialogResult.OK)
			{
				Departament newDepartament = form.SavedDept;

				TypedTreeNode deptNode = new TypedTreeNode();
				deptNode.Type = TreeNodeType.DEPARTMENT;
				deptNode.Content = newDepartament;
				deptNode.refresh();
				deptNode.ImageIndex = 0;

				treeViewLeft.SelectedNode.Nodes.Add(deptNode);

				TypedTreeNode cfgRootNode = new TypedTreeNode();
				cfgRootNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				cfgRootNode.Text  = "Configurations    ";
				cfgRootNode.ImageIndex =0;
				cfgRootNode.SelectedImageIndex = 1;
				cfgRootNode.Type = TreeNodeType.CONFIGURATION_GROUP_ROOT;
				deptNode.Nodes.Add (cfgRootNode);


				TypedTreeNode depMacRootNode = new TypedTreeNode();
				depMacRootNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				depMacRootNode.Text = "Machines    ";  
				depMacRootNode.ImageIndex = 0;
				depMacRootNode.SelectedImageIndex = 1;
				depMacRootNode.Type = TreeNodeType.MACHINE_GROUP_ROOT;
				deptNode.Nodes.Add (depMacRootNode);

				TypedTreeNode shiftHdrRootNode = new TypedTreeNode();
				shiftHdrRootNode.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				shiftHdrRootNode.Text = "Shifts    "; 
				shiftHdrRootNode.ImageIndex = 0;
				shiftHdrRootNode.SelectedImageIndex = 1;
				shiftHdrRootNode.Type = TreeNodeType.SHIFTHDR_GROUP_ROOT;
				deptNode.Nodes.Add (shiftHdrRootNode);

				deptNode.Expand();
				if (!deptNode.Parent.IsExpanded)
					deptNode.Parent.Expand();
			}
			// END FN

			form.Dispose();		
	    }catch(Exception ex){
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}

	}
	private void AddCapMacCfg()
	{

		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.CONFIGURATION_GROUP_ROOT) 
				return;
		}catch{
			return;
		}

		MacConfiguration conf = new MacConfiguration();
		conf.setDept (((Departament)((TypedTreeNode)treeViewLeft.SelectedNode.Parent).Content).getDept());
		conf.setPlt (((Plant)((TypedTreeNode)treeViewLeft.SelectedNode.Parent.Parent.Parent).Content).getPlt());

		FormEditCapMacCfg form = null; 

		try
		{
			form = new FormEditCapMacCfg();
			form.IsInsert = true;
			form.Configuration = conf;
			form.ShowDialog();
			if (form.DialogResult == DialogResult.OK)
			{
				conf = form.SavedConfiguration;

				TypedTreeNode cfgNode  = new TypedTreeNode();
				cfgNode.Type = TreeNodeType.CONFIGURATION;
				cfgNode.Content = conf;
				cfgNode.refresh();
				cfgNode.ImageIndex = 0;
				cfgNode.SelectedImageIndex = 1;

				treeViewLeft.SelectedNode.Nodes.Add (cfgNode);
				if (!treeViewLeft.SelectedNode.IsExpanded)
					treeViewLeft.SelectedNode.Expand();
			}
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
	}

	private void AddShift()
	{
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.SHIFTHDR_GROUP_ROOT) 
				return;
		}catch{
			return;
		}

		string db = Configuration.DftDataBase;
		int company = Configuration.DftCompany;
		string plant = ((Plant)((TypedTreeNode)treeViewLeft.SelectedNode.Parent.Parent.Parent).Content).getPlt();
		string dept = ((Departament)((TypedTreeNode)treeViewLeft.SelectedNode.Parent).Content).getDept();

		FormABMShift form = null; 

		try
		{
			form = new NujitERP.WinForms.CapacityModule.FormABMShift();
			form.setNewParameters (db, company, plant, dept);
			form.ShowDialog();
			if (form.DialogResult == DialogResult.OK)
			{
				TypedTreeNode currentTreeNode = new TypedTreeNode();
				
				Shift newShift = form.getSavedShift();
				currentTreeNode.Type = TreeNodeType.SHIFTHDR;
				currentTreeNode.Content = newShift;
				currentTreeNode.refresh();

				treeViewLeft.SelectedNode.Nodes.Add(currentTreeNode);

				if (!currentTreeNode.Parent.IsExpanded)
					currentTreeNode.Parent.Expand();
			}
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
	}

	//UpdateShift()
	private Result UpdateDeleteShift()
	{
		Result result = Result.NOTHING;
		try
		{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.SHIFTHDR)
			
				return Result.NOTHING;
		}
		catch
		{
			return Result.NOTHING;
		}	
		
		Shift shift = (Shift)((TypedTreeNode)this.treeViewLeft.SelectedNode).Content;

		FormABMShift form = null; 
	
		try
		{
			form = new FormABMShift();
			
			form.setUpdateParameters (shift.getDb(), shift.getCompany(), shift.getPlt(), shift.getDept(), shift.getShf());

			form.ShowDialog();
			if (form.DialogResult == DialogResult.OK)
			{
				if (form.getSavedShift() != null)
				{
					((TypedTreeNode)treeViewLeft.SelectedNode).Content = form.getSavedShift();
					((TypedTreeNode)treeViewLeft.SelectedNode).ObjectLoaded = true;
					result = Result.UPDATED;
				}
				else
					result = Result.DELETED;
			}
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
		return result;
	}
	
	private void AddPltDeptMach()
	{
	try{
		if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.MACHINE_GROUP_ROOT) 
			return;
	}catch{
		return;
	}

	Machine machine =  new Machine();
	machine.setPlt(((Plant)((TypedTreeNode)treeViewLeft.SelectedNode.Parent.Parent.Parent).Content).getPlt());
	machine.setDept(((Departament)((TypedTreeNode)treeViewLeft.SelectedNode.Parent).Content).getDept());
	FormEditMac form = null; 

	try
	{
		form = new FormEditMac();
		form.IsInsert = true;
		form.machine = machine;
		form.ShowDialog();
		if (form.DialogResult == DialogResult.OK)
		{
			TypedTreeNode currentTreeNode = new TypedTreeNode();
			
			Machine newMachine = form.SavedMachine;
			currentTreeNode.Type = TreeNodeType.MACHINE;
			currentTreeNode.Content = newMachine;
			currentTreeNode.refresh();

			treeViewLeft.SelectedNode.Nodes.Add(currentTreeNode);

			if (!currentTreeNode.Parent.IsExpanded)
				currentTreeNode.Parent.Expand();
		}
		form.Dispose();
	}
	catch(Exception ex)
	{
		FormException formException = new FormException(ex);
		formException.Show(); 
	
	}

	}
	private bool DeletePlt()
	{
		bool wasDeleted = false;
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.PLANT) 
				return wasDeleted;
		}catch{
			return wasDeleted;
		}

		FormEditPlt form = null; 

		Plant plant = (Plant)((TypedTreeNode)this.treeViewLeft.SelectedNode).Content;
		
		try
		{
			form = new FormEditPlt(plant);
			form.IsDelete = true;
			form.ShowDialog();
			wasDeleted = (form.DialogResult == DialogResult.OK);
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
		return wasDeleted;
	}
	private bool DeleteCapMacCfg()
	{
		bool wasDeleted = false;
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.CONFIGURATION) 
				return wasDeleted;
		}catch{
			return wasDeleted;
		}

		MacConfiguration conf = (MacConfiguration)((TypedTreeNode)treeViewLeft.SelectedNode).Content;
		FormEditCapMacCfg form = null; 

		try
		{
			form = new FormEditCapMacCfg();
			form.Configuration = conf;
			form.IsDelete  = true;
			form.ShowDialog();
			wasDeleted = (form.DialogResult == DialogResult.OK);
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		}
		return wasDeleted;
	}

	private bool UpdateDept()
	{
		bool hasUpdated = false;
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.DEPARTMENT) 
				return false;
		}catch{
			return false;
		}

		FormEditPltDept form = null; 

		Departament departament = (Departament)((TypedTreeNode)this.treeViewLeft.SelectedNode).Content;
		
		try	{
			form = new FormEditPltDept(departament);
			form.IsUpdate = true;
    		form.ShowDialog();
			hasUpdated = (form.DialogResult == DialogResult.OK);
			if (hasUpdated)
				((TypedTreeNode)this.treeViewLeft.SelectedNode).Content = form.SavedDept;
			form.Dispose();
		}
		catch(Exception ex)	{
	
			FormException formException = new FormException(ex);
			formException.Show(); 
		
		}
		return hasUpdated;
	}

	private bool DeleteDept()
	{
		bool wasDeleted = false;
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.DEPARTMENT) 
				return wasDeleted;
		}catch{
			return wasDeleted;
		}

		FormEditPltDept form = null; 
		
		Departament departament = (Departament)((TypedTreeNode)treeViewLeft.SelectedNode).Content;

		try
		{
            form = new FormEditPltDept(departament);
			form.IsDelete = true;
			form.ShowDialog();
			wasDeleted = (form.DialogResult == DialogResult.OK);
			form.Dispose();
		}
		catch(Exception ex)
		{
			FormException formException = new FormException(ex);
			formException.Show(); 
		}
		return wasDeleted;
	}


	private void MoveOrCopyShift(string strMoveOrCopy)
	{
/*
		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.SHIFTHDR) 
				return;
		}catch{
			return;
		}


		DataRow dRow = ((TypedTreeNode)this.treeViewLeft.SelectedNode).TagedDataRow;
	    
		if (dRow == null) return;
		
		Nujit.NujitERP.ClassLib.Master.ShiftHdr shiftHdr= new ShiftHdr();
		shiftHdr.AssembleFromDataRow(dRow);
		
		FormCopyShiftToDept form = null; 

		try
		{
			form = new FormCopyShiftToDept();
		
			form.ShiftHdr = shiftHdr;
		
			if (strMoveOrCopy.ToUpper().Equals("MOVE"))
			{
				form.MoveTo = true;
				form.CopyTo = false;
			
			}
			else if (strMoveOrCopy.ToUpper().Equals("COPY"))
			{
				form.MoveTo = false;	
				form.CopyTo = true;
			
			}
			form.ShowDialog();
			form.Dispose();
		}
		catch(Exception ex)
		{
			LogHandler.LogError(ex,"FormCopyShiftToDept"   ,"FormCopyShiftToDept","FormCopyShiftToDept");
			FormException formException = new FormException(ex);
			formException.Show(); 
	      	
		}
*/
	}

	private void OnClosed(object sender, System.EventArgs e)
	{
		if (this.formMainParent != null)
		{
			this.formMainParent.RemoveTab(this.Tag);

			this.formMainParent.SetButtons();
		}	
	}

	#endregion Methods

	#region Events

	private void cMnuItemAddPlt_Click(object sender, System.EventArgs e)
	{   
		AddNewPlt();
	}

	private void cMnuItemDeletePlant_Click(object sender, System.EventArgs e)
	{
		if (DeletePlt())
			treeViewLeft.SelectedNode.Remove();
	}

	private void cMnuItemDeleteDept_Click(object sender, System.EventArgs e)
	{
		if (DeleteDept())
			treeViewLeft.SelectedNode.Remove();
	}

	private void cMnuItemEditDept_Click(object sender, System.EventArgs e)
	{
		if (UpdateDept())
			((TypedTreeNode)treeViewLeft.SelectedNode).refresh(); 
	}

	private void cMnuItemEditPlant_Click(object sender, System.EventArgs e)
	{
		if (this.EditPlt())
			((TypedTreeNode)treeViewLeft.SelectedNode).refresh(); 
	}

	private void cMnuItemAddDept_Click(object sender, System.EventArgs e)
	{
		AddDepartment();
	}
	private void cMnuItemAddCfg_Click(object sender, System.EventArgs e)
	{
		AddCapMacCfg(); 
	}

	private void cMnuItemEditCfg_Click(object sender, System.EventArgs e)
	{
		if (EditCapMacCfg())
			((TypedTreeNode)treeViewLeft.SelectedNode).refresh(); 
	}

	private void cMnuItemDeleteCfg_Click(object sender, System.EventArgs e)
	{
		if (DeleteCapMacCfg())
			treeViewLeft.SelectedNode.Remove();
	}

	private void cMnuItemAddMac_Click(object sender, System.EventArgs e)
	{
		AddPltDeptMach();
	}

	private void cMnuItemEditMac_Click(object sender, System.EventArgs e)
	{
		if (EditPltDeptMach())
			((TypedTreeNode)this.treeViewLeft.SelectedNode).refresh();
	}

	private void cMnuItemDeleteMac_Click(object sender, System.EventArgs e)
	{
		if (DeletePltDeptMach())
			this.treeViewLeft.SelectedNode.Remove();
	}

	private void cMnuItemAddRemoveMachFromCfg_Click(object sender, System.EventArgs e)
	{
		EditMachCfgRelationship();
	}

	private void cMnuItemAddShift_Click(object sender, System.EventArgs e)
	{
		AddShift(); 
	}

	private void cMnuItemEditShift_Click(object sender, System.EventArgs e)
	{
		Result res = UpdateDeleteShift();
		if (res == Result.UPDATED)
			((TypedTreeNode)this.treeViewLeft.SelectedNode).refresh();
		else if (res == Result.DELETED)
			treeViewLeft.SelectedNode.Remove();
	}
	/*
	private void cMnuItemDeleteShift_Click(object sender, System.EventArgs e)
	{
		if (DialogResult.No == MessageBox.Show(" Sure you want to delete this record?   \n","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
		{
			return;
		}

		try{
			if (((TypedTreeNode)this.treeViewLeft.SelectedNode).Type != TreeNodeType.SHIFTHDR) 
			return;
		}catch{
			return;
		}

		DataRow dRow = ((TypedTreeNode)this.treeViewLeft.SelectedNode).TagedDataRow;
	    
		if (dRow == null) return;

		ShiftHdr  shiftHdr = new ShiftHdr();

		shiftHdr.AssembleFromDataRow(dRow);

		if (shiftHdr.DeleteAllMacCapShiftDayDetailsTransShiftHdr())//(shiftHdr.Delete())
		{
			MessageBox.Show("  Delete operation succeeded!  \n", "Deletion Info.",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.BindTree();
		}
		else
		{
			MessageBox.Show("  Can not delete record! Error occured.   \n", "Deletion Info.",MessageBoxButtons.OK,MessageBoxIcon.Information);
		
		}
	}

*/
	private void treeViewLeft_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
	{
			SetupCxMenuItems(e);
	}

	private void cMnuItemRefesh_Click(object sender, System.EventArgs e)
	{
		this.BindTree();
	}


	private void treeViewLeft_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
	{ 	
		if(e.Button == MouseButtons.Right) 
		{ 
			treeViewLeft.SelectedNode = treeViewLeft.GetNodeAt (e.X ,e.Y ); 
		} 
	}

	private void FormMaster_Load(object sender, System.EventArgs e)
	{
		this.BindTree();
	}
	
	private void splitterRightTopMiddle_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
	{

	}	
	private void cMnuItemCopyShift_Click(object sender, System.EventArgs e)
	{
		MoveOrCopyShift("COPY");
		this.BindTree();
	}


	private void cMnuItemMoveShift_Click(object sender, System.EventArgs e)
	{
		this.MoveOrCopyShift("MOVE");
		this.BindTree(); 
	}

	#endregion Events

	private void picBoxScheduling_Click(object sender, System.EventArgs e)	{
		
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowSchedule();

	}

	private void picBoxCapacity_Click(object sender, System.EventArgs e)
	{
		FormEditPerson formEditPerson = new FormEditPerson();
		formEditPerson.ShowDialog();
	}

	private void picBoxUsers_Click(object sender, System.EventArgs e)
	{
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowUserAdmForm();
	}

	private void picBoxShifts_Click(object sender, System.EventArgs e)
	{
		FormABMShift form = new FormABMShift();
		form.ShowDialog(this);
	}

	private void picBoxDataTransfer_Click(object sender, System.EventArgs e){
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowFormUpLoadHotList();
	}


	private void label1_Click(object sender, System.EventArgs e){	
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowSchedule();	
	}

	private void label5_Click(object sender, System.EventArgs e){
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowFormUpLoadHotList();
		
	}

	private void cMnuItemMacCapacity_Click(object sender, System.EventArgs e){
		ConfigurateMachCapacity();
//		this.BindTree(); 
	}

	private void label2_Click(object sender, System.EventArgs e){	
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowUserAdmForm();
	
	}

	private void pictureBox1_Click(object sender, System.EventArgs e)
	{
		if (Configuration.ControlUsers.Equals("Y")){
			FormMain refMain = (FormMain)this.MdiParent;

			if (!FormMain.Operator.getLoginName().ToUpper().Equals("ADMIN")){
				HotListReducedForm hotListReducedForm = new HotListReducedForm();
				hotListReducedForm.ShowDialog();
				return;
			}
		}

		HotListForm hotListForm = new HotListForm();
		hotListForm.ShowDialog();

	}

	private void pictureBox2_Click(object sender, System.EventArgs e)
	{
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowItemsForm();
	
	}

	private void pictureBoxProduction_Click(object sender, System.EventArgs e)
	{
		FormProductPlanView formProductPlanView = new FormProductPlanView();
		formProductPlanView.ShowDialog();
		formProductPlanView.Dispose();
	}

	private void pictureBoxChartReports_Click(object sender, System.EventArgs e)
	{
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowChartsAndReports();		
	}

	private void pictureBox3_Click(object sender, System.EventArgs e)
	{
		FormMain refMain = (FormMain)this.MdiParent;
		refMain.ShowFormSearchOrder();
	}

		private void label6_Click(object sender, System.EventArgs e)
		{
			if (Configuration.ControlUsers.Equals("Y"))
			{
				FormMain refMain = (FormMain)this.MdiParent;

				if (!FormMain.Operator.getLoginName().ToUpper().Equals("ADMIN"))
				{
					HotListReducedForm hotListReducedForm = new HotListReducedForm();
					hotListReducedForm.ShowDialog();
					return;
				}
			}

			HotListForm hotListForm = new HotListForm();
			hotListForm.ShowDialog();
		}

		private void labelPersons_Click(object sender, System.EventArgs e)
		{
			FormEditPerson formEditPerson = new FormEditPerson();
			formEditPerson.ShowDialog();
		}

		private void labelItems_Click(object sender, System.EventArgs e)
		{
			FormMain refMain = (FormMain)this.MdiParent;
			refMain.ShowItemsForm();
		}

		private void labelShifts_Click(object sender, System.EventArgs e)
		{
			FormABMShift form = new FormABMShift();
			form.ShowDialog(this);
		}

		private void labelProduction_Click(object sender, System.EventArgs e)
		{
			FormProductPlanView formProductPlanView = new FormProductPlanView();
			formProductPlanView.ShowDialog();
			formProductPlanView.Dispose();
		}

		private void labelChart_Click(object sender, System.EventArgs e)
		{
			FormMain refMain = (FormMain)this.MdiParent;
			refMain.ShowChartsAndReports();	
		}

		private void labelOrders_Click(object sender, System.EventArgs e)
		{
			FormMain refMain = (FormMain)this.MdiParent;
			refMain.ShowFormSearchOrder();
		}

/*		private void button1_Click(object sender, System.EventArgs e)
		{
			System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];

			System.Drawing.Imaging.EncoderParameters ep=new System.Drawing.Imaging.EncoderParameters();
			ep.Param[0]=new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality,(long)90);

			Image img = picBoxScheduling.BackgroundImage;
			img.Save ("C:\\Proyectos\\Nujit\\NujitERP\\Images\\Scheduling.jpg", codec, ep);
		}
*/
  }
}
