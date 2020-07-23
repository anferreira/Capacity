using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CustPartDataBaseContainer : GenericDataBaseContainer{

public 
CustPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custpart";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CustPartDataBase custPartDataBase = new CustPartDataBase(dataBaseAccess);
			custPartDataBase.load(reader);
			this.Add(custPartDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
public 
void readByDb(string db){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custpart " + 
		             "where CP_Db = '" + Converter.fixString(db) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CustPartDataBase custPartDataBase = new CustPartDataBase(dataBaseAccess);
			custPartDataBase.load(reader);
			this.Add(custPartDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDb> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDb> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDb> : " + mySqlExc.Message, mySqlExc);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDb> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from custpart";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

}//end class
}//end namespace
