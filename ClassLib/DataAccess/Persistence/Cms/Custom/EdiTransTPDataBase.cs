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
class EdiTransTPDataBase : GenericDataBaseElement {

private string Plant;
private string TPartner;
private int Detail;
private int LogFrom;
private int LogTo;
private DateTime DateProces;
private DateTime DateCreated;

public
EdiTransTPDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from editranstp where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from editranstp where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){    
    this.Plant = reader.GetString("Plant");
    this.TPartner = reader.GetString("TPartner");
	this.Detail = reader.GetInt32("Detail");
	this.LogFrom = reader.GetInt32("LogFrom");
	this.LogTo = reader.GetInt32("LogTo");            
    this.DateProces = reader.GetDateTime("DateProces");
    this.DateCreated = reader.GetDateTime("DateCreated");
}

public override
void write(){
	string sql = "insert into editranstp(" +
        "Plant," +
        "TPartner," +
		"Detail," +
		"LogFrom," +
		"LogTo," +
        "DateProces," +        
        "DateCreated" +

		") values (" +

        "'" + Converter.fixString(Plant) + "'," +
        "'" + Converter.fixString(TPartner) + "'," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(LogFrom) + "," +
		"" + NumberUtil.toString(LogTo) + "," +
        "'" + DateUtil.getCompleteDateRepresentation(DateProces) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(DateCreated) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update editranstp set " +
        "Plant='" + Converter.fixString(Plant) + "'," +
		"TPartner = '" + Converter.fixString(TPartner) + "', " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"LogFrom = " + NumberUtil.toString(LogFrom) + ", " +
		"LogTo = " + NumberUtil.toString(LogTo) + ", " +
        "DateProces='" + DateUtil.getCompleteDateRepresentation(DateProces) + "'," +
        "DateCreated = '" + DateUtil.getCompleteDateRepresentation(DateCreated) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from editranstp where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
        "Plant='" + Converter.fixString(Plant) + "' and " +
        "TPartner = '" + Converter.fixString(TPartner) + "' and " +
		"Detail = " + NumberUtil.toString(Detail) + "";
	return sqlWhere;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setTPartner(string TPartner){
	this.TPartner = TPartner;
}

public
void setDetail(int Detail){
	this.Detail = Detail;
}

public
void setLogFrom(int LogFrom){
	this.LogFrom = LogFrom;
}

public
void setLogTo(int LogTo){
	this.LogTo = LogTo;
}

public
void setDateProces(DateTime DateProces){
	this.DateProces = DateProces;
}

public
void setDateCreated(DateTime DateCreated){
	this.DateCreated = DateCreated;
}

public
string getPlant(){
	return Plant;
}

public
string getTPartner(){
	return TPartner;
}

public
int getDetail(){
	return Detail;
}

public
int getLogFrom(){
	return LogFrom;
}

public
int getLogTo(){
	return LogTo;
}

public
DateTime getDateProces(){
    return DateProces;
}

public
DateTime getDateCreated(){
	return DateCreated;
}

} // class
} // package