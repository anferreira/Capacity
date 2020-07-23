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
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmpShiftScheduleReportViewDataBaseContainer : GenericDataBaseContainer {

public
EmpShiftScheduleReportViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from empshiftschedulereportview";
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EmpShiftScheduleReportViewDataBase empShiftScheduleReportViewDataBase = new EmpShiftScheduleReportViewDataBase(dataBaseAccess);
		empShiftScheduleReportViewDataBase.load(reader);
		this.Add(empShiftScheduleReportViewDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table empshiftschedulereportview";
	truncate(sql);
}

public
void readByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate,int ishiftNum,int rows){
    string sql = "select h.Id,h.Dept,h.ShiftNum,d.Detail,d.EmpId,e.FirstName,e.LastName,d.MachId,m.PDM_Mach Mach,m.PDM_Des1 MachDesc,cmp.Priority " +
                " from EmpShiftScheduleHdr h, EmpShiftScheduleDtl d , Employee e , pltdeptmach m " +
                " left outer join CapacityMachPriority cmp on cmp.MachineId = m.PDM_Id and cmp.HdrId = (select max(id) from capacityhdr "  + (!string.IsNullOrEmpty(splant) ? " where " + DBFormatter.equalLikeSql("Plant", splant) : "" ) + ") " +
                " where d.HdrId = h.ID and e.EmpID = d.EmpId and m.PDM_Id = d.MachId";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);

    if (!string.IsNullOrEmpty(sdept)){ 
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("m.PDM_Dept", sdept);        
    }
    
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue ){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql+= "( ";

        if (fromDate != DateUtil.MinValue)
            sql+= "Date >= '" + DateUtil.getCompleteDateRepresentation(fromDate, DateUtil.MMDDYYYY)  + "'";            
        
        if (toDate != DateUtil.MinValue){
            sql+= fromDate != DateUtil.MinValue ? " and " : "";
            sql+= " Date <= '" + DateUtil.getCompleteDateRepresentation(toDate, DateUtil.MMDDYYYY)  + "'";
        }

        sql += ")";
    }
  
    if (ishiftNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "ShiftNum =" + ishiftNum.ToString();

    sql += " order by e.LastName,e.FirstName";
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}


public
void readMachineByFilters(string splant,string sdept,DateTime fromDate,DateTime toDate,int ishiftNum,string swithPriorityYesNo,int rows){
    string sql = "select h.Id,h.Dept,h.ShiftNum,d.Detail,d.EmpId,e.FirstName,e.LastName,m.PDM_Id MachId,m.PDM_Mach Mach,m.PDM_Des1 MachDesc,cmp.Priority " +
                " from pltdeptmach m " +
                " left outer join PltDeptMachDef mdef on mdef.MachId=m.PDM_Id"  +
                " left outer join CapacityMachPriority cmp on cmp.MachineId = m.PDM_Id and cmp.HdrId = (select max(id) from capacityhdr " + (!string.IsNullOrEmpty(splant) ? " where " + DBFormatter.equalLikeSql("Plant", splant) : "") + ") " +                                
                " left outer join EmpShiftScheduleHdr h on ";
    bool  bwhereAdded=false;

    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql+= " " + DBFormatter.getSqlRangeDates("Date",fromDate,toDate);        

    if (ishiftNum > 0)
        sql+= " and ShiftNum =" + ishiftNum.ToString();
                                                                
    if (!string.IsNullOrEmpty(splant))
        sql+= " and " + DBFormatter.equalLikeSql("Plant",splant);

    sql+= " left outer join EmpShiftScheduleDtl d on d.HdrId = h.ID and d.MachId = m.PDM_Id";
    sql+= " left outer join Employee e on e.EmpID = d.EmpId " ;

    sql+= " where mdef.ShowOnTvReport = '" + Constants.STRING_YES +"'"; //where added so rest of filters will use 'and'

    if (!string.IsNullOrEmpty(sdept))        
        sql+= " and " + DBFormatter.equalLikeSql("m.PDM_Dept", sdept);        
    
    if (!string.IsNullOrEmpty(swithPriorityYesNo)){         
        if (swithPriorityYesNo.Equals(Constants.STRING_YES)) { 
            sql += " and cmp.Priority > 0";        
        }
    }
          
    sql += " order by m.PDM_Id";
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}



} // class
} // package