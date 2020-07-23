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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned { 

public
class PlannedHdrDataBase : GenericDataBaseElement {

private int Id;
private DateTime DateCreated;
private string Status;
private string Plant;
private int TotMachines;
private int MachPlanned;
private int LastMachPlannedId;
private DateTime DateTimeStamp;

public
PlannedHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from plannedhdr where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from plannedhdr where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.DateCreated = reader.GetDateTime("DateCreated");
	this.Status = reader.GetString("Status");
	this.Plant = reader.GetString("Plant");
	this.TotMachines = reader.GetInt32("TotMachines");
	this.MachPlanned = reader.GetInt32("MachPlanned");
	this.LastMachPlannedId = reader.GetInt32("LastMachPlannedId");
    this.DateTimeStamp = reader.GetDateTime("DateTimeStamp");
}

public override
void write(){
	string sql = "insert into plannedhdr(" + 
		"DateCreated," +
		"Status," +
		"Plant," +
		"TotMachines," +
		"MachPlanned," +
		"LastMachPlannedId," +
        "DateTimeStamp"+

        ") values (" + 

		"'" + DateUtil.getCompleteDateRepresentation(DateCreated) + "'," +
		"'" + Converter.fixString(Status) + "'," +
		"'" + Converter.fixString(Plant) + "'," +
		"" + NumberUtil.toString(TotMachines) + "," +
		"" + NumberUtil.toString(MachPlanned) + "," +
		"" + NumberUtil.toString(LastMachPlannedId) +  "," +
        "" + DBFormatter.getNowFunction() + ")"; 
	write(sql);
	this.setId(dataBaseAccess.getLastId());	
}

public override
void update(){
	string sql = "update plannedhdr set " +
		"DateCreated = '" + DateUtil.getCompleteDateRepresentation(DateCreated) + "', " +
		"Status = '" + Converter.fixString(Status) + "', " +
		"Plant = '" + Converter.fixString(Plant) + "', " +
		"TotMachines = " + NumberUtil.toString(TotMachines) + ", " +
		"MachPlanned = " + NumberUtil.toString(MachPlanned) + ", " +
		"LastMachPlannedId = " + NumberUtil.toString(LastMachPlannedId) + ", " +
        "DateTimeStamp = " + DBFormatter.getNowFunction() + " " +

        " where " + getWhereCondition();
	update(sql);
}

public override
void delete(){
	string sql = "delete from plannedhdr where " + getWhereCondition();
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
void setTotMachines(int TotMachines){
	this.TotMachines = TotMachines;
}

public
void setMachPlanned(int MachPlanned){
	this.MachPlanned = MachPlanned;
}

public
void setLastMachPlannedId(int LastMachPlannedId){
	this.LastMachPlannedId = LastMachPlannedId;
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
int getTotMachines(){
	return TotMachines;
}

public
int getMachPlanned(){
	return MachPlanned;
}

public
int getLastMachPlannedId(){
	return LastMachPlannedId;
}

public
DateTime getDateTimeStamp(){
	return DateTimeStamp;
}

public
bool readLastByFilter(string splant){
    string sql = "select * from plannedhdr h where h.Id in (select max(h2.Id) from plannedhdr h2 ";
    
    if (!string.IsNullOrEmpty(splant))                     
        sql+= " where Plant='" + splant +"'";
    sql+=")";

	return read(sql);	
}

public
DateTime readDateTimeStamp() {
    return base.readDateTimeStamp("plannedhdr", "DateTimeStamp");
}


} // class
} // package