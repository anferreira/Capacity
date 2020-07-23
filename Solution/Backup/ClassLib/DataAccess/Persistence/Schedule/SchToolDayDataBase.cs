using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchToolDayDataBase : GenericDataBaseElement{

private string Sch_TLID;
private DateTime Sch_Dt;
private decimal Sch_Qty;
private decimal Sch_Cycles;
private decimal Sch_Hr;

public
SchToolDayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.Sch_TLID = reader.GetString("Sch_TLID");
	this.Sch_Dt = reader.GetDateTime("Sch_Dt");
	this.Sch_Qty = reader.GetDecimal("Sch_Qty");
	this.Sch_Cycles = reader.GetDecimal("Sch_Cycles");
	this.Sch_Hr = reader.GetDecimal("Sch_Hr");
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
void setSch_TLID(string Sch_TLID){
	this.Sch_TLID = Sch_TLID;
}

public
void setSch_Dt(DateTime Sch_Dt){
	this.Sch_Dt = Sch_Dt;
}

public
void setSch_Qty(decimal Sch_Qty){
	this.Sch_Qty = Sch_Qty;
}

public
void setSch_Cycles(decimal Sch_Cycles){
	this.Sch_Cycles = Sch_Cycles;
}

public
void setSch_Hr(decimal Sch_Hr){
	this.Sch_Hr = Sch_Hr;
}

public
string getSch_TLID(){
	return Sch_TLID;
}

public
DateTime getSch_Dt(){
	return Sch_Dt;
}

public
decimal getSch_Qty(){
	return Sch_Qty;
}

public
decimal getSch_Cycles(){
	return Sch_Cycles;
}

public
decimal getSch_Hr(){
	return Sch_Hr;
}


} // class

} // namespace