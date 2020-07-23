using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchPrFmShfDataBase : GenericDataBaseElement{

private string SPS_SchVersion;
private string SPS_ProdID;
private string SPS_ActID;
private int SPS_Seq;
private DateTime SPS_Dt;
private string SPS_Shf;
private string SPS_MasPrOrd;
private decimal SPS_Qty;
private decimal SPS_QtyPr;
private decimal SPS_Hr;
private decimal SPS_HrPr;
private decimal SPS_Contain;
private string SPS_ConType;
private decimal SPS_Racks;
private string SPS_RackType;

public
SchPrFmShfDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SPS_SchVersion = reader.GetString("SPS_SchVersion");
	this.SPS_ProdID = reader.GetString("SPS_ProdID");
	this.SPS_ActID = reader.GetString("SPS_ActID");
	this.SPS_Seq = reader.GetInt32("SPS_Seq");
	this.SPS_Dt = reader.GetDateTime("SPS_Dt");
	this.SPS_Shf = reader.GetString("SPS_Shf");
	this.SPS_MasPrOrd = reader.GetString("SPS_MasPrOrd");
	this.SPS_Qty = reader.GetDecimal("SPS_Qty");
	this.SPS_QtyPr = reader.GetDecimal("SPS_QtyPr");
	this.SPS_Hr = reader.GetDecimal("SPS_Hr");
	this.SPS_HrPr = reader.GetDecimal("SPS_HrPr");
	this.SPS_Contain = reader.GetDecimal("SPS_Contain");
	this.SPS_ConType = reader.GetString("SPS_ConType");
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
void setSPS_ProdID(string SPS_ProdID){
	this.SPS_ProdID = SPS_ProdID;
}
public
void setSPS_ActID(string SPS_ActID){
	this.SPS_ActID = SPS_ActID;
}
public
void setSPS_Seq(int SPS_Seq){
	this.SPS_Seq = SPS_Seq;
}
public
void setSPS_Dt(DateTime SPS_Dt){
	this.SPS_Dt = SPS_Dt;
}
public
void setSPS_Shf(string SPS_Shf){
	this.SPS_Shf = SPS_Shf;
}
public
void setSPS_MasPrOrd(string SPS_MasPrOrd){
	this.SPS_MasPrOrd = SPS_MasPrOrd;
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
void setSPS_ConType(string SPS_ConType){
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
string getSPS_ProdID(){
	return SPS_ProdID;
}

public
string getSPS_ActID(){
	return SPS_ActID;
}

public
int getSPS_Seq(){
	return SPS_Seq;
}

public
DateTime getSPS_Dt(){
	return SPS_Dt;
}

public
string getSPS_Shf(){
	return SPS_Shf;
}

public
string getSPS_MasPrOrd(){
	return SPS_MasPrOrd;
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
string getSPS_ConType(){
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