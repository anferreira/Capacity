using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMachHrDataBase : GenericDataBaseElement{

private string SMH_SchVersion;
private int SMH_MachOrdNum;
private string SMH_Plt;
private string SMH_Dept;
private string SMH_Mach;
private string SMH_Shf;
private string SMH_ShfGrp;
private DateTime SMH_DtShf;
private DateTime SMH_Dt;
private DateTime SMH_TmStart;
private DateTime SMH_TmEnd;
private decimal SMH_Qty;
private decimal SMH_Cycles;
private decimal SMH_HrPr;
private decimal SMH_HrPrUtil;
private decimal SMH_UtilPer;
private string SHM_TmType;
private decimal SMH_CountSt;
private decimal SMH_CountEnd;
private string SMH_MasPrOrd;
private string SMH_PrOrd;
private string SMH_Status;
private string SMH_DRS;
private decimal SMH_HoursBeh;
private decimal SMH_OrdID;
private decimal SMH_ItemID;
private string SMH_RLID;

public
SchMachHrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader)	{
	this.SMH_SchVersion = reader.GetString("SMH_SchVersion");
	this.SMH_MachOrdNum = reader.GetInt32("SMH_MachOrdNum");
	this.SMH_Plt = reader.GetString("SMH_Plt");
	this.SMH_Dept = reader.GetString("SMH_Dept");
	this.SMH_Mach = reader.GetString("SMH_Mach");
	this.SMH_Shf = reader.GetString("SMH_Shf");
	this.SMH_ShfGrp = reader.GetString("SMH_ShfGrp");
	this.SMH_DtShf = reader.GetDateTime("SMH_DtShf");
	this.SMH_Dt = reader.GetDateTime("SMH_Dt");
	this.SMH_TmStart = reader.GetDateTime("SMH_TmStart");
	this.SMH_TmEnd = reader.GetDateTime("SMH_TmEnd");
	this.SMH_Qty = reader.GetDecimal("SMH_Qty");
	this.SMH_Cycles = reader.GetDecimal("SMH_Cycles");
	this.SMH_HrPr = reader.GetDecimal("SMH_HrPr");
	this.SMH_HrPrUtil = reader.GetDecimal("SMH_HrPrUtil");
	this.SMH_UtilPer = reader.GetDecimal("SMH_UtilPer");
	this.SHM_TmType = reader.GetString("SHM_TmType");
	this.SMH_CountSt = reader.GetDecimal("SMH_CountSt");
	this.SMH_CountEnd = reader.GetDecimal("SMH_CountEnd");
	this.SMH_MasPrOrd = reader.GetString("SMH_MasPrOrd");
	this.SMH_PrOrd = reader.GetString("SMH_PrOrd");
	this.SMH_Status = reader.GetString("SMH_Status");
	this.SMH_DRS = reader.GetString("SMH_DRS");
	this.SMH_HoursBeh = reader.GetDecimal("SMH_HoursBeh");
	this.SMH_OrdID = reader.GetDecimal("SMH_OrdID");
	this.SMH_ItemID = reader.GetDecimal("SMH_ItemID");
	this.SMH_RLID = reader.GetString("SMH_RLID");
}

