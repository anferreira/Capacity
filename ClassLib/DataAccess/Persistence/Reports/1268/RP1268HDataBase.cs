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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Reports{

    public
class RP1268HDataBase : GenericDataBaseElement {

private int Id;
private DateTime date;
private DateTime time;
private string status;

public
RP1268HDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from " + getTablePrefix3() + "rp1268h where " + getWhereCondition();
	return read(sql);
}

public
bool readLast(){
	string sql = "select * from " + getTablePrefix3() + "rp1268h where Id in (select max(id) from " + getTablePrefix3()  + "RP1268H)";
	return read(sql);
}

public
bool readLastByStatus(string status){
	string sql = "select * from " + getTablePrefix3() + "rp1268h where Id in (select max(id) from " + getTablePrefix3()  + "RP1268H where Status='"+ status + "')";
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTablePrefix3() + "rp1268h where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.date = reader.GetDateTime("Date");
    this.time = reader.GetDateTime("Time");
    this.status = reader.GetString("Status");
}

public override
void write(){
	string sql = "insert into " + getTablePrefix3() + "rp1268h(" + 
		"Id," +
		"Date," +
        "Time," +
        "Status" +
        
        ") values (" + 

		"" + NumberUtil.toString(Id) + "," +
		"'" + DateUtil.getDateRepresentation(date) + "'," +
        "'" + DateUtil.getTimeRepresentation(time) + "'," +
        "'" + status + "')";   
	//write(sql);	

    try{
        //System.Windows.Forms.MessageBox.Show("write rp1268h: " + sql);
        write(sql);
    }catch(Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)
            System.Windows.Forms.MessageBox.Show("write rp1268h error: " + ex.Message);
    }
}

public override
void update(){
	string sql = "update " + getTablePrefix3() + "rp1268h set " +
		"Id = " + NumberUtil.toString(Id) + ", " +
        "Date = '" + DateUtil.getDateRepresentation(date) + "'," +
        "Time = '" + DateUtil.getTimeRepresentation(time) + "'," +
        "Status = '" + status + "' " +

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rp1268h where " + getWhereCondition();
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
void setDate(DateTime date){
	this.date = date;
}

public
void setTime(DateTime time){
	this.time = time;
}

public
void setStatus(string status){
	this.status = status;
}

public
int getId(){
	return Id;
}

public
DateTime getDate(){
	return date;
}

public
DateTime getTime(){
	return time;
}

public
string getStatus(){
	return status;
}

public
void updateAllStatusExceptOneId(int id,string status){
	string sql = "update " + getTablePrefix3() + "rp1268h set " +
        "Status = '" + status + "' " +
        "where Id <> " + NumberUtil.toString(Id);
	update(sql);
}

} // class
} // package