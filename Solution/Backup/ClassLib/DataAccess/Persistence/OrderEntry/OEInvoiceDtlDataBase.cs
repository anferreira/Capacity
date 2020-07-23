/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OeInvoiceDtlDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: OeInvoiceDtlDataBase.cs,v $
*   Revision 1.5  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.4  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.3  2005/04/12 04:21:34  cmelo
*   *** empty log message ***
*
*   Revision 1.2  2005/03/21 18:17:19  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/18 21:51:58  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class OeInvoiceDtlDataBase : GenericDataBaseElement {

private string ID_Db;
private int ID_Company;
private string ID_Plant;
private int ID_InvoiceNum;
private int ID_InvLineNum;
private int ID_OrderNum;
private int ID_OrderItemNum;
private string ID_ReleaseNum;
private string ID_Part;
private int ID_Sequence;
private string ID_Revision;
private string ID_CustPart;
private string ID_CustPartRevision;
private decimal ID_QtyShipped;
private string ID_QSUom;
private decimal ID_QtyShipInv;
private string ID_QSIUom;
private decimal ID_QtyBackOrder;
private decimal ID_QtyOutstand;
private decimal ID_UnitPrice;
private string ID_UPUom;
private decimal ID_LineExt;
private string ID_Desciption;
private string ID_SC1;
private string ID_SC2;
private string ID_SC3;
private string ID_SC4;
private string ID_SC5;
private string ID_SC6;
private string ID_GLSalesAcc;
private string ID_GLCosAcc;
private string ID_GLCosType;
private int ID_ShipCompany;
private string ID_ShipPlant;
private string ID_ShipStkLoc;
private decimal ID_Tax1Amt;
private decimal ID_Tax2Amt;
private decimal ID_Tax3Amt;
private decimal ID_LineExtwTax;
private decimal ID_TaxAmtTot;
private decimal ID_FreightAmt;
private decimal ID_DiscountAmt;
private decimal ID_CostExt;
private decimal ID_UnitCost;
private decimal ID_LabCost;
private decimal ID_MatCost;
private decimal ID_OHCost;
private decimal ID_OutsideCost;
private decimal ID_RoyCharges;
private decimal ID_PriceBefDis;
private string ID_SalesPerson;
private string ID_CommPlan;
private decimal ID_CommPerCent;
private decimal ID_CommRate;
private string ID_ComponentList;
private string ID_WarrantyClaimDetail;
private decimal ID_QtyReturned;
private string ID_Manufacturer;
private string ID_ManuPart;
private DateTime ID_DateShipped;
private int ID_PackingSlip;
private int ID_PackingSlipLin;
private string ID_CustRan;
private string ID_Condition;
private string ID_Project;

public
OeInvoiceDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from oeinvoicedtl where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	string sql = "select * from oeinvoicedtl where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.ID_Db = reader.GetString("ID_Db");
	this.ID_Company = reader.GetInt32("ID_Company");
	this.ID_Plant = reader.GetString("ID_Plant");
	this.ID_InvoiceNum = reader.GetInt32("ID_InvoiceNum");
	this.ID_InvLineNum = reader.GetInt32("ID_InvLineNum");
	this.ID_OrderNum = reader.GetInt32("ID_OrderNum");
	this.ID_OrderItemNum = reader.GetInt32("ID_OrderItemNum");
	this.ID_ReleaseNum = reader.GetString("ID_ReleaseNum");
	this.ID_Part = reader.GetString("ID_Part");
	this.ID_Sequence = reader.GetInt32("ID_Sequence");
	this.ID_Revision = reader.GetString("ID_Revision");
	this.ID_CustPart = reader.GetString("ID_CustPart");
	this.ID_CustPartRevision = reader.GetString("ID_CustPartRevision");
	this.ID_QtyShipped = reader.GetDecimal("ID_QtyShipped");
	this.ID_QSUom = reader.GetString("ID_QSUom");
	this.ID_QtyShipInv = reader.GetDecimal("ID_QtyShipInv");
	this.ID_QSIUom = reader.GetString("ID_QSIUom");
	this.ID_QtyBackOrder = reader.GetDecimal("ID_QtyBackOrder");
	this.ID_QtyOutstand = reader.GetDecimal("ID_QtyOutstand");
	this.ID_UnitPrice = reader.GetDecimal("ID_UnitPrice");
	this.ID_UPUom = reader.GetString("ID_UPUom");
	this.ID_LineExt = reader.GetDecimal("ID_LineExt");
	this.ID_Desciption = reader.GetString("ID_Desciption");
	this.ID_SC1 = reader.GetString("ID_SC1");
	this.ID_SC2 = reader.GetString("ID_SC2");
	this.ID_SC3 = reader.GetString("ID_SC3");
	this.ID_SC4 = reader.GetString("ID_SC4");
	this.ID_SC5 = reader.GetString("ID_SC5");
	this.ID_SC6 = reader.GetString("ID_SC6");
	this.ID_GLSalesAcc = reader.GetString("ID_GLSalesAcc");
	this.ID_GLCosAcc = reader.GetString("ID_GLCosAcc");
	this.ID_GLCosType = reader.GetString("ID_GLCosType");
	this.ID_ShipCompany = reader.GetInt32("ID_ShipCompany");
	this.ID_ShipPlant = reader.GetString("ID_ShipPlant");
	this.ID_ShipStkLoc = reader.GetString("ID_ShipStkLoc");
	this.ID_Tax1Amt = reader.GetDecimal("ID_Tax1Amt");
	this.ID_Tax2Amt = reader.GetDecimal("ID_Tax2Amt");
	this.ID_Tax3Amt = reader.GetDecimal("ID_Tax3Amt");
	this.ID_LineExtwTax = reader.GetDecimal("ID_LineExtwTax");
	this.ID_TaxAmtTot = reader.GetDecimal("ID_TaxAmtTot");
	this.ID_FreightAmt = reader.GetDecimal("ID_FreightAmt");
	this.ID_DiscountAmt = reader.GetDecimal("ID_DiscountAmt");
	this.ID_CostExt = reader.GetDecimal("ID_CostExt");
	this.ID_UnitCost = reader.GetDecimal("ID_UnitCost");
	this.ID_LabCost = reader.GetDecimal("ID_LabCost");
	this.ID_MatCost = reader.GetDecimal("ID_MatCost");
	this.ID_OHCost = reader.GetDecimal("ID_OHCost");
	this.ID_OutsideCost = reader.GetDecimal("ID_OutsideCost");
	this.ID_RoyCharges = reader.GetDecimal("ID_RoyCharges");
	this.ID_PriceBefDis = reader.GetDecimal("ID_PriceBefDis");
	this.ID_SalesPerson = reader.GetString("ID_SalesPerson");
	this.ID_CommPlan = reader.GetString("ID_CommPlan");
	this.ID_CommPerCent = reader.GetDecimal("ID_CommPerCent");
	this.ID_CommRate = reader.GetDecimal("ID_CommRate");
	this.ID_ComponentList = reader.GetString("ID_ComponentList");
	this.ID_WarrantyClaimDetail = reader.GetString("ID_WarrantyClaimDetail");
	this.ID_QtyReturned = reader.GetDecimal("ID_QtyReturned");
	this.ID_Manufacturer = reader.GetString("ID_Manufacturer");
	this.ID_ManuPart = reader.GetString("ID_ManuPart");
	this.ID_DateShipped = reader.GetDateTime("ID_DateShipped");
	this.ID_PackingSlip = reader.GetInt32("ID_PackingSlip");
	this.ID_PackingSlipLin = reader.GetInt32("ID_PackingSlipLin");
	this.ID_CustRan = reader.GetString("ID_CustRan");
	this.ID_Condition = reader.GetString("ID_Condition");
	this.ID_Project = reader.GetString("ID_Project");
}

