/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class JitdmDataBaseContainer : GenericDataBaseContainer {

public
JitdmDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from jitdm";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from jitdm";
	if (searchText.Length > 0){
		sql += " where BJ1REF# like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1SRC like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1RAN like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1REF1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1REF2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1STAT like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1KBPR like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1KBST like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1KBEN like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1SHPP like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1SHPT like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1TYPE like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1TIMT like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1TIMC like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1RTEG like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1SVCC like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1MODE like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1USR1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1USR2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1USR3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1USR4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT5 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT6 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT7 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUT8 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTA like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTB like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTC like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTD like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTE like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTF like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTG like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTH like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTI like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTJ like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTK like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTL like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTM like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTN like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTO like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTP like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTQ like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTR like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTS like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTT like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FUTU like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FLG1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FLG2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FLG3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1FLG4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1JITS like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1TMZN like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1USID like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1ITYP like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ1OPCD like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		JitdmDataBase jitdmDataBase = new JitdmDataBase(dataBaseAccess);
		jitdmDataBase.load(reader);
		this.Add(jitdmDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table jitdm";
	truncate(sql);
}

public
void readByFilters(string stpartner,string spart,decimal pLKEYN,decimal logNum,decimal ent, string sreference,string signCumSearch,decimal cum,string sorderBy,int rows){
    string sql = "select * from " + getTablePrefix() + "jitdm jd";     

    if (pLKEYN > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "BJ1KEYN=" + NumberUtil.toString(pLKEYN);
    if (!string.IsNullOrEmpty(sreference))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("BJ1REF#",sreference);

    if (logNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "BJ1LOG#=" + NumberUtil.toString(logNum);
    if (ent > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "BJ1ENT#=" + NumberUtil.toString(ent);
    
    if (cum != decimal.MinValue)  
        sql = DBFormatter.addWhereAndSentence(sql) + "BJ1QCUM" + (string.IsNullOrEmpty(signCumSearch) ? "=" : signCumSearch) + NumberUtil.toString(cum);
                       
    sql+= " order by "  + (string.IsNullOrEmpty(sorderBy) ? "BJ1DTTM" : sorderBy); 
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}


} // class
} // package