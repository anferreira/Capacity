using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacDayDataBase : GenericDataBaseElement{
	
private string CMD_SchVersion;
private string CMD_Plt;
private string CMD_Dept;
private string CMD_Mach;
private string CMD_TmType;
private int CMD_Wk;
private DateTime CMD_Dt;
private decimal CMD_Hr;
private decimal CMD_HrPr;
private decimal CMD_UtilPer;
private decimal CMD_MachCyc;
private decimal CMD_SchPr;
private decimal CMD_Racks;
private int CMD_TmBlkOrd;
private decimal CMD_HrCum;
private decimal CMD_HrPrCum;
private string CMD_CapType;

public
CapMacDayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CMD_SchVersion = reader.GetString("CMD_SchVersion");
	this.CMD_Plt = reader.GetString("CMD_Plt");
	this.CMD_Dept = reader.GetString("CMD_Dept");
	this.CMD_Mach = reader.GetString("CMD_Mach");
	this.CMD_TmType = reader.GetString("CMD_TmType");
	this.CMD_Wk = reader.GetInt16("CMD_Wk");
	this.CMD_Dt = reader.GetDateTime("CMD_Dt");
	this.CMD_Hr = reader.GetDecimal("CMD_Hr");
	this.CMD_HrPr = reader.GetDecimal("CMD_HrPr");
	this.CMD_UtilPer = reader.GetDecimal("CMD_UtilPer");
	this.CMD_MachCyc = reader.GetDecimal("CMD_MachCyc");
	this.CMD_SchPr = reader.GetDecimal("CMD_SchPr");
	this.CMD_Racks = reader.GetDecimal("CMD_Racks");
	this.CMD_TmBlkOrd = reader.GetInt32("CMD_TmBlkOrd");
	this.CMD_HrCum = reader.GetDecimal("CMD_HrCum");
	this.CMD_HrPrCum = reader.GetDecimal("CMD_HrPrCum");
	this.CMD_CapType = reader.GetString("CMD_CapType");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacday where " + 
			"CMD_SchVersion = '" + CMD_SchVersion + "' and " +
			"CMD_Plt = '" + CMD_Plt + "' and " +
			"CMD_Dept = '" + CMD_Dept + "' and " +
			"CMD_Mach = '" + CMD_Mach + "' and " +
			"CMD_TmType = '" + CMD_TmType + "' and " +
			"CMD_Dt	= '" + DateUtil.getDateRepresentation(CMD_Dt) + "'";

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
		string sql = "delete from capmacday where " +
			"CMD_SchVersion = '" + CMD_SchVersion + "' and " +
			"CMD_Plt = '" + CMD_Plt + "' and " +
			"CMD_Dept = '" + CMD_Dept + "' and " +
			"CMD_Mach = '" + CMD_Mach + "' and " +
			"CMD_TmType = '" + CMD_TmType + "' and " +
			"CMD_Dt	= '" + DateUtil.getDateRepresentation(CMD_Dt) + "'";
		
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
		string sql = "update capmacday set " +
			"CMD_Wk = " + NumberUtil.toString(CMD_Wk) + ", " +
			"CMD_Hr = " + NumberUtil.toString(CMD_Hr) + ", " +
			"CMD_HrPr = " + NumberUtil.toString(CMD_HrPr) + ", " +
			"CMD_UtilPer = " + NumberUtil.toString(CMD_UtilPer) + ", " +
			"CMD_MachCyc = " + NumberUtil.toString(CMD_MachCyc) + ", " +
			"CMD_SchPr = " + NumberUtil.toString(CMD_SchPr) + ", " +
			"CMD_Racks = " + NumberUtil.toString(CMD_Racks) + ", " +
			"CMD_TmBlkOrd = " + CMD_TmBlkOrd + ", " +
			"CMD_HrCum = " + NumberUtil.toString(CMD_HrCum) + ", " +
			"CMD_HrPrCum = " + NumberUtil.toString(CMD_HrPrCum) + ", " +
			"CMD_CapType = '" + Converter.fixString(CMD_CapType) + "' " +
		"where " + 
			"CMD_SchVersion = '" + CMD_SchVersion + "' and " +
			"CMD_Plt = '" + CMD_Plt + "' and " +
			"CMD_Dept = '" + CMD_Dept + "' and " +
			"CMD_Mach = '" + CMD_Mach + "' and " +
			"CMD_TmType = '" + CMD_TmType + "' and " +
			"CMD_Dt	= '" + DateUtil.getDateRepresentation(CMD_Dt) + "'";

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
		string sql = "insert into capmacday values('" + 
			Converter.fixString(CMD_SchVersion) + "', '" +
			Converter.fixString(CMD_Plt) + "', '" +
			Converter.fixString(CMD_Dept) + "', '" +
			Converter.fixString(CMD_Mach) + "', '" +
			Converter.fixString(CMD_TmType) + "', " +
			NumberUtil.toString(CMD_Wk) + ", '" +
			DateUtil.getDateRepresentation(CMD_Dt) + "', " +
			NumberUtil.toString(CMD_Hr) + ", " +
			NumberUtil.toString(CMD_HrPr) + ", " +
			NumberUtil.toString(CMD_UtilPer) + ", " +
			NumberUtil.toString(CMD_MachCyc) + ", " +
			NumberUtil.toString(CMD_SchPr) + ", " +
			NumberUtil.toString(CMD_Racks) + ", " +
			NumberUtil.toString(CMD_TmBlkOrd) + ", " +
			NumberUtil.toString(CMD_HrCum) + ", " +
			NumberUtil.toString(CMD_HrPrCum) + ", '" +
			Converter.fixString(CMD_CapType) + "')";

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
		string sql = "select * from capmacday where " + 
			"CMD_SchVersion = '" + CMD_SchVersion + "' and " +
			"CMD_Plt = '" + CMD_Plt + "' and " +
			"CMD_Dept = '" + CMD_Dept + "' and " +
			"CMD_Mach = '" + CMD_Mach + "' and " +
			"CMD_TmType = '" + CMD_TmType + "' and " +
			"CMD_Dt = '" + DateUtil.getDateRepresentation(CMD_Dt) + "'";
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
void setCMD_SchVersion(string CMD_SchVersion){
	this.CMD_SchVersion = CMD_SchVersion;
}

public
void setCMD_Plt(string CMD_Plt){
	this.CMD_Plt = CMD_Plt;
}

public
void setCMD_Dept(string CMD_Dept){
	this.CMD_Dept = CMD_Dept;
}

public
void setCMD_Mach(string CMD_Mach){
	this.CMD_Mach = CMD_Mach;
}

public
void setCMD_TmType(string CMD_TmType){
	this.CMD_TmType = CMD_TmType;
}

public
void setCMD_Wk(int CMD_Wk){
	this.CMD_Wk = CMD_Wk;
}

public
void setCMD_Dt(DateTime CMD_Dt){
	this.CMD_Dt = CMD_Dt;
}

public
void setCMD_Hr(decimal CMD_Hr){
	this.CMD_Hr = CMD_Hr;
}

public
void setCMD_HrPr(decimal CMD_HrPr){
	this.CMD_HrPr = CMD_HrPr;
}

public
void setCMD_UtilPer(decimal CMD_UtilPer){
	this.CMD_UtilPer = CMD_UtilPer;
}

public
void setCMD_MachCyc(decimal CMD_MachCyc){
	this.CMD_MachCyc = CMD_MachCyc;
}

public
void setCMD_SchPr(decimal CMD_SchPr){
	this.CMD_SchPr = CMD_SchPr;
}

public
void setCMD_Racks(decimal CMD_Racks){
	this.CMD_Racks = CMD_Racks;
}

public
void setCMD_TmBlkOrd(int CMD_TmBlkOrd){
	this.CMD_TmBlkOrd = CMD_TmBlkOrd;
}

public
void setCMD_HrCum(decimal CMD_HrCum){
	this.CMD_HrCum = CMD_HrCum;
}

public
void setCMD_HrPrCum(decimal CMD_HrPrCum){
	this.CMD_HrPrCum = CMD_HrPrCum;
}

public
void setCMD_CapType(string CMD_CapType){
	this.CMD_CapType = CMD_CapType;
}


public
string getCMD_SchVersion(){
	return CMD_SchVersion;
}

public
string getCMD_Plt(){
	return CMD_Plt;
}

public
string getCMD_Dept(){
	return CMD_Dept;
}

public
string getCMD_Mach(){
	return CMD_Mach;
}

public
string getCMD_TmType(){
	return CMD_TmType;
}

public
int getCMD_Wk(){
	return CMD_Wk;
}

public
DateTime getCMD_Dt(){
	return CMD_Dt;
}

public
decimal getCMD_Hr(){
	return CMD_Hr;
}

public
decimal getCMD_HrPr(){
	return CMD_HrPr;
}

public
decimal getCMD_UtilPer(){
	return CMD_UtilPer;
}

public
decimal getCMD_MachCyc(){
	return CMD_MachCyc;
}

public
decimal getCMD_SchPr(){
	return CMD_SchPr;
}

public
decimal getCMD_Racks(){
	return CMD_Racks;
}

public
int getCMD_TmBlkOrd(){
	return CMD_TmBlkOrd;
}

public
decimal getCMD_HrCum(){
	return CMD_HrCum;
}

public
decimal getCMD_HrPrCum(){
	return CMD_HrPrCum;
}

public
string getCMD_CapType(){
	return CMD_CapType;
}

}

}