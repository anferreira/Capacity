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
class EmpShiftScheduleDtlDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private string EmpId;
private int MachId;
private int LabourTypeId;
private decimal LabMultiplier;
private string Absent;

public
EmpShiftScheduleDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from empshiftscheduledtl where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from empshiftscheduledtl where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.EmpId = reader.GetString("EmpId");
	this.MachId = reader.GetInt32("MachId");
	this.LabourTypeId = reader.GetInt32("LabourTypeId");
    this.LabMultiplier = reader.GetDecimal("LabMultiplier");
    this.Absent = reader.GetString("Absent");
}

public override
void write(){
	string sql = "insert into empshiftscheduledtl(" + 
		"HdrId," +
		"Detail," +
		"EmpId," +
		"MachId," +
		"LabourTypeId," +
        "LabMultiplier," +
        "Absent" +
       
        ") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(EmpId) + "'," +
		"" + NumberUtil.toString(MachId) + "," +
		"" + NumberUtil.toString(LabourTypeId) + "," +
        "" + NumberUtil.toString(LabMultiplier) + "," +
        "'" + Converter.fixString(Absent) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update empshiftscheduledtl set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"EmpId = '" + Converter.fixString(EmpId) + "', " +
		"MachId = " + NumberUtil.toString(MachId) + ", " +
		"LabourTypeId = " + NumberUtil.toString(LabourTypeId) + ", " +
        "LabMultiplier = " + NumberUtil.toString(LabMultiplier) + ", " +
        "Absent = '" + Converter.fixString(Absent) + "' " +
        
        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from empshiftscheduledtl where " + getWhereCondition();
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
void setEmpId(string EmpId){
	this.EmpId = EmpId;
}

public
void setMachId(int MachId){
	this.MachId = MachId;
}

public
void setLabourTypeId(int LabourTypeId){
	this.LabourTypeId = LabourTypeId;
}

public
void setLabMultiplier(decimal LabMultiplier){
	this.LabMultiplier = LabMultiplier;
}

public
void setAbsent(string Absent){
	this.Absent = Absent;
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
string getEmpId(){
	return EmpId;
}

public
int getMachId(){
	return MachId;
}

public
int getLabourTypeId(){
	return LabourTypeId;
}

public
decimal getLabMultiplier(){
	return LabMultiplier;
}

public
string getAbsent(){
	return Absent;
}

} // class
} // package