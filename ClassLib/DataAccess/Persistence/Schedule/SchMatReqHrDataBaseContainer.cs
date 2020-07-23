using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMatReqHrDataBaseContainer : GenericDataBaseContainer{

public
SchMatReqHrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqhr";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMatReqHrDataBase schMatReqHrDataBase = new SchMatReqHrDataBase(dataBaseAccess);
			schMatReqHrDataBase.load(reader);
			this.Add(schMatReqHrDataBase);
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
void readAllMaterialsForOrders(){
	NotNullDataReader reader = null;
	try{
		string sql = "select " +
			"A.SMH_SchVersion, " +
			"A.SMH_MachOrdNum, " +
			"A.SMH_Plt, " +
			"A.SMH_Dept, " +
			"A.SMH_Mach, " +
			"A.SMH_Shf, " +
			"A.SMH_Dt, " +
			"A.SMH_DtShf, " +
			"B.SPH_ProdID, " +
			"0 as SMH_LineID, " +
			"C.BMS_MatID, " +
			"B.SPH_Seq, " +
			"B.SPH_ActID, " +
			"C.BMS_QtyPerInv, " +
			"C.BMS_Uom, " +
			"C.BMS_MatQty, " +
			"0.0 as SMH_InvStartPos, " +
			"0.0 as SMH_InvEndPos " +
		"from schmachhr as A, schprfmhr as B, bomsum as C" + 
		" where " +
				"A.SMH_MasPrOrd = B.SPH_PrOrdMas and " +
				"A.SMH_PrOrd = B.SPH_PrOrd and " +
				"B.SPH_ProdID = C.BMS_ProdID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMatReqHrDataBase schMatReqHrDataBase = new SchMatReqHrDataBase(dataBaseAccess);
			schMatReqHrDataBase.load(reader);
			this.Add(schMatReqHrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllMaterialsForOrders> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllMaterialsForOrders> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllMaterialsForOrders> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try	{
		string sql = "delete from schmatreqhr";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}


} // class

}