/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:50 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/PurchaseOrder/PoItemRel.cs,v $ 
*   $State: Exp $ 
*   $Log: PoItemRel.cs,v $
*   Revision 1.2  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/14 03:02:20  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class PoItemRel : MarshalByRefObject
{

private int iD;
private string database;
private int company;
private string plant;
private int po;
private int poItem;
private string poITemRel;
private string wO;
private string condition;
private string revision;
private decimal attribute1;
private decimal attribute2;
private decimal attribute3;
private string attribute4;
private string attribute5;
private decimal qtyOrdered;
private decimal qtyReceived;
private decimal qtyReturned;
private string uom;
private decimal price;
private string priceUom;
private decimal valueOrdered;
private decimal valueReceived;
private decimal percentComp;
private string itemSts;
private string autoCumApply;
private string project;
private string sourceOrig;
private string dropShip;
private decimal hardAllocated;
private decimal invAllocated;
private int invidiualPick;
private string pickDtl;
private int ordersWaiting;
private string approved;
private int pOAccountDis;
private DateTime dateReq;
private DateTime dateConfirmed;
private string status;
private decimal itemValue;
private decimal itemValueLeft;
private int defReceiveCo;
private string defRecievePlt;
private string defReceiveLoc;
private string tax1;
private string tax2;
private string tax3;
private decimal taxAmt1;
private decimal taxAmt2;
private decimal taxAmt3;

public
PoItemRel(){
	this.iD = 0;
	this.database = "";
	this.company = 0;
	this.plant = "";
	this.po = 0;
	this.poItem = 0;
	this.poITemRel = "";
	this.wO = "";
	this.condition = "";
	this.revision = "";
	this.attribute1 = 0;
	this.attribute2 = 0;
	this.attribute3 = 0;
	this.attribute4 = "";
	this.attribute5 = "";
	this.qtyOrdered = 0;
	this.qtyReceived = 0;
	this.qtyReturned = 0;
	this.uom = "";
	this.price = 0;
	this.priceUom = "";
	this.valueOrdered = 0;
	this.valueReceived = 0;
	this.percentComp = 0;
	this.itemSts = "";
	this.autoCumApply = "";
	this.project = "";
	this.sourceOrig = "";
	this.dropShip = "";
	this.hardAllocated = 0;
	this.invAllocated = 0;
	this.invidiualPick = 0;
	this.pickDtl = "";
	this.ordersWaiting = 0;
	this.approved = "";
	this.pOAccountDis = 0;
	this.dateReq = DateUtil.MinValue;
	this.dateConfirmed = DateUtil.MinValue;
	this.status = "";
	this.itemValue = 0;
	this.itemValueLeft = 0;
	this.defReceiveCo = 0;
	this.defRecievePlt = "";
	this.defReceiveLoc = "";
	this.tax1 = "";
	this.tax2 = "";
	this.tax3 = "";
	this.taxAmt1 = 0;
	this.taxAmt2 = 0;
	this.taxAmt3 = 0;
}

public
PoItemRel(
				int iD,
				string database,
				int company,
				string plant,
				int po,
				int poItem,
				string poITemRel,
				string wO,
				string condition,
				string revision,
				decimal attribute1,
				decimal attribute2,
				decimal attribute3,
				string attribute4,
				string attribute5,
				decimal qtyOrdered,
				decimal qtyReceived,
				decimal qtyReturned,
				string uom,
				decimal price,
				string priceUom,
				decimal valueOrdered,
				decimal valueReceived,
				decimal percentComp,
				string itemSts,
				string autoCumApply,
				string project,
				string sourceOrig,
				string dropShip,
				decimal hardAllocated,
				decimal invAllocated,
				int invidiualPick,
				string pickDtl,
				int ordersWaiting,
				string approved,
				int pOAccountDis,
				DateTime dateReq,
				DateTime dateConfirmed,
				string status,
				decimal itemValue,
				decimal itemValueLeft,
				int defReceiveCo,
				string defRecievePlt,
				string defReceiveLoc,
				string tax1,
				string tax2,
				string tax3,
				decimal taxAmt1,
				decimal taxAmt2,
				decimal taxAmt3)
{
	this.iD = iD;
	this.database = database;
	this.company = company;
	this.plant = plant;
	this.po = po;
	this.poItem = poItem;
	this.poITemRel = poITemRel;
	this.wO = wO;
	this.condition = condition;
	this.revision = revision;
	this.attribute1 = attribute1;
	this.attribute2 = attribute2;
	this.attribute3 = attribute3;
	this.attribute4 = attribute4;
	this.attribute5 = attribute5;
	this.qtyOrdered = qtyOrdered;
	this.qtyReceived = qtyReceived;
	this.qtyReturned = qtyReturned;
	this.uom = uom;
	this.price = price;
	this.priceUom = priceUom;
	this.valueOrdered = valueOrdered;
	this.valueReceived = valueReceived;
	this.percentComp = percentComp;
	this.itemSts = itemSts;
	this.autoCumApply = autoCumApply;
	this.project = project;
	this.sourceOrig = sourceOrig;
	this.dropShip = dropShip;
	this.hardAllocated = hardAllocated;
	this.invAllocated = invAllocated;
	this.invidiualPick = invidiualPick;
	this.pickDtl = pickDtl;
	this.ordersWaiting = ordersWaiting;
	this.approved = approved;
	this.pOAccountDis = pOAccountDis;
	this.dateReq = dateReq;
	this.dateConfirmed = dateConfirmed;
	this.status = status;
	this.itemValue = itemValue;
	this.itemValueLeft = itemValueLeft;
	this.defReceiveCo = defReceiveCo;
	this.defRecievePlt = defRecievePlt;
	this.defReceiveLoc = defReceiveLoc;
	this.tax1 = tax1;
	this.tax2 = tax2;
	this.tax3 = tax3;
	this.taxAmt1 = taxAmt1;
	this.taxAmt2 = taxAmt2;
	this.taxAmt3 = taxAmt3;
}

public
void setID(int iD){
	this.iD = iD;
}

public
void setDatabase(string database){
	this.database = database;
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
void setPo(int po){
	this.po = po;
}

public
void setPoItem(int poItem){
	this.poItem = poItem;
}

public
void setPoITemRel(string poITemRel){
	this.poITemRel = poITemRel;
}

public
void setWO(string wO){
	this.wO = wO;
}

public
void setCondition(string condition){
	this.condition = condition;
}

public
void setRevision(string revision){
	this.revision = revision;
}

public
void setAttribute1(decimal attribute1){
	this.attribute1 = attribute1;
}

public
void setAttribute2(decimal attribute2){
	this.attribute2 = attribute2;
}

public
void setAttribute3(decimal attribute3){
	this.attribute3 = attribute3;
}

public
void setAttribute4(string attribute4){
	this.attribute4 = attribute4;
}

public
void setAttribute5(string attribute5){
	this.attribute5 = attribute5;
}

public
void setQtyOrdered(decimal qtyOrdered){
	this.qtyOrdered = qtyOrdered;
}

public
void setQtyReceived(decimal qtyReceived){
	this.qtyReceived = qtyReceived;
}

public
void setQtyReturned(decimal qtyReturned){
	this.qtyReturned = qtyReturned;
}

public
void setUom(string uom){
	this.uom = uom;
}

public
void setPrice(decimal price){
	this.price = price;
}

public
void setPriceUom(string priceUom){
	this.priceUom = priceUom;
}

public
void setValueOrdered(decimal valueOrdered){
	this.valueOrdered = valueOrdered;
}

public
void setValueReceived(decimal valueReceived){
	this.valueReceived = valueReceived;
}

public
void setPercentComp(decimal percentComp){
	this.percentComp = percentComp;
}

public
void setItemSts(string itemSts){
	this.itemSts = itemSts;
}

public
void setAutoCumApply(string autoCumApply){
	this.autoCumApply = autoCumApply;
}

public
void setProject(string project){
	this.project = project;
}

public
void setSourceOrig(string sourceOrig){
	this.sourceOrig = sourceOrig;
}

public
void setDropShip(string dropShip){
	this.dropShip = dropShip;
}

public
void setHardAllocated(decimal hardAllocated){
	this.hardAllocated = hardAllocated;
}

public
void setInvAllocated(decimal invAllocated){
	this.invAllocated = invAllocated;
}

public
void setInvidiualPick(int invidiualPick){
	this.invidiualPick = invidiualPick;
}

public
void setPickDtl(string pickDtl){
	this.pickDtl = pickDtl;
}

public
void setOrdersWaiting(int ordersWaiting){
	this.ordersWaiting = ordersWaiting;
}

public
void setApproved(string approved){
	this.approved = approved;
}

public
void setPOAccountDis(int pOAccountDis){
	this.pOAccountDis = pOAccountDis;
}

public
void setDateReq(DateTime dateReq){
	this.dateReq = dateReq;
}

public
void setDateConfirmed(DateTime dateConfirmed){
	this.dateConfirmed = dateConfirmed;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setItemValue(decimal itemValue){
	this.itemValue = itemValue;
}

public
void setItemValueLeft(decimal itemValueLeft){
	this.itemValueLeft = itemValueLeft;
}

public
void setDefReceiveCo(int defReceiveCo){
	this.defReceiveCo = defReceiveCo;
}

public
void setDefRecievePlt(string defRecievePlt){
	this.defRecievePlt = defRecievePlt;
}

public
void setDefReceiveLoc(string defReceiveLoc){
	this.defReceiveLoc = defReceiveLoc;
}

public
void setTax1(string tax1){
	this.tax1 = tax1;
}

public
void setTax2(string tax2){
	this.tax2 = tax2;
}

public
void setTax3(string tax3){
	this.tax3 = tax3;
}

public
void setTaxAmt1(decimal taxAmt1){
	this.taxAmt1 = taxAmt1;
}

public
void setTaxAmt2(decimal taxAmt2){
	this.taxAmt2 = taxAmt2;
}

public
void setTaxAmt3(decimal taxAmt3){
	this.taxAmt3 = taxAmt3;
}

public
int getID(){
	 return iD;
}

public
string getDatabase(){
	 return database;
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
int getPo(){
	 return po;
}

public
int getPoItem(){
	 return poItem;
}

public
string getPoITemRel(){
	 return poITemRel;
}

public
string getWO(){
	 return wO;
}

public
string getCondition(){
	 return condition;
}

public
string getRevision(){
	 return revision;
}

public
decimal getAttribute1(){
	 return attribute1;
}

public
decimal getAttribute2(){
	 return attribute2;
}

public
decimal getAttribute3(){
	 return attribute3;
}

public
string getAttribute4(){
	 return attribute4;
}

public
string getAttribute5(){
	 return attribute5;
}

public
decimal getQtyOrdered(){
	 return qtyOrdered;
}

public
decimal getQtyReceived(){
	 return qtyReceived;
}

public
decimal getQtyReturned(){
	 return qtyReturned;
}

public
string getUom(){
	 return uom;
}

public
decimal getPrice(){
	 return price;
}

public
string getPriceUom(){
	 return priceUom;
}

public
decimal getValueOrdered(){
	 return valueOrdered;
}

public
decimal getValueReceived(){
	 return valueReceived;
}

public
decimal getPercentComp(){
	 return percentComp;
}

public
string getItemSts(){
	 return itemSts;
}

public
string getAutoCumApply(){
	 return autoCumApply;
}

public
string getProject(){
	 return project;
}

public
string getSourceOrig(){
	 return sourceOrig;
}

public
string getDropShip(){
	 return dropShip;
}

public
decimal getHardAllocated(){
	 return hardAllocated;
}

public
decimal getInvAllocated(){
	 return invAllocated;
}

public
int getInvidiualPick(){
	 return invidiualPick;
}

public
string getPickDtl(){
	 return pickDtl;
}

public
int getOrdersWaiting(){
	 return ordersWaiting;
}

public
string getApproved(){
	 return approved;
}

public
int getPOAccountDis(){
	 return pOAccountDis;
}

public
DateTime getDateReq(){
	 return dateReq;
}

public
DateTime getDateConfirmed(){
	 return dateConfirmed;
}

public
string getStatus(){
	 return status;
}

public
decimal getItemValue(){
	 return itemValue;
}

public
decimal getItemValueLeft(){
	 return itemValueLeft;
}

public
int getDefReceiveCo(){
	 return defReceiveCo;
}

public
string getDefRecievePlt(){
	 return defRecievePlt;
}

public
string getDefReceiveLoc(){
	 return defReceiveLoc;
}

public
string getTax1(){
	 return tax1;
}

public
string getTax2(){
	 return tax2;
}

public
string getTax3(){
	 return tax3;
}

public
decimal getTaxAmt1(){
	 return taxAmt1;
}

public
decimal getTaxAmt2(){
	 return taxAmt2;
}

public
decimal getTaxAmt3(){
	 return taxAmt3;
}

} // class

} // package