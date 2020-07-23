using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchToolShfDataBase : GenericDataBaseElement{

private string STS_Version;
private string STS_TLID;
private string STS_Shf;
private DateTime STS_Dt;
private string STS_TmType;
private decimal STX_Hr;
private decimal STX_Cycles;

public
SchToolShfDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.STS_Version = reader.GetString("STS_Version");
	this.STS_TLID = reader.GetString("STS_TLID");
	this.STS_Shf = reader.GetString("STS_Shf");
	this.STS_Dt = reader.GetDateTime("STS_Dt");
	this.STS_TmType = reader.GetString("STS_TmType");
	this.STX_Hr = reader.GetDecimal("STX_Hr");
	this.STX_Cycles = reader.GetDecimal("STX_Cycles");
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
void setSTS_Version(string STS_Version){
	this.STS_Version = STS_Version;
}

public
void setSTS_TLID(string STS_TLID){
	this.STS_TLID = STS_TLID;
}

public
void setSTS_Shf(string STS_Shf){
	this.STS_Shf = STS_Shf;
}

public
void setSTS_Dt(DateTime STS_Dt){
	this.STS_Dt = STS_Dt;
}

public
void setSTS_TmType(string STS_TmType){
	this.STS_TmType = STS_TmType;
}

public
void setSTX_Hr(decimal STX_Hr){
	this.STX_Hr = STX_Hr;
}

public
void setSTX_Cycles(decimal STX_Cycles){
	this.STX_Cycles = STX_Cycles;
}


public
string getSTS_Version(){
	return STS_Version;
}

public
string getSTS_TLID(){
	return STS_TLID;
}

public
string getSTS_Shf(){
	return STS_Shf;
}

public
DateTime getSTS_Dt(){
	return STS_Dt;
}

public
string getSTS_TmType(){
	return STS_TmType;
}

public
decimal getSTX_Hr(){
	return STX_Hr;
}

public
decimal getSTX_Cycles(){
	return STX_Cycles;
}


} // class

} // namespace