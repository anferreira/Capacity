using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class ShiftDayDetailDataBaseContainer : GenericDataBaseContainer{

private string db;
private int company;
private string shf;
private string plt;
private string dept;

public
ShiftDayDetailDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shiftdaydetail";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftDayDetailDataBase shiftDayDetailDataBase = new ShiftDayDetailDataBase(dataBaseAccess);
			shiftDayDetailDataBase.load(reader);
			this.Add(shiftDayDetailDataBase);
		}
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByPltDeptShf(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from shiftdaydetail where " +
			"SDS_Db = '" + db + "' and " +
			"SDS_Company = " + NumberUtil.toString(company) + " and " +
			"SDS_Plt = '" + plt + "' and " +
			"SDS_Dept = '" + dept + "' and " +
			"SDS_Shf = '" + shf + "'";

		reader = dataBaseAccess.executeQuery(sql);
		while(reader.Read()){
			ShiftDayDetailDataBase shiftDayDetailDataBase = new ShiftDayDetailDataBase(dataBaseAccess);
			shiftDayDetailDataBase.load(reader);
			this.Add(shiftDayDetailDataBase);
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
void setDb(string db){
	this.db = db;
}

public
void setCompany(int company){
	this.company = company;
}

public
void setShf(string shf){
	this.shf = shf;
}

public 
void setPlt(string plt){
	this.plt = plt;
}

public 
void setDept(string dept){
	this.dept = dept;
}

} // class

} // namespace