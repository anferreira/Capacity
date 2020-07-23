/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class UpCum01PViewDataBaseContainer : UpCum01PDataBaseContainer {

public
UpCum01PViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		UpCum01PViewDataBase upCum01PViewDataBase = new UpCum01PViewDataBase(dataBaseAccess);
		upCum01PViewDataBase.load(reader);
		this.Add(upCum01PViewDataBase);
	}
}
        /*
public 
void readByFilters(DateTime fromDate){

    string sql = "select " +
" t1.FEBOL# as BOLNumber, " +
" t1.FEBTYP as BOLType, " +
" t1.FESIND as Shipped, " +
" t1.FEBCS# as BillToNum, " +
" t1.FESCS# as ShipToNum, " +
" t1.FESDAT as ShipDate, " +
" T7.UPEXSD as ExpShipDate, " +
" t1.FEPLTC as Plant, " +
" t2.FGENT# as Line, " +
" t2.FGPART as Part, " +
" t2.FGCPT#  as CustPart, " +
" t2.FGORD# as OrderNum, " +
" t2.FGITEM as OrderItem, " +
" t2.FGCREL as OrderRelease, " +
" t2.FGQSHP as QtyShipped, " +
" t7.DDQTBI as QtyBackOrdered, " +
" t7.UPEXNQ as ExpectedQty, " +
" t2.FGCCUM as CumulativeQty, " +
" t2.FGPCUM as PreviousCQty, " +
" t2.FGCREL as EDIrelease, " +

" t4.AVMAJG as MajGroup, " +
" t4.AVMING as MinGroup, " +
" t4.AVMAJS as MajSales, " +
" t4.AVMINS as MinSales, " +
" t4.AVGLCD as GLSales, " +
" t4.AVGLED as GLExp, " +
" t6.DCOTYP as OrderType, " +
" t5.bvclas as CustClass, " +

" t3.SMCKEY as TRLP_key, " +
" t3.SMRDAT as TRLP_RELEASE_DATE, " +
" t3.SPTRPT as JITH_TRAD_PARTNER, " +
" t3.SPOEMC as JITH_CUM_REQUIRED, " +
" t3.SPOEMS as JITH_CUM_SHIPPING, " +
" t3.SPOEMD as JITD_CUM_DISCREPA, " +
" t3.PYDATE as JITD_PYDATE, " +
" t3.JITCUM as JITD_CUM_QTY, " +
" t3.OZOEMC as RRLH_CUM_REQUIRED, " +
" t3.OZOEMS as RRLH_CUM_SHIPPING , " +
" t3.OZCUMD as RRLH_CUM_DISCREPA, " +
" t3.PLRDAT as RRLD_RELEASE, " +
" t3.RRLCUM as RRLD_CUM_QTY, " +
" t3.UPLITI as LEAD_TIME, " +
" t3.UPARDA as ARRIVAL_DATE, " +
" t3.UPOTST as ON_TIME_STATUS, " +
" t3.UPQTST as QUANTITY_STATUS, " +

"  case  " +
"  when DCOTYP = 'S' THEN 'STANDARD' " +
"  when DCOTYP = 'B' and FGCREL = '' THEN 'BLANKET' " +
"  when DCOTYP = 'B' and FGCREL <> '' THEN 'BLANKETEDI' " +
" end as OrderType " +

" from " + getTablePrefix() + "BOLH as t1 " +
" join " + getTablePrefix() + "BOLD as t2 on t1.FEBOL# = t2.FGBOL# " +
" left join " + getTablePrefix() + "UPCUM01P as t3 on t2.FEBOL#= T3.FEBOL# and T2.FEITEM and T3.FEITEM " +
" join " + getTablePrefix() + "STKMM as t4 on t2.FGPART = t4.AVPART " +
" join " + getTablePrefix() + "CUST as t5 on t1.FEBCS# = t5.BVCUST " +
" join " + getTablePrefix() + "OCRH as t6 on t2.FGORD# = t6.DCORD# " +
" join " + getTablePrefix() + "OCRI as t7 on t2.FGORD# = t3.DDORD# and t2.FGITEM = t7.DDITM# " +

" where  " +
    " t1.FESDAT > '" + DateUtil.getDateRepresentation(fromDate,DateUtil.MMDDYYYY) + "' and " +
    " t1.FESIND = 'Y'"; 

    read(sql);
}
        */

