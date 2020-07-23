using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class BomSumDataBase : GenericDataBaseElement{

private string BMS_ProdID;
private string BMS_ActID;
private int BMS_Seq;
private string BMS_SubID;
private int BMS_SubOrdNum;
private int BMS_MethodRank;
private int BMS_MatOrdNum;
private string BMS_MatID;
private int BMS_MatSeq;
private string BMS_TLID;
private decimal BMS_MatQty;
private string BMS_Uom;
private decimal BMS_PrQty;
private string BMS_PrQtyUom;
private decimal BMS_QtyPerInv;
private string BMS_QtyPerUom;
private string BMS_UsePer;
private decimal BMS_MatPer;
private decimal BMS_ScrapPer;
private decimal BMS_ScrapAmt;
private string BMS_ScrapUnt;
private string BMS_EcnCurr;
private string BMS_EcnFut;
private DateTime BMS_EcnFutDat;
private string BMS_BomSumYN;

public 
BomSumDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.BMS_ProdID = reader.GetString("BMS_ProdID").Trim();
	this.BMS_ActID = reader.GetString("BMS_ActID").Trim();
	this.BMS_Seq = reader.GetInt32("BMS_Seq");
	this.BMS_SubID = reader.GetString("BMS_SubID").Trim();
	this.BMS_SubOrdNum = reader.GetInt32("BMS_SubOrdNum");
	this.BMS_MethodRank = reader.GetInt32("BMS_MethodRank");
	this.BMS_MatOrdNum = reader.GetInt32("BMS_MatOrdNum");
	this.BMS_MatID = reader.GetString("BMS_MatID").Trim();
	this.BMS_MatSeq = reader.GetInt32("BMS_MatSeq");
	this.BMS_TLID = reader.GetString("BMS_TLID").Trim();
	this.BMS_MatQty = reader.GetDecimal("BMS_MatQty");
	this.BMS_Uom = reader.GetString("BMS_Uom").Trim();
	this.BMS_PrQty = reader.GetDecimal("BMS_PrQty");
	this.BMS_PrQtyUom = reader.GetString("BMS_PrQtyUom").Trim();
	this.BMS_QtyPerInv = reader.GetDecimal("BMS_QtyPerInv");
	this.BMS_QtyPerUom = reader.GetString("BMS_QtyPerUom").Trim();
	this.BMS_UsePer = reader.GetString("BMS_UsePer").Trim();
	this.BMS_MatPer = reader.GetDecimal("BMS_MatPer");
	this.BMS_ScrapPer = reader.GetDecimal("BMS_ScrapPer");
	this.BMS_ScrapAmt = reader.GetDecimal("BMS_ScrapAmt");
	this.BMS_ScrapUnt = reader.GetString("BMS_ScrapUnt").Trim();
	this.BMS_EcnCurr = reader.GetString("BMS_EcnCurr").Trim();
	this.BMS_EcnFut = reader.GetString("BMS_EcnFut").Trim();
	this.BMS_EcnFutDat = reader.GetDateTime("BMS_EcnFutDat");
	this.BMS_BomSumYN = reader.GetString("BMS_BomSumYN").Trim();
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from bomsum where " +
			"BMS_ProdID = '" + Converter.fixString(BMS_ProdID) + "'";
		
		if (BMS_Seq>0) sql += " and BMS_Seq = " + NumberUtil.toString(BMS_Seq);
		
		sql += " and BMS_MatID = '" + Converter.fixString(BMS_MatID) + "'";
		
		if (BMS_MatSeq>0) sql += " and BMS_MatSeq = " + NumberUtil.toString(BMS_MatSeq);

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

public 
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from bomsum where " +
			"BMS_ProdID = '" + Converter.fixString(BMS_ProdID) + "'";
		
		if (BMS_Seq>0) sql += " and BMS_Seq = " + NumberUtil.toString(BMS_Seq);
		
		sql += " and BMS_MatID = '" + Converter.fixString(BMS_MatID) + "'";
		
		if (BMS_MatSeq>0) sql += " and BMS_MatSeq = " + NumberUtil.toString(BMS_MatSeq);

		bool returnType = false;

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			returnType = true;
		}
		return returnType;
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