public override
void write(){
	string sql = "insert into oeinvoicedtl (" + 
		"ID_Db," +
		"ID_Company," +
		"ID_Plant," +
		"ID_InvoiceNum," +
		"ID_InvLineNum," +
		"ID_OrderNum," +
		"ID_OrderItemNum," +
		"ID_ReleaseNum," +
		"ID_Part," +
		"ID_Sequence," +
		"ID_Revision," +
		"ID_CustPart," +
		"ID_CustPartRevision," +
		"ID_QtyShipped," +
		"ID_QSUom," +
		"ID_QtyShipInv," +
		"ID_QSIUom," +
		"ID_QtyBackOrder," +
		"ID_QtyOutstand," +
		"ID_UnitPrice," +
		"ID_UPUom," +
		"ID_LineExt," +
		"ID_Desciption," +
		"ID_SC1," +
		"ID_SC2," +
		"ID_SC3," +
		"ID_SC4," +
		"ID_SC5," +
		"ID_SC6," +
		"ID_GLSalesAcc," +
		"ID_GLCosAcc," +
		"ID_GLCosType," +
		"ID_ShipCompany," +
		"ID_ShipPlant," +
		"ID_ShipStkLoc," +
		"ID_Tax1Amt," +
		"ID_Tax2Amt," +
		"ID_Tax3Amt," +
		"ID_LineExtwTax," +
		"ID_TaxAmtTot," +
		"ID_FreightAmt," +
		"ID_DiscountAmt," +
		"ID_CostExt," +
		"ID_UnitCost," +
		"ID_LabCost," +
		"ID_MatCost," +
		"ID_OHCost," +
		"ID_OutsideCost," +
		"ID_RoyCharges," +
		"ID_PriceBefDis," +
		"ID_SalesPerson," +
		"ID_CommPlan," +
		"ID_CommPerCent," +
		"ID_CommRate," +
		"ID_ComponentList," +
		"ID_WarrantyClaimDetail," +
		"ID_QtyReturned," +
		"ID_Manufacturer," +
		"ID_ManuPart," +
		"ID_DateShipped," +
		"ID_PackingSlip," +
		"ID_PackingSlipLin," +
		"ID_CustRan" +
		"ID_Condition" +
		"ID_Project" +

		") values (" + 

		"'" + Converter.fixString(ID_Db) + "'," +
		"" + NumberUtil.toString(ID_Company) + "," +
		"'" + Converter.fixString(ID_Plant) + "'," +
		"" + NumberUtil.toString(ID_InvoiceNum) + "," +
		"" + NumberUtil.toString(ID_InvLineNum) + "," +
		"" + NumberUtil.toString(ID_OrderNum) + "," +
		"" + NumberUtil.toString(ID_OrderItemNum) + "," +
		"'" + Converter.fixString(ID_ReleaseNum) + "'," +
		"'" + Converter.fixString(ID_Part) + "'," +
		"" + NumberUtil.toString(ID_Sequence) + "," +
		"'" + Converter.fixString(ID_Revision) + "'," +
		"'" + Converter.fixString(ID_CustPart) + "'," +
		"'" + Converter.fixString(ID_CustPartRevision) + "'," +
		"" + NumberUtil.toString(ID_QtyShipped) + "," +
		"'" + Converter.fixString(ID_QSUom) + "'," +
		"" + NumberUtil.toString(ID_QtyShipInv) + "," +
		"'" + Converter.fixString(ID_QSIUom) + "'," +
		"" + NumberUtil.toString(ID_QtyBackOrder) + "," +
		"" + NumberUtil.toString(ID_QtyOutstand) + "," +
		"" + NumberUtil.toString(ID_UnitPrice) + "," +
		"'" + Converter.fixString(ID_UPUom) + "'," +
		"" + NumberUtil.toString(ID_LineExt) + "," +
		"'" + Converter.fixString(ID_Desciption) + "'," +
		"'" + Converter.fixString(ID_SC1) + "'," +
		"'" + Converter.fixString(ID_SC2) + "'," +
		"'" + Converter.fixString(ID_SC3) + "'," +
		"'" + Converter.fixString(ID_SC4) + "'," +
		"'" + Converter.fixString(ID_SC5) + "'," +
		"'" + Converter.fixString(ID_SC6) + "'," +
		"'" + Converter.fixString(ID_GLSalesAcc) + "'," +
		"'" + Converter.fixString(ID_GLCosAcc) + "'," +
		"'" + Converter.fixString(ID_GLCosType) + "'," +
		"" + NumberUtil.toString(ID_ShipCompany) + "," +
		"'" + Converter.fixString(ID_ShipPlant) + "'," +
		"'" + Converter.fixString(ID_ShipStkLoc) + "'," +
		"" + NumberUtil.toString(ID_Tax1Amt) + "," +
		"" + NumberUtil.toString(ID_Tax2Amt) + "," +
		"" + NumberUtil.toString(ID_Tax3Amt) + "," +
		"" + NumberUtil.toString(ID_LineExtwTax) + "," +
		"" + NumberUtil.toString(ID_TaxAmtTot) + "," +
		"" + NumberUtil.toString(ID_FreightAmt) + "," +
		"" + NumberUtil.toString(ID_DiscountAmt) + "," +
		"" + NumberUtil.toString(ID_CostExt) + "," +
		"" + NumberUtil.toString(ID_UnitCost) + "," +
		"" + NumberUtil.toString(ID_LabCost) + "," +
		"" + NumberUtil.toString(ID_MatCost) + "," +
		"" + NumberUtil.toString(ID_OHCost) + "," +
		"" + NumberUtil.toString(ID_OutsideCost) + "," +
		"" + NumberUtil.toString(ID_RoyCharges) + "," +
		"" + NumberUtil.toString(ID_PriceBefDis) + "," +
		"'" + Converter.fixString(ID_SalesPerson) + "'," +
		"'" + Converter.fixString(ID_CommPlan) +"', " +
		"" + NumberUtil.toString(ID_CommPerCent) + "," +
		"" + NumberUtil.toString(ID_CommRate) + "," +
		"'" + Converter.fixString(ID_ComponentList) + "'," +
		"'" + Converter.fixString(ID_WarrantyClaimDetail) + "'," +
		"" + NumberUtil.toString(ID_QtyReturned) + "," +
		"'" + Converter.fixString(ID_Manufacturer) + "'," +
		"'" + Converter.fixString(ID_ManuPart) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ID_DateShipped) + "'," +
		"" + NumberUtil.toString(ID_PackingSlip) + "," +
		"" + NumberUtil.toString(ID_PackingSlipLin) + "," +
		"'" + Converter.fixString(ID_CustRan) + "'," +
		"'" + Converter.fixString(ID_Condition) +"'" +
		"'" + Converter.fixString(ID_Project) +"')";
	write(sql);
}

