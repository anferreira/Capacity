using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Core.Print;
using Nujit.NujitERP.ClassLib.ErpException;


namespace Nujit.NujitERP.WinForms.Orders{
	/// <summary>
	/// Summary description for BarCodeReader.
	/// </summary>
	public class Cash
	{		
		Order		order = null;
		CoreFactory coreFactory=null;
		Person		billPerson=null;
		Person		shipPerson=null;
		Employee	employee=null;

		bool		bHeaderCreated=false;

		public bool getOrderCreated()
		{
			return bHeaderCreated;
		}		

		public Cash(CoreFactory coreFactory)
		{
			this.coreFactory= coreFactory; 
		}
		public bool createNewOrder(Employee employee,Person billPerson)
		{	
			bool	bresult=false;
			
			this.employee	= employee;
			this.billPerson	= billPerson;
			this.shipPerson	= billPerson;

			bHeaderCreated=false;//is a new order			

			try
			{			
				//new order, and set the default values
				order = new  Order();
				
				order.setId(0);//temporal
				order.setOrderNum(0);
				order.setQuote(0);								
				order.setOrgId("0");
				order.setSalesPerson(employee.getId());

				//bill person
				order.setBillToNum(billPerson.getId());
				order.setShipToNum(billPerson.getId());//by default, set the same value as BillToNum				
				order.setBillToName(billPerson.getName());
				order.setBillToAdd1(billPerson.getAddress1());
				order.setBillToAdd2(billPerson.getAddress2());
				order.setBillToAdd3(billPerson.getAddress3());
				order.setBillToAdd4(billPerson.getAddress4());
				order.setBillToAdd5(billPerson.getAddress5());
				order.setBillToAdd6(billPerson.getAddress6());	
				order.setBillToZipCode(billPerson.getZipCode());
				
				order.setOrderTotal(0);
				order.setOrderDate(DateTime.Now);		
				order.setOrderStatus(Constants.ORDER_STATUS_CREATED);
				order.setOrderType(Constants.ORDER_TYPE_QUOTE);//quote by default	
				order.setRetailProductType("");			

				bresult=true;
			}		
			catch(NujitException Nex)
			{	
				MessageBox.Show(Nex.Message);							
			}		

			return bresult;
		}

		public bool loadOrder(int iorder,out Order order,out Person billPerson,out Person shipPerson,out Employee employee)
		{
			bool	bresult=false;
			
			order = null;
			billPerson = null;
			shipPerson = null;
			employee = null;
							
			if (this.loadOrder(iorder))
			{
				bresult=true;

				order		= this.order;
				billPerson	= this.billPerson;
				shipPerson	= this.shipPerson;
				employee	= this.employee;								
			}
			

			return bresult;
		}

		public bool loadOrder(int iorder)
		{
			bool				bresult=true;
			string				sbillPersonId,shipPersonId;
			string				smessage="";
			OrderDtlRel			orderDtlRel=null;
			
			try
			{
				order = coreFactory.readOrderHeaderAllData(iorder);	
				if (order!=null)
				{
					bHeaderCreated=true;//the order is old
					
					//bill person
					sbillPersonId = order.getBillToNum();

					//ship person
					if (order.getCountLines() > 0)
					{
						orderDtlRel = order.getLineRelByIndex(0,0);//get the first detail rel
						if (orderDtlRel!= null)
							shipPersonId = orderDtlRel.getShipToNum();
						else
							shipPersonId = sbillPersonId;
					}
					else
						shipPersonId = sbillPersonId;

					//read bill person					
					if (coreFactory.existsPerson("",sbillPersonId))
					{
						billPerson = coreFactory.readPerson("",sbillPersonId);						
						order.getPerson(ref billPerson);//show the same data as the order, the problem is "Add New" CustVend
					}
					else
					{
						smessage= "Can not read bill person:" + sbillPersonId;
						bresult= false;
					}

					//read ship person
					
					if (coreFactory.existsPerson("",shipPersonId))
					{
						shipPerson = coreFactory.readPerson("",shipPersonId);						
						if (orderDtlRel!= null)
							orderDtlRel.getPerson(ref shipPerson);//show the same name as the order, the problem is "Add New" CustVend
					}
					else
					{
						smessage= "Can not read ship person:" + shipPersonId;
						bresult= false;
					}
						
					//read employee					
					if (coreFactory.existsEmployee(order.getSalesPerson()))
						employee = coreFactory.readEmployee(order.getSalesPerson());					
					else
					{
						smessage= "Can not read employee:" + order.getSalesPerson();
						bresult= false;
					}

					if (!bresult)						
						MessageBox.Show(smessage);
				}		
				else
				{
					MessageBox.Show("Can not read the order.");
					bresult=false;
				}		
			}		
			catch(NujitException Nex)
			{	
				MessageBox.Show(Nex.Message);			
				bresult=false;
			}		

			return bresult;
		}

