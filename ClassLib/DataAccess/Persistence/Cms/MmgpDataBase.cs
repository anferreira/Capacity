using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class MmgpDataBase : GenericDataBaseElement{


private string BRMGRP;
private string BRDES;
private string BR2;
private string BRGRP;
private string BR6;


public 
MmgpDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.BRMGRP = reader.GetString("BRMGRP");
	this.BRDES = reader.GetString("BRDES");
	this.BR2 = reader.GetString("BR2");
	this.BRGRP = reader.GetString("BRGRP");

	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_0))
		this.BR6 = reader.GetString("BR6");
}

public override
void write(){
    try{
		string sql = "insert into mmgp values('" +
                Converter.fixString(BRMGRP) + "', '" +
                Converter.fixString(BRDES) +"', '" +
                Converter.fixString(BR2) +"', '" +
                Converter.fixString(BRGRP) +"', '" +
                Converter.fixString(BR6) +"')";
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
void readByMinorGroup(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from mmgp where BRMGRP = '" + Converter.fixString(BRMGRP) + "'";
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

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setBRMGRP(string BRMGRP){
	this.BRMGRP = BRMGRP;
}

public
void setBRDES(string BRDES){
	this.BRDES = BRDES;
}

public
void setBR2(string BR2){
	this.BR2 = BR2;
}

public
void setBRGRP(string BRGRP){
	this.BRGRP = BRGRP;
}

public
void setBR6(string BR6){
	this.BR6 = BR6;
}


public
string getBRMGRP(){
	return BRMGRP;
}

public
string getBRDES(){
	return BRDES;
}

public
string getBR2(){
	return BR2;
}

public
string getBRGRP(){
	return BRGRP;
}

public
string getBR6(){
	return BR6;
}


}//end class

}//end namespace
