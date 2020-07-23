using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMachHrDataBaseContainer : GenericDataBaseContainer{

private string SCH_Dept;
private string SCH_Plt;
private string SCH_Mach;
private string SMH_SchVersion;
	
public
SchMachHrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void setSCH_Dept(string departament){
    this.SCH_Dept = departament;
}

public
void setSCH_Plt(string SCH_Plt){
    this.SCH_Plt = SCH_Plt;
}

public
void setSCH_Mach(string SCH_Mach){
    this.SCH_Mach = SCH_Mach;
}

public
void setSMH_SchVersion(string SMH_SchVersion){
    this.SMH_SchVersion = SMH_SchVersion;
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmachhr where SMH_Dept = '" +
			SCH_Dept + "' and SMH_Plt ='" + SCH_Plt + "' and SMH_Mach = '" + SCH_Mach + "'" +
			" and (SMH_DRS = 'R' or SMH_DRS = 'S') and SMH_SchVersion = '" + SMH_SchVersion + "'" +
			" order by SMH_Dept, SMH_Mach, SMH_DtShf, SMH_Shf, SMH_DRS";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMachHrDataBase schMachHrDataBase = new SchMachHrDataBase(dataBaseAccess);
			schMachHrDataBase.load(reader);
			this.Add(schMachHrDataBase);
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
void readByVersion(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmachhr where " + 
			"SMH_SchVersion ='" + SMH_SchVersion + 
			"' and (SMH_DRS = 'R' or SMH_DRS = 'S')" +
			" order by SMH_Dept, SMH_Mach, SMH_DtShf, SMH_Shf, SMH_DRS";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMachHrDataBase schMachHrDataBase = new SchMachHrDataBase(dataBaseAccess);
			schMachHrDataBase.load(reader);
			this.Add(schMachHrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from schmachhr";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}
}

} // class

} // namespace