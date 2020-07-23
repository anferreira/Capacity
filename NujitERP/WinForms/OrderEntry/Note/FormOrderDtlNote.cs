using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormNote.
	/// </summary>
	public class FormOrderDtlNote : FormNote
	{				
		OrderDtl orderDtl=null;
		public FormOrderDtlNote(OrderDtl orderDtl) : base()
		{
			this.orderDtl = orderDtl;

			setNote();

			objectToScreen();
		}

		protected override Note createNote()
		{
			return orderDtl.createNote("");
		}

		protected override void objectToScreen()
		{
			int		i=0;
			string	snote="";
			
			for (i=0; i < orderDtl.getCountNotes();i++)
			{
				note = orderDtl.getNoteByIndex(i);
				snote+= note.getNote();
			}
			this.textBoxNote.Text = snote;
		}

		protected override void screenToObject()
		{					
			note.setNote(this.textBoxNote.Text);

			if (orderDtl.getNoteByID(note.getLineNum())== null)//it there is not notes											
				orderDtl.addNewNote(note);//add new note
										
			if (note.getNote().Length < 1)//if there is no note
				orderDtl.removeNoteByID(note.getLineNum());//remove it			
			
		}		

		public OrderDtl getOrderDtl()
		{
			return this.orderDtl;
		}
	}
}
