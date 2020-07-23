/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo    $ 
*   $Date 15-04-2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/StktDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: StktDataBaseContainer.cs,v $
*   Revision 1.8  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.7  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.6  2005/05/02 21:02:02  cmelo
*   *** empty log message ***
*
*   Revision 1.5  2005/04/29 19:26:51  cmelo
*   *** empty log message ***
*
*   Revision 1.4  2005/04/27 22:29:54  cmelo
*   *** empty log message ***
*
*   Revision 1.3  2005/04/20 21:59:15  cmelo
*   *** empty log message ***
*
*   Revision 1.2  2005/04/18 19:01:40  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/04/15 22:26:56  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class StktDataBaseContainer : GenericDataBaseContainer{

public
StktDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from "; 
     	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
	    sql += "stkt";


		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			StktDataBase stktDataBase = new StktDataBase(dataBaseAccess);
			stktDataBase.load(reader);
			this.Add(stktDataBase);
		}

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public void truncate(){
	try{
		string sql = "delete from stkt";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

//We read direct from Stkt table in Cmstemp
public void readForReport(DateTime dateTo, DateTime dateFrom,string prod){

	NotNullDataReader reader = null;
	try{
		string sql = "select * from stkt " +
		             "where BYPART = '" +Converter.fixString(prod) +"' and " +
		                   "BYACTN = 'I' and " + 
		                   "(BYTDAT  between '" +DateUtil.getDateRepresentation(dateFrom) +"' and '"  
		                                        +DateUtil.getDateRepresentation(dateTo) +"') " +
		             "order by BYPART";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			StktDataBase stktDataBase = new StktDataBase(dataBaseAccess);
			stktDataBase.load(reader);
			this.Add(stktDataBase);
		}

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
int readMaxByTran(){
	NotNullDataReader reader = null;
	try{
	    int maxValue = 0;
		string sql = "select max(BYTRAN) from stkt"; 
     	
	 	reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			maxValue = reader.GetInt32(0);
		}
        return maxValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
void read(int maxTransaction){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from "; 
     	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
	    sql += "stkt "  +
	           "where BYTRAN >"+ NumberUtil.toString(maxTransaction) + " " +
	           "order by BYTRAN " + 
	           "fetch first 1000 rows only";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			StktDataBase stktDataBase = new StktDataBase(dataBaseAccess);
			stktDataBase.load(reader);
			this.Add(stktDataBase);
		}

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

} // class
} // package