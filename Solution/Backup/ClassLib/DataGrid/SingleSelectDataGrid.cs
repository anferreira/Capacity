using System;
using System.Data; 
using System.Drawing; 
using System.Windows.Forms;  
using Nujit.NujitERP.ClassLib;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.CustomDataGrid 
{
	public class SingleSelectDataGrid : System.Windows.Forms.DataGrid
	{		
		private int oldSelectedRow = -1;
 
		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e) 
		{ 
			//don't call the base class if left mouse down 
			if(e.Button != MouseButtons.Left) 
				base.OnMouseMove(e); 
		} 
 
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) 
		{ 
			//don't call the base class if in header 
			System.Windows.Forms.DataGrid.HitTestInfo hti = this.HitTest(new Point(e.X, e.Y)); 
			if(hti.Type == DataGrid.HitTestType.Cell) 
			{ 
				if(oldSelectedRow > -1) 
				{
					try
					{
						this.UnSelect(oldSelectedRow); 
					}
					catch
					{
						oldSelectedRow = -1;
					}
				}
				oldSelectedRow = -1; 

				base.OnMouseDown(e); 
			} 
			else if(hti.Type == DataGrid.HitTestType.RowHeader) 
			{ 
				if(oldSelectedRow > -1) 
				{
					try
					{
						this.UnSelect(oldSelectedRow); 
					}
					catch
					{
						oldSelectedRow = -1;
					}
				}
				if((Control.ModifierKeys & Keys.Shift) == 0) 
					base.OnMouseDown(e); 
				else 
					this.CurrentCell = new DataGridCell(hti.Row, hti.Column); 

				this.Select(hti.Row); 

				oldSelectedRow = hti.Row; 
			}
		} 

		public override bool PreProcessMessage(ref Message msg )  
		{ 
			Keys keyCode = (Keys)(int)msg.WParam & Keys.KeyCode; 
 
			//if(msg.Msg == WM_KEYDOWN && keyCode == Keys.Delete && ((DataView) this.DataSource).AllowDelete) 
			if(msg.Msg == Constants.WM_KEYDOWN && keyCode == Keys.Delete) 
			{ 
				//if(MessageBox.Show("Delete this row?", "", MessageBoxButtons.YesNo) == DialogResult.No) 
				return true; 
			} 
			return base.PreProcessMessage(ref msg); 
		}  

	}
}
