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
class DemandDayDataBase : GenericDataBaseElement {

private int Id;
private string Plant;
private string Source;
private string TPartner;
private string ShipLoc;
private string Part;
private DateTime Created;
private string OldRelNum;
private string NewRelNum;
private DateTime OldRelDate;
private DateTime RelDate;
private decimal OldCumRequired;
private decimal CumRequired;
private decimal OrderNum;
private decimal Item;
private decimal TrlpKeyId;
private decimal LogNum;

public
DemandDayDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from demandday where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from demandday where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Id = reader.GetInt32("Id");
	this.Plant = reader.GetString("Plant");
	this.Source = reader.GetString("Source");
	this.TPartner = reader.GetString("TPartner");
	this.ShipLoc = reader.GetString("ShipLoc");
	this.Part = reader.GetString("Part");
	this.Created = reader.GetDateTime("Created");
	this.OldRelNum = reader.GetString("OldRelNum");
	this.NewRelNum = reader.GetString("NewRelNum");
	this.OldRelDate = reader.GetDateTime("OldRelDate");
	this.RelDate = reader.GetDateTime("RelDate");
	this.OldCumRequired = reader.GetDecimal("OldCumRequired");
	this.CumRequired = reader.GetDecimal("CumRequired");
	this.OrderNum = reader.GetDecimal("OrderNum");
	this.Item = reader.GetDecimal("Item");
	this.TrlpKeyId = reader.GetDecimal("TrlpKeyId");
    this.LogNum  = reader.GetDecimal("LogNum");
}

public override
void write(){
	string sql = "insert into demandday(" + 
		"Plant," +
		"Source," +
		"TPartner," +
		"ShipLoc," +
		"Part," +
		"Created," +
		"OldRelNum," +
		"NewRelNum," +
		"OldRelDate," +
		"RelDate," +
		"OldCumRequired," +
		"CumRequired," +
		"OrderNum," +
		"Item," +
		"TrlpKeyId," +
        "LogNum" +
        
        ") values (" + 

		"'" + Converter.fixString(Plant) + "'," +
		"'" + Converter.fixString(Source) + "'," +
		"'" + Converter.fixString(TPartner) + "'," +
		"'" + Converter.fixString(ShipLoc) + "'," +
		"'" + Converter.fixString(Part) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(Created) + "'," +
		"'" + Converter.fixString(OldRelNum) + "'," +
		"'" + Converter.fixString(NewRelNum) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OldRelDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(RelDate) + "'," +
		"" + NumberUtil.toString(OldCumRequired) + "," +
		"" + NumberUtil.toString(CumRequired) + "," +
		"" + NumberUtil.toString(OrderNum) + "," +
		"" + NumberUtil.toString(Item) + "," +
		"" + NumberUtil.toString(TrlpKeyId) + "," +
        "" + NumberUtil.toString(LogNum) + ")";

	write(sql);
	this.setId(dataBaseAccess.getLastId());	
}

public override
void update(){
	string sql = "update demandday set " +
		"Plant = '" + Converter.fixString(Plant) + "', " +
		"Source = '" + Converter.fixString(Source) + "', " +
		"TPartner = '" + Converter.fixString(TPartner) + "', " +
		"ShipLoc = '" + Converter.fixString(ShipLoc) + "', " +
		"Part = '" + Converter.fixString(Part) + "', " +
		"Created = '" + DateUtil.getCompleteDateRepresentation(Created) + "', " +
		"OldRelNum = '" + Converter.fixString(OldRelNum) + "', " +
		"NewRelNum = '" + Converter.fixString(NewRelNum) + "', " +
		"OldRelDate = '" + DateUtil.getCompleteDateRepresentation(OldRelDate) + "', " +
		"RelDate = '" + DateUtil.getCompleteDateRepresentation(RelDate) + "', " +
		"OldCumRequired = " + NumberUtil.toString(OldCumRequired) + ", " +
		"CumRequired = " + NumberUtil.toString(CumRequired) + ", " +
		"OrderNum = " + NumberUtil.toString(OrderNum) + ", " +
		"Item = " + NumberUtil.toString(Item) + ", " +
		"TrlpKeyId = " + NumberUtil.toString(TrlpKeyId) + ", " +
        "LogNum = " + NumberUtil.toString(LogNum) + " " +

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from demandday where " + getWhereCondition();
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
void setShipLoc(string ShipLoc){
	this.ShipLoc = ShipLoc;
}

public
void setPart(string Part){
	this.Part = Part;
}

public
void setCreated(DateTime Created){
	this.Created = Created;
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
void setOldRelDate(DateTime OldRelDate){
	this.OldRelDate = OldRelDate;
}

public
void setRelDate(DateTime RelDate){
	this.RelDate = RelDate;
}

public
void setOldCumRequired(decimal OldCumRequired){
	this.OldCumRequired = OldCumRequired;
}

public
void setCumRequired(decimal CumRequired){
	this.CumRequired = CumRequired;
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
void setLogNum(decimal LogNum){
	this.LogNum = LogNum;
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
string getShipLoc(){
	return ShipLoc;
}

public
string getPart(){
	return Part;
}

public
DateTime getCreated(){
	return Created;
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
DateTime getOldRelDate(){
	return OldRelDate;
}

public
DateTime getRelDate(){
	return RelDate;
}

public
decimal getOldCumRequired(){
	return OldCumRequired;
}

public
decimal getCumRequired(){
	return CumRequired;
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
decimal getTrlpKeyId(){
	return TrlpKeyId;
}

public
decimal getLogNum(){
	return LogNum;
}

} // class
} // package