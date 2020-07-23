using System;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class EmployeeDataBaseContainer : GenericDataBaseContainer{


public
EmployeeDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

#if OE_SYNC
public
void readToSynchronize(LastRevision lastRevision, int iquantity)
{
	try
	{
		string sql = "select * " +
			" from employee where " + 			
			" (DateUpdated >='"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "'" +
			" and EmpId > '"	+ lastRevision.getFieldId() + "')" + 
			" or " +
			" (DateUpdated > '"	+ DateUtil.getCompleteDateRepresentation(lastRevision.getDate()) + "')" +
			" order by DateUpdated,EmpId";

		sql = DBFormatter.selectTopRows (sql, Configuration.SqlRepositoryType, iquantity);
		
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read())
		{
			EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
			employeeDataBase.load(reader);			
			this.Add(employeeDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readToSynchronize>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readToSynchronize>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readToSynchronize> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readToSynchronize>: " + de.Message,de);
	}
}
#endif

public
void read(){
	try{
		string sql = "select * from employee";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
			employeeDataBase.load(reader);
			this.Add(employeeDataBase);
		}
		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <read>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <read>: " + de.Message,de);
	}
}

public
void truncate(){
	try{
		string sql = "delete from employee";
		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <truncate>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <truncate>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <truncate>: " + de.Message,de);
	}
}

public
void readByDesc(string desc,int iTop)
{
	try
	{
		string sql = "select ";

		if (iTop > 0)
			sql+=" top "  + iTop.ToString();

		sql+=" * from employee ";
		sql+=" where firstName like '%"	+ Converter.fixString(desc) + "%'";
		sql+=" or lastName like '%"		+ Converter.fixString(desc) + "%'";
		sql+=" Order by firstName,lastName";		

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);

		int i = int.MinValue;

		while(reader.Read())
		{
			EmployeeDataBase employeeDataBase = new EmployeeDataBase(dataBaseAccess);
			employeeDataBase.load(reader);
			this.Add(employeeDataBase);
			i++;
		}
		reader.Close();
	
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readByDesc>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readByDesc>: " + sCe.Message, sCe);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class EmployeeDataBaseContainer <readByDesc>: " + de.Message,de);
	}
}



} // class

} // namespace