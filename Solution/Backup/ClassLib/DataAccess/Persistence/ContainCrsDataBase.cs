using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ContainCrsDataBase : GenericDataBaseElement{

private string CTN_Contain;
private string CTN_ContType;
private string CTN_ProdID;
private string CTN_State;
private decimal CTN_QtyPer;
private decimal CTN_Wgt;
private string CTN_Uom;
private string CTN_PackType;
private int CTN_PackPref;
private string CTN_PackPart;
private string CTN_NxLevCont;
private string CTN_CustID;
private decimal CTN_Vol;
private string CTN_VolUom;
private int CTN_Priority;
private decimal CTN_TmLoad;
private decimal CTN_TmUnload;
private int CTN_LoadPer;
private int CTN_UnloadPer;
private decimal CTN_StdFillPer;
private decimal CTN_QtyCont;
private decimal CTN_OnLine;
private decimal CTN_OffLine;

public
ContainCrsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.CTN_Contain = reader.GetString("CTN_Contain");
	this.CTN_ContType = reader.GetString("CTN_ContType");
	this.CTN_ProdID = reader.GetString("CTN_ProdID");
	this.CTN_State = reader.GetString("CTN_State");
	this.CTN_QtyPer = reader.GetDecimal("CTN_QtyPer");
	this.CTN_Wgt = reader.GetDecimal("CTN_Wgt");
	this.CTN_Uom = reader.GetString("CTN_Uom");
	this.CTN_PackType = reader.GetString("CTN_PackType");
	this.CTN_PackPref = reader.GetInt32("CTN_PackPref");
	this.CTN_PackPart = reader.GetString("CTN_PackPart");
	this.CTN_NxLevCont = reader.GetString("CTN_NxLevCont");
	this.CTN_CustID = reader.GetString("CTN_CustID");
	this.CTN_Vol = reader.GetDecimal("CTN_Vol");
	this.CTN_VolUom = reader.GetString("CTN_VolUom");
	this.CTN_Priority = reader.GetInt32("CTN_Priority");
	this.CTN_TmLoad = reader.GetDecimal("CTN_TmLoad");
	this.CTN_TmUnload = reader.GetDecimal("CTN_TmUnload");
	this.CTN_LoadPer = reader.GetInt32("CTN_LoadPer");
	this.CTN_UnloadPer = reader.GetInt32("CTN_UnloadPer");
	this.CTN_StdFillPer = reader.GetDecimal("CTN_StdFillPer");
	this.CTN_QtyCont = reader.GetDecimal("CTN_QtyCont");
	this.CTN_OnLine = reader.GetDecimal("CTN_OnLine");
	this.CTN_OffLine = reader.GetDecimal("CTN_OffLine");
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
void setCTN_Contain(string CTN_Contain){
	this.CTN_Contain = CTN_Contain;
}

public
void setCTN_ContType(string CTN_ContType){
	this.CTN_ContType = CTN_ContType;
}

public
void setCTN_ProdID(string CTN_ProdID){
	this.CTN_ProdID = CTN_ProdID;
}

public
void setCTN_State(string CTN_State){
	this.CTN_State = CTN_State;
}

public
void setCTN_QtyPer(decimal CTN_QtyPer){
	this.CTN_QtyPer = CTN_QtyPer;
}

public
void setCTN_Wgt(decimal CTN_Wgt){
	this.CTN_Wgt = CTN_Wgt;
}

public
void setCTN_Uom(string CTN_Uom){
	this.CTN_Uom = CTN_Uom;
}

public
void setCTN_PackType(string CTN_PackType){
	this.CTN_PackType = CTN_PackType;
}

public
void setCTN_PackPref(int CTN_PackPref){
	this.CTN_PackPref = CTN_PackPref;
}

public
void setCTN_PackPart(string CTN_PackPart){
	this.CTN_PackPart = CTN_PackPart;
}

public
void setCTN_NxLevCont(string CTN_NxLevCont){
	this.CTN_NxLevCont = CTN_NxLevCont;
}

public
void setCTN_CustID(string CTN_CustID){
	this.CTN_CustID = CTN_CustID;
}

public
void setCTN_Vol(decimal CTN_Vol){
	this.CTN_Vol = CTN_Vol;
}

public
void setCTN_VolUom(string CTN_VolUom){
	this.CTN_VolUom = CTN_VolUom;
}

public
void setCTN_Priority(int CTN_Priority){
	this.CTN_Priority = CTN_Priority;
}

public
void setCTN_TmLoad(decimal CTN_TmLoad){
	this.CTN_TmLoad = CTN_TmLoad;
}

public
void setCTN_TmUnload(decimal CTN_TmUnload){
	this.CTN_TmUnload = CTN_TmUnload;
}

public
void setCTN_LoadPer(int CTN_LoadPer){
	this.CTN_LoadPer = CTN_LoadPer;
}

public
void setCTN_UnloadPer(int CTN_UnloadPer){
	this.CTN_UnloadPer = CTN_UnloadPer;
}

public
void setCTN_StdFillPer(decimal CTN_StdFillPer){
	this.CTN_StdFillPer = CTN_StdFillPer;
}

public
void setCTN_QtyCont(decimal CTN_QtyCont){
	this.CTN_QtyCont = CTN_QtyCont;
}

public
void setCTN_OnLine(decimal CTN_OnLine){
	this.CTN_OnLine = CTN_OnLine;
}

public
void setCTN_OffLine(decimal CTN_OffLine){
	this.CTN_OffLine = CTN_OffLine;
}


public
string getCTN_Contain(){
	return CTN_Contain;
}

public
string getCTN_ContType(){
	return CTN_ContType;
}

public
string getCTN_ProdID(){
	return CTN_ProdID;
}

public
string getCTN_State(){
	return CTN_State;
}

public
decimal getCTN_QtyPer(){
	return CTN_QtyPer;
}

public
decimal getCTN_Wgt(){
	return CTN_Wgt;
}

public
string getCTN_Uom(){
	return CTN_Uom;
}

public
string getCTN_PackType(){
	return CTN_PackType;
}

public
int getCTN_PackPref(){
	return CTN_PackPref;
}

public
string getCTN_PackPart(){
	return CTN_PackPart;
}

public
string getCTN_NxLevCont(){
	return CTN_NxLevCont;
}

public
string getCTN_CustID(){
	return CTN_CustID;
}

public
decimal getCTN_Vol(){
	return CTN_Vol;
}

public
string getCTN_VolUom(){
	return CTN_VolUom;
}

public
int getCTN_Priority(){
	return CTN_Priority;
}

public
decimal getCTN_TmLoad(){
	return CTN_TmLoad;
}

public
decimal getCTN_TmUnload(){
	return CTN_TmUnload;
}

public
int getCTN_LoadPer(){
	return CTN_LoadPer;
}

public
int getCTN_UnloadPer(){
	return CTN_UnloadPer;
}

public
decimal getCTN_StdFillPer(){
	return CTN_StdFillPer;
}

public
decimal getCTN_QtyCont(){
	return CTN_QtyCont;
}

public
decimal getCTN_OnLine(){
	return CTN_OnLine;
}

public
decimal getCTN_OffLine(){
	return CTN_OffLine;
}


} // class

} // namespace