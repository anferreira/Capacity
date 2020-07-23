using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
#if !POCKET_PC
using MySql.Data;
#endif

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class GroupDiscDataBase : GenericDataBaseElement{
	
private int			PRGD_id;
private string		PRGD_GroupCode;
private int			PRGD_DiscNum;
private string		PRGD_DiscCode;
private DateTime	PRGD_DateUpdated;



public GroupDiscDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public 
void read(){
	try{
		string sql = "select * from groupdisc where PRGD_GroupCode = '" + PRGD_GroupCode + "'";
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

		reader.Close();
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <read>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBase <read>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <read>: " + de.Message,de);
	}
}
	
public 
bool exists(){
	try{
		bool returnValue = false;
		string	sql =	"select * from groupdisc where " + 
						" PRGD_GroupCode = '"	+ PRGD_GroupCode	+ "' and " +		
						" PRGD_DiscNum= "		+ PRGD_DiscNum;
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		reader.Close();

		return returnValue;
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <exists>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBase <exists>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <exists>: " + de.Message,de);
	}
}


public 
void load(NotNullDataReader reader){

	this.PRGD_id			= reader.GetInt32("PRGD_id");	
	this.PRGD_GroupCode		= reader.GetString("PRGD_GroupCode");
	this.PRGD_DiscNum		= reader.GetInt32("PRGD_DiscNum");
	this.PRGD_DiscCode		= reader.GetString("PRGD_DiscCode");	
	this.PRGD_DateUpdated	= reader.GetDateTime("PRGD_DateUpdated");
}

public override 
void write(){
	try{	
		string sql = "insert into groupdisc(PRGD_GroupCode,PRGD_DiscNum,PRGD_DiscCode,PRGD_DateUpdated)" +			
			"values('" + 
			Converter.fixString(PRGD_GroupCode)	+ "'," +
			PRGD_DiscNum.ToString()				+ ",'"	+
			Converter.fixString(PRGD_DiscCode)	+ "','" + 
			DateUtil.getCompleteDateRepresentation(PRGD_DateUpdated) + "')";

		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <write>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBase <write>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <write>: " + de.Message,de);
	}
}

public override 
void update(){
	try{
		string sql ="update groupdisc set " +			
					"PRGD_DiscCode='"		+ Converter.fixString(PRGD_DiscCode)+ "'," +
					"PRGD_DateUpdated='"	+ DateUtil.getCompleteDateRepresentation(PRGD_DateUpdated) + "'" +
					" where "				+					
					" PRGD_GroupCode = '"	+ PRGD_GroupCode	+ "' and " +		
					" PRGD_DiscNum= "		+ PRGD_DiscNum;
			
		dataBaseAccess.executeUpdate(sql);

	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <update>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBase <update>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <update>: " + de.Message,de);
	}
}

public override 
void delete(){
	try{
		string sql =	"delete from groupdisc where " +
						" PRGD_GroupCode = '"	+ PRGD_GroupCode	+ "' and " +
						" PRGD_DiscNum= "		+ PRGD_DiscNum;
	
		dataBaseAccess.executeUpdate(sql);
	}
	catch(System.Data.SqlClient.SqlException se)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <delete>: " + se.Message,se);
	}
#if POCKET_PC
	catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class GroupDiscDataBase <delete>: " + sCe.Message);
	}
#else
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
#endif
	catch(System.Data.DataException de)
	{
		throw new PersistenceException("Error in class GroupDiscDataBase <delete>: " + de.Message,de);
	}
}

public
void setPRGD_GroupCode(string PRGD_GroupCode){
	this.PRGD_GroupCode = PRGD_GroupCode;
}

public
void setPRGD_DiscNum(int PRGD_DiscNum)
{
	this.PRGD_DiscNum = PRGD_DiscNum;
}

public
void setPRGD_DiscCode(string PRGD_DiscCode){
	this.PRGD_DiscCode = PRGD_DiscCode;
}

public 
void setPRGD_id(int PRGD_id)
{
	this.PRGD_id = PRGD_id;
}

public 
void setPRGD_DateUpdated(DateTime PRGD_DateUpdated)
{
	this.PRGD_DateUpdated = PRGD_DateUpdated;
}

public
	string getPRGD_GroupCode()
{
	return this.PRGD_GroupCode;
}
public
	int getPRGD_DiscNum()
{
	return this.PRGD_DiscNum;
}

public
	string getPRGD_DiscCode()
{
	return PRGD_DiscCode;
}
public 
int getPRGD_id()
{
	return PRGD_id;
}

public 
DateTime getPRGD_DateUpdated()
{
	return this.PRGD_DateUpdated;
	
}



} // class

} // namespace
