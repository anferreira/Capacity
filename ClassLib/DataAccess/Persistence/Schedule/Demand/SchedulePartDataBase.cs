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
class SchedulePartDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private string Part;
private string IsFamily;
private int Seq;
private decimal Qty;
private DateTime StartDate;
private DateTime EndDate;
private int StartShift;
private int Priority;
private int Queue;
private decimal RunStd;
private decimal CavityNum;
private decimal QtyReported;
private string Uom;
private int CapacityHdrId;
private int HotListId;
private int MachId;
private decimal SchNonChargeDT;
private decimal SchChargeDT;

public
SchedulePartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from schedulepart where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from schedulepart where " + getWhereCondition();
	return exists(sql);
}


public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");    
	this.Part = reader.GetString("Part");
	this.IsFamily = reader.GetString("IsFamily");
	this.Seq = reader.GetInt32("Seq");
	this.Qty = reader.GetDecimal("Qty");
	this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");
	this.StartShift = reader.GetInt32("StartShift");

    this.Priority = reader.GetInt32("Priority");
    this.Queue = reader.GetInt32("Queue"); 
    this.RunStd = reader.GetDecimal("RunStd");
    this.CavityNum = reader.GetDecimal("CavityNum");
    this.QtyReported = reader.GetDecimal("QtyReported");
    this.Uom = reader.GetString("Uom");
    this.CapacityHdrId = reader.GetInt32("CapacityHdrId");
    this.HotListId = reader.GetInt32("HotListId");

    this.MachId =reader.GetInt32("MachId");
    this.SchNonChargeDT = reader.GetDecimal("SchNonChargeDT");
    this.SchChargeDT = reader.GetDecimal("SchChargeDT");
}

public override
void write(){ 
	string sql = "insert into schedulepart(" + 
		"HdrId," +
		"Detail," +        
        "Part," +
		"IsFamily," +
		"Seq," +
		"Qty," +
		"StartDate," +
		"EndDate," +
		"StartShift," +
        "Priority," +
        "Queue," +
        "RunStd," +
        "CavityNum," +
        "QtyReported," +
        "Uom," +
        "CapacityHdrId," +
        "HotListId," +
        "MachId," +
        "SchNonChargeDT," +
        "SchChargeDT" +
          
        ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +        
        "'" + Converter.fixString(Part) + "'," +
		"'" + Converter.fixString(IsFamily) + "'," +
		"" + NumberUtil.toString(Seq) + "," +
		"" + NumberUtil.toString(Qty) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate) + "'," +
		"" + NumberUtil.toString(StartShift) + "," +
        "" + NumberUtil.toString(Priority) + "," +
		"" + NumberUtil.toString(Queue) + "," +
        "" + NumberUtil.toString(RunStd) + "," +
		"" + NumberUtil.toString(CavityNum) + "," +
        "" + NumberUtil.toString(QtyReported) + "," +
        "'" + Converter.fixString(Uom) + "'," +             
        "" + NumberUtil.toString(CapacityHdrId) + "," +
        "" + NumberUtil.toString(HotListId) + "," +
        "" + NumberUtil.toString(MachId) + "," +
        "" + NumberUtil.toString(SchNonChargeDT) + "," +
        "" + NumberUtil.toString(SchChargeDT) + ")";            
    write(sql);	
}

public override
void update(){
	string sql = "update schedulepart set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +        
        "Part = '" + Converter.fixString(Part) + "', " +
		"IsFamily = '" + Converter.fixString(IsFamily) + "', " +
		"Seq = " + NumberUtil.toString(Seq) + ", " +
		"Qty = " + NumberUtil.toString(Qty) + ", " +
		"StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "', " +
		"StartShift = " + NumberUtil.toString(StartShift) + ", " +
        "Priority = " + NumberUtil.toString(Priority) + ", " +
        "Queue = " + NumberUtil.toString(Queue) + ", " +
        "RunStd = " + NumberUtil.toString(Priority) + ", " +
        "CavityNum = " + NumberUtil.toString(Queue) + ", " +
        "QtyReported = " + NumberUtil.toString(QtyReported) + ", " +
        "Uom = '" + Converter.fixString(Uom) + "', " +
        "CapacityHdrId = " + NumberUtil.toString(CapacityHdrId) + ", " +
        "HotListId = " + NumberUtil.toString(HotListId) + ", " +
        "SchChargeDT = " + NumberUtil.toString(SchChargeDT) + ", " +
        "SchNonChargeDT = " + NumberUtil.toString(SchNonChargeDT) + " " +

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from schedulepart where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail);
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
void setPart(string Part){
	this.Part = Part;
}

public
void setIsFamily(string IsFamily){
	this.IsFamily = IsFamily;
}

public
void setSeq(int Seq){
	this.Seq = Seq;
}

public
void setQty(decimal Qty){
	this.Qty = Qty;
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
void setStartShift(int StartShift){
	this.StartShift = StartShift;
}

public
void setPriority(int Priority){
	this.Priority = Priority;
}

public
void setQueue(int Queue){
	this.Queue = Queue;
}

public
void setRunStd(decimal RunStd){
	this.RunStd = RunStd;
}

public
void setCavityNum(decimal CavityNum){
	this.CavityNum = CavityNum;
}

public
void setQtyReported(decimal QtyReported){
	this.QtyReported = QtyReported;
}

public
void setUom(string Uom){
	this.Uom = Uom;
}

public
void setCapacityHdrId(int CapacityHdrId){
	this.CapacityHdrId = CapacityHdrId;
}

public
void setHotListId(int HotListId){
	this.HotListId = HotListId;
}

public
void setMachId(int MachId){
	this.MachId = MachId;
}

public
void setSchNonChargeDT(decimal SchNonChargeDT){
	this.SchNonChargeDT = SchNonChargeDT;
}

public
void setSchChargeDT(decimal SchChargeDT){
	this.SchChargeDT = SchChargeDT;
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
string getPart(){
	return Part;
}

public
string getIsFamily(){
	return IsFamily;
}

public
int getSeq(){
	return Seq;
}

public
decimal getQty(){
	return Qty;
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
int getStartShift(){
	return StartShift;
}

public
int getPriority(){
	return Priority;
}

public
int getQueue(){
	return Queue;
}

public
decimal getRunStd(){
	return RunStd;
}

public
decimal getCavityNum(){
	return CavityNum;
}

public
decimal getQtyReported(){
	return QtyReported;
}

public
string getUom(){
    return Uom;
}

public
int getCapacityHdrId(){
	return CapacityHdrId;
}

public
int getHotListId(){
	return HotListId;
}

public
int getMachId(){
    return MachId;
}

public
decimal getSchNonChargeDT(){
	return SchNonChargeDT;
}

public
decimal getSchChargeDT(){
	return SchChargeDT;
}


} // class
} // package