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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class ScheduleReceiptPartDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private DateTime StartDate;
private DateTime RecDate;
private int RecShift;
private decimal RecQty;
private decimal RepQty;

public
ScheduleReceiptPartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from schedulereceiptpart where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from schedulereceiptpart where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");    
    this.StartDate = reader.GetDateTime("StartDate");
	this.RecDate = reader.GetDateTime("RecDate");
	this.RecShift = reader.GetInt32("RecShift");
	this.RecQty = reader.GetDecimal("RecQty");
    this.RepQty =reader.GetDecimal("RepQty");
}

public override
void write(){ 
	string sql = "insert into schedulereceiptpart(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +        
        "StartDate," +
        "RecDate," +
		"RecShift," +
        "RecQty," +
        "RepQty" +
        
        ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +        
        "'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(RecDate) + "'," +
		"" + NumberUtil.toString(RecShift) + "," +
		"" + NumberUtil.toString(RecQty) + "," +
        "" + NumberUtil.toString(RepQty) + ")";
            
    write(sql);	
}

public override
void update(){
	string sql = "update schedulereceiptpart set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +
        "StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
        "RecDate = '" + DateUtil.getCompleteDateRepresentation(RecDate) + "', " +
		"RecShift = " + NumberUtil.toString(RecShift) + ", " +
		"RecQty = " + NumberUtil.toString(RecQty) + ", " +
        "RepQty = " + NumberUtil.toString(RepQty) + " " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from schedulereceiptpart where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + " and " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + "";
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
void setSubDetail(int SubDetail){
	this.SubDetail = SubDetail;
}
             
public
void setStartDate(DateTime StartDate){
	this.StartDate = StartDate;
}

public
void setRecDate(DateTime RecDate){
	this.RecDate = RecDate;
}

public
void setRecShift(int RecShift){
	this.RecShift = RecShift;
}

public
void setRecQty(decimal RecQty){
	this.RecQty = RecQty;
}

public
void setRepQty(decimal RepQty){
	this.RepQty = RepQty;
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
int getSubDetail(){
	return SubDetail;
}

public
DateTime getStartDate(){
    return StartDate;
}
    
public
DateTime getRecDate(){
	return RecDate;
}

public
int getRecShift(){
	return RecShift;
}

public
decimal getRecQty(){
	return RecQty;
}

public
decimal getRepQty(){
    return RepQty;
}

} // class
} // package