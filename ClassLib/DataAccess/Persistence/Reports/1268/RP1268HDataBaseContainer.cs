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
using Nujit.NujitERP.ClassLib.ErpException;
using MySql.Data.MySqlClient;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Reports{

public
class RP1268HDataBaseContainer : GenericDataBaseContainer {

public
RP1268HDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from " + getTablePrefix3() + "rp1268h";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from " + getTablePrefix3() + "rp1268h";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);
		rP1268HDataBase.load(reader);
		this.Add(rP1268HDataBase);
	}
}

public
void truncate(){
	try{
		string sql = "delete from rp1268h";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}
}

public
ArrayList getReport1268(){
    NotNullDataReader reader = null;
    ArrayList   alist = new ArrayList();
    string      startGroupCode      = Configuration.StartMajorGroup;
    string      sendGroupCode       = Configuration.EndMajorGroup;
    string      swipStartGroupCode  = Configuration.WipStartMajorGroup;
    string      swipEndGroupCode    = Configuration.WipEndMajorGroup;
    bool        bonlyWithDemand     = Configuration.Report1268ShowOnlyWithDemand;
    bool        bwhereAdded=false;    
    decimal     daux=0;
            
    string      sqlCustomerDemand = ",(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
    "   and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (XXX1 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (XXX2 * 7 + 1)) days)) " +
    " ) as WEEKXXX ";

    string      sqlCustomerDemand2 =",(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
    "   and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (XXX1 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (XXX2 * 7 + 1)) days)) " +
    " )  + " +
    " (select COALESCE(SUM(total), 0) from( " +
    " select(s.JYSQTY * m2.AQQPPC) as total, m2.AQMTLP as MaterialPart from cmsdat.ssch as s , cmsdat.metHdm as m2 "+
    " where s.JYPART = m2.AQPART and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (XXX1 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (XXX2 * 7 + 1)) days)) " +
    " )  as query where HOT_ProdID = MaterialPart ) as WEEKXXX ";

    string      saux = "";

	try{
            string sql = 
" select HOT_ProdID as PartNumber "+
" ,  " +
" Concat(Concat(Concat(Concat(Concat( " +
" Concat((select ifnull(MAx(MainPart), '') from funnel.mainmat where part = HOT_ProdID and DTL = 1) " +
" , (select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from funnel.mainmat where part = HOT_ProdID and DTL = 2)) " +
" , (select ifnull(MAx(MainPart), '') from funnel.mainmat where part = HOT_ProdID and DTL = 2)) " +
" , (select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from funnel.mainmat where part = HOT_ProdID and DTL = 3)) " +
" ,(select ifnull(MAx(MainPart), '') from funnel.mainmat where part = HOT_ProdID and DTL = 3)) " +
" ,(select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from funnel.mainmat where part = HOT_ProdID and DTL = 4)) " +
" ,(select ifnull(MAx(MainPart), '') from funnel.mainmat where part = HOT_ProdID and DTL = 4)) " +
" AS MainMaterial " +

" ,( " +
" Concat(Concat(Concat(Concat(Concat(Concat( " +
" (select         CASE WHEN 1 = (select m2.Dtl from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 1) " +
                " THEN varchar( " +
                             " ifnull(SUM(s.bxqtoh), 0) / " +
                            " ( " +
                                " select(case when mh2.AQQPPC IS NULL then ifnull(mh.AQQPPC, 1) ELSE ifnull(mh2.AQQPPC, 1) END) as Tot " +
                                " from cmsdat.methdm mh " +
                                " left outer join cmsdat.methdm mh2 on  mh2.AQPART = HOT_ProdID and mh2.AQPART = mh.AQPART and mh2.AQMTLP = (select m2.MAINPART from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 1) " +
                                " where mh.AQPART = HOT_ProdID " +
                               " limit 1 " +
                            " ) " +
               " ) " +
              " ELSE ''   END " +
             " from cmsdat.stkb s where BxPART in (select mainpart from funnel.mainmat where part = HOT_ProdID and dtl = 1) " +
" ) " +
" , (select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from funnel.mainmat where part = HOT_ProdID and DTL = 2)) " +
" , (select         CASE WHEN 2 = (select m2.Dtl from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 2) " +
                " THEN varchar( " +
                             " ifnull(SUM(s.bxqtoh), 0) / " +
                            " ( " +
                                " select(case when mh2.AQQPPC IS NULL then ifnull(mh.AQQPPC, 1) ELSE ifnull(mh2.AQQPPC, 1) END) as Tot " +
                                " from cmsdat.methdm mh " +
                                " left outer join cmsdat.methdm mh2 on  mh2.AQPART = HOT_ProdID and mh2.AQPART = mh.AQPART and mh2.AQMTLP = (select m2.MAINPART from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 2)  " +
                                " where mh.AQPART = HOT_ProdID " +
                               " limit 1 " +
                            " ) " +
               " )  " +
              " ELSE ''   END " +
             " from cmsdat.stkb s where BxPART in (select mainpart from funnel.mainmat where part = HOT_ProdID and dtl = 2)) " +
" ) " +
" ,(select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from funnel.mainmat where part = HOT_ProdID and DTL = 3)) " +
" ,(select         CASE WHEN 3 = (select m2.Dtl from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 3)    " +
                " THEN varchar( " +
                             " ifnull(SUM(s.bxqtoh), 0) / " +
                            " ( " +
                                " select(case when mh2.AQQPPC IS NULL then ifnull(mh.AQQPPC, 1) ELSE ifnull(mh2.AQQPPC, 1) END) as Tot " +
                                " from cmsdat.methdm mh " +
                                " left outer join cmsdat.methdm mh2 on  mh2.AQPART = HOT_ProdID and mh2.AQPART = mh.AQPART and mh2.AQMTLP = (select m2.MAINPART from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 3)  " +
                                " where mh.AQPART = HOT_ProdID " +
                               " limit 1 " +
                            " )  " +
               " )  " +
              " ELSE ''   END " +
             " from cmsdat.stkb s where BxPART in (select mainpart from funnel.mainmat where part = HOT_ProdID and dtl = 3)) " +
" ) " +
" ,(select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from funnel.mainmat where part = HOT_ProdID and DTL = 4)) " +
" ,(select         CASE WHEN 4 = (select m2.Dtl from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 4)    " +
                " THEN varchar( " +
                             " ifnull(SUM(s.bxqtoh), 0) / " +
                            " ( " +
                                " select(case when mh2.AQQPPC IS NULL then ifnull(mh.AQQPPC, 1) ELSE ifnull(mh2.AQQPPC, 1) END) as Tot " +
                                " from cmsdat.methdm mh " +
                                " left outer join cmsdat.methdm mh2 on  mh2.AQPART = HOT_ProdID and mh2.AQPART = mh.AQPART and mh2.AQMTLP = (select m2.MAINPART from funnel.mainmat m2 where m2.part = HOT_ProdID  and m2.Dtl = 4)  " +
                                " where mh.AQPART = HOT_ProdID " +
                               " limit 1 " +
                            " )  " +
               " )  " +
              " ELSE ''   END " +
             " from cmsdat.stkb s where BxPART in (select mainpart from funnel.mainmat where part = HOT_ProdID and dtl = 4)) " +
" ) " +
" )AS MTPart " +

/*
",select ifnull(SUM(RTPART), 0) as RTPART  from( select ifnull(SUM(w.VDQTOH), 0) as RTPART  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >0    and w.VDSEQ# < 10 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as RTPART  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >0    and HTSEQ < 10 ) ) as q " +
",select ifnull(SUM(Part10), 0) as Part10  from( select ifnull(SUM(w.VDQTOH), 0) as Part10  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=10  and w.VDSEQ# < 20 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part10  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=10  and HTSEQ < 20 ) ) as q " +
",select ifnull(SUM(Part20), 0) as Part20  from( select ifnull(SUM(w.VDQTOH), 0) as Part20  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=20  and w.VDSEQ# < 30 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part20  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=20  and HTSEQ < 30 ) ) as q " +
",select ifnull(SUM(Part30), 0) as Part30  from( select ifnull(SUM(w.VDQTOH), 0) as Part30  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=30  and w.VDSEQ# < 40 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part30  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=30  and HTSEQ < 40 ) ) as q " +
",select ifnull(SUM(Part40), 0) as Part40  from( select ifnull(SUM(w.VDQTOH), 0) as Part40  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=40  and w.VDSEQ# < 50 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part40  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=40  and HTSEQ < 50 ) ) as q " +
",select ifnull(SUM(Part50), 0) as Part50  from( select ifnull(SUM(w.VDQTOH), 0) as Part50  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=50  and w.VDSEQ# < 60 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part50  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=50  and HTSEQ < 60 ) ) as q " +
",select ifnull(SUM(Part60), 0) as Part60  from( select ifnull(SUM(w.VDQTOH), 0) as Part60  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=60  and w.VDSEQ# < 70 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part60  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=60  and HTSEQ < 70 ) ) as q " +
",select ifnull(SUM(Part70), 0) as Part70  from( select ifnull(SUM(w.VDQTOH), 0) as Part70  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=70  and w.VDSEQ# < 80 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part70  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=70  and HTSEQ < 80 ) ) as q " +
",select ifnull(SUM(Part80), 0) as Part80  from( select ifnull(SUM(w.VDQTOH), 0) as Part80  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=80  and w.VDSEQ# < 90 )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part80  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=80  and HTSEQ < 90 ) ) as q " +
",select ifnull(SUM(Part90), 0) as Part90  from( select ifnull(SUM(w.VDQTOH), 0) as Part90  from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=90  and w.VDSEQ# < 100)  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part90  from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=90  and HTSEQ < 100) ) as q " +
",select ifnull(SUM(Part100),0) as Part100 from( select ifnull(SUM(w.VDQTOH), 0) as Part100 from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=100 and w.VDSEQ# < 110)  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part100 from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=100 and HTSEQ < 110) ) as q " +
",select ifnull(SUM(Part110),0) as Part110 from( select ifnull(SUM(w.VDQTOH), 0) as Part110 from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=110 and w.VDSEQ# < 120)  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part110 from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=110 and HTSEQ < 120) ) as q " +
",select ifnull(SUM(Part120),0) as Part120 from( select ifnull(SUM(w.VDQTOH), 0) as Part120 from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=120 and w.VDSEQ# < 130)  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part120 from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=120 and HTSEQ < 130) ) as q " +
",select ifnull(SUM(Part130),0) as Part130 from( select ifnull(SUM(w.VDQTOH), 0) as Part130 from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=130 and w.VDSEQ# < 140)  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part130 from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=130 and HTSEQ < 140) ) as q " +
",select ifnull(SUM(Part140),0) as Part140 from( select ifnull(SUM(w.VDQTOH), 0) as Part140 from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=140 and w.VDSEQ# < 150)  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part140 from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=140 and HTSEQ < 150) ) as q " +
",select ifnull(SUM(Part150),0) as Part150 from( select ifnull(SUM(w.VDQTOH), 0) as Part150 from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=150 and w.VDSEQ# < 160)  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part150 from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=150 and HTSEQ < 160) ) as q " +
",select ifnull(SUM(Part160),0) as Part160 from( select ifnull(SUM(w.VDQTOH), 0) as Part160 from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=160                   )  union  select COALESCE(SUM(HTQTY - HTQTYC), 0)*-1 as Part160 from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ=m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=160                ) ) as q " +
*/
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >0 and w.VDSEQ# < 10) ) as RTPart " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=10 and w.VDSEQ# < 20) ) as Part10 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=20 and w.VDSEQ# < 30) ) as Part20 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=30 and w.VDSEQ# < 40) ) as Part30 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=40 and w.VDSEQ# < 50) ) as Part40 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=50 and w.VDSEQ# < 60) ) as Part50 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=60 and w.VDSEQ# < 70) ) as Part60 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=70 and w.VDSEQ# < 80) ) as Part70 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=80 and w.VDSEQ# < 90) ) as Part80 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=90 and w.VDSEQ# < 100) ) as Part90 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=100 and w.VDSEQ# < 110) ) as Part100 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=110 and w.VDSEQ# < 120) ) as Part110 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=120 and w.VDSEQ# < 130) ) as Part120 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=130 and w.VDSEQ# < 140) ) as Part130 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=140 and w.VDSEQ# < 150) ) as Part140 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=150 and w.VDSEQ# < 160) ) as Part150 " +
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=160 and w.VDSEQ# <=499) ) as Part160 " +

" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >0    and HTSEQ < 10 ) ) as RTPartSeri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=10  and HTSEQ < 20 ) ) as Part10Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=20  and HTSEQ < 30 ) ) as Part20Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=30  and HTSEQ < 40 ) ) as Part30Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=40  and HTSEQ < 50 ) ) as Part40Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=50  and HTSEQ < 60 ) ) as Part50Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=60  and HTSEQ < 70 ) ) as Part60Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=70  and HTSEQ < 80 ) ) as Part70Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=80  and HTSEQ < 90 ) ) as Part80Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=90  and HTSEQ < 100) ) as Part90Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=100 and HTSEQ < 110) ) as Part100Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=110 and HTSEQ < 120) ) as Part110Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=120 and HTSEQ < 130) ) as Part120Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=130 and HTSEQ < 140) ) as Part130Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=140 and HTSEQ < 150) ) as Part140Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=150 and HTSEQ < 160) ) as Part150Seri " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri , cmsdat.methdr m where HTPART = HOT_ProdID and HTSTS = 'H' and m.AOPART = HTPART and HTSEQ = m.AOSEQ# and m.AOREPP='Y' and (HTSEQ >=160 and HTSEQ <=499) ) as Part160Seri " +



" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri where HTPART = HOT_ProdID and HTSTS = 'H' ) as QtyHold " +
" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri where HTPART = HOT_ProdID and HTSTS = 'H' and HTSEQ=0) as QtyHoldSeqZero " +
" ,(select sum(BXQTOH)  from cmsdat.stkb where BxPART = HOT_ProdID) as FG " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
"   and s.JYDATE < ((current date) +(7 - dayofweek(current date) + (-1 * 7 + 2)) days)  " +
 " ) + " +
" ( " +
" select COALESCE(SUM(total),0)  from ( " +
" select (s.JYSQTY *  m2.AQQPPC)  as total, m2.AQMTLP as MaterialPart from cmsdat.ssch as s , cmsdat.metHdm as m2 " +
" where s.JYPART =  m2.AQPART " +
" and s.JYDATE < ((current date) +(7 - dayofweek(current date) + (-1 * 7 + 2)) days) " +
" )  as query where HOT_ProdID=MaterialPart " +
" ) as PAST";
    
    //ad customer demand sql for Weeks        
    for (int i=0;i < 14; i++){        
        saux = sqlCustomerDemand2;
        saux = saux.Replace("XXX1", (i - 1).ToString());
        saux = saux.Replace("XXX2", i.ToString());
        saux = saux.Replace("WEEKXXX", "WEEK"+ (i+1).ToString());
        sql+= saux;
    }
    sql += " ,st2.AVMING,st2.AVMAJG,st2.AVENGC "; //min/maj group and EngineeringChange#
    sql += " ,(select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w where w.VDPART=HOT_ProdID and w.VDSEQ#=500) as QTYG12 " +
           " ,(select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri where HTPART = HOT_ProdID and HTSTS = 'H' and HTSEQ=500) as QTYG12Seri ";

    sql +=
    " from(select distinct(AVPART) as HOT_ProdID " +

    " from cmsdat.stkmm "; //where AVMAJG='' and AVPART in (select part from funnel.mainmat)" +    //= 'TEN2724' " +

    bwhereAdded=false;
    if (!string.IsNullOrEmpty(startGroupCode) || !string.IsNullOrEmpty(sendGroupCode)){  
        bwhereAdded=true;
        sql+= " where (";
        if (!string.IsNullOrEmpty(startGroupCode))
            sql+= " AVMAJG >= '" + startGroupCode + "'";

        if (!string.IsNullOrEmpty(sendGroupCode)){
            if (!string.IsNullOrEmpty(startGroupCode))
                sql += " and ";
            sql += " AVMAJG <= '" + sendGroupCode + "'";
        }
        sql+= " )";
    }
    if (bonlyWithDemand){
        sql += bwhereAdded ? " and " : " where ";        
        sql += " AVPART in (select JYPART from cmsdat.ssch) ";
    }

sql+=" union " +
    " select distinct(st.V6PART) as HOT_ProdID from cmsdat.STKa as st where st.V6SELP = 'Y' ";
    if (bonlyWithDemand)
         sql+=" and st.V6PART in (select JYPART from cmsdat.ssch)";

sql+=" union " +
     " select distinct(AQMTLP) as HOT_ProdID from cmsdat.metHdm as m , cmsdat.STKmm smm "+
     " where smm.AVPART=AQMTLP ";  

    if (!string.IsNullOrEmpty(swipStartGroupCode) || !string.IsNullOrEmpty(swipEndGroupCode)){      
        sql+= " and (";
        if (!string.IsNullOrEmpty(swipStartGroupCode))
            sql+= " AVMAJG >= '" + swipStartGroupCode + "'";

        if (!string.IsNullOrEmpty(swipEndGroupCode)){
            if (!string.IsNullOrEmpty(swipStartGroupCode))
                sql += " and ";
            sql += " AVMAJG <= '" + swipEndGroupCode + "'";
        }
        sql+= " ) ";
    }
    //if (bonlyWithDemand)
        //sql += " and AQPART in (select JYPART from cmsdat.ssch)";

sql +=" ) as query left outer join cmsdat.stkmm st2 on st2.AVPART=HOT_ProdID ";   
                 
//sql+= " where HOT_ProdID ='ENA81010'  "; //used for test for specific part

sql+=" order by HOT_ProdID ";

        sql = sql.Replace("cmsdat.", getTablePrefix());
        sql = sql.Replace("funnel.", getTablePrefix3());
        //System.Windows.Forms.MessageBox.Show("Before Sql:"+sql);

        reader = dataBaseAccess.executeQuery(sql);

        //System.Windows.Forms.MessageBox.Show("After Sql");

        while (reader.Read()){            
            string[] line = new string[50];
			line[0] = reader.GetString("PartNumber");
			line[1] = reader.GetString("MainMaterial");
            line[2] = reader.GetString("MTPart");
            line[3] = Convert.ToString(reader.GetDecimal("RTPart") - reader.GetDecimal("RTPartSeri"));

            int ind=4;
            for (int j=10; j <=160;j=j+10){
                line[ind] = Convert.ToString(reader.GetDecimal("Part" + j.ToString()) - reader.GetDecimal("Part" + j.ToString()+"Seri"));
                ind++;
            }             

            line[ind] = Convert.ToString(reader.GetDecimal("QtyHold"));
            ind++;
            daux = reader.GetDecimal("FG") - reader.GetDecimal("QtyHoldSeqZero");
            line[ind] = Convert.ToString(daux);//FG
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("FG") - reader.GetDecimal("QtyHold"));
            ind++;

            //customer demand                        
            line[ind] = Convert.ToString(reader.GetDecimal("PAST"));
            ind++;
            for (int j=1; j <=14;j++){
                line[ind] = Convert.ToString(reader.GetDecimal("WEEK" + j.ToString()));
                ind++;
            }

            line[ind] = reader.GetString("AVMING");
            ind++;
            line[ind] = reader.GetString("AVMAJG");
            ind++;
            line[ind] = reader.GetString("AVENGC");  
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("QTYG12") - reader.GetDecimal("QTYG12Seri") );
                        
            alist.Add((object)line);            
        }
         
        //System.Windows.Forms.MessageBox.Show("getReport1268 Count Records:" + alist.Count.ToString());               

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getReport1268> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getReport1268> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getReport1268>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getReport1268> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
    return alist;
}

