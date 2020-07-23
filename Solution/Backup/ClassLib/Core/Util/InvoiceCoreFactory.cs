/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:51 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/Util/InvoiceCoreFactory.cs,v $ 
*   $State: Exp $ 
*   $Log: InvoiceCoreFactory.cs,v $
*   Revision 1.6  2005-05-17 04:34:51  gmuller
*   ponga aqui un comentario
*
*   Revision 1.5  2005/04/29 05:05:27  gmuller
*   ponga aqui un comentario
*
*   Revision 1.4  2005/04/12 04:21:10  cmelo
*   *** empty log message ***
*
*   Revision 1.3  2005/04/07 23:25:22  cmelo
*   *** empty log message ***
*
*   Revision 1.2  2005/04/05 22:58:40  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/23 20:20:00  cmelo
*   *** empty log message ***
*
*   Revision 1.4  2005/03/21 18:46:46  cmelo
*   *** empty log message ***
*
*   Revision 1.3  2005/03/18 21:52:33  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{

public class InvoiceCoreFactory : InventoryCoreFactory{

protected InvoiceCoreFactory() : base(){
}



//------------------------------ Invoice -----------------------------------------------------------------
public
bool existsInvoice(string db,int company,string plant,int invoiceNum){
	
	try{
		OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
		oeInvoiceHdrDataBase.setIH_Db(db);
		oeInvoiceHdrDataBase.setIH_Company(company);
		oeInvoiceHdrDataBase.setIH_Plant(plant);
		oeInvoiceHdrDataBase.setIH_InvoiceNum(invoiceNum);

		return oeInvoiceHdrDataBase.exists();
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}


public
Invoice readInvoice(string db,int company,string plant,int invoiceNum){
   	try{
        Invoice invoice = new Invoice();
        
		OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
		oeInvoiceHdrDataBase.setIH_Db(db);
		oeInvoiceHdrDataBase.setIH_Company(company);
		oeInvoiceHdrDataBase.setIH_Plant(plant);
		oeInvoiceHdrDataBase.setIH_InvoiceNum(invoiceNum);
		
		if (!oeInvoiceHdrDataBase.exists())
			return null;

		oeInvoiceHdrDataBase.read();
		
		
		InvoiceHdr invoiceHdr = this.objectDataBaseToObject(oeInvoiceHdrDataBase);
		invoice.setInvoiceHdr(invoiceHdr);
		
		OeInvoiceDtlDataBaseContainer oeInvoiceDtlDataBaseContainer = new OeInvoiceDtlDataBaseContainer(dataBaseAccess);

        oeInvoiceDtlDataBaseContainer.readByHdr(db,company,plant,invoiceNum);
		
		if (oeInvoiceDtlDataBaseContainer.Count > 0){ //This invoice has Details associated
		    InvoiceDtl[] invoiceDtl = getInvoiceDtl(oeInvoiceDtlDataBaseContainer);
            invoice.setInvoiceDtl(invoiceDtl);    
        }
        
		return invoice;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateInvoice(Invoice invoice){
   try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        InvoiceHdr invoiceHdr = invoice.getInvoiceHdr();
        OEInvoiceHdrDataBase oeInvoiceHdrDataBase = this.objectToObjectDataBase(invoiceHdr);
			        
        oeInvoiceHdrDataBase.update();
        
        //First we deleted all the details for that invoice and then we inserted all the details.
        OeInvoiceDtlDataBaseContainer oeInvoiceDtlDataBaseContainer = new OeInvoiceDtlDataBaseContainer(dataBaseAccess);
        oeInvoiceDtlDataBaseContainer.deleteByHdr(invoiceHdr.getDb(),invoiceHdr.getCompany(),invoiceHdr.getPlant(),
                                                  invoiceHdr.getInvoiceNum());
        
        InvoiceDtl[] invoiceDtl = invoice.getInvoiceDtl();
        
        for (int i =0; i < invoiceDtl.Length; i++){
            OeInvoiceDtlDataBase oeInvoiceDtlDataBase = this.objectToObjectDataBase(invoiceDtl[i]);
            oeInvoiceDtlDataBase.write(); //Write all the details for that invoice
        }

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
void writeInvoice(Invoice invoice){
   try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        OEInvoiceHdrDataBase oeInvoiceHdrDataBase = this.objectToObjectDataBase(invoice.getInvoiceHdr());
			        
        oeInvoiceHdrDataBase.write();
          
        //Write the detail  
        InvoiceDtl[] invoiceDtl = invoice.getInvoiceDtl();
        for (int i =0; i < invoiceDtl.Length; i++){
            OeInvoiceDtlDataBase oeInvoiceDtlDataBase = this.objectToObjectDataBase(invoiceDtl[i]);
            oeInvoiceDtlDataBase.write(); //Write all the details for that invoice
        }


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
void deleteInvoice(string db, int company, string plant, int invoiceNum){
   try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        
        OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
        oeInvoiceHdrDataBase.setIH_Db(db);
        oeInvoiceHdrDataBase.setIH_Company(company);
        oeInvoiceHdrDataBase.setIH_Plant(plant);
        oeInvoiceHdrDataBase.setIH_InvoiceNum(invoiceNum);
			        
        oeInvoiceHdrDataBase.delete();
        
        OeInvoiceDtlDataBaseContainer oeInvoiceDtlDataBaseContainer = new OeInvoiceDtlDataBaseContainer(dataBaseAccess);
        oeInvoiceDtlDataBaseContainer.deleteByHdr(db, company, plant, invoiceNum);
      
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

protected InvoiceHdr objectDataBaseToObject (OEInvoiceHdrDataBase oeInvoiceHdrDataBase){
	InvoiceHdr invoiceHdr = new InvoiceHdr();

    invoiceHdr.setDb(oeInvoiceHdrDataBase.getIH_Db());
    invoiceHdr.setCompany(oeInvoiceHdrDataBase.getIH_Company());
    invoiceHdr.setPlant(oeInvoiceHdrDataBase.getIH_Plant());
    invoiceHdr.setInvoiceNum(oeInvoiceHdrDataBase.getIH_InvoiceNum());
    invoiceHdr.setOrderNum(oeInvoiceHdrDataBase.getIH_OrderNum());
    invoiceHdr.setPosted(oeInvoiceHdrDataBase.getIH_Posted());
    invoiceHdr.setInvDate(oeInvoiceHdrDataBase.getIH_InvDate());
    invoiceHdr.setShipDate(oeInvoiceHdrDataBase.getIH_ShipDate());
    invoiceHdr.setInvType(oeInvoiceHdrDataBase.getIH_InvType());
    invoiceHdr.setInvCredit(oeInvoiceHdrDataBase.getIH_InvCredit());
    invoiceHdr.setBillToCust(oeInvoiceHdrDataBase.getIH_BillToCust());
    invoiceHdr.setShiptoCust(oeInvoiceHdrDataBase.getIH_ShiptoCust());
    invoiceHdr.setBillToName(oeInvoiceHdrDataBase.getIH_BillToName());
    invoiceHdr.setShipToName(oeInvoiceHdrDataBase.getIH_ShipToName());
    invoiceHdr.setInvoiceTotal(oeInvoiceHdrDataBase.getIH_InvoiceTotal());
    invoiceHdr.setTax1Total(oeInvoiceHdrDataBase.getIH_Tax1Total());
    invoiceHdr.setTax2Total(oeInvoiceHdrDataBase.getIH_Tax2Total());
    invoiceHdr.setTax3Total(oeInvoiceHdrDataBase.getIH_Tax3Total());
    invoiceHdr.setDiscountTot(oeInvoiceHdrDataBase.getIH_DiscountTot());
    invoiceHdr.setTaxTotal(oeInvoiceHdrDataBase.getIH_TaxTotal());
    invoiceHdr.setCostTotal(oeInvoiceHdrDataBase.getIH_CostTotal());
    invoiceHdr.setTerms(oeInvoiceHdrDataBase.getIH_Terms());
    invoiceHdr.setPayType(oeInvoiceHdrDataBase.getIH_PayType());
    invoiceHdr.setPONum(oeInvoiceHdrDataBase.getIH_PONum());
    invoiceHdr.setQuoteNum(oeInvoiceHdrDataBase.getIH_QuoteNum());
    invoiceHdr.setCurrency(oeInvoiceHdrDataBase.getIH_Currency());
    invoiceHdr.setSalesPer(oeInvoiceHdrDataBase.getIH_SalesPer());
    invoiceHdr.setBolNumber(oeInvoiceHdrDataBase.getIH_BOLNumber());
    invoiceHdr.setPackSlipNum(oeInvoiceHdrDataBase.getIH_PackSlipNum());
    invoiceHdr.setStockLoc(oeInvoiceHdrDataBase.getIH_StockLoc());
    invoiceHdr.setWarehouse(oeInvoiceHdrDataBase.getIH_Warehouse());
    invoiceHdr.setShipToAdr1(oeInvoiceHdrDataBase.getIH_ShipToAdr1());
    invoiceHdr.setShipToAdr2(oeInvoiceHdrDataBase.getIH_ShipToAdr2());
    invoiceHdr.setShipToAdr3(oeInvoiceHdrDataBase.getIH_ShipToAdr3());
    invoiceHdr.setShipVia(oeInvoiceHdrDataBase.getIH_ShipVia());
    invoiceHdr.setFreightTerms(oeInvoiceHdrDataBase.getIH_FreightTerms());
    invoiceHdr.setFobPoint(oeInvoiceHdrDataBase.getIH_FOBPoint());
    invoiceHdr.setPrinted(oeInvoiceHdrDataBase.getIH_Printed());
    invoiceHdr.setEmailed(oeInvoiceHdrDataBase.getIH_Emailed());
    invoiceHdr.setFaxed(oeInvoiceHdrDataBase.getIH_Faxed());
    invoiceHdr.setEmailList(oeInvoiceHdrDataBase.getIH_EmailList());
    invoiceHdr.setArYear(oeInvoiceHdrDataBase.getIH_ARYear());
    invoiceHdr.setARPeriod(oeInvoiceHdrDataBase.getIH_ARPeriod());
    invoiceHdr.setPostedToERP(oeInvoiceHdrDataBase.getIH_PostedToERP());
    invoiceHdr.setBatchNumber(oeInvoiceHdrDataBase.getIH_BatchNumber());
    invoiceHdr.setChargesCalculated(oeInvoiceHdrDataBase.getIH_ChargesCalculated());
    invoiceHdr.setPoDate(oeInvoiceHdrDataBase.getIH_PODate());
    invoiceHdr.setOrderDate(oeInvoiceHdrDataBase.getIH_OrderDate());
    invoiceHdr.setRecordCheck(oeInvoiceHdrDataBase.getIH_RecordCheck());
    invoiceHdr.setDateCreated(oeInvoiceHdrDataBase.getIH_DateCreated());
    invoiceHdr.setDateUpdated(oeInvoiceHdrDataBase.getIH_DateUpdated());
    invoiceHdr.setUserID(oeInvoiceHdrDataBase.getIH_UserID());
    invoiceHdr.setBaseCurrency(oeInvoiceHdrDataBase.getIH_BaseCurrency());
    invoiceHdr.setExchangeRate(oeInvoiceHdrDataBase.getIH_ExchangeRate());
    invoiceHdr.setDepositAmt(oeInvoiceHdrDataBase.getIH_DepositAmt());
    invoiceHdr.setAmtOwed(oeInvoiceHdrDataBase.getIH_AmtOwed());
    invoiceHdr.setAuthorization(oeInvoiceHdrDataBase.getIH_Authorization());
    invoiceHdr.setCreditCardType(oeInvoiceHdrDataBase.getIH_CreditCardType());
    invoiceHdr.setCreditCardNumber(oeInvoiceHdrDataBase.getIH_CreditCardNumber());
    invoiceHdr.setExpiryDate(oeInvoiceHdrDataBase.getIH_ExpiryDate());
    invoiceHdr.setDealer(oeInvoiceHdrDataBase.getIH_Dealer());
    invoiceHdr.setDealerSalesRep(oeInvoiceHdrDataBase.getIH_DealerSalesRep());
    invoiceHdr.setPaid(oeInvoiceHdrDataBase.getIH_Paid());
    invoiceHdr.setBalance(oeInvoiceHdrDataBase.getIH_Balance());
    invoiceHdr.setPaymentsMethod(oeInvoiceHdrDataBase.getIH_PaymentsMethod());
    invoiceHdr.setReturned(oeInvoiceHdrDataBase.getIH_Returned());
    invoiceHdr.setRefunded(oeInvoiceHdrDataBase.getIH_Refunded());
    invoiceHdr.setBalanceReturn(oeInvoiceHdrDataBase.getIH_BalanceReturn());
        	
	return invoiceHdr;
}

protected OEInvoiceHdrDataBase objectToObjectDataBase (InvoiceHdr invoiceHdr){	
	OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);

    oeInvoiceHdrDataBase.setIH_Db(invoiceHdr.getDb());
    oeInvoiceHdrDataBase.setIH_Company(invoiceHdr.getCompany());
    oeInvoiceHdrDataBase.setIH_Plant(invoiceHdr.getPlant());
    oeInvoiceHdrDataBase.setIH_InvoiceNum(invoiceHdr.getInvoiceNum());
    oeInvoiceHdrDataBase.setIH_OrderNum(invoiceHdr.getOrderNum());
    oeInvoiceHdrDataBase.setIH_Posted(invoiceHdr.getPosted());
    oeInvoiceHdrDataBase.setIH_InvDate(invoiceHdr.getInvDate());
    oeInvoiceHdrDataBase.setIH_ShipDate(invoiceHdr.getShipDate());
    oeInvoiceHdrDataBase.setIH_InvType(invoiceHdr.getInvType());
    oeInvoiceHdrDataBase.setIH_InvCredit(invoiceHdr.getInvCredit());
    oeInvoiceHdrDataBase.setIH_BillToCust(invoiceHdr.getBillToCust());
    oeInvoiceHdrDataBase.setIH_ShiptoCust(invoiceHdr.getShiptoCust());
    oeInvoiceHdrDataBase.setIH_BillToName(invoiceHdr.getBillToName());
    oeInvoiceHdrDataBase.setIH_ShipToName(invoiceHdr.getShipToName());
    oeInvoiceHdrDataBase.setIH_InvoiceTotal(invoiceHdr.getInvoiceTotal());
    oeInvoiceHdrDataBase.setIH_Tax1Total(invoiceHdr.getTax1Total());
    oeInvoiceHdrDataBase.setIH_Tax2Total(invoiceHdr.getTax2Total());
    oeInvoiceHdrDataBase.setIH_Tax3Total(invoiceHdr.getTax3Total());
    oeInvoiceHdrDataBase.setIH_DiscountTot(invoiceHdr.getDiscountTot());
    oeInvoiceHdrDataBase.setIH_TaxTotal(invoiceHdr.getTaxTotal());
    oeInvoiceHdrDataBase.setIH_CostTotal(invoiceHdr.getCostTotal());
    oeInvoiceHdrDataBase.setIH_Terms(invoiceHdr.getTerms());
    oeInvoiceHdrDataBase.setIH_PayType(invoiceHdr.getPayType());
    oeInvoiceHdrDataBase.setIH_PONum(invoiceHdr.getPoNum());
    oeInvoiceHdrDataBase.setIH_QuoteNum(invoiceHdr.getQuoteNum());
    oeInvoiceHdrDataBase.setIH_Currency(invoiceHdr.getCurrency());
    oeInvoiceHdrDataBase.setIH_SalesPer(invoiceHdr.getSalesPer());
    oeInvoiceHdrDataBase.setIH_BOLNumber(invoiceHdr.getBolNumber());
    oeInvoiceHdrDataBase.setIH_PackSlipNum(invoiceHdr.getPackSlipNum());
    oeInvoiceHdrDataBase.setIH_StockLoc(invoiceHdr.getStockLoc());
    oeInvoiceHdrDataBase.setIH_Warehouse(invoiceHdr.getWarehouse());
    oeInvoiceHdrDataBase.setIH_ShipToAdr1(invoiceHdr.getShipToAdr1());
    oeInvoiceHdrDataBase.setIH_ShipToAdr2(invoiceHdr.getShipToAdr2());
    oeInvoiceHdrDataBase.setIH_ShipToAdr3(invoiceHdr.getShipToAdr3());
    oeInvoiceHdrDataBase.setIH_ShipVia(invoiceHdr.getShipVia());
    oeInvoiceHdrDataBase.setIH_FreightTerms(invoiceHdr.getFreightTerms());
    oeInvoiceHdrDataBase.setIH_FOBPoint(invoiceHdr.getFobPoint());
    oeInvoiceHdrDataBase.setIH_Printed(invoiceHdr.getPrinted());
    oeInvoiceHdrDataBase.setIH_Emailed(invoiceHdr.getEmailed());
    oeInvoiceHdrDataBase.setIH_Faxed(invoiceHdr.getFaxed());
    oeInvoiceHdrDataBase.setIH_EmailList(invoiceHdr.getEmailList());
    oeInvoiceHdrDataBase.setIH_ARYear(invoiceHdr.getArYear());
    oeInvoiceHdrDataBase.setIH_ARPeriod(invoiceHdr.getArPeriod());
    oeInvoiceHdrDataBase.setIH_PostedToERP(invoiceHdr.getPostedToERP());
    oeInvoiceHdrDataBase.setIH_BatchNumber(invoiceHdr.getBatchNumber());
    oeInvoiceHdrDataBase.setIH_ChargesCalculated(invoiceHdr.getChargesCalculated());
    oeInvoiceHdrDataBase.setIH_PODate(invoiceHdr.getPoDate());
    oeInvoiceHdrDataBase.setIH_OrderDate(invoiceHdr.getOrderDate());
    oeInvoiceHdrDataBase.setIH_RecordCheck(invoiceHdr.getRecordCheck());
    oeInvoiceHdrDataBase.setIH_DateCreated(invoiceHdr.getDateCreated());
    oeInvoiceHdrDataBase.setIH_DateUpdated(invoiceHdr.getDateUpdated());
    oeInvoiceHdrDataBase.setIH_UserID(invoiceHdr.getUserID());
    oeInvoiceHdrDataBase.setIH_BaseCurrency(invoiceHdr.getBaseCurrency());
    oeInvoiceHdrDataBase.setIH_ExchangeRate(invoiceHdr.getExchangeRate());
    oeInvoiceHdrDataBase.setIH_DepositAmt(invoiceHdr.getDepositAmt());
    oeInvoiceHdrDataBase.setIH_AmtOwed(invoiceHdr.getAmtOwed());
    oeInvoiceHdrDataBase.setIH_Authorization(invoiceHdr.getAuthorization());
    oeInvoiceHdrDataBase.setIH_CreditCardType(invoiceHdr.getCreditCardType());
    oeInvoiceHdrDataBase.setIH_CreditCardNumber(invoiceHdr.getCreditCardNumber());
    oeInvoiceHdrDataBase.setIH_ExpiryDate(invoiceHdr.getExpiryDate());
    oeInvoiceHdrDataBase.setIH_Dealer(invoiceHdr.getDealer());
    oeInvoiceHdrDataBase.setIH_DealerSalesRep(invoiceHdr.getDealerSalesRep());
    oeInvoiceHdrDataBase.setIH_Paid(invoiceHdr.getPaid());
    oeInvoiceHdrDataBase.setIH_Balance(invoiceHdr.getBalance());
    oeInvoiceHdrDataBase.setIH_PaymentsMethod(invoiceHdr.getPaymentsMethod());
    oeInvoiceHdrDataBase.setIH_Returned(invoiceHdr.getReturned());
    oeInvoiceHdrDataBase.setIH_Refunded(invoiceHdr.getRefunded());
    oeInvoiceHdrDataBase.setIH_BalanceReturn(invoiceHdr.getBalanceReturn());
    	

	return oeInvoiceHdrDataBase;
}
	

public
Invoice createInvoice(){
	return new Invoice();
}

public string[][] getInvoiceByNum(){

    try{
            OEInvoiceHdrDataBaseContainer oeInvoiceHdrDataBaseContainer= new OEInvoiceHdrDataBaseContainer(dataBaseAccess);
            oeInvoiceHdrDataBaseContainer.read();
            string[][] vec = new String[oeInvoiceHdrDataBaseContainer.Count][];
             
            IEnumerator iEnum = oeInvoiceHdrDataBaseContainer.GetEnumerator();
	        int index = 0;
	        while(iEnum.MoveNext()){
		        OEInvoiceHdrDataBase oeInvoiceHdrDataBase = (OEInvoiceHdrDataBase)iEnum.Current;
        		
		        string[] v = new String[5];
		        v[0] = oeInvoiceHdrDataBase.getIH_InvoiceNum().ToString();
		        v[1] = oeInvoiceHdrDataBase.getIH_Db();
		        v[2] = oeInvoiceHdrDataBase.getIH_Company().ToString();
		        v[3] = oeInvoiceHdrDataBase.getIH_Plant();
		        v[4] = oeInvoiceHdrDataBase.getIH_InvType();
		        vec[index] = v;
		        index++;
	        }
	        return vec;
	  
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message,persistenceException);
    }catch(System.Exception exception){
        throw new NujitException(exception.Message,exception);
    }	    
}

// detail 
private
InvoiceDtl objectDataBaseToObject (OeInvoiceDtlDataBase oeInvoiceDtlDataBase){

	InvoiceDtl invoiceDtl = new InvoiceDtl();

	invoiceDtl.setDb(oeInvoiceDtlDataBase.getID_Db());
	invoiceDtl.setCompany(oeInvoiceDtlDataBase.getID_Company());
	invoiceDtl.setPlant(oeInvoiceDtlDataBase.getID_Plant());
	invoiceDtl.setInvoiceNum(oeInvoiceDtlDataBase.getID_InvoiceNum());
	invoiceDtl.setInvLineNum(oeInvoiceDtlDataBase.getID_InvLineNum());
	invoiceDtl.setOrderNum(oeInvoiceDtlDataBase.getID_OrderNum());
	invoiceDtl.setOrderItemNum(oeInvoiceDtlDataBase.getID_OrderItemNum());
	invoiceDtl.setReleaseNum(oeInvoiceDtlDataBase.getID_ReleaseNum());
	invoiceDtl.setPart(oeInvoiceDtlDataBase.getID_Part());
	invoiceDtl.setSequence(oeInvoiceDtlDataBase.getID_Sequence());
	invoiceDtl.setRevision(oeInvoiceDtlDataBase.getID_Revision());
	invoiceDtl.setCustPart(oeInvoiceDtlDataBase.getID_CustPart());
	invoiceDtl.setCustPartRevision(oeInvoiceDtlDataBase.getID_CustPartRevision());
	invoiceDtl.setQtyShipped(oeInvoiceDtlDataBase.getID_QtyShipped());
	invoiceDtl.setQSUom(oeInvoiceDtlDataBase.getID_QSUom());
	invoiceDtl.setQtyShipInv(oeInvoiceDtlDataBase.getID_QtyShipInv());
	invoiceDtl.setQSIUom(oeInvoiceDtlDataBase.getID_QSIUom());
	invoiceDtl.setQtyBackOrder(oeInvoiceDtlDataBase.getID_QtyBackOrder());
	invoiceDtl.setQtyOutstand(oeInvoiceDtlDataBase.getID_QtyOutstand());
	invoiceDtl.setUnitPrice(oeInvoiceDtlDataBase.getID_UnitPrice());
	invoiceDtl.setUPUom(oeInvoiceDtlDataBase.getID_UPUom());
	invoiceDtl.setLineExt(oeInvoiceDtlDataBase.getID_LineExt());
	invoiceDtl.setDesciption(oeInvoiceDtlDataBase.getID_Desciption());
	invoiceDtl.setSC1(oeInvoiceDtlDataBase.getID_SC1());
	invoiceDtl.setSC2(oeInvoiceDtlDataBase.getID_SC2());
	invoiceDtl.setSC3(oeInvoiceDtlDataBase.getID_SC3());
	invoiceDtl.setSC4(oeInvoiceDtlDataBase.getID_SC4());
	invoiceDtl.setSC5(oeInvoiceDtlDataBase.getID_SC5());
	invoiceDtl.setSC6(oeInvoiceDtlDataBase.getID_SC6());
	invoiceDtl.setGLSalesAcc(oeInvoiceDtlDataBase.getID_GLSalesAcc());
	invoiceDtl.setGLCosAcc(oeInvoiceDtlDataBase.getID_GLCosAcc());
	invoiceDtl.setGLCosType(oeInvoiceDtlDataBase.getID_GLCosType());
	invoiceDtl.setShipCompany(oeInvoiceDtlDataBase.getID_ShipCompany());
	invoiceDtl.setShipPlant(oeInvoiceDtlDataBase.getID_ShipPlant());
	invoiceDtl.setShipStkLoc(oeInvoiceDtlDataBase.getID_ShipStkLoc());
	invoiceDtl.setTax1Amt(oeInvoiceDtlDataBase.getID_Tax1Amt());
	invoiceDtl.setTax2Amt(oeInvoiceDtlDataBase.getID_Tax2Amt());
	invoiceDtl.setTax3Amt(oeInvoiceDtlDataBase.getID_Tax3Amt());
	invoiceDtl.setLineExtwTax(oeInvoiceDtlDataBase.getID_LineExtwTax());
	invoiceDtl.setTaxAmtTot(oeInvoiceDtlDataBase.getID_TaxAmtTot());
	invoiceDtl.setFreightAmt(oeInvoiceDtlDataBase.getID_FreightAmt());
	invoiceDtl.setDiscountAmt(oeInvoiceDtlDataBase.getID_DiscountAmt());
	invoiceDtl.setCostExt(oeInvoiceDtlDataBase.getID_CostExt());
	invoiceDtl.setUnitCost(oeInvoiceDtlDataBase.getID_UnitCost());
	invoiceDtl.setLabCost(oeInvoiceDtlDataBase.getID_LabCost());
	invoiceDtl.setMatCost(oeInvoiceDtlDataBase.getID_MatCost());
	invoiceDtl.setOHCost(oeInvoiceDtlDataBase.getID_OHCost());
	invoiceDtl.setOutsideCost(oeInvoiceDtlDataBase.getID_OutsideCost());
	invoiceDtl.setRoyCharges(oeInvoiceDtlDataBase.getID_RoyCharges());
	invoiceDtl.setPriceBefDis(oeInvoiceDtlDataBase.getID_PriceBefDis());
	invoiceDtl.setSalesPerson(oeInvoiceDtlDataBase.getID_SalesPerson());
	invoiceDtl.setCommPlan(oeInvoiceDtlDataBase.getID_CommPlan());
	invoiceDtl.setCommPerCent(oeInvoiceDtlDataBase.getID_CommPerCent());
	invoiceDtl.setCommRate(oeInvoiceDtlDataBase.getID_CommRate());
	invoiceDtl.setComponentList(oeInvoiceDtlDataBase.getID_ComponentList());
	invoiceDtl.setWarrantyClaimDetail(oeInvoiceDtlDataBase.getID_WarrantyClaimDetail());
	invoiceDtl.setQtyReturned(oeInvoiceDtlDataBase.getID_QtyReturned());
	invoiceDtl.setManufacturer(oeInvoiceDtlDataBase.getID_Manufacturer());
	invoiceDtl.setManuPart(oeInvoiceDtlDataBase.getID_ManuPart());
	invoiceDtl.setDateShipped(oeInvoiceDtlDataBase.getID_DateShipped());
	invoiceDtl.setPackingSlip(oeInvoiceDtlDataBase.getID_PackingSlip());
	invoiceDtl.setPackingSlipLin(oeInvoiceDtlDataBase.getID_PackingSlipLin());
	invoiceDtl.setCustRan(oeInvoiceDtlDataBase.getID_CustRan());
	invoiceDtl.setCondition(oeInvoiceDtlDataBase.getID_Condition());
	invoiceDtl.setProject(oeInvoiceDtlDataBase.getID_Project());

	return invoiceDtl;
}

private
OeInvoiceDtlDataBase objectToObjectDataBase (InvoiceDtl invoiceDtl){

OeInvoiceDtlDataBase oeInvoiceDtlDataBase = new OeInvoiceDtlDataBase(dataBaseAccess);

	oeInvoiceDtlDataBase.setID_Db(invoiceDtl.getDb());
	oeInvoiceDtlDataBase.setID_Company(invoiceDtl.getCompany());
	oeInvoiceDtlDataBase.setID_Plant(invoiceDtl.getPlant());
	oeInvoiceDtlDataBase.setID_InvoiceNum(invoiceDtl.getInvoiceNum());
	oeInvoiceDtlDataBase.setID_InvLineNum(invoiceDtl.getInvLineNum());
	oeInvoiceDtlDataBase.setID_OrderNum(invoiceDtl.getOrderNum());
	oeInvoiceDtlDataBase.setID_OrderItemNum(invoiceDtl.getOrderItemNum());
	oeInvoiceDtlDataBase.setID_ReleaseNum(invoiceDtl.getReleaseNum());
	oeInvoiceDtlDataBase.setID_Part(invoiceDtl.getPart());
	oeInvoiceDtlDataBase.setID_Sequence(invoiceDtl.getSequence());
	oeInvoiceDtlDataBase.setID_Revision(invoiceDtl.getRevision());
	oeInvoiceDtlDataBase.setID_CustPart(invoiceDtl.getCustPart());
	oeInvoiceDtlDataBase.setID_CustPartRevision(invoiceDtl.getCustPartRevision());
	oeInvoiceDtlDataBase.setID_QtyShipped(invoiceDtl.getQtyShipped());
	oeInvoiceDtlDataBase.setID_QSUom(invoiceDtl.getQSUom());
	oeInvoiceDtlDataBase.setID_QtyShipInv(invoiceDtl.getQtyShipInv());
	oeInvoiceDtlDataBase.setID_QSIUom(invoiceDtl.getQSIUom());
	oeInvoiceDtlDataBase.setID_QtyBackOrder(invoiceDtl.getQtyBackOrder());
	oeInvoiceDtlDataBase.setID_QtyOutstand(invoiceDtl.getQtyOutstand());
	oeInvoiceDtlDataBase.setID_UnitPrice(invoiceDtl.getUnitPrice());
	oeInvoiceDtlDataBase.setID_UPUom(invoiceDtl.getUPUom());
	oeInvoiceDtlDataBase.setID_LineExt(invoiceDtl.getLineExt());
	oeInvoiceDtlDataBase.setID_Desciption(invoiceDtl.getDesciption());
	oeInvoiceDtlDataBase.setID_SC1(invoiceDtl.getSC1());
	oeInvoiceDtlDataBase.setID_SC2(invoiceDtl.getSC2());
	oeInvoiceDtlDataBase.setID_SC3(invoiceDtl.getSC3());
	oeInvoiceDtlDataBase.setID_SC4(invoiceDtl.getSC4());
	oeInvoiceDtlDataBase.setID_SC5(invoiceDtl.getSC5());
	oeInvoiceDtlDataBase.setID_SC6(invoiceDtl.getSC6());
	oeInvoiceDtlDataBase.setID_GLSalesAcc(invoiceDtl.getGLSalesAcc());
	oeInvoiceDtlDataBase.setID_GLCosAcc(invoiceDtl.getGLCosAcc());
	oeInvoiceDtlDataBase.setID_GLCosType(invoiceDtl.getGLCosType());
	oeInvoiceDtlDataBase.setID_ShipCompany(invoiceDtl.getShipCompany());
	oeInvoiceDtlDataBase.setID_ShipPlant(invoiceDtl.getShipPlant());
	oeInvoiceDtlDataBase.setID_ShipStkLoc(invoiceDtl.getShipStkLoc());
	oeInvoiceDtlDataBase.setID_Tax1Amt(invoiceDtl.getTax1Amt());
	oeInvoiceDtlDataBase.setID_Tax2Amt(invoiceDtl.getTax2Amt());
	oeInvoiceDtlDataBase.setID_Tax3Amt(invoiceDtl.getTax3Amt());
	oeInvoiceDtlDataBase.setID_LineExtwTax(invoiceDtl.getLineExtwTax());
	oeInvoiceDtlDataBase.setID_TaxAmtTot(invoiceDtl.getTaxAmtTot());
	oeInvoiceDtlDataBase.setID_FreightAmt(invoiceDtl.getFreightAmt());
	oeInvoiceDtlDataBase.setID_DiscountAmt(invoiceDtl.getDiscountAmt());
	oeInvoiceDtlDataBase.setID_CostExt(invoiceDtl.getCostExt());
	oeInvoiceDtlDataBase.setID_UnitCost(invoiceDtl.getUnitCost());
	oeInvoiceDtlDataBase.setID_LabCost(invoiceDtl.getLabCost());
	oeInvoiceDtlDataBase.setID_MatCost(invoiceDtl.getMatCost());
	oeInvoiceDtlDataBase.setID_OHCost(invoiceDtl.getOHCost());
	oeInvoiceDtlDataBase.setID_OutsideCost(invoiceDtl.getOutsideCost());
	oeInvoiceDtlDataBase.setID_RoyCharges(invoiceDtl.getRoyCharges());
	oeInvoiceDtlDataBase.setID_PriceBefDis(invoiceDtl.getPriceBefDis());
	oeInvoiceDtlDataBase.setID_SalesPerson(invoiceDtl.getSalesPerson());
	oeInvoiceDtlDataBase.setID_CommPlan(invoiceDtl.getCommPlan());
	oeInvoiceDtlDataBase.setID_CommPerCent(invoiceDtl.getCommPerCent());
	oeInvoiceDtlDataBase.setID_CommRate(invoiceDtl.getCommRate());
	oeInvoiceDtlDataBase.setID_ComponentList(invoiceDtl.getComponentList());
	oeInvoiceDtlDataBase.setID_WarrantyClaimDetail(invoiceDtl.getWarrantyClaimDetail());
	oeInvoiceDtlDataBase.setID_QtyReturned(invoiceDtl.getQtyReturned());
	oeInvoiceDtlDataBase.setID_Manufacturer(invoiceDtl.getManufacturer());
	oeInvoiceDtlDataBase.setID_ManuPart(invoiceDtl.getManuPart());
	oeInvoiceDtlDataBase.setID_DateShipped(invoiceDtl.getDateShipped());
	oeInvoiceDtlDataBase.setID_PackingSlip(invoiceDtl.getPackingSlip());
	oeInvoiceDtlDataBase.setID_PackingSlipLin(invoiceDtl.getPackingSlipLin());
	oeInvoiceDtlDataBase.setID_CustRan(invoiceDtl.getCustRan());
	oeInvoiceDtlDataBase.setID_Condition(invoiceDtl.getCondition());
	oeInvoiceDtlDataBase.setID_Project(invoiceDtl.getProject());

	return oeInvoiceDtlDataBase;
}

private InvoiceDtl[] getInvoiceDtl(OeInvoiceDtlDataBaseContainer oeInvoiceDtlDataBaseContainer){
   
      InvoiceDtl[] dtl = new InvoiceDtl[oeInvoiceDtlDataBaseContainer.Count];

	    int i = 0;
	    for(IEnumerator en = oeInvoiceDtlDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    OeInvoiceDtlDataBase oeInvoiceDtlDataBase = (OeInvoiceDtlDataBase) en.Current;
    			
		    InvoiceDtl item;
            item = objectDataBaseToObject(oeInvoiceDtlDataBase);
		       			
		    dtl[i] = item;
		    i++;
	    }
	    return dtl;

}


} // class
} // package