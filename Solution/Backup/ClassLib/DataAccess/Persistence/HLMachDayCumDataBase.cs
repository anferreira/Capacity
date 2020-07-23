using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class HLMachDayCumDataBase : GenericDataBaseElement{
private string HMDC_Plt;  
private string HMDC_Dept;  
private string HMDC_MachConfig; 
private decimal HMDC_HrPDC; 
private decimal HMDC_HrD001C; 
private decimal HMDC_HrD002C; 
private decimal HMDC_HrD003C; 
private decimal HMDC_HrD004C; 
private decimal HMDC_HrD005C; 
private decimal HMDC_HrD006C; 
private decimal HMDC_HrD007C; 
private decimal HMDC_HrD008C; 
private decimal HMDC_HrD009C; 
private decimal HMDC_HrD010C; 
private decimal HMDC_HrD011C; 
private decimal HMDC_HrD012C; 
private decimal HMDC_HrD013C; 
private decimal HMDC_HrD014C; 
private decimal HMDC_HrD015C; 
private decimal HMDC_HrD016C; 
private decimal HMDC_HrD017C; 
private decimal HMDC_HrD018C; 
private decimal HMDC_HrD019C; 
private decimal HMDC_HrD020C; 
private decimal HMDC_HrD021C; 
private decimal HMDC_HrD022C; 
private decimal HMDC_HrD023C; 
private decimal HMDC_HrD024C; 
private decimal HMDC_HrD025C; 
private decimal HMDC_HrD026C; 
private decimal HMDC_HrD027C; 
private decimal HMDC_HrD028C; 
private decimal HMDC_HrD029C; 
private decimal HMDC_HrD030C; 
private decimal HMDC_HrD031C; 
private decimal HMDC_HrD032C; 
private decimal HMDC_HrD033C; 
private decimal HMDC_HrD034C; 
private decimal HMDC_HrD035C; 
private decimal HMDC_HrD036C; 
private decimal HMDC_HrD037C; 
private decimal HMDC_HrD038C; 
private decimal HMDC_HrD039C; 
private decimal HMDC_HrD040C; 
private decimal HMDC_HrD041C; 
private decimal HMDC_HrD042C; 
private decimal HMDC_HrD043C; 
private decimal HMDC_HrD044C; 
private decimal HMDC_HrD045C; 
private decimal HMDC_HrD046C; 
private decimal HMDC_HrD047C; 
private decimal HMDC_HrD048C; 
private decimal HMDC_HrD049C; 
private decimal HMDC_HrD050C; 
private decimal HMDC_HrD051C; 
private decimal HMDC_HrD052C; 
private decimal HMDC_HrD053C; 
private decimal HMDC_HrD054C; 
private decimal HMDC_HrD055C; 
private decimal HMDC_HrD056C; 
private decimal HMDC_HrD057C; 
private decimal HMDC_HrD058C; 
private decimal HMDC_HrD059C; 
private decimal HMDC_HrD060C; 


public HLMachDayCumDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
			
}

