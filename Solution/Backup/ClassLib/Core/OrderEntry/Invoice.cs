using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]	
public class Invoice : MarshalByRefObject{


private InvoiceHdr invoiceHdr; //the header
private InvoiceDtl[] invoiceDtl; //all the details 

internal Invoice(){
      
}

//Setters

public
void setInvoiceHdr(InvoiceHdr invoiceHdr){
    this.invoiceHdr = invoiceHdr;
}

public
void setInvoiceDtl(InvoiceDtl[] invoiceDtl){
    this.invoiceDtl = invoiceDtl;
}


//Getters
public
InvoiceHdr getInvoiceHdr(){
    return invoiceHdr;
}

public
InvoiceDtl[] getInvoiceDtl(){
    return invoiceDtl;
}


}//end class
}//end namespace
