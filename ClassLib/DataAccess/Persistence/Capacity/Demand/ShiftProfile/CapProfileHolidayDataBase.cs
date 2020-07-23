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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapProfileHolidayDataBase : GenericDataBaseElement {

private int Id;
private string Plant;
private DateTime StartDate;
private DateTime EndDate;
private string HolidayType;

public
CapProfileHolidayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capprofileholiday where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capprofileholiday where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
    this.Plant = reader.GetString("Plant");
    this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");
	this.HolidayType = reader.GetString("HolidayType");
}

public override
void write(){
	string sql = "insert into capprofileholiday(" +
        "Plant," +
        "StartDate," +
		"EndDate," +
		"HolidayType" +

		") values (" +
        "'" + Converter.fixString(Plant) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate)   + "'," +
        "'" + Converter.fixString(HolidayType) + "')";
	write(sql);

	this.setId(dataBaseAccess.getLastId());	 	
}

public override
void update(){
	string sql = "update capprofileholiday set " +
        "Plant = '" + Converter.fixString(Plant) + "', " +
        "StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "', " +
        "HolidayType ='" + Converter.fixString(HolidayType) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capprofileholiday where " + getWhereCondition();
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
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setStartDate(DateTime StartDate){
	this.StartDate = StartDate;
}

public
void setEndDate(DateTime EndDate){
	this.EndDate = EndDate;
}

public
void setHolidayType(string HolidayType){
	this.HolidayType = HolidayType;
}

public
int getId(){
	return Id;
}

public
string getPlant(){
    return Plant;
}

public
DateTime getStartDate(){
	return StartDate;
}

public
DateTime getEndDate(){
	return EndDate;
}

public
string getHolidayType(){
	return HolidayType;
}



} // class
} // package