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
class DemandWeekDataBase : GenericDataBaseElement {

private int Id;
private string Plant;
private string Source;
private string TPartner;
private string OldRelNum;
private string NewRelNum;
private DateTime RelDate;
private string ShipLoc;
private string Part;
private DateTime FromDate;
private decimal WeekShip;
private decimal PastDue;
private decimal Monday;
private decimal Tuesday;
private decimal Wednesday;
private decimal Thursday;
private decimal Friday;
private decimal Saturday;
private decimal Sunday;
private decimal TotWeekReq;

private decimal OrderNum;
private decimal Item;
private decimal TrlpKeyId;

public
DemandWeekDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from demandweek where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from demandweek where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.Plant = reader.GetString("Plant");
	this.Source = reader.GetString("Source");
	this.TPartner = reader.GetString("TPartner");
	this.OldRelNum = reader.GetString("OldRelNum");
	this.NewRelNum = reader.GetString("NewRelNum");
    this.RelDate = reader.GetDateTime("RelDate");
    this.ShipLoc = reader.GetString("ShipLoc");
	this.Part = reader.GetString("Part");
    this.FromDate = reader.GetDateTime("FromDate");
	this.WeekShip = reader.GetDecimal("WeekShip");
	this.PastDue = reader.GetDecimal("PastDue");
	this.Monday = reader.GetDecimal("Monday");
	this.Tuesday = reader.GetDecimal("Tuesday");
	this.Wednesday = reader.GetDecimal("Wednesday");
	this.Thursday = reader.GetDecimal("Thursday");
	this.Friday = reader.GetDecimal("Friday");
	this.Saturday = reader.GetDecimal("Saturday");
	this.Sunday = reader.GetDecimal("Sunday");
	this.TotWeekReq = reader.GetDecimal("TotWeekReq");

    this.OrderNum = reader.GetDecimal("OrderNum");
    this.Item = reader.GetDecimal("Item");
    this.TrlpKeyId = reader.GetDecimal("TrlpKeyId");
}

public override
void write(){
	string sql = "insert into demandweek(" + 
		"Plant," +
		"Source," +
		"TPartner," +
		"OldRelNum," +
		"NewRelNum," +
        "RelDate," +       
        "ShipLoc," +
		"Part," +
        "FromDate,"+
        "WeekShip," +
		"PastDue," +
		"Monday," +
		"Tuesday," +
		"Wednesday," +
		"Thursday," +
		"Friday," +
		"Saturday," +
		"Sunday," +
		"TotWeekReq," +

        "OrderNum," +
        "Item," +
        "TrlpKeyId" +
    
		") values (" + 

		"'" + Converter.fixString(Plant) + "'," +
		"'" + Converter.fixString(Source) + "'," +
		"'" + Converter.fixString(TPartner) + "'," +
		"'" + Converter.fixString(OldRelNum) + "'," +
		"'" + Converter.fixString(NewRelNum) + "'," +
        "'" + DateUtil.getDateRepresentation(RelDate, DateUtil.MMDDYYYY) + "'," +
        "'" + Converter.fixString(ShipLoc) + "'," +
		"'" + Converter.fixString(Part) + "'," +
        "'" + DateUtil.getDateRepresentation(FromDate,DateUtil.MMDDYYYY) + "'," +        
        "" + NumberUtil.toString(WeekShip) + "," +
		"" + NumberUtil.toString(PastDue) + "," +
		"" + NumberUtil.toString(Monday) + "," +
		"" + NumberUtil.toString(Tuesday) + "," +
		"" + NumberUtil.toString(Wednesday) + "," +
		"" + NumberUtil.toString(Thursday) + "," +
		"" + NumberUtil.toString(Friday) + "," +
		"" + NumberUtil.toString(Saturday) + "," +
		"" + NumberUtil.toString(Sunday) + "," +
		"" + NumberUtil.toString(TotWeekReq) + "," +

        "" + NumberUtil.toString(OrderNum) + "," +
		"" + NumberUtil.toString(Item) + "," +
		"" + NumberUtil.toString(TrlpKeyId) + ")";            

write(sql);

	this.setId(dataBaseAccess.getLastId());
}

