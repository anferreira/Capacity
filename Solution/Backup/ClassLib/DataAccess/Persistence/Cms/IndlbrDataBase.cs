using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class IndlbrDataBase : GenericDataBaseElement{

private string AFCODE;
private string AFDES1;
private string AFBK01;
 
public 
IndlbrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.AFCODE = reader.GetString("AFCODE");
	this.AFDES1 = reader.GetString("AFDES1");
	this.AFBK01 = reader.GetString("AFBK01");
}


public override
void write(){
	try{
		string sql = "insert into ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		sql += "indlbr values('" +
	            Converter.fixString(AFCODE) +"', '" +
				Converter.fixString(AFDES1) +"', '" +
                Converter.fixString(AFBK01) +"')";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";

		sql += "indlbr where AFCODE = '" + Converter.fixString(AFCODE) + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setAFCODE(string AFCODE){
	this.AFCODE = AFCODE;
}

public
void setAFDES1(string AFDES1){
	this.AFDES1 = AFDES1;
}

public
void setAFBK01(string AFBK01){
	this.AFBK01 = AFBK01;
}


public
string getAFCODE(){
	return AFCODE;
}

public
string getAFDES1(){
	return AFDES1;
}

public
string getAFBK01(){
	return AFBK01;
}

}//end class

}//end namespace