public
int readMAxId(){
    NotNullDataReader reader = null;
    try{
                            
        string sql = "select MAX(Id) from " + getTablePrefix3() + "rp1268h";            
		reader = dataBaseAccess.executeQuery(sql);
	    if (reader.Read())
            return (int)reader.GetDecimal(0);
	    
	    return 0;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readMAxId> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <readMAxId> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<readMAxId>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<readMAxId> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}
       

public
ArrayList getStoredReport1268(int iheaderID){
    NotNullDataReader   reader = null;
    ArrayList           alist = new ArrayList();
    
	try{
        string sql =
" select Part as PartNumber " +

" ,Concat(Concat(Concat(Concat(Concat( " +
" Concat((select ifnull(MAx(MainMat),'') from funnel.RP1268S as s where s.HDRID= d.HDRID and s.Detail= d.Detail  and s.SubDtl= 1) " +

 " ,(select CASE WHEN length(ifnull(MAx(MainMat),'')) > 0 THEN '\n' ELSE '' END from funnel.RP1268S as s where s.HDRID=d.HDRID and s.Detail=d.Detail and s.SubDtl=2)) " +

" ,(select ifnull(MAx(MainMat),'') from funnel.RP1268S as s where s.HDRID= d.HDRID and s.Detail= d.Detail  and s.SubDtl= 2)) " +
" ,(select CASE WHEN length(ifnull(MAx(MainMat),'')) > 0 THEN '\n' ELSE '' END from funnel.RP1268S as s where s.HDRID=d.HDRID and s.Detail=d.Detail and s.SubDtl=3)) " +
" ,(select ifnull(MAx(MainMat),'') from funnel.RP1268S as s where s.HDRID= d.HDRID and s.Detail= d.Detail  and s.SubDtl= 3)) " +
" ,(select CASE WHEN length(ifnull(MAx(MainMat),'')) > 0 THEN '\n' ELSE '' END from funnel.RP1268S as s where s.HDRID=d.HDRID and s.Detail=d.Detail and s.SubDtl=4)) " +
" ,(select ifnull(MAx(MainMat),'') from funnel.RP1268S as s where s.HDRID= d.HDRID and s.Detail= d.Detail  and s.SubDtl= 4)) " +
" AS MainMaterial " +

" ,(Concat(Concat(Concat(Concat(Concat(Concat( " +
" (select         CASE WHEN SUM(s.Qty) is not null THEN varchar(ifnull(SUM(s.Qty), 0)) ELSE ''   END " +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 1) " +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '\n' ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2)) " +
" , (select         CASE WHEN SUM(s.Qty) is not null THEN varchar(ifnull(SUM(s.Qty), 0)) ELSE ''   END " +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2)) " +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '\n' ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3)) " +
" , (select         CASE WHEN SUM(s.Qty) is not null THEN varchar(ifnull(SUM(s.Qty), 0)) ELSE ''   END " +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3)) " +
" ,(select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '\n' ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4)) " +
" ,(select         CASE WHEN SUM(s.Qty) is not null THEN varchar(ifnull(SUM(s.Qty), 0)) ELSE ''   END " +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4)) " +
" )as MTPart " +

