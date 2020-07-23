using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderDtlChargesDataBaseContainer : GenericDataBaseContainer{

public
OrderDtlChargesDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	try{
		string sql = "select * from orderdtlcharges";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OrderDtlChargesDataBase orderDtlChargesDataBase = new OrderDtlChargesDataBase(dataBaseAccess);
			orderDtlChargesDataBase.load(reader);			
			this.Add(orderDtlChargesDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <read>: " + de.Message,de);
	}
}

public 
void readByOHeaderNumber(int iorder,int item){
	try{
		string sql ="select * from orderdtlcharges "+
					" where "			+			
					"OH_ID="			+ iorder	+ " and " +					
					"ODC_ItemNum="		+ item;
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		
		while(reader.Read()){
			OrderDtlChargesDataBase orderDtlChargesDataBase = new OrderDtlChargesDataBase(dataBaseAccess);
			orderDtlChargesDataBase.load(reader);
			this.Add(orderDtlChargesDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <readByOHeaderNumber>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <readByOHeaderNumber>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOHeaderNumber> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <readByOHeaderNumber>: " + de.Message,de);
	}
}

public
void truncate(){
	try{
		string sql = "delete from orderdtlcharges";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlChargesDataBaseContainer <truncate>: " + de.Message,de);
	}
}

public
OrderDtlChargesDataBase getOrderDetailChargesInfo(string skey){
	int pos = getFirstElementPosition(skey);
	if (pos == -1)
		return null;
	else
		return (OrderDtlChargesDataBase)this[pos];
}


} // class

} // namespace