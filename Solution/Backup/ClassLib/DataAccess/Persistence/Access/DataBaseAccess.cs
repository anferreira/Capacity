using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using Nujit.NujitERP.ClassLib.Common;
using MySql.Data;
using System.Threading;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access{

/// <summary>
/// This class manage the database connection and
/// other operations invoked from DataBase objects in this
/// namespace
/// </summary>
public
class DataBaseAccess{

// The string connection to the SqlServer Database
//private static string oleDbConnectionString = "Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=gustavo";
//private static string sqlConnectionString = "user id=NujitUser;password=User;Initial Catalog=NUJIT3;Data Source=127.0.0.1;Integrated Security=SSPI;";

private IDbConnection connection = null;
private IDbTransaction transaction = null;

private int connectionType = NUJIT_DATABASE;

public const int NUJIT_DATABASE = 0;
public const int CMS_DATABASE = 1;
public const int CMSTEMP_DATABASE = 2;


/// <summary>
/// Contructor
/// </summary>
public
DataBaseAccess(){
	getConnection();
}

/// <summary>
/// Destructor
/// </summary>
~DataBaseAccess(){
	if ((connection != null) && (connection.State == System.Data.ConnectionState.Open)){
		connection.Close();
		connection.Dispose();
	}
	connection = null;
}


/// <summary>
/// Returns the connection type used
/// </summary>
/// <returns></returns>
public 
int getConnectionType(){ 
	return connectionType; 
}

/// <summary>
/// Initialize the connections to database
/// </summary>
/// <returns></returns>
private
IDbConnection getConnection(){
	lock(this){
		if ((connection == null) || (connection.State != System.Data.ConnectionState.Open)){
			if (connection != null){
				connection.Close();
				connection.Dispose();
			}
			connection = null;

			connection = ConnectionManager.getConnection(connectionType);
			connection.Open();
		}

		return connection;
	}
}

/// <summary>
/// Change pointers between availables connections
/// </summary>
/// <returns></returns>
public
void switchConnection(int connectionType){
	lock(this){
		if (transaction != null)
			throw new PersistenceException("There is an unclosed transaction");

		this.connectionType = connectionType;

		if (connection != null){
			connection.Close();
			connection.Dispose();
			connection = null;
		}
		
		getConnection();
	}
}

/// <summary>
/// Executes a update or insert statement in the database 
/// </summary>
/// <param name="statement"></param>
/// <returns></returns>
public
int executeUpdate(String statement){
	lock(this){
		int returnValue = 0;
		
		getConnection();
		
		System.Data.IDbCommand command = connection.CreateCommand();
		if (transaction != null)
			command.Transaction = transaction;
		command.CommandText = statement;
		command.CommandType = CommandType.Text;
		returnValue = command.ExecuteNonQuery();
		return returnValue;
	}
}

/// <summary>
/// Executes a select statement int the database
/// </summary>
/// <param name="sqlQuery"></param>
/// <returns></returns>
public
NotNullDataReader executeQuery(String sqlQuery){
	lock(this){
		bool ioexc = true;
		NotNullDataReader notNullDataReader = null;
		PersistenceException persistenceException = null;

		for(int i = 0; i < 5 && ioexc; i++){
			getConnection();

			IDbCommand command = connection.CreateCommand();
			command.CommandText = sqlQuery;

			if (transaction != null)
				command.Transaction = transaction;
			
			command.CommandType = CommandType.Text;

			ioexc = false;
			try{
				notNullDataReader = new NotNullDataReader(command.ExecuteReader());
			}catch(System.IO.IOException ioe){
				if (notNullDataReader != null)
					notNullDataReader.Close();
				notNullDataReader = null;
				
				connection.Close();
				ioexc = true;
				
				persistenceException = new PersistenceException("Cannot connect to the database #1#", ioe);
				Thread.Sleep(500);
			}catch(System.OverflowException oe){
				if (notNullDataReader != null)
					notNullDataReader.Close();
				notNullDataReader = null;
				
				connection.Close();
				ioexc = true;
				
				persistenceException = new PersistenceException("Cannot connect to the database #1#", oe);
				Thread.Sleep(500);
			}
		}

		if (ioexc)
//			throw new PersistenceException("Cannot connect to the database #1#");
			throw persistenceException;

		return notNullDataReader;
	}
}

/// <summary>
/// Begin a transaction
/// </summary>
public
void beginTransaction(){
	lock(this){
		bool ioexc = true;
		PersistenceException persistenceException = null;
		for(int i = 0; i < 5 && ioexc; i++)	{
			try	{
				if (transaction == null){
					getConnection();

					transaction = this.connection.BeginTransaction();
				}
				else{
					throw new PersistenceException("Transaction already started !!!!!");
				}
				ioexc = false;
			}catch(System.IO.IOException ioe){
				connection.Close();
				ioexc = true;
					
				persistenceException = new PersistenceException("Cannot connect to the database #1#", ioe);
				Thread.Sleep(500);
			}
		}
		if (ioexc)
			throw persistenceException;
	}
}

/// <summary>
/// Rollbacks a transaction
/// </summary>
public
void rollbackTransaction(){
	lock(this){
		if (transaction != null){
			transaction.Rollback();
			transaction = null;
		}
	}
}

/// <summary>
/// Commits a transaction
/// </summary>
public
void commitTransaction(){
	lock(this){
		transaction.Commit();
		transaction = null;
	}
}

/// <summary>
/// Used only for determinate if a table is locked in an AS400
/// </summary>
public
bool isBlocked(string libraryName, string tableName){
	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2))
		return false;
	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_1))
		return false;
	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_0))
		return false;

	libraryName += "          ";
	tableName += "          ";

	libraryName = libraryName.Substring(0, 10);
	tableName = tableName.Substring(0, 10);
	
	string commStr = "{{CALL " + '"' + Configuration.CMSProgramLibrary + '"' + ".CHKLOCK(?,?,?)}}";

	OleDbCommand objCommand = new OleDbCommand(commStr, (OleDbConnection)connection);
						
	OleDbParameter k0 = new OleDbParameter("Parm0", libraryName);
	k0.Direction = ParameterDirection.InputOutput;
	k0.Size = 10;
	k0.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(k0);

	OleDbParameter k1 = new OleDbParameter("Parm1", tableName);
	k1.Direction = ParameterDirection.InputOutput;
	k1.Size = 10;
	k1.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(k1);

	string block = " ";
	OleDbParameter k2 = new OleDbParameter("Parm2", block);
	k2.Direction = ParameterDirection.InputOutput;
	k2.Size = 1;
	k2.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(k2);
	
	int result = 0;
	result = objCommand.ExecuteNonQuery();
	
	if (objCommand.Parameters["Parm2"].Value.Equals("Y"))
		return true;
	return false;
}

