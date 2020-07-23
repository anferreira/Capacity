using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class OETerritoryDataBase : GenericDataBaseElement {

private int TR_ID;
private string TR_Territory;
private string TR_Description;
private string TR_SearchKey;
private string TR_Salesperson;

public 
OETerritoryDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.TR_ID = reader.GetInt32("TR_ID");
    this.TR_Territory = reader.GetString("TR_Territory");
    this.TR_Description = reader.GetString("TR_Description");
    this.TR_SearchKey = reader.GetString("TR_SearchKey");
    this.TR_Salesperson = reader.GetString("TR_Salesperson");
}

public override
void write(){
  try{
		string sql = "insert into oeterritory (TR_Territory,TR_Description,TR_SearchKey,TR_Salesperson) " +
		            "values('" +
                        Converter.fixString(TR_Territory) +"', '" +
                        Converter.fixString(TR_Description) +"', '" +
                        Converter.fixString(TR_SearchKey) +"', '" +
                        Converter.fixString(TR_Salesperson) +"')";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + "  <write>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + "  <write>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
}

public override
void update(){
    throw new PersistenceException("Method not implemented");
}

public override
void delete(){
 try{
		string sql = "delete from oeterritory " +
		            "where " +
                        NumberUtil.toString(TR_ID);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + "  <delete>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + "  <delete>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}


//Setters

public 
void setTR_ID (int TR_ID){
    this.TR_ID = TR_ID;
}

public 
void setTR_Territory (string TR_Territory){
    this.TR_Territory = TR_Territory;
}

public 
void setTR_Description (string TR_Description){
    this.TR_Description = TR_Description;
}

public 
void setTR_SearchKey (string TR_SearchKey){
    this.TR_SearchKey = TR_SearchKey;
}

public 
void setTR_Salesperson (string TR_Salesperson){
    this.TR_Salesperson = TR_Salesperson;
}


//Getters
public 
int getTR_ID(){
    return TR_ID;
}

public 
string getTR_Territory(){
    return TR_Territory;
}

public 
string getTR_Description(){
    return TR_Description;
}

public 
string getTR_SearchKey(){
    return TR_SearchKey;
}

public 
string getTR_Salesperson(){
    return TR_Salesperson;
}

}//end class

}//end namespace
