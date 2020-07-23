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
	/// Summary description for GridPaintOrders.
	/// </summary>
	public class GridPaintOrders : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dgridPOTotals;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GridPaintOrders()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GridPaintOrders));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgridPOTotals = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
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
			this.groupBox1.Size = new System.Drawing.Size(632, 248);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Paint Orders Totals";
			// 
			// dgridPOTotals
			// 
			this.dgridPOTotals.CaptionVisible = false;
			this.dgridPOTotals.DataMember = "";
			this.dgridPOTotals.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridPOTotals.Location = new System.Drawing.Point(16, 24);
			this.dgridPOTotals.Name = "dgridPOTotals";
			this.dgridPOTotals.ReadOnly = true;
			this.dgridPOTotals.Size = new System.Drawing.Size(600, 208);
			this.dgridPOTotals.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(216, 272);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "View Details";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(336, 272);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "Close";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// GridPaintOrders
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 310);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.button1,
																		  this.groupBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "GridPaintOrders";
			this.Text = "Paint Order Scheduling";
			this.Load += new System.EventHandler(this.GridPaintOrders_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgridPOTotals)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void GridPaintOrders_Load(object sender, System.EventArgs e)
		{
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

			DataGridColumnStyle GridDelColumn;
			DataGridColumnStyle GridSeqStyle;

			PropertyDescriptorCollection pcol = this.BindingContext[dsHotList, dataTable.TableName].GetItemProperties();

			GridDelColumn = new Nujit.NujitERP.WinForms.CustomControls.ColumnStyle(pcol[dataTable.TableName]);
			GridDelColumn.MappingName = "Colour";
			GridDelColumn.HeaderText = "Colour";
			GridDelColumn.Width = 119;
			dgdtblStyle.GridColumnStyles.Add(GridDelColumn);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_PastDue";
			GridSeqStyle.HeaderText = "PastDue";
			GridSeqStyle.Width = 80;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day001";
			GridSeqStyle.HeaderText = "Day 1";
			GridSeqStyle.Width = 72;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day002";
			GridSeqStyle.HeaderText = "Day 2";
			GridSeqStyle.Width = 72;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day003";
			GridSeqStyle.HeaderText = "Day 3";
			GridSeqStyle.Width = 72;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day004";
			GridSeqStyle.HeaderText = "Day 4";
			GridSeqStyle.Width = 72;
			dgdtblStyle.GridColumnStyles.Add(GridSeqStyle);

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "HOT_Day005";
			GridSeqStyle.HeaderText = "Day 5";
			GridSeqStyle.Width = 72;
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

			hotListDataTable.Columns.Add(new DataColumn("Colour", typeof(string)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_PastDue", typeof(decimal)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day001", typeof(decimal)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day002", typeof(decimal)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day003", typeof(decimal)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day004", typeof(decimal)));
			hotListDataTable.Columns.Add(new DataColumn("HOT_Day005", typeof(decimal)));

			string[][] vec = UtilCoreFactory.createCoreFactory().getPaintOrdersHotListSumAsString();
			for(int x = 0; x < vec.Length; x++){
				dataRow = hotListDataTable.NewRow();
				dataRow.ItemArray = vec[x];
				hotListDataTable.Rows.Add(dataRow);
			}

			dataRow = hotListDataTable.NewRow();
			dataRow.ItemArray = vec[1];
			hotListDataTable.Rows.Add(dataRow);

			DataSet hotListDataSet = new DataSet();
			hotListDataSet.Tables.Add(hotListDataTable);
			//hotListDataSet = loadHotListGrid.setColumnName(hotListDataSet);

			return hotListDataSet;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			int rowSel = dgridPOTotals.CurrentRowIndex;
			GridPaintOrdersDtl gridDtl = new GridPaintOrdersDtl(rowSel);
			gridDtl.ShowDialog(this);
            

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
