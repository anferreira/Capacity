using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapCfgShfDataBase : GenericDataBaseElement{
	
private string CCH_SchVersion;
private string CCH_Plt;
private string CCH_Dept;
private string CCH_Cfg;
private int CCH_Wk;
private int CCH_WkAcc;
private DateTime CCH_Dt;
private string CCH_Shf;
private string CCH_TmType;
private decimal CCH_Hr;
private decimal CCH_HrPr;

public
CapCfgShfDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CCH_SchVersion = reader.GetString("CCH_SchVersion");
	this.CCH_Plt = reader.GetString("CCH_Plt");
	this.CCH_Dept = reader.GetString("CCH_Dept");
	this.CCH_Cfg = reader.GetString("CCH_Cfg");
	this.CCH_Wk = reader.GetInt32("CCH_Wk");
	this.CCH_WkAcc = reader.GetInt32("CCH_WkAcc");
	this.CCH_Dt = reader.GetDateTime("CCH_Dt");
	this.CCH_Shf = reader.GetString("CCH_Shf");
	this.CCH_TmType = reader.GetString("CCH_TmType");
	this.CCH_Hr = reader.GetDecimal("CCH_Hr");
	this.CCH_HrPr = reader.GetDecimal("CCH_HrPr");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capcfgshf where " + 
			"CCH_SchVersion = '" + CCH_SchVersion + "' and " +
			"CCH_Plt = '" + CCH_Plt + "' and " +
			"CCH_Dept = '" + CCH_Dept + "' and " +
			"CCH_Cfg = '" + CCH_Cfg + "' and " +
			"CCH_Wk = " + CCH_Wk + " and " +
			"CCH_WkAcc = " + CCH_WkAcc + " and " +
			"CCH_Dt = '" + DateUtil.getDateRepresentation(CCH_Dt) + "'";
		
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
			"CCH_SchVersion = '" + CCH_SchVersion + "' and " +
			"CCH_Plt = '" + CCH_Plt + "' and " +
			"CCH_Dept = '" + CCH_Dept + "' and " +
			"CCH_Cfg = '" + CCH_Cfg + "' and " +
			"CCH_Wk = " + CCH_Wk + " and " +
			"CCH_WkAcc = " + CCH_WkAcc + " and " +
			"CCH_Dt = '" + DateUtil.getDateRepresentation(CCH_Dt) + "'";
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
			"CCH_TmType = '" + Converter.fixString(CCH_TmType) + "', " +
			"CCH_Shf = '" + Converter.fixString(CCH_Shf) + "', " +
			"CCH_Hr = " + NumberUtil.toString(CCH_Hr) + ", " +
			"CCH_HrPr = " + NumberUtil.toString(CCH_HrPr) +
		" where " + 
			"CCH_SchVersion = '" + CCH_SchVersion + "' and " +
			"CCH_Plt = '" + CCH_Plt + "' and " +
			"CCH_Dept = '" + CCH_Dept + "' and " +
			"CCH_Cfg = '" + CCH_Cfg + "' and " +
			"CCH_Wk = " + CCH_Wk + " and " +
			"CCH_WkAcc = " + CCH_WkAcc + " and " +
			"CCH_Dt = '" + DateUtil.getDateRepresentation(CCH_Dt) + "'";
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
			Converter.fixString(CCH_SchVersion) + "', '" +
			Converter.fixString(CCH_Plt) + "', '" +
			Converter.fixString(CCH_Dept) + "', '" +
			Converter.fixString(CCH_Cfg) + "', " +
			CCH_Wk + ", " +
			CCH_WkAcc + ", '" +
			DateUtil.getDateRepresentation(CCH_Dt) + "', '" +
			Converter.fixString(CCH_Shf) + "', '" +
			Converter.fixString(CCH_TmType) + "', " +
			NumberUtil.toString(CCH_Hr) + ", " +
			NumberUtil.toString(CCH_HrPr) + ")";

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
	try{
		read();
	}catch(System.Data.SqlClient.SqlException){
		return false;
	}catch(System.Data.DataException){
		return false;
	}catch(MySql.Data.MySqlClient.MySqlException){
		return false;
	}
	return true;
}

public
void setCCH_SchVersion(string CCH_SchVersion){
	this.CCH_SchVersion = CCH_SchVersion;
}

public
void setCCH_Plt(string CCH_Plt){
	this.CCH_Plt = CCH_Plt;
}

public
void setCCH_Dept(string CCH_Dept){
	this.CCH_Dept = CCH_Dept;
}

public
void setCCH_Cfg(string CCH_Cfg){
	this.CCH_Cfg = CCH_Cfg;
}

public
void setCCH_Wk(int CCH_Wk){
	this.CCH_Wk = CCH_Wk;
}

public
void setCCH_WkAcc(int CCH_WkAcc){
	this.CCH_WkAcc = CCH_WkAcc;
}

public
void setCCH_Dt(DateTime CCH_Dt){
	this.CCH_Dt = CCH_Dt;
}

public
void setCCH_Shf(string CCH_Shf){
	this.CCH_Shf = CCH_Shf;
}

public
void setCCH_TmType(string CCH_TmType){
	this.CCH_TmType = CCH_TmType;
}

public
void setCCH_Hr(decimal CCH_Hr){
	this.CCH_Hr = CCH_Hr;
}

public
void setCCH_HrPr(decimal CCH_HrPr){
	this.CCH_HrPr = CCH_HrPr;
}



public
string getCCH_SchVersion(){
	return CCH_SchVersion;
}

public
string getCCH_Plt(){
	return CCH_Plt;
}

public
string getCCH_Dept(){
	return CCH_Dept;
}

public
string getCCH_Cfg(){
	return CCH_Cfg;
}

public
int getCCH_Wk(){
	return CCH_Wk;
}

public
int getCCH_WkAcc(){
	return CCH_WkAcc;
}

public
DateTime getCCH_Dt(){
	return CCH_Dt;
}

public
string getCCH_Shf(){
	return CCH_Shf;
}

public
string getCCH_TmType(){
	return CCH_TmType;
}

public
decimal getCCH_Hr(){
	return CCH_Hr;
}

public
decimal getCCH_HrPr(){
	return CCH_HrPr;
}

}

}