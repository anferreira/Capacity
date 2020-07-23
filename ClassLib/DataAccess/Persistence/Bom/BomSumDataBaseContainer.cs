using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class BomSumDataBaseContainer : GenericDataBaseContainer{


public
BomSumDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.load(reader);
		this.Add(bomSumDataBase);
	}
}

public
void read(){
	string sql = "select * from bomsum";
    read(sql);            
}

public
void readByFamId(string productCode){	
	string sql = "select B.* " +
	" from prodfminfo as A, bomsum as B " +
	"where PFS_ProdID = '" + Converter.fixString(productCode) + "' and PFS_FamProd = 'F' and " +
	"BMS_ProdID = PFS_ProdID "; 
		
    read(sql);	
}

public
void readByProdId(string prodId){	
	string sql = "select * from bomsum where BMS_ProdID = '" + Converter.fixString(prodId) + "'";
	read(sql);		
}

public
void readForMaterials(string prodId, int seqId){	
	string sql = "";
	if (seqId != 0){
		sql = "select * from bomsum, prodfminfo where " + 
			"BMS_ProdID = '" + Converter.fixString(prodId) + "' and BMS_Seq = " + seqId + " and " +
			"BMS_MatID = PFS_ProdId and PFS_InvStatus = 'A'";
	}else{
		sql = "select * from bomsum, prodfmInfo where BMS_ProdID = '" + Converter.fixString(prodId) + "' and " +
			"BMS_MatID = PFS_ProdId and PFS_InvStatus = 'A'";
	}

	read(sql);	
}

public
void readParentMaterials(string matId, int seqId){	
	string sql = "";
	if (seqId != 0)
		sql = "select * from bomsum where BMS_MatID = '" + Converter.fixString(matId) + "' and " +
			"BMS_MatSeq = " + seqId;
	else
		sql = "select * from bomsum where BMS_MatID = '" + Converter.fixString(matId) + "'";

	read(sql);		
}

public
void truncate(){	
	string sql = "delete from bomsum";
	truncate(sql);	
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

public
void deleteByPart(string spart){
    string sql = "delete from bomsum where BMS_ProdID = '" + Converter.fixString(spart) + "'";
    delete(sql);
}

public
void deleteByPartList(Hashtable hashtBomSumByPart){    
    string  spart = "";
	string  sql = "delete from bomsum";
    string  spartList = "";

    foreach (DictionaryEntry entry in hashtBomSumByPart){
        spart = (string)entry.Value;
        spartList+= string.IsNullOrEmpty(spartList)  ? "" : ",";
        spartList+="'" + Converter.fixString(spart) + "'";
    }
    
    if (!string.IsNullOrEmpty(spartList)){
        sql+= "  where BMS_ProdID in ( " + spartList + ")";
        delete(sql);	
    }
}



public
ArrayList readByDisctinctPartSeq(){
	NotNullDataReader   reader = null;
    ArrayList           array = new ArrayList();
	try{
		string sql ="select BMS_ProdID,BMS_Seq from bomsum " +
                   " where BMS_ProdID not in ( select b2.BMS_MatID from bomsum b2) " +
                   " group by BMS_ProdID,BMS_Seq order by BMS_ProdID, BMS_Seq";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
		    string [] sline = new string[2];
            sline[0] = reader.GetString("BMS_ProdID");
            sline[1] = reader.GetInt32("BMS_Seq").ToString();

            array.Add(sline);
		}

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDisctinctPartSeq> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDisctinctPartSeq> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDisctinctPartSeq> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
    return array;
}

} // class

} // namespace