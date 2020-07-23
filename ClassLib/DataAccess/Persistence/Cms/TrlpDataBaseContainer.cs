using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class TrlpDataBaseContainer : GenericDataBaseContainer{

public 
TrlpDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    while(reader.Read()){
		TrlpDataBase trlpDataBase = new TrlpDataBase(dataBaseAccess);
		trlpDataBase.load(reader);
		this.Add(trlpDataBase);
	}
}

public
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary+".";
		
	sql += "trlp";

	read(sql);		
}

public
void truncate(){	
	string sql = "delete from trlp";
	truncate(sql);	
}

public 
ArrayList generateReportShippingSch(string db,string[] filterTPartner,string[] filterShipToLoc,string filterRelease){
	NotNullDataReader reader = null;
	try	{
	    string sqlConnection = Configuration.CMSLibrary;
		string sql = "select " +
	                    "D.AVMAJG, " + 
	                    "D.AVMING, " + 
	                    "A.SMTRPT, " +
	                    "A.SMSTXL, " +
	                    "A.SMCPT#, " +
	                    "A.SMPART, " +
	                    "C.PYDATE, " +
	                    "C.PYHM , " +
	                    "C.PYQTY, " +
	                    "C.PYNQTY, " +
	                    "C.PYQCUM  " +
                "from  " + db + ".JITH as B, " +
                           db + ".JITD as C, " +
                           db + ".TRLP as A " +
                                "left join " + db + ".STKMM as D on A.SMPART  = D.AVPART " +
                "where " +
	                "A.SMCKEY  = B.SPKEYN and " +
	                "A.SMSREF  = B.SPREF# and " + 
	                "B.SPKEYN  = C.PYKEYN and " +
	                "B.SPREF#  = C.PYREF# and " +
	                "C.PYRAN= ' '";
	                
        if (filterTPartner.Length > 0){
			sql += " and A.SMTRPT in (";

			for(int i = 0; i < filterTPartner.Length; i++){
				sql += "'" + filterTPartner[i] + "'";
				if (i < filterTPartner.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
		if (filterShipToLoc.Length > 0){
			sql +=" and A.SMSTXL in (";
			for(int i = 0; i < filterShipToLoc.Length; i++){
				//sql += "'" + filterShipToLoc[i].Replace(" ","") + "'";
				sql += "'" + filterShipToLoc[i] + "'";
				if (i < filterShipToLoc.Length - 1)
					sql += ", ";
			}
			sql +=") ";
        }           
        
        if (!filterRelease.Equals(""))
            sql +=" and A.SMSREF = '" + Converter.fixString(filterRelease) +"' ";
            
        sql +="order by A.SMTRPT,D.AVMAJG, D.AVMING,A.SMSTXL,A.SMCPT#,SMPART,C.PYDATE,C.PYHM";	                
	                
		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[11];
			getReaderShippingSch(reader,line);
			array.Add((object)line);
		}

		return array;
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
    }catch(System.Exception exc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <generateReportShippingSch> : " + exc.Message, exc);
    }finally{
	    if (reader != null)
		    reader.Close();
	   }
}

private 
void getReaderShippingSch(NotNullDataReader reader,string[] line){
    line[0]= reader.GetString("AVMAJG"); 
    line[1]= reader.GetString("AVMING");
    line[2]= reader.GetString("SMTRPT");
    line[3]= reader.GetString("SMSTXL");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	    line[4]= reader.GetString("SMCPT#");
	else
	    line[4]= reader.GetString("SMCPT");
    line[5]= reader.GetString("SMPART");
    line[6]= DateUtil.getDateRepresentation(reader.GetDateTime("PYDATE"),DateUtil.MMDDYYYY);
    line[7]= reader.GetDecimal("PYHM").ToString();
    line[8]= reader.GetDecimal("PYQTY").ToString();
    line[9]= reader.GetDecimal("PYNQTY").ToString();
    line[10]= reader.GetDecimal("PYQCUM").ToString();
}

public 
ArrayList generateReportMaterialRelease(string db,string[] filterTPartner,string[] filterShipToLoc){
   NotNullDataReader reader = null;
	try	{
	   	string sql = "select " +
                        "B.AVMAJG, " +
                        "B.AVMING, " +
                        "A.SMTRPT, " +
                        "A.SMSTXL, " +
                        "A.SMCPT#, " +
                        "A.SMPART, " +
                        "C.PLRDAT, " +
                        "C.PLQCUM, " +
                        "C.PLQNET, " +
                        "C.PLADJN " +
                  "from  " + db + ".RRLD as C, " +
                             db + ".RRLH as D, " +
                             db + ".TRLP as A " +
                            "left join " + db + ".STKMM as B on A.SMPART  = B.AVPART " +
                   "where " +
                        "A.SMCKEY = D.OZKEYN and " + 
                        "A.SMCREL = D.OZREL# and " + 
                        "D.OZKEYN = C.PLKEYN and " + 
                        "D.OZREL# = C.PLREL# "; 
                        
                        
         if (filterTPartner.Length > 0){
			sql += " and A.SMTRPT in (";

			for(int i = 0; i < filterTPartner.Length; i++){
				sql += "'" + filterTPartner[i] + "'";
				if (i < filterTPartner.Length - 1)
					sql += ", ";
			}
			sql +=") ";
		}
		if (filterShipToLoc.Length > 0){
			sql +=" and A.SMSTXL in (";
			for(int i = 0; i < filterShipToLoc.Length; i++){
				//sql += "'" + filterShipToLoc[i].Replace(" ","") + "'";
				sql += "'" + filterShipToLoc[i] + "'";
				if (i < filterShipToLoc.Length - 1)
					sql += ", ";
			}
			sql +=") ";
        }           
        sql +="order by A.SMTRPT,B.AVMAJG, B.AVMING,A.SMSTXL,A.SMCPT#,SMPART,C.PLRDAT";

		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[10];
			getReaderMaterialRelease(reader,line);
			array.Add((object)line);
		}

		return array;
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <generateReportMaterialRelease> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

private 
void getReaderMaterialRelease(NotNullDataReader reader,string[] line){
    line[0]= reader.GetString("AVMAJG"); 
    line[1]= reader.GetString("AVMING");
    line[2]= reader.GetString("SMTRPT");
    line[3]= reader.GetString("SMSTXL");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	    line[4]= reader.GetString("SMCPT#");
	else
	    line[4]= reader.GetString("SMCPT");
    line[5]= reader.GetString("SMPART");
    line[6]= DateUtil.getDateRepresentation(reader.GetDateTime("PLRDAT"),DateUtil.MMDDYYYY);
    line[7]= reader.GetDecimal("PLQCUM").ToString();
    line[8]= reader.GetDecimal("PLQNET").ToString();
    line[9]= reader.GetDecimal("PLADJN").ToString();
}


//Only use to read form the AS400
public
string[][] selectTPartnerByDB(string db){
	NotNullDataReader reader = null;
	try	{
	   	string sql = "select distinct SMTRPT " +
                  "from  " + db + ".TRLP " +
                         "order by SMTRPT ";  

		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[1];
			line[0]= reader.GetString("SMTRPT");
			array.Add((object)line);
		}
		
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		return returnArray;
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <selectTPartnerByDB> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
 
public
void readByFilters(string stp,string shipLoc,string sbillTo,string shipTo,string spart,decimal dorder,decimal dorderItem,string scustPO,decimal keyNum,string srel,int rows){
    string sql = "select * from " + getTablePrefix() +"TRLP";

    if (!string.IsNullOrEmpty(stp))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMTRPT",stp);
    if (!string.IsNullOrEmpty(shipLoc))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMSTXL",shipLoc);            
    if (!string.IsNullOrEmpty(sbillTo))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMCUST",sbillTo);
    if (!string.IsNullOrEmpty(shipTo))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMLOCN",shipTo);
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMPART",spart);
    
    if (dorder > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "SMORD#=" + NumberUtil.toString(dorder);
    if (dorderItem > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "SMITM#=" + NumberUtil.toString(dorderItem);
    if (!string.IsNullOrEmpty(scustPO))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Trim(SMCPO#)",scustPO);

    if (keyNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "SMCKEY=" + NumberUtil.toString(keyNum);
    if (!string.IsNullOrEmpty(srel))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMCREL", srel);
    
    sql+=" order by SMTRPT,SMSTXL,SMRDAT desc";            
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);    

    read(sql);
}

public
ArrayList readDistinctTradingPartners(string splant,string source){
    ArrayList           arrayList = new ArrayList();
    NotNullDataReader   reader = null;
    try{
        string sql  =   "select SMTRPT, max(SMRDAT) SMRDAT from " + getTablePrefix() +"trlp";

        if (!string.IsNullOrEmpty(splant))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMPLANT", splant);

        if (!string.IsNullOrEmpty(source)) { 
            if (source.IndexOf("830") >=0)
                sql = DBFormatter.addWhereAndSentence(sql) + "SMTRPT in (select distinct(OZTRPT) from " + getTablePrefix() + "RRLH)"; 
            if (source.IndexOf("862") >=0)
                sql = DBFormatter.addWhereAndSentence(sql) + "SMTRPT in (select distinct(SPTRPT) from " + getTablePrefix() + "JITH)"; 
        }

        sql+= " group by SMTRPT order by SMTRPT";                        
        string[]item=new string[2];
		reader = dataBaseAccess.executeQuery(sql);

        while(reader.Read()){            		
            item=new string[2];
            item[0]= reader.GetString("SMTRPT");
            item[1]= DateUtil.getDateRepresentation(reader.GetDateTime("SMRDAT"),DateUtil.MMDDYYYY);

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
ArrayList readDistinctShipLoc(string stpartner){
    ArrayList           arrayList = new ArrayList();
    NotNullDataReader   reader = null;
    try{
        string sql  = "select distinct(SMSTXL) SMSTXL from " + getTablePrefix() +"trlp";
                                            
        if (!string.IsNullOrEmpty(stpartner))
            sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMTRPT",stpartner);        
        sql+= " order by SMSTXL";

		reader = dataBaseAccess.executeQuery(sql);

        while(reader.Read())            		        
            arrayList.Add(reader.GetString("SMSTXL"));	            
	    
	    return arrayList;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctShipLoc> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctShipLoc> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctShipLoc>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctShipLoc> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList readDistinctParts(string stpartner,string shipLoc){
    ArrayList           arrayList = new ArrayList();
    NotNullDataReader   reader = null;
    try{
        string sql  = "select distinct(SMCPT#) SMCPT# from " + getTablePrefix() +"trlp";

        if (!string.IsNullOrEmpty(stpartner))
           sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMTRPT",stpartner);        
        if (!string.IsNullOrEmpty(shipLoc))
            sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SMSTXL",shipLoc);                            
        sql+= " order by SMCPT#";

		reader = dataBaseAccess.executeQuery(sql);

        while(reader.Read())            		        
            arrayList.Add(reader.GetString("SMCPT#"));	            
	    
	    return arrayList;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctParts> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readDistinctParts> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctParts>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readDistinctParts> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}



}//end class

}//end namespace
