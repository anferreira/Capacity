using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;


namespace Nujit.NujitWms.ClassLib.Persistence.Cms{


public 
class LbHistDataBaseContainer : GenericDataBaseContainer{

public 
LbHistDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from " + getTablePrefix()+  "lbhist";
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		LbHistDataBase lbHistDataBase = new LbHistDataBase(dataBaseAccess);
		lbHistDataBase.load(reader);
		this.Add(lbHistDataBase);
	}
}

public
ArrayList readDvdate(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(DVDATE) as DvDate from " + getTablePrefix() + "lbhist";
		
		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[1];
			line[0]= reader.GetDateTime("DvDate").ToShortDateString();
			array.Add((object)line);
		}
		
		return array;
	}
	#if !POCKET_PC
	catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}
	#endif
	catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class LbhistDataBaseContainer : " + other.Message, other);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public  
void truncate(){
	string sql = "truncate table lbhist";
	truncate(sql);
}

public
decimal summaryTotalTimeByFilters(string sdept,DateTime from,DateTime to){
	NotNullDataReader   reader = null;
    decimal             dtotalTime = 0;
    
	try{                
        //string sql = "select abs(sum(DVTIME)) as LabourTime from " + getTablePrefix() +  "LBHIST ";

        string sql ="select abs(SUM(CASE WHEN DVTIME > 0 THEN DVTIME ELSE 0 END)) AS posSum,"+
                    " abs(SUM(CASE WHEN DVTIME < 0 THEN DVTIME ELSE 0 END)) AS negSum "+
                    " from " + getTablePrefix() + "LBHIST";

        if (!string.IsNullOrEmpty(sdept)){
            sql = DBFormatter.addWhereAndSentence(sql);
            sql += "DVDEPT = '" + Converter.fixString(sdept) + "'";
        }

        if (from != DateUtil.MinValue){
            sql = DBFormatter.addWhereAndSentence(sql);
            if (to != DateUtil.MinValue)
                sql += "(";
            sql += "DVDATE" + (to != DateUtil.MinValue ? ">" : "") + "='" + DateUtil.getDateRepresentation(from, DateUtil.MMDDYYYY) + "'";		
	    }

        if (to != DateUtil.MinValue){
            sql = DBFormatter.addWhereAndSentence(sql);
            sql += "DVDATE" + (from != DateUtil.MinValue ? "<" : "") + "='" + DateUtil.getDateRepresentation(to, DateUtil.MMDDYYYY) + "'";
            if (from != DateUtil.MinValue)
                sql += ")";
	    }
                
        reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
            dtotalTime = reader.GetDecimal("posSum") - reader.GetDecimal("negSum");
            
	}catch(System.Data.SqlClient.SqlException se){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <summaryTotalTimeByFilters> : " + se.Message);
	}catch(System.Data.DataException de){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <summaryTotalTimeByFilters> : " + de.Message);
	}
	#if !POCKET_PC	
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
        throw new PersistenceException("Error in class " + this.GetType().Name + "<summaryTotalTimeByFilters>  : " + mySqlExc.Message, mySqlExc);
	}
	#endif
	catch(System.Exception ex){
        throw new PersistenceException("Error in class " + this.GetType().Name + "<summaryTotalTimeByFilters> : " + ex.Message, ex);
	}finally{
		if (reader != null)
			reader.Close();
	}
    return dtotalTime;
}


public
Hashtable getEmployeeUsualShift(DateTime fromDate1,DateTime fromDate2){
	NotNullDataReader   reader = null;
    Hashtable           hashEmlpoyShift=new Hashtable();
    
    try{        
        string  semployee="";
        int     ishift1=0;
        int     ishift2=0;
        int     ishift =0;
        string  sdateReplace= "DATEX";
        string  sql         = "select ZMEMPL";
        string  sqlSub=  "(select DVSHFT from "  + getTablePrefix() + "lbhist where DVDATE >= '" + sdateReplace + "' " +
                        " and DVEMPL=ZMEMPL group by DVSHFT order by Count(*))";

        sql+= "," + sqlSub.Replace(sdateReplace,DateUtil.getDateRepresentation(fromDate1,DateUtil.MMDDYYYY)) + " as Shift1";
        sql+= "," + sqlSub.Replace(sdateReplace,DateUtil.getDateRepresentation(fromDate2,DateUtil.MMDDYYYY)) + " as Shift2";
        sql+= " from " + getTablePrefix() + "LBHIST";
                               
        reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
            semployee   = reader.GetString("ZMEMPL");                     
            ishift1     = reader.GetInt32("Shift1");
            ishift2     = reader.GetInt32("Shift1");
        
            ishift = ishift1 > 0 ? ishift1 : 0;
            ishift = ishift  > 0 ? ishift : ishift2;
            
            if (hashEmlpoyShift.Contains(semployee))
			    hashEmlpoyShift.Add(semployee,ishift);    
		}            
            
	}catch(System.Data.SqlClient.SqlException se){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <getEmployeeUsualShift> : " + se.Message);
	}catch(System.Data.DataException de){
        throw new PersistenceException("Error in class " + this.GetType().Name + " <getEmployeeUsualShift> : " + de.Message);
	}
	#if !POCKET_PC	
	catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
        throw new PersistenceException("Error in class " + this.GetType().Name + "<getEmployeeUsualShift>  : " + mySqlExc.Message, mySqlExc);
	}
	#endif
	catch(System.Exception ex){
        throw new PersistenceException("Error in class " + this.GetType().Name + "<getEmployeeUsualShift> : " + ex.Message, ex);
	}finally{
		if (reader != null)
			reader.Close();
	}
    return hashEmlpoyShift;
}


}
}
