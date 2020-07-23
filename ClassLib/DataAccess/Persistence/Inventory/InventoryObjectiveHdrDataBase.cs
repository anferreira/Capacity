/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class InventoryObjectiveHdrDataBase : GenericDataBaseElement {

private int Id;
private DateTime DateCreated;
private string Status;
private string Plant;
private DateTime DateTimeStamp;

public
InventoryObjectiveHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from inventoryobjectivehdr where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from inventoryobjectivehdr where " + getWhereCondition();
	return exists(sql);
}

public
bool readLastByFilter(string splant){
    string sql = "select * from inventoryobjectivehdr h where h.Id in (select max(h2.Id) from inventoryobjectivehdr h2 ";
    
    if (!string.IsNullOrEmpty(splant))                     
        sql+= " where Plant='" + splant +"'";
    sql+=")";

	return read(sql);	
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.DateCreated = reader.GetDateTime("DateCreated");
	this.Status = reader.GetString("Status");
	this.Plant = reader.GetString("Plant");
    this.DateTimeStamp = reader.GetDateTime("DateTimeStamp");
}

public override 
void write(){
	string sql = "insert into inventoryobjectivehdr(" + 
		"DateCreated," +
		"Status," +
        "Plant," +
        "DateTimeStamp" +

        ") values (" + 

		"'" + DateUtil.getCompleteDateRepresentation(DateCreated) + "'," +
		"'" + Converter.fixString(Status) + "'," +
		"'" + Converter.fixString(Plant) + "'," +
        "" + DBFormatter.getNowFunction() + ")";
    write(sql);

	this.setId(dataBaseAccess.getLastId());    
}

public override
void update(){
	string sql = "update inventoryobjectivehdr set " +
		"DateCreated = '" + DateUtil.getCompleteDateRepresentation(DateCreated) + "', " +
		"Status = '" + Converter.fixString(Status) + "', " +
		"Plant = '" + Converter.fixString(Plant) + "', " +
        "DateTimeStamp = " + DBFormatter.getNowFunction() + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from inventoryobjectivehdr where " + getWhereCondition();
	delete(sql);
}

public override
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
void setDateCreated(DateTime DateCreated){
	this.DateCreated = DateCreated;
}

public
void setStatus(string Status){
	this.Status = Status;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setDateTimeStamp(DateTime DateTimeStamp){
	this.DateTimeStamp = DateTimeStamp;
}

public
int getId(){
	return Id;
}

public
DateTime getDateCreated(){
	return DateCreated;
}

public
string getStatus(){
	return Status;
}

public
string getPlant(){
	return Plant;
}

public
DateTime getDateTimeStamp(){
	return DateTimeStamp;
}

public
DateTime readDateTimeStamp() {
    return base.readDateTimeStamp("inventoryobjectivehdr", "DateTimeStamp");
}

} // class
} // package