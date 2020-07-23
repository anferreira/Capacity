using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class MonthEndMachineStatsDataBaseContainer: GenericDataBaseContainer{

	public MonthEndMachineStatsDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from monthendmachinestats";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			MonthEndMachineStatsDataBase monthEndMachineStatsDataBase= new MonthEndMachineStatsDataBase(dataBaseAccess);
			monthEndMachineStatsDataBase.load(reader);
			this.Add(monthEndMachineStatsDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

}//end class
}//end namespace
