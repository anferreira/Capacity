using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class TimeResDataBase : GenericDataBaseElement{

private string TR_TR;
private string TR_TRDes;

public
TimeResDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.TR_TR = reader.GetString("TR_TR");
	this.TR_TRDes = reader.GetString("TR_TRDes");
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
void setTR_TR(string TR_TR){
	this.TR_TR = TR_TR;
}

public
void setTR_TRDes(string TR_TRDes){
	this.TR_TRDes = TR_TRDes;
}

public
string getTR_TR(){
	return TR_TR;
}

public
string getTR_TRDes(){
	return TR_TRDes;
}


} // class

} // namespace