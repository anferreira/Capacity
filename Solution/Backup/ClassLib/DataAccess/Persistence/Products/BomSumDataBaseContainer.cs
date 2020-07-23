using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class BomSumDataBaseContainer : GenericDataBaseContainer{


public
BomSumDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from bomsum";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
			bomSumDataBase.load(reader);
			this.Add(bomSumDataBase);
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
void readByFamId(string productCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select B.* " +
		" from prodfminfo as A, bomsum as B " +
		"where PFS_ProdID = '" + productCode + "' and PFS_FamProd = 'F' and " +
		"BMS_ProdID = PFS_ProdID "; 
		
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
			bomSumDataBase.load(reader);
			this.Add(bomSumDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamId> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamId> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamId> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByProdId(string prodId){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from bomsum where BMS_ProdID = '" + prodId + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
			bomSumDataBase.load(reader);
			this.Add(bomSumDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdId> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdId> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdId> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readForMaterials(string prodId, int seqId){
	NotNullDataReader reader = null;
	try{
		string sql = "";
		if (seqId != 0){
			sql = "select * from bomsum, prodfminfo where " + 
				"BMS_ProdID = '" + prodId + "' and BMS_Seq = " + seqId + " and " +
				"BMS_MatID = PFS_ProdId and PFS_InvStatus = 'A'";
		}else{
			sql = "select * from bomsum, prodfmInfo where BMS_ProdID = '" + prodId + "' and " +
				"BMS_MatID = PFS_ProdId and PFS_InvStatus = 'A'";
		}

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
			bomSumDataBase.load(reader);
			this.Add(bomSumDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForMaterials> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForMaterials> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForMaterials> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readParentMaterials(string matId, int seqId){
	NotNullDataReader reader = null;
	try{
		string sql = "";
		if (seqId != 0)
			sql = "select * from bomsum where BMS_MatID = '" + matId + "' and " +
				"BMS_MatSeq = " + seqId;
		else
			sql = "select * from bomsum where BMS_MatID = '" + matId + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
			bomSumDataBase.load(reader);
			this.Add(bomSumDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readParentMaterials> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readParentMaterials> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readParentMaterials> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from bomsum";
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
string[][] getErrorsBom(){
	NotNullDataReader reader  = null;
	NotNullDataReader readerAux = null;

	try{
		System.Collections.ArrayList array = new ArrayList();

		string sql = "SELECT BMS_ProdID, BMS_MatID, PFS_InvStatus " +
				 	 "FROM bomsum, prodfminfo WHERE " +
					 "BMS_ProdID = PFS_ProdID AND PFS_PartType = 'M' AND " +
					 "(bomsum.BMS_ProdID NOT IN (SELECT PC_ProdId FROM prodfmactsub))";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string[] line = new string[4];
			line[0] = reader.GetString(0);
			line[1] = reader.GetString(1);
			line[2] = reader.GetString(2);
			line[3] = "Parent Part does not have Routing Entries";
			array.Add(line);
		}

		reader.Close();
		reader = null;

		sql = "SELECT BMS_ProdID, BMS_MatID, PFS_InvStatus " +
			  "FROM bomsum, prodfminfo WHERE " +
			  "BMS_MatID = PFS_ProdID AND PFS_PartType = 'M'";

		reader = dataBaseAccess.executeQuery(sql);

		Hashtable materialHash = new Hashtable();
		while (reader.Read()){
			string val = reader.GetString(0) + ";" + reader.GetString(1) + ";" + reader.GetString(2);
            if (!materialHash.ContainsKey(val))
			    materialHash.Add(val, val);
		}
		
		reader.Close();
		reader = null;

		IEnumerator iEnum = materialHash.Values.GetEnumerator(); 
		while(iEnum.MoveNext()){
		
			string v = (string)iEnum.Current;
			string[] vAux = v.Split(';');

			sql = "SELECT BMS_MatID " +
				"FROM bomsum WHERE " +
				"BMS_ProdID = '" + vAux[1] + "' AND " +
				"BMS_ProdID NOT IN (SELECT PC_ProdId FROM prodfmactsub)";

			reader = dataBaseAccess.executeQuery(sql);
			while(reader.Read())
			{
				string[] line = new string[4];
				line[0] = vAux[0];
				line[1] = vAux[1];
				line[2] = vAux[2];
				line[3] = "Material Part does not have Routing Entries";
				array.Add(line);
			}

			reader.Close();
			reader = null;
		}

		int index = 0;
		string[][] result = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext();){
			string[] line = (string[])en.Current;
			result[index] = line;
			index++;
		}

		return result;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getErrorsBom> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getErrorsBom> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getErrorsBom> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (readerAux != null)
			readerAux.Close();
		if (reader != null)
			reader.Close();
	}
}

} // class

} // namespace