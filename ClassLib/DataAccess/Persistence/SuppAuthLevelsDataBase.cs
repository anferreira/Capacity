using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

//using Nujit.NujitERP.ClassLib.Util;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SuppAuthLevelsDataBase : GenericDataBaseElement{

private int ID;
private string AL_AuthorLev;
private string AL_ALDesc;
private string AL_Shipment;
private string AL_Production;
private string AL_Material;
private string AL_Forecast;

public
SuppAuthLevelsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.AL_AuthorLev = reader.GetString("AL_AuthorLev");
	this.AL_ALDesc = reader.GetString("AL_ALDesc");
	this.AL_Shipment = reader.GetString("AL_Shipment");
	this.AL_Production = reader.GetString("AL_Production");
	this.AL_Material = reader.GetString("AL_Material");
	this.AL_Forecast = reader.GetString("AL_Forecast");
}

public override
void write(){
	try{
		string sql = "insert into suppauthlevels('" + 
			Converter.fixString(AL_AuthorLev) + "', '" +
			Converter.fixString(AL_ALDesc) + "', '" +
			Converter.fixString(AL_Shipment) + "', " +
			Converter.fixString(AL_Production) + "', '" +
			Converter.fixString(AL_Material) + "', '" +
			Converter.fixString(AL_Forecast) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	try{
		string sql = "delete from suppauthlevels where ID = " + ID.ToString();

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void setID(int ID){
	this.ID = ID;
}

public
void setAL_AuthorLev(string AL_AuthorLev){
	this.AL_AuthorLev = AL_AuthorLev;
}

public
void setAL_ALDesc(string AL_ALDesc){
	this.AL_ALDesc = AL_ALDesc;
}

public
void setAL_Shipment(string AL_Shipment){
	this.AL_Shipment = AL_Shipment;
}

public
void setAL_Production(string AL_Production){
	this.AL_Production = AL_Production;
}

public
void setAL_Material(string AL_Material){
	this.AL_Material = AL_Material;
}

public
void setAL_Forecast(string AL_Forecast){
	this.AL_Forecast = AL_Forecast;
}


public
int getID(){
	return ID;
}

public
string getAL_AuthorLev(){
	return AL_AuthorLev;
}

public
string getAL_ALDesc(){
	return AL_ALDesc;
}

public
string getAL_Shipment(){
	return AL_Shipment;
}

public
string getAL_Production(){
	return AL_Production;
}

public
string getAL_Material(){
	return AL_Material;
}

public
string getAL_Forecast(){
	return AL_Forecast;
}


} // class

} // namespace