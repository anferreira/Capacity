using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class RrlhDataBaseContainer	: GenericDataBaseContainer{

public 
RrlhDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    while(reader.Read()){
		RrlhDataBase rrlhDataBase = new RrlhDataBase(dataBaseAccess);
		rrlhDataBase.load(reader);
		this.Add(rrlhDataBase);
	}
}

public
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary+".";
	sql += "rrlh";

    read(sql);		
}

public
void truncate(){
	string sql = "delete from rrlh";
	truncate(sql);	
}

public
void readByFilters(string splant,decimal dkeyNum,string stpartner,string srelease,string shipLoc,string spart,decimal oZLOG, decimal OZLOGMinor, int irows){ 
    string sql          = "select * from " + getTablePrefix() + "RRlH rh";
    string splantSql    = "";

    if (!string.IsNullOrEmpty(splant)){ 
        splantSql= "select st.OYLOG# from " + getTablePrefix() + "Stxh st where st.OYLOG#=rh.OZLOG# and st.OYTRPR=rh.OZTRPT and OYPLNT='" + Converter.fixString(splant) + "'";    
        sql     = DBFormatter.addWhereAndSentence(sql) + " exists (" + DBFormatter.selectTopRows(splantSql, 1) + ")";
    }
  
    if (dkeyNum > 0)
        sql= DBFormatter.addWhereAndSentence(sql) + "OZKEYN=" + NumberUtil.toString(dkeyNum);

    if (!string.IsNullOrEmpty(srelease))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("OZREL#", srelease);  

    if (!string.IsNullOrEmpty(shipLoc))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("OZSTXL", shipLoc);  
    
    if (!string.IsNullOrEmpty(stpartner))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("OZTRPT", stpartner);      

    if (!string.IsNullOrEmpty(spart))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("OZCPT#", spart);

    if (oZLOG > 0)
        sql= DBFormatter.addWhereAndSentence(sql) +  "OZLOG# =" + NumberUtil.toString(oZLOG);
    else  if (OZLOGMinor > 0)
        sql= DBFormatter.addWhereAndSentence(sql) +  "OZLOG# < " + NumberUtil.toString(OZLOGMinor);
            
    sql+= " order by rh.OZLOG# desc";

    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,1);

    read(sql);
}


public
ArrayList readDistinctTradingPartners(){
    ArrayList           arrayList = new ArrayList();
    NotNullDataReader   reader = null;
    try{
        string sql  = "select OZTRPT, max(OZSDAT) OZSDAT from " + getTablePrefix() + "RRLH" +
                      " group by OZTRPT order by OZTRPT";                        
        string[]item=new string[2];
		reader = dataBaseAccess.executeQuery(sql);

        while(reader.Read()){            		
            item=new string[2];
            item[0]= reader.GetString("OZTRPT");
            item[1]= DateUtil.getDateRepresentation(reader.GetDateTime("OZSDAT"),DateUtil.MMDDYYYY);

            arrayList.Add(item);
	    }        
	    
	    return arrayList;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctTradingPartners> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctTradingPartners> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctTradingPartners>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctTradingPartners> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList getDifferentsTParnter(){    
    NotNullDataReader   reader  = null;
    ArrayList           array   = new ArrayList();
    try{
        string sql      = "select distinct(OZTRPT) from " + getTablePrefix() + "rrlh order by OZTRPT";
                                                                                          
		reader = dataBaseAccess.executeQuery(sql);
	    while (reader.Read()) { 
            array.Add(reader.GetString(0));            
	    }
	    return array;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDifferentsTParnter> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDifferentsTParnter> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getDifferentsTParnter>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getDifferentsTParnter> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

}//end class

}//end namespace