public override
void update(){
	string sql = "update oeinvoicedtl set " +
		"ID_Db = '" + Converter.fixString(ID_Db) + "', " +
		"ID_Company = " + NumberUtil.toString(ID_Company) + ", " +
		"ID_Plant = '" + Converter.fixString(ID_Plant) + "', " +
		"ID_InvoiceNum = " + NumberUtil.toString(ID_InvoiceNum) + ", " +
		"ID_InvLineNum = " + NumberUtil.toString(ID_InvLineNum) + ", " +
		"ID_OrderNum = " + NumberUtil.toString(ID_OrderNum) + ", " +
		"ID_OrderItemNum = " + NumberUtil.toString(ID_OrderItemNum) + ", " +
		"ID_ReleaseNum = '" + Converter.fixString(ID_ReleaseNum) + "', " +
		"ID_Part = '" + Converter.fixString(ID_Part) + "', " +
		"ID_Sequence = " + NumberUtil.toString(ID_Sequence) + ", " +
		"ID_Revision = '" + Converter.fixString(ID_Revision) + "', " +
		"ID_CustPart = '" + Converter.fixString(ID_CustPart) + "', " +
		"ID_CustPartRevision = '" + Converter.fixString(ID_CustPartRevision) + "', " +
		"ID_QtyShipped = " + NumberUtil.toString(ID_QtyShipped) + ", " +
		"ID_QSUom = '" + Converter.fixString(ID_QSUom) + "', " +
		"ID_QtyShipInv = " + NumberUtil.toString(ID_QtyShipInv) + ", " +
		"ID_QSIUom = '" + Converter.fixString(ID_QSIUom) + "', " +
		"ID_QtyBackOrder = " + NumberUtil.toString(ID_QtyBackOrder) + ", " +
		"ID_QtyOutstand = " + NumberUtil.toString(ID_QtyOutstand) + ", " +
		"ID_UnitPrice = " + NumberUtil.toString(ID_UnitPrice) + ", " +
		"ID_UPUom = '" + Converter.fixString(ID_UPUom) + "', " +
		"ID_LineExt = " + NumberUtil.toString(ID_LineExt) + ", " +
		"ID_Desciption = '" + Converter.fixString(ID_Desciption) + "', " +
		"ID_SC1 = '" + Converter.fixString(ID_SC1) + "', " +
		"ID_SC2 = '" + Converter.fixString(ID_SC2) + "', " +
		"ID_SC3 = '" + Converter.fixString(ID_SC3) + "', " +
		"ID_SC4 = '" + Converter.fixString(ID_SC4) + "', " +
		"ID_SC5 = '" + Converter.fixString(ID_SC5) + "', " +
		"ID_SC6 = '" + Converter.fixString(ID_SC6) + "', " +
		"ID_GLSalesAcc = '" + Converter.fixString(ID_GLSalesAcc) + "', " +
		"ID_GLCosAcc = '" + Converter.fixString(ID_GLCosAcc) + "', " +
		"ID_GLCosType = '" + Converter.fixString(ID_GLCosType) + "', " +
		"ID_ShipCompany = " + NumberUtil.toString(ID_ShipCompany) + ", " +
		"ID_ShipPlant = '" + Converter.fixString(ID_ShipPlant) + "', " +
		"ID_ShipStkLoc = '" + Converter.fixString(ID_ShipStkLoc) + "', " +
		"ID_Tax1Amt = " + NumberUtil.toString(ID_Tax1Amt) + ", " +
		"ID_Tax2Amt = " + NumberUtil.toString(ID_Tax2Amt) + ", " +
		"ID_Tax3Amt = " + NumberUtil.toString(ID_Tax3Amt) + ", " +
		"ID_LineExtwTax = " + NumberUtil.toString(ID_LineExtwTax) + ", " +
		"ID_TaxAmtTot = " + NumberUtil.toString(ID_TaxAmtTot) + ", " +
		"ID_FreightAmt = " + NumberUtil.toString(ID_FreightAmt) + ", " +
		"ID_DiscountAmt = " + NumberUtil.toString(ID_DiscountAmt) + ", " +
		"ID_CostExt = " + NumberUtil.toString(ID_CostExt) + ", " +
		"ID_UnitCost = " + NumberUtil.toString(ID_UnitCost) + ", " +
		"ID_LabCost = " + NumberUtil.toString(ID_LabCost) + ", " +
		"ID_MatCost = " + NumberUtil.toString(ID_MatCost) + ", " +
		"ID_OHCost = " + NumberUtil.toString(ID_OHCost) + ", " +
		"ID_OutsideCost = " + NumberUtil.toString(ID_OutsideCost) + ", " +
		"ID_RoyCharges = " + NumberUtil.toString(ID_RoyCharges) + ", " +
		"ID_PriceBefDis = " + NumberUtil.toString(ID_PriceBefDis) + ", " +
		"ID_SalesPerson = '" + Converter.fixString(ID_SalesPerson) + "', " +
		"ID_CommPlan = '" + Converter.fixString(ID_CommPlan) +"', " +
		"ID_CommPerCent = " + NumberUtil.toString(ID_CommPerCent) + ", " +
		"ID_CommRate = " + NumberUtil.toString(ID_CommRate) + ", " +
		"ID_ComponentList = '" + Converter.fixString(ID_ComponentList) + "', " +
		"ID_WarrantyClaimDetail = '" + Converter.fixString(ID_WarrantyClaimDetail) + "', " +
		"ID_QtyReturned = " + NumberUtil.toString(ID_QtyReturned) + ", " +
		"ID_Manufacturer = '" + Converter.fixString(ID_Manufacturer) + "', " +
		"ID_ManuPart = '" + Converter.fixString(ID_ManuPart) + "', " +
		"ID_DateShipped = '" + DateUtil.getCompleteDateRepresentation(ID_DateShipped) + "', " +
		"ID_PackingSlip = " + NumberUtil.toString(ID_PackingSlip) + ", " +
		"ID_PackingSlipLin = " + NumberUtil.toString(ID_PackingSlipLin) + ", " +
		"ID_CustRan = '" + Converter.fixString(ID_CustRan) + "', " +
		"ID_Condition = '" + Converter.fixString(ID_Condition) +"', " +
		"ID_Project = '" + Converter.fixString(ID_Project) +"' " +
		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from oeinvoicedtl where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"ID_Db = '" + Converter.fixString(ID_Db) + "' and " +
		"ID_Company = " + NumberUtil.toString(ID_Company) + " and " +
		"ID_Plant = '" + Converter.fixString(ID_Plant) + "' and " +
		"ID_InvoiceNum = " + NumberUtil.toString(ID_InvoiceNum) + " and " +
		"ID_InvLineNum = " + NumberUtil.toString(ID_InvLineNum) + "";
	return sqlWhere;
}

