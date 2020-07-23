using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ProdFmActPlanDtDataBaseContainer : GenericDataBaseContainer{

public
ProdFmActPlanDtDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = new ProdFmActPlanDtDataBase(dataBaseAccess);
		prodFmActPlanDtDataBase.load(reader);		
		this.Add(prodFmActPlanDtDataBase);
	}
}

public void read(){
	string sql = "select * from prodfmactplandt";
	read(sql);
}

public void readByFamilyPart(string part){
	string sql = "select * from prodfmactplandt where PFPD_FamCfg = '" + Converter.fixString(part) +"'";
	read(sql);
}

public 
string[][] readByDesc(string desc){
	NotNullDataReader reader = null;
	string[][] v = null;
	try{
		string sql = "select distinct * from prodfmactplandt where PFPD_FamCfg like '%" + desc + "%' order by PFPD_FamCfg";
		             
		reader = dataBaseAccess.executeQuery(sql);
		
		ArrayList array = new ArrayList();
		
		while(reader.Read()){
			string[] line = new string[10];
			line[0] = reader.GetString("PFPD_FamCfg").Trim();
			line[1] = reader.GetInt32("PFPD_FamSeq").ToString();
			line[2] = reader.GetString("PFPD_ProdID").Trim();
			line[3] = reader.GetDecimal("PFPD_Seq").ToString();
			line[4] = reader.GetDecimal("PFPD_Qty").ToString();
			line[5] = reader.GetString("PFPD_InvUom").Trim();
			line[6] = reader.GetDecimal("PFPD_QtyAvail").ToString();
			line[7] = reader.GetString("PFPD_ShutYN").Trim();
			line[8] = reader.GetDecimal("PFPD_MinQty").ToString();
			line[9] = reader.GetDecimal("PFPD_MaxQty").ToString();
			
			array.Add(line);	
		}
		
		v = new string[array.Count][];
		int i = 0;
		IEnumerator en = array.GetEnumerator();
		while(en.MoveNext()){
			v[i] = (string[]) en.Current;
			i += 1;
		}
				
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
	
	return v;
}

public 
string[][] readPartsByFamilyPart(string family){
	NotNullDataReader reader = null;
	string[][] v = null;
	try{
		string sql = "select pi.PFS_ProdID, pi.PFS_Des1, pi.PFS_SeqLast from prodfmactplandt pm, prodfminfo pi " +
		             "where pm.PFPD_FamCfg = '" + Converter.fixString(family) + "' and pi.PFS_ProdID = PFPD_ProdID " +
		             "order by PFPD_FamCfg";
		             
		reader = dataBaseAccess.executeQuery(sql);
		
		v = new string [4][];
		
		int i = 0;
		while(reader.Read() && (i < 4)){
			string[] line = new string[3];
			line[0] = reader.GetString("PFS_ProdID").Trim();
			line[1] = reader.GetString("PFS_Des1").Trim();
			line[2] = reader.GetInt32("PFS_SeqLast").ToString();
			
			v[i] = line;
			i += 1;
		}
		
		while(i < 4){
			string[] line = new string[3];
			line[0] = "";
			line[1] = "";
			line[2] = "";
			
			v[i] = line;
			i += 1;
		}		
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readPartsByFamilyPart> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readPartsByFamilyPart> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readPartsByFamilyPart> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
	
	return v;
}

public 
void truncate(){	
	string sql = "delete from prodfmactplandt";
    truncate(sql);	
}

public
void readByFamily(string famCode){
	string sql = "select * " +
				" from prodfmactplandt where " + 
			" PFPD_FamCfg = '" + famCode + "'";
    read(sql);
}

public
void readByFilters(string sfamCfg, int ifamSeq,string spart,int iseq,int rows){
    string sql = "select * from prodfmactplandt";
    
    if (!string.IsNullOrEmpty(sfamCfg))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PFPD_FamCfg", sfamCfg);
    if (ifamSeq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "PFPD_FamSeq = " + NumberUtil.toString(ifamSeq);

    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("PFPD_ProdID", spart);
    if (iseq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "PFPD_Seq = " + NumberUtil.toString(iseq);
    
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}


} // class

}