private
string getSqlOcri(bool bapplyRule60Days){
    string sdateOcri   = "IFNULL(CAST(DC4TMSP AS Date),FESDAT)";   
    string srule60Days = " and " + sdateOcri + " >= (FESDAT- 60 days) and " + sdateOcri + " <= FESDAT";

    string selectConcatOcrit = "   Concat(DC4TMSP,  Concat('" + Constants.DEFAULT_SEP + "',"+ " Concat (Cast(DC4SDAT as varchar(30)),Concat ('" +  Constants.DEFAULT_SEP + "', Cast(DC4QDAT as varchar(30)) ))) )";    
    string sqlocrit =" select " + selectConcatOcrit + "DC4TMSP from " + getTablePrefix() + "ocrit as ot where ot.DC4ORD#= oi.DDORD# and ot.DC4ITM#= oi.DDITM# " +
                    " and DC4TMSP is not null and DC4SDAT is not null and DC4QDAT is not null " + //not null on each field on select                        
                    " and length(DC4TMSP) >= 8 and LOCATE('-',DC4TMSP) >=2 and LOCATE('-',DC4TMSP) > 4 " + //rules so we can check could be date, not null / len>=8 / 2 - chars
                    (bapplyRule60Days ? srule60Days : "" )+
                    " order by DC4TMSP desc"; //2020-06-30 show newest so added desc
    sqlocrit = "(" + DBFormatter.selectTopRows(sqlocrit,1) + ")";


    return sqlocrit;
}

private
string getSqlTradingPartner(){
    string sql = " left outer join " + getTablePrefix() + "TRLP as tp on tp.SMORD# = bd.FGORD# and tp.SMITM#=bd.FGITEM and tp.SMORD# = (select tp2.SMORD#  from  " + getTablePrefix() +"TRLP tp2 where tp2.SMORD#=bd.FGORD# and tp2.SMITM#=bd.FGITEM " +   
                " and tp.SMTRPT=tp2.SMTRPT and tp.SMSTXL=tp2.SMSTXL and tp.SMCPT#=tp2.SMCPT# and tp.SMYEAR=tp2.SMYEAR and tp.SMCKEY=tp2.SMCKEY";
    sql = DBFormatter.selectTopRows(sql, 1) + ")";
    return sql;
}

private
string getSqlTradingPartner2(){
    string sql = " select SMTRPT from cmsdat.trlp where SMCUST=bh.FEBCS# and SMLOCN=bh.FESCS# order by SMRDAT desc";
      sql = "(" + DBFormatter.selectTopRows(sql, 1) + ") as SMTRPT2";
    return sql;
}

private
string getSqlTradingPartner3(){
    string sql = " select SMTRPT from cmsdat.trlp where oh.DCOTYP='B' and SMCUST=bh.FEBCS# order by SMRDAT desc";
      sql = "(" + DBFormatter.selectTopRows(sql, 1) + ") as SMTRPT3";
    return sql;
}

private
string getSqlPpap(){
    string sql =" select CASE WHEN AOOPNM = 'PAP' THEN 'Y' ELSE 'N' END from " + getTablePrefix() + "Methdr " +
                " where AOPART=bd.FGPART and AOOPNM='PAP' and AOPLNT=bh.FEPLTC";                
    sql = "(" + DBFormatter.selectTopRows(sql, 1) + ") as Ppap";
    return sql;
}

