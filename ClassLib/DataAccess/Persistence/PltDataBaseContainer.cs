using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


/// <summary>
/// Represents the Plant table
/// </summary>
public 
class PltDataBaseContainer : GenericDataBaseContainer{

/// <summary>
/// Constructor
/// </summary>
/// <param name="dataBaseAccess"></param>
public
PltDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
		pltDataBase.load(reader);
		this.Add(pltDataBase);
	}
}

/// <summary>
/// Read method, reads all records from Plt table
/// </summary>
public
void read(){
	string sql = "select * from plt";
	read(sql);
}

/// <summary>
/// Read method, reads all records from Plt table by desc of Plt
/// </summary>
public
void readByDesc(string desc){	
	string sql = "select * from plt" +
		" where (P_Plt like '%" + Converter.fixString(desc) + "%') or " +
		"(P_PltName like '%" + Converter.fixString(desc) + "%') or " +
		"(P_Ads1 like '%" + Converter.fixString(desc) + "%') or " +
		"(P_Ads2 like '%" + Converter.fixString(desc) + "%') or " +
		"(P_Ads3 like '%" + Converter.fixString(desc) + "%') or " +
		"(P_Ads4 like '%" + Converter.fixString(desc) + "%') or " +
		"(P_PltShort like '%" + Converter.fixString(desc) + "%')"; 

	read(sql);		
}

/// <summary>
/// Truncates the Plt table
/// </summary>
public
void truncate(){
	string sql = "delete from plt";
	truncate(sql);	
}

} // class

} // namespace
