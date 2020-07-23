using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PopTvnDataBaseContainer : GenericDataBaseContainer{

public
PopTvnDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PopTvnDataBase popTvnDataBase = new PopTvnDataBase(dataBaseAccess);
		popTvnDataBase.load(reader);
		this.Add(popTvnDataBase);
    }
}

public
void read(){	
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "poptvn";

	read(sql);			
}

public
void truncate(){	
	string sql = "delete from poptvn";
    truncate(sql);	
}

public
PopTvnDataBaseContainer getPopTvnDataBaseContainer(string JRPT){
	PopTvnDataBaseContainer result = new PopTvnDataBaseContainer(dataBaseAccess);

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		PopTvnDataBase popTvnDataBase = (PopTvnDataBase)en.Current;

		if (JRPT.Equals(popTvnDataBase.getJRPT()))
			result.Add(popTvnDataBase);
	}
	return result;
}

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

} // class

} // namespace