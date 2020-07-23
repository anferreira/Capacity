using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacCfgDataBase : GenericDataBaseElement{
	
private string CMC_Plt;
private string CMC_Dept;
private string CMC_Cfg;
private string CMC_Des1;
private string CMC_Set;
private decimal CMC_TotalHrs;
private decimal CMC_TotalHrsPr;
private string CMC_Exact;

public
CapMacCfgDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CMC_Plt = reader.GetString("CMC_Plt");
	this.CMC_Dept = reader.GetString("CMC_Dept");
	this.CMC_Cfg = reader.GetString("CMC_Cfg");
	this.CMC_Des1 = reader.GetString("CMC_Des1");
	this.CMC_Set = reader.GetString("CMC_Set");
	this.CMC_TotalHrs = reader.GetDecimal("CMC_TotalHrs");
	this.CMC_TotalHrsPr = reader.GetDecimal("CMC_TotalHrsPr");
	this.CMC_Exact = reader.GetString("CMC_Exact");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmaccfg where " + 
			"CMC_Plt = '" + CMC_Plt + "' and " +
			"CMC_Dept = '" + CMC_Dept + "' and " +
			"CMC_Cfg = '" + CMC_Cfg + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
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

public override
void write(){
	try{
		string sql = "insert into capmaccfg values('" + 
			Converter.fixString(CMC_Plt) + "', '" + 
			Converter.fixString(CMC_Dept) + "', '" + 
			Converter.fixString(CMC_Cfg) + "', '" + 
			Converter.fixString(CMC_Des1) + "', '" + 
			Converter.fixString(CMC_Set) + "', " + 
			NumberUtil.toString(CMC_TotalHrs) + ", " + 
			NumberUtil.toString(CMC_TotalHrsPr) + ", '" + 
			Converter.fixString(CMC_Exact) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete from capmaccfg where " +
			"CMC_Plt = '" + CMC_Plt + "' and " +
			"CMC_Dept = '" + CMC_Dept + "' and " +
			"CMC_Cfg = '" + CMC_Cfg + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update capmaccfg set " +
			"CMC_Des1 = '" + Converter.fixString(CMC_Des1) + "', " +
			"CMC_Set = '" + Converter.fixString(CMC_Set) + "', " +
			"CMC_TotalHrs = " + NumberUtil.toString(CMC_TotalHrs) + ", " +
			"CMC_TotalHrsPr = " + NumberUtil.toString(CMC_TotalHrsPr) + ", " +
			"CMC_Exact = '" + Converter.fixString(CMC_Exact) + "'" +
		" where " + 
			"CMC_Plt = '" + CMC_Plt + "' and " +
			"CMC_Dept = '" + CMC_Dept + "' and " +
			"CMC_Cfg = '" + CMC_Cfg + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool hasConfigurationForDept(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;

		string sql = "select count(*) as cantCfg " +
		             "from capmaccfg " + 
		             "where " + 
		                "CMC_Plt = '" + CMC_Plt + "' and " +
			            "CMC_Dept = '" + CMC_Dept + "'";
		             
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
		    int cantCfg = reader.GetInt32("cantCfg");
		    if (cantCfg>0)
		        returnValue = true;
        }
		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasConfigurationForDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasConfigurationForDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasConfigurationForDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try
	{
		bool returnValue = false;
		string sql ="select * from capmaccfg where CMC_Plt = '" + CMC_Plt + "'" +
			"and CMC_Dept = '"	+ CMC_Dept	+ "'" +
			"and CMC_Cfg = '"	+ CMC_Cfg	+ "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc)
	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}
	finally
	{
		if (reader != null)
			reader.Close();
	}
}

public
void setCMC_Plt(string CMC_Plt){
	this.CMC_Plt = CMC_Plt;
}

public
void setCMC_Dept(string CMC_Dept){
	this.CMC_Dept = CMC_Dept;
}

public
void setCMC_Cfg(string CMC_Cfg){
	this.CMC_Cfg = CMC_Cfg;
}

public
void setCMC_Des1(string CMC_Des1){
	this.CMC_Des1 = CMC_Des1;
}

public
void setCMC_Set(string CMC_Set){
	this.CMC_Set = CMC_Set;
}

public
void setCMC_TotalHrs(decimal CMC_TotalHrs){
	this.CMC_TotalHrs = CMC_TotalHrs;
}
public
void setCMC_TotalHrsPr(decimal CMC_TotalHrsPr){
	this.CMC_TotalHrsPr = CMC_TotalHrsPr;
}

public
void setCMC_Exact(string CMC_Exact){
	this.CMC_Exact = CMC_Exact;
}


public
string getCMC_Plt(){
	return CMC_Plt;
}

public
string getCMC_Dept(){
	return CMC_Dept;
}

public
string getCMC_Cfg(){
	return CMC_Cfg;
}

public
string getCMC_Des1(){
	return CMC_Des1;
}

public
string getCMC_Set(){
	return CMC_Set;
}

public
decimal getCMC_TotalHrs(){
	return CMC_TotalHrs;
}

public
decimal getCMC_TotalHrsPr(){
	return CMC_TotalHrsPr;
}

public
string getCMC_Exact(){
	return CMC_Exact;
}

} // class

} // namespace