using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMatReqHrDataBase : GenericDataBaseElement{

private string SMH_SchVersion;
private int SMH_MachOrdNum;
private string SMH_Plt;
private string SMH_Dept;
private string SMH_Mach;
private string SMH_Shf;
private DateTime SMH_Dt;
private DateTime SMH_DtShf;
private string SMH_ProdID;
private int SMH_LineID;
private string SMH_MatID;
private int SMH_Seq;
private string SMH_ActID;
private decimal SMH_QtyPerInv;
private string SMH_Uom;
private decimal SMH_QtyReq;
private decimal SMH_InvStartPos;
private decimal SMH_InvEndPos;

public
SchMatReqHrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public 
void load(NotNullDataReader reader){
	this.SMH_SchVersion = reader.GetString("SMH_SchVersion");
	this.SMH_MachOrdNum = reader.GetInt32("SMH_MachOrdNum");
	this.SMH_Plt = reader.GetString("SMH_Plt");
	this.SMH_Dept = reader.GetString("SMH_Dept");
	this.SMH_Mach = reader.GetString("SMH_Mach");
	this.SMH_Shf = reader.GetString("SMH_Shf");
	this.SMH_Dt = reader.GetDateTime("SMH_Dt");
	this.SMH_DtShf = reader.GetDateTime("SMH_DtShf");
	this.SMH_ProdID = reader.GetString("SMH_ProdID");
	this.SMH_LineID = reader.GetInt32("SMH_LineID");
	this.SMH_MatID = reader.GetString("SMH_MatID");
	this.SMH_Seq = reader.GetInt32("SMH_Seq");
	this.SMH_ActID = reader.GetString("SMH_ActID");
	this.SMH_QtyPerInv = reader.GetDecimal("SMH_QtyPerInv");
	this.SMH_Uom = reader.GetString("SMH_Uom");
	this.SMH_QtyReq = reader.GetDecimal("SMH_QtyReq");
	this.SMH_InvStartPos = reader.GetDecimal("SMH_InvStartPos");
	this.SMH_InvEndPos = reader.GetDecimal("SMH_InvEndPos");
}

public
void read(){
	throw new PersistenceException("Method not implemented");
}

public override
void write(){
	try{
		string sql = "insert into schmatreqhr values('" + 
			Converter.fixString(SMH_SchVersion) + "', " +
			SMH_MachOrdNum + ", '" +
			Converter.fixString(SMH_Plt) + "', '" +
			Converter.fixString(SMH_Dept) + "', '" +
			Converter.fixString(SMH_Mach) + "', '" +
			Converter.fixString(SMH_Shf) + "', '" +
			DateUtil.getDateRepresentation(SMH_Dt)+ "', '" +
			DateUtil.getDateRepresentation(SMH_DtShf) + "', '" +
			SMH_ProdID + "', " +
			SMH_LineID + ", '" +
			Converter.fixString(SMH_MatID) + "', " +
			SMH_Seq + ", '" +
			Converter.fixString(SMH_ActID) + "', " +
			NumberUtil.toString(SMH_QtyPerInv) + ", '" +
			Converter.fixString(SMH_Uom) + "', " +
			NumberUtil.toString(SMH_QtyReq) + ", " +
			NumberUtil.toString(SMH_InvStartPos) + ", " +
			NumberUtil.toString(SMH_InvEndPos) + ")";

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
void delete(){
	throw new PersistenceException("Method not implemented");
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

//sets


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
void setSMH_Dt(DateTime SMH_Dt){
	this.SMH_Dt = SMH_Dt;
}

public 
void setSMH_DtShf(DateTime SMH_DtShf){
	this.SMH_DtShf = SMH_DtShf;
}

public 
void setSMH_ProdID(string SMH_ProdID){
	this.SMH_ProdID = SMH_ProdID;
}

public 
void setSMH_LineID(int SMH_LineID){
	this.SMH_LineID = SMH_LineID;
}

public 
void setSMH_MatID(string SMH_MatID){
	this.SMH_MatID = SMH_MatID;
}

public 
void setSMH_Seq(int SMH_Seq){
	this.SMH_Seq = SMH_Seq;
}

public 
void setSMH_ActID(string SMH_ActID){
	this.SMH_ActID = SMH_ActID;
}

public 
void setSMH_QtyPerInv(decimal SMH_QtyPerInv){
	this.SMH_QtyPerInv = SMH_QtyPerInv;
}

public 
void setSMH_Uom (string SMH_Uom){
	this.SMH_Uom = SMH_Uom;
}

public 
void setSMH_QtyReq(decimal SMH_QtyReq){
	this.SMH_QtyReq = SMH_QtyReq;
}

public 
void setSMH_InvStartPos(decimal SMH_InvStartPos){
	this.SMH_InvStartPos = SMH_InvStartPos;
}

public 
void setSMH_InvEndPos (decimal SMH_InvEndPos){
	this.SMH_InvEndPos = SMH_InvEndPos;
}

//gets

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
DateTime getSMH_Dt(){
	return SMH_Dt;
}

public 
DateTime getSMH_DtShf(){
	return SMH_DtShf;
}

public 
string getSMH_ProdID(){
	return SMH_ProdID;
}

public 
int getSMH_LineID(){
	return SMH_LineID;
}

public 
string getSMH_MatID(){
	return SMH_MatID;
}

public 
int getSMH_Seq(){
	return SMH_Seq;
}

public 
string getSMH_ActID(){
	return SMH_ActID;
}

public 
decimal getSMH_QtyPerInv(){
	return SMH_QtyPerInv;
}

public 
string getSMH_Uom(){
	return SMH_Uom;
}

public 
decimal getSMH_QtyReq(){
	return SMH_QtyReq;
}

public 
decimal getSMH_InvStartPos(){
	return SMH_InvStartPos;
}

public 
decimal getSMH_InvEndPos(){
	return SMH_InvEndPos;
}

} // class

} // namespace