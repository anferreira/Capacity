/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class MainMatDataBaseContainer : GenericDataBaseContainer {

public
MainMatDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){	
    string sql = "select * from " + getTablePrefix3() + "mainmat";    
    read(sql);            
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from " + getTablePrefix3() + "mainmat";
	if (searchText.Length > 0){
		sql += " where PART like '" + Converter.fixString(searchText) + "%'";
		sql += " or MAINPART like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){    
	while(reader.Read()){
		MainMatDataBase mainMatDataBase = new MainMatDataBase(dataBaseAccess);
		mainMatDataBase.load(reader);
		this.Add(mainMatDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table mainmat";
	truncate(sql);
}

public 
void readByHeader(string spart){	
    string sql ="select * from " + getTablePrefix3() + "mainmat where PART='" + Converter.fixString(spart) + "'"+
                " order by DTL";
    read(sql);            
}

public 
void deleteByHeader(string spart){	
    string sql = "delete from " + getTablePrefix3() + "mainmat where PART='" + Converter.fixString(spart) + "'";        
    delete(sql);            
}


public
string[][] getReport1268(){
    NotNullDataReader reader = null;
	try{
        ArrayList array = new ArrayList();
            string sql = "select HOT_ProdID as 'Part Number' " +
            " ,( " +
            " SELECT CONCAT( " +

            "  (select ifnull(MAx(MainPart),'') from mainmat where part=HOT_ProdID and DTL=1) " +


            " ,(select CASE WHEN length(ifnull(MAx(MainPart),'')) > 0 THEN '\n' ELSE '' END " +
            " from mainmat where part=HOT_ProdID and DTL=2) " +
            " ,(select ifnull(MAx(MainPart),'') from mainmat where part=HOT_ProdID and DTL=2) " +

            " ,(select CASE WHEN length(ifnull(MAx(MainPart),'')) > 0 THEN '\n' ELSE '' END " +
            " from mainmat where part=HOT_ProdID and DTL=3) " +
            " ,(select ifnull(MAx(MainPart),'') from mainmat where part=HOT_ProdID and DTL=3) " +

            " ,(select CASE WHEN length(ifnull(MAx(MainPart),'')) > 0 THEN '\n' ELSE '' END " +
            " from mainmat where part=HOT_ProdID and DTL=4) " +
            " ,(select ifnull(MAx(MainPart),'') from mainmat where part=HOT_ProdID and DTL=4) " +


            " ))  " +
            " AS 'Main Material'  " +

            " ,( " +
            " SELECT CONCAT( " +

            " (select  " +
            " CASE WHEN EXISTS(select m2.Dtl from mainmat m2 where m2.part=HOT_ProdID and m2.Dtl=1) " +
              " THEN FORMAT(COALESCE(SUM(i.IPL_Qoh) /  " +

            " (select " +
            " ( " +
            " case when b2.BMS_PrQty IS NULL then ifnull(min(b.BMS_PrQty),1)  " +
            " ELSE  " +
            " ifnull(min(b2.BMS_PrQty),1)  " +
            " END " +
            " )  " +
            " as tot " +
            " from  " +
            " BomSum b  " +
            " left outer join BomSum b2 on b2.BMS_ProdID=b.BMS_ProdID " +

            " and b2.BMS_MatID=(select m2.MAINPART from mainmat m2 where m2.part=b.BMS_ProdID and m2.Dtl=1) " +
            "  where b.BMS_ProdID=HOT_ProdID  " +
            " order by b2.BMS_ProdID desc limit 1 " +
            " ) " +
            " ,0),0)  " +
            " ELSE '' " +
               " END  " +

              " from mainmat m  " +
            " left outer join prodfminfo p on p.PFS_ProdID=m.MainPart " +

            " left outer join invpltloc i on i.IPL_ProdID=m.MainPart and i.IPL_Seq=p.PFS_SeqLast " +
            " where m.part=HOT_ProdID and m.Dtl=1 " +
            " ) " +
            " ,(select CASE WHEN length(ifnull(MAx(MainPart),'')) > 0 THEN '\n' ELSE '' END " +
            " from mainmat where part=HOT_ProdID and DTL=2) " +
            " ,(select  " +
            " CASE WHEN EXISTS(select m2.Dtl from mainmat m2 where m2.part=HOT_ProdID and m2.Dtl=2) " +
              " THEN FORMAT(COALESCE(SUM(i.IPL_Qoh),0) /  " +
            " (select " +
            " ( " +
            " case when b2.BMS_PrQty IS NULL then ifnull(min(b.BMS_PrQty),1)  " +
            " ELSE  " +
            " ifnull(min(b2.BMS_PrQty),1)  " +
            " END " +
            " )  " +
            "  as tot from BomSum b left outer join BomSum b2 on b2.BMS_ProdID=b.BMS_ProdID " +
            "  and b2.BMS_MatID=(select m2.MAINPART from mainmat m2 where m2.part=b.BMS_ProdID and m2.Dtl=2) " +
            "  where b.BMS_ProdID=HOT_ProdID  " +
            "  order by b2.BMS_ProdID desc limit 1 " +
            "  ),0) " +
              "  ELSE '' " +
               "  END " +
              " from mainmat m  " +


            " left outer join prodfminfo p on p.PFS_ProdID=m.MainPart " +
            " left outer join invpltloc i on i.IPL_ProdID=m.MainPart and i.IPL_Seq=p.PFS_SeqLast " +
            " where m.part=HOT_ProdID and m.Dtl=2) " +
            " ,(select CASE WHEN length(ifnull(MAx(MainPart),'')) > 0 THEN '\n' ELSE '' END " +
            " from mainmat where part=HOT_ProdID and DTL=3) " +
            " ,(select  " +
            " CASE WHEN EXISTS(select m2.Dtl from mainmat m2 where m2.part=HOT_ProdID and m2.Dtl=3) " +
              " THEN FORMAT(COALESCE(SUM(i.IPL_Qoh) /  " +

            " (select " +
            " (case when b2.BMS_PrQty IS NULL then ifnull(min(b.BMS_PrQty),1)  " +
            " ELSE ifnull(min(b2.BMS_PrQty),1) END ) as tot  " +
            " from BomSum b left outer join BomSum b2 on b2.BMS_ProdID=b.BMS_ProdID " +
            " and b2.BMS_MatID=(select m2.MAINPART from mainmat m2 where m2.part=b.BMS_ProdID and m2.Dtl=3) " +
            " where b.BMS_ProdID=HOT_ProdID order by b2.BMS_ProdID desc limit 1 " +
            " ),0),0) " +
              " ELSE '' " +
               " END  " +
              " from mainmat m left outer join prodfminfo p on p.PFS_ProdID=m.MainPart   " +
            " left outer join invpltloc i on i.IPL_ProdID=m.MainPart and i.IPL_Seq=p.PFS_SeqLast " +
              " where m.part=HOT_ProdID and m.Dtl=3) " +
            " ,(select CASE WHEN length(ifnull(MAx(MainPart),'')) > 0 THEN '\n' ELSE '' END " +
            " from mainmat where part=HOT_ProdID and DTL=4) " +
            " ,(select  " +
            " CASE WHEN EXISTS(select m2.Dtl from mainmat m2 where m2.part=HOT_ProdID and m2.Dtl=4) " +
              " THEN FORMAT(COALESCE(SUM(i.IPL_Qoh) /  " +
            " (select  " +
            " ( " +
            " case when b2.BMS_PrQty IS NULL then ifnull(min(b.BMS_PrQty),1)  " +
            " ELSE ifnull(min(b2.BMS_PrQty),1) END) as tot  " +
            " from BomSum b left outer join BomSum b2 on b2.BMS_ProdID=b.BMS_ProdID " +
            " and b2.BMS_MatID=(select m2.MAINPART from mainmat m2 where m2.part=b.BMS_ProdID and m2.Dtl=4) " +
             " where b.BMS_ProdID=HOT_ProdID order by b2.BMS_ProdID desc limit 1 " +
            " ),0),0)  " +
            " ELSE '' END  " +
            " from mainmat m left outer join prodfminfo p on p.PFS_ProdID=m.MainPart   " +
            " left outer join invpltloc i on i.IPL_ProdID=m.MainPart and i.IPL_Seq=p.PFS_SeqLast " +
              " where m.part=HOT_ProdID and m.Dtl=4) " +
            " ))  " +
            " AS 'MT-Part' " +

            " ,(select  FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >0 and PC_Seq < 10) ) as 'RT-Part'  " +


            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 10 and PC_Seq < 20) ) as 'Part-10'  " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 20 and PC_Seq < 30) ) as 'Part-20'  " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 30 and PC_Seq < 40) ) as 'Part-30'  " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and   " +
            " (PC_Seq >= 40 and PC_Seq < 50) ) as 'Part-40' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 50 and PC_Seq < 60) ) as 'Part-50' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 60 and PC_Seq < 70) ) as 'Part-60' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 70 and PC_Seq < 80) ) as 'Part-70' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 80 and PC_Seq < 90) ) as 'Part-80' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 90 and PC_Seq < 100) ) as 'Part-90' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 100 and PC_Seq < 110) ) as 'Part-100' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 110 and PC_Seq < 120) ) as 'Part-110' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 120 and PC_Seq < 130) ) as 'Part-120' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 130 and PC_Seq < 140) ) as 'Part-130' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 140 and PC_Seq < 150) ) as 'Part-140' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 150 and PC_Seq < 160) ) as 'Part-150' " +

            " ,(select FORMAT(COALESCE(SUM(IPL_Qoh),0),0) " +
            " from prodfmactsub as s , invpltloc i  " +
            " where  PC_ProdID= HOT_ProdID and PC_RepPoint='Y'  " +
            " and IPL_ProdID = PC_ProdID and IPL_Seq=PC_Seq and IPL_FinishedGoods='N' and  " +
            " (PC_Seq >= 160) ) as 'Part-160' " +

            " ,(select COALESCE(SUM(HTQTY-HTQTYC),0) " +
            " from seri where HTPART=HOT_ProdID and HTSTS = 'H' " +
            " ) as QtyHold " +

            " , (select COALESCE(SUM(i.IPL_Qoh),0) from invpltloc i " +
                    " where IPL_ProdID=HOT_ProdID and IPL_FinishedGoods='Y') as 'F/G'	 " +
            " ,(	 " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID " +
            " and d.DEDT_DtShip < SUBDATE(CURDATE(), WEEKDAY(CURDATE())) " +
            " ) as 'PAST' " +
            " ,(	 " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and ( d.DEDT_DtShip >= SUBDATE(CURDATE(), WEEKDAY(CURDATE())) " +
             " and d.DEDT_DtShip <=  " +
            " DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 6 DAY)) " +
            " ) as WEEK1 " +
            " ,( " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and  (  " +
            " d.DEDT_DtShip >= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*1   DAY) " +
            " and " +
            " d.DEDT_DtShip <= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*2-1 DAY)) " +
            " ) as WEEK2 " +
            " ,(	 " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and (  " +
            " d.DEDT_DtShip >= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*2   DAY) " +
            " and " +
            " d.DEDT_DtShip <= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*3-1 DAY)) " +
            " ) as WEEK3 " +
            " ,( " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and (  " +
            " d.DEDT_DtShip >= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*3   DAY) " +
            " and " +
            " d.DEDT_DtShip <= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*4-1 DAY)) " +
            " ) as WEEK4 " +
            " ,( " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and (  " +
            " d.DEDT_DtShip >= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*4   DAY) " +
            " and " +

            " d.DEDT_DtShip <= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*5-1 DAY)) " +
            " ) as WEEK5 " +
            " ,( " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and (  " +
            " d.DEDT_DtShip >= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*5   DAY) " +
            " and " +
            " d.DEDT_DtShip <= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*6-1 DAY)) " +
            " ) as WEEK6 " +
            " ,( " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and (  " +
            " d.DEDT_DtShip >= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*6   DAY) " +
            " and " +
            " d.DEDT_DtShip <= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*7-1 DAY)) " +
            " ) as WEEK7 " +
            " ,( " +
            " select FORMAT(COALESCE(sum(DEDT_QtyID),0),0) " +
            " from demdetail as d  " +
            " where DEDT_ProdID=HOT_ProdID  " +
            " and (  " +
            " d.DEDT_DtShip >= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*7   DAY) " +
            " and " +
            " d.DEDT_DtShip <= DATE_ADD(SUBDATE(CURDATE(),WEEKDAY(CURDATE())), INTERVAL 7*8-1 DAY)) " +
            " ) as WEEK8 " +

            " from (select distinct(PFS_ProdId) as HOT_ProdID  " +
                " from prodfminfo  " +
                " ) as query  " +
            " order by HOT_ProdID ";

                reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			                    
			string[] line = new string[40];
			line[0] = reader.GetString("Part Number");
			line[1] = reader.GetString("Main Material");
            line[2] = reader.GetString("MT-Part");
            line[3] = reader.GetString("RT-Part");

            int ind=4;
            for (int j=10; j <=160;j=j+10){
                line[ind] = reader.GetString("Part-" + j.ToString());
                ind++;
            }
            line[ind] = Convert.ToString(reader.GetDecimal("QtyHold"));
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("F/G"));
            ind++;
            line[ind] = Convert.ToString(reader.GetDecimal("F/G") - reader.GetDecimal("QtyHold"));
            ind++;

            //customer demand                        
            for (int j=1; j <=8;j++){
                line[ind] = reader.GetString("WEEK" + j.ToString());
                ind++;
            }                  
            array.Add((object)line);           
		}
        
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] line = (string[])en.Current;
			returnArray[index] = line;
			index++;
		}
		return returnArray;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByFilters(string spart,string smainPart,int rows){    
    string sql ="select * from " + getTablePrefix3() + "mainmat";            

    if (!string.IsNullOrEmpty(spart)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("PART",spart +"%");
    }

    if (!string.IsNullOrEmpty(smainPart)){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql += DBFormatter.equalLikeSql("MAINPART",smainPart + "%");        
    }
    
    sql += " order by PART,DTL";            
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    //System.Windows.Forms.MessageBox.Show("readByFilters:"+sql);
    read(sql);
}





} // class
} // package