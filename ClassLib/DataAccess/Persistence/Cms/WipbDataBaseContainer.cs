using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class WipbDataBaseContainer : GenericDataBaseContainer{

public
WipbDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		WipbDataBase wipbDataBase = new WipbDataBase(dataBaseAccess);
		wipbDataBase.load(reader);
		this.Add(wipbDataBase);
	}
}

public
void read(){	
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "wipb";

	read(sql);			
}

public
void read(string[] filter){	
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
		
	sql += "wipb";

	if (filter.Length > 0){
		sql += " where VDSTOK in (";

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
	string sql = "delete from wipb";
    truncate(sql);		
}

public
void readByFilters(string skeytGreaterThan,int rows){
    string sql      = "select * from "+ getTablePrefix()  + "wipb";    
    string scastSeq = "CAST("  + getFieldDigit("VDSEQ") + " AS varchar(10))"; //3 len
    scastSeq = DBFormatter.lpad(scastSeq, 10,'0');        
    string skey     = "VDPART,"+ scastSeq + ",VDLOT,VDSTOK";
            
    if (!string.IsNullOrEmpty(skeytGreaterThan)){
        sql = DBFormatter.addWhereAndSentence(sql);
        string sfields = "Rtrim(VDPART)";                       sfields = DBFormatter.concat(sfields, "'"+ Constants.DEFAULT_SEP +"'");
        sfields = DBFormatter.concat(sfields, scastSeq);        sfields = DBFormatter.concat(sfields, "'"+ Constants.DEFAULT_SEP +"'");
        sfields = DBFormatter.concat(sfields, "Rtrim(VDLOT)");  sfields = DBFormatter.concat(sfields, "'"+ Constants.DEFAULT_SEP +"'");
        sfields = DBFormatter.concat(sfields, "Rtrim(VDSTOK)"); 
        sql+= sfields + " > '" + skeytGreaterThan + "'";
    }
            
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}

} // class

} // namespace