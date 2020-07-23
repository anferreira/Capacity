using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class ScrapDataBaseContainer : GenericDataBaseContainer{

private DateTime BODATE;
private string BOSHFT;
private string BODEPT;
private string BORESC;
private string BOPART;
private decimal BOSEQN;

public 
ScrapDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
	    string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary_2nd + ".";
		sql += "scrap";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ScrapDataBase scrapDataBase = new ScrapDataBase(dataBaseAccess);
			scrapDataBase.load(reader);
			this.Add(scrapDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readForPrHist(){
	NotNullDataReader reader = null;
	try{
	    string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary_2nd + ".";
		sql += "scrap where " +
			"BODATE = '" + DateUtil.getDateRepresentation(BODATE, DateUtil.YYYYMMDD_AS) + "' and " +
			"BOSHFT = '" + Converter.fixString(BOSHFT) + "' and " +
			"BODEPT = '" + Converter.fixString(BODEPT) + "' and " +
			"BORESC = '" + Converter.fixString(BORESC) + "' and " +
			"BOPART = '" + Converter.fixString(BOPART) + "' and " +
			"BOSEQN = " + NumberUtil.toString(BOSEQN);

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ScrapDataBase scrapDataBase = new ScrapDataBase(dataBaseAccess);
			scrapDataBase.load(reader);
			this.Add(scrapDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from scrap";
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
void setBODATE(DateTime BODATE){
	this.BODATE = BODATE;
}

public
void setBOSHFT(string BOSHFT){
	this.BOSHFT = BOSHFT;
}

public
void setBODEPT(string BODEPT){
	this.BODEPT = BODEPT;
}

public
void setBORESC(string BORESC){
	this.BORESC = BORESC;
}

public
void setBOPART(string BOPART){
	this.BOPART = BOPART;
}

public
void setBOSEQN(decimal BOSEQN){
	this.BOSEQN = BOSEQN;
}


public
DateTime getBODATE(){
	return BODATE;
}

public
string getBOSHFT(){
	return BOSHFT;
}

public
string getBODEPT(){
	return BODEPT;
}

public
string getBORESC(){
	return BORESC;
}

public
string getBOPART(){
	return BOPART;
}

public
decimal getBOSEQN(){
	return BOSEQN;
}

}//end class

}//end namespace