" , RTPart, Part10, Part20, Part30, Part40, Part50, Part60,Part70,Part80,Part90,Part100,Part110,Part120,Part130,Part140,Part150,Part160 " +
" ,QtyHold,FinGood,NetQoh " +
" ,AVMAJG,AVMING,ENGCHANGE,QTYG12 " +
",CDPAST,CDWEEK1,CDWEEK2,CDWEEK3,CDWEEK4,CDWEEK5,CDWEEK6,CDWEEK7,CDWEEK8,CDWEEK9,CDWEEK10,CDWEEK11,CDWEEK12,CDWEEK13,CDWEEK14 " +


//new main material received qty/dates
" ,(Concat(Concat(Concat(Concat(Concat(Concat(" +
" (select         CASE WHEN SUM(s.wK1RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK1RECQTY), 0)  AS bigint))  ELSE ''   END" +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 1)" +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))" +
" , (select         CASE WHEN SUM(s.wK1RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK1RECQTY), 0)  AS bigint))  ELSE ''   END" +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))" +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))" +
" , (select         CASE WHEN SUM(s.wK1RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK1RECQTY), 0)  AS bigint))  ELSE ''   END" +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))" +
" ,(select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  " +
" ,(select         CASE WHEN SUM(s.wK1RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK1RECQTY), 0)  AS bigint))  ELSE ''   END" +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  " +
" )as FirstWeek" +

