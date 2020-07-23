using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines{


public 
class PltDeptMachViewDataBaseContainer : PltDeptMachDataBaseContainer{

public
PltDeptMachViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PltDeptMachViewDataBase pltDeptMachViewDataBase = new PltDeptMachViewDataBase(dataBaseAccess);
		pltDeptMachViewDataBase.load(reader);
		this.Add(pltDeptMachViewDataBase);
	}
}

public
void readByFilters(string smachine,string sdes1, string splant, string sdept,string scheduled,DateTime planDate, ArrayList arrayMachineIds, int rows){
    string sql = "select m.*, mdef.DateLastPlanned as DateLastPlanned , " +
                " (select Priority from CapacityMachPriority p where p.HdrId = (select max(Id) from capacityhdr where Plant=m.PDM_Plt) " +
                " and p.MachineId = m.PDM_Id) as Priority " +
                " from pltdeptmach m left outer join PltDeptMachDef mdef on mdef.MachId=PDM_ID";
    string sqlAux = "";

    sqlAux+= readBaseByFilters(smachine, sdes1, splant, sdept, scheduled);

    if (arrayMachineIds.Count > 0){
        sqlAux = DBFormatter.addWhereAndSentence(sqlAux) + " PDM_ID in (";
        string sids = "";

        for (int i=0; i < arrayMachineIds.Count;i++){
            sids+= string.IsNullOrEmpty(sids) ? "":","; 
            sids+= ((int)arrayMachineIds[i]).ToString(); 
        }
        sqlAux+= sids + ")";
    }

    if (planDate != DateUtil.MinValue) {
        planDate = DateUtil.minorHour(planDate);
        sqlAux = DBFormatter.addWhereAndSentence(sqlAux) + "mdef.DateLastPlanned < '"  + DateUtil.getCompleteDateRepresentation(planDate,DateUtil.MMDDYYYY) +"'";
        //might have hot list record too
        sqlAux+= " and exists (" +
              " select HOT_Id from hotlist where HOT_Id in (select max(Id) from hotlisthdr where HLR_Plant=m.PDM_Plt) " +
              " and HOT_Plt=m.PDM_Plt and HOT_Dept=PDM_Dept and HOT_Mach=PDM_Mach )";
    }

    sql += sqlAux + " order by PDM_Dept,PDM_Mach";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}


} // class

} // namespace
