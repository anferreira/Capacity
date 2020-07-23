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
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class StxhDataBaseContainer : GenericDataBaseContainer {

public
StxhDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from stxh";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from stxh";
	if (searchText.Length > 0){
		sql += " where OYTRCD like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYTRPR like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYDOCN like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYEXCD like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYDCCL like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYMAPT like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYSTAT like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYNOTE like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYSUPL like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYDOCC like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYITYP like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT5 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT6 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT7 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT8 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYFUT9 like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYPLNT like '" + Converter.fixString(searchText) + "%'";
		sql += " or OYMLBX like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		StxhDataBase stxhDataBase = new StxhDataBase(dataBaseAccess);
		stxhDataBase.load(reader);
		this.Add(stxhDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table stxh";
	truncate(sql);
}
    
public 
void readByFilters(decimal oYLOG, decimal oYLOGMinor,string oYTRPR,string oYDOCN,DateTime fromDate,DateTime toDate,string scustPo,string scustPart,string srelease,string customer,string shipTo,string shipToLoc,int irows){
	string sql      = "select * from " + getTablePrefix() +"stxh";
    string subQuery = "";
    
    if (!string.IsNullOrEmpty(scustPart) || !string.IsNullOrEmpty(srelease) || !string.IsNullOrEmpty(customer) || 
        !string.IsNullOrEmpty(shipToLoc)){ 
        subQuery= "select sd.RCENT# from " + getTablePrefix() + "stxd sd";

        if (oYLOG > 0)
            subQuery= DBFormatter.addWhereAndSentence(subQuery) + "RCLOG#="+ NumberUtil.toString(oYLOG);
        if (!string.IsNullOrEmpty(oYTRPR))
            subQuery= DBFormatter.addWhereAndSentence(subQuery) + DBFormatter.equalLikeSql("RCTRDP",oYTRPR);
        if (!string.IsNullOrEmpty(shipToLoc))
            subQuery = DBFormatter.addWhereAndSentence(subQuery) + DBFormatter.equalLikeSql("RCLSTX", shipToLoc);                               

        if (!string.IsNullOrEmpty(scustPo))
            subQuery = DBFormatter.addWhereAndSentence(subQuery) + DBFormatter.equalLikeSql("Trim(RCCPO#)", scustPo);
        if (!string.IsNullOrEmpty(scustPart))
            subQuery = DBFormatter.addWhereAndSentence(subQuery) + DBFormatter.equalLikeSql("RCCPT#",scustPart);
        if (!string.IsNullOrEmpty(srelease))
            subQuery = DBFormatter.addWhereAndSentence(subQuery) + DBFormatter.equalLikeSql("RCREL#", srelease);
        if (!string.IsNullOrEmpty(customer))
            subQuery = DBFormatter.addWhereAndSentence(subQuery) + DBFormatter.equalLikeSql("RCCUST", customer);
        if (!string.IsNullOrEmpty(shipTo))
            subQuery = DBFormatter.addWhereAndSentence(subQuery) + DBFormatter.equalLikeSql("RCLOCN", shipTo);                
    }

    //select   sd.RCLOG#,  sd.RCTRDP, sd.RCLSTX, sd.RCCPT#, sd.RCCPO#,RCREL#, sd.RCCUST, sd.* from CMSDAT.stxd sd

    if (oYLOG > 0)
        sql= DBFormatter.addWhereAndSentence(sql) + "OYLOG#="+ NumberUtil.toString(oYLOG);
    if (oYLOGMinor > 0)
        sql= DBFormatter.addWhereAndSentence(sql) + "OYLOG#<"+ NumberUtil.toString(oYLOGMinor);
    
    if (!string.IsNullOrEmpty(oYTRPR))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OYTRPR",oYTRPR);
    if (!string.IsNullOrEmpty(oYDOCN))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OYDOCN",oYDOCN);

    if (fromDate!= DateUtil.MinValue || toDate != DateUtil.MinValue)
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("OYCDAT",fromDate,toDate);

    if (!string.IsNullOrEmpty(subQuery)){
        sql= DBFormatter.addWhereAndSentence(sql) + "OYENT# in (" + subQuery  + ")";
    }

    sql+= " order by OYLOG# desc";

    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,irows);
                
    read(sql);
}


public
ArrayList getDifferentsTParnterByDate(DateTime fromDate,DateTime toDate){    
    NotNullDataReader   reader  = null;
    ArrayList           array   = new ArrayList();
    try{
        string sql      = "select distinct(oYTRPR) from " + getTablePrefix() +"stxh";

        if (fromDate!= DateUtil.MinValue || toDate != DateUtil.MinValue)
            sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("OYCDAT",fromDate,toDate);
                        
		reader = dataBaseAccess.executeQuery(sql);
	    while (reader.Read()) { 
            array.Add(reader.GetString(0));            
	    }
	    return array;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDifferentsTParnterByDate> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDifferentsTParnterByDate> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getDifferentsTParnterByDate>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getDifferentsTParnterByDate> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}
        
public
bool getMinMaxLogsByTrPartner(string splant,string stpartner,int oYLOG,out int logFrom,out int logTo,out DateTime dateProcess){    
    NotNullDataReader   reader  = null;
    ArrayList           array   = new ArrayList();
    bool                bresult =false;

    dateProcess = DateUtil.MinValue;
    logFrom = logTo = 0;
    try{
        string sql  = "select  min(OYLOG#) as min,max(OYLOG#) as max,max(OYCDAT) as dateProcess from " + getTablePrefix() +"stxh";

               sql=     "select  OYLOG# as min,OYLOG# as max,OYCDAT as dateProcess from " + getTablePrefix() +"stxh" +
                        " where " + DBFormatter.equalLikeSql("OYPLNT", splant) + " and " +
                                    DBFormatter.equalLikeSql("OYTRPR",stpartner) +      
                        " and OYLOG# > " + NumberUtil.toString(oYLOG);
        sql = DBFormatter.selectTopRows(sql,1);

		reader = dataBaseAccess.executeQuery(sql);
	    if (reader.Read()) { 
            logFrom     = Convert.ToInt32(reader.GetDecimal("min"));
            logTo       = Convert.ToInt32(reader.GetDecimal("max"));
            dateProcess = reader.GetDateTime("dateProcess");
            bresult = true;
	    }
	    
    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getMinMaxLogsByTrPartner> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getMinMaxLogsByTrPartner> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getMinMaxLogsByTrPartner>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getMinMaxLogsByTrPartner> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
    return bresult;
}

} // class
} // package