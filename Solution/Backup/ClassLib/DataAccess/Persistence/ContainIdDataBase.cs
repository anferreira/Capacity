using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ContainIdDataBase : GenericDataBaseElement{

private string CNID_ContID;
private string CNID_ContType;
private string CNID_ContOwn;

public
ContainIdDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.CNID_ContID = reader.GetString("CNID_ContID");
	this.CNID_ContType = reader.GetString("CNID_ContType");
	this.CNID_ContOwn = reader.GetString("CNID_ContOwn");
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
void setCNID_ContID(string CNID_ContID){
	this.CNID_ContID = CNID_ContID;
}

public
void setCNID_ContType(string CNID_ContType){
	this.CNID_ContType = CNID_ContType;
}

public
void setCNID_ContOwn(string CNID_ContOwn){
	this.CNID_ContOwn = CNID_ContOwn;
}


public
string getCNID_ContID(){
	return CNID_ContID;
}

public
string getCNID_ContType(){
	return CNID_ContType;
}

public
string getCNID_ContOwn(){
	return CNID_ContOwn;
}



} // class

} // namespace