using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class DiscountsDataBaseContainer : GenericDataBaseContainer{

public
DiscountsDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void readByDesc(string desc,int itop){
	try{		
		string sql = "select ";

		sql+=" * from discounts";
		sql+=" where DF_DiscDesc like '" + Converter.fixString(desc) + "%'";					
		sql+= " Order by DF_DiscDesc";					

		if (itop > 0)
			sql = DBFormatter.selectTopRows (sql, Configuration.SqlRepositoryType, itop);

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);

		while(reader.Read())
		{
			DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);
			discountsDataBase.load(reader);
			this.Add(discountsDataBase);		
		}
		reader.Close();
		
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readByDesc>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readByDesc>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readByDesc>: " + de.Message,de);
	}
}

public
void readByIngGroupDesc(string sgroupId,string sdesc,int itop,string sorderBy){
	try{		
		string sql = "select ";

		sql+=" d.*,g.* from discounts d, groupdisc g";
		sql+= " where ";
		sql+=" g.PRGD_GroupCode='" + sgroupId + "' and ";
		sql+=" g.PRGD_DiscCode= d.DF_DiscCode";
		
		if (sdesc.Length > 0)
			sql+= " and DF_DiscDesc like '" + sdesc + "%'";

		if (sorderBy.Length < 1)
			sorderBy="DF_DiscDesc";

		sql+= " Order by " + sorderBy;					

		if (itop > 0)
			sql = DBFormatter.selectTopRows (sql, Configuration.SqlRepositoryType, itop);

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);

		int i = int.MinValue;

		while(reader.Read())
		{
			DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);
			discountsDataBase.load(reader);
			this.Add(discountsDataBase);
			i++;
		}
		reader.Close();
		
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readByIngGroupDesc>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readByIngGroupDesc>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByIngGroupDesc> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readByIngGroupDesc>: " + de.Message,de);
	}
}


public
void read(){
	try{
		string sql = "select * from discounts";
		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);
			discountsDataBase.load(reader);
			this.Add(discountsDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <read>: " + de.Message,de);
	}
}

#if OE_SYNC
public
void readToSynchronize(LastRevision lastRevision,int iquantity){
	try{
		
		string sql = "select * " +
			" from discounts "		+ 
			" where "				+ 
			" (DF_DateUpdated >='"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'" +
			" and DF_DiscCode > '"	+ lastRevision.getFieldId() + "')" + 
			" or " +
			" (DF_DateUpdated > '"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "')" +
			" order by DF_DateUpdated,DF_DiscCode";
		sql = DBFormatter.selectTopRows (sql, Configuration.SqlRepositoryType, iquantity);
					
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);
			discountsDataBase.load(reader);
			this.Add(discountsDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readToSynchronize>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readToSynchronize>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readToSynchronize> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <readToSynchronize>: " + de.Message,de);
	}
}
#endif

public
void truncate(){
	try{
		string sql = "delete from discounts";
		
		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer <truncate>: " + de.Message,de);
	}
}

public
DiscountsDataBase getDiscountsInfo(string skey){
	int pos = getFirstElementPosition(skey);
	if (pos == -1)
		return null;
	else
		return (DiscountsDataBase)this[pos];
}

} // class

} // namespace