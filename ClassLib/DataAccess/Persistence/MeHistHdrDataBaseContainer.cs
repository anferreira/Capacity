using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class MeHistHdrDataBaseContainer: GenericDataBaseContainer{

public 
MeHistHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from mehisthdr";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			MeHistHdrDataBase meHistHdrDataBase = new MeHistHdrDataBase(dataBaseAccess);
			meHistHdrDataBase.load(reader);
			this.Add(meHistHdrDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class MeHistHdrDataBaseContainer : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class MeHistHdrDataBaseContainer : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

}//end class

}//end namespace
