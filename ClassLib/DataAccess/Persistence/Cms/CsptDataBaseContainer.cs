using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class CsptDataBaseContainer : GenericDataBaseContainer{

public 
CsptDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		CsptDataBase csptDataBase = new CsptDataBase(dataBaseAccess);
		csptDataBase.load(reader);
		this.Add(csptDataBase);
	}
}

public 
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "cspt";

    read(sql);
}

public 
void truncate(){
    string sql = "delete from cspt";
    truncate(sql);	
}

public
void readByFilters(string skeytGreaterThan,int rows){
    string sql = "select * from "+ getTablePrefix()  + "cspt";
    string skey= "RRPART,RRCUST";

    if (!string.IsNullOrEmpty(skeytGreaterThan)){
        sql = DBFormatter.addWhereAndSentence(sql);
        string sfields = "Rtrim(RRPART)";
        sfields = DBFormatter.concat(sfields, "Rtrim(RRCUST)");
        sql+= sfields + " > '" + skeytGreaterThan + "'";
    }
            
    sql += " order by " + skey;
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
    
	read(sql);
}



}//end class

}//end namespace
