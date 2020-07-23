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
class ShipExportDataBaseContainer : GenericDataBaseContainer {

public
ShipExportDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from shipexport";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from shipexport";
	if (searchText.Length > 0){
		sql += " where Site like '" + Converter.fixString(searchText) + "%'";
		sql += " or BillTo like '" + Converter.fixString(searchText) + "%'";
		sql += " or ShipTo like '" + Converter.fixString(searchText) + "%'";
		sql += " or OrdType like '" + Converter.fixString(searchText) + "%'";
		sql += " or Product like '" + Converter.fixString(searchText) + "%'";
		sql += " or CustPart like '" + Converter.fixString(searchText) + "%'";
		sql += " or ProdType like '" + Converter.fixString(searchText) + "%'";
		sql += " or BackFlag like '" + Converter.fixString(searchText) + "%'";
		sql += " or BackOrderFlag like '" + Converter.fixString(searchText) + "%'";
		sql += " or Market like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ShipExportDataBase shipExportDataBase = new ShipExportDataBase(dataBaseAccess);
		shipExportDataBase.load(reader);
		this.Add(shipExportDataBase);
	}
}

public 
void truncate(){
	string sql = "truncate table shipexport";
	truncate(sql);
}

public 
void readByBolIds(ArrayList array){
    string sql = "select * from shipexport";
    string sbolIds = "";

    foreach(decimal dbolId in array){
        sbolIds+= string.IsNullOrEmpty(sbolIds) ? "":",";
        sbolIds+= Convert.ToInt64(dbolId).ToString();        
    }

    if (!string.IsNullOrEmpty(sbolIds)){    
        sql+= " where Bol in (" + sbolIds + ")";
        sql+= " order by Bol desc";
        read(sql);
    }	
}

public
void readByFilters(string sbillTo,string shipTo,string smajSales,string sordType,DateTime fromShipDate,DateTime toShipDate,int irows){
    string sql = "select * from shipexport";

    if (!string.IsNullOrEmpty(sbillTo)) 
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("BillTo", sbillTo);

    if (!string.IsNullOrEmpty(shipTo)) 
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("ShipTo", shipTo);

    if (!string.IsNullOrEmpty(smajSales)) 
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("MajSales", smajSales);

   if (!string.IsNullOrEmpty(sordType)) 
        sql= DBFormatter.addWhereAndSentence(sql) + DBFormatter.equalLikeSql("OrdType",sordType);
                
    if (fromShipDate != DateUtil.MinValue || toShipDate != DateUtil.MinValue)    
        sql = DBFormatter.addWhereAndSentence(sql) + DBFormatter.getSqlRangeDates("ShipDate",fromShipDate,toShipDate);

    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,irows);

    read(sql);    
}

} // class
} // package