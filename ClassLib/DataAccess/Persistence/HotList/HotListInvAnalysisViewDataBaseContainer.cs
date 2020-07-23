using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class HotListInvAnalysisViewDataBaseContainer : HotListDataBaseContainer{

public
HotListInvAnalysisViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		HotListInvAnalysisViewDataBase hotListInvAnalysisViewDataBase = new HotListInvAnalysisViewDataBase(dataBaseAccess);
		hotListInvAnalysisViewDataBase.load(reader);
		this.Add(hotListInvAnalysisViewDataBase);
	}
}

private
string addProdFmInfoOuterJoin(){
    return " left outer join prodfminfo p on p.PFS_ProdID = HOT_ProdID "; 
}

private
string addProdFmactSubOuterJoin(){
    return " left outer join prodfmactsub on PC_ProdID = HOT_ProdID and PC_Plt = HOT_Plt and PC_Dept = HOT_Dept and PC_Seq = HOT_Seq and PC_Cfg = HOT_Mach "; 
}        

private
string addSchMaterialAvailOuterJoin(){
    DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,0,0,0);
    DateTime toDate    = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23,59,59);

    return " left outer join SchMaterialAvail sch on sch.ParentSrcHotDtlId=h.HOT_IdAut and sch.CounterParentSrcHotId=1 and ( " + DBFormatter.getSqlRangeDates("sch.dateTime",fromDate,toDate,true)+ ")"; 
}

private
string getSqlLevel(){
    string sql = "(select count(*)+1 from prodfmactplan where PAPL_ProdID=HOT_ProdID and PAPL_Seq > h.HOT_Seq) as Level2";
    return sql;
}

