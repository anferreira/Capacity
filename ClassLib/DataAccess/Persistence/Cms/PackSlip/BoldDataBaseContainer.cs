using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms.PackSlip{

public class BoldDataBaseContainer : GenericDataBaseContainer{

public BoldDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public 
void read(){
	string table = getTablePrefix() + "bold";	
	string sql = "select * from " + table;

	read(sql);
}

public 
void deleteByHdr(decimal did){	
	string sql = "delete from bold where FGBOL=" + NumberUtil.toString(did);
	delete(sql);
}

public
void readByHeaders(BolhDataBaseContainer headers){
	if (headers.Count == 0)
		return;

	string fgbolField = "FGBOL";
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	{
		sql += getTablePrefix();
		fgbolField = "FGBOL#";
	}
	sql += "bold";

	sql += " where "+fgbolField+" in (";

	for(int i = 0; i < headers.Count; i++)
	{
		BolhDataBase bolhDataBase = (BolhDataBase)headers[i];
		sql+=bolhDataBase.getFEBOL().ToString();
		if (i != headers.Count - 1)
			sql += ", ";
	}
	sql += ")";

    sql+= " order by " + getFieldDigit("FGBOL") + "," + getFieldDigit("FGENT");

    read(sql);
}

public
void read(string[] headers){
	if (headers.Length == 0)
		return;

	string fgbolField = "FGBOL";
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	{
		sql += getTablePrefix();
		fgbolField = "FGBOL#";
	}
	sql += "bold";

	sql+=" where " + fgbolField + " >= " + headers[0] + " and " + fgbolField + " <= " + headers[headers.Length - 1];

	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		BoldDataBase boldDataBase = new BoldDataBase(dataBaseAccess);
		boldDataBase.load(reader);
		this.Add(boldDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table bold";
	truncate(sql);
}

public
void readByFiltersTransfer(string skeyGreaterThan,string splant,int rows){
    string sql = "select * from "+ getTablePrefix()  + "bold";                
    string scastFGBOL = "CAST(" + getFieldDigit("FGBOL") + " AS varchar(10))";// len 9
    string scastFGENT = "CAST(" + getFieldDigit("FGENT") + " AS varchar(5))";// len 3
    scastFGBOL = DBFormatter.lpad(scastFGBOL, 10,'0');
    scastFGENT = DBFormatter.lpad(scastFGENT, 5,'0');
    string skey= scastFGBOL + ","  + scastFGENT;              
            
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FGPLNT", splant);
    
    if (!string.IsNullOrEmpty(skeyGreaterThan)){   
        sql = DBFormatter.addWhereAndSentence(sql);                                     
        string sfields =scastFGBOL;                             sfields = DBFormatter.concat(sfields,"'"+Constants.DEFAULT_SEP+"'");
        sfields =       DBFormatter.concat(sfields, scastFGENT);
        sql += sfields + " > '" + skeyGreaterThan + "'";
    }

    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}
        /*
public
void readByFilters(string skeytGreaterThan,int rows){
    //PRIMARY KEY(  JRPT# , JRSEQ# , JRVPTS , JRVND# 
    //JRSEQ# NUMERIC(3, 0) , JRVPTS NUMERIC(6, 0)
    string sql          = "select * from "+ getTablePrefix()  + "poptvn";        
    string scastPSeq    = "CAST(" + getFieldDigit("JRSEQ") + " AS varchar(10))"; //3 len 
    string scastVPSeq   = "CAST(JRVPTS AS varchar(10))"; //6 len 
    scastPSeq  = DBFormatter.lpad(scastPSeq , 10,'0');
    scastVPSeq = DBFormatter.lpad(scastVPSeq, 10,'0');
    string skey         = getFieldDigit("JRPT") + "," + scastPSeq + ","  + scastVPSeq + "," + getFieldDigit("JRVND");
            
    if (!string.IsNullOrEmpty(skeytGreaterThan)){   
        sql = DBFormatter.addWhereAndSentence(sql);                                     
        string sfields = "Rtrim(" + getFieldDigit("JRPT") + ")";    sfields = DBFormatter.concat(sfields,"'"+Constants.DEFAULT_SEP+"'");
        sfields = DBFormatter.concat(sfields, scastPSeq);           sfields = DBFormatter.concat(sfields,"'"+Constants.DEFAULT_SEP+"'");
        sfields = DBFormatter.concat(sfields, scastVPSeq);          sfields = DBFormatter.concat(sfields,"'"+Constants.DEFAULT_SEP+"'");
        sfields = DBFormatter.concat(sfields, "Rtrim(" + getFieldDigit("JRVND") + ")");                
        sql += sfields + " > '" + skeytGreaterThan + "'";
    }
                
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}
*/

public
void readAllloadCustPOs(decimal h, decimal i){    
    NotNullDataReader   reader  = null;    
    try{                
        string sql      = "select FGBOL#,FGENT#,FGORD#,FGCPO# " +
                          " from "+ getTablePrefix()  + "bold ";   
        if (h > 0 && i > 0)
            sql+= " where FGBOL#=" + NumberUtil.toString(h) + "  and FGENT#=" + NumberUtil.toString(i);
        
        reader = dataBaseAccess.executeQuery(sql);
	    while (reader.Read()) { 
            BoldDataBase boldDataBase = new BoldDataBase(dataBaseAccess);
            boldDataBase.setFGBOL(reader.GetDecimal("FGBOL#"));
            boldDataBase.setFGENT(reader.GetDecimal("FGENT#"));
            boldDataBase.setFGORD(reader.GetDecimal("FGORD#"));
            boldDataBase.setFGCPO(reader.GetString("FGCPO#"));

            this.Add(boldDataBase);            
	    }	    

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllloadCustPOs> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllloadCustPOs> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readAllloadCustPOs>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readAllloadCustPOs> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}    
}


}//end class

}//end namespace
