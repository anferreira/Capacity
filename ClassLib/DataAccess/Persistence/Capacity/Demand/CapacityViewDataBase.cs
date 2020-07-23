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
class CapacityViewDataBase : GenericDataBaseElement {

private string Plant;
private string Dept;
private int ReqId;
private string ReqType;
private string Machine;
private string Labour;
private string Tool;
private string Title;
private decimal Hours;
private DateTime SDate;
private decimal DirectHoursToShifts;

public
CapacityViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capacityview where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capacityview where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Plant = reader.GetString("Plant");
	this.Dept = reader.GetString("Dept");
    this.ReqId = reader.GetInt32("ReqId");
    this.ReqType = reader.GetString("ReqType");
	this.Machine = reader.GetString("Machine");
	this.Labour = reader.GetString("Labour");
	this.Tool = reader.GetString("Tool");
	this.Title = reader.GetString("Title");
    try{
        if (reader.HasColumn("Hours"))
	        this.Hours = reader.GetDecimal("Hours");
        else
            this.Hours = 0;
    }catch (Exception ex){ this.Hours = 0; }
	this.SDate = reader.GetDateTime("SDate");
    this.DirectHoursToShifts = reader.GetDecimal("DirectHoursToShifts");
}

public override
void write(){ 
	string sql = "insert into capacityview(" + 
		"Plant," +
		"Dept," +
        "ReqId," +
        "ReqType," +
		"Machine," +
		"Labour," +
		"Tool," +
		"Title," +
		"Hours," +
		"SDate," +
        "DirectHoursToShifts"+

        ") values (" + 

		"'" + Converter.fixString(Plant) + "'," +
		"'" + Converter.fixString(Dept) + "'," +
        "" + NumberUtil.toString(ReqId) + "'," +
        "'" + Converter.fixString(ReqType) + "'," +
		"'" + Converter.fixString(Machine) + "'," +
		"'" + Converter.fixString(Labour) + "'," +
		"'" + Converter.fixString(Tool) + "'," +
		"'" + Converter.fixString(Title) + "'," +
		"" + NumberUtil.toString(Hours) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(SDate)  +"'," +
        "" + NumberUtil.toString(DirectHoursToShifts) + ")";           

    write(sql);	
}

public override
void update(){
	string sql = "update capacityview set " +
		"Plant = '" + Converter.fixString(Plant) + "', " +
		"Dept = '" + Converter.fixString(Dept) + "', " +
        "ReqId = " + NumberUtil.toString(ReqId) + ", " +
        "ReqType = '" + Converter.fixString(ReqType) + "', " +
		"Machine = '" + Converter.fixString(Machine) + "', " +
		"Labour = '" + Converter.fixString(Labour) + "', " +
		"Tool = '" + Converter.fixString(Tool) + "', " +
		"Title = '" + Converter.fixString(Title) + "', " +
		"Hours = " + NumberUtil.toString(Hours) + ", " +
		"SDate = '" + DateUtil.getCompleteDateRepresentation(SDate)+ "', " +
        "DirectHoursToShifts = " + NumberUtil.toString(DirectHoursToShifts) + " " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capacityview where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Plant = '" + Converter.fixString(Plant) + "' and " +
		"Dept = '" + Converter.fixString(Dept) + "' and " +
        "ReqId = " + NumberUtil.toString(ReqId) + " and " +
        "ReqType = '" + Converter.fixString(ReqType) + "' and " +
		"Machine = '" + Converter.fixString(Machine) + "' and " +
		"Labour = '" + Converter.fixString(Labour) + "' and " +
		"Tool = '" + Converter.fixString(Tool) + "' and " +
		"Title = '" + Converter.fixString(Title) + "'";
	return sqlWhere;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setDept(string Dept){
	this.Dept = Dept;
}

public
void setReqType(string ReqType){
	this.ReqType = ReqType;
}

public
void setReqId(int ReqId){
	this.ReqId = ReqId;
}

public
void setMachine(string Machine){
	this.Machine = Machine;
}

public
void setLabour(string Labour){
	this.Labour = Labour;
}

public
void setTool(string Tool){
	this.Tool = Tool;
}

public
void setTitle(string Title){
	this.Title = Title;
}

public
void setHours(decimal Hours){
	this.Hours = Hours;
}

public
void setSDate(DateTime SDate){
	this.SDate = SDate;
}

public
void setDirectHoursToShifts(decimal DirectHoursToShifts){
	this.DirectHoursToShifts = DirectHoursToShifts;
}

public
string getPlant(){
	return Plant;
}

public
string getDept(){
	return Dept;
}

public
int getReqId(){
	return ReqId;
}

public
string getReqType(){
	return ReqType;
}

public
string getMachine(){
	return Machine;
}

public
string getLabour(){
	return Labour;
}

public
string getTool(){
	return Tool;
}

public
string getTitle(){
	return Title;
}

public
decimal getHours(){
	return Hours;
}

public
DateTime getSDate(){
	return SDate;
}

public
decimal getDirectHoursToShifts(){
	return DirectHoursToShifts;
}

} // class
} // package