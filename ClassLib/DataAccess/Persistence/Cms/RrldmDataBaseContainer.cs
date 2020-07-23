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
class RrldmDataBaseContainer : GenericDataBaseContainer {

public
RrldmDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from rrldm";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from rrldm";
	if (searchText.Length > 0){
		sql += " where BJ0REL# like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0AUTC like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0TIMC like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0ATYP like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0RAN# like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USR1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USR2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USR3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USR4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT5 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT6 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FLG1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FLG2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FLG3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FLG4 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FLG5 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT7 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT8 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUT9 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTA like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTB like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTC like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTD like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTE like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTF like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTG like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTH like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTI like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTJ like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0FUTK like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USR5 like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRF like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRG like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRH like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRI like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRJ like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRK like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRL like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRM like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USRN like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0TMZN like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0USID like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0ITYP like '" + Converter.fixString(searchText) + "%'";
		sql += " or BJ0OPCD like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		RrldmDataBase rrldmDataBase = new RrldmDataBase(dataBaseAccess);
		rrldmDataBase.load(reader);
		this.Add(rrldmDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table rrldm";
	truncate(sql);
}


public
void readByFilters(string stpartner,string spart,decimal pLKEYN,string spLREL,string signCumSearch,decimal cum,string sorderBy,int rows){
    string sql = "select * from " + getTablePrefix() + "rrldm rd";     

            /*
    if (!string.IsNullOrEmpty(stpartner) || !string.IsNullOrEmpty(spart)){
        sql+= " , " + getTablePrefix() + "RRlH rh";
    
        if (!string.IsNullOrEmpty(stpartner))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZTRPT",stpartner);
        if (!string.IsNullOrEmpty(stpartner))
            sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZCPT#",spart);

        sql+= " and rh.OZKEYN=rd.PLKEYN and rh.OZREL#=rd.PLREL# ";
    }*/

    if (pLKEYN > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "BJ0KEYN=" + NumberUtil.toString(pLKEYN);
    if (!string.IsNullOrEmpty(spLREL))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("BJ0REL#", spLREL);

    if (cum != decimal.MinValue)  
        sql = DBFormatter.addWhereAndSentence(sql) + "BJ0QCUM" + (string.IsNullOrEmpty(signCumSearch) ? "=" : signCumSearch) + NumberUtil.toString(cum);
                       
    sql+= " order by "  + (string.IsNullOrEmpty(sorderBy) ? "BJ0TDAT" : sorderBy);
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}


} // class
} // package