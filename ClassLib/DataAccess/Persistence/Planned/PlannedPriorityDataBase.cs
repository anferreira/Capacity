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
class PlannedPriorityDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int MachineId;
private int MachPriority;
private string Planned;
private string Labour;
private string Part;
private decimal QtyPlanned;

public
PlannedPriorityDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from plannedpriority where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from plannedpriority where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.MachineId = reader.GetInt32("MachineId");
	this.MachPriority = reader.GetInt32("MachPriority");
	this.Planned = reader.GetString("Planned");
	this.Labour = reader.GetString("Labour");
	this.Part = reader.GetString("Part");
	this.QtyPlanned = reader.GetDecimal("QtyPlanned");
}

public override
void write(){
	string sql = "insert into plannedpriority(" + 
		"HdrId," +
		"Detail," +
		"MachineId," +
		"MachPriority," +
		"Planned," +
		"Labour," +
		"Part," +
		"QtyPlanned" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(MachineId) + "," +
		"" + NumberUtil.toString(MachPriority) + "," +
		"'" + Converter.fixString(Planned) + "'," +
		"'" + Converter.fixString(Labour) + "'," +
		"'" + Converter.fixString(Part) + "'," +
		"" + NumberUtil.toString(QtyPlanned) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update plannedpriority set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"MachineId = " + NumberUtil.toString(MachineId) + ", " +
		"MachPriority = " + NumberUtil.toString(MachPriority) + ", " +
		"Planned = '" + Converter.fixString(Planned) + "', " +
		"Labour = '" + Converter.fixString(Labour) + "', " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"QtyPlanned = " + NumberUtil.toString(QtyPlanned) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from plannedpriority where " + getWhereCondition();
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
void setMachineId(int MachineId){
	this.MachineId = MachineId;
}

public
void setMachPriority(int MachPriority){
	this.MachPriority = MachPriority;
}

public
void setPlanned(string Planned){
	this.Planned = Planned;
}

public
void setLabour(string Labour){
	this.Labour = Labour;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setQtyPlanned(decimal QtyPlanned){
	this.QtyPlanned = QtyPlanned;
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
int getMachineId(){
	return MachineId;
}

public
int getMachPriority(){
	return MachPriority;
}

public
string getPlanned(){
	return Planned;
}

public
string getLabour(){
	return Labour;
}

public
string getPart(){
	return Part;
}

public
decimal getQtyPlanned(){
	return QtyPlanned;
}

} // class
} // package