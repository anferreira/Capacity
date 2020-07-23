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
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class ScheduleReceiptPartViewDataBaseContainer  : ScheduleReceiptPartDataBaseContainer  {

public
ScheduleReceiptPartViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ScheduleReceiptPartViewDataBase scheduleReceiptPartViewDataBase = new ScheduleReceiptPartViewDataBase(dataBaseAccess);
		scheduleReceiptPartViewDataBase.load(reader);
		this.Add(scheduleReceiptPartViewDataBase);
	}
}

public
void readByFilters(int id,string spart,int seq,string smachine,int imachineId,DateTime startDate,DateTime endDate){    
	
    string sql = "select p.part,p.seq,Convert(date, r.RecDate) RecDate, " +
                " 0 HdrId, 0 Detail, 0 SubDetail,Convert(date, r.RecDate) StartDate,0 RecShift, " +
                " sum(r.RecQty) RecQty , sum(r.RepQty) RepQty " +
                " from schedulereceiptpart as r ,schedulepart as p " +
                " where p.HdrId = r.HdrId and p.Detail= r.Detail ";

    if (id > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "r.HdrId=" + NumberUtil.toString(id);
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("p.part",spart);
    if (seq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "p.seq=" + NumberUtil.toString(seq);

    if (!string.IsNullOrEmpty(smachine))
        sql = DBFormatter.addWhereAndSentence(sql) + " p.MachId in (select PDM_Id from pltdeptmach where PDM_Mach like '" + smachine + "%')";

    if (imachineId > 0)                            
        sql = DBFormatter.addWhereAndSentence(sql) + "p.MachId= " + NumberUtil.toString(imachineId);            

    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue )              
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("r.RecDate", startDate,endDate,false);                 

    sql+= " group by p.part,p.seq,Convert(date, r.RecDate)"; //  YEAR(r.RecDate), MONTH(r.RecDate), Day(r.RecDate)";        
    sql+= " order by RecDate";
    
    read(sql);
}

} // class
} // package