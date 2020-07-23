using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ProdFmInfoViewDataBaseContainer : ProdFmInfoDataBaseContainer   {

public
ProdFmInfoViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ProdFmInfoViewDataBase prodFmInfoViewDataBase = new ProdFmInfoViewDataBase(dataBaseAccess);
		prodFmInfoViewDataBase.load(reader);
		this.Add(prodFmInfoViewDataBase);
	}
}

public
void readByFilters(string splant,string sprodId,string sdes1,int imachineId,string smajGroup,string stype,string schMatAvailFlag,int rows){
    string      sqlQoh      = " , (select sum(IPL_Qoh) from invpltloc where IPL_ProdID=PFS_ProdID and IPL_Seq=PFS_SeqLast " + (!string.IsNullOrEmpty(splant) ? " and IPL_Plant='"+ splant +"'" : "") + ") as Qoh ";
    string      sql          = "select p.*,s.Id as SchMaterialAvailId" + sqlQoh + " from prodfminfo p left outer join SchMaterialAvail s on ParentPart=PFS_ProdID and ParentSeq=PFS_SeqLast ";
    string      sqlFilters   = "";
    DateTime    fromDate= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,0,0,0);
    DateTime    toDate  = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23,59,59);

    if (!string.IsNullOrEmpty(splant)) 
        sql+= " and s.Plant='" + splant + "'";
    
    sql+= " and ParentSrcHotId in ( select Max(Id) from HotListHdr " + 
          (!string.IsNullOrEmpty(splant) ? " where HLR_Plant='" + splant + "'" :"") +  " )";          
            
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql+= " and " + DBFormatter.getSqlRangeDates("s.DateTime", fromDate, toDate,true);            
    sql+= " and s.CounterParentSrcHotId=1"; //main record, to not duplicate records

    sql+= " left outer join hotlist h on h.HOT_Id=ParentSrcHotId and HOT_ProdID=PFS_ProdID and HOT_Seq=PFS_SeqLast";

    if (!string.IsNullOrEmpty(sprodId))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + " PFS_ProdID like '" + sprodId + "'";
    if (!string.IsNullOrEmpty(sdes1))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + " PFS_Des1 like '" + sdes1 + "'";

    if (imachineId > 0){                            
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + " PFS_ProdID in (" +
            " select b.PC_ProdID from pltdeptmach m, prodfmactsub b " +
            " where m.PDM_Plt = b.PC_Plt and m.PDM_Dept = b.PC_Dept and m.PDM_Mach=PC_Cfg " +
            " and m.PDM_ID = " + imachineId + ")";            
    }

    if (!string.IsNullOrEmpty(smajGroup))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("PFS_MajorGroup",smajGroup);
    if (!string.IsNullOrEmpty(stype))
        sqlFilters = DBFormatter.addWhereAndSentence(sqlFilters) + DBFormatter.equalLikeSql("PFS_PartType", stype);    

    if (!string.IsNullOrEmpty(schMatAvailFlag)){
        sqlFilters= DBFormatter.addWhereAndSentence(sqlFilters)  + "ParentSeq " + (schMatAvailFlag.Equals(Constants.STRING_YES) ? " is not null " : " is null");

        if (schMatAvailFlag.Equals(Constants.STRING_NO))
           sqlFilters= DBFormatter.addWhereAndSentence(sqlFilters) + " exists (select BMS_ProdID from bomsum where BMS_ProdID=PFS_ProdID and BMS_Seq=PFS_SeqLast)" +
                        " and h.HOT_Seq is not null "; //and exist hot list for that part/seq
    }

    sql+= " " + sqlFilters;
    
    sql += " order by PFS_ProdID";
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}


} // class

} // namespace