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
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class ShipExportSumDataBase : GenericDataBaseElement {

private decimal OrderNum;
private decimal Item;
private string Release;
private string Site;
private string BillTo;
private string CustPO;
private string OrdType;
private string Product;
private DateTime DateRequest;
private DateTime ChangeDate;
private DateTime ShipDate;
private string DtWkMonthWkDesc;
private string MajGroup;
private string MinGroup;
private string MinSales;
private string MajSales;
private string Ppap;
private decimal QtyOrder;
private decimal QtyShipped;
private decimal QtyOrderSh;
private decimal QtyShippedSh;
private decimal QtyPpm;
private int ActualDays;
private string Compliance;
private string Include;
private string Sale;
private string Change;
private string Backord;
private string ExcludeComment;
private string ParentRelease;
private int LeadTime;
private int LeadTime2;
private int LeadTime3;

private decimal QtyShippedOnTime;
private decimal QtyShippedLate;
private string FixManual;
private decimal CumQty;
private decimal QtyOrderedFromCum;
private string Note;

private string ShipTo;
private DateTime CreateDate;
private string TradPartner;
private DateTime DateRequestFromCum;

public
ShipExportSumDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from shipexportsum where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from shipexportsum where " + getWhereCondition();
	return exists(sql);
}

public
bool existsFixManual(decimal orderNum,decimal item,string srelease){
	OrderNum= orderNum;
    Item    = item;
    Release = srelease;
	string sql = "select FixManual from shipexportsum where " + getWhereCondition() + " and FixManual='" + Constants.STRING_YES + "'";
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.OrderNum = reader.GetDecimal("OrderNum");
	this.Item = reader.GetDecimal("Item");
	this.Release = reader.GetString("Release");
    this.Site = reader.GetString("Site");
	this.BillTo = reader.GetString("BillTo");
	this.CustPO = reader.GetString("CustPO");
	this.OrdType = reader.GetString("OrdType");
	this.Product = reader.GetString("Product");
	this.DateRequest = reader.GetDateTime("DateRequest");
	this.ChangeDate = reader.GetDateTime("ChangeDate");
	this.ShipDate = reader.GetDateTime("ShipDate");
	this.DtWkMonthWkDesc = reader.GetString("DtWkMonthWkDesc");
    this.MajGroup = reader.GetString("MajGroup");
    this.MinGroup = reader.GetString("MinGroup");
	this.MinSales = reader.GetString("MinSales");
	this.MajSales = reader.GetString("MajSales");
	this.Ppap = reader.GetString("Ppap");
	this.QtyOrder = reader.GetDecimal("QtyOrder");
	this.QtyShipped = reader.GetDecimal("QtyShipped");
	this.QtyOrderSh = reader.GetDecimal("QtyOrderSh");
	this.QtyShippedSh = reader.GetDecimal("QtyShippedSh");
	this.QtyPpm = reader.GetDecimal("QtyPpm");
	this.ActualDays = reader.GetInt32("ActualDays");
	this.Compliance = reader.GetString("Compliance");
	this.Include = reader.GetString("Include");
	this.Sale = reader.GetString("Sale");
	this.Change = reader.GetString("Change");
	this.Backord = reader.GetString("Backord");
	this.ExcludeComment = reader.GetString("ExcludeComment");
	this.ParentRelease = reader.GetString("ParentRelease");
    this.LeadTime   = reader.GetInt32("LeadTime");
    this.LeadTime2  = reader.GetInt32("LeadTime2");     
    this.LeadTime3  = reader.GetInt32("LeadTime3");  

    this.QtyShippedOnTime = reader.GetDecimal("QtyShippedOnTime");
    this.QtyShippedLate = reader.GetDecimal("QtyShippedLate");
    this.FixManual      = reader.GetString("FixManual");            
    this.CumQty         = reader.GetDecimal("CumQty");
    this.QtyOrderedFromCum = reader.GetDecimal("QtyOrderedFromCum");
    this.Note           = reader.GetString("Note"); 
            
    this.ShipTo         = reader.GetString("ShipTo");
    this.CreateDate     = reader.GetDateTime("CreateDate");
    this.TradPartner    = reader.GetString("TradPartner");
    this.DateRequestFromCum = reader.GetDateTime("DateRequestFromCum");
}