public
void readByFilters(int id,string splant, string sdept, string smachine, int imachineId, string spart,int iseq,string smajorGroup,string sglExp,string srepPoint,string sprodFamily,string sfieldDay,bool borderByDemand,string sqlOrderByQty, int rows){
    string sql = "select PC_OptRunQty,PC_ProdLev,PFS_PartType,PFS_Level,PFS_VirtKanManDem,PFS_Des1,h.*,sch.parentQtyAdjust MatQty from hotlist h" + 
                addProdFmInfoOuterJoin() + addSchMaterialAvailOuterJoin() + addProdFmactSubOuterJoin(); 

    sql+= readBaseByFilters(id,splant,sdept,smachine,imachineId,spart,iseq,smajorGroup,sglExp,srepPoint,"",sfieldDay);

    if (!string.IsNullOrEmpty(sprodFamily)) //we already have left outer join with prodfminfo so check for family
        sql = DBFormatter.addWhereAndSentence(sql)+ DBFormatter.equalLikeSql("PFS_FamProd", sprodFamily);
    
    sql += " order by ";
    if (borderByDemand)
        sql+= orderByDemand();
    else
        sql+= "HOT_Dept,HOT_Mach" + (string.IsNullOrEmpty(sqlOrderByQty) ? "":",") + sqlOrderByQty;

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

public
void readByFiltersWeekly(int id,string splant, string sdept, string smachine, int imachineId, string spart,int iseq,string smajorGroup,string sglExp,string sreportedPoint,string sfieldDay,bool borderByDemand,ArrayList sfieldList,int rows){
  	NotNullDataReader reader = null;
	try{
        string sql = "select PC_OptRunQty,PFS_PartType,PFS_Level,PC_ProdLev,PFS_VirtKanManDem,PFS_Des1,HOT_IdAut,HOT_Id,HOT_ProdID,HOT_ActID,HOT_Seq,HOT_Uom,HOT_Dept,HOT_Mach,HOT_MachCyc,HOT_Qoh,HOT_QohCml,HOT_MinorGroup,HOT_MajorGroup,HOT_Finalized,HOT_Type,HOT_MainMaterial,HOT_MainMaterialSeq,HOT_MainMaterialQoh,HOT_Plt";
        string sqlQty = ",HOT_PastDue";
        string sqlFieldList = "";

        for (int i=0; i < sfieldList.Count;i++)
            sqlFieldList+= "," + (string)sfieldList[i];

        sql+= sqlQty + sqlFieldList + ", sch.parentQtyAdjust MatQty from hotlist h ";
        sql+= addProdFmInfoOuterJoin() + addSchMaterialAvailOuterJoin() + addProdFmactSubOuterJoin();

        sql+= readBaseByFilters(id,splant,sdept,smachine,imachineId,spart,iseq,smajorGroup,sglExp,sreportedPoint,"", sfieldDay);
        
        sql += " order by ";
        if (borderByDemand)
            sql+= orderByDemand();
        else
            sql+= "HOT_Dept,HOT_Mach" + sqlFieldList;

	    if (rows > 0)
		    sql = DBFormatter.selectTopRows(sql,rows);
	    

	    reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
            HotListInvAnalysisViewDataBase hotListDataBase = new HotListInvAnalysisViewDataBase(dataBaseAccess);
            hotListDataBase.setHOT_IdAut(reader.GetInt32("HOT_IdAut"));
            hotListDataBase.setHOT_Id(reader.GetInt32("HOT_Id"));
	        hotListDataBase.setHOT_ProdID(reader.GetString("HOT_ProdID"));
	        hotListDataBase.setHOT_ActID(reader.GetString("HOT_ActID"));
	        hotListDataBase.setHOT_Seq(reader.GetInt32("HOT_Seq"));
	        hotListDataBase.setHOT_Uom(reader.GetString("HOT_Uom"));
	        hotListDataBase.setHOT_Dept(reader.GetString("HOT_Dept"));
	        hotListDataBase.setHOT_Mach(reader.GetString("HOT_Mach"));
	        hotListDataBase.setHOT_MachCyc(reader.GetDecimal("HOT_MachCyc"));
	        hotListDataBase.setHOT_Qoh(reader.GetDecimal("HOT_Qoh"));
	        hotListDataBase.setHOT_QohCml(reader.GetDecimal("HOT_QohCml"));
	        hotListDataBase.setHOT_PastDue(reader.GetDecimal("HOT_PastDue"));
	    

	        hotListDataBase.setHOT_MajorGroup(reader.GetString("HOT_MajorGroup"));
	        hotListDataBase.setHOT_MinorGroup(reader.GetString("HOT_MinorGroup"));
	        hotListDataBase.setHOT_Finalized(reader.GetString("HOT_Finalized"));
	        hotListDataBase.setHOT_Type(reader.GetString("HOT_Type"));

	        hotListDataBase.setHOT_MainMaterial(reader.GetString("HOT_MainMaterial"));
	        hotListDataBase.setHOT_MainMaterialSeq(reader.GetInt32("HOT_MainMaterialSeq"));
	        hotListDataBase.setHOT_MainMaterialQoh(reader.GetDecimal("HOT_MainMaterialQoh"));
            hotListDataBase.setHOT_Plt(reader.GetString("HOT_Plt"));

            hotListDataBase.setPFS_VirtKanManDem(reader.GetDecimal("PFS_VirtKanManDem"));
            hotListDataBase.setPFS_PartType(reader.GetString("PFS_PartType"));                    
            hotListDataBase.setPFS_Level(reader.GetDecimal("PFS_Level"));
            hotListDataBase.setPFS_Level(Convert.ToInt32(reader.GetInt32("PC_ProdLev")));                    
            hotListDataBase.setMatQty(reader.GetDecimal("MatQty"));
            hotListDataBase.setPC_OptRunQty(reader.GetDecimal("PC_OptRunQty"));


            decimal dpriorQty=0;
            for (int i=0; i < sfieldList.Count; i++) { 
                string sfieldName =  (string)sfieldList[i];
                switch (sfieldName){
                    case "HOT_Day001" : hotListDataBase.setHOT_Day001(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day002" : hotListDataBase.setHOT_Day002(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day003" : hotListDataBase.setHOT_Day003(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day004" : hotListDataBase.setHOT_Day004(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day005" : hotListDataBase.setHOT_Day005(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day006" : hotListDataBase.setHOT_Day006(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day007" : hotListDataBase.setHOT_Day007(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day008" : hotListDataBase.setHOT_Day008(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day009" : hotListDataBase.setHOT_Day009(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day010" : hotListDataBase.setHOT_Day010(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day011" : hotListDataBase.setHOT_Day011(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day012" : hotListDataBase.setHOT_Day012(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day013" : hotListDataBase.setHOT_Day013(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day014" : hotListDataBase.setHOT_Day014(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day015" : hotListDataBase.setHOT_Day015(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day016" : hotListDataBase.setHOT_Day016(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day017" : hotListDataBase.setHOT_Day017(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day018" : hotListDataBase.setHOT_Day018(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day019" : hotListDataBase.setHOT_Day019(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day020" : hotListDataBase.setHOT_Day020(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day021" : hotListDataBase.setHOT_Day021(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day022" : hotListDataBase.setHOT_Day022(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day023" : hotListDataBase.setHOT_Day023(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day024" : hotListDataBase.setHOT_Day024(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day025" : hotListDataBase.setHOT_Day025(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day026" : hotListDataBase.setHOT_Day026(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day027" : hotListDataBase.setHOT_Day027(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day028" : hotListDataBase.setHOT_Day028(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day029" : hotListDataBase.setHOT_Day029(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day030" : hotListDataBase.setHOT_Day030(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day031" : hotListDataBase.setHOT_Day031(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day032" : hotListDataBase.setHOT_Day032(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day033" : hotListDataBase.setHOT_Day033(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day034" : hotListDataBase.setHOT_Day034(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day035" : hotListDataBase.setHOT_Day035(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day036" : hotListDataBase.setHOT_Day036(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day037" : hotListDataBase.setHOT_Day037(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day038" : hotListDataBase.setHOT_Day038(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day039" : hotListDataBase.setHOT_Day039(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day040" : hotListDataBase.setHOT_Day040(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day041" : hotListDataBase.setHOT_Day041(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day042" : hotListDataBase.setHOT_Day042(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day043" : hotListDataBase.setHOT_Day043(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day044" : hotListDataBase.setHOT_Day044(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day045" : hotListDataBase.setHOT_Day045(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day046" : hotListDataBase.setHOT_Day046(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day047" : hotListDataBase.setHOT_Day047(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day048" : hotListDataBase.setHOT_Day048(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day049" : hotListDataBase.setHOT_Day049(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day050" : hotListDataBase.setHOT_Day050(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day051" : hotListDataBase.setHOT_Day051(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day052" : hotListDataBase.setHOT_Day052(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day053" : hotListDataBase.setHOT_Day053(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day054" : hotListDataBase.setHOT_Day054(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day055" : hotListDataBase.setHOT_Day055(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day056" : hotListDataBase.setHOT_Day056(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day057" : hotListDataBase.setHOT_Day057(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day058" : hotListDataBase.setHOT_Day058(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day059" : hotListDataBase.setHOT_Day059(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day060" : hotListDataBase.setHOT_Day060(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day061" : hotListDataBase.setHOT_Day061(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day062" : hotListDataBase.setHOT_Day062(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day063" : hotListDataBase.setHOT_Day063(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day064" : hotListDataBase.setHOT_Day064(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day065" : hotListDataBase.setHOT_Day065(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day066" : hotListDataBase.setHOT_Day066(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day067" : hotListDataBase.setHOT_Day067(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day068" : hotListDataBase.setHOT_Day068(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day069" : hotListDataBase.setHOT_Day069(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day070" : hotListDataBase.setHOT_Day070(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day071" : hotListDataBase.setHOT_Day071(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day072" : hotListDataBase.setHOT_Day072(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day073" : hotListDataBase.setHOT_Day073(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day074" : hotListDataBase.setHOT_Day074(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day075" : hotListDataBase.setHOT_Day075(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day076" : hotListDataBase.setHOT_Day076(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day077" : hotListDataBase.setHOT_Day077(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day078" : hotListDataBase.setHOT_Day078(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day079" : hotListDataBase.setHOT_Day079(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day080" : hotListDataBase.setHOT_Day080(reader.GetDecimal(sfieldName));break;

                    case "HOT_Day081" : hotListDataBase.setHOT_Day081(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day082" : hotListDataBase.setHOT_Day082(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day083" : hotListDataBase.setHOT_Day083(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day084" : hotListDataBase.setHOT_Day084(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day085" : hotListDataBase.setHOT_Day085(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day086" : hotListDataBase.setHOT_Day086(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day087" : hotListDataBase.setHOT_Day087(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day088" : hotListDataBase.setHOT_Day088(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day089" : hotListDataBase.setHOT_Day089(reader.GetDecimal(sfieldName));break;
                    case "HOT_Day090" : hotListDataBase.setHOT_Day090(reader.GetDecimal(sfieldName));break;                                        
                }                               
            }


		    this.Add(hotListDataBase);
		}

		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersWeekly> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersWeekly> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFiltersWeekly> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


} // class

} // namespace