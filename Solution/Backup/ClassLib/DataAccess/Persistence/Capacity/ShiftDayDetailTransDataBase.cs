using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class ShiftDayDetailTransDataBase  : GenericDataBaseElement{

private string SDDT_Db;
private int SDDT_Company;
private string SDDT_Plt;
private string SDDT_Dept;
private string SDDT_Shf;
private DateTime SDDT_ShfAcTrnDte;
private string SDDT_TmType;
private string SDDT_TmStr;
private string SDDT_TmEnd;
private decimal SDDT_Hours;
private DateTime SDDT_ShfStrTrnDte;

public ShiftDayDetailTransDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void load(NotNullDataReader reader){
	this.SDDT_Db = reader.GetString("SDDT_Db");
	this.SDDT_Company = reader.GetInt32("SDDT_Company");
	this.SDDT_Plt = reader.GetString("SDDT_Plt");
	this.SDDT_Dept = reader.GetString("SDDT_Dept");
	this.SDDT_Shf = reader.GetString("SDDT_Shf");
	this.SDDT_ShfAcTrnDte = reader.GetDateTime("SDDT_ShfAcTrnDte");
	this.SDDT_TmType = reader.GetString("SDDT_TmType");
	this.SDDT_TmStr = reader.GetString("SDDT_TmStr");
	this.SDDT_TmEnd = reader.GetString("SDDT_TmEnd");
	this.SDDT_Hours = reader.GetDecimal("SDDT_Hours");
	this.SDDT_ShfStrTrnDte = reader.GetDateTime("SDDT_ShfStrTrnDte");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shiftdaydetailtrans where " + 
					"SDDT_Db = '" + SDDT_Db + "' and " +
					"SDDT_Company = " + NumberUtil.toString(SDDT_Company) + " and " +
					"SDDT_Plt = '" + SDDT_Plt + "' and " +
					"SDDT_Dept = '" + SDDT_Dept + "' and " +
					"SDDT_Shf = '" + SDDT_Shf + "' and " +
					"SDDT_ShfAcTrnDte = '" + DateUtil.getCompleteDateRepresentation(SDDT_ShfAcTrnDte) + "' and " +
					"SDDT_TmType = '" + SDDT_TmType + "' and " +
					"SDDT_TmStr = '" + SDDT_TmStr + "' and " +
					"SDDT_TmEnd = '" + SDDT_TmEnd + "'";

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
	string sql = "insert into shiftdaydetailtrans (" +
				"SDDT_Db, " +
				"SDDT_Company, " +
				"SDDT_Plt, " +
				"SDDT_Dept, " +
				"SDDT_Shf, " +
				"SDDT_ShfAcTrnDte, " +
				"SDDT_TmType, " +
				"SDDT_TmStr, " +
				"SDDT_TmEnd, " +
				"SDDT_Hours, " +
				"SDDT_ShfStrTrnDte" +

				") values ('" +
				
				Converter.fixString(SDDT_Db) + "'," +
				NumberUtil.toString(SDDT_Company) + ",'" +
				Converter.fixString(SDDT_Plt) + "','" +
				Converter.fixString(SDDT_Dept) + "','" +
				Converter.fixString(SDDT_Shf) + "','" +
				DateUtil.getCompleteDateRepresentation(SDDT_ShfAcTrnDte) + "','" +
				Converter.fixString(SDDT_TmType) + "','" +
				Converter.fixString(SDDT_TmStr) + "','" +
				Converter.fixString(SDDT_TmEnd) + "'," +
				NumberUtil.toString(SDDT_Hours) + ",'" +
				DateUtil.getCompleteDateRepresentation(SDDT_ShfStrTrnDte) + "')";

	base.write (sql);
}

public override
void delete(){
	string sql = "delete from shiftdaydetailtrans where " +
		"SDDT_Db = '" + SDDT_Db + "' and " +
		"SDDT_Company = " + NumberUtil.toString(SDDT_Company) + " and " +
		"SDDT_Plt = '" + SDDT_Plt + "' and " +
		"SDDT_Dept = '" + SDDT_Dept + "' and " +
		"SDDT_Shf = '" + SDDT_Shf + "' and " +
		"SDDT_ShfAcTrnDte = '" + DateUtil.getCompleteDateRepresentation(SDDT_ShfAcTrnDte) + "' and " +
		"SDDT_TmType = '" + SDDT_TmType + "' and " +
		"SDDT_TmStr = '" + SDDT_TmStr + "' and " +
		"SDDT_TmEnd = '" + SDDT_TmEnd + "'";

	base.delete (sql);
}

public override
void update(){
		throw new PersistenceException("Method without implement.");
}

//getters

public
string getSDDT_Db(){
   return SDDT_Db;
}

public
int getSDDT_Company(){
   return SDDT_Company;
}

public
string getSDDT_Plt(){
   return SDDT_Plt;
}

public
string getSDDT_Dept(){
   return SDDT_Dept;
}

public
string getSDDT_Shf(){
   return SDDT_Shf;
}

public
DateTime getSDDT_ShfAcTrnDte(){
   return SDDT_ShfAcTrnDte;
}

public
string getSDDT_TmType(){
   return SDDT_TmType;
}

public
string getSDDT_TmStr(){
   return SDDT_TmStr;
}

public
string getSDDT_TmEnd(){
   return SDDT_TmEnd;
}

public
decimal getSDDT_Hours(){
   return SDDT_Hours;
}

public
DateTime getSDDT_ShfStrTrnDte(){
   return SDDT_ShfStrTrnDte;
}


//setters
public void setSDDT_Db(string SDDT_Db){
   this.SDDT_Db = SDDT_Db;
}

public void setSDDT_Company(int SDDT_Company){
   this.SDDT_Company = SDDT_Company;
}

public void setSDDT_Plt(string SDDT_Plt){
   this.SDDT_Plt = SDDT_Plt;
}

public void setSDDT_Dept(string SDDT_Dept){
   this.SDDT_Dept = SDDT_Dept;
}

public void setSDDT_Shf(string SDDT_Shf){
   this.SDDT_Shf = SDDT_Shf;
}

public void setSDDT_ShfAcTrnDte(DateTime SDDT_ShfAcTrnDte){
   this.SDDT_ShfAcTrnDte = SDDT_ShfAcTrnDte;
}

public void setSDDT_TmType(string SDDT_TmType){
   this.SDDT_TmType = SDDT_TmType;
}

public void setSDDT_TmStr(string SDDT_TmStr){
   this.SDDT_TmStr = SDDT_TmStr;
}

public void setSDDT_TmEnd(string SDDT_TmEnd){
   this.SDDT_TmEnd = SDDT_TmEnd;
}

public void setSDDT_Hours(decimal SDDT_Hours){
   this.SDDT_Hours = SDDT_Hours;
}

public void setSDDT_ShfStrTrnDte(DateTime SDDT_ShfStrTrnDte){
   this.SDDT_ShfStrTrnDte = SDDT_ShfStrTrnDte;
}

}//end class
}//end namespace