/// <summary>
/// Used for autonumeric fields
/// </summary>
public 
int getLastId(){
	int intID = 0;

	if ((connectionType == NUJIT_DATABASE) || (connectionType == CMSTEMP_DATABASE)){
		string sentence = "";
		if (Configuration.SqlRepositoryType.Equals("SQLServer"))
			sentence = "select @@IDENTITY";
		else
			sentence = "select last_insert_id()";

		getConnection();

		System.Data.IDbCommand command = connection.CreateCommand();
		if (transaction != null)
			command.Transaction = transaction;
		command.CommandText = sentence;
		command.CommandType = CommandType.Text;
		intID = Convert.ToInt32(command.ExecuteScalar().ToString());
	}else{
		throw new PersistenceException("Operation is not allowed here");
	}
	return intID;	
}

/// <summary>
/// Send a OrderHeader to CMS, true indicate OK, otherwise fails
/// </summary>
/// <param name="cmsOrderLineID"></param>
/// <returns></returns>
public
bool sendOrderHeaderToCMS(string p0_Mode, out string p0_Order, string p0_BillCust, string p0_BContact, string p0_BCustPhone,
		string p0_ShipCust, string p0_SCustName, string p0_SCustAdd1, string p0_SCustAdd2,
		string p0_SCustAdd3, string p0_SCustAdd4, string p0_SCustPC, string p0_Carrier,
		string p0_Service, string p0_PO, string p0_Notes, string p0_IbmAuth, string p0_Attention,
		string p0_ShipComp, string p0_AllowBO){

	p0_Mode += "                                   ";
	p0_BillCust += "                                   ";
	p0_BContact += "                                   ";
	p0_BCustPhone += "                                   ";
	p0_ShipCust += "                                   ";
	p0_SCustName += "                                   ";
	p0_SCustAdd1 += "                                   ";
	p0_SCustAdd2 += "                                   ";
	p0_SCustAdd3 += "                                   ";
	p0_SCustAdd4 += "                                   ";
	p0_SCustPC += "                                   ";
	p0_Carrier += "                                   ";
	p0_Service += "                                   ";
	p0_PO += "                                   ";
	p0_Notes += "                                   ";
	p0_Notes += "                                   ";
	p0_Notes += "                                   ";
	p0_IbmAuth += "                                   ";
	p0_Attention += "                                   ";
	p0_ShipComp += "                                   ";
	p0_AllowBO += "                                   ";
	p0_Order = "                                   ";

//	string commStr = "{{CALL " + '"' + Configuration.CMSProgramLibrary + '"' + 
//		".ORDHDRAPI(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}}";
	string commStr = "{{CALL " + '"' + Configuration.CMSProgramLibrary + '"' + 
		".APIINTHDR(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}}";

	string p0_RtnCode = " ";

	System.Data.OleDb.OleDbConnection conn = (System.Data.OleDb.OleDbConnection)ConnectionManager.getConnection(DataBaseAccess.CMS_DATABASE);
	conn.Open();

	OleDbCommand objCommand = new OleDbCommand(commStr, conn);

//d p0_Mode         s              2                                      
//d p0_Order#       s              9s 0                                   
//d p0_BillCust#    s              8                                      
//d p0_BContact     s             25                                      
//d p0_BCustPhone   s             20                                      
//d p0_ShipCust#    s              8                                      
//d p0_SCustName    s             30                                      
//d p0_SCustAdd1    s             35                                      
//d p0_SCustAdd2    s             35                                      
//d p0_SCustAdd3    s             35                                      
//d p0_SCustAdd4    s             35                                      
//d p0_SCustPC      s             30                                      
//d p0_Carrier      s             17                                      
//d p0_Service      s              3                                   
//d p0_PO#          s             30                                   
//d p0_Notes        s             80                                   
//d p0_IbmAuth#     s             10                                   
//d p0_DropShipID   s             20                                   
//d p0_ShipComp     s              1                                   
//d p0_AllowBO      s              1                                   
//d p0_RtnCode      s              1
									 
									 
	OleDbParameter p0 = new OleDbParameter("Parm0", p0_Mode.Substring(0, 2));
	p0.Direction = ParameterDirection.InputOutput;
	p0.Size = 2;
	p0.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p0);

	OleDbParameter p1 = new OleDbParameter("Parm1", p0_Order.Substring(0,9));
	p1.Direction = ParameterDirection.InputOutput;
	p1.Size = 9;
	p1.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p1);

	OleDbParameter p2 = new OleDbParameter("Parm2", p0_BillCust.Substring(0, 8));
	p2.Direction = ParameterDirection.InputOutput;
	p2.Size = 8;
	p2.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p2);
	
	OleDbParameter p3 = new OleDbParameter("Parm3", p0_BContact.Substring(0, 25));
	p3.Direction = ParameterDirection.InputOutput;
	p3.Size = 25;
	p3.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p3);

	OleDbParameter p4 = new OleDbParameter("Parm4", p0_BCustPhone.Substring(0, 20));
	p4.Direction = ParameterDirection.InputOutput;
	p4.Size = 20;
	p4.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p4);

	OleDbParameter p5 = new OleDbParameter("Parm5", p0_ShipCust.Substring(0, 8));
	p5.Direction = ParameterDirection.InputOutput;
	p5.Size = 8;
	p5.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p5);

	OleDbParameter p6 = new OleDbParameter("Parm6", p0_SCustName.Substring(0, 30));
	p6.Direction = ParameterDirection.InputOutput;
	p6.Size = 30;
	p6.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p6);

	OleDbParameter p7 = new OleDbParameter("Parm7", p0_SCustAdd1.Substring(0, 35));
	p7.Direction = ParameterDirection.InputOutput;
	p7.Size = 35;
	p7.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p7);

	OleDbParameter p8 = new OleDbParameter("Parm8", p0_SCustAdd2.Substring(0, 35));
	p8.Direction = ParameterDirection.InputOutput;
	p8.Size = 35;
	p8.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p8);

	OleDbParameter p9 = new OleDbParameter("Parm9", p0_SCustAdd3.Substring(0, 35));
	p9.Direction = ParameterDirection.InputOutput;
	p9.Size = 35;
	p9.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p9);

	OleDbParameter p10 = new OleDbParameter("Parm10", p0_SCustAdd4.Substring(0, 35));
	p10.Direction = ParameterDirection.InputOutput;
	p10.Size = 35;
	p10.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p10);

	OleDbParameter p11 = new OleDbParameter("Parm11", p0_SCustPC.Substring(0, 30));
	p11.Direction = ParameterDirection.InputOutput;
	p11.Size = 30;
	p11.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p11);

	OleDbParameter p12 = new OleDbParameter("Parm12", p0_Carrier.Substring(0, 17));
	p12.Direction = ParameterDirection.InputOutput;
	p12.Size = 17;
	p12.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p12);

	OleDbParameter p13 = new OleDbParameter("Parm13", p0_Service.Substring(0, 3));
	p13.Direction = ParameterDirection.InputOutput;
	p13.Size = 3;
	p13.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p13);

	OleDbParameter p14 = new OleDbParameter("Parm14", p0_PO.Substring(0, 30));
	p14.Direction = ParameterDirection.InputOutput;
	p14.Size = 30;
	p14.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p14);

	OleDbParameter p15 = new OleDbParameter("Parm15", p0_Notes.Substring(0, 80));
	p15.Direction = ParameterDirection.InputOutput;
	p15.Size = 80;
	p15.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p15);

	OleDbParameter p16 = new OleDbParameter("Parm16", p0_IbmAuth.Substring(0, 10));
	p16.Direction = ParameterDirection.InputOutput;
	p16.Size = 10;
	p16.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p16);

	OleDbParameter p17 = new OleDbParameter("Parm17", p0_Attention.Substring(0, 20));
	p17.Direction = ParameterDirection.InputOutput;
	p17.Size = 20;
	p17.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p17);

	OleDbParameter p18 = new OleDbParameter("Parm18", p0_ShipComp.Substring(0, 1));
	p18.Direction = ParameterDirection.InputOutput;
	p18.Size = 1;
	p18.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p18);

	OleDbParameter p19 = new OleDbParameter("Parm19", p0_AllowBO.Substring(0, 1));
	p19.Direction = ParameterDirection.InputOutput;
	p19.Size = 1;
	p19.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p19);

	OleDbParameter p20 = new OleDbParameter("Parm20", p0_RtnCode.Substring(0, 1));
	p20.Direction = ParameterDirection.InputOutput;
	p20.Size = 1;
	p20.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p20);

	int result = 0;
	result = objCommand.ExecuteNonQuery();


	p0_Order = (string)objCommand.Parameters["Parm1"].Value;

	return true;
}
	