" ,(Concat(Concat(Concat(Concat(Concat(Concat(" +
" (select         CASE WHEN SUM(s.wK2RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK2RECQTY), 0)  AS bigint))  ELSE ''   END" +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 1)" +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select         CASE WHEN SUM(s.wK2RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK2RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))"  +
" , (select         CASE WHEN SUM(s.wK2RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK2RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))  "  +
" ,(select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" ,(select         CASE WHEN SUM(s.wK2RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK2RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" )as SecondWeek"  +


" ,(Concat(Concat(Concat(Concat(Concat(Concat("  +
" (select         CASE WHEN SUM(s.wK3RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK3RECQTY), 0)  AS bigint))  ELSE ''   END" +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 1)"  +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select         CASE WHEN SUM(s.wK3RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK3RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))"  +
" , (select         CASE WHEN SUM(s.wK3RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK3RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))  "  +
" ,(select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" ,(select         CASE WHEN SUM(s.wK3RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK3RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" )as ThirdWeek"  +


" ,(Concat(Concat(Concat(Concat(Concat(Concat("  +
" (select         CASE WHEN SUM(s.wK4RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK4RECQTY), 0)  AS bigint))  ELSE ''   END"  +
             " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 1)"  +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select         CASE WHEN SUM(s.wK4RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK4RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))"  +
" , (select         CASE WHEN SUM(s.wK4RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK4RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))  "  +
" ,(select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" ,(select         CASE WHEN SUM(s.wK4RECQTY) is not null THEN varchar(CAST(ifnull(SUM(s.wK4RECQTY), 0)  AS bigint))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" )as FourthWeek"  +


" ,(Concat(Concat(Concat(Concat(Concat(Concat("  +
" (select   CASE WHEN MAx(s.WK1RECDAT) is not null and MAx(s.WK1RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK1RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
          " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 1)"  +

" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select         CASE WHEN MAx(s.WK1RECDAT) is not null and MAx(s.WK1RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK1RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +

" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))"  +
" , (select         CASE WHEN MAx(s.WK1RECDAT) is not null and MAx(s.WK1RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK1RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))  "  +


" ,(select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" ,(select         CASE WHEN MAx(s.WK1RECDAT) is not null and MAx(s.WK1RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK1RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" )as DateFirstRec"  +


" ,(Concat(Concat(Concat(Concat(Concat(Concat("  +
" (select   CASE WHEN MAx(s.WK2RECDAT) is not null and MAx(s.WK2RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK2RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
          " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 1)"  +

" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +
" , (select         CASE WHEN MAx(s.WK2RECDAT) is not null and MAx(s.WK2RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK2RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 2))"  +

" , (select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))"  +
" , (select         CASE WHEN MAx(s.WK2RECDAT) is not null and MAx(s.WK2RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK2RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 3))  "  +


" ,(select CASE WHEN length(ifnull(MAx(MainMat), '')) > 0 THEN '' || chr(10) ELSE '' END from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" ,(select         CASE WHEN MAx(s.WK2RECDAT) is not null and MAx(s.WK2RECDAT) <> '1901-01-01' THEN varchar(CAST(MAx(s.WK2RECDAT) AS VARCHAR(10)))  ELSE ''   END"  +
              " from funnel.RP1268S as s where s.HDRID = d.HDRID and s.Detail = d.Detail  and s.SubDtl = 4))  "  +
" )as  DateSecondRec"  +




" from RP1268H h, RP1268D d " +
" where h.ID ";

        if (iheaderID > 0)
            sql+= " = " + iheaderID.ToString();
        else
            sql += " in (select max(id) from funnel.RP1268H where Status='A')  and d.HDRID=h.ID ";
        sql += " order by part ";        

        sql = sql.Replace("funnel.", getTablePrefix3());
        reader = dataBaseAccess.executeQuery(sql);        

        while (reader.Read()){            
            string[] line = new string[50];
			line[0] = reader.GetString("PartNumber");
			line[1] = reader.GetString("MainMaterial");
            line[2] = reader.GetString("MTPart");                    
            line[3] = reader.GetString("AVMAJG");                    
            line[4] = reader.GetString("AVMING");
            line[5] = Convert.ToString(reader.GetDecimal("RTPart"));

            int ind=6;
            for (int j=10; j <=160;j=j+10){
                line[ind] = Convert.ToString(reader.GetDecimal("Part" + j.ToString()));
                ind++;
            }
                    
            line[ind] = reader.GetString("ENGCHANGE");
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("QtyHold"));
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("QTYG12"));
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("FinGood"));
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("FinGood") - reader.GetDecimal("QtyHold"));
            
            //customer demand                        
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("CDPAST"));
            ind++;
            for (int j=1; j <=14;j++){
                line[ind] = Convert.ToString(reader.GetDecimal("CDWEEK" + j.ToString()));
                ind++;
            }

            //received qty and dates
            line[ind] = reader.GetString("FirstWeek");
            ind++;
            line[ind] = reader.GetString("DateFirstRec").Replace("-","");            
            ind++;
            line[ind] = reader.GetString("SecondWeek");
            ind++;
            line[ind] = reader.GetString("DateSecondRec").Replace("-", "");
            ind++;
            line[ind] = reader.GetString("ThirdWeek");
            ind++;
            line[ind] = reader.GetString("FourthWeek");
                                             
            alist.Add((object)line);                    
        }
                 
    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getStoredReport1268> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getStoredReport1268> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getStoredReport1268>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getStoredReport1268> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
    return alist;
}

