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
class ShipExportDataBase : GenericDataBaseElement {

private string Site;
private decimal Bol;
private decimal BolItem;
private string BillTo;
private string ShipTo;
private DateTime ShipDate;
private DateTime DateRequest;
private DateTime CreateDate;
private DateTime PostDate;
private decimal OrderNum;
private decimal Item;
private string Release;
private string OrdType;
private string Product;
private string CustPart;
private decimal QtyShipped;
private decimal QtyBack;
private decimal QtyExpec;
private decimal QtyOrder;
private string ProdType;
private string BackFlag;
private DateTime LineBookDate;
private DateTime CustReqDate;
private string BackOrderFlag;
private string Market;
private DateTime ExportDate;
private DateTime OrderDate;
private decimal FirstQty;
private string MajGroup;
private string MinGroup;
private string MinSales;
private string MajSales;

private string TradPartner;
private string ShipToLoc;

private decimal CumQty;
private string Ran;
private DateTime LTBookDate;
private decimal LTBookQty;

private DateTime LastDateChange;
private DateTime LastQtyDateChange;
private decimal LastQtyChange;
private string CustPO;
private string Ppap;
private string Trlp;
private string EdiRelease;
private int LeadTime;
private int LeadTime2;
private int LeadTime3;

private string ReleaseBase;
private decimal QtyOrdBase;
private decimal CumRequired;
private decimal QtyOrderedFromCum;

private decimal CumPrior;
private decimal QtyRequired;

public
ShipExportDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from shipexport where " + getWhereCondition();
	return read(sql);
}

public
bool readByBolIds(){
	string sql ="select * from shipexport where Bol = " + NumberUtil.toString(Bol) + " and " +
                "BolItem = " + NumberUtil.toString(BolItem);
	return read(sql);
}

public
bool existsBolIds(){
	string sql ="select * from shipexport where Bol = " + NumberUtil.toString(Bol) + " and " +
                "BolItem = " + NumberUtil.toString(BolItem);
	return exists(sql);
}

public
bool exists(){
	string sql = "select * from shipexport where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){	
	this.Site = reader.GetString("Site");
	this.Bol = reader.GetDecimal("Bol");
	this.BolItem = reader.GetDecimal("BolItem");
	this.BillTo = reader.GetString("BillTo");
	this.ShipTo = reader.GetString("ShipTo");
	this.ShipDate = reader.GetDateTime("ShipDate");
	this.DateRequest = reader.GetDateTime("DateRequest");
	this.CreateDate = reader.GetDateTime("CreateDate");
	this.PostDate = reader.GetDateTime("PostDate");
	this.OrderNum = reader.GetDecimal("OrderNum");
	this.Item = reader.GetDecimal("Item");
	this.Release = reader.GetString("Release");
	this.OrdType = reader.GetString("OrdType");
	this.Product = reader.GetString("Product");
	this.CustPart = reader.GetString("CustPart");
	this.QtyShipped = reader.GetDecimal("QtyShipped");
	this.QtyBack = reader.GetDecimal("QtyBack");
	this.QtyExpec = reader.GetDecimal("QtyExpec");
	this.QtyOrder = reader.GetDecimal("QtyOrder");
	this.ProdType = reader.GetString("ProdType");
	this.BackFlag = reader.GetString("BackFlag");
	this.LineBookDate = reader.GetDateTime("LineBookDate");
	this.CustReqDate = reader.GetDateTime("CustReqDate");
	this.BackOrderFlag = reader.GetString("BackOrderFlag");
	this.Market = reader.GetString("Market");
	this.ExportDate = reader.GetDateTime("ExportDate");

    this.OrderDate = reader.GetDateTime("OrderDate");
    this.FirstQty = reader.GetDecimal("FirstQty");
    this.MajGroup = reader.GetString("MajGroup");
    this.MinGroup = reader.GetString("MinGroup");
    this.MinSales = reader.GetString("MinSales"); 
    this.MajSales = reader.GetString("MajSales");     

    this.TradPartner= reader.GetString("TradPartner"); 
    this.ShipToLoc  = reader.GetString("ShipToLoc");     
    this.CumQty     = reader.GetDecimal("CumQty"); 
    this.Ran        = reader.GetString("Ran");    
    this.LTBookDate = reader.GetDateTime("LTBookDate"); 
    this.LTBookQty  = reader.GetDecimal("LTBookQty");    

    this.LastDateChange     = reader.GetDateTime("LastDateChange"); 
    this.LastQtyDateChange  = reader.GetDateTime("LastQtyDateChange"); 
    this.LastQtyChange      = reader.GetDecimal("LastQtyChange");    
    this.CustPO             = reader.GetString("CustPO");
    this.Ppap               = reader.GetString("Ppap");       
    this.Trlp               = reader.GetString("Trlp"); 
    this.EdiRelease         = reader.GetString("EdiRelease"); 
    this.LeadTime           = reader.GetInt32("LeadTime");     
    this.LeadTime2          = reader.GetInt32("LeadTime2");     
    this.LeadTime3          = reader.GetInt32("LeadTime3");     

    this.ReleaseBase        = reader.GetString("ReleaseBase");     
    this.QtyOrdBase         = reader.GetDecimal("QtyOrdBase");     
    this.CumRequired        = reader.GetDecimal("CumRequired");
    this.QtyOrderedFromCum         = reader.GetDecimal("QtyOrderedFromCum");     
            
    this.CumPrior           = reader.GetDecimal("CumPrior");
    this.QtyRequired        = reader.GetDecimal("QtyRequired");
}