private
string getSqlOtherBolForOrder(){
    string sql = "select bh2.FESDAT from " + getTablePrefix() + "BOLH as bh2 , " + getTablePrefix() + "BOLD as bd2 " +
                " where oh.DCOTYP='S' and bd.FGORD# > 0 and bd2.FGORD#=bd.FGORD# and bd2.FGITEM=bd.FGITEM " +
                " and bh2.FEBOL#=bd2.FGBOL# " +
                " and bh2.FEBOL#<>bh.FEBOL# " +
                " and (bh2.FESDAT <> bh.FESDAT or (bh2.FESDAT=bh2.FESDAT and bh2.FEBOL# < bh.FEBOL# )) " + //just in case first shipped having same FESDAT , so on that case we get minor Bol
                " order by bh2.FESDAT";                

    sql = "(" + DBFormatter.selectTopRows(sql, 1) + ") as FESTDATOtherOrder";
    return sql;
}       
   
/*
private
string getSqlOtherBolForOrderNew(){
    string sql = "select bd2.FGRLNO " +
                " from " + getTablePrefix() + "BOLH as bh2 , " + getTablePrefix() + "BOLD as bd2 " +
                " left outer join " + getTablePrefix() + "OCRR  as oc2 on bd2.FGORD# = oc2.DFORD# and bd2.FGITEM = oc2.DFITM# and bd2.FGRLNO=oc2.DFRLNO " +
                " where oh.DCOTYP='B' and bd.FGORD# > 0 and bd2.FGORD#=bd.FGORD# and bd2.FGITEM=bd.FGITEM " +
                " and bh2.FEBOL#=bd2.FGBOL# " +
                " and bh2.FEBOL#<>bh.FEBOL# " +

                " and bd.FGRLNO is not null and bd2.FGRLNO is not null and length(Trim(bd.FGRLNO)) > 2 " +
                " and bd2.FGRLNO = Concat(SubStr(bd.FGRLNO,1,length(Trim(bd.FGRLNO))-2),'00') " +

                " and ( (oc2.DFQTYR is not null and bd2.FGQSHP < (oc2.DFQTYR - oc2.DFQTBI)   ) or " +
                    "   (oc2.DFQTYR is null     and bd2.FGQSHP < " + sqlOCRRT() + "))"+


                " order by bh2.FESDAT";                

    sql = "(" + DBFormatter.selectTopRows(sql, 1) + ") as BOLOtherOrder";
    return sql;
} 
*/
private
string getSqlOtherBolForOrderNew(){
    string sql = "select bd2.FGRLNO " +
                " from " + getTablePrefix() + "BOLH as bh2 , " + getTablePrefix() + "BOLD as bd2 " +
                " where oh.DCOTYP='B' and bd.FGORD# > 0 and bd2.FGORD#=bd.FGORD# and bd2.FGITEM=bd.FGITEM " +
                " and bh2.FEBOL#=bd2.FGBOL# " +
                " and bh2.FEBOL#<>bh.FEBOL# " +

                " and bd.FGRLNO is not null and bd2.FGRLNO is not null and length(Trim(bd.FGRLNO)) > 2 " +
                " and bd2.FGRLNO = Concat(SubStr(bd.FGRLNO,1,length(Trim(bd.FGRLNO))-2),'00') " +                
                " order by bh2.FESDAT";                

    sql = "(" + DBFormatter.selectTopRows(sql, 1) + ") as BOLOtherOrder";
    return sql;
} 

