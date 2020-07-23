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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

    public
class LabourTypeDataBaseContainer : GenericDataBaseContainer {

public
LabourTypeDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from labourtype";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from labourtype";
	if (searchText.Length > 0){
		sql += " where Code like '" + Converter.fixString(searchText) + "%'";
		sql += " or LabName like '" + Converter.fixString(searchText) + "%'";
		sql += " or DirInd like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		LabourTypeDataBase labourTypeDataBase = new LabourTypeDataBase(dataBaseAccess);
		labourTypeDataBase.load(reader);
		this.Add(labourTypeDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table labourtype";
	truncate(sql);
}

public
void readByFilters(string scode,string slabName,string sdirInd,int rows){
    string sql = "select * from labourtype";

    if (!string.IsNullOrEmpty(scode))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("Code",scode);
    if (!string.IsNullOrEmpty(slabName))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("LabName", slabName);
    if (!string.IsNullOrEmpty(sdirInd))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("DirInd", sdirInd);

    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
                
    read(sql);
}
       

} // class
} // package