using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class PltInvLocDataBase : GenericDataBaseElement{

private string PL_Plt;
private string PL_Loc;
private string PL_LocName;
private string PL_Des1;
private string PL_Des2;
private string PL_Des3;
private string PL_Phone;
private string PL_Fax;
private string PL_Contact;
private string PL_InvAvail;
private DateTime PL_LastPhysical;
private string PL_HotListUse;

public
PltInvLocDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PL_Plt = reader.GetString("PL_Plt");
	this.PL_Loc = reader.GetString("PL_Loc");
	this.PL_LocName = reader.GetString("PL_LocName");
	this.PL_Des1 = reader.GetString("PL_Des1");
	this.PL_Des2 = reader.GetString("PL_Des2");
	this.PL_Des3 = reader.GetString("PL_Des3");
	this.PL_Phone  = reader.GetString("PL_Phone");
	this.PL_Fax = reader.GetString("PL_Fax");
	this.PL_Contact = reader.GetString("PL_Contact");
	this.PL_InvAvail = reader.GetString("PL_InvAvail");
	this.PL_LastPhysical = reader.GetDateTime("PL_LastPhysical");
	this.PL_HotListUse = reader.GetString("PL_HotListUse");
}

public override
void write(){
	try {
		string sql ="insert into pltinvloc values ('" +
				Converter.fixString(PL_Plt)  + "', '" + 
				Converter.fixString(PL_Loc)  + "', '" +
				Converter.fixString(PL_LocName) + "', '" +
				Converter.fixString(PL_Des1) + "', '" +
				Converter.fixString(PL_Des2) + "', '" +
				Converter.fixString(PL_Des3) + "', '" +
				Converter.fixString(PL_Phone) + "', '" +
				Converter.fixString(PL_Fax) + "', '" +
				Converter.fixString(PL_Contact) + "', '" +
				Converter.fixString(PL_InvAvail)  + "', '" +
				DateUtil.getDateRepresentation(PL_LastPhysical)  + "', '" +
				Converter.fixString(PL_HotListUse) + "')";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql ="update pltinvloc set " +
				"PL_LocName = '"+ Converter.fixString(PL_LocName) + "', " +
				"PL_Des1 = '"  + Converter.fixString(PL_Des1) + "', " +
				"PL_Des2 = '"  + Converter.fixString(PL_Des2) + "', " +
				"PL_Des3 = '"  + Converter.fixString(PL_Des3) + "', " +
				"PL_Phone = '"  + Converter.fixString(PL_Phone) + "', " +
				"PL_Fax = '"  + Converter.fixString(PL_Fax) + "', " +
				"PL_Contact = '"  + Converter.fixString(PL_Contact) + "', " +
				"PL_InvAvail = '"  + Converter.fixString(PL_InvAvail)  + "', " +
				"PL_LastPhysical = '" + DateUtil.getDateRepresentation(PL_LastPhysical) + "', " +
				"PL_HotListUse = '"  + Converter.fixString(PL_HotListUse) + "' " +
				"where " + 
					"PL_Plt = '" + PL_Plt  + "' and " + 
					"PL_Loc ='" + PL_Loc  + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete from pltinvloc " + 
			"where " + 
			"PL_Plt = '" + PL_Plt  + "' and " + 
			"PL_Loc ='" + PL_Loc  + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltinvloc " + 
			"where " + 
			"PL_Plt = '" + PL_Plt  + "' and " + 
			"PL_Loc ='" + PL_Loc  + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
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
void setPL_Plt(string PL_Plt){
	this.PL_Plt = PL_Plt;
}

public
void setPL_Loc(string PL_Loc){
	this.PL_Loc = PL_Loc;
}

public
void setPL_Des1(string PL_Des1){
	this.PL_Des1 = PL_Des1;
}

public
void setPL_Des2(string PL_Des2){
	this.PL_Des2 = PL_Des2;
}

public
void setPL_Des3(string PL_Des3){
	this.PL_Des3 = PL_Des3;
}

public
void setPL_InvAvail(string PL_InvAvail){
	this.PL_InvAvail = PL_InvAvail;
}

public
void setPL_Phone(string PL_Phone){
	this.PL_Phone = PL_Phone;
}

public
void setPL_Fax(string PL_Fax){
	this.PL_Fax = PL_Fax;
}

public
void setPL_Contact(string PL_Contact){
	this.PL_Contact = PL_Contact;
}

public
void setPL_LocName(string PL_LocName){
	this.PL_LocName = PL_LocName;
}

public
void setPL_LastPhysical(DateTime PL_LastPhysical){
	this.PL_LastPhysical = PL_LastPhysical;
}

public
void setPL_HotListUse(string PL_HotListUse){
	this.PL_HotListUse = PL_HotListUse;
}


public
string getPL_Plt(){
	return PL_Plt;
}

public
string getPL_Loc(){
	return PL_Loc;
}

public
string getPL_Des1(){
	return PL_Des1;
}

public
string getPL_Des2(){
	return PL_Des2;
}

public
string getPL_Des3(){
	return PL_Des3;
}


public
string getPL_InvAvail(){
	return this.PL_InvAvail;
}

public
string getPL_Phone(){
	return this.PL_Phone;
}

public
string getPL_Fax(){
	return this.PL_Fax;
}

public
string getPL_Contact(){
	return this.PL_Contact;
}

public
string getPL_LocName(){
	return this.PL_LocName;
}

public
DateTime getPL_LastPhysical(){
	return this.PL_LastPhysical;
}

public
string getPL_HotListUse(){
	return this.PL_HotListUse;
}

} // class

} // namespace
