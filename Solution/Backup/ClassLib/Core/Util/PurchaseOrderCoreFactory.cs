/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo$ 
*   $Date 13-04-2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/Util/PurchaseOrderCoreFactory.cs,v $ 
*   $State: Exp $ 
*   $Log: PurchaseOrderCoreFactory.cs,v $
*   Revision 1.2  2005-05-17 04:34:51  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/14 03:02:41  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util
{

public
class PurchaseOrderCoreFactory : ProductPlanCoreFactory
{

protected
PurchaseOrderCoreFactory() : base(){
}


//----------------------------- PoHdr ----------------------------------------------------------------
public
bool existsPoHdr (int id){

	try{
		PoHdrDataBase poHdrDataBase = new PoHdrDataBase(dataBaseAccess);

		poHdrDataBase.setPOH_Id(id);

		return poHdrDataBase.exists();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PoHdr readPoHdr (int id){

	try{
		PoHdrDataBase poHdrDataBase = new PoHdrDataBase(dataBaseAccess);

		poHdrDataBase.setPOH_Id(id);

		if (!poHdrDataBase.exists())
			return null;

		poHdrDataBase.read();

		PoHdr poHdr = this.objectDataBaseToObject(poHdrDataBase);

		return poHdr;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updatePoHdr(PoHdr poHdr){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoHdrDataBase poHdrDataBase = this.objectToObjectDataBase(poHdr);

		poHdrDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writePoHdr (PoHdr poHdr){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoHdrDataBase poHdrDataBase = this.objectToObjectDataBase(poHdr);

		poHdrDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deletePoHdr (int id){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoHdrDataBase poHdrDataBase = new PoHdrDataBase(dataBaseAccess);

		poHdrDataBase.setPOH_Id(id);

		poHdrDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
PoHdr objectDataBaseToObject (PoHdrDataBase poHdrDataBase){

	PoHdr poHdr = new PoHdr();

	poHdr.setId(poHdrDataBase.getPOH_Id());
	poHdr.setDb(poHdrDataBase.getPOH_Db());
	poHdr.setCompany(poHdrDataBase.getPOH_Company());
	poHdr.setPlant(poHdrDataBase.getPOH_Plant());
	poHdr.setPO(poHdrDataBase.getPOH_PO());
	poHdr.setPOStatus(poHdrDataBase.getPOH_POStatus());
	poHdr.setPODate(poHdrDataBase.getPOH_PODate());
	poHdr.setDtTmCreated(poHdrDataBase.getPOH_DtTmCreated());
	poHdr.setPOSource(poHdrDataBase.getPOH_POSource());
	poHdr.setPOType(poHdrDataBase.getPOH_POType());
	poHdr.setBPNumber(poHdrDataBase.getPOH_BPNumber());
	poHdr.setBPName(poHdrDataBase.getPOH_BPName());
	poHdr.setBPRemitTo(poHdrDataBase.getPOH_BPRemitTo());
	poHdr.setCustOrdShipAdr(poHdrDataBase.getPOH_CustOrdShipAdr());
	poHdr.setShiptoBPNum(poHdrDataBase.getPOH_ShiptoBPNum());
	poHdr.setShiptoBPName(poHdrDataBase.getPOH_ShiptoBPName());
	poHdr.setShiptoAddress1(poHdrDataBase.getPOH_ShiptoAddress1());
	poHdr.setShiptoAddress2(poHdrDataBase.getPOH_ShiptoAddress2());
	poHdr.setShiptoAddress3(poHdrDataBase.getPOH_ShiptoAddress3());
	poHdr.setShiptoPostZip(poHdrDataBase.getPOH_ShiptoPostZip());
	poHdr.setCity(poHdrDataBase.getPOH_City());
	poHdr.setStateProv(poHdrDataBase.getPOH_StateProv());
	poHdr.setRegion(poHdrDataBase.getPOH_Region());
	poHdr.setCountry(poHdrDataBase.getPOH_Country());
	poHdr.setContactName(poHdrDataBase.getPOH_ContactName());
	poHdr.setContact(poHdrDataBase.getPOH_Contact());
	poHdr.setContactPhone(poHdrDataBase.getPOH_ContactPhone());
	poHdr.setFreightTerms(poHdrDataBase.getPOH_FreightTerms());
	poHdr.setCarrier(poHdrDataBase.getPOH_Carrier());
	poHdr.setShipVia(poHdrDataBase.getPOH_ShipVia());
	poHdr.setFOB(poHdrDataBase.getPOH_FOB());
	poHdr.setPrinted(poHdrDataBase.getPOH_Printed());
	poHdr.setPOValue(poHdrDataBase.getPOH_POValue());
	poHdr.setFreight(poHdrDataBase.getPOH_Freight());
	poHdr.setDuty(poHdrDataBase.getPOH_Duty());
	poHdr.setBrokerage(poHdrDataBase.getPOH_Brokerage());
	poHdr.setCurrExchange(poHdrDataBase.getPOH_CurrExchange());
	poHdr.setCurrExchangeRate(poHdrDataBase.getPOH_CurrExchangeRate());
	poHdr.setCurrency(poHdrDataBase.getPOH_Currency());
	poHdr.setPOValueGoods(poHdrDataBase.getPOH_POValueGoods());
	poHdr.setCurrencyBase(poHdrDataBase.getPOH_CurrencyBase());
	poHdr.setPOValueBase(poHdrDataBase.getPOH_POValueBase());
	poHdr.setTax1(poHdrDataBase.getPOH_Tax1());
	poHdr.setTax2(poHdrDataBase.getPOH_Tax2());
	poHdr.setTax3(poHdrDataBase.getPOH_Tax3());
	poHdr.setTax1Amt(poHdrDataBase.getPOH_Tax1Amt());
	poHdr.setTax2Amt(poHdrDataBase.getPOH_Tax2Amt());
	poHdr.setTax3Amt(poHdrDataBase.getPOH_Tax3Amt());
	poHdr.setBuyer(poHdrDataBase.getPOH_Buyer());
	poHdr.setUserID(poHdrDataBase.getPOH_UserID());

	return poHdr;
}

private
PoHdrDataBase objectToObjectDataBase (PoHdr poHdr){

PoHdrDataBase poHdrDataBase = new PoHdrDataBase(dataBaseAccess);

	poHdrDataBase.setPOH_Id(poHdr.getId());
	poHdrDataBase.setPOH_Db(poHdr.getDb());
	poHdrDataBase.setPOH_Company(poHdr.getCompany());
	poHdrDataBase.setPOH_Plant(poHdr.getPlant());
	poHdrDataBase.setPOH_PO(poHdr.getPO());
	poHdrDataBase.setPOH_POStatus(poHdr.getPOStatus());
	poHdrDataBase.setPOH_PODate(poHdr.getPODate());
	poHdrDataBase.setPOH_DtTmCreated(poHdr.getDtTmCreated());
	poHdrDataBase.setPOH_POSource(poHdr.getPOSource());
	poHdrDataBase.setPOH_POType(poHdr.getPOType());
	poHdrDataBase.setPOH_BPNumber(poHdr.getBPNumber());
	poHdrDataBase.setPOH_BPName(poHdr.getBPName());
	poHdrDataBase.setPOH_BPRemitTo(poHdr.getBPRemitTo());
	poHdrDataBase.setPOH_CustOrdShipAdr(poHdr.getCustOrdShipAdr());
	poHdrDataBase.setPOH_ShiptoBPNum(poHdr.getShiptoBPNum());
	poHdrDataBase.setPOH_ShiptoBPName(poHdr.getShiptoBPName());
	poHdrDataBase.setPOH_ShiptoAddress1(poHdr.getShiptoAddress1());
	poHdrDataBase.setPOH_ShiptoAddress2(poHdr.getShiptoAddress2());
	poHdrDataBase.setPOH_ShiptoAddress3(poHdr.getShiptoAddress3());
	poHdrDataBase.setPOH_ShiptoPostZip(poHdr.getShiptoPostZip());
	poHdrDataBase.setPOH_City(poHdr.getCity());
	poHdrDataBase.setPOH_StateProv(poHdr.getStateProv());
	poHdrDataBase.setPOH_Region(poHdr.getRegion());
	poHdrDataBase.setPOH_Country(poHdr.getCountry());
	poHdrDataBase.setPOH_ContactName(poHdr.getContactName());
	poHdrDataBase.setPOH_Contact(poHdr.getContact());
	poHdrDataBase.setPOH_ContactPhone(poHdr.getContactPhone());
	poHdrDataBase.setPOH_FreightTerms(poHdr.getFreightTerms());
	poHdrDataBase.setPOH_Carrier(poHdr.getCarrier());
	poHdrDataBase.setPOH_ShipVia(poHdr.getShipVia());
	poHdrDataBase.setPOH_FOB(poHdr.getFOB());
	poHdrDataBase.setPOH_Printed(poHdr.getPrinted());
	poHdrDataBase.setPOH_POValue(poHdr.getPOValue());
	poHdrDataBase.setPOH_Freight(poHdr.getFreight());
	poHdrDataBase.setPOH_Duty(poHdr.getDuty());
	poHdrDataBase.setPOH_Brokerage(poHdr.getBrokerage());
	poHdrDataBase.setPOH_CurrExchange(poHdr.getCurrExchange());
	poHdrDataBase.setPOH_CurrExchangeRate(poHdr.getCurrExchangeRate());
	poHdrDataBase.setPOH_Currency(poHdr.getCurrency());
	poHdrDataBase.setPOH_POValueGoods(poHdr.getPOValueGoods());
	poHdrDataBase.setPOH_CurrencyBase(poHdr.getCurrencyBase());
	poHdrDataBase.setPOH_POValueBase(poHdr.getPOValueBase());
	poHdrDataBase.setPOH_Tax1(poHdr.getTax1());
	poHdrDataBase.setPOH_Tax2(poHdr.getTax2());
	poHdrDataBase.setPOH_Tax3(poHdr.getTax3());
	poHdrDataBase.setPOH_Tax1Amt(poHdr.getTax1Amt());
	poHdrDataBase.setPOH_Tax2Amt(poHdr.getTax2Amt());
	poHdrDataBase.setPOH_Tax3Amt(poHdr.getTax3Amt());
	poHdrDataBase.setPOH_Buyer(poHdr.getBuyer());
	poHdrDataBase.setPOH_UserID(poHdr.getUserID());

	return poHdrDataBase;
}

public
PoHdr createPoHdr(){
	return new PoHdr();
}

/****** This code goes in CoreFactory ******
#region PoHdr

bool existsPoHdr (int id);

PoHdr readPoHdr (int id);

void updatePoHdr(PoHdr poHdr);

void writePoHdr (PoHdr poHdr);

void deletePoHdr (int id);

#endregion

****** This code goes in RemoteCoreFactory ******
#region PoHdr

public
bool existsPoHdr (int id){
	return coreFactory.existsPoHdr (id);
}

public
PoHdr readPoHdr (int id){
	return coreFactory.readPoHdr (id);
}

public
void updatePoHdr(PoHdr poHdr){
	coreFactory.updatePoHdr(poHdr);
}

public
void writePoHdr (PoHdr poHdr){
	coreFactory.writePoHdr (poHdr);
}

public
void deletePoHdr (int id){
	coreFactory.deletePoHdr (id);
}

#endregion
*/


//------------------------------- POItem ---------------------------------------------------------

public
bool existsPoItem (int iD){

	try{
		PoItemDataBase poItemDataBase = new PoItemDataBase(dataBaseAccess);

		poItemDataBase.setPOI_ID(iD);

		return poItemDataBase.exists();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PoItem readPoItem (int iD){

	try{
		PoItemDataBase poItemDataBase = new PoItemDataBase(dataBaseAccess);

		poItemDataBase.setPOI_ID(iD);

		if (!poItemDataBase.exists())
			return null;

		poItemDataBase.read();

		PoItem poItem = this.objectDataBaseToObject(poItemDataBase);

		return poItem;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updatePoItem(PoItem poItem){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoItemDataBase poItemDataBase = this.objectToObjectDataBase(poItem);

		poItemDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writePoItem (PoItem poItem){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoItemDataBase poItemDataBase = this.objectToObjectDataBase(poItem);

		poItemDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deletePoItem (int iD){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoItemDataBase poItemDataBase = new PoItemDataBase(dataBaseAccess);

		poItemDataBase.setPOI_ID(iD);

		poItemDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
PoItem objectDataBaseToObject (PoItemDataBase poItemDataBase){

	PoItem poItem = new PoItem();

	poItem.setID(poItemDataBase.getPOI_ID());
	poItem.setDatabase(poItemDataBase.getPOI_Database());
	poItem.setCompany(poItemDataBase.getPOI_Company());
	poItem.setPlant(poItemDataBase.getPOI_Plant());
	poItem.setPo(poItemDataBase.getPOI_Po());
	poItem.setPoItem(poItemDataBase.getPOI_PoItem());
	poItem.setPOType(poItemDataBase.getPOI_POType());
	poItem.setPOSource(poItemDataBase.getPOI_POSource());
	poItem.setPart(poItemDataBase.getPOI_Part());
	poItem.setSequence(poItemDataBase.getPOI_Sequence());
	poItem.setWO(poItemDataBase.getPOI_WO());
	poItem.setRevision(poItemDataBase.getPOI_Revision());
	poItem.setBusPartner(poItemDataBase.getPOI_BusPartner());
	poItem.setBusPartnerPart(poItemDataBase.getPOI_BusPartnerPart());
	poItem.setManufacturer(poItemDataBase.getPOI_Manufacturer());
	poItem.setModel(poItemDataBase.getPOI_Model());
	poItem.setAttribute1(poItemDataBase.getPOI_Attribute1());
	poItem.setAttribute2(poItemDataBase.getPOI_Attribute2());
	poItem.setAttribute3(poItemDataBase.getPOI_Attribute3());
	poItem.setAttribute4(poItemDataBase.getPOI_Attribute4());
	poItem.setAttribute5(poItemDataBase.getPOI_Attribute5());
	poItem.setCondition(poItemDataBase.getPOI_Condition());
	poItem.setQtyOrdered(poItemDataBase.getPOI_QtyOrdered());
	poItem.setQtyReceived(poItemDataBase.getPOI_QtyReceived());
	poItem.setQtyReturned(poItemDataBase.getPOI_QtyReturned());
	poItem.setUom(poItemDataBase.getPOI_Uom());
	poItem.setPrice(poItemDataBase.getPOI_Price());
	poItem.setPriceUom(poItemDataBase.getPOI_PriceUom());
	poItem.setValueOrdered(poItemDataBase.getPOI_ValueOrdered());
	poItem.setValueReceived(poItemDataBase.getPOI_ValueReceived());
	poItem.setValueRemain(poItemDataBase.getPOI_ValueRemain());
	poItem.setPercentComp(poItemDataBase.getPOI_PercentComp());
	poItem.setItemSts(poItemDataBase.getPOI_ItemSts());
	poItem.setAutoCumApply(poItemDataBase.getPOI_AutoCumApply());
	poItem.setProject(poItemDataBase.getPOI_Project());
	poItem.setSourceOrig(poItemDataBase.getPOI_SourceOrig());
	poItem.setDropShip(poItemDataBase.getPOI_DropShip());
	poItem.setAllocated(poItemDataBase.getPOI_Allocated());
	poItem.setOrdersWaiting(poItemDataBase.getPOI_OrdersWaiting());
	poItem.setApproved(poItemDataBase.getPOI_Approved());
	poItem.setPOAccountDis(poItemDataBase.getPOI_POAccountDis());
	poItem.setDateReq(poItemDataBase.getPOI_DateReq());
	poItem.setDateConfirmed(poItemDataBase.getPOI_DateConfirmed());
	poItem.setReqCode(poItemDataBase.getPOI_ReqCode());
	poItem.setDefReceiveCo(poItemDataBase.getPOI_DefReceiveCo());
	poItem.setDefRecievePlt(poItemDataBase.getPOI_DefRecievePlt());
	poItem.setDefReceiveLoc(poItemDataBase.getPOI_DefReceiveLoc());
	poItem.setTax1(poItemDataBase.getPOI_Tax1());
	poItem.setTax2(poItemDataBase.getPOI_Tax2());
	poItem.setTax3(poItemDataBase.getPOI_Tax3());
	poItem.setTaxAmt1(poItemDataBase.getPOI_TaxAmt1());
	poItem.setTaxAmt2(poItemDataBase.getPOI_TaxAmt2());
	poItem.setTaxAmt3(poItemDataBase.getPOI_TaxAmt3());

	return poItem;
}

private
PoItemDataBase objectToObjectDataBase (PoItem poItem){

PoItemDataBase poItemDataBase = new PoItemDataBase(dataBaseAccess);

	poItemDataBase.setPOI_ID(poItem.getID());
	poItemDataBase.setPOI_Database(poItem.getDatabase());
	poItemDataBase.setPOI_Company(poItem.getCompany());
	poItemDataBase.setPOI_Plant(poItem.getPlant());
	poItemDataBase.setPOI_Po(poItem.getPo());
	poItemDataBase.setPOI_PoItem(poItem.getPoItem());
	poItemDataBase.setPOI_POType(poItem.getPOType());
	poItemDataBase.setPOI_POSource(poItem.getPOSource());
	poItemDataBase.setPOI_Part(poItem.getPart());
	poItemDataBase.setPOI_Sequence(poItem.getSequence());
	poItemDataBase.setPOI_WO(poItem.getWO());
	poItemDataBase.setPOI_Revision(poItem.getRevision());
	poItemDataBase.setPOI_BusPartner(poItem.getBusPartner());
	poItemDataBase.setPOI_BusPartnerPart(poItem.getBusPartnerPart());
	poItemDataBase.setPOI_Manufacturer(poItem.getManufacturer());
	poItemDataBase.setPOI_Model(poItem.getModel());
	poItemDataBase.setPOI_Attribute1(poItem.getAttribute1());
	poItemDataBase.setPOI_Attribute2(poItem.getAttribute2());
	poItemDataBase.setPOI_Attribute3(poItem.getAttribute3());
	poItemDataBase.setPOI_Attribute4(poItem.getAttribute4());
	poItemDataBase.setPOI_Attribute5(poItem.getAttribute5());
	poItemDataBase.setPOI_Condition(poItem.getCondition());
	poItemDataBase.setPOI_QtyOrdered(poItem.getQtyOrdered());
	poItemDataBase.setPOI_QtyReceived(poItem.getQtyReceived());
	poItemDataBase.setPOI_QtyReturned(poItem.getQtyReturned());
	poItemDataBase.setPOI_Uom(poItem.getUom());
	poItemDataBase.setPOI_Price(poItem.getPrice());
	poItemDataBase.setPOI_PriceUom(poItem.getPriceUom());
	poItemDataBase.setPOI_ValueOrdered(poItem.getValueOrdered());
	poItemDataBase.setPOI_ValueReceived(poItem.getValueReceived());
	poItemDataBase.setPOI_ValueRemain(poItem.getValueRemain());
	poItemDataBase.setPOI_PercentComp(poItem.getPercentComp());
	poItemDataBase.setPOI_ItemSts(poItem.getItemSts());
	poItemDataBase.setPOI_AutoCumApply(poItem.getAutoCumApply());
	poItemDataBase.setPOI_Project(poItem.getProject());
	poItemDataBase.setPOI_SourceOrig(poItem.getSourceOrig());
	poItemDataBase.setPOI_DropShip(poItem.getDropShip());
	poItemDataBase.setPOI_Allocated(poItem.getAllocated());
	poItemDataBase.setPOI_OrdersWaiting(poItem.getOrdersWaiting());
	poItemDataBase.setPOI_Approved(poItem.getApproved());
	poItemDataBase.setPOI_POAccountDis(poItem.getPOAccountDis());
	poItemDataBase.setPOI_DateReq(poItem.getDateReq());
	poItemDataBase.setPOI_DateConfirmed(poItem.getDateConfirmed());
	poItemDataBase.setPOI_ReqCode(poItem.getReqCode());
	poItemDataBase.setPOI_DefReceiveCo(poItem.getDefReceiveCo());
	poItemDataBase.setPOI_DefRecievePlt(poItem.getDefRecievePlt());
	poItemDataBase.setPOI_DefReceiveLoc(poItem.getDefReceiveLoc());
	poItemDataBase.setPOI_Tax1(poItem.getTax1());
	poItemDataBase.setPOI_Tax2(poItem.getTax2());
	poItemDataBase.setPOI_Tax3(poItem.getTax3());
	poItemDataBase.setPOI_TaxAmt1(poItem.getTaxAmt1());
	poItemDataBase.setPOI_TaxAmt2(poItem.getTaxAmt2());
	poItemDataBase.setPOI_TaxAmt3(poItem.getTaxAmt3());

	return poItemDataBase;
}

public
PoItem createPoItem(){
	return new PoItem();
}

/****** This code goes in CoreFactory ******
#region PoItem

bool existsPoItem (int iD);

PoItem readPoItem (int iD);

void updatePoItem(PoItem poItem);

void writePoItem (PoItem poItem);

void deletePoItem (int iD);

#endregion

****** This code goes in RemoteCoreFactory ******
#region PoItem

public
bool existsPoItem (int iD){
	return coreFactory.existsPoItem (iD);
}

public
PoItem readPoItem (int iD){
	return coreFactory.readPoItem (iD);
}

public
void updatePoItem(PoItem poItem){
	coreFactory.updatePoItem(poItem);
}

public
void writePoItem (PoItem poItem){
	coreFactory.writePoItem (poItem);
}

public
void deletePoItem (int iD){
	coreFactory.deletePoItem (iD);
}
*/

//---------------------------------------- PoItemRel
public
bool existsPoItemRel (int iD){

	try{
		PoItemRelDataBase poItemRelDataBase = new PoItemRelDataBase(dataBaseAccess);

		poItemRelDataBase.setPIR_ID(iD);

		return poItemRelDataBase.exists();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PoItemRel readPoItemRel (int iD){

	try{
		PoItemRelDataBase poItemRelDataBase = new PoItemRelDataBase(dataBaseAccess);

		poItemRelDataBase.setPIR_ID(iD);

		if (!poItemRelDataBase.exists())
			return null;

		poItemRelDataBase.read();

		PoItemRel poItemRel = this.objectDataBaseToObject(poItemRelDataBase);

		return poItemRel;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updatePoItemRel(PoItemRel poItemRel){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoItemRelDataBase poItemRelDataBase = this.objectToObjectDataBase(poItemRel);

		poItemRelDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writePoItemRel (PoItemRel poItemRel){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoItemRelDataBase poItemRelDataBase = this.objectToObjectDataBase(poItemRel);

		poItemRelDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deletePoItemRel (int iD){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PoItemRelDataBase poItemRelDataBase = new PoItemRelDataBase(dataBaseAccess);

		poItemRelDataBase.setPIR_ID(iD);

		poItemRelDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
PoItemRel objectDataBaseToObject (PoItemRelDataBase poItemRelDataBase){

	PoItemRel poItemRel = new PoItemRel();

	poItemRel.setID(poItemRelDataBase.getPIR_ID());
	poItemRel.setDatabase(poItemRelDataBase.getPIR_Database());
	poItemRel.setCompany(poItemRelDataBase.getPIR_Company());
	poItemRel.setPlant(poItemRelDataBase.getPIR_Plant());
	poItemRel.setPo(poItemRelDataBase.getPIR_Po());
	poItemRel.setPoItem(poItemRelDataBase.getPIR_PoItem());
	poItemRel.setPoITemRel(poItemRelDataBase.getPIR_PoITemRel());
	poItemRel.setWO(poItemRelDataBase.getPIR_WO());
	poItemRel.setCondition(poItemRelDataBase.getPIR_Condition());
	poItemRel.setRevision(poItemRelDataBase.getPIR_Revision());
	poItemRel.setAttribute1(poItemRelDataBase.getPIR_Attribute1());
	poItemRel.setAttribute2(poItemRelDataBase.getPIR_Attribute2());
	poItemRel.setAttribute3(poItemRelDataBase.getPIR_Attribute3());
	poItemRel.setAttribute4(poItemRelDataBase.getPIR_Attribute4());
	poItemRel.setAttribute5(poItemRelDataBase.getPIR_Attribute5());
	poItemRel.setQtyOrdered(poItemRelDataBase.getPIR_QtyOrdered());
	poItemRel.setQtyReceived(poItemRelDataBase.getPIR_QtyReceived());
	poItemRel.setQtyReturned(poItemRelDataBase.getPIR_QtyReturned());
	poItemRel.setUom(poItemRelDataBase.getPIR_Uom());
	poItemRel.setPrice(poItemRelDataBase.getPIR_Price());
	poItemRel.setPriceUom(poItemRelDataBase.getPIR_PriceUom());
	poItemRel.setValueOrdered(poItemRelDataBase.getPIR_ValueOrdered());
	poItemRel.setValueReceived(poItemRelDataBase.getPIR_ValueReceived());
	poItemRel.setPercentComp(poItemRelDataBase.getPIR_PercentComp());
	poItemRel.setItemSts(poItemRelDataBase.getPIR_ItemSts());
	poItemRel.setAutoCumApply(poItemRelDataBase.getPIR_AutoCumApply());
	poItemRel.setProject(poItemRelDataBase.getPIR_Project());
	poItemRel.setSourceOrig(poItemRelDataBase.getPIR_SourceOrig());
	poItemRel.setDropShip(poItemRelDataBase.getPIR_DropShip());
	poItemRel.setHardAllocated(poItemRelDataBase.getPIR_HardAllocated());
	poItemRel.setInvAllocated(poItemRelDataBase.getPIR_InvAllocated());
	poItemRel.setInvidiualPick(poItemRelDataBase.getPIR_InvidiualPick());
	poItemRel.setPickDtl(poItemRelDataBase.getPIR_PickDtl());
	poItemRel.setOrdersWaiting(poItemRelDataBase.getPIR_OrdersWaiting());
	poItemRel.setApproved(poItemRelDataBase.getPIR_Approved());
	poItemRel.setPOAccountDis(poItemRelDataBase.getPIR_POAccountDis());
	poItemRel.setDateReq(poItemRelDataBase.getPIR_DateReq());
	poItemRel.setDateConfirmed(poItemRelDataBase.getPIR_DateConfirmed());
	poItemRel.setStatus(poItemRelDataBase.getPIR_Status());
	poItemRel.setItemValue(poItemRelDataBase.getPIR_ItemValue());
	poItemRel.setItemValueLeft(poItemRelDataBase.getPIR_ItemValueLeft());
	poItemRel.setDefReceiveCo(poItemRelDataBase.getPIR_DefReceiveCo());
	poItemRel.setDefRecievePlt(poItemRelDataBase.getPIR_DefRecievePlt());
	poItemRel.setDefReceiveLoc(poItemRelDataBase.getPIR_DefReceiveLoc());
	poItemRel.setTax1(poItemRelDataBase.getPIR_Tax1());
	poItemRel.setTax2(poItemRelDataBase.getPIR_Tax2());
	poItemRel.setTax3(poItemRelDataBase.getPIR_Tax3());
	poItemRel.setTaxAmt1(poItemRelDataBase.getPIR_TaxAmt1());
	poItemRel.setTaxAmt2(poItemRelDataBase.getPIR_TaxAmt2());
	poItemRel.setTaxAmt3(poItemRelDataBase.getPIR_TaxAmt3());

	return poItemRel;
}

private
PoItemRelDataBase objectToObjectDataBase (PoItemRel poItemRel){

PoItemRelDataBase poItemRelDataBase = new PoItemRelDataBase(dataBaseAccess);

	poItemRelDataBase.setPIR_ID(poItemRel.getID());
	poItemRelDataBase.setPIR_Database(poItemRel.getDatabase());
	poItemRelDataBase.setPIR_Company(poItemRel.getCompany());
	poItemRelDataBase.setPIR_Plant(poItemRel.getPlant());
	poItemRelDataBase.setPIR_Po(poItemRel.getPo());
	poItemRelDataBase.setPIR_PoItem(poItemRel.getPoItem());
	poItemRelDataBase.setPIR_PoITemRel(poItemRel.getPoITemRel());
	poItemRelDataBase.setPIR_WO(poItemRel.getWO());
	poItemRelDataBase.setPIR_Condition(poItemRel.getCondition());
	poItemRelDataBase.setPIR_Revision(poItemRel.getRevision());
	poItemRelDataBase.setPIR_Attribute1(poItemRel.getAttribute1());
	poItemRelDataBase.setPIR_Attribute2(poItemRel.getAttribute2());
	poItemRelDataBase.setPIR_Attribute3(poItemRel.getAttribute3());
	poItemRelDataBase.setPIR_Attribute4(poItemRel.getAttribute4());
	poItemRelDataBase.setPIR_Attribute5(poItemRel.getAttribute5());
	poItemRelDataBase.setPIR_QtyOrdered(poItemRel.getQtyOrdered());
	poItemRelDataBase.setPIR_QtyReceived(poItemRel.getQtyReceived());
	poItemRelDataBase.setPIR_QtyReturned(poItemRel.getQtyReturned());
	poItemRelDataBase.setPIR_Uom(poItemRel.getUom());
	poItemRelDataBase.setPIR_Price(poItemRel.getPrice());
	poItemRelDataBase.setPIR_PriceUom(poItemRel.getPriceUom());
	poItemRelDataBase.setPIR_ValueOrdered(poItemRel.getValueOrdered());
	poItemRelDataBase.setPIR_ValueReceived(poItemRel.getValueReceived());
	poItemRelDataBase.setPIR_PercentComp(poItemRel.getPercentComp());
	poItemRelDataBase.setPIR_ItemSts(poItemRel.getItemSts());
	poItemRelDataBase.setPIR_AutoCumApply(poItemRel.getAutoCumApply());
	poItemRelDataBase.setPIR_Project(poItemRel.getProject());
	poItemRelDataBase.setPIR_SourceOrig(poItemRel.getSourceOrig());
	poItemRelDataBase.setPIR_DropShip(poItemRel.getDropShip());
	poItemRelDataBase.setPIR_HardAllocated(poItemRel.getHardAllocated());
	poItemRelDataBase.setPIR_InvAllocated(poItemRel.getInvAllocated());
	poItemRelDataBase.setPIR_InvidiualPick(poItemRel.getInvidiualPick());
	poItemRelDataBase.setPIR_PickDtl(poItemRel.getPickDtl());
	poItemRelDataBase.setPIR_OrdersWaiting(poItemRel.getOrdersWaiting());
	poItemRelDataBase.setPIR_Approved(poItemRel.getApproved());
	poItemRelDataBase.setPIR_POAccountDis(poItemRel.getPOAccountDis());
	poItemRelDataBase.setPIR_DateReq(poItemRel.getDateReq());
	poItemRelDataBase.setPIR_DateConfirmed(poItemRel.getDateConfirmed());
	poItemRelDataBase.setPIR_Status(poItemRel.getStatus());
	poItemRelDataBase.setPIR_ItemValue(poItemRel.getItemValue());
	poItemRelDataBase.setPIR_ItemValueLeft(poItemRel.getItemValueLeft());
	poItemRelDataBase.setPIR_DefReceiveCo(poItemRel.getDefReceiveCo());
	poItemRelDataBase.setPIR_DefRecievePlt(poItemRel.getDefRecievePlt());
	poItemRelDataBase.setPIR_DefReceiveLoc(poItemRel.getDefReceiveLoc());
	poItemRelDataBase.setPIR_Tax1(poItemRel.getTax1());
	poItemRelDataBase.setPIR_Tax2(poItemRel.getTax2());
	poItemRelDataBase.setPIR_Tax3(poItemRel.getTax3());
	poItemRelDataBase.setPIR_TaxAmt1(poItemRel.getTaxAmt1());
	poItemRelDataBase.setPIR_TaxAmt2(poItemRel.getTaxAmt2());
	poItemRelDataBase.setPIR_TaxAmt3(poItemRel.getTaxAmt3());

	return poItemRelDataBase;
}

public
PoItemRel createPoItemRel(){
	return new PoItemRel();
}

/****** This code goes in CoreFactory ******
#region PoItemRel

bool existsPoItemRel (int iD);

PoItemRel readPoItemRel (int iD);

void updatePoItemRel(PoItemRel poItemRel);

void writePoItemRel (PoItemRel poItemRel);

void deletePoItemRel (int iD);

#endregion

****** This code goes in RemoteCoreFactory ******
#region PoItemRel

public
bool existsPoItemRel (int iD){
	return coreFactory.existsPoItemRel (iD);
}

public
PoItemRel readPoItemRel (int iD){
	return coreFactory.readPoItemRel (iD);
}

public
void updatePoItemRel(PoItemRel poItemRel){
	coreFactory.updatePoItemRel(poItemRel);
}

public
void writePoItemRel (PoItemRel poItemRel){
	coreFactory.writePoItemRel (poItemRel);
}

public
void deletePoItemRel (int iD){
	coreFactory.deletePoItemRel (iD);
}

#endregion
*/


} // class
} // package