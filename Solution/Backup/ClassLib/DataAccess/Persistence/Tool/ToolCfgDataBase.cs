using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ToolCfgDataBase : GenericDataBaseElement{

private string TC_Config;
private string TC_Categ;
private int TC_NumTool;
private int TC_NumLTool;
private string TC_Consume;
private string TC_MUD;

public
ToolCfgDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.TC_Config = reader.GetString("TC_Config");
	this.TC_Categ = reader.GetString("TC_Categ");
	this.TC_NumTool = reader.GetInt32("TC_NumTool");
	this.TC_NumLTool = reader.GetInt32("TC_NumLTool");
	this.TC_Consume = reader.GetString("TC_Consume");
	this.TC_MUD = reader.GetString("TC_MUD");
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
void setTC_Config(string TC_Config){
	this.TC_Config = TC_Config;
}

public
void setTC_Categ(string TC_Categ){
	this.TC_Categ = TC_Categ;
}

public
void setTC_NumTool(int TC_NumTool){
	this.TC_NumTool = TC_NumTool;
}

public
void setTC_NumLTool(int TC_NumLTool){
	this.TC_NumLTool = TC_NumLTool;
}

public
void setTC_Consume(string TC_Consume){
	this.TC_Consume = TC_Consume;
}

public
void setTC_MUD(string TC_MUD){
	this.TC_MUD = TC_MUD;
}


public
string getTC_Config(){
	return TC_Config;
}

public
string getTC_Categ(){
	return TC_Categ;
}

public
int getTC_NumTool(){
	return TC_NumTool;
}

public
int getTC_NumLTool(){
	return TC_NumLTool;
}

public
string getTC_Consume(){
	return TC_Consume;
}

public
string getTC_MUD(){
	return TC_MUD;
}


} // class

} // namespace