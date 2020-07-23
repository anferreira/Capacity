using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class RrldDataBaseContainer : GenericDataBaseContainer	{

public 
RrldDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		RrldDataBase rrldDataBase = new RrldDataBase(dataBaseAccess);
		rrldDataBase.load(reader);
		this.Add(rrldDataBase);
    }
}

public
void read(){
    string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary+".";
	sql += "rrld";

	read(sql);		
}

public
void truncate(){
	string sql = "delete from rrld";
	truncate(sql);	
}

public
void readByFilters(string stpartner,string spart,decimal pLKEYN,string spLREL,DateTime pLRDAT, string signCumSearch,decimal cum,string sorderBy,int rows){
    string sql = "select * from " + getTablePrefix() + "rrld rd";     
            
    if (!string.IsNullOrEmpty(stpartner) || !string.IsNullOrEmpty(spart)){
        sql+= " , " + getTablePrefix() + "RRlH rh";
    
        if (!string.IsNullOrEmpty(stpartner))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZTRPT",stpartner);
        if (!string.IsNullOrEmpty(stpartner))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZCPT#",spart);

        sql+= " and rh.OZKEYN=rd.PLKEYN and rh.OZREL#=rd.PLREL# ";
    }

    if (pLKEYN > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "PLKEYN=" + NumberUtil.toString(pLKEYN);
    if (!string.IsNullOrEmpty(spLREL))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PLREL#", spLREL);

    if (pLRDAT != DateUtil.MinValue)
        sql = DBFormatter.addWhereAndSentence(sql) + "PLRDAT='" + DateUtil.getDateRepresentation(pLRDAT,DateUtil.MMDDYYYY) + "'";

    if (cum != decimal.MinValue)  
        sql = DBFormatter.addWhereAndSentence(sql) + "PLQCUM" + (string.IsNullOrEmpty(signCumSearch) ? "=" : signCumSearch) + NumberUtil.toString(cum);
                       
    sql+= " order by "  + (string.IsNullOrEmpty(sorderBy) ?  "PLRDAT": sorderBy);
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

public
void readByFilters(string stpartner,string spart,decimal pLKEYN,string spLREL,DateTime pLRDAT,int rows){
    string sql = "select * from " + getTablePrefix() + "rrld rd";     
            
    if (!string.IsNullOrEmpty(stpartner) || !string.IsNullOrEmpty(spart)){
        sql+= " , " + getTablePrefix() + "RRlH rh";
    
        if (!string.IsNullOrEmpty(stpartner))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZTRPT",stpartner);
        if (!string.IsNullOrEmpty(stpartner))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZCPT#",spart);

        sql+= " and rh.OZKEYN=rd.PLKEYN and rh.OZREL#=rd.PLREL# ";
    }

    if (pLKEYN > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "PLKEYN=" + NumberUtil.toString(pLKEYN);
    if (!string.IsNullOrEmpty(spLREL))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PLREL#", spLREL);

    if (pLRDAT != DateUtil.MinValue)
        sql = DBFormatter.addWhereAndSentence(sql) + "PLRDAT='" + DateUtil.getDateRepresentation(pLRDAT,DateUtil.MMDDYYYY) + "'";
                       
    sql+= " order by PLRDAT";
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

}//end class

}//end namespace
