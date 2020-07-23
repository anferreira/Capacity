using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Master;
using Nujit.NujitERP.WinForms.SearchForms;

namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormNewOrderDtl.
	/// </summary>
	public class FormDiscounts : System.Windows.Forms.Form
	{

		private Discount discount;
		private OrderDtlCharge _orderDtlCharge;
		private bool boolDebit;
		private bool boolBase;
		private CoreFactory coreFactory;

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
		private System.Windows.Forms.Button buttonSearchDiscount;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxDistribution;
		private System.Windows.Forms.Label labelDistribution;
		private System.Windows.Forms.RadioButton rdoButtonBase;
		private System.Windows.Forms.RadioButton rdoButtonNet;
		private System.Windows.Forms.RadioButton rdoButtonDebit;
		private System.Windows.Forms.RadioButton rdoButtonCredit;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
								#endregion

		#region Constructors
		public FormDiscounts()
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
			this.buttonSearchDiscount = new System.Windows.Forms.Button();
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
			this.buttonAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBoxGeneral.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxGeneral
			// 
			this.groupBoxGeneral.Controls.Add(this.textBoxDistribution);
			this.groupBoxGeneral.Controls.Add(this.labelDistribution);
			this.groupBoxGeneral.Controls.Add(this.buttonSearchDiscount);
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
			this.groupBoxGeneral.Location = new System.Drawing.Point(8, 8);
			this.groupBoxGeneral.Name = "groupBoxGeneral";
			this.groupBoxGeneral.Size = new System.Drawing.Size(200, 192);
			this.groupBoxGeneral.TabIndex = 1;
			this.groupBoxGeneral.TabStop = false;
			this.groupBoxGeneral.Text = "General";
			// 
			// textBoxDistribution
			// 
			this.textBoxDistribution.Location = new System.Drawing.Point(80, 136);
			this.textBoxDistribution.MaxLength = 1;
			this.textBoxDistribution.Name = "textBoxDistribution";
			this.textBoxDistribution.ReadOnly = true;
			this.textBoxDistribution.Size = new System.Drawing.Size(104, 20);
			this.textBoxDistribution.TabIndex = 30;
			this.textBoxDistribution.Text = "";
			// 
			// labelDistribution
			// 
			this.labelDistribution.Location = new System.Drawing.Point(16, 136);
			this.labelDistribution.Name = "labelDistribution";
			this.labelDistribution.Size = new System.Drawing.Size(64, 20);
			this.labelDistribution.TabIndex = 15;
			this.labelDistribution.Text = "Distribution";
			this.labelDistribution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonSearchDiscount
			// 
			this.buttonSearchDiscount.Location = new System.Drawing.Point(154, 42);
			this.buttonSearchDiscount.Name = "buttonSearchDiscount";
			this.buttonSearchDiscount.Size = new System.Drawing.Size(30, 16);
			this.buttonSearchDiscount.TabIndex = 10;
			this.buttonSearchDiscount.Text = "...";
			this.buttonSearchDiscount.Click += new System.EventHandler(this.buttonSearchDiscount_Click);
			// 
			// textBoxExtension
			// 
			this.textBoxExtension.Location = new System.Drawing.Point(80, 112);
			this.textBoxExtension.MaxLength = 1;
			this.textBoxExtension.Name = "textBoxExtension";
			this.textBoxExtension.ReadOnly = true;
			this.textBoxExtension.Size = new System.Drawing.Size(104, 20);
			this.textBoxExtension.TabIndex = 25;
			this.textBoxExtension.Text = "";
			// 
			// textBoxPercent
			// 
			this.textBoxPercent.Location = new System.Drawing.Point(80, 88);
			this.textBoxPercent.MaxLength = 1;
			this.textBoxPercent.Name = "textBoxPercent";
			this.textBoxPercent.ReadOnly = true;
			this.textBoxPercent.Size = new System.Drawing.Size(104, 20);
			this.textBoxPercent.TabIndex = 20;
			this.textBoxPercent.Text = "";
			// 
			// labelPercent
			// 
			this.labelPercent.Location = new System.Drawing.Point(16, 88);
			this.labelPercent.Name = "labelPercent";
			this.labelPercent.Size = new System.Drawing.Size(64, 20);
			this.labelPercent.TabIndex = 11;
			this.labelPercent.Text = "Porcentage";
			this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelExtension
			// 
			this.labelExtension.Location = new System.Drawing.Point(16, 112);
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.Size = new System.Drawing.Size(64, 20);
			this.labelExtension.TabIndex = 10;
			this.labelExtension.Text = "Extension";
			this.labelExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDesc
			// 
			this.textBoxDesc.Location = new System.Drawing.Point(80, 64);
			this.textBoxDesc.MaxLength = 100;
			this.textBoxDesc.Name = "textBoxDesc";
			this.textBoxDesc.ReadOnly = true;
			this.textBoxDesc.Size = new System.Drawing.Size(104, 20);
			this.textBoxDesc.TabIndex = 15;
			this.textBoxDesc.Text = "";
			// 
			// textBoxCode
			// 
			this.textBoxCode.Location = new System.Drawing.Point(80, 40);
			this.textBoxCode.MaxLength = 10;
			this.textBoxCode.Name = "textBoxCode";
			this.textBoxCode.Size = new System.Drawing.Size(72, 20);
			this.textBoxCode.TabIndex = 5;
			this.textBoxCode.Text = "";
			this.textBoxCode.LostFocus += new System.EventHandler(this.textBoxCode_LostFocus);
			// 
			// textBoxAmount
			// 
			this.textBoxAmount.Location = new System.Drawing.Point(80, 88);
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
			this.labelAmount.Location = new System.Drawing.Point(16, 88);
			this.labelAmount.Name = "labelAmount";
			this.labelAmount.Size = new System.Drawing.Size(64, 20);
			this.labelAmount.TabIndex = 6;
			this.labelAmount.Text = "Amount";
			this.labelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelAmount.Visible = false;
			// 
			// labelDesc
			// 
			this.labelDesc.Location = new System.Drawing.Point(16, 64);
			this.labelDesc.Name = "labelDesc";
			this.labelDesc.Size = new System.Drawing.Size(64, 20);
			this.labelDesc.TabIndex = 1;
			this.labelDesc.Text = "Description";
			this.labelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCode
			// 
			this.labelCode.Location = new System.Drawing.Point(16, 40);
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
			this.groupBox2.TabIndex = 10;
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
			this.groupBox3.TabIndex = 10;
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
			this.groupBox1.TabIndex = 5;
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
			this.checkBoxBeforeDiscount.TabIndex = 25;
			this.checkBoxBeforeDiscount.Text = "Before Discount";
			// 
			// checkBoxBeforeFreight
			// 
			this.checkBoxBeforeFreight.Location = new System.Drawing.Point(16, 128);
			this.checkBoxBeforeFreight.Name = "checkBoxBeforeFreight";
			this.checkBoxBeforeFreight.Size = new System.Drawing.Size(104, 20);
			this.checkBoxBeforeFreight.TabIndex = 20;
			this.checkBoxBeforeFreight.Text = "Before Frieght";
			// 
			// checkBoxBeforeTax
			// 
			this.checkBoxBeforeTax.Location = new System.Drawing.Point(16, 104);
			this.checkBoxBeforeTax.Name = "checkBoxBeforeTax";
			this.checkBoxBeforeTax.Size = new System.Drawing.Size(104, 20);
			this.checkBoxBeforeTax.TabIndex = 15;
			this.checkBoxBeforeTax.Text = "Before Tax";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBoxGeneral);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(400, 208);
			this.panel1.TabIndex = 5;
			// 
			// buttonAccept
			// 
			this.buttonAccept.Location = new System.Drawing.Point(168, 216);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(112, 24);
			this.buttonAccept.TabIndex = 3;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(288, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FormDiscounts
			// 
			this.AcceptButton = this.buttonAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(410, 247);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDiscounts";
			this.ShowInTaskbar = false;
			this.Text = "Discount";
			this.groupBoxGeneral.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		#endregion

		#region Events
		private void buttonSearchDiscount_Click(object sender, System.EventArgs e)
		{
			DiscountSearchForm discountSearchForm = new DiscountSearchForm("Discounts ...", coreFactory);
			discountSearchForm.ShowDialog();
	
			if ((discountSearchForm.DialogResult == DialogResult.OK) &&
				(discountSearchForm.getSelected() != null))
			{
				textBoxCode.Text = discountSearchForm.getSelected()[0];
				discount = new Discount ();
				discount = coreFactory.readDiscount(textBoxCode.Text);
				objectToScreen();
			}
		}

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

		private void textBoxCode_LostFocus(object sender, System.EventArgs e)
		{
			try
			{
				Discount ds = coreFactory.readDiscount (textBoxCode.Text);
				if (ds!=null)
				{
					discount = ds;
					objectToScreen();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException(ex);
				frmEx.ShowDialog(this);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("All changes will be lost." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				this.Close();
		}
		#endregion
		
		#region Methods
		private void MyInitialize()
		{
			boolDebit = true;
			boolBase = true;
		}

		private void objectToScreen()
		{
			textBoxDesc.Text = discount.getDiscDes();
			if (discount.getDiscRate() > 0)
			{
				textBoxPercent.Text = NumberUtil.toString(discount.getDiscRate()) + " %";
				textBoxPercent.Visible = true;
				labelPercent.Visible = true;
				textBoxAmount.Visible = false;
				labelAmount.Visible = false;
			}
			else
			{
				textBoxAmount.Text = NumberUtil.toString(discount.getDiscAmount());
				textBoxPercent.Visible = false;
				labelPercent.Visible = false;
				textBoxAmount.Visible = true;
				labelAmount.Visible = true;
			}
			if (textBoxPercent.Visible)
				textBoxDistribution.Text = "Not aplicable";
			else if (discount.getFixedUnit().Equals(Constants.DISCOUNT_TYPE_FIXEDUNIT_ONE))
				textBoxDistribution.Text = "Per Unit";
			else
				textBoxDistribution.Text = "Entire order detail";
			boolDebit = discount.getDrCr().Equals(Constants.DISCOUNT_TYPE_DEBIT);
			rdoButtonDebit.Checked = boolDebit;
			rdoButtonCredit.Checked = !boolDebit;
			boolBase = discount.getBaseNet().Equals(Constants.DISCOUNT_TYPE_TOTAL_BASE);
			rdoButtonBase.Checked = boolBase;
			rdoButtonNet.Checked = !boolBase;
		}

		public void screenToObject ()
		{
			if (checkBoxBeforeDiscount.Checked)
				_orderDtlCharge.setBeforeDiscount("T");
			else
				_orderDtlCharge.setBeforeDiscount("F");

			if (checkBoxBeforeFreight.Checked)
				_orderDtlCharge.setBeforeFreight("T");
			else
				_orderDtlCharge.setBeforeFreight("F");

			if (checkBoxBeforeTax.Checked)
				_orderDtlCharge.setBeforeTax("T");
			else
				_orderDtlCharge.setBeforeTax("F");
		}

		public OrderDtlCharge orderDtlCharge
		{
			get
			{
				if (discount != null)
				{
					if (_orderDtlCharge == null)
					{
						_orderDtlCharge = new OrderDtlCharge();
					}
					_orderDtlCharge.setAmount (discount.getDiscAmount());
					_orderDtlCharge.setBaseNet (discount.getBaseNet());
					_orderDtlCharge.setChargeCode (discount.getDiscCode());
					_orderDtlCharge.setChargeDesc (discount.getDiscDes());
					_orderDtlCharge.setFixedUnit (discount.getFixedUnit());
					_orderDtlCharge.setPercent (discount.getDiscRate());
					screenToObject();
				}
				return _orderDtlCharge;
			}
		}
		#endregion
	}
}
