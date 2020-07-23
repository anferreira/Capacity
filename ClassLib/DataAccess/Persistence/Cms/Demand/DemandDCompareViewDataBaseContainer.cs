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
class DemandDCompareViewDataBaseContainer : GenericDataBaseContainer {

public
DemandDCompareViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemandDCompareViewDataBase DemandDCompareViewDataBase = new DemandDCompareViewDataBase(dataBaseAccess);
		DemandDCompareViewDataBase.load(reader);
		this.Add(DemandDCompareViewDataBase);
	}
}
        
public
void readByFiltersGroupBy(string splant,string source,string stPartner, string shipLoc,string spart, DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){    
    string sfieldQty=  bcumulative ? "CurrCum" : "NetQty";
    string sql      = "select HdrId," + sfieldQty+ " NetQty,Source,RelNum,RelDate,TPartner,ShipLoc,Part,SDate from demandd d,demandH h where h.Id = d.HdrId";
    //string sgroupBy = " group by Source,RelNum,RelDate,TPartner,ShipLoc,Part,SDate";
    bool        b862 = !string.IsNullOrEmpty(source) && source.Equals(DemandD.SOURCE_862);                
                   
    if (!string.IsNullOrEmpty(splant))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);
    if (!string.IsNullOrEmpty(source))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Source", source);
    if (!string.IsNullOrEmpty(stPartner))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TPartner", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ShipLoc", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Part", spart);

    if (startRelDate != DateUtil.MinValue || endRelDate != DateUtil.MinValue) {         
        sql= DBFormatter.addWhereAndSentence(sql) + "( ";
        if (b862)
            sql+= " (RelDate = '" +  DateUtil.getDateRepresentation(DateUtil.MinValue,DateUtil.MMDDYYYY) +"' and " + DBFormatter.getSqlRangeDates("h.StaDate", startRelDate, endRelDate) + ") or (" ;            
        sql+= DBFormatter.getSqlRangeDates("RelDate",startRelDate,endRelDate);        
        sql+= ")"  + (b862 ? ")":"");            
    }

    //sql+= sgroupBy;
    sql= DBFormatter.addWhereAndSentence(sql) + sfieldQty + " <>0";

    sql+= " order by Source,RelDate desc,RelNum desc,TPartner,ShipLoc,Part";
    if (b862)
        sql+=",HdrId desc";    
     sql+= ",SDate";

    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
	read(sql);
}
        
public
void readAS400ByFiltersGroupBy(string splant,string source,string stPartner, string shipLoc,string spart, DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){    
    string sfieldQty=  bcumulative ?  "PLQCUM" : "PLQNET";
    string sql      = "select  CAST(OZLOG#  AS Int) HdrId ," + sfieldQty + " NetQty,'" + source + "' Source" + ",OZREL# RelNum,OYCDAT RelDate,OZTRPT TPartner,OZSTXL ShipLoc,OZCPT# Part,PLRDAT SDate " +
                     " from "   + getTablePrefix() + "RRLH rh," + getTablePrefix() +"RRLD rd " +
                        ","     + getTablePrefix() + "Stxh st";
    string splantSql="";    
                     
    //string sgroupBy = " group by Source,RelNum,RelDate,TPartner,ShipLoc,Part,SDate";
    bool        b862 = !string.IsNullOrEmpty(source) && source.Equals(DemandD.SOURCE_862);                
                        
/*
    if (!string.IsNullOrEmpty(source))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Source", source);
    */
    if (!string.IsNullOrEmpty(stPartner))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZTRPT", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZSTXL", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZCPT#",spart);

    if (startRelDate != DateUtil.MinValue || endRelDate != DateUtil.MinValue) {         
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("OYCDAT",startRelDate,endRelDate);        
    }
    
    sql= DBFormatter.addWhereAndSentence(sql) + "rh.OZKEYN = rd.PLKEYN and rh.OZREL#=rd.PLREL#" +
        " and OYLOG#=OZLOG# and OYTRPR=OZTRPT and OYENT# in (select max(st2.OYENT#) from " + getTablePrefix() + "Stxh st2 where st2.OYLOG#=st.OYLOG# and st2.OYTRPR=st.OYTRPR)";    
    sql= DBFormatter.addWhereAndSentence(sql) + sfieldQty + " <>0";

    if (!string.IsNullOrEmpty(splant)) { 
        splantSql = "select st.OYLOG# from " + getTablePrefix() + "Stxh st where st.OYLOG#=rh.OZLOG# and st.OYTRPR=rh.OZTRPT and OYPLNT='" + Converter.fixString(splant) + "'";    
        splantSql = " and exists (" + DBFormatter.selectTopRows(splantSql, 1) + ")";

        sql+= splantSql;
    }
    
    sql+= " order by OZLOG# desc,OZREL# desc,OZTRPT,OZSTXL,OZCPT#,PLRDAT";
    
    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
	read(sql);
}

