using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class BomSum : BusinessObject {

private string prodID;
private string actID;
private int seq;
private string subID;
private int subOrdNum;
private int methodRank;
private int matOrdNum;
private string matID;
private int matSeq;
private string tLID;
private decimal matQty;
private string uom;
private decimal prQty;
private string prQtyUom;
private decimal qtyPerInv;
private string qtyPerUom;
private string usePer;
private decimal matPer;
private decimal scrapPer;
private decimal scrapAmt;
private string scrapUnt;
private string ecnCurr;
private string ecnFut;
private DateTime ecnFutDat;
private string bomSumYN;
private bool _isDeleted = false;

private string matDescShow="";
private string matTypeShow="";
private decimal matQohShow=0;            

public 
BomSum(){
}

public 
BomSum(string prodID, string actID, int seq, string subID, int subOrdNum, 
		int methodRank, int matOrdNum, string matID, int matSeq, string tLID, 
		decimal matQty, string uom, decimal prQty, string prQtyUom, decimal qtyPerInv, 
		string qtyPerUom, string usePer, decimal matPer, decimal scrapPer, decimal scrapAmt, 
		string scrapUnt, string ecnCurr, string ecnFut, DateTime ecnFutDat, string bomSumYN){
	
	ProdID = prodID;
	ActID = actID;
	Seq = seq;
	SubID = subID;
	SubOrdNum = subOrdNum;
	MethodRank = methodRank;
	MatOrdNum = matOrdNum;
	MatID = matID;
	MatSeq = matSeq;
	TLID = tLID;
	MatQty = matQty;
	Uom = uom;
	PrQty = prQty;
	PrQtyUom = prQtyUom;
	QtyPerInv = qtyPerInv;
	QtyPerUom = qtyPerUom;
	UsePer = usePer;
	MatPer = matPer;
	ScrapPer = scrapPer;
	ScrapAmt = scrapAmt;
	ScrapUnt = scrapUnt;
	EcnCurr = ecnCurr;
	EcnFut = ecnFut;
	EcnFutDat = ecnFutDat;
	BomSumYN = bomSumYN;
	this._isDeleted = false;
}

public 
void setBMS_ProdID(string prodID){ 
	this.ProdID = prodID;
}

public 
void setBMS_ActID(string BMS_ActID){ 
	this.ActID = BMS_ActID;
}

public 
void setBMS_Seq(int BMS_Seq){ 
	this.Seq = BMS_Seq; 
}

public 
void setBMS_SubID(string BMS_SubID){ 
	this.SubID = BMS_SubID; 
}

public 
void setBMS_SubOrdNum(int BMS_SubOrdNum){ 
	this.SubOrdNum = BMS_SubOrdNum; 
}

public 
void setBMS_MethodRank(int BMS_MethodRank){ 
	this.MethodRank = BMS_MethodRank; 
}
	
public 
void setBMS_MatOrdNum(int BMS_MatOrdNum){ 
	this.MatOrdNum = BMS_MatOrdNum; 
}

public 
void setBMS_MatID(string BMS_MatID){ 
	this.MatID = BMS_MatID; 
}

public 
void setBMS_MatSeq(int BMS_MatSeq){ 
	this.MatSeq = BMS_MatSeq; 
}

public 
void setBMS_TLID(string BMS_TLID){ 
	this.TLID = BMS_TLID; 
}

public 
void setBMS_MatQty(decimal BMS_MatQty){ 
	this.MatQty = BMS_MatQty; 
}

public 
void setBMS_Uom(string BMS_Uom){ 
	this.Uom = BMS_Uom; 
}

public 
void setBMS_PrQty(decimal BMS_PrQty){ 
	this.PrQty = BMS_PrQty; 
}

public 
void setBMS_PrQtyUom(string BMS_PrQtyUom){ 
	this.PrQtyUom = BMS_PrQtyUom; 
}

public 
void setBMS_QtyPerInv(decimal BMS_QtyPerInv){ 
	this.QtyPerInv = BMS_QtyPerInv; 
}

public 
void setBMS_QtyPerUom(string BMS_QtyPerUom){ 
	this.QtyPerUom = BMS_QtyPerUom; 
}

public 
void setBMS_UsePer(string BMS_UsePer){ 
	this.UsePer = BMS_UsePer; 
}

public 
void setBMS_MatPer(decimal BMS_MatPer){ 
	this.MatPer = BMS_MatPer; 
}

public 
void setBMS_ScrapPer(decimal BMS_ScrapPer){ 
	this.ScrapPer = BMS_ScrapPer; 
}

public 
void setBMS_ScrapAmt(decimal BMS_ScrapAmt){ 
	this.ScrapAmt = BMS_ScrapAmt; 
}

public 
void setBMS_ScrapUnt(string BMS_ScrapUnt){ 
	this.ScrapUnt = BMS_ScrapUnt; 
}

public 
void setBMS_EcnCurr(string BMS_EcnCurr){ 
	this.EcnCurr = BMS_EcnCurr; 
}

public 
void setBMS_EcnFut(string BMS_EcnFut){ 
	this.EcnFut = BMS_EcnFut; 
}

public 
void setBMS_EcnFutDat(DateTime BMS_EcnFutDat){ 
	this.EcnFutDat = BMS_EcnFutDat; 
}

public 
void setBMS_BomSumYN(string BMS_BomSumYN){ 
	this.BomSumYN = BMS_BomSumYN; 
}

public 
void delete(){ 
	this._isDeleted = true;
}


public 
string getBMS_ProdID(){ 
	return ProdID; 
}

public
string getBMS_ActID(){ 
	return ActID; 
}

public 
int getBMS_Seq(){ 
	return Seq; 
}

public
string getBMS_SubID(){ 
	return SubID; 
}

public
int getBMS_SubOrdNum(){ 
	return SubOrdNum; 
}

public
int getBMS_MethodRank(){ 
	return MethodRank; 
}

public
int getBMS_MatOrdNum(){ 
	return MatOrdNum; 
}

public
string getBMS_MatID(){ 
	return MatID; 
}

public
int getBMS_MatSeq(){ 
	return MatSeq; 
}

public
string getBMS_TLID(){ 
	return TLID; 
}

public
decimal getBMS_MatQty(){ 
	return MatQty; 
}

public
string getBMS_Uom(){ 
	return Uom; 
}

public
decimal getBMS_PrQty(){ 
	return PrQty; 
}

public
string getBMS_PrQtyUom(){ 
	return PrQtyUom; 
}

public
decimal getBMS_QtyPerInv(){ 
	return QtyPerInv; 
}

public
string getBMS_QtyPerUom(){ 
	return QtyPerUom; 
}

public
string getBMS_UsePer(){ 
	return UsePer; 
}

public
decimal getBMS_MatPer(){ 
	return MatPer; 
}

public
decimal getBMS_ScrapPer(){ 
	return ScrapPer; 
}

public
decimal getBMS_ScrapAmt(){ 
	return ScrapAmt; 
}

public
string getBMS_ScrapUnt(){ 
	return ScrapUnt; 
}

public
string getBMS_EcnCurr(){ 
	return EcnCurr; 
}

public
string getBMS_EcnFut(){ 
	return EcnFut; 
}

public
DateTime getBMS_EcnFutDat(){ 
	return EcnFutDat; 
}

public
string getBMS_BomSumYN(){ 
	return BomSumYN; 
}

public
bool isDeleted(){ 
	return this._isDeleted; 
}

        

[System.Runtime.Serialization.DataMember]
public
string ProdID {
	get { return prodID;}
	set { if (this.prodID != value){
			this.prodID = value;
			Notify("ProdID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ActID {
	get { return actID;}
	set { if (this.actID != value){
			this.actID = value;
			Notify("ActID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq;}
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SubID {
	get { return subID;}
	set { if (this.subID != value){
			this.subID = value;
			Notify("SubID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SubOrdNum {
	get { return subOrdNum;}
	set { if (this.subOrdNum != value){
			this.subOrdNum = value;
			Notify("SubOrdNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MethodRank {
	get { return methodRank;}
	set { if (this.methodRank != value){
			this.methodRank = value;
			Notify("MethodRank");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MatOrdNum {
	get { return matOrdNum;}
	set { if (this.matOrdNum != value){
			this.matOrdNum = value;
			Notify("MatOrdNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MatID {
	get { return matID;}
	set { if (this.matID != value){
			this.matID = value;
			Notify("MatID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MatSeq {
	get { return matSeq;}
	set { if (this.matSeq != value){
			this.matSeq = value;
			Notify("MatSeq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TLID {
	get { return tLID;}
	set { if (this.tLID != value){
			this.tLID = value;
			Notify("TLID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MatQty {
	get { return matQty;}
	set { if (this.matQty != value){
			this.matQty = value;
			Notify("MatQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Uom {
	get { return uom;}
	set { if (this.uom != value){
			this.uom = value;
			Notify("Uom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PrQty {
	get { return prQty;}
	set { if (this.prQty != value){
			this.prQty = value;
			Notify("PrQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string PrQtyUom {
	get { return prQtyUom;}
	set { if (this.prQtyUom != value){
			this.prQtyUom = value;
			Notify("PrQtyUom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyPerInv {
	get { return qtyPerInv;}
	set { if (this.qtyPerInv != value){
			this.qtyPerInv = value;
			Notify("QtyPerInv");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string QtyPerUom {
	get { return qtyPerUom;}
	set { if (this.qtyPerUom != value){
			this.qtyPerUom = value;
			Notify("QtyPerUom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string UsePer {
	get { return usePer;}
	set { if (this.usePer != value){
			this.usePer = value;
			Notify("UsePer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MatPer {
	get { return matPer;}
	set { if (this.matPer != value){
			this.matPer = value;
			Notify("MatPer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ScrapPer {
	get { return scrapPer;}
	set { if (this.scrapPer != value){
			this.scrapPer = value;
			Notify("ScrapPer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ScrapAmt {
	get { return scrapAmt;}
	set { if (this.scrapAmt != value){
			this.scrapAmt = value;
			Notify("ScrapAmt");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ScrapUnt {
	get { return scrapUnt;}
	set { if (this.scrapUnt != value){
			this.scrapUnt = value;
			Notify("ScrapUnt");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EcnCurr {
	get { return ecnCurr;}
	set { if (this.ecnCurr != value){
			this.ecnCurr = value;
			Notify("EcnCurr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EcnFut {
	get { return ecnFut;}
	set { if (this.ecnFut != value){
			this.ecnFut = value;
			Notify("EcnFut");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EcnFutDat {
	get { return ecnFutDat;}
	set { if (this.ecnFutDat != value){
			this.ecnFutDat = value;
			Notify("EcnFutDat");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BomSumYN {
	get { return bomSumYN;}
	set { if (this.bomSumYN != value){
			this.bomSumYN = value;
			Notify("BomSumYN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MatDescShow {
	get { return matDescShow; }
	set { if (this.matDescShow != value){
			this.matDescShow = value;
			Notify("MatDescShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MatTypeShow {
	get { return matTypeShow; }
	set { if (this.matTypeShow != value){
			this.matTypeShow = value;
			Notify("MatTypeShow");
		}
	}
}

public
string MatTypeDescShow {
	get { return Constants.getMatTypeDesc(matTypeShow); }
	set {
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MatQohShow {
	get { return matQohShow; }
	set { if (this.matQohShow != value){
			this.matQohShow = value;
			Notify("MatQohShow");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is BomSum)
		return	this.prodID.Equals(((BomSum)obj).ProdID) &&
				this.seq.Equals(((BomSum)obj).Seq) &&
				this.matID.Equals(((BomSum)obj).MatID) &&
				this.matSeq.Equals(((BomSum)obj).MatSeq);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class

} // namespace