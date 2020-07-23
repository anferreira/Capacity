/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class SchMaterialAvailDataBaseContainer : GenericDataBaseContainer {

public
SchMaterialAvailDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from schmaterialavail";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from schmaterialavail";
	if (searchText.Length > 0){
		sql += " where ParentPart like '" + Converter.fixString(searchText) + "%'";
		sql += " or MaxUOM like '" + Converter.fixString(searchText) + "%'";
		sql += " or ChildSource like '" + Converter.fixString(searchText) + "%'";
		sql += " or ChildPart like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		SchMaterialAvailDataBase schMaterialAvailDataBase = new SchMaterialAvailDataBase(dataBaseAccess);
		schMaterialAvailDataBase.load(reader);
		this.Add(schMaterialAvailDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table schmaterialavail";
	truncate(sql);
}

public
void readByFilters(string splant,int parentSrcHotId,int parentSrcHotDtlId,int notParentSrcHotDtlId, string sparentPart, int partentSeq, string schildPart, int childSeq,DateTime dateTime,bool blastSeq,int rows){
    string      sql = "select * from schmaterialavail";
    DateTime    fromDate= new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,0,0,0);
    DateTime    toDate  = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,23,59,59);

    if (blastSeq){
        sql+= " , prodfminfo p ";
    }

    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant", splant);

    if (parentSrcHotId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " ParentSrcHotId =" + NumberUtil.toString(parentSrcHotId);

    if (parentSrcHotDtlId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " ParentSrcHotDtlId =" + NumberUtil.toString(parentSrcHotDtlId);

    if (notParentSrcHotDtlId > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " ParentSrcHotDtlId <>" + NumberUtil.toString(notParentSrcHotDtlId);

    if (!string.IsNullOrEmpty(sparentPart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ParentPart",sparentPart);

    if (partentSeq > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " ParentSeq =" + NumberUtil.toString(partentSeq);

    if (!string.IsNullOrEmpty(schildPart))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ChildPart", schildPart);

    if (childSeq > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " ChildSeq =" + NumberUtil.toString(childSeq);

    /*
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Plant",splant);*/

    if (blastSeq)
        sql = DBFormatter.addWhereAndSentence(sql) + "PFS_ProdID=ParentPart and PFS_SeqLast=ParentSeq";
  
    if (fromDate != DateUtil.MinValue || toDate != DateUtil.MinValue )
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("DateTime", fromDate, toDate,true);        
    
    sql += " order by ParentSrcHotId,ParentSrcHotDtlId,CounterParentSrcHotId";

	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class
} // package