public 
void load(NotNullDataReader reader){
	this.HMDC_Plt = reader.GetString("HMDC_Plt");
	this.HMDC_Dept = reader.GetString("HMDC_Dept");
	this.HMDC_MachConfig = reader.GetString("HMDC_MachConfig");
	this.HMDC_HrPDC = reader.GetDecimal("HMDC_HrPDC"); 
	this.HMDC_HrD001C = reader.GetDecimal("HMDC_HrD001C");  
	this.HMDC_HrD002C = reader.GetDecimal("HMDC_HrD002C");  
	this.HMDC_HrD003C = reader.GetDecimal("HMDC_HrD003C");  
	this.HMDC_HrD004C = reader.GetDecimal("HMDC_HrD004C");  
	this.HMDC_HrD005C = reader.GetDecimal("HMDC_HrD005C");  
	this.HMDC_HrD006C = reader.GetDecimal("HMDC_HrD006C");  
	this.HMDC_HrD007C = reader.GetDecimal("HMDC_HrD007C"); 
	this.HMDC_HrD008C = reader.GetDecimal("HMDC_HrD008C"); 
	this.HMDC_HrD009C = reader.GetDecimal("HMDC_HrD009C"); 
	this.HMDC_HrD010C = reader.GetDecimal("HMDC_HrD010C"); 
	this.HMDC_HrD011C = reader.GetDecimal("HMDC_HrD011C"); 
	this.HMDC_HrD012C = reader.GetDecimal("HMDC_HrD012C"); 
	this.HMDC_HrD013C = reader.GetDecimal("HMDC_HrD013C"); 
	this.HMDC_HrD014C = reader.GetDecimal("HMDC_HrD014C"); 
	this.HMDC_HrD015C = reader.GetDecimal("HMDC_HrD015C"); 
	this.HMDC_HrD016C = reader.GetDecimal("HMDC_HrD016C"); 
	this.HMDC_HrD017C = reader.GetDecimal("HMDC_HrD017C"); 
	this.HMDC_HrD018C = reader.GetDecimal("HMDC_HrD018C"); 
	this.HMDC_HrD019C = reader.GetDecimal("HMDC_HrD019C"); 
	this.HMDC_HrD020C = reader.GetDecimal("HMDC_HrD020C"); 
	this.HMDC_HrD021C = reader.GetDecimal("HMDC_HrD021C"); 
	this.HMDC_HrD022C = reader.GetDecimal("HMDC_HrD022C"); 
	this.HMDC_HrD023C = reader.GetDecimal("HMDC_HrD023C"); 
	this.HMDC_HrD024C = reader.GetDecimal("HMDC_HrD024C"); 
	this.HMDC_HrD025C = reader.GetDecimal("HMDC_HrD025C"); 
	this.HMDC_HrD026C = reader.GetDecimal("HMDC_HrD026C"); 
	this.HMDC_HrD027C = reader.GetDecimal("HMDC_HrD027C"); 
	this.HMDC_HrD028C = reader.GetDecimal("HMDC_HrD028C"); 
	this.HMDC_HrD029C = reader.GetDecimal("HMDC_HrD029C"); 
	this.HMDC_HrD030C = reader.GetDecimal("HMDC_HrD030C"); 
	this.HMDC_HrD031C = reader.GetDecimal("HMDC_HrD031C"); 
	this.HMDC_HrD032C = reader.GetDecimal("HMDC_HrD032C"); 
	this.HMDC_HrD033C = reader.GetDecimal("HMDC_HrD033C"); 
	this.HMDC_HrD034C = reader.GetDecimal("HMDC_HrD034C"); 
	this.HMDC_HrD035C = reader.GetDecimal("HMDC_HrD035C"); 
	this.HMDC_HrD036C = reader.GetDecimal("HMDC_HrD036C"); 
	this.HMDC_HrD037C = reader.GetDecimal("HMDC_HrD037C"); 
	this.HMDC_HrD038C = reader.GetDecimal("HMDC_HrD038C"); 
	this.HMDC_HrD039C = reader.GetDecimal("HMDC_HrD039C"); 
	this.HMDC_HrD040C = reader.GetDecimal("HMDC_HrD040C"); 
	this.HMDC_HrD041C = reader.GetDecimal("HMDC_HrD041C"); 
	this.HMDC_HrD042C = reader.GetDecimal("HMDC_HrD042C"); 
	this.HMDC_HrD043C = reader.GetDecimal("HMDC_HrD043C"); 
	this.HMDC_HrD044C = reader.GetDecimal("HMDC_HrD044C"); 
	this.HMDC_HrD045C = reader.GetDecimal("HMDC_HrD045C"); 
	this.HMDC_HrD046C = reader.GetDecimal("HMDC_HrD046C"); 
	this.HMDC_HrD047C = reader.GetDecimal("HMDC_HrD047C"); 
	this.HMDC_HrD048C = reader.GetDecimal("HMDC_HrD048C"); 
	this.HMDC_HrD049C = reader.GetDecimal("HMDC_HrD049C"); 
	this.HMDC_HrD050C = reader.GetDecimal("HMDC_HrD050C"); 
	this.HMDC_HrD051C = reader.GetDecimal("HMDC_HrD051C"); 
	this.HMDC_HrD052C = reader.GetDecimal("HMDC_HrD052C"); 
	this.HMDC_HrD053C = reader.GetDecimal("HMDC_HrD053C"); 
	this.HMDC_HrD054C = reader.GetDecimal("HMDC_HrD054C"); 
	this.HMDC_HrD055C = reader.GetDecimal("HMDC_HrD055C"); 
	this.HMDC_HrD056C = reader.GetDecimal("HMDC_HrD056C"); 
	this.HMDC_HrD057C = reader.GetDecimal("HMDC_HrD057C"); 
	this.HMDC_HrD058C = reader.GetDecimal("HMDC_HrD058C"); 
	this.HMDC_HrD059C = reader.GetDecimal("HMDC_HrD059C"); 
	this.HMDC_HrD060C = reader.GetDecimal("HMDC_HrD060C"); 
}

