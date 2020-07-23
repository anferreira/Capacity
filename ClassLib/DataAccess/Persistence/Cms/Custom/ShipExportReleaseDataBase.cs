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
class ShipExportReleaseDataBase : GenericDataBaseElement {

private string Site;
private decimal Bol;
private decimal BolItem;
private int Detail;
private string Release;
private DateTime RelDate;
private decimal RelCum;
private decimal RelQty;
private decimal OurShipCum;
private decimal OemYtdReq;
private decimal OemYtdShip;
private DateTime StDateCreated;
private string StTranslated;
private DateTime StTranslatedDate;
private string UserId;
private string Ran;

public
ShipExportReleaseDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from shipexportrelease where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from shipexportrelease where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.Site = reader.GetString("Site");
	this.Bol = reader.GetDecimal("Bol");
	this.BolItem = reader.GetDecimal("BolItem");
	this.Detail = reader.GetInt32("Detail");
	this.Release = reader.GetString("Release");
	this.RelDate = reader.GetDateTime("RelDate");
	this.RelCum = reader.GetDecimal("RelCum");
	this.RelQty = reader.GetDecimal("RelQty");
	this.OurShipCum = reader.GetDecimal("OurShipCum");
	this.OemYtdReq = reader.GetDecimal("OemYtdReq");
	this.OemYtdShip = reader.GetDecimal("OemYtdShip");
	this.StDateCreated = reader.GetDateTime("StDateCreated");
	this.StTranslated = reader.GetString("StTranslated");
	this.StTranslatedDate = reader.GetDateTime("StTranslatedDate");
    this.UserId = reader.GetString("UserId");
    this.Ran = reader.GetString("Ran");
}

public override
void write(){
	string sql = "insert into shipexportrelease(" + 
		"Site," +
		"Bol," +
		"BolItem," +
		"Detail," +
		"Release," +
		"RelDate," +
		"RelCum," +
		"RelQty," +
		"OurShipCum," +
		"OemYtdReq," +
		"OemYtdShip," +
		"StDateCreated," +
		"StTranslated," +
		"StTranslatedDate," +
        "UserId," +
        "Ran" +

        ") values (" + 

		"'" + Converter.fixString(Site) + "'," +
		"" + NumberUtil.toString(Bol) + "," +
		"" + NumberUtil.toString(BolItem) + "," +
		"" + NumberUtil.toString(Detail) + "," +
		"'" + Converter.fixString(Release) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(RelDate) + "'," +
		"" + NumberUtil.toString(RelCum) + "," +
		"" + NumberUtil.toString(RelQty) + "," +
		"" + NumberUtil.toString(OurShipCum) + "," +
		"" + NumberUtil.toString(OemYtdReq) + "," +
		"" + NumberUtil.toString(OemYtdShip) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(StDateCreated) + "'," +
		"'" + Converter.fixString(StTranslated) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(StTranslatedDate) + "'," +
        "'" + Converter.fixString(UserId) + "'," +
        "'" + Converter.fixString(Ran) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update shipexportrelease set " +
		"Site = '" + Converter.fixString(Site) + "', " +
		"Bol = " + NumberUtil.toString(Bol) + ", " +
		"BolItem = " + NumberUtil.toString(BolItem) + ", " +
		"Detail = " + NumberUtil.toString(Detail) + ", " +
		"Release = '" + Converter.fixString(Release) + "', " +
		"RelDate = '" + DateUtil.getCompleteDateRepresentation(RelDate) + "', " +
		"RelCum = " + NumberUtil.toString(RelCum) + ", " +
		"RelQty = " + NumberUtil.toString(RelQty) + ", " +
		"OurShipCum = " + NumberUtil.toString(OurShipCum) + ", " +
		"OemYtdReq = " + NumberUtil.toString(OemYtdReq) + ", " +
		"OemYtdShip = " + NumberUtil.toString(OemYtdShip) + ", " +
		"StDateCreated = '" + DateUtil.getCompleteDateRepresentation(StDateCreated) + "', " +
		"StTranslated = '" + Converter.fixString(StTranslated) + "', " +
		"StTranslatedDate = '" + DateUtil.getCompleteDateRepresentation(StTranslatedDate) + "', " +
        "UserId = '" + Converter.fixString(UserId) + "', " +
        "Ran = '" + Converter.fixString(Ran) + "' " +

        "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from shipexportrelease where " + getWhereCondition();
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
void setRelease(string Release){
	this.Release = Release;
}

public
void setRelDate(DateTime RelDate){
	this.RelDate = RelDate;
}

public
void setRelCum(decimal RelCum){
	this.RelCum = RelCum;
}

public
void setRelQty(decimal RelQty){
	this.RelQty = RelQty;
}

public
void setOurShipCum(decimal OurShipCum){
	this.OurShipCum = OurShipCum;
}

public
void setOemYtdReq(decimal OemYtdReq){
	this.OemYtdReq = OemYtdReq;
}

public
void setOemYtdShip(decimal OemYtdShip){
	this.OemYtdShip = OemYtdShip;
}

public
void setStDateCreated(DateTime StDateCreated){
	this.StDateCreated = StDateCreated;
}

public
void setStTranslated(string StTranslated){
	this.StTranslated = StTranslated;
}

public
void setStTranslatedDate(DateTime StTranslatedDate){
	this.StTranslatedDate = StTranslatedDate;
}

public
void setUserId(string UserId){
	this.UserId = UserId;
}

public
void setRan(string Ran){
	this.Ran = Ran;
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
string getRelease(){
	return Release;
}

public
DateTime getRelDate(){
	return RelDate;
}

public
decimal getRelCum(){
	return RelCum;
}

public
decimal getRelQty(){
	return RelQty;
}

public
decimal getOurShipCum(){
	return OurShipCum;
}

public
decimal getOemYtdReq(){
	return OemYtdReq;
}

public
decimal getOemYtdShip(){
	return OemYtdShip;
}

public
DateTime getStDateCreated(){
	return StDateCreated;
}

public
string getStTranslated(){
	return StTranslated;
}

public
DateTime getStTranslatedDate(){
	return StTranslatedDate;
}

public
string getUserId(){
	return UserId;
}

public
string getRan(){
	return Ran;
}

} // class
} // package