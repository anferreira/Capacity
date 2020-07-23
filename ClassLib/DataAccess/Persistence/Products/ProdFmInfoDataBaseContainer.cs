using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmInfoDataBaseContainer : GenericDataBaseContainer{

public
ProdFmInfoDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.load(reader);
		this.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());
	}
}

public
void read(){
    string sql = "select * from prodfminfo";
    read(sql);
}

public 
void readByDescOrId(string desc, string retailProductType){
	
	string sql = "select * from prodfminfo " +
		" where ((PFS_Des1 like '%" + Converter.fixString(desc) + "%') or " +
		"(PFS_Des2 like '%" + Converter.fixString(desc) + "%') or " +
		"(PFS_Des3 like '%" + Converter.fixString(desc) + "%') or " +
		"(PFS_ProdID like '%" + Converter.fixString(desc) + "%'))"; 
 
	if (retailProductType.Length > 0)
		sql += " and PFS_RetailProductType = '" + Converter.fixString(retailProductType) + "'";

	sql += " order by PFS_Des1";

    read(sql);		
}

public 
string readDescByProdId(string prod){
	NotNullDataReader reader = null;
	
	try{
		string sql = "select PFS_Des1 from prodfminfo " +
			" where (PFS_ProdID = '" + Converter.fixString(prod) + "')"; 
 
		reader = dataBaseAccess.executeQuery(sql);

		string result = "";
		if (reader.Read()){
			result = reader.GetString(0);
		}

		return result;
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
void readByProdId(string prod){	
	string sql = "select * from prodfminfo " +
		" where (PFS_ProdID like '%" + Converter.fixString(prod) + "%')";     
    read(sql);		
}

public 
void readByProdIdAndFamily(string prod, bool family){	
	string sql = "select * from prodfminfo " +
		" where (PFS_ProdID like '%" + Converter.fixString(prod) + "%') and (PFS_InvStatus = 'A')"; 
	if(family)
		sql += " and (PFS_FamProd = 'F')";
	else
		sql += " and (PFS_FamProd = 'P')";
 
	read(sql);		
}

public
void readByDesc(string desc){	
	string sql = "select * from prodfminfo " +
		" where (PFS_Des1 like '%" + Converter.fixString(desc) + "') or " +
		"(PFS_Des2 like '%" + Converter.fixString(desc) + "') or " +
		"(PFS_Des3 like '%" + Converter.fixString(desc) + "')";
 
	read(sql);		
}

// return all product codes from products table
public
string[] getProductCodes(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(PFS_ProdID) from prodfminfo " +
			" where PFS_FamProd = 'P'";
		ArrayList array = new ArrayList();

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string prod = reader.GetString(0);
			array.Add(prod);
		}

		object[] auxVector = array.ToArray();
		string[] returnVector = new String[auxVector.Length];
		for(int i = 0; i < auxVector.Length; i++){
			returnVector[i] = (string)auxVector[i];
		}

		return returnVector;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getProductCodes> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getProductCodes> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getProductCodes> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
string[] getManufacturedProductCodes(string plantCode){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(A.PFS_ProdID) from " +
			"prodfminfo as A, prodfmactsub as B " +
			" where " +
			"A.PFS_ProdId = B.PC_ProdId and " +
			"B.PC_Plt = '" + plantCode + "' and " +
			"A.PFS_FamProd = 'P' and A.PFS_PartType = 'M' and " +
			"A.PFS_InvStatus = 'A' " +
			"order by A.PFS_ProdID";
		ArrayList array = new ArrayList();

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string prod = reader.GetString(0);
			array.Add(prod);
		}

		object[] auxVector = array.ToArray();
		string[] returnVector = new String[auxVector.Length];
		for(int i = 0; i < auxVector.Length; i++){
			returnVector[i] = (string)auxVector[i];
		}

		return returnVector;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getManufacturedProductCodes> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getManufacturedProductCodes> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getManufacturedProductCodes> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

// return all family codes from products table
public
string[] getProductFamilyCodes(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(PFS_ProdID) from prodfminfo " +
			" where PFS_FamProd = 'F' and " +
			"A.PFS_InvStatus = 'A' " +
			"order by A.PFS_ProdID";
		ArrayList array = new ArrayList();
		
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			string prod = reader.GetString(0);
			array.Add(prod);
		}

		object[] auxVector = array.ToArray();
		string[] returnVector = new String[auxVector.Length];
		for(int i = 0; i < auxVector.Length; i++){
			returnVector[i] = (string)auxVector[i];
		}

		return returnVector;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getProductFamilyCodes> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getProductFamilyCodes> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getProductFamilyCodes> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void truncate(){
	string sql = "delete from prodfminfo";
	truncate(sql);	
}

public
ProdFmInfoDataBase getProdFmInfo(string part){
	int pos = getFirstElementPosition(part);
	if (pos == -1)
		return null;
	else
		return (ProdFmInfoDataBase)this[pos];
}

public
void readForReport(string infMayGroup,string infMinGroup,string supMayGroup,string supMinGroup, string[] prodsID){	
	string sql = "Select * from prodfminfo "  +
		    "where PFS_MajorGroup between '" + infMayGroup + "' and '" + 	supMayGroup +"' " +
			"and PFS_MinorGroup between '" + infMinGroup + "' and '" + supMinGroup  +"'"; 
		 
	if ((prodsID.Length>0)&&(prodsID != null)){
			sql += " and PFS_ProdID in (";
			for(int i = 0; i < prodsID.Length; i++){
				sql += "'" + prodsID[i] + "'";
				if (i < prodsID.Length - 1)
					sql += ", ";
			}
			sql +=") ";
	}
	sql +=" Order by PFS_MajorGroup, PFS_MinorGroup";
	read(sql);
}

public
string[] readMajorGroup(string major){
	NotNullDataReader reader = null;
	try{
		string sql = "Select distinct PFS_MajorGroup from prodfminfo ";
		
		if (!major.Equals(""))
		        sql +="where PFS_MajorGroup >'" +Converter.fixString(major) +"' " ;
        
        sql += "Group by PFS_MajorGroup "  +		        
               "Order by PFS_MajorGroup";
		
		reader = dataBaseAccess.executeQuery(sql);
		
	    ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[1];
			line[0] = reader.GetString(0);
			array.Add((object)line);
		}	
		
		int index = 0;
		string[] returnArray = new string[array.Count];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray[0];
			index++;
		}
		return returnArray;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMajorGroup> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMajorGroup> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMajorGroup> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
string[] readMinorGroup(){
	NotNullDataReader reader = null;
	try{
		string sql = "Select distinct PFS_MinorGroup from prodfminfo ";
		
	    sql += "Group by PFS_MinorGroup "  +		        
               "Order by PFS_MinorGroup";
		
		reader = dataBaseAccess.executeQuery(sql);
		
	    ArrayList array = new ArrayList();
		while(reader.Read()){
			string[] line = new string[1];
			line[0] = reader.GetString(0);
			array.Add((object)line);
		}	
		
		int index = 0;
		string[] returnArray = new string[array.Count];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray[0];
			index++;
		}
		return returnArray;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMinorGroup> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMinorGroup> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMinorGroup> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList readGLExps(){
	NotNullDataReader reader = null;
	try{
		string sql = "select distinct(PFS_GLExp) from prodfminfo where PFS_GLExp is not null and LEN(PFS_GLExp) > 0 order by PFS_GLExp";			
		reader = dataBaseAccess.executeQuery(sql);
		
	    ArrayList array = new ArrayList();
		while(reader.Read())			
			array.Add(reader.GetString(0));
		
		return array;

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readGLExp> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readGLExp> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readGLExp> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByFilters(string sprodId,string sdes1,int imachineId,string smajGroup,string stype,int rows){
    string sql = "select * from prodfminfo";

    if (!string.IsNullOrEmpty(sprodId))
        sql = DBFormatter.addWhereAndSentence(sql) + " PFS_ProdID like '" + sprodId + "'";
    if (!string.IsNullOrEmpty(sdes1))
        sql = DBFormatter.addWhereAndSentence(sql) + " PFS_Des1 like '" + sdes1 + "'";

    if (imachineId > 0){                            
        sql = DBFormatter.addWhereAndSentence(sql) + " PFS_ProdID in (" +
            " select b.PC_ProdID from pltdeptmach m, prodfmactsub b " +
            " where m.PDM_Plt = b.PC_Plt and m.PDM_Dept = b.PC_Dept and m.PDM_Mach=PC_Cfg " +
            " and m.PDM_ID = " + imachineId + ")";            
    }

    if (!string.IsNullOrEmpty(smajGroup))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PFS_MajorGroup",smajGroup);
    if (!string.IsNullOrEmpty(stype))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PFS_PartType", stype);    
    
    sql += " order by PFS_ProdID";
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class

} // namespace