using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchToolWkDataBase : GenericDataBaseElement{

private string Sch_Version;
private string Sch_TLID;
private int Sch_WkAcc;
private int Sch_WkPr;
private decimal Sch_Qty;
private decimal Sch_Hr;
private decimal Sch_Cycles;

public
SchToolWkDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.Sch_Version = reader.GetString("Sch_Version");
	this.Sch_TLID = reader.GetString("Sch_TLID");
	this.Sch_WkAcc = reader.GetInt32("Sch_WkAcc");
	this.Sch_WkPr = reader.GetInt32("Sch_WkPr");
	this.Sch_Qty = reader.GetDecimal("Sch_Qty");
	this.Sch_Hr = reader.GetDecimal("Sch_Hr");
	this.Sch_Cycles = reader.GetDecimal("Sch_Cycles");
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
void setSch_Version(string Sch_Version){
	this.Sch_Version = Sch_Version;
}

public
void setSch_TLID(string Sch_TLID){
	this.Sch_TLID = Sch_TLID;
}

public
void setSch_WkAcc(int Sch_WkAcc){
	this.Sch_WkAcc = Sch_WkAcc;
}

public
void setSch_WkPr(int Sch_WkPr){
	this.Sch_WkPr = Sch_WkPr;
}

public
void setSch_Qty(decimal Sch_Qty){
	this.Sch_Qty = Sch_Qty;
}

public
void setSch_Hr(decimal Sch_Hr){
	this.Sch_Hr = Sch_Hr;
}

public
void setSch_Cycles(decimal Sch_Cycles){
	this.Sch_Cycles = Sch_Cycles;
}


public
string getSch_Version(){
	return Sch_Version;
}

public
string getSch_TLID(){
	return Sch_TLID;
}

public
int getSch_WkAcc(){
	return Sch_WkAcc;
}

public
int getSch_WkPr(){
	return Sch_WkPr;
}

public
decimal getSch_Qty(){
	return Sch_Qty;
}

public
decimal getSch_Hr(){
	return Sch_Hr;
}

public
decimal getSch_Cycles(){
	return Sch_Cycles;
}


} // class

} // namespace