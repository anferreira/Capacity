using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class DemDetailDataBaseContainer : GenericDataBaseContainer{

private string DEDT_ProdID;

public
DemDetailDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void setDEDT_ProdID(string DEDT_ProdID){
	this.DEDT_ProdID = DEDT_ProdID;
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.DEDT_OrdID, A.DEDT_ItemID, A.DEDT_RLID, " +
			"A.DEDT_Type, A.DEDT_BusPrt, A.DEDT_BusLoc, A.DEDT_InvLoc, " + 
			"C.PAH_ProdID, C.PAH_ActID, C.PAH_Seq, A.DEDT_QtyID, " +
			"A.DEDT_QtyOver, A.DEDT_QtyUnder, A.DEDT_CumID, A.DEDT_ShipTm, " +
			"A.DEDT_SrcType, A.DEDT_EcnLevOrd, A.DEDT_EcnLevPr, A.DEDT_DtShip, " +
			"A.DEDT_DtArr, A.DEDT_DtReqArr, A.DEDT_Emerg, A.DEDT_MasPrOrdID, " +
			"A.DEDT_PrOrdID, A.DEDT_OrdUom, A.DEDT_InvUom, A.DEDT_CusProdID " +
			"from demdetail as A, prodfmacth as C " +
			"where  A.DEDT_ProdID = C.PAH_ProdID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DemDetailDataBase demDetailDataBase = new DemDetailDataBase(dataBaseAccess);
			demDetailDataBase.load(reader);
			this.Add(demDetailDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readActives(){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.DEDT_OrdID, A.DEDT_ItemID, A.DEDT_RLID, " +
			"A.DEDT_Type, A.DEDT_BusPrt, A.DEDT_BusLoc, A.DEDT_InvLoc, " + 
			"C.PAH_ProdID, C.PAH_ActID, C.PAH_Seq, A.DEDT_QtyID, " +
			"A.DEDT_QtyOver, A.DEDT_QtyUnder, A.DEDT_CumID, A.DEDT_ShipTm, " +
			"A.DEDT_SrcType, A.DEDT_EcnLevOrd, A.DEDT_EcnLevPr, A.DEDT_DtShip, " +
			"A.DEDT_DtArr, A.DEDT_DtReqArr, A.DEDT_Emerg, A.DEDT_MasPrOrdID, " +
			"A.DEDT_PrOrdID, A.DEDT_OrdUom, A.DEDT_InvUom, A.DEDT_CusProdID " +
			"from demdetail as A, prodfmacth as C, prodfminfo as E " +
			"where A.DEDT_ProdID = C.PAH_ProdID and A.DEDT_ProdID = E.PFS_ProdID and " + 
			"E.PFS_InvStatus = 'A' order by A.DEDT_ProdID";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DemDetailDataBase demDetailDataBase = new DemDetailDataBase(dataBaseAccess);
			demDetailDataBase.load(reader);
			this.Add(demDetailDataBase, demDetailDataBase.getDEDT_ProdID());
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readActives> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readActives> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readActives> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readForBom(){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.DEDT_OrdID, A.DEDT_ItemID, A.DEDT_RLID, " +
			"A.DEDT_Type, A.DEDT_BusPrt, A.DEDT_BusLoc, A.DEDT_InvLoc, " + 
			"C.PAH_ProdID, C.PAH_ActID, C.PAH_Seq, A.DEDT_QtyID, " +
			"A.DEDT_QtyOver, A.DEDT_QtyUnder, A.DEDT_CumID, A.DEDT_ShipTm, " +
			"A.DEDT_SrcType, A.DEDT_EcnLevOrd, A.DEDT_EcnLevPr, A.DEDT_DtShip, " +
			"A.DEDT_DtArr, A.DEDT_DtReqArr, A.DEDT_Emerg, A.DEDT_MasPrOrdID, " +
			"A.DEDT_PrOrdID, A.DEDT_OrdUom, A.DEDT_InvUom, A.DEDT_CusProdID " +
			"from demdetail as A, prodfmacth as C, prodfminfo as D " +
		"where (A.DEDT_ProdID = C.PAH_ProdID) and " +
			"A.DEDT_ProdID in (select D.BMS_ProdID from bomsum as D where A.DEDT_ProdID = D.BMS_ProdID)" +
			" and (A.DEDT_ProdID = D.PFS_ProdID) and (D.PFS_InvStatus = 'A') " +
			" order by A.DEDT_DtShip, A.DEDT_ProdID, C.PAH_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DemDetailDataBase demDetailDataBase = new DemDetailDataBase(dataBaseAccess);
			demDetailDataBase.load(reader);
			this.Add(demDetailDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByProd(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from demdetail where DEDT_ProdID = '" +
			DEDT_ProdID + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			DemDetailDataBase demDetailDataBase = new DemDetailDataBase(dataBaseAccess);
			demDetailDataBase.load(reader);
			this.Add(demDetailDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProd> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProd> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProd> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
DemDetailDataBaseContainer getByProd(string prod){
	DemDetailDataBaseContainer demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		DemDetailDataBase demDetailDataBase = (DemDetailDataBase) en.Current;

		if (demDetailDataBase.getDEDT_ProdID().Equals(prod))
			demDetailDataBaseContainer.Add(demDetailDataBase);
	}
	return demDetailDataBaseContainer;
}

public
void truncate(){
	try{
		string sql = "delete from demdetail";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

public 
string[][] getDemandAsString(string[] filterPart){
	NotNullDataReader reader = null;
	try{
		string sql = "select DEDT_ProdId, DEDT_DtShip, sum(DEDT_QtyID)" +
			" from demdetail";
		
		if ((filterPart != null) && (filterPart.Length > 0)){
			sql += " where DEDT_ProdID in (";
			for(int i = 0; i < filterPart.Length; i++){
				//sql += "'" + filterPart[i].Replace(" ","") + "'";
				sql += "'" + filterPart[i] + "'";
				if (i < filterPart.Length - 1)
					sql += ", ";
			}
			sql +=")";
		}

		sql += " group by DEDT_ProdId, DEDT_DtShip ";
		sql += " order by DEDT_ProdId, DEDT_DtShip";

		ArrayList array = new ArrayList();

		//long idx = 0;
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string[] v = new string[4];
			v[0] = reader.GetString(0);
			v[1] = DateUtil.getDateRepresentation(reader.GetDateTime(1));
			v[2] = decimal.Round(reader.GetDecimal(2), 0).ToString("########0");
			v[3] = "0";
			array.Add(v);
		}

		int index = 0;
		string[][] demand = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] v = (string[])en.Current;
			demand[index] = v;
			index++;
		}

		return demand;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDemandAsString> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDemandAsString> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDemandAsString> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
string[][] getDemandsAsStringByDate(DateTime dateFrom, DateTime dateTo, bool activeOnly){
	NotNullDataReader reader = null;
	try{
		string sql = "select C.PAH_ProdID, C.PAH_Seq, A.DEDT_DtShip, A.DEDT_QtyID, A.DEDT_OrdID, A.DEDT_ItemID, A.DEDT_RLID, A.DEDT_BusLoc, E.PFS_InvStatus " +
			"from demdetail as A, prodfmacth as C, prodfminfo as E " +
			"where A.DEDT_ProdID = C.PAH_ProdID and A.DEDT_ProdID = E.PFS_ProdID and ";

		if (activeOnly)
			sql += "E.PFS_InvStatus = 'A' and ";
		
		sql += "A.DEDT_DtShip >= '" + DateUtil.getDateRepresentation(dateFrom) + "' " +
			"and A.DEDT_DtShip <= '" + DateUtil.getDateRepresentation(dateTo) + "'";
		
		sql += " order by A.DEDT_DtShip, A.DEDT_ProdId";

		ArrayList array = new ArrayList();

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string[] v = new string[9];
			v[0] = reader.GetString(0);
			v[1] = NumberUtil.toString(reader.GetInt32(1));
			v[2] = DateUtil.getDateRepresentation(reader.GetDateTime(2), DateUtil.MMDDYYYY);
			v[3] = NumberUtil.toString(reader.GetDecimal(3));
			v[4] = NumberUtil.toString(reader.GetDecimal(4));
			v[5] = NumberUtil.toString(reader.GetDecimal(5));
			v[6] = reader.GetString(6);
			v[7] = reader.GetString(7);
			v[8] = reader.GetString(8);
			array.Add(v);
		}

		int index = 0;
		string[][] demand = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] v = (string[])en.Current;
			demand[index] = v;
			index++;
		}

		return demand;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDemandsAsStringByDate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDemandsAsStringByDate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDemandsAsStringByDate> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

} // class

} // namespace