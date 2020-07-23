using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class JithDataBaseContainer: GenericDataBaseContainer	{


public 
JithDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    while(reader.Read()){
		JithDataBase jithDataBase = new JithDataBase(dataBaseAccess);
		jithDataBase.load(reader);
		this.Add(jithDataBase);
	}
}

public
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary +".";
	sql += "jith";

    read(sql);			
}

public
void truncate(){	
	string sql = "delete from jith";
    truncate(sql);	
}

public
void readByFilters(decimal dkeyNum,string sreference,string stpartner,string srelease,string shipLoc,string spart,int irows){ 
    string  sql = "select * from " + getTablePrefix() + "jith jh";

    if (dkeyNum > 0)
        sql= DBFormatter.addWhereAndSentence(sql) + "SPKEYN=" + NumberUtil.toString(dkeyNum);
            
    if (!string.IsNullOrEmpty(sreference))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("SPREF#", sreference);  

    if (!string.IsNullOrEmpty(srelease))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("SPREL#",srelease);  
    
    if (!string.IsNullOrEmpty(stpartner))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("SPTRPT",stpartner);

    if (!string.IsNullOrEmpty(shipLoc))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("SPSTXL",shipLoc);            

    if (!string.IsNullOrEmpty(spart))
        sql= DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("SPCPT#",spart);
            
    sql+= " order by SPLOG# desc";

    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,irows);

    read(sql);
}

}

}
