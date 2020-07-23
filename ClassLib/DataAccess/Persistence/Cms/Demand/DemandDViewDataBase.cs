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
class DemandDViewDataBase : GenericDataBaseElement {

private string Source;
private string BillTo;
private string ShipTo;
private string ShipLoc;
private string Part;
private int Seq;
private string CustPart;
private DateTime SDate;
private decimal NetQty;
private string TimeCode;
private decimal Qoh;
private decimal FaAutCum;
private decimal MaAutCum;

public
DemandDViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
    string sql = "select * from " + getTablePrefix2() + "demandd where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
    string sql = "select * from " + getTablePrefix2() + "demandd where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){       
    this.TimeCode = reader.GetString("TimeCode");    //for now no matter time , these records will be together
    this.Source = reader.GetString("Source");
	this.BillTo = reader.GetString("BillTo");
	this.ShipTo = reader.GetString("ShipTo");
    this.ShipLoc = reader.GetString("ShipLoc");
    this.Part = reader.GetString("Part");
    this.Seq = reader.GetInt32("PFS_SeqLast"); 
    this.CustPart = reader.GetString("CustPart");
	this.SDate = reader.GetDateTime("SDate");
	this.NetQty = reader.GetDecimal("NetQty");    
    this.Qoh = reader.GetDecimal("Qoh");

    this.FaAutCum = reader.GetDecimal("FaAutCum");
    this.MaAutCum = reader.GetDecimal("MaAutCum");
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
void setSource(string Source){
	this.Source = Source;
}

public
void setBillTo(string BillTo){
	this.BillTo = BillTo;
}

public
void setShipTo(string ShipTo){
	this.ShipTo = ShipTo;
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
void setSeq(int Seq){
	this.Seq = Seq;
}

public
void setCustPart(string CustPart){
	this.CustPart = CustPart;
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
void setTimeCode(string TimeCode){
    this.TimeCode = TimeCode;
}

public
void setQoh(decimal Qoh){
    this.Qoh = Qoh;
}

public
void setFaAutCum(decimal FaAutCum){
    this.FaAutCum = FaAutCum;
}

public
void setMaAutCum(decimal MaAutCum){
    this.MaAutCum = MaAutCum;
}

public
string getSource(){
	return Source;
}

public
string getBillTo(){
	return BillTo;
}

public
string getShipTo(){
	return ShipTo;
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
string getCustPart(){
	return CustPart;
}

public
DateTime getSDate(){
	return SDate;
}

public
decimal getNetQty(){
    return NetQty;
}

public
string getTimeCode(){
    return TimeCode;
}

public
decimal getQoh(){
    return Qoh;
}

public
decimal getFaAutCum(){
    return this.FaAutCum;
}

public
decimal getMaAutCum(){
    return this.MaAutCum;    
}

public
int getSeq(){
	return Seq;
}

} // class
} // package