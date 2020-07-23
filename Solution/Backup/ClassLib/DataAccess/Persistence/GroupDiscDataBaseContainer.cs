using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class GroupDiscDataBaseContainer : GenericDataBaseContainer{

public
GroupDiscDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	try{
		string sql = "select * from groupdisc";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);
			groupDiscDataBase.load(reader);
			this.Add(groupDiscDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <read>: " + de.Message,de);
	}
}

#if OE_SYNC
public
void readToSynchronize(LastRevision lastRevision,int iquantity)
{
	try
	{
		string sql = "select * "		+
			" from groupdisc "			+ 
			" where "					+ 
			" (PRGD_DateUpdated >='"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'" +
			" and PRGD_id > '"			+ lastRevision.getFieldId() + "')" + 
			" or "						+
			" (PRGD_DateUpdated > '"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "')" +
			" order by PRGD_DateUpdated,PRGD_id";

		sql = DBFormatter.selectTopRows (sql, Configuration.SqlRepositoryType, iquantity);

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read())
		{
			GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);
			groupDiscDataBase.load(reader);
			this.Add(groupDiscDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <readToSynchronize>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <readToSynchronize>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readToSynchronize> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <readToSynchronize>: " + de.Message,de);
	}
}
#endif

public
	void readByCode(string sgroupCode)
{
	try
	{		
		string sql = "select";

		sql+=" * from groupdisc";
		sql+=" where PRGD_GroupCode like '" + Converter.fixString(sgroupCode) + "%'";
		sql+=" order by PRGD_GroupCode";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);

		int i = int.MinValue;

		while(reader.Read())
		{
			GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);
			groupDiscDataBase.load(reader);
			this.Add(groupDiscDataBase);

			i++;
		}
		reader.Close();

	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer : " + se.Message,se);
	}
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class DiscountsDataBaseContainer : " + de.Message,de);
	}
}

public
void truncate(){
	try{
		string sql = "delete from groupdisc";
		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <truncate>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBaseContainer <truncate>: " + de.Message,de);
	}
}


} // class

} // namespace