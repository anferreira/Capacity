using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class DelJitDtlDataBase: GenericDataBaseElement	{

private int DJD_ID;
private string DJD_Db;
private int DJD_Key;
private string DJD_Reference;
private DateTime DJD_ShipDate;
private decimal DJD_ShipTime;
private DateTime DJD_EndDate;
private int DJD_Qty;
private int DJD_CumQty;
private int DJD_QtyAdj;
private string DJD_Source;
private int DJD_LogNum;
private int DJD_EntNum;
private int DJD_BOLNum;
private int DJD_BOLLine;
private string DJD_RAN;
private string DJD_Ref1;
private string DJD_Ref2;
private string DJD_Stat;
private int DJD_RecordID;
private string DJD_KanBanPre;
private string DJD_KanBanStart;
private string DJD_KanBanEnd;
private string DJD_ShipPattern;
private string DJD_ShipPatternTime;

 
public DelJitDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.DJD_ID = reader.GetInt32("DJD_ID");
	this.DJD_Db = reader.GetString("DJD_Db");
	this.DJD_Key = reader.GetInt32("DJD_Key");
	this.DJD_Reference = reader.GetString("DJD_Reference");
	this.DJD_ShipDate = reader.GetDateTime("DJD_ShipDate");
	this.DJD_ShipTime = reader.GetDecimal("DJD_ShipTime");
	this.DJD_EndDate = reader.GetDateTime("DJD_EndDate");
	this.DJD_Qty = reader.GetInt32("DJD_Qty");
	this.DJD_CumQty = reader.GetInt32("DJD_CumQty");
	this.DJD_QtyAdj = reader.GetInt32("DJD_QtyAdj");
	this.DJD_Source = reader.GetString("DJD_Source");
	this.DJD_LogNum = reader.GetInt32("DJD_LogNum");
	this.DJD_EntNum = reader.GetInt32("DJD_EntNum");
	this.DJD_BOLNum = reader.GetInt32("DJD_BOLNum");
	this.DJD_BOLLine = reader.GetInt32("DJD_BOLLine");
	this.DJD_RAN = reader.GetString("DJD_RAN");
	this.DJD_Ref1 = reader.GetString("DJD_Ref1");
	this.DJD_Ref2 = reader.GetString("DJD_Ref2");
	this.DJD_Stat = reader.GetString("DJD_Stat");
	this.DJD_RecordID = reader.GetInt32("DJD_RecordID");
	this.DJD_KanBanPre = reader.GetString("DJD_KanBanPre");
	this.DJD_KanBanStart = reader.GetString("DJD_KanBanStart");
	this.DJD_KanBanEnd = reader.GetString("DJD_KanBanEnd");
	this.DJD_ShipPattern = reader.GetString("DJD_ShipPattern");
	this.DJD_ShipPatternTime = reader.GetString("DJD_ShipPatternTime");
}

