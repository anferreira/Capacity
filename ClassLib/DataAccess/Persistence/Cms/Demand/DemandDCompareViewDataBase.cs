/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class DemandDCompareViewDataBase : GenericDataBaseElement {

private int HdrId;
private string Source;
private string TPartner;
private DateTime RelDate;
private string RelNum;
private string ShipLoc;
private string Part;
private DateTime SDate;
private decimal NetQty;

public
DemandDCompareViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public override
void load(NotNullDataReader reader){
    this.HdrId = reader.GetInt32("HdrId");
    this.Source = reader.GetString("Source");
    this.TPartner = reader.GetString("TPartner");
    this.RelDate = reader.GetDateTime("RelDate");
    this.RelNum = reader.GetString("RelNum");
	this.ShipLoc = reader.GetString("ShipLoc");
	this.Part = reader.GetString("Part");
	this.SDate = reader.GetDateTime("SDate");
	this.NetQty = reader.GetDecimal("NetQty");    
}

public override
void write(){
    throw new PersistenceException("write Function not enabled");    
}

public override
void update(){
    throw new PersistenceException("update Function not enabled");    
}

public override
void delete(){
   throw new PersistenceException("delete Function not enabled");    
}

public
void setHdrId(int HdrId){
	this.HdrId = HdrId;
}

public
void setSource(string Source){
	this.Source = Source;
}

public
void setTPartner(string TPartner){
	this.TPartner = TPartner;
}

public
void setRelDate(DateTime RelDate){
	this.RelDate = RelDate;
}

public
void setRelNum(string RelNum){
	this.RelNum = RelNum;
}

public
void setShipLoc(string ShipLoc){
	this.ShipLoc = ShipLoc;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setSDate(DateTime SDate){
	this.SDate = SDate;
}

public
void setNetQty(decimal NetQty){
    this.NetQty = NetQty;
}

public
int getHdrId(){
	return HdrId;
}

public
string getSource(){
	return Source;
}
           
public
string getTPartner(){
	return TPartner;
}

public
DateTime getRelDate(){
    return RelDate;
}

public
string getRelNum(){
	return RelNum;
}

public
string getShipLoc(){
	return ShipLoc;
}

public
string getPart(){
	return Part;
}

public
DateTime getSDate(){
	return SDate;
}

public
decimal getNetQty(){
    return NetQty;
}

} // class
} // package