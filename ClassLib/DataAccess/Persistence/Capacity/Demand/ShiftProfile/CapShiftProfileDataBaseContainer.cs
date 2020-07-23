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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

public
class CapShiftProfileDataBaseContainer : GenericDataBaseContainer {

public
CapShiftProfileDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capshiftprofile";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capshiftprofile";
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
		CapShiftProfileDataBase capShiftProfileDataBase = new CapShiftProfileDataBase(dataBaseAccess);
		capShiftProfileDataBase.load(reader);
		this.Add(capShiftProfileDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table capshiftprofile";
	truncate(sql);
}

public
void readByFilters(string sid,string splant,int ishiftNum,string status,DateTime startDate,DateTime endDate,int ishiftTaskId,string shiftDefault,int rows){
    string sql = "select * from capshiftprofile as ch";

    if (!string.IsNullOrEmpty(sid))
        sql = DBFormatter.addWhereAndSentence(sql) + " Id like '" + sid + "%'";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + "Plant='" + Converter.fixString(splant) + "'"; 
 
    if (ishiftNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " ShiftNum =" + NumberUtil.toString(ishiftNum);

    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + "Status='" + Converter.fixString(status) + "'"; 

    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("StartDate","EndDate",startDate,endDate,false);         

    if (ishiftTaskId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " exists ( " +
              " select cd.HdrId from capshiftprofileDtl as cd where cd.HdrId = ch.Id and cd.ShiftTaskId = " + NumberUtil.toString(ishiftTaskId) + ")";

    if (!string.IsNullOrEmpty(shiftDefault))
        sql = DBFormatter.addWhereAndSentence(sql) + "ShiftDefault='" + Converter.fixString(shiftDefault) + "'"; 

    sql += " order by Id desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);

}

public
void readByFiltersExactlyDates(string splant,int ishiftNum,string status,DateTime startDate,DateTime endDate){
    string sqlTotal = "select ch.* from capshiftprofile as ch where ch.Id in ";
    string sql =  "select max(ch2.Id) from capshiftprofile as ch2 ";
    
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + "ch2.Plant='" + Converter.fixString(splant) + "'";

    if (ishiftNum > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "ch2.ShiftNum =" + NumberUtil.toString(ishiftNum);

    if (!string.IsNullOrEmpty(status))
        sql = DBFormatter.addWhereAndSentence(sql) + "ch2.Status='" + Converter.fixString(status) + "'";

    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue ){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql+= "( ";
        
        if (startDate != DateUtil.MinValue)
            sql+= DBFormatter.compareDate("ch2.StartDate") + " = '" + DateUtil.getDateRepresentation(startDate, DateUtil.YYYYMMDD)  + "'";            
        
        if (endDate != DateUtil.MinValue){
            sql+= startDate != DateUtil.MinValue ? " and " : "";
            sql+= DBFormatter.compareDate("ch2.EndDate") + "= '" + DateUtil.getDateRepresentation(endDate, DateUtil.YYYYMMDD)  + "'";
        }

        sql += ")";
    }

    sqlTotal += " (" + sql  + " )";
    	
    //System.Windows.Forms.MessageBox.Show(sqlTotal);
	read(sqlTotal);
}

public
void updateDefaults(string splant,int id,int shiftNum,string shiftDefault){
	string sql ="update capshiftprofile set ShiftDefault= '" + Converter.fixString(shiftDefault) + "'" +
                " where Plant = '" + Converter.fixString(splant) + "'" +
                " and Id <> " + id.ToString() + " and ShiftNum=" + shiftNum.ToString();
    update(sql);
}

} // class
} // package