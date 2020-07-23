using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CustVendDataBaseContainer : GenericDataBaseContainer{

public 
CustVendDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custvend";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
			custVendDataBase.load(reader);
			this.Add(custVendDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readById(string id){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custvend where CV_ID = '" + id + "'";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
			custVendDataBase.load(reader);
			this.Add(custVendDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readById> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readById> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readById> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByDesc(string desc, string type, string plant, string billToCust){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custvend" +
			" where ((CV_Plt like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_ID like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_Name like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_Address1 like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_Address2 like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_Address3 like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_Phone like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_Fax like '%" + Converter.fixString(desc) + "%') or " +
			"(CV_WebPage like '%" + Converter.fixString(desc) + "%'))"; 

		if (plant.Length>0) 
			sql += " and (CV_Plt = '" + Converter.fixString(plant) + "')";
		if (type.Length>0) 
			sql += " and (CV_RecType = '" + Converter.fixString(type) + "')";
		if (billToCust.Length>0)
			sql += " and (CV_BillToCust = '" + Converter.fixString(billToCust) + "')";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
			custVendDataBase.load(reader);		
			this.Add(custVendDataBase);
		}
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message, se);
	}
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message, de);
	}
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc)
	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message, mySqlExc);
	}
	finally
	{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{	
		string sql = "delete from custvend";
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
