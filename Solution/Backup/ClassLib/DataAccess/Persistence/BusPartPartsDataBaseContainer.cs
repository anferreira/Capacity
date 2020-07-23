/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/BusPartPartsDataBaseContainer.cs,v $ 
*   $State: Exp $ 
*   $Log: BusPartPartsDataBaseContainer.cs,v $
*   Revision 1.11  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.10  2005/05/17 04:34:51  gmuller
*   ponga aqui un comentario
*
*   Revision 1.9  2005/04/20 19:55:31  aferreira
*   *** empty log message ***
*
*   Revision 1.8  2005/03/29 19:38:42  aferreira
*   *** empty log message ***
*
*   Revision 1.7  2005/03/18 19:08:48  cmelo
*   *** empty log message ***
*
*   Revision 1.6  2005/03/18 01:41:24  cmelo
*   *** empty log message ***
*
*   Revision 1.5  2005/03/18 00:21:36  cmelo
*   *** empty log message ***
*
*   Revision 1.4  2005/03/17 02:52:42  cmelo
*   *** empty log message ***
*
*   Revision 1.3  2005/03/15 21:26:30  cmelo
*   *** empty log message ***
*
*   Revision 1.2  2005/03/15 01:10:18  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class BusPartPartsDataBaseContainer : GenericDataBaseContainer{

public
BusPartPartsDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from buspartparts";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BusPartPartsDataBase busPartPartsDataBase = new BusPartPartsDataBase(dataBaseAccess);
			busPartPartsDataBase.load(reader);
			this.Add(busPartPartsDataBase);
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

public void truncate(){
	try{
		string sql = "delete from buspartparts";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}


public 
void readByDesc(string desc,string db){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from buspartparts" +
				        " where " +
				        "BPP_Db='" + Converter.fixString(db) + "' and " +
				        "BPP_Part like '%"	+ Converter.fixString(desc) + "%' or " +
				        "BPP_BusPartnerBT like '%"	+ Converter.fixString(desc) + "%' or " +
				        "BPP_BusPartPart like '%"	+ Converter.fixString(desc) + "%' or " +
				        "BPP_BusPartnerST like '%"	+ Converter.fixString(desc) + "%' " +
		            "order by BPP_Db,BPP_Part,BPP_Sequence,BPP_BusPartnerBT,BPP_BusPartnerST" ;
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BusPartPartsDataBase busPartPartsDataBase = new BusPartPartsDataBase(dataBaseAccess);
			busPartPartsDataBase.load(reader);
			this.Add(busPartPartsDataBase);
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


public 
void readByPart(string db,string part){

	NotNullDataReader reader = null;
	try{
		string sql = "select * from buspartparts" +
				        " where " +
				        "BPP_Db='" + Converter.fixString(db) + "' and " +
				        "BPP_Part ='"	+ Converter.fixString(part) + "' " +
		            "order by BPP_BusPartnerBT,BPP_BusPartnerST,BPP_Manufacturer,BPP_BusPartPart," +
		                     "BPP_Revision" ;
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BusPartPartsDataBase busPartPartsDataBase = new BusPartPartsDataBase(dataBaseAccess);
			busPartPartsDataBase.load(reader);
			this.Add(busPartPartsDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByUPC(string upc,string db){

	NotNullDataReader reader = null;
	try{
		string sql = "select * from buspartparts" +
				        " where " +						       
				        "BPP_UPCBox ='"	+ Converter.fixString(upc) + "' or " +
						"BPP_UPCCase ='"+ Converter.fixString(upc) + "' or " +
						"BPP_UPCSkid ='"+ Converter.fixString(upc) + "' or " +
						"BPP_UPC ='"	+ Converter.fixString(upc) + "'";								

		if (db.Length > 0)
			sql+= " and BPP_Db='" + Converter.fixString(db) + "'";
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BusPartPartsDataBase busPartPartsDataBase = new BusPartPartsDataBase(dataBaseAccess);
			busPartPartsDataBase.load(reader);
			this.Add(busPartPartsDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void readByFilters(	string db, string part, int seq, string busPartnerBT,string busPartPart,
					string busPartnerST,string revision)
{
	NotNullDataReader reader = null;
	try{
		string sql = "select * from buspartparts";
				       
					if (db.Length > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";

						sql+= "BPP_Db='" + Converter.fixString(db) + "'";
					}

					if (part.Length > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";
						
						sql+= "BPP_Part='" + Converter.fixString(part) + "'";
					}

					if (seq > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";
						
						sql+= "BPP_Sequence=" + NumberUtil.toString(seq);
					}

					if (busPartnerBT.Length > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";
						
						sql+= "BPP_BusPartnerBT='" + Converter.fixString(busPartnerBT) + "'";
					}

					if (busPartnerST.Length > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";
						
						sql+= "BPP_BusPartnerST='" + Converter.fixString(busPartnerST) + "'";
					}

					if (busPartPart.Length > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";
						
						sql+= "BPP_BusPartPart='" + Converter.fixString(busPartPart) + "'";
					}

					if (busPartPart.Length > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";
						
						sql+= "BPP_BusPartPart='" + Converter.fixString(busPartPart) + "'";
					}

					if (revision.Length > 0)
					{	
						if (sql.IndexOf("where") < 0)	sql+= " where ";
						else							sql+= " and ";
						
						sql+= "BPP_Revision='" + Converter.fixString(revision) + "'";
					}
 
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BusPartPartsDataBase busPartPartsDataBase = new BusPartPartsDataBase(dataBaseAccess);
			busPartPartsDataBase.load(reader);
			this.Add(busPartPartsDataBase);
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
} // package