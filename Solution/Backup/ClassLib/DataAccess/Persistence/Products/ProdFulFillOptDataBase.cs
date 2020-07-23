using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class ProdFulFillOptDataBase : GenericDataBaseElement{

private int PFFO_Id;
private string PFFO_Plt;
private int PFFO_StdReplenishmentDays;


public ProdFulFillOptDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void load(NotNullDataReader reader){

    this.PFFO_Id = reader.GetInt32("PFFO_Id");
    this.PFFO_Plt = reader.GetString("PFFO_Plt");
    this.PFFO_StdReplenishmentDays = reader.GetInt32("PFFO_StdReplenishmentDays");
   
}

public override
void write(){

	try{
		string sql = "insert into prodfulfillopt (PFFO_Plt,PFFO_StdReplenishmentDays) " +
		             "values('" +
                            Converter.fixString(PFFO_Plt) +"', " +
                            NumberUtil.toString(PFFO_StdReplenishmentDays) +")";
                            
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}
}


public override
void update(){
	try{
		string sql = "update prodfulfillopt set " +
                        "PFFO_Plt = '" + Converter.fixString(PFFO_Plt) +"', " +
                        "PFFO_StdReplenishmentDays = " + NumberUtil.toString(PFFO_StdReplenishmentDays) +", " +
                     "where PFFO_Id =" + NumberUtil.toString(PFFO_Id);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}


public override
void delete(){
try{
		string sql = "delete from prodfulfillopt " +
			         "where PFFO_Id =" + NumberUtil.toString(PFFO_Id);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}


public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfulfillopt " + 
			         "where PFFO_Id =" + NumberUtil.toString(PFFO_Id);

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


//Setters
public void setPFFO_Plt (string PFFO_Plt){
    this.PFFO_Plt = PFFO_Plt;
}

public void setPFFO_StdReplenishmentDays (int PFFO_StdReplenishmentDays){
    this.PFFO_StdReplenishmentDays = PFFO_StdReplenishmentDays;
}


//Getters
public int getPFFO_Id(){
    return PFFO_Id;
}

public string getPFFO_Plt(){
    return PFFO_Plt;
}

public int getPFFO_StdReplenishmentDays(){
    return PFFO_StdReplenishmentDays;
}


}//end class
}//end namespace
