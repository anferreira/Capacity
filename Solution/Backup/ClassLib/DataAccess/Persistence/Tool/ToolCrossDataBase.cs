using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ToolCrossDataBase : GenericDataBaseElement{

private string TLX_ProdID;
private string TLX_ActID;
private int TLX_Seq;
private string TLX_SubID;
private int TLX_SubIDRank;
private int TLX_SubOrdNum;
private int TLX_MethodRank;
private string TLX_TLConfig;
private int TLX_Line;
private string TLX_TLSet;

public
ToolCrossDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.TLX_ProdID = reader.GetString("TLX_ProdID");
	this.TLX_ActID = reader.GetString("TLX_ActID");
	this.TLX_Seq = reader.GetInt32("TLX_Seq");
	this.TLX_SubID = reader.GetString("TLX_SubID");
	this.TLX_SubIDRank = reader.GetInt32("TLX_SubIDRank");
	this.TLX_SubOrdNum = reader.GetInt32("TLX_SubOrdNum");
	this.TLX_MethodRank = reader.GetInt32("TLX_MethodRank");
	this.TLX_TLConfig = reader.GetString("TLX_TLConfig");
	this.TLX_Line = reader.GetInt32("TLX_Line");
	this.TLX_TLSet = reader.GetString("TLX_TLSet");
}


void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from toolcross where " + 
					"TLX_ProdID = '" + TLX_ProdID + "' and " +
					"TLX_ActID = '" + TLX_ActID +  "' and " +
					"TLX_Seq = " + TLX_Seq +  " and " +
					"TLX_SubID = '" + TLX_SubID + "' and " +
					"TLX_SubIDRank = " + TLX_SubIDRank + " and " +
					"TLX_SubOrdNum = " + TLX_SubOrdNum + " and " + 
					"TLX_MethodRank = " + TLX_MethodRank + " and " +
					"TLX_TLConfig = '" + TLX_TLConfig + "' and " +
					"TLX_Line = " + TLX_Line ;
		
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
		string sql = "insert into toolcross values('" + 
					Converter.fixString(TLX_ProdID) + "', '" +
					Converter.fixString(TLX_ActID)  + "', " +
					TLX_Seq + ", '" +
					Converter.fixString(TLX_SubID)  + "', " +
					TLX_SubIDRank + ", " +
					TLX_SubOrdNum + ", " +
					TLX_MethodRank + ", '" +
					Converter.fixString(TLX_TLConfig)  + "', " +
					TLX_Line + ", '" +
					Converter.fixString(TLX_TLSet) + "')";
							
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
		string sql = "update toolcross set " +
			"TLX_TLSet = '" + Converter.fixString(TLX_TLSet) + "' " +
		" where " + 
			"TLX_ProdID = '" + TLX_ProdID + "' and " +
			"TLX_ActID = '" + TLX_ActID +  "' and " +
			"TLX_Seq = " + TLX_Seq +  " and " +
			"TLX_SubID = '" + TLX_SubID + "' and " +
			"TLX_SubIDRank = " + TLX_SubIDRank + " and " +
			"TLX_SubOrdNum = " + TLX_SubOrdNum + " and " + 
			"TLX_MethodRank = " + TLX_MethodRank + " and " +
			"TLX_TLConfig = '" + TLX_TLConfig + "' and " +
			"TLX_Line = " + TLX_Line ;
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
		string sql = "delete from toolcross where " +
			"TLX_ProdID = '" + TLX_ProdID + "' and " +
			"TLX_ActID = '" + TLX_ActID +  "' and " +
			"TLX_Seq = " + TLX_Seq +  " and " +
			"TLX_SubID = '" + TLX_SubID + "' and " +
			"TLX_SubIDRank = " + TLX_SubIDRank + " and " +
			"TLX_SubOrdNum = " + TLX_SubOrdNum + " and " + 
			"TLX_MethodRank = " + TLX_MethodRank + " and " +
			"TLX_TLConfig = '" + TLX_TLConfig + "' and " +
			"TLX_Line = " + TLX_Line ;
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
void setTLX_ProdID(string TLX_ProdID){
	this.TLX_ProdID = TLX_ProdID;
}

public
void setTLX_ActID(string TLX_ActID){
	this.TLX_ActID = TLX_ActID;
}

public
void setTLX_Seq(int TLX_Seq){
	this.TLX_Seq = TLX_Seq;
}

public
void setTLX_SubID(string TLX_SubID){
	this.TLX_SubID = TLX_SubID;
}

public
void setTLX_SubIDRank(int TLX_SubIDRank){
	this.TLX_SubIDRank = TLX_SubIDRank;
}

public
void setTLX_SubOrdNum(int TLX_SubOrdNum){
	this.TLX_SubOrdNum = TLX_SubOrdNum;
}

public
void setTLX_MethodRank(int TLX_MethodRank){
	this.TLX_MethodRank = TLX_MethodRank;
}

public
void setTLX_TLConfig(string TLX_TLConfig){
	this.TLX_TLConfig = TLX_TLConfig;
}

public
void setTLX_Line(int TLX_Line){
	this.TLX_Line = TLX_Line;
}

public
void setTLX_TLSet(string TLX_TLSet){
	this.TLX_TLSet = TLX_TLSet;
}



public
string getTLX_ProdID(){
	return TLX_ProdID;
}

public
string getTLX_ActID(){
	return TLX_ActID;
}

public
int getTLX_Seq(){
	return TLX_Seq;
}

public
string getTLX_SubID(){
	return TLX_SubID;
}

public
int getTLX_SubIDRank(){
	return TLX_SubIDRank;
}

public
int getTLX_SubOrdNum(){
	return TLX_SubOrdNum;
}

public
int getTLX_MethodRank(){
	return TLX_MethodRank;
}

public
string getTLX_TLConfig(){
	return TLX_TLConfig;
}

public
int getTLX_Line(){
	return TLX_Line;
}

public
string getTLX_TLSet(){
	return TLX_TLSet;
}


} // class

} // namespace