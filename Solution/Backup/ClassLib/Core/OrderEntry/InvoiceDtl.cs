/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:50 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/OrderEntry/InvoiceDtl.cs,v $ 
*   $State: Exp $ 
*   $Log: InvoiceDtl.cs,v $
*   Revision 1.8  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.7  2005/04/12 04:20:55  cmelo
*   *** empty log message ***
*
*   Revision 1.6  2005/04/05 23:04:40  gmuller
*   ponga aqui un comentario
*
*   Revision 1.5  2005/03/21 18:46:56  cmelo
*   *** empty log message ***
*
*   Revision 1.4  2005/03/18 21:52:19  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class InvoiceDtl : MarshalByRefObject
{

private string db;
private int company;
private string plant;
private int invoiceNum;
private int invLineNum;
private int orderNum;
private int orderItemNum;
private string releaseNum;
private string part;
private int sequence;
private string revision;
private string custPart;
private string custPartRevision;
private decimal qtyShipped;
private string qSUom;
private decimal qtyShipInv;
private string qSIUom;
private decimal qtyBackOrder;
private decimal qtyOutstand;
private decimal unitPrice;
private string uPUom;
private decimal lineExt;
private string desciption;
private string sC1;
private string sC2;
private string sC3;
private string sC4;
private string sC5;
private string sC6;
private string gLSalesAcc;
private string gLCosAcc;
private string gLCosType;
private int shipCompany;
private string shipPlant;
private string shipStkLoc;
private decimal tax1Amt;
private decimal tax2Amt;
private decimal tax3Amt;
private decimal lineExtwTax;
private decimal taxAmtTot;
private decimal freightAmt;
private decimal discountAmt;
private decimal costExt;
private decimal unitCost;
private decimal labCost;
private decimal matCost;
private decimal oHCost;
private decimal outsideCost;
private decimal royCharges;
private decimal priceBefDis;
private string salesPerson;
private string commPlan;
private decimal commPerCent;
private decimal commRate;
private string componentList;
private string warrantyClaimDetail;
private decimal qtyReturned;
private string manufacturer;
private string manuPart;
private DateTime dateShipped;
private int packingSlip;
private int packingSlipLin;
private string custRan;
private string condition;
private string project;


internal
InvoiceDtl(){
	this.db = "";
	this.company = 0;
	this.plant = "";
	this.invoiceNum = 0;
	this.invLineNum = 0;
	this.orderNum = 0;
	this.orderItemNum = 0;
	this.releaseNum = "";
	this.part = "";
	this.sequence = 0;
	this.revision = "";
	this.custPart = "";
	this.custPartRevision = "";
	this.qtyShipped = 0;
	this.qSUom = "";
	this.qtyShipInv = 0;
	this.qSIUom = "";
	this.qtyBackOrder = 0;
	this.qtyOutstand = 0;
	this.unitPrice = 0;
	this.uPUom = "";
	this.lineExt = 0;
	this.desciption = "";
	this.sC1 = "";
	this.sC2 = "";
	this.sC3 = "";
	this.sC4 = "";
	this.sC5 = "";
	this.sC6 = "";
	this.gLSalesAcc = "";
	this.gLCosAcc = "";
	this.gLCosType = "";
	this.shipCompany = 0;
	this.shipPlant = "";
	this.shipStkLoc = "";
	this.tax1Amt = 0;
	this.tax2Amt = 0;
	this.tax3Amt = 0;
	this.lineExtwTax = 0;
	this.taxAmtTot = 0;
	this.freightAmt = 0;
	this.discountAmt = 0;
	this.costExt = 0;
	this.unitCost = 0;
	this.labCost = 0;
	this.matCost = 0;
	this.oHCost = 0;
	this.outsideCost = 0;
	this.royCharges = 0;
	this.priceBefDis = 0;
	this.salesPerson = "";
	this.commPlan = "";
	this.commPerCent = 0;
	this.commRate = 0;
	this.componentList = "";
	this.warrantyClaimDetail = "";
	this.qtyReturned = 0;
	this.manufacturer = "";
	this.manuPart = "";
	this.dateShipped = DateUtil.MinValue;
	this.packingSlip = 0;
	this.packingSlipLin = 0;
	this.custRan = "";
	this.condition ="";
	this.project = "";
}

public
InvoiceDtl(
				string db,
				int company,
				string plant,
				int invoiceNum,
				int invLineNum,
				int orderNum,
				int orderItemNum,
				string releaseNum,
				string part,
				int sequence,
				string revision,
				string custPart,
				string custPartRevision,
				decimal qtyShipped,
				string qSUom,
				decimal qtyShipInv,
				string qSIUom,
				decimal qtyBackOrder,
				decimal qtyOutstand,
				decimal unitPrice,
				string uPUom,
				decimal lineExt,
				string desciption,
				string sC1,
				string sC2,
				string sC3,
				string sC4,
				string sC5,
				string sC6,
				string gLSalesAcc,
				string gLCosAcc,
				string gLCosType,
				int shipCompany,
				string shipPlant,
				string shipStkLoc,
				decimal tax1Amt,
				decimal tax2Amt,
				decimal tax3Amt,
				decimal lineExtwTax,
				decimal taxAmtTot,
				decimal freightAmt,
				decimal discountAmt,
				decimal costExt,
				decimal unitCost,
				decimal labCost,
				decimal matCost,
				decimal oHCost,
				decimal outsideCost,
				decimal royCharges,
				decimal priceBefDis,
				string salesPerson,
				string commPlan,
				decimal commPerCent,
				decimal commRate,
				string componentList,
				string warrantyClaimDetail,
				decimal qtyReturned,
				string manufacturer,
				string manuPart,
				DateTime dateShipped,
				int packingSlip,
				int packingSlipLin,
				string custRan,
				string condition,
				string project)
{
	this.db = db;
	this.company = company;
	this.plant = plant;
	this.invoiceNum = invoiceNum;
	this.invLineNum = invLineNum;
	this.orderNum = orderNum;
	this.orderItemNum = orderItemNum;
	this.releaseNum = releaseNum;
	this.part = part;
	this.sequence = sequence;
	this.revision = revision;
	this.custPart = custPart;
	this.custPartRevision = custPartRevision;
	this.qtyShipped = qtyShipped;
	this.qSUom = qSUom;
	this.qtyShipInv = qtyShipInv;
	this.qSIUom = qSIUom;
	this.qtyBackOrder = qtyBackOrder;
	this.qtyOutstand = qtyOutstand;
	this.unitPrice = unitPrice;
	this.uPUom = uPUom;
	this.lineExt = lineExt;
	this.desciption = desciption;
	this.sC1 = sC1;
	this.sC2 = sC2;
	this.sC3 = sC3;
	this.sC4 = sC4;
	this.sC5 = sC5;
	this.sC6 = sC6;
	this.gLSalesAcc = gLSalesAcc;
	this.gLCosAcc = gLCosAcc;
	this.gLCosType = gLCosType;
	this.shipCompany = shipCompany;
	this.shipPlant = shipPlant;
	this.shipStkLoc = shipStkLoc;
	this.tax1Amt = tax1Amt;
	this.tax2Amt = tax2Amt;
	this.tax3Amt = tax3Amt;
	this.lineExtwTax = lineExtwTax;
	this.taxAmtTot = taxAmtTot;
	this.freightAmt = freightAmt;
	this.discountAmt = discountAmt;
	this.costExt = costExt;
	this.unitCost = unitCost;
	this.labCost = labCost;
	this.matCost = matCost;
	this.oHCost = oHCost;
	this.outsideCost = outsideCost;
	this.royCharges = royCharges;
	this.priceBefDis = priceBefDis;
	this.salesPerson = salesPerson;
	this.commPlan = commPlan;
	this.commPerCent = commPerCent;
	this.commRate = commRate;
	this.componentList = componentList;
	this.warrantyClaimDetail = warrantyClaimDetail;
	this.qtyReturned = qtyReturned;
	this.manufacturer = manufacturer;
	this.manuPart = manuPart;
	this.dateShipped = dateShipped;
	this.packingSlip = packingSlip;
	this.packingSlipLin = packingSlipLin;
	this.custRan = custRan;
	this.condition = condition;
	this.project = project;
}

public
void setDb(string db){
	this.db = db;
}

public
void setCompany(int company){
	this.company = company;
}

public
void setPlant(string plant){
	this.plant = plant;
}

public
void setInvoiceNum(int invoiceNum){
	this.invoiceNum = invoiceNum;
}

public
void setInvLineNum(int invLineNum){
	this.invLineNum = invLineNum;
}

public
void setOrderNum(int orderNum){
	this.orderNum = orderNum;
}

public
void setOrderItemNum(int orderItemNum){
	this.orderItemNum = orderItemNum;
}

public
void setReleaseNum(string releaseNum){
	this.releaseNum = releaseNum;
}

public
void setPart(string part){
	this.part = part;
}

public
void setSequence(int sequence){
	this.sequence = sequence;
}

public
void setRevision(string revision){
	this.revision = revision;
}

public
void setCustPart(string custPart){
	this.custPart = custPart;
}

public
void setCustPartRevision(string custPartRevision){
	this.custPartRevision = custPartRevision;
}

public
void setQtyShipped(decimal qtyShipped){
	this.qtyShipped = qtyShipped;
}

public
void setQSUom(string qSUom){
	this.qSUom = qSUom;
}

public
void setQtyShipInv(decimal qtyShipInv){
	this.qtyShipInv = qtyShipInv;
}

public
void setQSIUom(string qSIUom){
	this.qSIUom = qSIUom;
}

public
void setQtyBackOrder(decimal qtyBackOrder){
	this.qtyBackOrder = qtyBackOrder;
}

public
void setQtyOutstand(decimal qtyOutstand){
	this.qtyOutstand = qtyOutstand;
}

public
void setUnitPrice(decimal unitPrice){
	this.unitPrice = unitPrice;
}

public
void setUPUom(string uPUom){
	this.uPUom = uPUom;
}

public
void setLineExt(decimal lineExt){
	this.lineExt = lineExt;
}

public
void setDesciption(string desciption){
	this.desciption = desciption;
}

public
void setSC1(string sC1){
	this.sC1 = sC1;
}

public
void setSC2(string sC2){
	this.sC2 = sC2;
}

public
void setSC3(string sC3){
	this.sC3 = sC3;
}

public
void setSC4(string sC4){
	this.sC4 = sC4;
}

public
void setSC5(string sC5){
	this.sC5 = sC5;
}

public
void setSC6(string sC6){
	this.sC6 = sC6;
}

public
void setGLSalesAcc(string gLSalesAcc){
	this.gLSalesAcc = gLSalesAcc;
}

public
void setGLCosAcc(string gLCosAcc){
	this.gLCosAcc = gLCosAcc;
}

public
void setGLCosType(string gLCosType){
	this.gLCosType = gLCosType;
}

public
void setShipCompany(int shipCompany){
	this.shipCompany = shipCompany;
}

public
void setShipPlant(string shipPlant){
	this.shipPlant = shipPlant;
}

public
void setShipStkLoc(string shipStkLoc){
	this.shipStkLoc = shipStkLoc;
}

public
void setTax1Amt(decimal tax1Amt){
	this.tax1Amt = tax1Amt;
}

public
void setTax2Amt(decimal tax2Amt){
	this.tax2Amt = tax2Amt;
}

public
void setTax3Amt(decimal tax3Amt){
	this.tax3Amt = tax3Amt;
}

public
void setLineExtwTax(decimal lineExtwTax){
	this.lineExtwTax = lineExtwTax;
}

public
void setTaxAmtTot(decimal taxAmtTot){
	this.taxAmtTot = taxAmtTot;
}

public
void setFreightAmt(decimal freightAmt){
	this.freightAmt = freightAmt;
}

public
void setDiscountAmt(decimal discountAmt){
	this.discountAmt = discountAmt;
}

public
void setCostExt(decimal costExt){
	this.costExt = costExt;
}

public
void setUnitCost(decimal unitCost){
	this.unitCost = unitCost;
}

public
void setLabCost(decimal labCost){
	this.labCost = labCost;
}

public
void setMatCost(decimal matCost){
	this.matCost = matCost;
}

public
void setOHCost(decimal oHCost){
	this.oHCost = oHCost;
}

public
void setOutsideCost(decimal outsideCost){
	this.outsideCost = outsideCost;
}

public
void setRoyCharges(decimal royCharges){
	this.royCharges = royCharges;
}

public
void setPriceBefDis(decimal priceBefDis){
	this.priceBefDis = priceBefDis;
}

public
void setSalesPerson(string salesPerson){
	this.salesPerson = salesPerson;
}

public
void setCommPlan(string commPlan){
	this.commPlan= commPlan;
}

public
void setCommPerCent(decimal commPerCent){
	this.commPerCent = commPerCent;
}

public
void setCommRate(decimal commRate){
	this.commRate = commRate;
}

public
void setComponentList(string componentList){
	this.componentList = componentList;
}

public
void setWarrantyClaimDetail(string warrantyClaimDetail){
	this.warrantyClaimDetail = warrantyClaimDetail;
}

public
void setQtyReturned(decimal qtyReturned){
	this.qtyReturned = qtyReturned;
}

public
void setManufacturer(string manufacturer){
	this.manufacturer = manufacturer;
}

public
void setManuPart(string manuPart){
	this.manuPart = manuPart;
}

public
void setDateShipped(DateTime dateShipped){
	this.dateShipped = dateShipped;
}

public
void setPackingSlip(int packingSlip){
	this.packingSlip = packingSlip;
}

public
void setPackingSlipLin(int packingSlipLin){
	this.packingSlipLin = packingSlipLin;
}

public
void setCustRan(string custRan){
	this.custRan = custRan;
}

public
void setCondition(string condition){
	this.condition = condition;
}

public
void setProject(string project){
	this.project = project;
}

public
string getDb(){
	 return db;
}

public
int getCompany(){
	 return company;
}

public
string getPlant(){
	 return plant;
}

public
int getInvoiceNum(){
	 return invoiceNum;
}

public
int getInvLineNum(){
	 return invLineNum;
}

public
int getOrderNum(){
	 return orderNum;
}

public
int getOrderItemNum(){
	 return orderItemNum;
}

public
string getReleaseNum(){
	 return releaseNum;
}

public
string getPart(){
	 return part;
}

public
int getSequence(){
	 return sequence;
}

public
string getRevision(){
	 return revision;
}

public
string getCustPart(){
	 return custPart;
}

public
string getCustPartRevision(){
	 return custPartRevision;
}

public
decimal getQtyShipped(){
	 return qtyShipped;
}

public
string getQSUom(){
	 return qSUom;
}

public
decimal getQtyShipInv(){
	 return qtyShipInv;
}

public
string getQSIUom(){
	 return qSIUom;
}

public
decimal getQtyBackOrder(){
	 return qtyBackOrder;
}

public
decimal getQtyOutstand(){
	 return qtyOutstand;
}

public
decimal getUnitPrice(){
	 return unitPrice;
}

public
string getUPUom(){
	 return uPUom;
}

public
decimal getLineExt(){
	 return lineExt;
}

public
string getDesciption(){
	 return desciption;
}

public
string getSC1(){
	 return sC1;
}

public
string getSC2(){
	 return sC2;
}

public
string getSC3(){
	 return sC3;
}

public
string getSC4(){
	 return sC4;
}

public
string getSC5(){
	 return sC5;
}

public
string getSC6(){
	 return sC6;
}

public
string getGLSalesAcc(){
	 return gLSalesAcc;
}

public
string getGLCosAcc(){
	 return gLCosAcc;
}

public
string getGLCosType(){
	 return gLCosType;
}

public
int getShipCompany(){
	 return shipCompany;
}

public
string getShipPlant(){
	 return shipPlant;
}

public
string getShipStkLoc(){
	 return shipStkLoc;
}

public
decimal getTax1Amt(){
	 return tax1Amt;
}

public
decimal getTax2Amt(){
	 return tax2Amt;
}

public
decimal getTax3Amt(){
	 return tax3Amt;
}

public
decimal getLineExtwTax(){
	 return lineExtwTax;
}

public
decimal getTaxAmtTot(){
	 return taxAmtTot;
}

public
decimal getFreightAmt(){
	 return freightAmt;
}

public
decimal getDiscountAmt(){
	 return discountAmt;
}

public
decimal getCostExt(){
	 return costExt;
}

public
decimal getUnitCost(){
	 return unitCost;
}

public
decimal getLabCost(){
	 return labCost;
}

public
decimal getMatCost(){
	 return matCost;
}

public
decimal getOHCost(){
	 return oHCost;
}

public
decimal getOutsideCost(){
	 return outsideCost;
}

public
decimal getRoyCharges(){
	 return royCharges;
}

public
decimal getPriceBefDis(){
	 return priceBefDis;
}

public
string getSalesPerson(){
	 return salesPerson;
}

public
string getCommPlan(){
	 return commPlan;
}

public
decimal getCommPerCent(){
	 return commPerCent;
}

public
decimal getCommRate(){
	 return commRate;
}

public
string getComponentList(){
	 return componentList;
}

public
string getWarrantyClaimDetail(){
	 return warrantyClaimDetail;
}

public
decimal getQtyReturned(){
	 return qtyReturned;
}

public
string getManufacturer(){
	 return manufacturer;
}

public
string getManuPart(){
	 return manuPart;
}

public
DateTime getDateShipped(){
	 return dateShipped;
}

public
int getPackingSlip(){
	 return packingSlip;
}

public
int getPackingSlipLin(){
	 return packingSlipLin;
}

public
string getCustRan(){
	 return custRan;
}

public
string getCondition(){
	 return condition;
}

public
string getProject(){
	 return project;
}

} // class

} // package