public override
void write(){
	string sql = "";
	try{
		sql = "insert into schmachhr values('" +
			Converter.fixString(SMH_SchVersion) + "', " +
			SMH_MachOrdNum.ToString() + ", '" +
			Converter.fixString(SMH_Plt) + "', '" +
			Converter.fixString(SMH_Dept) + "', '" +
			Converter.fixString(SMH_Mach) + "', '" +
			Converter.fixString(SMH_Shf) + "', '" +
			Converter.fixString(SMH_ShfGrp) + "', '" +
			DateUtil.getCompleteDateRepresentation(SMH_DtShf) +
			"', '" +
			DateUtil.getCompleteDateRepresentation(SMH_Dt) +
			"', '" +
			DateUtil.getCompleteDateRepresentation(SMH_TmStart) +
			"', '" +
			DateUtil.getCompleteDateRepresentation(SMH_TmEnd) +
			"', " +
			NumberUtil.toString(SMH_Qty) + ", " +
			NumberUtil.toString(SMH_Cycles) + ", " +
			NumberUtil.toString(SMH_HrPr) + ", " +
			NumberUtil.toString(SMH_HrPrUtil) + ", " +
			NumberUtil.toString(SMH_UtilPer) + ", '" +
			Converter.fixString(SHM_TmType) + "', " +
			NumberUtil.toString(SMH_CountSt) + ", " +
			NumberUtil.toString(SMH_CountEnd) + ", '" +
			Converter.fixString(SMH_MasPrOrd) + "', '" +
			Converter.fixString(SMH_PrOrd) + "', '" +
			Converter.fixString(SMH_Status) + "', '" +
			Converter.fixString(SMH_DRS) + "', " +
			NumberUtil.toString(SMH_HoursBeh) + "," +
			NumberUtil.toString(SMH_OrdID) + "," +
			NumberUtil.toString(SMH_ItemID) + ",'" +
			Converter.fixString(SMH_RLID) + "')";
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
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	try{
		string sql = "delete from schmachhr where " +
			"SMH_SchVersion = '" + SMH_SchVersion + "' and " +
			"SMH_MachOrdNum = " + SMH_MachOrdNum;

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
void setSMH_SchVersion(string SMH_SchVersion){
	this.SMH_SchVersion = SMH_SchVersion;
}

public
void setSMH_MachOrdNum(int SMH_MachOrdNum){
	this.SMH_MachOrdNum = SMH_MachOrdNum;
}

public
void setSMH_Plt(string SMH_Plt){
	this.SMH_Plt = SMH_Plt;
}

public
void setSMH_Dept(string SMH_Dept){
	this.SMH_Dept = SMH_Dept;
}

public
void setSMH_Mach(string SMH_Mach){
	this.SMH_Mach = SMH_Mach;
}

public
void setSMH_Shf(string SMH_Shf){
	this.SMH_Shf = SMH_Shf;
}

public
void setSMH_ShfGrp(string SMH_ShfGrp){
	this.SMH_ShfGrp = SMH_ShfGrp;
}

public
void setSMH_DtShf(DateTime SMH_DtShf){
	this.SMH_DtShf = SMH_DtShf;
}

public
void setSMH_Dt(DateTime SMH_Dt){
	this.SMH_Dt = SMH_Dt;
}

public
void setSMH_TmStart(DateTime SMH_TmStart){
	this.SMH_TmStart = SMH_TmStart;
}

public
void setSMH_TmEnd(DateTime SMH_TmEnd){
	this.SMH_TmEnd = SMH_TmEnd;
}

public
void setSMH_Qty(decimal SMH_Qty){
	this.SMH_Qty = SMH_Qty;
}

public
void setSMH_Cycles(decimal SMH_Cycles){
	this.SMH_Cycles = SMH_Cycles;
}

public
void setSMH_HrPr(decimal SMH_HrPr){
	this.SMH_HrPr = SMH_HrPr;
}

public
void setSMH_HrPrUtil(decimal SMH_HrPrUtil){
	this.SMH_HrPrUtil = SMH_HrPrUtil;
}

public
void setSMH_UtilPer(decimal SMH_UtilPer){
	this.SMH_UtilPer = SMH_UtilPer;
}

public
void setSHM_TmType(string SHM_TmType){
	this.SHM_TmType = SHM_TmType;
}

public
void setSMH_CountSt(decimal SMH_CountSt){
	this.SMH_CountSt = SMH_CountSt;
}

public
void setSMH_CountEnd(decimal SMH_CountEnd){
	this.SMH_CountEnd = SMH_CountEnd;
}

public
void setSMH_MasPrOrd(string SMH_MasPrOrd){
	this.SMH_MasPrOrd = SMH_MasPrOrd;
}

public
void setSMH_PrOrd(string SMH_PrOrd){
	this.SMH_PrOrd = SMH_PrOrd;
}

public
void setSMH_Status(string SMH_Status){
	this.SMH_Status = SMH_Status;
}

public
void setSMH_DRS(string SMH_DRS){
	this.SMH_DRS = SMH_DRS;
}

public
void setSMH_HoursBeh(decimal SMH_HoursBeh){
	this.SMH_HoursBeh = SMH_HoursBeh;
}

public
void setSMH_OrdID (decimal SMH_OrdID){
	this.SMH_OrdID = SMH_OrdID;
}

public
void setSMH_ItemID (decimal SMH_ItemID){
	this.SMH_ItemID = SMH_ItemID;
}

public
void setSMH_RLID (string SMH_RLID){
	this.SMH_RLID = SMH_RLID;
}


public
string getSMH_SchVersion(){
	return SMH_SchVersion;
}

public
int getSMH_MachOrdNum(){
	return SMH_MachOrdNum;
}

public
string getSMH_Plt(){
	return SMH_Plt;
}

public
string getSMH_Dept(){
	return SMH_Dept;
}

public
string getSMH_Mach(){
	return SMH_Mach;
}

public
string getSMH_Shf(){
	return SMH_Shf;
}

public
string getSMH_ShfGrp(){
	return SMH_ShfGrp;
}

public
DateTime getSMH_DtShf(){
	return SMH_DtShf;
}

public
DateTime getSMH_Dt(){
	return SMH_Dt;
}

public
DateTime getSMH_TmStart(){
	return SMH_TmStart;
}

public
DateTime getSMH_TmEnd(){
	return SMH_TmEnd;
}

public
decimal getSMH_Qty(){
	return SMH_Qty;
}

public
decimal getSMH_Cycles(){
	return SMH_Cycles;
}

public
decimal getSMH_HrPr(){
	return SMH_HrPr;
}

public
decimal getSMH_HrPrUtil(){
	return SMH_HrPrUtil;
}

public
decimal getSMH_UtilPer(){
	return SMH_UtilPer;
}

public
string getSHM_TmType(){
	return SHM_TmType;
}

public
decimal getSMH_CountSt(){
	return SMH_CountSt;
}

public
decimal getSMH_CountEnd(){
	return SMH_CountEnd;
}

public
string getSMH_MasPrOrd(){
	return SMH_MasPrOrd;
}

public
string getSMH_PrOrd(){
	return SMH_PrOrd;
}

public
string getSMH_Status(){
	return SMH_Status;
}

public
string getSMH_DRS(){
	return SMH_DRS;
}

public
decimal getSMH_HoursBeh(){
	return SMH_HoursBeh;
}

public
decimal getSMH_OrdID(){
	return SMH_OrdID;
}

public
decimal getSMH_ItemID(){
	return SMH_ItemID;
}

public
string getSMH_RLID(){
	return SMH_RLID;
}

}

}