/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class EmpShiftScheduleHdrDataBaseContainer : GenericDataBaseContainer {

public
EmpShiftScheduleHdrDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from empshiftschedulehdr";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from empshiftschedulehdr";
	if (searchText.Length > 0){
		sql += " where Plant like '" + Converter.fixString(searchText) + "%'";
		sql += " or Dept like '" + Converter.fixString(searchText) + "%'";
		sql += " or Notes like '" + Converter.fixString(searchText) + "%'";
		sql += " or CreatedByEmpId like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EmpShiftScheduleHdrDataBase empShiftScheduleHdrDataBase = new EmpShiftScheduleHdrDataBase(dataBaseAccess);
		empShiftScheduleHdrDataBase.load(reader);
		this.Add(empShiftScheduleHdrDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table empshiftschedulehdr";
	truncate(sql);
}

public
void readByFilters(string sid,string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string snotes, string screatedByEmpId,int rows){
    string sql = "select * from empshiftschedulehdr";

    if (!string.IsNullOrEmpty(sid))
        sql = DBFormatter.addWhereAndSentence(sql) + " Id like '" + sid + "%'";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);

    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("Date",fromDate,toDate,false);        

    if (ishiftNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "ShiftNum =" + ishiftNum.ToString();

    if (!string.IsNullOrEmpty(sdept))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Dept",sdept);
    if (!string.IsNullOrEmpty(snotes))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Notes", snotes);
    if (!string.IsNullOrEmpty(screatedByEmpId))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CreatedByEmpId", screatedByEmpId);

    sql += " order by Date desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

} // class
} // package