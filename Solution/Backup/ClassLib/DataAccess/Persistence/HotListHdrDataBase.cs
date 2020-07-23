using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class HotListHdrDataBase : GenericDataBaseElement{

private int id;
private DateTime HLR_HotlistRunDate;
private DateTime HLR_HotlistExpDate;

public
HotListHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.id = reader.GetInt32("id");
	this.HLR_HotlistRunDate = reader.GetDateTime("HLR_HotlistRunDate");
	this.HLR_HotlistExpDate = reader.GetDateTime("HLR_HotlistExpDate");
}

public override
void write(){
	try{
		string sql = "insert into hotlisthdr(HLR_HotlistRunDate, HLR_HotlistExpDate)" + 
		" values('" + 
			DateUtil.getCompleteDateRepresentation(HLR_HotlistRunDate) + "', '" +
			DateUtil.getCompleteDateRepresentation(HLR_HotlistExpDate) + "')";

		dataBaseAccess.executeUpdate(sql);

		this.id = dataBaseAccess.getLastId();
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
	try{
		string sql = "update hotlisthdr set HLR_HotlistExpDate = '" + 
			DateUtil.getCompleteDateRepresentation(HLR_HotlistExpDate) + 
			"' where id = "  + id.ToString();

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public 
int readLastId(){
	NotNullDataReader reader = null;
	try{
		int maxId = 0;
		string sql = "select max(id) as maxId from hotlisthdr";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			maxId = reader.GetInt32("maxId");
		return maxId;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setId(int id){
	this.id = id;
}

public
void setHLR_HotlistRunDate(DateTime HLR_HotlistRunDate){
	this.HLR_HotlistRunDate = HLR_HotlistRunDate;
}

public
void setHLR_HotlistExpDate(DateTime HLR_HotlistExpDate){
	this.HLR_HotlistExpDate = HLR_HotlistExpDate;
}


public
int getId(){
	return id;
}

public
DateTime getHLR_HotlistRunDate(){
	return HLR_HotlistRunDate;
}

public
DateTime getHLR_HotlistExpDate(){
	return HLR_HotlistExpDate;
}

} // class

} // namespace