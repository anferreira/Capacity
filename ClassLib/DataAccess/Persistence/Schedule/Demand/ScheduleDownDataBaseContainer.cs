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
class ScheduleDownDataBaseContainer : GenericDataBaseContainer {

public
ScheduleDownDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from scheduledown";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from scheduledown";
	if (searchText.Length > 0){
		sql += " where Type like '" + Converter.fixString(searchText) + "%'";
		sql += " or TypeName like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ScheduleDownDataBase scheduleDownDataBase = new ScheduleDownDataBase(dataBaseAccess);
		scheduleDownDataBase.load(reader);
		this.Add(scheduleDownDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table scheduledown";
	truncate(sql);
}

public
void readByHdrAll(int id){
	string sql = "select * from scheduledown where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from scheduledown where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}

} // class
} // package