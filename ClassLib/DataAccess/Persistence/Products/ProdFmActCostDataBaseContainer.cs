using System;
#if !POCKET_PC
using MySql.Data;
#endif
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ProdFmActCostDataBaseContainer : GenericDataBaseContainer{

public
ProdFmActCostDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

#if OE_SYNC
public
void readToSynchronize(LastRevision lastRevision,int iquantity)
{
	try
	{
		string sql = "select * from prodfmactcost "	+ 
			" where "								+ 
			" (PAC_DateUpdated >='"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'" +
			" and PAC_ProdID > '"	+ lastRevision.getFieldId() + "')" + 
			" or " +
			" (PAC_DateUpdated > '"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "')" +
			" order by PAC_DateUpdated,PAC_ProdID";

		sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType,iquantity);		

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read())
		{
			ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);
			prodFmActCostDataBase.load(reader);
			this.Add(prodFmActCostDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class" + this.GetType().Name +  "<readToSynchronize>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class" + this.GetType().Name +  "<readToSynchronize>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readToSynchronize> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de){
		throw new PersistenceException("Error in class"  + this.GetType().Name+ "<readToSynchronize>: " + de.Message,de);
	}
}
#endif

public void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactcost";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);
			prodFmActCostDataBase.load(reader);		
			this.Add(prodFmActCostDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class "+ this.GetType().Name  +"<read>: " + sCe.Message);
#else	
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
#endif
	}finally{
		if (reader != null)
			reader.Close();
	}
}

#if OE_SYNC
public 
void readManufactured(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactcost where PAC_PartType = 'M'";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);
			prodFmActCostDataBase.load(reader);		
			this.Add(prodFmActCostDataBase, prodFmActCostDataBase.getPAC_ProdID());
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class "+ this.GetType().Name +" <readManufactured>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class"+  this.GetType().Name +" <readManufactured>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readManufactured> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class"  + this.GetType().Name+ " <readManufactured>: " + de.Message,de);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readPurchased(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactcost where PAC_PartType = 'P'";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);
			prodFmActCostDataBase.load(reader);		
			this.Add(prodFmActCostDataBase, prodFmActCostDataBase.getPAC_ProdID());
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name +" <readPurchased>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class " +  this.GetType().Name +" <readPurchased>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readPurchased> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class"  + this.GetType().Name+ "<readPurchased>: " + de.Message,de);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}
#endif

public 
void truncate(){
	try{
		string sql = "delete from prodfmactcost";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class " + this.GetType().Name +" <truncate>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
#endif
	}
}
public 
void truncatePurchased(){
	try{
		string sql = "delete from prodfmactcost where PAC_PartType = 'P'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncatePurchased> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncatePurchased> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class " + this.GetType().Name +" <truncatePurchased>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncatePurchased> : " + mySqlExc.Message, mySqlExc);
#endif
	}
}

public 
void truncateManufactured(){
	try{
		string sql = "delete from prodfmactcost where PAC_PartType = 'M'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateManufactured> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateManufactured> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class " + this.GetType().Name +" <truncateManufactured>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateManufactured> : " + mySqlExc.Message, mySqlExc);
#endif
	}
}


} // class

} // namespace