		public Order getOrder()
		{
			return order;
		}
		public Employee getEmployee()
		{
			return employee;
		}

		public Person getBillPerson()
		{
			return billPerson;
		}

		public Person getShipPerson()
		{
			return shipPerson;
		}

		public void setOrder(Order order)
		{
			this.order = order;
		}
		public void setEmployee(Employee employee)
		{
			this.employee = employee;
		}

		public void setBillPerson(Person billPerson)
		{
			this.billPerson = billPerson;
		}

		public void setShipPerson(Person shipPerson)
		{
			this.shipPerson = shipPerson;
		}
/*
		public bool changeDtlQuantity(OrderDtl orderDtl,double dquantity)
		{						
			OrderDtlRel	orderDtlRel=null;
			bool		bresult=false;
						
			orderDtl.setQtyOrdSum(dquantity);	//new quantity		
			
			orderDtlRel	=	orderDtl.getDltRel(0);//get the first order detail rel
			if (orderDtlRel==null)
			{
				//the order detail rel , does not exists, so create it now
				orderDtlRel = new OrderDtlRel();
				orderDtlRel = orderDtl.addDtlRel(billPerson,shipPerson);//set detail rel
			}			
			
			orderDtlRel.setQtyOrd(orderDtl.getQtyOrdSum());	//new quantity			
			orderDtl.recalculate();//get subtotal apply discounts

			//new total prize
			order.recalculate();
						
			try
			{				
				//begin transaction
				coreFactory.beginTransaction();						
				
				coreFactory.updateOrderHeader(order);//update order

				coreFactory.updateOrderLine(orderDtl);//update order line								
				coreFactory.updateOrderDetailRel(orderDtlRel);//update order detail					

				//commit
				coreFactory.commitTransaction();			
				
				bresult=true;		
			}			
			catch(NujitException Nex)
			{	
				MessageBox.Show(Nex.Message);								
			}						
			
			return bresult;		
		}
		public bool addNewDetail(Product product)
		{
			bool				bresult=false;			
			OrderDtl			orderDtl = null;
			OrderDtlRel			orderDtlRel = null;					
			double				dprice=0;
			double				dquantity= 0;					
			string[][]			slistPrices;
			bool				bproductWasInTheOrder=false;
			int					iorder=0;
						
			if (this.order.getFinished())
			{
				MessageBox.Show("Sorry, this order is ended.");
				return false;
			}			
			
			dquantity = decimal.ToDouble(product.getStdPackSize());
			if (dquantity==0)
				dquantity=1;
	
			//check if this product is in the order
			orderDtl = order.checkIfProductInTheOrder(product.getProdID());
			if (orderDtl== null)
			{
				bproductWasInTheOrder=false;		
				//product price
				slistPrices = coreFactory.readProductPriceByCustomer(	product.getProdID(),
																		order.getBillToNum(),
																		DateUtil.getDateRepresentation(DateTime.Now,DateUtil.MMDDYYYY),			
																		"A");//A active					
				if (slistPrices.Length < 1)
				{
					MessageBox.Show("The product has not a price.");
					return false;
				}			

				dprice = double.Parse(slistPrices[0][0]);//price


				//create the new orderDtl and orderDtlRel 
				order.addNewLine(	out orderDtl,out orderDtlRel,product,
									billPerson,shipPerson,
									dprice,dquantity,iOrderLineQuantity);								
			}			
			else
			{
				bproductWasInTheOrder=true;
				orderDtl.setQtyOrdSum(orderDtl.getQtyOrdSum() + dquantity);	//new quantity		
				
				orderDtlRel	=	orderDtl.getDltRel(0);//get the first order detail rel
				if (orderDtlRel==null)
				{
					//the order detail rel , does not exists, so create it now
					orderDtlRel = new OrderDtlRel();
					orderDtlRel = orderDtl.addDtlRel(billPerson,shipPerson);//set detail rel
				}			
				
				orderDtlRel.setQtyOrd(orderDtl.getQtyOrdSum());	//new quantity
				orderDtl.recalculate();//get subtotal apply discounts				
			}			
			
			//new total prize
			order.recalculate();
									
			try
			{				
				//begin transaction
				coreFactory.beginTransaction();						
				if (!bHeaderCreated)
				{						
					bHeaderCreated=true;
					coreFactory.writeOrderHeader(order);//new order				
	
					iorder = coreFactory.getLastId();//get autonumeric inserted

					//add new id order
					order.setId(iorder);
					if (order.getOrderType() == Constants.ORDER_TYPE_ORDER)
						order.setOrderNum(iorder);
					else
						order.setQuote(iorder);

					orderDtl.setHId(iorder);
					orderDtl.setOrderNum(iorder);

					orderDtlRel.setHId(iorder);					
					orderDtlRel.setOrderNum(iorder);					
				}			
								
				coreFactory.updateOrderHeader(order);//update order

				if (!bproductWasInTheOrder)
				{
					coreFactory.writeOrderLine(orderDtl);//order line								
					coreFactory.writeOrderDetailRel(orderDtlRel);//order detail
				}			
				else		
				{
					coreFactory.updateOrderLine(orderDtl);//update order line								
					coreFactory.updateOrderDetailRel(orderDtlRel);//update order detail
				}			

				//commit
				coreFactory.commitTransaction();						
				
								
				bresult=true;
			}			
			catch(NujitException Nex)
			{	
				MessageBox.Show(Nex.Message);				
			}						
			
			return bresult;		
		}


		public bool deleteOrderDetail(OrderDtl orderDtl,int indexFromTheList)
		{	
			bool			bresult=false;			
			OrderDtlRel		orderDtlRel= new OrderDtlRel();
			OrderDtlCharge	orderDtlCharge= new OrderDtlCharge();			
			
			order.removeLine(indexFromTheList);		

			//order detail rel
			orderDtlRel.setHId(orderDtl.getHId());
			orderDtlRel.setItemNum(orderDtl.getItemNum());

			orderDtlCharge.setHId(orderDtl.getHId());
			orderDtlCharge.setItemNum(orderDtl.getItemNum());

			order.recalculate();//recalculate total

			try
			{
				coreFactory.beginTransaction();//begin transaction
				
				coreFactory.updateOrderHeader(order);//update de order header

				//delete detail rel
				coreFactory.deleteOrderDetailRelFromDetail(orderDtlRel);

				//delete detail charges 
				coreFactory.deleteOrderDetailChargeFromDetail(orderDtlCharge);

				//delete de line order selected														
				coreFactory.deleteOrderLine(orderDtl);	//delete the line			

				coreFactory.commitTransaction();//commit																	

				bresult=true;
			}			
			catch(NujitException Nex)
			{					
				MessageBox.Show(Nex.Message);
			}	

			return bresult;
		}

		public bool deleteOrder()
		{
			bool	bdelete=false;

			if (!this.order.getFinished())
			{								
				if (	MessageBox.Show("Do you want to delete this order?", "Question", 
  						MessageBoxButtons.YesNo, 
						MessageBoxIcon.Asterisk,
						MessageBoxDefaultButton.Button1)== System.Windows.Forms.DialogResult.Yes)				
  					bdelete=true;
					
				if (bdelete)
				{									
					try
					{
						coreFactory.beginTransaction();		

						coreFactory.deleteOrderHeader(order);	//delete the header
						
						coreFactory.commitTransaction();						
					}			
					catch(NujitException Nex)
					{	
						bdelete = false;//can not delete the order
						MessageBox.Show(Nex.Message);
					}								
				}			
			}			
			else
				MessageBox.Show("Sorry, this order is ended, can not delete this order.");				

			return bdelete;
		}		

		public bool sendOrderToServer()
		{
			bool  bsendOrder=false;

			if (!this.order.getFinished())
			{									
				if (	MessageBox.Show("¿Do you want to print and finish the order?", "Question", 
						MessageBoxButtons.YesNo, 
						MessageBoxIcon.Asterisk,
						MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)				
				{									
					try
					{
						PrintServerOrder printServerOrder = new PrintServerOrder();

						printServerOrder.processReport(this);						
						bool bprintResult=false;

						if (Configuration.getPrintByServer())	bprintResult = printServerOrder.print();
						else									bprintResult = printServerOrder.printDirectly();

						if (bprintResult) 	MessageBox.Show("Order printed.");
						else				MessageBox.Show("Could not print the order.");


						//code to print		

						order.setOrderStatus(Constants.ORDER_STATUS_FINISHED);//set to finished							
						//the update is in sendOrder, when it works in on line mode
						if (!Configuration.getWorkModeOnline())
							coreFactory.updateOrderHeader(order);//update order finished	
										
						bsendOrder=true;
					}
					catch (NujitException Nex)
					{
						bsendOrder=false;
						MessageBox.Show(Nex.Message);
					}

					if (bsendOrder && Configuration.getWorkModeOnline())//if all ok and , if wotk online
					{						
						//because, the user works online, so we send the order
						TransferCoreFactory t = new TransferCoreFactory();

						if (t.sendOrder(order))
							MessageBox.Show("Order processed.");
					}
				}
			}

			return bsendOrder;
			
		}

		public bool selectClient(Constants.TYPE_CLIENT typeClient)
		{
			bool	bresult=false;
			Person	personSelected=null;

			//select the client
			ClientForm clientForm= new ClientForm(typeClient,billPerson.getId());
			clientForm.ShowDialog();

			personSelected= clientForm.getPersonSelected();
			if (personSelected != null) //if there is a client selected
			{
				if (typeClient == Constants.TYPE_CLIENT.TYPE_CLIENT_BILL)
				{
					billPerson = personSelected;

					order.setBillToNum(billPerson.getId());									
				}		

				//ship person
				shipPerson = personSelected;
				if (typeClient == Constants.TYPE_CLIENT.TYPE_CLIENT_SHIP)
				{
					ClientDataFormModify clientDataForm = new ClientDataFormModify(shipPerson,"Change shipp address");
					clientDataForm.ShowDialog();

					if (clientDataForm.getSelected())
					{
						shipPerson = clientDataForm.getPerson();
					}		
				}		
				order.setShipToNum(shipPerson.getId());																			

				try
				{
					//update all the order detail rel, from the order
					OrderDtlRel orderDtlRel = new OrderDtlRel();

					orderDtlRel.setPerson(shipPerson);

					orderDtlRel.setHId(order.getId());//order header

					coreFactory.updateOrderDetailRelFromHeader(orderDtlRel);//update all the Detail Rel, in the database with the new values

					order.updateOrderDetailRel(orderDtlRel);//update all the Detail Rel object, to the new values

					bresult=true;
				}		
				catch (NujitException Nex)
				{
					MessageBox.Show(Nex.Message);					
				}				
			}		

			return bresult;
		}

		public bool addCharges(OrderDtl orderDtl,string sdicountGroupId)
		{
			bool		bresult=true;
			bool		buseTranscation=false;
			ArrayList	arrayDiscounts=null;//to storage the discounts
			Discount	discount = null;
									
			try
			{
				//get all the discounts from the group							
				arrayDiscounts = coreFactory.getDiscountsInGroupDescByDesc(sdicountGroupId,"%",-1,"PRGD_DiscNum");//order by PRGD_DiscNum

				if (arrayDiscounts.Count > 0)//if there are discounts?
				{
					coreFactory.beginTransaction(); //begin

					for(int i = 0;i <arrayDiscounts.Count && bresult;i++)
					{
						discount = (Discount)arrayDiscounts[i];
						bresult = addOneCharge(orderDtl,discount.getDiscCode(),buseTranscation);
					}			

					if (bresult)
						coreFactory.commitTransaction();//commit					
				}		
			}		
			catch (NujitException Nex)
			{
				bresult=false;
				MessageBox.Show(Nex.Message);					
			}				
			return bresult;
		}

		public bool addCharge(OrderDtl orderDtl,string sdicountId)
		{
			bool buseTranscation=true;

			return addOneCharge(orderDtl,sdicountId,buseTranscation);
		}
		public bool addOneCharge(OrderDtl orderDtl,string sdicountId,bool buseTranscation)
		{
			bool			bresult=false;
			Discount		discount=null;
			OrderDtlCharge	orderDtlCharge=null;
			int				imaxItemCharge=0;

			discount = coreFactory.readDiscount(sdicountId);//read the discount
			if (discount != null)
			{								
				//get the max item item charge					
				imaxItemCharge  = coreFactory.getMaxItemFromDetailCharge(orderDtl.getHId(),orderDtl.getItemNum());
				imaxItemCharge++;

				//fill the OrderDtlCharge values
				orderDtlCharge = orderDtl.addDtlCharge(imaxItemCharge,discount,billPerson);

				orderDtl.addDtlCharge(orderDtlCharge);//add charge to the list
				orderDtl.recalculate();//calculate subtotal with the charges
									
				order.recalculate();

				try
				{										
					if (buseTranscation)
						coreFactory.beginTransaction();	//begin transaction

					coreFactory.updateOrderHeader(order);
					coreFactory.updateOrderLine(orderDtl);
					coreFactory.writeOrderDetailCharge(orderDtlCharge);

					if (buseTranscation)
						coreFactory.commitTransaction();//commit

					bresult=true;
				}								
				catch(NujitException Nex)
				{						
					MessageBox.Show(Nex.Message);
					order = coreFactory.readOrderHeaderAllData(order.getId());//read all the order															
				}	
			}
			return bresult;
		}


		public bool deleteAllDetailCharge(OrderDtl orderDtl)
		{
			bool			bresult=false;			
			OrderDtlCharge	orderDtlCharge= new OrderDtlCharge();
											
			orderDtl.removeAllDltCharge(); //remove all the charges array

			//to delete charges
			orderDtlCharge.setHId(orderDtl.getHId());
			orderDtlCharge.setItemNum(orderDtl.getItemNum());
				
			orderDtl.recalculate();//calculate subtotal with charges
				
			order.recalculate();

			try
			{					
				coreFactory.beginTransaction();//begin transaction

				coreFactory.updateOrderHeader(order);
				coreFactory.updateOrderLine(orderDtl);
				coreFactory.deleteOrderDetailChargeFromDetail(orderDtlCharge);

				coreFactory.commitTransaction();//commit

				bresult=true;
			}								
			catch(NujitException Nex)
			{					
				MessageBox.Show(Nex.Message);				
			}	
			
			return bresult;
		}

		public bool updateOrder()
		{
			bool			bresult=false;						

			try
			{					
				coreFactory.updateOrderHeader(order);				
				bresult=true;
			}								
			catch(NujitException Nex)
			{					
				MessageBox.Show(Nex.Message);				
			}	
			
			return bresult;
		}*/

	}
}
