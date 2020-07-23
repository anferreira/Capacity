using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.CustomControls
{
	/// <summary>
	/// Summary description for ColumnStyle.
	/// </summary>
	public class ColumnStyle:DataGridTextBoxColumn
	{
		private int colType;

		public ColumnStyle(PropertyDescriptor pcol)
		{
			colType = 0;
		}

		public ColumnStyle(PropertyDescriptor pcol, int colType)
		{
			this.colType = colType;
		}

		protected override void Abort(int RowNum) 
		{
		}

		protected override bool Commit(CurrencyManager DataSource,int RowNum) 
		{
			return true;
		}
		protected override void Edit(CurrencyManager Source ,int Rownum,Rectangle Bounds, bool ReadOnly,string InstantText, bool CellIsVisible) 
		{
		}

		protected override int GetMinimumHeight() 
		{
			//
			// return here your minimum height
			//
			return 14;
		}

		protected override int GetPreferredHeight(Graphics g ,object Value) 
		{
			//
			// return here your preferred height
			//
			return 14;
		}

		protected override Size GetPreferredSize(Graphics g, object Value) 
		{
			//
			// return here your preferred size
			//
			Size cellSize = new Size(75 ,14);
			return cellSize;
		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum) 
		{
			Brush BackBrush = new SolidBrush(Color.White);

			//bool bdel = (bool) GetColumnValueAtRow(Source, RowNum);
			string bdel = GetColumnValueAtRow(Source, RowNum).ToString();
            
			if (colType==0) {
				switch(RowNum) {
					case 0:
						BackBrush = Brushes.Red;
						break;
					case 1:
						BackBrush = Brushes.Blue;
						break;
					case 2:
						BackBrush = Brushes.Green;
						break;
					case 3:
						BackBrush = Brushes.Yellow;
						break;
					case 4:
						BackBrush = Brushes.BlueViolet;
						break;
					default:
						BackBrush = Brushes.White;
						break;
				}
			} else if (colType==1) {
				if (RowNum==0)
                    BackBrush = Brushes.Red;
				else
					BackBrush = Brushes.White;
			} else if (colType==2) {
				if (RowNum==0)
                    BackBrush = Brushes.Blue;
				else
					BackBrush = Brushes.White;
			} else if (colType==3) {
				if (RowNum==0)
                    BackBrush = Brushes.Green;
				else
					BackBrush = Brushes.White;
			} else if (colType==4) {
				if (RowNum==0)
                    BackBrush = Brushes.Yellow;
				else
					BackBrush = Brushes.White;
			} else if (colType==5) {
				if (RowNum==0)
                    BackBrush = Brushes.BlueViolet;
				else
					BackBrush = Brushes.White;
			}

			g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

			System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
			g.DrawString( bdel ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );

		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum,bool AlignToRight) 
		{
			Brush BackBrush = new SolidBrush(Color.White);
			//bool bdel = (bool) GetColumnValueAtRow(Source, RowNum);
			string bdel = GetColumnValueAtRow(Source, RowNum).ToString();

			if (colType==0) {
				switch(RowNum) {
					case 0:
						BackBrush = Brushes.Red;
						break;
					case 1:
						BackBrush = Brushes.Blue;
						break;
					case 2:
						BackBrush = Brushes.Green;
						break;
					case 3:
						BackBrush = Brushes.Yellow;
						break;
					default:
						BackBrush = Brushes.White;
						break;
				}
			} else if (colType==1) {
				if (RowNum==0)
                    BackBrush = Brushes.Red;
				else
					BackBrush = Brushes.White;
			} else if (colType==2) {
				if (RowNum==0)
                    BackBrush = Brushes.Blue;
				else
					BackBrush = Brushes.White;
			} else if (colType==3) {
				if (RowNum==0)
                    BackBrush = Brushes.Green;
				else
					BackBrush = Brushes.White;
			} else if (colType==4) {
				if (RowNum==0)
                    BackBrush = Brushes.Yellow;
				else
					BackBrush = Brushes.White;
			} else if (colType==5) {
				if (RowNum==0)
                    BackBrush = Brushes.BlueViolet;
				else
					BackBrush = Brushes.White;
			}

			g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

			System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
			g.DrawString( bdel ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );

		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum, Brush BackBrush ,Brush ForeBrush ,bool AlignToRight) 
		{
					
			//bool bdel = (bool) GetColumnValueAtRow(Source, RowNum);
			string bdel = GetColumnValueAtRow(Source, RowNum).ToString();

			if (colType==0) {
				switch(RowNum) {
					case 0:
						BackBrush = Brushes.Red;
						break;
					case 1:
						BackBrush = Brushes.Blue;
						break;
					case 2:
						BackBrush = Brushes.Green;
						break;
					case 3:
						BackBrush = Brushes.Yellow;
						break;
					case 4:
						BackBrush = Brushes.BlueViolet;
						break;
					default:
						BackBrush = Brushes.White;
						break;
				}
			} else if (colType==1) {
				if (RowNum==0)
                    BackBrush = Brushes.Red;
				else
					BackBrush = Brushes.White;
			} else if (colType==2) {
				if (RowNum==0)
                    BackBrush = Brushes.Blue;
				else
					BackBrush = Brushes.White;
			} else if (colType==3) {
				if (RowNum==0)
                    BackBrush = Brushes.Green;
				else
					BackBrush = Brushes.White;
			} else if (colType==4) {
				if (RowNum==0)
                    BackBrush = Brushes.Yellow;
				else
					BackBrush = Brushes.White;
			} else if (colType==5) {
				if (RowNum==0)
                    BackBrush = Brushes.BlueViolet;
				else
					BackBrush = Brushes.White;
			}

			g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

			System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
			g.DrawString( bdel ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );


		}

	}
}