public
void setID_Db(string ID_Db){
	this.ID_Db = ID_Db;
}

public
void setID_Company(int ID_Company){
	this.ID_Company = ID_Company;
}

public
void setID_Plant(string ID_Plant){
	this.ID_Plant = ID_Plant;
}

public
void setID_InvoiceNum(int ID_InvoiceNum){
	this.ID_InvoiceNum = ID_InvoiceNum;
}

public
void setID_InvLineNum(int ID_InvLineNum){
	this.ID_InvLineNum = ID_InvLineNum;
}

public
void setID_OrderNum(int ID_OrderNum){
	this.ID_OrderNum = ID_OrderNum;
}

public
void setID_OrderItemNum(int ID_OrderItemNum){
	this.ID_OrderItemNum = ID_OrderItemNum;
}

public
void setID_ReleaseNum(string ID_ReleaseNum){
	this.ID_ReleaseNum = ID_ReleaseNum;
}

public
void setID_Part(string ID_Part){
	this.ID_Part = ID_Part;
}

public
void setID_Sequence(int ID_Sequence){
	this.ID_Sequence = ID_Sequence;
}

public
void setID_Revision(string ID_Revision){
	this.ID_Revision = ID_Revision;
}

public
void setID_CustPart(string ID_CustPart){
	this.ID_CustPart = ID_CustPart;
}