public override
void write(){
	string sql = "insert into shipexportsum(" + 
		"OrderNum," +
		"Item," +
		"Release," +
        "Site," +
        "BillTo," +
		"CustPO," +
		"OrdType," +
		"Product," +
		"DateRequest," +
		"ChangeDate," +
		"ShipDate," +
		"DtWkMonthWkDesc," +
        "MajGroup," +
        "MinGroup," +
        "MinSales," +
		"MajSales," +
		"Ppap," +
		"QtyOrder," +
		"QtyShipped," +
		"QtyOrderSh," +
		"QtyShippedSh," +
		"QtyPpm," +
		"ActualDays," +
		"Compliance," +
		"Include," +
		"Sale," +
		"Change," +
		"Backord," +
		"ExcludeComment," +
		"ParentRelease," +

        "LeadTime,"+
        "LeadTime2," +
        "LeadTime3," +
        "QtyShippedOnTime,"+
        "QtyShippedLate," +
        "FixManual," +
        "CumQty,"+
        "QtyOrderedFromCum," +
        "Note," +

        "ShipTo," +
        "CreateDate," +
        "TradPartner," +
        "DateRequestFromCum"+

        ") values (" + 

		"" + NumberUtil.toString(OrderNum) + "," +
		"" + NumberUtil.toString(Item) + "," +
		"'" + Converter.fixString(Release) + "'," +
        "'" + Converter.fixString(Site) + "'," +
        "'" + Converter.fixString(BillTo) + "'," +
		"'" + Converter.fixString(CustPO) + "'," +
		"'" + Converter.fixString(OrdType) + "'," +
		"'" + Converter.fixString(Product) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(DateRequest) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ChangeDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ShipDate) + "'," +
		"'" + Converter.fixString(DtWkMonthWkDesc) + "'," +
        "'" + Converter.fixString(MajGroup) + "'," +
        "'" + Converter.fixString(MinGroup) + "'," +
        "'" + Converter.fixString(MinSales) + "'," +
		"'" + Converter.fixString(MajSales) + "'," +
		"'" + Converter.fixString(Ppap) + "'," +
		"" + NumberUtil.toString(QtyOrder) + "," +
		"" + NumberUtil.toString(QtyShipped) + "," +
		"" + NumberUtil.toString(QtyOrderSh) + "," +
		"" + NumberUtil.toString(QtyShippedSh) + "," +
		"" + NumberUtil.toString(QtyPpm) + "," +
		"" + NumberUtil.toString(ActualDays) + "," +
		"'" + Converter.fixString(Compliance) + "'," +
		"'" + Converter.fixString(Include) + "'," +
		"'" + Converter.fixString(Sale) + "'," +
		"'" + Converter.fixString(Change) + "'," +
		"'" + Converter.fixString(Backord) + "'," +
		"'" + Converter.fixString(ExcludeComment) + "'," +
		"'" + Converter.fixString(ParentRelease) + "'," +
        "" + NumberUtil.toString(LeadTime) + "," +
        "" + NumberUtil.toString(LeadTime2) + "," +
        "" + NumberUtil.toString(LeadTime3) + "," +

        "" + NumberUtil.toString(QtyShippedOnTime) + "," +
        "" + NumberUtil.toString(QtyShippedLate) + "," +
        "'" + Converter.fixString(FixManual) + "'," +
         "" + NumberUtil.toString(CumQty) + "," +
        "" + NumberUtil.toString(QtyOrderedFromCum) + "," +
        "'" + Converter.fixString(Note) + "'," +

        "'" + Converter.fixString(ShipTo) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(CreateDate) + "'," +
        "'" + Converter.fixString(TradPartner) + "'," +        
        "'" + DateUtil.getCompleteDateRepresentation(DateRequestFromCum) + "')";
            
    write(sql);	
}

