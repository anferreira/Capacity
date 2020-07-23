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

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
		custVendDataBase.load(reader);
		this.Add(custVendDataBase);
	}
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
    string sql = "delete from custvend";
    truncate(sql);			
}

public
void readByFilters(string splant,string sid,string stype,string scustType,string status,string sname,string saddress1,string sbillToCust,string sphone,int irows){
    string sql = "select * from custvend";
       
	if (!string.IsNullOrEmpty(splant)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_Plt",splant);
    if (!string.IsNullOrEmpty(sid)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_ID", sid);
    if (!string.IsNullOrEmpty(stype)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_RecType",stype);
    if (!string.IsNullOrEmpty(scustType)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_CustomerType",scustType);
    if (!string.IsNullOrEmpty(sbillToCust)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_BillToCust",sbillToCust);
    if (!string.IsNullOrEmpty(sname)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_Name",sname);
    if (!string.IsNullOrEmpty(saddress1)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_Address1",saddress1);
    if (!string.IsNullOrEmpty(sphone)) 
		sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CV_Phone", sphone);

    sql+= " order by CV_ID";
    if (irows > 0)
       sql = DBFormatter.selectTopRows(sql,irows);
	
    read(sql);
}

}//end class

}//end namespace
