using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ArInvoiceDataBaseContainer	: GenericDataBaseContainer{

private string ARI_Db;
private string ARI_Company;
private string ARI_Plant;
private string ARI_ARInvoiceN;
private string ARI_InvoiceType;
private decimal ARI_InvoiceAmt;
private decimal ARI_Payment;
private decimal ARI_Balance;

public 
ArInvoiceDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoice";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceDataBase arInvoiceDataBase = new ArInvoiceDataBase(dataBaseAccess);
			arInvoiceDataBase.load(reader);
			this.Add(arInvoiceDataBase);
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
void readInvoiceUpdate(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoice " + 
					"where " +
					"ARI_Db = '" + Converter.fixString(ARI_Db) +"' and " +
					"ARI_Company = '" + Converter.fixString(ARI_Company) +"' and " +
					"ARI_ARInvoiceN = '" +Converter.fixString(ARI_ARInvoiceN) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceDataBase arInvoiceDataBase = new ArInvoiceDataBase(dataBaseAccess);
			arInvoiceDataBase.load(reader);
			this.Add(arInvoiceDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readInvoiceUpdate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readInvoiceUpdate>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readInvoiceUpdate> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readDebitsNotes(){
	NotNullDataReader  reader = null;
	try{
		string sql = "select * from arinvoice " +
					 "where ARI_InvoiceType = 'DEB' or "+ 
							"ARI_InvoiceType = 'POA'";

        reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceDataBase arInvoiceDataBase = new ArInvoiceDataBase(dataBaseAccess);
			arInvoiceDataBase.load(reader);
			this.Add(arInvoiceDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDebitsNotes>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDebitsNotes>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readDebitsNotes> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByDB(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoice " + 
					"where " +
					"ARI_Db = '" + Converter.fixString(ARI_Db) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceDataBase arInvoiceDataBase = new ArInvoiceDataBase(dataBaseAccess);
			arInvoiceDataBase.load(reader);
			this.Add(arInvoiceDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDB>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDB>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDB> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}



//read for the insertion in ARInvoiceAsg
public 
void readArInvoiceHdrDtl(){
	NotNullDataReader reader = null;
	try{
		string sql = "select " +
				"ARInvoice.ARI_Db, " +
				"ARInvoice.ARI_Company, " +
				"ARInvoice.ARI_Plant, " +
				"ARInvoice.ARI_ARInvoiceN, " +
				"ARInvoice.ARI_ARInvoiceNum, " +
				"ARInvoice.ARI_InvoiceType, " +
				"ARInvoice.ARI_BOLNum, " +
				"ARInvoice.ARI_BOLN, " +
				"ARInvoice.ARI_CustNum, " +
				"ARInvoice.ARI_BillToName, " +
				"ARInvoice.ARI_ShiptoNum, " +
				"ARInvoice.ARI_ShiptoName, " +
				"ARInvoice.ARI_CustPlant, " +
				"ARInvoice.ARI_InvDate, " +
				"ARInvoice.ARI_PostDate, " +
				"ARInvoice.ARI_DueDate, " +
				"ARInvoice.ARI_InvoiceAmt, " +
				"ARInvoice.ARI_Payment, " +
				"ARInvoice.ARI_Balance, " +
				"ARInvoice.ARI_CreditTot, " +
				"ARInvoice.ARI_LastPayDate, " +
				"ARInvoice.ARI_LastCheck, " +
				"ARInvoice.ARI_LastCheckAmt, " +
				"ARInvoice.ARI_PostPeriod, " +
				"ARInvoice.ARI_PostYear, " +
				"ARInvoice.ARI_Program, " +
				"ARInvoice.ARI_Status, " +
				"ARInvoice.ARI_Currency, " +
				"ARI_PostExgRate " +
			 "from arinvoice, invoicedtl, invoicehdr " +
			 "where ARI_Db = IH_Db and  " +
				"	ARI_Company = IH_Company and " +
				"	ARI_Plant = IH_Plant and " +
				"	ARI_ARInvoiceNum = IH_InvoiceNum and " + //Verificar que sea con el campo ARI_InvoiceNum
				"	ARI_Db = ID_Db and  " +
				"	ARI_Company = ID_Company and " +
				"	ARI_Plant = ID_Plant and " +
				"	ARI_ARInvoiceNum = ID_InvoiceNum ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceDataBase arInvoiceDataBase = new ArInvoiceDataBase(dataBaseAccess);
			arInvoiceDataBase.load(reader);
			this.Add(arInvoiceDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readArInvoiceHdrDtl>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readArInvoiceHdrDtl>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readArInvoiceHdrDtl> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByInvoice(string searchText){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoice " +
					 "where (ARI_ARInvoiceN like '%"+ Converter.fixString(searchText) + "%')";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceDataBase arInvoiceDataBase = new ArInvoiceDataBase(dataBaseAccess);
			arInvoiceDataBase.load(reader);
			this.Add(arInvoiceDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByInvoice>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByInvoice>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByInvoice> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from arinvoice";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate>: " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message);
	}
}

//Setters
public 
void setARI_Db(string ARI_Db){
	this.ARI_Db = ARI_Db;
}

public 
void setARI_Company(string ARI_Company){
	this.ARI_Company = ARI_Company;
}

public 
void setARI_Plant(string ARI_Plant){
	this.ARI_Plant = ARI_Plant;
}

public 
void setARI_ARInvoiceN(string ARI_ARInvoiceN){
	this.ARI_ARInvoiceN = ARI_ARInvoiceN;
}

public 
void setARI_InvoiceType(string ARI_InvoiceType){
   this.ARI_InvoiceType = ARI_InvoiceType;
}

public 
void setARI_InvoiceAmt(decimal ARI_InvoiceAmt){
   this.ARI_InvoiceAmt = ARI_InvoiceAmt;
}

public 
void setARI_Payment(decimal ARI_Payment){
   this.ARI_Payment = ARI_Payment;
}

public 
void setARI_Balance(decimal ARI_Balance){
   this.ARI_Balance= ARI_Balance;
}

//Getters
public 
string getARI_Db(){
	return ARI_Db;
}

public 
string getARI_Company(){
	return ARI_Company;
}

public 
string getARI_Plant(){
	return ARI_Plant;
}

public 
string getARI_ARInvoiceN(){
	return ARI_ARInvoiceN;
}

public
string getARI_InvoiceType(){
   return ARI_InvoiceType;
}

public
decimal getARI_InvoiceAmt(){
   return ARI_InvoiceAmt;
}

public
decimal getARI_Payment(){
   return ARI_Payment;
}

public
decimal getARI_Balance(){
   return ARI_Balance;
}

}//end class

}//end namespace
