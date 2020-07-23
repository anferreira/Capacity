using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmSetDataBase : GenericDataBaseElement{

private string PFS_ProdID;
private string PFS_ActID;
private int PFS_Seq;
private string PFS_SubID;
private int PFS_SubIDRank;
private int PFS_SubOrdNum;
private int PFS_MethodRank;
private int PFS_SetupRank;
private string PFS_SetUpType;
private string PFS_ToolType;
private decimal PFS_LabHr;
private int PFS_LabNum;
private string PFS_Dept;
private string PFS_EmpType;

public
ProdFmSetDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PFS_ProdID = reader.GetString("PFS_ProdID");
	this.PFS_ActID = reader.GetString("PFS_ActID");
	this.PFS_Seq = reader.GetInt32("PFS_Seq");
	this.PFS_SubID = reader.GetString("PFS_SubID");
	this.PFS_SubIDRank = reader.GetInt32("PFS_SubIDRank");
	this.PFS_SubOrdNum = reader.GetInt32("PFS_SubOrdNum");
	this.PFS_MethodRank = reader.GetInt32("PFS_MethodRank");
	this.PFS_SetupRank = reader.GetInt32("PFS_SetupRank");
	this.PFS_SetUpType = reader.GetString("PFS_SetUpType");
	this.PFS_ToolType = reader.GetString("PFS_ToolType");
	this.PFS_LabHr = reader.GetDecimal("PFS_LabHr");
	this.PFS_LabNum = reader.GetInt32("PFS_LabNum");
	this.PFS_Dept = reader.GetString("PFS_Dept");
	this.PFS_EmpType = reader.GetString("PFS_EmpType");
}


public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmset where " + 
					"PFS_ProdID = '" + PFS_ProdID + "' and " +
					"PFS_ActID = '" + PFS_ActID + "' and " +
					"PFS_Seq = " + PFS_Seq + "and " +
					"PFS_SubID = '" + PFS_SubID + "' and " +
					"PFS_SubIDRank = " + PFS_SubIDRank + " and " +
					"PFS_SubOrdNum = " + PFS_SubOrdNum + " and " +
					"PFS_MethodRank = " + PFS_MethodRank + " and " +
					"PFS_SetupRank = " + PFS_SetupRank + " and " + 
					"PFS_SetUpType = '" + PFS_SetUpType + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
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


