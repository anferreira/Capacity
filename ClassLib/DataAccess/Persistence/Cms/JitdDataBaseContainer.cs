using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class JitdDataBaseContainer: GenericDataBaseContainer{

public 
JitdDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		JitdDataBase jitdDataBase = new JitdDataBase(dataBaseAccess);
		jitdDataBase.load(reader);
		this.Add(jitdDataBase);
	}
}

public
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary +".";
	sql += "jitd";

    read(sql);   		
}

public
void truncate(){
	string sql = "delete from jitd";
	truncate(sql);	
}

/*
public
void readByFilters(string stpartner,string spart,decimal pLKEYN,string spLREL,string signCumSearch,decimal cum,string sorderBy,int rows){
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

    if (cum != decimal.MinValue)  
        sql = DBFormatter.addWhereAndSentence(sql) + "PLQCUM" + (string.IsNullOrEmpty(signCumSearch) ? "=" : signCumSearch) + NumberUtil.toString(cum);
                       
    sql+= " order by "  + (string.IsNullOrEmpty(sorderBy) ?  "PLRDAT": sorderBy);
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}
*/
public
void readByFilters(string stpartner,string spart,decimal pLKEYN,decimal logNum,string sreference,string sran,string signCumSearch,decimal cum,string sorderBy,int rows){
    string sql = "select * from " + getTablePrefix() + "jitd jd";     
            
    if (pLKEYN > 0 || !string.IsNullOrEmpty(stpartner) || !string.IsNullOrEmpty(sreference) || !string.IsNullOrEmpty(spart)){
        sql+= " , " + getTablePrefix() + "jith jh";
        if (pLKEYN > 0)
            sql = DBFormatter.addWhereAndSentence(sql) + "SPKEYN=" + NumberUtil.toString(pLKEYN);
        if (!string.IsNullOrEmpty(sreference))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SPREF#",sreference); 
    
        if (!string.IsNullOrEmpty(stpartner))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SPTRPT",stpartner);                                      
        if (!string.IsNullOrEmpty(spart))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SPCPT#",spart);

        sql+=" and jh.SPKEYN=jd.PYKEYN and jh.SPREF#=jd.PYREF#";
    }

    if (pLKEYN > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "PYKEYN=" + NumberUtil.toString(pLKEYN);
    if (logNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "PYLOG#=" + NumberUtil.toString(logNum);
            
    if (!string.IsNullOrEmpty(sreference))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PYREF#",sreference);
    if (!string.IsNullOrEmpty(sran))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PYRAN",sran);
            
    if (cum != decimal.MinValue)  
        sql = DBFormatter.addWhereAndSentence(sql) + "PYQCUM" + (string.IsNullOrEmpty(signCumSearch) ? "=" : signCumSearch) + NumberUtil.toString(cum);
                       
    sql+= " order by "  + (string.IsNullOrEmpty(sorderBy) ? "PYQCUM" : sorderBy);
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

}
}
