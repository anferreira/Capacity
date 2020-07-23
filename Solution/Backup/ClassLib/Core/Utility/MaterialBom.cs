using System;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class MaterialBom{

private string dept;
private string prodId;
private int seq;
private string prodType;
private DateTime dateShip;
private decimal qty;
private decimal qoh;

public
MaterialBom(){
	this.dept = "";
	this.prodId = "";
	this.seq = 0;
	this.dateShip = DateTime.Now;
	this.qty = 0;
	this.qoh = 0;
	this.prodType = "P";
}

public
MaterialBom(string dept, string prodId, int seq, DateTime dateShip, decimal qty, decimal qoh, string prodType){
	this.dept = dept;
	this.prodId = prodId;
	this.seq = seq;
	this.dateShip = dateShip;
	this.qty = qty;
	this.qoh = qoh;
	this.prodType = prodType;
}

public
MaterialBom(MaterialBom copy){
	this.dept = copy.dept;
	this.prodId = copy.prodId;
	this.seq = copy.seq;
	this.dateShip = copy.dateShip;
	this.qty = copy.qty;
	this.qoh = copy.qoh;
	this.prodType = copy.prodType;
}

public
void setDept(string dept){
	this.dept = dept;
}

public
void setProdId(string prodId){
	this.prodId = prodId;
}

public
void setSeq(int seq){
	this.seq = seq;
}

public
void setDateShip(DateTime dateShip){
	this.dateShip = dateShip;
}

public
void setQty(decimal qty){
	this.qty = qty;
}

public
void setQoh(decimal qoh){
	this.qoh = qoh;
}

public
void setProdType(string prodType){
	this.prodType = prodType;
}


public
string getDept(){
	return dept;
}

public
string getProdId(){
	return prodId;
}

public
int getSeq(){
	return seq;
}

public
DateTime getDateShip(){
	return dateShip;
}

public
decimal getQty(){
	return qty;
}

public
decimal getQoh(){
	return qoh;
}

public
string getProdType(){
	return prodType;
}

} // class

} // namespace
