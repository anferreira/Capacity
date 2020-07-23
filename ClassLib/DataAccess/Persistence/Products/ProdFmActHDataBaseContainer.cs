using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActHDataBaseContainer : GenericDataBaseContainer{

public
ProdFmActHDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
		prodFmActHDataBase.load(reader);
		this.Add(prodFmActHDataBase);
	}
}

public
void readByFilters(string spart,int iseq,string splant,string sreportingPoint){
	string sql      = "select * from prodfmacth";
    string sqlSub   = "";
     
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PAH_ProdID",spart);    
    if (iseq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " PAH_Seq = " + NumberUtil.toString(iseq);

    if (!string.IsNullOrEmpty(sreportingPoint)){
        sqlSub   = "select PC_ProdID from prodFmActSub where PC_ProdID=PAH_ProdID and PC_Seq=PAH_Seq and PC_RepPoint ='" + Converter.fixString(sreportingPoint) + "'";

        if (!string.IsNullOrEmpty(splant))
            sqlSub = DBFormatter.addWhereAndSentence(sqlSub) + DBFormatter.equalLikeSql("PC_Plt", splant);

        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" + sqlSub + ")";
    }

    sql+= " order by PAH_ProdID,PAH_Seq desc";

    read(sql);    
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmacth";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
			prodFmActHDataBase.load(reader);
			this.Add(prodFmActHDataBase);
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
void readByFamily(string productCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select A.*" +
			" from prodfmacth as A, prodfminfo as B where " +
			"PFS_ProdID = '" + 	productCode + "' and PFS_FamProd = 'F' and " +
			" PAH_ProdId = PFS_ProdId" + 
			"order by PFS_ProdID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
			prodFmActHDataBase.load(reader);
			this.Add(prodFmActHDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByFamily> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readAllProdMaxSeq(){
	NotNullDataReader reader = null;
	try{
		string sql = "select PAH_ProdID, max(PAH_Seq) from prodfmacth" +
			" group by PAH_ProdID order by PAH_ProdID";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
			prodFmActHDataBase.specialLoad(reader);
			this.Add(prodFmActHDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllProdMaxSeq> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllProdMaxSeq> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readAllProdMaxSeq> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readWithInv(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmacth where PAH_ProdID in " + 
			"(select distinct(IPL_ProdID) from InvPltLoc)";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
			prodFmActHDataBase.load(reader);
			this.Add(prodFmActHDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readWithInv> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readWithInv> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readWithInv> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByProduct(string productCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmacth where PAH_ProdID = '" + productCode + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ProdFmActHDataBase prodFmActHDataBase = new ProdFmActHDataBase(dataBaseAccess);
			prodFmActHDataBase.load(reader);
			this.Add(prodFmActHDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByProduct> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	try{
		string sql = "delete from prodfmacth";
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
ProdFmActHDataBaseContainer getByProd(string prod){
	ProdFmActHDataBaseContainer prodFmActHDataBaseContainer = new ProdFmActHDataBaseContainer(dataBaseAccess);

	int pos = this.getFirstElementPosition(prod);
	if (pos > -1){
		for(; (pos < this.Count); pos++){
			ProdFmActHDataBase prodFmActHDataBase = (ProdFmActHDataBase) this[pos];
			
			if (prodFmActHDataBase.getPAH_ProdID().Trim().Equals(prod.Trim()))
				prodFmActHDataBaseContainer.Add(prodFmActHDataBase);
			else
				break;
		}
	}
	return prodFmActHDataBaseContainer;
}

public
void deleteByPart(string spart){
	string sql = "delete from prodfmacth where PAH_ProdID = '" + spart + "'";
    delete(sql);		
}

public
void deleteByPartList(Hashtable hashtProdfmactByPart){    
    string  spart = "";
	string  sql = "delete from prodfmacth";
    string  spartList = "";

    foreach (DictionaryEntry entry in hashtProdfmactByPart){
        spart = (string)entry.Value;
        spartList+= string.IsNullOrEmpty(spartList)  ? "" : ",";
        spartList+="'" + spart + "'";
    }
    
    if (!string.IsNullOrEmpty(spartList)){
        sql+= "  where PAH_ProdID in ( " + spartList + ")";
        delete(sql);	
    }
}


} // class

} // namespace