private 
string sqlOCRRT(){
    string sdate        = "IFNULL(CAST(orr.DC5TMSP AS Date),FESDAT)";  
     string sqlOnRange   = " select DC5QTOO from " + getTablePrefix() +"OCRRT as orr where orr.DC5ORD#=bd2.FGORD# and orr.DC5ITM#=bd2.FGITEM and orr.DC5RLNO=bd2.FGRLNO " +
                           " and orr.DC5TMSP is not null and orr.DC5QTOO is not null and orr.DC5SDAT is not null and orr.DC5QDAT is not null " + //not null on each field on select
                           " and length(orr.DC5TMSP) >= 8 and LOCATE('-',orr.DC5TMSP) >=2 and LOCATE('-',orr.DC5TMSP) > 4 "; //rules so we can check could be date, not null / len>=8 / 2 - chars
    string sqlAny       = sqlOnRange;
    string sqlAnyNew    = sqlOnRange;
    string sqlOnRangeNew= sqlOnRange;
        
    sqlOnRangeNew+=    " and " + sdate +  " >= (FESDAT- 60 days) and " + sdate + " <= FESDAT order by orr.DC5TMSP";
    sqlOnRangeNew = "(" + DBFormatter.selectTopRows(sqlOnRangeNew, 1) + ")";

    return sqlOnRangeNew;
}

