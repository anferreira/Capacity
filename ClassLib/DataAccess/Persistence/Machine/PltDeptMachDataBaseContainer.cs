using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines{


public 
class PltDeptMachDataBaseContainer : GenericDataBaseContainer{

private string PDM_Dept;
private string PDM_Plt;

public
PltDeptMachDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
		pltDeptMachDataBase.load(reader);
		this.Add(pltDeptMachDataBase);
	}
}

public
void setPDM_Dept(string PDM_Dept){
	this.PDM_Dept = PDM_Dept;
}

public
void setPDM_Plt(string PDM_Plt){
	this.PDM_Plt = PDM_Plt;
}

public
void readByPltDept(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "'";
					
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void readByPltDeptAndDesc(string searchText){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "'";
		if (searchText.Length > 0)	
			sql += " and PDM_Mach like '%" + searchText + "%' or PDM_Des1 like '%" + searchText + "%'";
			
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt;
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void readByPltDeptNotInConfiguration(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "' and not exists (";
		sql += "select * from capmaccfga where CMCA_Plt = '" + PDM_Plt + "' and CMCA_Dept = '" +
			PDM_Dept + "' and CMCA_Mach = PDM_Mach)";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void readByPltDeptNotInConfiguration(string cfg){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach where PDM_Plt = '" + PDM_Plt +
			"' and PDM_Dept = '" + PDM_Dept + "' and not exists (";
		sql += "select * from capmaccfga where CMCA_Plt = '" + PDM_Plt + "' and CMCA_Dept = '" +
			PDM_Dept + "' and CMCA_Cfg = '" + cfg + "' and CMCA_Mach = PDM_Mach)";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.load(reader);
			this.Add(pltDeptMachDataBase);
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
void read(){	
	string sql = "select * from pltdeptmach";
	read(sql);		
}

public
void truncate(){
	try{
		string sql = "delete from pltdeptmach";
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
void readByFilters(string smachine,string sdes1, string splant, string sdept,string scheduled,int rows){
    string sql = "select * from pltdeptmach";

    sql+= readBaseByFilters(smachine, sdes1, splant, sdept,scheduled);

    sql += " order by PDM_Dept,PDM_Mach";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

protected
string readBaseByFilters(string smachine,string sdes1, string splant, string sdept,string scheduled){
    string sql = " ";

    if (!string.IsNullOrEmpty(smachine))
        sql = DBFormatter.addWhereAndSentence(sql) + " PDM_Mach like '" + smachine + "'";
    if (!string.IsNullOrEmpty(sdes1))
        sql = DBFormatter.addWhereAndSentence(sql) + " PDM_Des1 like '" + sdes1 + "'";
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + " PDM_Plt like '" + splant + "'";
    if (!string.IsNullOrEmpty(sdept))
        sql = DBFormatter.addWhereAndSentence(sql) + " PDM_Dept like '" + sdept + "'";
    if (!string.IsNullOrEmpty(scheduled))
        sql = DBFormatter.addWhereAndSentence(sql) + " PDM_Scheduled = '" + scheduled + "'";
            
    return sql;
}

public
void readByIds(ArrayList arrayIds){
    string sql = "select * from pltdeptmach";

    if (arrayIds.Count > 0){
        sql+= " where PDM_ID in (";
        string saux ="";
        foreach (int id in arrayIds)
            saux+= (string.IsNullOrEmpty(saux) ? "" :",") + id.ToString();

        sql += saux + ")";
    }
    
	read(sql);
}


} // class

} // namespace
