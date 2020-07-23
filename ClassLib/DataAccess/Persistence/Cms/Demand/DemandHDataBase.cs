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
class DemandHDataBase : GenericDataBaseElement {

private int Id;
private DateTime DateTime;
private string Status;
private DateTime StaDate;
private DateTime EndDate;
private string Plant;


public
DemandHDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
    string sql = "select * from " + getTablePrefix2() + "demandh where " + getWhereCondition();
	return read(sql);
}

public
bool readLastByFilter(string splant){
    string sql = "select * from demandh h where h.Id in (select max(h2.Id) from demandh h2 ";
    
    if (!string.IsNullOrEmpty(splant))                     
        sql+= " where Plant='" + splant +"'";
    sql+=")";

	return read(sql);	
}

public
bool exists(){
    string sql = "select * from " + getTablePrefix2() + "demandh where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
    this.DateTime = reader.GetDateTime("DateTime");	
	this.Status = reader.GetString("Status");
	this.StaDate = reader.GetDateTime("StaDate");	
	this.EndDate = reader.GetDateTime("EndDate");	
    this.Plant = reader.GetString("Plant");
}

public override
void write(){    
    string sql = "insert into " + getTablePrefix2() + "demandh(" + 
		 (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE ? "Id," : "") + 
		"DateTime," +		
		"Status," +
		"StaDate," +		
		"EndDate," +
        "Plant" +

        ") values (" +

        (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE ? NumberUtil.toString(Id) : "") + 		
		"'" + DateUtil.getCompleteDateRepresentation(DateTime) + "'," +        
		"'" + Converter.fixString(Status) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(StaDate) + "'," +        
        "'" + DateUtil.getCompleteDateRepresentation(EndDate) + "'," +
        "'" + Converter.fixString(Plant) + "')";
    try{
        write(sql);
        if (dataBaseAccess.getConnectionType() != DataBaseAccess.CMS_DATABASE)
            this.Id = dataBaseAccess.getLastId();
    }catch(Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)
            System.Windows.Forms.MessageBox.Show("write demandh error: " + ex.Message);
    }    
}

public override
void update(){
    string sql = "update  " + getTablePrefix2() + "demandh set " +		
        "DateTime = '" + DateUtil.getCompleteDateRepresentation(DateTime) + "', " +        
		"Status = '" + Converter.fixString(Status) + "', " +
        "StaDate = '" + DateUtil.getCompleteDateRepresentation(StaDate) + "', " +        
        "EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "', " +
        "Plant = '" + Converter.fixString(Plant) + "' " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
    string sql = "delete from " + getTablePrefix2() + "demandh where " + getWhereCondition();
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
void setDateTime(DateTime DateTime){
    this.DateTime = DateTime;
}

public
void setStatus(string Status){
	this.Status = Status;
}

public
void setStaDate(DateTime StaDate){
	this.StaDate = StaDate;
}

public
void setEndDate(DateTime EndDate){
	this.EndDate = EndDate;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}
      
public
int getId(){
	return Id;
}

public
DateTime getDateTime(){
    return DateTime;
}

public
string getStatus(){
	return Status;
}

public
DateTime getStaDate(){
	return StaDate;
}

public
DateTime getEndDate(){
	return EndDate;
}

public
string getPlant(){
	return Plant;
}


} // class
} // package