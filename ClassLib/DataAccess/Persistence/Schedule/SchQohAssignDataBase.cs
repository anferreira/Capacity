/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Schedule/SchQohAssignDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: SchQohAssignDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:53  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/09 03:42:36  fnicolet
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SchQohAssignDataBase : GenericDataBaseElement {

private string SQA_Dept;
private string SQA_Plt;
private string SQA_SchVersion;
private string SQA_ProdID;
private int SQA_Seq;
private decimal SQA_OrdID;
private decimal SQA_ItemID;
private string SQA_RLID;
private decimal SQA_Qty;

public
SchQohAssignDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from schqohassign where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	string sql = "select * from schqohassign where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.SQA_Dept = reader.GetString("SQA_Dept");
	this.SQA_Plt = reader.GetString("SQA_Plt");
	this.SQA_SchVersion = reader.GetString("SQA_SchVersion");
	this.SQA_ProdID = reader.GetString("SQA_ProdID");
	this.SQA_Seq = reader.GetInt32("SQA_Seq");
	this.SQA_OrdID = reader.GetDecimal("SQA_OrdID");
	this.SQA_ItemID = reader.GetDecimal("SQA_ItemID");
	this.SQA_RLID = reader.GetString("SQA_RLID");
	this.SQA_Qty = reader.GetDecimal("SQA_Qty");
}

public override
void write(){
	string sql = "insert into schqohassign (" + 
		"SQA_Dept," +
		"SQA_Plt," +
		"SQA_SchVersion," +
		"SQA_ProdID," +
		"SQA_Seq," +
		"SQA_OrdID," +
		"SQA_ItemID," +
		"SQA_RLID," +
		"SQA_Qty" +

		") values (" + 

		"'" + Converter.fixString(SQA_Dept) + "'," +
		"'" + Converter.fixString(SQA_Plt) + "'," +
		"'" + Converter.fixString(SQA_SchVersion) + "'," +
		"'" + Converter.fixString(SQA_ProdID) + "'," +
		"" + NumberUtil.toString(SQA_Seq) + "," +
		"" + NumberUtil.toString(SQA_OrdID) + "," +
		"" + NumberUtil.toString(SQA_ItemID) + "," +
		"'" + Converter.fixString(SQA_RLID) + "'," +
		"" + NumberUtil.toString(SQA_Qty) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update schqohassign set " +
		"SQA_Dept = '" + Converter.fixString(SQA_Dept) + "', " +
		"SQA_Plt = '" + Converter.fixString(SQA_Plt) + "', " +
		"SQA_SchVersion = '" + Converter.fixString(SQA_SchVersion) + "', " +
		"SQA_ProdID = '" + Converter.fixString(SQA_ProdID) + "', " +
		"SQA_Seq = " + NumberUtil.toString(SQA_Seq) + ", " +
		"SQA_OrdID = " + NumberUtil.toString(SQA_OrdID) + ", " +
		"SQA_ItemID = " + NumberUtil.toString(SQA_ItemID) + ", " +
		"SQA_RLID = '" + Converter.fixString(SQA_RLID) + "', " +
		"SQA_Qty = " + NumberUtil.toString(SQA_Qty) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from schqohassign where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"SQA_Dept = '" + Converter.fixString(SQA_Dept) + "' and " +
		"SQA_Plt = '" + Converter.fixString(SQA_Plt) + "' and " +
		"SQA_SchVersion = '" + Converter.fixString(SQA_SchVersion) + "' and " +
		"SQA_ProdID = '" + Converter.fixString(SQA_ProdID) + "' and " +
		"SQA_Seq = " + NumberUtil.toString(SQA_Seq) + " and " +
		"SQA_OrdID = " + NumberUtil.toString(SQA_OrdID) + " and " +
		"SQA_ItemID = " + NumberUtil.toString(SQA_ItemID) + " and " +
		"SQA_RLID = '" + Converter.fixString(SQA_RLID) + "'";
	return sqlWhere;
}

public
void setSQA_Dept(string SQA_Dept){
	this.SQA_Dept = SQA_Dept;
}

public
void setSQA_Plt(string SQA_Plt){
	this.SQA_Plt = SQA_Plt;
}

public
void setSQA_SchVersion(string SQA_SchVersion){
	this.SQA_SchVersion = SQA_SchVersion;
}

public
void setSQA_ProdID(string SQA_ProdID){
	this.SQA_ProdID = SQA_ProdID;
}

public
void setSQA_Seq(int SQA_Seq){
	this.SQA_Seq = SQA_Seq;
}

public
void setSQA_OrdID(decimal SQA_OrdID){
	this.SQA_OrdID = SQA_OrdID;
}

public
void setSQA_ItemID(decimal SQA_ItemID){
	this.SQA_ItemID = SQA_ItemID;
}

public
void setSQA_RLID(string SQA_RLID){
	this.SQA_RLID = SQA_RLID;
}

public
void setSQA_Qty(decimal SQA_Qty){
	this.SQA_Qty = SQA_Qty;
}

public
string getSQA_Dept(){
	return SQA_Dept;
}

public
string getSQA_Plt(){
	return SQA_Plt;
}

public
string getSQA_SchVersion(){
	return SQA_SchVersion;
}

public
string getSQA_ProdID(){
	return SQA_ProdID;
}

public
int getSQA_Seq(){
	return SQA_Seq;
}

public
decimal getSQA_OrdID(){
	return SQA_OrdID;
}

public
decimal getSQA_ItemID(){
	return SQA_ItemID;
}

public
string getSQA_RLID(){
	return SQA_RLID;
}

public
decimal getSQA_Qty(){
	return SQA_Qty;
}

public string getHashKey(){
	return SQA_Dept + "_" + SQA_Plt + "_" + SQA_SchVersion + "_" + SQA_ProdID + "_" + SQA_Seq.ToString() + "_" + SQA_OrdID.ToString() + "_" + SQA_ItemID.ToString() + "_" + SQA_RLID;
}

} // class

} // package