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
class ShipExportSumCompareDataBaseContainer : ShipExportSumDataBaseContainer {

public
ShipExportSumCompareDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		ShipExportSumCompareDataBase shipExportSumCompareDataBase = new ShipExportSumCompareDataBase(dataBaseAccess);
		shipExportSumCompareDataBase.load(reader);
		this.Add(shipExportSumCompareDataBase);
	}
}

public
void readByFilters(string splant,string sbillTo,string shipTo,string sbol, string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,
    bool bqtyOrder,bool bqtyShip,bool bdateReq,bool bdateShip,bool bqtyPpm, bool bleadTime, bool bppap,int irows){
    string  sql         = "select * from shipexportsum s, TEST_1 t where t.OrderNum=s.OrderNum and t.Item=s.Item and t.Release=s.Release ";
    string  sqlFilters  = readBaseFilters(splant, sbillTo, shipTo, sbol, sorder, scustPO, sdocType, srelease, orderItem, blateOrders, sppap, fromDate, toDate, irows);

    sql=   DBFormatter.addWhereAndSentence(sql) + sqlFilters.Replace("where","");            

    if (bqtyOrder)
        sql= DBFormatter.addWhereAndSentence(sql) + " s.QtyOrder <> t.QtyOrderedExcel";
    if (bqtyShip)
        sql= DBFormatter.addWhereAndSentence(sql) + " s.QtyShipped <> t.QtyShippedExcel";
    if (bdateReq)
        sql= DBFormatter.addWhereAndSentence(sql) + " CAST(s.DateRequest as date) <> CAST(t.CustRequestDateExcel as date)";
    if (bdateShip)
        sql= DBFormatter.addWhereAndSentence(sql) + " CAST(s.ShipDate as date) <> CAST(t.ShipDateExcel as date)";             
    if (bqtyPpm)
        sql= DBFormatter.addWhereAndSentence(sql) + " s.QtyPpm <> t.PPMQtyExcel";      
    if (bleadTime)
        sql= DBFormatter.addWhereAndSentence(sql) + " s.LeadTime <> t.ActLeadTimeExcel";      
    if (bppap)
        sql= DBFormatter.addWhereAndSentence(sql) + "(t.PPAPExcel <> '' and s.Ppap <> SUBSTRING(t.PPAPExcel,1,1) )";      
    
    sql += " order by s.ShipDate desc,s.OrderNum desc,s.Item";
   
    if (irows > 0)
        sql = DBFormatter.selectTopRows(sql,irows);

    read(sql);
}


} // class
} // package