public
void deleteExceptId(int id){
	string sql ="delete from " + getTablePrefix3() + "rp1268h " +
                " where Id <> " + NumberUtil.toString(id);
	delete(sql);
}


private
string getReceivedQty(){

    string sql = "select SELXX from( " +
//Standard PO
" select " +
" 'ST' Type , pi.KBPO# PoNum,  ( pi.kbqtyo - pi.kbqtyr ) as NetQty , pi.KBQTYR QtyReceived, KAODAT as HDate,  pi.KBRDAT DDate,pi.KBPT# Part " +
" from cmsdat.POH as ph , cmsdat.POI as pi " +
" where ph.KAOTYP = 'S' and ph.KAPO# = pi.KBPO# " + //AND ph.KAOSTS not in ('C','H') and pi.KBISTS <> 'C'
" union " +
//Blanket
" select " +
" 'BL' Type ,pori.KGPO# PoNum,  ( pori.kgqtyo - pori.kgqtyr ) as NetQty , pori.kgqtyr  QtyReceived, KAODAT as HDate,  pori.KGRDAT DDate,pori.KGPT# Part " +
" from cmsdat.POH as ph , cmsdat.pori as pori " +
" where ph.KAPO# = pori.KGPO# and ph.KAOTYP  = 'B' " + //AND ph.KAOSTS not in ('C','H' ) and pori.KGISTS  <> 'C'
" union " +
" select " +
" 'CB' Type ,prh.KLPO# PoNum,  ( prd.KMQTYR ) as NetQty , prd.KMQTYR QtyReceived, prh.KLSDAT as HDate, prd.KMSDAT DDate ,prh.KLPT# Part " +
" from cmsdat.POPRH prh, cmsdat.POPRD prd " +
" where prh.KLPO# = prd.KMPO# and prh.KLITM#=prd.KMITM# and prh.KLCREL= prd.KMRELN and prh.KLCRCM = '1' and prd.KMQTYR<> 0 " +
" ) as query " +
" where Part= PARTXX " +
" and (DDate >= ((current date) + (7 - dayofweek(current date) + (XXX1 * 7 + 2)) days)  and DDate <= ((current date) +(7 - dayofweek(current date) + (XXX2 * 7 + 1)) days)) ";

    sql = sql.Replace("cmsdat.", getTablePrefix());
    return sql;
}

