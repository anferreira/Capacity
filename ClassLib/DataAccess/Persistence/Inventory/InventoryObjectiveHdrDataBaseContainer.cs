/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class InventoryObjectiveHdrDataBaseContainer : GenericDataBaseContainer {

public
InventoryObjectiveHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from inventoryobjectivehdr";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from inventoryobjectivehdr";
	if (searchText.Length > 0){
		sql += " where Status like '" + Converter.fixString(searchText) + "%'";
		sql += " or Plant like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		InventoryObjectiveHdrDataBase inventoryObjectiveHdrDataBase = new InventoryObjectiveHdrDataBase(dataBaseAccess);
		inventoryObjectiveHdrDataBase.load(reader);
		this.Add(inventoryObjectiveHdrDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table inventoryobjectivehdr";
	truncate(sql);
}

public
void readByFilters(string sid,string splant,string status,DateTime fromDate,DateTime toDate,int rows){
    string sql = "select * from inventoryobjectivehdr";

    if (!string.IsNullOrEmpty(sid))
        sql = DBFormatter.addWhereAndSentence(sql) + " Id like '" + sid + "%'";
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);
  
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("DateCreated",fromDate, toDate,false);    
    
    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Status", status + "%");

    sql += " order by Id desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class
} // package