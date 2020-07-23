using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Threading;
using MySql.Data;

using Nujit.NujitERP.ClassLib.Common;
using Npgsql;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access{


public 
class ConnectionManager{
public static string CURRENT_DATABASE = "";
public static int CURRENT_CONNECTION_TYPE = -1;

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

                switch(Configuration.SqlRepositoryType){
                    case DataBaseAccess.SQLSERVER:
                        CURRENT_DATABASE = DataBaseAccess.SQLSERVER;
                        connection = new SqlConnection(sqlConnectionString);
                        break;
                    case DataBaseAccess.MYSQL:
                        CURRENT_DATABASE = DataBaseAccess.MYSQL;
                        connection = new MySql.Data.MySqlClient.MySqlConnection(sqlConnectionString);
                        break;
                    case DataBaseAccess.POSTGRESQL:
                        CURRENT_DATABASE = DataBaseAccess.POSTGRESQL;
                        connection = new NpgsqlConnection(sqlConnectionString);
                        break;
                }
				
				break;
			case DataBaseAccess.CMS_DATABASE:
				if (Configuration.CMSRepositoryType.Equals("ODBC")){
                    CURRENT_DATABASE = DataBaseAccess.ODBC;
                    connection = new OdbcConnection(cmsConnectionString);
				}else{
                    CURRENT_DATABASE = DataBaseAccess.OLEDB;
                    connection = new OleDbConnection(cmsConnectionString);
                }   
				break;
			case DataBaseAccess.CMSTEMP_DATABASE:
                switch(Configuration.SqlRepositoryType){
                    case DataBaseAccess.SQLSERVER:
                        CURRENT_DATABASE = DataBaseAccess.SQLSERVER;
                        connection = new SqlConnection(sqlTempConnectionString);
                        break;
                    case DataBaseAccess.MYSQL:
                        CURRENT_DATABASE = DataBaseAccess.MYSQL;
                        connection = new MySql.Data.MySqlClient.MySqlConnection(sqlTempConnectionString);
                        break;
                    case DataBaseAccess.POSTGRESQL:
                        CURRENT_DATABASE = DataBaseAccess.POSTGRESQL;
                        connection = new NpgsqlConnection(sqlTempConnectionString);
                        break;
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

    CURRENT_CONNECTION_TYPE = connectionType;
	return connection;
}

public static
string getCURRENT_DATABASE() {
    return CURRENT_DATABASE;
}

public static
int getCURRENT_CONNECTION_TYPE(){
    return CURRENT_CONNECTION_TYPE;
}

} // class
} // namespace
