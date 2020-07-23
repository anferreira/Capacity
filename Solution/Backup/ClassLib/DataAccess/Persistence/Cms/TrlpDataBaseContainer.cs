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

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary+".";
		
		sql += "trlp";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			TrlpDataBase trlpDataBase = new TrlpDataBase(dataBaseAccess);
			trlpDataBase.load(reader);
			this.Add(trlpDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + other.Message, other);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from trlp";
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

}//end class

}//end namespace