public override
void write(){
	string sql = "insert into shipexport(" + 
		"Site," +
		"Bol," +
		"BolItem," +
		"BillTo," +
		"ShipTo," +
		"ShipDate," +
		"DateRequest," +
		"CreateDate," +
		"PostDate," +
		"OrderNum," +
		"Item," +
		"Release," +
		"OrdType," +
		"Product," +
		"CustPart," +
		"QtyShipped," +
		"QtyBack," +
		"QtyExpec," +
		"QtyOrder," +
		"ProdType," +
		"BackFlag," +
		"LineBookDate," +
		"CustReqDate," +
		"BackOrderFlag," +
		"Market," +
		"ExportDate," +

        "OrderDate," +
        "FirstQty," +
        "MajGroup," +
        "MinGroup," +
        "MinSales," +
        "MajSales," +

        "TradPartner," +
        "ShipToLoc," +
        "CumQty," +
        "Ran," +
        "LTBookDate," +
        "LTBookQty," +

        "LastDateChange," +
        "LastQtyDateChange," +
        "LastQtyChange," +
        "CustPO," +
        "Ppap," +
        "Trlp," +
        "EdiRelease," +
        "LeadTime," +
        "LeadTime2," +
        "LeadTime3," +

        "ReleaseBase," +
        "QtyOrdBase," +

        "CumRequired," +
        "QtyOrderedFromCum," +

        "CumPrior," +
        "QtyRequired" +

        ") values (" + 

		"'" + Converter.fixString(Site) + "'," +
		"" + NumberUtil.toString(Bol) + "," +
		"" + NumberUtil.toString(BolItem) + "," +
		"'" + Converter.fixString(BillTo) + "'," +
		"'" + Converter.fixString(ShipTo) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ShipDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(DateRequest) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(CreateDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(PostDate) + "'," +
		"" + NumberUtil.toString(OrderNum) + "," +
		"" + NumberUtil.toString(Item) + "," +		
        "'" + Converter.fixString(Release) + "'," +
        "'" + Converter.fixString(OrdType) + "'," +
		"'" + Converter.fixString(Product) + "'," +
		"'" + Converter.fixString(CustPart) + "'," +
		"" + NumberUtil.toString(QtyShipped) + "," +
		"" + NumberUtil.toString(QtyBack) + "," +
		"" + NumberUtil.toString(QtyExpec) + "," +
		"" + NumberUtil.toString(QtyOrder) + "," +
		"'" + Converter.fixString(ProdType) + "'," +
		"'" + Converter.fixString(BackFlag) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(LineBookDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(CustReqDate) + "'," +
		"'" + Converter.fixString(BackOrderFlag) + "'," +
		"'" + Converter.fixString(Market) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ExportDate) + "'," +

        "'" + DateUtil.getCompleteDateRepresentation(OrderDate) + "'," +
        "" + NumberUtil.toString(FirstQty) + "," +
	    "'" + Converter.fixString(MajGroup) + "'," +
		"'" + Converter.fixString(MinGroup) + "'," +
        "'" + Converter.fixString(MinSales) + "'," +
        "'" + Converter.fixString(MajSales) + "'," +

        "'" + Converter.fixString(TradPartner) + "'," +
        "'" + Converter.fixString(ShipToLoc) + "'," +
        "" + NumberUtil.toString(CumQty) + "," +
        "'" + Converter.fixString(Ran) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(LTBookDate) + "'," +
        "" + NumberUtil.toString(LTBookQty) + "," +     

        "'" + DateUtil.getCompleteDateRepresentation(LastDateChange) + "'," +
        "'" + DateUtil.getCompleteDateRepresentation(LastQtyDateChange) + "'," +        
        "" + NumberUtil.toString(LastQtyChange) + "," +
        "'" + Converter.fixString(CustPO) + "'," +
        "'" + Converter.fixString(Ppap) + "'," +
        "'" + Converter.fixString(Trlp) + "'," +
        "'" + Converter.fixString(EdiRelease) + "'," +
        "" + NumberUtil.toString(LeadTime) + "," +
        "" + NumberUtil.toString(LeadTime2) + "," +
        "" + NumberUtil.toString(LeadTime3) + "," +

        "'" + Converter.fixString(ReleaseBase) + "'," +
        "" + NumberUtil.toString(QtyOrdBase) + "," +        
        "" + NumberUtil.toString(CumRequired) + "," +
        "" + NumberUtil.toString(QtyOrderedFromCum) + "," +

        "" + NumberUtil.toString(CumPrior) + "," +
        "" + NumberUtil.toString(QtyRequired) + ")";

    write(sql);	
}

public override
void update(){
	string sql = "update shipexport set " +
		"Site = '" + Converter.fixString(Site) + "', " +
		"Bol = " + NumberUtil.toString(Bol) + ", " +
		"BolItem = " + NumberUtil.toString(BolItem) + ", " +
		"BillTo = '" + Converter.fixString(BillTo) + "', " +
		"ShipTo = '" + Converter.fixString(ShipTo) + "', " +
		"ShipDate = '" + DateUtil.getCompleteDateRepresentation(ShipDate) + "', " +
		"DateRequest = '" + DateUtil.getCompleteDateRepresentation(DateRequest) + "', " +
		"CreateDate = '" + DateUtil.getCompleteDateRepresentation(CreateDate) + "', " +
		"PostDate = '" + DateUtil.getCompleteDateRepresentation(PostDate) + "', " +
		"OrderNum = " + NumberUtil.toString(OrderNum) + ", " +
		"Item = " + NumberUtil.toString(Item) + ", " +
        "Release = '" + Converter.fixString(Release) + "', " +
        "OrdType = '" + Converter.fixString(OrdType) + "', " +
		"Product = '" + Converter.fixString(Product) + "', " +
		"CustPart = '" + Converter.fixString(CustPart) + "', " +
		"QtyShipped = " + NumberUtil.toString(QtyShipped) + ", " +
		"QtyBack = " + NumberUtil.toString(QtyBack) + ", " +
		"QtyExpec = " + NumberUtil.toString(QtyExpec) + ", " +
		"QtyOrder = " + NumberUtil.toString(QtyOrder) + ", " +
		"ProdType = '" + Converter.fixString(ProdType) + "', " +
		"BackFlag = '" + Converter.fixString(BackFlag) + "', " +
		"LineBookDate = '" + DateUtil.getCompleteDateRepresentation(LineBookDate) + "', " +
		"CustReqDate = '" + DateUtil.getCompleteDateRepresentation(CustReqDate) + "', " +
		"BackOrderFlag = '" + Converter.fixString(BackOrderFlag) + "', " +
		"Market = '" + Converter.fixString(Market) + "', " +
		"ExportDate = '" + DateUtil.getCompleteDateRepresentation(ExportDate) + "', " +

        "OrderDate='" + DateUtil.getCompleteDateRepresentation(OrderDate) + "'," +
        "FirstQty=" + NumberUtil.toString(FirstQty) + "," +
        "MajGroup='" + Converter.fixString(MajGroup) + "'," +
        "MinGroup='" + Converter.fixString(MinGroup) + "'," +
        "MinSales='" + Converter.fixString(MinSales) + "'," +
        "MajSales='" + Converter.fixString(MajSales) + "'," +

        "TradPartner='" + Converter.fixString(TradPartner) + "'," +
        "ShipToLoc='" + Converter.fixString(ShipToLoc) + "'," +
        "CumQty=" + NumberUtil.toString(CumQty) + "," +
        "Ran='" + Converter.fixString(Ran) + "'," +
        "LTBookDate='" + DateUtil.getCompleteDateRepresentation(LTBookDate) + "'," +
        "LTBookQty=" + NumberUtil.toString(LTBookQty) + ", " +

        "LastDateChange='" + DateUtil.getCompleteDateRepresentation(LastDateChange) + "'," +
        "LastQtyDateChange='" + DateUtil.getCompleteDateRepresentation(LastQtyDateChange) + "'," +        
        "LastQtyChange=" + NumberUtil.toString(LastQtyChange) + ", " +
        "CustPO='" + Converter.fixString(CustPO) + "', " +
        "Ppap='" + Converter.fixString(Ppap) + "', " +
        "Trlp='" + Converter.fixString(Trlp) + "', " +
        "EdiRelease='" + Converter.fixString(EdiRelease) + "', " +
        "LeadTime=" + NumberUtil.toString(LeadTime) + "," +
        "LeadTime2=" + NumberUtil.toString(LeadTime2) + "," +
        "LeadTime3=" + NumberUtil.toString(LeadTime3) + "," +

        "ReleaseBase='" + Converter.fixString(ReleaseBase) + "'," +
        "QtyOrdBase=" + NumberUtil.toString(QtyOrdBase) + "," +

        "CumRequired=" + NumberUtil.toString(CumRequired) + "," +
        "QtyOrderedFromCum=" + NumberUtil.toString(QtyOrderedFromCum) + "," +

        "CumPrior=" + NumberUtil.toString(CumPrior) + "," +
        "QtyRequired=" + NumberUtil.toString(QtyRequired) + " " +            
           
         "where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from shipexport where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"Site = '" + Converter.fixString(Site) + "' and " +
		"Bol = " + NumberUtil.toString(Bol) + " and " +
		"BolItem = " + NumberUtil.toString(BolItem) + "";
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
void setBillTo(string BillTo){
	this.BillTo = BillTo;
}

public
void setShipTo(string ShipTo){
	this.ShipTo = ShipTo;
}

public
void setShipDate(DateTime ShipDate){
	this.ShipDate = ShipDate;
}

public
void setDateRequest(DateTime DateRequest){
	this.DateRequest = DateRequest;
}

public
void setCreateDate(DateTime CreateDate){
	this.CreateDate = CreateDate;
}

public
void setPostDate(DateTime PostDate){
	this.PostDate = PostDate;
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
void setOrdType(string OrdType){
	this.OrdType = OrdType;
}

public
void setProduct(string Product){
	this.Product = Product;
}

public
void setCustPart(string CustPart){
	this.CustPart = CustPart;
}

public
void setQtyShipped(decimal QtyShipped){
	this.QtyShipped = QtyShipped;
}

public
void setQtyBack(decimal QtyBack){
	this.QtyBack = QtyBack;
}

public
void setQtyExpec(decimal QtyExpec){
	this.QtyExpec = QtyExpec;
}

public
void setQtyOrder(decimal QtyOrder){
	this.QtyOrder = QtyOrder;
}

public
void setProdType(string ProdType){
	this.ProdType = ProdType;
}

public
void setBackFlag(string BackFlag){
	this.BackFlag = BackFlag;
}

public
void setLineBookDate(DateTime LineBookDate){
	this.LineBookDate = LineBookDate;
}

public
void setCustReqDate(DateTime CustReqDate){
	this.CustReqDate = CustReqDate;
}

public
void setBackOrderFlag(string BackOrderFlag){
	this.BackOrderFlag = BackOrderFlag;
}

public
void setMarket(string Market){
	this.Market = Market;
}

public
void setExportDate(DateTime ExportDate){
	this.ExportDate = ExportDate;
}

public
void setOrderDate(DateTime OrderDate){
	this.OrderDate = OrderDate;
}

public
void setFirstQty(decimal FirstQty){
	this.FirstQty = FirstQty;
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
void setTradPartner(string TradPartner){
	this.TradPartner = TradPartner;
}

public
void setShipToLoc(string ShipToLoc){
	this.ShipToLoc = ShipToLoc;
}
 
public
void setCumQty(decimal CumQty){
	this.CumQty = CumQty;
}
                
public
void setRan(string Ran){
	this.Ran = Ran;
}

public
void setLTBookDate(DateTime LTBookDate){
	this.LTBookDate = LTBookDate;
}

public
void setLTBookQty(decimal LTBookQty){
	this.LTBookQty = LTBookQty;
}

public
void setLastDateChange(DateTime LastDateChange){
	this.LastDateChange = LastDateChange;
}

public
void setLastQtyDateChange(DateTime LastQtyDateChange){
	this.LastQtyDateChange = LastQtyDateChange;
}

public
void setLastQtyChange(decimal LastQtyChange){
	this.LastQtyChange = LastQtyChange;
}

public
void setCustPO(string CustPO){
	this.CustPO = CustPO;
}

public
void setPpap(string Ppap){
	this.Ppap = Ppap;
}

public
void setTrlp(string Trlp){
	this.Trlp = Trlp;
}

public
void setEdiRelease(string EdiRelease){
	this.EdiRelease = EdiRelease;
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
void setReleaseBase(string ReleaseBase){
	this.ReleaseBase = ReleaseBase;
}

public
void setQtyOrdBase(decimal QtyOrdBase){
	this.QtyOrdBase = QtyOrdBase;
}

public
void setCumRequired(decimal CumRequired){
    this.CumRequired = CumRequired;
}

public
void setQtyOrderedFromCum(decimal QtyOrderedFromCum){
    this.QtyOrderedFromCum = QtyOrderedFromCum;
}
     
public
void setCumPrior(decimal CumPrior){
    this.CumPrior = CumPrior;
}

public
void setQtyRequired(decimal QtyRequired){
    this.QtyRequired = QtyRequired;
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
string getBillTo(){
	return BillTo;
}

public
string getShipTo(){
	return ShipTo;
}

public
DateTime getShipDate(){
	return ShipDate;
}

public
DateTime getDateRequest(){
	return DateRequest;
}

public
DateTime getCreateDate(){
	return CreateDate;
}

public
DateTime getPostDate(){
	return PostDate;
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
string getOrdType(){
	return OrdType;
}

public
string getProduct(){
	return Product;
}

public
string getCustPart(){
	return CustPart;
}

public
decimal getQtyShipped(){
	return QtyShipped;
}

public
decimal getQtyBack(){
	return QtyBack;
}

public
decimal getQtyExpec(){
	return QtyExpec;
}

public
decimal getQtyOrder(){
	return QtyOrder;
}

public
string getProdType(){
	return ProdType;
}

public
string getBackFlag(){
	return BackFlag;
}

public
DateTime getLineBookDate(){
	return LineBookDate;
}

public
DateTime getCustReqDate(){
	return CustReqDate;
}

public
string getBackOrderFlag(){
	return BackOrderFlag;
}

public
string getMarket(){
	return Market;
}

public
DateTime getExportDate(){
	return ExportDate;
}

public
DateTime getOrderDate(){
	return OrderDate;
}

public
decimal getFirstQty(){
	return FirstQty;
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
string getTradPartner(){
	return TradPartner;
}

public
string getShipToLoc(){
	return ShipToLoc;
}

public
decimal getCumQty(){
    return CumQty;
}
                
public
string getRan(){
    return Ran;
}

public
DateTime getLTBookDate(){
    return LTBookDate;
}

public
decimal getLTBookQty(){
    return LTBookQty;
}

public
DateTime getLastDateChange(){
	return LastDateChange;
}

public
DateTime getLastQtyDateChange(){
	return LastQtyDateChange;
}

public
decimal getLastQtyChange(){
    return LastQtyChange;
}

public
string getCustPO(){
    return CustPO;
}

public
string getPpap(){
    return Ppap;
}

public
string getTrlp(){
    return Trlp;
}

public
string getEdiRelease(){
    return EdiRelease;
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
string getReleaseBase(){
	return ReleaseBase;
}

public
decimal getQtyOrdBase(){
    return QtyOrdBase;
}

public
decimal getCumRequired(){
    return CumRequired;
}

public
decimal getQtyOrderedFromCum(){
    return QtyOrderedFromCum;
}

public
decimal getCumPrior(){
    return CumPrior;
}

public
decimal getQtyRequired(){
    return QtyRequired;
}
 
public 
void updateCustPO(){
	string sql ="update shipexport set " +
		        "CustPO='" + Converter.fixString(CustPO) + "' " +        
            " where Bol = " + NumberUtil.toString(Bol) + " and " +
            " BolItem = " + NumberUtil.toString(BolItem);
    
	update(sql);
}

public 
void updateNewFields(){
	string sql ="update shipexport set " +
                "QtyOrder = " + NumberUtil.toString(QtyOrder) + ", " +
                "EdiRelease='" + Converter.fixString(EdiRelease) + "', " +
                "ReleaseBase='" + Converter.fixString(ReleaseBase) + "'," +
                "QtyOrdBase=" + NumberUtil.toString(QtyOrdBase) + "," +
                "LeadTime=" + NumberUtil.toString(LeadTime) + " " +
                " where " + getWhereCondition();

    update(sql);
}

public 
void updateLeadTimeFields(){
	string sql ="update shipexport set " +
                "LTBookDate='" + DateUtil.getCompleteDateRepresentation(LTBookDate) + "'," +
                "LTBookQty=" + NumberUtil.toString(LTBookQty) + ", " +
                "LeadTime=" + NumberUtil.toString(LeadTime) + " " +
                " where " + getWhereCondition();

    update(sql);
}

public 
void updateBaseFields(){
	string sql ="update shipexport set " +
                "ReleaseBase='" + Converter.fixString(ReleaseBase) + "'," +
                "QtyOrdBase=" + NumberUtil.toString(QtyOrdBase) + " " +             
                " where " + getWhereCondition();

    update(sql);
}

public 
void updateCums(){
	string sql ="update shipexport set " +
                 "CumQty=" + NumberUtil.toString(CumQty) + "," +
                 "CumRequired=" + NumberUtil.toString(CumRequired) + "," +
                 "QtyOrderedFromCum=" + NumberUtil.toString(QtyOrderedFromCum) + "," +

                 "CumPrior=" + NumberUtil.toString(CumPrior) + "," +
                 "QtyRequired=" + NumberUtil.toString(QtyRequired) + " " +

                " where Bol = " + NumberUtil.toString(Bol) + " and " +
                " BolItem = " + NumberUtil.toString(BolItem);
    
	update(sql);
}

} // class
} // package