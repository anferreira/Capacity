using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class OEInvoiceHdrDataBaseContainer : GenericDataBaseContainer{

private string IH_Db;
private int IH_Company;
private string IH_Plant;
private int IH_InvoiceNum;

private int IH_BOLNumber;

public 
OEInvoiceHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicehdr";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.load(reader);
			this.Add(oeInvoiceHdrDataBase);
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
void readNotPassedToErp(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicehdr " +
		             "where IH_PostedToERP ='N'"; ;

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.load(reader);
			this.Add(oeInvoiceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readNotPassedToErp>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readNotPassedToErp>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readNotPassedToErp> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from oeinvoicehdr";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}


public 
void readByDbInvoiceNum(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicehdr " +
					"where IH_Db = '" + Converter.fixString(IH_Db) + "' and " + 
					"IH_InvoiceNum = " + NumberUtil.toString(IH_InvoiceNum);
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.loadByDbInvoiceNum(reader);
			this.Add(oeInvoiceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbInvoiceNum>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbInvoiceNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbInvoiceNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByDbBolInvoiceNumber(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicehdr " +
					"where " +
						"IH_Db = '" + Converter.fixString(IH_Db) + "' and " +
						"IH_InvoiceNum =" + NumberUtil.toString(IH_InvoiceNum) + " and " +
						"IH_BOLNumber = " + NumberUtil.toString(IH_BOLNumber);
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.loadByDbInvoiceNum(reader);
			this.Add(oeInvoiceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbBolInvoiceNumber>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbBolInvoiceNumber>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDbBolInvoiceNumber> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readMaxMinInvoiceNum(){
	NotNullDataReader reader = null;
	try{
		string sql = "select max(IH_InvoiceNum) as Max, min(IH_InvoiceNum) as Min " +
		             "from oeinvoicehdr " + 
					 "where IH_Db = '" + Converter.fixString(IH_Db)+"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.loadMaxMin(reader);
			this.Add(oeInvoiceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaxMinInvoiceNum> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaxMinInvoiceNum>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaxMinInvoiceNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
int readCount(){
    int count =0;
    NotNullDataReader reader =null;
	try{
		string sql = "select count(*) as countRecords from oeinvoicehdr " + 
					 "where IH_Db = '" + Converter.fixString(IH_Db)+"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase= new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.loadCountRecords(reader);
			count = oeInvoiceHdrDataBase.getcountRecords();
		}
	    return count;	
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readCount> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readCount>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readCount> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readMaxMinInvoiceDate(){
    NotNullDataReader reader = null;
	try{
		string sql = "select max(IH_InvDate) as MaxDate, min(IH_InvDate) as MinDate " +
                     "from oeinvoicehdr " + 
					 "where IH_Db = '" + Converter.fixString(IH_Db)+"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.loadMaxMinDate(reader);
			this.Add(oeInvoiceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDataBase> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDataBase>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDataBase> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByBOLNumber(int bolNumber){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicehdr " + 
					 "where IH_BOLNumber = " + NumberUtil.toString(bolNumber) +" and " +
					        "IH_Db = '" + Converter.fixString(IH_Db) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OEInvoiceHdrDataBase oeInvoiceHdrDataBase = new OEInvoiceHdrDataBase(dataBaseAccess);
			oeInvoiceHdrDataBase.load(reader);
			this.Add(oeInvoiceHdrDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByBolNumber> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByBolNumber>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByBolNumber> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}



//Setters
public 
void setIH_Db(string IH_Db){
   this.IH_Db = IH_Db;
}

public 
void setIH_Company(int IH_Company){
   this.IH_Company = IH_Company;
}

public 
void setIH_Plant(string IH_Plant){
   this.IH_Plant = IH_Plant;
}

public 
void setIH_InvoiceNum(int IH_InvoiceNum){
   this.IH_InvoiceNum = IH_InvoiceNum;
}

public 
void setIH_BOLNumber(int IH_BOLNumber){
   this.IH_BOLNumber = IH_BOLNumber;
}


//Getters
public
string getIH_Db(){
   return IH_Db;
}

public
int getIH_Company(){
   return IH_Company;
}

public
string getIH_Plant(){
   return IH_Plant;
}

public
int getIH_InvoiceNum(){
   return IH_InvoiceNum;
}

public
int getIH_BOLNumber(){
   return IH_BOLNumber;
}

}//end class

}//end namespace