public
void setID_CustPartRevision(string ID_CustPartRevision){
	this.ID_CustPartRevision = ID_CustPartRevision;
}

public
void setID_QtyShipped(decimal ID_QtyShipped){
	this.ID_QtyShipped = ID_QtyShipped;
}

public
void setID_QSUom(string ID_QSUom){
	this.ID_QSUom = ID_QSUom;
}

public
void setID_QtyShipInv(decimal ID_QtyShipInv){
	this.ID_QtyShipInv = ID_QtyShipInv;
}

public
void setID_QSIUom(string ID_QSIUom){
	this.ID_QSIUom = ID_QSIUom;
}

public
void setID_QtyBackOrder(decimal ID_QtyBackOrder){
	this.ID_QtyBackOrder = ID_QtyBackOrder;
}

public
void setID_QtyOutstand(decimal ID_QtyOutstand){
	this.ID_QtyOutstand = ID_QtyOutstand;
}

public
void setID_UnitPrice(decimal ID_UnitPrice){
	this.ID_UnitPrice = ID_UnitPrice;
}

public
void setID_UPUom(string ID_UPUom){
	this.ID_UPUom = ID_UPUom;
}

public
void setID_LineExt(decimal ID_LineExt){
	this.ID_LineExt = ID_LineExt;
}

