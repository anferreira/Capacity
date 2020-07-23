using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class NoteCoreFactory : MachineCoreFactory{

public
NoteCoreFactory() : base(){
}

public Note[] readNotes(string stype, int ikey1,int ikey2,int ikey3)
{
	try
	{
		NoteDataBaseContainer noteDataBaseContainer= new NoteDataBaseContainer(dataBaseAccess);	
		noteDataBaseContainer.readAllNotesFromType(stype,ikey1,ikey2,ikey3);
			
		Note[] items = new Note[noteDataBaseContainer.Count];
		int i = 0;
		IEnumerator enu = noteDataBaseContainer.GetEnumerator();
		while (enu.MoveNext())
		{
			items[i] = objectDataBaseToObject((NoteDataBase)enu.Current);
			i++;
		}
		return items;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public
Note readNote(string stype, int ikey1,int ikey2,int ikey3,int ilineNum)
{
	try
	{
		NoteDataBase noteDataBase = new NoteDataBase(dataBaseAccess);

		noteDataBase.setN_Type(stype);		
		noteDataBase.setN_Key1(ikey1);	
		noteDataBase.setN_Key2(ikey2);	
		noteDataBase.setN_Key3(ikey3);	
		noteDataBase.setN_LineNum(ilineNum);
		
		if (!noteDataBase.exists())
			return null;

		noteDataBase.read();
	
		return objectDataBaseToObject(noteDataBase);

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Return if exists a Note
/// </summary>
/// <param name="Note"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsNote(string stype, int ikey1,int ikey2,int ikey3,int ilineNum){
	try
	{
		NoteDataBase noteDataBase = new NoteDataBase(dataBaseAccess);

		noteDataBase.setN_Type(stype);		
		noteDataBase.setN_Key1(ikey1);	
		noteDataBase.setN_Key2(ikey2);	
		noteDataBase.setN_Key3(ikey3);	
		noteDataBase.setN_LineNum(ilineNum);
			
		return noteDataBase.exists();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Write to the database a Note object
/// </summary>
/// <param name="proccess"></param>
public
void writeNote(Note note){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		NoteDataBase noteDataBase = this.objectToObjectDatabase(note);
						
		noteDataBase.write();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a Note object
/// </summary>
/// <param name="proccess"></param>
public
void updateNote(Note note){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		NoteDataBase noteDataBase = this.objectToObjectDatabase(note);
						
		noteDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Delete a Note object
/// </summary>
/// <param name="proccess"></param>
public
void deleteNote(Note note){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		NoteDataBase noteDataBase = this.objectToObjectDatabase(note);
								
		noteDataBase.delete();
			
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

public
void deleteNoteAllFromTypeKey(Note note){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		NoteDataBase noteDataBase = this.objectToObjectDatabase(note);
								
		noteDataBase.deleteAllFromTypeKey();
			
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

protected 
Note objectDataBaseToObject(NoteDataBase noteDataBase)
{
	Note note = new Note();

	note.setId(noteDataBase.getN_ID());
	note.setType(noteDataBase.getN_Type());
	note.setKey1(noteDataBase.getN_Key1());
	note.setKey2(noteDataBase.getN_Key2());
	note.setKey3(noteDataBase.getN_Key3());
	note.setLineNum(noteDataBase.getN_LineNum());
	note.setNote(noteDataBase.getN_Note());

	return note;
}


protected 
NoteDataBase objectToObjectDatabase(Note note)
{
	NoteDataBase noteDataBase = new NoteDataBase(dataBaseAccess);		
	
	noteDataBase.setN_ID(note.getId());
	noteDataBase.setN_Type(note.getType());
	noteDataBase.setN_Key1(note.getKey1());
	noteDataBase.setN_Key2(note.getKey2());
	noteDataBase.setN_Key3(note.getKey3());
	noteDataBase.setN_LineNum(note.getLineNum());
	noteDataBase.setN_Note(note.getNote());

	return noteDataBase;		
}


} // class

} // namespace