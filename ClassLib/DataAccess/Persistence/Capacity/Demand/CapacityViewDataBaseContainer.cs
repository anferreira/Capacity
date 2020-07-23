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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapacityViewDataBaseContainer : GenericDataBaseContainer {

public
CapacityViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capacityview";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capacityview";
	if (searchText.Length > 0){
		sql += " where Plant like '" + Converter.fixString(searchText) + "%'";
		sql += " or Dept like '" + Converter.fixString(searchText) + "%'";
		sql += " or ReqType like '" + Converter.fixString(searchText) + "%'";
		sql += " or Machine like '" + Converter.fixString(searchText) + "%'";
		sql += " or Labour like '" + Converter.fixString(searchText) + "%'";
		sql += " or Tool like '" + Converter.fixString(searchText) + "%'";
		sql += " or Title like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapacityViewDataBase capacityViewDataBase = new CapacityViewDataBase(dataBaseAccess);
		capacityViewDataBase.load(reader);
		this.Add(capacityViewDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table capacityview";
	truncate(sql);
}

public 
void readForReport(int icapacityHdrId,string splant,string sdept,string srequirment,int ireqId,string stype,string spart,DateTime dateWeek, bool bgroupByPlantDept,CapacityView.SORT_TYPE sortType){
    string sqlTotal = "select * from ( ";
    string sqlPart  =  string.IsNullOrEmpty(spart) ? "" : " and " + DBFormatter.equalLikeSql("cp.Part", spart) + " ";
    string sqlBasePastDue = "select cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId as ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cr.Hours) as Hours,'TitleXX' as Title,DATE_ADD(DATE_ADD(DATE(current_date()), INTERVAL(-WEEKDAY(DATE(current_date()))) DAY), INTERVAL -1 DAY) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail " + sqlPart;

    string sqlBase = "select cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId as ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cr.Hours) as Hours,'TitleXX' as Title, " + 
                    " DATE_ADD(DATE_ADD(CURDATE(), INTERVAL (9  - IF(DAYOFWEEK(CURDATE())=1, 8, DAYOFWEEK(CURDATE()))) DAY), INTERVAL DAYXX DAY) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail  " + sqlPart;

    string sqlGroupBy = bgroupByPlantDept ? " group by cp.Plant,cp.Dept,cr.Type,cr.ReqId " :  " group by cr.Type,cp.Plant,cp.Dept,cr.ReqId ";
    string sqlPastDue = sqlBasePastDue.Replace("TitleXX",CapacityView.TITLE_PASTDUE) +
                        " and cp.startDate < DATE_ADD(DATE(current_date()), INTERVAL(-WEEKDAY(DATE(current_date()))) DAY) " +
                        sqlGroupBy;

    string sqlWeekXXX= sqlBase +
                    " and(cp.startDate >= DATE_ADD(DATE_ADD(CURDATE(), INTERVAL (9  - IF(DAYOFWEEK(CURDATE())=1, 8, DAYOFWEEK(CURDATE()))) DAY), INTERVAL DAYXX DAY) " + //14
                    " and cp.startDate <= DATE_ADD(DATE_ADD(CURDATE(), INTERVAL (8 - IF(DAYOFWEEK(CURDATE())=1, 8, DAYOFWEEK(CURDATE()))) DAY), INTERVAL DAYYY DAY))" +//14
                    sqlGroupBy;



    if (ConnectionManager.getCURRENT_DATABASE().Equals(DataBaseAccess.SQLSERVER)){
        sqlBasePastDue = "select cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId as ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cr.Hours) as Hours,"+
                    "'TitleXX' as Title, Convert(date,DATEADD(day,-1,dateadd(wk, datediff(wk, 0, DATEADD(dd,-1,getdate())), 0))) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail " + sqlPart;

        sqlBase = "select cp.Plant as Plant,cp.Dept as Dept,cr.Type as ReqType,cr.ReqId as ReqId,m.PDM_Mach as Machine,m.PDM_DirectHoursToShifts as DirectHoursToShifts,'' as Labour, '' as Tool, sum(cr.Hours) as Hours,'TitleXX' as Title, " +                     
                    " Convert(date, DATEADD(day, DAYXX, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0))) as SDate " +
                    " from capacitypart cp , capacityreq cr " +
                    " LEFT join pltdeptmach m on cr.Type = 'M' and cr.ReqId = m.PDM_ID " +
                    " where cr.HdrId = " + NumberUtil.toString(icapacityHdrId) +
                    " and cr.hdrId = cp.hdrId and cr.detail = cp.detail  " + sqlPart;

                
        sqlGroupBy = bgroupByPlantDept ? " group by cp.Plant,cp.Dept,cr.Type,cr.ReqId " :  " group by cr.Type,cp.Plant,cp.Dept,cr.ReqId ";
        sqlGroupBy+= ",m.PDM_Mach,m.PDM_DirectHoursToShifts";
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
    if (ireqId > 0)
        sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery) + " ReqId=" + NumberUtil.toString(ireqId);
    if (!string.IsNullOrEmpty(stype))
        sqlSubQuery = DBFormatter.addWhereAndSentence(sqlSubQuery) + " ReqType='" + Converter.fixString(stype) + "'";

    if (dateWeek != DateUtil.MinValue){
        sqlSubQuery= DBFormatter.addWhereAndSentence(sqlSubQuery) +
                    "SDate ='" + DateUtil.getDateRepresentation(dateWeek,DateUtil.YYYYMMDD) +"'";
    }
        
    sqlTotal += " " + sqlSubQuery;
    //sqlTotal += bgroupByPlantDept ? " order by Plant,Dept,SDate,ReqType desc,Machine" : " order by ReqType,Plant,Dept,SDate,Machine";

           
    sqlTotal += " order by ";         
    if (bgroupByPlantDept)
        sqlTotal += sortType == CapacityView.SORT_TYPE.DEPT_REQUIRMENT ? " ReqType,Labour,Tool,Machine,SDate" : " Plant,Dept,ReqType,Labour,Tool,Machine,SDate";
    else
        sqlTotal += sortType == CapacityView.SORT_TYPE.DEPT_REQUIRMENT ? " ReqType,Labour,Tool,Machine,SDate" : " Plant,Dept,ReqType,Labour,Tool,Machine,SDate";        

    saveFile(sqlTotal);
    //System.Windows.Forms.MessageBox.Show(sqlTotal);
        
    read(sqlTotal);
}
      
private
void saveFile(string strData){
    string strFileName = "c:\\Temp\\rp.sql";
    System.IO.FileStream fs;
    System.IO.TextWriter tw = null;
	try{
			if (System.IO.File.Exists(strFileName))				
				fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Open);
    
			else
				fs= new System.IO.FileStream(strFileName, System.IO.FileMode.Create);
    
            tw = new System.IO.StreamWriter(fs);
            tw.Write(strData);

    }finally{
			if (tw != null){
				tw.Flush();
				tw.Close();
			}
    }
}

} // class
} // package