public
void readByFilters(string splant,string stpartner, string sbillTo, string shipTo, string sbol,string sorder, string spo,string scustPO,string shipped,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate, int irows){           
    string sqlocrit     = getSqlOcri(true) + "as OCRITValues";
    string sqlocritAny  = getSqlOcri(false)+ "as OCRITValuesAny";

    string sfilters = "";
    string selectField  = "SELXXFIELD";    
    string selectConcat =  "   Concat(DC5TMSP,  Concat('" + Constants.DEFAULT_SEP + "',"+ " Concat (Cast(DC5QTOO as varchar(30)),         Concat ('" + Constants.DEFAULT_SEP + "',     Concat (Cast(DC5SDAT as varchar(30)),     Concat ('" +  Constants.DEFAULT_SEP + "', Cast(DC5QDAT as varchar(30)))) ))) )";
    string sdate        = "IFNULL(CAST(orr.DC5TMSP AS Date),FESDAT)";                        

    string sqlOnRange   =  " select " + selectField + " from " + getTablePrefix() +"OCRRT as orr where orr.DC5ORD#=bd.FGORD# and orr.DC5ITM#=bd.FGITEM and orr.DC5RLNO=bd.FGRLNO " +
                           " and orr.DC5TMSP is not null and orr.DC5QTOO is not null and orr.DC5SDAT is not null and orr.DC5QDAT is not null " + //not null on each field on select
                           " and length(orr.DC5TMSP) >= 8 and LOCATE('-',orr.DC5TMSP) >=2 and LOCATE('-',orr.DC5TMSP) > 4 "; //rules so we can check could be date, not null / len>=8 / 2 - chars
    string sqlAny       = sqlOnRange;
    string sqlAnyNew    = sqlOnRange;
    string sqlOnRangeNew= sqlOnRange;
    string sqlDC5QTOO   =  sqlOnRange;
        
    sqlOnRangeNew+=    " and " + sdate +  " >= (FESDAT- 60 days) and " + sdate + " <= FESDAT order by orr.DC5TMSP";
    sqlOnRangeNew = "(" + DBFormatter.selectTopRows(sqlOnRangeNew, 1) + ") as OCRRTValues";
           
    //sqlDC5QTOO +=    " and " + sdate +  " >= (FESDAT- 60 days) and " + sdate + " <= CAST(REPLACE(Concat('20',substr(FEFUTR,1,8)), '/', '-')   AS Date)  order by orr.DC5TMSP desc";
    //FEFUTR --> 20/05/12101230      
    sqlDC5QTOO +=    " and " + sdate +  " >= (FESDAT- 60 days) and " +
                " (( FEFUTR is not null and length(FEFUTR) >= 8 and LOCATE('/', FEFUTR) >= 2 and LOCATE('/',FEFUTR) > 4 and " + sdate + " <= CAST(REPLACE(Concat('20',substr(FEFUTR,1,8)), '/', '-') AS Date) ) OR " + sdate + " <= FESDAT)"  + " order by orr.DC5TMSP desc";    
    sqlDC5QTOO = "(" + DBFormatter.selectTopRows(sqlDC5QTOO, 1) + ") as DC5QTOO";

    sqlAny+= " and " + sdate + " <= FESDAT order by orr.DC5TMSP";
    sqlAny = "(" + DBFormatter.selectTopRows(sqlAny, 1) + ") as " + selectField+"Any";

    sqlAnyNew+= " and " + sdate + " <= FESDAT order by orr.DC5TMSP";
    sqlAnyNew = "(" + DBFormatter.selectTopRows(sqlAnyNew, 1) + ") as OCRRTValuesAny";

    string sqlTradingPartner= getSqlTradingPartner();


    string sql = "select " +
" DFSDAT," +                                             // req date blanket
" DDSDAT," +                                             //req date standard order
" oh.DCQDAT," +                                          //req date order hdr
" (oi.DDQTOI - oi.DDQTSI + bd.FGQSHP) QtyOrder," +       // QtyOrder std
" (DDQTOI - DDQTSI) as DDQTBI," +                        //qty back order std
" DFQTBO,"+                                              //qty back order blanket 
" oc.DFQTYR," +
" oc.DFQTOO," +                                         //'ocrr Quantity            Orig. Ordered Ord.' , 
" (oc.DFQTYR - oc.DFQTBI) QtyOrderOcrr,"    +           //qty order from ocrr
" oh.DCODAT," +                                          //std create date
" bh.FEFUTR," +                                          //post date
" bh.FEBOL#, " +
" bd.FGBOL#, " +
" bh.FEBTYP, " +
" bh.FESIND, " +
" bh.FEBCS#, " +
" bh.FESCS#, " +
" bh.FESDAT, " +
" bh.FECDAT, " + //new
//" oi.UPEXSD, " +
" bh.FEPLTC, " +
" bd.FGENT#, " +
" bd.FGPART, " +
" bd.FGCPT#, " +
" bd.FGORD#, " +
" bd.FGITEM, " +
" bd.FGCREL, " +
" bd.FGQSHP, " +
" bd.FGRAN#, " +
" oi.DDQTBI, " +
//" oi.UPEXNQ, " +
" bd.FGCCUM, " +
" bd.FGPCUM, " +
" bd.FGCREL, " +
" bd.FGRLNO, " + //order rel num
" bd.FGCREL, " + //edi release
" bd.FGCPO#, " + //customer PO

" p.AVMAJG, " +
" p.AVMING, " +
" p.AVMAJS, " +
" p.AVMINS, " +
" p.AVGLCD, " +
" p.AVGLED, " +
" oh.DCOTYP, " +
" c.BVCLAS, " +
" c.BVSLT " +

//" t3.* " +

" , case  " +
"  when DCOTYP = 'S' THEN 'STANDARD' " +
"  when DCOTYP = 'B' and bd.FGCREL = '' THEN 'BLANKET' " +
"  when DCOTYP = 'B' and bd.FGCREL <> '' THEN 'BLANKETEDI' " +
" end as DCOTYPText, oi.DDQTOI," +
" tp.SMTRPT," +
" tp.SMSTXL," +
    sqlocrit + "," + sqlocritAny + "," +
    sqlOnRangeNew.Replace(selectField, selectConcat)+ "," +
    sqlAnyNew.Replace(selectField, selectConcat) + "," +
    getSqlPpap() + "," + getSqlOtherBolForOrder() + "," +
    getSqlOtherBolForOrderNew() + "," +
    getSqlTradingPartner2() + "," +
    getSqlTradingPartner3() + "," +
    sqlDC5QTOO.Replace(selectField, "DC5QTOO") +

" from " + getTablePrefix() + "BOLH as bh " +
" join " + getTablePrefix() + "BOLD as bd on bh.FEBOL# = bd.FGBOL# " +
//" left outer join " + getTablePrefix3()+ "UPCUM01P as t3 on bd.FGBOL#= T3.FGBOL# and bd.FGITEM = T3.FGITEM " +
" left outer join " + getTablePrefix() + "STKMM as p  on bd.FGPART = p.AVPART " +
" left outer join " + getTablePrefix() + "CUST  as c  on bh.FEBCS# = c.BVCUST " +
" left outer join " + getTablePrefix() + "OCRH  as oh on bd.FGORD# = oh.DCORD# " +
" left outer join " + getTablePrefix() + "OCRI  as oi on bd.FGORD# = oi.DDORD# and bd.FGITEM = oi.DDITM# " +
" left outer join " + getTablePrefix() + "OCRR  as oc on bd.FGORD# = oc.DFORD# and bd.FGITEM = oc.DFITM# and bd.FGRLNO=oc.DFRLNO "+
sqlTradingPartner + " ";

    if (!string.IsNullOrEmpty(splant)) 
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("bh.FEPLTC", splant);
    
    if (!string.IsNullOrEmpty(sbillTo)) 
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("bh.FEBCS#", sbillTo);

    if (!string.IsNullOrEmpty(shipTo)) 
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("bh.FESCS#", shipTo);

    if (!string.IsNullOrEmpty(sbol))        
        sfilters = DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("CAST(bh.FEBOL# AS varchar(15))", sbol);
            
    if (!string.IsNullOrEmpty(sorder))    
        sfilters = DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("CAST(bd.FGORD# AS varchar(15))", sorder);

    if (!string.IsNullOrEmpty(spo))
        sfilters = DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("CAST(bd.FGPO# AS varchar(15))",spo);        

    if (!string.IsNullOrEmpty(scustPO))
        sfilters = DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("FGCPO#", scustPO);        
               
    if (!string.IsNullOrEmpty(shipped))
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + "bh.FESIND='" + shipped + "'";

    if (!string.IsNullOrEmpty(stpartner))
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("BVTRDP", stpartner);  

    if (!string.IsNullOrEmpty(srelease))
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.equalLikeSql("bd.FGRLNO", srelease);  

    if (orderItem > 0)
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + "bd.FGITEM =" + NumberUtil.toString(orderItem);

    if (blateOrders) {
        //OCRI.DDSDAT  / OCRR.DFSDAT
        sfilters= DBFormatter.addWhereAndSentence(sfilters) +
                "((oh.DCOTYP='B' and bh.FESDAT > oc.DFSDAT) or (oh.DCOTYP<>'B' and bh.FESDAT > oi.DDSDAT))";        
    }

    if (!string.IsNullOrEmpty(sppap)){
        sfilters= DBFormatter.addWhereAndSentence(sfilters);
        string smethdr = "select AOPART from " + getTablePrefix() + "Methdr where AOPART = bd.FGPART and AOOPNM = 'PAP' and AOPLNT=bh.FEPLTC";
        sfilters+= sppap.Equals(Constants.STRING_YES) ? " exists " : " not exists ";
        sfilters+= " ( " + smethdr + " ) ";
    }

    sfilters= DBFormatter.addWhereAndSentence(sfilters) + "bh.FEBTYP='C' ";
    //sfilters+=  " and bd.FGENT# = 1 ";

    if (!string.IsNullOrEmpty(sdocType)) 
        sfilters= DBFormatter.addWhereAndSentence(sfilters) + "oh.DCOTYP='" + sdocType + "'";
            
    if (fromDate!= DateUtil.MinValue || toDate!= DateUtil.MinValue)
        sfilters = DBFormatter.addWhereAndSentence(sfilters) + DBFormatter.getSqlRangeDates("bh.FESDAT",fromDate,toDate,false);    

    sql += " " + sfilters;    
    sql+=" order by FEBOL# desc,bd.FGENT#";//,FGENT#";
   
    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,irows);

    read(sql);
}


} // class
} // package