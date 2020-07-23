using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class SchPrOrdMatDataBaseContainer: GenericDataBaseContainer{

public 
SchPrOrdMatDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try	{
		string sql = "select * from schprordmat";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchPrOrdMatDataBase schPrOrdMatDataBase = new SchPrOrdMatDataBase(dataBaseAccess);
			schPrOrdMatDataBase.load(reader);
			this.Add(schPrOrdMatDataBase);
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
}//end read

public 
void readAllMaterialsForOrders(){
	NotNullDataReader reader = null;
	try	{
		string sql = "select " +
			"SPO_PrOrd, " +
			"BMS_MatID, " +
			"BMS_ActID, " +
			"BMS_Seq, " +
			"SPO_Qty * BMS_MatQty, " +
			"BMS_Uom, " +
			"BMS_MatQty, " +
			"SPO_Uom, " +
			"BMS_PrQtyUom, " +
			"BMS_QtyPerInv, " +
			"BMS_QtyPerUom, " +
			"BMS_ScrapPer " +
			"from bomsum as A, schprord as B " +
			"where A.BMS_ProdID = B.SPO_ProdID and " +
//			"A.BMS_ActID = B.SPO_ActID and " +
			"A.BMS_Seq = B.SPO_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		decimal counter = 0;

		while(reader.Read()){
			SchPrOrdMatDataBase schPrOrdMatDataBase = new SchPrOrdMatDataBase(dataBaseAccess);
			schPrOrdMatDataBase.load2(reader);

			counter++;
			schPrOrdMatDataBase.setSMP_LineID(decimal.ToInt32(counter));

			this.Add(schPrOrdMatDataBase);
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
		string sql = "delete from schprordmat";
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

} // namespace
