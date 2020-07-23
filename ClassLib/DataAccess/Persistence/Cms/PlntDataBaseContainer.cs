using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PlntDataBaseContainer : GenericDataBaseContainer{

public 
PlntDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PlntDataBase plntDataBase = new PlntDataBase(dataBaseAccess);
		plntDataBase.load(reader);
		this.Add(plntDataBase);
	}
}

public 
void read(){
	string sql = "select * from ";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		sql += Configuration.CMSLibrary + ".";
	sql += "plnt";

    read(sql);
}

public 
void truncate(){
	string sql = "delete from plnt";
	truncate(sql);	
}


} // class

} // namespace