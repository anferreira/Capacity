using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class LbHistDataBaseContainer	: GenericDataBaseContainer{

public 
LbHistDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
	    string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary +".";
		
		sql += "lbhist";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			LbHistDataBase lbHistDataBase = new LbHistDataBase(dataBaseAccess);
			lbHistDataBase.load(reader);
			this.Add(lbHistDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList readDvdate(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(DVDATE) as DvDate from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		sql += "lbhist";

		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[1];
			line[0]= reader.GetDateTime("DvDate").ToShortDateString();
			array.Add((object)line);
		}
		
		return array;
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
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
	try{
		string sql = "delete from lbhist";
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
                        " and DVEMPL=ZMEMPL group by DVSHFT order by Count(*)";
        sqlSub = DBFormatter.selectTopRows(sqlSub,1) + ")";

        sql+= "," + sqlSub.Replace(sdateReplace,DateUtil.getDateRepresentation(fromDate1,DateUtil.MMDDYYYY)) + " as Shift1";
        sql+= "," + sqlSub.Replace(sdateReplace,DateUtil.getDateRepresentation(fromDate2,DateUtil.MMDDYYYY)) + " as Shift2";
        sql+= " from " + getTablePrefix() + "tazm" ;
                               
        reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
            semployee   = reader.GetString("ZMEMPL");                     
            ishift1     = Convert.ToInt32(reader.GetDecimal("Shift1"));
            ishift2     = Convert.ToInt32(reader.GetDecimal("Shift2"));
        
            ishift = ishift1 > 0 ? ishift1: 0;
            ishift = ishift  > 0 ? ishift : ishift2;
            
            if (!hashEmlpoyShift.Contains(semployee))
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

public
void getEmployeeLastDeptDate(out Hashtable hashDepts,out Hashtable hashDates){
	NotNullDataReader   reader = null;
    hashDepts = new Hashtable();
    hashDates = new Hashtable();
    
    try{        
        string      semployee="";
        string      sdept="";
        DateTime    date=DateTime.Now;        
        string      sfieldReplace= "FIELDX";
        string      sql         = "select ZMEMPL";
        string      sqlSub= "(select " + sfieldReplace + " from " + getTablePrefix() + "lbhist where "+
                            " DVEMPL=ZMEMPL order by DVDATE desc";
        sqlSub = DBFormatter.selectTopRows(sqlSub,1) + ")";

        //DVDEPT,DVDATE
                
        sql+= "," + sqlSub.Replace(sfieldReplace, "DVDEPT") + " as DVDEPT";
        sql+= "," + sqlSub.Replace(sfieldReplace, "DVDATE") + " as DVDATE";
        sql+= " from " + getTablePrefix() + "tazm" ;
                               
        reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
            semployee   = reader.GetString("ZMEMPL");                     
            sdept       = reader.GetString("DVDEPT"); 
            date        = reader.GetDateTime("DVDATE");
                    
            if (!hashDepts.Contains(semployee))
			    hashDepts.Add(semployee,sdept);    

            if (!hashDates.Contains(semployee))
			    hashDates.Add(semployee,date);    
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
}

}

}
