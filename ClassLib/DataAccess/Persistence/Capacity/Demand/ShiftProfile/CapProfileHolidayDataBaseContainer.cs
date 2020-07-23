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
class CapProfileHolidayDataBaseContainer : GenericDataBaseContainer {

public
CapProfileHolidayDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capprofileholiday";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capprofileholiday";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapProfileHolidayDataBase capProfileHolidayDataBase = new CapProfileHolidayDataBase(dataBaseAccess);
		capProfileHolidayDataBase.load(reader);
		this.Add(capProfileHolidayDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table capprofileholiday";
	truncate(sql);
}

public
void readByFilters(string sid,string splant,string sholType,DateTime startDate,DateTime endDate,int rows){
    string sql = "select * from capprofileholiday ";

    if (!string.IsNullOrEmpty(sid))
        sql = DBFormatter.addWhereAndSentence(sql) + " Id like '" + sid + "%'";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + "Plant='" + Converter.fixString(splant) + "'"; 
 
 
    if (!string.IsNullOrEmpty(sholType))
        sql = DBFormatter.addWhereAndSentence(sql) + "HolidayType='" + Converter.fixString(sholType) + "'"; 

    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("StartDate", startDate,endDate);         

    sql += " order by StartDate desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);

}

public
void readIfHoliday(string splant,DateTime date,int rows){
    string sql = "select * from capprofileholiday ";

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + "Plant='" + Converter.fixString(splant) + "'";  
     
    if (date != DateUtil.MinValue){
        DateTime dateTo = date;
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("StartDate","EndDate",date,dateTo,false);        
    }    

    sql += " order by StartDate desc";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);

}

} // class
} // package