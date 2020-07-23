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
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Customer{

public
class TradingPartnerDataBaseContainer : GenericDataBaseContainer {

public
TradingPartnerDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from tradingpartner";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from tradingpartner";
	if (searchText.Length > 0){
		sql += " where TPartner like '" + Converter.fixString(searchText) + "%'";
		sql += " or ShipExport830 like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		TradingPartnerDataBase tradingPartnerDataBase = new TradingPartnerDataBase(dataBaseAccess);
		tradingPartnerDataBase.load(reader);		
        this.Add(tradingPartnerDataBase, tradingPartnerDataBase.getTPartner());
	}
}

public 
void truncate(){
	string sql = "truncate table tradingpartner";
	truncate(sql);
}

public
void readByFilters(string stpartner,int rows){
	string sql = "select * from tradingpartner";

    if (!string.IsNullOrEmpty(stpartner))
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("TPartner",stpartner);

    sql+= " order by TPartner";
    if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public
TradingPartnerDataBase getTPartner(string stpartner){
	int pos = getFirstElementPosition(stpartner);
	if (pos == -1)
		return null;
	else
		return (TradingPartnerDataBase)this[pos];
}

} // class
} // package