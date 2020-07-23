/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo$ 
*   $Date 15-04-2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/StktDataBase.cs,v $ 
*   $State: Exp $ 


/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class StktDataBase : GenericDataBaseElement {

private string BYPART;
private string BYLOT;
private string BYSTOK;
private string BYACTN;
private decimal BYQTY;
private DateTime BYTDAT;
private string BYJREF;
private string BYIREF;
private string BYLREF;
private string BYPREF;
private string BYTRST;
private decimal BYTRAN;
private string BYSRC;
private string BYREAS;
private string BYDREF;
private decimal BYSEQ;
private string BYBUNT;
private decimal BYTQTY;
private string BYTUNT;
private string BYA1;
private decimal BYPGQT;
private decimal BYPSQT;
private DateTime BYSDAT;
private DateTime BYSTIM;
// Columns that belongs to the 5.1 version of cmsdat.
private string BYUSER;
private int BYFSYY;
private int BYFSPR;
private string BYPLNT;
private string BYFUT1A;
private string BYFUT2A;
private string BYFUT3A;
private string BYFUT4A;
private string BYFUT5A;
private string BYFUT6A;
private decimal BYFUT1N;
private decimal BYFUT2N;
private decimal BYFUT3N;

public
StktDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}


public /*override*/
void load(NotNullDataReader reader){
	this.BYPART = reader.GetString("BYPART");
	this.BYLOT = reader.GetString("BYLOT");
	this.BYSTOK = reader.GetString("BYSTOK");
	this.BYACTN = reader.GetString("BYACTN");
	this.BYQTY = reader.GetDecimal("BYQTY");
	this.BYTDAT = reader.GetDateTime("BYTDAT");
	this.BYJREF = reader.GetString("BYJREF");
	this.BYIREF = reader.GetString("BYIREF");
	this.BYLREF = reader.GetString("BYLREF");
	this.BYPREF = reader.GetString("BYPREF");
	this.BYTRST = reader.GetString("BYTRST");
	this.BYTRAN = reader.GetDecimal("BYTRAN");
	this.BYSRC = reader.GetString("BYSRC");
	this.BYREAS = reader.GetString("BYREAS");
	this.BYDREF = reader.GetString("BYDREF");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	       this.BYSEQ = reader.GetDecimal("BYSEQ#");
	else
	       this.BYSEQ = reader.GetDecimal("BYSEQ");
	this.BYBUNT = reader.GetString("BYBUNT");
	this.BYTQTY = reader.GetDecimal("BYTQTY");
	this.BYTUNT = reader.GetString("BYTUNT");
	this.BYA1 = reader.GetString("BYA1");
	this.BYPGQT = reader.GetDecimal("BYPGQT");
	this.BYPSQT = reader.GetDecimal("BYPSQT");
	this.BYSDAT = reader.GetDateTime("BYSDAT");
	this.BYSTIM = reader.GetDateTime("BYSTIM");
	
	if ((Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_1)) || 
	    (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE)){
	    this.BYUSER = reader.GetString("BYUSER");
	    this.BYFSYY = int.Parse(reader.GetDecimal("BYFSYY").ToString());
	    this.BYFSPR = int.Parse(reader.GetDecimal("BYFSPR").ToString());
	    this.BYPLNT = reader.GetString("BYPLNT");
	    this.BYFUT1A = reader.GetString("BYFUT1A");
	    this.BYFUT2A = reader.GetString("BYFUT2A");
	    this.BYFUT3A = reader.GetString("BYFUT3A");
	    this.BYFUT4A = reader.GetString("BYFUT4A");
	    this.BYFUT5A = reader.GetString("BYFUT5A");
	    this.BYFUT6A = reader.GetString("BYFUT6A");
	    this.BYFUT1N = reader.GetDecimal("BYFUT1N");
	    this.BYFUT2N = reader.GetDecimal("BYFUT2N");
	    this.BYFUT3N = reader.GetDecimal("BYFUT3N");
    }
}

