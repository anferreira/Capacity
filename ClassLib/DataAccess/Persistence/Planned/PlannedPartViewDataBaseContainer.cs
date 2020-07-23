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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned {

public
class PlannedPartViewDataBaseContainer : GenericDataBaseContainer {

public
PlannedPartViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PlannedPartViewDataBase plannedPartViewDataBase = new PlannedPartViewDataBase(dataBaseAccess);
		plannedPartViewDataBase.load(reader);
		this.Add(plannedPartViewDataBase);
	}
}

public 
void readForReport(string splant,int ihdrId,string spart,int seq){
    string sqlTotal = "select * from ( ";
    string sqlPart  =  string.IsNullOrEmpty(spart) ? "" : " and " + DBFormatter.equalLikeSql("cp.Part", spart) + " ";
    
    string sqlBase =
                "select part,seq,sum(QtyOriginal) QtyOriginal,sum(QtyPlanned) QtyPlanned,'TitleXX' as Title, " +
                " Convert(date, DATEADD(day, DAYXX, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0))) as SDate " +
                " from PlannedPart p where p.HdrId = " + ihdrId;                
                
    string sqlGroupBy = " group by part,seq";    
    string sqlWeekXXX= sqlBase +
                    " and (p.startDate >= Convert(date, DATEADD(day, DAYXX, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0)))  " +
                    " and  p.startDate <  Convert(date, DATEADD(day, DAYYY, dateadd(wk, datediff(wk, 0, DATEADD(dd, -1, getdate())), 0))) )" +                    
                    sqlGroupBy;
   
    int idays=7;

    for (int i=0; i <= CapacityView.TITLE_COUNTS;i++){
        string stitle = (i == 0) ? (CapacityView.TITLE_WEEKNUM + i.ToString()) : (CapacityView.TITLE_WEEKNUM + i.ToString());
        sqlTotal +=  " union all " + sqlWeekXXX.Replace("TitleXX",stitle).Replace("DAYXX", (idays*i).ToString()).Replace("DAYYY", ((idays * i) + 7).ToString());
    }
    
    sqlTotal+= " ) as q ";
    
            /*
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

    //System.Windows.Forms.MessageBox.Show(sqlTotal);
        
*/
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