using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Threading;
using MySql.Data;

using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access{


public 
class ConnectionManager{

public static 
IDbConnection getConnection(int connectionType){
	string sqlConnectionString = Configuration.SqlDBConnectionString;
	string oleDbConnectionString = Configuration.DBConnectionString;
	string cmsConnectionString = Configuration.CMSConnectionstring;
	string sqlTempConnectionString = Configuration.CMSTempConnectionstring;
	IDbConnection connection = null;
	int intents = 0;

	while(connection == null){
		try{
			intents++;

			switch(connectionType){
			case DataBaseAccess.NUJIT_DATABASE:
				if (Configuration.SqlRepositoryType.Equals("SQLServer")){
					connection = new SqlConnection(sqlConnectionString);
				}else{
					connection = new MySql.Data.MySqlClient.MySqlConnection(sqlConnectionString);
				}
				break;
			case DataBaseAccess.CMS_DATABASE:
				if (Configuration.CMSRepositoryType.Equals("ODBC"))
					connection = new OdbcConnection(cmsConnectionString);
				else
					connection = new OleDbConnection(cmsConnectionString);
				break;
			case DataBaseAccess.CMSTEMP_DATABASE:
				if (Configuration.SqlRepositoryType.Equals("SQLServer")){
					connection = new SqlConnection(sqlTempConnectionString);
				}else{
					connection = new MySql.Data.MySqlClient.MySqlConnection(sqlTempConnectionString);
				}
				break;
			}
		}catch(System.Exception exc){
			if (intents > 4){
				throw exc;
			}else{
				Thread.Sleep(TimeSpan.FromMinutes(1));
			}
		}
	}

	return connection;
}

} // class
} // namespace
