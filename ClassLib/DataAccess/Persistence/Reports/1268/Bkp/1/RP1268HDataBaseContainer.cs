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
    ArrayList alist = new ArrayList();

	try{
            string sql = 
" select HOT_ProdID as PartNumber "+
" ,  " +
" Concat(Concat(Concat(Concat(Concat( " +
" Concat((select ifnull(MAx(MainPart), '') from funnel.mainmat where part = HOT_ProdID and DTL = 1) " +
" , (select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from mainmat where part = HOT_ProdID and DTL = 2)) " +
" , (select ifnull(MAx(MainPart), '') from mainmat where part = HOT_ProdID and DTL = 2)) " +
" , (select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from mainmat where part = HOT_ProdID and DTL = 3)) " +
" ,(select ifnull(MAx(MainPart), '') from mainmat where part = HOT_ProdID and DTL = 3)) " +
" ,(select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from mainmat where part = HOT_ProdID and DTL = 4)) " +
" ,(select ifnull(MAx(MainPart), '') from mainmat where part = HOT_ProdID and DTL = 4)) " +
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
" , (select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from mainmat where part = HOT_ProdID and DTL = 2)) " +
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
" ,(select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from mainmat where part = HOT_ProdID and DTL = 3)) " +
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
" ,(select CASE WHEN length(ifnull(MAx(MainPart), '')) > 0 THEN '\n' ELSE '' END from mainmat where part = HOT_ProdID and DTL = 4)) " +
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
" , (select ifnull(SUM(w.VDQTOH), 0) from cmsdat.wipb w , cmsdat.methdr m  where w.VDPART = HOT_ProdID  and m.AOPART = VDPART and  w.VDSEQ#=m.AOSEQ# and m.AOREPP='Y' and ( w.VDSEQ# >=160) ) as Part160 " +

" , (select COALESCE(SUM(HTQTY - HTQTYC), 0) from cmsdat.seri where HTPART = HOT_ProdID and HTSTS = 'H' ) as QtyHold " +
" ,(select sum(BXQTOH)  from cmsdat.stkb where BxPART = HOT_ProdID) as FG " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and s.JYDATE < ((current date) +(7 - dayofweek(current date) + (-1 * 7 + 2)) days)  " +
 " ) as PAST " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (-1 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (0 * 7 + 1)) days)) " +
 " ) as WEEK1 " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (0 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (1 * 7 + 1)) days)) " +
 " ) as WEEK2 " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (1 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (2 * 7 + 1)) days)) " +
 " ) as WEEK3 " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (2 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (3 * 7 + 1)) days)) " +
 " ) as WEEK4 " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (3 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (4 * 7 + 1)) days)) " +
 " ) as WEEK5 " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (5 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (4 * 7 + 1)) days)) " +
 " ) as WEEK6 " +


" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (4 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (5 * 7 + 1)) days)) " +
 " ) as WEEK6 " +

" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (5 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (6 * 7 + 1)) days)) " +
 " ) as WEEK7 " +


" ,(select COALESCE(SUM(s.JYSQTY), 0) from cmsdat.ssch as s where s.JYPART = HOT_ProdID " +
  " and(s.JYDATE >= ((current date) + (7 - dayofweek(current date) + (6 * 7 + 2)) days)  and s.JYDATE <= ((current date) +(7 - dayofweek(current date) + (7 * 7 + 1)) days)) " +
 " ) as WEEK8 " +


" from(select distinct(AVPART) as HOT_ProdID " +

    " from cmsdat.stkmm where AVPART like '%FAU%' " +    //= 'TEN2724' " +

    " ) as query " +
" order by HOT_ProdID ";

                    System.Windows.Forms.MessageBox.Show("Before Sql");

        reader = dataBaseAccess.executeQuery(sql);

        System.Windows.Forms.MessageBox.Show("After Sql");

        while (reader.Read()){            
            string[] line = new string[40];
			line[0] = reader.GetString("PartNumber");
			line[1] = reader.GetString("MainMaterial");
            line[2] = reader.GetString("MTPart");
            line[3] = Convert.ToString(reader.GetDecimal("RTPart"));

            int ind=4;
            for (int j=10; j <=160;j=j+10){
                line[ind] = Convert.ToString(reader.GetDecimal("Part" + j.ToString()));
                ind++;
            }
            line[ind] = Convert.ToString(reader.GetDecimal("QtyHold"));
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("FG"));
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("FG") - reader.GetDecimal("QtyHold"));
            ind++;

            //customer demand                        
            line[ind] = Convert.ToString(reader.GetDecimal("PAST"));
            ind++;
            for (int j=1; j <=8;j++){
                line[ind] = Convert.ToString(reader.GetDecimal("WEEK" + j.ToString()));
                ind++;
            }
            alist.Add((object)line);                    
        }
         
        System.Windows.Forms.MessageBox.Show("getReport1268 Count Records:" + alist.Count.ToString());               

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
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

} // class
} // package