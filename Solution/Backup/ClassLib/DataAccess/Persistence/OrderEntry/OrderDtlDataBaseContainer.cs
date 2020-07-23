using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderDtlDataBaseContainer : GenericDataBaseContainer{

public
OrderDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	try{
		string sql = "select * from orderdtl";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
			orderDtlDataBase.load(reader);			
			this.Add(orderDtlDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <read>: " + de.Message,de);
	}
}

public 
void readByOHeaderNumber(int iorder){
	try{
		string sql ="select * from orderdtl " +
					" where "	+					
					" OH_ID="	+ iorder		+
					" order by OD_ItemNum";
 
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		
		while(reader.Read()){
			OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
			orderDtlDataBase.load(reader);
			this.Add(orderDtlDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <readByOHeaderNumber>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <readByOHeaderNumber>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOHeaderNumber> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <readByOHeaderNumber>: " + de.Message,de);
	}
}

public 
void readByProductId(int iorder,string sprodID){
	try{
		string sql ="select * from orderdtl "	+
					" where "					+					
					" OH_ID="		+ iorder	+ " and " +
					" OD_ProdID='"	+ sprodID	+ "'" +
					" order by OD_ItemNum";
 
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);

		int i = int.MinValue;

		while(reader.Read()){
			OrderDtlDataBase orderDtlDataBase = new OrderDtlDataBase(dataBaseAccess);
			orderDtlDataBase.load(reader);
			this.Add(orderDtlDataBase);

			i++;
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <readByProductId>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <readByProductId>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProductId> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <readByProductId>: " + de.Message,de);
	}
}

public
void truncate(){
	try{
		string sql = "delete from orderdtl";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlDataBaseContainer <truncate>: " + de.Message,de);
	}
}

public
OrderDtlDataBase getOrderLineInfo(string skey){
	int pos = getFirstElementPosition(skey);
	if (pos == -1)
		return null;
	else
		return (OrderDtlDataBase)this[pos];
}

} // class

} // namespace