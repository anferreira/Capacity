/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Capacity/CapCfgProdPrefDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: CapCfgProdPrefDataBaseContainer.cs,v $
*   Revision 1.3  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/01 01:53:00  fnicolet
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class CapCfgProdPrefDataBaseContainer : GenericDataBaseContainer{

public
CapCfgProdPrefDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from capcfgprodpref";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			CapCfgProdPrefDataBase capCfgProdPrefDataBase = new CapCfgProdPrefDataBase(dataBaseAccess);
			capCfgProdPrefDataBase.load(reader);
			this.Add(capCfgProdPrefDataBase);
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
		string sql = "delete from capcfgprodpref";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

} // class

} // package