public
void readAS400ByFilters862GroupBy(string splant,string source,string stPartner, string shipLoc,string spart, DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){            
    string sfieldQty=  bcumulative ? "PYQCUM" : "PYNQTY";
    string sql      = "select  CAST(SPLOG#  AS Int) HdrId ," + sfieldQty + " NetQty,'" + source + "' Source" + ",SPREF# RelNum,OYCDAT RelDate,SPTRPT TPartner,SPSTXL ShipLoc,SPCPT# Part,PYDATE SDate " +
                     " from "   + getTablePrefix() + "JITH jh , " + getTablePrefix() + "JITD as jd " +                      
                     ","        + getTablePrefix() + "Stxh st ";                                
    string splantSql="";
                     
    //string sgroupBy = " group by Source,RelNum,RelDate,TPartner,ShipLoc,Part,SDate";
    bool        b862 = !string.IsNullOrEmpty(source) && source.Equals(DemandD.SOURCE_862);                
                       
    /*
    if (!string.IsNullOrEmpty(source))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Source", source);
    */         
    if (!string.IsNullOrEmpty(stPartner))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SPTRPT", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SPSTXL", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("SPCPT#",spart);

    if (startRelDate != DateUtil.MinValue || endRelDate != DateUtil.MinValue) {         
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("PYDATE", startRelDate,endRelDate);        
    }
                    
    sql = DBFormatter.addWhereAndSentence(sql) + "jh.SPKEYN=jd.PYKEYN and jh.SPREF#=jd.PYREF#" +
        " and OYLOG#=SPLOG# and OYTRPR=SPTRPT and OYENT# in (select max(st2.OYENT#) from " + getTablePrefix() + "Stxh st2 where st2.OYLOG#=st.OYLOG# and st2.OYTRPR=st.OYTRPR)";    
    sql= DBFormatter.addWhereAndSentence(sql) + sfieldQty + " <>0";

    //if (!string.IsNullOrEmpty(splant))
        //sql= DBFormatter.addWhereAndSentence(sql) + "exists (select tr.SMCKEY from " + getTablePrefix() + "TRLP as tr where tr.SMTRPT=jh.SPTRPT and tr.SMSTXL=jh.SPSTXL and tr.SMCPT#=jh.SPCPT# and tr.SMCKEY=jh.SPKEYN and tr.SMPLANT='" + Converter.fixString(splant) + "')";                    

    if (!string.IsNullOrEmpty(splant)) { 
        splantSql = "select st.OYLOG# from " + getTablePrefix() + "Stxh st where st.OYLOG#=jh.SPLOG# and st.OYTRPR=jh.SPTRPT and OYPLNT='" + Converter.fixString(splant) + "'";    
        splantSql = " and exists (" + DBFormatter.selectTopRows(splantSql, 1) + ")";
        sql+= splantSql;
    }

    sql+= " order by SPLOG# desc,SPREF# desc,SPTRPT,SPSTXL,SPCPT#,PYDATE";
    
    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
	read(sql);
}

