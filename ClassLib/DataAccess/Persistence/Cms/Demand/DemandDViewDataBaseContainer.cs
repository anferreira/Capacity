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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class DemandDViewDataBaseContainer : GenericDataBaseContainer {

public
DemandDViewDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		DemandDViewDataBase demandDViewDataBase = new DemandDViewDataBase(dataBaseAccess);
		demandDViewDataBase.load(reader);
		this.Add(demandDViewDataBase);
	}
}

public
void readByFiltersGroupBy(int id,string source,string stimecode,string stpartner,string sbillTo,string shipTo,string spart,bool baddAuthorization,bool baddTimeCode, int irows){    
    string  sqlSelect =     baddAuthorization ? "FaAutCum" : " (select 0.0) as FaAutCum";
            sqlSelect+="," +(baddAuthorization ? "MaAutCum" : " (select 0.0) as MaAutCum");
    string  saddGroupBy = baddAuthorization ? ",FaAutCum,MaAutCum":"";

    sqlSelect   += baddTimeCode ? ",TimeCode" : ",'' as TimeCode";
    saddGroupBy += baddTimeCode ? ",TimeCode" : "";

    string sql = "select Source,Part,CustPart,BillTo,ShipTo,ShipLoc,SDate,Sum(NetQty) NetQty,PFS_SeqLast, " + sqlSelect +
                ",(select Sum(IPL_Qoh) from prodfminfo, invpltloc where Part = PFS_ProdID and PFS_ProdID = IPL_ProdID and IPL_Seq = PFS_SeqLast) as Qoh " +
                " from demandd " +
                " left outer join prodfminfo on PFS_ProdID=Part " +
                " where HdrId = " + id.ToString() + " and NetQty <> 0 and Part <> '' and Discard = '" + Constants.STRING_NO +"'";
                   
    if (!string.IsNullOrEmpty(source))
        sql+= " and Source = '" + Converter.fixString(source) + "'";
    if (!string.IsNullOrEmpty(stimecode))
        sql+= " and TimeCode = '" + Converter.fixString(stimecode) + "'";            
    if (!string.IsNullOrEmpty(stpartner))
        sql+= " and TPartner = '" + Converter.fixString(stpartner) + "'";
    if (!string.IsNullOrEmpty(sbillTo))
        sql+= " and BillTo = '" + Converter.fixString(sbillTo) + "'";
    if (!string.IsNullOrEmpty(shipTo))
        sql+= " and ShipTo = '" + Converter.fixString(shipTo) + "'";
    if (!string.IsNullOrEmpty(spart))
        sql+= " and Part like  '"+ Converter.fixString(spart) + "%'";

    sql +=
                    " group by Source,Part,CustPart,BillTo,ShipTo,ShipLoc,SDate,PFS_SeqLast " + saddGroupBy +
                    " order by Part,ShipTo,Source,SDate";
    
    if (irows > 0)
		sql = DBFormatter.selectTopRows(sql, irows);
	read(sql);
}

} // class
} // package