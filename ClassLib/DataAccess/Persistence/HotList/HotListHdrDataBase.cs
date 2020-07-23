using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class HotListHdrDataBase : GenericDataBaseElement{

private int id;
private DateTime HLR_HotlistRunDate;
private DateTime HLR_HotlistExpDate;
private string HLR_Plant;

public
HotListHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
bool read(){
	string sql = "select * from hotlisthdr where " + getWhereCondition();
	return read(sql);
}

public
bool readPriorLastByFilter(string splant){
    string sqlBase = "select max(id) from hotlisthdr";
    string sqlPriorId="";
    
    if (!string.IsNullOrEmpty(splant))
        sqlBase = DBFormatter.addWhereAndSentence(sqlBase) + " HLR_Plant = '" + splant +"'";
    
    sqlPriorId = "(" + DBFormatter.addWhereAndSentence(sqlBase) + " Id < (" + sqlBase + "))";
            
    string sql = "select * from hotlisthdr h where h.Id in " + sqlPriorId;
    
	return read(sql);	
}

public
string getWhereCondition(){
	string sqlWhere =
        "id = " + NumberUtil.toString(id) + "";
	return sqlWhere;
}


public override
void load(NotNullDataReader reader){
	this.id = reader.GetInt32("id");
	this.HLR_HotlistRunDate = reader.GetDateTime("HLR_HotlistRunDate");
	this.HLR_HotlistExpDate = reader.GetDateTime("HLR_HotlistExpDate");
    this.HLR_Plant = reader.GetString("HLR_Plant");
}

public override
void write(){
	try{
		string sql = "insert into hotlisthdr(HLR_HotlistRunDate, HLR_HotlistExpDate,HLR_Plant)" + 
		" values('" + 
			DateUtil.getCompleteDateRepresentation(HLR_HotlistRunDate) + "', '" +
			DateUtil.getCompleteDateRepresentation(HLR_HotlistExpDate) + "', '" +
            HLR_Plant + "')";

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
			DateUtil.getCompleteDateRepresentation(HLR_HotlistExpDate) + "' ," +
            " HLR_Plant = '" + HLR_Plant + "' where id = "  + id.ToString();

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

public 
int readLastIdByPlant(string splant){
	NotNullDataReader reader = null;
	try{
		int maxId = 0;
		string sql = "select max(id) as maxId from hotlisthdr where HLR_Plant ='" + splant + "'";
		
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
void setHLR_Plant(string HLR_Plant){
	this.HLR_Plant = HLR_Plant;
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

public
string getHLR_Plant(){
	return HLR_Plant;
}

public
string fieldHotListDay(int idaysWithQty){
    //we might use same hours for both dates
    DateTime    runDateAux      = DateUtil.minorHour(HLR_HotlistRunDate);              
    DateTime    now             = DateUtil.minorHour(DateTime.Now);
    int         idaysSinceRun   = Convert.ToInt32((now - runDateAux).TotalDays);
    int         idays           = idaysWithQty > 0 ? idaysSinceRun + idaysWithQty : 0;
                idays           = idays > Constants.MAX_HOTLIST_DAYS ? Constants.MAX_HOTLIST_DAYS : idays;

    string      sfield          = idays > 0 ? "HOT_Day" + idays.ToString("000") : "";
    int         idaysPastDue    = idaysSinceRun;
    string      sfieldPastDue   = "";
    string      sfieldsTotals   ="";
        
    if (!string.IsNullOrEmpty(sfield)) {      
        idaysPastDue  = idaysPastDue  > Constants.MAX_HOTLIST_DAYS ? Constants.MAX_HOTLIST_DAYS : idaysPastDue;

        if (idaysPastDue <= 0)  sfieldPastDue = "HOT_PastDue";
        else                    sfieldPastDue = "HOT_Day" + idaysPastDue.ToString("000");
        sfieldsTotals = "(" + sfieldPastDue + " - " + sfield + ")";
    }

    return sfieldsTotals;                
}

public
string sqlOrderByQty(){
    //we might use same hours for both dates
    DateTime    runDateAux  = DateUtil.minorHour(HLR_HotlistRunDate);              
    DateTime    now         = DateUtil.minorHour(DateTime.Now);
    int         idays       = Convert.ToInt32((now - runDateAux).TotalDays)+1;//start on Day_001             
    string      sfieldsOrder="";
    
    for (int i= idays; i <= Constants.MAX_HOTLIST_DAYS; i++) { 
        if (i > idays)
            sfieldsOrder += ",";
        sfieldsOrder += "HOT_Day" + i.ToString("000");
    }                    
    return sfieldsOrder;                
}

} // class

} // namespace