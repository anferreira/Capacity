using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using GridScheduling.gui;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;

//using Nujit.NujitERP.WinForms.CustomControls;

namespace GridScheduling.gui.schedule{
	/// <summary>
	/// Summary description for AddForm.
	/// </summary>
	public
	class PaintForPartForm : System.Windows.Forms.Form{
		
		private CoreFactory core = UtilCoreFactory.createCoreFactory();
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button cancelButton;
		private DataTable dataTable;
		private System.Windows.Forms.DataGrid grid;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private int[] paintThis;

		public
		PaintForPartForm(){
			InitializeComponent();
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
		private void InitializeComponent(){
			this.cancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.grid = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(736, 288);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 53;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OkButton.Location = new System.Drawing.Point(656, 288);
			this.OkButton.Name = "OkButton";
			this.OkButton.TabIndex = 52;
			this.OkButton.Text = "Ok";
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// grid
			// 
			this.grid.CaptionVisible = false;
			this.grid.DataMember = "";
			this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grid.Location = new System.Drawing.Point(16, 16);
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(832, 256);
			this.grid.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(536, 32);
			this.label1.TabIndex = 40;
			this.label1.Text = "View 1 Colour Scheduling";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label1});
			this.panel1.Location = new System.Drawing.Point(16, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(864, 56);
			this.panel1.TabIndex = 41;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.grid,
																				 this.OkButton,
																				 this.cancelButton});
			this.panel2.Location = new System.Drawing.Point(16, 80);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(864, 320);
			this.panel2.TabIndex = 42;
			// 
			// PaintForPartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(906, 416);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel2,
																		  this.panel1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "PaintForPartForm";
			this.Text = "Tiercon";
			this.Load += new System.EventHandler(this.PaintForPartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private
		void PaintForPartForm_Load(object sender, System.EventArgs e){
			DataSet dsHotList = this.generateGrid();
			if (dsHotList != null && dsHotList.Tables.Count >0 ){
				this.grid.DataSource = dsHotList.Tables[0];
				grid.Refresh();
			} else {
				this.grid.DataSource = null;
				MessageBox.Show("HotList is empty or something went wrong");
			}
			
			grid.PreferredColumnWidth	= 100;
			DataGridTableStyle dgdtblStyle		= new DataGridTableStyle();
			dgdtblStyle.MappingName				= dataTable.TableName;
			grid.TableStyles.Clear(); 
			dgdtblStyle.AllowSorting			= false;
			dgdtblStyle.PreferredRowHeight		= 22;

			this.Cursor = Cursors.Default;
			dgdtblStyle.AllowSorting         = false;
			dgdtblStyle.RowHeadersVisible    = true;

			DataGridColumnStyle gridDelColumn;
			DataGridColumnStyle gridSeqStyle;

			PropertyDescriptorCollection pcol = this.BindingContext[dsHotList, dataTable.TableName].GetItemProperties();

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Unpainted";
			gridSeqStyle.HeaderText = "Unpainted";
			gridSeqStyle.Width = 140;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "U.Seq";
			gridSeqStyle.HeaderText = "U.Seq";
			gridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Painted Part";
			gridSeqStyle.HeaderText = "Painted Part";
			gridSeqStyle.Width = 70;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "P.Seq";
			gridSeqStyle.HeaderText = "P.Seq";
			gridSeqStyle.Width = 50;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridDelColumn = new ColumnStyle(pcol[dataTable.TableName]);
			((ColumnStyle)gridDelColumn).setPaintThis(paintThis);
			gridDelColumn.MappingName = "Colour";
			gridDelColumn.HeaderText = "Colour";
			gridDelColumn.Width = 107;
			dgdtblStyle.GridColumnStyles.Add(gridDelColumn);
			
			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "QOH";
			gridSeqStyle.HeaderText = "QOH";
			gridSeqStyle.Width = 62;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Past Due";
			gridSeqStyle.HeaderText = "Past Due";
			gridSeqStyle.Width = 62;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Day 1";
			gridSeqStyle.HeaderText = "Day 1";
			gridSeqStyle.Width = 62;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Day 2";
			gridSeqStyle.HeaderText = "Day 2";
			gridSeqStyle.Width = 62;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Day 3";
			gridSeqStyle.HeaderText = "Day 3";
			gridSeqStyle.Width = 62;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Day 4";
			gridSeqStyle.HeaderText = "Day 4";
			gridSeqStyle.Width = 62;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			gridSeqStyle = new DataGridTextBoxColumn();
			gridSeqStyle.MappingName = "Day 5";
			gridSeqStyle.HeaderText = "Day 5";
			gridSeqStyle.Width = 62;
			dgdtblStyle.GridColumnStyles.Add(gridSeqStyle);

			dgdtblStyle.ReadOnly = true;
			grid.TableStyles.Add(dgdtblStyle);
			grid.SetDataBinding(dsHotList,dataTable.TableName);

			DataView dataView = new DataView(dsHotList.Tables[0]);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;
			grid.AllowSorting = false;
			
			grid.Refresh();
		}

		private
		DataSet generateGrid(){
            dataTable = new DataTable();
            DataRow dataRow;
 
			dataTable.Columns.Add(new DataColumn("Unpainted", typeof(string)));
			dataTable.Columns.Add(new DataColumn("U.Seq", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Painted Part", typeof(string)));
			dataTable.Columns.Add(new DataColumn("P.Seq", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Colour", typeof(string)));
			dataTable.Columns.Add(new DataColumn("QOH", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Past Due", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Day 1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Day 2", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Day 3", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Day 4", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Day 5", typeof(string)));

			string[][] vec1 = core.getPaintOrdersHotListAsString(0);
			string[][] vec2 = core.getPaintOrdersHotListAsString(1);
			
			string[][] vec = new string[vec1.Length + vec2.Length][];
			vec[0] = vec1[0];
			vec[1] = vec1[1];
			vec[2] = vec1[2];
			vec[3] = vec1[3];
			vec[4] = vec1[4];

			vec[5] = vec2[0];
			vec[6] = vec2[1];
			vec[7] = vec2[2];
			vec[8] = vec2[3];
			vec[9] = vec2[4];
			
			vec[10] = vec1[5];
			vec[11] = vec1[6];
			vec[12] = vec1[7];
			vec[13] = vec1[8];
			vec[14] = vec1[9];
			
			vec[15] = vec2[5];
			vec[16] = vec2[6];
			vec[17] = vec2[7];
			vec[18] = vec2[8];
			vec[19] = vec2[9];
			
			vec[20] = vec1[10];
			vec[21] = vec1[11];
			vec[22] = vec1[12];
			vec[23] = vec1[13];
			vec[24] = vec1[14];
			
			vec[25] = vec2[10];
			vec[26] = vec2[11];
			vec[27] = vec2[12];
			vec[28] = vec2[13];
			vec[29] = vec2[14];
			
			vec[30] = vec1[15];
			vec[31] = vec1[16];
			vec[32] = vec1[17];
			vec[33] = vec1[18];
			vec[34] = vec1[19];
			
			vec[35] = vec2[15];
			vec[36] = vec2[16];
			vec[37] = vec2[17];
			vec[38] = vec2[18];
			vec[39] = vec2[19];
			
			paintThis = new int[500];
			for(int i = 0; i < paintThis.Length; i++)
				paintThis[i] = 0;
			
			int colorPos = 1;

			decimal[] totals = new decimal[6];
			string lastProd = vec[0][0];

			int prodCount = 0;

			for(int x = 0; x < vec.Length; x++){
				if (!lastProd.Equals(vec[x][0])){
//				if (prodCount == 20){
					addTotalsToGrid(totals[0], totals[1], totals[2], 
						totals[3], totals[4], totals[5], 0
						/*decimal.Parse(vec[x][4])*/);

					totals[0] = 0;
 					totals[1] = 0;
 					totals[2] = 0;
 					totals[3] = 0;
 					totals[4] = 0;
 					totals[5] = 0;

					lastProd = vec[x][0];

						colorPos = 1;
					
					prodCount = 0;
				}

				prodCount++;

				//vec[x][2] = "100";

				dataRow = dataTable.NewRow();
 				dataRow[0] = vec[x][0]; // prod
				dataRow[1] = "0"; //vec[x][1]; // seq
				
				switch(int.Parse(vec[x][1])){
				case 10:
					dataRow[2] = "C34-70W";
					break;
				case 20:
					dataRow[2] = "CPS-A29NF";
					break;
				case 30:
					dataRow[2] = "H05-80";
					break;
				case 40:
					dataRow[2] = "H74-70";
					break;
				case 50:
					dataRow[2] = "D35-30";
					break;
				}
				

//				dataRow[2] = vec[x][2]; // # part bom
 				dataRow[3] = "10"; //vec[x][3]; // seq bom
 				dataRow[4] = ""; // colour

 				dataRow[6] = vec[x][4]; // past due

				dataRow[5] = "0"; //vec[x][4]; // qoh
 				dataRow[7] = vec[x][5]; // day1
 				dataRow[8] = vec[x][6]; // day 2
 				dataRow[9] = vec[x][7]; // day 3
 				dataRow[10] = vec[x][8]; // day 4
 				dataRow[11] = vec[x][9]; // day 5

				totals[0] += decimal.Parse(vec[x][4]);
 				totals[1] += decimal.Parse(vec[x][5]);
 				totals[2] += decimal.Parse(vec[x][6]);
 				totals[3] += decimal.Parse(vec[x][7]);
 				totals[4] += decimal.Parse(vec[x][8]);
 				totals[5] += decimal.Parse(vec[x][9]);

				dataTable.Rows.Add(dataRow);
				
				paintThis[dataTable.Rows.Count - 1] = colorPos;
				colorPos++;
			}
			
			addTotalsToGrid(totals[0], totals[1], totals[2], 
				totals[3], totals[4], totals[5], 0
				/*decimal.Parse(vec[vec.Length - 1][4])*/);
		
			DataSet hotListDataSet = new DataSet();
			hotListDataSet.Tables.Add(dataTable);
			return hotListDataSet;
		}

		private
		void addTotalsToGrid(decimal c0, decimal c1, decimal c2, decimal c3, 
				decimal c4, decimal c5, decimal qoh){

			DataRow dataRow;
			
			dataRow = dataTable.NewRow();
			dataRow[0] = "Total Quantity Required";
			dataRow[1] = "";
 			dataRow[2] = "";
 			dataRow[3] = "";
 			dataRow[4] = "";
 			dataRow[5] = "";
 			dataRow[6] = c0.ToString();
 			dataRow[7] = c1.ToString();
 			dataRow[8] = c2.ToString();
 			dataRow[9] = c3.ToString();
 			dataRow[10] = c4.ToString();
 			dataRow[11] = c5.ToString();
			dataTable.Rows.Add(dataRow);

			dataRow = dataTable.NewRow();
			dataRow[0] = "Ending Inventory Position";
			dataRow[1] = "";
 			dataRow[2] = "";
 			dataRow[3] = "";
 			dataRow[4] = "";
 			dataRow[5] = "";
 			dataRow[6] = (c0 + qoh).ToString();
 			dataRow[7] = (c0 + c1 + qoh).ToString();
 			dataRow[8] = (c0 + c1 + c2 + qoh).ToString();
 			dataRow[9] = (c0 + c1 + c2 + c3 + qoh).ToString();
 			dataRow[10] = (c0 + c1 + c2 + c3 + c4 + qoh).ToString();
 			dataRow[11] = (c0 + c1 + c2 + c3 + c4 + c5 + qoh).ToString();
			dataTable.Rows.Add(dataRow);
		
			dataRow = dataTable.NewRow();
			dataRow[0] = "";
			dataRow[1] = "";
 			dataRow[2] = "";
 			dataRow[3] = "";
 			dataRow[4] = "";
 			dataRow[5] = "";
 			dataRow[6] = "";
 			dataRow[7] = "";
 			dataRow[8] = "";
 			dataRow[9] = "";
 			dataRow[10] = "";
 			dataRow[11] = "";
			dataTable.Rows.Add(dataRow);
		}

		private
		void okButton_Click(object sender, System.EventArgs e){
			this.Dispose();
		}

		private
		void reviewButton_Click(object sender, System.EventArgs e){
			// add code for reload objects here
			MessageBox.Show("reviewButton pressed");
		}

		private
		string getCurrentValue(int column){
			int row = grid.CurrentCell.RowNumber;
			int index = 0;
			
			IEnumerator en = dataTable.Rows.GetEnumerator();
			while(en.MoveNext()){
				DataRow dataRow = (DataRow)en.Current;

				if (index == row)
					return dataRow[column].ToString();
				index++;
			}
			return "";
		}
		
		// sets a value in the shift data grid
		private
		void setCurrentValue(string myValue, int column){
			int row = grid.CurrentCell.RowNumber;
			int index = 0;

			IEnumerator en = dataTable.Rows.GetEnumerator();
			while(en.MoveNext()){
				DataRow dataRow = (DataRow)en.Current;

				if (index == row){
					string dataType = dataRow[column].GetType().ToString();
					switch(dataType){
					case "System.String":
						dataRow[column] = myValue;
						break;
					case "System.Int32":
						int intValue = int.Parse(myValue);
						dataRow[column] = intValue;
						break;
					case "System.Decimal":
						dataRow[column] = decimal.Parse(myValue);
						break;
					case "System.DateTime":
						dataRow[column] = DateUtil.parseDate(myValue, DateUtil.DDMMYYYY);
						break;
					}
				}
				index++;
			}
		}
		
		private 
		void OkButton_Click(object sender, System.EventArgs e){
			this.Dispose();
		}

		private 
		void cancelButton_Click(object sender, System.EventArgs e){
			this.Hide();
			this.Dispose();
		}

		private 
		void grid_Click(object sender, System.EventArgs e){
			grid.PreferredRowHeight = 10;
			DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
			dgdtblStyle = grid.TableStyles[0];
			dgdtblStyle.PreferredRowHeight = 10;
		}

//--------------------------------------------------------------------------------
	public class ColumnStyle:DataGridTextBoxColumn{
		private int[] paintThis;

		public void setPaintThis(int[] paintThis){
			this.paintThis = paintThis;
		}
		public ColumnStyle(PropertyDescriptor pcol){
		}
		protected override void Abort(int RowNum){
		}
		protected override bool Commit(CurrencyManager DataSource,int RowNum){
			return true;
		}
		protected override void Edit(CurrencyManager Source ,int Rownum,Rectangle Bounds, bool ReadOnly,string InstantText, bool CellIsVisible){
		}
		protected override int GetMinimumHeight(){
			return 16;
		}
		protected override int GetPreferredHeight(Graphics g ,object Value){
			return 16;
		}
		protected override Size GetPreferredSize(Graphics g, object Value){
			Size cellSize = new Size(75 ,16);
			return cellSize;
		}
		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum){
			Brush BackBrush = new SolidBrush(Color.White);
			string bdel = GetColumnValueAtRow(Source, RowNum).ToString();

			switch(RowNum) {
				case 0:
                    BackBrush = Brushes.Coral;
					break;
				case 1:
					BackBrush = Brushes.Aqua;
                    break;
				default:
					BackBrush = Brushes.White;
                    break;
			}

			g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
			System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
			g.DrawString( bdel ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );
		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum,bool AlignToRight){
			Brush BackBrush = new SolidBrush(Color.White);
			string bdel = GetColumnValueAtRow(Source, RowNum).ToString();

			switch(RowNum) {
			case 0:
                BackBrush = Brushes.Coral;
				break;
			case 1:
				BackBrush = Brushes.Aqua;
                break;
			default:
				BackBrush = Brushes.White;
                break;
			}

			g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
			System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
			g.DrawString( bdel ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );
		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum, Brush BackBrush ,Brush ForeBrush ,bool AlignToRight){
			string bdel = GetColumnValueAtRow(Source, RowNum).ToString();

			if (RowNum < 0)
				RowNum = 0;
			
			System.Drawing.Brush[] brushes = new System.Drawing.Brush[15];
			brushes[0] = Brushes.White;
			brushes[1] = Brushes.Red;
			brushes[2] = Brushes.Blue;
			brushes[3] = Brushes.Green;
			brushes[4] = Brushes.Yellow;
			brushes[5] = Brushes.BlueViolet;
			brushes[6] = Brushes.Brown;
			brushes[7] = Brushes.Chocolate;
			brushes[8] = Brushes.Beige;
			brushes[9] = Brushes.Crimson;
			brushes[10] = Brushes.BlueViolet;
			brushes[11] = Brushes.Brown;
			brushes[12] = Brushes.Chocolate;
			brushes[13] = Brushes.Beige;
			brushes[14] = Brushes.Crimson;

			int colorPos = 0;
			if (RowNum < paintThis.Length)
				colorPos = paintThis[RowNum];
			if (colorPos < brushes.Length)
				BackBrush = brushes[colorPos];
			else	
				BackBrush = Brushes.White;
			
			g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

			System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
			g.DrawString( bdel ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );
		}
	}
//--------------------------------------------------------------------------------

	} // class
} // namespace
