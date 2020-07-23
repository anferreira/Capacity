/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: aferreira $ 
*   $Date: 2014-05-06 14:58:08 $ 
*   $Source: /usr/local/cvsroot/Projects/NujitWms2011/ClassLib/Persistence/Cms/Concord/TazmDataBaseContainer.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class TazmDataBaseContainer : GenericDataBaseContainer {

public
TazmDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from " + getTablePrefix() + "tazm";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from tazm";
	if (searchText.Length > 0){
		sql += " where ZMEMPL like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMFNME like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMLNME like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMADR1 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMADR2 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMADR3 like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMPOST like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMHPHO like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMHFAX like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMWPHO like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMWEXT like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMCONT like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMTELC like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMSOIN like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMTITL like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMETYP like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMCLCD like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMGRCD like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMTAG# like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMSTAT like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMREAS like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMBDEP like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMRPNT like '" + Converter.fixString(searchText) + "%'";
		sql += " or ZMUVER like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		TazmDataBase tazmDataBase = new TazmDataBase(dataBaseAccess);
		tazmDataBase.load(reader);
		this.Add(tazmDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table tazm";
	truncate(sql);
}

public
void readByFilters(string sname,string slname, int rows){
	string sql = "select * from " + getTablePrefix() + "tazm";


	if (!string.IsNullOrEmpty(sname)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql+= "ZMFNME like %'" + sname + "%'";
	}
    if (!string.IsNullOrEmpty(slname)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += "ZMLNME like %'" + slname + "%'";
	}

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

} // class
} // package