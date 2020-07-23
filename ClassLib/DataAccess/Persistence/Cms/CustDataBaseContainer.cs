using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class CustDataBaseContainer : GenericDataBaseContainer{
		
public 
CustDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CustDataBase custDataBase = new CustDataBase(dataBaseAccess);
		custDataBase.load(reader);
		this.Add(custDataBase);
	}
}

public
void read(){
    string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "cust";

    read(sql);		
}

public
void truncate(){
	string sql = "delete from cust";
    truncate(sql);		
}
     
public
ArrayList getDifferentsTParnter(){    
    NotNullDataReader   reader  = null;
    ArrayList           array   = new ArrayList();
    try{
        string sql      = "select distinct(BVTRDP) from " + getTablePrefix() + "cust order by BVTRDP";
                                        
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

}//en namespace
