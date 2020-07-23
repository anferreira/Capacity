using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ActSubDataBase : GenericDataBaseElement{

private string AMS_ActID;
private string AMS_SubID;
private string AMS_DirInd;
private string AMS_Sched;
private string AMS_DeptLoc;
private string AMS_MachLoc;
private string AMS_DeptResp;
private string AMS_Des1;
private string AMS_Des2;
private string AMS_Des3;
private string AMS_Colour;
private string AMS_ColourID;
private int AMS_ColourRank;
private string AMS_EmpCfg;

public
ActSubDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.AMS_ActID = reader.GetString("AMS_ActID");
	this.AMS_SubID = reader.GetString("AMS_SubID");
	this.AMS_DirInd = reader.GetString("AMS_DirInd");
	this.AMS_Sched = reader.GetString("AMS_Sched");
	this.AMS_DeptLoc = reader.GetString("AMS_DeptLoc");
	this.AMS_MachLoc = reader.GetString("AMS_MachLoc");
	this.AMS_DeptResp = reader.GetString("AMS_DeptResp");
	this.AMS_Des1 = reader.GetString("AMS_Des1");
	this.AMS_Des2 = reader.GetString("AMS_Des2");
	this.AMS_Des3 = reader.GetString("AMS_Des3");
	this.AMS_Colour = reader.GetString("AMS_Colour");
	this.AMS_ColourID = reader.GetString("AMS_ColourID");
	this.AMS_ColourRank = reader.GetInt16("AMS_ColourRank");
	this.AMS_EmpCfg = reader.GetString("AMS_EmpCfg");
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
void setAMS_ActID(string AMS_ActID){
	this.AMS_ActID = AMS_ActID;
}

public
void setAMS_SubID(string AMS_SubID){
	this.AMS_SubID = AMS_SubID;
}

public
void setAMS_DirInd(string AMS_DirInd){
	this.AMS_DirInd = AMS_DirInd;
}

public
void setAMS_Sched(string AMS_Sched){
	this.AMS_Sched = AMS_Sched;
}

public
void setAMS_DeptLoc(string AMS_DeptLoc){
	this.AMS_DeptLoc = AMS_DeptLoc;
}

public
void setAMS_MachLoc(string AMS_MachLoc){
	this.AMS_MachLoc = AMS_MachLoc;
}

public
void setAMS_DeptResp(string AMS_DeptResp){
	this.AMS_DeptResp = AMS_DeptResp;
}

public
void setAMS_Des1(string AMS_Des1){
	this.AMS_Des1 = AMS_Des1;
}

public
void setAMS_Des2(string AMS_Des2){
	this.AMS_Des2 = AMS_Des2;
}

public
void setAMS_Des3(string AMS_Des3){
	this.AMS_Des3 = AMS_Des3;
}

public
void setAMS_Colour(string AMS_Colour){
	this.AMS_Colour = AMS_Colour;
}

public
void setAMS_ColourID(string AMS_ColourID){
	this.AMS_ColourID = AMS_ColourID;
}

public
void setAMS_ColourRank(int AMS_ColourRank){
	this.AMS_ColourRank = AMS_ColourRank;
}

public
void setAMS_EmpCfg(string AMS_EmpCfg){
	this.AMS_EmpCfg = AMS_EmpCfg;
}


public
string getAMS_ActID(){
	return AMS_ActID;
}

public
string getAMS_SubID(){
	return AMS_SubID;
}

public
string getAMS_DirInd(){
	return AMS_DirInd;
}

public
string getAMS_Sched(){
	return AMS_Sched;
}

public
string getAMS_DeptLoc(){
	return AMS_DeptLoc;
}

public
string getAMS_MachLoc(){
	return AMS_MachLoc;
}

public
string getAMS_DeptResp(){
	return AMS_DeptResp;
}

public
string getAMS_Des1(){
	return AMS_Des1;
}

public
string getAMS_Des2(){
	return AMS_Des2;
}

public
string getAMS_Des3(){
	return AMS_Des3;
}

public
string getAMS_Colour(){
	return AMS_Colour;
}

public
string getAMS_ColourID(){
	return AMS_ColourID;
}

public
int getAMS_ColourRank(){
	return AMS_ColourRank;
}

public
string getAMS_EmpCfg(){
	return AMS_EmpCfg;
}

} // class

} // namespace