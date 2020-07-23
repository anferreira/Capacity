using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
#if POCKET_PC
using MobileOrder.Gui;
#endif

namespace Nujit.NujitERP.ClassLib.Core.Util
{


public
class OrderCoreFactory : NoteCoreFactory{

public
OrderCoreFactory() : base(){
}

public void updateOrderNotSend()
{
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);
		
		orderHdrDataBase.updateOrderNotSend();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// return all OrderHeaders codes 
/// </summary>
/// <returns></returns>
public int getMaxOrderHeader()
{
	try
	{
		OrderHdrDataBase orderHdrDataBase= new OrderHdrDataBase(dataBaseAccess);	
		
		return orderHdrDataBase.getMaxOrderHeader();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public
Order getOrderHeader(int iorder){
	try
	{
		OrderHdrDataBaseContainer orderHdrDataBaseContainer= new OrderHdrDataBaseContainer(dataBaseAccess);	
		orderHdrDataBaseContainer.readByOHeaderNumber(iorder);

		Order order= null;
		
		int i = 0;
		for(IEnumerator en = orderHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			DictionaryEntry orderHdrDataBaseEntry = (DictionaryEntry) en.Current;

			OrderHdrDataBase orderHdrDataBase = (OrderHdrDataBase) orderHdrDataBaseEntry.Value;
			
			order = objectDataBaseToObject(orderHdrDataBase);
			
			i++;
		}
		return order;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public
ArrayList readOrdersHeadersArrayList(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected){

	ArrayList	arrayList = new ArrayList();
	try
	{
		OrderHdrDataBaseContainer orderHdrDataBaseContainer= new OrderHdrDataBaseContainer(dataBaseAccess);	
		orderHdrDataBaseContainer.readByOHeader(sclient,semployee,dateSince,dateUntil,stypeOfOrderSelected,"","",0,false);		
		
		Order		order = null;	
		int			i=0;
			
		
		IEnumerator iEnum = orderHdrDataBaseContainer.GetEnumerator();
		
		for (i=0;iEnum.MoveNext();i++){
			OrderHdrDataBase orderHdrDataBase = (OrderHdrDataBase)iEnum.Current;
		
			order = this.readOrderHeaderAllData(orderHdrDataBase.getOH_ID());
			
			if (order != null)
			{
				#if POCKET_PC
					smessage="\n\n\n Processing Order :" + order.getId()	+ "\n\n\n";
					smessage+=	" Total:" + (i+1) + "/" +  orderHdrDataBaseContainer.Count + "\n\n\n\n";				
					smessage+=	" Please Wait";				
					MessageTimer	messTimer = new MessageTimer(smessage,50,"Ok","","");
	 				messTimer.ShowDialog();										
					messTimer.Dispose();
					messTimer= null;
				#endif

				arrayList.Add(order);	
			}
		}
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
	return arrayList;
}

public Order[] readOrdersHeaders(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected, string sorderStatus, string sorderType, int iorderNum, bool onlyPendingOrders)
{
	try
	{
		OrderHdrDataBaseContainer orderHdrDataBaseContainer= new OrderHdrDataBaseContainer(dataBaseAccess);	
		orderHdrDataBaseContainer.readByOHeader(sclient,semployee,dateSince,dateUntil,stypeOfOrderSelected,sorderStatus,sorderType,iorderNum, onlyPendingOrders);

		Order[] items = new Order[orderHdrDataBaseContainer.Count];
		int i = 0;
		IEnumerator enu = orderHdrDataBaseContainer.GetEnumerator();
		while (enu.MoveNext())
		{
			items[i] = objectDataBaseToObject((OrderHdrDataBase)enu.Current);
			i++;
		}
		return items;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public
string[][] readOrdersHeaders(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string stypeOfOrderSelected){
	try
	{
		OrderHdrDataBaseContainer orderHdrDataBaseContainer= new OrderHdrDataBaseContainer(dataBaseAccess);	
		orderHdrDataBaseContainer.readByOHeader(sclient,semployee,dateSince,dateUntil,stypeOfOrderSelected,"","",0,false);
		
		string[][] items = new string[orderHdrDataBaseContainer.Count][];
		int i = 0;

		IEnumerator iEnum = orderHdrDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			OrderHdrDataBase orderHdrDataBase = (OrderHdrDataBase)iEnum.Current;
				
			string[] item = new String[9];
			bool	 bvalue=false;

			item[0] = "0";//orderHdrDataBase.getTerminal().ToString();			
			item[1] = orderHdrDataBase.getOH_ID().ToString();			
			item[2] = orderHdrDataBase.getOH_BillToNum();			
			item[3] = orderHdrDataBase.getOH_SalesPerson();
			item[4] = orderHdrDataBase.getOH_OrderTotal().ToString();			
			item[5] = DateUtil.getCompleteDateRepresentation(orderHdrDataBase.getOH_OrderDate(), DateUtil.MMDDYYYY);
			item[6] = orderHdrDataBase.getOH_Synchronized();			

			//status, sent or not
			if (orderHdrDataBase.getOH_OrderStatus().Equals(Constants.ORDER_STATUS_CREATED))
				bvalue = false;
			else
				bvalue = true;

			item[7] = NumberUtil.boolToint(bvalue).ToString();

			//type of order, Quote or not
			if (orderHdrDataBase.getOH_OrderType().Equals(Constants.ORDER_TYPE_QUOTE))
				bvalue = true;
			else
				bvalue = false;

			item[8]	= NumberUtil.boolToint(bvalue).ToString();
								
			items[i] = item;
			i++;
		}
		return items;
	
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public
	string[][] readOrdersHeadersNotSend()
{
	try
	{
		OrderHdrDataBaseContainer orderHdrDataBaseContainer= new OrderHdrDataBaseContainer(dataBaseAccess);	
		orderHdrDataBaseContainer.readByOHeaderNotSend();

		string[][] items = new string[orderHdrDataBaseContainer.Count][];
		int i = 0;

		IEnumerator iEnum = orderHdrDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			OrderHdrDataBase orderHdrDataBase = (OrderHdrDataBase)iEnum.Current;
					
			string[] item = new String[6];		

			item[0] = "0";//orderHdrDataBase.getTerminal().ToString();			
			item[1] = orderHdrDataBase.getOH_ID().ToString();			
			item[2] = orderHdrDataBase.getOH_BillToNum();			
			item[3] = orderHdrDataBase.getOH_SalesPerson();
			item[4] = orderHdrDataBase.getOH_OrderTotal().ToString();	
			item[5] = DateUtil.getCompleteDateRepresentation(orderHdrDataBase.getOH_OrderDate(), DateUtil.MMDDYYYY);
			
			items[i] = item;
			i++;
		}
		return items;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Return if exists a Order
/// </summary>
/// <param name="OrderHeaderCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsOrderHeader(int iorder){
	try
	{
		OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);
		
		orderHdrDataBase.setOH_ID(iorder);
		
		return orderHdrDataBase.exists();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Read and return a Order object
/// </summary>
/// <param name="OrderHeaderCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
Order readOrderHeader(int iorder){
	try
	{
		OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);
				
		orderHdrDataBase.setOH_ID(iorder);

		if (!orderHdrDataBase.exists())
			return null;

		orderHdrDataBase.read();

		Order order = objectDataBaseToObject(orderHdrDataBase);
		
		return order;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public
Order readOrderHeaderAllData(int iorder){

	try
	{
		//read header
		Order		order = readOrderHeader(iorder);
		OrderDtl	orderDtl = null;
		Note[]		notes = new Note[0];
		int			i=0,j=0;
		
		if (order != null)
		{
			//read detail
			order = getOrderLinesById(order);

			//read notes
			notes = this.readNotes(Constants.NOTE_TYPE_ORDER,order.getId(),int.MinValue,int.MinValue);

			for(j = 0;j < notes.Length;j++)
				order.addNote(notes[j]);
		
			for (i=0; i < order.getCountLines();i++)
			{
				orderDtl = order.getLineByIndex(i);
				//order dtl rel 
				if (orderDtl!= null)
				{
					orderDtl  = getOrderDetailRelById(orderDtl);				
					orderDtl  = getOrderDetailChargeById(orderDtl);

					notes = this.readNotes(Constants.NOTE_TYPE_ORDER_DTL,orderDtl.getHId(),orderDtl.getItemNum(),int.MinValue);
					for(j = 0;j < notes.Length;j++)
						orderDtl.addNote(notes[j]);
				}		
			}		
		}

		return order;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Write to the database a Order object
/// </summary>
/// <param name="proccess"></param>
public
void writeOrderHeader(Order order){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderHdrDataBase orderHdrDataBase = objectToObjectDatabase(order);
		
		orderHdrDataBase.write();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

public void writeCompleteOrder (Order order)
{
	try
	{
		this.FillRedundancies (order);
		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderHdrDataBase orderHdrDataBase = this.objectToObjectDatabase(order);		
	
		orderHdrDataBase.write();

		int id = dataBaseAccess.getLastId();
		order.setId(id);

		// Temporary:
		order.setOrderNum (0);
		order.setQuote (0);
		if (order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER))
			order.setOrderNum (id);
		else
			order.setQuote (id);
		orderHdrDataBase.setOH_ID (id);
		orderHdrDataBase.setOH_OrderNum (order.getOrderNum());
		orderHdrDataBase.setOH_Quote (order.getQuote());
		orderHdrDataBase.update();
		// End Temporary.

		//add note
		IEnumerator enuNote = order.getNoteEnumerator();
		while (enuNote.MoveNext())
		{
			Note note = (Note)enuNote.Current;

			note.setKey1(order.getId()); 
			NoteDataBase noteDataBase = this.objectToObjectDatabase(note);
			noteDataBase.write();
		}

		IEnumerator enu = order.getLineEnumerator();
		while (enu.MoveNext())
		{
			OrderDtl orderDtl = (OrderDtl)enu.Current;
			orderDtl.setHId(order.getId());

			// Temporary
			orderDtl.setOrderNum (order.getOrderNum() + order.getQuote());
			// End Temporary.

			OrderDtlDataBase orderDtlDataBase = this.objectToObjectDatabase(orderDtl);
			orderDtlDataBase.write();

			IEnumerator enuCharges = orderDtl.getDtlChargesEnumerator();
			while (enuCharges.MoveNext())
			{
				OrderDtlCharge orderDtlCharge = (OrderDtlCharge)enuCharges.Current;
				orderDtlCharge.setHId (orderDtl.getHId());

				// Temporary
				orderDtlCharge.setOrderNum (orderDtl.getOrderNum());
				// End Temporary

				orderDtlCharge.setItemNum (orderDtl.getItemNum()); // Just in case.

				OrderDtlChargesDataBase orderDtlChargeDataBase = this.objectToObjectDatabase(orderDtlCharge);
				orderDtlChargeDataBase.write();
			}

			IEnumerator enuRels = orderDtl.getDtlRelsEnumerator();
			while (enuRels.MoveNext())
			{
				OrderDtlRel orderDtlRel = (OrderDtlRel)enuRels.Current;
				orderDtlRel.setHId (orderDtl.getHId());

				// Temporary
				orderDtlRel.setOrderNum (orderDtl.getOrderNum());
				// End Temporary

				orderDtlRel.setItemNum (orderDtl.getItemNum()); // Just in case.

				OrderDtlRelDataBase orderDtlRelDataBase = this.objectToObjectDatabase(orderDtlRel);
				orderDtlRelDataBase.write();
			}

			//detail notes
			IEnumerator enuNoteDtl = orderDtl.getNoteEnumerator();
			while (enuNoteDtl.MoveNext())
			{
				Note note = (Note)enuNoteDtl.Current;

				note.setKey1(order.getId());
				note.setKey2(orderDtl.getItemNum());

				NoteDataBase noteDataBase = this.objectToObjectDatabase(note);
				noteDataBase.write();
			}
		}

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

public
void writeOrderHeaderAndLines(Order order)
{
	try
	{		
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
	
		OrderHdrDataBase orderHdrDataBase = objectToObjectDatabase(order);
		OrderDtl			orderDtl=null;
		OrderDtlRel			orderDtlRel=null;
		OrderDtlCharge		orderDtlCharge=null;
		Note				note = null;
		int					j=0;
		int					iorder=0,iorderDtl=0;
		
		orderHdrDataBase.write();//write order header
	
		iorder = this.dataBaseAccess.getLastId();//get autonumeric inserted

		orderHdrDataBase.setOH_ID(iorder);
		if (orderHdrDataBase.getOH_OrderType() == Constants.ORDER_TYPE_ORDER)
			orderHdrDataBase.setOH_OrderNum(iorder);
		else
			orderHdrDataBase.setOH_Quote(iorder);		

		orderHdrDataBase.update();//update new order
		
		for (j=0; j < order.getCountNotes();j++)
		{		
			note = order.getNoteByIndex(j);		
	
			note.setKey1(iorder);					

			this.writeNote(note);//write note
		}

		for (int i=0; i < order.getCountLines(); i++)
		{
			orderDtl = order.getLineByIndex(i);			

			orderDtl.setHId(iorder);//set order id
			orderDtl.setOrderNum(iorder);

			this.writeOrderLine(orderDtl);//write detail

			iorderDtl = this.dataBaseAccess.getLastId();//get autonumeric inserted
			
			for (j=0; j < orderDtl.getCountLines();j++)
			{				
				orderDtlRel = orderDtl.getDltRelByIndex(j);
				orderDtlRel.setHId(iorder);					
				orderDtlRel.setOrderNum(iorder);
				orderDtlRel.setOrderDtlID(iorderDtl);

				this.writeOrderDetailRel(orderDtlRel);//write detail rel				
			}
			for (j=0; j < orderDtl.getCountCharges();j++)
			{					
				orderDtlCharge = orderDtl.getDltChargeByIndex(j);

				orderDtlCharge.setHId(iorder);	//set order id	
				orderDtlCharge.setOrderNum(iorder);

				this.writeOrderDetailCharge(orderDtlCharge);//write detail charge				
			}
			//notes
			for (j=0; j < orderDtl.getCountNotes();j++)
			{		
				note = orderDtl.getNoteByIndex(j);		
		
				note.setKey1(iorder);					

				this.writeNote(note);//write note
			}
		}

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();	
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a Order object
/// </summary>
/// <param name="proccess"></param>
public
void updateOrderHeader(Order order){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderHdrDataBase orderHdrDataBase = objectToObjectDatabase(order);
		
		orderHdrDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

public void updateCompleteOrder(Order order)
{
	try
	{
		this.FillRedundancies (order);
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderHdrDataBase orderHdrDataBase = objectToObjectDatabase (order);

		orderHdrDataBase.update();

		// Delete All Charges
		OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);
		orderDtlChargeDataBase.setOH_ID(order.getId());
		orderDtlChargeDataBase.deleteAllFromHeader();

		// Delete All Rels
		OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);
		orderDtlRelDataBase.setOH_ID(order.getId());
		orderDtlRelDataBase.deleteAllFromHeader();
		
		// Delete All Dtls
		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
		orderDtlDataBase.setOH_ID(order.getId());
		orderDtlDataBase.deleteAllFromHeader();

		//Delete All From notes		
		NoteDataBase noteDataBase = new NoteDataBase(dataBaseAccess);
		noteDataBase.setN_Key1(order.getId());		
		noteDataBase.setN_Key2(int.MinValue);		
		noteDataBase.setN_Key3(int.MinValue);		
		noteDataBase.setN_LineNum(int.MinValue);		
		noteDataBase.setN_Type(Constants.NOTE_TYPE_ORDER);//order
		
		noteDataBase.deleteAllFromTypeKey();

		noteDataBase.setN_Type(Constants.NOTE_TYPE_ORDER_DTL);//order dtl
		noteDataBase.deleteAllFromTypeKey();
		

		orderDtlDataBase.setOH_ID(order.getId());
		orderDtlDataBase.deleteAllFromHeader();

		IEnumerator enuNote = order.getNoteEnumerator();
		while (enuNote.MoveNext())
		{
			Note note = (Note)enuNote.Current;

			note.setKey1(order.getId()); 
			noteDataBase = this.objectToObjectDatabase(note);
			noteDataBase.write();
		}

		IEnumerator enu = order.getLineEnumerator();
		while (enu.MoveNext())
		{
			OrderDtl orderDtl = (OrderDtl)enu.Current;
			orderDtl.setHId(order.getId());

			// Temporary
			orderDtl.setOrderNum (order.getOrderNum() + order.getQuote());
			// End Temporary.

			orderDtlDataBase = this.objectToObjectDatabase(orderDtl);
			orderDtlDataBase.write();

			IEnumerator enuCharges = orderDtl.getDtlChargesEnumerator();
			while (enuCharges.MoveNext())
			{
				OrderDtlCharge orderDtlCharge = (OrderDtlCharge)enuCharges.Current;
				orderDtlCharge.setHId (orderDtl.getHId());

				// Temporary
				orderDtlCharge.setOrderNum (orderDtl.getOrderNum());
				// End Temporary

				orderDtlCharge.setItemNum (orderDtl.getItemNum()); // Just in case.

				orderDtlChargeDataBase = this.objectToObjectDatabase(orderDtlCharge);
				orderDtlChargeDataBase.write();
			}

			IEnumerator enuRels = orderDtl.getDtlRelsEnumerator();
			while (enuRels.MoveNext())
			{
				OrderDtlRel orderDtlRel = (OrderDtlRel)enuRels.Current;
				orderDtlRel.setHId (orderDtl.getHId());

				// Temporary
				orderDtlRel.setOrderNum (orderDtl.getOrderNum());
				// End Temporary

				orderDtlRel.setItemNum (orderDtl.getItemNum()); // Just in case.

				orderDtlRelDataBase = this.objectToObjectDatabase(orderDtlRel);
				orderDtlRelDataBase.write();
			}

			//detail notes
			IEnumerator enuNoteDtl = orderDtl.getNoteEnumerator();
			while (enuNoteDtl.MoveNext())
			{
				Note note = (Note)enuNoteDtl.Current;

				note.setKey1(order.getId());
				note.setKey2(orderDtl.getItemNum());

				noteDataBase = this.objectToObjectDatabase(note);
				noteDataBase.write();
			}
		}

		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Delete a Order object
/// </summary>
/// <param name="proccess"></param>
public
void deleteOrderHeader(Order order){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);

		OrderDtl			orderDtl= new OrderDtl();
		OrderDtlRel			orderDtlRel= new OrderDtlRel();
		OrderDtlCharge		orderDtlCharge= new OrderDtlCharge();
		
		orderHdrDataBase.setOH_ID(order.getId());
		orderDtl.setHId(order.getId());//set order id to detail
		orderDtlRel.setHId(order.getId());//set order id to detail rel
		orderDtlCharge.setHId(order.getId());//set order id to detail charge

		//delete all details from this order
		OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);
		orderDtlRelDataBase.setOH_ID(order.getId());
		orderDtlRelDataBase.deleteAllFromHeader();

		//charges
		OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);
		orderDtlChargeDataBase.setOH_ID(order.getId());
		orderDtlChargeDataBase.deleteAllFromHeader();

		//details
		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
		orderDtlDataBase.setOH_ID(order.getId());
		orderDtlDataBase.deleteAllFromHeader();

		//notes
		//Delete All From notes		
		NoteDataBase noteDataBase = new NoteDataBase(dataBaseAccess);
		noteDataBase.setN_Key1(order.getId());		
		noteDataBase.setN_Key2(int.MinValue);		
		noteDataBase.setN_Key3(int.MinValue);		
		noteDataBase.setN_LineNum(int.MinValue);		
		noteDataBase.setN_Type(Constants.NOTE_TYPE_ORDER);//order
		
		noteDataBase.deleteAllFromTypeKey();

		noteDataBase.setN_Type(Constants.NOTE_TYPE_ORDER_DTL);//order dtl
		noteDataBase.deleteAllFromTypeKey();
						
		orderHdrDataBase.delete();
			
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

private 
Order objectDataBaseToObject(OrderHdrDataBase orderHdrDataBase)
{
	Order order = new Order();

	order.setId(orderHdrDataBase.getOH_ID());
	order.setDb(orderHdrDataBase.getOH_Db());
	order.setCompany(orderHdrDataBase.getOH_Company());
	order.setPlant(orderHdrDataBase.getOH_Plant());
	order.setOrderNum(orderHdrDataBase.getOH_OrderNum());
	order.setOrgId(orderHdrDataBase.getOH_OrgID());		
	order.setOrderDate(orderHdrDataBase.getOH_OrderDate());
	order.setOrderStatus(orderHdrDataBase.getOH_OrderStatus());
	order.setDistributionLoc(orderHdrDataBase.getOH_DistributionLoc());
	order.setOrderType(orderHdrDataBase.getOH_OrderType());
	order.setBillToNum(orderHdrDataBase.getOH_BillToNum());
	order.setBillToName(orderHdrDataBase.getOH_BillToName());
	order.setBillToAdd1(orderHdrDataBase.getOH_BillToAdd1());
	order.setBillToAdd2(orderHdrDataBase.getOH_BillToAdd2());
	order.setBillToAdd3(orderHdrDataBase.getOH_BillToAdd3());
	order.setBillToAdd4(orderHdrDataBase.getOH_BillToAdd4());
	order.setBillToAdd5(orderHdrDataBase.getOH_BillToAdd5());
	order.setBillToAdd6(orderHdrDataBase.getOH_BillToAdd6());
	order.setBillToZipCode(orderHdrDataBase.getOH_BillToZipCode());
	order.setAttention(orderHdrDataBase.getOH_Attention());
	order.setTerms(orderHdrDataBase.getOH_Terms());
	order.setShipVia(orderHdrDataBase.getOH_ShipVia());
	order.setPO(orderHdrDataBase.getOH_PO());
	order.setQuote(orderHdrDataBase.getOH_Quote());
	order.setCurrency(orderHdrDataBase.getOH_Currency());
	order.setSalesPerson(orderHdrDataBase.getOH_SalesPerson());
	order.setComPercent(orderHdrDataBase.getOH_ComPercent());
	order.setComRate(orderHdrDataBase.getOH_ComRate());
	order.setDateRequest(orderHdrDataBase.getOH_DateRequest());
	order.setDatePromise(orderHdrDataBase.getOH_DatePromise());
	order.setDateShip(orderHdrDataBase.getOH_DateShip());
	order.setDateConfirm(orderHdrDataBase.getOH_DateConfirm());
	order.setDateCancel(orderHdrDataBase.getOH_DateCancel());
	order.setProdDate(orderHdrDataBase.getOH_ProdDate());
	order.setTerritory(orderHdrDataBase.getOH_Territory());
	order.setHoldStatus(orderHdrDataBase.getOH_HoldStatus());
	order.setShipComplete(orderHdrDataBase.getOH_ShipComplete());
	order.setOrderTotal(orderHdrDataBase.getOH_OrderTotal());
	order.setOrderNet(orderHdrDataBase.getOH_OrderNet());
	order.setTax1Total(orderHdrDataBase.getOH_Tax1Total());
	order.setTax2Total(orderHdrDataBase.getOH_Tax2Total());
	order.setTax3Total(orderHdrDataBase.getOH_Tax3Total());
	order.setDiscountTot(orderHdrDataBase.getOH_DiscountTot());
	order.setCommissTot(orderHdrDataBase.getOH_CommissTot());
	order.setRoyaltyTot(orderHdrDataBase.getOH_RoyaltyTot());
	order.setSynchronized(orderHdrDataBase.getOH_Synchronized());
	order.setOrgOrderType(orderHdrDataBase.getOH_OrgOrderType());
	order.setRetailProductType(orderHdrDataBase.getOH_RetailProductType());
	order.setSentToCMS(orderHdrDataBase.getOH_SentToCMS());
	order.setSentUser(orderHdrDataBase.getOH_SentUser());
	order.setSentDateTime(orderHdrDataBase.getOH_SentDateTime());
	order.setErpOrdNum(orderHdrDataBase.getOH_ErpOrderNum());
	
	return order;
}


private 
OrderHdrDataBase objectToObjectDatabase(Order order)
{
	OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);		

	orderHdrDataBase.setOH_ID(order.getId());
	orderHdrDataBase.setOH_Db(order.getDb());
	orderHdrDataBase.setOH_Company(order.getCompany());
	orderHdrDataBase.setOH_Plant(order.getPlant());
	orderHdrDataBase.setOH_OrderNum(order.getOrderNum());
	orderHdrDataBase.setOH_OrgID(order.getOrgId());		
	orderHdrDataBase.setOH_OrderDate(order.getOrderDate());
	orderHdrDataBase.setOH_OrderStatus(order.getOrderStatus());
	orderHdrDataBase.setOH_DistributionLoc(order.getDistributionLoc());
	orderHdrDataBase.setOH_OrderType(order.getOrderType());
	orderHdrDataBase.setOH_BillToNum(order.getBillToNum());
	orderHdrDataBase.setOH_BillToName(order.getBillToName());
	orderHdrDataBase.setOH_BillToAdd1(order.getBillToAdd1());
	orderHdrDataBase.setOH_BillToAdd2(order.getBillToAdd2());
	orderHdrDataBase.setOH_BillToAdd3(order.getBillToAdd3());
	orderHdrDataBase.setOH_BillToAdd4(order.getBillToAdd4());
	orderHdrDataBase.setOH_BillToAdd5(order.getBillToAdd5());
	orderHdrDataBase.setOH_BillToAdd6(order.getBillToAdd6());
	orderHdrDataBase.setOH_BillToZipCode(order.getBillToZipCode());
	orderHdrDataBase.setOH_Attention(order.getAttention());
	orderHdrDataBase.setOH_Terms(order.getTerms());
	orderHdrDataBase.setOH_ShipVia(order.getShipVia());
	orderHdrDataBase.setOH_PO(order.getPO());
	orderHdrDataBase.setOH_Quote(order.getQuote());
	orderHdrDataBase.setOH_Currency(order.getCurrency());
	orderHdrDataBase.setOH_SalesPerson(order.getSalesPerson());
	orderHdrDataBase.setOH_ComPercent(order.getComPercent());
	orderHdrDataBase.setOH_ComRate(order.getComRate());
	orderHdrDataBase.setOH_DateRequest(order.getDateRequest());
	orderHdrDataBase.setOH_DatePromise(order.getDatePromise());
	orderHdrDataBase.setOH_DateShip(order.getDateShip());
	orderHdrDataBase.setOH_DateConfirm(order.getDateConfirm());
	orderHdrDataBase.setOH_DateCancel(order.getDateCancel());
	orderHdrDataBase.setOH_ProdDate(order.getProdDate());
	orderHdrDataBase.setOH_Territory(order.getTerritory());
	orderHdrDataBase.setOH_HoldStatus(order.getHoldStatus());
	orderHdrDataBase.setOH_ShipComplete(order.getShipComplete());
	orderHdrDataBase.setOH_OrderTotal(order.getOrderTotal());
	orderHdrDataBase.setOH_OrderNet(order.getOrderNet());
	orderHdrDataBase.setOH_Tax1Total(order.getTax1Total());
	orderHdrDataBase.setOH_Tax2Total(order.getTax2Total());
	orderHdrDataBase.setOH_Tax3Total(order.getTax3Total());
	orderHdrDataBase.setOH_DiscountTot(order.getDiscountTot());
	orderHdrDataBase.setOH_CommissTot(order.getCommissTot());
	orderHdrDataBase.setOH_RoyaltyTot(order.getRoyaltyTot());
	orderHdrDataBase.setOH_Synchronized(order.getSynchronized());
	orderHdrDataBase.setOH_OrgOrderType(order.getOrgOrderType());
	orderHdrDataBase.setOH_RetailProductType(order.getRetailProductType());
	orderHdrDataBase.setOH_SentToCMS(order.getSentToCMS());
	orderHdrDataBase.setOH_SentUser(order.getSentUser());
	orderHdrDataBase.setOH_SentDateTime(order.getSentDateTime());
	orderHdrDataBase.setOH_ErpOrderNum(order.getErpOrdNum());
	
	return orderHdrDataBase;		
}

#if !POCKET_PC
public
bool sendOrderToCMS(Order order, string user){

	bool		bresult=true;

	try{
		OrderDtl	orderDtlAux = null;
		OrderDtlRel	orderDtlRelAux = null;
		
		orderDtlAux = order.getLineByIndex(0);//first line
		orderDtlRelAux = orderDtlAux.getDltRelByIndex(0);
		
		string p0_Mode = "AQ";//'AQ'  Quote,'DQ' Delete Quote y 'UQ' Update Quote.
		string p0_Order = "";
		string p0_BillCust = order.getBillToNum();
		string p0_BContact = ""; // esto no va mas ->> order.getBillToName();
		string p0_BCustPhone = orderDtlRelAux.getPhoneNum();
// medida temporal		string p0_ShipCust = orderDtlRelAux.getShipToNum();
string p0_ShipCust = p0_BillCust;
// medida temporal		string p0_SCustName = orderDtlRelAux.getShipToName();
string p0_SCustName = order.getBillToName();

		string p0_SCustAdd1 = orderDtlRelAux.getShipToAdd1();
		string p0_SCustAdd2 = orderDtlRelAux.getShipToAdd2();
		string p0_SCustAdd3 = orderDtlRelAux.getShipToAdd3();
		string p0_SCustAdd4 = orderDtlRelAux.getShipToAdd4();

// medida temporal		string p0_SCustPC = orderDtlRelAux.getShipPostZip();//codigo postal del Shipping Customer.
string p0_SCustPC = order.getBillToZipCode();

		string p0_Carrier = order.getShipVia();
		string p0_Service = "";
		string p0_PO = order.getPO();
//		string p0_Notes = order.getAttention();
		string p0_Notes = order.getShipVia();
		string p0_IbmAuth = "";
		string p0_Attention = order.getAttention();
		string p0_ShipComp = Constants.STRING_NO;
		string p0_AllowBO = Constants.STRING_YES;
		
		string		p0_FrtExempt = "";
		int		    p0_RtnArrayQty = 0;
		string		p0_OptionLst = "";
		string		p0_Parts = "";
		string		p0_PrcUnits = "";
		string		p0_Prices = "";
		string		p0_Qtys = "";
		string		p0_DisAmt = "";
		string		p0_DisCode = "";
		string		p0_Cost = "";
		string		p0_FrtAmt = "";
		string		p0_PartType = "";
		string		p0_RtnCode = "";		
				
		bool		bheaderCreated=false;
	
		// init a new transaction
		this.beginTransaction();
//p0_Mode = "DB"; // for debug in AS400
		if (dataBaseAccess.sendOrderHeaderToCMS(p0_Mode, out p0_Order, p0_BillCust, p0_BContact, p0_BCustPhone, 
			p0_ShipCust, p0_SCustName, p0_SCustAdd1, p0_SCustAdd2, p0_SCustAdd3, p0_SCustAdd4,
			p0_SCustPC, p0_Carrier, p0_Service, p0_PO, p0_Notes, p0_IbmAuth, p0_Attention, 
			p0_ShipComp, p0_AllowBO)){

			// Order Header sent OK 
			bheaderCreated=true;
			order.setSentToCMS(Constants.STRING_YES);
			order.setErpOrdNum(p0_Order);
			order.setSentUser(user);
			order.setSentDateTime(DateTime.Now);
			this.updateOrderHeader(order);
		}else{
			bresult = false;
		}

		// 100 for filler
		for(int i = 0; bresult && i < 100; i++){
			OrderDtl orderDtl = order.getLineByIndex(i);
			if (orderDtl != null){
				orderDtl.setErpOrderNum("");//initialize , like can not send
				
				string auxDisCode = "";
				for(int j = 0; j < orderDtl.getCountCharges(); j++){
					OrderDtlCharge orderDtlCharge = orderDtl.getDltChargeByIndex(j);
					auxDisCode = orderDtlCharge.getChargeCode();
				}
			
				p0_DisCode += StringUtil.AddChar(auxDisCode, ' ', 4, true);

				p0_OptionLst += StringUtil.AddChar("", ' ', 7, false);
				p0_Parts += StringUtil.AddChar(orderDtl.getProdID(), ' ', 20, true);

				p0_PrcUnits += StringUtil.AddChar(orderDtl.getQtyOrdUom(), ' ', 3, true);

				string unitPrice = NumberUtil.toString(orderDtl.getUnitPrice());
				p0_Prices += StringUtil.AddChar(unitPrice, ' ', 10, false);
				
				string becareful = orderDtl.getQtyOrdSum().ToString();
				int qtyAux = decimal.ToInt32(decimal.Parse(becareful));
				p0_Qtys += StringUtil.AddChar(qtyAux.ToString(), ' ', 6, false);

				string totDisc = NumberUtil.toString(orderDtl.getTotalDiscounts());
				p0_DisAmt += StringUtil.AddChar(totDisc, ' ', 10, false);//becareful!!		

				p0_Cost += StringUtil.AddChar(p0_Cost, ' ', 10, false);//becareful!!
				p0_FrtAmt += StringUtil.AddChar("", ' ', 10, false);
				p0_PartType += StringUtil.AddSpaces("", 1, true);
			}else{
				p0_DisCode += StringUtil.AddChar("", ' ', 4, true);
				p0_OptionLst += StringUtil.AddChar("", ' ', 7, false);
				p0_Parts += StringUtil.AddChar("", ' ', 20, true);
				p0_PrcUnits += StringUtil.AddChar("", ' ', 3, true);
				p0_Prices += StringUtil.AddChar("", ' ', 10, false);
				p0_Qtys += StringUtil.AddChar("", ' ', 6, false);
				p0_DisAmt += StringUtil.AddChar("", ' ', 10, false);
				p0_Cost += StringUtil.AddChar("", ' ', 10, false);
				p0_FrtAmt += StringUtil.AddChar("", ' ', 10, false);
				p0_PartType += StringUtil.AddSpaces("", 1, true);
			}
		}

		p0_FrtExempt = "N";
		p0_RtnArrayQty = order.getCountLines();
		p0_RtnCode = " ";
		p0_Mode = "AQ";
//p0_Mode = "DB"; // for debug in AS400
		if (dataBaseAccess.sendOrderLineToCMS(p0_Mode, p0_Order, p0_FrtExempt, p0_RtnArrayQty,
				p0_OptionLst, p0_Parts, p0_PrcUnits, p0_Prices, p0_Qtys, p0_DisAmt,
				p0_DisCode, p0_Cost, p0_FrtAmt, p0_PartType, p0_RtnCode)){

			for(int z = 0; bresult && z < order.getCountLines(); z++){
				OrderDtl orderDtl = order.getLineByIndex(z);
			
				orderDtl.setErpOrderNum(p0_Order);
				orderDtl.setErpOrderItemNum(z);
				this.updateOrderLine(orderDtl);
			}
		}else{ // error
			bresult = false;
		}
		
		if (bresult){ // transaction OK
			this.commitTransaction();
		}else{ // ERROR, have to delete all records in CMS
			this.rollbackTransaction();

			if (bheaderCreated){

				p0_Mode="DO";//del order detail
				
				for(int x = 0; bresult && x < order.getCountLines(); x++){
						
					OrderDtl orderDtl = order.getLineByIndex(x);
					/*
					dataBaseAccess.sendOrderLineToCMS(	p0_Mode,
														p0_Order,
														p0_FrtExempt,
														p0_RtnArrayQty,
														p0_OptionLst,
														p0_Parts,
														p0_PrcUnits,
														p0_Prices,
														p0_Qtys,
														p0_DisAmt,
														p0_DisCode,
														p0_Cost,
														p0_FrtAmt,
														p0_PartType,
														p0_RtnCode,
														out  cmsOrderLineID);
					*/									
				}
			}
		}
	}catch(System.Exception exc){
		bresult = false;
		throw new NujitException(exc.Message);
	}

	return bresult;

}
#endif

private void FillRedundancies (Order order)
{
	IEnumerator enu = order.getLineEnumerator();
	while (enu.MoveNext())
	{
		OrderDtl orderDtl = (OrderDtl)enu.Current;

		orderDtl.setHId (order.getId());
		orderDtl.setCompany(order.getCompany());
		orderDtl.setCustPO(order.getPO());
		orderDtl.setErpOrderNum(order.getErpOrdNum());
		orderDtl.setOrderNum (order.getOrderNum());
		orderDtl.setOrgId (order.getOrgId());
		orderDtl.setPlant (order.getPlant());
		FillRedundancies (orderDtl, order);
	}
	order.recalculate();
}

private void FillRedundancies (OrderDtl orderDtl, Order order)
{
	IEnumerator enu = orderDtl.getDtlChargesEnumerator();
	while (enu.MoveNext())
	{
		OrderDtlCharge orderDtlCharge = (OrderDtlCharge)enu.Current;

		orderDtlCharge.setOrderNum (orderDtl.getOrderNum());
	}
	enu = orderDtl.getDtlRelsEnumerator();
	while (enu.MoveNext())
	{
		OrderDtlRel orderDtlRel = (OrderDtlRel)enu.Current;

		orderDtlRel.setOrderNum (orderDtl.getOrderNum());
		orderDtlRel.setPlant (orderDtl.getPlant());
		orderDtlRel.setProdDescription (orderDtl.getProdDescription());
		orderDtlRel.setOrgId (orderDtl.getOrgId());
		orderDtlRel.setOrgItemNum (orderDtl.getOrgItemNum());
		orderDtlRel.setCompany (orderDtl.getCompany());
		orderDtlRel.setAttention (order.getAttention());
	}
}

public 
Order createOrder(){
	return new Order();
}

//////////////////////////////////////////////////////////////////////////////////
//								ORDER DTL										//
//////////////////////////////////////////////////////////////////////////////////

public OrderDtl	readIfProductSold(string sprodId)
{
	try
	{
		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
					
		if (!orderDtlDataBase.readIfProductSold(sprodId))
			return null;
		
		OrderDtl orderDtl = objectDataBaseToObject(orderDtlDataBase);
				
		return orderDtl;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public int getMaxOrderLine(int iorder)
{
	try
	{
		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
		
		orderDtlDataBase.setOH_ID(iorder);	
		
		return orderDtlDataBase.getMaxOrderLine();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}
public
string[][] getOrderLinesById(int iorder){
	try
	{
		OrderDtlDataBaseContainer orderDtlDataBaseContainer= new OrderDtlDataBaseContainer(dataBaseAccess);	
		orderDtlDataBaseContainer.readByOHeaderNumber(iorder);

				
		string[][] items = new String[orderDtlDataBaseContainer.Count][];
		int i= 0;

		IEnumerator iEnum = orderDtlDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			OrderDtlDataBase orderDtlDataBase = (OrderDtlDataBase)iEnum.Current;		

			string[] item = new String[7];

			item[0] =orderDtlDataBase.getOH_ID().ToString();
			item[1] =orderDtlDataBase.getOD_ItemNum().ToString();			
			item[2] =orderDtlDataBase.getOD_ProdID();
			item[3] =orderDtlDataBase.getOD_ProdDescription();			
			item[4] =orderDtlDataBase.getOD_UnitPrice().ToString();
			item[5] =orderDtlDataBase.getOD_QtyOrdSum().ToString();			
			item[6] =orderDtlDataBase.getOD_DateAdded().ToString();

			items[i] = item;
			i++;
		}
		return items;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}
public
Order getOrderLinesById(Order order)
{
	try
	{
		OrderDtlDataBaseContainer orderDtlDataBaseContainer= new OrderDtlDataBaseContainer(dataBaseAccess);	
		orderDtlDataBaseContainer.readByOHeaderNumber(order.getId());
		
		string[][] items = new String[orderDtlDataBaseContainer.Count][];
		

		IEnumerator iEnum = orderDtlDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){

			OrderDtlDataBase orderDtlDataBase = (OrderDtlDataBase)iEnum.Current;		
			
			OrderDtl orderDtl = objectDataBaseToObject(orderDtlDataBase);
							
			order.addLine(orderDtl);
			
		}
		return order;
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public 
OrderDtl readLineByProductId(int iorder,string sprodID)
{
	try
	{
		OrderDtlDataBaseContainer orderDtlDataBaseContainer= new OrderDtlDataBaseContainer(dataBaseAccess);	
		orderDtlDataBaseContainer.readByProductId(iorder,sprodID);
		
		string[][] items = new String[orderDtlDataBaseContainer.Count][];
		int i= 0;
		OrderDtl orderDtl = null;

		IEnumerator iEnum = orderDtlDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){

			OrderDtlDataBase orderDtlDataBase = (OrderDtlDataBase)iEnum.Current;		
			
			orderDtl = objectDataBaseToObject(orderDtlDataBase);

			i++;
		}
		return orderDtl;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Return if exists a OrderDtl
/// </summary>
/// <param name="OrderLineCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsOrderLine(int iorder,int item){
	try
	{
		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);

		orderDtlDataBase.setOH_ID(iorder);
		orderDtlDataBase.setOD_ItemNum(item);

		return orderDtlDataBase.exists();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Read and return a OrderDtl object
/// </summary>
/// <param name="OrderLineCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
OrderDtl readOrderLine(int iorder,int item){
	try
	{
		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
			
		orderDtlDataBase.setOH_ID(iorder);
		orderDtlDataBase.setOD_ItemNum(item);

		if (!orderDtlDataBase.exists())
			return null;

		orderDtlDataBase.read();
		
		OrderDtl orderDtl = objectDataBaseToObject(orderDtlDataBase);
				
		return orderDtl;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Write to the database a OrderDtl object
/// </summary>
/// <param name="proccess"></param>
private
void writeOrderLine(OrderDtl orderDtl){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlDataBase orderDtlDataBase  = objectToObjectDatabase(orderDtl);
		
		orderDtlDataBase.write();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a OrderDtl object
/// </summary>
/// <param name="proccess"></param>
private
void updateOrderLine(OrderDtl orderDtl){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlDataBase orderDtlDataBase  = objectToObjectDatabase(orderDtl);

		orderDtlDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Delete a OrderDtl object
/// </summary>
/// <param name="proccess"></param>
private
void deleteOrderLine(OrderDtl orderDtl){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);

		orderDtlDataBase.setOH_ID(orderDtl.getHId());
		orderDtlDataBase.setOD_ItemNum(orderDtl.getItemNum());
		
		orderDtlDataBase.delete();
			
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

private
void deleteOrderLinesFromHeader(OrderDtl orderDtl)
{
	try
	{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);

		orderDtlDataBase.setOH_ID(orderDtl.getHId());
		
		orderDtlDataBase.deleteAllFromHeader();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

private 
OrderDtl objectDataBaseToObject(OrderDtlDataBase orderDtlDataBase)
{
	OrderDtl orderDtl= new OrderDtl();

	orderDtl.setHId(orderDtlDataBase.getOH_ID());
	orderDtl.setId(orderDtlDataBase.getOD_ID());
	orderDtl.setDb(orderDtlDataBase.getOD_Db());
	orderDtl.setCompany(orderDtlDataBase.getOD_Company());
	orderDtl.setPlant(orderDtlDataBase.getOD_Plant());
	orderDtl.setOrderNum(orderDtlDataBase.getOD_OrderNum());
	orderDtl.setItemNum(orderDtlDataBase.getOD_ItemNum());	
	orderDtl.setOrgId(orderDtlDataBase.getOD_OrgID());
	orderDtl.setOrgItemNum(orderDtlDataBase.getOD_OrgItemNum());
	orderDtl.setProdID(orderDtlDataBase.getOD_ProdID());
	orderDtl.setProdDescription(orderDtlDataBase.getOD_ProdDescription());
	orderDtl.setSeq(orderDtlDataBase.getOD_Seq());
	orderDtl.setInternalRef(orderDtlDataBase.getOD_InternalRef());
	orderDtl.setCustPart(orderDtlDataBase.getOD_CustPart());
	orderDtl.setCustPO(orderDtlDataBase.getOD_CustPO());
	orderDtl.setQtyOrdSum(orderDtlDataBase.getOD_QtyOrdSum());
	orderDtl.setQtyShippedSum(orderDtlDataBase.getOD_QtyShippedSum());
	orderDtl.setQtyOrdUom(orderDtlDataBase.getOD_QtyOrdUom());
	orderDtl.setUnitPrice(orderDtlDataBase.getOD_UnitPrice());
	orderDtl.setUnitPriceUom(orderDtlDataBase.getOD_UnitPriceUom());
	orderDtl.setItemNetTotal(orderDtlDataBase.getOD_ItemNetTotal());
	orderDtl.setDateAdded(orderDtlDataBase.getOD_DateAdded());
	orderDtl.setTotalDiscounts(orderDtlDataBase.getOD_TotalDiscounts());
	orderDtl.setTotalPromo(orderDtlDataBase.getOD_TotalPromo());
	orderDtl.setTotalRoyalty(orderDtlDataBase.getOD_TotalRoyalty());
	orderDtl.setTotalFreight(orderDtlDataBase.getOD_TotalFreight());
	orderDtl.setTotalTax(orderDtlDataBase.getOD_TotalTax());
	orderDtl.setTotalStTax(orderDtlDataBase.getOD_TotalStTax());
	orderDtl.setTotalFedTax(orderDtlDataBase.getOD_TotalFedTax());	
	orderDtl.setErpOrderNum(orderDtlDataBase.getOD_ErpOrderNum());
	orderDtl.setErpOrderItemNum(orderDtlDataBase.getOD_ErpOrderItemNum());
	orderDtl.setQtyPackSize(orderDtlDataBase.getOD_QtyPackSize());
	orderDtl.setCost(orderDtlDataBase.getOD_Cost());	
	orderDtl.setCondition(orderDtlDataBase.getOD_Condition());	
	orderDtl.setProject(orderDtlDataBase.getOD_Project());	

	return orderDtl;
}


protected 
OrderDtlDataBase objectToObjectDatabase(OrderDtl orderDtl)
{
	OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);		

	orderDtlDataBase.setOH_ID(orderDtl.getHId());
	orderDtlDataBase.setOD_ID(orderDtl.getId());
	orderDtlDataBase.setOD_Db(orderDtl.getDb());
	orderDtlDataBase.setOD_Company(orderDtl.getCompany());
	orderDtlDataBase.setOD_Plant(orderDtl.getPlant());
	orderDtlDataBase.setOD_OrderNum(orderDtl.getOrderNum());
	orderDtlDataBase.setOD_ItemNum(orderDtl.getItemNum());	
	orderDtlDataBase.setOD_OrgID(orderDtl.getOrgId());
	orderDtlDataBase.setOD_OrgItemNum(orderDtl.getOrgItemNum());
	orderDtlDataBase.setOD_ProdID(orderDtl.getProdID());
	orderDtlDataBase.setOD_ProdDescription(orderDtl.getProdDescription());
	orderDtlDataBase.setOD_Seq(orderDtl.getSeq());
	orderDtlDataBase.setOD_InternalRef(orderDtl.getInternalRef());
	orderDtlDataBase.setOD_CustPart(orderDtl.getCustPart());
	orderDtlDataBase.setOD_CustPO(orderDtl.getCustPO());
	orderDtlDataBase.setOD_QtyOrdSum(orderDtl.getQtyOrdSum());
	orderDtlDataBase.setOD_QtyShippedSum(orderDtl.getQtyShippedSum());
	orderDtlDataBase.setOD_QtyOrdUom(orderDtl.getQtyOrdUom());
	orderDtlDataBase.setOD_UnitPrice(orderDtl.getUnitPrice());
	orderDtlDataBase.setOD_UnitPriceUom(orderDtl.getUnitPriceUom());
	orderDtlDataBase.setOD_ItemNetTotal(orderDtl.getItemNetTotal());
	orderDtlDataBase.setOD_DateAdded(orderDtl.getDateAdded());
	orderDtlDataBase.setOD_TotalDiscounts(orderDtl.getTotalDiscounts());
	orderDtlDataBase.setOD_TotalPromo(orderDtl.getTotalPromo());
	orderDtlDataBase.setOD_TotalRoyalty(orderDtl.getTotalRoyalty());
	orderDtlDataBase.setOD_TotalFreight(orderDtl.getTotalFreight());
	orderDtlDataBase.setOD_TotalTax(orderDtl.getTotalTax());
	orderDtlDataBase.setOD_TotalStTax(orderDtl.getTotalStTax());
	orderDtlDataBase.setOD_TotalFedTax(orderDtl.getTotalFedTax());		
	orderDtlDataBase.setOD_ErpOrderNum(orderDtl.getErpOrderNum());
	orderDtlDataBase.setOD_ErpOrderItemNum(orderDtl.getErpOrderItemNum());
	orderDtlDataBase.setOD_QtyPackSize(orderDtl.getQtyPackSize());
	orderDtlDataBase.setOD_Cost(orderDtl.getCost());	
	orderDtlDataBase.setOD_Condition(orderDtl.getCondition());	
	orderDtlDataBase.setOD_Project(orderDtl.getProject());	

	return orderDtlDataBase;
}

public
OrderDtl createOrderDtl() {
	return new OrderDtl();
}

//////////////////////////////////////////////////////////////////////////////////
//							ORDER DTL CHARGE									//
//////////////////////////////////////////////////////////////////////////////////

public int getMaxItemFromDetailCharge(int iorder, int itemNum)
{
	try
	{
		OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);
		
		orderDtlChargeDataBase.setOH_ID(iorder);		
		orderDtlChargeDataBase.setODC_ItemNum(itemNum);		
		
		return orderDtlChargeDataBase.getMaxItemFromDetailCharges();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public
OrderDtlCharge createOrderDtlCharge() {
	return new OrderDtlCharge();
}

//////////////////////////////////////////////////////////////////////////////////
//								ORDER DTL REL									//
//////////////////////////////////////////////////////////////////////////////////

public int getMaxItemFromDetail(OrderDtlRel orderDtlRel)
{
	try
	{
		OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);
		
		orderDtlRelDataBase.setOH_ID(orderDtlRel.getHId());		
		orderDtlRelDataBase.setODR_ItemNum(orderDtlRel.getItemNum());		
		
		return orderDtlRelDataBase.getMaxItemFromDetailRel();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}
public
string[][] getOrderDetailRelById(OrderDtlRel orderDtlRel){
	try
	{
		OrderDtlRelDataBaseContainer orderDtlRelDataBaseContainer= new OrderDtlRelDataBaseContainer(dataBaseAccess);	
		orderDtlRelDataBaseContainer.readByOHeaderNumber(orderDtlRel.getHId(),orderDtlRel.getItemNum());

		string[][] items = new string[orderDtlRelDataBaseContainer.Count][];
		int i = 0;

		IEnumerator iEnum = orderDtlRelDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			OrderDtlRelDataBase orderDtlRelDataBase = (OrderDtlRelDataBase)iEnum.Current;		

			string[] item = new String[7];

			item[0] =orderDtlRelDataBase.getOH_ID().ToString();
			item[1] =orderDtlRelDataBase.getODR_ItemNum().ToString();			/*
			item[2] =orderDtlRelDataBase.getOD_ProdID();
			item[3] =orderDtlRelDataBase.getOD_ProdDescription();			
			item[4] =orderDtlRelDataBase.getOD_UnitPrice().ToString();
			item[5] =orderDtlRelDataBase.getOD_QtyOrdSum().ToString();			
			item[6] =orderDtlRelDataBase.getOD_DateAdded().ToString();*/

			items[i] = item;
			i++;
		}
		return items;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}
	
/// <summary>
/// Return if exists a OrderDtlRel
/// </summary>
/// <param name="OrderLineCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsOrderDetailRel(OrderDtlRel orderDtlRel){
	try
	{
		OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);

		orderDtlRelDataBase.setOH_ID(orderDtlRel.getHId());		
		orderDtlRelDataBase.setODR_ItemNum(orderDtlRel.getItemNum());		
		orderDtlRelDataBase.setODR_ItemNumRel(orderDtlRel.getItemNumRel());

		return orderDtlRelDataBase.exists();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}


/// <summary>
/// Read and return a OrderDtlRel object
/// </summary>
/// <param name="OrderLineCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
OrderDtlRel readOrderDetailRel(OrderDtlRel orderDtlRelCons){	
	try
	{
		OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);

		orderDtlRelDataBase.setOH_ID(orderDtlRelCons.getHId());		
		orderDtlRelDataBase.setODR_ItemNum(orderDtlRelCons.getItemNum());		
		orderDtlRelDataBase.setODR_ItemNumRel(orderDtlRelCons.getItemNumRel());

		if (!orderDtlRelDataBase.exists())
			return null;

		orderDtlRelDataBase.read();
		
		//orderDtlRelDataBase to orderDtlRel
		OrderDtlRel orderDtlRel= objectDataBaseToObject(orderDtlRelDataBase);
				
		return orderDtlRel;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public 
OrderDtl getOrderDetailRelById(OrderDtl orderDtl)
{
	try
	{
		OrderDtlRelDataBaseContainer orderDtlRelDataBaseContainer= new OrderDtlRelDataBaseContainer(dataBaseAccess);	
		orderDtlRelDataBaseContainer.readByOHeaderNumber(orderDtl.getHId(),orderDtl.getItemNum());
			
		IEnumerator iEnum = orderDtlRelDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){

			OrderDtlRelDataBase orderDtlRelDataBase = (OrderDtlRelDataBase)iEnum.Current;		
			
			//orderDtlRelDataBase to orderDtlRel
			OrderDtlRel orderDtlRel= objectDataBaseToObject(orderDtlRelDataBase);
							
			orderDtl.addDtlRel(orderDtlRel);			
		}
		return orderDtl;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Write to the database a OrderDtlRel object
/// </summary>
/// <param name="proccess"></param>
private
void writeOrderDetailRel(OrderDtlRel orderDtlRel){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		//orderDtlRel to orderDtlRelDataBase
		OrderDtlRelDataBase orderDtlRelDataBase = objectToObjectDatabase(orderDtlRel);
		
		orderDtlRelDataBase.write();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a OrderDtlRel object
/// </summary>
/// <param name="proccess"></param>
private
void updateOrderDetailRel(OrderDtlRel orderDtlRel){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		//orderDtlRel to orderDtlRelDataBase
		OrderDtlRelDataBase orderDtlRelDataBase = objectToObjectDatabase(orderDtlRel);
		
		orderDtlRelDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

private
void updateOrderDetailRelFromHeader(OrderDtlRel orderDtlRel){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		//orderDtlRel to orderDtlRelDataBase
		OrderDtlRelDataBase orderDtlRelDataBase = objectToObjectDatabase(orderDtlRel);
		
		orderDtlRelDataBase.updateAllFromHeader();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Delete a OrderDtlRel object
/// </summary>
/// <param name="proccess"></param>
private
void deleteOrderDetailRelFromDetail(OrderDtlRel orderDtlRel){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);

		orderDtlRelDataBase.setOH_ID(orderDtlRel.getHId());
		orderDtlRelDataBase.setODR_ItemNum(orderDtlRel.getItemNum());
		
		orderDtlRelDataBase.deleteFromDetail();
			
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

private
void deleteOrderDetailRelFromHeader(OrderDtlRel orderDtlRel)
{
	try
	{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);

		orderDtlRelDataBase.setOH_ID(orderDtlRel.getHId());
		
		orderDtlRelDataBase.deleteAllFromHeader();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

private 
OrderDtlRel objectDataBaseToObject(OrderDtlRelDataBase orderDtlRelDataBase)
{
	OrderDtlRel orderDtlRel = new OrderDtlRel();

	orderDtlRel.setHId(orderDtlRelDataBase.getOH_ID());
	orderDtlRel.setId(orderDtlRelDataBase.getODR_ID());
	orderDtlRel.setDb(orderDtlRelDataBase.getODR_Db());
	orderDtlRel.setCompany(orderDtlRelDataBase.getODR_Company());
	orderDtlRel.setPlant(orderDtlRelDataBase.getODR_Plant());
	orderDtlRel.setOrderNum(orderDtlRelDataBase.getODR_OrderNum());
	orderDtlRel.setItemNum(orderDtlRelDataBase.getODR_ItemNum());
	orderDtlRel.setItemNumRel(orderDtlRelDataBase.getODR_ItemNumRel());
	orderDtlRel.setOrgId(orderDtlRelDataBase.getODR_OrgID());
	orderDtlRel.setOrgItemNum(orderDtlRelDataBase.getODR_OrgItemNum());
	orderDtlRel.setOrgItemNumRel(orderDtlRelDataBase.getODR_OrgItemNumRel());
	orderDtlRel.setShipToNum(orderDtlRelDataBase.getODR_ShipToNum());
	orderDtlRel.setShipToName(orderDtlRelDataBase.getODR_ShipToName());
	orderDtlRel.setShipToAdd1(orderDtlRelDataBase.getODR_ShipToAdd1());
	orderDtlRel.setShipToAdd2(orderDtlRelDataBase.getODR_ShipToAdd2());
	orderDtlRel.setShipToAdd3(orderDtlRelDataBase.getODR_ShipToAdd3());
	orderDtlRel.setShipToAdd4(orderDtlRelDataBase.getODR_ShipToAdd4());
	orderDtlRel.setShipToAdd5(orderDtlRelDataBase.getODR_ShipToAdd5());
	orderDtlRel.setShipToAdd6(orderDtlRelDataBase.getODR_ShipToAdd6());
	orderDtlRel.setShipPostZip(orderDtlRelDataBase.getODR_ShipToZipCode());
	orderDtlRel.setPhoneNum(orderDtlRelDataBase.getODR_PhoneNum());
	orderDtlRel.setAttention(orderDtlRelDataBase.getODR_Attention());
	orderDtlRel.setCustPO(orderDtlRelDataBase.getODR_CustPO());
	orderDtlRel.setQtyOrd(orderDtlRelDataBase.getODR_QtyOrd());
	orderDtlRel.setQtyOrdUom(orderDtlRelDataBase.getODR_QtyOrdUom());
	orderDtlRel.setQtyOrdInv(orderDtlRelDataBase.getODR_QtyOrdInv());
	orderDtlRel.setQtyOrdInvUom(orderDtlRelDataBase.getODR_QtyOrdInvUom());
	orderDtlRel.setQtyShipped(orderDtlRelDataBase.getODR_QtyShipped());
	orderDtlRel.setQtyShippedInv(orderDtlRelDataBase.getODR_QtyShippedInv());		
	orderDtlRel.setQtyBO(orderDtlRelDataBase.getODR_QtyBO());
	orderDtlRel.setQtyBOInv(orderDtlRelDataBase.getODR_QtyBOInv());
	orderDtlRel.setDatePromise(orderDtlRelDataBase.getOD_DatePromise());
	orderDtlRel.setDateRequest(orderDtlRelDataBase.getOD_DateRequest());
	orderDtlRel.setDateShipping(orderDtlRelDataBase.getOD_DateShipping());
	orderDtlRel.setDateCancel(orderDtlRelDataBase.getOD_DateCancel());
	orderDtlRel.setDateChanged(orderDtlRelDataBase.getOD_DateChanged());
	orderDtlRel.setDateNotBefore(orderDtlRelDataBase.getOD_DateNotBefore());
	orderDtlRel.setDateAdded(orderDtlRelDataBase.getOD_DateAdded());	
	orderDtlRel.setOrderDtlID(orderDtlRelDataBase.getODR_OrderDtlID());
	orderDtlRel.setProdDescription(orderDtlRelDataBase.getODR_ProdDescription());
	orderDtlRel.setCondition(orderDtlRelDataBase.getODR_Condition());
	orderDtlRel.setProject(orderDtlRelDataBase.getODR_Project());

	return orderDtlRel;
}

protected 
OrderDtlRelDataBase objectToObjectDatabase(OrderDtlRel orderDtlRel)
{
	OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);		

	orderDtlRelDataBase.setOH_ID(orderDtlRel.getHId());
	orderDtlRelDataBase.setODR_ID(orderDtlRel.getId());
	orderDtlRelDataBase.setODR_Db(orderDtlRel.getDb());
	orderDtlRelDataBase.setODR_Company(orderDtlRel.getCompany());
	orderDtlRelDataBase.setODR_Plant(orderDtlRel.getPlant());
	orderDtlRelDataBase.setODR_OrderNum(orderDtlRel.getOrderNum());
	orderDtlRelDataBase.setODR_ItemNum(orderDtlRel.getItemNum());
	orderDtlRelDataBase.setODR_ItemNumRel(orderDtlRel.getItemNumRel());
	orderDtlRelDataBase.setODR_OrgID(orderDtlRel.getOrgId());
	orderDtlRelDataBase.setODR_OrgItemNum(orderDtlRel.getOrgItemNum());
	orderDtlRelDataBase.setODR_OrgItemNumRel(orderDtlRel.getOrgItemNumRel());
	orderDtlRelDataBase.setODR_ShipToNum(orderDtlRel.getShipToNum());
	orderDtlRelDataBase.setODR_ShipToName(orderDtlRel.getShipToName());
	orderDtlRelDataBase.setODR_ShipToAdd1(orderDtlRel.getShipToAdd1());
	orderDtlRelDataBase.setODR_ShipToAdd2(orderDtlRel.getShipToAdd2());
	orderDtlRelDataBase.setODR_ShipToAdd3(orderDtlRel.getShipToAdd3());
	orderDtlRelDataBase.setODR_ShipToAdd4(orderDtlRel.getShipToAdd4());
	orderDtlRelDataBase.setODR_ShipToAdd5(orderDtlRel.getShipToAdd5());
	orderDtlRelDataBase.setODR_ShipToAdd6(orderDtlRel.getShipToAdd6());
	orderDtlRelDataBase.setODR_ShipToZipCode(orderDtlRel.getShipPostZip());
	orderDtlRelDataBase.setODR_PhoneNum(orderDtlRel.getPhoneNum());
	orderDtlRelDataBase.setODR_Attention(orderDtlRel.getAttention());
	orderDtlRelDataBase.setODR_CustPO(orderDtlRel.getCustPO());
	orderDtlRelDataBase.setODR_QtyOrd(orderDtlRel.getQtyOrd());
	orderDtlRelDataBase.setODR_QtyOrdUom(orderDtlRel.getQtyOrdUom());
	orderDtlRelDataBase.setODR_QtyOrdInv(orderDtlRel.getQtyOrdInv());
	orderDtlRelDataBase.setODR_QtyOrdInvUom(orderDtlRel.getQtyOrdInvUom());
	orderDtlRelDataBase.setODR_QtyShipped(orderDtlRel.getQtyShipped());
	orderDtlRelDataBase.setODR_QtyShippedInv(orderDtlRel.getQtyShippedInv());		
	orderDtlRelDataBase.setODR_QtyBO(orderDtlRel.getQtyBO());
	orderDtlRelDataBase.setODR_QtyBOInv(orderDtlRel.getQtyBOInv());
	orderDtlRelDataBase.setOD_DatePromise(orderDtlRel.getDatePromise());
	orderDtlRelDataBase.setOD_DateRequest(orderDtlRel.getDateRequest());
	orderDtlRelDataBase.setOD_DateShipping(orderDtlRel.getDateShipping());
	orderDtlRelDataBase.setOD_DateCancel(orderDtlRel.getDateCancel());
	orderDtlRelDataBase.setOD_DateChanged(orderDtlRel.getDateChanged());
	orderDtlRelDataBase.setOD_DateNotBefore(orderDtlRel.getDateNotBefore());
	orderDtlRelDataBase.setOD_DateAdded(orderDtlRel.getDateAdded());	
	orderDtlRelDataBase.setODR_OrderDtlID(orderDtlRel.getOrderDtlRelID());
	orderDtlRelDataBase.setODR_ProdDescription(orderDtlRel.getProdDescription());
	orderDtlRelDataBase.setODR_Condition(orderDtlRel.getCondition());
	orderDtlRelDataBase.setODR_Project(orderDtlRel.getProject());

	return orderDtlRelDataBase;		
}

/// <summary>
/// Return if exists a OrderDtlCharges
/// </summary>
/// <param name="OrderLineCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsOrderDtlCharge(OrderDtlCharge orderDtlCharge){
	try
	{
		OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);

		orderDtlChargeDataBase.setOH_ID(orderDtlCharge.getHId());		
		orderDtlChargeDataBase.setODC_ItemNum(orderDtlCharge.getItemNum());		
		orderDtlChargeDataBase.setODC_ItemChgNum(orderDtlCharge.getItemChgNum());

		return orderDtlChargeDataBase.exists();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Read and return a OrderDtlCharges object
/// </summary>
/// <param name="OrderLineCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
OrderDtlCharge readOrderDetailCharge(OrderDtlCharge orderDtlChargeCons){	
	try
	{
		OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);

		orderDtlChargeDataBase.setOH_ID(orderDtlChargeCons.getHId());		
		orderDtlChargeDataBase.setODC_ItemNum(orderDtlChargeCons.getItemNum());		
		orderDtlChargeDataBase.setODC_ItemChgNum(orderDtlChargeCons.getItemChgNum());

		if (!orderDtlChargeDataBase.exists())
			return null;

		orderDtlChargeDataBase.read();
		
		//orderDtlChargeDataBase to orderDtlCharge
		OrderDtlCharge orderDtlCharge= objectDataBaseToObject(orderDtlChargeDataBase);
				
		return orderDtlCharge;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

public 
OrderDtl getOrderDetailChargeById(OrderDtl orderDtl)
{
	try
	{
		OrderDtlChargesDataBaseContainer orderDtlChargesDataBaseContainer= new OrderDtlChargesDataBaseContainer(dataBaseAccess);	
		orderDtlChargesDataBaseContainer.readByOHeaderNumber(orderDtl.getHId(),orderDtl.getItemNum());
			
		IEnumerator iEnum = orderDtlChargesDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){

			OrderDtlChargesDataBase orderDtlChargesDataBase = (OrderDtlChargesDataBase)iEnum.Current;		
			
			//orderDtlChargesDataBase to orderDtlCharges
			OrderDtlCharge orderDtlCharge= objectDataBaseToObject(orderDtlChargesDataBase);
							
			orderDtl.addDtlCharge(orderDtlCharge);			
		}
		return orderDtl;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Write to the database a OrderDtlCharges object
/// </summary>
/// <param name="proccess"></param>
private
void writeOrderDetailCharge(OrderDtlCharge orderDtlCharge){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		//orderDtlCharge to orderDtlChargeDataBase
		OrderDtlChargesDataBase orderDtlChargeDataBase = objectToObjectDatabase(orderDtlCharge);
		
		orderDtlChargeDataBase.write();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a OrderDtlCharges object
/// </summary>
/// <param name="proccess"></param>
private
void updateOrderDetailCharge(OrderDtlCharge orderDtlCharge){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		//orderDtlCharge to orderDtlChargeDataBase
		OrderDtlChargesDataBase orderDtlChargeDataBase = objectToObjectDatabase(orderDtlCharge);
		
		orderDtlChargeDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Delete a OrderDtlCharges object
/// </summary>
/// <param name="proccess"></param>
private
void deleteOrderDetailChargeFromDetail(OrderDtlCharge orderDtlCharge){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);

		orderDtlChargeDataBase.setOH_ID(orderDtlCharge.getHId());
		orderDtlChargeDataBase.setODC_ItemNum(orderDtlCharge.getItemNum());
		
		orderDtlChargeDataBase.deleteFromDetail();
			
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

private
void deleteOrderDetailChargeFromHeader(OrderDtlCharge orderDtlCharge)
{
	try
	{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);

		orderDtlChargeDataBase.setOH_ID(orderDtlCharge.getHId());
		
		orderDtlChargeDataBase.deleteAllFromHeader();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}


private 
OrderDtlCharge objectDataBaseToObject(OrderDtlChargesDataBase orderDtlChargeDataBase)
{
	OrderDtlCharge orderDtlCharge = new OrderDtlCharge();

	orderDtlCharge.setHId(orderDtlChargeDataBase.getOH_ID());
	orderDtlCharge.setId (orderDtlChargeDataBase.getODC_ID());	
	orderDtlCharge.setDb (orderDtlChargeDataBase.getODC_Db());
	orderDtlCharge.setOrderNum (orderDtlChargeDataBase.getODC_OrderNum());
	orderDtlCharge.setItemNum(orderDtlChargeDataBase.getODC_ItemNum());
	orderDtlCharge.setItemChgNum(orderDtlChargeDataBase.getODC_ItemChgNum());
	orderDtlCharge.setChargeCode(orderDtlChargeDataBase.getODC_ChargeCode());
	orderDtlCharge.setChargeDesc(orderDtlChargeDataBase.getODC_ChargeDesc());
	orderDtlCharge.setChargeType(orderDtlChargeDataBase.getODC_ChargeType());
	orderDtlCharge.setChargeTypeSub(orderDtlChargeDataBase.getODC_ChargeTypeSub());
	orderDtlCharge.setBaseNet(orderDtlChargeDataBase.getODC_BaseNet());
	orderDtlCharge.setFixedUnit(orderDtlChargeDataBase.getODC_FixedUnit());
	orderDtlCharge.setSaleCOS(orderDtlChargeDataBase.getODC_SaleCOS());
	orderDtlCharge.setAmount(orderDtlChargeDataBase.getODC_Amount());
	orderDtlCharge.setMaxAmount(orderDtlChargeDataBase.getODC_MaxAmount());
	orderDtlCharge.setBeforeTax(orderDtlChargeDataBase.getODC_BeforeTax());
	orderDtlCharge.setBeforeFreight(orderDtlChargeDataBase.getODC_BeforeFreight());
	orderDtlCharge.setBeforeDiscount(orderDtlChargeDataBase.getODC_BeforeDiscount());
	orderDtlCharge.setPercent(orderDtlChargeDataBase.getODC_Percent());
	orderDtlCharge.setExtension(orderDtlChargeDataBase.getODC_Extension());
	orderDtlCharge.setApplytoCust(orderDtlChargeDataBase.getODC_ApplytoCust());
	orderDtlCharge.setApplytoSupplier(orderDtlChargeDataBase.getODC_ApplytoSupplier());
	orderDtlCharge.setGLAccountNum(orderDtlChargeDataBase.getODC_GLAccountNum());
	orderDtlCharge.setOnSalePaidInv(orderDtlChargeDataBase.getODC_OnSalePaidInv());
	orderDtlCharge.setPaid(orderDtlChargeDataBase.getODC_Paid());
	orderDtlCharge.setReceived(orderDtlChargeDataBase.getODC_Received());

	return orderDtlCharge;
}


protected 
OrderDtlChargesDataBase objectToObjectDatabase(OrderDtlCharge orderDtlCharge)
{
	OrderDtlChargesDataBase orderDtlChargeDataBase = new OrderDtlChargesDataBase(dataBaseAccess);		

	orderDtlChargeDataBase.setOH_ID(orderDtlCharge.getHId());
	orderDtlChargeDataBase.setODC_ID(orderDtlCharge.getId());	
	orderDtlChargeDataBase.setODC_Db(orderDtlCharge.getDb());
	orderDtlChargeDataBase.setODC_OrderNum(orderDtlCharge.getOrderNum());
	orderDtlChargeDataBase.setODC_ItemNum(orderDtlCharge.getItemNum());
	orderDtlChargeDataBase.setODC_ItemChgNum(orderDtlCharge.getItemChgNum());
	orderDtlChargeDataBase.setODC_ChargeCode(orderDtlCharge.getChargeCode());
	orderDtlChargeDataBase.setODC_ChargeDesc(orderDtlCharge.getChargeDesc());
	orderDtlChargeDataBase.setODC_ChargeType(orderDtlCharge.getChargeType());
	orderDtlChargeDataBase.setODC_ChargeTypeSub(orderDtlCharge.getChargeTypeSub());
	orderDtlChargeDataBase.setODC_BaseNet(orderDtlCharge.getBaseNet());
	orderDtlChargeDataBase.setODC_FixedUnit(orderDtlCharge.getFixedUnit());
	orderDtlChargeDataBase.setODC_SaleCOS("0");//becarefull!!!!!!!! orderDtlCharge.getSaleCOS());
	orderDtlChargeDataBase.setODC_Amount(orderDtlCharge.getAmount());
	orderDtlChargeDataBase.setODC_MaxAmount(orderDtlCharge.getMaxAmount());
	orderDtlChargeDataBase.setODC_BeforeTax(orderDtlCharge.getBeforeTax());
	orderDtlChargeDataBase.setODC_BeforeFreight(orderDtlCharge.getBeforeFreight());
	orderDtlChargeDataBase.setODC_BeforeDiscount(orderDtlCharge.getBeforeDiscount());
	orderDtlChargeDataBase.setODC_Percent(orderDtlCharge.getPercent());
	orderDtlChargeDataBase.setODC_Extension(orderDtlCharge.getExtension());
	orderDtlChargeDataBase.setODC_ApplytoCust(orderDtlCharge.getApplytoCust());
	orderDtlChargeDataBase.setODC_ApplytoSupplier(orderDtlCharge.getApplytoSupplier());
	orderDtlChargeDataBase.setODC_GLAccountNum(orderDtlCharge.getGLAccountNum());
	orderDtlChargeDataBase.setODC_OnSalePaidInv(orderDtlCharge.getOnSalePaidInv());
	orderDtlChargeDataBase.setODC_Paid(orderDtlCharge.getPaid());
	orderDtlChargeDataBase.setODC_Received(orderDtlCharge.getReceived());

	return orderDtlChargeDataBase;		
}

public
OrderDtlRel createOrderDtlRel() {
	return new OrderDtlRel();
}

} // class

} // namespace