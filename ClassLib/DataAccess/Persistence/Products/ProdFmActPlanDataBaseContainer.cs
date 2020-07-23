using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActPlanDataBaseContainer : GenericDataBaseContainer{

public
ProdFmActPlanDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactplan";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
			prodFmActPlanDataBase.load(reader);		
			this.Add(prodFmActPlanDataBase, prodFmActPlanDataBase.getKey());
		}
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
decimal readLeadTimeByProduct(string prodID){
	NotNullDataReader reader = null;
	try{
		string sql = "select PAPL_DayLT from prodfmactplan where PAPL_ProdID = '" + prodID + "' order by PAPL_Seq";

		decimal result = 0;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			result = reader.GetDecimal(0);		
		
		return result;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByProduct(string prodID){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactplan where PAPL_ProdID = '" + prodID + "' order by PAPL_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
			prodFmActPlanDataBase.load(reader);		
			this.Add(prodFmActPlanDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public 
void readByProductSeqInverse(string prodID){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactplan where PAPL_ProdID = '" + prodID + "' order by PAPL_Seq desc";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
			prodFmActPlanDataBase.load(reader);		
			this.Add(prodFmActPlanDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try{
		string sql = "delete from prodfmactplan";
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
void clearLeadTimes(){
    try{
        string sql = "update prodfmactplan set PAPL_DayLT = 0, PAPL_HourLT = 0, PAPL_DayLTCum = 0, PAPL_HourLTCum = 0";
        dataBaseAccess.executeUpdate(sql);
    }catch (System.Data.SqlClient.SqlException se){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <clearLeadTimes> : " + se.Message, se);
    }catch (System.Data.DataException de){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <clearLeadTimes> : " + de.Message, de);
    }catch (MySql.Data.MySqlClient.MySqlException mySqlExc){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <clearLeadTimes> : " + mySqlExc.Message, mySqlExc);
    }
}

public 
void truncateFamilies(){
	try{
		string sql = "delete from prodfmactplan where PAPL_ProdID in " + 
			"(select PFS_ProdId from prodfminfo where PFS_FamProd = 'F')";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateFamilies> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateFamilies> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateFamilies> : " + mySqlExc.Message, mySqlExc);
	}
}

public 
void truncateProducts(){
	try{
		string sql = "delete from prodfmactplan where PAPL_ProdID not in " + 
			"(select PFPD_FamCfg from ProdFmActplanDt)";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateProducts> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateProducts> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncateProducts> : " + mySqlExc.Message, mySqlExc);
	}
}

public 
ArrayList readForShortageReport(string[] vecMajorFilter,string[] vecMinorFilter){
	NotNullDataReader reader = null;
	try{
	    bool filter = false;
		string sql = "select * from prodfmactplan, prodfminfo, invpltloc ";
		
		if (vecMajorFilter.Length > 0){
		    sql +="where PFS_MajorGroup in (";
		    filter = true;
		    for(int i = 0; i < vecMajorFilter.Length; i++){
				sql += "'" + vecMajorFilter[i] + "'";
				if (i < vecMajorFilter.Length - 1)
					sql += ", ";
			}
			sql +=") and ";
		}
		     
		if (vecMinorFilter.Length > 0){
		    if (!filter){
		        sql += "where ";
		        filter = true;
		    }
		    sql +=" PFS_MinorGroup in (";
		    
		    for(int i = 0; i < vecMinorFilter.Length; i++){
				sql += "'" + vecMinorFilter[i] + "'";
				if (i < vecMinorFilter.Length - 1)
					sql += ", ";
			}
			sql +=") and ";
		}
		
		
		if (! filter)    
		    sql += "where "; 
		
		sql += " PAPL_ProdID = PFS_ProdId and " +
		       " PFS_ProdId = IPL_ProdID and " +
		       " PFS_SeqLast = IPL_Seq " +
		       " order by PAPL_ProdID";   

    	reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[6];
			getInfoAsArray(reader,line);
			array.Add((object)line);
		}
        
		return array;
	
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

private 
void getInfoAsArray(NotNullDataReader reader, string[] line){
   line[0]= reader.GetString("PAPL_ProdID"); 
   line[1]= reader.GetInt32("PAPL_Seq").ToString(); 
   line[2]= reader.GetString("PFS_MajorGroup"); 
   line[3]= reader.GetDecimal("PAPL_MinInv").ToString(); 
   line[4]= reader.GetString("IPL_StkLoc"); 
   line[5]= reader.GetDecimal("IPL_QOH").ToString(); 
}

public
ProdFmActPlanDataBase getProdFmActPlan(string prodID, int seq){
	string key = prodID + "_" + seq.ToString();

	int pos = getFirstElementPosition(key);
	if (pos == -1)
		return null;
	else
		return (ProdFmActPlanDataBase)this[pos];
}

public
void deleteByPart(string spart){
    string sql = "delete from prodfmactplan where PAPL_ProdID = '" + spart + "'";
    delete(sql);
}

public
void deleteByPartList(Hashtable hashtProdfmactByPart){    
    string  spart = "";
	string  sql = "delete from prodfmactplan";
    string  spartList = "";

    foreach (DictionaryEntry entry in hashtProdfmactByPart){
        spart = (string)entry.Value;
        spartList+= string.IsNullOrEmpty(spartList)  ? "" : ",";
        spartList+="'" + spart + "'";
    }
    
    if (!string.IsNullOrEmpty(spartList)){
        sql+= "  where PAPL_ProdID in ( " + spartList + ")";
        delete(sql);	
    }
}

} // class

} // namespace
