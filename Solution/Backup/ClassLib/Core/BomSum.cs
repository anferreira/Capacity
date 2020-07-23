using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class BomSum{

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
private bool _isDeleted = false;

public 
BomSum(){
}

public 
BomSum(string BMS_ProdID, string BMS_ActID, int BMS_Seq, string BMS_SubID, int BMS_SubOrdNum, 
		int BMS_MethodRank, int BMS_MatOrdNum, string BMS_MatID, int BMS_MatSeq, string BMS_TLID, 
		decimal BMS_MatQty, string BMS_Uom, decimal BMS_PrQty, string BMS_PrQtyUom, decimal BMS_QtyPerInv, 
		string BMS_QtyPerUom, string BMS_UsePer, decimal BMS_MatPer, decimal BMS_ScrapPer, decimal BMS_ScrapAmt, 
		string BMS_ScrapUnt, string BMS_EcnCurr, string BMS_EcnFut, DateTime BMS_EcnFutDat, string BMS_BomSumYN){
	
	this.BMS_ProdID = BMS_ProdID;
	this.BMS_ActID = BMS_ActID;
	this.BMS_Seq = BMS_Seq;
	this.BMS_SubID = BMS_SubID;
	this.BMS_SubOrdNum = BMS_SubOrdNum;
	this.BMS_MethodRank = BMS_MethodRank;
	this.BMS_MatOrdNum = BMS_MatOrdNum;
	this.BMS_MatID = BMS_MatID;
	this.BMS_MatSeq = BMS_MatSeq;
	this.BMS_TLID = BMS_TLID;
	this.BMS_MatQty = BMS_MatQty;
	this.BMS_Uom = BMS_Uom;
	this.BMS_PrQty = BMS_PrQty;
	this.BMS_PrQtyUom = BMS_PrQtyUom;
	this.BMS_QtyPerInv = BMS_QtyPerInv;
	this.BMS_QtyPerUom = BMS_QtyPerUom;
	this.BMS_UsePer = BMS_UsePer;
	this.BMS_MatPer = BMS_MatPer;
	this.BMS_ScrapPer = BMS_ScrapPer;
	this.BMS_ScrapAmt = BMS_ScrapAmt;
	this.BMS_ScrapUnt = BMS_ScrapUnt;
	this.BMS_EcnCurr = BMS_EcnCurr;
	this.BMS_EcnFut = BMS_EcnFut;
	this.BMS_EcnFutDat = BMS_EcnFutDat;
	this.BMS_BomSumYN = BMS_BomSumYN;
	this._isDeleted = false;
}

public 
void setBMS_ProdID(string BMS_ProdID){ 
	this.BMS_ProdID = BMS_ProdID;
}

public 
void setBMS_ActID(string BMS_ActID){ 
	this.BMS_ActID = BMS_ActID; }

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
void delete(){ 
	this._isDeleted = true;
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

public
bool isDeleted(){ 
	return this._isDeleted; 
}

} // class

} // namespace