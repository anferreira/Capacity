/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class RacaDataBaseContainer : GenericDataBaseContainer {

public
RacaDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from raca";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from raca";
	if (searchText.Length > 0){
		sql += " where QFREAS like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		RacaDataBase racaDataBase = new RacaDataBase(dataBaseAccess);
		racaDataBase.load(reader);
		this.Add(racaDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table raca";
	truncate(sql);
}

public
void readByFiltersTransfer(decimal dkeyGreaterThan,int rows){
    string sql = "select * from "+ getTablePrefix()  + "raca";
    string skey= getFieldDigit("QFENT");
                
    if (dkeyGreaterThan > 0)
        sql = DBFormatter.addWhereAndSentence(sql) + " " + skey + " > " + NumberUtil.toString(dkeyGreaterThan);
                   
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class
} // package