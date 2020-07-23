using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ToolCavDataBase : GenericDataBaseElement{

private string TL_TLID;
private decimal TL_CavID;
private string TL_CavDes;
private string TL_Fixed;
private string TL_ProdMulti;
private string TL_ProdID;

public
ToolCavDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.TL_TLID = reader.GetString("TL_TLID");
	this.TL_CavID = reader.GetDecimal("TL_CavID");
	this.TL_CavDes = reader.GetString("TL_CavDes");
	this.TL_Fixed = reader.GetString("TL_Fixed");
	this.TL_ProdMulti = reader.GetString("TL_ProdMulti");
	this.TL_ProdID = reader.GetString("TL_ProdID");
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
void setTL_TLID(string TL_TLID){
	this.TL_TLID = TL_TLID;
}

public
void setTL_CavID(decimal TL_CavID){
	this.TL_CavID = TL_CavID;
}

public
void setTL_CavDes(string TL_CavDes){
	this.TL_CavDes = TL_CavDes;
}

public
void setTL_Fixed(string TL_Fixed){
	this.TL_Fixed = TL_Fixed;
}

public
void setTL_ProdMulti(string TL_ProdMulti){
	this.TL_ProdMulti = TL_ProdMulti;
}

public
void setTL_ProdID(string TL_ProdID){
	this.TL_ProdID = TL_ProdID;
}


public
string getTL_TLID(){
	return TL_TLID;
}

public
decimal getTL_CavID(){
	return TL_CavID;
}

public
string getTL_CavDes(){
	return TL_CavDes;
}

public
string getTL_Fixed(){
	return TL_Fixed;
}

public
string getTL_ProdMulti(){
	return TL_ProdMulti;
}

public
string getTL_ProdID(){
	return TL_ProdID;
}


} // class

} // namespace