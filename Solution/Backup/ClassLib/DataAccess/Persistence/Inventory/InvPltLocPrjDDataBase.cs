using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class InvPltLocPrjDDataBase : GenericDataBaseElement{

private string IPLD_Plt;
private string IPLD_Mach;
private string IPLD_ProdID;
private string IPLD_ActID;
private int IPLD_Seq;
private DateTime IPLD_Dt;
private decimal IPLD_DlyOrdID;
private decimal IPLD_Qty;
private decimal IPLD_QtyCml;
private string IPLD_TmRes;
private string IPLD_RecType;

public
InvPltLocPrjDDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.IPLD_Plt = reader.GetString("IPLD_Plt");
	this.IPLD_Mach = reader.GetString("IPLD_Mach");
	this.IPLD_ProdID = reader.GetString("IPLD_ProdID");
	this.IPLD_ActID = reader.GetString("IPLD_ActID");
	this.IPLD_Seq = reader.GetInt32("IPLD_Seq");
	this.IPLD_Dt = reader.GetDateTime("IPLD_Dt");
	this.IPLD_DlyOrdID = reader.GetDecimal("IPLD_DlyOrdID");
	this.IPLD_Qty = reader.GetDecimal("IPLD_Qty");
	this.IPLD_QtyCml = reader.GetDecimal("IPLD_QtyCml");
	this.IPLD_TmRes = reader.GetString("IPLD_TmRes");
	this.IPLD_RecType = reader.GetString("IPLD_RecType");
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
void setIPLD_Plt(string IPLD_Plt){
	this.IPLD_Plt = IPLD_Plt;
}

public
void setIPLD_Mach(string IPLD_Mach){
	this.IPLD_Mach = IPLD_Mach;
}

public
void setIPLD_ProdID(string IPLD_ProdID){
	this.IPLD_ProdID = IPLD_ProdID;
}

public
void setIPLD_ActID(string IPLD_ActID){
	this.IPLD_ActID = IPLD_ActID;
}

public
void setIPLD_Seq(int IPLD_Seq){
	this.IPLD_Seq = IPLD_Seq;
}

public
void setIPLD_Dt(DateTime IPLD_Dt){
	this.IPLD_Dt = IPLD_Dt;
}

public
void setIPLD_DlyOrdID(decimal IPLD_DlyOrdID){
	this.IPLD_DlyOrdID = IPLD_DlyOrdID;
}

public
void setIPLD_Qty(decimal IPLD_Qty){
	this.IPLD_Qty = IPLD_Qty;
}

public
void setIPLD_QtyCml(decimal IPLD_QtyCml){
	this.IPLD_QtyCml = IPLD_QtyCml;
}

public
void setIPLD_TmRes(string IPLD_TmRes){
	this.IPLD_TmRes = IPLD_TmRes;
}

public
void setIPLD_RecType(string IPLD_RecType){
	this.IPLD_RecType = IPLD_RecType;
}

public
string getIPLD_Plt(){
	return IPLD_Plt;
}

public
string getIPLD_Mach(){
	return IPLD_Mach;
}

public
string getIPLD_ProdID(){
	return IPLD_ProdID;
}

public
string getIPLD_ActID(){
	return IPLD_ActID;
}

public
int getIPLD_Seq(){
	return IPLD_Seq;
}

public
DateTime getIPLD_Dt(){
	return IPLD_Dt;
}

public
decimal getIPLD_DlyOrdID(){
	return IPLD_DlyOrdID;
}

public
decimal getIPLD_Qty(){
	return IPLD_Qty;
}

public
decimal getIPLD_QtyCml(){
	return IPLD_QtyCml;
}

public
string getIPLD_TmRes(){
	return IPLD_TmRes;
}

public
string getIPLD_RecType(){
	return IPLD_RecType;
}


} // clas(){

} // namespac(){
