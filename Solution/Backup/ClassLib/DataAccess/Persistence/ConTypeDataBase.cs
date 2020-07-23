using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ConTypeDataBase : GenericDataBaseElement{

private string CT_ConType;
private string CT_Internal;
private string CT_ProdState;

public
ConTypeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.CT_ConType = reader.GetString("CT_ConType");
	this.CT_Internal = reader.GetString("CT_Internal");
	this.CT_ProdState = reader.GetString("CT_ProdState");
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
void setCT_ConType(string CT_ConType){
	this.CT_ConType = CT_ConType;
}

public
void setCT_Internal(string CT_Internal){
	this.CT_Internal = CT_Internal;
}

public
void setCT_ProdState(string CT_ProdState){
	this.CT_ProdState = CT_ProdState;
}


public
string getCT_ConType(){
	return CT_ConType;
}

public
string getCT_Internal(){
	return CT_Internal;
}

public
string getCT_ProdState(){
	return CT_ProdState;
}


} // class

} // namespace