public
void read(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}
public override
void write(){
	throw new PersistenceException("Method not implemented");
}

//--- Seters
public
string getHMDC_Plt (){
	return this.HMDC_Plt;
}

public
string setHMDC_Dept (){
	return this.HMDC_Dept;
}

public
string getHMDC_MachConfig (){
	return this.HMDC_MachConfig;
}

public
decimal getHMDC_HrPDC (){
	return this.HMDC_HrPDC;
}
 

public
decimal getHMDC_HrD001C (){
	return this.HMDC_HrD001C;
}

public
decimal getHMDC_HrD002C (){
	return this.HMDC_HrD002C;
}

public
decimal getHMDC_HrD003C (){
	return this.HMDC_HrD003C;
}

public
decimal getHMDC_HrD004C (){
	return this.HMDC_HrD004C;
}

public
decimal getHMDC_HrD005C (){
	return this.HMDC_HrD005C;
}

public
decimal getHMDC_HrD006C (){
	return this.HMDC_HrD006C;
}

public
decimal getHMDC_HrD007C (){
	return this.HMDC_HrD007C;
}

public
decimal getHMDC_HrD008C (){
	return this.HMDC_HrD008C;
} 

public
decimal getHMDC_HrD009C (){
	return this.HMDC_HrD009C;
}

public
decimal getHMDC_HrD010C (){
	return this.HMDC_HrD010C;
}

public
decimal getHMDC_HrD011C (){
	return this.HMDC_HrD011C;
}

public
decimal getHMDC_HrD012C (){
	return this.HMDC_HrD012C;
}
public
decimal getHMDC_HrD013C (){
	return this.HMDC_HrD013C;
} 

public
decimal getHMDC_HrD014C (){
	return this.HMDC_HrD014C;
}

public
decimal getHMDC_HrD015C (){
	return this.HMDC_HrD015C;
}

public
decimal getHMDC_HrD016C (){
	return this.HMDC_HrD016C;
}


public
decimal getHMDC_HrD017C (){
	return this.HMDC_HrD017C;
}

public
decimal getHMDC_HrD018C (){
	return this.HMDC_HrD018C;
}
public
decimal getHMDC_HrD019C (){
	return this.HMDC_HrD019C;
}

public
decimal getHMDC_HrD020C (){
	return this.HMDC_HrD020C;
}


public
decimal getHMDC_HrD021C (){
	return this.HMDC_HrD021C;
}


public
decimal getHMDC_HrD022C (){
	return this.HMDC_HrD022C;
} 

public
decimal getHMDC_HrD023C (){
		return this.HMDC_HrD023C;
}
public
decimal getHMDC_HrD024C (){
	return this.HMDC_HrD024C;
}
public
decimal getHMDC_HrD025C (){
	return this.HMDC_HrD025C;
}
public
decimal getHMDC_HrD026C (){
	return this.HMDC_HrD026C;
}

public
decimal getHMDC_HrD027C (){
	return this.HMDC_HrD027C;
}

public
decimal getHMDC_HrD028C (){
	return this.HMDC_HrD028C;
} 

public
decimal getHMDC_HrD029C (){
	return this.HMDC_HrD029C;
}
public
decimal getHMDC_HrD030C (){
	return this.HMDC_HrD030C;
} 

