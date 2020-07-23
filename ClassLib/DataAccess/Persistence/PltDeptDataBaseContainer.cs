using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class PltDeptDataBaseContainer : GenericDataBaseContainer{

private string DE_Plt;

public
PltDeptDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
		pltDeptDataBase.load(reader);
		this.Add(pltDeptDataBase);
	}
}

public
void setDE_Plt(string DE_Plt){
	this.DE_Plt = DE_Plt;
}

public
void read(){
    string sql = "select * from pltdept";
    read(sql);		
}

public
string[] getDepartamentCodes(){
	NotNullDataReader reader = null;
	try{
		ArrayList array = new ArrayList();

		string sql = "select distinct(DE_Dept) from pltdept order by DE_Dept";
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read())
			array.Add(reader.GetString(0));

		string[] vec = new String[array.Count];

		int index = 0;
		IEnumerator iEnum2 = array.GetEnumerator();
		while(iEnum2.MoveNext()){
			vec[index] = iEnum2.Current.ToString();
			index++;
		}
		
		return vec;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDepartamentCodes> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDepartamentCodes> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <getDepartamentCodes> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByPlt(){
    string sql = "select * from pltdept where DE_Plt = '" + DE_Plt + "'";
    read(sql);
}

public
void truncate(){	
	string sql = "delete from pltdept";
    truncate(sql);		
}

public 
void readByDesc(string desc, string db, int company, string plt){	
	string sql = "select * from pltdept " +
			" where " +
			"(DE_Dept like '%" + Converter.fixString(desc) + "%' or " +
			"DE_Des1 like '%" + Converter.fixString(desc) + "%')";
		
	if (db.Length > 0)
		sql += " and DE_Db = '" + db + "'";

	if (company >= 0)
		sql += " and DE_Company = " + NumberUtil.toString(company);

	if (plt.Length > 0)
		sql += " and DE_Plt = '" + plt + "'";

	sql += " order by DE_Des1";
 
	read(sql);		
}
         
public 
void readByFilters(string scompany,string splant,string sdept,string sdeptDesc,int rows){	
	string sql = "select * from pltdept";

    if (!string.IsNullOrEmpty(scompany))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DE_Company",scompany);
    if (!string.IsNullOrEmpty(splant))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DE_Plt",splant);
    if (!string.IsNullOrEmpty(sdept))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DE_Dept", sdept);

    if (!string.IsNullOrEmpty(sdeptDesc))
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DE_Des1", sdeptDesc+"%");
    
	sql+= " order by DE_Company,DE_Plt,DE_Dept";
    if (rows > 0)
	   sql = DBFormatter.selectTopRows(sql,rows);
 
	read(sql);		
}

} // class

} // namespace
