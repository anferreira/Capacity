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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class SchedulePartInventoryViewDataBaseContainer : GenericDataBaseContainer {

public
SchedulePartInventoryViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		SchedulePartInventoryViewDataBase schedulePartInventoryViewDataBase = new SchedulePartInventoryViewDataBase(dataBaseAccess);
		schedulePartInventoryViewDataBase.load(reader);
		this.Add(schedulePartInventoryViewDataBase);
	}
}

public
void readByFilters(int id,string spart,int iseq, string smachine, int imachineId,string sglExp,DateTime startDate,DateTime endDate,int rows){
    string sqlFilters="";
    string sql ="select q.*,p.PFS_Des1 Des1 from ( " +
                " select 'QOH' Type,IPL_ProdID Part,IPL_Seq Seq, sum(IPL_Qoh)RecQty, 0.0 RepQty, GETDATE() RecDate " + //inventory
                " from invpltloc " +
                " group by IPL_ProdID, IPL_Seq " +

                " union all " +

                " select 'RCPA' Type,p.Part, p.Seq, rp.RecQty, rp.RepQty, rp.RecDate" +
                " from schedulereceiptpart rp, schedulepart p " +
                " where rp.HdrId = p.HdrId and rp.Detail = p.Detail ";
                if (id > 0)
                    sql+= " and rp.HdrId = " + NumberUtil.toString(id);

                sql+= " union all " +
                " select 'MATC' Type,mc.MatPart Part, mc.MatSeq Seq, (mc.QtyConsum * -1) RecQty,mc.QtyReported RepQty,rp.RecDate " +
                " from schedulereceiptpart rp, schedulematerialconsumpart mc " +
                " where rp.HdrId = mc.HdrId and  rp.Detail = mc.Detail and rp.SubDetail = mc.SubDetail ";
                if (id > 0)
                    sql += " and rp.HdrId = " + NumberUtil.toString(id);

    sql += " ) as q left outer join prodfminfo as p on p.PFS_ProdID = Part";

    if (!string.IsNullOrEmpty(spart))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) +  DBFormatter.equalLikeSql("Part",spart);
    if (!string.IsNullOrEmpty(sglExp))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) +  DBFormatter.equalLikeSql("PFS_GLExp",sglExp);
    if (iseq >= 0)
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + "Seq=" + NumberUtil.toString(iseq);
                
    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue )
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.getSqlRangeDates("RecDate", startDate, endDate,false);
        
    if (imachineId > 0 || !string.IsNullOrEmpty(smachine)){               
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + " exists ( " +
                    getSqlMachine(smachine, imachineId,"Part","Seq") +
                    " )";
    }    

    sql+= sqlFilters;
    sql+= " order by Part,Seq,RecDate";

    if (rows > 0)
        sql+= DBFormatter.selectTopRows(sql,rows);

    read(sql);
}


private
string getSqlMachine(string smachine, int imachineId,string spartField,string seqField){
    string sql =
        " select b.PC_ProdID from pltdeptmach m, prodfmactsub b " +
        " where b.PC_ProdID = " + spartField + " and b.PC_Seq= " + seqField + " " +
        " and m.PDM_Plt = b.PC_Plt and m.PDM_Dept = b.PC_Dept and m.PDM_Mach=PC_Cfg ";
    if (imachineId > 0)
        sql+= " and m.PDM_ID = " + imachineId + " ";
    if (!string.IsNullOrEmpty(smachine))
        sql+= " and m.PDM_Mach like '" + smachine + "%' ";       
   
    return sql;
}

} // class
} // package