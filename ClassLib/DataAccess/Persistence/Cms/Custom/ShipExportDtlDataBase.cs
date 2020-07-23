/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class ShipExportDtlDataBase : GenericDataBaseElement {

private string Site;
private decimal Bol;
private decimal BolItem;
private int Detail;
private decimal OrderNum;
private decimal Item;
private string Release;
private string TimeStamp;
private string Action;
private DateTime RelDate;
private decimal RelQtyInvUnit;
private decimal QtyShippedInv;
private decimal QtyBackInv;
private DateTime DateRequest;
private DateTime ShipDate;
private string Ran;

private string User;

public
ShipExportDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from shipexportdtl where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from shipexportdtl where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){	
	this.Site = reader.GetString("Site");
	this.Bol = reader.GetDecimal("Bol");
	this.BolItem = reader.GetDecimal("BolItem");
	this.Detail = reader.GetInt32("Detail");
	this.OrderNum = reader.GetDecimal("OrderNum");
	this.Item = reader.GetDecimal("Item");
	this.Release = reader.GetString("Release");
	this.TimeStamp = reader.GetString("TimeStamp");
	this.Action = reader.GetString("Action");
	this.RelDate = reader.GetDateTime("RelDate");
	this.RelQtyInvUnit = reader.GetDecimal("RelQtyInvUnit");
	this.QtyShippedInv = reader.GetDecimal("QtyShippedInv");
	this.QtyBackInv = reader.GetDecimal("QtyBackInv");
	this.DateRequest = reader.GetDateTime("DateRequest");
	this.ShipDate = reader.GetDateTime("ShipDate");
	this.Ran = reader.GetString("Ran");

    try { this.User = reader.GetString("User"); } catch { this.User = ""; };
}

public override
void write(){
	string sql = "insert into shipexportdtl(" + 
		"Site," +
		"Bol," +
		"BolItem," +
		"Detail," +
		"OrderNum," +
		"Item," +
		"Release," +
		"TimeStamp," +
		"Action," +
		"RelDate," +
		"RelQtyInvUnit," +
		"QtyShippedInv," +
		"QtyBackInv," +
		"DateRequest," +
		"ShipDate," +
		"Ran" +

		") values (" + 

		"'" + Converter.fixString(Site) + "'," +
		"" + NumberUtil.toString(Bol) + "," +
		"" + NumberUtil.toString(BolItem) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"" + NumberUtil.toString(OrderNum) + "," +
		"" + NumberUtil.toString(Item) + "," +
		"'" + Converter.fixString(Release) + "'," +
		"'" + Converter.fixString(TimeStamp) + "'," +
		"'" + Converter.fixString(Action) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(RelDate) + "'," +
		"" + NumberUtil.toString(RelQtyInvUnit) + "," +
		"" + NumberUtil.toString(QtyShippedInv) + "," +
		"" + NumberUtil.toString(QtyBackInv) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(DateRequest) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ShipDate) + "'," +
		"'" + Converter.fixString(Ran) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update shipexportdtl set " +
		"Site = '" + Converter.fixString(Site) + "', " +
		"Bol = " + NumberUtil.toString(Bol) + ", " +
		"BolItem = " + NumberUtil.toString(BolItem) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"OrderNum = " + NumberUtil.toString(OrderNum) + ", " +
		"Item = " + NumberUtil.toString(Item) + ", " +
		"Release = '" + Converter.fixString(Release) + "', " +
		"TimeStamp = '" + Converter.fixString(TimeStamp) + "', " +
		"Action = '" + Converter.fixString(Action) + "', " +
		"RelDate = '" + DateUtil.getCompleteDateRepresentation(RelDate) + "', " +
		"RelQtyInvUnit = " + NumberUtil.toString(RelQtyInvUnit) + ", " +
		"QtyShippedInv = " + NumberUtil.toString(QtyShippedInv) + ", " +
		"QtyBackInv = " + NumberUtil.toString(QtyBackInv) + ", " +
		"DateRequest = '" + DateUtil.getCompleteDateRepresentation(DateRequest) + "', " +
		"ShipDate = '" + DateUtil.getCompleteDateRepresentation(ShipDate) + "', " +
		"Ran = '" + Converter.fixString(Ran) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from shipexportdtl where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Site = '" + Converter.fixString(Site) + "' and " +
		"Bol = " + NumberUtil.toString(Bol) + " and " +
		"BolItem = " + NumberUtil.toString(BolItem) + " and " +
		"Detail = " + NumberUtil.toString(Detail) + "";
	return sqlWhere;
}

public
void setSite(string Site){
	this.Site = Site;
}

public
void setBol(decimal Bol){
	this.Bol = Bol;
}

public
void setBolItem(decimal BolItem){
	this.BolItem = BolItem;
}

public
void setDetail(int Detail){
	this.Detail = Detail;
}

public
void setOrderNum(decimal OrderNum){
	this.OrderNum = OrderNum;
}

public
void setItem(decimal Item){
	this.Item = Item;
}

public
void setRelease(string Release){
	this.Release = Release;
}

public
void setTimeStamp(string TimeStamp){
	this.TimeStamp = TimeStamp;
}

public
void setAction(string Action){
	this.Action = Action;
}

public
void setRelDate(DateTime RelDate){
	this.RelDate = RelDate;
}

public
void setRelQtyInvUnit(decimal RelQtyInvUnit){
	this.RelQtyInvUnit = RelQtyInvUnit;
}

public
void setQtyShippedInv(decimal QtyShippedInv){
	this.QtyShippedInv = QtyShippedInv;
}

public
void setQtyBackInv(decimal QtyBackInv){
	this.QtyBackInv = QtyBackInv;
}

public
void setDateRequest(DateTime DateRequest){
	this.DateRequest = DateRequest;
}

public
void setShipDate(DateTime ShipDate){
	this.ShipDate = ShipDate;
}

public
void setRan(string Ran){
	this.Ran = Ran;
}

public
void setUser(string User){
	this.User = User;
}

public
string getSite(){
	return Site;
}

public
decimal getBol(){
	return Bol;
}

public
decimal getBolItem(){
	return BolItem;
}

public
int getDetail(){
	return Detail;
}

public
decimal getOrderNum(){
	return OrderNum;
}

public
decimal getItem(){
	return Item;
}

public
string getRelease(){
	return Release;
}

public
string getTimeStamp(){
	return TimeStamp;
}

public
string getAction(){
	return Action;
}

public
DateTime getRelDate(){
	return RelDate;
}

public
decimal getRelQtyInvUnit(){
	return RelQtyInvUnit;
}

public
decimal getQtyShippedInv(){
	return QtyShippedInv;
}

public
decimal getQtyBackInv(){
	return QtyBackInv;
}

public
DateTime getDateRequest(){
	return DateRequest;
}

public
DateTime getShipDate(){
	return ShipDate;
}

public
string getRan(){
	return Ran;
}

public
string getUser(){
	return User;
}

} // class
} // package