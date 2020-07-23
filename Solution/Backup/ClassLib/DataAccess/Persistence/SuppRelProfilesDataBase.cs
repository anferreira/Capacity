using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class SuppRelProfilesDataBase : GenericDataBaseElement{

private int ID;
private string SRP_ReleaseProfile;
private string SRP_ProfileDesc;
private string SRP_DelforYN;
private string SRP_DeljitYN;
private string SRP_KanbanYN;
private int SRP_JITDays;
private int SRP_JITWeeks;
private int SRP_JITMonths;
private int SRP_DELDays;
private int SRP_DELWeeks;
private int SRP_DELMonths;
private DateTime SRP_DateCrt;
private string SRP_UserCrt;
private DateTime SRP_DateUpd;
private string SRP_UserUpd;

public
SuppRelProfilesDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.SRP_ReleaseProfile = reader.GetString("SRP_ReleaseProfile");
	this.SRP_ProfileDesc = reader.GetString("SRP_ProfileDesc");
	this.SRP_DelforYN = reader.GetString("SRP_DelforYN");
	this.SRP_DeljitYN = reader.GetString("SRP_DeljitYN");
	this.SRP_KanbanYN = reader.GetString("SRP_KanbanYN");
	this.SRP_JITDays = reader.GetInt32("SRP_JITDays");
	this.SRP_JITWeeks = reader.GetInt32("SRP_JITWeeks");
	this.SRP_JITMonths = reader.GetInt32("SRP_JITMonths");
	this.SRP_DELDays = reader.GetInt32("SRP_DELDays");
	this.SRP_DELWeeks = reader.GetInt32("SRP_DELWeeks");
	this.SRP_DELMonths = reader.GetInt32("SRP_DELMonths");
	this.SRP_DateCrt = reader.GetDateTime("SRP_DateCrt");
	this.SRP_UserCrt = reader.GetString("SRP_UserCrt");
	this.SRP_DateUpd = reader.GetDateTime("SRP_DateUpd");
	this.SRP_UserUpd = reader.GetString("SRP_UserUpd");
}

public override
void write(){
	throw new PersistenceException("Method not implemented");
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setID(int ID){
	this.ID = ID;
}

public
void setSRP_ReleaseProfile(string SRP_ReleaseProfile){
	this.SRP_ReleaseProfile = SRP_ReleaseProfile;
}

public
void setSRP_ProfileDesc(string SRP_ProfileDesc){
	this.SRP_ProfileDesc = SRP_ProfileDesc;
}

public
void setSRP_DelforYN(string SRP_DelforYN){
	this.SRP_DelforYN = SRP_DelforYN;
}

public
void setSRP_DeljitYN(string SRP_DeljitYN){
	this.SRP_DeljitYN = SRP_DeljitYN;
}

public
void setSRP_KanbanYN(string SRP_KanbanYN){
	this.SRP_KanbanYN = SRP_KanbanYN;
}

public
void setSRP_JITDays(int SRP_JITDays){
	this.SRP_JITDays = SRP_JITDays;
}

public
void setSRP_JITWeeks(int SRP_JITWeeks){
	this.SRP_JITWeeks = SRP_JITWeeks;
}

public
void setSRP_JITMonths(int SRP_JITMonths){
	this.SRP_JITMonths = SRP_JITMonths;
}

public
void setSRP_DELDays(int SRP_DELDays){
	this.SRP_DELDays = SRP_DELDays;
}

public
void setSRP_DELWeeks(int SRP_DELWeeks){
	this.SRP_DELWeeks = SRP_DELWeeks;
}

public
void setSRP_DELMonths(int SRP_DELMonths){
	this.SRP_DELMonths = SRP_DELMonths;
}

public
void setSRP_DateCrt(DateTime SRP_DateCrt){
	this.SRP_DateCrt = SRP_DateCrt;
}

public
void setSRP_UserCrt(string SRP_UserCrt){
	this.SRP_UserCrt = SRP_UserCrt;
}

public
void setSRP_DateUpd(DateTime SRP_DateUpd){
	this.SRP_DateUpd = SRP_DateUpd;
}

public
void setSRP_UserUpd(string SRP_UserUpd){
	this.SRP_UserUpd = SRP_UserUpd;
}


public
int getID(){
	return ID;
}

public
string getSRP_ReleaseProfile(){
	return SRP_ReleaseProfile;
}

public
string getSRP_ProfileDesc(){
	return SRP_ProfileDesc;
}

public
string getSRP_DelforYN(){
	return SRP_DelforYN;
}

public
string getSRP_DeljitYN(){
	return SRP_DeljitYN;
}

public
string getSRP_KanbanYN(){
	return SRP_KanbanYN;
}

public
int getSRP_JITDays(){
	return SRP_JITDays;
}

public
int getSRP_JITWeeks(){
	return SRP_JITWeeks;
}

public
int getSRP_JITMonths(){
	return SRP_JITMonths;
}

public
int getSRP_DELDays(){
	return SRP_DELDays;
}

public
int getSRP_DELWeeks(){
	return SRP_DELWeeks;
}

public
int getSRP_DELMonths(){
	return SRP_DELMonths;
}

public
DateTime getSRP_DateCrt(){
	return SRP_DateCrt;
}

public
string getSRP_UserCrt(){
	return SRP_UserCrt;
}

public
DateTime getSRP_DateUpd(){
	return SRP_DateUpd;
}

public
string getSRP_UserUpd(){
	return SRP_UserUpd;
}


} // class

} // namespace