public override
void update(){
	string sql = "update demandweek set " +
		"Plant = '" + Converter.fixString(Plant) + "', " +
		"Source = '" + Converter.fixString(Source) + "', " +
		"TPartner = '" + Converter.fixString(TPartner) + "', " +
		"OldRelNum = '" + Converter.fixString(OldRelNum) + "', " +
		"NewRelNum = '" + Converter.fixString(NewRelNum) + "', " +
        "RelDate='" + DateUtil.getDateRepresentation(RelDate, DateUtil.MMDDYYYY) + "'," +
		"ShipLoc = '" + Converter.fixString(ShipLoc) + "', " +
		"Part = '" + Converter.fixString(Part) + "', " +
        "FromDate = '" + DateUtil.getDateRepresentation(FromDate, DateUtil.MMDDYYYY) + "', " +        
        "WeekShip = " + NumberUtil.toString(WeekShip) + ", " +
		"PastDue = " + NumberUtil.toString(PastDue) + ", " +
		"Monday = " + NumberUtil.toString(Monday) + ", " +
		"Tuesday = " + NumberUtil.toString(Tuesday) + ", " +
		"Wednesday = " + NumberUtil.toString(Wednesday) + ", " +
		"Thursday = " + NumberUtil.toString(Thursday) + ", " +
		"Friday = " + NumberUtil.toString(Friday) + ", " +
		"Saturday = " + NumberUtil.toString(Saturday) + ", " +
		"Sunday = " + NumberUtil.toString(Sunday) + ", " +
		"TotWeekReq = " + NumberUtil.toString(TotWeekReq) + ", " +

        "OrderNum=" + NumberUtil.toString(OrderNum) + "," +
        "Item=" + NumberUtil.toString(Item) + "," +
        "TrlpKeyId=" + NumberUtil.toString(TrlpKeyId) + " " + 

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from demandweek where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Id = " + NumberUtil.toString(Id) + "";
	return sqlWhere;
}

public
void setId(int Id){
	this.Id = Id;
}

public
void setPlant(string Plant){
	this.Plant = Plant;
}

public
void setSource(string Source){
	this.Source = Source;
}

public
void setTPartner(string TPartner){
	this.TPartner = TPartner;
}

public
void setOldRelNum(string OldRelNum){
	this.OldRelNum = OldRelNum;
}

public
void setNewRelNum(string NewRelNum){
	this.NewRelNum = NewRelNum;
}

public
void setRelDate(DateTime RelDate){
	this.RelDate = RelDate;
}
    
public
void setShipLoc(string ShipLoc){
	this.ShipLoc = ShipLoc;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setFromDate(DateTime FromDate){
	this.FromDate = FromDate;
}

public
void setWeekShip(decimal WeekShip){
	this.WeekShip = WeekShip;
}

public
void setPastDue(decimal PastDue){
	this.PastDue = PastDue;
}

public
void setMonday(decimal Monday){
	this.Monday = Monday;
}

public
void setTuesday(decimal Tuesday){
	this.Tuesday = Tuesday;
}

public
void setWednesday(decimal Wednesday){
	this.Wednesday = Wednesday;
}

public
void setThursday(decimal Thursday){
	this.Thursday = Thursday;
}

public
void setFriday(decimal Friday){
	this.Friday = Friday;
}

public
void setSaturday(decimal Saturday){
	this.Saturday = Saturday;
}

public
void setSunday(decimal Sunday){
	this.Sunday = Sunday;
}

public
void setTotWeekReq(decimal TotWeekReq){
	this.TotWeekReq = TotWeekReq;
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
void setTrlpKeyId(decimal TrlpKeyId){
	this.TrlpKeyId = TrlpKeyId;
}
  
public
int getId(){
	return Id;
}

public
string getPlant(){
	return Plant;
}

public
string getSource(){
	return Source;
}

public
string getTPartner(){
	return TPartner;
}

public
string getOldRelNum(){
	return OldRelNum;
}

public
string getNewRelNum(){
	return NewRelNum;
}

public
DateTime getRelDate(){
	return RelDate;
}

public
string getShipLoc(){
	return ShipLoc;
}

public
string getPart(){
	return Part;
}

public
DateTime getFromDate(){
	return FromDate;
}

public
decimal getWeekShip(){
	return WeekShip;
}

public
decimal getPastDue(){
	return PastDue;
}

public
decimal getMonday(){
	return Monday;
}

public
decimal getTuesday(){
	return Tuesday;
}

public
decimal getWednesday(){
	return Wednesday;
}

public
decimal getThursday(){
	return Thursday;
}

public
decimal getFriday(){
	return Friday;
}

public
decimal getSaturday(){
	return Saturday;
}

public
decimal getSunday(){
	return Sunday;
}

public
decimal getTotWeekReq(){
	return TotWeekReq;
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
decimal getTrlpKeyId( ){
    return TrlpKeyId;
}

} // class
} // package