using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMachShfDataBase : GenericDataBaseElement{
	
private string SMS_SchVersion;
private string SMS_Plt;
private string SMS_Dept;
private string SMS_Mach;
private string SMS_Shf;
private DateTime SMS_DtShf;
private DateTime SMS_Dt;
private string SMS_ShfGrp;
private string SMS_ProdID;
private string SMS_ActID;
private int SMS_Seq;
private decimal SMS_Qty;
private decimal SMS_Cycles;
private decimal SMS_Hr;
private decimal SMS_HrPr;
private decimal SMS_UtilPer;
private string SMS_TmType;
private decimal SMS_CountSt;
private decimal SMS_CountEnd;
private string SMS_MasPrOrd;
private string SMS_PrOrd;

public
SchMachShfDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SMS_SchVersion = reader.GetString("SMS_SchVersion");
	this.SMS_Plt = reader.GetString("SMS_Plt");
	this.SMS_Dept = reader.GetString("SMS_Dept");
	this.SMS_Mach = reader.GetString("SMS_Mach");
	this.SMS_Shf = reader.GetString("SMS_Shf");
	this.SMS_DtShf = reader.GetDateTime("SMS_DtShf");
	this.SMS_Dt = reader.GetDateTime("SMS_Dt");
	this.SMS_ShfGrp = reader.GetString("SMS_ShfGrp");
	this.SMS_ProdID = reader.GetString("SMS_ProdID");
	this.SMS_ActID = reader.GetString("SMS_ActID");
	this.SMS_Seq = reader.GetInt32("SMS_Seq");
	this.SMS_Qty = reader.GetDecimal("SMS_Qty");
	this.SMS_Cycles = reader.GetDecimal("SMS_Cycles");
	this.SMS_Hr = reader.GetDecimal("SMS_Hr");
	this.SMS_HrPr = reader.GetDecimal("SMS_HrPr");
	this.SMS_UtilPer = reader.GetDecimal("SMS_UtilPer");
	this.SMS_TmType = reader.GetString("SMS_TmType");
	this.SMS_CountSt = reader.GetDecimal("SMS_CountSt");
	this.SMS_CountEnd = reader.GetDecimal("SMS_CountEnd");
	this.SMS_MasPrOrd = reader.GetString("SMS_MasPrOrd");
	this.SMS_PrOrd = reader.GetString("SMS_PrOrd");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmachshf where " + 
			"SMS_SchVersion = '" + SMS_SchVersion + "' and " +
			"SMS_Plt = '" + SMS_Plt + "' and " +
			"SMS_Dept = '" + SMS_Dept + "' and " +
			"SMS_Mach = '" + SMS_Mach + "' and " +
			"SMS_Shf = '" + SMS_Shf + "' and " +
			"SMS_DtShf = '" + DateUtil.getDateRepresentation(SMS_DtShf)+ "' and " +
			"SMS_Dt  = ' " + DateUtil.getDateRepresentation(SMS_Dt) +  "' and " +
			"SMS_ShfGrp = '" + SMS_ShfGrp + "'";
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
		string sql = "insert into schmachshf values('" + 
				Converter.fixString(SMS_SchVersion) + "' ,'" +
				Converter.fixString(SMS_Plt) + "' ,'" +
				Converter.fixString(SMS_Dept) + "' ,'" +
				Converter.fixString(SMS_Mach) + "' ,'" +
				Converter.fixString(SMS_Shf) + "' ,'" +
				DateUtil.getDateRepresentation(SMS_DtShf) +"' ,'" +
				DateUtil.getDateRepresentation(SMS_Dt) +"' ,'" +
				Converter.fixString(SMS_ShfGrp) +"' ,'" +
				Converter.fixString(SMS_ProdID) +"' ,'" +
				Converter.fixString(SMS_ActID) +"' ," +
				NumberUtil.toString(SMS_Seq) + " ," +
				NumberUtil.toString(SMS_Qty) + " ," +
				NumberUtil.toString(SMS_Cycles) + " ," +
				NumberUtil.toString(SMS_Hr) + " ," +
				NumberUtil.toString(SMS_HrPr) + " ," +
				NumberUtil.toString(SMS_UtilPer) + " ,'" +
				Converter.fixString(SMS_TmType) +"' ," +
				NumberUtil.toString(SMS_CountSt) + " ," + 
				NumberUtil.toString(SMS_CountEnd) + " ," +
				Converter.fixString(SMS_MasPrOrd) +"' ,'" +
				Converter.fixString(SMS_PrOrd) + "')";
			
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
void update(){
	try{
		string sql = "update schmachshf set " +
				"SMS_ProdID = '" + Converter.fixString(SMS_ProdID) + "', " + 
				"SMS_ActID = '" + Converter.fixString(SMS_ActID) + "', " +
				"SMS_Seq = " + SMS_Seq + ", " +
				"SMS_Qty = " + NumberUtil.toString(SMS_Qty) + ", " +
				"SMS_Cycles = " + NumberUtil.toString(SMS_Cycles) + ", " +
				"SMS_Hr = " + NumberUtil.toString(SMS_Hr) + ", " +
				"SMS_HrPr = "+ NumberUtil.toString(SMS_HrPr) + ", " +
				"SMS_UtilPer = " + NumberUtil.toString(SMS_UtilPer) + ", " +
				"SMS_TmType = " + Converter.fixString(SMS_TmType) + ", " +
				"SMS_CountSt = " + NumberUtil.toString(SMS_CountSt) + ", " +
				"SMS_CountEnd = " + NumberUtil.toString(SMS_CountEnd) + ", " +
				"SMS_MasPrOrd = '" + Converter.fixString(SMS_MasPrOrd) + "', " +
				"SMS_PrOrd = '" + Converter.fixString(SMS_PrOrd) + "', " +
		" where " + 
			"SMS_SchVersion = '" + SMS_SchVersion + "' and " +
			"SMS_Plt = '" + SMS_Plt + "' and " +
			"SMS_Dept = '" + SMS_Dept + "' and " +
			"SMS_Mach = '" + SMS_Mach + "' and " +
			"SMS_Shf = '" + SMS_Shf + "' and " +
			"SMS_DtShf = '" + DateUtil.getDateRepresentation(SMS_DtShf)+ "' and " +
			"SMS_Dt  = ' " + DateUtil.getDateRepresentation(SMS_Dt) +  "' and " +
			"SMS_ShfGrp = '" + SMS_ShfGrp + "'";
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
void delete(){
	try{
		string sql = "delete from schmachshf where " +
			"SMS_SchVersion = '" + SMS_SchVersion + "' and " +
			"SMS_Plt = '" + SMS_Plt + "' and " +
			"SMS_Dept = '" + SMS_Dept + "' and " +
			"SMS_Mach = '" + SMS_Mach + "' and " +
			"SMS_Shf = '" + SMS_Shf + "' and " +
			"SMS_DtShf = '" + DateUtil.getDateRepresentation(SMS_DtShf)+ "' and " +
			"SMS_Dt  = ' " + DateUtil.getDateRepresentation(SMS_Dt) +  "' and " +
			"SMS_ShfGrp = '" + SMS_ShfGrp + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void setSMS_SchVersion(string SMS_SchVersion){
	this.SMS_SchVersion = SMS_SchVersion;
}

public
void setSMS_Plt(string SMS_Plt){
	this.SMS_Plt = SMS_Plt;
}

public
void setSMS_Dept(string SMS_Dept){
	this.SMS_Dept = SMS_Dept;
}

public
void setSMS_Mach(string SMS_Mach){
	this.SMS_Mach = SMS_Mach;
}

public
void setSMS_Shf(string SMS_Shf){
	this.SMS_Shf = SMS_Shf;
}

public
void setSMS_DtShf(DateTime SMS_DtShf){
	this.SMS_DtShf = SMS_DtShf;
}

public
void setSMS_Dt(DateTime SMS_Dt){
	this.SMS_Dt = SMS_Dt;
}

public
void setSMS_ShfGrp(string SMS_ShfGrp){
	this.SMS_ShfGrp = SMS_ShfGrp;
}


public
void setSMS_ProdID(string SMS_ProdID){
	this.SMS_ProdID = SMS_ProdID;
}

public
void setSMS_ActID(string SMS_ActID){
	this.SMS_ActID = SMS_ActID;
}

public
void setSMS_Seq(int SMS_Seq){
	this.SMS_Seq = SMS_Seq;
}

public
void setSMS_Qty(decimal SMS_Qty){
	this.SMS_Qty = SMS_Qty;
}

public
void setSMS_Cycles(decimal SMS_Cycles){
	this.SMS_Cycles = SMS_Cycles;
}

public
void setSMS_Hr(decimal SMS_Hr){
	this.SMS_Hr = SMS_Hr;
}

public
void setSMS_HrPr(decimal SMS_HrPr){
	this.SMS_HrPr = SMS_HrPr;
}

public
void setSMS_UtilPer(decimal SMS_UtilPer){
	this.SMS_UtilPer = SMS_UtilPer;
}

public
void setSMS_TmType(string SMS_TmType){
	this.SMS_TmType = SMS_TmType;
}

public
void setSMS_CountSt(decimal SMS_CountSt){
	this.SMS_CountSt = SMS_CountSt;
}

public
void setSMS_CountEnd(decimal SMS_CountEnd){
	this.SMS_CountEnd = SMS_CountEnd;
}

public
void setSMS_MasPrOrd(string SMS_MasPrOrd){
	this.SMS_MasPrOrd = SMS_MasPrOrd;
}

public
void setSMS_PrOrd(string SMS_PrOrd){
	this.SMS_PrOrd = SMS_PrOrd;
}


public
string getSMS_SchVersion(){
	return SMS_SchVersion;
}

public
string getSMS_Plt(){
	return SMS_Plt;
}

public
string getSMS_Dept(){
	return SMS_Dept;
}

public
string getSMS_Mach(){
	return SMS_Mach;
}

public
string getSMS_Shf(){
	return SMS_Shf;
}

public
DateTime getSMS_DtShf(){
	return SMS_DtShf;
}

public
DateTime getSMS_Dt(){
	return SMS_Dt;
}

public
string getSMS_ShfGrp(){
	return SMS_ShfGrp;
}

public
string getSMS_ProdID(){
	return SMS_ProdID;
}

public
string getSMS_ActID(){
	return SMS_ActID;
}

public
int getSMS_Seq(){
	return SMS_Seq;
}

public
decimal getSMS_Qty(){
	return SMS_Qty;
}

public
decimal getSMS_Cycles(){
	return SMS_Cycles;
}

public
decimal getSMS_Hr(){
	return SMS_Hr;
}

public
decimal getSMS_HrPr(){
	return SMS_HrPr;
}

public
decimal getSMS_UtilPer(){
	return SMS_UtilPer;
}

public
string getSMS_TmType(){
	return SMS_TmType;
}

public
decimal getSMS_CountSt(){
	return SMS_CountSt;
}

public
decimal getSMS_CountEnd(){
	return SMS_CountEnd;
}

public
string getSMS_MasPrOrd(){
	return SMS_MasPrOrd;
}

public
string getSMS_PrOrd(){
	return SMS_PrOrd;
}


}

}