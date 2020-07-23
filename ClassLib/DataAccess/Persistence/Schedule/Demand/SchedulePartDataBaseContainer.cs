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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class SchedulePartDataBaseContainer : GenericDataBaseContainer {

public
SchedulePartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from schedulepart";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from schedulepart";
	if (searchText.Length > 0){
		sql += " where Part like '" + Converter.fixString(searchText) + "%'";
		sql += " or IsFamily like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		SchedulePartDataBase schedulePartDataBase = new SchedulePartDataBase(dataBaseAccess);
		schedulePartDataBase.load(reader);
		this.Add(schedulePartDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table schedulepart";
	truncate(sql);
}

public
void readByHdrAll(int id){
	string sql = "select * from schedulepart where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from schedulepart where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}

public
void readByFilters(int capacityHdrId,int hotListId){
    string sql = "select * from schedulepart";

    if (capacityHdrId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " CapacityHdrId =" + NumberUtil.toString(capacityHdrId);
    if (hotListId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " HotListId =" + NumberUtil.toString(hotListId);
                
    read(sql);
}

} // class
} // package