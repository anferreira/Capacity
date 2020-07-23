using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchToolHrDataBase : GenericDataBaseElement{

private string STH_TLID;
private DateTime STH_DtPr;
private string STH_Plt;
private string STH_Dept;
private string STH_Mach;
private decimal STH_OrdSortID;
private string STH_ProdID;
private string STH_TmType;
private DateTime STH_DtStart;
private DateTime STH_DtEnd;
private decimal STH_Hr;
private decimal STH_Cycles;

public
SchToolHrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.STH_TLID = reader.GetString("STH_TLID");
	this.STH_DtPr = reader.GetDateTime("STH_DtPr");
	this.STH_Plt = reader.GetString("STH_Plt");
	this.STH_Dept = reader.GetString("STH_Dept");
	this.STH_Mach = reader.GetString("STH_Mach");
	this.STH_OrdSortID = reader.GetDecimal("STH_OrdSortID");
	this.STH_ProdID = reader.GetString("STH_ProdID");
	this.STH_TmType = reader.GetString("STH_TmType");
	this.STH_DtStart = reader.GetDateTime("STH_DtStart");
	this.STH_DtEnd = reader.GetDateTime("STH_DtEnd");
	this.STH_Hr = reader.GetDecimal("STH_Hr");
	this.STH_Cycles = reader.GetDecimal("STH_Cycles");
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
void setSTH_TLID(string STH_TLID){
	this.STH_TLID = STH_TLID;
}

public
void setSTH_DtPr(DateTime STH_DtPr){
	this.STH_DtPr = STH_DtPr;
}

public
void setSTH_Plt(string STH_Plt){
	this.STH_Plt = STH_Plt;
}

public
void setSTH_Dept(string STH_Dept){
	this.STH_Dept = STH_Dept;
}

public
void setSTH_Mach(string STH_Mach){
	this.STH_Mach = STH_Mach;
}

public
void setSTH_OrdSortID(decimal STH_OrdSortID){
	this.STH_OrdSortID = STH_OrdSortID;
}

public
void setSTH_ProdID(string STH_ProdID){
	this.STH_ProdID = STH_ProdID;
}


public
void setSTH_TmType(string STH_TmType){
	this.STH_TmType = STH_TmType;
}

public
void setSTH_DtStart(DateTime STH_DtStart){
	this.STH_DtStart = STH_DtStart;
}

public
void setSTH_DtEnd(DateTime STH_DtEnd){
	this.STH_DtEnd = STH_DtEnd;
}

public
void setSTH_Hr(decimal STH_Hr){
	this.STH_Hr = STH_Hr;
}

public
void setSTH_Cycles(decimal STH_Cycles){
	this.STH_Cycles = STH_Cycles;
}


public
string getSTH_TLID(){
	return STH_TLID;
}

public
DateTime getSTH_DtPr(){
	return STH_DtPr;
}

public
string getSTH_Plt(){
	return STH_Plt;
}

public
string getSTH_Dept(){
	return STH_Dept;
}

public
string getSTH_Mach(){
	return STH_Mach;
}

public
decimal getSTH_OrdSortID(){
	return STH_OrdSortID;
}

public
string getSTH_ProdID(){
	return STH_ProdID;
}


public
string getSTH_TmType(){
	return STH_TmType;
}

public
DateTime getSTH_DtStart(){
	return STH_DtStart;
}

public
DateTime getSTH_DtEnd(){
	return STH_DtEnd;
}

public
decimal getSTH_Hr(){
	return STH_Hr;
}

public
decimal getSTH_Cycles(){
	return STH_Cycles;
}

} // class

} // namespace