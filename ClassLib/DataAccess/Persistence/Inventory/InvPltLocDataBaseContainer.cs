using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class InvPltLocDataBaseContainer : GenericDataBaseContainer{

private int IPL_Seq;
private string IPL_ProdID;
//private string IPL_StkLoc;


public
InvPltLocDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
		invPltLocDataBase.load(reader);
		this.Add(invPltLocDataBase);
	}
}

public
void read(){
	string sql = "select * from invpltloc";
    read(sql);
}

public
void readAllBySeq(){
	string sql = "select * from invpltloc where IPL_Seq = " +
	IPL_Seq.ToString() + " order by IPL_ProdID";
    
    read(sql);		
}

public
void readByProdId(string splant){
	string sql = "select * from invpltloc where " + 
		"IPL_ProdID = '" + Converter.fixString(IPL_ProdID) + "' and IPL_Plant='" + Converter.fixString(splant) + "'";
    read(sql);
}

public
void readForReport(){
	NotNullDataReader reader = null;
	try{
		string  sql= "select IPL_ProdID," +
						"IPL_Seq," +
						"IPL_StkLoc," +
						"IPL_ActID," +
						"IPL_LotID," +
						"IPL_MasPrOrd," +
						"IPL_PrOrd," +
						"IPL_Qoh," +
						"IPL_QohAvail," +
						"IPL_Uom," +
						"IPL_Qoh2," +
						"IPL_QohAvail2," +
						"IPL_Uom2," +
						"IPL_Prod2," + 
						"PFS_Des1 " +
					"from invpltloc, prodfminfo " +
						 "where IPL_ProdID = '" +Converter.fixString(IPL_ProdID) +"' and "+
						       "IPL_ProdID = PFS_ProdID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.loadForReport(reader);
			this.Add(invPltLocDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForReport> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readForHotList(string splant){
	NotNullDataReader reader = null;
	try{
        string  sqlPlant = " and IPL_Plant='" + splant + "' ";

        string  sql = "select distinct PAH_ProdID AS HOTC_ProdID," +
			"PAH_ActID AS HOTC_ActID, " +
			"PAH_Seq AS HOTC_Seq, " +
	        
			"(select sum(det1.IPL_Qoh) "+
			"from invpltloc det1 " +
			"where det1.IPL_Seq = prodFm.PAH_Seq AND det1.IPL_ProdID = prodFm.PAH_ProdID " + sqlPlant +  ") " +
			"AS HOTC_Qoh, " +
	        
			"(select sum(det1.IPL_Qoh) "+
			"from invpltloc det1 " +
			"where det1.IPL_Seq >= prodFm.PAH_Seq AND det1.IPL_ProdID = prodFm.PAH_ProdID " + sqlPlant + ") " +
			"AS HOTC_QohCml, " +
			"'" + Constants.DEFAULT_UOM + "' AS HOTC_Uom " +
			"from prodfmacth prodFm LEFT OUTER JOIN " + 
			"invpltloc det2 ON " +
				"prodFm.PAH_ProdID = det2.IPL_ProdID and " +
				"prodFm.PAH_Seq = det2.IPL_Seq " + sqlPlant + 
                "order by prodFm.PAH_ProdID, prodFm.PAH_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.loadForHotList(reader);
			this.Add(invPltLocDataBase, invPltLocDataBase.getIPL_ProdID());
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForHotList> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForHotList> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForHotList> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){	
    string sql = "delete from invpltloc";
    truncate(sql);		
}

public
void setIPL_Seq(int IPL_Seq){
	this.IPL_Seq = IPL_Seq;
}

public
int getIPL_Seq(){
	return IPL_Seq;
}

public
void setIPLProdID(string IPL_ProdID){
	this.IPL_ProdID = IPL_ProdID;
}

public
string getIPL_ProdID(){
	return IPL_ProdID;
}

public
decimal getSumQtyByPartSeq(string spart,int iseq,string splant){
	NotNullDataReader   reader = null;
    decimal             dqoh=0;   
	try{
		string sql ="select sum(IPL_Qoh) as qoh from invpltloc where IPL_ProdID = '" + Converter.fixString(spart) + "'" +
                    " and IPL_Seq = " + NumberUtil.toString(iseq) +
                    " and IPL_Plant = '" + Converter.fixString(splant) + "'";

        reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
            dqoh = reader.GetDecimal("qoh");
        	                                	
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getSumQtyByPartSeq> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getSumQtyByPartSeq> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getSumQtyByPartSeq> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
    return dqoh;
}

public
void readByFilters(string spart,int iseq, string splant,string stockLoc,string smachine,int imachineId,string sglExp,string srepPoint,string sprodFamily, int rows){
    string sql = "select p.PFS_Des1,i.* from invpltloc i, prodfminfo p where IPL_ProdID = PFS_ProdID";

    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("IPL_ProdID",spart);
    if (iseq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "IPL_Seq = " + NumberUtil.toString(iseq);

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("IPL_Plant",splant);

    if (!string.IsNullOrEmpty(stockLoc))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("IPL_StkLoc",stockLoc);

    if (imachineId > 0 || !string.IsNullOrEmpty(smachine)){               
        sql = DBFormatter.addWhereAndSentence(sql) + " exists ( " +
            " select b.PC_ProdID from pltdeptmach m, prodfmactsub b " +
            " where b.PC_ProdID = IPL_ProdID and b.PC_Seq=IPL_Seq " +
            " and m.PDM_Plt = b.PC_Plt and m.PDM_Dept = b.PC_Dept and m.PDM_Mach=PC_Cfg ";
        if (imachineId > 0)
            sql+= " and m.PDM_ID = " + imachineId + " ";
        if (!string.IsNullOrEmpty(smachine))
            sql+= " and m.PDM_Mach like '" + smachine + "%' ";
        sql+=" )";
    }

    if (!string.IsNullOrEmpty(sglExp))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PFS_GLExp", sglExp);

    if (!string.IsNullOrEmpty(srepPoint)){
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" +
            " select p.PC_ProdID from prodfmactsub p where " +
            " p.PC_ProdID = IPL_ProdID and p.PC_Seq = IPL_Seq " +
            " and p.PC_RepPoint = '" + srepPoint + "'" +
            " )";
    }

    if (!string.IsNullOrEmpty(sprodFamily)) {
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" +
            " select p.PFS_ProdID from prodfminfo p where " +
            " IPL_ProdID = PFS_ProdID and p.PFS_FamProd = '" + Converter.fixString(sprodFamily) + "'" +
            " )";                
    }
    
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    sql+= " order by IPL_ProdID,IPL_Seq";

    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    //System.Windows.Forms.MessageBox.Show(sql);
    read(sql);
}

} // class

} // namespace