public
decimal getHMDC_HrD031C (){
	return this.HMDC_HrD031C;
}

public
decimal getHMDC_HrD032C (){
	return this.HMDC_HrD032C;
}
public
decimal getHMDC_HrD033C (){
	return this.HMDC_HrD033C;
}
public
decimal getHMDC_HrD034C (){
	return this.HMDC_HrD034C;
}

public
decimal getHMDC_HrD035C (){
	return this.HMDC_HrD035C;
}

public
decimal getHMDC_HrD036C (){
	return this.HMDC_HrD036C;
} 

public
decimal getHMDC_HrD037C (){
	return this.HMDC_HrD037C;
} 
public
decimal getHMDC_HrD038C (){
	return this.HMDC_HrD038C;
}

public
decimal getHMDC_HrD039C (){
	return this.HMDC_HrD039C;
}

public
decimal getHMDC_HrD040C (){
	return this.HMDC_HrD040C;
}
public
decimal getHMDC_HrD041C (){
	return this.HMDC_HrD041C;
} 

public
decimal getHMDC_HrD042C (){
	return this.HMDC_HrD042C;
}

public
decimal getHMDC_HrD043C (){
	return this.HMDC_HrD043C;
}

public
decimal getHMDC_HrD044C (){
	return this.HMDC_HrD044C;
}

public
decimal getHMDC_HrD045C (){
	return this.HMDC_HrD045C;
}


public
decimal getHMDC_HrD046C (){
	return this.HMDC_HrD046C;
}

public
decimal getHMDC_HrD047C (){
	return this.HMDC_HrD047C;
}

public
decimal getHMDC_HrD048C (){
	return this.HMDC_HrD048C;
}

public
decimal getHMDC_HrD049C (){
	return this.HMDC_HrD049C;
}

public
decimal getHMDC_HrD050C (){
	return this.HMDC_HrD050C;
}
public
decimal getHMDC_HrD051C (){
	return this.HMDC_HrD051C;
}

public
decimal getHMDC_HrD052C (){
	return this.HMDC_HrD052C;
}
public
decimal getHMDC_HrD053C (){
	return this.HMDC_HrD053C;
}

public
decimal getHMDC_HrD054C (){
	return this.HMDC_HrD054C;
}
public
decimal getHMDC_HrD055C (){
	return this.HMDC_HrD055C;
} 
public
decimal getHMDC_HrD056C (){
	return this.HMDC_HrD056C;
} 

public
decimal getHMDC_HrD057C (){
	return this.HMDC_HrD057C;
}

public
decimal getHMDC_HrD058C (){
	return this.HMDC_HrD058C;
}
public
decimal getHMDC_HrD059C (){
	return this.HMDC_HrD059C;
}
public
decimal getHMDC_HrD060C (){
	return this.HMDC_HrD060C;
} 

//--- Seters
public
void setHMDC_Plt (string HMDC_Plt){
	this.HMDC_Plt = HMDC_Plt;
}
public
void setHMDC_Dept (string HMDC_Dept){
	this.HMDC_Dept = HMDC_Dept;
}

public
void setHMDC_MachConfig (string HMDC_MachConfig){
	this.HMDC_MachConfig = HMDC_MachConfig;
}

public
void setHMDC_HrPDC (decimal HMDC_HrPDC){
	this.HMDC_HrPDC= HMDC_HrPDC;
}
 

public
void setHMDC_HrD001C (decimal HMDC_HrD001C){
	this.HMDC_HrD001C = HMDC_HrD001C;
}

public
void setHMDC_HrD002C (decimal HMDC_HrD002C){
	this.HMDC_HrD002C= HMDC_HrD002C;
}

public
void setHMDC_HrD003C (decimal HMDC_HrD003C){
	this.HMDC_HrD003C = HMDC_HrD003C;
}

public
void setHMDC_HrD004C (decimal HMDC_HrD004C){
	this.HMDC_HrD004C = HMDC_HrD004C;
}

