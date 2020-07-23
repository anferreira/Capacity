using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SchMatReqDayDataBaseContainer : GenericDataBaseContainer{

public
SchMatReqDayDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqday order by SMD_MatID, SMD_MatSeq, SMD_MatReqDate";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMatReqDayDataBase schMatReqDayDataBase = new SchMatReqDayDataBase(dataBaseAccess);
			schMatReqDayDataBase.load(reader);
			this.Add(schMatReqDayDataBase);
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
void readMaterials(string startSupplier, string endSupplier, string startPart, string endPart){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqday order by SMD_MatID, SMD_MatSeq, SMD_MatReqDate";
		
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMatReqDayDataBase schMatReqDayDataBase = new SchMatReqDayDataBase(dataBaseAccess);
			schMatReqDayDataBase.load(reader);
			this.Add(schMatReqDayDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaterials> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaterials> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readMaterials> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
ArrayList readByPartDept(string[] parts, string[] depts){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqday ";
		
		if (depts.Length > 0){
			sql += " where SMD_Dept in(";
			for(int x = 0; x < depts.Length; x++){
				sql += "'" + depts[x] + "'";
				if (x == depts.Length - 1)
					sql += ")";
				else
					sql += ", ";
			}
		}
		
		if (parts.Length > 0){
			if (depts.Length > 0)
				sql += " and ";
			else
				sql += " where ";

			sql += " SMD_ProdID in(";
			for(int x = 0; x < parts.Length; x++){
				sql += "'" + parts[x] + "'";
				if (x == parts.Length - 1)
					sql += ")";
				else
					sql += ", ";
			}
		}

		if (sql.IndexOf("where") > 0)
			sql += " and ";
		else
			sql += " where ";

		sql += " SMD_Usage = 'D' ";
		sql += "order by SMD_MatID, SMD_MatReqDate, SMD_ProdID";
		
		ArrayList arrayList = new ArrayList();

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMatReqDayDataBase schMatReqDayDataBase = new SchMatReqDayDataBase(dataBaseAccess);
			schMatReqDayDataBase.load(reader);
			this.Add(schMatReqDayDataBase);
			arrayList.Add(schMatReqDayDataBase);
		}
		return arrayList;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPartDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPartDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPartDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
string[][] getPartsDueDate(string[] parts, string[] depts, bool orderByVendor){
	NotNullDataReader reader = null;
	try{
		/*string sql = "select SP_SupplierNum, SMD_ProdID, SMD_ProdSeq, SMD_MatID, " + 
			"SMD_MatSeq, SMD_MatReqDate, SMD_DemMatReq, SMD_SchMatReq, PFS_Des1" +
			" from schmatreqday, suppproductcross, prodfminfo " +
			" where SMD_MatID = SP_ProdID and SP_Priority = 1 and PFS_ProdID = SMD_MatID "; // and SMD_MatSeq = SP_Seq ";*/

		string sql = "select SP_SupplierNum, SMD_ProdID, SMD_ProdSeq, SMD_MatID, " + 
			"SMD_MatSeq, SMD_MatReqDate, SMD_DemMatReq, SMD_SchMatReq, PFS_Des1" +
			" from schmatreqday, suppproductcross, prodfminfo " +
			" where SMD_MatID = SP_ProdID and PFS_ProdID = SMD_MatID ";

		if (depts.Length > 0)
		{
			sql += " and SMD_Dept in (";
			for(int x = 0; x < depts.Length; x++){
				sql += "'" + depts[x] + "'";
				if (x == depts.Length - 1)
					sql += ") ";
				else
					sql += ", ";
			}
		}
		
		if (parts.Length > 0){
			sql += " and ";

			sql += " SMD_ProdID in (";
			for(int x = 0; x < parts.Length; x++){
				sql += "'" + parts[x] + "'";
				if (x == parts.Length - 1)
					sql += ") ";
				else
					sql += ", ";
			}
		}
		if (orderByVendor)
			sql += "order by SP_SupplierNum, SMD_MatID, SMD_MatReqDate";
		else
			sql += "order by SMD_MatID, SMD_MatReqDate";

		ArrayList array = new ArrayList();
		Hashtable mats = new Hashtable();

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){

			string matId = reader.GetString("SMD_MatID");
			DateTime matReqDate = reader.GetDateTime("SMD_MatReqDate");

			string key = matId +  ";" + DateUtil.getDateRepresentation(matReqDate, DateUtil.MMDDYYYY);
			if (mats.ContainsKey(key))
				continue;

			string[] line = new string[10];
			line[0] = reader.GetString("SP_SupplierNum");
			line[1] = reader.GetString("SMD_ProdID");
			line[2] = reader.GetInt32("SMD_ProdSeq").ToString();
			line[3] = matId;
			line[4] = reader.GetInt32("SMD_MatSeq").ToString();
			line[5] = DateUtil.getDateRepresentation(matReqDate, DateUtil.MMDDYYYY);
			line[6] = reader.GetDecimal("SMD_DemMatReq").ToString();
			line[7] = reader.GetDecimal("SMD_SchMatReq").ToString();
			line[8] = "qoh";
			line[9] = reader.GetString("PFS_Des1");
			array.Add((object)line);


			key = matId +  ";" + DateUtil.getDateRepresentation(matReqDate, DateUtil.MMDDYYYY);
			mats.Add(key, key);
		}

		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] line = (string[])en.Current;
			returnArray[index] = line;
			index++;
		}
		return returnArray;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getPartsDueDate> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByVersion(string version){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schmatreqday where " + 
			"SMD_SchVersion = '" + version + "' and SMD_Usage in ('S', 'B')";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			SchMatReqDayDataBase schMatReqDayDataBase = new SchMatReqDayDataBase(dataBaseAccess);
			schMatReqDayDataBase.load(reader);
			this.Add(schMatReqDayDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByVersion> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void truncate(){
	try	{
		string sql = "delete from schmatreqday";
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
SchMatReqDayDataBase getAndAddRecord(string version, string plt, string dept,
		string prod, int prodSeq, string mat, int matSeq, DateTime date,
		string usage){


	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		SchMatReqDayDataBase schMatReqDayDataBase = (SchMatReqDayDataBase) en.Current;

		if ((schMatReqDayDataBase.getSMD_SchVersion().Equals(version)) &&
				(schMatReqDayDataBase.getSMD_Plt().Equals(plt)) &&
				(schMatReqDayDataBase.getSMD_Dept().Equals(dept)) &&
				(schMatReqDayDataBase.getSMD_ProdID().Equals(prod)) &&
				(schMatReqDayDataBase.getSMD_ProdSeq() == prodSeq) &&
				(schMatReqDayDataBase.getSMD_MatID().Equals(mat)) &&
				(schMatReqDayDataBase.getSMD_MatSeq() == matSeq) &&
				(schMatReqDayDataBase.getSMD_MatReqDate().Equals(date))){
			
			if (!schMatReqDayDataBase.getSMD_Usage().Equals(usage))
				schMatReqDayDataBase.setSMD_Usage("B");
			
			return schMatReqDayDataBase;
		}
	}

	SchMatReqDayDataBase schMatReqDayDataBase2 = new SchMatReqDayDataBase(dataBaseAccess);
	schMatReqDayDataBase2.setSMD_SchVersion(version);
	schMatReqDayDataBase2.setSMD_Plt(plt);
	schMatReqDayDataBase2.setSMD_Dept(dept);
	schMatReqDayDataBase2.setSMD_ProdID(prod);
	schMatReqDayDataBase2.setSMD_ProdSeq(prodSeq);
	schMatReqDayDataBase2.setSMD_MatID(mat);
	schMatReqDayDataBase2.setSMD_MatSeq(matSeq);
	schMatReqDayDataBase2.setSMD_MatReqDate(date);
	schMatReqDayDataBase2.setSMD_Usage(usage);
	schMatReqDayDataBase2.setSMD_InvQty(0);
	schMatReqDayDataBase2.setSMD_POQty(0);
	schMatReqDayDataBase2.setSMD_DemMatReq(0);
	schMatReqDayDataBase2.setSMD_SchMatReq(0);
	this.Add(schMatReqDayDataBase2);

	return schMatReqDayDataBase2;
}

public
SchMatReqDayDataBase getRecord(string version, string plt, string dept,
		string prod, int prodSeq, string mat, int matSeq, DateTime date){

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		SchMatReqDayDataBase schMatReqDayDataBase = (SchMatReqDayDataBase)en.Current;

		if (
			/*(schMatReqDayDataBase.getSMD_SchVersion().Equals(version)) &&*/
				(schMatReqDayDataBase.getSMD_Plt().Equals(plt)) &&
				(schMatReqDayDataBase.getSMD_Dept().Equals(dept)) &&
				(schMatReqDayDataBase.getSMD_ProdID().Equals(prod)) &&
				(schMatReqDayDataBase.getSMD_ProdSeq() == prodSeq) &&
				(schMatReqDayDataBase.getSMD_MatID().Equals(mat)) &&
				(schMatReqDayDataBase.getSMD_MatSeq() == matSeq) &&
				(schMatReqDayDataBase.getSMD_MatReqDate().Equals(date))){
			
			return schMatReqDayDataBase;
		}
	}
	
	return null;
}

public
SchMatReqDayDataBase getRecord(string prod, int prodSeq, DateTime dateReq){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		SchMatReqDayDataBase schMatReqDayDataBase = (SchMatReqDayDataBase) en.Current;

		string d1 = DateUtil.getDateRepresentation(schMatReqDayDataBase.getSMD_MatReqDate(), DateUtil.DDMMYYYY);
		string d2 = DateUtil.getDateRepresentation(dateReq, DateUtil.DDMMYYYY);

		if ((schMatReqDayDataBase.getSMD_ProdID().Equals(prod)) &&
				(schMatReqDayDataBase.getSMD_ProdSeq() == prodSeq) &&
				(d1.Equals(d2))){
				
			return schMatReqDayDataBase;
		}
	}
	
	return null;
}

} // class

} // namespace