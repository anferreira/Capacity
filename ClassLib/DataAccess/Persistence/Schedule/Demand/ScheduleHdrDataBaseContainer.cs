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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand{

public
class ScheduleHdrDataBaseContainer : GenericDataBaseContainer {

public
ScheduleHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from schedulehdr";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from schedulehdr";
	if (searchText.Length > 0){
		sql += " where Status like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);
		scheduleHdrDataBase.load(reader);
		this.Add(scheduleHdrDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table schedulehdr";
	truncate(sql);
}

public
void readByFilters(string sid,string splant,string status,int icapacityHdr, int ihotListId,DateTime fromDate,DateTime toDate,int rows){
    string sql = "select * from schedulehdr";

    if (!string.IsNullOrEmpty(sid))
        sql = DBFormatter.addWhereAndSentence(sql) + " Id like '" + sid + "%'";
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);

    if (icapacityHdr > 0){
        sql = DBFormatter.addWhereAndSentence(sql) + 
        " exists (select HdrId from schedulepart where HdrId=Id and CapacityHdrId = " + NumberUtil.toString(icapacityHdr) + " ) ";        
    }

    if (ihotListId > 0){
        sql = DBFormatter.addWhereAndSentence(sql) +
        " exists (select HdrId from schedulepart where HdrId=Id and HotListId = " + NumberUtil.toString(ihotListId) + " ) ";
    }

    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("DateCreated",fromDate,toDate,false);        
    
    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Status", status + "%");

    sql += " order by Id desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

} // class
} // package