using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.Reports.BOMReport;

namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for FormMatUsage.
	/// </summary>
	public class FormMatUsage : System.Windows.Forms.Form
	{
		private string prodId;
		private int seqId;
		private decimal Qoh;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGrid gridParentMats;
		private System.Windows.Forms.CheckBox cbFinal;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbQty;
		private System.Windows.Forms.Label lbMaterials;
		private System.Windows.Forms.Label lbInventory;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMatUsage()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.prodId = "";
			this.seqId = 0;
		}

		public FormMatUsage(string prodId, int seqId)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.prodId = prodId;
			this.seqId = seqId;
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbFinal = new System.Windows.Forms.CheckBox();
			this.lbInventory = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lbQty = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lbMaterials = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.gridParentMats = new System.Windows.Forms.DataGrid();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridParentMats)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.cbFinal,
																					this.lbInventory,
																					this.label10,
																					this.lbQty,
																					this.label6,
																					this.lbMaterials,
																					this.label8,
																					this.gridParentMats,
																					this.label3,
																					this.label4,
																					this.label2,
																					this.label1});
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(664, 344);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Product usage";
			// 
			// cbFinal
			// 
			this.cbFinal.Location = new System.Drawing.Point(504, 24);
			this.cbFinal.Name = "cbFinal";
			this.cbFinal.Size = new System.Drawing.Size(152, 24);
			this.cbFinal.TabIndex = 15;
			this.cbFinal.Text = "Show final products only";
			this.cbFinal.CheckedChanged += new System.EventHandler(this.cbFinal_CheckedChanged);
			// 
			// lbInventory
			// 
			this.lbInventory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbInventory.Location = new System.Drawing.Point(568, 56);
			this.lbInventory.Name = "lbInventory";
			this.lbInventory.Size = new System.Drawing.Size(72, 24);
			this.lbInventory.TabIndex = 14;
			this.lbInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(504, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 24);
			this.label10.TabIndex = 13;
			this.label10.Text = "Inventory:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbQty
			// 
			this.lbQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbQty.Location = new System.Drawing.Point(344, 56);
			this.lbQty.Name = "lbQty";
			this.lbQty.Size = new System.Drawing.Size(72, 24);
			this.lbQty.TabIndex = 12;
			this.lbQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(280, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 24);
			this.label6.TabIndex = 11;
			this.label6.Text = "Total Qty.:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMaterials
			// 
			this.lbMaterials.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbMaterials.Location = new System.Drawing.Point(80, 56);
			this.lbMaterials.Name = "lbMaterials";
			this.lbMaterials.Size = new System.Drawing.Size(72, 24);
			this.lbMaterials.TabIndex = 10;
			this.lbMaterials.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 24);
			this.label8.TabIndex = 9;
			this.label8.Text = "Materials:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gridParentMats
			// 
			this.gridParentMats.CaptionVisible = false;
			this.gridParentMats.DataMember = "";
			this.gridParentMats.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridParentMats.Location = new System.Drawing.Point(16, 88);
			this.gridParentMats.Name = "gridParentMats";
			this.gridParentMats.ReadOnly = true;
			this.gridParentMats.Size = new System.Drawing.Size(632, 240);
			this.gridParentMats.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(344, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 24);
			this.label3.TabIndex = 7;
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(280, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Sequence:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(80, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 24);
			this.label2.TabIndex = 2;
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Product Id:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(352, 376);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "Close";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(256, 376);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 5;
			this.button1.Text = "Print Report";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormMatUsage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(696, 414);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.button2,
																		  this.groupBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormMatUsage";
			this.Text = "Material usage";
			this.Load += new System.EventHandler(this.FormMatUsage_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridParentMats)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void FormMatUsage_Load(object sender, System.EventArgs e)
		{
			label2.Text = prodId;
			label3.Text = seqId.ToString();
			Inventory inventory = UtilCoreFactory.createCoreFactory().readInventory(prodId);
            Qoh = inventory.getTotalInventory(seqId);
			lbInventory.Text = Qoh.ToString();
			gridFill();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void gridFill()
		{
			DataSet dsMaterials = generateParentMaterialsDataSet();
			if ((dsMaterials != null) && (dsMaterials.Tables.Count) >0 ){
				this.gridParentMats.DataSource = dsMaterials.Tables[0];
				gridParentMats.Refresh();
			} else {
				this.gridParentMats.DataSource = null;
				MessageBox.Show("The material could not be found or something went wrong");
			}

			DataTable dataTable = null;
			dataTable = dsMaterials.Tables[0];
	            
			gridParentMats.PreferredColumnWidth	= 100;
			DataGridTableStyle dgdtblStyle		= new DataGridTableStyle();
			dgdtblStyle.MappingName				= dataTable.TableName;
			gridParentMats.TableStyles.Clear();
			dgdtblStyle.AllowSorting			= true;
			dgdtblStyle.PreferredRowHeight		= 22;
	
			this.Cursor = Cursors.Default;
			dgdtblStyle.AllowSorting         = true;
			dgdtblStyle.RowHeadersVisible    = true;

			DataGridColumnStyle GridColStyle;

			GridColStyle = new DataGridTextBoxColumn();
			GridColStyle.MappingName = "MaterialID";
			GridColStyle.HeaderText = "Material ID";
			GridColStyle.Width = 120;
			dgdtblStyle.GridColumnStyles.Add(GridColStyle);

			GridColStyle = new DataGridTextBoxColumn();
			GridColStyle.MappingName = "Desc";
			GridColStyle.HeaderText = "Description";
			GridColStyle.Width = 255;
			dgdtblStyle.GridColumnStyles.Add(GridColStyle);
			
			GridColStyle = new DataGridTextBoxColumn();
			GridColStyle.MappingName = "MaterialSeq";
			GridColStyle.HeaderText = "Material Seq";
			GridColStyle.Width = 100;
			dgdtblStyle.GridColumnStyles.Add(GridColStyle);

			GridColStyle = new DataGridTextBoxColumn();
			GridColStyle.MappingName = "Qty";
			GridColStyle.HeaderText = "Qty";
			GridColStyle.Width = 100;
			dgdtblStyle.GridColumnStyles.Add(GridColStyle);

			dgdtblStyle.ReadOnly = true;

			gridParentMats.TableStyles.Add(dgdtblStyle);

			gridParentMats.SetDataBinding(dsMaterials,dataTable.TableName);
			DataView dataView		= new DataView(dataTable);
			dataView.AllowEdit		= false;
			dataView.AllowDelete	= false;
			dataView.AllowNew = false;
			dataView.Sort = "MaterialID desc";

			gridParentMats.Refresh();
		}

		private DataSet generateParentMaterialsDataSet(){
			DataTable parentMatDataTable = new DataTable();
			DataRow dataRow;
			int matCount;
			decimal matQty = 0;

            parentMatDataTable.TableName = "parentMaterials";
			parentMatDataTable.Columns.Add(new DataColumn("MaterialID", typeof(string)));
			parentMatDataTable.Columns.Add(new DataColumn("Desc", typeof(string)));
			parentMatDataTable.Columns.Add(new DataColumn("MaterialSeq", typeof(int)));
			parentMatDataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));

			string[][] vec = getParentMaterialsArray(prodId,seqId, cbFinal.Checked);

			matCount = vec.GetLength(0);

			for(int x = 0; x < vec.GetLength(0); x++){
				dataRow = parentMatDataTable.NewRow();
				dataRow.ItemArray = vec[x];
				parentMatDataTable.Rows.Add(dataRow);
				matQty = matQty + (decimal.Parse(vec[x][3]));
			}

			lbMaterials.Text = matCount.ToString();
			lbQty.Text = matQty.ToString();

			DataSet parentMatDataSet = new DataSet();
			parentMatDataSet.Tables.Add(parentMatDataTable);

			return parentMatDataSet;
		}

		private string[][] getParentMaterialsArray(string matId, int matSeqId, bool final) {

			ArrayList matList = new ArrayList();
			ArrayList matListFinal = new ArrayList();

			string[] lineArrayP = new string[4];
			lineArrayP[0] = matId;
			lineArrayP[1] = "";
			lineArrayP[2] = matSeqId.ToString();
			lineArrayP[3] = "0";
			matList.Add(lineArrayP);
			matListFinal.Add(lineArrayP);

			matList = getParentMaterials(matId, matSeqId, matList, matListFinal, final);
			string[][] returnArray = new string[matList.Count-1][];

			for(int x = 1; x < matList.Count; x++)
				returnArray[x-1] = (string[])matList[x];
			return returnArray;
		}


		private ArrayList getParentMaterials(string matId, int matSeqId, ArrayList matList, ArrayList matListFinal, bool final) {
		
			string[][] nodesUp = null;

            try {
				nodesUp = UtilCoreFactory.createCoreFactory().getParentMaterials(matId,matSeqId);
				if (nodesUp.GetLength(0)>0) {
					for(int x = 0; x < nodesUp.GetLength(0); x++){
						string[] lineArray = new string[4];
						string matIdP = nodesUp[x][0];
						string descP = nodesUp[x][1];
						int matSeqIdP = int.Parse(nodesUp[x][2]);
						string matQtyP = nodesUp[x][3];

						//MessageBox.Show(matIdP);

						lineArray[0] = matIdP;
						lineArray[1] = descP;
						lineArray[2] = matSeqIdP.ToString();
						lineArray[3] = UtilCoreFactory.createCoreFactory().QtyInSubmaterialsOf(prodId, seqId, matIdP, matSeqIdP).ToString();
						if (!findMatInArray(lineArray, matListFinal)) {
							if (!final)
								matList.Add(lineArray);
							matListFinal.Add(lineArray);
							matList = getParentMaterials(matIdP, matSeqIdP, matList, matListFinal, final);
						}
					} 
				} else {
					string[] lineArray = new string[4];
					lineArray[0] = matId;
					Product prod = UtilCoreFactory.createCoreFactory().readProduct(matId);
					lineArray[1] = prod.getDes1();
					lineArray[2] = matSeqId.ToString();
					lineArray[3] =  UtilCoreFactory.createCoreFactory().QtyInSubmaterialsOf(prodId, seqId, matId, matSeqId).ToString();
					if (!findMatInArray(lineArray, matList)) {
						matList.Add(lineArray);
						matListFinal.Add(lineArray);
					}
				}
			} catch (NujitException ne) {
				MessageBox.Show(ne.Message);
			}
			return matList;
		}

		private bool findMatInArray(string[] material, ArrayList list) {
			for(int x = 0; x < list.Count; x++){
				string[] lineArray = (string[])list[x];
				if ((material[0] == lineArray[0]) && (int.Parse(material[2]) == int.Parse(lineArray[2])))
					return true;
			}

			return false;
		}

		private void cbFinal_CheckedChanged(object sender, System.EventArgs e)
		{
			gridFill();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//this.Cursor = System.Windows.Forms.Cursors.Default;
			DataSet dsMaterials = generateParentMaterialsDataSet();
			FormBOMReport bomr = new FormBOMReport(dsMaterials, prodId, seqId, Qoh, cbFinal.Checked);
			try {
					bomr.ShowDialog();
					bomr.Dispose();
			} catch (Exception exp){
				MessageBox.Show("Fatal Error: "+exp.Message);
			}
		}
	}
}
