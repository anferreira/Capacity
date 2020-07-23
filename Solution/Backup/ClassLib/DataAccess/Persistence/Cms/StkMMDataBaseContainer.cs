using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkMMDataBaseContainer : GenericDataBaseContainer{

public
StkMMDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		sql += "stkmm";

		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE && Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2))
			sql += " left join " + Configuration.CMSLibrary + ".stka on " + Configuration.CMSLibrary + ".stkmm.AVPART = " + Configuration.CMSLibrary + ".stka.V6PART and " + Configuration.CMSLibrary + ".stka.V6PLNT = '" + Configuration.DftPlant + "'";

		sql += " order by ";
		
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE && Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2))
			sql += Configuration.CMSLibrary + ".stkmm.AVPART";
		else
			sql += "AVPART";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			StkMMDataBase stkMMDataBase = new StkMMDataBase(dataBaseAccess);
			stkMMDataBase.load(reader);
			this.Add(stkMMDataBase, stkMMDataBase.getAVPART());
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(System.Exception exc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + exc.Message, exc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from stkmm";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}

} // class

} // namespace