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
class PlannedPartDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private string Part;
private int Seq;
private string IsFamily;
private decimal QtyOriginal;
private decimal QtyPlanned;
private decimal QtyChange;
private decimal QtyOvertime;
private DateTime StartDate;
private DateTime EndDate;
private int ProfMachPlanHdrId;
private int ProfMachPlanHdrDtl;

public
PlannedPartDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from plannedpart where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from plannedpart where " + getWhereCondition();
	return exists(sql);
}

public
bool existsShifrProfile(int iprofShiftHdrId, int iprofShiftHdrDtl){
	string sql ="select * from plannedpart where " +
                " ProfMachPlanHdrId = " + NumberUtil.toString(iprofShiftHdrId) + " and " +
                " ProfMachPlanHdrDtl= " + NumberUtil.toString(iprofShiftHdrDtl); 
    return read(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");
	this.Part = reader.GetString("Part");
	this.Seq = reader.GetInt32("Seq");
	this.IsFamily = reader.GetString("IsFamily");
	this.QtyOriginal = reader.GetDecimal("QtyOriginal");
	this.QtyPlanned = reader.GetDecimal("QtyPlanned");
    this.QtyChange = reader.GetDecimal("QtyChange");
    this.QtyOvertime = reader.GetDecimal("QtyOvertime");
    this.StartDate = reader.GetDateTime("StartDate");
	this.EndDate = reader.GetDateTime("EndDate");
    this.ProfMachPlanHdrId = reader.GetInt32("ProfMachPlanHdrId");
    this.ProfMachPlanHdrDtl = reader.GetInt32("ProfMachPlanHdrDtl");
}

public override
void write(){
	string sql = "insert into plannedpart(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +
		"Part," +
		"Seq," +
		"IsFamily," +
		"QtyOriginal," +
		"QtyPlanned," +
        "QtyChange," +
        "QtyOvertime," + 
        "StartDate," +
		"EndDate," +
        "ProfMachPlanHdrId,"+
        "ProfMachPlanHdrDtl"+

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +
		"'" + Converter.fixString(Part) + "'," +
		"" + NumberUtil.toString(Seq) + "," +
		"'" + Converter.fixString(IsFamily) + "'," +
		"" + NumberUtil.toString(QtyOriginal) + "," +
		"" + NumberUtil.toString(QtyPlanned) + "," +
        "" + NumberUtil.toString(QtyChange) + "," +
        "" + NumberUtil.toString(QtyOvertime) + "," +        
        "'" + DateUtil.getCompleteDateRepresentation(StartDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(EndDate) + "',"+
        "" + NumberUtil.toString(ProfMachPlanHdrId) + "," +  
        "" + NumberUtil.toString(ProfMachPlanHdrDtl) + ")";      

	write(sql);	
}

public override
void update(){
	string sql = "update plannedpart set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"Seq = " + NumberUtil.toString(Seq) + ", " +
		"IsFamily = '" + Converter.fixString(IsFamily) + "', " +
		"QtyOriginal = " + NumberUtil.toString(QtyOriginal) + ", " +
		"QtyPlanned = " + NumberUtil.toString(QtyPlanned) + ", " +
        "QtyChange = " + NumberUtil.toString(QtyChange) + ", " +
        "QtyOvertime = " + NumberUtil.toString(QtyOvertime) + ", " +        
        "StartDate = '" + DateUtil.getCompleteDateRepresentation(StartDate) + "', " +
		"EndDate = '" + DateUtil.getCompleteDateRepresentation(EndDate) + "', " +
        "ProfMachPlanHdrId = " + NumberUtil.toString(ProfMachPlanHdrId) + ", " +
        "ProfMachPlanHdrDtl = " + NumberUtil.toString(ProfMachPlanHdrDtl) + " " +

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from plannedpart where " + getWhereCondition();
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
void setPart(string Part){
	this.Part = Part;
}

public
void setSeq(int Seq){
	this.Seq = Seq;
}

public
void setIsFamily(string IsFamily){
	this.IsFamily = IsFamily;
}

public
void setQtyOriginal(decimal QtyOriginal){
	this.QtyOriginal = QtyOriginal;
}

public
void setQtyPlanned(decimal QtyPlanned){
	this.QtyPlanned = QtyPlanned;
}

public
void setQtyChange(decimal QtyChange){
	this.QtyChange = QtyChange;
}

public
void setQtyOvertime(decimal QtyOvertime){
	this.QtyOvertime = QtyOvertime;
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
void setProfMachPlanHdrId(int ProfMachPlanHdrId){
	this.ProfMachPlanHdrId = ProfMachPlanHdrId;
}

public
void setProfMachPlanHdrDtl(int ProfMachPlanHdrDtl){
	this.ProfMachPlanHdrDtl = ProfMachPlanHdrDtl;
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
string getPart(){
	return Part;
}

public
int getSeq(){
	return Seq;
}

public
string getIsFamily(){
	return IsFamily;
}

public
decimal getQtyOriginal(){
	return QtyOriginal;
}

public
decimal getQtyPlanned(){
	return QtyPlanned;
}

public
decimal getQtyChange(){
	return QtyChange;
}

public
decimal getQtyOvertime(){
	return QtyOvertime;
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
int getProfMachPlanHdrId(){
	return ProfMachPlanHdrId;
}

public
int getProfMachPlanHdrDtl(){
	return ProfMachPlanHdrDtl;
}

} // class
} // package