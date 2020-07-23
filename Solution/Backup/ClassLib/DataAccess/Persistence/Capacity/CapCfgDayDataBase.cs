using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapCfgDayDataBase : GenericDataBaseElement{
	
private string CCD_SchVersion;
private string CCD_Plt;
private string CCD_Dept;
private string CCD_Cfg;
private int CCD_Wk;
private int CCD_WkAcc;
private DateTime CCD_Dt;
private string CCD_TmType;
private decimal CCD_Hr;
private decimal CCD_HrPr;
private decimal CCD_HrCum;

public
CapCfgDayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CCD_SchVersion = reader.GetString("CCD_SchVersion");
	this.CCD_Plt = reader.GetString("CCD_Plt");
	this.CCD_Dept = reader.GetString("CCD_Dept");
	this.CCD_Cfg = reader.GetString("CCD_Cfg");
	this.CCD_Wk = reader.GetInt32("CCD_Wk");
	this.CCD_WkAcc = reader.GetInt32("CCD_WkAcc");
	this.CCD_Dt = reader.GetDateTime("CCD_Dt");
	this.CCD_TmType = reader.GetString("CCD_TmType");
	this.CCD_Hr = reader.GetDecimal("CCD_Hr");
	this.CCD_HrPr = reader.GetDecimal("CCD_HrPr");
	this.CCD_HrCum = reader.GetDecimal("CCD_HrCum");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capcfgday where " + 
			"CCD_SchVersion = '" + CCD_SchVersion + "' and " +
			"CCD_Plt = '" + CCD_Plt + "' and " +
			"CCD_Dept = '" + CCD_Dept + "' and " +
			"CCD_Cfg = '" + CCD_Cfg + "' and " +
			"CCD_Dt = '" + DateUtil.getDateRepresentation(CCD_Dt) + "' and " + 
			"CCD_TmType = '" + CCD_TmType + "'";
		
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
		string sql = "delete from capcfgday where " +
			"CCD_SchVersion = '" + CCD_SchVersion + "' and " +
			"CCD_Plt = '" + CCD_Plt + "' and " +
			"CCD_Dept = '" + CCD_Dept + "' and " +
			"CCD_Cfg = '" + CCD_Cfg + "' and " +
			"CCD_Dt = '" + DateUtil.getDateRepresentation(CCD_Dt) + "' and " + 
			"CCD_TmType = '" + CCD_TmType + "'";
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
		string sql = "update capcfgday set " +
			"CCD_TmType = '" + Converter.fixString(CCD_TmType) + "', " +
			"CCD_Hr = " + NumberUtil.toString(CCD_Hr) + ", " +
			"CCD_HrPr = " + NumberUtil.toString(CCD_HrPr) + ", " +
			"CCD_HrCum = " + NumberUtil.toString(CCD_HrCum) +
		" where " + 
			"CCD_SchVersion = '" + CCD_SchVersion + "' and " +
			"CCD_Plt = '" + CCD_Plt + "' and " +
			"CCD_Dept = '" + CCD_Dept + "' and " +
			"CCD_Cfg = '" + CCD_Cfg + "' and " +
			"CCD_Dt = '" + DateUtil.getDateRepresentation(CCD_Dt) + "' and " + 
			"CCD_TmType = '" + CCD_TmType + "'";
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
		string sql = "insert into capcfgday values('" + 
			Converter.fixString(CCD_SchVersion) + "', '" +
			Converter.fixString(CCD_Plt) + "', '" +
			Converter.fixString(CCD_Dept) + "', '" +
			Converter.fixString(CCD_Cfg) + "', " +
			CCD_Wk + ", " +
			CCD_WkAcc + ", '" +
			DateUtil.getDateRepresentation(CCD_Dt) + "', '" +
			Converter.fixString(CCD_TmType) + "', " +
			NumberUtil.toString(CCD_Hr) + ", " +
			NumberUtil.toString(CCD_HrPr) + ", " +
			NumberUtil.toString(CCD_HrCum) + ")";
			
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
		string sql = "select * from capcfgday where " + 
			"CCD_SchVersion = '" + CCD_SchVersion + "' and " +
			"CCD_Plt = '" + CCD_Plt + "' and " +
			"CCD_Dept = '" + CCD_Dept + "' and " +
			"CCD_Cfg = '" + CCD_Cfg + "' and " +
			"CCD_Dt = '" + DateUtil.getDateRepresentation(CCD_Dt) + "' and " + 
			"CCD_TmType = '" + CCD_TmType + "'";
		
		bool returnValue = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue  = true;
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
void setCCD_SchVersion(string CCD_SchVersion){
	this.CCD_SchVersion = CCD_SchVersion;
}

public
void setCCD_Plt(string CCD_Plt){
	this.CCD_Plt = CCD_Plt;
}

public
void setCCD_Dept(string CCD_Dept){
	this.CCD_Dept = CCD_Dept;
}

public
void setCCD_Cfg(string CCD_Cfg){
	this.CCD_Cfg = CCD_Cfg;
}

public
void setCCD_Wk(int CCD_Wk){
	this.CCD_Wk = CCD_Wk;
}

public
void setCCD_WkAcc(int CCD_WkAcc){
	this.CCD_WkAcc = CCD_WkAcc;
}

public
void setCCD_Dt(DateTime CCD_Dt){
	this.CCD_Dt = CCD_Dt;
}

public
void setCCD_TmType(string CCD_TmType){
	this.CCD_TmType = CCD_TmType;
}

public
void setCCD_Hr(decimal CCD_Hr){
	this.CCD_Hr = CCD_Hr;
}

public
void setCCD_HrPr(decimal CCD_HrPr){
	this.CCD_HrPr = CCD_HrPr;
}

public
void setCCD_HrCum(decimal CCD_HrCum){
	this.CCD_HrCum = CCD_HrCum;
}

public
string getCCD_SchVersion(){
	return CCD_SchVersion;
}

public
string getCCD_Plt(){
	return CCD_Plt;
}

public
string getCCD_Dept(){
	return CCD_Dept;
}

public
string getCCD_Cfg(){
	return CCD_Cfg;
}

public
int getCCD_Wk(){
	return CCD_Wk;
}

public
int getCCD_WkAcc(){
	return CCD_WkAcc;
}

public
DateTime getCCD_Dt(){
	return CCD_Dt;
}

public
string getCCD_TmType(){
	return CCD_TmType;
}

public
decimal getCCD_Hr(){
	return CCD_Hr;
}

public
decimal getCCD_HrPr(){
	return CCD_HrPr;
}

public
decimal getCCD_HrCum(){
	return CCD_HrCum;
}


} // class

} // namespace