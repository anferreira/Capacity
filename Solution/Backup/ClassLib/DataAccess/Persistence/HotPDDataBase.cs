using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class HotPDDataBase : GenericDataBaseElement{

private string DEDT_ProdID;
private decimal Total;

public
HotPDDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.DEDT_ProdID = reader.GetString("DEDT_ProdID");
	this.Total = reader.GetDecimal("Total");
}

public
void read(){
	throw new PersistenceException("Method not implemented");
}


public override
void write(){
	try{
		string sql = "insert into hotpd values('" + 
		Converter.fixString(DEDT_ProdID) + "', " +
		NumberUtil.toString(Total) + ")";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setDEDT_ProdID(string DEDT_ProdID){
	this.DEDT_ProdID = DEDT_ProdID;
}

public
void setTotal(decimal Total){
	this.Total = Total;
}


public
string getDEDT_ProdID(){
	return DEDT_ProdID;
}

public
decimal getTotal(){
	return Total;
}


} // class

} // namespace