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

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from invpltloc";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.load(reader);
			this.Add(invPltLocDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readAllBySeq(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from invpltloc where IPL_Seq = " +
			IPL_Seq.ToString() + " order by IPL_ProdID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.load(reader);
			this.Add(invPltLocDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllBySeq> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllBySeq> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllBySeq> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByProdId(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from invpltloc where " + 
			"IPL_ProdID = '" + IPL_ProdID + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.load(reader);
			this.Add(invPltLocDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdId> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdId> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdId> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
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
void readForHotList(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct PAH_ProdID AS HOTC_ProdID," +
			"PAH_ActID AS HOTC_ActID, " +
			"PAH_Seq AS HOTC_Seq, " +
	        
			"(select sum(det1.IPL_Qoh) "+
			"from invpltloc det1 " +
			"where det1.IPL_Seq = prodFm.PAH_Seq AND det1.IPL_ProdID = prodFm.PAH_ProdID) " +
			"AS HOTC_Qoh, " +
	        
			"(select sum(det1.IPL_Qoh) "+
			"from invpltloc det1 " +
			"where det1.IPL_Seq >= prodFm.PAH_Seq AND det1.IPL_ProdID = prodFm.PAH_ProdID) " +
			"AS HOTC_QohCml, " +
			"'" + Constants.DEFAULT_UOM + "' AS HOTC_Uom " +
			"from prodfmacth prodFm LEFT OUTER JOIN " + 
			"invpltloc det2 ON " +
				"prodFm.PAH_ProdID = det2.IPL_ProdID and " +
				"prodFm.PAH_Seq = det2.IPL_Seq " + 
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
	try{
		string sql = "delete from invpltloc";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message);
	}
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
} // class

} // namespace