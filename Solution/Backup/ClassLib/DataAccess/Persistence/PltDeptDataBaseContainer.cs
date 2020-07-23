using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class PltDeptDataBaseContainer : GenericDataBaseContainer{

private string DE_Plt;

public
PltDeptDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void setDE_Plt(string DE_Plt){
	this.DE_Plt = DE_Plt;
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdept";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
			pltDeptDataBase.load(reader);
			this.Add(pltDeptDataBase);
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
string[] getDepartamentCodes(){
	NotNullDataReader reader = null;
	try{
		ArrayList array = new ArrayList();

		string sql = "select distinct(DE_Dept) from pltdept order by DE_Dept";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read())
			array.Add(reader.GetString(0));

		string[] vec = new String[array.Count];

		int index = 0;
		IEnumerator iEnum2 = array.GetEnumerator();
		while(iEnum2.MoveNext()){
			vec[index] = iEnum2.Current.ToString();
			index++;
		}
		
		return vec;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDepartamentCodes> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDepartamentCodes> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDepartamentCodes> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByPlt(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdept where DE_Plt = '" + DE_Plt + "'";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
			pltDeptDataBase.load(reader);		
			this.Add(pltDeptDataBase);
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
void truncate(){
	try{
		string sql = "delete from pltdept";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

public 
void readByDesc(string desc, string db, int company, string plt){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdept " +
				" where " +
				"(DE_Dept like '%" + Converter.fixString(desc) + "%' or " +
				"DE_Des1 like '%" + Converter.fixString(desc) + "%')";
		
		if (db.Length > 0)
			sql += " and DE_Db = '" + db + "'";

		if (company >= 0)
			sql += " and DE_Company = " + NumberUtil.toString(company);

		if (plt.Length > 0)
			sql += " and DE_Plt = '" + plt + "'";

		sql += " order by DE_Des1";
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
			pltDeptDataBase.load(reader);
			this.Add(pltDeptDataBase);
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