public
void readAS400BoldByFiltersGroupBy(string splant,string source,string stPartner, string shipLoc,string spart, DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){    
    string sfieldQty=  bcumulative ? "FGCCUM" : "FGQSHP";
    string sql      = "select  CAST(bh.FEBOL#  AS Int) HdrId," + sfieldQty + " NetQty,'" + source + "' Source,'' RelNum,bh.FESDAT RelDate,'' TPartner,'' ShipLoc,FGCPT# Part,bh.FESDAT SDate " + 
                     " from "   + getTablePrefix() + "bolh bh," + getTablePrefix() + "bold bd ";
                        //","     + getTablePrefix() + "Stxh st";                                  
    //string sgroupBy = " group by Source,RelNum,RelDate,TPartner,ShipLoc,Part,SDate";
    bool        b862 = !string.IsNullOrEmpty(source) && source.Equals(DemandD.SOURCE_862);                

    sql = DBFormatter.addWhereAndSentence(sql) +  "bh.FEBOL# = bd.FGBOL#";
    if (!string.IsNullOrEmpty(splant))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FEPLTC", splant);

            /*            
    if (!string.IsNullOrEmpty(stPartner))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZTRPT", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OZSTXL", shipLoc);*/
    if (!string.IsNullOrEmpty(spart))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FGCPT#", spart);

    if (startRelDate != DateUtil.MinValue || endRelDate != DateUtil.MinValue) {         
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("FESDAT",startRelDate,endRelDate);        
    }

    sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("FESIND",Constants.STRING_YES);
    sql += " order by FESDAT desc";
    
    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
	read(sql);
}


public
void readDemandDayByFiltersGroupBy(string splant,string source,string stPartner, string shipLoc,string spart, DateTime startRelDate, DateTime endRelDate,bool bcumulative,bool bqtyDifferences,int irows){    
    string sfieldQty= bqtyDifferences ? "(CumRequired - OldCumRequired)" : "CumRequired";
    string sql      = "select  Id HdrId," + sfieldQty + " NetQty,'" + source + "' Source,NewRelNum RelNum,Created RelDate,TPartner,ShipLoc,Part,RelDate SDate " + 
                     " from DemandDay";
                        //","     + getTablePrefix() + "Stxh st";                                  
    //string sgroupBy = " group by Source,RelNum,RelDate,TPartner,ShipLoc,Part,SDate";
    bool        b862 = !string.IsNullOrEmpty(source) && source.Equals(DemandD.SOURCE_862);                
    
    if (!string.IsNullOrEmpty(splant))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant", splant);
            
    if (!string.IsNullOrEmpty(stPartner))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TPartner", stPartner);
    if (!string.IsNullOrEmpty(shipLoc))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ShipLoc", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Part", spart);

    if (startRelDate != DateUtil.MinValue || endRelDate != DateUtil.MinValue) {         
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("RelDate", startRelDate,endRelDate);        
    }
    
    sql += " order by LogNum desc,NewRelNum desc,RelDate desc";
    
    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
	read(sql);
}

public
void readDemandDayAllChangesByFilters(string splant, string source, string stPartner, string shipLoc, string spart, string snewRelNum, DateTime fromDate, DateTime toDate, int rows){
    DemandDayDataBaseContainer  demandDayDataBaseContainer = new DemandDayDataBaseContainer(dataBaseAccess);
    string                      sql = "select  Id HdrId,CumRequired NetQty,'" + source + "' Source,NewRelNum RelNum,Created RelDate,TPartner,ShipLoc,Part,RelDate SDate " + 
                                " from (" + demandDayDataBaseContainer.readByFilters(splant, source, stPartner, shipLoc, spart, snewRelNum, fromDate, toDate,rows) + 
                                " ) as q" +
                                " order by TPartner,ShipLoc,Part,LogNum desc,NewRelNum desc, RelDate ";

    read(sql);
}

} // class
} // package