public
void setHMDC_HrD005C (decimal HMDC_HrD005C){
	this.HMDC_HrD005C = HMDC_HrD005C;
}

public
void setHMDC_HrD006C (decimal HMDC_HrD006C){
	this.HMDC_HrD006C = HMDC_HrD006C;
}

public
void setHMDC_HrD007C (decimal HMDC_HrD007C){
	this.HMDC_HrD007C= HMDC_HrD007C;
}

public
void setHMDC_HrD008C (decimal HMDC_HrD008C){
	this.HMDC_HrD008C= HMDC_HrD008C;
} 

public
void setHMDC_HrD009C (decimal HMDC_HrD009C){
	this.HMDC_HrD009C = HMDC_HrD009C;
}

public
void setHMDC_HrD010C (decimal HMDC_HrD010C){
	this.HMDC_HrD010C = HMDC_HrD010C;
}

public
void setHMDC_HrD011C (decimal HMDC_HrD011C){
	this.HMDC_HrD011C =HMDC_HrD011C;
}

public
void setHMDC_HrD012C (decimal HMDC_HrD012C){
	this.HMDC_HrD012C = HMDC_HrD012C;
}
public
void setHMDC_HrD013C (decimal HMDC_HrD013C){
	this.HMDC_HrD013C = HMDC_HrD013C;
} 

public
void setHMDC_HrD014C (decimal HMDC_HrD014C){
	this.HMDC_HrD014C = HMDC_HrD014C;
}

public
void setHMDC_HrD015C (decimal HMDC_HrD015C){
	this.HMDC_HrD015C = HMDC_HrD015C;
}

public
void setHMDC_HrD016C (decimal HMDC_HrD016C){
	this.HMDC_HrD016C = HMDC_HrD016C;
}


public
void setHMDC_HrD017C (decimal HMDC_HrD017C){
	this.HMDC_HrD017C = HMDC_HrD017C;
}

public
void setHMDC_HrD018C (decimal HMDC_HrD018C){
	this.HMDC_HrD018C = HMDC_HrD018C;
}
public
void setHMDC_HrD019C (decimal HMDC_HrD019C){
	this.HMDC_HrD019C = HMDC_HrD019C;
}

public
void setHMDC_HrD020C (decimal HMDC_HrD020C){
	this.HMDC_HrD020C = HMDC_HrD020C;
}


public
void setHMDC_HrD021C (decimal HMDC_HrD021C){
	this.HMDC_HrD021C = HMDC_HrD021C;
}


public
void setHMDC_HrD022C (decimal HMDC_HrD022C){
	this.HMDC_HrD022C = HMDC_HrD022C;
} 

public
void setHMDC_HrD023C (decimal HMDC_HrD023C){
		this.HMDC_HrD023C = HMDC_HrD023C;
}
public
void setHMDC_HrD024C (decimal HMDC_HrD024C){
	this.HMDC_HrD024C = HMDC_HrD024C;
}
public
void setHMDC_HrD025C (decimal HMDC_HrD025C){
	this.HMDC_HrD025C = HMDC_HrD025C;
}
public
void setHMDC_HrD026C (decimal HMDC_HrD026C){
	this.HMDC_HrD026C = HMDC_HrD026C;
}

public
void setHMDC_HrD027C (decimal HMDC_HrD027C){
	this.HMDC_HrD027C =HMDC_HrD027C;
}

public
void setHMDC_HrD028C (decimal HMDC_HrD028C){
	this.HMDC_HrD028C = HMDC_HrD028C;
} 

public
void setHMDC_HrD029C (decimal HMDC_HrD029C){
	this.HMDC_HrD029C = HMDC_HrD029C;
}
public
void setHMDC_HrD030C (decimal HMDC_HrD030C){
	this.HMDC_HrD030C = HMDC_HrD030C;
} 

public
void setHMDC_HrD031C (decimal HMDC_HrD031C){
	this.HMDC_HrD031C = HMDC_HrD031C;
}

