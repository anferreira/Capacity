using System;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class MaterialDueDate : CumulativeInventory{

private decimal ent8;
private decimal ent9;
private decimal ent10;
private decimal ent11;
private decimal ent12;
private decimal ent13;
private decimal ent14;

public
MaterialDueDate(string supplier, string product, int seq, string description,
		decimal pastDue, decimal ent1,
		decimal ent2, decimal ent3, decimal ent4, decimal ent5,
		decimal ent6, decimal ent7, decimal ent8, decimal ent9, decimal ent10, 
		decimal ent11, decimal ent12, decimal ent13, decimal ent14) : base(supplier, product, 
				seq, description, pastDue, ent1, ent2, ent3, ent4, ent5, ent6, ent7){
}

public
void setEnt8(decimal ent8){
	this.ent8 = ent8;
}

public
void setEnt9(decimal ent9){
	this.ent9 = ent9;
}

public
void setEnt10(decimal ent10){
	this.ent10 = ent10;
}

public
void setEnt11(decimal ent11){
	this.ent11 = ent11;
}

public
void setEnt12(decimal ent12){
	this.ent12 = ent12;
}

public
void setEnt13(decimal ent13){
	this.ent13 = ent13;
}

public
void setEnt14(decimal ent14){
	this.ent14 = ent14;
}


public
decimal getEnt8(){
	return ent8;
}

public
decimal getEnt9(){
	return ent9;
}

public
decimal getEnt10(){
	return ent10;
}

public
decimal getEnt11(){
	return ent11;
}

public
decimal getEnt12(){
	return ent12;
}

public
decimal getEnt13(){
	return ent13;
}

public
decimal getEnt14(){
	return ent14;
}

} // class

} // namespace
