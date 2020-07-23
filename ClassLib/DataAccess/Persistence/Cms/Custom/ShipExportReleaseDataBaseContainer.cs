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
class ShipExportReleaseDataBaseContainer : GenericDataBaseContainer {

public
ShipExportReleaseDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from shipexportrelease";
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ShipExportReleaseDataBase shipExportReleaseDataBase = new ShipExportReleaseDataBase(dataBaseAccess);
		shipExportReleaseDataBase.load(reader);
		this.Add(shipExportReleaseDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table shipexportrelease";
	truncate(sql);
}

public
void readByHdr(string site,decimal bol,decimal bolItem){
	string sql = "select * from shipexportrelease " +
		" Site = '" + Converter.fixString(site) + "' and " +
		" Bol = " + NumberUtil.toString(bol) + " and " +
		" BolItem = " + NumberUtil.toString(bolItem) + "" +
        " order by Site,Bol,BolItem,Detail";
    read(sql);
}

public
void deleteByHdr(string site,decimal bol,decimal bolItem){
	string sql = "delete from shipexportrelease where " +
		" Site = '" + Converter.fixString(site) + "' and " +
		" Bol = " + NumberUtil.toString(bol) + " and " +
		" BolItem = " + NumberUtil.toString(bolItem);
    delete(sql);
}


} // class
} // package