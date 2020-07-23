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
class ScheduleTaskDataBaseContainer : GenericDataBaseContainer {

public
ScheduleTaskDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from scheduletask";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from scheduletask";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ScheduleTaskDataBase scheduleTaskDataBase = new ScheduleTaskDataBase(dataBaseAccess);
		scheduleTaskDataBase.load(reader);
		this.Add(scheduleTaskDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table scheduletask";
	truncate(sql);
}

public
void readByHdrAll(int id){
	string sql = "select * from scheduletask where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from scheduletask where HdrId=" + NumberUtil.toString(id);	
	delete(sql);
}

} // class
} // package