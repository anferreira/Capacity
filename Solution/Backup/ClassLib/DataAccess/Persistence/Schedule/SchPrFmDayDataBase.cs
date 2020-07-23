using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrFmDayDataBase : GenericDataBaseElement{

private string SPS_SchVersion;
private string SPS_Plt;
private string SPD_ProdID;
private string SPD_ActID;
private int SPD_Seq;
private DateTime SPD_Dt;
private string SPS_MasPrOrd;
private string SPS_TmType;
private decimal SPS_Qty;
private decimal SPS_QtyPr;
private decimal SPS_Hr;
private decimal SPS_HrPr;
private decimal SPS_Contain;
private decimal SPS_ConType;
private decimal SPS_Racks;
private string SPS_RackType;

public
SchPrFmDayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SPS_SchVersion = reader.GetString("SPS_SchVersion");
	this.SPS_Plt = reader.GetString("SPS_Plt");
	this.SPD_ProdID = reader.GetString("SPD_ProdID");
	this.SPD_ActID = reader.GetString("SPD_ActID");
	this.SPD_Seq = reader.GetInt32("SPD_Seq");
	this.SPD_Dt = reader.GetDateTime("SPD_Dt");
	this.SPS_MasPrOrd = reader.GetString("SPS_MasPrOrd");
	this.SPS_TmType = reader.GetString("SPS_TmType");
	this.SPS_Qty = reader.GetDecimal("SPS_Qty");
	this.SPS_QtyPr = reader.GetDecimal("SPS_QtyPr");
	this.SPS_Hr = reader.GetDecimal("SPS_Hr");
	this.SPS_HrPr = reader.GetDecimal("SPS_HrPr");
	this.SPS_Contain = reader.GetDecimal("SPS_Contain");
	this.SPS_ConType = reader.GetDecimal("SPS_ConType");
	this.SPS_Racks = reader.GetDecimal("SPS_Racks");
	this.SPS_RackType = reader.GetString("SPS_RackType");
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
void setSPS_SchVersion(string SPS_SchVersion){
	this.SPS_SchVersion = SPS_SchVersion;
}

public
void setSPS_Plt(string SPS_Plt){
	this.SPS_Plt = SPS_Plt;
}

public
void setSPD_ProdID(string SPD_ProdID){
	this.SPD_ProdID = SPD_ProdID;
}

public
void setSPD_ActID(string SPD_ActID){
	this.SPD_ActID = SPD_ActID;
}

public
void setSPD_Seq(int SPD_Seq){
	this.SPD_Seq = SPD_Seq;
}

public
void setSPD_Dt(DateTime SPD_Dt){
	this.SPD_Dt = SPD_Dt;
}

public
void setSPS_MasPrOrd(string SPS_MasPrOrd){
	this.SPS_MasPrOrd = SPS_MasPrOrd;
}

public
void setSPS_TmType(string SPS_TmType){
	this.SPS_TmType = SPS_TmType;
}

public
void setSPS_Qty(decimal SPS_Qty){
	this.SPS_Qty = SPS_Qty;
}

public
void setSPS_QtyPr(decimal SPS_QtyPr){
	this.SPS_QtyPr = SPS_QtyPr;
}

public
void setSPS_Hr(decimal SPS_Hr){
	this.SPS_Hr = SPS_Hr;
}

public
void setSPS_HrPr(decimal SPS_HrPr){
	this.SPS_HrPr = SPS_HrPr;
}

public
void setSPS_Contain(decimal SPS_Contain){
	this.SPS_Contain = SPS_Contain;
}

public
void setSPS_ConType(decimal SPS_ConType){
	this.SPS_ConType = SPS_ConType;
}

public
void setSPS_Racks(decimal SPS_Racks){
	this.SPS_Racks = SPS_Racks;
}

public
void setSPS_RackType(string SPS_RackType){
	this.SPS_RackType = SPS_RackType;
}


public
string getSPS_SchVersion(){
	return SPS_SchVersion;
}

public
string getSPS_Plt(){
	return SPS_Plt;
}

public
string getSPD_ProdID(){
	return SPD_ProdID;
}

public
string getSPD_ActID(){
	return SPD_ActID;
}

public
int getSPD_Seq(){
	return SPD_Seq;
}

public
DateTime getSPD_Dt(){
	return SPD_Dt;
}

public
string getSPS_MasPrOrd(){
	return SPS_MasPrOrd;
}

public
string getSPS_TmType(){
	return SPS_TmType;
}

public
decimal getSPS_Qty(){
	return SPS_Qty;
}

public
decimal getSPS_QtyPr(){
	return SPS_QtyPr;
}

public
decimal getSPS_Hr(){
	return SPS_Hr;
}

public
decimal getSPS_HrPr(){
	return SPS_HrPr;
}

public
decimal getSPS_Contain(){
	return SPS_Contain;
}

public
decimal getSPS_ConType(){
	return SPS_ConType;
}

public
decimal getSPS_Racks(){
	return SPS_Racks;
}

public
string getSPS_RackType(){
	return SPS_RackType;
}

} // class

} // namespace