/// <summary>
/// Send a OrderLine to CMS, true indicate OK, otherwise fails
/// </summary>
/// <param name="cmsOrderLineID"></param>
/// <returns></returns>
public
bool sendOrderLineToCMS(string p0_Mode, string p0_Order, string p0_FrtExempt, int p0_RtnArrayQty, string p0_OptionLst,
						string p0_Parts, string p0_PrcUnits, string p0_Prices, string p0_Qtys, string p0_DisAmt,
						string p0_DisCode, string p0_Cost, string p0_FrtAmt, string p0_PartType,
						string p0_RtnCode){



//	string commStr = "{{CALL " + '"' + Configuration.CMSProgramLibrary + '"' + 
//		".ORDDTLAPI(?,?,?,?,?,?,?,?,?,?,?,?,?,?)}}";
	string commStr = "{{CALL " + '"' + Configuration.CMSProgramLibrary + '"' + 
		".APIINTDTL(?,?,?,?,?,?,?,?,?,?,?,?,?,?)}}";

	System.Data.OleDb.OleDbConnection conn = (System.Data.OleDb.OleDbConnection)ConnectionManager.getConnection(DataBaseAccess.CMS_DATABASE);
	conn.Open();

	OleDbCommand objCommand = new OleDbCommand(commStr, conn);

	OleDbParameter p0 = new OleDbParameter("Parm0", p0_Mode.Substring(0, 2));
	p0.Direction = ParameterDirection.InputOutput;
	p0.Size = 2;
	p0.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p0);

	p0_Order += "                                      ";
	OleDbParameter p1 = new OleDbParameter("Parm1", p0_Order.Substring(0, 9));
	p1.Direction = ParameterDirection.InputOutput;
	p1.Size = 9;
	p1.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p1);

	OleDbParameter p2 = new OleDbParameter("Parm2", p0_FrtExempt);
	p2.Direction = ParameterDirection.InputOutput;
	p2.Size = 1;
	p2.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p2);
	
	string aux2 = p0_RtnArrayQty.ToString() + "                                      ";
	OleDbParameter p3 = new OleDbParameter("Parm3", aux2.Substring(0, 3));
	p3.Direction = ParameterDirection.InputOutput;
	p3.Size = 3;
	p3.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p3);

	OleDbParameter p4 = new OleDbParameter("Parm4", p0_OptionLst);
	p4.Direction = ParameterDirection.InputOutput;
	p4.Size = 700;
