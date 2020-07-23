using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class HLMachDayCumDataBaseContainercs  : GenericDataBaseContainer{
		
public 
HLMachDayCumDataBaseContainercs(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from hlmachdaycum";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			HLMachDayCumDataBase hLMachDayCumDataBase = new HLMachDayCumDataBase(dataBaseAccess);
			hLMachDayCumDataBase.load(reader);
			this.Add(hLMachDayCumDataBase);
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

}

}
