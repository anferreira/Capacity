using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class ArRemLinkHdrDataBaseContainer	:GenericDataBaseContainer{

public 
ArRemLinkHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from ARRemLinkHdr";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArRemLinkHdrDataBase arRemLinkHdrDataBase = new ArRemLinkHdrDataBase(dataBaseAccess);
			arRemLinkHdrDataBase.load(reader);
			this.Add(arRemLinkHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from ARRemLinkHdr";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

}//end class

}//end namespace
