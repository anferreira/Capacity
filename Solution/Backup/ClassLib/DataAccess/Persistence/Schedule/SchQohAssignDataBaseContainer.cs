/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Schedule/SchQohAssignDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: SchQohAssignDataBaseContainer.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:53  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/09 03:42:36  fnicolet
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class SchQohAssignDataBaseContainer : GenericDataBaseContainer{

public
SchQohAssignDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schqohassign";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchQohAssignDataBase schQohAssignDataBase = new SchQohAssignDataBase(dataBaseAccess);
			schQohAssignDataBase.load(reader);
			this.Add(schQohAssignDataBase, schQohAssignDataBase.getHashKey());
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

public
void readByPltDeptVersion(string plt, string dept, string version){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schqohassign where " + 
			"SQA_Plt = '" + plt + "' and SQA_Dept = '" + dept + 
			"' and SQA_SchVersion = '" + version + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchQohAssignDataBase schQohAssignDataBase = new SchQohAssignDataBase(dataBaseAccess);
			schQohAssignDataBase.load(reader);
			this.Add(schQohAssignDataBase, schQohAssignDataBase.getHashKey());
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptVersion> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptVersion> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptVersion> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public void truncate(){
	try{
		string sql = "delete from schqohassign";

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