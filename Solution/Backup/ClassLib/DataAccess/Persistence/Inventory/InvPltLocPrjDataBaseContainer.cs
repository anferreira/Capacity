using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class InvPltLocPrjDataBaseContainer : GenericDataBaseContainer{

public
InvPltLocPrjDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from invpltlocprj";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			InvPltLocPrjDataBase invPltLocPrjDataBase = new InvPltLocPrjDataBase(dataBaseAccess);
			invPltLocPrjDataBase.load(reader);
			this.Add(invPltLocPrjDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

} // class

}