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


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Reports{

    public
class RP1268DDataBaseContainer : GenericDataBaseContainer {

public
RP1268DDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	string sql = "select * from " + getTablePrefix3() + "rp1268d";
	read(sql);
}

public
void readByDesc(string searchText, int rows){
	string sql = "select * from rp1268d";
	if (searchText.Length > 0){
		sql += " where Part like '" + Converter.fixString(searchText) + "%'";
	}
	if (rows > 0)
		sql = DBFormatter.selectTopRows(sql,rows);
	read(sql);
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		RP1268DDataBase rP1268DDataBase = new RP1268DDataBase(dataBaseAccess);
		rP1268DDataBase.load(reader);
		this.Add(rP1268DDataBase);
	}
}

public
void truncate(){
	try{
		string sql = "delete from rp1268d";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}
}

public
void deleteExceptId(int id){
	string sql ="delete from " + getTablePrefix3() + "rp1268d " +
                " where HdrId <> " + NumberUtil.toString(id);
	delete(sql);
}

} // class
} // package