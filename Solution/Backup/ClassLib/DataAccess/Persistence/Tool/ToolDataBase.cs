using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ToolDataBase : GenericDataBaseElement{

private string TL_TLID;
private string TL_Type;
private string TL_Des1;
private string TL_Des2;
private string TL_Des3;
private string TL_Cat;
private int TL_CavNum;
private int TL_CavAvail;
private int TL_CavUnavail;
private string TL_FamMulti;
private string TL_ProdMulti;
private string TL_TLCfg;
private string TL_Plt;
private string TL_Dept;
private string TL_Mach;
private string TL_Status;
private int TL_Priority;
private string TL_Consume;

public
ToolDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.TL_TLID = reader.GetString("TL_TLID");
	this.TL_Type = reader.GetString("TL_Type");
	this.TL_Des1 = reader.GetString("TL_Des1");
	this.TL_Des2 = reader.GetString("TL_Des2");
	this.TL_Des3 = reader.GetString("TL_Des3");
	this.TL_Cat = reader.GetString("TL_Cat");
	this.TL_CavNum = reader.GetInt16("TL_CavNum");
	this.TL_CavAvail = reader.GetInt16("TL_CavAvail");
	this.TL_CavUnavail = reader.GetInt16("TL_CavUnavail");
	this.TL_FamMulti = reader.GetString("TL_FamMulti");
	this.TL_ProdMulti = reader.GetString("TL_ProdMulti");
	this.TL_TLCfg = reader.GetString("TL_TLCfg");
	this.TL_Plt = reader.GetString("TL_Plt");
	this.TL_Dept = reader.GetString("TL_Dept");
	this.TL_Mach = reader.GetString("TL_Mach");
	this.TL_Status = reader.GetString("TL_Status");
	this.TL_Priority = reader.GetInt16("TL_Priority");
	this.TL_Consume = reader.GetString("TL_Consume");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from tool where " + 
				"TL_TLID =' " + TL_TLID + "'";
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
		string sql = "insert into tool values('" + 
			"TL_TLID = '" + Converter.fixString(TL_TLID) + "', " +
			"TL_Type = '" + Converter.fixString(TL_Type) + "', " +
			"TL_Des1 = '" + Converter.fixString(TL_Des1) + "', " +
			"TL_Des2 = '" + Converter.fixString(TL_Des2) + "', " +
			"TL_Des3 = '" + Converter.fixString(TL_Des3) + "', " +
			"TL_Cat = '" + Converter.fixString(TL_Cat) + "', " +
			"TL_CavNum =" + TL_CavNum + ", " +
			"TL_CavAvail =" + TL_CavAvail + ", " +
			"TL_CavUnavail =" + TL_CavUnavail + ", " +
			"TL_FamMulti = '" + Converter.fixString(TL_FamMulti) + "', " +
			"TL_ProdMulti = '" + Converter.fixString(TL_ProdMulti) + "', " +
			"TL_TLCfg = '" + Converter.fixString(TL_TLCfg) + "', " +
			"TL_Plt = '" + Converter.fixString(TL_Plt) + "', " +
			"TL_Dept = '" + Converter.fixString(TL_Dept) + "', " +
			"TL_Mach = '" + Converter.fixString(TL_Mach) + "', " +
			"TL_Status = '" + Converter.fixString(TL_Status) + "', " +
			"TL_Priority =" + TL_Priority + ", " +
			"TL_Consume = '" + Converter.fixString(TL_Consume) + "'";
			
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
		string sql = "update tool set " +
				"TL_Type = '" + Converter.fixString(TL_Type) + "', " +
				"TL_Des1 = '" + Converter.fixString(TL_Des1) + "', " +
				"TL_Des2 = '" + Converter.fixString(TL_Des2) + "', " +
				"TL_Des3 = '" + Converter.fixString(TL_Des3) + "', " +
				"TL_Cat = '" + Converter.fixString(TL_Cat) + "', " +
				"TL_CavNum =" + TL_CavNum + ", " +
				"TL_CavAvail =" + TL_CavAvail + ", " +
				"TL_CavUnavail =" + TL_CavUnavail + ", " +
				"TL_FamMulti = '" + Converter.fixString(TL_FamMulti) + "', " +
				"TL_ProdMulti = '" + Converter.fixString(TL_ProdMulti) + "', " +
				"TL_TLCfg = '" + Converter.fixString(TL_TLCfg) + "', " +
				"TL_Plt = '" + Converter.fixString(TL_Plt) + "', " +
				"TL_Dept = '" + Converter.fixString(TL_Dept) + "', " +
				"TL_Mach = '" + Converter.fixString(TL_Mach) + "', " +
				"TL_Status = '" + Converter.fixString(TL_Status) + "', " +
				"TL_Priority =" + TL_Priority + ", " +
				"TL_Consume = '" + Converter.fixString(TL_Consume) + "' " +
			" where " + 
					"TL_TLID =' " + TL_TLID + "'";
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
		string sql = "delete from tool where " +
			"TL_TLID =' " + TL_TLID + "'";
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
void setTL_TLID(string TL_TLID){
	this.TL_TLID = TL_TLID;
}

public
void setTL_Type(string TL_Type){
	this.TL_Type = TL_Type;
}

public
void setTL_Des1(string TL_Des1){
	this.TL_Des1 = TL_Des1;
}

public
void setTL_Des2(string TL_Des2){
	this.TL_Des2 = TL_Des2;
}

public
void setTL_Des3(string TL_Des3){
	this.TL_Des3 = TL_Des3;
}

public
void setTL_Cat(string TL_Cat){
	this.TL_Cat = TL_Cat;
}


public
void setTL_CavNum(int TL_CavNum){
	this.TL_CavNum = TL_CavNum;
}

public
void setTL_CavAvail(int TL_CavAvail){
	this.TL_CavAvail = TL_CavAvail;
}

public
void setTL_CavUnavail(int TL_CavUnavail){
	this.TL_CavUnavail = TL_CavUnavail;
}

public
void setTL_FamMulti(string TL_FamMulti){
	this.TL_FamMulti = TL_FamMulti;
}

public
void setTL_ProdMulti(string TL_ProdMulti){
	this.TL_ProdMulti = TL_ProdMulti;
}

public
void setTL_TLCfg(string TL_TLCfg){
	this.TL_TLCfg = TL_TLCfg;
}

public
void setTL_Plt(string TL_Plt){
	this.TL_Plt = TL_Plt;
}

public
void setTL_Dept(string TL_Dept){
	this.TL_Dept = TL_Dept;
}

public
void setTL_Mach(string TL_Mach){
	this.TL_Mach = TL_Mach;
}

public
void setTL_Status(string TL_Status){
	this.TL_Status = TL_Status;
}

public
void setTL_Priority(int TL_Priority){
	this.TL_Priority = TL_Priority;
}

public
void setTL_Consume(string TL_Consume){
	this.TL_Consume = TL_Consume;
}

//--------------------------------
public
string getTL_TLID(){
	return TL_TLID;
}

public
string getTL_Type(){
	return TL_Type;
}

public
string getTL_Des1(){
	return TL_Des1;
}

public
string getTL_Des2(){
	return TL_Des2;
}

public
string getTL_Des3(){
	return TL_Des3;
}

public
string getTL_Cat(){
	return TL_Cat;
}

public
int getTL_CavNum(){
	return TL_CavNum;
}

public
int getTL_CavAvail(){
	return TL_CavAvail;
}

public
int getTL_CavUnavail(){
	return TL_CavUnavail;
}

public
string getTL_FamMulti(){
	return TL_FamMulti;
}

public
string getTL_ProdMulti(){
	return TL_ProdMulti;
}

public
string getTL_TLCfg(){
	return TL_TLCfg;
}

public
string getTL_Plt(){
	return TL_Plt;
}

public
string getTL_Dept(){
	return TL_Dept;
}

public
string getTL_Mach(){
	return TL_Mach;
}

public
string getTL_Status(){
	return TL_Status;
}

public
int getTL_Priority(){
	return TL_Priority;
}

public
string getTL_Consume(){
	return TL_Consume;
}


} // class

} // namespace