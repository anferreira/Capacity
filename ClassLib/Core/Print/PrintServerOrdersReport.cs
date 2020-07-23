using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;





namespace Nujit.NujitERP.ClassLib.Core.Print
{

public class PrintServerOrdersReport :PrintServer
{					

public PrintServerOrdersReport(): base()
{
	
}
#if POCKET_PC
public bool processReport(	string		sclientSelected,
							string		sEmployeeSelected,
							string		sdateSince,
							string		sdateUntil,
							string		stypeOfOrderSelected,
							out bool	bthereIsData)
{
	string			sline="",s1="",s2="";
	string			sepLine="\r\n";						
	
	DateTime		dateSince=DateTime.Now,dateUntil=DateTime.Now;
	
	double			dprice=0;			
	int				h=0,i=0,j=0;						
	int				iMaxLine=80;
	
	ArrayList		arrayList=null;
	Order			order=null;
	OrderDtl		orderDtl = null;	
	OrderDtlCharge	orderDtlCharge=null;
	bool			bresult=true;
		
	bthereIsData=false;			
	sbody="";
	stitle="";

	try
	{
		
		dateSince = DateUtil.parseCompleteDate(sdateSince,DateUtil.MMDDYYYY);
		dateUntil = DateUtil.parseCompleteDate(sdateUntil,DateUtil.MMDDYYYY);

		stitle=	"Orders Report Between ";
		stitle+= DateUtil.getDateRepresentation(dateSince,DateUtil.MMDDYYYY) + " and ";
		stitle+= DateUtil.getDateRepresentation(dateUntil,DateUtil.MMDDYYYY);
		stitle+= " From Terminal:" + Configuration.getTerminalId().ToString();
		stitle = StringUtil.center(stitle,iMaxLine);		
		stitle+= sepLine+sepLine; 

		stitle+=	StringUtil.AddSpaces("OrderNum",10,true)	+ " ";
		stitle+=	StringUtil.AddSpaces("Date",18,true)		+ " ";
		stitle+=	StringUtil.AddSpaces("Ship Date",12,true)	+ " ";
		stitle+=	StringUtil.AddSpaces("PO",20,true)			+ " ";
		stitle+=	StringUtil.AddSpaces("Total",10,true)		+ " ";		
		stitle+=	sepLine + sepLine;	

		arrayList = coreFactory.readOrdersHeadersArrayList(sclientSelected,sEmployeeSelected,dateSince,dateUntil,stypeOfOrderSelected);			
		for(h = 0;h < arrayList.Count;h++)
		{				
			//order header
			order = (Order)arrayList[h];
			if (order!=null)
			{				
				bthereIsData=true;

				//sheader = order.ge		
				sline= StringUtil.AddSpaces(order.getId().ToString(),10,true) + " ";
				sline+=DateUtil.getCompleteDateRepresentation(order.getOrderDate(),DateUtil.MMDDYYYY) + " ";
				s1	= DateUtil.getDateRepresentation(order.getDateShip(),DateUtil.MMDDYYYY);
				sline+=StringUtil.AddSpaces(s1,12,true);				
				sline+=StringUtil.AddSpaces(order.getPO(),20,true);				
				sline+=Constants.MONEY_SYMBOL + order.getOrderTotal().ToString("##0.#0") + " ";
				sline+=sepLine;
				sbody+= sline;

				//second header line
				sline=order.getBillToName() + "(" +  order.getBillToNum() +") ";
				sline+=order.getBillToAdd1();
				sline+=sepLine;
				sbody+= sline;

				if (order.getBillToAdd2().Length > 0 || order.getBillToAdd3().Length > 0)
				{
					sline= StringUtil.AddSpaces(order.getBillToAdd2().ToString(),39,true) + ",";
					sline+=StringUtil.AddSpaces(order.getBillToAdd3().ToString(),39,true) + " ";

					sline+=sepLine;
					sbody+= sline;
				}		

				sbody+= sepLine;
				
				//details
				for (i=0;i < order.getCountLines();i++)
				{
					orderDtl = order.getLineByIndex(i);

					sline=  "  ";
					sline+= StringUtil.AddSpaces(orderDtl.getProdDescription(),40,true);
					sline+= "(" +orderDtl.getProdID() + ")";
					sline+= "#" + orderDtl.getQtyOrdSum().ToString("##0.#0") + " ";
					
					dprice=orderDtl.getItemNetTotal() - orderDtl.getTotalDiscounts();
					sline+=Constants.MONEY_SYMBOL + dprice.ToString("##0.#0") + " ";
					
					sline+=sepLine;
					sbody+= sline;
					
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
						sline= s2;

						sline+= sepLine;
						sbody+= sline;		
					}		
				}	
				
				sbody+= sepLine;					
			}					
		}				
	}
	catch(NujitException Nex)
	{						
		MessageBox.Show(Nex.Message);
		bresult=false;
	}
	catch(Exception ex)
	{						
		MessageBox.Show(ex.Message);
		bresult=false;
	}

	return bresult;
}
#endif

public override string getXmlHeader()
{ 
	return "ORDERS_REPORT_PRINT";
}//Header




	}
}
	