using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{


public 
class NoteList {


	ArrayList arrayNotes= null;

public 
NoteList(){
	
	arrayNotes= new ArrayList();
}

public 
void addNote(Note note)
{
	this.arrayNotes.Add(note);	
}

public 
Note getNoteByIndex(int index)
{
	Note note=null;

	if (index < arrayNotes.Count)
		note= (Note)arrayNotes[index];

	return note;	
}

public void addNewNote (Note note)
{
	if (this.arrayNotes.Count == 0)
		note.setLineNum(1);
	else
		note.setLineNum(((Note)arrayNotes[arrayNotes.Count-1]).getLineNum()+1);
	arrayNotes.Add (note);
}

public Note getNoteByID (int ilineNum)
{
	IEnumerator enu = arrayNotes.GetEnumerator();
	while (enu.MoveNext())
	{
		if (ilineNum.Equals(((Note)enu.Current).getLineNum()))
			return (Note)enu.Current;
	}
	return null;
}

public bool removeNoteByID (int itemNum)
{
	int i=0;
	bool found = false;
	while ((i<this.arrayNotes.Count) && (!found))
	{
		if (itemNum.Equals(((Note)arrayNotes[i]).getLineNum()))
		{
			found = true;
			arrayNotes.RemoveAt(i);
		}
		i++;
	}
	return found;
}

public
IEnumerator getNoteEnumerator()
{
	return arrayNotes.GetEnumerator();
}
	
public 
int getCountNotes()
{
	return arrayNotes.Count;
}	

#if OE_SYNC
public 
XmlDocument toXml(XmlDocument xmlDoc)
{	
	try
	{										
			int				i=0;
			
			//notes
			for (i=0; i < this.arrayNotes.Count;i++)
			{				
				Note note = this.getNoteByIndex(i);
				xmlDoc = note.toXml(xmlDoc);
			}			
							
	}
	catch (XmlException ex)
	{		
		throw new NujitException("Error in class OrderDtl  <toXml> : " + ex.Message);		
	}
	
	return xmlDoc;
}
#endif

public 
void removeAllNotes()
{
	if (this.arrayNotes.Count > 0)
	{
		arrayNotes.Clear();		
	}		
}		

} // class

} // namespace
