using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacWkDataBase : GenericDataBaseElement{
	
private string CMW_SchVersion;
private string CMW_Plt;
private string CMW_Dept;
private string CMW_Mach;
private string CMW_TmType;
private int CMW_Wk;
private int CMW_WkAcc;
private decimal CMW_Hr;
private decimal CMW_HrPr;
private int CMW_Year;
private string CMW_TypeNum;
private DateTime CMW_DtWkStart;
private decimal CMW_SchPr;
private decimal CMW_MachCyc;
private decimal CMW_Racks;
private decimal CMW_HrClm;
private decimal CMW_HrPrClm;
private string CMW_CapType;
private int CMW_TmBlkOrd;


public
CapMacWkDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CMW_SchVersion = reader.GetString("CMW_SchVersion");
	this.CMW_Plt = reader.GetString("CMW_Plt");
	this.CMW_Dept = reader.GetString("CMW_Dept");
	this.CMW_Mach = reader.GetString("CMW_Mach");
	this.CMW_TmType = reader.GetString("CMW_TmType");
	this.CMW_Wk = reader.GetInt32("CMW_Wk");
	this.CMW_WkAcc = reader.GetInt32("CMW_WkAcc");
	this.CMW_Hr = reader.GetDecimal("CMW_Hr");
	this.CMW_HrPr = reader.GetDecimal("CMW_HrPr");
	this.CMW_Year = reader.GetInt32("CMW_Year");
	this.CMW_TypeNum = reader.GetString("CMW_TypeNum");
	this.CMW_DtWkStart = reader.GetDateTime("CMW_DtWkStart");
	this.CMW_SchPr = reader.GetDecimal("CMW_SchPr");
	this.CMW_MachCyc = reader.GetDecimal("CMW_MachCyc");
	this.CMW_Racks = reader.GetDecimal("CMW_Racks");
	this.CMW_HrClm = reader.GetDecimal("CMW_HrClm");
	this.CMW_HrPrClm = reader.GetDecimal("CMW_HrPrClm");
	this.CMW_CapType = reader.GetString("CMW_CapType");
	this.CMW_TmBlkOrd = reader.GetInt32("CMW_TmBlkOrd");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmacwk where " + 
			"CMW_SchVersion = '" + CMW_SchVersion + "' and " +
			"CMW_Plt = '" + CMW_Plt + "' and " +
			"CMW_Dept = '" + CMW_Dept + "' and " +
			"CMW_Mach = '" + CMW_Mach + "' and " +
			"CMW_TmType = '" + CMW_TmType + "' and " +
			"CMW_Wk = " + NumberUtil.toString(CMW_Wk) + " and " +
			"CMW_Year = " + NumberUtil.toString(CMW_Year);
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
		string sql = "delete from capmacwk where " +
			"CMW_SchVersion = '" + CMW_SchVersion + "' and " +
			"CMW_SchVersion = '" + CMW_SchVersion + "' and " +
			"CMW_Plt = '" + CMW_Plt + "' and " +
			"CMW_Dept = '" + CMW_Dept + "' and " +
			"CMW_Mach = '" + CMW_Mach + "' and " +
			"CMW_TmType = '" + CMW_TmType + "' and " +
			"CMW_Wk = " + NumberUtil.toString(CMW_Wk) + " and " +
			"CMW_Year = " + NumberUtil.toString(CMW_Year);
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
		string sql = "update capmacwk set " +
			"CMW_WkAcc = " + CMW_WkAcc + ", " +
			"CMW_Hr = " + NumberUtil.toString(CMW_Hr) + ", " +
			"CMW_HrPr = " + NumberUtil.toString(CMW_HrPr) + ", " +
			"CMW_typeNum = '" + Converter.fixString(CMW_TypeNum) + "', " +
			"CMW_DtWkStart = '" + DateUtil.getDateRepresentation(CMW_DtWkStart) + "', " +
			"CMW_SchPr = " + NumberUtil.toString(CMW_SchPr) + ", " +
			"CMW_MachCyc = " + NumberUtil.toString(CMW_MachCyc) + ", " +
			"CMW_Racks = " + NumberUtil.toString(CMW_Racks) + ", " +
			"CMW_HrClm = " + NumberUtil.toString(CMW_HrClm) + ", " +
			"CMW_HrPrClm = " + NumberUtil.toString(CMW_HrPrClm) + ", " +
			"CMW_CapType = '" + Converter.fixString(CMW_CapType) + "', " +
			"CMW_TmBlkOrd = " + CMW_TmBlkOrd + " " +
		"where " + 
			"CMW_SchVersion = '" + CMW_SchVersion + "' and " +
			"CMW_Plt = '" + CMW_Plt + "' and " +
			"CMW_Dept = '" + CMW_Dept + "' and " +
			"CMW_Mach = '" + CMW_Mach + "' and " +
			"CMW_TmType = '" + CMW_TmType + "' and " +
			"CMW_Wk = " + NumberUtil.toString(CMW_Wk) + " and " +
			"CMW_Year = " + NumberUtil.toString(CMW_Year);
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
		string sql = "insert into capmacwk values('" + 
			Converter.fixString(CMW_SchVersion) + "', '" + 
			Converter.fixString(CMW_Plt) + "', '" + 
			Converter.fixString(CMW_Dept) + "', '" + 
			Converter.fixString(CMW_Mach) + "', '" + 
			Converter.fixString(CMW_TmType) + "', " + 
			NumberUtil.toString(CMW_Wk) + ", " + 
			NumberUtil.toString(CMW_WkAcc) + ", " + 
			NumberUtil.toString(CMW_Hr) + ", " + 
			NumberUtil.toString(CMW_HrPr) + ", " + 
			NumberUtil.toString(CMW_Year) + ", '" + 
			Converter.fixString(CMW_TypeNum) + "', '" + 
			DateUtil.getDateRepresentation(CMW_DtWkStart) + "', " +
			NumberUtil.toString(CMW_SchPr) + ", " + 
			NumberUtil.toString(CMW_MachCyc) + ", " + 
			NumberUtil.toString(CMW_Racks) + ", " + 
			NumberUtil.toString(CMW_HrClm) + ", " + 
			NumberUtil.toString(CMW_HrPrClm) + ", '" + 
			Converter.fixString(CMW_CapType) + "', " + 
			NumberUtil.toString(CMW_TmBlkOrd) + ")";
								
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
		string sql = "select * from capmacwk where " + 
			"CMW_SchVersion = '" + CMW_SchVersion + "' and " +
			"CMW_Plt = '" + CMW_Plt + "' and " +
			"CMW_Dept = '" + CMW_Dept + "' and " +
			"CMW_Mach = '" + CMW_Mach + "' and " +
			"CMW_TmType = '" + CMW_TmType + "' and " +
			"CMW_Wk = " + NumberUtil.toString(CMW_Wk) + " and " +
			"CMW_Year = " + NumberUtil.toString(CMW_Year);

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
void setCMW_SchVersion(string CMW_SchVersion){
	this.CMW_SchVersion = CMW_SchVersion;
}

public
void setCMW_Plt(string CMW_Plt){
	this.CMW_Plt = CMW_Plt;
}

public
void setCMW_Dept(string CMW_Dept){
	this.CMW_Dept = CMW_Dept;
}

public
void setCMW_Mach(string CMW_Mach){
	this.CMW_Mach = CMW_Mach;
}

public
void setCMW_TmType(string CMW_TmType){
	this.CMW_TmType = CMW_TmType;
}

public
void setCMW_Wk(int CMW_Wk){
	this.CMW_Wk = CMW_Wk;
}

public
void setCMW_WkAcc(int CMW_WkAcc){
	this.CMW_WkAcc = CMW_WkAcc;
}

public
void setCMW_Hr(decimal CMW_Hr){
	this.CMW_Hr = CMW_Hr;
}

public
void setCMW_HrPr(decimal CMW_HrPr){
	this.CMW_HrPr = CMW_HrPr;
}

public
void setCMW_Year(int CMW_Year){
	this.CMW_Year = CMW_Year;
}

public
void setCMW_TypeNum(string CMW_TypeNum){
	this.CMW_TypeNum = CMW_TypeNum;
}

public
void setCMW_DtWkStart(DateTime CMW_DtWkStart){
	this.CMW_DtWkStart = CMW_DtWkStart;
}

public
void setCMW_SchPr(decimal CMW_SchPr){
	this.CMW_SchPr = CMW_SchPr;
}

public
void setCMW_MachCyc(decimal CMW_MachCyc){
	this.CMW_MachCyc = CMW_MachCyc;
}

public
void setCMW_Racks(decimal CMW_Racks){
	this.CMW_Racks = CMW_Racks;
}

public
void setCMW_HrClm(decimal CMW_HrClm){
	this.CMW_HrClm = CMW_HrClm;
}

public
void setCMW_HrPrClm(decimal CMW_HrPrClm){
	this.CMW_HrPrClm = CMW_HrPrClm;
}

public
void setCMW_CapType(string CMW_CapType){
	this.CMW_CapType = CMW_CapType;
}

public
void setCMW_TmBlkOrd(int CMW_TmBlkOrd){
	this.CMW_TmBlkOrd = CMW_TmBlkOrd;
}

//---------------------

public
string getCMW_SchVersion(){
	return CMW_SchVersion;
}

public
string getCMW_Plt(){
	return CMW_Plt;
}

public
string getCMW_Dept(){
	return CMW_Dept;
}

public
string getCMW_Mach(){
	return CMW_Mach;
}

public
string getCMW_TmType(){
	return CMW_TmType;
}

public
int getCMW_Wk(){
	return CMW_Wk;
}

public
int getCMW_WkAcc(){
	return CMW_WkAcc;
}

public
decimal getCMW_Hr(){
	return CMW_Hr;
}

public
decimal getCMW_HrPr(){
	return CMW_HrPr;
}

public
int getCMW_Year(){
	return CMW_Year;
}

public
string getCMW_TypeNum(){
	return CMW_TypeNum;
}

public
DateTime getCMW_DtWkStart(){
	return CMW_DtWkStart;
}

public
decimal getCMW_SchPr(){
	return CMW_SchPr;
}

public
decimal getCMW_MachCyc(){
	return CMW_MachCyc;
}

public
decimal getCMW_Racks(){
	return CMW_Racks;
}

public
decimal getCMW_HrClm(){
	return CMW_HrClm;
}

public
decimal getCMW_HrPrClm(){
	return CMW_HrPrClm;
}

public
string getCMW_CapType(){
	return CMW_CapType;
}

public
int getCMW_TmBlkOrd(){
	return CMW_TmBlkOrd;
}


}

}