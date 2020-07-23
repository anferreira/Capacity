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
class EmpShiftScheduleHdrSumViewDataBaseContainer : GenericDataBaseContainer {

public
EmpShiftScheduleHdrSumViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
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
		EmpShiftScheduleHdrSumViewDataBase empShiftScheduleHdrSumViewDataBase = new EmpShiftScheduleHdrSumViewDataBase(dataBaseAccess);
		empShiftScheduleHdrSumViewDataBase.load(reader);
		this.Add(empShiftScheduleHdrSumViewDataBase);
	}
}

public
void readByFilters(string splant, DateTime fromDate,DateTime toDate,int ishiftNum,string sdept,string screatedByEmpId,int rows){
    string sql ="select h.Date,h.ShiftNum,e.EmpId, 1 as EmployeeCount " +
                " from EmpShiftScheduleHdr as h, EmpShiftScheduleDtl e where h.Id=e.HdrId"; 
    
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);

    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("Date",fromDate,toDate,false);
        
    if (ishiftNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "ShiftNum =" + ishiftNum.ToString();

    if (!string.IsNullOrEmpty(sdept))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Dept",sdept);
    if (!string.IsNullOrEmpty(screatedByEmpId))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("CreatedByEmpId", screatedByEmpId);

    sql+= " group by h.Date,h.ShiftNum,e.EmpId order by h.Date,h.ShiftNum,e.EmpId";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

} // class
} // package