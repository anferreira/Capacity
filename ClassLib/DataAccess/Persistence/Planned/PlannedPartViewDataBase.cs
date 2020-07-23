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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned { 

public
class PlannedPartViewDataBase : GenericDataBaseElement {

private string Part;
private int Seq;
private decimal QtyOriginal;
private decimal QtyPlanned;
private DateTime Date;
private string Title;

public
PlannedPartViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from PlannedPartview where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from PlannedPartview where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
    this.Part       = reader.GetString("Plant");
    this.Seq        = reader.GetInt32("Seq");
    this.QtyOriginal= reader.GetDecimal("QtyOriginal");
    this.QtyPlanned = reader.GetDecimal("QtyPlanned");
    this.Date       = reader.GetDateTime("Date");
    this.Title      = reader.GetString("Plant");            
}

public override
void write(){ 
    throw new Exception("No write allowed.");	
}

public override
void update(){
	throw new Exception("No write allowed.");
}

public override
void delete(){
	throw new Exception("No write allowed.");
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
void setQtyOriginal(decimal QtyOriginal){
	this.QtyOriginal = QtyOriginal;
}

public
void setQtyPlanned(decimal QtyPlanned){
	this.QtyPlanned = QtyPlanned;
}

public
void setDate(DateTime Date){
	this.Date = Date;
}

public
void setTitle(string Title){
	this.Title = Title;
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
decimal getQtyOriginal(){
	return QtyOriginal;
}

public
decimal getQtyPlanned(){
	return QtyPlanned;
}

public
DateTime getDate(){
	return Date;
}

public
string getTitle(){
	return Title;
}


} // class
} // package