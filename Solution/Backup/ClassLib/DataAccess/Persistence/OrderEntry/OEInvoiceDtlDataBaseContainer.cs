/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/OrderEntry/OeInvoiceDtlDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: OeInvoiceDtlDataBaseContainer.cs,v $
*   Revision 1.4  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.3  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/04/05 22:58:55  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/18 21:51:58  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class OeInvoiceDtlDataBaseContainer : GenericDataBaseContainer{

public
OeInvoiceDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicedtl";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OeInvoiceDtlDataBase oeInvoiceDtlDataBase = new OeInvoiceDtlDataBase(dataBaseAccess);
			oeInvoiceDtlDataBase.load(reader);
			this.Add(oeInvoiceDtlDataBase);
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
void readByHdr(string db,int company,string plant,int invoiceNum){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicedtl " +
		             "where " +
		                    "ID_Db = '" + Converter.fixString(db) + "' and " +
			                "ID_Company =" + NumberUtil.toString(company) + " and " +
			                "ID_Plant = '" + Converter.fixString(plant) + "' and " +
			                "ID_InvoiceNum = " + NumberUtil.toString(invoiceNum);

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OeInvoiceDtlDataBase oeInvoiceDtlDataBase = new OeInvoiceDtlDataBase(dataBaseAccess);
			oeInvoiceDtlDataBase.load(reader);
			this.Add(oeInvoiceDtlDataBase);
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
void deleteByHdr(string db,int company,string plant,int invoiceNum){
	NotNullDataReader reader = null;
	try{
		string sql = "delete from oeinvoicedtl " +
		             "where " +
		                    "ID_Db = '" + Converter.fixString(db) + "' and " +
			                "ID_Company =" + NumberUtil.toString(company) + " and " +
			                "ID_Plant = '" + Converter.fixString(plant) + "' and " +
			                "ID_InvoiceNum = " + NumberUtil.toString(invoiceNum);

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			OeInvoiceDtlDataBase oeInvoiceDtlDataBase = new OeInvoiceDtlDataBase(dataBaseAccess);
			oeInvoiceDtlDataBase.load(reader);
			this.Add(oeInvoiceDtlDataBase);
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
		string sql = "delete from oeinvoicedtl";

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