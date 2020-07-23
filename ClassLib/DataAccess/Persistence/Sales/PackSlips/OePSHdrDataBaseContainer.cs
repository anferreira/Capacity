/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips{

public
class OePSHdrDataBaseContainer : GenericDataBaseContainer {

public
OePSHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from oepshdr";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from oepshdr";
	if (searchText.Length > 0){
		sql += " where BillTo like '" + Converter.fixString(searchText) + "%'";
		sql += " or ShipTo like '" + Converter.fixString(searchText) + "%'";
		sql += " or Status like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);
		oePSHdrDataBase.load(reader);
		this.Add(oePSHdrDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table oepshdr";
	truncate(sql);
}

public
void readByFilters(string splant,DateTime fromDate,DateTime toDate,int irows){
	string sql = "select * from oepshdr";

    if (!string.IsNullOrEmpty(splant))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);
	
    if (fromDate != DateUtil.MinValue || fromDate != DateUtil.MinValue )
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("DatePosted", fromDate,toDate);

    sql+= " order by Id desc";

    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
	read(sql);
}

} // class
} // package