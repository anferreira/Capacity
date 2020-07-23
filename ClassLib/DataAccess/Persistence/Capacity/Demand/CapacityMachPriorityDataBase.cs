/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapacityMachPriorityDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int MachineId;
private int Priority;
private string Planned;
private string Labour;
private string Part;
private decimal Qty;

public
CapacityMachPriorityDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from capacitymachpriority where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from capacitymachpriority where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.MachineId = reader.GetInt32("MachineId");
	this.Priority = reader.GetInt32("Priority");
	this.Planned = reader.GetString("Planned");
	this.Labour = reader.GetString("Labour");
	this.Part = reader.GetString("Part");
	this.Qty = reader.GetDecimal("Qty");
}

public override
void write(){ 
	string sql = "insert into capacitymachpriority(" + 
		"HdrId," +
		"Detail," +
		"MachineId," +
		"Priority," +
		"Planned," +
		"Labour," +
		"Part," +
		"Qty" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(MachineId) + "," +
		"" + NumberUtil.toString(Priority) + "," +
		"'" + Converter.fixString(Planned) + "'," +
		"'" + Converter.fixString(Labour) + "'," +
		"'" + Converter.fixString(Part) + "'," +
		"" + NumberUtil.toString(Qty) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update capacitymachpriority set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"MachineId = " + NumberUtil.toString(MachineId) + ", " +
		"Priority = " + NumberUtil.toString(Priority) + ", " +
		"Planned = '" + Converter.fixString(Planned) + "', " +
		"Labour = '" + Converter.fixString(Labour) + "', " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"Qty = " + NumberUtil.toString(Qty) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capacitymachpriority where " + getWhereCondition();
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
void setPriority(int Priority){
	this.Priority = Priority;
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
void setQty(decimal Qty){
	this.Qty = Qty;
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
int getPriority(){
	return Priority;
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
decimal getQty(){
	return Qty;
}

public
bool readByHdrMachine(int ihdrId,int imachineId){
	string sql= "select * from capacitymachpriority where " +
                " HdrId = " + NumberUtil.toString(ihdrId) +
                " and MachineId = " + NumberUtil.toString(imachineId);
    return read(sql);
}

} // class
} // package