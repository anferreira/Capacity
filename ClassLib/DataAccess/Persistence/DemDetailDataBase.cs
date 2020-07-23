using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class DemDetailDataBase : GenericDataBaseElement, IComparer, IComparable{

private decimal DEDT_OrdID;
private decimal DEDT_ItemID;
private string DEDT_RLID;
private string DEDT_Type;
private string DEDT_BusPrt;
private string DEDT_BusLoc;
private string DEDT_InvLoc;
private string DEDT_ProdID;
private string DEDT_ActID;
private int DEDT_Seq;
private decimal DEDT_QtyID;
private decimal DEDT_QtyOver;
private decimal DEDT_QtyUnder;
private decimal DEDT_CumID;
private decimal DEDT_ShipTm;
private string DEDT_SrcType;
private string DEDT_EcnLevOrd;
private string DEDT_EcnLevPr;
private DateTime DEDT_DtShip;
private DateTime DEDT_DtArr;
private DateTime DEDT_DtReqArr;
private string DEDT_Emerg;
private string DEDT_MasPrOrdID;
private string DEDT_PrOrdID;
private string DEDT_OrdUom;
private string DEDT_InvUom;
private string DEDT_CusProdID;

// only used for BOM
private string departamentCode;
private bool generated = false;

public
DemDetailDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
DemDetailDataBase(DemDetailDataBase demDetailDataBase) : base(demDetailDataBase.dataBaseAccess){
	this.DEDT_OrdID = demDetailDataBase.DEDT_OrdID;
	this.DEDT_ItemID = demDetailDataBase.DEDT_ItemID;
	this.DEDT_RLID = demDetailDataBase.DEDT_RLID;
	this.DEDT_Type = demDetailDataBase.DEDT_Type;
	this.DEDT_BusPrt = demDetailDataBase.DEDT_BusPrt;
	this.DEDT_BusLoc = demDetailDataBase.DEDT_BusLoc;
	this.DEDT_InvLoc = demDetailDataBase.DEDT_InvLoc;
	this.DEDT_ProdID = demDetailDataBase.DEDT_ProdID;
	this.DEDT_ActID = demDetailDataBase.DEDT_ActID;
	this.DEDT_Seq = demDetailDataBase.DEDT_Seq;
	this.DEDT_QtyID = demDetailDataBase.DEDT_QtyID;
	this.DEDT_QtyOver = demDetailDataBase.DEDT_QtyOver;
	this.DEDT_QtyUnder = demDetailDataBase.DEDT_QtyUnder;
	this.DEDT_CumID = demDetailDataBase.DEDT_CumID;
	this.DEDT_ShipTm = demDetailDataBase.DEDT_ShipTm;
	this.DEDT_SrcType = demDetailDataBase.DEDT_SrcType;
	this.DEDT_EcnLevOrd = demDetailDataBase.DEDT_EcnLevOrd;
	this.DEDT_EcnLevPr = demDetailDataBase.DEDT_EcnLevPr;
	this.DEDT_DtShip = demDetailDataBase.DEDT_DtShip;
	this.DEDT_DtArr = demDetailDataBase.DEDT_DtArr;
	this.DEDT_DtReqArr = demDetailDataBase.DEDT_DtReqArr;
	this.DEDT_Emerg = demDetailDataBase.DEDT_Emerg;
	this.DEDT_MasPrOrdID = demDetailDataBase.DEDT_MasPrOrdID;
	this.DEDT_PrOrdID = demDetailDataBase.DEDT_PrOrdID;
	this.DEDT_OrdUom = demDetailDataBase.DEDT_OrdUom;
	this.DEDT_InvUom = demDetailDataBase.DEDT_InvUom;
	this.DEDT_CusProdID = demDetailDataBase.DEDT_CusProdID;
	this.generated = true;
}

public
void load(NotNullDataReader reader){
	this.DEDT_OrdID = reader.GetDecimal(0);
	this.DEDT_ItemID = reader.GetDecimal(1);
	this.DEDT_RLID = reader.GetString(2);
	this.DEDT_Type = reader.GetString(3);
	this.DEDT_BusPrt = reader.GetString(4);
	this.DEDT_BusLoc = reader.GetString(5);
	this.DEDT_InvLoc = reader.GetString(6);
	this.DEDT_ProdID = reader.GetString(7);
	this.DEDT_ActID = reader.GetString(8);
	this.DEDT_Seq = reader.GetInt32(9);
	this.DEDT_QtyID = reader.GetDecimal(10);
	this.DEDT_QtyOver = reader.GetDecimal(11);
	this.DEDT_QtyUnder = reader.GetDecimal(12);
	this.DEDT_CumID = reader.GetDecimal(13);
	this.DEDT_ShipTm = reader.GetDecimal(14);
	this.DEDT_SrcType = reader.GetString(15);
	this.DEDT_EcnLevOrd = reader.GetString(16);
	this.DEDT_EcnLevPr = reader.GetString(17);
	this.DEDT_DtShip = reader.GetDateTime(18);
	this.DEDT_DtArr = reader.GetDateTime(19);
	this.DEDT_DtReqArr = reader.GetDateTime(20);
	this.DEDT_Emerg = reader.GetString(21);
	this.DEDT_MasPrOrdID = reader.GetString(22);
	this.DEDT_PrOrdID = reader.GetString(23);
	this.DEDT_OrdUom = reader.GetString(24);
	this.DEDT_InvUom = reader.GetString(25);
	this.DEDT_CusProdID = reader.GetString(26);
}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * demdetail " + 
					"where DEDT_OrdID = " + this.DEDT_OrdID + " and DEDT_ItemID = " + this.DEDT_ItemID + 
					"and DEDT_RLID = '" + this.DEDT_RLID + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void write(){
	try{
		string sql = "insert into demdetail(" +
			"DEDT_OrdID, DEDT_ItemID, DEDT_RLID, DEDT_BusLoc, " +
			"DEDT_ProdID, DEDT_QtyID, DEDT_CumID, DEDT_DtShip, " +
            "DEDT_InvLoc, DEDT_ShipTm,DEDT_SrcType,DEDT_CusProdID) values(" +
			NumberUtil.toString(DEDT_OrdID) + ", " +
			NumberUtil.toString(DEDT_ItemID) + ", '" +
			Converter.fixString(DEDT_RLID) + "', '" +
			Converter.fixString(DEDT_BusLoc) + "', '" +
			Converter.fixString(DEDT_ProdID) + "', " +
			NumberUtil.toString(DEDT_QtyID) + ", " +
			NumberUtil.toString(DEDT_CumID) + ", '" +
			DateUtil.getDateRepresentation(DEDT_DtShip) + "', '" +
			Converter.fixString(DEDT_InvLoc) + "', " +
			NumberUtil.toString(DEDT_ShipTm) + ", " +
            "'"+ Converter.fixString(DEDT_SrcType) + "', " +
            "'"+ Converter.fixString(DEDT_CusProdID) + "')";
                  
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
void setDEDT_OrdID(decimal DEDT_OrdID){
	this.DEDT_OrdID = DEDT_OrdID;
}

public
void setDEDT_ItemID(decimal DEDT_ItemID){
	this.DEDT_ItemID = DEDT_ItemID;
}

public
void setDEDT_RLID(string DEDT_RLID){
	this.DEDT_RLID = DEDT_RLID;
}

public
void setDEDT_Type(string DEDT_Type){
	this.DEDT_Type = DEDT_Type;
}

public
void setDEDT_BusPrt(string DEDT_BusPrt){
	this.DEDT_BusPrt = DEDT_BusPrt;
}

public
void setDEDT_BusLoc(string DEDT_BusLoc){
	this.DEDT_BusLoc = DEDT_BusLoc;
}

public
void setDEDT_InvLoc(string DEDT_InvLoc){
	this.DEDT_InvLoc = DEDT_InvLoc;
}

public
void setDEDT_ProdID(string DEDT_ProdID){
	this.DEDT_ProdID = DEDT_ProdID;
}

public
void setDEDT_ActID(string DEDT_ActID){
	this.DEDT_ActID = DEDT_ActID;
}

public
void setDEDT_Seq(int DEDT_Seq){
	this.DEDT_Seq = DEDT_Seq;
}

public
void setDEDT_QtyID(decimal DEDT_QtyID){
	this.DEDT_QtyID = DEDT_QtyID;
}

public
void setDEDT_QtyOver(decimal DEDT_QtyOver){
	this.DEDT_QtyOver = DEDT_QtyOver;
}

public
void setDEDT_QtyUnder(decimal DEDT_QtyUnder){
	this.DEDT_QtyUnder = DEDT_QtyUnder;
}

public
void setDEDT_CumID(decimal DEDT_CumID){
	this.DEDT_CumID = DEDT_CumID;
}

public
void setDEDT_ShipTm(decimal DEDT_ShipTm){
	this.DEDT_ShipTm = DEDT_ShipTm;
}

public
void setDEDT_SrcType(string DEDT_SrcType){
	this.DEDT_SrcType = DEDT_SrcType;
}

public
void setDEDT_EcnLevOrd(string DEDT_EcnLevOrd){
	this.DEDT_EcnLevOrd = DEDT_EcnLevOrd;
}

public
void setDEDT_EcnLevPr(string DEDT_EcnLevPr){
	this.DEDT_EcnLevPr = DEDT_EcnLevPr;
}

public
void setDEDT_DtShip(DateTime DEDT_DtShip){
	this.DEDT_DtShip = DEDT_DtShip;
}

public
void setDEDT_DtArr(DateTime DEDT_DtArr){
	this.DEDT_DtArr = DEDT_DtArr;
}

public
void setDEDT_DtReqArr(DateTime DEDT_DtReqArr){
	this.DEDT_DtReqArr = DEDT_DtReqArr;
}

public
void setDEDT_Emerg(string DEDT_Emerg){
	this.DEDT_Emerg = DEDT_Emerg;
}

public
void setDEDT_MasPrOrdID(string DEDT_MasPrOrdID){
	this.DEDT_MasPrOrdID = DEDT_MasPrOrdID;
}

public
void setDEDT_PrOrdID(string DEDT_PrOrdID){
	this.DEDT_PrOrdID = DEDT_PrOrdID;
}

public
void setDEDT_OrdUom(string DEDT_OrdUom){
	this.DEDT_OrdUom = DEDT_OrdUom;
}

public
void setDEDT_InvUom(string DEDT_InvUom){
	this.DEDT_InvUom = DEDT_InvUom;
}

public
void setDEDT_CusProdID(string DEDT_CusProdID){
	this.DEDT_CusProdID = DEDT_CusProdID;
}

// only used for BOM
public
void setDepartamentCode(string departamentCode){
	this.departamentCode = departamentCode;
}

	
public
decimal getDEDT_OrdID(){
	return DEDT_OrdID;
}

public
decimal getDEDT_ItemID(){
	return DEDT_ItemID;
}

public
string getDEDT_RLID(){
	return DEDT_RLID;
}

public
string getDEDT_Type(){
	return DEDT_Type;
}

public
string getDEDT_BusPrt(){
	return DEDT_BusPrt;
}

public
string getDEDT_BusLoc(){
	return DEDT_BusLoc;
}

public
string getDEDT_InvLoc(){
	return DEDT_InvLoc;
}

public
string getDEDT_ProdID(){
	return DEDT_ProdID;
}

public
string getDEDT_ActID(){
	return DEDT_ActID;
}

public
int getDEDT_Seq(){
	return DEDT_Seq;
}

public
decimal getDEDT_QtyID(){
	return DEDT_QtyID;
}

public
decimal getDEDT_QtyOver(){
	return DEDT_QtyOver;
}

public
decimal getDEDT_QtyUnder(){
	return DEDT_QtyUnder;
}

public
decimal getDEDT_CumID(){
	return DEDT_CumID;
}

public
decimal getDEDT_ShipTm(){
	return DEDT_ShipTm;
}

public
string getDEDT_SrcType(){
	return DEDT_SrcType;
}

public
string getDEDT_EcnLevOrd(){
	return DEDT_EcnLevOrd;
}

public
string getDEDT_EcnLevPr(){
	return DEDT_EcnLevPr;
}

public
DateTime getDEDT_DtShip(){
	return DEDT_DtShip;
}

public
DateTime getDEDT_DtArr(){
	return DEDT_DtArr;
}

public
DateTime getDEDT_DtReqArr(){
	return DEDT_DtReqArr;
}

public
string getDEDT_Emerg(){
	return DEDT_Emerg;
}

public
string getDEDT_MasPrOrdID(){
	return DEDT_MasPrOrdID;
}

public
string getDEDT_PrOrdID(){
	return DEDT_PrOrdID;
}

public
string getDEDT_OrdUom(){
	return DEDT_OrdUom;
}

public
string getDEDT_InvUom(){
	return DEDT_InvUom;
}

public
string getDEDT_CusProdID(){
	return DEDT_CusProdID;
}

// only used for BOM
public
string getDepartamentCode(){
	return departamentCode;
}

public
bool isGenerated(){
	return this.generated;
}

public
int Compare(object x, object y){
	DemDetailDataBase obj1 = (DemDetailDataBase)x;
	DemDetailDataBase obj2 = (DemDetailDataBase)y;
//Value Condition 
//Less than zero x is less than y. 
//Zero x equals y. 
//Greater than zero x is greater than y. 

	string key1 = obj1.getDEDT_ProdID() + "_" + obj1.getDEDT_Seq().ToString() + "_" +
		DateUtil.getDateRepresentation(obj1.getDEDT_DtShip(), DateUtil.YYYYMMDD);
	string key2 = obj2.getDEDT_ProdID() + "_" + obj2.getDEDT_Seq().ToString() + "_" +
		DateUtil.getDateRepresentation(obj2.getDEDT_DtShip(), DateUtil.YYYYMMDD);
	return key1.CompareTo(key2);
}

public
int CompareTo(object obj){
	DemDetailDataBase obj2 = (DemDetailDataBase)obj;

	string key1 = this.getDEDT_ProdID() + "_" + this.getDEDT_Seq().ToString() + "_" +
		DateUtil.getDateRepresentation(this.getDEDT_DtShip(), DateUtil.YYYYMMDD);
	string key2 = obj2.getDEDT_ProdID() + "_" + obj2.getDEDT_Seq().ToString() + "_" +
		DateUtil.getDateRepresentation(obj2.getDEDT_DtShip(), DateUtil.YYYYMMDD);
	return key1.CompareTo(key2);
}

} // clas(){

} // namespac(){
