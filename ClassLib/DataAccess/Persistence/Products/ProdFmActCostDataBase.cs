using System;
#if !POCKET_PC
using MySql.Data;
#endif
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ProdFmActCostDataBase : GenericDataBaseElement{

private string PAC_ProdID;
private string PAC_ActID;
private int PAC_Seq;
private string PAC_PartType;
private decimal PAC_Cost;
private DateTime PAC_DateUpdated;


public
ProdFmActCostDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PAC_ProdID = reader.GetString("PAC_ProdID");
	this.PAC_ActID = reader.GetString("PAC_ActID");
	this.PAC_Seq = reader.GetInt32("PAC_Seq");
	this.PAC_PartType = reader.GetString("PAC_PartType").Trim();
	this.PAC_Cost = reader.GetDecimal("PAC_Cost");
	this.PAC_DateUpdated = reader.GetDateTime("PAC_DateUpdated");
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactcost where " + 
				"PAC_ProdID  = '" + PAC_ProdID + "' and " +
				"PAC_Seq = " + PAC_Seq;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdFmActCostDataBase <read>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
#endif
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactcost where " + 
			"PAC_ProdID  = '" + PAC_ProdID + "' and " +
			"PAC_Seq = " + PAC_Seq;
		reader = dataBaseAccess.executeQuery(sql);
		
		if (reader.Read())
			return true;
		else
			return false;
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdFmActCostDataBase <read>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
#endif
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override 
void write(){
	try{
		string sql = "insert into prodfmactcost values('" + 
			Converter.fixString(PAC_ProdID) + "', '" +
			Converter.fixString(PAC_ActID) + "', " +
			NumberUtil.toString(PAC_Seq) + ", '" +
			Converter.fixString(PAC_PartType) + "', " +
			NumberUtil.toString(PAC_Cost) + "," +
			"'" + DateUtil.getCompleteDateRepresentation(PAC_DateUpdated) + "')";			

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdFmActCostDataBase <write>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
#endif
	}

}

public override
void update(){
	try{
		string sql = "update prodfmactcost set " +
			"PAC_PartType = '" + Converter.fixString(PAC_PartType) + "', " +
			"PAC_Cost = " + NumberUtil.toString(PAC_Cost) + ", " +
			"PAC_DateUpdated='" + DateUtil.getCompleteDateRepresentation(PAC_DateUpdated) + "'" +			
		" where " +
			"PAC_ProdID  = '" + PAC_ProdID + "' and " +
#if !OE_SYNC
			"PAC_ActID = '" + PAC_ActID + "' and " +
#endif
			"PAC_Seq = " + PAC_Seq;

 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdFmActCostDataBase <update>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
#endif
	}

}

public override
void delete(){
	try{
		string sql = "delete from prodfmactcost where " +
			"PAC_ProdID  = '" + PAC_ProdID + "' and " +
#if !OE_SYNC
			"PAC_ActID = '" + PAC_ActID + "' and " +
#endif
			"PAC_Seq = " + PAC_Seq;
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
#if POCKET_PC
	}catch(System.Data.SqlServerCe.SqlCeException sCe){
		throw new PersistenceException("Error in class ProdFmActCostDataBase <delete>: " + sCe.Message);
#else
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
#endif
	}
}

public
void setPAC_ProdID(string PAC_ProdID){
	this.PAC_ProdID = PAC_ProdID;
}

public
void setPAC_ActID(string PAC_ActID){
	this.PAC_ActID = PAC_ActID;
}

public
void setPAC_Seq(int PAC_Seq){
	this.PAC_Seq = PAC_Seq;
}

public
void setPAC_PartType(string PAC_PartType){
	this.PAC_PartType = PAC_PartType;
}

public
void setPAC_Cost(decimal PAC_Cost){
	this.PAC_Cost = PAC_Cost;
}

public
void setPAC_DateUpdated(DateTime PAC_DateUpdated){
	this.PAC_DateUpdated = PAC_DateUpdated;
}
	
public
string getPAC_ProdID(){
	return PAC_ProdID;
}

public
string getPAC_ActID(){
	return PAC_ActID;
}

public
int getPAC_Seq(){
	return PAC_Seq;
}

public
string getPAC_PartType(){
	return PAC_PartType;
}

public
decimal getPAC_Cost(){
	return PAC_Cost;
}

public
DateTime getPAC_DateUpdated(){
	return PAC_DateUpdated;
}


} // class

} // namespace
