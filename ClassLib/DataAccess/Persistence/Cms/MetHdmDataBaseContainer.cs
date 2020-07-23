using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class MetHdmDataBaseContainer : GenericDataBaseContainer{

public
MetHdmDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "methdm";

	read(sql);	
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		MetHdmDataBase metHdmDataBase = new MetHdmDataBase(dataBaseAccess);
        metHdmDataBase.load(reader);
		this.Add(metHdmDataBase);
	}
}

public
void truncate(){	
	string sql = "delete from methdm";
    truncate(sql);	
}

public
void readByEqualFilters(string aQPART,string aQMTLP,int rows){
    string sql = "select * from " + getTablePrefix() + "methdm";

    if (!string.IsNullOrEmpty(aQPART)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "AQPART='" + aQPART + "'";
    }

    if (!string.IsNullOrEmpty(aQMTLP)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "AQMTLP='" + aQMTLP + "'";
    }

    if (rows > 0)
        sql = DBFormatter.selectTopRows(sql,rows);
   // System.Windows.Forms.MessageBox.Show(sql);
    read(sql);    
}

public
decimal getAQQPPC(string aQPART,string aQMTLP){ 
    decimal             daqqppc=1;
    NotNullDataReader   reader = null;
	try{
		string sql ="select (case when mh2.AQQPPC IS NULL then ifnull(mh.AQQPPC, 1) ELSE ifnull(mh2.AQQPPC, 1) END) as Tot " +
                    " from " + getTablePrefix() +"methdm mh " +
                    " left outer join " + getTablePrefix() + "methdm mh2 on mh2.AQPART = '" + aQPART + "' " +
                    " and mh2.AQPART = mh.AQPART and mh2.AQMTLP = '"+ aQMTLP + "' " +
                    " where mh.AQPART = '" + aQPART + "'";         
        sql = DBFormatter.selectTopRows(sql,1);
                                       
        reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
           daqqppc=reader.GetDecimal(0);

	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAQQPPC> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAQQPPC> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAQQPPC> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getAQQPPC> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
    return daqqppc;
}

private
string getAQSEQField(){
    string sfield = getFieldDigit("AQSEQ");
    if (dataBaseAccess.getConnectionType() != DataBaseAccess.CMS_DATABASE)            
        sfield+= "_";
    return sfield;
}

private
string getAQLINField(){
    string sfield = getFieldDigit("AQLIN");
    if (dataBaseAccess.getConnectionType() != DataBaseAccess.CMS_DATABASE)            
        sfield+= "_";
    return sfield;
}

public
void readByFilters(string skeytGreaterThan,string splant,int rows){
    //PRIMARY KEY( AQTYPE , AQPLNT , AQPART , AQSEQ# , AQLIN# ) )       
    string sql      = "select * from "+ getTablePrefix()  + "methdm";    
    string scastSeq = "CAST(" + getAQSEQField() + " AS varchar(10))"; //3 len
    string scastLin = "CAST(" + getAQLINField() + " AS varchar(10))"; //2 len    
    scastSeq = DBFormatter.lpad(scastSeq, 10,'0');
    scastLin = DBFormatter.lpad(scastLin, 10,'0');
    string skey     = "AQTYPE,AQPLNT,AQPART," + scastSeq + "," + scastLin;

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("AQPLNT", splant);
            
    if (!string.IsNullOrEmpty(skeytGreaterThan)){        
        sql = DBFormatter.addWhereAndSentence(sql);     
        string sfields = "Rtrim(AQTYPE)";                       sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields,"Rtrim(AQPLNT)");  sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields,"Rtrim(AQPART)");  sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastSeq);        sfields = DBFormatter.concat(sfields,"'"+ Constants.DEFAULT_SEP + "'");
        sfields = DBFormatter.concat(sfields, scastLin);
        sql+= sfields + " > '" + skeytGreaterThan + "'";
    }
            
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class

} // namespace