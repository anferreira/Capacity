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
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class DemandWeekDataBaseContainer : GenericDataBaseContainer {

public
DemandWeekDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from demandweek";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from demandweek";
	if (searchText.Length > 0){
		sql += " where Plant like '" + Converter.fixString(searchText) + "%'";
		sql += " or Source like '" + Converter.fixString(searchText) + "%'";
		sql += " or TPartner like '" + Converter.fixString(searchText) + "%'";
		sql += " or OldRelNum like '" + Converter.fixString(searchText) + "%'";
		sql += " or NewRelNum like '" + Converter.fixString(searchText) + "%'";
		sql += " or ShipLoc like '" + Converter.fixString(searchText) + "%'";
		sql += " or Part like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemandWeekDataBase demandWeekDataBase = new DemandWeekDataBase(dataBaseAccess);
		demandWeekDataBase.load(reader);
		this.Add(demandWeekDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table demandweek";
	truncate(sql);
}

public
void readByFilters(string splant,string source,string stPartner,string soldRelNum,string snewRelNum,string shipLoc,string spart,DateTime fromDate,int rows){
    string sql = "select * from  demandweek ";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);
    if (!string.IsNullOrEmpty(source))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Source",source);
    if (!string.IsNullOrEmpty(stPartner))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TPartner",stPartner);
    if (!string.IsNullOrEmpty(soldRelNum))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OldRelNum", soldRelNum);
    if (!string.IsNullOrEmpty(snewRelNum))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("NewRelNum", snewRelNum);
    if (!string.IsNullOrEmpty(shipLoc))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ShipLoc", shipLoc);
    if (!string.IsNullOrEmpty(spart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Part", spart);


    if (fromDate != DateUtil.MinValue)
        sql = DBFormatter.addWhereAndSentence(sql) + " FromDate = '" + DateUtil.getDateRepresentation(fromDate,DateUtil.MMDDYYYY) + "'";
    
    sql += " order by Plant,Source,TPartner,ShipLoc,Part,FromDate";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}


} // class
} // package