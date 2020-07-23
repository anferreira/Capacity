/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/GeneralLedger/GLCurrencyDlyExcDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: GLCurrencyDlyExcDataBaseContainer.cs,v $
*   Revision 1.4  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.3  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/03/11 22:07:02  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/11 03:15:52  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class GLCurrencyDlyExcDataBaseContainer : GenericDataBaseContainer{

public
GLCurrencyDlyExcDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from glcurrencydlyexc";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase = new GLCurrencyDlyExcDataBase(dataBaseAccess);
			gLCurrencyDlyExcDataBase.load(reader);
			this.Add(gLCurrencyDlyExcDataBase);
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
		string sql = "delete from glcurrencydlyexc";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

public 
void readByDesc(string desc,string db){

	NotNullDataReader reader = null;
	try{
		string sql = "select * from glcurrencydlyexc" +
				        " where " +
				        "CDE_Db='" + Converter.fixString(db) + "' and " +
				        "CDE_CurrencyBase like '%"	+ Converter.fixString(desc) + "%' or " +
                        "CDE_CurrencyCode like '%"	+ Converter.fixString(desc) + "%'" +				       
		            "order by CDE_CurrencyBase, CDE_CurrencyCode" ;
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			GLCurrencyDlyExcDataBase glCurrencyDlyExcDataBase = new GLCurrencyDlyExcDataBase(dataBaseAccess);
			glCurrencyDlyExcDataBase.load(reader);
			this.Add(glCurrencyDlyExcDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

} // class
} // package