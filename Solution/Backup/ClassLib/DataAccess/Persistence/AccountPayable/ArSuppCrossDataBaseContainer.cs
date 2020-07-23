using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ArSuppCrossDataBaseContainer : GenericDataBaseContainer{


private string SC_TradingPartner;
private string SC_SupplierNum;

public
ArSuppCrossDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arsuppcross";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArSuppCrossDataBase arSuppCrossDataBase = new ArSuppCrossDataBase(dataBaseAccess);
			arSuppCrossDataBase.load(reader);
			this.Add(arSuppCrossDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByTPartnerSuppNum(){
    NotNullDataReader reader = null;
   	try{
		string sql = "select * from arsuppcross " +
		             "where SC_TradingPartner = '" + Converter.fixString(SC_TradingPartner)+"' and " +
		                   "SC_SupplierNum = '" + Converter.fixString(SC_SupplierNum) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArSuppCrossDataBase arSuppCrossDataBase = new ArSuppCrossDataBase(dataBaseAccess);
			arSuppCrossDataBase.load(reader);
			this.Add(arSuppCrossDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTPartnerSuppNum> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTPartnerSuppNum> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTPartnerSuppNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
public
void truncate(){
	try{
		string sql = "delete from from arsuppcross";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}


//Setters
public 
void setSC_SupplierNum(string SC_SupplierNum){
   this.SC_SupplierNum = SC_SupplierNum;
}

public 
void setSC_TradingPartner(string SC_TradingPartner){
   this.SC_TradingPartner = SC_TradingPartner;
}


//Getters
public
string getSC_TradingPartner(){
   return SC_TradingPartner;
}

public
string getSC_SupplierNum(){
   return SC_SupplierNum;
}

}//end class

}//end namespace
