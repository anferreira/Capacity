using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacShfDataBase : GenericDataBaseElement{
	
private string CMS_SchVersion;
private string CMS_Plt;
private string CMS_Dept;
private string CMS_Mach;
private string CMS_TmType;
private int CMS_Wk;
private DateTime CMS_Dt;
private string CMS_Shf;
private decimal CMS_Hr;
private decimal CMS_HrPr;
private decimal CMS_UtilPer;
private DateTime CMS_DtShf;
private decimal CMS_SchPr;
private decimal CMS_MachCyc;
private decimal CMS_Racks;
private decimal CMS_HrClm;
private decimal CMS_HrPrClm;
private string CMS_CapType;
private int CMS_TmBlkOrd;

public
CapMacShfDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CMS_SchVersion = reader.GetString("CMS_SchVersion");
	this.CMS_Plt = reader.GetString("CMS_Plt");
	this.CMS_Dept = reader.GetString("CMS_Dept");
	this.CMS_Mach = reader.GetString("CMS_Mach");
	this.CMS_TmType = reader.GetString("CMS_TmType");
	this.CMS_Wk = reader.GetInt16("CMS_Wk");
	this.CMS_Dt = reader.GetDateTime("CMS_Dt");
	this.CMS_Shf = reader.GetString("CMS_Shf");
	this.CMS_Hr = reader.GetDecimal("CMS_Hr");
	this.CMS_HrPr = reader.GetDecimal("CMS_HrPr");
	this.CMS_UtilPer = reader.GetDecimal("CMS_UtilPer");
	this.CMS_DtShf = reader.GetDateTime("CMS_DtShf");
	this.CMS_SchPr = reader.GetDecimal("CMS_SchPr");
	this.CMS_MachCyc = reader.GetDecimal("CMS_MachCyc");
	this.CMS_Racks = reader.GetDecimal("CMS_Racks");
	this.CMS_HrClm = reader.GetDecimal("CMS_HrClm");
	this.CMS_HrPrClm = reader.GetDecimal("CMS_HrPrClm");
	this.CMS_CapType = reader.GetString("CMS_CapType");
	this.CMS_TmBlkOrd = reader.GetInt32("CMS_TmBlkOrd");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacshf where " + 
			"CMS_SchVersion = '" + CMS_SchVersion + "' and " +
			"CMS_Plt = '" + CMS_Plt + "' and " +
			"CMS_Dept = '" + CMS_Dept + "' and " +
			"CMS_Mach = '" + CMS_Mach + "' and " +
			"CMS_TmType = '" + CMS_TmType + "' and " +
			"CMS_Wk = " + CMS_Wk + " and " +
			"CMS_Dt	= '" + DateUtil.getDateRepresentation(CMS_Dt) + "' and " +
			"CMS_Shf = '" + CMS_Shf + "'";

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
		string sql = "delete from capmacshf where " +
			"CMS_SchVersion = '" + CMS_SchVersion + "' and " +
			"CMS_Plt = '" + CMS_Plt + "' and " +
			"CMS_Dept = '" + CMS_Dept + "' and " +
			"CMS_Mach = '" + CMS_Mach + "' and " +
			"CMS_TmType = '" + CMS_TmType + "' and " +
			"CMS_Wk = " + CMS_Wk + " and " +
			"CMS_Dt	= '" + DateUtil.getDateRepresentation(CMS_Dt) + "' and " +
			"CMS_Shf = '" + CMS_Shf + "'";

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
		string sql = "update capmacshf set " +
			"CMS_Hr = " + NumberUtil.toString(CMS_Hr) + ", " +
			"CMS_HrPr = " + NumberUtil.toString(CMS_HrPr) + ", " +
			"CMS_UtilPer = " + NumberUtil.toString(CMS_UtilPer) + ", " +
			"CMS_DtShf = '" + DateUtil.getDateRepresentation(CMS_DtShf) + "', " +
			"CMS_SchPr = " + NumberUtil.toString(CMS_SchPr) + ", " +
			"CMS_MachCyc = " + NumberUtil.toString(CMS_MachCyc) + ", " +
			"CMS_Racks = " + NumberUtil.toString(CMS_Racks) + ", " +
			"CMS_HrClm = " + NumberUtil.toString(CMS_HrClm) + ", " +
			"CMS_HrPrClm = " + NumberUtil.toString(CMS_HrPrClm) + ", " +
			"CMS_CapType = '" + Converter.fixString(CMS_CapType) + "', " +
			"CMS_TmBlkOrd = " + CMS_TmBlkOrd + " " +
		"where " + 
			"CMS_SchVersion = '" + CMS_SchVersion + "' and " +
			"CMS_Plt = '" + CMS_Plt + "' and " +
			"CMS_Dept = '" + CMS_Dept + "' and " +
			"CMS_Mach = '" + CMS_Mach + "' and " +
			"CMS_TmType = '" + CMS_TmType + "' and " +
			"CMS_Wk = " + CMS_Wk + " and " +
			"CMS_Dt = '" + DateUtil.getDateRepresentation(CMS_Dt) + "' and " +
			"CMS_Shf = '" + CMS_Shf + "'";

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
		string sql = "insert into capmacshf values('" + 
			Converter.fixString(CMS_SchVersion) + "', '" + 
			Converter.fixString(CMS_Plt) + "', '" + 
			Converter.fixString(CMS_Dept) + "', '" + 
			Converter.fixString(CMS_Mach) + "', '" + 
			Converter.fixString(CMS_TmType) + "', " + 
			CMS_Wk + ", '" + 
			DateUtil.getDateRepresentation(CMS_Dt) + "', '" +
			Converter.fixString(CMS_Shf) + "', " + 
			NumberUtil.toString(CMS_Hr) + ", " + 
			NumberUtil.toString(CMS_HrPr) + ", " + 
			NumberUtil.toString(CMS_UtilPer) + ", '" + 
			DateUtil.getDateRepresentation(CMS_DtShf) + "', " +
			NumberUtil.toString(CMS_SchPr) + ", " + 
			NumberUtil.toString(CMS_MachCyc) + ", " + 
			NumberUtil.toString(CMS_Racks) + ", " + 
			NumberUtil.toString(CMS_HrClm) + ", " + 
			NumberUtil.toString(CMS_HrPrClm) + ", '" + 
			Converter.fixString(CMS_CapType) + "', " + 
			CMS_TmBlkOrd + ")";

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
		string sql = "select * from capmacshf where " + 
			"CMS_SchVersion = '" + CMS_SchVersion + "' and " +
			"CMS_Plt = '" + CMS_Plt + "' and " +
			"CMS_Dept = '" + CMS_Dept + "' and " +
			"CMS_Mach = '" + CMS_Mach + "' and " +
			"CMS_TmType = '" + CMS_TmType + "' and " +
			"CMS_Wk = " + CMS_Wk + " and " +
			"CMS_Dt	= '" + DateUtil.getDateRepresentation(CMS_Dt) + "' and " +
			"CMS_Shf = '" + CMS_Shf + "'";

		bool returnValue = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			returnValue = true;
			reader.Close();
			reader = null;
		}
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
void setCMS_SchVersion(string CMS_SchVersion){
	this.CMS_SchVersion = CMS_SchVersion;
}

