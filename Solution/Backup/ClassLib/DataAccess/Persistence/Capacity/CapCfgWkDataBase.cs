using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapCfgWkDataBase : GenericDataBaseElement{
	
private string CCW_SchVersion;
private string CCW_Plt;
private string CCW_Dept;
private string CCW_Cfg;
private int CCW_Wk;
private int CCW_WkAcc;
private decimal CCW_Hr;
private decimal CCW_HrPr;
private int CCW_Year;
private string CCW_TmType;

public
CapCfgWkDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CCW_SchVersion = reader.GetString("CCW_SchVersion");
	this.CCW_Plt = reader.GetString("CCW_Plt");
	this.CCW_Dept = reader.GetString("CCW_Dept");
	this.CCW_Cfg = reader.GetString("CCW_Cfg");
	this.CCW_Wk = reader.GetInt32("CCW_Wk");
	this.CCW_WkAcc = reader.GetInt32("CCW_WkAcc");
	this.CCW_Hr = reader.GetDecimal("CCW_Hr");
	this.CCW_HrPr = reader.GetDecimal("CCW_HrPr");
	this.CCW_Year = reader.GetInt32("CCW_Year");
	this.CCW_TmType = reader.GetString("CCW_TmType");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capcfgshf where " + 
			"CCW_SchVersion = '" + Converter.fixString(CCW_SchVersion) + "' and " +
			"CCW_Plt = '" + Converter.fixString(CCW_Plt) + "' and " +
			"CCW_Dept = '" + Converter.fixString(CCW_Dept) + "' and " +
			"CCW_Cfg = '" + Converter.fixString(CCW_Cfg) + "' and " +
			"CCW_Wk = " + NumberUtil.toString(CCW_Wk) + " and " +
			"CCW_Year = " + NumberUtil.toString(CCW_Year) + " and " + 
			"CCW_TmType = " + Converter.fixString(CCW_TmType);
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
void delete(){
	try{
		string sql = "delete from capcfgshf where " +
			"CCW_SchVersion = '" + Converter.fixString(CCW_SchVersion) + "' and " +
			"CCW_Plt = '" + Converter.fixString(CCW_Plt) + "' and " +
			"CCW_Dept = '" + Converter.fixString(CCW_Dept) + "' and " +
			"CCW_Cfg = '" + Converter.fixString(CCW_Cfg) + "' and " +
			"CCW_Wk = " + NumberUtil.toString(CCW_Wk) + " and " +
			"CCW_Year = " + NumberUtil.toString(CCW_Year) + " and " + 
			"CCW_TmType = " + Converter.fixString(CCW_TmType);
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
		string sql = "update capcfgshf set " +
			"CCW_Hr = " + NumberUtil.toString(CCW_Hr) + ", " +
			"CCW_HrPr = " + NumberUtil.toString(CCW_HrPr) +
			"CCW_WkAcc = " + NumberUtil.toString(CCW_WkAcc) + 
		" where " + 
			"CCW_SchVersion = '" + Converter.fixString(CCW_SchVersion) + "' and " +
			"CCW_Plt = '" + Converter.fixString(CCW_Plt) + "' and " +
			"CCW_Dept = '" + Converter.fixString(CCW_Dept) + "' and " +
			"CCW_Cfg = '" + Converter.fixString(CCW_Cfg) + "' and " +
			"CCW_Wk = " + NumberUtil.toString(CCW_Wk) + " and " +
			"CCW_Year = " + NumberUtil.toString(CCW_Year) + " and " + 
			"CCW_TmType = " + Converter.fixString(CCW_TmType);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void write(){
	try{
		string sql = "insert into capcfgshf values('" + 
			Converter.fixString(CCW_SchVersion) + "', '" +
			Converter.fixString(CCW_Plt) + "', '" +
			Converter.fixString(CCW_Dept) + "', '" +
			Converter.fixString(CCW_Cfg) + "', " +
			NumberUtil.toString(CCW_Wk) + ", " +
			NumberUtil.toString(CCW_WkAcc) + ", " +
			NumberUtil.toString(CCW_Hr) + ", " +
			NumberUtil.toString(CCW_HrPr) + ", " + 
			NumberUtil.toString(CCW_Year) + ", " + 
			Converter.fixString(CCW_TmType) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capcfgshf where " + 
			"CCW_SchVersion = '" + Converter.fixString(CCW_SchVersion) + "' and " +
			"CCW_Plt = '" + Converter.fixString(CCW_Plt) + "' and " +
			"CCW_Dept = '" + Converter.fixString(CCW_Dept) + "' and " +
			"CCW_Cfg = '" + Converter.fixString(CCW_Cfg) + "' and " +
			"CCW_Wk = " + NumberUtil.toString(CCW_Wk) + " and " +
			"CCW_Year = " + NumberUtil.toString(CCW_Year) + " and " + 
			"CCW_TmType = " + Converter.fixString(CCW_TmType);

		bool returnValue = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
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
void setCCW_SchVersion(string CCW_SchVersion){
	this.CCW_SchVersion = CCW_SchVersion;
}

public
void setCCW_Plt(string CCW_Plt){
	this.CCW_Plt = CCW_Plt;
}

public
void setCCW_Dept(string CCW_Dept){
	this.CCW_Dept = CCW_Dept;
}

public
void setCCW_Cfg(string CCW_Cfg){
	this.CCW_Cfg = CCW_Cfg;
}

public
void setCCW_Wk(int CCW_Wk){
	this.CCW_Wk = CCW_Wk;
}

public
void setCCW_WkAcc(int CCW_WkAcc){
	this.CCW_WkAcc = CCW_WkAcc;
}

public
void setCCW_Hr(decimal CCW_Hr){
	this.CCW_Hr = CCW_Hr;
}

public
void setCCW_HrPr(decimal CCW_HrPr){
	this.CCW_HrPr = CCW_HrPr;
}

public
void setCCW_Year(int CCW_Year){
	this.CCW_Year = CCW_Year;
}

public
void setCCW_TmType(string CCW_TmType){
	this.CCW_TmType = CCW_TmType;
}


public
string getCCW_SchVersion(){
	return CCW_SchVersion;
}

public
string getCCW_Plt(){
	return CCW_Plt;
}

public
string getCCW_Dept(){
	return CCW_Dept;
}

public
string getCCW_Cfg(){
	return CCW_Cfg;
}

public
int getCCW_Wk(){
	return CCW_Wk;
}

public
int getCCW_WkAcc(){
	return CCW_WkAcc;
}

public
decimal getCCW_Hr(){
	return CCW_Hr;
}

public
decimal getCCW_HrPr(){
	return CCW_HrPr;
}

public
int getCCW_Year(){
	return CCW_Year;
}

public
string getCCW_TmType(){
	return CCW_TmType;
}


} // class

} // namespace