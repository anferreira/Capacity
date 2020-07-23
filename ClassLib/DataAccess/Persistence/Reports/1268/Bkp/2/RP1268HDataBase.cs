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

public
RP1268HDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from " + getTablePrefix3() + "rp1268h where " + getWhereCondition();
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
}

public override
void write(){
	string sql = "insert into " + getTablePrefix3() + "rp1268h(" + 
		"Id," +
		"Date," +
        "Time" +

        ") values (" + 

		"" + NumberUtil.toString(Id) + "," +
		"'" + DateUtil.getDateRepresentation(date) + "'," +
        "'" + DateUtil.getTimeRepresentation(time) + "')";    
	write(sql);	
}

public override
void update(){
	string sql = "update " + getTablePrefix3() + "rp1268h set " +
		"Id = " + NumberUtil.toString(Id) + ", " +
		"Date = '" + DateUtil.getCompleteDateRepresentation(date) + "', " +
        "Time = '" + DateUtil.getTimeRepresentation(time).Replace(":", "") + "' " +

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

} // class
} // package