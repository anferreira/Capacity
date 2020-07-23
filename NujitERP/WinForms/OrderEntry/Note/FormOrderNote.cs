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
	public class FormOrderNote : FormNote
	{				
		Order order= null;
		public FormOrderNote(Order order) : base()
		{
			this.order = order;				

			setNote();

			objectToScreen();
		}

		protected override Note createNote()
		{
			return order.createNote("");
		}

		protected override void objectToScreen()
		{
			int		i=0;
			string	snote="";
			
			for (i=0; i < order.getCountNotes();i++)
			{
				note = order.getNoteByIndex(i);
				snote+= note.getNote();
			}
			this.textBoxNote.Text = snote;
		}

		protected override void screenToObject()
		{					
			note.setNote(this.textBoxNote.Text);

			if (order.getNoteByID(note.getLineNum())== null)//it there is not notes											
				order.addNewNote(note);//add new note
										
			if (note.getNote().Length < 1)//if there is no note
				order.removeNoteByID(note.getLineNum());//remove it			
			
		}		

		public Order getOrder()
		{
			return order;
		}
	}
}
