/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Capacity/CapMacTimeTypePorcDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: CapMacTimeTypePorcDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/03/29 04:18:13  fnicolet
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class CapMacTimeTypePorcDataBase : GenericDataBaseElement {

private string MTTP_Plt;
private string MTTP_Dept;
private string MTTP_Mach;
private string MTTP_TmType;
private decimal MTTP_Porcentage;

public
CapMacTimeTypePorcDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from capmactimetypeporc where " + getWhereCondition();

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
	string sql = "select * from capmactimetypeporc where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.MTTP_Plt = reader.GetString("MTTP_Plt");
	this.MTTP_Dept = reader.GetString("MTTP_Dept");
	this.MTTP_Mach = reader.GetString("MTTP_Mach");
	this.MTTP_TmType = reader.GetString("MTTP_TmType");
	this.MTTP_Porcentage = reader.GetDecimal("MTTP_Porcentage");
}

public override
void write(){
	string sql = "insert into capmactimetypeporc (" + 
		"MTTP_Plt," +
		"MTTP_Dept," +
		"MTTP_Mach," +
		"MTTP_TmType," +
		"MTTP_Porcentage" +

		") values (" + 

		"'" + Converter.fixString(MTTP_Plt) + "'," +
		"'" + Converter.fixString(MTTP_Dept) + "'," +
		"'" + Converter.fixString(MTTP_Mach) + "'," +
		"'" + Converter.fixString(MTTP_TmType) + "'," +
		"" + NumberUtil.toString(MTTP_Porcentage) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update capmactimetypeporc set " +
		"MTTP_Plt = '" + Converter.fixString(MTTP_Plt) + "', " +
		"MTTP_Dept = '" + Converter.fixString(MTTP_Dept) + "', " +
		"MTTP_Mach = '" + Converter.fixString(MTTP_Mach) + "', " +
		"MTTP_TmType = '" + Converter.fixString(MTTP_TmType) + "', " +
		"MTTP_Porcentage = " + NumberUtil.toString(MTTP_Porcentage) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from capmactimetypeporc where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"MTTP_Plt = '" + Converter.fixString(MTTP_Plt) + "' and " +
		"MTTP_Dept = '" + Converter.fixString(MTTP_Dept) + "' and " +
		"MTTP_Mach = '" + Converter.fixString(MTTP_Mach) + "' and " +
		"MTTP_TmType = '" + Converter.fixString(MTTP_TmType) + "'";
	return sqlWhere;
}

public
void setMTTP_Plt(string MTTP_Plt){
	this.MTTP_Plt = MTTP_Plt;
}

public
void setMTTP_Dept(string MTTP_Dept){
	this.MTTP_Dept = MTTP_Dept;
}

public
void setMTTP_Mach(string MTTP_Mach){
	this.MTTP_Mach = MTTP_Mach;
}

public
void setMTTP_TmType(string MTTP_TmType){
	this.MTTP_TmType = MTTP_TmType;
}

public
void setMTTP_Porcentage(decimal MTTP_Porcentage){
	this.MTTP_Porcentage = MTTP_Porcentage;
}

public
string getMTTP_Plt(){
	return MTTP_Plt;
}

public
string getMTTP_Dept(){
	return MTTP_Dept;
}

public
string getMTTP_Mach(){
	return MTTP_Mach;
}

public
string getMTTP_TmType(){
	return MTTP_TmType;
}

public
decimal getMTTP_Porcentage(){
	return MTTP_Porcentage;
}

} // class

} // package