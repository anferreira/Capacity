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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Cms;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class DemandDayDataBaseContainer : GenericDataBaseContainer {

public
DemandDayDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from demandday";
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemandDayDataBase demandDayDataBase = new DemandDayDataBase(dataBaseAccess);
		demandDayDataBase.load(reader);
		this.Add(demandDayDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table demandday";
	truncate(sql);
}

public
void readByFilters(string splant, string source, string stPartner, string shipLoc, string spart, string soldRelNum, string snewRelNum, decimal logNum, DateTime fromDate,DateTime toDate,bool bdesctOrder,int rows){
    string sql = "select * from  demandday ";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);
    if (!string.IsNullOrEmpty(source))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Source",source);
    if (!string.IsNullOrEmpty(stPartner))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TPartner", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ShipLoc", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Part", spart);
    if (!string.IsNullOrEmpty(soldRelNum))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OldRelNum", soldRelNum);
    if (!string.IsNullOrEmpty(snewRelNum))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("NewRelNum", snewRelNum);    
    
    if (logNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "LogNum=" + NumberUtil.toString(logNum);

    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue)
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("RelDate",fromDate,toDate);

    sql += " order by Plant,Source,TPartner,ShipLoc,Part,RelDate" + (bdesctOrder ? " desc":"") + ",LogNum desc";
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

public
void readByFiltersLogMinor(string splant, string source, string stPartner, string shipLoc, string spart, string soldRelNum, string snewRelNum, decimal logNum, DateTime fromDate,DateTime toDate,bool bdesctOrder,int rows){
    string sql = "select * from  demandday ";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);
    if (!string.IsNullOrEmpty(source))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Source",source);
    if (!string.IsNullOrEmpty(stPartner))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TPartner", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ShipLoc", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Part", spart);
    if (!string.IsNullOrEmpty(soldRelNum))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OldRelNum", soldRelNum);
    if (!string.IsNullOrEmpty(snewRelNum))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("NewRelNum", snewRelNum);    
    
    if (logNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "LogNum <" + NumberUtil.toString(logNum);

    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue)
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("RelDate",fromDate,toDate);

    sql += " order by Plant,Source,TPartner,ShipLoc,Part,RelDate" + (bdesctOrder ? " desc":"") + ",LogNum desc";
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

public
string getSqlMainRecsQuery(string source){    
    string sql = "select LogNum LogNum2 ,Plant Plant2, Source Source2,TPartner TPartner2, ShipLoc ShipLoc2,Part Part2 "+
                 " from (  select MAx(LogNum) LogNum,Plant,Source,TPartner,ShipLoc,Part from DemandDay "+
                 " where Source='" + Converter.fixString(source) +"'" + 
                 " group by Plant,Source,TPartner,ShipLoc,Part " +
                 " ) as q where q.LogNum=d.LogNum and q.Plant=d.Plant and q.Source=d.Source and q.TPartner=d.TPartner and q.ShipLoc=d.ShipLoc and q.Part=d.Part ";
    return sql;
}

public
string readByFilters(string splant, string source, string stPartner, string shipLoc, string spart, string snewRelNum, DateTime fromDate,DateTime toDate,int rows){
    string sqlTotal     = "";
    string sqlFilters   = "";
    string sqlFilters1  = "";
    string sql1         = "select d.Created,d.Id,d.Plant,d.Source,d.TPartner,d.ShipLoc,d.Part,d.RelDate,d.CumRequired,d.NewRelNum,d.LogNum " +
                        " from DemandDay d ";

    string sqlFilters2  = "";
    string sql2         = "select d2.Created,d2.Id,d2.Plant,d2.Source,d2.TPartner,d2.ShipLoc,d2.Part,d2.RelDate,d2.CumRequired,d2.NewRelNum,d2.LogNum " + 
                        " from DemandDay d  , DemandDay d2 ";    

    sqlFilters1 = DBFormatter.addWhereAndSentence(sqlFilters1) + " exists ( " + getSqlMainRecsQuery(source) + ")";
    sqlFilters1 = DBFormatter.addWhereAndSentence(sqlFilters1) + " OldRelNum <> ''";
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue)
        sqlFilters1 = DBFormatter.addWhereAndSentence(sqlFilters1) + DBFormatter.getSqlRangeDates("d.RelDate",fromDate,toDate);
    sql1+= sqlFilters1;


    sqlFilters2 = DBFormatter.addWhereAndSentence(sqlFilters2) + " exists ( " + getSqlMainRecsQuery(source) + ")";
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue)
        sqlFilters2 = DBFormatter.addWhereAndSentence(sqlFilters2) + DBFormatter.getSqlRangeDates("d2.RelDate",fromDate,toDate);
    sqlFilters2 = DBFormatter.addWhereAndSentence(sqlFilters2) + 
        " d.Plant = d2.Plant and d.Source = d2.Source and d.TPartner = d2.TPartner and d.ShipLoc = d2.ShipLoc " +
        " and d.Part = d2.Part and d.OldRelNum = d2.NewRelNum";
    sql2+= sqlFilters2;

    sqlTotal = "select Created,Id,Plant,Source,TPartner,ShipLoc,Part,RelDate,CumRequired,NewRelNum,LogNum from ( " + 
                sql1 + " union " + sql2 +
                " ) as sqlTotal ";

   if (!string.IsNullOrEmpty(splant))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("Plant",splant);
    if (!string.IsNullOrEmpty(source))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("Source",source);
    if (!string.IsNullOrEmpty(stPartner))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("TPartner", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("ShipLoc", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("Part", spart);
    if (!string.IsNullOrEmpty(snewRelNum))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("NewRelNum", snewRelNum);    
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue)
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.getSqlRangeDates("RelDate",fromDate,toDate);

    sqlTotal+= " " + sqlFilters;
    //sqlTotal+= " order by Plant,Source,TPartner,ShipLoc,Part,LogNum desc,NewRelNum desc, RelDate desc";

    return sqlTotal;
}

public
void readByFilters2(string splant, string source, string stPartner, string shipLoc, string spart, string snewRelNum, DateTime fromDate,DateTime toDate,int rows){
    string sqlTotal     = "";
    string sqlFilters   = "";    
    string sql          =   "select * from DemandDay d ";
    
    sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + " exists ( " + getSqlMainRecsQuery(source) + ")";
    sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + " OldRelNum <> ''"; // we do not check if OldRelDate there because on some case there was not prior value minor for that date and OldRelDate <> '" + DateUtil.getDateRepresentation(DateUtil.MinValue,DateUtil.MMDDYYYY) + "'";
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue)
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.getSqlRangeDates("d.RelDate",fromDate,toDate);
    
   if (!string.IsNullOrEmpty(splant))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("Plant",splant);
    if (!string.IsNullOrEmpty(source))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("Source",source);
    if (!string.IsNullOrEmpty(stPartner))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("TPartner", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("ShipLoc", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("Part", spart);
    if (!string.IsNullOrEmpty(snewRelNum))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("NewRelNum", snewRelNum);    
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue)
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.getSqlRangeDates("RelDate",fromDate,toDate);

    sqlTotal+= sql + sqlFilters;
    sqlTotal+= " order by Plant,Source,TPartner,ShipLoc,Part,LogNum desc,NewRelNum desc, RelDate desc";

    read(sqlTotal);
}

} // class
} // package