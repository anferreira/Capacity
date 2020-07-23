using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ActMasterDataBase : GenericDataBaseElement{

private string AM_ActID;
private string AM_ActCat;
private string AM_Dept;
private string AM_Mach;
private string AM_Des1;
private string AM_Des2;
private string AM_Des3;

public
ActMasterDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.AM_ActID = reader.GetString("AM_ActID");
	this.AM_ActCat = reader.GetString("AM_ActCat");
	this.AM_Dept = reader.GetString("AM_Dept");
	this.AM_Mach = reader.GetString("AM_Mach");
	this.AM_Des1 = reader.GetString("AM_Des1");
	this.AM_Des2 = reader.GetString("AM_Des2");
	this.AM_Des3 = reader.GetString("AM_Des3");
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
void setAM_ActID(string AM_ActID){
	this.AM_ActID = AM_ActID;
}

public
void setAM_ActCat(string AM_ActCat){
	this.AM_ActCat = AM_ActCat;
}
	
public
void setAM_Dept(string AM_Dept){
	this.AM_Dept = AM_Dept;
}

public
void setAM_Mach(string AM_Mach){
	this.AM_Mach = AM_Mach;
}

public
void setAM_Des1(string AM_Des1){
	this.AM_Des1 = AM_Des1;
}

public
void setAM_Des2(string AM_Des2){
	this.AM_Des2 = AM_Des2;
}

public
void setAM_Des3(string AM_Des3){
	this.AM_Des3 = AM_Des3;
}

	
public
string getAM_ActID(){
	return AM_ActID;
}

public
string getAM_ActCat(){
	return AM_ActCat;
}
	
public
string getAM_Dept(){
	return AM_Dept;
}

public
string getAM_Mach(){
	return AM_Mach;
}

public
string getAM_Des1(){
	return AM_Des1;
}

public
string getAM_Des2(){
	return AM_Des2;
}

public
string getAM_Des3(){
	return AM_Des3;
}

} // class

} // namespace