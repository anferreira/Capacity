using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class ArInvoiceDefDataBaseContainer: GenericDataBaseContainer{


public ArInvoiceDefDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoicedef";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceDefDataBase arInvoiceDefDataBase = new ArInvoiceDefDataBase(dataBaseAccess);
			arInvoiceDefDataBase.load(reader);
			this.Add(arInvoiceDefDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public void truncate(){
	try{
		string sql = "delete from arinvoicedef";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message);
		}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}



}//end Class
}//end namespace
