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
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand{

    public
class CapShiftTaskDataBaseContainer : GenericDataBaseContainer {

public
CapShiftTaskDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from capshifttask";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from capshifttask";
	if (searchText.Length > 0){
		sql += " where TaskName like '" + Converter.fixString(searchText) + "%'";
		sql += " or DirInd like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);
		capShiftTaskDataBase.load(reader);
		this.Add(capShiftTaskDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table capshifttask";
	truncate(sql);
}

public
void readByFilters(string sid,string staskName,string sdirInd,int rows){
    string sql = "select * from capshifttask";

    if (!string.IsNullOrEmpty(sid))
        sql = DBFormatter.addWhereAndSentence(sql) + " Id like '" + sid + "%'";
 
    if (!string.IsNullOrEmpty(staskName))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TaskName", staskName);

    if (!string.IsNullOrEmpty(sdirInd))
        sql = DBFormatter.addWhereAndSentence(sql) + "DirInd='" + Converter.fixString(sdirInd) + "'";    

    sql += " order by TaskName";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

    //System.Windows.Forms.MessageBox.Show(sql);
	read(sql);
}

} // class
} // package