using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class InvPltDataBase : GenericDataBaseElement{

private string IP_Plt;
private string IP_ActID;
private int IP_Seq;
private string IP_ProdID;
private string IP_MasPrOrd;
private string IP_PrOrd;
private string IP_LotID;
private decimal IP_Qty;
private decimal IP_QtyAvail;
private string IP_Uom;
private decimal IP_Qty2;
private string IP_Uom2;
private DateTime IP_Dt;
private decimal IP_QtyAvail2;

public
InvPltDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.IP_Plt = reader.GetString("IP_Plt");
	this.IP_ActID = reader.GetString("IP_ActID");
	this.IP_Seq = reader.GetInt32("IP_Seq");
	this.IP_ProdID = reader.GetString("IP_ProdID");
	this.IP_MasPrOrd = reader.GetString("IP_MasPrOrd");
	this.IP_PrOrd = reader.GetString("IP_PrOrd");
	this.IP_LotID = reader.GetString("IP_LotID");
	this.IP_Qty = reader.GetDecimal("IP_Qty");
	this.IP_QtyAvail = reader.GetDecimal("IP_QtyAvail");
	this.IP_Uom = reader.GetString("IP_Uom");
	this.IP_Qty2 = reader.GetDecimal("IP_Qty2");
	this.IP_Uom2 = reader.GetString("IP_Uom2");
	this.IP_Dt = reader.GetDateTime("IP_Dt");
	this.IP_QtyAvail2 = reader.GetDecimal("IP_QtyAvail2");
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
void setIP_Plt(string IP_Plt){
	this.IP_Plt = IP_Plt;
}

public
void setIP_ActID(string IP_ActID){
	this.IP_ActID = IP_ActID;
}

public
void setIP_Seq(int IP_Seq){
	this.IP_Seq = IP_Seq;
}

public
void setIP_ProdID(string IP_ProdID){
	this.IP_ProdID = IP_ProdID;
}

public
void setIP_MasPrOrd(string IP_MasPrOrd){
	this.IP_MasPrOrd = IP_MasPrOrd;
}

public
void setIP_PrOrd(string IP_PrOrd){
	this.IP_PrOrd = IP_PrOrd;
}

public
void setIP_LotID(string IP_LotID){
	this.IP_LotID = IP_LotID;
}

public
void setIP_Qty(decimal IP_Qty){
	this.IP_Qty = IP_Qty;
}

public
void setIP_QtyAvail(decimal IP_QtyAvail){
	this.IP_QtyAvail = IP_QtyAvail;
}

public
void setIP_Uom(string IP_Uom){
	this.IP_Uom = IP_Uom;
}

public
void setIP_Qty2(decimal IP_Qty2){
	this.IP_Qty2 = IP_Qty2;
}

public
void setIP_Uom2(string IP_Uom2){
	this.IP_Uom2 = IP_Uom2;
}

public
void setIP_Dt(DateTime IP_Dt){
	this.IP_Dt = IP_Dt;
}

public
void setIP_QtyAvail2(decimal IP_QtyAvail2){
	this.IP_QtyAvail2 = IP_QtyAvail2;
}


public
string getIP_Plt(){
	return IP_Plt;
}

public
string getIP_ActID(){
	return IP_ActID;
}

public
int getIP_Seq(){
	return IP_Seq;
}

public
string getIP_ProdID(){
	return IP_ProdID;
}

public
string getIP_MasPrOrd(){
	return IP_MasPrOrd;
}

public
string getIP_PrOrd(){
	return IP_PrOrd;
}

public
string getIP_LotID(){
	return IP_LotID;
}

public
decimal getIP_Qty(){
	return IP_Qty;
}

public
decimal getIP_QtyAvail(){
	return IP_QtyAvail;
}

public
string getIP_Uom(){
	return IP_Uom;
}

public
decimal getIP_Qty2(){
	return IP_Qty2;
}

public
string getIP_Uom2(){
	return IP_Uom2;
}

public
DateTime getIP_Dt(){
	return IP_Dt;
}

public
decimal getIP_QtyAvail2(){
	return IP_QtyAvail2;
}


} // clas(){

} // namespac(){
