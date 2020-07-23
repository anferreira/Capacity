using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


/// <summary>
/// Represents a plant 
/// </summary>
public 
class PltDataBase : GenericDataBaseElement{

private string P_Plt;
private string P_PltName;
private string P_Ads1;
private string P_Ads2;
private string P_Ads3;
private string P_Ads4;
private string P_PltShort;
private DateTime P_DateUpdated;

/// <summary>
/// Constructor
/// </summary>
/// <param name="dataBaseAccess"></param>
public
PltDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

/// <summary>
/// Read data from database for field name
/// </summary>
/// <param name="reader"></param>
public override
void load(NotNullDataReader reader){
	this.P_Plt = reader.GetString("P_Plt");
	this.P_PltName = reader.GetString("P_PltName");
	this.P_Ads1 = reader.GetString("P_Ads1");
	this.P_Ads2 = reader.GetString("P_Ads2");
	this.P_Ads3 = reader.GetString("P_Ads3");
	this.P_Ads4 = reader.GetString("P_Ads4");
	this.P_PltShort = reader.GetString("P_PltShort");
	this.P_DateUpdated = reader.GetDateTime("P_DateUpdated");
}

/// <summary>
/// Read a Plant by key
/// </summary>
public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from plt where P_Plt = '" + P_Plt + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

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

/// <summary>
/// Delete a Plant by key
/// </summary>
public override
void delete(){
	try{
		string sql ="delete from plt " +
				"where " + 
				       "P_Plt = '" + P_Plt + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

/// <summary>
/// Update a Plant by key
/// </summary>
public override
void update(){
	try{
		string sql ="update plt set " +
			        "P_PltName = '" + Converter.fixString(P_PltName) + "', " +
			        "P_Ads1 = '" + Converter.fixString(P_Ads1) + "', " +
			        "P_Ads2 = '" + Converter.fixString(P_Ads2) + "', " +
			        "P_Ads3 = '" + Converter.fixString(P_Ads3) + "', " +
			        "P_Ads4 = '" + Converter.fixString(P_Ads4) + "', " +
			        "P_PltShort = '" + Converter.fixString(P_PltShort) + "', " +
					"P_DateUpdated = '" + DateUtil.getCompleteDateRepresentation(P_DateUpdated) + "' " +
				"where " + 
				       "P_Plt = '" + P_Plt + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

/// <summary>
/// Write a Plant 
/// </summary>
public override
void write(){
	try{
		string sql = "insert into plt values('" + 
			Converter.fixString(P_Plt) + "', '" +
			Converter.fixString(P_PltName) + "', '" +
			Converter.fixString(P_Ads1) + "', '" +
			Converter.fixString(P_Ads2) + "', '" +
			Converter.fixString(P_Ads3) + "', '" +
			Converter.fixString(P_Ads4) + "', '" +
			Converter.fixString(P_PltShort) + "', '" +
			DateUtil.getCompleteDateRepresentation(P_DateUpdated) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

/// <summary>
/// Return if a plant exists
/// </summary>
public
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;

		string sql = "select * from plt where P_Plt = '" + P_Plt + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;
		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


// Set methods
public
void setP_Plt(string P_Plt){
	this.P_Plt = P_Plt;
}

public
void setP_PltName(string P_PltName){
	this.P_PltName = P_PltName;
}

public
void setP_Ads1(string P_Ads1){
	this.P_Ads1 = P_Ads1;
}

public
void setP_Ads2(string P_Ads2){
	this.P_Ads2 = P_Ads2;
}

public
void setP_Ads3(string P_Ads3){
	this.P_Ads3 = P_Ads3;
}

public
void setP_Ads4(string P_Ads4){
	this.P_Ads4 = P_Ads4;
}

public
void setP_PltShort(string P_PltShort){
	this.P_PltShort = P_PltShort;
}

public
void setP_DateUpdated(DateTime P_DateUpdated){
	this.P_DateUpdated = P_DateUpdated;
}


// Get methods
public
string getP_Plt(){
	return P_Plt;
}

public
string getP_PltName(){
	return P_PltName;
}

public
string getP_Ads1(){
	return P_Ads1;
}

public
string getP_Ads2(){
	return P_Ads2;
}

public
string getP_Ads3(){
	return P_Ads3;
}

public
string getP_Ads4(){
	return P_Ads4;
}

public
string getP_PltShort(){
	return P_PltShort;
}

public
DateTime getP_DateUpdated(){
	return P_DateUpdated;
}

} // class

}
