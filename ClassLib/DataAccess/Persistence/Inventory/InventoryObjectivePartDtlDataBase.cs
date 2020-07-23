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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class InventoryObjectivePartDtlDataBase : GenericDataBaseElement {

private int HdrId;
private int Detail;
private int SubDtl;
private DateTime DateObjective;
private decimal DaysOnHand;
private decimal Qty;
private decimal QtyReported;

public
InventoryObjectivePartDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from inventoryobjectivepartdtl where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from inventoryobjectivepartdtl where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.HdrId = reader.GetInt32("HdrId");
	this.Detail = reader.GetInt32("Detail");
	this.SubDtl = reader.GetInt32("SubDtl");
	this.DateObjective = reader.GetDateTime("DateObjective");
	this.DaysOnHand = reader.GetDecimal("DaysOnHand");
	this.Qty = reader.GetDecimal("Qty");
	this.QtyReported = reader.GetDecimal("QtyReported");
}

public override 
void write(){
	string sql = "insert into inventoryobjectivepartdtl(" + 
		"HdrId," +
		"Detail," +
		"SubDtl," +
		"DateObjective," +
		"DaysOnHand," +
		"Qty," +
		"QtyReported" +

		") values (" + 

		"" + NumberUtil.toString(HdrId) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(SubDtl) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(DateObjective) + "'," +
		"" + NumberUtil.toString(DaysOnHand) + "," +
		"" + NumberUtil.toString(Qty) + "," +
		"" + NumberUtil.toString(QtyReported) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update inventoryobjectivepartdtl set " +
		"HdrId = " + NumberUtil.toString(HdrId) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"SubDtl = " + NumberUtil.toString(SubDtl) + ", " +
		"DateObjective = '" + DateUtil.getCompleteDateRepresentation(DateObjective) + "', " +
		"DaysOnHand = " + NumberUtil.toString(DaysOnHand) + ", " +
		"Qty = " + NumberUtil.toString(Qty) + ", " +
		"QtyReported = " + NumberUtil.toString(QtyReported) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from inventoryobjectivepartdtl where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HdrId = " + NumberUtil.toString(HdrId) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + " and " +
		"SubDtl = " + NumberUtil.toString(SubDtl) + "";
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
void setSubDtl(int SubDtl){
	this.SubDtl = SubDtl;
}

public
void setDateObjective(DateTime DateObjective){
	this.DateObjective = DateObjective;
}

public
void setDaysOnHand(decimal DaysOnHand){
	this.DaysOnHand = DaysOnHand;
}

public
void setQty(decimal Qty){
	this.Qty = Qty;
}

public
void setQtyReported(decimal QtyReported){
	this.QtyReported = QtyReported;
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
int getSubDtl(){
	return SubDtl;
}

public
DateTime getDateObjective(){
	return DateObjective;
}

public
decimal getDaysOnHand(){
	return DaysOnHand;
}

public
decimal getQty(){
	return Qty;
}

public
decimal getQtyReported(){
	return QtyReported;
}

} // class
} // package