public 
string sqlUpdate(){
	string sql = "update shipexportsum set " +
		"OrderNum = " + NumberUtil.toString(OrderNum) + ", " +
		"Item = " + NumberUtil.toString(Item) + ", " +
		"Release = '" + Converter.fixString(Release) + "', " +
        "Site = '" + Converter.fixString(Site) + "', " +
        "BillTo = '" + Converter.fixString(BillTo) + "', " +
		"CustPO = '" + Converter.fixString(CustPO) + "', " +
		"OrdType = '" + Converter.fixString(OrdType) + "', " +
		"Product = '" + Converter.fixString(Product) + "', " +
		"DateRequest = '" + DateUtil.getCompleteDateRepresentation(DateRequest) + "', " +
		"ChangeDate = '" + DateUtil.getCompleteDateRepresentation(ChangeDate) + "', " +
		"ShipDate = '" + DateUtil.getCompleteDateRepresentation(ShipDate) + "', " +
		"DtWkMonthWkDesc = '" + Converter.fixString(DtWkMonthWkDesc) + "', " +
        "MajGroup='" + Converter.fixString(MajGroup) + "'," +
        "MinGroup='" + Converter.fixString(MinGroup) + "'," +
        "MinSales = '" + Converter.fixString(MinSales) + "', " +
		"MajSales = '" + Converter.fixString(MajSales) + "', " +
		"Ppap = '" + Converter.fixString(Ppap) + "', " +
		"QtyOrder = " + NumberUtil.toString(QtyOrder) + ", " +
		"QtyShipped = " + NumberUtil.toString(QtyShipped) + ", " +
		"QtyOrderSh = " + NumberUtil.toString(QtyOrderSh) + ", " +
		"QtyShippedSh = " + NumberUtil.toString(QtyShippedSh) + ", " +
		"QtyPpm = " + NumberUtil.toString(QtyPpm) + ", " +
		"ActualDays = " + NumberUtil.toString(ActualDays) + ", " +
		"Compliance = '" + Converter.fixString(Compliance) + "', " +
		"Include = '" + Converter.fixString(Include) + "', " +
		"Sale = '" + Converter.fixString(Sale) + "', " +
		"Change = '" + Converter.fixString(Change) + "', " +
		"Backord = '" + Converter.fixString(Backord) + "', " +
		"ExcludeComment = '" + Converter.fixString(ExcludeComment) + "', " +
		"ParentRelease = '" + Converter.fixString(ParentRelease) + "', " +
        "LeadTime = " + NumberUtil.toString(LeadTime) + "," +
        "LeadTime2=" + NumberUtil.toString(LeadTime2) + "," +
        "LeadTime3=" + NumberUtil.toString(LeadTime3) + "," +

        "QtyShippedOnTime=" + NumberUtil.toString(QtyShippedOnTime) + "," +
        "QtyShippedLate=" + NumberUtil.toString(QtyShippedLate) + ", " +
        "FixManual = '" + Converter.fixString(FixManual) + "', " +
        "CumQty=" + NumberUtil.toString(CumQty) + "," +
        "QtyOrderedFromCum=" + NumberUtil.toString(QtyOrderedFromCum) + "," +
        "Note = '" + Converter.fixString(Note) + "'," +

        "ShipTo='" + Converter.fixString(ShipTo) + "', " +
        "CreateDate='" + DateUtil.getCompleteDateRepresentation(CreateDate) + "'," +
        "TradPartner='" + Converter.fixString(TradPartner) + "', " +
        "DateRequestFromCum = '" + DateUtil.getCompleteDateRepresentation(DateRequestFromCum) + "'  " +        

        "where " + getWhereCondition();

	return sql;
}

public override
void update(){
	string sql = sqlUpdate() + " and FixManual='" + Constants.STRING_NO +"'";
	update(sql);
}

public 
void updateForced(){
	string sql = sqlUpdate();
	update(sql);
}

public
void updateNote(){
	string sql = "update shipexportsum set " +
        "Note = '" + Converter.fixString(Note) + "' " +
         "where " + getWhereCondition();
	update(sql);
}

