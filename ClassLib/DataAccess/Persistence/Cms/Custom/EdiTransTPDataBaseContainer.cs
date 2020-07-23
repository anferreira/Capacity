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
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class EdiTransTPDataBaseContainer : GenericDataBaseContainer {

public
EdiTransTPDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from editranstp";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from editranstp";
	if (searchText.Length > 0){
		sql += " where TrPartner like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		EdiTransTPDataBase ediTransTPDataBase = new EdiTransTPDataBase(dataBaseAccess);
		ediTransTPDataBase.load(reader);
		this.Add(ediTransTPDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table editranstp";
	truncate(sql);
}

public
void lastTransTps(){
    string sql ="select* from EdiTransTP tr " +
                " where tr.Detail = (select max(Detail) from EdiTransTP tr2 where tr2.Plant = tr.Plant and tr2.TPartner = tr.TPartner) " +
                " order by tr.Plant,tr.TPartner";
    read(sql);
}

} // class
} // package