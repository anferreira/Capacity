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
class ScheduleReceiptPartDataBaseContainer : GenericDataBaseContainer {

public
ScheduleReceiptPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from schedulereceiptpart";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from schedulereceiptpart";
	if (searchText.Length > 0){
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ScheduleReceiptPartDataBase scheduleReceiptPartDataBase = new ScheduleReceiptPartDataBase(dataBaseAccess);
		scheduleReceiptPartDataBase.load(reader);
		this.Add(scheduleReceiptPartDataBase);
	}
}

public
void truncate(){
	string sql = "truncate table schedulereceiptpart";
	truncate(sql);
}

public
void readByHdrAll(int id){
	string sql = "select * from schedulereceiptpart where HdrId=" + NumberUtil.toString(id) +
                " order by HdrId,Detail,SubDetail";
    read(sql);
}

public
void deleteByHdr(int id){
	string sql = "delete from schedulereceiptpart where HdrId=" + NumberUtil.toString(id);    
	delete(sql);
}


public
void readByFilters(int id,int imachId,string part,int iseq,DateTime startDate,DateTime endDate){
    string sql ="select rp.* from schedulereceiptpart rp,schedulepart p " +
                " where rp.HdrId=p.HdrId and rp.Detail = p.Detail ";

    if (id > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "rp.HdrId = " + NumberUtil.toString(id);    
    if (imachId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "p.MachId = " + NumberUtil.toString(imachId);
    if (!string.IsNullOrEmpty(part))
        sql = DBFormatter.addWhereAndSentence(sql) + "p.Part = '" + part + "'";
    if (iseq >= 0)
        sql = DBFormatter.addWhereAndSentence(sql) + "p.Seq = " + NumberUtil.toString(iseq);

    //we only check Start date
    if (startDate != DateUtil.MinValue || endDate != DateUtil.MinValue ){
        sql = DBFormatter.addWhereAndSentence(sql);
        sql+= "( ";

        if (startDate != DateUtil.MinValue)
            sql+= "rp.StartDate >= '" + DateUtil.getDateRepresentation(startDate, DateUtil.YYYYMMDD)  + "'";            
        
        if (endDate != DateUtil.MinValue){
            sql+= startDate != DateUtil.MinValue ? " and " : "";
            sql+= "rp.StartDate <= '" + DateUtil.getDateRepresentation(endDate, DateUtil.YYYYMMDD)  + "'";
        }

        sql += ")";
    }

    sql += " order by rp.StartDate";

    read(sql);
}

} // class
} // package