public override
void write(){
	try{
		string sql = "insert into prodfmset values('" + 
				Converter.fixString(PFS_ProdID) + "', '" +
				Converter.fixString(PFS_ActID)  + "', " +
				PFS_Seq + ", '" +
				Converter.fixString(PFS_SubID) + "', " +
				PFS_SubIDRank + ", " +
				PFS_SubOrdNum + ", " +
				PFS_MethodRank + ", " +
				PFS_SetupRank + ", '" +
				Converter.fixString(PFS_SetUpType) + "', '" +
				Converter.fixString(PFS_ToolType) + "', " +
				NumberUtil.toString(PFS_LabHr) + ", " +
				PFS_LabNum + ", '" +
				Converter.fixString(PFS_Dept) + "', '" +
				Converter.fixString(PFS_EmpType) +"')";

				
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
	try{
		string sql = "update prodfmset set " +
						"PFS_ToolType = '" + Converter.fixString(PFS_ToolType) + "', " +
						"PFS_LabHr = " + PFS_LabHr + ", " +
						"PFS_LabNum = " + PFS_LabNum + ", " +
						"PFS_Dept = ' " + Converter.fixString(PFS_Dept) + "', " +
						"PFS_EmpType = ' " + Converter.fixString(PFS_EmpType) +"', " + 
					"where " +
					"PFS_ProdID = ' " + PFS_ProdID + "' and " +
					"PFS_ActID = ' " + PFS_ActID + "' and " + 
					"PFS_Seq = " + PFS_Seq + " and " +
					"PFS_SubID = ' " + PFS_SubID + "' and " +
					"PFS_SubIDRank = " + PFS_SubIDRank + " and " +
					"PFS_SubOrdNum = " + PFS_SubOrdNum + " and " +
					"PFS_MethodRank = " + PFS_MethodRank + " and " +
					"PFS_SetupRank = " + PFS_SetupRank + " and " +
					"PFS_SetUpType = ' " + PFS_SetUpType + "'";
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
		string sql = "delete from prodfmset where " +
					"PFS_ProdID = ' " + PFS_ProdID + "' and " +
					"PFS_ActID = ' " + PFS_ActID + "' and " + 
					"PFS_Seq = " + PFS_Seq + " and " +
					"PFS_SubID = ' " + PFS_SubID + "' and " +
					"PFS_SubIDRank = " + PFS_SubIDRank + " and " +
					"PFS_SubOrdNum = " + PFS_SubOrdNum + " and " +
					"PFS_MethodRank = " + PFS_MethodRank + " and " +
					"PFS_SetupRank = " + PFS_SetupRank + " and " +
					"PFS_SetUpType = ' " + PFS_SetUpType + "'";
				dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}


}

public
void setPFS_ProdID(string PFS_ProdID){
	this.PFS_ProdID = PFS_ProdID;
}
public
void setPFS_ActID(string PFS_ActID){
	this.PFS_ActID = PFS_ActID;
}
public
void setPFS_Seq(int PFS_Seq){
	this.PFS_Seq = PFS_Seq;
}
public
void setPFS_SubID(string PFS_SubID){
	this.PFS_SubID = PFS_SubID;
}
public
void setPFS_SubIDRank(int PFS_SubIDRank){
	this.PFS_SubIDRank = PFS_SubIDRank;
}
public
void setPFS_SubOrdNum(int PFS_SubOrdNum){
	this.PFS_SubOrdNum = PFS_SubOrdNum;
}
public
void setPFS_MethodRank(int PFS_MethodRank){
	this.PFS_MethodRank = PFS_MethodRank;
}
public
void setPFS_SetupRank(int PFS_SetupRank){
	this.PFS_SetupRank = PFS_SetupRank;
}
public
void setPFS_SetUpType(string PFS_SetUpType){
	this.PFS_SetUpType = PFS_SetUpType;
}
public
void setPFS_ToolType(string PFS_ToolType){
	this.PFS_ToolType = PFS_ToolType;
}
public
void setPFS_LabHr(decimal PFS_LabHr){
	this.PFS_LabHr = PFS_LabHr;
}
public
void setPFS_LabNum(int PFS_LabNum){
	this.PFS_LabNum = PFS_LabNum;
}
public
void setPFS_Dept(string PFS_Dept){
	this.PFS_Dept = PFS_Dept;
}
public
void setPFS_EmpType(string PFS_EmpType){
	this.PFS_EmpType = PFS_EmpType;
}


public
string getPFS_ProdID(){
	return PFS_ProdID;
}

public
string getPFS_ActID(){
	return PFS_ActID;
}

public
int getPFS_Seq(){
	return PFS_Seq;
}

public
string getPFS_SubID(){
	return PFS_SubID;
}

public
int getPFS_SubIDRank(){
	return PFS_SubIDRank;
}

public
int getPFS_SubOrdNum(){
	return PFS_SubOrdNum;
}

public
int getPFS_MethodRank(){
	return PFS_MethodRank;
}

public
int getPFS_SetupRank(){
	return PFS_SetupRank;
}

public
string getPFS_SetUpType(){
	return PFS_SetUpType;
}

public
string getPFS_ToolType(){
	return PFS_ToolType;
}

public
decimal getPFS_LabHr(){
	return PFS_LabHr;
}

public
int getPFS_LabNum(){
	return PFS_LabNum;
}

public
string getPFS_Dept(){
	return PFS_Dept;
}

public
string getPFS_EmpType(){
	return PFS_EmpType;
}


} // class

} // namespace