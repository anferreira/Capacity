using System;
#if OE_SYNC
using Comunications;
using Messages;
#endif
using System.Xml;
using System.IO;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;
using System.Drawing;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Print
{

public class PrintServerOrder :PrintServer
{					

public PrintServerOrder(): base()
{
	
}
//#if POCKET_PC				//receive this following 4 parameters to not use cash, cash is defined in WindForms/OrderEntry
public bool processReport(	Person			billPerson,	
							Person			shipPerson,	
							Employee		employee,	
							Order			order,		
							int				inumberOfCopies)
{
	bool			bresult=true;
	string			sline="";
	string			sepLine="\r\n";	
	string			s1,s2,snotes;
	int				i=0,j=0;
	double			dprice=0;
	double			dtotalDiscounts=0;
	OrderDtl		orderDtl=null;
	OrderDtlCharge	orderDtlCharge=null;
	int				iMaxLine=80;

//	Person			billPerson	=cash.getBillPerson();
//	Person			shipPerson	=cash.getShipPerson();
//	Employee		employee	=cash.getEmployee();
//	Order			order		=cash.getOrder();		
	Note			note = null;

	this.iorderPrintCopies = inumberOfCopies;

	stitle= StringUtil.center("Sales Orders",iMaxLine);
	stitle+= sepLine + sepLine;	

	//Order Date: 01/07/2005						Order #: A52-002
	s1 = "Order Date: "	+ DateUtil.getDateRepresentation(order.getOrderDate(),DateUtil.MMDDYYYY);
	s2 = "Order #: "	+ order.getId();

	sline= StringUtil.alingToRight(s1,s2,iMaxLine);
	sline+= sepLine;
	sbody+= sline;

	//Ship  Date: 02/02/2005			
	sline = "Ship  Date: " + DateUtil.getDateRepresentation(order.getDateShip(),DateUtil.MMDDYYYY);
	sline+= sepLine;
	sbody+= sline;	
	
	s2 = StringUtil.AddSpaces(Constants.COMPANY_NAME,18,true);
	sline= StringUtil.alingToRight(s1,s2,iMaxLine);
	sline+= sepLine;
	sbody+= sline;

	s2= StringUtil.AddSpaces(Constants.COMPANY_ADDRESS1,18,true);
	sline = StringUtil.alingToRight("",s2,iMaxLine);
	sline+= sepLine;
	sbody+= sline;

	s2= StringUtil.AddSpaces(Constants.COMPANY_ADDRESS2,18,true);
	sline = StringUtil.alingToRight("",s2,iMaxLine);
	sline+= sepLine;
	sbody+= sline;

	s2= StringUtil.AddSpaces(Constants.COMPANY_ADDRESS3,18,true);
	sline = StringUtil.alingToRight("",s2,iMaxLine);
	sline+= sepLine;
	sbody+= sline;

	s2= StringUtil.AddSpaces(Constants.COMPANY_PHONE1,18,true);
	sline = StringUtil.alingToRight("",s2,iMaxLine);
	sline+= sepLine;
	sbody+= sline;

	s2= StringUtil.AddSpaces(Constants.COMPANY_PHONE2 + " ",18,true);
	sline = StringUtil.alingToRight("",s2,iMaxLine);
	sline+= sepLine;
	sbody+= sline;

	s2= StringUtil.AddSpaces(Constants.COMPANY_FAX,18,true);
	sline = StringUtil.alingToRight("",s2,iMaxLine);
	sline+= sepLine+sepLine;
	sbody+= sline;	

	/*
	s2= StringUtil.AddSpaces(Constants.COMPANY_EMAIL,18,true);
	sline = StringUtil.alingToRight("",s2,iMaxLine);
	sline+= sepLine+sepLine;
	sbody+= sline;
	*/

//	Bill-To:					Ship-To:
//	  Name					         Name							
//          Address line 1				 Address line 1
//          Address Line 2				 Address Line 2
//          Address Line 3				 Address Line 3

	s1="Bill-To:";
	s2= StringUtil.AddSpaces("Ship-To:",iMaxLine/2,false);
	sline = s1 + s2;
	sline+= sepLine;
	sbody+= sline;

	//name
	s1 = StringUtil.AddSpaces("       " + billPerson.getName(),iMaxLine/2,true);
	s2 = StringUtil.AddSpaces("       " + shipPerson.getName(),iMaxLine/2,true);
	sline = s1 + s2;
	sline+= sepLine;
	sbody+= sline;

	//address
	if (billPerson.getAddress1().Length > 0 || shipPerson.getAddress1().Length > 0)
	{
		s1 = StringUtil.AddSpaces("       " + billPerson.getAddress1(),iMaxLine/2,true);
		s2 = StringUtil.AddSpaces("       " + shipPerson.getAddress1(),iMaxLine/2,true);
		sline = s1 + s2;
		sline+= sepLine;
		sbody+= sline;
	}		
		
	if (billPerson.getAddress2().Length > 0 || shipPerson.getAddress2().Length > 0)
	{
		s1 = StringUtil.AddSpaces("       " + billPerson.getAddress2(),iMaxLine/2,true);
		s2 = StringUtil.AddSpaces("       " + shipPerson.getAddress2(),iMaxLine/2,true);
		sline = s1 + s2;
		sline+= sepLine;
		sbody+= sline;
	}		

	if (billPerson.getAddress3().Length > 0 || shipPerson.getAddress3().Length > 0)
	{
		s1 = StringUtil.AddSpaces("       " + billPerson.getAddress3(),iMaxLine/2,true);
		s2 = StringUtil.AddSpaces("       " + shipPerson.getAddress3(),iMaxLine/2,true);
		sline = s1 + s2;
		sline+= sepLine;
		sbody+= sline;
	}	
	
	if (billPerson.getPhone().Length > 0 || billPerson.getFax().Length > 0 || 
		shipPerson.getPhone().Length > 0 ||	shipPerson.getFax().Length > 0)
	{

		s1 = StringUtil.AddSpaces("       " + billPerson.getPhone(),iMaxLine/4,true);
		s2 = StringUtil.AddSpaces("(" + billPerson.getFax() + ")",iMaxLine/4,true); 
		sline=s1 + s2;

		s1 = StringUtil.AddSpaces("       " + shipPerson.getPhone(),iMaxLine/4,true);
		s2 = StringUtil.AddSpaces("(" + shipPerson.getFax() + ")",iMaxLine/4,true); 
		sline+=s1 + s2;		

		sline+= sepLine;
		sbody+= sline;
	}		
	
	sbody+= sepLine;

	//P.O: 12345687 		  
	sline="P.O      : " + order.getPO();
	sline+= sepLine;
	sbody+= sline;

	if (order.getAttention().Length > 0)
	{
		//Attention
		sline="Attention: " + order.getAttention();
		sline+= sepLine;
		sbody+= sline;
	}


//	------------------------------------------------------------------------------------
//
//	Product ID		Qty		Price			Extension
//
//	------------------------------------------------------------------------------------
//	AAAAAA			3		$40.00			$80.00
//					- % 20 (Qty Discount)
//					- $ 70 (New Customer Discount)

	//line
	sline = "";
	sline = StringUtil.AddSpaces(sline,iMaxLine,false);
	sline = sline.Replace(" ","_");
	sline+= sepLine+sepLine;
	sbody+= sline;					

	//Product ID		Description Qty		Price			Extension
	sline = StringUtil.AddSpaces("Product ID",30,true);
	s1	  = StringUtil.AddSpaces("Qty",15,true);
	sline+=s1;	
	s1	  = StringUtil.AddSpaces("Price",15,true);
	sline+=s1;
	s1	  = StringUtil.AddSpaces("Extension",15,true);
	sline+=s1;

	sline+= sepLine+sepLine;
	sbody+= sline;			

	//line
	sline = "";
	sline = StringUtil.AddSpaces(sline,iMaxLine,false);
	sline = sline.Replace(" ","_");
	sline+= sepLine+sepLine;
	sbody+= sline;					


	//AAAAA			3		$40.00			$80.00	    	
	for (i=0;i < order.getCountLines();i++)
	{
		orderDtl = order.getLineByIndex(i);
	
		dtotalDiscounts+= orderDtl.getTotalDiscounts();

		sline="";
		dprice = orderDtl.getItemNetTotal() - orderDtl.getTotalDiscounts();
		sline = StringUtil.AddSpaces(orderDtl.getProdID(),30,true);	

		s1	  = StringUtil.AddSpaces(orderDtl.getQtyOrdSum().ToString("##0.#0"),15,true);
		sline+=s1;

		s1	  = StringUtil.AddSpaces(Constants.MONEY_SYMBOL + orderDtl.getUnitPrice().ToString("##0.#0"),15,true);
		sline+=s1;

		s1	  = StringUtil.AddSpaces(Constants.MONEY_SYMBOL + dprice.ToString("##0.#0"),15,true);
		sline+=s1;

		sline+= sepLine;
		sbody+= sline;			

		//print the description in the obove line
		s1	= StringUtil.AddSpaces("",30,true);
		s2	=orderDtl.getProdDescription();
		sline = StringUtil.AddSpaces(s1 + s2,iMaxLine,true);	
		sline+= sepLine+sepLine;
		sbody+= sline;			
				
		//Product ID                   Qty            Price          Extension 
	

		//charges
		for (j=0; j < orderDtl.getCountCharges();j++)
		{							
			orderDtlCharge = orderDtl.getDltChargeByIndex(j);

			s1="";			
			if (orderDtlCharge.getPercent() > 0)
				s1="- %" + orderDtlCharge.getPercent().ToString("##0.#0");
			else
				s1="- " + Constants.MONEY_SYMBOL + orderDtlCharge.getAmount().ToString("##0.#0");
			
			s2 = StringUtil.AddSpaces(s1,s1.Length + 45,false);
			s2+= " (" + orderDtlCharge.getChargeDesc() + ")";
			sline= StringUtil.AddSpaces(s2,iMaxLine,true);

			sline+= sepLine;
			sbody+= sline;			
		}		
		
		sbody+= sepLine;
	}	
	
	sbody+= sepLine;			
//
//								Sub-Total: $230.00
//							    Discounts: -$40
//				
//								Total: $190.00

	//Subtotal
	dprice= order.getOrderTotal() + dtotalDiscounts;
	s1=StringUtil.alingToRight("","Sub-Total:",60); 
	s2=StringUtil.AddSpaces(Constants.MONEY_SYMBOL + dprice.ToString("##0.#0"),15,true); 
	sline= s1 + s2;
	sline+= sepLine;
	sbody+= sline;			
	//Discounts
	dprice= order.getOrderTotal() + dtotalDiscounts;
	s1=StringUtil.alingToRight("","Discounts:",60);
	s2=StringUtil.AddSpaces("-" + Constants.MONEY_SYMBOL + dtotalDiscounts.ToString("##0.#0"),10,true); 
	sline= s1 + s2;
	sline+= sepLine+sepLine;
	sbody+= sline;		
	
	//Total	
	s1=StringUtil.alingToRight("","Total:",60);
	s2=StringUtil.AddSpaces(Constants.MONEY_SYMBOL +order.getOrderTotal().ToString("##0.#0"),10,true); 
	sline= s1 + s2;
	sline+= sepLine+sepLine;
	sbody+= sline;	
	
	sline=StringUtil.AddSpaces(Constants.ORDER_PRINT_TAX_LEGEND,iMaxLine,false);
	sline+= sepLine;
	sbody+= sline;	

	//Note	
	snotes="";
	for (j=0; j < order.getCountNotes();j++)
	{
		note = order.getNoteByIndex(j);
		snotes+= note.getNote();
	}
	if (snotes.Length > 0)
	{
		sline= sepLine;
		sline+= "Note    : ";
		s2="";				
		//cut the Notes in lines with length= iMaxLine-10
		for (j=0; StringUtil.cutString(snotes,out s1,j,iMaxLine-10);j++,sline=StringUtil.AddSpaces(s2,10,true))
		{
			sline+= s1 + sepLine;
			sbody+= sline;			
		}	
	}

//	-------------------------------------------------------------------------------------
//	Employee: Name Employee
//	Code    : 1234	
//	--------------------------------------------------------------------------------------
	//line
	sline = "";
	sline = StringUtil.AddSpaces(sline,iMaxLine,false);
	sline = sline.Replace(" ","_");
	sline+= sepLine+sepLine;
	sbody+= sline;		

	//employee name
	s1= "Employee: " + employee.getFirstName();
	sline = StringUtil.AddSpaces(s1,iMaxLine,true);
	sline+= sepLine;
	sbody+= sline;		

	//employee code
	s1= "Code    : " + employee.getId();
	sline = StringUtil.AddSpaces(s1,iMaxLine,true);
	sline+= sepLine;
	sbody+= sline;		

	//line
	sline = "";
	sline = StringUtil.AddSpaces(sline,iMaxLine,false);
	sline = sline.Replace(" ","_");
	sline+= sepLine+sepLine;
	sbody+= sline;		
			
	return bresult;
}
//#endif

public override string getXmlHeader()
{ 
	return "ORDER_PRINT";
}//Header




	}
}
	