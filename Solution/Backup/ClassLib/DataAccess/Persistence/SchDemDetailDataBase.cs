using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class SchDemDetailDataBase : GenericDataBaseElement{

private decimal SDD_OrdID;
private decimal SDD_ItemID;
private string SDD_RLID;
private string SDD_Type;
private string SDD_BusPrt;
private string SDD_BusLoc;
private string SDD_InvLoc;
private string SDD_ProdID;
private string SDD_ActID;
private int SDD_Seq;
private decimal SDD_QtyID;
private decimal SDD_QtyOver;
private decimal SDD_QtyUnder;
private decimal SDD_CumID;
private decimal SDD_ShipTm;
private string SDD_SrcType;
private string SDD_EcnLevOrd;
private string SDD_EcnLevPr;
private DateTime SDD_DtShip;
private DateTime SDD_DtArr;
private DateTime SDD_DtReqArr;
private string SDD_Emerg;
private string SDD_MasPrOrdID;
private string SDD_PrOrdID;
private string SDD_OrdUom;
private string SDD_InvUom;
private string SDD_CusProdID;


public
SchDemDetailDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
SchDemDetailDataBase(DemDetailDataBase demDetailDataBase) : base(demDetailDataBase.getDataBaseAccess()){
	this.SDD_OrdID = demDetailDataBase.getDEDT_OrdID();
	this.SDD_ItemID = demDetailDataBase.getDEDT_ItemID();
	this.SDD_RLID = demDetailDataBase.getDEDT_RLID();
	this.SDD_Type = demDetailDataBase.getDEDT_Type();
	this.SDD_BusPrt = demDetailDataBase.getDEDT_BusPrt();
	this.SDD_BusLoc = demDetailDataBase.getDEDT_BusLoc();
	this.SDD_InvLoc = demDetailDataBase.getDEDT_InvLoc();
	this.SDD_ProdID = demDetailDataBase.getDEDT_ProdID();
	this.SDD_ActID = demDetailDataBase.getDEDT_ActID();
	this.SDD_Seq = demDetailDataBase.getDEDT_Seq();
	this.SDD_QtyID = demDetailDataBase.getDEDT_QtyID();
	this.SDD_QtyOver = demDetailDataBase.getDEDT_QtyOver();
	this.SDD_QtyUnder = demDetailDataBase.getDEDT_QtyUnder();
	this.SDD_CumID = demDetailDataBase.getDEDT_CumID();
	this.SDD_ShipTm = demDetailDataBase.getDEDT_ShipTm();
	this.SDD_SrcType = demDetailDataBase.getDEDT_SrcType();
	this.SDD_EcnLevOrd = demDetailDataBase.getDEDT_EcnLevOrd();
	this.SDD_EcnLevPr = demDetailDataBase.getDEDT_EcnLevPr();
	this.SDD_DtShip = demDetailDataBase.getDEDT_DtShip();
	this.SDD_DtArr = demDetailDataBase.getDEDT_DtArr();
	this.SDD_DtReqArr = demDetailDataBase.getDEDT_DtReqArr();
	this.SDD_Emerg = demDetailDataBase.getDEDT_Emerg();
	this.SDD_MasPrOrdID = demDetailDataBase.getDEDT_MasPrOrdID();
	this.SDD_PrOrdID = demDetailDataBase.getDEDT_PrOrdID();
	this.SDD_OrdUom = demDetailDataBase.getDEDT_OrdUom();
	this.SDD_InvUom = demDetailDataBase.getDEDT_InvUom();
	this.SDD_CusProdID = demDetailDataBase.getDEDT_CusProdID();
}

public
void load(NotNullDataReader reader){
	this.SDD_OrdID = reader.GetDecimal(0);
	this.SDD_ItemID = reader.GetDecimal(1);
	this.SDD_RLID = reader.GetString(2);
	this.SDD_Type = reader.GetString(3);
	this.SDD_BusPrt = reader.GetString(4);
	this.SDD_BusLoc = reader.GetString(5);
	this.SDD_InvLoc = reader.GetString(6);
	this.SDD_ProdID = reader.GetString(7);
	this.SDD_ActID = reader.GetString(8);
	this.SDD_Seq = reader.GetInt32(9);
	this.SDD_QtyID = reader.GetDecimal(10);
	this.SDD_QtyOver = reader.GetDecimal(11);
	this.SDD_QtyUnder = reader.GetDecimal(12);
	this.SDD_CumID = reader.GetDecimal(13);
	this.SDD_ShipTm = reader.GetDecimal(14);
	this.SDD_SrcType = reader.GetString(15);
	this.SDD_EcnLevOrd = reader.GetString(16);
	this.SDD_EcnLevPr = reader.GetString(17);
	this.SDD_DtShip = reader.GetDateTime(18);
	this.SDD_DtArr = reader.GetDateTime(19);
	this.SDD_DtReqArr = reader.GetDateTime(20);
	this.SDD_Emerg = reader.GetString(21);
	this.SDD_MasPrOrdID = reader.GetString(22);
	this.SDD_PrOrdID = reader.GetString(23);
	this.SDD_OrdUom = reader.GetString(24);
	this.SDD_InvUom = reader.GetString(25);
	this.SDD_CusProdID = reader.GetString(26);
}

public override
void write(){
	try{
		string sql = "insert into schdemdetail(" +
			"SDD_OrdID, SDD_ItemID, SDD_RLID, SDD_BusLoc, " +
			"SDD_ProdID, SDD_QtyID, SDD_CumID, SDD_DtShip, " +
			"SDD_InvLoc, SDD_ShipTm) values(" +
			NumberUtil.toString(SDD_OrdID) + ", " +
			NumberUtil.toString(SDD_ItemID) + ", '" +
			Converter.fixString(SDD_RLID) + "', '" +
			Converter.fixString(SDD_BusLoc) + "', '" +
			Converter.fixString(SDD_ProdID) + "', " +
			NumberUtil.toString(SDD_QtyID) + ", " +
			NumberUtil.toString(SDD_CumID) + ", '" +
			DateUtil.getDateRepresentation(SDD_DtShip) + "', '" +
			Converter.fixString(SDD_InvLoc) + "', " +
			NumberUtil.toString(SDD_ShipTm) + ")";

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
	throw new PersistenceException("Method not implemented");
}

public
void setSDD_OrdID(decimal SDD_OrdID){
	this.SDD_OrdID = SDD_OrdID;
}

public
void setSDD_ItemID(decimal SDD_ItemID){
	this.SDD_ItemID = SDD_ItemID;
}

public
void setSDD_RLID(string SDD_RLID){
	this.SDD_RLID = SDD_RLID;
}

public
void setSDD_Type(string SDD_Type){
	this.SDD_Type = SDD_Type;
}

public
void setSDD_BusPrt(string SDD_BusPrt){
	this.SDD_BusPrt = SDD_BusPrt;
}

public
void setSDD_BusLoc(string SDD_BusLoc){
	this.SDD_BusLoc = SDD_BusLoc;
}

public
void setSDD_InvLoc(string SDD_InvLoc){
	this.SDD_InvLoc = SDD_InvLoc;
}

public
void setSDD_ProdID(string SDD_ProdID){
	this.SDD_ProdID = SDD_ProdID;
}

public
void setSDD_ActID(string SDD_ActID){
	this.SDD_ActID = SDD_ActID;
}

public
void setSDD_Seq(int SDD_Seq){
	this.SDD_Seq = SDD_Seq;
}

public
void setSDD_QtyID(decimal SDD_QtyID){
	this.SDD_QtyID = SDD_QtyID;
}

public
void setSDD_QtyOver(decimal SDD_QtyOver){
	this.SDD_QtyOver = SDD_QtyOver;
}

public
void setSDD_QtyUnder(decimal SDD_QtyUnder){
	this.SDD_QtyUnder = SDD_QtyUnder;
}

public
void setSDD_CumID(decimal SDD_CumID){
	this.SDD_CumID = SDD_CumID;
}

public
void setSDD_ShipTm(decimal SDD_ShipTm){
	this.SDD_ShipTm = SDD_ShipTm;
}

public
void setSDD_SrcType(string SDD_SrcType){
	this.SDD_SrcType = SDD_SrcType;
}

public
void setSDD_EcnLevOrd(string SDD_EcnLevOrd){
	this.SDD_EcnLevOrd = SDD_EcnLevOrd;
}

public
void setSDD_EcnLevPr(string SDD_EcnLevPr){
	this.SDD_EcnLevPr = SDD_EcnLevPr;
}

public
void setSDD_DtShip(DateTime SDD_DtShip){
	this.SDD_DtShip = SDD_DtShip;
}

public
void setSDD_DtArr(DateTime SDD_DtArr){
	this.SDD_DtArr = SDD_DtArr;
}

public
void setSDD_DtReqArr(DateTime SDD_DtReqArr){
	this.SDD_DtReqArr = SDD_DtReqArr;
}

public
void setSDD_Emerg(string SDD_Emerg){
	this.SDD_Emerg = SDD_Emerg;
}

public
void setSDD_MasPrOrdID(string SDD_MasPrOrdID){
	this.SDD_MasPrOrdID = SDD_MasPrOrdID;
}

public
void setSDD_PrOrdID(string SDD_PrOrdID){
	this.SDD_PrOrdID = SDD_PrOrdID;
}

public
void setSDD_OrdUom(string SDD_OrdUom){
	this.SDD_OrdUom = SDD_OrdUom;
}

public
void setSDD_InvUom(string SDD_InvUom){
	this.SDD_InvUom = SDD_InvUom;
}

public
void setSDD_CusProdID(string SDD_CusProdID){
	this.SDD_CusProdID = SDD_CusProdID;
}


public
decimal getSDD_OrdID(){
	return SDD_OrdID;
}

public
decimal getSDD_ItemID(){
	return SDD_ItemID;
}

public
string getSDD_RLID(){
	return SDD_RLID;
}

public
string getSDD_Type(){
	return SDD_Type;
}

public
string getSDD_BusPrt(){
	return SDD_BusPrt;
}

public
string getSDD_BusLoc(){
	return SDD_BusLoc;
}

public
string getSDD_InvLoc(){
	return SDD_InvLoc;
}

public
string getSDD_ProdID(){
	return SDD_ProdID;
}

public
string getSDD_ActID(){
	return SDD_ActID;
}

public
int getSDD_Seq(){
	return SDD_Seq;
}

public
decimal getSDD_QtyID(){
	return SDD_QtyID;
}

public
decimal getSDD_QtyOver(){
	return SDD_QtyOver;
}

public
decimal getSDD_QtyUnder(){
	return SDD_QtyUnder;
}

public
decimal getSDD_CumID(){
	return SDD_CumID;
}

public
decimal getSDD_ShipTm(){
	return SDD_ShipTm;
}

public
string getSDD_SrcType(){
	return SDD_SrcType;
}

public
string getSDD_EcnLevOrd(){
	return SDD_EcnLevOrd;
}

public
string getSDD_EcnLevPr(){
	return SDD_EcnLevPr;
}

public
DateTime getSDD_DtShip(){
	return SDD_DtShip;
}

public
DateTime getSDD_DtArr(){
	return SDD_DtArr;
}

public
DateTime getSDD_DtReqArr(){
	return SDD_DtReqArr;
}

public
string getSDD_Emerg(){
	return SDD_Emerg;
}

public
string getSDD_MasPrOrdID(){
	return SDD_MasPrOrdID;
}

public
string getSDD_PrOrdID(){
	return SDD_PrOrdID;
}

public
string getSDD_OrdUom(){
	return SDD_OrdUom;
}

public
string getSDD_InvUom(){
	return SDD_InvUom;
}

public
string getSDD_CusProdID(){
	return SDD_CusProdID;
}


} // clas(){

} // namespac(){
