/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $  Claudia Melo
*   $Date: 2006-12-21 19:56:25 $  6/4/2005
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePickDtlDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: OePickDtlDataBaseContainer.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/12 19:34:22  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/04/07 20:37:29  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class OePickDtlDataBaseContainer : GenericDataBaseContainer{

public
OePickDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from oepickdtl";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OePickDtlDataBase oePickDtlDataBase = new OePickDtlDataBase(dataBaseAccess);
			oePickDtlDataBase.load(reader);
			this.Add(oePickDtlDataBase);
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
		string sql = "delete from oepickdtl";

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