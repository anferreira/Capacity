using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkbDataBaseContainer : GenericDataBaseContainer{

public
StkbDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		StkbDataBase stkbDataBase = new StkbDataBase(dataBaseAccess);
		stkbDataBase.load(reader);
		this.Add(stkbDataBase);
	}
}

public
void read(){	
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "stkb";

	read(sql);			
}

public
void read(string[] filter){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "stkb"; 

	if (filter.Length > 0){
		sql += " where BXSTOK in (";

		for(int i = 0; i < filter.Length; i++){
			sql += "'" + filter[i] + "'";
			if (i < filter.Length - 1)
				sql += ", ";
		}
		sql += ")";
	}

	read(sql);
}

public
void truncate(){	
	string sql = "delete from stkb";
    truncate(sql);	
}

public
void readByFilters(string skeytGreaterThan,int rows){
    string sql = "select * from "+ getTablePrefix()  + "stkb";
    string skey= "BXPART,BXLOT,BXSTOK,BXUNIT";
            
    if (!string.IsNullOrEmpty(skeytGreaterThan)){
        sql = DBFormatter.addWhereAndSentence(sql);
        string sfields = "Rtrim(BXPART)";                       sfields = DBFormatter.concat(sfields, "'"+ Constants.DEFAULT_SEP +"'");
        sfields = DBFormatter.concat(sfields, "Rtrim(BXLOT)");  sfields = DBFormatter.concat(sfields, "'"+ Constants.DEFAULT_SEP +"'");
        sfields = DBFormatter.concat(sfields, "Rtrim(BXSTOK)"); sfields = DBFormatter.concat(sfields, "'"+ Constants.DEFAULT_SEP +"'");
        sfields = DBFormatter.concat(sfields, "Rtrim(BXUNIT)"); sfields = DBFormatter.concat(sfields, "'"+ Constants.DEFAULT_SEP +"'");
        sql+= sfields + " > '" + skeytGreaterThan + "'";
    }
            
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class

} // namespace