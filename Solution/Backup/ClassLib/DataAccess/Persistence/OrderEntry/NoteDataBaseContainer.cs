using System;
using Nujit.NujitERP.ClassLib.Core;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
#if !POCKET_PC
using MySql.Data;
using System.Data.OleDb;
#endif
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class NoteDataBaseContainer : GenericDataBaseContainer{

public
NoteDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from note";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			NoteDataBase noteDataBase = new NoteDataBase(dataBaseAccess);
			noteDataBase.load(reader);		
			this.Add(noteDataBase);
		}
	}
	catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class "+ this.GetType().Name  +"<read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class "+ this.GetType().Name  +"<read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class"  + this.GetType().Name+ "<read>: " + de.Message,de);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readAllNotesFromType(string stype,int ikey1,int ikey2,int ikey3){
	try{
		string		sql="select * from note " +
						" where "	+
						"N_Type='"	+ Converter.fixString(stype) + "' and " +
						"N_Key1="	+ NumberUtil.toString(ikey1) + " and ";

						sql+= "N_Key2";
						if (NumberUtil.isNull(ikey2))	sql+= " is ";	
						else							sql+= "=";					
						sql+=  NumberUtil.toString(ikey2)	+ " and ";

						sql+= "N_Key3";
						if (NumberUtil.isNull(ikey3))	sql+= " is ";
						else							sql+= "=";				
						sql+=  NumberUtil.toString(ikey3);
								
			 
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			NoteDataBase noteDataBase = new NoteDataBase(dataBaseAccess);
			noteDataBase.load(reader);
			this.Add(noteDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class NoteDataBaseContainer <readProductPrice>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class NoteDataBaseContainer <readProductPrice>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readProductPrice> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class NoteDataBaseContainer <readProductPrice>: " + de.Message,de);
	}
}

public 
void truncate(){
	try{
		string sql = "delete from note";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " +  this.GetType().Name +" <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class " + this.GetType().Name +" <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class"  + this.GetType().Name+ "<truncate>: " + de.Message,de);
	}
}

} // class

} // namespace
