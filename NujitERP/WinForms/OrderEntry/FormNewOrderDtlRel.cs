using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
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
	public class FormNewOrderDtlRel : System.Windows.Forms.Form
	{

		#region Controls

		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBoxBillTo;
		private System.Windows.Forms.TextBox textBoxBillToName;
		private System.Windows.Forms.TextBox textBoxBillToNum;
		private System.Windows.Forms.GroupBox groupBoxShipTo;
		private System.Windows.Forms.TextBox textBoxShipToName;
		private System.Windows.Forms.TextBox textBoxShipToNum;
		private System.Windows.Forms.Button buttonSearchShipTo;
		private System.Windows.Forms.GroupBox groupBoxDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerNotBefore;
		private System.Windows.Forms.DateTimePicker dateTimePickerPromise;
		private System.Windows.Forms.DateTimePicker dateTimePickerRequest;
		private System.Windows.Forms.CheckBox checkBoxRequest;
		private System.Windows.Forms.CheckBox checkBoxPromise;
		private System.Windows.Forms.CheckBox checkBoxNotBefore;
		private System.Windows.Forms.Label labelBillToName;
		private System.Windows.Forms.Label labelBillToNum;
		private System.Windows.Forms.Label labelShipToName;
		private System.Windows.Forms.Label labelShipToNum;
		private System.Windows.Forms.Label labelQty;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
#endregion

		private OrderDtl _orderDtl;
		private Order _order;
		private System.Windows.Forms.NumericUpDown numericUpDownQty;
		private OrderDtlRel _orderDtlRel;
		private CoreFactory coreFactory;
		private string origShipToNum;

		#region Constructors
		public FormNewOrderDtlRel(Order order, OrderDtl orderDtl)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			coreFactory = UtilCoreFactory.createCoreFactory();
			_order = order;
			_orderDtl = orderDtl;
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
			this.buttonAccept = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxBillTo = new System.Windows.Forms.GroupBox();
			this.textBoxBillToName = new System.Windows.Forms.TextBox();
			this.labelBillToName = new System.Windows.Forms.Label();
			this.labelBillToNum = new System.Windows.Forms.Label();
			this.textBoxBillToNum = new System.Windows.Forms.TextBox();
			this.groupBoxShipTo = new System.Windows.Forms.GroupBox();
			this.textBoxShipToName = new System.Windows.Forms.TextBox();
			this.labelShipToName = new System.Windows.Forms.Label();
			this.labelShipToNum = new System.Windows.Forms.Label();
			this.textBoxShipToNum = new System.Windows.Forms.TextBox();
			this.buttonSearchShipTo = new System.Windows.Forms.Button();
			this.groupBoxDate = new System.Windows.Forms.GroupBox();
			this.checkBoxNotBefore = new System.Windows.Forms.CheckBox();
			this.checkBoxPromise = new System.Windows.Forms.CheckBox();
			this.checkBoxRequest = new System.Windows.Forms.CheckBox();
			this.dateTimePickerNotBefore = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerPromise = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerRequest = new System.Windows.Forms.DateTimePicker();
			this.labelQty = new System.Windows.Forms.Label();
			this.numericUpDownQty = new System.Windows.Forms.NumericUpDown();
			this.groupBoxBillTo.SuspendLayout();
			this.groupBoxShipTo.SuspendLayout();
			this.groupBoxDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQty)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonAccept
			// 
			this.buttonAccept.Location = new System.Drawing.Point(192, 192);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(112, 24);
			this.buttonAccept.TabIndex = 50;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(312, 192);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(112, 24);
			this.buttonCancel.TabIndex = 60;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// groupBoxBillTo
			// 
			this.groupBoxBillTo.Controls.Add(this.textBoxBillToName);
			this.groupBoxBillTo.Controls.Add(this.labelBillToName);
			this.groupBoxBillTo.Controls.Add(this.labelBillToNum);
			this.groupBoxBillTo.Controls.Add(this.textBoxBillToNum);
			this.groupBoxBillTo.Location = new System.Drawing.Point(8, 8);
			this.groupBoxBillTo.Name = "groupBoxBillTo";
			this.groupBoxBillTo.Size = new System.Drawing.Size(184, 80);
			this.groupBoxBillTo.TabIndex = 10;
			this.groupBoxBillTo.TabStop = false;
			this.groupBoxBillTo.Text = "Bill To";
			// 
			// textBoxBillToName
			// 
			this.textBoxBillToName.Location = new System.Drawing.Point(64, 48);
			this.textBoxBillToName.Name = "textBoxBillToName";
			this.textBoxBillToName.ReadOnly = true;
			this.textBoxBillToName.Size = new System.Drawing.Size(112, 20);
			this.textBoxBillToName.TabIndex = 20;
			this.textBoxBillToName.Text = "";
			// 
			// labelBillToName
			// 
			this.labelBillToName.Location = new System.Drawing.Point(16, 48);
			this.labelBillToName.Name = "labelBillToName";
			this.labelBillToName.Size = new System.Drawing.Size(48, 20);
			this.labelBillToName.TabIndex = 34;
			this.labelBillToName.Text = "Name:";
			this.labelBillToName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBillToNum
			// 
			this.labelBillToNum.Location = new System.Drawing.Point(16, 24);
			this.labelBillToNum.Name = "labelBillToNum";
			this.labelBillToNum.Size = new System.Drawing.Size(48, 20);
			this.labelBillToNum.TabIndex = 33;
			this.labelBillToNum.Text = "Num:";
			this.labelBillToNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxBillToNum
			// 
			this.textBoxBillToNum.Location = new System.Drawing.Point(64, 24);
			this.textBoxBillToNum.Name = "textBoxBillToNum";
			this.textBoxBillToNum.ReadOnly = true;
			this.textBoxBillToNum.Size = new System.Drawing.Size(112, 20);
			this.textBoxBillToNum.TabIndex = 10;
			this.textBoxBillToNum.Text = "";
			// 
			// groupBoxShipTo
			// 
			this.groupBoxShipTo.Controls.Add(this.textBoxShipToName);
			this.groupBoxShipTo.Controls.Add(this.labelShipToName);
			this.groupBoxShipTo.Controls.Add(this.labelShipToNum);
			this.groupBoxShipTo.Controls.Add(this.textBoxShipToNum);
			this.groupBoxShipTo.Controls.Add(this.buttonSearchShipTo);
			this.groupBoxShipTo.Location = new System.Drawing.Point(8, 96);
			this.groupBoxShipTo.Name = "groupBoxShipTo";
			this.groupBoxShipTo.Size = new System.Drawing.Size(184, 80);
			this.groupBoxShipTo.TabIndex = 20;
			this.groupBoxShipTo.TabStop = false;
			this.groupBoxShipTo.Text = "Ship To";
			// 
			// textBoxShipToName
			// 
			this.textBoxShipToName.Location = new System.Drawing.Point(64, 48);
			this.textBoxShipToName.Name = "textBoxShipToName";
			this.textBoxShipToName.ReadOnly = true;
			this.textBoxShipToName.Size = new System.Drawing.Size(112, 20);
			this.textBoxShipToName.TabIndex = 30;
			this.textBoxShipToName.Text = "";
			// 
			// labelShipToName
			// 
			this.labelShipToName.Location = new System.Drawing.Point(16, 48);
			this.labelShipToName.Name = "labelShipToName";
			this.labelShipToName.Size = new System.Drawing.Size(48, 20);
			this.labelShipToName.TabIndex = 34;
			this.labelShipToName.Text = "Name:";
			this.labelShipToName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelShipToNum
			// 
			this.labelShipToNum.Location = new System.Drawing.Point(16, 24);
			this.labelShipToNum.Name = "labelShipToNum";
			this.labelShipToNum.Size = new System.Drawing.Size(48, 20);
			this.labelShipToNum.TabIndex = 33;
			this.labelShipToNum.Text = "Num:";
			this.labelShipToNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxShipToNum
			// 
			this.textBoxShipToNum.Location = new System.Drawing.Point(64, 24);
			this.textBoxShipToNum.Name = "textBoxShipToNum";
			this.textBoxShipToNum.ReadOnly = true;
			this.textBoxShipToNum.Size = new System.Drawing.Size(80, 20);
			this.textBoxShipToNum.TabIndex = 10;
			this.textBoxShipToNum.Text = "";
			// 
			// buttonSearchShipTo
			// 
			this.buttonSearchShipTo.Location = new System.Drawing.Point(146, 26);
			this.buttonSearchShipTo.Name = "buttonSearchShipTo";
			this.buttonSearchShipTo.Size = new System.Drawing.Size(30, 16);
			this.buttonSearchShipTo.TabIndex = 20;
			this.buttonSearchShipTo.Text = "...";
			this.buttonSearchShipTo.Click += new System.EventHandler(this.buttonSearchShipTo_Click);
			// 
			// groupBoxDate
			// 
			this.groupBoxDate.Controls.Add(this.checkBoxNotBefore);
			this.groupBoxDate.Controls.Add(this.checkBoxPromise);
			this.groupBoxDate.Controls.Add(this.checkBoxRequest);
			this.groupBoxDate.Controls.Add(this.dateTimePickerNotBefore);
			this.groupBoxDate.Controls.Add(this.dateTimePickerPromise);
			this.groupBoxDate.Controls.Add(this.dateTimePickerRequest);
			this.groupBoxDate.Location = new System.Drawing.Point(208, 8);
			this.groupBoxDate.Name = "groupBoxDate";
			this.groupBoxDate.Size = new System.Drawing.Size(224, 104);
			this.groupBoxDate.TabIndex = 30;
			this.groupBoxDate.TabStop = false;
			this.groupBoxDate.Text = "Date";
			// 
			// checkBoxNotBefore
			// 
			this.checkBoxNotBefore.Location = new System.Drawing.Point(8, 72);
			this.checkBoxNotBefore.Name = "checkBoxNotBefore";
			this.checkBoxNotBefore.Size = new System.Drawing.Size(80, 20);
			this.checkBoxNotBefore.TabIndex = 50;
			this.checkBoxNotBefore.Text = "Not Before";
			this.checkBoxNotBefore.CheckedChanged += new System.EventHandler(this.checkBoxNotBefore_CheckedChanged);
			// 
			// checkBoxPromise
			// 
			this.checkBoxPromise.Location = new System.Drawing.Point(8, 48);
			this.checkBoxPromise.Name = "checkBoxPromise";
			this.checkBoxPromise.Size = new System.Drawing.Size(80, 20);
			this.checkBoxPromise.TabIndex = 30;
			this.checkBoxPromise.Text = "Promise";
			this.checkBoxPromise.CheckedChanged += new System.EventHandler(this.checkBoxPromise_CheckedChanged);
			// 
			// checkBoxRequest
			// 
			this.checkBoxRequest.Location = new System.Drawing.Point(8, 24);
			this.checkBoxRequest.Name = "checkBoxRequest";
			this.checkBoxRequest.Size = new System.Drawing.Size(80, 20);
			this.checkBoxRequest.TabIndex = 10;
			this.checkBoxRequest.Text = "Request";
			this.checkBoxRequest.CheckedChanged += new System.EventHandler(this.checkBoxRequest_CheckedChanged);
			// 
			// dateTimePickerNotBefore
			// 
			this.dateTimePickerNotBefore.Enabled = false;
			this.dateTimePickerNotBefore.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerNotBefore.Location = new System.Drawing.Point(88, 72);
			this.dateTimePickerNotBefore.Name = "dateTimePickerNotBefore";
			this.dateTimePickerNotBefore.Size = new System.Drawing.Size(128, 20);
			this.dateTimePickerNotBefore.TabIndex = 60;
			// 
			// dateTimePickerPromise
			// 
			this.dateTimePickerPromise.Enabled = false;
			this.dateTimePickerPromise.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerPromise.Location = new System.Drawing.Point(88, 48);
			this.dateTimePickerPromise.Name = "dateTimePickerPromise";
			this.dateTimePickerPromise.Size = new System.Drawing.Size(128, 20);
			this.dateTimePickerPromise.TabIndex = 40;
			// 
			// dateTimePickerRequest
			// 
			this.dateTimePickerRequest.Enabled = false;
			this.dateTimePickerRequest.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerRequest.Location = new System.Drawing.Point(88, 24);
			this.dateTimePickerRequest.Name = "dateTimePickerRequest";
			this.dateTimePickerRequest.Size = new System.Drawing.Size(128, 20);
			this.dateTimePickerRequest.TabIndex = 20;
			// 
			// labelQty
			// 
			this.labelQty.Location = new System.Drawing.Point(232, 144);
			this.labelQty.Name = "labelQty";
			this.labelQty.Size = new System.Drawing.Size(32, 20);
			this.labelQty.TabIndex = 42;
			this.labelQty.Text = "Qty:";
			this.labelQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownQty
			// 
			this.numericUpDownQty.DecimalPlaces = 2;
			this.numericUpDownQty.Location = new System.Drawing.Point(264, 144);
			this.numericUpDownQty.Maximum = new System.Decimal(new int[] {
																			 999999999,
																			 0,
																			 0,
																			 0});
			this.numericUpDownQty.Name = "numericUpDownQty";
			this.numericUpDownQty.Size = new System.Drawing.Size(88, 20);
			this.numericUpDownQty.TabIndex = 40;
			// 
			// FormNewOrderDtlRel
			// 
			this.AcceptButton = this.buttonAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 223);
			this.Controls.Add(this.numericUpDownQty);
			this.Controls.Add(this.groupBoxDate);
			this.Controls.Add(this.groupBoxShipTo);
			this.Controls.Add(this.groupBoxBillTo);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.labelQty);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewOrderDtlRel";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shipment";
			this.groupBoxBillTo.ResumeLayout(false);
			this.groupBoxShipTo.ResumeLayout(false);
			this.groupBoxDate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQty)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public Order order
		{
			get
			{
				return _order;
			}
			set
			{
				_order = value;
			}
		}

		public OrderDtl orderDtl
		{
			get
			{
				return _orderDtl;
			}
			set
			{
				_orderDtl = value;
			}
		}

		public OrderDtlRel orderDtlRel
		{
			get
			{
				return _orderDtlRel;
			}
			set
			{
				_orderDtlRel = value;
				objectToScreen (_orderDtlRel);
				origShipToNum = value.getShipToNum();
			}
		}
		#endregion

		#region Methods
		private void MyInitialize()
		{
			textBoxBillToNum.Text = _order.getBillToNum();
			textBoxBillToName.Text = _order.getBillToName();
			if (_orderDtl.getQtyPackSize().Equals(0.0))
			{
				numericUpDownQty.Increment = 1;
				numericUpDownQty.Value = 1;
			}
			else
			{
				numericUpDownQty.Increment = (decimal)(_orderDtl.getQtyPackSize());
				numericUpDownQty.Value = (decimal)(_orderDtl.getQtyPackSize());
			}
		}

		private void screenToObject (ref OrderDtlRel orderDtlRel)
		{
			if (orderDtlRel == null)
				orderDtlRel = new OrderDtlRel();
			
			bool isNew = true;
			if (origShipToNum != null)
				isNew = !origShipToNum.Equals(textBoxShipToNum.Text);
			if (isNew)
			{
				try 
				{
					Person person = coreFactory.readPerson(_order.getPlant(),textBoxShipToNum.Text);
					orderDtlRel.setShipToNum (person.getId());
					orderDtlRel.setShipToName (person.getName());
					orderDtlRel.setShipToAdd1 (person.getAddress1());
					orderDtlRel.setShipToAdd2 (person.getAddress2());
					orderDtlRel.setShipToAdd3 (person.getAddress3());
					orderDtlRel.setShipToAdd4 (person.getAddress4());
					orderDtlRel.setShipToAdd5 (person.getAddress5());
					orderDtlRel.setShipToAdd6 (person.getAddress6());
					orderDtlRel.setShipPostZip (person.getZipCode());
					orderDtlRel.setPhoneNum (person.getPhone());
				}
				catch (Exception ex)
				{
					FormException frmEx = new FormException(ex);
					frmEx.ShowDialog(this);
				}
			}
			orderDtlRel.setQtyOrd (decimal.ToDouble(numericUpDownQty.Value));
			
			if (checkBoxRequest.Checked)
				orderDtlRel.setDateRequest(dateTimePickerRequest.Value);
			else
				orderDtlRel.setDateRequest(DateUtil.MinValue);

			if (checkBoxPromise.Checked)
				orderDtlRel.setDatePromise(dateTimePickerPromise.Value);
			else
				orderDtlRel.setDatePromise(DateUtil.MinValue);
			if (checkBoxNotBefore.Checked)
				orderDtlRel.setDateNotBefore(dateTimePickerNotBefore.Value);
			else
				orderDtlRel.setDateNotBefore(DateUtil.MinValue);
		}

		public void objectToScreen (OrderDtlRel orderDtlRel)
		{
			numericUpDownQty.Value = (decimal)(orderDtlRel.getQtyOrd());
			if (!orderDtlRel.getDateRequest().Equals(DateUtil.MinValue))
			{
				checkBoxRequest.Checked = true;
				dateTimePickerRequest.Value = orderDtlRel.getDateRequest();
			}
			else
				checkBoxRequest.Checked = false;
			if (!orderDtlRel.getDatePromise().Equals(DateUtil.MinValue))
			{
				checkBoxPromise.Checked = true;
				dateTimePickerPromise.Value = orderDtlRel.getDatePromise();
			}
			else
				checkBoxPromise.Checked = false;
			if (!orderDtlRel.getDateNotBefore().Equals(DateUtil.MinValue))
			{
				checkBoxNotBefore.Checked = true;
				dateTimePickerNotBefore.Value = orderDtlRel.getDateNotBefore();
			}
			else
				checkBoxNotBefore.Checked = false;
			textBoxShipToNum.Text = _orderDtlRel.getShipToNum();
			textBoxShipToName.Text = _orderDtlRel.getShipToName();
		}

		private void hasToBeDouble (TextBox textBox)
		{
			if (!textBox.Text.Equals(string.Empty) && !NumberUtil.isDoubleNumber(textBox.Text) && (!textBox.Text.Equals(".")) && (!textBox.Text.Equals(",")))
			{
				int pos = textBox.SelectionStart;
				if (pos == 0)
					textBox.Text = textBox.Text.Substring(1,textBox.Text.Length-1);
				else
				{
					string auxStr = textBox.Text;
					textBox.Text = auxStr.Substring (0,pos-1) + auxStr.Substring(pos,auxStr.Length-pos);
					textBox.SelectionStart = pos - 1;
					textBox.SelectionLength = 0;
				}
			}
			else
			{
				int pos = textBox.SelectionStart;
				int len = textBox.SelectionLength;
				for (int i=0; i<textBox.Text.Length; i++)
					if (textBox.Text[i].Equals(','))
						textBox.Text = textBox.Text.Substring(0,i) + "." + textBox.Text.Substring (i+1);
				if (pos >= 0)
					textBox.SelectionStart = pos;
				if (len >= 0)
					textBox.SelectionLength = len;
			}
		}
		#endregion

		#region Events
		private void checkBoxNotBefore_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerNotBefore.Enabled = checkBoxNotBefore.Checked;
		}

		private void checkBoxPromise_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerPromise.Enabled = checkBoxPromise.Checked;
		}

		private void checkBoxRequest_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerRequest.Enabled = checkBoxRequest.Checked;
		}

		private void buttonSearchShipTo_Click(object sender, System.EventArgs e)
		{
			PersonSearchForm personSearchForm = new PersonSearchForm("Persons ...");
			personSearchForm.setBillToCust (_order.getBillToNum());
			personSearchForm.setFilter ("C");
			personSearchForm.ShowDialog();
	
			if ((personSearchForm.DialogResult == DialogResult.OK) &&
				(personSearchForm.getSelected() != null))
			{
				textBoxShipToNum.Text = personSearchForm.getSelected()[1];
				textBoxShipToName.Text = personSearchForm.getSelected()[2];
				//				this.loadBillTo();
			}
		}

		private void buttonAccept_Click(object sender, System.EventArgs e)
		{
			try 
			{
				bool exists = coreFactory.existsPerson(_order.getPlant(),textBoxShipToNum.Text);
				if ((exists  && !_orderDtl.hasDtlRel(textBoxShipToNum.Text)) || textBoxShipToNum.Text.Equals(origShipToNum))
				{
					this.DialogResult = DialogResult.OK;
					screenToObject (ref _orderDtlRel);
				}
				else
				{
					if (exists || textBoxBillToNum.Text.Equals(origShipToNum))
						MessageBox.Show ("This costumer already has a shipment assigned.", "Waring",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					else
						MessageBox.Show ("You must determine who will receive this product.", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException(ex);
				frmEx.ShowDialog(this);
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("All changes will be lost." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				this.Close();
		}
		#endregion


	}
}