public
void setID_Desciption(string ID_Desciption){
	this.ID_Desciption = ID_Desciption;
}

public
void setID_SC1(string ID_SC1){
	this.ID_SC1 = ID_SC1;
}

public
void setID_SC2(string ID_SC2){
	this.ID_SC2 = ID_SC2;
}

public
void setID_SC3(string ID_SC3){
	this.ID_SC3 = ID_SC3;
}

public
void setID_SC4(string ID_SC4){
	this.ID_SC4 = ID_SC4;
}

public
void setID_SC5(string ID_SC5){
	this.ID_SC5 = ID_SC5;
}

public
void setID_SC6(string ID_SC6){
	this.ID_SC6 = ID_SC6;
}

public
void setID_GLSalesAcc(string ID_GLSalesAcc){
	this.ID_GLSalesAcc = ID_GLSalesAcc;
}

public
void setID_GLCosAcc(string ID_GLCosAcc){
	this.ID_GLCosAcc = ID_GLCosAcc;
}

public
void setID_GLCosType(string ID_GLCosType){
	this.ID_GLCosType = ID_GLCosType;
}

public
void setID_ShipCompany(int ID_ShipCompany){
	this.ID_ShipCompany = ID_ShipCompany;
}

public
void setID_ShipPlant(string ID_ShipPlant){
	this.ID_ShipPlant = ID_ShipPlant;
}

public
void setID_ShipStkLoc(string ID_ShipStkLoc){
	this.ID_ShipStkLoc = ID_ShipStkLoc;
}

