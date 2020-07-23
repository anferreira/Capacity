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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines{

public
class PltDeptMachDefDataBase : GenericDataBaseElement {

private int MachId;
private decimal PlanRunHrs;
private decimal HrsPerShift;
private decimal PlanDownHrs;
private decimal PlanChanOvHrs;
private decimal StdShiftPerWeek;
private decimal UnitChanOverTime;
private decimal DirectHoursToShifts;
private decimal Oee;
private decimal PerfOa;
private decimal ScrapRate;
private decimal NetPressRate;
private decimal WeeklyCapacity;
private decimal DownHrsPerShift;
private string ShowOnTvReport;
private DateTime DateLastPlanned;

public
PltDeptMachDefDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from pltdeptmachdef where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from pltdeptmachdef where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.MachId = reader.GetInt32("MachId");
	this.PlanRunHrs = reader.GetDecimal("PlanRunHrs");
	this.HrsPerShift = reader.GetDecimal("HrsPerShift");
	this.PlanDownHrs = reader.GetDecimal("PlanDownHrs");
	this.PlanChanOvHrs = reader.GetDecimal("PlanChanOvHrs");
	this.StdShiftPerWeek = reader.GetDecimal("StdShiftPerWeek");
	this.UnitChanOverTime = reader.GetDecimal("UnitChanOverTime");
	this.DirectHoursToShifts = reader.GetDecimal("DirectHoursToShifts");
	this.Oee = reader.GetDecimal("Oee");
	this.PerfOa = reader.GetDecimal("PerfOa");
	this.ScrapRate = reader.GetDecimal("ScrapRate");
	this.NetPressRate = reader.GetDecimal("NetPressRate");
    this.WeeklyCapacity = reader.GetDecimal("WeeklyCapacity");
    this.DownHrsPerShift = reader.GetDecimal("DownHrsPerShift");
    this.ShowOnTvReport = reader.GetString("ShowOnTvReport"); 
    this.DateLastPlanned = reader.GetDateTime("DateLastPlanned"); 
}

public override
void write(){
	string sql = "insert into pltdeptmachdef(" + 
		"MachId," +
		"PlanRunHrs," +
		"HrsPerShift," +
		"PlanDownHrs," +
		"PlanChanOvHrs," +
		"StdShiftPerWeek," +
		"UnitChanOverTime," +
		"DirectHoursToShifts," +
		"Oee," +
		"PerfOa," +
		"ScrapRate," +
		"NetPressRate," +
        "WeeklyCapacity," +
        "DownHrsPerShift,"+
        "ShowOnTvReport,"+
        "DateLastPlanned" +
       
        ") values (" + 

		"" + NumberUtil.toString(MachId) + "," +
		"" + NumberUtil.toString(PlanRunHrs) + "," +
		"" + NumberUtil.toString(HrsPerShift) + "," +
		"" + NumberUtil.toString(PlanDownHrs) + "," +
		"" + NumberUtil.toString(PlanChanOvHrs) + "," +
		"" + NumberUtil.toString(StdShiftPerWeek) + "," +
		"" + NumberUtil.toString(UnitChanOverTime) + "," +
		"" + NumberUtil.toString(DirectHoursToShifts) + "," +
		"" + NumberUtil.toString(Oee) + "," +
		"" + NumberUtil.toString(PerfOa) + "," +
		"" + NumberUtil.toString(ScrapRate) + "," +
		"" + NumberUtil.toString(NetPressRate) + "," +
        "" + NumberUtil.toString(WeeklyCapacity) + "," +
        "" + NumberUtil.toString(DownHrsPerShift) + "," +
        "'" + Converter.fixString(ShowOnTvReport) + "',"+
        "'" + DateUtil.getCompleteDateRepresentation(DateLastPlanned,DateUtil.MMDDYYYY) + "')";
            
    write(sql);	
}

public override
void update(){
	string sql = "update pltdeptmachdef set " +
		"MachId = " + NumberUtil.toString(MachId) + ", " +
		"PlanRunHrs = " + NumberUtil.toString(PlanRunHrs) + ", " +
		"HrsPerShift = " + NumberUtil.toString(HrsPerShift) + ", " +
		"PlanDownHrs = " + NumberUtil.toString(PlanDownHrs) + ", " +
		"PlanChanOvHrs = " + NumberUtil.toString(PlanChanOvHrs) + ", " +
		"StdShiftPerWeek = " + NumberUtil.toString(StdShiftPerWeek) + ", " +
		"UnitChanOverTime = " + NumberUtil.toString(UnitChanOverTime) + ", " +
		"DirectHoursToShifts = " + NumberUtil.toString(DirectHoursToShifts) + ", " +
		"Oee = " + NumberUtil.toString(Oee) + ", " +
		"PerfOa = " + NumberUtil.toString(PerfOa) + ", " +
		"ScrapRate = " + NumberUtil.toString(ScrapRate) + ", " +
		"NetPressRate = " + NumberUtil.toString(NetPressRate) + ", " +
        "WeeklyCapacity = " + NumberUtil.toString(WeeklyCapacity) + ", " +
        "DownHrsPerShift = " + NumberUtil.toString(DownHrsPerShift) + ", " +
        "ShowOnTvReport ='" + Converter.fixString(ShowOnTvReport) + "', " +
        "DateLastPlanned ='" +DateUtil.getCompleteDateRepresentation(DateLastPlanned,DateUtil.MMDDYYYY) + "' " +        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from pltdeptmachdef where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"MachId = " + NumberUtil.toString(MachId) + "";
	return sqlWhere;
}

public
void setMachId(int MachId){
	this.MachId = MachId;
}

public
void setPlanRunHrs(decimal PlanRunHrs){
	this.PlanRunHrs = PlanRunHrs;
}

public
void setHrsPerShift(decimal HrsPerShift){
	this.HrsPerShift = HrsPerShift;
}

public
void setPlanDownHrs(decimal PlanDownHrs){
	this.PlanDownHrs = PlanDownHrs;
}

public
void setPlanChanOvHrs(decimal PlanChanOvHrs){
	this.PlanChanOvHrs = PlanChanOvHrs;
}

public
void setStdShiftPerWeek(decimal StdShiftPerWeek){
	this.StdShiftPerWeek = StdShiftPerWeek;
}

public
void setUnitChanOverTime(decimal UnitChanOverTime){
	this.UnitChanOverTime = UnitChanOverTime;
}

public
void setDirectHoursToShifts(decimal DirectHoursToShifts){
	this.DirectHoursToShifts = DirectHoursToShifts;
}

public
void setOee(decimal Oee){
	this.Oee = Oee;
}

public
void setPerfOa(decimal PerfOa){
	this.PerfOa = PerfOa;
}

public
void setScrapRate(decimal ScrapRate){
	this.ScrapRate = ScrapRate;
}

public
void setNetPressRate(decimal NetPressRate){
	this.NetPressRate = NetPressRate;
}

public
void setWeeklyCapacity(decimal WeeklyCapacity){
	this.WeeklyCapacity = WeeklyCapacity;
}

public
void setDownHrsPerShift(decimal DownHrsPerShift){
	this.DownHrsPerShift = DownHrsPerShift;
}

public
void setShowOnTvReport(string ShowOnTvReport){
	this.ShowOnTvReport = ShowOnTvReport;
}

public
void setDateLastPlanned(DateTime DateLastPlanned){
	this.DateLastPlanned = DateLastPlanned;
}

public
int getMachId(){
	return MachId;
}

public
decimal getPlanRunHrs(){
	return PlanRunHrs;
}

public
decimal getHrsPerShift(){
	return HrsPerShift;
}

public
decimal getPlanDownHrs(){
	return PlanDownHrs;
}

public
decimal getPlanChanOvHrs(){
	return PlanChanOvHrs;
}

public
decimal getStdShiftPerWeek(){
	return StdShiftPerWeek;
}

public
decimal getUnitChanOverTime(){
	return UnitChanOverTime;
}

public
decimal getDirectHoursToShifts(){
	return DirectHoursToShifts;
}

public
decimal getOee(){
	return Oee;
}

public
decimal getPerfOa(){
	return PerfOa;
}

public
decimal getScrapRate(){
	return ScrapRate;
}

public
decimal getNetPressRate(){
	return NetPressRate;
}

public
decimal getWeeklyCapacity(){
    return WeeklyCapacity;
}

public
decimal getDownHrsPerShift(){
    return DownHrsPerShift;
}

public
string getShowOnTvReport(){
    return ShowOnTvReport;
}

public
DateTime getDateLastPlanned(){
	return DateLastPlanned;
}

public
void updateWeeklyCapacity(){
    string sql ="update d2 SET d2.WeeklyCapacity =( " +
                " select COALESCE( max(r.PC_RunStd),1) from PltDeptMachDef d, prodfmactsub r, PltDeptMach m " +
                " where  d2.MachId> 0 and d2.MachId = d.MachId and d.MachId = m.PDM_Id " +
                " and m.PDM_Plt= r.PC_Plt and m.PDM_Dept = r.PC_Dept and m.PDM_Mach = r.PC_Cfg ) * d2.HrsPerShift * d2.StdShiftPerWeek " +
                " FROM PltDeptMachDef d2 , PltDeptMach mm where d2.MachId= mm.PDM_Id and d2.WeeklyCapacity<> 0";
    update(sql);
}


} // class
} // package