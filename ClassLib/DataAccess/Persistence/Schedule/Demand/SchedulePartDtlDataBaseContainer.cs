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
class SchedulePartDtlDataBaseContainer : GenericDataBaseContainer {

public
SchedulePartDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from schedulepartdtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from schedulepartdtl";
	if (searchText.Length > 0){
		sql += " where Part like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		SchedulePartDtlDataBase schedulePartDtlDataBase = new SchedulePartDtlDataBase(dataBaseAccess);
		schedulePartDtlDataBase.load(reader);
		this.Add(schedulePartDtlDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table schedulepartdtl";
	truncate(sql);
}
 
public
void readByHdrAll(int id){
	string sql = "select * from schedulepartdtl where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from schedulepartdtl where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package