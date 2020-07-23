using System;
using System.Collections;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class PdToolDataBaseContainer : GenericDataBaseContainer{

public
PdToolDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pdtool";
		reader = dataBaseAccess.executeQuery(sql);
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

public
void readByDesc(string searchText, int rows){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pdtool";
		if (searchText.Length > 0){
			sql += " where TOO_Db like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_Company like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_Plant like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_ToolNumber like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_Desc1 like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_Desc2 like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_Desc3 like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_MaintenanceClass like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_ToolStatus like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_ScheduleStatus like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_ProductionUom like '" + Converter.fixString(searchText) + "%'";
			sql += " or TOO_CurrentWorkOrder like '" + Converter.fixString(searchText) + "%'";
		}
		if (rows > 0)
			sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType, rows);
		reader = dataBaseAccess.executeQuery(sql);
		load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}

public
void readByPart(string part1, string part2, string part3, string part4){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct t.* from pdtool t, pdtoolpart tp where t.TOO_ToolNumber = tp.PTP_ToolNum and (" +
		             "tp.PTP_Part = '" + Converter.fixString(part1) + "' or " +
		             "tp.PTP_Part = '" + Converter.fixString(part3) + "' or " +
		             "tp.PTP_Part = '" + Converter.fixString(part4) + "') " +
		             "order by t.TOO_ToolNumber"; 
		
		reader = dataBaseAccess.executeQuery(sql);
		load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PdToolDataBase pdToolDataBase = new PdToolDataBase(dataBaseAccess);
		pdToolDataBase.load(reader);
		this.Add(pdToolDataBase);
	}
}

public
void truncate(){
	try{	
		string sql = "delete from pdtool";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}	
}

public
void readByFilters(string scompany,string splant,string stoolNumber, string sdesc1,int rows){
    string sql = "select * from pdtool";

    if (!string.IsNullOrEmpty(scompany))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TOO_Company", scompany);
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TOO_Plant", splant);
    if (!string.IsNullOrEmpty(stoolNumber))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TOO_ToolNumber", stoolNumber);
    if (!string.IsNullOrEmpty(sdesc1))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TOO_Desc1", sdesc1);

    sql+= " order by TOO_ToolNumber";
    
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
                
    read(sql);
}

} // class
} // package