public
void setID_Tax1Amt(decimal ID_Tax1Amt){
	this.ID_Tax1Amt = ID_Tax1Amt;
}

public
void setID_Tax2Amt(decimal ID_Tax2Amt){
	this.ID_Tax2Amt = ID_Tax2Amt;
}

public
void setID_Tax3Amt(decimal ID_Tax3Amt){
	this.ID_Tax3Amt = ID_Tax3Amt;
}

public
void setID_LineExtwTax(decimal ID_LineExtwTax){
	this.ID_LineExtwTax = ID_LineExtwTax;
}

public
void setID_TaxAmtTot(decimal ID_TaxAmtTot){
	this.ID_TaxAmtTot = ID_TaxAmtTot;
}

public
void setID_FreightAmt(decimal ID_FreightAmt){
	this.ID_FreightAmt = ID_FreightAmt;
}

public
void setID_DiscountAmt(decimal ID_DiscountAmt){
	this.ID_DiscountAmt = ID_DiscountAmt;
}

public
void setID_CostExt(decimal ID_CostExt){
	this.ID_CostExt = ID_CostExt;
}

public
void setID_UnitCost(decimal ID_UnitCost){
	this.ID_UnitCost = ID_UnitCost;
}

public
void setID_LabCost(decimal ID_LabCost){
	this.ID_LabCost = ID_LabCost;
}

public
void setID_MatCost(decimal ID_MatCost){
	this.ID_MatCost = ID_MatCost;
}

public
void setID_OHCost(decimal ID_OHCost){
	this.ID_OHCost = ID_OHCost;
}

public
void setID_OutsideCost(decimal ID_OutsideCost){
	this.ID_OutsideCost = ID_OutsideCost;
}

public
void setID_RoyCharges(decimal ID_RoyCharges){
	this.ID_RoyCharges = ID_RoyCharges;
}

public
void setID_PriceBefDis(decimal ID_PriceBefDis){
	this.ID_PriceBefDis = ID_PriceBefDis;
}

public
void setID_SalesPerson(string ID_SalesPerson){
	this.ID_SalesPerson = ID_SalesPerson;
}

public
void setID_CommPlan(string ID_CommPlan){
	this.ID_CommPlan = ID_CommPlan;
}


public
void setID_CommPerCent(decimal ID_CommPerCent){
	this.ID_CommPerCent = ID_CommPerCent;
}

public
void setID_CommRate(decimal ID_CommRate){
	this.ID_CommRate = ID_CommRate;
}

public
void setID_ComponentList(string ID_ComponentList){
	this.ID_ComponentList = ID_ComponentList;
}

public
void setID_WarrantyClaimDetail(string ID_WarrantyClaimDetail){
	this.ID_WarrantyClaimDetail = ID_WarrantyClaimDetail;
}

public
void setID_QtyReturned(decimal ID_QtyReturned){
	this.ID_QtyReturned = ID_QtyReturned;
}

public
void setID_Manufacturer(string ID_Manufacturer){
	this.ID_Manufacturer = ID_Manufacturer;
}

public
void setID_ManuPart(string ID_ManuPart){
	this.ID_ManuPart = ID_ManuPart;
}

public
void setID_DateShipped(DateTime ID_DateShipped){
	this.ID_DateShipped = ID_DateShipped;
}

public
void setID_PackingSlip(int ID_PackingSlip){
	this.ID_PackingSlip = ID_PackingSlip;
}

public
void setID_PackingSlipLin(int ID_PackingSlipLin){
	this.ID_PackingSlipLin = ID_PackingSlipLin;
}

public
void setID_CustRan(string ID_CustRan){
	this.ID_CustRan = ID_CustRan;
}

public
void setID_Condition(string ID_Condition){
	this.ID_Condition = ID_Condition;
}

public
void setID_Project(string ID_Project){
	this.ID_Project = ID_Project;
}

public
string getID_Db(){
	return ID_Db;
}

public
int getID_Company(){
	return ID_Company;
}

public
string getID_Plant(){
	return ID_Plant;
}

public
int getID_InvoiceNum(){
	return ID_InvoiceNum;
}

public
int getID_InvLineNum(){
	return ID_InvLineNum;
}

public
int getID_OrderNum(){
	return ID_OrderNum;
}

public
int getID_OrderItemNum(){
	return ID_OrderItemNum;
}

