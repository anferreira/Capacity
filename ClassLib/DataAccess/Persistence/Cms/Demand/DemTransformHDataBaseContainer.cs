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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class DemTransformHDataBaseContainer : GenericDataBaseContainer {

public
DemTransformHDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from demtransformh";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from demtransformh";
	if (searchText.Length > 0){
		sql += " where Status like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemTransformHDataBase demTransformHDataBase = new DemTransformHDataBase(dataBaseAccess);
		demTransformHDataBase.load(reader);
		this.Add(demTransformHDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table demtransformh";
	truncate(sql);
}


public
void readBFilters(int demandHdr,string status, int rows){
	string sql = "select * from demtransformh";

    if (demandHdr > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "DemandHdr=" + NumberUtil.toString(demandHdr);
            
    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Status", status + "%");

    sql+= " order by Id desc";

    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
            
	read(sql);
}

} // class
} // package