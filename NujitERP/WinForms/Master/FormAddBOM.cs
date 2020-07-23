using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms.SearchForms;
using Nujit.NujitERP.WinForms.Util;

namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for FormAddBOM.
	/// </summary>
	public class FormAddBOM : System.Windows.Forms.Form
	{
		private string prodId;
		private int seqId;
		private string matId;
		private int matSeq;
		private Product product;
		private BomSum bomSumObj;
		private int returnCode;
		public static int ADD_PRESSED = 100;
		public static int CANCEL_PRESSED = 200;

		private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbMatSeq;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblProdId;
		private System.Windows.Forms.TextBox txtTool;
		private System.Windows.Forms.TextBox txtPos;
		private System.Windows.Forms.TextBox txtMethod;
		private System.Windows.Forms.TextBox txtUnit;
		private System.Windows.Forms.TextBox txtProdQty;
		private System.Windows.Forms.TextBox txtProdUnit;
		private System.Windows.Forms.Label lbProdSeq;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label lbMatId;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lbProdDesc;
		private System.Windows.Forms.Label lbMatDesc;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAddBOM()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.prodId = "";
			this.seqId = 0;
			this.matId = "";
			this.matSeq = 0;
		}

		public FormAddBOM(string prodId, int seqId)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.prodId = prodId;
			this.seqId = seqId;
			this.matId = "";
			this.matSeq = 0;
		}

		public FormAddBOM(BomSum bomSumObj)
		{
			InitializeComponent();
			this.prodId = bomSumObj.getBMS_ProdID();
			this.seqId = bomSumObj.getBMS_Seq();
			this.matId = bomSumObj.getBMS_MatID();
			this.matSeq = bomSumObj.getBMS_MatSeq();

			this.Text = "Edit Material";
			button1.Text = "Update";
			button3.Enabled = false;
			button3.Visible = false;

			lblProdId.Text = prodId;
			lbProdSeq.Text = seqId.ToString();
			lbMatId.Text = matId;
			
			cmbMatSeq.Text = "";
			cmbMatSeq.DataSource = coreFactory.getValidsSeqsForProduct(matId);	

			if (cmbMatSeq.Items.IndexOf(matSeq.ToString())>-1)
				cmbMatSeq.SelectedIndex = cmbMatSeq.Items.IndexOf(matSeq.ToString());
			else if (cmbMatSeq.Items.Count>0)
				cmbMatSeq.SelectedIndex = 0;
			else {
				cmbMatSeq.DataSource = null;
				cmbMatSeq.Items.Add("0");
				cmbMatSeq.SelectedIndex = 0;
			}
			
			if (cmbMatSeq.Text != "")
				this.matSeq = int.Parse(cmbMatSeq.Text);

			txtUnit.Text = bomSumObj.getBMS_Uom().ToString();
			txtPos.Text = bomSumObj.getBMS_MatOrdNum().ToString();
			txtMethod.Text = bomSumObj.getBMS_MethodRank().ToString();
			txtTool.Text = bomSumObj.getBMS_TLID().ToString();
			txtProdQty.Text = bomSumObj.getBMS_PrQty().ToString();
			txtProdUnit.Text = bomSumObj.getBMS_PrQtyUom().ToString();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAddBOM));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbMatId = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.txtProdUnit = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtProdQty = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtTool = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtPos = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMethod = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbMatSeq = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lbProdSeq = new System.Windows.Forms.Label();
			this.lblProdId = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbProdDesc = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lbMatDesc = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lbMatDesc,
																					this.label14,
																					this.lbMatId,
																					this.button3,
																					this.txtProdUnit,
																					this.label10,
																					this.txtProdQty,
																					this.label9,
																					this.txtUnit,
																					this.label8,
																					this.txtTool,
																					this.label7,
																					this.txtPos,
																					this.label3,
																					this.txtMethod,
																					this.label6,
																					this.cmbMatSeq,
																					this.label4,
																					this.label5});
			this.groupBox1.Location = new System.Drawing.Point(16, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 184);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "BOM Details";
			// 
			// lbMatId
			// 
			this.lbMatId.Location = new System.Drawing.Point(104, 24);
			this.lbMatId.Name = "lbMatId";
			this.lbMatId.Size = new System.Drawing.Size(104, 24);
			this.lbMatId.TabIndex = 24;
			this.lbMatId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(208, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(32, 21);
			this.button3.TabIndex = 23;
			this.button3.Text = "...";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// txtProdUnit
			// 
			this.txtProdUnit.Location = new System.Drawing.Point(312, 152);
			this.txtProdUnit.Name = "txtProdUnit";
			this.txtProdUnit.Size = new System.Drawing.Size(96, 20);
			this.txtProdUnit.TabIndex = 22;
			this.txtProdUnit.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(224, 152);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 21;
			this.label10.Text = "Production Unit:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtProdQty
			// 
			this.txtProdQty.Location = new System.Drawing.Point(104, 152);
			this.txtProdQty.Name = "txtProdQty";
			this.txtProdQty.Size = new System.Drawing.Size(96, 20);
			this.txtProdQty.TabIndex = 20;
			this.txtProdQty.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 152);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 23);
			this.label9.TabIndex = 19;
			this.label9.Text = "Production Qty.:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUnit
			// 
			this.txtUnit.Location = new System.Drawing.Point(312, 120);
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(96, 20);
			this.txtUnit.TabIndex = 18;
			this.txtUnit.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(224, 120);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 17;
			this.label8.Text = "Unit:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTool
			// 
			this.txtTool.Location = new System.Drawing.Point(104, 120);
			this.txtTool.Name = "txtTool";
			this.txtTool.Size = new System.Drawing.Size(96, 20);
			this.txtTool.TabIndex = 16;
			this.txtTool.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 15;
			this.label7.Text = "Tool:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPos
			// 
			this.txtPos.Location = new System.Drawing.Point(312, 88);
			this.txtPos.Name = "txtPos";
			this.txtPos.Size = new System.Drawing.Size(96, 20);
			this.txtPos.TabIndex = 14;
			this.txtPos.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(224, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "Position:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMethod
			// 
			this.txtMethod.Location = new System.Drawing.Point(104, 88);
			this.txtMethod.Name = "txtMethod";
			this.txtMethod.Size = new System.Drawing.Size(96, 20);
			this.txtMethod.TabIndex = 12;
			this.txtMethod.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Method:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbMatSeq
			// 
			this.cmbMatSeq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMatSeq.Location = new System.Drawing.Point(328, 24);
			this.cmbMatSeq.Name = "cmbMatSeq";
			this.cmbMatSeq.Size = new System.Drawing.Size(80, 21);
			this.cmbMatSeq.Sorted = true;
			this.cmbMatSeq.TabIndex = 9;
			this.cmbMatSeq.SelectedIndexChanged += new System.EventHandler(this.cmbMatSeq_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(256, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Mat. Seq.:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Material Id:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(136, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(240, 312);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lbProdDesc,
																					this.label12,
																					this.lbProdSeq,
																					this.lblProdId,
																					this.label2,
																					this.label1});
			this.groupBox3.Location = new System.Drawing.Point(16, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(424, 88);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Product";
			// 
			// lbProdSeq
			// 
			this.lbProdSeq.Location = new System.Drawing.Point(328, 24);
			this.lbProdSeq.Name = "lbProdSeq";
			this.lbProdSeq.Size = new System.Drawing.Size(88, 24);
			this.lbProdSeq.TabIndex = 9;
			this.lbProdSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblProdId
			// 
			this.lblProdId.Location = new System.Drawing.Point(80, 24);
			this.lblProdId.Name = "lblProdId";
			this.lblProdId.Size = new System.Drawing.Size(152, 24);
			this.lblProdId.TabIndex = 8;
			this.lblProdId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(256, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Sequence:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Product Id:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbProdDesc
			// 
			this.lbProdDesc.Location = new System.Drawing.Point(80, 56);
			this.lbProdDesc.Name = "lbProdDesc";
			this.lbProdDesc.Size = new System.Drawing.Size(336, 24);
			this.lbProdDesc.TabIndex = 11;
			this.lbProdDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 23);
			this.label12.TabIndex = 10;
			this.label12.Text = "Description:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMatDesc
			// 
			this.lbMatDesc.Location = new System.Drawing.Point(104, 56);
			this.lbMatDesc.Name = "lbMatDesc";
			this.lbMatDesc.Size = new System.Drawing.Size(304, 24);
			this.lbMatDesc.TabIndex = 26;
			this.lbMatDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 56);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 23);
			this.label14.TabIndex = 25;
			this.label14.Text = "Description:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormAddBOM
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(456, 352);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox3,
																		  this.button2,
																		  this.button1,
																		  this.groupBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormAddBOM";
			this.Text = "Add Material";
			this.Load += new System.EventHandler(this.FormAddBOM_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormAddBOM_Load(object sender, System.EventArgs e)
		{
			lblProdId.Text = prodId;
			lbProdSeq.Text = seqId.ToString();
			Product prod = coreFactory.readProduct(prodId);			
			lbProdDesc.Text = prod.getDes1();
			if (matId!="") {
				prod = coreFactory.readProduct(matId);			
				lbMatDesc.Text = prod.getDes1();
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			returnCode = CANCEL_PRESSED;
			this.Visible = false;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try {
				int method = int.Parse(txtMethod.Text);
				int pos = int.Parse(txtPos.Text);
				int matSeq = 0;
				if (cmbMatSeq.Text!="")
					matSeq = int.Parse(cmbMatSeq.Text);
				decimal prodQty = decimal.Parse(txtProdQty.Text);

				bomSumObj = new BomSum(prodId, "", seqId, "", 0, method, pos, matId, matSeq, txtTool.Text, 0, txtUnit.Text, prodQty, txtProdUnit.Text, 0, "", "", 0, 0, 0, "", "", "", DateTime.Now, "");
				returnCode = ADD_PRESSED;
				this.Visible = false;
			} catch(System.Exception){
				MessageBox.Show("Please verify all the fields");
			}
		}

		public BomSum getBomSumObject() {
			return bomSumObj;
		}

		public int getReturnCode(){
			return returnCode;
		}
		private void button3_Click(object sender, System.EventArgs e)
		{
			ProductSearchForm productSearchForm = new ProductSearchForm("Material search", true);
			productSearchForm.ShowDialog();
			
			if (productSearchForm.DialogResult == DialogResult.OK){
				string[] v = productSearchForm.getSelected();
				if (v!=null) {
					string id = v[0];
					objectToScreen(id);
				}
			}
			productSearchForm.Dispose();
		}

		private	void objectToScreen(string id){
			if (coreFactory.existsProduct(id)){
				product = coreFactory.readProduct(id);
				lbMatId.Text = product.getProdID();
				matId = product.getProdID();
				cmbMatSeq.Text = "";
			
				if (matId != "") {
					//cmbMatSeq.DataSource = null;
					Product prod = coreFactory.readProduct(matId);
					lbMatDesc.Text = prod.getDes1();
					cmbMatSeq.DataSource = coreFactory.getValidsSeqsForProduct(matId);	

					int matSeq = 0;
					if (cmbMatSeq.Items.IndexOf(product.getSeqLast().ToString())>-1)
						cmbMatSeq.SelectedIndex = cmbMatSeq.Items.IndexOf(product.getSeqLast().ToString());
					else if (cmbMatSeq.Items.Count>0)
						cmbMatSeq.SelectedIndex = 0;
					else {
						cmbMatSeq.DataSource = null;
						cmbMatSeq.Items.Add("0");
						cmbMatSeq.SelectedIndex = 0;
					}
					
					if (cmbMatSeq.Text != "")
						matSeq = int.Parse(cmbMatSeq.Text);

					if  (coreFactory.existsBomSum(prodId, seqId, matId, matSeq)) {
						BomSum bomSumObj = coreFactory.readBomSum(prodId, seqId, matId, matSeq);
						txtUnit.Text = bomSumObj.getBMS_Uom().ToString();
						txtPos.Text = bomSumObj.getBMS_MatOrdNum().ToString();
						txtMethod.Text = bomSumObj.getBMS_MethodRank().ToString();
						txtTool.Text = bomSumObj.getBMS_TLID().ToString();
						txtProdQty.Text = bomSumObj.getBMS_PrQty().ToString();
						txtProdUnit.Text = bomSumObj.getBMS_PrQtyUom().ToString();
					} else {
						txtUnit.Text = "";
						txtPos.Text = "1";
						txtMethod.Text = "0";
						txtTool.Text = "";
						txtProdQty.Text = "1";
						txtProdUnit.Text = "";
					}
				}
			}
		}

		private	void updateMatInfo() {
			int matSeq = 0;
			
			if (cmbMatSeq.Text != "")
				matSeq = int.Parse(cmbMatSeq.Text);


			if  (coreFactory.existsBomSum(prodId, seqId, matId, matSeq)) {
				BomSum bomSumObj = coreFactory.readBomSum(prodId, seqId, matId, matSeq);
				txtUnit.Text = bomSumObj.getBMS_Uom().ToString();
				txtPos.Text = bomSumObj.getBMS_MatOrdNum().ToString();
				txtMethod.Text = bomSumObj.getBMS_MethodRank().ToString();
				txtTool.Text = bomSumObj.getBMS_TLID().ToString();
				txtProdQty.Text = bomSumObj.getBMS_PrQty().ToString();
				txtProdUnit.Text = bomSumObj.getBMS_PrQtyUom().ToString();
			} else {
				txtUnit.Text = "";
				txtPos.Text = "1";
				txtMethod.Text = "0";
				txtTool.Text = "";
				txtProdQty.Text = "1";
				txtProdUnit.Text = "";
			}
		}

		private void cmbMatSeq_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbMatSeq.SelectedIndex>-1) {
                updateMatInfo();
			}
		}
	}
}