public
void setCMS_Plt(string CMS_Plt){
	this.CMS_Plt = CMS_Plt;
}

public
void setCMS_Dept(string CMS_Dept){
	this.CMS_Dept = CMS_Dept;
}

public
void setCMS_Mach(string CMS_Mach){
	this.CMS_Mach = CMS_Mach;
}

public
void setCMS_TmType(string CMS_TmType){
	this.CMS_TmType = CMS_TmType;
}

public
void setCMS_Wk(int CMS_Wk){
	this.CMS_Wk = CMS_Wk;
}

public
void setCMS_Dt(DateTime CMS_Dt){
	this.CMS_Dt = CMS_Dt;
}

public
void setCMS_Shf(string CMS_Shf){
	this.CMS_Shf = CMS_Shf;
}

public
void setCMS_Hr(decimal CMS_Hr){
	this.CMS_Hr = CMS_Hr;
}

public
void setCMS_HrPr(decimal CMS_HrPr){
	this.CMS_HrPr = CMS_HrPr;
}

public
void setCMS_UtilPer(decimal CMS_UtilPer){
	this.CMS_UtilPer = CMS_UtilPer;
}

public
void setCMS_DtShf(DateTime CMS_DtShf){
	this.CMS_DtShf = CMS_DtShf;
}

public
void setCMS_SchPr(decimal CMS_SchPr){
	this.CMS_SchPr = CMS_SchPr;
}

public
void setCMS_MachCyc(decimal CMS_MachCyc){
	this.CMS_MachCyc = CMS_MachCyc;
}

public
void setCMS_Racks(decimal CMS_Racks){
	this.CMS_Racks = CMS_Racks;
}

public
void setCMS_HrClm(decimal CMS_HrClm){
	this.CMS_HrClm = CMS_HrClm;
}

public
void setCMS_HrPrClm(decimal CMS_HrPrClm){
	this.CMS_HrPrClm = CMS_HrPrClm;
}

public
void setCMS_CapType(string CMS_CapType){
	this.CMS_CapType = CMS_CapType;
}

public
void setCMS_TmBlkOrd(int CMS_TmBlkOrd){
	this.CMS_TmBlkOrd = CMS_TmBlkOrd;
}


public
string getCMS_SchVersion(){
	return CMS_SchVersion;
}

public
string getCMS_Plt(){
	return CMS_Plt;
}

public
string getCMS_Dept(){
	return CMS_Dept;
}

public
string getCMS_Mach(){
	return CMS_Mach;
}

public
string getCMS_TmType(){
	return CMS_TmType;
}

public
int getCMS_Wk(){
	return CMS_Wk;
}

public
DateTime getCMS_Dt(){
	return CMS_Dt;
}

public
string getCMS_Shf(){
	return CMS_Shf;
}

public
decimal getCMS_Hr(){
	return CMS_Hr;
}

public
decimal getCMS_HrPr(){
	return CMS_HrPr;
}

public
decimal getCMS_UtilPer(){
	return CMS_UtilPer;
}

public
DateTime getCMS_DtShf(){
	return CMS_DtShf;
}

public
decimal getCMS_SchPr(){
	return CMS_SchPr;
}

public
decimal getCMS_MachCyc(){
	return CMS_MachCyc;
}

public
decimal getCMS_Racks(){
	return CMS_Racks;
}

public
decimal getCMS_HrClm(){
	return CMS_HrClm;
}

public
decimal getCMS_HrPrClm(){
	return CMS_HrPrClm;
}

public
string getCMS_CapType(){
	return CMS_CapType;
}

public
int getCMS_TmBlkOrd(){
	return CMS_TmBlkOrd;
}


}

}