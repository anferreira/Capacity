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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapShiftProfileDtlDataBaseContainer : GenericDataBaseContainer {

public
CapShiftProfileDtlDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capshiftprofiledtl";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capshiftprofiledtl";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapShiftProfileDtlDataBase capShiftProfileDtlDataBase = new CapShiftProfileDtlDataBase(dataBaseAccess);
		capShiftProfileDtlDataBase.load(reader);
		this.Add(capShiftProfileDtlDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table capshiftprofiledtl";
	truncate(sql);
}

public
void readByHdr(int id){
	string sql ="select dtl.*,t.TaskName,t.DirInd from capshiftprofiledtl as dtl " +
                " left outer join capshifttask as t on t.Id = ShiftTaskId " +
                " where HdrId=" + NumberUtil.toString(id) +
                " order by Detail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from capshiftprofiledtl where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

} // class
} // package