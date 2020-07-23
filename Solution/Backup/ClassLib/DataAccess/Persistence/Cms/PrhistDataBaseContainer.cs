using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PrhistDataBaseContainer: GenericDataBaseContainer{

public 
PrhistDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void generateProductionHistory(string smode, DateTime dateBefore, DateTime dateAfter,
								string splant, string sshift, string sdept, string sresource, 
								string spart, int seq){
	
	NotNullDataReader reader = null;

	try{
		string sql="";
		
		sql = "select dep.AAPLNT,prh.* from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary_2nd + ".";
		
		sql +=	"prhist prh, ";

		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		
		sql +=	"depts dep";


		sql +=	" where ";
		sql +=	" DWMODE = '"	+ smode		+	"' and ";
		sql +=	" DWDATE >='"	+ DateUtil.getCompleteDateRepresentation(dateBefore, DateUtil.YYYYMMDD_AS)	+	"' and ";
		sql +=	" DWDATE <='"	+ DateUtil.getCompleteDateRepresentation(dateAfter, DateUtil.YYYYMMDD_AS)	+	"'";		

		if (sshift != null){
			sql += " and DWSHFT = " + sshift;
			if (sdept != null){
				sql += " and DWDEPT = '" + sdept +	"'";
				if (sresource != null){
					sql += " and DWRESR = '" + sresource + "'";
					
					if (spart != null){
						sql += " and DWPART = '" + spart + "'";

						if (seq != 0){
							sql += " and DWSEQN = " + seq.ToString();
						}
					}
				}
			}
		}

		sql+= " and prh.DWDEPT = dep.AADEPT";

		if (splant != null)
			sql+= " and dep.AAPLNT = '" + splant + "'";
 
		sql +=  " order by dep.AAPLNT, DWSHFT, DWDEPT, DWRESR, DWPART, DWSEQN, DWDATE";	//order by field and date

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PrhistDataBase prhistDataBase = new PrhistDataBase(dataBaseAccess);
			prhistDataBase.loadForReport(reader);

			this.Add(prhistDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <generateProductionHistory> : " + other.Message, other);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary_2nd + ".";
		sql += "prhist";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			PrhistDataBase prhistDataBase = new PrhistDataBase(dataBaseAccess);
			prhistDataBase.load(reader);
			this.Add(prhistDataBase);
		}
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + other.Message, other);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList readDwdate(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(DWDATE) as DwDate from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary_2nd +".";
		
		sql += "prhist";

		reader = dataBaseAccess.executeQuery(sql);
		ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[1];
			line[0]= reader.GetDateTime("DwDate").ToShortDateString(); 
			array.Add((object)line);
		}
		
		return array;
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class PrhistDataBaseContainer : " + other.Message, other);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
void truncate(){
	try{
		string sql = "delete from prhist";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}

}//end class

}//end nanespace
