using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class InvPltLocPrjDataBase : GenericDataBaseElement{

private string ILP_Plt;
private string ILP_PltLoc;
private string ILP_ProdID;
private string ILP_ActID;
private int ILP_Seq;
private string ILP_LotID;
private string ILP_MasPrOrd;
private string ILP_PrOrd;
private DateTime IPL_Dt;
private decimal ILP_QtyStr;
private decimal ILP_QtyAvailStr;
private decimal IPL_QtyReworkStr;
private DateTime IPL_DtTmStr;
private string ILP_Uom;
private string IPL_TmRes;

public
InvPltLocPrjDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ILP_Plt = reader.GetString("ILP_Plt");
	this.ILP_PltLoc = reader.GetString("ILP_PltLoc");
	this.ILP_ProdID = reader.GetString("ILP_ProdID");
	this.ILP_ActID = reader.GetString("ILP_ActID");
	this.ILP_Seq = reader.GetInt32("ILP_Seq");
	this.ILP_LotID = reader.GetString("ILP_LotID");
	this.ILP_MasPrOrd = reader.GetString("ILP_MasPrOrd");
	this.ILP_PrOrd = reader.GetString("ILP_PrOrd");
	this.IPL_Dt = reader.GetDateTime("IPL_Dt");
	this.ILP_QtyStr = reader.GetDecimal("ILP_QtyStr");
	this.ILP_QtyAvailStr = reader.GetDecimal("ILP_QtyAvailStr");
	this.IPL_QtyReworkStr = reader.GetDecimal("IPL_QtyReworkStr");
	this.IPL_DtTmStr = reader.GetDateTime("IPL_DtTmStr");
	this.ILP_Uom = reader.GetString("ILP_Uom");
	this.IPL_TmRes = reader.GetString("IPL_TmRes");
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
void setILP_Plt(string ILP_Plt){
	this.ILP_Plt = ILP_Plt;
}

public
void setILP_PltLoc(string ILP_PltLoc){
	this.ILP_PltLoc = ILP_PltLoc;
}

public
void setILP_ProdID(string ILP_ProdID){
	this.ILP_ProdID = ILP_ProdID;
}

public
void setILP_ActID(string ILP_ActID){
	this.ILP_ActID = ILP_ActID;
}

public
void setILP_Seq(int ILP_Seq){
	this.ILP_Seq = ILP_Seq;
}

public
void setILP_LotID(string ILP_LotID){
	this.ILP_LotID = ILP_LotID;
}

public
void setILP_MasPrOrd(string ILP_MasPrOrd){
	this.ILP_MasPrOrd = ILP_MasPrOrd;
}

public
void setILP_PrOrd(string ILP_PrOrd){
	this.ILP_PrOrd = ILP_PrOrd;
}

public
void setIPL_Dt(DateTime IPL_Dt){
	this.IPL_Dt = IPL_Dt;
}

public
void setILP_QtyStr(decimal ILP_QtyStr){
	this.ILP_QtyStr = ILP_QtyStr;
}

public
void setILP_QtyAvailStr(decimal ILP_QtyAvailStr){
	this.ILP_QtyAvailStr = ILP_QtyAvailStr;
}

public
void setIPL_QtyReworkStr(decimal IPL_QtyReworkStr){
	this.IPL_QtyReworkStr = IPL_QtyReworkStr;
}

public
void setIPL_DtTmStr(DateTime IPL_DtTmStr){
	this.IPL_DtTmStr = IPL_DtTmStr;
}

public
void setILP_Uom(string ILP_Uom){
	this.ILP_Uom = ILP_Uom;
}

public
void setIPL_TmRes(string IPL_TmRes){
	this.IPL_TmRes = IPL_TmRes;
}


public
string getILP_Plt(){
	return ILP_Plt;
}

public
string getILP_PltLoc(){
	return ILP_PltLoc;
}

public
string getILP_ProdID(){
	return ILP_ProdID;
}

public
string getILP_ActID(){
	return ILP_ActID;
}

public
int getILP_Seq(){
	return ILP_Seq;
}

public
string getILP_LotID(){
	return ILP_LotID;
}

public
string getILP_MasPrOrd(){
	return ILP_MasPrOrd;
}

public
string getILP_PrOrd(){
	return ILP_PrOrd;
}

public
DateTime getIPL_Dt(){
	return IPL_Dt;
}

public
decimal getILP_QtyStr(){
	return ILP_QtyStr;
}

public
decimal getILP_QtyAvailStr(){
	return ILP_QtyAvailStr;
}

public
decimal getIPL_QtyReworkStr(){
	return IPL_QtyReworkStr;
}

public
DateTime getIPL_DtTmStr(){
	return IPL_DtTmStr;
}

public
string getILP_Uom(){
	return ILP_Uom;
}

public
string getIPL_TmRes(){
	return IPL_TmRes;
}


} // clas(){

} // namespac(){
