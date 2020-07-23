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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapacityPartDataBaseContainer : GenericDataBaseContainer {

public
CapacityPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capacitypart";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capacitypart";
	if (searchText.Length > 0){
		sql += " where Part like '" + Converter.fixString(searchText) + "%'";
		sql += " or IsFamily like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapacityPartDataBase capacityPartDataBase = new CapacityPartDataBase(dataBaseAccess);
		capacityPartDataBase.load(reader);
		this.Add(capacityPartDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table capacitypart";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql = "select * from capacitypart where HdrId=" + NumberUtil.toString(id) + " order by HdrId,Detail";	
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from capacitypart where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}


public
void readByFilters(int ihdrId,string spart,int iseq,string stype,int ireqId,int rows){   
    string sql = "select * from capacityreq cr, capacitypart cp";	

    if (ihdrId > 0)  
        sql = DBFormatter.addWhereAndSentence(sql) + "cp.HdrId = " + NumberUtil.toString(ihdrId);
    
    sql = DBFormatter.addWhereAndSentence(sql) + "cp.HdrId = cr.HdrId and cp.Detail = cr.Detail";

    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("cp.Part", spart);

    if (iseq >= 0)  
        sql = DBFormatter.addWhereAndSentence(sql) + "cp.Seq = " + NumberUtil.toString(iseq);

    if (!string.IsNullOrEmpty(stype))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("cr.Type",stype);

    if (ireqId > 0)  
        sql = DBFormatter.addWhereAndSentence(sql) + "cr.ReqID = " + NumberUtil.toString(ireqId);

    sql+= " order by cp.Part,cp.Seq,cp.StartDate";

    if (rows > 0)
        sql = DBFormatter.selectTopRows(sql,rows);

    read(sql);
}

public
int readMaxDetailFromHdr(int ihdr){
    NotNullDataReader reader = null;
    try{
        string sql = "select MAX(Detail) from capacitypart where HdrId=" + NumberUtil.toString(ihdr);            
		reader = dataBaseAccess.executeQuery(sql);
	    if (reader.Read())
            return (int)reader.GetInt32(0);
	    
	    return 0;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaxDetail> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaxDetail> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readMaxDetail>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readMaxDetail> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}
  
} // class
} // package