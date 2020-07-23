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
class EmpShiftScheduleDtlDataBaseContainer : GenericDataBaseContainer {

public
EmpShiftScheduleDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from empshiftscheduledtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from empshiftscheduledtl";
	if (searchText.Length > 0){
		sql += " where EmpId like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EmpShiftScheduleDtlDataBase empShiftScheduleDtlDataBase = new EmpShiftScheduleDtlDataBase(dataBaseAccess);
		empShiftScheduleDtlDataBase.load(reader);
		this.Add(empShiftScheduleDtlDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table empshiftscheduledtl";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql = "select * from empshiftscheduledtl where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from empshiftscheduledtl where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package