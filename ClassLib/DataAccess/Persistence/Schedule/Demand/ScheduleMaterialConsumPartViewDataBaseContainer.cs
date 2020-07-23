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
class ScheduleMaterialConsumPartViewDataBaseContainer : ScheduleMaterialConsumPartDataBaseContainer  {

public
ScheduleMaterialConsumPartViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ScheduleMaterialConsumPartViewDataBase scheduleMaterialConsumPartViewDataBase = new ScheduleMaterialConsumPartViewDataBase(dataBaseAccess);
		scheduleMaterialConsumPartViewDataBase.load(reader);
		this.Add(scheduleMaterialConsumPartViewDataBase);
	}
}

public
void readByFilters(int id,string spart,int seq,string smachine,int imachineId,DateTime startDate,DateTime endDate){    
	
    string sql = "select Convert(date,p.StartDate) StartDate, " +
                "0 HdrId,0 Detail,0 SubDetail,0 SubSubDetail,m.MatPart,m.MatSeq,'' MatType," +
                "0.0 QtyReq,sum(m.QtyReported) QtyReported,sum(QtyConsum) QtyConsum" +
                " from schedulematerialconsumpart as m ,schedulepart as p " +
                " where p.HdrId = m.HdrId and p.Detail= m.Detail ";            
    if (id > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "m.HdrId=" + NumberUtil.toString(id);
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) +  DBFormatter.equalLikeSql("m.MatPart", spart);
    if (seq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "m.MatSeq=" + NumberUtil.toString(seq);
        
    if (imachineId > 0 || !string.IsNullOrEmpty(smachine)){                            
        sql = DBFormatter.addWhereAndSentence(sql) + " exists ( " +
            " select b.PC_ProdID from pltdeptmach mch, prodfmactsub b " +
            " where b.PC_ProdID = m.MatPart and b.PC_Seq=m.MatSeq " +
            " and mch.PDM_Plt = b.PC_Plt and mch.PDM_Dept = b.PC_Dept and mch.PDM_Mach=b.PC_Cfg ";

            if (imachineId > 0)
                sql+= " and mch.PDM_ID = " + imachineId + " ";
            if (!string.IsNullOrEmpty(smachine))
                sql+= " and mch.PDM_Mach like '" + smachine + "%' ";            
            sql+=" )";
    }

    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue )        
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("p.StartDate", startDate, endDate,false);    

    sql+= " group by m.MatPart,m.MatSeq,Convert(date,p.StartDate)";//YEAR(p.StartDate), MONTH(p.StartDate), Day(p.StartDate)";        
    sql+= " order by Convert(date,p.StartDate)";
    
    read(sql);
}

} // class
} // package