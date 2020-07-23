using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ArInvoiceAsgDataBaseContainer	: GenericDataBaseContainer{


private string ARIA_Plant;

public 
ArInvoiceAsgDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoiceasg ";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceAsgDataBase arInvoiceAsgDataBase = new ArInvoiceAsgDataBase(dataBaseAccess);
			arInvoiceAsgDataBase.load(reader);
			this.Add(arInvoiceAsgDataBase);
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
string[][] getByDebAndPoa(){
    NotNullDataReader reader = null;
	try	{
		string sql = "select ARIA_ID,ARIA_DB,ARIA_Company,ARIA_InvoiceN,ARIA_InvoiceNum,ARIA_InvItemNum," +
					        "ARIA_Plant,ARIA_Program,ARIA_InvClass,ARIA_InvType,ARIA_SalesPerson,ARIA_Territory,"+
				            "ARIA_GLAccountNum,ARIA_CustRefInv,ARIA_RefInvDate,ARIA_OtherDes,ARIA_DebitRC,ARIA_UserID," +
				            "ARIA_Date,ARIA_Status,ARIA_Notes, ARI_CustNum " +
					"from arinvoiceasg, arinvoice " +
					"where ARIA_InvType ='DEB' and " + 
							"ARIA_Plant = ARI_Plant and " +
							"ARIA_Company =ARI_Company and " +
							"ARIA_Db = ARIA_Db and " +
							"ARIA_InvoiceN =ARI_ArInvoiceN  or " +
							"ARIA_InvType ='POA' and " + 
							"ARIA_Plant = ARI_Plant and " +
							"ARIA_Company =ARI_Company and " +
							"ARIA_Db = ARIA_Db and " +
							"ARIA_InvoiceN =ARI_ArInvoiceN " +	   
					"order by ARIA_InvoiceN, ARIA_InvItemNum"; 
 
		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			ArInvoiceAsgDataBase arInvoiceAsgDataBase = new ArInvoiceAsgDataBase(dataBaseAccess);
	
			string[] line = new string[22];
			getReaderAsString(reader,line);
			array.Add((object)line);
		}
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		return returnArray;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getByDebAndPoa>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getByDebAndPoa>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getByDebAndPoa> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public 
string[][] getByByInvoiceN(string invoiceN){
    NotNullDataReader reader = null;
	try{
		string sql = "select ARIA_ID,ARIA_DB,ARIA_Company,ARIA_InvoiceN,ARIA_InvoiceNum,ARIA_InvItemNum," +
						    "ARIA_Plant,ARIA_Program,ARIA_InvClass,ARIA_InvType,ARIA_SalesPerson,ARIA_Territory,"+
						    "ARIA_GLAccountNum,ARIA_CustRefInv,ARIA_RefInvDate,ARIA_OtherDes,ARIA_DebitRC,ARIA_UserID," +
						    "ARIA_Date,ARIA_Status,ARIA_Notes, ARI_CustNum " +
					 "from arinvoiceasg, arinvoice " +
					 "where " +
						"ARIA_InvoiceN = '" +Converter.fixString(invoiceN) +"' and " +
						"ARIA_Plant    = ARI_Plant and " +
						"ARIA_Company  = ARI_Company and " +
						"ARIA_Db       = ARIA_Db and " +
						"ARIA_InvoiceN = ARI_ArInvoiceN " +	   
					"order by ARIA_InvoiceN, ARIA_InvItemNum";

		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			ArInvoiceAsgDataBase arInvoiceAsgDataBase = new ArInvoiceAsgDataBase(dataBaseAccess);
		
			string[] line = new string[22];
			getReaderAsString(reader,line);
			array.Add((object)line);
		}
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		return returnArray;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getByByInvoice>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getByByInvoice>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getByByInvoice> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

private 
void getReaderAsString(NotNullDataReader reader,string[] line){
	line[0]= reader.GetString("ARIA_InvoiceN");
	line[1]=reader.GetString("ARI_CustNum");
	line[2]= reader.GetInt32("ARIA_InvoiceNum").ToString();
	line[3]= reader.GetInt32("ARIA_InvItemNum").ToString();
	line[4]= reader.GetString("ARIA_DB");
	line[5]= reader.GetString("ARIA_Company");
	line[6]= reader.GetString("ARIA_Plant");
	line[7]= reader.GetString("ARIA_Program");
	line[8]= reader.GetString("ARIA_InvClass");
	line[9]= reader.GetString("ARIA_InvType");
	line[10]= reader.GetString("ARIA_SalesPerson");
	line[11]= reader.GetString("ARIA_Territory");
	line[12]= reader.GetInt32("ARIA_GLAccountNum").ToString();
	line[13]= reader.GetString("ARIA_CustRefInv");
	line[14]= DateUtil.getDateRepresentation(reader.GetDateTime("ARIA_RefInvDate"), DateUtil.MMDDYYYY);
	line[15]= reader.GetString("ARIA_OtherDes");
	line[16]= reader.GetString("ARIA_DebitRC");
	line[17]= reader.GetString("ARIA_UserID");
	line[18]= DateUtil.getDateRepresentation(reader.GetDateTime("ARIA_Date"), DateUtil.MMDDYYYY);
	line[19]= reader.GetString("ARIA_Status");
	line[20]= reader.GetString("ARIA_Notes");
	line[21]= reader.GetInt32("ARIA_ID").ToString();		
}

public 
void readByOrder(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoiceasg " +
					"order by ARIA_ID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ArInvoiceAsgDataBase arInvoiceAsgDataBase = new ArInvoiceAsgDataBase(dataBaseAccess);
			arInvoiceAsgDataBase.load(reader);
			this.Add(arInvoiceAsgDataBase);
		}
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOrder>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOrder>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByOrder> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from arinvoiceasg";
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
void setARIA_Plant(string ARIA_Plant){
   this.ARIA_Plant = ARIA_Plant;
}


//Getters
public
string getARIA_Plant(){
   return ARIA_Plant;
}

}//end class

}//end namespace
