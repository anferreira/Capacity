using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OrderDtlRelDataBaseContainer : GenericDataBaseContainer{

public
OrderDtlRelDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	try{
		string sql = "select * from orderdtlrel";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);
			orderDtlRelDataBase.load(reader);			
			this.Add(orderDtlRelDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <read>: " + de.Message,de);
	}
}

public 
void readByOHeaderNumber(int iorder,int item){
	try{
		string sql ="select * from orderdtlrel "+
					" where "					+			
					" OH_ID="		+ iorder	+ " and " +
					" ODR_ItemNum="	+ item;
	 
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		
		while(reader.Read()){
			OrderDtlRelDataBase orderDtlRelDataBase = new OrderDtlRelDataBase(dataBaseAccess);
			orderDtlRelDataBase.load(reader);
			this.Add(orderDtlRelDataBase);
		}
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <readByOHeaderNumber>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <readByOHeaderNumber>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOHeaderNumber> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <readByOHeaderNumber>: " + de.Message,de);
	}
}

public
void truncate(){
	try{
		string sql = "delete from orderdtlrel";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class OrderDtlRelDataBase <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class OrderDtlRelDataBase <truncate>: " + de.Message,de);
	}
}

public
OrderDtlRelDataBase getOrderDetailRelInfo(string skey){
	int pos = getFirstElementPosition(skey);
	if (pos == -1)
		return null;
	else
		return (OrderDtlRelDataBase)this[pos];
}


} // class

} // namespace