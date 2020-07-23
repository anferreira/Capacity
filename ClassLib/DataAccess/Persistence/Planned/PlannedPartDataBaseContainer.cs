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
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned {

public
class PlannedPartDataBaseContainer : GenericDataBaseContainer {

public
PlannedPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from plannedpart";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from plannedpart";
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
		PlannedPartDataBase plannedPartDataBase = new PlannedPartDataBase(dataBaseAccess);
		plannedPartDataBase.load(reader);
		this.Add(plannedPartDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table plannedpart";
	truncate(sql);
}

public
void readByHdr(int id,int detail){
	string sql = "select * from plannedpart where HdrId=" + NumberUtil.toString(id) +
                " and Detail=" + NumberUtil.toString(detail) +
                " order by SubDetail";
    read(sql);
}

public
void readByHdrAll(int id){
	string sql = "select * from plannedpart where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from plannedpart where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}

public
void deleteByReqHdr(int ihdr,int idtl){
	string sql = "delete from plannedpart where HdrId=" + NumberUtil.toString(ihdr) +
                                          " and Detail="+ NumberUtil.toString(idtl);
    delete(sql);
}

public
void updateShifProfileRemoved(int iprofMachPlanHdrId,ArrayList arrayListMachPlanDetails){
	string sql = "update plannedpart set ProfMachPlanHdrId=0,ProfMachPlanHdrDtl=0 where ProfMachPlanHdrId=" + NumberUtil.toString(iprofMachPlanHdrId);

    if (arrayListMachPlanDetails.Count > 0){
        sql+= " and ProfMachPlanHdrDtl Not In (";
        string saux ="";
        foreach(int iprofMachPlanHdrDtl in arrayListMachPlanDetails)
            saux += (string.IsNullOrEmpty(saux) ? "" : ",") + iprofMachPlanHdrDtl.ToString();
        sql+= saux + ")";
    }          
    update(sql);
}


} // class
} // package