using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ToolSetDataBase : GenericDataBaseElement{

private string TLS_TLSet;
private string TLS_Config;
private string TLS_Des1;
private int TLS_NumSameTL;
private int TLS_NumDifTL;

public
ToolSetDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.TLS_TLSet = reader.GetString("TLS_TLSet");
	this.TLS_Config = reader.GetString("TLS_Config");
	this.TLS_Des1 = reader.GetString("TLS_Des1");
	this.TLS_NumSameTL = reader.GetInt16("TLS_NumSameTL");
	this.TLS_NumDifTL = reader.GetInt16("TLS_NumDifTL");
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
void setTLS_TLSet(string TLS_TLSet){
	this.TLS_TLSet = TLS_TLSet;
}

public
void setTLS_Config(string TLS_Config){
	this.TLS_Config = TLS_Config;
}

public
void setTLS_Des1(string TLS_Des1){
	this.TLS_Des1 = TLS_Des1;
}

public
void setTLS_NumSameTL(int TLS_NumSameTL){
	this.TLS_NumSameTL = TLS_NumSameTL;
}

public
void setTLS_NumDifTL(int TLS_NumDifTL){
	this.TLS_NumDifTL = TLS_NumDifTL;
}


public
string getTLS_TLSet(){
	return TLS_TLSet;
}

public
string getTLS_Config(){
	return TLS_Config;
}

public
string getTLS_Des1(){
	return TLS_Des1;
}

public
int getTLS_NumSameTL(){
	return TLS_NumSameTL;
}

public
int getTLS_NumDifTL(){
	return TLS_NumDifTL;
}


} // class

} // namespace