public override
void write(){
	string sql = "insert into stkt (" + 
		"BYPART," +
		"BYLOT," +
		"BYSTOK," +
		"BYACTN," +
		"BYQTY," +
		"BYTDAT," +
		"BYJREF," +
		"BYIREF," +
		"BYLREF," +
		"BYPREF," +
		"BYTRST," +
		"BYTRAN," +
		"BYSRC," +
		"BYREAS," +
		"BYDREF," +
		"BYSEQ," +
		"BYBUNT," +
		"BYTQTY," +
		"BYTUNT," +
		"BYA1," +
		"BYPGQT," +
		"BYPSQT," +
		"BYSDAT," +
		"BYSTIM," +
		"BYUSER," +
		"BYFSYY," +
		"BYFSPR," +
		"BYPLNT," +
		"BYFUT1A," +
		"BYFUT2A," +
		"BYFUT3A," +
		"BYFUT4A," +
		"BYFUT5A," +
		"BYFUT6A," +
		"BYFUT1N," +
		"BYFUT2N," +
		"BYFUT3N" +

		") values (" + 

		"'" + Converter.fixString(BYPART) + "'," +
		"'" + Converter.fixString(BYLOT) + "'," +
		"'" + Converter.fixString(BYSTOK) + "'," +
		"'" + Converter.fixString(BYACTN) + "'," +
		"" + NumberUtil.toString(BYQTY) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(BYTDAT) + "'," +
		"'" + Converter.fixString(BYJREF) + "'," +
		"'" + Converter.fixString(BYIREF) + "'," +
		"'" + Converter.fixString(BYLREF) + "'," +
		"'" + Converter.fixString(BYPREF) + "'," +
		"'" + Converter.fixString(BYTRST) + "'," +
		"" + NumberUtil.toString(BYTRAN) + "," +
		"'" + Converter.fixString(BYSRC) + "'," +
		"'" + Converter.fixString(BYREAS) + "'," +
		"'" + Converter.fixString(BYDREF) + "'," +
		"" + NumberUtil.toString(BYSEQ) + "," +
		"'" + Converter.fixString(BYBUNT) + "'," +
		"" + NumberUtil.toString(BYTQTY) + "," +
		"'" + Converter.fixString(BYTUNT) + "'," +
		"'" + Converter.fixString(BYA1) + "'," +
		"" + NumberUtil.toString(BYPGQT) + "," +
		"" + NumberUtil.toString(BYPSQT) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(BYSDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(BYSTIM) + "'," +
		"'" + Converter.fixString(BYUSER) + "'," +
		"" + NumberUtil.toString(BYFSYY) + "," +
		"" + NumberUtil.toString(BYFSPR) + "," +
		"'" + Converter.fixString(BYPLNT) + "'," +
		"'" + Converter.fixString(BYFUT1A) + "'," +
		"'" + Converter.fixString(BYFUT2A) + "'," +
		"'" + Converter.fixString(BYFUT3A) + "'," +
		"'" + Converter.fixString(BYFUT4A) + "'," +
		"'" + Converter.fixString(BYFUT5A) + "'," +
		"'" + Converter.fixString(BYFUT6A) + "'," +
		"" + NumberUtil.toString(BYFUT1N) + "," +
		"" + NumberUtil.toString(BYFUT2N) + "," +
		"" + NumberUtil.toString(BYFUT3N) + ")";
	write(sql);
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
void setBYPART(string BYPART){
	this.BYPART = BYPART;
}

public
void setBYLOT(string BYLOT){
	this.BYLOT = BYLOT;
}

public
void setBYSTOK(string BYSTOK){
	this.BYSTOK = BYSTOK;
}

public
void setBYACTN(string BYACTN){
	this.BYACTN = BYACTN;
}

public
void setBYQTY(decimal BYQTY){
	this.BYQTY = BYQTY;
}

public
void setBYTDAT(DateTime BYTDAT){
	this.BYTDAT = BYTDAT;
}

public
void setBYJREF(string BYJREF){
	this.BYJREF = BYJREF;
}

public
void setBYIREF(string BYIREF){
	this.BYIREF = BYIREF;
}

public
void setBYLREF(string BYLREF){
	this.BYLREF = BYLREF;
}

public
void setBYPREF(string BYPREF){
	this.BYPREF = BYPREF;
}

public
void setBYTRST(string BYTRST){
	this.BYTRST = BYTRST;
}

public
void setBYTRAN(decimal BYTRAN){
	this.BYTRAN = BYTRAN;
}

public
void setBYSRC(string BYSRC){
	this.BYSRC = BYSRC;
}

public
void setBYREAS(string BYREAS){
	this.BYREAS = BYREAS;
}

public
void setBYDREF(string BYDREF){
	this.BYDREF = BYDREF;
}

public
void setBYSEQ(decimal BYSEQ){
	this.BYSEQ = BYSEQ;
}

public
void setBYBUNT(string BYBUNT){
	this.BYBUNT = BYBUNT;
}

public
void setBYTQTY(decimal BYTQTY){
	this.BYTQTY = BYTQTY;
}

public
void setBYTUNT(string BYTUNT){
	this.BYTUNT = BYTUNT;
}

public
void setBYA1(string BYA1){
	this.BYA1 = BYA1;
}

public
void setBYPGQT(decimal BYPGQT){
	this.BYPGQT = BYPGQT;
}

public
void setBYPSQT(decimal BYPSQT){
	this.BYPSQT = BYPSQT;
}

public
void setBYSDAT(DateTime BYSDAT){
	this.BYSDAT = BYSDAT;
}

public
void setBYSTIM(DateTime BYSTIM){
	this.BYSTIM = BYSTIM;
}

public
void setBYUSER(string BYUSER){
	this.BYUSER = BYUSER;
}

public
void setBYFSYY(int BYFSYY){
	this.BYFSYY = BYFSYY;
}

public
void setBYFSPR(int BYFSPR){
	this.BYFSPR = BYFSPR;
}

public
void setBYPLNT(string BYPLNT){
	this.BYPLNT = BYPLNT;
}

public
void setBYFUT1A(string BYFUT1A){
	this.BYFUT1A = BYFUT1A;
}

public
void setBYFUT2A(string BYFUT2A){
	this.BYFUT2A = BYFUT2A;
}

public
void setBYFUT3A(string BYFUT3A){
	this.BYFUT3A = BYFUT3A;
}

public
void setBYFUT4A(string BYFUT4A){
	this.BYFUT4A = BYFUT4A;
}

public
void setBYFUT5A(string BYFUT5A){
	this.BYFUT5A = BYFUT5A;
}

public
void setBYFUT6A(string BYFUT6A){
	this.BYFUT6A = BYFUT6A;
}

public
void setBYFUT1N(decimal BYFUT1N){
	this.BYFUT1N = BYFUT1N;
}

public
void setBYFUT2N(decimal BYFUT2N){
	this.BYFUT2N = BYFUT2N;
}

public
void setBYFUT3N(decimal BYFUT3N){
	this.BYFUT3N = BYFUT3N;
}

public
string getBYPART(){
	return BYPART;
}

public
string getBYLOT(){
	return BYLOT;
}

public
string getBYSTOK(){
	return BYSTOK;
}

public
string getBYACTN(){
	return BYACTN;
}

public
decimal getBYQTY(){
	return BYQTY;
}

public
DateTime getBYTDAT(){
	return BYTDAT;
}

public
string getBYJREF(){
	return BYJREF;
}

public
string getBYIREF(){
	return BYIREF;
}

public
string getBYLREF(){
	return BYLREF;
}

public
string getBYPREF(){
	return BYPREF;
}

public
string getBYTRST(){
	return BYTRST;
}

public
decimal getBYTRAN(){
	return BYTRAN;
}

public
string getBYSRC(){
	return BYSRC;
}

public
string getBYREAS(){
	return BYREAS;
}

public
string getBYDREF(){
	return BYDREF;
}

public
decimal getBYSEQ(){
	return BYSEQ;
}

public
string getBYBUNT(){
	return BYBUNT;
}

public
decimal getBYTQTY(){
	return BYTQTY;
}

public
string getBYTUNT(){
	return BYTUNT;
}

public
string getBYA1(){
	return BYA1;
}

public
decimal getBYPGQT(){
	return BYPGQT;
}

public
decimal getBYPSQT(){
	return BYPSQT;
}

public
DateTime getBYSDAT(){
	return BYSDAT;
}

public
DateTime getBYSTIM(){
	return BYSTIM;
}

public
string getBYUSER(){
	return BYUSER;
}

public
int getBYFSYY(){
	return BYFSYY;
}

public
int getBYFSPR(){
	return BYFSPR;
}

public
string getBYPLNT(){
	return BYPLNT;
}

public
string getBYFUT1A(){
	return BYFUT1A;
}

public
string getBYFUT2A(){
	return BYFUT2A;
}

public
string getBYFUT3A(){
	return BYFUT3A;
}

public
string getBYFUT4A(){
	return BYFUT4A;
}

public
string getBYFUT5A(){
	return BYFUT5A;
}

public
string getBYFUT6A(){
	return BYFUT6A;
}

public
decimal getBYFUT1N(){
	return BYFUT1N;
}

public
decimal getBYFUT2N(){
	return BYFUT2N;
}

public
decimal getBYFUT3N(){
	return BYFUT3N;
}

} // class

} // package