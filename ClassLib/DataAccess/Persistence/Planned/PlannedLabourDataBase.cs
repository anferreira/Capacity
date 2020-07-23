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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned { 

public
class PlannedLabourDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private int LabourTypeId;
private decimal Hours;
private decimal TotEmployPlan;
private decimal TotEmployOver;
private decimal TotEmployTemp;
private decimal TotEmployHire;
private decimal TotEmployVacation;
private decimal TotEmployAbsent;
private int ShiftNum;
private DateTime StartDate;
private DateTime EndDate;

public
PlannedLabourDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from plannedlabour where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from plannedlabour where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");
	this.LabourTypeId = reader.GetInt32("LabourTypeId");
	this.Hours = reader.GetDecimal("Hours");    
    this.TotEmployPlan= reader.GetDecimal("TotEmployPlan");
    this.TotEmployOver= reader.GetDecimal("TotEmployOver");
    this.TotEmployTemp= reader.GetDecimal("TotEmployTemp");

    this.TotEmployHire      = reader.GetDecimal("TotEmployHire");
    this.TotEmployVacation  = reader.GetDecimal("TotEmployVacation");
    this.TotEmployAbsent    = reader.GetDecimal("TotEmployAbsent");
    this.ShiftNum = reader.GetInt32("ShiftNum");

    this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");
}

public override
void write(){
	string sql = "insert into plannedlabour(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +
		"LabourTypeId," +
		"Hours," +
        "TotEmployPlan," +
        "TotEmployOver," +
        "TotEmployTemp," +
        "TotEmployHire," +
        "TotEmployVacation," +
        "TotEmployAbsent," +
        "ShiftNum," +
        "StartDate," +
		"EndDate" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +
		"" + NumberUtil.toString(LabourTypeId) + "," +
		"" + NumberUtil.toString(Hours) + "," +        
        "" + NumberUtil.toString(TotEmployPlan) + "," +
        "" + NumberUtil.toString(TotEmployOver) + "," +
        "" + NumberUtil.toString(TotEmployTemp) + "," +

        "" + NumberUtil.toString(TotEmployHire) + "," +
        "" + NumberUtil.toString(TotEmployVacation) + "," +
        "" + NumberUtil.toString(TotEmployAbsent) + "," +
        "" + NumberUtil.toString(ShiftNum) + "," +

        "'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update plannedlabour set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +
		"LabourTypeId = " + NumberUtil.toString(LabourTypeId) + ", " +
		"Hours = " + NumberUtil.toString(Hours) + ", " +
        "TotEmployPlan = " + NumberUtil.toString(TotEmployPlan) + ", " +
        "TotEmployOver = " + NumberUtil.toString(TotEmployOver) + ", " +
        "TotEmployTemp = " + NumberUtil.toString(TotEmployTemp) + ", " +

        "TotEmployHire = " + NumberUtil.toString(TotEmployHire) + ", " +
        "TotEmployVacation = " + NumberUtil.toString(TotEmployVacation) + ", " +
        "TotEmployAbsent = " + NumberUtil.toString(TotEmployAbsent) + ", " +
        "ShiftNum = " + NumberUtil.toString(ShiftNum) + ", " +
        
        "StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from plannedlabour where " + getWhereCondition();
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
void setLabourTypeId(int LabourTypeId){
	this.LabourTypeId = LabourTypeId;
}

public
void setHours(decimal Hours){
	this.Hours = Hours;
}

public
void setTotEmployPlan(decimal TotEmployPlan){
	this.TotEmployPlan = TotEmployPlan;
}

public
void setTotEmployOver(decimal TotEmployOver){
	this.TotEmployOver = TotEmployOver;
}

public
void setTotEmployTemp(decimal TotEmployTemp){
	this.TotEmployTemp = TotEmployTemp;
}

public
void setTotEmployHire(decimal TotEmployHire){
	this.TotEmployHire = TotEmployHire;
}

public
void setTotEmployVacation(decimal TotEmployVacation){
	this.TotEmployVacation = TotEmployVacation;
}

public
void setTotEmployAbsent(decimal TotEmployAbsent){
	this.TotEmployAbsent = TotEmployAbsent;
}

public
void setShiftNum(int ShiftNum){
	this.ShiftNum = ShiftNum;
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
int getLabourTypeId(){
	return LabourTypeId;
}

public
decimal getHours(){
	return Hours;
}

public
decimal getTotEmployPlan(){
    return TotEmployPlan;
}

public
decimal getTotEmployOver(){
    return TotEmployOver;
}

public
decimal getTotEmployTemp(){
	return TotEmployTemp;
}

public
decimal getTotEmployHire(){
    return TotEmployHire;
}

public
decimal getTotEmployVacation(){
	return TotEmployVacation;
}

public
decimal getTotEmployAbsent(){
	return TotEmployAbsent;
}

public
int getShiftNum(){
	return ShiftNum;
}

public
DateTime getStartDate(){
	return StartDate;
}

public
DateTime getEndDate(){
	return EndDate;
}

} // class
} // package