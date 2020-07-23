using System;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class CumulativeInventory{

private string supplier;
private string product;
private int seq;
private string description;
private decimal pastDue;
private decimal ent1;
private decimal ent2;
private decimal ent3;
private decimal ent4;
private decimal ent5;
private decimal ent6;
private decimal ent7;

public
CumulativeInventory(string supplier, string product, int seq, string description,
		decimal pastDue, decimal ent1, decimal ent2, decimal ent3, decimal ent4, 
		decimal ent5, decimal ent6, decimal ent7){

	this.supplier = supplier;
	this.product = product;
	this.seq = seq;
	this.description = description;
	this.pastDue = pastDue;
	this.ent1 = ent1;
	this.ent2 = ent2;
	this.ent3 = ent3;
	this.ent4 = ent4;
	this.ent5 = ent5;
	this.ent6 = ent6;
	this.ent7 = ent7;
}

public
void setSupplier(string supplier){
	this.supplier = supplier;
}

public
void setProduct(string product){
	this.product = product;
}

public
void setSeq(int seq){
	this.seq = seq;
}

public
void setDescription(string description){
	this.description = description;
}

public
void setPastDue(decimal pastDue){
	this.pastDue = pastDue;
}

public
void setEnt1(decimal ent1){
	this.ent1 = ent1;
}

public
void setEnt2(decimal ent2){
	this.ent2 = ent2;
}

public
void setEnt3(decimal ent3){
	this.ent3 = ent3;
}

public
void setEnt4(decimal ent4){
	this.ent4 = ent4;
}

public
void setEnt5(decimal ent5){
	this.ent5 = ent5;
}

public
void setEnt6(decimal ent6){
	this.ent6 = ent6;
}

public
void setEnt7(decimal ent7){
	this.ent7 = ent7;
}


public
string getSupplier(){
	return supplier;
}

public
string getProduct(){
	return product;
}

public
int getSeq(){
	return seq;
}

public
string getDescription(){
	return description;
}

public
decimal getPastDue(){
	return pastDue;
}

public
decimal getEnt1(){
	return ent1;
}

public
decimal getEnt2(){
	return ent2;
}

public
decimal getEnt3(){
	return ent3;
}

public
decimal getEnt4(){
	return ent4;
}

public
decimal getEnt5(){
	return ent5;
}

public
decimal getEnt6(){
	return ent6;
}

public
decimal getEnt7(){
	return ent7;
}

} // class

} // namespace
