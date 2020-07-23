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
class CapShiftProfileMachPlanEmployeeDataBaseContainer : GenericDataBaseContainer {

public
CapShiftProfileMachPlanEmployeeDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capshiftprofilemachplanemployee";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capshiftprofilemachplanemployee";
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
		CapShiftProfileMachPlanEmployeeDataBase capShiftProfileMachPlanEmployeeDataBase = new CapShiftProfileMachPlanEmployeeDataBase(dataBaseAccess);
		capShiftProfileMachPlanEmployeeDataBase.load(reader);
		this.Add(capShiftProfileMachPlanEmployeeDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table capshiftprofilemachplanemployee";
	truncate(sql);
}


public 
void readByHdrAll(int ihdrId){
	string sql = "select * from capshiftprofilemachplanemployee where HdrId =" + NumberUtil.toString(ihdrId) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}

public 
void deleteByHdr(int ihdrId){
	string sql = "delete from capshiftprofilemachplanemployee where HdrId =" + NumberUtil.toString(ihdrId);
    delete(sql);
}

} // class
} // package