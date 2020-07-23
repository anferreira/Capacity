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
class DemTransformHDataBase : GenericDataBaseElement {

private int Id;
private DateTime DateCreated;
private int DemandHdr;
private string Status;
private string Plant;
private string WeekMode;
private string MonthMode;

public
DemTransformHDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from demtransformh where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from demtransformh where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.DateCreated = reader.GetDateTime("DateCreated");
	this.DemandHdr = reader.GetInt32("DemandHdr");
	this.Status = reader.GetString("Status");
    this.Plant= reader.GetString("Plant");

    this.WeekMode = reader.GetString("WeekMode");        
    this.MonthMode = reader.GetString("MonthMode");    
}

public override
void write(){  
	string sql = "insert into demtransformh(" + 
		"DateCreated," +
		"DemandHdr," +
        "Status," +
        "Plant," +
        "WeekMode," +
        "MonthMode" +

        ") values (" + 

		"'" + DateUtil.getCompleteDateRepresentation(DateCreated) + "'," +
		"" + NumberUtil.toString(DemandHdr) + "," +
		"'" + Converter.fixString(Status) + "'," +
        "'" + Converter.fixString(Plant) + "'," +
        "'" + Converter.fixString(WeekMode) + "'," +
        "'" + Converter.fixString(MonthMode) + "')";

	write(sql);
	this.setId(dataBaseAccess.getLastId());	
}

public override
void update(){
	string sql = "update demtransformh set " +
		"DateCreated = '" + DateUtil.getCompleteDateRepresentation(DateCreated) + "', " +
		"DemandHdr = " + NumberUtil.toString(DemandHdr) + ", " +
		"Status = '" + Converter.fixString(Status) + "', " +
        "Plant = '" + Converter.fixString(Plant) + "', " +
        "WeekMode = '" + Converter.fixString(WeekMode) + "', " +
        "MonthMode = '" + Converter.fixString(MonthMode) + "' " +

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from demtransformh where " + getWhereCondition();
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
void setDateCreated(DateTime DateCreated){
	this.DateCreated = DateCreated;
}

public
void setDemandHdr(int DemandHdr){
	this.DemandHdr = DemandHdr;
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
void setWeekMode(string WeekMode){
	this.WeekMode = WeekMode;
}

public
void setMonthMode(string MonthMode){
	this.MonthMode = MonthMode;
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
int getDemandHdr(){
	return DemandHdr;
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
bool readByDemandHdrMaxId(int demandHdr){
	string sql = "select * from demtransformh where Id in (select max(Id) from demtransformh where DemandHdr = " + demandHdr + ")";    
	return read(sql);
}

public
string getWeekMode(){
	return WeekMode;
}

public
string getMonthMode(){
    return MonthMode;
}

} // class
} // package