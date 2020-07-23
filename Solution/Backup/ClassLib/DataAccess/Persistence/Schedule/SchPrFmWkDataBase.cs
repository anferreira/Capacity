using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrFmWkDataBase : GenericDataBaseElement{

private string SPW_SchVersion;
private string SPW_Plt;
private string SPW_ProdID;
private string SPW_ActID;
private int SPW_Seq;
private int SPW_WkAcc;
private int SPW_WkPr;
private string SPW_TmType;
private decimal SPW_Qty;
private decimal SPW_QtyPr;
private decimal SPW_Hr;
private decimal SPW_HrPr;
private decimal SPW_Contain;
private string SPW_ConType;
private decimal SPW_Racks;
private string SPW_RackType;

public
SchPrFmWkDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SPW_SchVersion = reader.GetString("SPW_SchVersion");
	this.SPW_Plt = reader.GetString("SPW_Plt");
	this.SPW_ProdID = reader.GetString("SPW_ProdID");
	this.SPW_ActID = reader.GetString("SPW_ActID");
	this.SPW_Seq = reader.GetInt32("SPW_Seq");
	this.SPW_WkAcc = reader.GetInt32("SPW_WkAcc");
	this.SPW_WkPr = reader.GetInt32("SPW_WkPr");
	this.SPW_TmType = reader.GetString("SPW_TmType");
	this.SPW_Qty = reader.GetDecimal("SPW_Qty");
	this.SPW_QtyPr = reader.GetDecimal("SPW_QtyPr");
	this.SPW_Hr = reader.GetDecimal("SPW_Hr");
	this.SPW_HrPr = reader.GetDecimal("SPW_HrPr");
	this.SPW_Contain = reader.GetDecimal("SPW_Contain");
	this.SPW_ConType = reader.GetString("SPW_ConType");
	this.SPW_Racks = reader.GetDecimal("SPW_Racks");
	this.SPW_RackType = reader.GetString("SPW_RackType");
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
void setSPW_SchVersion(string SPW_SchVersion){
	this.SPW_SchVersion = SPW_SchVersion;
}

public
void setSPW_Plt(string SPW_Plt){
	this.SPW_Plt = SPW_Plt;
}

public
void setSPW_ProdID(string SPW_ProdID){
	this.SPW_ProdID = SPW_ProdID;
}

public
void setSPW_ActID(string SPW_ActID){
	this.SPW_ActID = SPW_ActID;
}

public
void setSPW_Seq(int SPW_Seq){
	this.SPW_Seq = SPW_Seq;
}

public
void setSPW_WkAcc(int SPW_WkAcc){
	this.SPW_WkAcc = SPW_WkAcc;
}

public
void setSPW_WkPr(int SPW_WkPr){
	this.SPW_WkPr = SPW_WkPr;
}

public
void setSPW_TmType(string SPW_TmType){
	this.SPW_TmType = SPW_TmType;
}

public
void setSPW_Qty(decimal SPW_Qty){
	this.SPW_Qty = SPW_Qty;
}

public
void setSPW_QtyPr(decimal SPW_QtyPr){
	this.SPW_QtyPr = SPW_QtyPr;
}

public
void setSPW_Hr(decimal SPW_Hr){
	this.SPW_Hr = SPW_Hr;
}

public
void setSPW_HrPr(decimal SPW_HrPr){
	this.SPW_HrPr = SPW_HrPr;
}

public
void setSPW_Contain(decimal SPW_Contain){
	this.SPW_Contain = SPW_Contain;
}

public
void setSPW_ConType(string SPW_ConType){
	this.SPW_ConType = SPW_ConType;
}

public
void setSPW_Racks(decimal SPW_Racks){
	this.SPW_Racks = SPW_Racks;
}

public
void setSPW_RackType(string SPW_RackType){
	this.SPW_RackType = SPW_RackType;
}


public
string getSPW_SchVersion(){
	return SPW_SchVersion;
}

public
string getSPW_Plt(){
	return SPW_Plt;
}

public
string getSPW_ProdID(){
	return SPW_ProdID;
}

public
string getSPW_ActID(){
	return SPW_ActID;
}

public
int getSPW_Seq(){
	return SPW_Seq;
}

public
int getSPW_WkAcc(){
	return SPW_WkAcc;
}

public
int getSPW_WkPr(){
	return SPW_WkPr;
}

public
string getSPW_TmType(){
	return SPW_TmType;
}

public
decimal getSPW_Qty(){
	return SPW_Qty;
}

public
decimal getSPW_QtyPr(){
	return SPW_QtyPr;
}

public
decimal getSPW_Hr(){
	return SPW_Hr;
}

public
decimal getSPW_HrPr(){
	return SPW_HrPr;
}

public
decimal getSPW_Contain(){
	return SPW_Contain;
}

public
string getSPW_ConType(){
	return SPW_ConType;
}

public
decimal getSPW_Racks(){
	return SPW_Racks;
}

public
string getSPW_RackType(){
	return SPW_RackType;
}


} // class

} // namespace