public override
void delete(){
	string sql = "delete from shipexportsum where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"OrderNum = " + NumberUtil.toString(OrderNum) + " and " +
		"Item = " + NumberUtil.toString(Item) + " and " +
		"Release = '" + Converter.fixString(Release) + "'";
	return sqlWhere;
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
void setSite(string Site){
	this.Site = Site;
}

public
void setBillTo(string BillTo){
	this.BillTo = BillTo;
}

public
void setCustPO(string CustPO){
	this.CustPO = CustPO;
}

public
void setOrdType(string OrdType){
	this.OrdType = OrdType;
}

public
void setProduct(string Product){
	this.Product = Product;
}

public
void setDateRequest(DateTime DateRequest){
	this.DateRequest = DateRequest;
}

public
void setChangeDate(DateTime ChangeDate){
	this.ChangeDate = ChangeDate;
}

public
void setShipDate(DateTime ShipDate){
	this.ShipDate = ShipDate;
}

public
void setDtWkMonthWkDesc(string DtWkMonthWkDesc){
	this.DtWkMonthWkDesc = DtWkMonthWkDesc;
}
  
public
void setMajGroup(string MajGroup){
	this.MajGroup = MajGroup;
}

public
void setMinGroup(string MinGroup){
	this.MinGroup = MinGroup;
}

public
void setMinSales(string MinSales){
	this.MinSales = MinSales;
}

public
void setMajSales(string MajSales){
	this.MajSales = MajSales;
}

public
void setPpap(string Ppap){
	this.Ppap = Ppap;
}

public
void setQtyOrder(decimal QtyOrder){
	this.QtyOrder = QtyOrder;
}

public
void setQtyShipped(decimal QtyShipped){
	this.QtyShipped = QtyShipped;
}

public
void setQtyOrderSh(decimal QtyOrderSh){
	this.QtyOrderSh = QtyOrderSh;
}

public
void setQtyShippedSh(decimal QtyShippedSh){
	this.QtyShippedSh = QtyShippedSh;
}

public
void setQtyPpm(decimal QtyPpm){
	this.QtyPpm = QtyPpm;
}

public
void setActualDays(int ActualDays){
	this.ActualDays = ActualDays;
}

public
void setCompliance(string Compliance){
	this.Compliance = Compliance;
}

public
void setInclude(string Include){
	this.Include = Include;
}

public
void setSale(string Sale){
	this.Sale = Sale;
}

public
void setChange(string Change){
	this.Change = Change;
}

public
void setBackord(string Backord){
	this.Backord = Backord;
}

public
void setExcludeComment(string ExcludeComment){
	this.ExcludeComment = ExcludeComment;
}

public
void setParentRelease(string ParentRelease){
	this.ParentRelease = ParentRelease;
}

public
void setLeadTime(int LeadTime){
	this.LeadTime = LeadTime;
}

public
void setLeadTime2(int LeadTime2){
	this.LeadTime2 = LeadTime2;
}

public
void setLeadTime3(int LeadTime3){
	this.LeadTime3 = LeadTime3;
}

public
void setQtyShippedOnTime(decimal QtyShippedOnTime){
	this.QtyShippedOnTime = QtyShippedOnTime;
}

public
void setQtyShippedLate(decimal QtyShippedLate){
	this.QtyShippedLate = QtyShippedLate;
}

public
void setFixManual(string FixManual){
	this.FixManual = FixManual;
}

public
void setCumQty(decimal CumQty){
	this.CumQty = CumQty;
}

public
void setQtyOrderedFromCum(decimal QtyOrderedFromCum){
	this.QtyOrderedFromCum = QtyOrderedFromCum;
}

public
void setNote(string Note){
	this.Note = Note;
}

public
void setShipTo(string ShipTo){
	this.ShipTo = ShipTo;
}

public
void setCreateDate(DateTime CreateDate){
	this.CreateDate = CreateDate;
}

public
void setTradPartner(string TradPartner){
	this.TradPartner = TradPartner;
}

public
void setDateRequestFromCum(DateTime DateRequestFromCum){
	this.DateRequestFromCum = DateRequestFromCum;
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
string getSite(){
	return Site;
}

public
string getBillTo(){
	return BillTo;
}

public
string getCustPO(){
	return CustPO;
}

public
string getOrdType(){
	return OrdType;
}

public
string getProduct(){
	return Product;
}

public
DateTime getDateRequest(){
	return DateRequest;
}

public
DateTime getChangeDate(){
	return ChangeDate;
}

public
DateTime getShipDate(){
	return ShipDate;
}

public
string getDtWkMonthWkDesc(){
	return DtWkMonthWkDesc;
}

public
string getMajGroup(){
	return MajGroup;
}

public
string getMinGroup(){
	return MinGroup;
}

public
string getMinSales(){
	return MinSales;
}

public
string getMajSales(){
	return MajSales;
}

public
string getPpap(){
	return Ppap;
}

public
decimal getQtyOrder(){
	return QtyOrder;
}

public
decimal getQtyShipped(){
	return QtyShipped;
}

public
decimal getQtyOrderSh(){
	return QtyOrderSh;
}

public
decimal getQtyShippedSh(){
	return QtyShippedSh;
}

public
decimal getQtyPpm(){
	return QtyPpm;
}

public
int getActualDays(){
	return ActualDays;
}

public
string getCompliance(){
	return Compliance;
}

public
string getInclude(){
	return Include;
}

public
string getSale(){
	return Sale;
}

public
string getChange(){
	return Change;
}

public
string getBackord(){
	return Backord;
}

public
string getExcludeComment(){
	return ExcludeComment;
}

public
string getParentRelease(){
	return ParentRelease;
}

public
int getLeadTime(){
	return LeadTime;
}

public
int getLeadTime2(){
    return LeadTime2;
}

public
int getLeadTime3(){
    return LeadTime3;
}

public
decimal getQtyShippedOnTime(){
    return QtyShippedOnTime;
}

public
decimal getQtyShippedLate(){
    return QtyShippedLate;
}

public
string getFixManual(){
    return FixManual;
}

public
decimal getCumQty(){
    return CumQty;
}

public
decimal getQtyOrderedFromCum(){
	return QtyOrderedFromCum;
}

public
string getNote(){
    return Note;
}

public
string getShipTo(){
	return ShipTo;
}

public
DateTime getCreateDate( ){
	return CreateDate;
}

public
string getTradPartner(){
	return TradPartner;
}
    
public
DateTime getDateRequestFromCum( ){
    return DateRequestFromCum;
}

} // class
} // package