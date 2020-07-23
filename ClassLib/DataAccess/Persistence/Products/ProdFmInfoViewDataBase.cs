using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ProdFmInfoViewDataBase : ProdFmInfoDataBase{

private decimal Qoh;
private int     SchMaterialAvailId;
        
public
ProdFmInfoViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
/*
public
ProdFmInfoDataBaseViewDataBase(ProdFmInfoDataBaseViewDataBase ProdFmInfoDataBaseViewDataBase) : base(ProdFmInfoDataBaseViewDataBase.dataBaseAccess){
	
}*/

public 
void load(NotNullDataReader reader){
    base.load(reader);
    this.Qoh                = reader.GetDecimal("Qoh");    
    this.SchMaterialAvailId = reader.GetInt32("SchMaterialAvailId");    
}

public override
void update(){
	throw new PersistenceException("Error in class ProdFmInfoViewDataBase <update>: Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Error in class ProdFmInfoViewDataBase <delete>: Method not implemented");
}
        
public
void setQoh(decimal Qoh){
	this.Qoh = Qoh;
}

public
void setSchMaterialAvailId(int SchMaterialAvailId){
	this.SchMaterialAvailId = SchMaterialAvailId;
}

public
decimal getQoh(){
	return Qoh;
}

public
int getSchMaterialAvailId(){
	return SchMaterialAvailId;
}        

} // class

} // namespace