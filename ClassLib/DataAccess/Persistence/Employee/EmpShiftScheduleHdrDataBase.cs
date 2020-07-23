/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmpShiftScheduleHdrDataBase : GenericDataBaseElement {

private int Id;
private string Plant;
private DateTime Date;
private int ShiftNum;
private string Dept;
private string Notes;
private string CreatedByEmpId;

private string PreShiftNote;
private string PostShiftNote;

public
EmpShiftScheduleHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from empshiftschedulehdr where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from empshiftschedulehdr where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.Plant = reader.GetString("Plant");
	this.Date = reader.GetDateTime("Date");
	this.ShiftNum = reader.GetInt32("ShiftNum");
	this.Dept = reader.GetString("Dept");
	this.Notes = reader.GetString("Notes");
	this.CreatedByEmpId = reader.GetString("CreatedByEmpId");

    this.PreShiftNote = reader.GetString("PreShiftNote");
    this.PostShiftNote= reader.GetString("PostShiftNote");
}

public override
void write(){
	string sql = "insert into empshiftschedulehdr(" + 
		"Plant," +
		"Date," +
		"ShiftNum," +
		"Dept," +
		"Notes," +
		"CreatedByEmpId," +

        "PreShiftNote," +
        "PostShiftNote" +        
            ") values (" + 

		"'" + Converter.fixString(Plant) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(Date) + "'," +
		"" + NumberUtil.toString(ShiftNum) + "," +
		"'" + Converter.fixString(Dept) + "'," +
		"'" + Converter.fixString(Notes) + "'," +
		"'" + Converter.fixString(CreatedByEmpId) + "'," +

        "'" + Converter.fixString(PreShiftNote) + "'," +
		"'" + Converter.fixString(PostShiftNote) + "')";            

	write(sql);
	this.setId(dataBaseAccess.getLastId());
}

public override
void update(){
	string sql = "update empshiftschedulehdr set " +
		"Plant = '" + Converter.fixString(Plant) + "', " +
		"Date = '" + DateUtil.getCompleteDateRepresentation(Date) + "', " +
		"ShiftNum = " + NumberUtil.toString(ShiftNum) + ", " +
		"Dept = '" + Converter.fixString(Dept) + "', " +
		"Notes = '" + Converter.fixString(Notes) + "', " +
		"CreatedByEmpId = '" + Converter.fixString(CreatedByEmpId) + "', " +

   		"PreShiftNote = '" + Converter.fixString(PreShiftNote) + "', " +
        "PostShiftNote = '" + Converter.fixString(PostShiftNote) + "' " +        

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from empshiftschedulehdr where " + getWhereCondition();
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
void setDate(DateTime Date){
	this.Date = Date;
}

public
void setShiftNum(int ShiftNum){
	this.ShiftNum = ShiftNum;
}

public
void setDept(string Dept){
	this.Dept = Dept;
}

public
void setNotes(string Notes){
	this.Notes = Notes;
}

public
void setCreatedByEmpId(string CreatedByEmpId){
	this.CreatedByEmpId = CreatedByEmpId;
}

public
void setPreShiftNote(string PreShiftNote){
	this.PreShiftNote = PreShiftNote;
}

public
void setPostShiftNote(string PostShiftNote){
	this.PostShiftNote = PostShiftNote;
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
DateTime getDate(){
	return Date;
}

public
int getShiftNum(){
	return ShiftNum;
}

public
string getDept(){
	return Dept;
}

public
string getNotes(){
	return Notes;
}

public
string getCreatedByEmpId(){
	return CreatedByEmpId;
}

public
string getPreShiftNote(){
	return PreShiftNote;
}

public
string getPostShiftNote(){
	return PostShiftNote;
}

} // class
} // package