public
void setHMDC_HrD032C (decimal HMDC_HrD032C){
	this.HMDC_HrD032C = HMDC_HrD032C;
}
public
void setHMDC_HrD033C (decimal HMDC_HrD033C){
	this.HMDC_HrD033C = HMDC_HrD033C;
}
public
void setHMDC_HrD034C (decimal HMDC_HrD034C){
	this.HMDC_HrD034C = HMDC_HrD034C;
}

public
void setHMDC_HrD035C (decimal HMDC_HrD035C){
	this.HMDC_HrD035C = HMDC_HrD035C;
}

public
void setHMDC_HrD036C (decimal HMDC_HrD036C){
	this.HMDC_HrD036C= HMDC_HrD036C;
} 

public
void setHMDC_HrD037C (decimal HMDC_HrD037C){
	this.HMDC_HrD037C = HMDC_HrD037C;
} 
public
void setHMDC_HrD038C (decimal HMDC_HrD038C){
	this.HMDC_HrD038C = HMDC_HrD038C;
}

public
void setHMDC_HrD039C (decimal HMDC_HrD039C){
	this.HMDC_HrD039C = HMDC_HrD039C;
}

public
void setHMDC_HrD040C (decimal HMDC_HrD040C){
	this.HMDC_HrD040C = HMDC_HrD040C;
}
public
void setHMDC_HrD041C (decimal HMDC_HrD041C){
	this.HMDC_HrD041C = HMDC_HrD041C;
} 

public
void setHMDC_HrD042C (decimal HMDC_HrD042C){
	this.HMDC_HrD042C =HMDC_HrD042C;
}

public
void setHMDC_HrD043C (decimal HMDC_HrD043C){
	this.HMDC_HrD043C = HMDC_HrD043C;
}

public
void setHMDC_HrD044C (decimal HMDC_HrD044C){
	this.HMDC_HrD044C = HMDC_HrD044C;
}

public
void setHMDC_HrD045C (decimal HMDC_HrD045C){
	this.HMDC_HrD045C = HMDC_HrD045C;
}


public
void setHMDC_HrD046C (decimal HMDC_HrD046C){
	this.HMDC_HrD046C =HMDC_HrD046C;
}

public
void setHMDC_HrD047C (decimal HMDC_HrD047C){
	this.HMDC_HrD047C = HMDC_HrD047C;
}

public
void setHMDC_HrD048C (decimal HMDC_HrD048C){
	this.HMDC_HrD048C = HMDC_HrD048C;
}

public
void setHMDC_HrD049C (decimal HMDC_HrD049C){
	this.HMDC_HrD049C = HMDC_HrD049C;
}

public
void setHMDC_HrD050C (decimal HMDC_HrD050C){
	this.HMDC_HrD050C = HMDC_HrD050C;
}
public
void setHMDC_HrD051C (decimal HMDC_HrD051C){
	this.HMDC_HrD051C = HMDC_HrD051C;
}

public
void setHMDC_HrD052C (decimal HMDC_HrD052C){
	this.HMDC_HrD052C = HMDC_HrD052C;
}
public
void setHMDC_HrD053C (decimal HMDC_HrD053C){
	this.HMDC_HrD053C = HMDC_HrD053C;
}

public
void setHMDC_HrD054C (decimal HMDC_HrD054C){
	this.HMDC_HrD054C = HMDC_HrD054C;
}
public
void setHMDC_HrD055C (decimal HMDC_HrD055C){
	this.HMDC_HrD055C = HMDC_HrD055C;
} 
public
void setHMDC_HrD056C (decimal HMDC_HrD056C){
	this.HMDC_HrD056C = HMDC_HrD056C;
} 

public
void setHMDC_HrD057C (decimal HMDC_HrD057C){
	this.HMDC_HrD057C = HMDC_HrD057C;
}

public
void setHMDC_HrD058C (decimal HMDC_HrD058C){
	this.HMDC_HrD058C = HMDC_HrD058C;
}
public
void setHMDC_HrD059C (decimal HMDC_HrD059C){
	this.HMDC_HrD059C = HMDC_HrD059C;
}
public
void setHMDC_HrD060C (decimal HMDC_HrD060C){
	this.HMDC_HrD060C = HMDC_HrD060C;
} 

}//end class
}// end namespace