public override 
void write(){
	try{
		string sql = "insert into bomsum values('" + 
			Converter.fixString(BMS_ProdID) + "', '" +
			Converter.fixString(BMS_ActID) + "'," +
			BMS_Seq + ", '" +
			Converter.fixString(BMS_SubID) + "', " +
			BMS_SubOrdNum + ", " +
			BMS_MethodRank + ", " +
			BMS_MatOrdNum + ", '" +
			Converter.fixString(BMS_MatID) + "', " +
			NumberUtil.toString(BMS_MatSeq) + ", '" +
			Converter.fixString(BMS_TLID) + "', " +
			NumberUtil.toString(BMS_MatQty) + ", '" +
			Converter.fixString(BMS_Uom) + "', " +
			NumberUtil.toString(BMS_PrQty) + ", '" +
			Converter.fixString(BMS_PrQtyUom) + "', " +
			NumberUtil.toString(BMS_QtyPerInv) + ", '" +
			Converter.fixString(BMS_QtyPerUom) + "', '" +
			Converter.fixString(BMS_UsePer) + "', " +
			NumberUtil.toString(BMS_MatPer) + ", " +
			NumberUtil.toString(BMS_ScrapPer) + ", " +
			NumberUtil.toString(BMS_ScrapAmt) + ", '" +
			Converter.fixString(BMS_ScrapUnt) + "', '" +
			Converter.fixString(BMS_EcnCurr) + "', '" +
			Converter.fixString(BMS_EcnFut) + "', '" +
			DateUtil.getDateRepresentation(BMS_EcnFutDat) + "', '" +
			Converter.fixString(BMS_BomSumYN) + "')";
		
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
		string sql = "update bomsum set " +
			"BMS_ActID = '" + Converter.fixString(BMS_ActID)  + "', " +
			"BMS_SubID = '" + Converter.fixString(BMS_SubID)  + "', " +
			"BMS_SubOrdNum = " + BMS_SubOrdNum  + ", " +
			"BMS_MethodRank = " + BMS_MethodRank  + ", " +
			"BMS_MatOrdNum = " + BMS_MatOrdNum  + ", " +
			"BMS_TLID = '" + Converter.fixString(BMS_TLID)  + "', " +
			"BMS_MatQty = " + NumberUtil.toString(BMS_MatQty)  + ", " +
			"BMS_Uom = '" + Converter.fixString(BMS_Uom)  + "', " +
			"BMS_PrQty = " + NumberUtil.toString(BMS_PrQty)  + ", " +
			"BMS_PrQtyUom = '" + Converter.fixString(BMS_PrQtyUom)  + "', " +
			"BMS_QtyPerInv = " + NumberUtil.toString(BMS_QtyPerInv)  + ", " +
			"BMS_QtyPerUom = '" + Converter.fixString(BMS_QtyPerUom)  + "', " +
			"BMS_UsePer = '" + Converter.fixString(BMS_UsePer)  + "', " +
			"BMS_MatPer = " + NumberUtil.toString(BMS_MatPer)  + ", " +
			"BMS_ScrapPer = " + NumberUtil.toString(BMS_ScrapPer)  + ", " +
			"BMS_ScrapAmt = " + NumberUtil.toString(BMS_ScrapAmt)  + ", " +
			"BMS_ScrapUnt = '" + Converter.fixString(BMS_ScrapUnt)  + "', " +
			"BMS_EcnCurr = '" + Converter.fixString(BMS_EcnCurr) + "', " +
			"BMS_EcnFut = '" + Converter.fixString(BMS_EcnFut) + "', " +
			"BMS_EcnFutDat= '" + DateUtil.getDateRepresentation(BMS_EcnFutDat) + "', " +
			"BMS_BomSumYN = '" + Converter.fixString(BMS_BomSumYN)  + "'" + 
			" where " +
			"BMS_ProdID = '" + Converter.fixString(BMS_ProdID) + "' and " +
			"BMS_Seq = " + NumberUtil.toString(BMS_Seq) + " and " +
			"BMS_MatID = '" + Converter.fixString(BMS_MatID) + "' and " +
			"BMS_MatSeq = " + NumberUtil.toString(BMS_MatSeq);

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
		string sql = "delete from bomsum where " +
			"BMS_ProdID = '" + Converter.fixString(BMS_ProdID) + "' and " +
			"BMS_Seq = " + NumberUtil.toString(BMS_Seq) + " and " +
			"BMS_MatID = '" + Converter.fixString(BMS_MatID) + "' and " +
			"BMS_MatSeq = " + NumberUtil.toString(BMS_MatSeq);
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
void setBMS_ProdID(string BMS_ProdID){
	this.BMS_ProdID = BMS_ProdID;
}

public
void setBMS_ActID(string BMS_ActID){
	this.BMS_ActID = BMS_ActID;
}

public
void setBMS_Seq(int BMS_Seq){
	this.BMS_Seq = BMS_Seq;
}

public
void setBMS_SubID(string BMS_SubID){
	this.BMS_SubID = BMS_SubID;
}

public
void setBMS_SubOrdNum(int BMS_SubOrdNum){
	this.BMS_SubOrdNum = BMS_SubOrdNum;
}

public
void setBMS_MethodRank(int BMS_MethodRank){
	this.BMS_MethodRank = BMS_MethodRank;
}

public
void setBMS_MatOrdNum(int BMS_MatOrdNum){
	this.BMS_MatOrdNum = BMS_MatOrdNum;
}

public
void setBMS_MatID(string BMS_MatID){
	this.BMS_MatID = BMS_MatID;
}

public
void setBMS_MatSeq(int BMS_MatSeq){
	this.BMS_MatSeq = BMS_MatSeq;
}

public
void setBMS_TLID(string BMS_TLID){
	this.BMS_TLID = BMS_TLID;
}

public
void setBMS_MatQty(decimal BMS_MatQty){
	this.BMS_MatQty = BMS_MatQty;
}

public
void setBMS_Uom(string BMS_Uom){
	this.BMS_Uom = BMS_Uom;
}

public
void setBMS_PrQty(decimal BMS_PrQty){
	this.BMS_PrQty = BMS_PrQty;
}

public
void setBMS_PrQtyUom(string BMS_PrQtyUom){
	this.BMS_PrQtyUom = BMS_PrQtyUom;
}

public
void setBMS_QtyPerInv(decimal BMS_QtyPerInv){
	this.BMS_QtyPerInv = BMS_QtyPerInv;
}

public
void setBMS_QtyPerUom(string BMS_QtyPerUom){
	this.BMS_QtyPerUom = BMS_QtyPerUom;
}

public
void setBMS_UsePer(string BMS_UsePer){
	this.BMS_UsePer = BMS_UsePer;
}

public
void setBMS_MatPer(decimal BMS_MatPer){
	this.BMS_MatPer = BMS_MatPer;
}

public
void setBMS_ScrapPer(decimal BMS_ScrapPer){
	this.BMS_ScrapPer = BMS_ScrapPer;
}

public
void setBMS_ScrapAmt(decimal BMS_ScrapAmt){
	this.BMS_ScrapAmt = BMS_ScrapAmt;
}

public
void setBMS_ScrapUnt(string BMS_ScrapUnt){
	this.BMS_ScrapUnt = BMS_ScrapUnt;
}

public
void setBMS_EcnCurr(string BMS_EcnCurr){
	this.BMS_EcnCurr = BMS_EcnCurr;
}

public
void setBMS_EcnFut(string BMS_EcnFut){
	this.BMS_EcnFut = BMS_EcnFut;
}

public
void setBMS_EcnFutDat(DateTime BMS_EcnFutDat){
	this.BMS_EcnFutDat = BMS_EcnFutDat;
}

public
void setBMS_BomSumYN(string BMS_BomSumYN){
	this.BMS_BomSumYN = BMS_BomSumYN;
}

public
string getBMS_ProdID(){
	return BMS_ProdID;
}

public
string getBMS_ActID(){
	return BMS_ActID;
}

public
int getBMS_Seq(){
	return BMS_Seq;
}

public
string getBMS_SubID(){
	return BMS_SubID;
}

public
int getBMS_SubOrdNum(){
	return BMS_SubOrdNum;
}

public
int getBMS_MethodRank(){
	return BMS_MethodRank;
}

public
int getBMS_MatOrdNum(){
	return BMS_MatOrdNum;
}

public
string getBMS_MatID(){
	return BMS_MatID;
}

public
int getBMS_MatSeq(){
	return BMS_MatSeq;
}

public
string getBMS_TLID(){
	return BMS_TLID;
}

public
decimal getBMS_MatQty(){
	return BMS_MatQty;
}

public
string getBMS_Uom(){
	return BMS_Uom;
}

public
decimal getBMS_PrQty(){
	return BMS_PrQty;
}

public
string getBMS_PrQtyUom(){
	return BMS_PrQtyUom;
}

public
decimal getBMS_QtyPerInv(){
	return BMS_QtyPerInv;
}

public
string getBMS_QtyPerUom(){
	return BMS_QtyPerUom;
}

public
string getBMS_UsePer(){
	return BMS_UsePer;
}

public
decimal getBMS_MatPer(){
	return BMS_MatPer;
}

public
decimal getBMS_ScrapPer(){
	return BMS_ScrapPer;
}

public
decimal getBMS_ScrapAmt(){
	return BMS_ScrapAmt;
}

public
string getBMS_ScrapUnt(){
	return BMS_ScrapUnt;
}

public
string getBMS_EcnCurr(){
	return BMS_EcnCurr;
}

public
string getBMS_EcnFut(){
	return BMS_EcnFut;
}

public
DateTime getBMS_EcnFutDat(){
	return BMS_EcnFutDat;
}

public
string getBMS_BomSumYN(){
	return BMS_BomSumYN;
}

} // class

} // namespace