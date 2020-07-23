using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class ShiftHdrDataBaseContainer : GenericDataBaseContainer{

private string SH_Db;
private int SH_Company;
private string SH_Plt;
private string SH_Dept;

public
ShiftHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void setSH_Db(string SH_Db){
	this.SH_Db = SH_Db;
}

public
void setSH_Company(int SH_Company){
	this.SH_Company = SH_Company;
}

public
void setSH_Plt(string SH_Plt){
	this.SH_Plt = SH_Plt;
}

public
void setSH_Dept(string SH_Dept){
	this.SH_Dept = SH_Dept;
}

public
string getSH_Db(){
	return SH_Db;
}

public
string getSH_Plt(){
	return SH_Plt;
}

public
string getSH_Dept(){
	return SH_Dept;
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shifthdr order by SH_Shf";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
			shiftHdrDataBase.load(reader);
			this.Add(shiftHdrDataBase);
		}
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

public
void readByPltDept(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shifthdr where " +
			"SH_Db = '" + SH_Db + "' and " +
			"SH_Company = " + NumberUtil.toString(SH_Company) + " and " +
			"SH_Plt = '" + SH_Plt + "' and " +
			"SH_Dept = '" + SH_Dept + "' order by SH_Shf";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
			shiftHdrDataBase.load(reader);
			this.Add(shiftHdrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByPlt(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shifthdr where " +
			"SH_Db = '" + SH_Db + "' and " +
			"SH_Company = " + NumberUtil.toString(SH_Company) + " and " +
			"SH_Plt = '" + SH_Plt + "' order by SH_Shf";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
			shiftHdrDataBase.load(reader);
			this.Add(shiftHdrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPlt> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPlt> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPlt> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByDesc(string desc, string db, int company, string plt, string dept){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shifthdr " +
				" where " +
				"(SH_Shf like '%" + Converter.fixString(desc) + "%' or " +
				"SH_Des like '%" + Converter.fixString(desc) + "%')";
		
		if (db.Length > 0)
			sql += " and SH_Db = '" + db + "'";

		if (company >= 0)
			sql += " and SH_Company = " + NumberUtil.toString(company);

		if (plt.Length > 0)
			sql += " and SH_Plt = '" + plt + "'";

		if (dept.Length > 0)
			sql += " and SH_Dept = '" + dept + "'";

		sql += " order by SH_Des";
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftHdrDataBase shiftHdrDataBase = new ShiftHdrDataBase(dataBaseAccess);
			shiftHdrDataBase.load(reader);
			this.Add(shiftHdrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}



} // class

} // namespace