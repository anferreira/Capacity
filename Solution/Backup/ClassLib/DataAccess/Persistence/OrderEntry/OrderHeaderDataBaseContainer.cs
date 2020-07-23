using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderHdrDataBaseContainer : GenericDataBaseContainer{
	


public
OrderHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	try{
		string sql = "select * from orderhdr order by OH_ID";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		int i = int.MinValue;

		while(reader.Read()){
			OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);
			orderHdrDataBase.load(reader);
//			this.Add(OrderHdrDataBase.GetHashCode(), OrderHdrDataBase);
			this.Add(orderHdrDataBase);

			i++;
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <read>: " + de.Message,de);
	}
}

	
public 
void readByOHeaderNumber(int iorder){
	try{
		string sql=	"select * from orderhdr "  +
					" where "	+								
					" OH_ID= "	+ iorder.ToString();			
			
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);
			orderHdrDataBase.load(reader);
			this.Add(orderHdrDataBase);
		}
		reader.Close();

	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeaderNumber>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeaderNumber>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOHeaderNumber> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeaderNumber>: " + de.Message,de);
	}
}

public 
void readByOHeader(string sclient,string semployee,DateTime dateSince,DateTime dateUntil,string  stypeOfOrderSelected, string sorderStatus, string sorderType, int iorderNum, bool onlyPendingOrders)
{
	try
	{
		bool	bcondition=false;
		string sql = "select * from orderhdr "; 
		
		//if there is a search condition
		if (sclient.Length > 0 || semployee.Length > 0 || 
			(!dateSince.Equals(DateUtil.MinValue) && !dateUntil.Equals(DateUtil.MinValue))
			|| stypeOfOrderSelected.Length > 0 || sorderStatus.Length > 0
			|| sorderType.Length > 0 || iorderNum != 0 || onlyPendingOrders)
			sql+= " where ";

		//client
		if (sclient.Length > 0)
		{
			sql+= " OH_BillToNum ='"  + Converter.fixString(sclient) + "'";
			bcondition=true;
		}

		if (semployee.Length > 0)
		{
			if (bcondition)
				sql+= " and ";

			sql+= " OH_SalesPerson ='"  + Converter.fixString(semployee) + "'";
			bcondition=true;
		}

		//date
		if (!dateSince.Equals(DateUtil.MinValue) && !dateUntil.Equals(DateUtil.MinValue))
		{
			if (bcondition)
				sql+= " and ";

			sql+= " OH_OrderDate >= '" + DateUtil.getCompleteDateRepresentation(dateSince) + "' ";
			sql+= " and OH_OrderDate <= '" + DateUtil.getCompleteDateRepresentation(dateUntil) + "'";

			bcondition=true;
		}

		//typeOfOrderSelected
		if (stypeOfOrderSelected.Length > 0)//order or quote
		{
			if (bcondition)
				sql+= " and ";
			
			sql+= " OH_RetailProductType='" + stypeOfOrderSelected + "'";
			bcondition = true;
		}

		//status
		if (sorderStatus.Length > 0)//order or quote
		{
			if (bcondition)
				sql+= " and ";
				
			sql+= " OH_OrderStatus='" + sorderStatus + "'";
			bcondition=true;
		}

		//type
		if (sorderType.Length > 0)//order or quote
		{
			if (bcondition)
				sql+= " and ";
				
			sql+= " OH_OrderType='" + sorderType + "'";
			bcondition=true;
		}
			
		//orderNum
		if (iorderNum != 0)
		{
			if (bcondition)
				sql+= " and ";
				
			sql+= " (OH_OrderNum=" + iorderNum + " or OH_Quote=" + iorderNum + ")";
			bcondition=true;
		}

		//pendingOrders
		if (onlyPendingOrders)
		{
			if (bcondition)
				sql+= " and ";
				
			sql+= " (OH_SentToCMS = 'N')";
			bcondition=true;
		}

		sql+= " order by OH_ID";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		int i = int.MinValue;

		while(reader.Read())
		{
			OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);
			orderHdrDataBase.load(reader);
			this.Add(orderHdrDataBase);
			i++;
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeader>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeader>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOHeader> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeader>: " + de.Message,de);
	}
}
public 
void readByOHeaderNotSend()
{
	try
	{
		string sql = "select * from orderhdr " + 					
					" where OH_Synchronized ='" + Constants.STRING_NO + "'" + //if the order was not synchronized						
					" and OH_OrderStatus='" + Constants.ORDER_STATUS_FINISHED + "'" + 
					" Order by OH_ID";
		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		int i = int.MinValue;

		while(reader.Read())
		{
			OrderHdrDataBase orderHdrDataBase = new OrderHdrDataBase(dataBaseAccess);
			orderHdrDataBase.load(reader);
			this.Add(orderHdrDataBase);
			i++;
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
	throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeaderNotSend>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeaderNotSend>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOHeaderNotSend> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <readByOHeaderNotSend>: " + de.Message,de);
	}
}

/*
public
string[][] getPendingOrderList(){
	try{
		string sql = "select * from orderhdr where OH_SentToCMS = 'N'";
//		string sql = "select * from orderhdr";
		ArrayList array = new ArrayList();
		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string[] line = new string[22];

			line[0] = reader.GetInt32("OH_ID").ToString(); 
			line[1] = reader.GetString("OH_Plant");
			line[2] = reader.GetInt32("OH_OrderNum").ToString(); 
			line[3] = reader.GetString("OH_OrgID");
			line[4] = DateUtil.getDateRepresentation(reader.GetDateTime("OH_OrderDate"), DateUtil.MMDDYYYY);
			line[5] = reader.GetString("OH_OrderStatus");
			line[6] = reader.GetString("OH_OrderType");
			line[7] = reader.GetString("OH_SalesPerson");
			line[8] = reader.GetString("OH_Company");
			line[9] = reader.GetString("OH_OrgID");
			line[10] = reader.GetString("OH_BillToNum");
 			line[11] = reader.GetString("OH_BillToName");
 			line[12] = reader.GetString("OH_BillToAdd1");
 			line[13] = reader.GetString("OH_BillToZipCode");
 			line[14] = reader.GetString("OH_PO");
 			line[15] = NumberUtil.toString(reader.GetInt32("OH_Quote"));
			line[16] = DateUtil.getDateRepresentation(reader.GetDateTime("OH_DateRequest"), DateUtil.MMDDYYYY);
			line[17] = DateUtil.getDateRepresentation(reader.GetDateTime("OH_DatePromise"), DateUtil.MMDDYYYY);
			line[18] = DateUtil.getDateRepresentation(reader.GetDateTime("OH_DateShip"), DateUtil.MMDDYYYY);
			line[19] = DateUtil.getDateRepresentation(reader.GetDateTime("OH_DateConfirm"), DateUtil.MMDDYYYY);
			line[20] = NumberUtil.toString(reader.GetDecimal("OH_OrderTotal"));
			line[21] = reader.GetString("OH_RetailProductType");

			array.Add(line);
		}
		reader.Close();

		string[][] v = new string[array.Count][];

		for(int i = 0; i < array.Count; i++){
			v[i] = (string[])array[i];
		}

		return v;
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <getOrdersList>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <getOrdersList>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getOrdersList> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <getOrdersList>: " + de.Message,de);
	}
}
*/

public
void truncate(){
	try{
		string sql = "delete from orderhdr";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderHdrDataBaseContainer <truncate>: " + de.Message,de);
	}
}

public
OrderHdrDataBase getOrderHeaderInfo(string skey){
	int pos = getFirstElementPosition(skey);
	if (pos == -1)
		return null;
	else
		return (OrderHdrDataBase)this[pos];
}


} // class

} // namespace