using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Master;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.SearchForms;

namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormNewOrderDtl.
	/// </summary>
	public class FormGroupDiscounts : System.Windows.Forms.Form
	{

		#region Controls
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.GroupBox groupBoxGeneral;
		private System.Windows.Forms.Label labelCode;
		private System.Windows.Forms.Label labelDesc;
		private System.Windows.Forms.CheckBox checkBoxBeforeTax;
		private System.Windows.Forms.CheckBox checkBoxBeforeFreight;
		private System.Windows.Forms.CheckBox checkBoxBeforeDiscount;
		private System.Windows.Forms.Label labelAmount;
		private System.Windows.Forms.TextBox textBoxAmount;
		private System.Windows.Forms.TextBox textBoxCode;
		private System.Windows.Forms.TextBox textBoxDesc;
		private System.Windows.Forms.Label labelExtension;
		private System.Windows.Forms.Label labelPercent;
		private System.Windows.Forms.TextBox textBoxPercent;
		private System.Windows.Forms.TextBox textBoxExtension;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxDistribution;
		private System.Windows.Forms.Label labelDistribution;
		private System.Windows.Forms.RadioButton rdoButtonBase;
		private System.Windows.Forms.RadioButton rdoButtonNet;
		private System.Windows.Forms.RadioButton rdoButtonDebit;
		private System.Windows.Forms.RadioButton rdoButtonCredit;
		private System.Windows.Forms.Label labelGroupCode;
		private System.Windows.Forms.Button buttonSearchGroupDiscount;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGrid dataGridCharges;
		private System.Windows.Forms.TextBox textBoxGroupCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		private ArrayList detailChargesVec;
		private bool boolDebit;
		private bool boolBase;
		private int oldGridIndex;
		private System.Windows.Forms.Button buttonCancel;
		private CoreFactory coreFactory;

		#region Contructors
		public FormGroupDiscounts()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			coreFactory = UtilCoreFactory.createCoreFactory();
			MyInitialize();
			//
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
			this.textBoxDistribution = new System.Windows.Forms.TextBox();
			this.labelDistribution = new System.Windows.Forms.Label();
			this.textBoxExtension = new System.Windows.Forms.TextBox();
			this.textBoxPercent = new System.Windows.Forms.TextBox();
			this.labelPercent = new System.Windows.Forms.Label();
			this.labelExtension = new System.Windows.Forms.Label();
			this.textBoxDesc = new System.Windows.Forms.TextBox();
			this.textBoxCode = new System.Windows.Forms.TextBox();
			this.textBoxAmount = new System.Windows.Forms.TextBox();
			this.labelAmount = new System.Windows.Forms.Label();
			this.labelDesc = new System.Windows.Forms.Label();
			this.labelCode = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdoButtonBase = new System.Windows.Forms.RadioButton();
			this.rdoButtonNet = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoButtonDebit = new System.Windows.Forms.RadioButton();
			this.rdoButtonCredit = new System.Windows.Forms.RadioButton();
			this.checkBoxBeforeDiscount = new System.Windows.Forms.CheckBox();
			this.checkBoxBeforeFreight = new System.Windows.Forms.CheckBox();
			this.checkBoxBeforeTax = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBoxGroupCode = new System.Windows.Forms.TextBox();
			this.labelGroupCode = new System.Windows.Forms.Label();
			this.buttonSearchGroupDiscount = new System.Windows.Forms.Button();
			this.buttonAccept = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGridCharges = new System.Windows.Forms.DataGrid();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxGeneral.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCharges)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxGeneral
			// 
			this.groupBoxGeneral.Controls.Add(this.textBoxDistribution);
			this.groupBoxGeneral.Controls.Add(this.labelDistribution);
			this.groupBoxGeneral.Controls.Add(this.textBoxExtension);
			this.groupBoxGeneral.Controls.Add(this.textBoxPercent);
			this.groupBoxGeneral.Controls.Add(this.labelPercent);
			this.groupBoxGeneral.Controls.Add(this.labelExtension);
			this.groupBoxGeneral.Controls.Add(this.textBoxDesc);
			this.groupBoxGeneral.Controls.Add(this.textBoxCode);
			this.groupBoxGeneral.Controls.Add(this.textBoxAmount);
			this.groupBoxGeneral.Controls.Add(this.labelAmount);
			this.groupBoxGeneral.Controls.Add(this.labelDesc);
			this.groupBoxGeneral.Controls.Add(this.labelCode);
			this.groupBoxGeneral.Location = new System.Drawing.Point(8, 48);
			this.groupBoxGeneral.Name = "groupBoxGeneral";
			this.groupBoxGeneral.Size = new System.Drawing.Size(200, 152);
			this.groupBoxGeneral.TabIndex = 30;
			this.groupBoxGeneral.TabStop = false;
			this.groupBoxGeneral.Text = "General";
			// 
			// textBoxDistribution
			// 
			this.textBoxDistribution.Location = new System.Drawing.Point(80, 120);
			this.textBoxDistribution.MaxLength = 1;
			this.textBoxDistribution.Name = "textBoxDistribution";
			this.textBoxDistribution.ReadOnly = true;
			this.textBoxDistribution.Size = new System.Drawing.Size(104, 20);
			this.textBoxDistribution.TabIndex = 50;
			this.textBoxDistribution.Text = "";
			// 
			// labelDistribution
			// 
			this.labelDistribution.Location = new System.Drawing.Point(16, 120);
			this.labelDistribution.Name = "labelDistribution";
			this.labelDistribution.Size = new System.Drawing.Size(64, 20);
			this.labelDistribution.TabIndex = 15;
			this.labelDistribution.Text = "Distribution";
			this.labelDistribution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxExtension
			// 
			this.textBoxExtension.Location = new System.Drawing.Point(80, 96);
			this.textBoxExtension.MaxLength = 1;
			this.textBoxExtension.Name = "textBoxExtension";
			this.textBoxExtension.ReadOnly = true;
			this.textBoxExtension.Size = new System.Drawing.Size(104, 20);
			this.textBoxExtension.TabIndex = 40;
			this.textBoxExtension.Text = "";
			// 
			// textBoxPercent
			// 
			this.textBoxPercent.Location = new System.Drawing.Point(80, 72);
			this.textBoxPercent.MaxLength = 1;
			this.textBoxPercent.Name = "textBoxPercent";
			this.textBoxPercent.ReadOnly = true;
			this.textBoxPercent.Size = new System.Drawing.Size(104, 20);
			this.textBoxPercent.TabIndex = 30;
			this.textBoxPercent.Text = "";
			// 
			// labelPercent
			// 
			this.labelPercent.Location = new System.Drawing.Point(16, 72);
			this.labelPercent.Name = "labelPercent";
			this.labelPercent.Size = new System.Drawing.Size(64, 20);
			this.labelPercent.TabIndex = 11;
			this.labelPercent.Text = "Porcentage";
			this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelExtension
			// 
			this.labelExtension.Location = new System.Drawing.Point(16, 96);
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.Size = new System.Drawing.Size(64, 20);
			this.labelExtension.TabIndex = 10;
			this.labelExtension.Text = "Extension";
			this.labelExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDesc
			// 
			this.textBoxDesc.Location = new System.Drawing.Point(80, 48);
			this.textBoxDesc.MaxLength = 100;
			this.textBoxDesc.Name = "textBoxDesc";
			this.textBoxDesc.ReadOnly = true;
			this.textBoxDesc.Size = new System.Drawing.Size(104, 20);
			this.textBoxDesc.TabIndex = 20;
			this.textBoxDesc.Text = "";
			// 
			// textBoxCode
			// 
			this.textBoxCode.Location = new System.Drawing.Point(80, 24);
			this.textBoxCode.MaxLength = 10;
			this.textBoxCode.Name = "textBoxCode";
			this.textBoxCode.ReadOnly = true;
			this.textBoxCode.Size = new System.Drawing.Size(104, 20);
			this.textBoxCode.TabIndex = 10;
			this.textBoxCode.Text = "";
			// 
			// textBoxAmount
			// 
			this.textBoxAmount.Location = new System.Drawing.Point(80, 72);
			this.textBoxAmount.MaxLength = 16;
			this.textBoxAmount.Name = "textBoxAmount";
			this.textBoxAmount.ReadOnly = true;
			this.textBoxAmount.Size = new System.Drawing.Size(104, 20);
			this.textBoxAmount.TabIndex = 5;
			this.textBoxAmount.Text = "";
			this.textBoxAmount.Visible = false;
			// 
			// labelAmount
			// 
			this.labelAmount.Location = new System.Drawing.Point(16, 72);
			this.labelAmount.Name = "labelAmount";
			this.labelAmount.Size = new System.Drawing.Size(64, 20);
			this.labelAmount.TabIndex = 6;
			this.labelAmount.Text = "Amount";
			this.labelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelAmount.Visible = false;
			// 
			// labelDesc
			// 
			this.labelDesc.Location = new System.Drawing.Point(16, 48);
			this.labelDesc.Name = "labelDesc";
			this.labelDesc.Size = new System.Drawing.Size(64, 20);
			this.labelDesc.TabIndex = 1;
			this.labelDesc.Text = "Description";
			this.labelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCode
			// 
			this.labelCode.Location = new System.Drawing.Point(16, 24);
			this.labelCode.Name = "labelCode";
			this.labelCode.Size = new System.Drawing.Size(64, 20);
			this.labelCode.TabIndex = 0;
			this.labelCode.Text = "Code";
			this.labelCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.checkBoxBeforeDiscount);
			this.groupBox2.Controls.Add(this.checkBoxBeforeFreight);
			this.groupBox2.Controls.Add(this.checkBoxBeforeTax);
			this.groupBox2.Location = new System.Drawing.Point(216, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(184, 192);
			this.groupBox2.TabIndex = 40;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Properties";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rdoButtonBase);
			this.groupBox3.Controls.Add(this.rdoButtonNet);
			this.groupBox3.Location = new System.Drawing.Point(96, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(80, 72);
			this.groupBox3.TabIndex = 20;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Applies on";
			// 
			// rdoButtonBase
			// 
			this.rdoButtonBase.Checked = true;
			this.rdoButtonBase.Location = new System.Drawing.Point(8, 16);
			this.rdoButtonBase.Name = "rdoButtonBase";
			this.rdoButtonBase.Size = new System.Drawing.Size(56, 24);
			this.rdoButtonBase.TabIndex = 4;
			this.rdoButtonBase.TabStop = true;
			this.rdoButtonBase.Text = "Base";
			this.rdoButtonBase.CheckedChanged += new System.EventHandler(this.rdoButtonBase_CheckedChanged);
			// 
			// rdoButtonNet
			// 
			this.rdoButtonNet.Location = new System.Drawing.Point(8, 40);
			this.rdoButtonNet.Name = "rdoButtonNet";
			this.rdoButtonNet.Size = new System.Drawing.Size(56, 24);
			this.rdoButtonNet.TabIndex = 5;
			this.rdoButtonNet.Text = "Net";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoButtonDebit);
			this.groupBox1.Controls.Add(this.rdoButtonCredit);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(72, 72);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Type";
			// 
			// rdoButtonDebit
			// 
			this.rdoButtonDebit.Checked = true;
			this.rdoButtonDebit.Location = new System.Drawing.Point(8, 16);
			this.rdoButtonDebit.Name = "rdoButtonDebit";
			this.rdoButtonDebit.Size = new System.Drawing.Size(56, 24);
			this.rdoButtonDebit.TabIndex = 4;
			this.rdoButtonDebit.TabStop = true;
			this.rdoButtonDebit.Text = "Debit";
			this.rdoButtonDebit.CheckedChanged += new System.EventHandler(this.rdoButtonDebit_CheckedChanged);
			// 
			// rdoButtonCredit
			// 
			this.rdoButtonCredit.Location = new System.Drawing.Point(8, 40);
			this.rdoButtonCredit.Name = "rdoButtonCredit";
			this.rdoButtonCredit.Size = new System.Drawing.Size(56, 24);
			this.rdoButtonCredit.TabIndex = 5;
			this.rdoButtonCredit.Text = "Credit";
			// 
			// checkBoxBeforeDiscount
			// 
			this.checkBoxBeforeDiscount.Location = new System.Drawing.Point(16, 152);
			this.checkBoxBeforeDiscount.Name = "checkBoxBeforeDiscount";
			this.checkBoxBeforeDiscount.Size = new System.Drawing.Size(104, 20);
			this.checkBoxBeforeDiscount.TabIndex = 50;
			this.checkBoxBeforeDiscount.Text = "Before Discount";
			// 
			// checkBoxBeforeFreight
			// 
			this.checkBoxBeforeFreight.Location = new System.Drawing.Point(16, 128);
			this.checkBoxBeforeFreight.Name = "checkBoxBeforeFreight";
			this.checkBoxBeforeFreight.Size = new System.Drawing.Size(104, 20);
			this.checkBoxBeforeFreight.TabIndex = 40;
			this.checkBoxBeforeFreight.Text = "Before Frieght";
			// 
			// checkBoxBeforeTax
			// 
			this.checkBoxBeforeTax.Location = new System.Drawing.Point(16, 104);
			this.checkBoxBeforeTax.Name = "checkBoxBeforeTax";
			this.checkBoxBeforeTax.Size = new System.Drawing.Size(104, 20);
			this.checkBoxBeforeTax.TabIndex = 30;
			this.checkBoxBeforeTax.Text = "Before Tax";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBoxGroupCode);
			this.panel1.Controls.Add(this.groupBoxGeneral);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.labelGroupCode);
			this.panel1.Controls.Add(this.buttonSearchGroupDiscount);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(408, 208);
			this.panel1.TabIndex = 5;
			// 
			// textBoxGroupCode
			// 
			this.textBoxGroupCode.Location = new System.Drawing.Point(88, 16);
			this.textBoxGroupCode.MaxLength = 10;
			this.textBoxGroupCode.Name = "textBoxGroupCode";
			this.textBoxGroupCode.ReadOnly = true;
			this.textBoxGroupCode.Size = new System.Drawing.Size(88, 20);
			this.textBoxGroupCode.TabIndex = 10;
			this.textBoxGroupCode.Text = "";
			// 
			// labelGroupCode
			// 
			this.labelGroupCode.Location = new System.Drawing.Point(16, 16);
			this.labelGroupCode.Name = "labelGroupCode";
			this.labelGroupCode.Size = new System.Drawing.Size(72, 20);
			this.labelGroupCode.TabIndex = 3;
			this.labelGroupCode.Text = "Group Code";
			this.labelGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonSearchGroupDiscount
			// 
			this.buttonSearchGroupDiscount.Location = new System.Drawing.Point(178, 18);
			this.buttonSearchGroupDiscount.Name = "buttonSearchGroupDiscount";
			this.buttonSearchGroupDiscount.Size = new System.Drawing.Size(24, 16);
			this.buttonSearchGroupDiscount.TabIndex = 20;
			this.buttonSearchGroupDiscount.Text = "...";
			this.buttonSearchGroupDiscount.Click += new System.EventHandler(this.buttonSearchGroupDiscount_Click);
			// 
			// buttonAccept
			// 
			this.buttonAccept.Location = new System.Drawing.Point(168, 344);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(112, 24);
			this.buttonAccept.TabIndex = 60;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dataGridCharges);
			this.panel2.Location = new System.Drawing.Point(0, 208);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(408, 128);
			this.panel2.TabIndex = 6;
			// 
			// dataGridCharges
			// 
			this.dataGridCharges.CaptionVisible = false;
			this.dataGridCharges.DataMember = "";
			this.dataGridCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridCharges.Location = new System.Drawing.Point(8, 0);
			this.dataGridCharges.Name = "dataGridCharges";
			this.dataGridCharges.Size = new System.Drawing.Size(392, 128);
			this.dataGridCharges.TabIndex = 50;
			this.dataGridCharges.CurrentCellChanged += new System.EventHandler(this.dataGridCharges_CurrentCellChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(288, 344);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(112, 24);
			this.buttonCancel.TabIndex = 71;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormGroupDiscounts
			// 
			this.AcceptButton = this.buttonAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(410, 375);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGroupDiscounts";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Discount";
			this.groupBoxGeneral.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridCharges)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
		private void rdoButtonBase_CheckedChanged(object sender, System.EventArgs e)
		{
			rdoButtonBase.Checked = boolBase;
			rdoButtonNet.Checked = !boolBase;
		}

		private void rdoButtonDebit_CheckedChanged(object sender, System.EventArgs e)
		{
			rdoButtonDebit.Checked = boolDebit;
			rdoButtonCredit.Checked = !boolDebit;
		}

		private void buttonAccept_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonSearchGroupDiscount_Click(object sender, System.EventArgs e)
		{
			DiscountGroupSearchForm discountGroupSearchForm = new DiscountGroupSearchForm("Discounts ...", coreFactory);
			discountGroupSearchForm.ShowDialog();
	
			if ((discountGroupSearchForm.DialogResult == DialogResult.OK) &&
				(discountGroupSearchForm.getSelected() != null))
			{
				try
				{
					string groupCode = discountGroupSearchForm.getSelected()[0];
					textBoxGroupCode.Text = groupCode;

					ArrayList discounts = coreFactory.getDiscountsInGroupDescByDesc (groupCode,"",0,"PRGD_DiscNum");

					detailChargesVec = new ArrayList();
					IEnumerator enu = discounts.GetEnumerator();
					while (enu.MoveNext())
						detailChargesVec.Add(OrderDtlCharge.FromDiscount((Discount)enu.Current));

					this.loadGrid();
					dataGridCharges.Select(0);
					oldGridIndex = 0;
					objectToScreen ((OrderDtlCharge)detailChargesVec[0]);
				}
				catch (Exception ex)
				{
					FormException frmEx = new FormException(ex);
					frmEx.ShowDialog(this);
				}
			}
		}

		private void dataGridCharges_CurrentCellChanged(object sender, EventArgs ne)
		{
			if (oldGridIndex != dataGridCharges.CurrentRowIndex)
			{
				if (oldGridIndex != -1)
					screenToObject ((OrderDtlCharge)detailChargesVec[oldGridIndex]);
				objectToScreen ((OrderDtlCharge)detailChargesVec[dataGridCharges.CurrentRowIndex]);
				oldGridIndex = dataGridCharges.CurrentRowIndex;
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("All changes will be lost." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				this.Close();
		}
		#endregion
		
		#region Methods
		private void MyInitialize()
		{
			oldGridIndex = -1;
			boolDebit = true;
			boolBase = true;
			detailChargesVec = new ArrayList();
			this.InitialDataGrid();
		}

		private void screenToObject (OrderDtlCharge orderDtlCharge)
		{
			if (checkBoxBeforeDiscount.Checked)
				orderDtlCharge.setBeforeDiscount ("T");
			else
				orderDtlCharge.setBeforeDiscount ("F");
			if (checkBoxBeforeFreight.Checked)
				orderDtlCharge.setBeforeFreight ("T");
			else
				orderDtlCharge.setBeforeFreight ("F");
			if (checkBoxBeforeTax.Checked)
				orderDtlCharge.setBeforeTax ("T");
			else
				orderDtlCharge.setBeforeTax ("F");
		}

		private void objectToScreen(OrderDtlCharge orderDtlCharge)
		{
			textBoxDesc.Text = orderDtlCharge.getChargeDesc();
			if (orderDtlCharge.getPercent() > 0)
			{
				textBoxPercent.Text = NumberUtil.toString(orderDtlCharge.getPercent()) + " %";
				textBoxPercent.Visible = true;
				labelPercent.Visible = true;
				textBoxAmount.Visible = false;
				labelAmount.Visible = false;
			}
			else
			{
				textBoxAmount.Text = NumberUtil.toString(orderDtlCharge.getAmount());
				textBoxPercent.Visible = false;
				labelPercent.Visible = false;
				textBoxAmount.Visible = true;
				labelAmount.Visible = true;
			}
			if (textBoxPercent.Visible)
				textBoxDistribution.Text = "Not aplicable";
			else if (orderDtlCharge.getFixedUnit().Equals(Constants.DISCOUNT_TYPE_FIXEDUNIT_ONE))
				textBoxDistribution.Text = "Per Unit";
			else
				textBoxDistribution.Text = "Entire order detail";
			boolDebit = false;
			rdoButtonDebit.Checked = boolDebit;
			rdoButtonCredit.Checked = !boolDebit;
			boolBase = orderDtlCharge.getBaseNet().Equals(Constants.DISCOUNT_TYPE_TOTAL_BASE);
			rdoButtonBase.Checked = boolBase;
			rdoButtonNet.Checked = !boolBase;
			checkBoxBeforeDiscount.Checked = orderDtlCharge.getBeforeDiscount().Equals("T");
			checkBoxBeforeFreight.Checked = orderDtlCharge.getBeforeFreight().Equals("T");
			checkBoxBeforeTax.Checked = orderDtlCharge.getBeforeTax().Equals("T");

		}

		private void InitialDataGrid()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount Desc.", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Pecent / Amount", typeof(string)));
	
			DataView dataView = new DataView(dataTable);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;

			dataGridCharges.DataSource = dataView;
			dataGridCharges.PreferredColumnWidth = 150;
			dataGridCharges.TableStyles.Clear();
			dataGridCharges.TableStyles.Add(new DataGridTableStyle());
			
			GridColumnStylesCollection	colStyle;
			colStyle				= dataGridCharges.TableStyles[0].GridColumnStyles;		
			colStyle[0].Width      	= 50;
			colStyle[1].Width		= 203;
			colStyle[2].Width		= 100;
			dataGridCharges.RowHeaderWidth = 20;
			dataGridCharges.Refresh();
		}

		private void loadGrid()
		{
			IEnumerator enu = detailChargesVec.GetEnumerator();
			(((DataView)dataGridCharges.DataSource).Table).Clear();
			while (enu.MoveNext())
			{
				loadGrid((OrderDtlCharge)enu.Current);
			}
		}

		private void loadGrid(OrderDtlCharge orderDtlCharge)
		{
			DataTable dt = ((DataView)dataGridCharges.DataSource).Table;
			DataRow dr = dt.NewRow();
			dr[0] = orderDtlCharge.getChargeCode();
			dr[1] = orderDtlCharge.getChargeDesc();
			if (orderDtlCharge.getPercent()>0)
				dr[2] = "% " + NumberUtil.toString(orderDtlCharge.getPercent());
			else
				dr[2] = "$ " + NumberUtil.toString(orderDtlCharge.getAmount());
			dt.Rows.Add(dr);
		}
		
		public IEnumerator getChargesEnumerator()
		{
			return detailChargesVec.GetEnumerator();
		}

		#endregion
	}
}
