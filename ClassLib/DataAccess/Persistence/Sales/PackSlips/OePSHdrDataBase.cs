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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips{

public
class OePSHdrDataBase : GenericDataBaseElement {

private int Id;
private int ExernalId;
private string Plant;
private string BillTo;
private string ShipTo;
private DateTime DateCreated;
private DateTime ShipDate;
private DateTime DatePosted;
private string Status;

public
OePSHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from oepshdr where " + getWhereCondition();
	return read(sql);
}

public
bool readExernalId(int iexernalId){
	string sql = "select * from oepshdr where ExernalId =" + NumberUtil.toString(iexernalId);
	return read(sql);
}

public
bool exists(){
	string sql = "select * from oepshdr where " + getWhereCondition();
	return exists(sql);
}

public
bool existsExernalId(int iexernalId){
	string sql = "select * from oepshdr where ExernalId =" + NumberUtil.toString(iexernalId);
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.ExernalId = reader.GetInt32("ExernalId");
    this.Plant = reader.GetString("Plant");
	this.BillTo = reader.GetString("BillTo");
	this.ShipTo = reader.GetString("ShipTo");
	this.DateCreated = reader.GetDateTime("DateCreated");
	this.ShipDate = reader.GetDateTime("ShipDate");
	this.DatePosted = reader.GetDateTime("DatePosted");
	this.Status = reader.GetString("Status");
}

public override
void write(){
	string sql = "insert into oepshdr(" + 
		"ExernalId," +
        "Plant," +        
        "BillTo," +
		"ShipTo," +
		"DateCreated," +
		"ShipDate," +
		"DatePosted," +
		"Status" +

		") values (" + 

		"" + NumberUtil.toString(ExernalId) + "," +        
        "'" + Converter.fixString(Plant) + "'," +
        "'" + Converter.fixString(BillTo) + "'," +
		"'" + Converter.fixString(ShipTo) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(DateCreated) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ShipDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(DatePosted) + "'," +
		"'" + Converter.fixString(Status) + "')";
	write(sql);
	this.setId(dataBaseAccess.getLastId());	
}

public override
void update(){
	string sql = "update oepshdr set " +
		"ExernalId = " + NumberUtil.toString(ExernalId) + ", " +
        "Plant = '" + Converter.fixString(Plant) + "', " +
        "BillTo = '" + Converter.fixString(BillTo) + "', " +
		"ShipTo = '" + Converter.fixString(ShipTo) + "', " +
		"DateCreated = '" + DateUtil.getCompleteDateRepresentation(DateCreated) + "', " +
		"ShipDate = '" + DateUtil.getCompleteDateRepresentation(ShipDate) + "', " +
		"DatePosted = '" + DateUtil.getCompleteDateRepresentation(DatePosted) + "', " +
		"Status = '" + Converter.fixString(Status) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oepshdr where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Id = " + NumberUtil.toString(Id) + "";
	return sqlWhere;
}

public
void setId(int Id){
	this.Id = Id;
}

public
void setExernalId(int ExernalId){
	this.ExernalId = ExernalId;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
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
void setDateCreated(DateTime DateCreated){
	this.DateCreated = DateCreated;
}

public
void setShipDate(DateTime ShipDate){
	this.ShipDate = ShipDate;
}

public
void setDatePosted(DateTime DatePosted){
	this.DatePosted = DatePosted;
}

public
void setStatus(string Status){
	this.Status = Status;
}

public
int getId(){
	return Id;
}

public
int getExernalId(){
	return ExernalId;
}

public
string getPlant(){
	return Plant;
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
DateTime getDateCreated(){
	return DateCreated;
}

public
DateTime getShipDate(){
	return ShipDate;
}

public
DateTime getDatePosted(){
	return DatePosted;
}

public
string getStatus(){
	return Status;
}

} // class
} // package