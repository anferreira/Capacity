using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SchOrdMasDataBaseContainer : GenericDataBaseContainer{

private string PDM_Dept;
private string PDM_Plt;
private string PDM_Mach;

public
SchOrdMasDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
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
void setPDM_Mach(string PDM_Mach){
    this.PDM_Mach = PDM_Mach;
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.* from schordmas as A, schprfmhr as B, schmachhr as C where C.SMH_Dept = '" +
			PDM_Dept + 
			"' and (C.SMH_DRS = 'R' or C.SMH_DRS = 'S') and B.SPH_MachOrdNum = C.SMH_MachOrdNum and " +
			"A.SMO_SchVersion = B.SPH_SchVersion and A.SMO_MasPrOrd = C.SMH_MasPrOrd and A.SMO_Seq = B.SPH_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchOrdMasDataBase schOrdMasDataBase = new SchOrdMasDataBase(dataBaseAccess);
			schOrdMasDataBase.load(reader);
			this.Add(schOrdMasDataBase);
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
void truncate(){
	try{
		string sql = "delete from schordmas";
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