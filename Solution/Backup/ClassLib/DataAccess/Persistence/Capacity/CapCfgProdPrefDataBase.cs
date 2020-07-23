/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Capacity/CapCfgProdPrefDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: CapCfgProdPrefDataBase.cs,v $
*   Revision 1.4  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.3  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/04/05 04:06:53  fnicolet
*   *** empty log message ***
*
*   Revision 1.1  2005/04/01 01:53:00  fnicolet
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class CapCfgProdPrefDataBase : GenericDataBaseElement {

private string PFCP_Plt;
private string PFCP_Dept;
private string PFCP_Cfg;
private string PFCP_Mach;
private string PFCP_ProdID;
private int PFCP_Seq;
private int PFCP_Pref;

public
CapCfgProdPrefDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from capcfgprodpref where " + getWhereCondition();

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
	string sql = "select * from capcfgprodpref where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.PFCP_Plt = reader.GetString("PFCP_Plt");
	this.PFCP_Dept = reader.GetString("PFCP_Dept");
	this.PFCP_Cfg = reader.GetString("PFCP_Cfg");
	this.PFCP_Mach = reader.GetString("PFCP_Mach");
	this.PFCP_ProdID = reader.GetString("PFCP_ProdID");
	this.PFCP_Seq = reader.GetInt32("PFCP_Seq");
	this.PFCP_Pref = reader.GetInt32("PFCP_Pref");
}

public override
void write(){
	string sql = "insert into capcfgprodpref (" + 
		"PFCP_Plt," +
		"PFCP_Dept," +
		"PFCP_Cfg," +
		"PFCP_Mach," +
		"PFCP_ProdID," +
		"PFCP_Seq," +
		"PFCP_Pref" +

		") values (" + 

		"'" + Converter.fixString(PFCP_Plt) + "'," +
		"'" + Converter.fixString(PFCP_Dept) + "'," +
		"'" + Converter.fixString(PFCP_Cfg) + "'," +
		"'" + Converter.fixString(PFCP_Mach) + "'," +
		"'" + Converter.fixString(PFCP_ProdID) + "'," +
		"" + NumberUtil.toString(PFCP_Seq) + "," +
		"" + NumberUtil.toString(PFCP_Pref) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update capcfgprodpref set " +
		"PFCP_Plt = '" + Converter.fixString(PFCP_Plt) + "', " +
		"PFCP_Dept = '" + Converter.fixString(PFCP_Dept) + "', " +
		"PFCP_Cfg = '" + Converter.fixString(PFCP_Cfg) + "', " +
		"PFCP_Mach = '" + Converter.fixString(PFCP_Mach) + "', " +
		"PFCP_ProdID = '" + Converter.fixString(PFCP_ProdID) + "', " +
		"PFCP_Seq = " + NumberUtil.toString(PFCP_Seq) + ", " +
		"PFCP_Pref = " + NumberUtil.toString(PFCP_Pref) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capcfgprodpref where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"PFCP_Plt = '" + Converter.fixString(PFCP_Plt) + "' and " +
		"PFCP_Dept = '" + Converter.fixString(PFCP_Dept) + "' and " +
		"PFCP_Cfg = '" + Converter.fixString(PFCP_Cfg) + "' and " +
		"PFCP_Mach = '" + Converter.fixString(PFCP_Mach) + "' and " +
		"PFCP_ProdID = '" + Converter.fixString(PFCP_ProdID) + "' and " +
		"PFCP_Seq = " + NumberUtil.toString(PFCP_Seq) + "";
	return sqlWhere;
}

public
void setPFCP_Plt(string PFCP_Plt){
	this.PFCP_Plt = PFCP_Plt;
}

public
void setPFCP_Dept(string PFCP_Dept){
	this.PFCP_Dept = PFCP_Dept;
}

public
void setPFCP_Cfg(string PFCP_Cfg){
	this.PFCP_Cfg = PFCP_Cfg;
}

public
void setPFCP_Mach(string PFCP_Mach){
	this.PFCP_Mach = PFCP_Mach;
}

public
void setPFCP_ProdID(string PFCP_ProdID){
	this.PFCP_ProdID = PFCP_ProdID;
}

public
void setPFCP_Seq(int PFCP_Seq){
	this.PFCP_Seq = PFCP_Seq;
}

public
void setPFCP_Pref(int PFCP_Pref){
	this.PFCP_Pref = PFCP_Pref;
}

public
string getPFCP_Plt(){
	return PFCP_Plt;
}

public
string getPFCP_Dept(){
	return PFCP_Dept;
}

public
string getPFCP_Cfg(){
	return PFCP_Cfg;
}

public
string getPFCP_Mach(){
	return PFCP_Mach;
}

public
string getPFCP_ProdID(){
	return PFCP_ProdID;
}

public
int getPFCP_Seq(){
	return PFCP_Seq;
}

public
int getPFCP_Pref(){
	return PFCP_Pref;
}

/*public 
string getKey(){
	return PFCP_Plt + "_" + PFCP_Dept + "_" + PFCP_Cfg + "_" + PFCP_Mach + "_" + PFCP_ProdID + "_" + PFCP_Seq.ToString();
}
*/
} // class

} // package