public override 
void write(){
	try{
		string sql = "insert into deljitdtl (DJD_Db, DJD_Key, DJD_Reference, DJD_ShipDate, DJD_ShipTime, " +
		                                    "DJD_EndDate, DJD_Qty, DJD_CumQty, DJD_QtyAdj, DJD_Source, DJD_LogNum,"+
		                                    "DJD_EntNum, DJD_BOLNum, DJD_BOLLine, DJD_RAN, DJD_Ref1, DJD_Ref2, " +
		                                    "DJD_Stat, DJD_RecordID, DJD_KanBanPre, DJD_KanBanStart, DJD_KanBanEnd,"+
		                                    "DJD_ShipPattern, DJD_ShipPatternTime) " +
		            "values('" + 
                            Converter.fixString(DJD_Db) +"', " +
                            NumberUtil.toString(DJD_Key) +", '" +
                            Converter.fixString(DJD_Reference) +"', '" +
                            DateUtil.getCompleteDateRepresentation(DJD_ShipDate) +"', " +
                            NumberUtil.toString(DJD_ShipTime) +", '" +
                            DateUtil.getCompleteDateRepresentation(DJD_EndDate) +"', " +
                            NumberUtil.toString(DJD_Qty) +", " +
                            NumberUtil.toString(DJD_CumQty) +", " +
                            NumberUtil.toString(DJD_QtyAdj) +", '" +
                            Converter.fixString(DJD_Source) +"', " +
                            NumberUtil.toString(DJD_LogNum) +", " +
                            NumberUtil.toString(DJD_EntNum) +", " +
                            NumberUtil.toString(DJD_BOLNum) +", " +
                            NumberUtil.toString(DJD_BOLLine) +", '" +
                            Converter.fixString(DJD_RAN) +"', '" +
                            Converter.fixString(DJD_Ref1) +"', '" +
                            Converter.fixString(DJD_Ref2) +"', '" +
                            Converter.fixString(DJD_Stat) +"', " +
                            NumberUtil.toString(DJD_RecordID) +", '" +
                            Converter.fixString(DJD_KanBanPre) +"', '" +
                            Converter.fixString(DJD_KanBanStart) +"', '" +
                            Converter.fixString(DJD_KanBanEnd) +"', '" +
                            Converter.fixString(DJD_ShipPattern) +"', '" +
                            Converter.fixString(DJD_ShipPatternTime) +"')";
		 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
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
void read(){
    throw new PersistenceException("Method not implemented");
}

//Setters
public void setDJD_ID (int DJD_ID){
    this.DJD_ID = DJD_ID;
}

public void setDJD_Db (string DJD_Db){
    this.DJD_Db = DJD_Db;
}

public void setDJD_Key (int DJD_Key){
    this.DJD_Key = DJD_Key;
}

public void setDJD_Reference (string DJD_Reference){
    this.DJD_Reference = DJD_Reference;
}

public void setDJD_ShipDate (DateTime DJD_ShipDate){
    this.DJD_ShipDate = DJD_ShipDate;
}

public void setDJD_ShipTime (decimal DJD_ShipTime){
    this.DJD_ShipTime = DJD_ShipTime;
}

public void setDJD_EndDate (DateTime DJD_EndDate){
    this.DJD_EndDate = DJD_EndDate;
}

public void setDJD_Qty (int DJD_Qty){
    this.DJD_Qty = DJD_Qty;
}

public void setDJD_CumQty (int DJD_CumQty){
    this.DJD_CumQty = DJD_CumQty;
}

public void setDJD_QtyAdj (int DJD_QtyAdj){
    this.DJD_QtyAdj = DJD_QtyAdj;
}

public void setDJD_Source (string DJD_Source){
    this.DJD_Source = DJD_Source;
}

public void setDJD_LogNum (int DJD_LogNum){
    this.DJD_LogNum = DJD_LogNum;
}

public void setDJD_EntNum (int DJD_EntNum){
    this.DJD_EntNum = DJD_EntNum;
}

public void setDJD_BOLNum (int DJD_BOLNum){
    this.DJD_BOLNum = DJD_BOLNum;
}

public void setDJD_BOLLine (int DJD_BOLLine){
    this.DJD_BOLLine = DJD_BOLLine;
}

public void setDJD_RAN (string DJD_RAN){
    this.DJD_RAN = DJD_RAN;
}

public void setDJD_Ref1 (string DJD_Ref1){
    this.DJD_Ref1 = DJD_Ref1;
}

public void setDJD_Ref2 (string DJD_Ref2){
    this.DJD_Ref2 = DJD_Ref2;
}

public void setDJD_Stat (string DJD_Stat){
    this.DJD_Stat = DJD_Stat;
}

public void setDJD_RecordID (int DJD_RecordID){
    this.DJD_RecordID = DJD_RecordID;
}

public void setDJD_KanBanPre (string DJD_KanBanPre){
    this.DJD_KanBanPre = DJD_KanBanPre;
}

public void setDJD_KanBanStart (string DJD_KanBanStart){
    this.DJD_KanBanStart = DJD_KanBanStart;
}

public void setDJD_KanBanEnd (string DJD_KanBanEnd){
    this.DJD_KanBanEnd = DJD_KanBanEnd;
}

public void setDJD_ShipPattern (string DJD_ShipPattern){
    this.DJD_ShipPattern = DJD_ShipPattern;
}

public void setDJD_ShipPatternTime (string DJD_ShipPatternTime){
    this.DJD_ShipPatternTime = DJD_ShipPatternTime;
}

//Getters

public int getDJD_ID(){
    return DJD_ID;
}

public string getDJD_Db(){
    return DJD_Db;
}

public int getDJD_Key(){
    return DJD_Key;
}

public string getDJD_Reference(){
    return DJD_Reference;
}

public DateTime getDJD_ShipDate(){
    return DJD_ShipDate;
}

public decimal getDJD_ShipTime(){
    return DJD_ShipTime;
}

public DateTime getDJD_EndDate(){
    return DJD_EndDate;
}

public int getDJD_Qty(){
    return DJD_Qty;
}

public int getDJD_CumQty(){
    return DJD_CumQty;
}

public int getDJD_QtyAdj(){
    return DJD_QtyAdj;
}

public string getDJD_Source(){
    return DJD_Source;
}

public int getDJD_LogNum(){
    return DJD_LogNum;
}

public int getDJD_EntNum(){
    return DJD_EntNum;
}

public int getDJD_BOLNum(){
    return DJD_BOLNum;
}

public int getDJD_BOLLine(){
    return DJD_BOLLine;
}

public string getDJD_RAN(){
    return DJD_RAN;
}

public string getDJD_Ref1(){
    return DJD_Ref1;
}

public string getDJD_Ref2(){
    return DJD_Ref2;
}

public string getDJD_Stat(){
    return DJD_Stat;
}

public int getDJD_RecordID(){
    return DJD_RecordID;
}

public string getDJD_KanBanPre(){
    return DJD_KanBanPre;
}

public string getDJD_KanBanStart(){
    return DJD_KanBanStart;
}

public string getDJD_KanBanEnd(){
    return DJD_KanBanEnd;
}

public string getDJD_ShipPattern(){
    return DJD_ShipPattern;
}

public string getDJD_ShipPatternTime(){
    return DJD_ShipPatternTime;
}


}//end class
}//end namespace