//	p4.Precision = 0;
	p4.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p4);

	OleDbParameter p5 = new OleDbParameter("Parm5", p0_Parts);
	p5.Direction = ParameterDirection.InputOutput;
	p5.Size = 2000;
	p5.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p5);

	OleDbParameter p6 = new OleDbParameter("Parm6", p0_PrcUnits);
	p6.Direction = ParameterDirection.InputOutput;
	p6.Size = 300;
	p6.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p6);

	OleDbParameter p7 = new OleDbParameter("Parm7", p0_Prices);
	p7.Direction = ParameterDirection.InputOutput;
	p7.Size = 1000;
//	p7.Precision = 2;
	p7.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p7);

	OleDbParameter p8 = new OleDbParameter("Parm8", p0_Qtys);
	p8.Direction = ParameterDirection.InputOutput;
	p8.Size = 600;
//	p8.Precision = 0;
	p8.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p8);

	OleDbParameter p9 = new OleDbParameter("Parm9", p0_DisAmt);
	p9.Direction = ParameterDirection.InputOutput;
	p9.Size = 1000;
//	p9.Precision = 2;
	p9.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p9);

	OleDbParameter p10 = new OleDbParameter("Parm10", p0_DisCode);
	p10.Direction = ParameterDirection.InputOutput;
	p10.Size = 400;
	p10.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p10);

	OleDbParameter p11 = new OleDbParameter("Parm11", p0_Cost);
	p11.Direction = ParameterDirection.InputOutput;
	p11.Size = 1000;
//	p11.Precision = 2;
	p11.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p11);

	OleDbParameter p12 = new OleDbParameter("Parm12", p0_FrtAmt);
	p12.Direction = ParameterDirection.InputOutput;
	p12.Size = 1000;
//	p12.Precision = 2;
	p12.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p12);

	OleDbParameter p13 = new OleDbParameter("Parm13", p0_PartType);
	p13.Direction = ParameterDirection.InputOutput;
	p13.Size = 100;
	p13.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p13);

	OleDbParameter p14 = new OleDbParameter("Parm14", p0_RtnCode);
	p14.Direction = ParameterDirection.InputOutput;
	p14.Size = 1;
	p14.OleDbType = OleDbType.Char;
	objCommand.Parameters.Add(p14);

	int result = 0;
	result = objCommand.ExecuteNonQuery();

	return true;
}

} // class

} // namespace
