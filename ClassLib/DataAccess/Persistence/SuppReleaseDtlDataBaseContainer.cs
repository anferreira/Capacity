using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class SuppReleaseDtlDataBaseContainer : GenericDataBaseContainer{


public
SuppReleaseDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from suppreleasedtl";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SuppReleaseDtlDataBase suppReleaseDtlDataBase = new SuppReleaseDtlDataBase(dataBaseAccess);
			suppReleaseDtlDataBase.load(reader);
			this.Add(suppReleaseDtlDataBase);
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
SuppReleaseDtlDataBase getSuppReleaseDtlDataBase(string prodID, int prodSeq, DateTime date){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		SuppReleaseDtlDataBase suppReleaseDtlDataBase = (SuppReleaseDtlDataBase)en.Current;
		if (suppReleaseDtlDataBase.getSP_ProdID().Equals(prodID) && 
				(suppReleaseDtlDataBase.getSP_Seq() == prodSeq) && 
				suppReleaseDtlDataBase.getSP_Date().Equals(date))
			return suppReleaseDtlDataBase;
	}
	return null;
}

public
void truncate(){
	try{
		string sql = "delete from suppreleasedtl";
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