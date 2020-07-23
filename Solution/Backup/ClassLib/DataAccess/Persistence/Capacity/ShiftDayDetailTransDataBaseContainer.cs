using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public class ShiftDayDetailTransDataBaseContainer : GenericDataBaseContainer{

private string SDDT_Db;
private int SDDT_Company;
private string SDDT_Plt;
private string SDDT_Dept;
private string SDDT_Shf;
private DateTime SDDT_ShfAcTrnDte;
private DateTime SDDT_ShfStrTrnDte;

public ShiftDayDetailTransDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void readByPltDeptShf(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shiftdaydetailtrans where " +
					"SDDT_Db = '" + SDDT_Db +"' and " +
					"SDDT_Company = " + NumberUtil.toString(SDDT_Company) + " and " +
					"SDDT_Plt = '" + SDDT_Plt +"' and " +
					"SDDT_Dept = '" + SDDT_Dept +"' and " +
					"SDDT_Shf = '" + SDDT_Shf +"'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftDayDetailTransDataBase shiftDayDetailTransDataBase = new ShiftDayDetailTransDataBase(dataBaseAccess);
			shiftDayDetailTransDataBase.load(reader);
			this.Add(shiftDayDetailTransDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptShf> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptShf> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptShf> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByPltDeptShfEndStartTime(DateTime dateStr,DateTime dateEnd){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shiftdaydetailtrans where " +
					"SDDT_Db = '" + SDDT_Db +"' and " +
					"SDDT_Company = '" + NumberUtil.toString(SDDT_Company) +"' and " +
					"SDDT_Plt = '" + SDDT_Plt +"' and " +
					"SDDT_Dept = '" + SDDT_Dept +"' and " +
					"SDDT_Shf = '" + SDDT_Shf +"' and " +
					"SDDT_ShfAcTrnDte BETWEEN  '" + DateUtil.getDateRepresentation(dateStr) +"' and " +
					"'" + DateUtil.getDateRepresentation(dateEnd) +"'";

				
		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftDayDetailTransDataBase shiftDayDetailTransDataBase = new ShiftDayDetailTransDataBase(dataBaseAccess);
			shiftDayDetailTransDataBase.load(reader);
			this.Add(shiftDayDetailTransDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptShfEndStartTime> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptShfEndStartTime> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByPltDeptShfEndStartTime> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
string getSDDT_Db(){
   return SDDT_Db;
}

public
int getSDDT_Company(){
   return SDDT_Company;
}

public
string getSDDT_Plt(){
   return SDDT_Plt;
}

public
string getSDDT_Dept(){
   return SDDT_Dept;
}

public
string getSDDT_Shf(){
   return SDDT_Shf;
}

public
DateTime getSDDT_ShfAcTrnDte(){
   return SDDT_ShfAcTrnDte;
}

public
DateTime getSDDT_ShfStrTrnDte(){
   return SDDT_ShfStrTrnDte;
}



//setters
public void setSDDT_Db(string SDDT_Db){
   this.SDDT_Db = SDDT_Db;
}

public void setSDDT_Company(int SDDT_Company){
   this.SDDT_Company = SDDT_Company;
}

public void setSDDT_Plt(string SDDT_Plt){
   this.SDDT_Plt = SDDT_Plt;
}

public void setSDDT_Dept(string SDDT_Dept){
   this.SDDT_Dept = SDDT_Dept;
}

public void setSDDT_Shf(string SDDT_Shf){
   this.SDDT_Shf = SDDT_Shf;
}

public void setSDDT_ShfAcTrnDte(DateTime SDDT_ShfAcTrnDte){
   this.SDDT_ShfAcTrnDte = SDDT_ShfAcTrnDte;
}

public void setSDDT_ShfStrTrnDte(DateTime SDDT_ShfStrTrnDte){
   this.SDDT_ShfStrTrnDte = SDDT_ShfStrTrnDte;
}



}//end class
}//end namespace