public
string getID_ReleaseNum(){
	return ID_ReleaseNum;
}

public
string getID_Part(){
	return ID_Part;
}

public
int getID_Sequence(){
	return ID_Sequence;
}

public
string getID_Revision(){
	return ID_Revision;
}

public
string getID_CustPart(){
	return ID_CustPart;
}

public
string getID_CustPartRevision(){
	return ID_CustPartRevision;
}

public
decimal getID_QtyShipped(){
	return ID_QtyShipped;
}

public
string getID_QSUom(){
	return ID_QSUom;
}

public
decimal getID_QtyShipInv(){
	return ID_QtyShipInv;
}

public
string getID_QSIUom(){
	return ID_QSIUom;
}

public
decimal getID_QtyBackOrder(){
	return ID_QtyBackOrder;
}

public
decimal getID_QtyOutstand(){
	return ID_QtyOutstand;
}

public
decimal getID_UnitPrice(){
	return ID_UnitPrice;
}

public
string getID_UPUom(){
	return ID_UPUom;
}

public
decimal getID_LineExt(){
	return ID_LineExt;
}

public
string getID_Desciption(){
	return ID_Desciption;
}

public
string getID_SC1(){
	return ID_SC1;
}

public
string getID_SC2(){
	return ID_SC2;
}

public
string getID_SC3(){
	return ID_SC3;
}

public
string getID_SC4(){
	return ID_SC4;
}

public
string getID_SC5(){
	return ID_SC5;
}

public
string getID_SC6(){
	return ID_SC6;
}

public
string getID_GLSalesAcc(){
	return ID_GLSalesAcc;
}

public
string getID_GLCosAcc(){
	return ID_GLCosAcc;
}

public
string getID_GLCosType(){
	return ID_GLCosType;
}

public
int getID_ShipCompany(){
	return ID_ShipCompany;
}

public
string getID_ShipPlant(){
	return ID_ShipPlant;
}

public
string getID_ShipStkLoc(){
	return ID_ShipStkLoc;
}

public
decimal getID_Tax1Amt(){
	return ID_Tax1Amt;
}

public
decimal getID_Tax2Amt(){
	return ID_Tax2Amt;
}

public
decimal getID_Tax3Amt(){
	return ID_Tax3Amt;
}

public
decimal getID_LineExtwTax(){
	return ID_LineExtwTax;
}

public
decimal getID_TaxAmtTot(){
	return ID_TaxAmtTot;
}

public
decimal getID_FreightAmt(){
	return ID_FreightAmt;
}

public
decimal getID_DiscountAmt(){
	return ID_DiscountAmt;
}

public
decimal getID_CostExt(){
	return ID_CostExt;
}

public
decimal getID_UnitCost(){
	return ID_UnitCost;
}

public
decimal getID_LabCost(){
	return ID_LabCost;
}

public
decimal getID_MatCost(){
	return ID_MatCost;
}

public
decimal getID_OHCost(){
	return ID_OHCost;
}

public
decimal getID_OutsideCost(){
	return ID_OutsideCost;
}

public
decimal getID_RoyCharges(){
	return ID_RoyCharges;
}

public
decimal getID_PriceBefDis(){
	return ID_PriceBefDis;
}

public
string getID_SalesPerson(){
	return ID_SalesPerson;
}

public
string getID_CommPlan(){
	return ID_CommPlan;
}

public
decimal getID_CommPerCent(){
	return ID_CommPerCent;
}

public
decimal getID_CommRate(){
	return ID_CommRate;
}

public
string getID_ComponentList(){
	return ID_ComponentList;
}

public
string getID_WarrantyClaimDetail(){
	return ID_WarrantyClaimDetail;
}

public
decimal getID_QtyReturned(){
	return ID_QtyReturned;
}

public
string getID_Manufacturer(){
	return ID_Manufacturer;
}

public
string getID_ManuPart(){
	return ID_ManuPart;
}

public
DateTime getID_DateShipped(){
	return ID_DateShipped;
}

public
int getID_PackingSlip(){
	return ID_PackingSlip;
}

public
int getID_PackingSlipLin(){
	return ID_PackingSlipLin;
}

public
string getID_CustRan(){
	return ID_CustRan;
}

public
string getID_Condition(){
	return ID_Condition;
}

public
string getID_Project(){
	return ID_Project;
}

} // class
} // package