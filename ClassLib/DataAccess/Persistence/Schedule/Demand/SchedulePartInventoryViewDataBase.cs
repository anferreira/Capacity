/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class SchedulePartInventoryViewDataBase : GenericDataBaseElement {

private string Type;
private string Part;
private int Seq;
private decimal RecQty;
private decimal RepQty;
private DateTime RecDate;
private string Des1;


public
SchedulePartInventoryViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
    return false;
}

public
bool exists(){
	return false;
}

public override
void load(NotNullDataReader reader){
    this.Type = reader.GetString("Type");
    this.Part = reader.GetString("Part");
    this.Seq = reader.GetInt32("Seq");
    this.RecQty = reader.GetDecimal("RecQty");
    this.RepQty = reader.GetDecimal("RepQty");
    this.RecDate = reader.GetDateTime("RecDate");            
    this.Des1 = reader.GetString("Des1");
}

public override
void write(){ 	
}

public override
void update(){	
}

public override
void delete(){
	
}

public
void setType(string Type){
	this.Type = Type;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setSeq(int Seq){
	this.Seq = Seq;
}

public
void setRecQty(decimal RecQty){
	this.RecQty = RecQty;
}

public
void setRepQty(decimal RepQty){
	this.RepQty = RepQty;
}

public
void setRecDate(DateTime RecDate){
	this.RecDate = RecDate;
}

public
void setDes1(string Des1){
	this.Des1 = Des1;
}

public
string getType(){
	return Type;
}

public
string getPart(){
	return Part;
}

public
int getSeq(){
    return Seq;
}

public
decimal getRecQty(){
    return RecQty;
}

public
decimal getRepQty(){
	return RepQty;
}

public
DateTime getRecDate(){
	return RecDate;
}

public
string getDes1(){
	return Des1;
}

} // class
} // package