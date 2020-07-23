using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using MySql.Data;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class CompanyDataBaseContainer	: GenericDataBaseContainer{

public CompanyDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public 
void readByDesc(string desc,string sdb){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from company " +
				" where " +
				"(CIA_Name like '%" + Converter.fixString(desc) + "%' or " +
				"CIA_Description like '%" + Converter.fixString(desc) + "%')";

			if (sdb.Length > 0)
				sql+= " and CIA_Db = '" + Converter.fixString(sdb) + "'"; 		

				sql+=" order by CIA_Name,CIA_Description";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CompanyDataBase companyDataBase = new CompanyDataBase(dataBaseAccess);
			companyDataBase.load(reader);
			this.Add(companyDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDescOrId> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDescOrId> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDescOrId> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public void read(){
    
    NotNullDataReader reader = null;
	try{
		string sql = "select * from company";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CompanyDataBase companyDataBase = new CompanyDataBase(dataBaseAccess);
			companyDataBase.load(reader);
			this.Add(companyDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public void truncate(){
	try{
		string sql = "delete from company";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

}//end class
}//end namespace
