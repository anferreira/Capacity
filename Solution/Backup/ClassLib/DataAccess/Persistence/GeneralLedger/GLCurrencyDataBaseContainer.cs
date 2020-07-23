/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo$ 
*   $Date 03/10/2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/GeneralLedger/GLCurrencyDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: GLCurrencyDataBaseContainer.cs,v $
*   Revision 1.4  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.3  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/03/11 20:28:14  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/11 03:28:33  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class GLCurrencyDataBaseContainer : GenericDataBaseContainer{

public
GLCurrencyDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from glcurrency";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			GLCurrencyDataBase gLCurrencyDataBase = new GLCurrencyDataBase(dataBaseAccess);
			gLCurrencyDataBase.load(reader);
			this.Add(gLCurrencyDataBase);
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
		string sql = "delete from glcurrency";

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
		string sql = "select * from glcurrency" +
				        " where " +
				        "GLC_Db='" + Converter.fixString(db) + "' and " +
				        "GLC_Currency like '%"	+ Converter.fixString(desc) + "%' or " +
                        "GLC_Description like '%"	+ Converter.fixString(desc) + "%'" +				       
		            "order by GLC_Currency, GLC_Description" ;
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			GLCurrencyDataBase glCurrencyDataBase = new GLCurrencyDataBase(dataBaseAccess);
			glCurrencyDataBase.load(reader);
			this.Add(glCurrencyDataBase);
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