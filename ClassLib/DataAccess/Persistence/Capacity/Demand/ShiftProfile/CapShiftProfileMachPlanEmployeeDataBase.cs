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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapShiftProfileMachPlanEmployeeDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDetail;
private string EmpId;

public
CapShiftProfileMachPlanEmployeeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capshiftprofilemachplanemployee where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capshiftprofilemachplanemployee where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDetail = reader.GetInt32("SubDetail");
	this.EmpId = reader.GetString("EmpId");
}

public override
void write(){
	string sql = "insert into capshiftprofilemachplanemployee(" + 
		"HdrId," +
		"Detail," +
		"SubDetail," +
		"EmpId" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDetail) + "," +
		"'" + Converter.fixString(EmpId) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update capshiftprofilemachplanemployee set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDetail = " + NumberUtil.toString(SubDetail) + ", " +
		"EmpId = '" + Converter.fixString(EmpId) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capshiftprofilemachplanemployee where " + getWhereCondition();
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
void setEmpId(string EmpId){
	this.EmpId = EmpId;
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
string getEmpId(){
	return EmpId;
}

} // class
} // package