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
class EmpShiftScheduleNotesDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private string Topic;
private string Notes;

public
EmpShiftScheduleNotesDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from empshiftschedulenotes where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from empshiftschedulenotes where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.Topic = reader.GetString("Topic");
	this.Notes = reader.GetString("Notes");
}

public override
void write(){
	string sql = "insert into empshiftschedulenotes(" + 
		"HdrId," +
		"Detail," +
		"Topic," +
		"Notes" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(Topic) + "'," +
		"'" + Converter.fixString(Notes) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update empshiftschedulenotes set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Topic = '" + Converter.fixString(Topic) + "', " +
		"Notes = '" + Converter.fixString(Notes) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from empshiftschedulenotes where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + "";
	return sqlWhere;
}

public
void setHdrId(int HdrId){
	this.HdrId = HdrId;
}

public
void setDetail(int Detail){
	this.Detail = Detail;
}

public
void setTopic(string Topic){
	this.Topic = Topic;
}

public
void setNotes(string Notes){
	this.Notes = Notes;
}

public
int getHdrId(){
	return HdrId;
}

public
int getDetail(){
	return Detail;
}

public
string getTopic(){
	return Topic;
}

public
string getNotes(){
	return Notes;
}

} // class
} // package