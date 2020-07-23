using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchOrdMasDataBase : GenericDataBaseElement{

// attributes
private string SMO_SchVersion;
private string SMO_MasPrOrd;
private string SMO_ProdID;
private string SMO_ActID;
private int SMO_Seq;
private string SMO_Status;
private decimal SMO_Qty;
private decimal SMO_QtyMin;
private decimal SMO_QtyOver;
private decimal SMO_QtyUnd;
private string SMO_Uom;
private DateTime SMO_DtReq;
private DateTime SMO_DtStart;
private DateTime SMO_DtEnd;
private decimal SMO_HrPr;
private decimal SMO_HrPrUtil;
private long SMO_HrLabD;
private string SMO_MultiOrd;
private string SMO_MultiSeq;
private double SMO_Qty2;
private string SMO_Uom2;
	
public
SchOrdMasDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SMO_SchVersion = reader.GetString("SMO_SchVersion");
	this.SMO_MasPrOrd = reader.GetString("SMO_MasPrOrd");
	this.SMO_ProdID = reader.GetString("SMO_ProdID");
	this.SMO_ActID = reader.GetString("SMO_ActID");
	this.SMO_Seq = reader.GetInt32("SMO_Seq");
	this.SMO_Status = reader.GetString("SMO_Status");
	this.SMO_Qty = reader.GetDecimal("SMO_Qty");
	this.SMO_QtyMin = reader.GetDecimal("SMO_QtyMin");
	this.SMO_QtyOver = reader.GetDecimal("SMO_QtyOver");
	this.SMO_QtyUnd = reader.GetDecimal("SMO_QtyUnd");
	this.SMO_Uom = reader.GetString("SMO_Uom");
	this.SMO_DtReq = reader.GetDateTime("SMO_DtReq");
	this.SMO_DtStart = reader.GetDateTime("SMO_DtStart");
	this.SMO_DtEnd = reader.GetDateTime("SMO_DtEnd");
	this.SMO_HrPr = reader.GetDecimal("SMO_HrPr");
	this.SMO_HrPrUtil = reader.GetDecimal("SMO_HrPrUtil");
	this.SMO_HrLabD = reader.GetInt32("SMO_HrLabD");
	this.SMO_MultiOrd = reader.GetString("SMO_MultiOrd");
	this.SMO_MultiSeq = reader.GetString("SMO_MultiSeq");
	this.SMO_Qty2 = reader.GetDouble("SMO_Qty2");
	this.SMO_Uom2 = reader.GetString("SMO_Uom2");
}

public override
void write(){
	throw new PersistenceException("Method not implemented");
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
decimal getSMO_Qty(){
	return SMO_Qty;
}

public 
decimal getSMO_QtyMin(){
	return SMO_QtyMin;
}


public 
string getSMO_SchVersion(){
	return SMO_SchVersion;
}

public
string getSMO_MasPrOrd(){
	return SMO_MasPrOrd;
}

public 
int getSMO_Seq(){
	return SMO_Seq;
}

public 
string getSMO_ProdID(){
	return SMO_ProdID;
}
	
}

}