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
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapacityViewPartDataBaseContainer : CapacityViewDataBaseContainer {

public
CapacityViewPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapacityViewPartDataBase capacityViewPartDataBase = new CapacityViewPartDataBase(dataBaseAccess);
		capacityViewPartDataBase.load(reader);
		this.Add(capacityViewPartDataBase);
	}
}

public 
void readForPart(int icapacityHdrId,string splant,string sdept,string srequirment,string stype,MachineContainer machineContainer, DateTime startDate, DateTime endDate, bool bgroupByPlantDept,CapacityView.SORT_TYPE sortType){
    string sqlTotal = "select *, 0.0 Hours from ( ";
    string sqlBasePastDue = "select cp.Part,cp.Seq,cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cp.Qty) as Qty,'TitleXX' as Title,DATE_ADD(DATE_ADD(DATE(current_date()), INTERVAL(-WEEKDAY(DATE(current_date()))) DAY), INTERVAL -1 DAY) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail ";

    string sqlBase = "select cp.Part,cp.Seq,cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cp.Qty) as Qty,'TitleXX' as Title, " + 
                    " DATE_ADD(DATE_ADD(CURDATE(), INTERVAL (9  - IF(DAYOFWEEK(CURDATE())=1, 8, DAYOFWEEK(CURDATE()))) DAY), INTERVAL DAYXX DAY) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail ";

    string sqlGroupBy = bgroupByPlantDept ? " group by cp.Part,cp.Seq,cp.Plant,cp.Dept,cr.Type,cr.ReqId " : " group by cp.Part,cp.Seq,cr.Type,cp.Plant,cp.Dept,cr.ReqId ";
    string sqlPastDue = sqlBasePastDue.Replace("TitleXX",CapacityView.TITLE_PASTDUE) +
                        " and cp.startDate < DATE_ADD(DATE(current_date()), INTERVAL(-WEEKDAY(DATE(current_date()))) DAY) " +
                        sqlGroupBy;

    string sqlWeekXXX= sqlBase +
                    " and(cp.startDate >= DATE_ADD(DATE_ADD(CURDATE(), INTERVAL (9  - IF(DAYOFWEEK(CURDATE())=1, 8, DAYOFWEEK(CURDATE()))) DAY), INTERVAL DAYXX DAY) " + //14
                    " and cp.startDate <= DATE_ADD(DATE_ADD(CURDATE(), INTERVAL (8 - IF(DAYOFWEEK(CURDATE())=1, 8, DAYOFWEEK(CURDATE()))) DAY), INTERVAL DAYYY DAY))" +//14
                    sqlGroupBy;

    if (ConnectionManager.getCURRENT_DATABASE().Equals(DataBaseAccess.SQLSERVER)){
        sqlBasePastDue = "select cp.Part,cp.Seq,cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cp.Qty) as Qty,'TitleXX' as Title, Convert(date,DATEADD(day,-1,dateadd(wk, datediff(wk, 0, DATEADD(dd,-1,getdate())), 0))) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail ";

        sqlBase = "select cp.Part,cp.Seq,cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cp.Qty) as Qty,'TitleXX' as Title, " +                     
                    " Convert(date, DATEADD(day, DAYXX, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0))) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail ";

        sqlGroupBy = bgroupByPlantDept ? " group by cp.Plant,cp.Dept,cr.Type,cr.ReqId " :  " group by cr.Type,cp.Plant,cp.Dept,cr.ReqId ";
        sqlGroupBy+= ",cp.Part,cp.Seq,m.PDM_Mach,m.PDM_DirectHoursToShifts";        
        sqlPastDue = sqlBasePastDue.Replace("TitleXX",CapacityView.TITLE_PASTDUE) +
                        " and cp.startDate < Convert(date, DATEADD(day, 0, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0))) " +
                        sqlGroupBy;

        sqlWeekXXX= sqlBase +
                    " and (cp.startDate >= Convert(date, DATEADD(day, DAYXX, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0)))  " +
                    " and  cp.startDate <  Convert(date, DATEADD(day, DAYYY, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0))) )" +
                    sqlGroupBy;        
    }

    sqlTotal += sqlPastDue;
   
    int idays=7;         
    if (ConnectionManager.getCURRENT_DATABASE().Equals(DataBaseAccess.MYSQL)){
       for (int i=0; i <= CapacityView.TITLE_COUNTS;i++){
        string stitle = (i == 0) ? (CapacityView.TITLE_WEEKNUM + i.ToString()) : (CapacityView.TITLE_WEEKNUM + i.ToString());
        sqlTotal +=  " union all " + sqlWeekXXX.Replace("TitleXX",stitle).Replace("DAYXX", ((idays*i)-7).ToString()).Replace("DAYYY", (idays * i).ToString());
        }
    } else if (ConnectionManager.getCURRENT_DATABASE().Equals(DataBaseAccess.SQLSERVER)){
        for (int i=0; i <= CapacityView.TITLE_COUNTS;i++){
            string stitle = (i == 0) ? (CapacityView.TITLE_WEEKNUM + i.ToString()) : (CapacityView.TITLE_WEEKNUM + i.ToString());
            sqlTotal +=  " union all " + sqlWeekXXX.Replace("TitleXX",stitle).Replace("DAYXX", (idays*i).ToString()).Replace("DAYYY", ((idays * i) + 7).ToString());
        }
    }

    sqlTotal+= " ) as q ";
    
    string sqlSubQuery = "";

    if (!string.IsNullOrEmpty(splant))
        sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery) + " Plant like '" + Converter.fixString(splant) + "'";
    if (!string.IsNullOrEmpty(sdept))
        sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery) + " Dept like '" + Converter.fixString(sdept) + "'";
    if (!string.IsNullOrEmpty(srequirment))
        sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery) + " ( Machine like '" + Converter.fixString(srequirment) + "' or Labour like '" + Converter.fixString(srequirment) + "' or Tool like '" + Converter.fixString(srequirment) + "')";
    if (!string.IsNullOrEmpty(stype))
        sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery) + " ReqType='" + Converter.fixString(stype) + "'";

    if (startDate != DateUtil.MinValue && endDate != DateUtil.MinValue)
        sqlSubQuery= DBFormatter.addWhereAndSentence(sqlSubQuery) + DBFormatter.getSqlRangeDates("SDate", startDate, endDate,false);                    

    if (machineContainer.Count > 0){
        sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery) + " ReqId in (";
        for (int k=0; k < machineContainer.Count;k++){
            Machine machine = (Machine)machineContainer[k];               
            sqlSubQuery+= k > 0 ? "," : "";
            sqlSubQuery+= machine.Id.ToString();
        }
        sqlSubQuery+= ")";
    }
        
    sqlTotal += " " + sqlSubQuery;
    //sqlTotal += bgroupByPlantDept ? " order by Plant,Dept,SDate,ReqType desc,Machine" : " order by ReqType,Plant,Dept,SDate,Machine";

           
    sqlTotal += " order by ";         
    if (bgroupByPlantDept)
        sqlTotal += sortType == CapacityView.SORT_TYPE.DEPT_REQUIRMENT ? " ReqType,Labour,Tool,Machine,SDate" : " Plant,Dept,ReqType,Labour,Tool,Machine,SDate";
    else
        sqlTotal += sortType == CapacityView.SORT_TYPE.DEPT_REQUIRMENT ? " ReqType,Labour,Tool,Machine,SDate" : " Plant,Dept,ReqType,Labour,Tool,Machine,SDate";        

    
    //System.Windows.Forms.MessageBox.Show(sqlTotal);
        
    read(sqlTotal);
}

/*
public
void readHotList(int ihotlist){
            
    string sql ="select DATE_ADD(hdr.HLR_HotlistRunDate, INTERVAL 2 DAY) Date, " +
                " (h.HOT_Day002-h.HOT_Day001),h.HOT_ProdID,h.HOT_Seq,h.HOT_Dept,h.HOT_Mach,h.HOT_MachCyc "+
                " from hotlist h where = " + ihotlist;
    
    string sql="";
    string saux1="",saux2="";
    string sqlBase = "select DATE_ADD(hdr.HLR_HotlistRunDate, INTERVAL INTERVALDAY) Date, " +
                " (h.HOT_DayXXX-h.HOT_DayYYY),h.HOT_ProdID,h.HOT_Seq,h.HOT_Dept,h.HOT_Mach,h.HOT_MachCyc "+
                " from hotlist h where = " + ihotlist;            

    for (int i=2; i <= 90;i++){
        sql+= string.IsNullOrEmpty(sql) ? "" : " union ";
        
        saux1 = i.ToString("000");
        saux2 = (i-1).ToString("000");
        sql+= sqlBase.Replace("INTERVALDAY",i.ToString()).Replace("XXX",saux1).Replace("XXX", saux1);

    } 
} */

} // class
} // package