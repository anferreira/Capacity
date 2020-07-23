using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms.CustomControls;

namespace GridScheduling.gui.schedule
{
	/// <summary>
	/// Summary description for GridPaintOrdersDtl.
	/// </summary>
	public class GridPaintOrdersDtl : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dgridPOTotals;
		private System.Windows.Forms.Button button1;
		private int pOrow;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GridPaintOrdersDtl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.pOrow = 0;
		}

		public GridPaintOrdersDtl(int pOrow)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.pOrow = pOrow;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GridPaintOrdersDtl));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgridPOTotals = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridPOTotals)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.dgridPOTotals});
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(824, 320);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Paint Order Details";
			// 
			// dgridPOTotals
			// 
			this.dgridPOTotals.DataMember = "";
			this.dgridPOTotals.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridPOTotals.Location = new System.Drawing.Point(16, 24);
			this.dgridPOTotals.Name = "dgridPOTotals";
			this.dgridPOTotals.ReadOnly = true;
			this.dgridPOTotals.Size = new System.Drawing.Size(792, 280);
			this.dgridPOTotals.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(376, 344);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// GridPaintOrdersDtl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 374);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.groupBox1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "GridPaintOrdersDtl";
			this.Text = "Paint Order Scheduling Colour Detail";
			this.Load += new System.EventHandler(this.GridPaintOrdersDtl_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgridPOTotals)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void GridPaintOrdersDtl_Load(object sender, System.EventArgs e)
		{

			switch (pOrow) {
				case 0:
					dgridPOTotals.CaptionText = "Colour 1";
					dgridPOTotals.CaptionBackColor = Color.Red;
					break;
				case 1:
					dgridPOTotals.CaptionText = "Colour 2";
					dgridPOTotals.CaptionBackColor = Color.Blue;
					break;
				case 2:
					dgridPOTotals.CaptionText = "Colour 3";
					dgridPOTotals.CaptionBackColor = Color.Green;
					break;
				case 3:
					dgridPOTotals.CaptionText = "Colour 4";
					dgridPOTotals.CaptionBackColor = Color.Yellow;
					break;
				default:
					break;
			}

			DataSet dsHotList = generateHotListPaintOrderDataSet();
			if (dsHotList != null && dsHotList.Tables.Count >0 ){
				this.dgridPOTotals.DataSource = dsHotList.Tables[0];
				dgridPOTotals.Refresh();
			} else {
				this.dgridPOTotals.DataSource = null;
				MessageBox.Show("HotList is empty or something went wrong");
			}

			DataTable dataTable = null;
			dataTable = dsHotList.Tables[0];
	            
			dgridPOTotals.PreferredColumnWidth	= 100;
			DataGridTableStyle dgdtblStyle		= new DataGridTableStyle();
			dgdtblStyle.MappingName				= dataTable.TableName;
			dgridPOTotals.TableStyles.Clear();
			dgdtblStyle.AllowSorting			= true;
			dgdtblStyle.PreferredRowHeight		= 22;
	
			this.Cursor = Cursors.Default;
			dgdtblStyle.AllowSorting         = false;
			dgdtblStyle.RowHeadersVisible    = true;

			DataGridColumnStyle GridSeqStyle;

			/*PropertyDescriptorCollection pcol = this.BindingContext[dsHotList, dataTable.TableName].GetItemProperties();

			GridDelColumn = new ColumnStyle(pcol[dataTable.TableName]);
			GridDelColumn.MappingName = "HOT_ProdID";
			GridDelColumn.HeaderText = "Prod.ID";
			GridDelColumn.Width = 109;
			dgdtblStyle.GridColumnStyles.Add(GridDelColumn);*/

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_ProdID";
			GridSeqStyle.HeaderText = "Prod.ID";
			GridSeqStyle.Width = 105;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Seq";
			GridSeqStyle.HeaderText = "Seq.";
			GridSeqStyle.Width = 47;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "MatId";
			GridSeqStyle.HeaderText = "Mat.Id.";
			GridSeqStyle.Width = 105;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "MatSeq";
			GridSeqStyle.HeaderText = "Mat.Seq.";
			GridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "QOHRaw";
			GridSeqStyle.HeaderText = "QOH Raw";
			GridSeqStyle.Width = 64;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "QOHPlan";
			GridSeqStyle.HeaderText = "QOH Planned";
			GridSeqStyle.Width = 64;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_PastDue";
			GridSeqStyle.HeaderText = "Past Due";
			GridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day001";
			GridSeqStyle.HeaderText = "Day 1";
			GridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day002";
			GridSeqStyle.HeaderText = "Day 2";
			GridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day003";
			GridSeqStyle.HeaderText = "Day 3";
			GridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day004";
			GridSeqStyle.HeaderText = "Day 4";
			GridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day005";
			GridSeqStyle.HeaderText = "Day 5";
			GridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			dgdtblStyle.ReadOnly = true;

			dgridPOTotals.TableStyles.Add(dgdtblStyle);

			dgridPOTotals.SetDataBinding(dsHotList,dataTable.TableName);
			DataView dataView		= new DataView(dataTable);
			dataView.AllowEdit		= false;
			dataView.AllowDelete	= false;

			dgridPOTotals.Refresh();
		}

		private DataSet generateHotListPaintOrderDataSet(){
			DataTable hotListDataTable = new DataTable();
			DataRow dataRow;

			hotListDataTable.Columns.Add(new DataColumn("HOT_ProdID", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Seq", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("MatId", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("MatSeq", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("QOHRaw", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("QOHPlan", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_PastDue", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day001", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day002", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day003", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day004", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day005", typeof(string)));

			string[][] vec = UtilCoreFactory.createCoreFactory().getPaintOrdersHotListAsString(pOrow);
			if (vec.Length>0) {
				for(int x = 0; x < vec.Length; x++){
					switch(int.Parse(vec[x][1])){
					case 10:
						vec[x][2] = "C34-70W";
						break;
					case 20:
						vec[x][2] = "CPS-A29NF";
						break;
					case 30:
						vec[x][2] = "H05-80";
						break;
					case 40:
						vec[x][2] = "H74-70";
						break;
					case 50:
						vec[x][2] = "D35-30";
						break;
					}
					
					vec[x][1] = "10";
					vec[x][3] = "0";
					vec[x][4] = "0";

					dataRow = hotListDataTable.NewRow();
					dataRow.ItemArray = vec[x];

					dataRow[10] = dataRow[9];
					dataRow[11] = dataRow[9];

					dataRow.ItemArray = vec[x];
					hotListDataTable.Rows.Add(dataRow);
				}
			} else {
				MessageBox.Show("Empty data set");
			}

			DataSet hotListDataSet = new DataSet();
			hotListDataSet.Tables.Add(hotListDataTable);
			//hotListDataSet = loadHotListGrid.setColumnName(hotListDataSet);

			return hotListDataSet;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
