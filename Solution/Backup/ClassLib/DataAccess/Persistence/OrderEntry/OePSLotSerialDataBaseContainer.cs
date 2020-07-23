/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OePSLotSerialDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: OePSLotSerialDataBaseContainer.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/03/29 04:05:57  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class OePSLotSerialDataBaseContainer : GenericDataBaseContainer{

public
OePSLotSerialDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from oepslotserial";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OePSLotSerialDataBase oePSLotSerialDataBase = new OePSLotSerialDataBase(dataBaseAccess);
			oePSLotSerialDataBase.load(reader);
			this.Add(oePSLotSerialDataBase);
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
		string sql = "delete from oepslotserial";

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