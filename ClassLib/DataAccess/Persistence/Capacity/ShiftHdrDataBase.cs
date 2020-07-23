using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ShiftHdrDataBase : GenericDataBaseElement{

private string SH_Db;
private int SH_Company;
private string SH_Plt;
private string SH_Dept;
private string SH_Shf;
private string SH_Des;
private string SH_ShfType;
private string SH_ShfStatus;
private string SH_RegTime;
private DateTime SH_StrPeriod;
private DateTime SH_EndPeriod;
private int SH_EmpNumTl;
private int SH_MachNum;
private decimal SH_MachDirCost;
private decimal SH_LabDirCost;
private decimal SH_LabIndCost;
private decimal SH_LabTempCost;
private int SH_EmpNumD;
private int SH_EmpNumI;
private int SH_EmpNumT;


public
ShiftHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SH_Db = reader.GetString("SH_Db");
	this.SH_Company = reader.GetInt32("SH_Company");
	this.SH_Plt = reader.GetString("SH_Plt");
	this.SH_Dept = reader.GetString("SH_Dept");
	this.SH_Shf = reader.GetString("SH_Shf");
	this.SH_Des = reader.GetString("SH_Des");
	this.SH_ShfType = reader.GetString("SH_ShfType");
	this.SH_ShfStatus = reader.GetString("SH_ShfStatus");
	this.SH_RegTime = reader.GetString("SH_RegTime");
	this.SH_StrPeriod =	 reader.GetDateTime("SH_StrPeriod");
	this.SH_EndPeriod =	 reader.GetDateTime("SH_EndPeriod");
	this.SH_EmpNumTl = reader.GetInt32("SH_EmpNumTl");
	this.SH_MachNum = reader.GetInt32("SH_MachNum");
	this.SH_MachDirCost = reader.GetDecimal("SH_MachDirCost");
	this.SH_LabDirCost = reader.GetDecimal("SH_LabDirCost");
	this.SH_LabIndCost = reader.GetDecimal("SH_LabIndCost");
	this.SH_LabTempCost = reader.GetDecimal("SH_LabTempCost");
	this.SH_EmpNumD = reader.GetInt32("SH_EmpNumD");
	this.SH_EmpNumI = reader.GetInt32("SH_EmpNumI");
	this.SH_EmpNumT = reader.GetInt32("SH_EmpNumT");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shifthdr where" + 
			" SH_Db = '" + SH_Db + "' and" +
			" SH_Company = " + NumberUtil.toString(SH_Company) + " and" +
			" SH_Shf = '" + SH_Shf + "' and" +
			" SH_Plt = '" + SH_Plt + "' and" +
			" SH_Dept = '" + SH_Dept + "'";

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
		string sql = "delete from shifthdr where " + 
			" SH_Db = '" + SH_Db + "' and" +
			" SH_Company = " + NumberUtil.toString(SH_Company) + " and" +
			" SH_Shf = '" + SH_Shf + "' and" +
			" SH_Plt = '" + SH_Plt + "' and" +
			" SH_Dept = '" + SH_Dept + "'";

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
		string sql = "update shifthdr set " + 

			"SH_Des = '"		+ Converter.fixString(SH_Des) + "', " +
			"SH_ShfType = '"	+ Converter.fixString(SH_ShfType) + "', " +
			"SH_ShfStatus = '"	+ Converter.fixString(SH_ShfStatus) + "', " +
			"SH_RegTime = '"	+ Converter.fixString(SH_RegTime) + "', " +
			"SH_StrPeriod =	'"	+ DateUtil.getCompleteDateRepresentation(SH_StrPeriod) + "', " +
			"SH_EndPeriod =	'"	+ DateUtil.getCompleteDateRepresentation(SH_EndPeriod) + "', " +
			"SH_EmpNumTl = "	+ NumberUtil.toString(SH_EmpNumTl) + ", " +
			"SH_MachNum = "		+ NumberUtil.toString(SH_MachNum) + ", " +
			"SH_MachDirCost = "	+ NumberUtil.toString(SH_MachDirCost) + ", " +
			"SH_LabDirCost = "	+ NumberUtil.toString(SH_LabDirCost) + ", " +
			"SH_LabIndCost = "	+ NumberUtil.toString(SH_LabIndCost) + ", " +
			"SH_LabTempCost = "	+ NumberUtil.toString(SH_LabTempCost) + ", " +
			"SH_EmpNumD = "		+ NumberUtil.toString(SH_EmpNumD) + ", " +
			"SH_EmpNumI = "		+ NumberUtil.toString(SH_EmpNumI) + ", " +
			"SH_EmpNumT = "		+ NumberUtil.toString(SH_EmpNumT) + 


			" where" + 
			" SH_Db = '" + SH_Db + "' and" +
			" SH_Company = " + NumberUtil.toString(SH_Company) + " and" +
			" SH_Shf = '" + SH_Shf + "' and" +
			" SH_Plt = '" + SH_Plt + "' and" +
			" SH_Dept = '" + SH_Dept + "'";

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
	string sql = "insert into shifthdr (" +
		"SH_Db, " +
		"SH_Company, " +
		"SH_Plt, " +
		"SH_Dept, " +
		"SH_Shf, " +
		"SH_Des, " +
		"SH_ShfType, " +
		"SH_ShfStatus, " +
		"SH_RegTime, " +
		"SH_StrPeriod, " +
		"SH_EndPeriod, " +
		"SH_EmpNumTl, " +
		"SH_MachNum, " +
		"SH_MachDirCost, " +
		"SH_LabDirCost, " +
		"SH_LabIndCost, " +
		"SH_LabTempCost, " +
		"SH_EmpNumD, " +
		"SH_EmpNumI, " +
		"SH_EmpNumT" +

		") values (" +

		"'" + Converter.fixString(SH_Db) + "'," +
		""	+ NumberUtil.toString(SH_Company) + "," +
		"'" + Converter.fixString(SH_Plt) + "'," +
		"'" + Converter.fixString(SH_Dept) + "'," +
		"'" + Converter.fixString(SH_Shf) + "'," +
		"'"	+ Converter.fixString(SH_Des) + "'," +
		"'"	+ Converter.fixString(SH_ShfType) + "'," +
		"'"	+ Converter.fixString(SH_ShfStatus) + "'," +
		"'"	+ Converter.fixString(SH_RegTime) + "'," +
		"'"	+ DateUtil.getCompleteDateRepresentation(SH_StrPeriod) + "'," +
		"'"	+ DateUtil.getCompleteDateRepresentation(SH_EndPeriod) + "'," +
		""	+ NumberUtil.toString(SH_EmpNumTl) + "," +
		""	+ NumberUtil.toString(SH_MachNum) + "," +
		""	+ NumberUtil.toString(SH_MachDirCost) + "," +
		""	+ NumberUtil.toString(SH_LabDirCost) + "," +
		""	+ NumberUtil.toString(SH_LabIndCost) + "," +
		""	+ NumberUtil.toString(SH_LabTempCost) + "," +
		""	+ NumberUtil.toString(SH_EmpNumD) + "," +
		""	+ NumberUtil.toString(SH_EmpNumI) + "," +
		""	+ NumberUtil.toString(SH_EmpNumT) + ")";

	base.write (sql);
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shifthdr where " + 
			" SH_Db = '" + SH_Db + "' and" +
			" SH_Company = " + NumberUtil.toString(SH_Company) + " and" +
			" SH_Shf = '" + SH_Shf + "' and" +
			" SH_Plt = '" + SH_Plt + "' and" +
			" SH_Dept = '" + SH_Dept + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			return true;
		else
			return false;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setSH_Db(string SH_Db){
	this.SH_Db = SH_Db;
}

public
void setSH_Company(int SH_Company){
	this.SH_Company = SH_Company;
}

public
void setSH_Shf(string SH_Shf){
	this.SH_Shf = SH_Shf;
}

public
void setSH_Plt(string SH_Plt){
	this.SH_Plt = SH_Plt;
}

public
void setSH_Dept(string SH_Dept){
	this.SH_Dept = SH_Dept;
}

public
void setSH_Des(string SH_Des){
	this.SH_Des = SH_Des;
}

public
void setSH_ShfType(string SH_ShfType){
	this.SH_ShfType = SH_ShfType;
}

public
void setSH_ShfStatus(string SH_ShfStatus){
	this.SH_ShfStatus = SH_ShfStatus;
}

public
void setSH_RegTime(string SH_RegTime){
	this.SH_RegTime = SH_RegTime;
}

public
void setSH_StrPeriod(DateTime SH_StrPeriod){
	this.SH_StrPeriod = SH_StrPeriod;
}

public
void setSH_EndPeriod(DateTime SH_EndPeriod){
	this.SH_EndPeriod = SH_EndPeriod;
}

public
void setSH_EmpNumTl(int SH_EmpNumTl){
	this.SH_EmpNumTl = SH_EmpNumTl;
}

public
void setSH_MachNum(int SH_MachNum){
	this.SH_MachNum = SH_MachNum;
}

public
void setSH_MachDirCost(decimal SH_MachDirCost){
	this.SH_MachDirCost = SH_MachDirCost;
}

public
void setSH_LabDirCost(decimal SH_LabDirCost){
	this.SH_LabDirCost = SH_LabDirCost;
}

public
void setSH_LabIndCost(decimal SH_LabIndCost){
	this.SH_LabIndCost = SH_LabIndCost;
}

public
void setSH_LabTempCost(decimal SH_LabTempCost){
	this.SH_LabTempCost = SH_LabTempCost;
}

public
void setSH_EmpNumD(int SH_EmpNumD){
	this.SH_EmpNumD = SH_EmpNumD;
}

public
void setSH_EmpNumI(int SH_EmpNumI){
	this.SH_EmpNumI = SH_EmpNumI;
}

public
void setSH_EmpNumT(int SH_EmpNumT){
	this.SH_EmpNumT = SH_EmpNumT;
}

public
string getSH_Db(){
	return SH_Db;
}

public
int getSH_Company(){
	return SH_Company;
}

public
string getSH_Shf(){
	return SH_Shf;
}

public
string getSH_Des(){
	return SH_Des;
}

public
string getSH_Plt(){
	return SH_Plt;
}

public
string getSH_Dept(){
	return SH_Dept;
}

public
string getSH_ShfType(){
	return SH_ShfType;
}

public
string getSH_ShfStatus(){
	return SH_ShfStatus;
}

public
string getSH_RegTime(){
	return SH_RegTime;
}

public
DateTime getSH_StrPeriod(){
	return SH_StrPeriod;
}

public	
DateTime getSH_EndPeriod(){
	return SH_EndPeriod;
}

public
int getSH_EmpNumTl(){
	return SH_EmpNumTl;
}

public
int getSH_MachNum(){
	return SH_MachNum;
}

public
decimal getSH_MachDirCost(){
	return SH_MachDirCost;
}

public
decimal getSH_LabDirCost(){
	return SH_LabDirCost;
}

public
decimal getSH_LabIndCost(){
	return SH_LabIndCost;
}

public
decimal getSH_LabTempCost(){
	return SH_LabTempCost;
}

public
int getSH_EmpNumD(){
	return SH_EmpNumD;
}

public
int getSH_EmpNumI(){
	return SH_EmpNumI;
}

public
int getSH_EmpNumT(){
	return SH_EmpNumT;
}

} // class

} // namespace