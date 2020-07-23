using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActSubDataBaseContainer : GenericDataBaseContainer{

public
ProdFmActSubDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    while(reader.Read()){
		ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
		prodFmActSubDataBase.load(reader);
		this.Add(prodFmActSubDataBase,prodFmActSubDataBase.getPC_ProdID());
	}
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub order by PC_ProdID,PC_Seq,PC_RoutingType desc";

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
void readForBomOnlyByProd(string prodId,string splant){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub where PC_ProdId = '" + prodId + "'";
        if (!string.IsNullOrEmpty(splant))
              sql+= " and PC_Plt='" + splant  + "'";
        sql += " order by PC_ProdID,PC_Seq,PC_RoutingType desc";

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
                " order by PC_ProdID,PC_Seq,PC_RoutingType desc";

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
		string sql ="select * from prodfmactsub where PC_ProdID in (select distinct(DEDT_ProdId) from DemDetail) " +
                    " order by PC_ProdID,PC_Seq,PC_RoutingType desc";

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
ProdFmActSubDataBase getProdFmActSub(string part, int seq,string splant){
	int pos = getFirstElementPosition(part);
	if (pos == -1)
		return null;

	for(; pos < this.Count; pos++){
		ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) this[pos];
		if (part.Equals(prodFmActSubDataBase.getPC_ProdID()) && (seq == prodFmActSubDataBase.getPC_Seq())  && splant.ToUpper().Equals(prodFmActSubDataBase.getPC_Plt().ToUpper()))
			return prodFmActSubDataBase;
	}
	return null;
}

public
ProdFmActSubDataBaseContainer getProdFmActSubContainer(string part){
	ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) en.Current;
		if (prodFmActSubDataBase.getPC_ProdID().Trim().Equals(part.Trim()) && prodFmActSubDataBase.getPC_RoutingType().Equals(Routing.ROUTING_TYPE_MAIN)) //AF 2020-04-23 checking onyl for Main routing, because if Alternative included, could be duplicates
			prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);
	}
	return prodFmActSubDataBaseContainer;
}

public
void readByPart(string part, string seq){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from prodfmactsub where PC_ProdID = '" + part + "' and PC_Seq = " + seq +
                     " order by PC_ProdID,PC_Seq,PC_RoutingType desc";

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
		string sql ="select * from prodfmactsub where PC_ProdID = '" + productCode + "' and " +
		            "PC_Dept = '" + department + "' " +
                    " order by PC_ProdID,PC_Seq,PC_RoutingType desc";

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

public
void readByFilters(string sprodId,int seq,int imachineId,string splant,string sroutingType,bool blabToolInvolved,bool borderByMachine,int rows){            		
    string sql = "select * from prodfmactsub";
    
    if (!string.IsNullOrEmpty(sprodId))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_ProdID",sprodId);
    if (seq >=0)
        sql = DBFormatter.addWhereAndSentence(sql) + " PC_Seq = "+ NumberUtil.toString(seq);

    if (!string.IsNullOrEmpty(sroutingType))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_RoutingType",sroutingType);
            
    if (imachineId > 0){                            
        sql = DBFormatter.addWhereAndSentence(sql) + " exists (" +
            " select m.PDM_ID from pltdeptmach m " +
            " where  m.PDM_ID = " + imachineId + 
            " and m.PDM_Plt = PC_Plt and m.PDM_Dept = PC_Dept and m.PDM_Mach=PC_Cfg " +
            " )";
    }

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_Plt", splant);

    if (blabToolInvolved) //check if exists labour configurated for that routing
        sql = DBFormatter.addWhereAndSentence(sql) + " exists ( select HdrId from ProdFmactSubLabTool where HdrId=PC_Id)";
    
    if (borderByMachine)
        sql += " order by PC_Cfg,PC_ProdID,PC_Seq";
    else
        sql += " order by PC_ProdID,PC_Seq,PC_RoutingType desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

public
void readByFilters(string PC_ProdID,string PC_Plt,string PC_Dept,int PC_Seq,string PC_Cfg,string PC_RoutingType, bool blabToolInvolved, int rows){
    string sql = "select * from prodfmactsub";

    if (!string.IsNullOrEmpty(PC_ProdID))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_ProdID",PC_ProdID);
    if (!string.IsNullOrEmpty(PC_Plt))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_Plt", PC_Plt);
    if (!string.IsNullOrEmpty(PC_Dept))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_Dept", PC_Dept);
    if (PC_Seq >=0)
        sql = DBFormatter.addWhereAndSentence(sql) + "PC_Seq =" + NumberUtil.toString(PC_Seq);
    if (!string.IsNullOrEmpty(PC_Cfg))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_Cfg", PC_Cfg);
    if (!string.IsNullOrEmpty(PC_RoutingType))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PC_RoutingType", PC_RoutingType);
    
    if (blabToolInvolved) //check if exists labour configurated for that routing
        sql = DBFormatter.addWhereAndSentence(sql) + " exists ( select HdrId from ProdFmactSubLabTool where HdrId=PC_Id)";

    sql += " order by PC_ProdID,PC_Seq,PC_RoutingType desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

public
void deleteByFilter(string splant){
    string sql = "delete from prodfmactsub";
        
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + "PC_Plt='" + splant +"'";                       

	delete(sql);
}

public
void deleteByPart(string spart,string splant){
	string sql = "delete from prodfmactsub where PC_ProdID = '" + spart + "' and PC_Plt='" + splant + "'";
    delete(sql);		
}

public
void updateOptRunQty(){
    string sql ="update ProdFmActSub set PC_OptRunQty " +
                " = (SELECT ISNULL(MAX(PFS_OptimRunPurchSize),0) AS OptRunQty FROM prodfminfo WHERE PFS_ProdID = PC_ProdID)";
    update(sql);
}

} // class

}