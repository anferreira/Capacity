using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActSubDtDataBaseContainer : GenericDataBaseContainer{

public
ProdFmActSubDtDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsubdt";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDtDataBase prodFmActSubDtDataBase = new ProdFmActSubDtDataBase(dataBaseAccess);
			prodFmActSubDtDataBase.load(reader);
			this.Add(prodFmActSubDtDataBase);
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
void readByFamily(string productCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select * " +
				 " from prodfmactsubdt where " + 
				" PCD_FamId = '" + productCode + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDtDataBase prodFmActSubDtDataBase = new ProdFmActSubDtDataBase(dataBaseAccess);
			prodFmActSubDtDataBase.load(reader);
			this.Add(prodFmActSubDtDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


} // class

}