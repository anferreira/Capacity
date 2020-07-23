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
class CapShiftProfileMachPlanDataBaseContainer : GenericDataBaseContainer {

public
CapShiftProfileMachPlanDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capshiftprofilemachplan";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capshiftprofilemachplan";
	if (searchText.Length > 0){
		sql += " where FullShift like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapShiftProfileMachPlanDataBase capShiftProfileMachPlanDataBase = new CapShiftProfileMachPlanDataBase(dataBaseAccess);
		capShiftProfileMachPlanDataBase.load(reader);
		this.Add(capShiftProfileMachPlanDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table capshiftprofilemachplan";
	truncate(sql);
}

public 
void readByHdr(int ihdrId){
	string sql = "select * from capshiftprofilemachplan where HdrId =" + NumberUtil.toString(ihdrId) +
                " order by HdrId,Detail";
    read(sql);
}

public 
void readByHdrsMachine(string shdrListIds,int imachineId){
	string sql = "select * from capshiftprofilemachplan where HdrId in (" + shdrListIds + ") and " +
                 "MachId=" + NumberUtil.toString(imachineId);                
    read(sql);
}

public 
void deleteByHdr(int ihdrId){
	string sql = "delete from capshiftprofilemachplan where HdrId =" + NumberUtil.toString(ihdrId);
    delete(sql);
}

} // class
} // package