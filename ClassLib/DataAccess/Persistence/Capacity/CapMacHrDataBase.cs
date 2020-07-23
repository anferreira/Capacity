using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CapMacHrDataBase : GenericDataBaseElement, IComparable{
	
private string CMH_SchVersion;
private string CMH_Plt;
private string CMH_Dept;
private string CMH_Mach;
private int CMH_Wk;
private DateTime CMH_Dt;
private string CMH_Shf;
private string CMH_TmType;
private int CMH_TmBlkOrd;
private string CMH_TmStart;
private string CMH_TmEnd;
private decimal CMH_Hr;
private decimal CMH_HrPr;
private DateTime CMH_DtShf;
private string CMH_TmTypePre;
private string CMH_ShfCode;
private decimal CMH_UtilPer;
private decimal CMH_HrClm;
private decimal CMH_HrPrClm;
private string CMH_CapType;

public
CapMacHrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.CMH_SchVersion = reader.GetString("CMH_SchVersion");
	this.CMH_Plt = reader.GetString("CMH_Plt");
	this.CMH_Dept = reader.GetString("CMH_Dept");
	this.CMH_Mach = reader.GetString("CMH_Mach");
	this.CMH_Wk = reader.GetInt16("CMH_Wk");
	this.CMH_Dt = reader.GetDateTime("CMH_Dt");
	this.CMH_Shf = reader.GetString("CMH_Shf");
	this.CMH_TmType = reader.GetString("CMH_TmType");
	this.CMH_TmBlkOrd = reader.GetInt32("CMH_TmBlkOrd");
	this.CMH_TmStart = reader.GetString("CMH_TmStart");
	this.CMH_TmEnd = reader.GetString("CMH_TmEnd");
	this.CMH_Hr = reader.GetDecimal("CMH_Hr");
	this.CMH_HrPr = reader.GetDecimal("CMH_HrPr");
	this.CMH_DtShf = reader.GetDateTime("CMH_DtShf");
	this.CMH_TmTypePre = reader.GetString("CMH_TmTypePre");
	this.CMH_ShfCode = reader.GetString("CMH_ShfCode");
	this.CMH_UtilPer = reader.GetDecimal("CMH_UtilPer");
	this.CMH_HrClm = reader.GetDecimal("CMH_HrClm");
	this.CMH_HrPrClm = reader.GetDecimal("CMH_HrPrClm");
	this.CMH_CapType = reader.GetString("CMH_CapType");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capmachr where " + 
			"CMH_SchVersion = ' " + CMH_SchVersion + "' and " +
			"CMH_Plt = '" + CMH_Plt + "' and " +
			"CMH_Dept = '" + CMH_Dept + "' and " +
			"CMH_Mach = '" + CMH_Mach + "' and " +
			"CMH_Wk = " + CMH_Wk + " and " +
			"CMH_Dt	= '" + DateUtil.getDateRepresentation(CMH_Dt) + "' and '" +
			"CMH_Shf = '" + CMH_Shf + "' and " +
			"CMH_TmType = '" + CMH_TmType + "'";

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
		string sql = "delete from capmachr where " +
			"CMH_SchVersion = '" + CMH_SchVersion + "' and " +
			"CMH_Plt = '" + CMH_Plt + "' and " +
			"CMH_Dept = '" + CMH_Dept + "' and " +
			"CMH_Mach = '" + CMH_Mach + "' and " +
			"CMH_Wk = " + CMH_Wk + " and " +
			"CMH_Dt	= '" + DateUtil.getDateRepresentation(CMH_Dt) + "' and " +
			"CMH_Shf = '" + CMH_Shf + "' and " +
			"CMH_TmType = '" + CMH_TmType + "'";

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
		string sql = "update capmachr set " +
			"CMH_TmType = '" + Converter.fixString(CMH_TmType) + "', " +			
			"CMH_TmBlkOrd = " + CMH_TmBlkOrd + ", " +
			"CMH_TmStart = '" + Converter.fixString(CMH_TmStart) + "', " +
			"CMH_TmEnd = '" + Converter.fixString(CMH_TmEnd) + "', " +
			"CMH_Hr = " + NumberUtil.toString(CMH_Hr) + ", " +
			"CMH_HrPr = " + NumberUtil.toString(CMH_HrPr) + ", " +
			"CMH_DtShf = '" + DateUtil.getDateRepresentation(CMH_DtShf) + "', " +
			"CMH_TmTypePre = '" + Converter.fixString(CMH_TmTypePre) + "', " +
			"CMH_ShfCode = '" + Converter.fixString(CMH_ShfCode) + "', " +
			"CMH_UtilPer = " + NumberUtil.toString(CMH_UtilPer) + ", " +
			"CMH_HrClm = " + NumberUtil.toString(CMH_HrClm) + ", " +
			"CMH_HrPrClm = " + NumberUtil.toString(CMH_HrPrClm) + ", " +
			"CMH_CapType = '" + Converter.fixString(CMH_CapType) + "' " +
		"where " + 
			"CMH_SchVersion = ' " + CMH_SchVersion + "' and " +
			"CMH_Plt = '" + CMH_Plt + "' and " +
			"CMH_Dept = '" + CMH_Dept + "' and " +
			"CMH_Mach = '" + CMH_Mach + "' and " +
			"CMH_Wk = " + CMH_Wk + " and " +
			"CMH_Dt	= '" + DateUtil.getDateRepresentation(CMH_Dt) + "' and '" +
			"CMH_Shf = '" + CMH_Shf + "' and " +
			"CMH_TmType = '" + CMH_TmType + "'";
		
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
		string sql = "insert into capmachr values('" + 
			Converter.fixString(CMH_SchVersion) + "', '" +
			Converter.fixString(CMH_Plt) + "', '" +
			Converter.fixString(CMH_Dept) + "', '" +
			Converter.fixString(CMH_Mach) + "', " +
			CMH_Wk + ", '" +
			DateUtil.getDateRepresentation(CMH_Dt) + "', '" +
			Converter.fixString(CMH_Shf) + "', '" +
			Converter.fixString(CMH_TmType) + "', " +
			CMH_TmBlkOrd + ", '" +
			Converter.fixString(CMH_TmStart) + "', '" +
			Converter.fixString(CMH_TmEnd) + "', " +
			NumberUtil.toString(CMH_Hr) + ", " +
			NumberUtil.toString(CMH_HrPr) + ", '" +
			DateUtil.getDateRepresentation(CMH_DtShf) + "', '" +
			Converter.fixString(CMH_TmTypePre) + "', '" +
			Converter.fixString(CMH_ShfCode) + "', " +
			NumberUtil.toString(CMH_UtilPer) + ", " +
			NumberUtil.toString(CMH_HrClm) + ", " +
			NumberUtil.toString(CMH_HrPrClm) + ", '" +
			Converter.fixString(CMH_CapType) + "')";

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
void setCMH_SchVersion(string CMH_SchVersion){
	this.CMH_SchVersion = CMH_SchVersion;
}

public 
void setCMH_Plt(string CMH_Plt){
	this.CMH_Plt = CMH_Plt;
}

public 
void setCMH_Dept(string CMH_Dept){
	this.CMH_Dept = CMH_Dept;
}

public 
void setCMH_Mach(string CMH_Mach){
	this.CMH_Mach = CMH_Mach;
}

public 
void setCMH_Wk(int CMH_Wk){
	this.CMH_Wk = CMH_Wk;
}

public 
void setCMH_Dt(DateTime CMH_Dt){
	this.CMH_Dt = CMH_Dt;
}

public 
void setCMH_Shf(string CMH_Shf){
	this.CMH_Shf = CMH_Shf;
}

public 
void setCMH_TmType(string CMH_TmType){
	this.CMH_TmType = CMH_TmType;
}

public 
void setCMH_TmBlkOrd(int CMH_TmBlkOrd){
	this.CMH_TmBlkOrd = CMH_TmBlkOrd;
}

public 
void setCMH_TmStart(string CMH_TmStart){
	this.CMH_TmStart = CMH_TmStart;
}

public 
void setCMH_TmEnd(string CMH_TmEnd){
	this.CMH_TmEnd = CMH_TmEnd;
}

public 
void setCMH_Hr(decimal CMH_Hr){
	this.CMH_Hr = CMH_Hr;
}

public 
void setCMH_HrPr(decimal CMH_HrPr){
	this.CMH_HrPr = CMH_HrPr;
}

public 
void setCMH_DtShf(DateTime CMH_DtShf){
	this.CMH_DtShf = CMH_DtShf;
}

public 
void setCMH_TmTypePre(string CMH_TmTypePre){
	this.CMH_TmTypePre = CMH_TmTypePre;
}

public 
void setCMH_ShfCode(string CMH_ShfCode){
	this.CMH_ShfCode = CMH_ShfCode;
}

public 
void setCMH_UtilPer(decimal CMH_UtilPer){
	this.CMH_UtilPer = CMH_UtilPer;
}

public 
void setCMH_HrClm(decimal CMH_HrClm){
	this.CMH_HrClm = CMH_HrClm;
}

public 
void setCMH_HrPrClm(decimal CMH_HrPrClm){
	this.CMH_HrPrClm = CMH_HrPrClm;
}

public 
void setCMH_CapType(string CMH_CapType){
	this.CMH_CapType = CMH_CapType;
}


public
string getCMH_SchVersion(){
	return CMH_SchVersion;
}

public
string getCMH_Plt(){
	return CMH_Plt;
}

public
string getCMH_Dept(){
	return CMH_Dept;
}

public
string getCMH_Mach(){
	return CMH_Mach;
}

public
int getCMH_Wk(){
	return CMH_Wk;
}

public
DateTime getCMH_Dt(){
	return CMH_Dt;
}

public
string getCMH_Shf(){
	return CMH_Shf;
}

public
string getCMH_TmType(){
	return CMH_TmType;
}

public
int getCMH_TmBlkOrd(){
	return CMH_TmBlkOrd;
}

public
string getCMH_TmStart(){
	return CMH_TmStart;
}

public
string getCMH_TmEnd(){
	return CMH_TmEnd;
}

public
decimal getCMH_Hr(){
	return CMH_Hr;
}

public
decimal getCMH_HrPr(){
	return CMH_HrPr;
}

public
DateTime getCMH_DtShf(){
	return CMH_DtShf;
}

public
string getCMH_TmTypePre(){
	return CMH_TmTypePre;
}

public
string getCMH_ShfCode(){
	return CMH_ShfCode;
}

public
decimal getCMH_UtilPer(){
	return CMH_UtilPer;
}

public
decimal getCMH_HrClm(){
	return CMH_HrClm;
}

public
decimal getCMH_HrPrClm(){
	return CMH_HrPrClm;
}

public
string getCMH_CapType(){
	return CMH_CapType;
}

public Int32 CompareTo (Object obj){
	try{
		Int32 dateComp = this.CMH_Dt.CompareTo(((CapMacHrDataBase)obj).getCMH_Dt());
		if (dateComp == 0){
			return this.CMH_TmStart.CompareTo(((CapMacHrDataBase)obj).getCMH_TmStart());
		}
		else{
			return dateComp;
		}
	}catch{
		return 0;
	}
}

}

}