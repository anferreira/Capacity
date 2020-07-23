/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class DemandHDataBaseContainer : GenericDataBaseContainer {

public
DemandHDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from " + getTablePrefix2() +  "demandh";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
    string sql = "select * from  " + getTablePrefix2() + "demandh";
	if (searchText.Length > 0){
		sql += " where Status like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemandHDataBase demandHDataBase = new DemandHDataBase(dataBaseAccess);
		demandHDataBase.load(reader);
		this.Add(demandHDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table demandh";
	truncate(sql);
}

public
int readMAxId(){
    NotNullDataReader reader = null;
    try{

        string sql = "select MAX(Id) from " + getTablePrefix2() + "demandh";            
		reader = dataBaseAccess.executeQuery(sql);
	    if (reader.Read())
            return (int)reader.GetInt32(0);
	    
	    return 0;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readMAxId> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readMAxId> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readMAxId>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readMAxId> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByFilters(string id,string splant, string status, decimal dtrlpKeyId,DateTime fromDate, DateTime toDate,int rows){
    string sql = "select * from  " + getTablePrefix2() + "demandh ";

    if (!string.IsNullOrEmpty(id))
        sql = DBFormatter.addWhereAndSentence(sql) + " ID like '" + id + "%'";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);

    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("DateTime",fromDate,toDate,false);        
    
    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Status", status + "%");

    if (dtrlpKeyId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (select TrlpKeyId from demandd where HdrId=ID and TrlpKeyId =" + NumberUtil.toString(dtrlpKeyId)+ ")";

    sql += " order by Id desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}



} // class
} // package