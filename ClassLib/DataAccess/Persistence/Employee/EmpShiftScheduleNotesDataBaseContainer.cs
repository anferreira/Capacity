/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmpShiftScheduleNotesDataBaseContainer : GenericDataBaseContainer {

public
EmpShiftScheduleNotesDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from empshiftschedulenotes";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from empshiftschedulenotes";
	if (searchText.Length > 0){
		sql += " where Topic like '" + Converter.fixString(searchText) + "%'";
		sql += " or Notes like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EmpShiftScheduleNotesDataBase empShiftScheduleNotesDataBase = new EmpShiftScheduleNotesDataBase(dataBaseAccess);
		empShiftScheduleNotesDataBase.load(reader);
		this.Add(empShiftScheduleNotesDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table empshiftschedulenotes";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql = "select * from empshiftschedulenotes where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from empshiftschedulenotes where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package