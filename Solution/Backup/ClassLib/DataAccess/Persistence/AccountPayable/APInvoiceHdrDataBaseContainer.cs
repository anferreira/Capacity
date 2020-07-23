using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class APInvoiceHdrDataBaseContainer : GenericDataBaseContainer	{
public APInvoiceHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public void read(){
    NotNullDataReader  reader = null;
	try{
		string sql = "select * from apinvoicehdr ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			APInvoiceHdrDataBase aPInvoiceHdrDataBase = new APInvoiceHdrDataBase(dataBaseAccess);
			aPInvoiceHdrDataBase.load(reader);
			this.Add(aPInvoiceHdrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public void readByDates(DateTime startDate, DateTime endDate, string supplier){
    NotNullDataReader  reader = null;
	try{
		string sql = "select * from apinvoicehdr " +
		             "where APH_SupplierID = '" + supplier + "' and " + 
		                   "APH_InvoiceDate between '" + DateUtil.getDateRepresentation(startDate) +
		                                "' and '" + DateUtil.getDateRepresentation(endDate) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			APInvoiceHdrDataBase aPInvoiceHdrDataBase = new APInvoiceHdrDataBase(dataBaseAccess);
			aPInvoiceHdrDataBase.load(reader);
			this.Add(aPInvoiceHdrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}	


public void readByFiscal(int startFiscalY,int endFiscalY,int startFiscalP,int endFiscalP,string supplier){
    NotNullDataReader  reader = null;
	try{
		string sql = "select * from apinvoicehdr " +
		             "where APH_SupplierID = '" + supplier + "' and " + 
		                    "APH_FiscalYear >=" + startFiscalY + " and "+
                            "APH_FiscalYear <=" + endFiscalY + " and " +
                            "APH_FiscalPeriod >=" + startFiscalP + " and " +
                            "APH_FiscalPeriod <=" + endFiscalP;

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			APInvoiceHdrDataBase aPInvoiceHdrDataBase = new APInvoiceHdrDataBase(dataBaseAccess);
			aPInvoiceHdrDataBase.load(reader);
			this.Add(aPInvoiceHdrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}	

}//end class
}//end namespace
