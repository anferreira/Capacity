using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkMMDataBaseContainer : GenericDataBaseContainer{

public
StkMMDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		StkMMDataBase  stkMMDataBase = new StkMMDataBase(dataBaseAccess);
		stkMMDataBase.load(reader);
		this.Add(stkMMDataBase);
	}
}

public
void read(){	
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "stkmm";

	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE && Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2))
		sql += " left join " + Configuration.CMSLibrary + ".stka on " + Configuration.CMSLibrary + ".stkmm.AVPART = " + Configuration.CMSLibrary + ".stka.V6PART and " + Configuration.CMSLibrary + ".stka.V6PLNT = '" + Configuration.DftPlant + "'";

	sql += " order by ";
		
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE && Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2))
		sql += Configuration.CMSLibrary + ".stkmm.AVPART";
	else
		sql += "AVPART";

    read(sql);		
}

public
void truncate(){
	string sql = "delete from stkmm";
    truncate(sql);
}

public
void readByFilters(string savpartGreaterThan,string splant,int rows){
    string sql = "select * from "+ getTablePrefix()  +"stkmm";
            
    if (!string.IsNullOrEmpty(splant))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("AVDPLT",splant);

    if (!string.IsNullOrEmpty(savpartGreaterThan))
        sql = DBFormatter.addWhereAndSentence(sql) + " AVPART > '" + savpartGreaterThan + "'";

    sql+= " order by AVPART";
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);

	read(sql);
}


} // class

} // namespace