public
DateTime getDatesFirstReceipts(string spart,int iweek){
    NotNullDataReader reader = null;
    try{                        
        string sql = getReceivedQty();

        sql = sql.Replace("PARTXX", "'" + Converter.fixString(spart) + "'");
        sql = sql.Replace("SELXX", "Min(DDate)");

        sql = sql.Replace("XXX1", (iweek - 1).ToString());
        sql = sql.Replace("XXX2", iweek.ToString());
        sql = sql.Replace("WEEKXXX", "WEEK"+ (iweek + 1).ToString());

        //System.Windows.Forms.MessageBox.Show(sql);
        try{         
		    reader = dataBaseAccess.executeQuery(sql);
        }catch(Exception ex){
		   System.Windows.Forms.MessageBox.Show(ex.Message);
	    }

	    if (reader.Read()){
                    //DateTime rD = reader.GetDateTime(0);
                    //if (rD.Year > 2000)
                    //System.Windows.Forms.MessageBox.Show("Part:"+ spart + "Date:" + DateUtil.getDateRepresentation(reader.GetDateTime(0)));
            return reader.GetDateTime(0);
        }
	            
	    return DateUtil.MinValue;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getReceivedQtyFromPartWeek> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getReceivedQtyFromPartWeek> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getReceivedQtyFromPartWeek>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getReceivedQtyFromPartWeek> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}

public
decimal getReceivedQtyFromPartWeek(string spart,int iweek){
    NotNullDataReader reader = null;
    try{                
        string sql = getReceivedQty();

        sql = sql.Replace("PARTXX", "'" + Converter.fixString(spart) + "'");
        sql = sql.Replace("SELXX", "ifnull(SUM(QtyReceived), 0)");

        sql = sql.Replace("XXX1", (iweek - 1).ToString());
        sql = sql.Replace("XXX2", iweek.ToString());
        sql = sql.Replace("WEEKXXX", "WEEK"+ (iweek + 1).ToString());

        //System.Windows.Forms.MessageBox.Show(sql);
        try{     
    
		reader = dataBaseAccess.executeQuery(sql);
        }catch(Exception ex){
		   System.Windows.Forms.MessageBox.Show(ex.Message);
	    }

	    if (reader.Read())
            return reader.GetDecimal(0);
	    
	    return 0;

    }catch(System.Data.SqlClient.SqlException se){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDatesFirstReceipts> : " + se.Message, se);
    }catch(System.Data.DataException de){
	    throw new PersistenceException("Error in class " + this.GetType().Name + " <getDatesFirstReceipts> : " + de.Message, de);
    }
    #if !POCKET_PC	
    catch(MySqlException mySqlExc){
	    throw new PersistenceException("Error in class " + this.GetType().Name + "<getDatesFirstReceipts>  : " + mySqlExc.Message, mySqlExc);
    }
    #endif
	catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<getDatesFirstReceipts> : " + ex.Message, ex);
	}
	finally{
		if (reader != null)
			reader.Close();
	}
}
} // class
} // package