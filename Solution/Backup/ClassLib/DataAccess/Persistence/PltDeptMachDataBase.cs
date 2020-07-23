using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class PltDeptMachDataBase : GenericDataBaseElement{

private string PDM_Plt;
private string PDM_Dept;
private string PDM_Mach;
private string PDM_Des1;
private string PDM_Des2;
private string PDM_Des3;
private string PDM_Des4;
private string PDM_PltInvLoc;
private string PDM_InOut;
private string PDM_MachTyp;
private string PDM_SchType;
private decimal PDM_UtilPer;
private string PDM_InvDrFr;
private string PDM_InvRecTo;
private decimal PDM_CableLn;
private string PDM_LnUom;
private decimal PDM_Speed;
private decimal PDM_MaxRacks;
private decimal PDM_DefSpaceRack;
private string PDM_DefSpaceUom;
private decimal PDM_MaxWgt;
private string PDM_MaxWgtUom;
private string PDM_MachShort;

public
PltDeptMachDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PDM_Plt = reader.GetString("PDM_Plt");
	this.PDM_Dept = reader.GetString("PDM_Dept");
	this.PDM_Mach = reader.GetString("PDM_Mach");
	this.PDM_Des1 = reader.GetString("PDM_Des1");
	this.PDM_Des2 = reader.GetString("PDM_Des2");
	this.PDM_Des3 = reader.GetString("PDM_Des3");
	this.PDM_Des4 = reader.GetString("PDM_Des4");
	this.PDM_PltInvLoc = reader.GetString("PDM_PltInvLoc");
	this.PDM_InOut = reader.GetString("PDM_InOut");
	this.PDM_MachTyp = reader.GetString("PDM_MachTyp");
	this.PDM_SchType = reader.GetString("PDM_SchType");
	this.PDM_UtilPer = reader.GetDecimal("PDM_UtilPer");
	this.PDM_InvDrFr = reader.GetString("PDM_InvDrFr");
	this.PDM_InvRecTo = reader.GetString("PDM_InvRecTo");
	this.PDM_CableLn = reader.GetDecimal("PDM_CableLn");
	this.PDM_LnUom = reader.GetString("PDM_LnUom");
	this.PDM_Speed = reader.GetDecimal("PDM_Speed");
	this.PDM_MaxRacks = reader.GetDecimal("PDM_MaxRacks");
	this.PDM_DefSpaceRack = reader.GetDecimal("PDM_DefSpaceRack");
	this.PDM_DefSpaceUom = reader.GetString("PDM_DefSpaceUom");
	this.PDM_MaxWgt = reader.GetDecimal("PDM_MaxWgt");
	this.PDM_MaxWgtUom = reader.GetString("PDM_MaxWgtUom");
	this.PDM_MachShort = reader.GetString("PDM_MachShort");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach " + 
			"where " + 
			"PDM_Plt = '" + PDM_Plt  + "' and " + 
			"PDM_Dept ='" + PDM_Dept + "' and " +
			"PDM_Mach = '" + PDM_Mach + "'";
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
void readByMach(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdeptmach " + 
			"where " + 
			"PDM_Dept ='" + PDM_Dept + "' and " +
			"PDM_Mach = '" + PDM_Mach + "'";
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

public override
void delete(){
	try{
		string sql = "delete from pltdeptmach " + 
			"where " + 
			"PDM_Plt = '" + PDM_Plt  + "' and " + 
			"PDM_Dept ='" + PDM_Dept + "' and " +
			"PDM_Mach = '" + PDM_Mach + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update pltdeptmach set " +
			"PDM_Des1 = '" + Converter.fixString(PDM_Des1) + "', " +
			"PDM_Des2 = '" + Converter.fixString(PDM_Des2) + "', " +
			"PDM_Des3 = '" + Converter.fixString(PDM_Des3) + "', " +
			"PDM_Des4 = '" + Converter.fixString(PDM_Des4) + "', " +
			"PDM_PltInvLoc = '" + Converter.fixString(PDM_PltInvLoc) + "', " +
			"PDM_InOut = '" + Converter.fixString(PDM_InOut) + "', " +
			"PDM_MachTyp = '" + Converter.fixString(PDM_MachTyp) + "', " +
			"PDM_SchType = '" + Converter.fixString(PDM_SchType) + "', " +
			"PDM_UtilPer = " + NumberUtil.toString(PDM_UtilPer) + ", " +
			"PDM_InvDrFr = '" + Converter.fixString(PDM_InvDrFr) + "', " +
			"PDM_InvRecTo = '" + Converter.fixString(PDM_InvRecTo) + "', " +
			"PDM_CableLn = " + NumberUtil.toString(PDM_CableLn) + ", " +
			"PDM_LnUom = '" + Converter.fixString(PDM_LnUom) + "', " +
			"PDM_Speed = " + NumberUtil.toString(PDM_Speed) + ", " +
			"PDM_MaxRacks = " + NumberUtil.toString(PDM_MaxRacks) + ", " +
			"PDM_DefSpaceRack = " + NumberUtil.toString(PDM_DefSpaceRack) + ", " +
			"PDM_DefSpaceUom = '" + Converter.fixString(PDM_DefSpaceUom) + "', " +
			"PDM_MaxWgt = " + NumberUtil.toString(PDM_MaxWgt) + ", " +
			"PDM_MaxWgtUom = '" + Converter.fixString(PDM_MaxWgtUom) + "', " +
			"PDM_MachShort = '" + Converter.fixString(PDM_MachShort) + "' " +
			"where " + 
			"PDM_Plt = '" + PDM_Plt  + "' and " + 
			"PDM_Dept ='" + PDM_Dept + "' and " +
			"PDM_Mach = '" + PDM_Mach + "'";
		
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
void write(){
	try{
		string sql = "insert into pltdeptmach values('" + 
			Converter.fixString(PDM_Plt) + "', '" + 
			Converter.fixString(PDM_Dept) + "', '" + 
			Converter.fixString(PDM_Mach) + "', '" + 
			Converter.fixString(PDM_Des1) + "', '" + 
			Converter.fixString(PDM_Des2) + "', '" + 
			Converter.fixString(PDM_Des3) + "', '" + 
			Converter.fixString(PDM_Des4) + "', '" + 
			Converter.fixString(PDM_PltInvLoc) + "', '" + 
			Converter.fixString(PDM_InOut) + "', '" + 
			Converter.fixString(PDM_MachTyp) + "', '" + 
			Converter.fixString(PDM_SchType) + "', " + 
			NumberUtil.toString(PDM_UtilPer) + ", '" + 
			Converter.fixString(PDM_InvDrFr) + "', '" + 
			Converter.fixString(PDM_InvRecTo) + "', " + 
			NumberUtil.toString(PDM_CableLn) + ", '" + 
			Converter.fixString(PDM_LnUom) + "', " + 
			NumberUtil.toString(PDM_Speed) + ", " + 
			NumberUtil.toString(PDM_MaxRacks) + ", " + 
			NumberUtil.toString(PDM_DefSpaceRack) + ", '" + 
			Converter.fixString(PDM_DefSpaceUom) + "', " + 
			NumberUtil.toString(PDM_MaxWgt) + ", '" + 
			Converter.fixString(PDM_MaxWgtUom)  + "', '" + 
			Converter.fixString(PDM_MachShort) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}


public
bool hasMachinesForDept(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;

		string sql = "select count(*) as cantMachine " +
		             "from pltdeptmach " + 
		             "where PDM_Plt = '" + PDM_Plt  + "' and PDM_Dept ='" +PDM_Dept + "'";
		             
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
		    int cantMachine = reader.GetInt32("cantMachine");
		    if (cantMachine >0)
		        returnValue = true;
        }
		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasMachinesForDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasMachinesForDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasMachinesForDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from pltdeptmach " + 
			"where PDM_Plt = '" + PDM_Plt  + "' and PDM_Dept ='" + 
			PDM_Dept + "' and PDM_Mach = '" + PDM_Mach + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;

		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool existsByMach(){
	NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from pltdeptmach " + 
			"where PDM_Dept ='" + 
			PDM_Dept + "' and PDM_Mach = '" + PDM_Mach + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;

		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setPDM_Plt(string PDM_Plt){
	this.PDM_Plt = PDM_Plt;
}

public
void setPDM_Dept(string PDM_Dept){
	this.PDM_Dept = PDM_Dept;
}

public
void setPDM_Mach(string PDM_Mach){
	this.PDM_Mach = PDM_Mach;
}

public
void setPDM_Des1(string PDM_Des1){
	this.PDM_Des1 = PDM_Des1;
}

public
void setPDM_Des2(string PDM_Des2){
	this.PDM_Des2 = PDM_Des2;
}

public
void setPDM_Des3(string PDM_Des3){
	this.PDM_Des3 = PDM_Des3;
}

public
void setPDM_Des4(string PDM_Des4){
	this.PDM_Des4 = PDM_Des4;
}

public
void setPDM_PltInvLoc(string PDM_PltInvLoc){
	this.PDM_PltInvLoc = PDM_PltInvLoc;
}

public
void setPDM_InOut(string PDM_InOut){
	this.PDM_InOut = PDM_InOut;
}

public
void setPDM_MachTyp(string PDM_MachTyp){
	this.PDM_MachTyp = PDM_MachTyp;
}

public
void setPDM_SchType(string PDM_SchType){
	this.PDM_SchType = PDM_SchType;
}

public
void setPDM_UtilPer(decimal PDM_UtilPer){
	this.PDM_UtilPer = PDM_UtilPer;
}

public
void setPDM_InvDrFr(string PDM_InvDrFr){
	this.PDM_InvDrFr = PDM_InvDrFr;
}

public
void setPDM_InvRecTo(string PDM_InvRecTo){
	this.PDM_InvRecTo = PDM_InvRecTo;
}

public
void setPDM_CableLn(decimal PDM_CableLn){
	this.PDM_CableLn = PDM_CableLn;
}

public
void setPDM_LnUom(string PDM_LnUom){
	this.PDM_LnUom = PDM_LnUom;
}

public
void setPDM_Speed(decimal PDM_Speed){
	this.PDM_Speed = PDM_Speed;
}

public
void setPDM_MaxRacks(decimal PDM_MaxRacks){
	this.PDM_MaxRacks = PDM_MaxRacks;
}

public
void setPDM_DefSpaceRack(decimal PDM_DefSpaceRack){
	this.PDM_DefSpaceRack = PDM_DefSpaceRack;
}

public
void setPDM_DefSpaceUom(string PDM_DefSpaceUom){
	this.PDM_DefSpaceUom = PDM_DefSpaceUom;
}

public
void setPDM_MaxWgt(decimal PDM_MaxWgt){
	this.PDM_MaxWgt = PDM_MaxWgt;
}

public
void setPDM_MaxWgtUom(string PDM_MaxWgtUom){
	this.PDM_MaxWgtUom = PDM_MaxWgtUom;
}

public
void setPDM_MachShort(string PDM_MachShort){
	this.PDM_MachShort = PDM_MachShort;
}


public
string getPDM_Plt(){
	return PDM_Plt;
}

public
string getPDM_Dept(){
	return PDM_Dept;
}

public
string getPDM_Mach(){
	return PDM_Mach;
}

public
string getPDM_Des1(){
	return PDM_Des1;
}

public
string getPDM_Des2(){
	return PDM_Des2;
}

public
string getPDM_Des3(){
	return PDM_Des3;
}

public
string getPDM_Des4(){
	return PDM_Des4;
}

public
string getPDM_PltInvLoc(){
	return PDM_PltInvLoc;
}

public
string getPDM_InOut(){
	return PDM_InOut;
}

public
string getPDM_MachTyp(){
	return PDM_MachTyp;
}

public
string getPDM_SchType(){
	return PDM_SchType;
}

public
decimal getPDM_UtilPer(){
	return PDM_UtilPer;
}

public
string getPDM_InvDrFr(){
	return PDM_InvDrFr;
}

public
string getPDM_InvRecTo(){
	return PDM_InvRecTo;
}

public
decimal getPDM_CableLn(){
	return PDM_CableLn;
}

public
string getPDM_LnUom(){
	return PDM_LnUom;
}

public
decimal getPDM_Speed(){
	return PDM_Speed;
}

public
decimal getPDM_MaxRacks(){
	return PDM_MaxRacks;
}

public
decimal getPDM_DefSpaceRack(){
	return PDM_DefSpaceRack;
}

public
string getPDM_DefSpaceUom(){
	return PDM_DefSpaceUom;
}

public
decimal getPDM_MaxWgt(){
	return PDM_MaxWgt;
}

public
string getPDM_MaxWgtUom(){
	return PDM_MaxWgtUom;
}

public
string getPDM_MachShort(){
	return PDM_MachShort;
}


} // class

} // namespace
