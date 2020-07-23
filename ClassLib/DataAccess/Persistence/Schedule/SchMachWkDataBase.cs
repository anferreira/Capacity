using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMachWkDataBase : GenericDataBaseElement{
	
private string SMW_SchVersion;
private string SMW_Plt;
private string SMW_Dept;
private string SMW_Mach;
private string SMW_TmType;
private int SMW_WkAcc;
private int SMW_WkPr;
private string SMW_MachCfg;
private DateTime SMW_DtWkStart;
private decimal SMW_MachCyc;
private decimal SMW_Racks;

public
SchMachWkDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SMW_SchVersion = reader.GetString("SMW_SchVersion");
	this.SMW_Plt = reader.GetString("SMW_Plt");
	this.SMW_Dept = reader.GetString("SMW_Dept");
	this.SMW_Mach = reader.GetString("SMW_Mach");
	this.SMW_TmType = reader.GetString("SMW_TmType");
	this.SMW_WkAcc = reader.GetInt32("SMW_WkAcc");
	this.SMW_WkPr = reader.GetInt32("SMW_WkPr");
	this.SMW_MachCfg = reader.GetString("SMW_MachCfg");
	this.SMW_DtWkStart = reader.GetDateTime("SMW_DtWkStart");
	this.SMW_MachCyc = reader.GetDecimal("SMW_MachCyc");
	this.SMW_Racks = reader.GetDecimal("SMW_Racks");
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
void setSMW_SchVersion(string SMW_SchVersion){
	this.SMW_SchVersion = SMW_SchVersion;
}

public
void setSMW_Plt(string SMW_Plt){
	this.SMW_Plt = SMW_Plt;
}

public
void setSMW_Dept(string SMW_Dept){
	this.SMW_Dept = SMW_Dept;
}

public
void setSMW_Mach(string SMW_Mach){
	this.SMW_Mach = SMW_Mach;
}

public
void setSMW_TmType(string SMW_TmType){
	this.SMW_TmType = SMW_TmType;
}

public
void setSMW_WkAcc(int SMW_WkAcc){
	this.SMW_WkAcc = SMW_WkAcc;
}

public
void setSMW_WkPr(int SMW_WkPr){
	this.SMW_WkPr = SMW_WkPr;
}

public
void setSMW_MachCfg(string SMW_MachCfg){
	this.SMW_MachCfg = SMW_MachCfg;
}

public
void setSMW_DtWkStart(DateTime SMW_DtWkStart){
	this.SMW_DtWkStart = SMW_DtWkStart;
}

public
void setSMW_MachCyc(decimal SMW_MachCyc){
	this.SMW_MachCyc = SMW_MachCyc;
}

public
void setSMW_Racks(decimal SMW_Racks){
	this.SMW_Racks = SMW_Racks;
}

public
string getSMW_SchVersion(){
	return SMW_SchVersion;
}

public
string getSMW_Plt(){
	return SMW_Plt;
}

public
string getSMW_Dept(){
	return SMW_Dept;
}

public
string getSMW_Mach(){
	return SMW_Mach;
}

public
string getSMW_TmType(){
	return SMW_TmType;
}

public
int getSMW_WkAcc(){
	return SMW_WkAcc;
}

public
int getSMW_WkPr(){
	return SMW_WkPr;
}

public
string getSMW_MachCfg(){
	return SMW_MachCfg;
}

public
DateTime getSMW_DtWkStart(){
	return SMW_DtWkStart;
}

public
decimal getSMW_MachCyc(){
	return SMW_MachCyc;
}

public
decimal getSMW_Racks(){
	return SMW_Racks;
}


}

}