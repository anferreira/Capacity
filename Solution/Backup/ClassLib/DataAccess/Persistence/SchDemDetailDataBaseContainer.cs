using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class SchDemDetailDataBaseContainer : GenericDataBaseContainer{

private string DEDT_ProdID;

public
SchDemDetailDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void setDEDT_ProdID(string DEDT_ProdID){
	this.DEDT_ProdID = DEDT_ProdID;
}

public
void truncate(){
	try{
		string sql = "delete from schdemdetail";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}


} // class

} // namespace