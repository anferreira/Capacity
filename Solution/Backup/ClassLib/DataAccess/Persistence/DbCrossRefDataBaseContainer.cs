using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class DbCrossRefDataBaseContainer : GenericDataBaseContainer{

private string ST_Customer;

public 
DbCrossRefDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
    NotNullDataReader reader =null;
	try{
		string sql = "select * from dbcrossref";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DbCrossRefDataBase dbCrossRefDataBase = new DbCrossRefDataBase(dataBaseAccess);
			dbCrossRefDataBase.load(reader);		
			this.Add(dbCrossRefDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : <read>" + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : <read>" + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readAllDB(){
    NotNullDataReader reader = null;
	try{
	    string sql = "select distinct ST_Db from dbcrossref "+ 
		             "Order by ST_Db";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DbCrossRefDataBase dbCrossRefDataBase = new DbCrossRefDataBase(dataBaseAccess);
			dbCrossRefDataBase.loadDB(reader);		
			this.Add(dbCrossRefDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : <readAllDb>" + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : <readAllDb>" + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllDb> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByClient(){
    NotNullDataReader reader = null;
	try{
	    string sql = "select distinct ST_DB from dbcrossref " +
					 "where ST_Customer = '" + Converter.fixString(ST_Customer) +"' " +
					 "order by ST_Db";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DbCrossRefDataBase dbCrossRefDataBase = new DbCrossRefDataBase(dataBaseAccess);
			dbCrossRefDataBase.loadDB(reader);		
			this.Add(dbCrossRefDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByClient> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByClient>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByClient> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{	
		string sql = "delete from dbcrossref";
			dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

//Setters
public void setST_Customer(string ST_Customer){
   this.ST_Customer = ST_Customer;
}

//Getters
public
string getST_Customer(){
   return ST_Customer;
}

}//end class

}//end namespace
