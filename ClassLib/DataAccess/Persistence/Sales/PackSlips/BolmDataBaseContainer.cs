/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips{

public
class BolmDataBaseContainer : GenericDataBaseContainer {

public
BolmDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from " + getTablePrefix() + "bolm";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from " + getTablePrefix() + "bolm";
	if (searchText.Length > 0){
		sql += " where RAPIND like '" + Converter.fixString(searchText) + "%'";
		sql += " or RASIND like '" + Converter.fixString(searchText) + "%'";
		sql += " or RASHPL like '" + Converter.fixString(searchText) + "%'";
		sql += " or RABNME like '" + Converter.fixString(searchText) + "%'";
		sql += " or RASVIA like '" + Converter.fixString(searchText) + "%'";
		sql += " or RATKID like '" + Converter.fixString(searchText) + "%'";
		sql += " or RAROUT like '" + Converter.fixString(searchText) + "%'";
		sql += " or RADOCD like '" + Converter.fixString(searchText) + "%'";
		sql += " or RACARC like '" + Converter.fixString(searchText) + "%'";
		sql += " or RAPRTF like '" + Converter.fixString(searchText) + "%'";
		sql += " or RAPLNT like '" + Converter.fixString(searchText) + "%'";
		sql += " or RASTMZ like '" + Converter.fixString(searchText) + "%'";
		sql += " or RASBOL like '" + Converter.fixString(searchText) + "%'";
		sql += " or RABLTR like '" + Converter.fixString(searchText) + "%'";
		sql += " or RABSTS like '" + Converter.fixString(searchText) + "%'";
		sql += " or RABLAK like '" + Converter.fixString(searchText) + "%'";
		sql += " or RABSET like '" + Converter.fixString(searchText) + "%'";
		sql += " or RABLMD like '" + Converter.fixString(searchText) + "%'";
		sql += " or RASEAL like '" + Converter.fixString(searchText) + "%'";
		sql += " or RACPRO like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		BolmDataBase bolmDataBase = new BolmDataBase(dataBaseAccess);
		bolmDataBase.load(reader);
		this.Add(bolmDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table bolm";
	truncate(sql);
}

public
void readByFilters(decimal dbolid, DateTime startDate, DateTime endDate, string status, string shipVia, string struckID, string sroute,int rows){    
    string sql ="select * from " + getTablePrefix() + "bolm";
  
    //private DateTime RACDAT;
        
    if (dbolid > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "RAMBOL=" + NumberUtil.toString(dbolid);
        
    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + "RABSTS='" +Converter.fixString(status) + "'";
    if (!string.IsNullOrEmpty(shipVia))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("RASVIA", shipVia + "%");
    if (!string.IsNullOrEmpty(struckID))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("RATKID", struckID + "%");
    if (!string.IsNullOrEmpty(sroute))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("RAROUT", sroute + "%");

    sql += " order by RAMBOL desc";            
    System.Windows.Forms.MessageBox.Show("readByFilters:"+sql);
    read(sql);
}

} // class
} // package