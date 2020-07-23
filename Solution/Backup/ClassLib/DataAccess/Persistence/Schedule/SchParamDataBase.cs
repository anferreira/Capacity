using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchParamDataBase : GenericDataBaseElement{

private string SYP_SysSett;
private DateTime SYP_SysDt;
private string SYP_AutoRep;
private string SYP_Rep;
private string SYP_Order;
private string SYP_ComOrd;

public
SchParamDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.SYP_SysSett = reader.GetString("SYP_SysSett");
	this.SYP_SysDt = reader.GetDateTime("SYP_SysDt");
	this.SYP_AutoRep = reader.GetString("SYP_AutoRep");
	this.SYP_Rep = reader.GetString("SYP_Rep");
	this.SYP_Order = reader.GetString("SYP_Order");
	this.SYP_ComOrd = reader.GetString("SYP_ComOrd");
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
void setSYP_SysSett(string SYP_SysSett){
	this.SYP_SysSett = SYP_SysSett;
}

public
void setSYP_SysDt(DateTime SYP_SysDt){
	this.SYP_SysDt = SYP_SysDt;
}

public
void setSYP_AutoRep(string SYP_AutoRep){
	this.SYP_AutoRep = SYP_AutoRep;
}

public
void setSYP_Rep(string SYP_Rep){
	this.SYP_Rep = SYP_Rep;
}

public
void setSYP_Order(string SYP_Order){
	this.SYP_Order = SYP_Order;
}

public
void setSYP_ComOrd(string SYP_ComOrd){
	this.SYP_ComOrd = SYP_ComOrd;
}


public
string getSYP_SysSett(){
	return SYP_SysSett;
}

public
DateTime getSYP_SysDt(){
	return SYP_SysDt;
}

public
string getSYP_AutoRep(){
	return SYP_AutoRep;
}

public
string getSYP_Rep(){
	return SYP_Rep;
}

public
string getSYP_Order(){
	return SYP_Order;
}

public
string getSYP_ComOrd(){
	return SYP_ComOrd;
}


} // class

} // namespace