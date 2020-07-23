using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActSubDataBaseContainer : GenericDataBaseContainer{

public
ProdFmActSubDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.load(reader);
			this.Add(prodFmActSubDataBase, prodFmActSubDataBase.getPC_ProdID());
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
void readForBomOnlyByProd(string prodId){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub where PC_ProdId = '" + prodId + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.load(reader);
			this.Add(prodFmActSubDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBomOnlyByProd> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBomOnlyByProd> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBomOnlyByProd> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByFamilyCode(string productCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.* " +
				 " from prodfmactsub as A, prodfminfo as B where " + 
				" PFS_ProdID = '" + productCode + "' and PFS_FamProd ='F' and " + 
				" PFS_ProdID = PC_ProdID " +
				" order by PFS_ProdID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.load(reader);
			this.Add(prodFmActSubDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamilyCode> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamilyCode> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamilyCode> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from prodfmactsub";
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
void readForBom(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub where PC_ProdID in (select distinct(DEDT_ProdId) from DemDetail)";

		Hashtable control = new Hashtable();
		
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.load(reader);
			if (!control.ContainsKey(prodFmActSubDataBase.getPC_ProdID())){
				this.Add(prodFmActSubDataBase, prodFmActSubDataBase.getPC_ProdID());
				control.Add(prodFmActSubDataBase.getPC_ProdID(), prodFmActSubDataBase.getPC_ProdID());
			}
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readForBom> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
ProdFmActSubDataBase getProdFmActSub(string part){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) en.Current;
		if (prodFmActSubDataBase.getPC_ProdID().Trim().Equals(part.Trim()))
			return prodFmActSubDataBase;
	}
	return null;
}

public
ProdFmActSubDataBase getProdFmActSub(string part, int seq){
	int pos = getFirstElementPosition(part);
	if (pos == -1)
		return null;

	for(; pos < this.Count; pos++){
		ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) this[pos];
		if (part.Equals(prodFmActSubDataBase.getPC_ProdID()) && (seq == prodFmActSubDataBase.getPC_Seq()))
			return prodFmActSubDataBase;
	}
	return null;
}

public
ProdFmActSubDataBaseContainer getProdFmActSubContainer(string part){
	ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) en.Current;
		if (prodFmActSubDataBase.getPC_ProdID().Trim().Equals(part.Trim()))
			prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);
	}
	return prodFmActSubDataBaseContainer;
}

public
void readByPart(string part, string seq){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub where PC_ProdID = '" + part + "' and PC_Seq = " + seq;

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.load(reader);
			this.Add(prodFmActSubDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPart> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByProdAndDept(string productCode, string department){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub where PC_ProdID = '" + productCode + "' and " +
		             "PC_Dept = '" + department + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
			prodFmActSubDataBase.load(reader);
			this.Add(prodFmActSubDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdAndDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdAndDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProdAndDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

} // class

}