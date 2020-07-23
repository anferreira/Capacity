using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{

	
public 
class ReportsCoreFactory : PurchaseOrderCoreFactory{

private bool flgChargeVec = false;

public 
ReportsCoreFactory():base(){
}

//Generation of two new reports from the AS400
public string[][] generateReportMaterialRelease(string db, string[] filterTPartner,string[] filterShipToLoc,
                                                bool flag,bool flagValue0){
	try {
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		TrlpDataBaseContainer trlpDataBaseContainer = new  TrlpDataBaseContainer(dataBaseAccess);
	    
		ArrayList array = trlpDataBaseContainer.generateReportMaterialRelease(db,filterTPartner,filterShipToLoc);
	    
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
	    
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		if (returnArray.Length==0)//The selection is empty
			return returnArray;
		else
			return  processRecordsMatRelease(returnArray,flag,flagValue0);
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//public string[][] generateReportMaterialRelease(DbConnection dbConnection){
//
//    ArrayList array = new ArrayList();
//    
//    DbCrossRefDataBaseContainer dbCrossRefDataBaseContainer= new DbCrossRefDataBaseContainer(dataBaseAccess);
//    dbCrossRefDataBaseContainer = dbConnection.getDbCrossRefDataBaseContainer();
//    
//    dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
//    TrlpDataBaseContainer trlpDataBaseContainer = new  TrlpDataBaseContainer(dataBaseAccess);
//    
//	IEnumerator iEnum = dbCrossRefDataBaseContainer.GetEnumerator();
//	while(iEnum.MoveNext()){
//		DbCrossRefDataBase dbCrossRefDataBase = (DbCrossRefDataBase)iEnum.Current;
//		ArrayList arrayList = null; //= trlpDataBaseContainer.generateReportMaterialRelease(dbCrossRefDataBase.getST_Db(),"CMSDAT");
//		array.AddRange(arrayList);
//    }
//    
//    dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
//    
//    int index = 0;
//    string[][] returnArray = new string[array.Count][];
//    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
//		string[] lineArray = (string[])en.Current;
//		returnArray[index] = lineArray;
//		index++;
//	}
//	
//   return returnArray;
//}

public string[][] generateReportShippingSchedule(string db, string[] filterTPartner,string[] filterShipToLoc,bool flagReq, 
                                                 bool flagByDtl,bool flagValue0,string release){
	try {
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		TrlpDataBaseContainer trlpDataBaseContainer = new  TrlpDataBaseContainer(dataBaseAccess);
		ArrayList array = trlpDataBaseContainer.generateReportShippingSch(db,filterTPartner,filterShipToLoc,release);
	    
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
	    
		string[][] returnArray = new string[array.Count][];
		int index = 0;
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		if (returnArray.Length==0){ // the select has no records
			return returnArray;
		}
		if (flagByDtl)
			return  processRecordsShippingSchDtl(returnArray,flagReq,flagValue0);
		else
			return processRecordsShippingSchAcum(returnArray,flagReq,flagValue0);
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public string[][] generateReportShippingSchByWeek(string db, string[] filterTPartner,string[] filterShipToLoc,bool flagReq, 
                                                bool flagByDtl,bool flagValue0,string release){
	try {
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		TrlpDataBaseContainer trlpDataBaseContainer = new  TrlpDataBaseContainer(dataBaseAccess);
		ArrayList array = trlpDataBaseContainer.generateReportShippingSch(db,filterTPartner,filterShipToLoc,release);
	    
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
	    
		string[][] returnArray = new string[array.Count][];
		int index = 0;
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		if (returnArray.Length==0){ // the select has no records
			return returnArray;
		}
		if (flagByDtl)
			return  processRecordsShippingSchDtlByWeek(returnArray,flagReq,flagValue0);
		else
			return processRecordsShippingSchAcumByWeek(returnArray,flagReq,flagValue0);
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//public string[][] generateReportShippingSchedule(DbConnection dbConnection){
//    
//    ArrayList array = new ArrayList();
//   
//    DbCrossRefDataBaseContainer dbCrossRefDataBaseContainer= new DbCrossRefDataBaseContainer(dataBaseAccess);
//    dbCrossRefDataBaseContainer = dbConnection.getDbCrossRefDataBaseContainer();
//   
//    dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
//    TrlpDataBaseContainer trlpDataBaseContainer = new  TrlpDataBaseContainer(dataBaseAccess);
//   	IEnumerator iEnum = dbCrossRefDataBaseContainer.GetEnumerator();
//   	
//	while(iEnum.MoveNext()){
//		DbCrossRefDataBase dbCrossRefDataBase = (DbCrossRefDataBase)iEnum.Current;
//		ArrayList arrayList = null;// = trlpDataBaseContainer.generateReportShippingSch(dbCrossRefDataBase.getST_Db(),"CMSDAT");
//		array.AddRange(arrayList);
//	}
//	
//  	dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
//
//    int index = 0;
//    string[][] returnArray = new string[array.Count][];
//    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
//		string[] lineArray = (string[])en.Current;
//		returnArray[index] = lineArray;
//		index++;
//	}
//    return returnArray;
//}

public string[][] getSMTRPT(string db){     
		try {    
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		TrlpDataBaseContainer trlpDataBaseContainer = new  TrlpDataBaseContainer(dataBaseAccess);
		string[][] vec =  trlpDataBaseContainer.selectTPartnerByDB(db);
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
	    
		return vec;
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public
string[][] getUATRPTAsString(){
	try {    
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		TrptDataBaseContainer trptDataBaseContainer = new TrptDataBaseContainer(dataBaseAccess);
		trptDataBaseContainer.readByUATRPT();

		string[][] vec = new String[trptDataBaseContainer.Count][];
		int index = 0;

		IEnumerator iEnum = trptDataBaseContainer.GetEnumerator();
		while(iEnum.MoveNext()){
			TrptDataBase trptCrossDataBase = (TrptDataBase)iEnum.Current;
			
			string[] v = new String[2];
			v[0] = trptCrossDataBase.getUATRPT();
			v[1] = "true";
			vec[index] = v;
			index++;
		}

		return vec;
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getSYSHPTAsString(string[] filterTPartner){
	try {
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
		TrplDataBaseContainer trplDataBaseContainer = new TrplDataBaseContainer(dataBaseAccess);
		trplDataBaseContainer.readBySYTRDP(filterTPartner);

		string[][] vec = new String[trplDataBaseContainer.Count][];
		int index = 0;

		IEnumerator iEnum = trplDataBaseContainer.GetEnumerator();
		while(iEnum.MoveNext()){
			TrplDataBase trplCrossDataBase = (TrplDataBase)iEnum.Current;
			
			string[] v = new String[2];
			v[0] = trplCrossDataBase.getSYSTXL()+"," +trplCrossDataBase.getSYTRDP();
			v[1] = "true";
			vec[index] = v;
			index++;
		}

		return vec;
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private string[][] processRecordsMatRelease(string[][] vec,bool flag,bool flagValue0){
	try {
		DateTime[] dates = new DateTime[16];
		loadDates(dates); 
		ArrayList array = new ArrayList();
		string avmajg = vec[0][0];
		string avming = vec[0][1];
		string smtrpt = vec[0][2];
		string smstxl = vec[0][3];
		string smcpt = vec[0][4];
		string smpart = vec[0][5];
		decimal[] acumulate = new decimal[18]; //0 is pastDue, 1 week1 and so on
		for (int i = 0; i<acumulate.Length; i++)
			acumulate[i]= 0;
		for (int i=0; i < vec.Length;i++){
			if (avmajg.Equals(vec[i][0])){
				if (avming.Equals(vec[i][1])){
					if (smtrpt.Equals(vec[i][2])){
						if (smstxl.Equals(vec[i][3])){
							if (smcpt.Equals(vec[i][4])){
								if (smpart.Equals(vec[i][5])){
									sumValuesMatReleases(acumulate,flag,vec,i,dates);//calculate the week and we sum in the correct backet
								}else{//smpart.Equals(vec[i][5])
									string[] vecLine =chargeVectorMatRelease(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart);
									if (vecLine!=null)
										array.Add(vecLine);
									smpart= vec[i][5];
									sumValuesMatReleases(acumulate,flag,vec,i,dates);//calculate the week and we sum in the correct backet
								}//end else
							}else{//smcpt.Equals(vec[i][4]
								string[] vecLine =chargeVectorMatRelease(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart);
								if (vecLine!=null)
									array.Add(vecLine);
								smcpt=vec[i][4];
								smpart= vec[i][5];
								sumValuesMatReleases(acumulate,flag,vec,i,dates);//calculate the week and we sum in the correct backet                      
							}//end else
						}else{//smstxl.Equals(vec[i][3])
							string[] vecLine =chargeVectorMatRelease(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart);
							if (vecLine!=null)
								array.Add(vecLine);
							smstxl=vec[i][3];
							smcpt=vec[i][4];
							smpart= vec[i][5];
							sumValuesMatReleases(acumulate,flag,vec,i,dates);//calculate the week and we sum in the correct backet                      
						}//end else
					}else{//smtrpt = vec[i][2]
						string[] vecLine =chargeVectorMatRelease(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart);
						if (vecLine!=null)
							array.Add(vecLine);
						smtrpt = vec[i][2];
						smstxl=vec[i][3];
						smcpt=vec[i][4];
						smpart= vec[i][5];
						sumValuesMatReleases(acumulate,flag,vec,i,dates);//calculate the week and we sum in the correct backet                      
					}//end else
				}else{//avming.Equals(vec[i][1]
					string[] vecLine =chargeVectorMatRelease(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart);
					if (vecLine!=null)
						array.Add(vecLine);
					avming=vec[i][1];
					smtrpt = vec[i][2];
					smstxl=vec[i][3];
					smcpt=vec[i][4];
					smpart= vec[i][5];
					sumValuesMatReleases(acumulate,flag,vec,i,dates);//calculate the week and we sum in the correct backet                      
				}//end else        
			}else{//avmajg<> vec[i][0]
					string[] vecLine =chargeVectorMatRelease(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart);
					if (vecLine!=null)
						array.Add(vecLine);
					avmajg=vec[i][0];
					avming=vec[i][1];
					smtrpt = vec[i][2];
					smstxl=vec[i][3];
					smcpt=vec[i][4];
					smpart= vec[i][5];
					sumValuesMatReleases(acumulate,flag,vec,i,dates);//calculate the week and we sum in the correct backet  
			}//end else  
		}
	    
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		return returnArray;
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private string[] fillVectorMatRelease(decimal[] acumulate,string avmajg,string avming,string smtrpt,
			                          string smstxl,string smcpt,string smpart){
	try {
		string[] v = new String[25];

		v[0] = avmajg;
		v[1] = avming;
		v[2] = smtrpt;
		v[3] = smstxl;
		v[4] = smcpt;
		v[5] = smpart;
		v[6] = acumulate[0].ToString();
		v[7] = acumulate[1].ToString();
		v[8] = acumulate[2].ToString();
		v[9] = acumulate[3].ToString();
		v[10] = acumulate[4].ToString();
		v[11] = acumulate[5].ToString();
		v[12] = acumulate[6].ToString();
		v[13] = acumulate[7].ToString();
		v[14] = acumulate[8].ToString();
		v[15] = acumulate[9].ToString();
		v[16] = acumulate[10].ToString();
		v[17] = acumulate[11].ToString();
		v[18] = acumulate[12].ToString();
		v[19] = acumulate[13].ToString();
		v[20] = acumulate[14].ToString();
		v[21] = acumulate[15].ToString();
		v[22] = acumulate[16].ToString();
		v[23] = acumulate[17].ToString();
		decimal sum=0;
		for (int i=0; i<acumulate.Length;i++)
			sum+=acumulate[i];
		v[24] = sum.ToString();    
		return v;
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private string[] chargeVectorMatRelease(bool flagValue0,decimal[] acumulate,string avmajg,string avming,string smtrpt,
			                          string smstxl,string smcpt,string smpart){
	try {
		if (flagValue0){
			string[] v =  fillVectorMatRelease(acumulate,avmajg,avming,smtrpt,
								smstxl,smcpt,smpart);
			for (int i=0;i < acumulate.Length ;i++)
					acumulate[i] = 0;
			return v;
		}else   
			if (!checkValue(acumulate)){
				string[] v =  fillVectorMatRelease(acumulate,avmajg,avming,smtrpt,
								smstxl,smcpt,smpart);
				for (int i=0;i < acumulate.Length ;i++)
					acumulate[i] = 0;
				return v;
			} 
        		    
		for (int i=0;i < acumulate.Length ;i++)
				acumulate[i] = 0;
		return null;

	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
private void sumValuesMatReleases(decimal[] acumulate,bool flag,string[][] vec, int position,DateTime[] dates){
	try {
		int week = theWeekIs(vec[position][6],dates);//function that returns the week where we acumulate the record
		if (week < 0){//acumulate in past due
			if (flag)
				acumulate[0]+=decimal.Parse(vec[position][8]);
			else
				acumulate[0]+=decimal.Parse(vec[position][9]);
		}else{//acumulate in a week
			switch (week.ToString()){
			    case "0": //acumulate in week1
					if (flag)
						acumulate[1]+=decimal.Parse(vec[position][8]);
					else
						acumulate[1]+=decimal.Parse(vec[position][9]);
					break;
				case "1": //acumulate in week2
					if (flag)
						acumulate[2]+=decimal.Parse(vec[position][8]);
					else
						acumulate[2]+=decimal.Parse(vec[position][9]);
					break;
				case "2": //acumulate in week3
					if (flag)
						acumulate[3]+=decimal.Parse(vec[position][8]);
					else
						acumulate[3]+=decimal.Parse(vec[position][9]);
					break;
				case "3": //acumulate in week4
					if (flag)
						acumulate[4]+=decimal.Parse(vec[position][8]);
					else
						acumulate[4]+=decimal.Parse(vec[position][9]);
					break;
				case "4": //acumulate in week5
					if (flag)
						acumulate[5]+=decimal.Parse(vec[position][8]);
					else
						acumulate[5]+=decimal.Parse(vec[position][9]);
					break;
				case "5": //acumulate in week6
					if (flag)
						acumulate[6]+=decimal.Parse(vec[position][8]);
					else
						acumulate[6]+=decimal.Parse(vec[position][9]);
					break;
				case "6": //acumulate in week7
					if (flag)
						acumulate[7]+=decimal.Parse(vec[position][8]);
					else
						acumulate[7]+=decimal.Parse(vec[position][9]);
					break;
				case "7": //acumulate in week8
					if (flag)
						acumulate[8]+=decimal.Parse(vec[position][8]);
					else
						acumulate[8]+=decimal.Parse(vec[position][9]);
					break;
				case "8": //acumulate in week9
					if (flag)
						acumulate[9]+=decimal.Parse(vec[position][8]);
					else
						acumulate[9]+=decimal.Parse(vec[position][9]);
					break;
				case "9": //acumulate in week10
					if (flag)
						acumulate[10]+=decimal.Parse(vec[position][8]);
					else
						acumulate[10]+=decimal.Parse(vec[position][9]);
					break;
				case "10": //acumulate in week11
					if (flag)
						acumulate[11]+=decimal.Parse(vec[position][8]);
					else
						acumulate[11]+=decimal.Parse(vec[position][9]);
					break;
				case "11": //acumulate in week12
					if (flag)
						acumulate[12]+=decimal.Parse(vec[position][8]);
					else
						acumulate[12]+=decimal.Parse(vec[position][9]);
					break;
				case "12": //acumulate in week13
					if (flag)
						acumulate[13]+=decimal.Parse(vec[position][8]);
					else
						acumulate[13]+=decimal.Parse(vec[position][9]);
					break;
				case "13": //acumulate in week14
					if (flag)
						acumulate[14]+=decimal.Parse(vec[position][8]);
					else
						acumulate[14]+=decimal.Parse(vec[position][9]);
					break;
				case "14": //acumulate in week15
					if (flag)
						acumulate[15]+=decimal.Parse(vec[position][8]);
					else
						acumulate[15]+=decimal.Parse(vec[position][9]);
					break;
				case "15": //acumulate in week16
					if (flag)
						acumulate[16]+=decimal.Parse(vec[position][8]);
					else
						acumulate[16]+=decimal.Parse(vec[position][9]);
					break;
				case "16": //acumulate over weeks
					if (flag)
						acumulate[17]+=decimal.Parse(vec[position][8]);
					else
						acumulate[17]+=decimal.Parse(vec[position][9]);
					break;    
			}
		}
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private int theWeekIs(string day, DateTime[] dates){
// -1 - is in pastDue
// 0 - is in week 1 
// 1 - is in weel 2 and so on
// 16 - is out of te range of the dates that we are 
	try {
		DateTime theDay = DateUtil.parseDate(day,DateUtil.MMDDYYYY);
		int exit =0;
		for (int i= 0; i<dates.Length;i++){
			if (DateTime.Compare(theDay,dates[i])< 0)
				return --i;
			if (DateTime.Compare(theDay,dates[i])== 0)
				return i;
			else exit++;
		}
		return exit++;
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private void loadDates(DateTime[] dates){
	try {
		int lessDays=0; 
		switch (DateTime.Today.DayOfWeek.ToString()){
			case "Monday": 
						break;
			case "Tuesday": 
						lessDays = 1;
						break;
			case "Wednesday": 
						lessDays = 2;
						break;
			case "Thuersday": 
						lessDays = 3;
						break;
			case "Friday": 
						lessDays = 4;
						break;
			case "Saturday": 
						lessDays = 5;
						break;
			case "Sunday": 
						lessDays = 6;
						break;
		}
		dates[0] = DateTime.Today.AddDays(-lessDays);
		for (int i=1; i<dates.Length;i++){
			dates[i] = dates[i-1].AddDays(7);
		}
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private string[][] processRecordsShippingSchAcum(string[][] vec,bool flagReq,bool flagValue0){
	try {
		DateTime[] days = new DateTime[14];
		loadDays(days); 
		ArrayList array = new ArrayList();

		string avmajg = vec[0][0];
		string avming = vec[0][1];
		string smtrpt = vec[0][2];
		string smstxl = vec[0][3];
		string smcpt = vec[0][4];
		string smpart = vec[0][5];
		string pyhm = vec[0][7];
		decimal[] acumulate = new decimal[16]; //0 is pastDue, 1 week1 and so on
		for (int i = 0; i<acumulate.Length; i++)
			acumulate[i]= 0;
		for (int i=0; i < vec.Length;i++){
			if (avmajg.Equals(vec[i][0])){
				if (avming.Equals(vec[i][1])){
					if (smtrpt.Equals(vec[i][2])){
						if (smstxl.Equals(vec[i][3])){
							if (smcpt.Equals(vec[i][4])){
								if (smpart.Equals(vec[i][5])){
									sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet
									}else{//smpart.Equals(vec[i][5])
									string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
									if (vecLine!=null)
										array.Add(vecLine);
									smpart= vec[i][5];
									sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet
									}//end else
							}else{//smcpt.Equals(vec[i][4]
								string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
								if (vecLine!=null)
									array.Add(vecLine);
								smcpt=vec[i][4];
								smpart= vec[i][5];
								sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
							}//end else
						}else{//smstxl.Equals(vec[i][3])
							string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
							if (vecLine!=null)
								array.Add(vecLine);
							smstxl=vec[i][3];
							smcpt=vec[i][4];
							smpart= vec[i][5];
							sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
						}//end else
						}else{//smtrpt = vec[i][2]
						string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
						if (vecLine!=null)
							array.Add(vecLine);
						smtrpt = vec[i][2];
						smstxl=vec[i][3];
						smcpt=vec[i][4];
						smpart= vec[i][5];
						sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
					}//end else
				}else{//avming.Equals(vec[i][1]
					string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
					if (vecLine!=null)
						array.Add(vecLine);
					avming=vec[i][1];
					smtrpt = vec[i][2];
					smstxl=vec[i][3];
					smcpt=vec[i][4];
					smpart= vec[i][5];
					sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
				}//end else        
			}else{//avmajg<> vec[i][0]
					string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
					if (vecLine!=null)
						array.Add(vecLine);
					avmajg=vec[i][0];
					avming=vec[i][1];
					smtrpt = vec[i][2];
					smstxl=vec[i][3];
					smcpt=vec[i][4];
					smpart= vec[i][5];
					sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet  
			}//end else  
		}

		if (!flgChargeVec){
			string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
			if (vecLine!=null)
				array.Add(vecLine);
		}
		        
		int index = 0;
		string[][] returnArray = new string[array.Count][];
		for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
			string[] lineArray = (string[])en.Current;
			returnArray[index] = lineArray;
			index++;
		}
		return returnArray;    
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private bool checkValue(decimal[] acum){
	try {
		bool result = false;
		decimal sum=0;
		for (int i=0;i< acum.Length;i++)
			sum += acum[i];
		if (sum==0)
			result= true;
		return result;
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private void sumValuesShippingSch(decimal[] acumulate,bool flagReq,string[][] vec, int position,DateTime[] days){
	try { 
		DateTime todayDay = DateTime.Today;

		if ((DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[0]) < 0)){//is past due
		if (flagReq)
				acumulate[0]+=decimal.Parse(vec[position][8]);
		else
				acumulate[0]+=decimal.Parse(vec[position][9]);  
		}else{
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[0]) ==0){
				if (flagReq)
					acumulate[1]+=decimal.Parse(vec[position][8]);
				else
					acumulate[1]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[1])==0){
				if (flagReq)
					acumulate[2]+=decimal.Parse(vec[position][8]);
				else
					acumulate[2]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[2])==0){ //acumulate in day3
				if (flagReq)
					acumulate[2]+=decimal.Parse(vec[position][8]);
				else
					acumulate[2]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[3])==0){ //acumulate in day4
				if (flagReq)
					acumulate[3]+=decimal.Parse(vec[position][8]);
				else
					acumulate[3]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[4])==0){ //acumulate in day5
				if (flagReq)
					acumulate[4]+=decimal.Parse(vec[position][8]);
				else
					acumulate[4]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[5])==0){ //acumulate in day5
				if (flagReq)
					acumulate[5]+=decimal.Parse(vec[position][8]);
				else
					acumulate[5]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[6])==0){ //acumulate in day7
				if (flagReq)
					acumulate[6]+=decimal.Parse(vec[position][8]);
				else
					acumulate[6]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[7])==0){ //acumulate in day8
				if (flagReq)
					acumulate[8]+=decimal.Parse(vec[position][8]);
				else
					acumulate[8]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[8])==0){ //acumulate in day9
				if (flagReq)
					acumulate[9]+=decimal.Parse(vec[position][8]);
				else
					acumulate[9]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[9])==0){ //acumulate in day10
				if (flagReq)
					acumulate[10]+=decimal.Parse(vec[position][8]);
				else
					acumulate[10]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[10])==0){ //acumulate in day11
				if (flagReq)
					acumulate[11]+=decimal.Parse(vec[position][8]);
				else
					acumulate[11]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[11])==0){ //acumulate in day12
				if (flagReq)
					acumulate[12]+=decimal.Parse(vec[position][8]);
				else
					acumulate[12]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[12])==0){ //acumulate in day13
				if (flagReq)
					acumulate[13]+=decimal.Parse(vec[position][8]);
				else
					acumulate[13]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[12])==0){ //acumulate in day14
				if (flagReq)
					acumulate[13]+=decimal.Parse(vec[position][8]);
				else
					acumulate[13]+=decimal.Parse(vec[position][9]);  
			}
			if (DateTime.Compare(DateUtil.parseDate(vec[position][6],DateUtil.MMDDYYYY),days[12])>0){ //acumulate in day14
				if (flagReq)
					acumulate[14]+=decimal.Parse(vec[position][8]);
				else
					acumulate[14]+=decimal.Parse(vec[position][9]);  
			}
		}
	}catch (PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch (System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private void loadDays(DateTime[] days){
    for(int i=0;i<days.Length;i++)
        days[i] = DateTime.Today.AddDays(i);
}

private string[] fillVecShippingSch(decimal[] acumulate,string avmajg,string avming,string smtrpt,
                          string smstxl,string smcpt,string smpart,string pyhm){
	string[] v= new String[24];

    v[0] = avmajg;
    v[1] = avming;
    v[2] = smtrpt;
    v[3] = smstxl;
    v[4] = smcpt;
    v[5] = smpart;
    v[6] = formatHour(pyhm);
    v[7] = acumulate[0].ToString();
    v[8] = acumulate[1].ToString();
    v[9] = acumulate[2].ToString();
    v[10] = acumulate[3].ToString();
    v[11] = acumulate[4].ToString();
    v[12] = acumulate[5].ToString();
    v[13] = acumulate[6].ToString();
    v[14] = acumulate[7].ToString();
    v[15] = acumulate[8].ToString();
    v[16] = acumulate[9].ToString();
    v[17] = acumulate[10].ToString();
    v[18] = acumulate[11].ToString();
    v[19] = acumulate[12].ToString();
    v[20] = acumulate[13].ToString();
    v[21] = acumulate[14].ToString();
    v[22] = acumulate[15].ToString(); 
    decimal sum=0;
    for(int i=0; i<acumulate.Length;i++)
        sum+=acumulate[i];
    v[23]= sum.ToString();
    return v;                         
}
private string[] chargeVectorShippingSch(bool flagValue0,decimal[] acumulate,string avmajg,string avming,string smtrpt,
                          string smstxl,string smcpt,string smpart,string pyhm){
   
    if (flagValue0){
        string[] v = fillVecShippingSch(acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
        for (int i=0 ; i < acumulate.Length;i++)
            acumulate[i] = 0;
        if (!flgChargeVec)   
            flgChargeVec = true;
        return v;        
   }else //we must insert only if the columns are 0
        if (!checkValue(acumulate)){
            string[] v = fillVecShippingSch(acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
            for (int i=0 ; i < acumulate.Length;i++)
                acumulate[i] = 0;
            if (!flgChargeVec)   
                flgChargeVec = true;
            return v;    
        }
   
    for (int i=0 ; i < acumulate.Length;i++)
        acumulate[i] = 0;
    return null;

}


private string[][] processRecordsShippingSchDtl(string[][] vec,bool flagReq,bool flagValue0){
    DateTime[] days = new DateTime[14];
    loadDays(days); 
    ArrayList array = new ArrayList();
    string avmajg = vec[0][0];
    string avming = vec[0][1];
    string smtrpt = vec[0][2];
    string smstxl = vec[0][3];
    string smcpt = vec[0][4];
    string smpart = vec[0][5];
    string pyhm = vec[0][7];
    decimal[] acumulate = new decimal[16]; //0 is pastDue, 1 week1 and so on
    for (int i = 0; i<acumulate.Length; i++)
        acumulate[i]= 0;
    for (int i=0; i < vec.Length;i++){
        if (avmajg.Equals(vec[i][0])){
            if (avming.Equals(vec[i][1])){
                if (smtrpt.Equals(vec[i][2])){
                    if (smstxl.Equals(vec[i][3])){
                        if (smcpt.Equals(vec[i][4])){
                            if (smpart.Equals(vec[i][5])){
                                if (pyhm.Equals(vec[i][7]))
                                    sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet
                                else{
                                    string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                                    if (vecLine!=null)
                                        array.Add(vecLine);
                                    pyhm= vec[i][7];
                                    sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet   
                                }//end else
                             }else{//smpart.Equals(vec[i][5])
                                string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                                if (vecLine!=null)
                                    array.Add(vecLine);
                                smpart= vec[i][5];
                                pyhm= vec[i][7];
                                sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet
                             }//end else
                        }else{//smcpt.Equals(vec[i][4]
                            string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                            if (vecLine!=null)
                                array.Add(vecLine);
                            smcpt=vec[i][4];
                            smpart= vec[i][5];
                            pyhm= vec[i][7];
                            sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
                        }//end else
                    }else{//smstxl.Equals(vec[i][3])
                        string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                        if (vecLine!=null)
                            array.Add(vecLine);
                        smstxl=vec[i][3];
                        smcpt=vec[i][4];
                        smpart= vec[i][5];
                        pyhm= vec[i][7];
                        sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
                    }//end else
                 }else{//smtrpt = vec[i][2]
                    string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                    if (vecLine!=null)
                        array.Add(vecLine);
                    smtrpt = vec[i][2];
                    smstxl=vec[i][3];
                    smcpt=vec[i][4];
                    smpart= vec[i][5];
                    pyhm= vec[i][7];
                    sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
                }//end else
            }else{//avming.Equals(vec[i][1]
                string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                if (vecLine!=null)
                    array.Add(vecLine);
                avming=vec[i][1];
                smtrpt = vec[i][2];
                smstxl=vec[i][3];
                smcpt=vec[i][4];
                smpart= vec[i][5];
                pyhm= vec[i][7];
                sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet                      
            }//end else        
        }else{//avmajg<> vec[i][0]
                string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                if (vecLine!=null)
                    array.Add(vecLine);
                avmajg=vec[i][0];
                avming=vec[i][1];
                smtrpt = vec[i][2];
                smstxl=vec[i][3];
                smcpt=vec[i][4];
                smpart= vec[i][5];
                pyhm= vec[i][7];
                sumValuesShippingSch(acumulate,flagReq,vec,i,days);//calculate the week and we sum in the correct backet  
        }//end else  
    }
    
    if (!flgChargeVec){
        string[] vecLine =chargeVectorShippingSch(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
        if (vecLine!=null)
            array.Add(vecLine);
    }
    
    int index = 0;
    string[][] returnArray = new string[array.Count][];
    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		string[] lineArray = (string[])en.Current;
		returnArray[index] = lineArray;
		index++;
	}
    return returnArray;    
}
private string formatHour(string hour){
  string retHour="";
 
  if (hour.Length==1)
        retHour = "0"+hour +":00"; 
  else{
    if (hour.Length<=3) //the hour is between 0:00 and 9:59
        retHour = "0"+(hour.Substring(0,1))+":" +(hour.Substring(1,2));
    else  //the hour is between 10:00 to 23:59
        retHour = (hour.Substring(0,2))+":" +(hour.Substring(2,2));
    
  }
  return retHour;
}

private string[][] processRecordsShippingSchAcumByWeek(string[][]vec ,bool flagReq,bool flagValue0){
    DateTime[] dates = new DateTime[30];
    loadDates(dates); 
    ArrayList array = new ArrayList();
    string avmajg = vec[0][0];
    string avming = vec[0][1];
    string smtrpt = vec[0][2];
    string smstxl = vec[0][3];
    string smcpt = vec[0][4];
    string smpart = vec[0][5];
    string pyhm = vec[0][6];
    decimal[] acumulate = new decimal[32]; //0 is pastDue, 1 week1 and so on
    for (int i = 0; i<acumulate.Length; i++)
        acumulate[i]= 0;
        
    for (int i=0; i < vec.Length;i++){
        if (avmajg.Equals(vec[i][0])){
            if (avming.Equals(vec[i][1])){
                if (smtrpt.Equals(vec[i][2])){
                    if (smstxl.Equals(vec[i][3])){
                        if (smcpt.Equals(vec[i][4])){
                            if (smpart.Equals(vec[i][5])){
                                sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet
                             }else{//smpart.Equals(vec[i][5])
                                string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,vec[i][7]);
                                if (vecLine!=null)
                                    array.Add(vecLine);
                                smpart= vec[i][5];
                                sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet
                             }//end else
                        }else{//smcpt.Equals(vec[i][4]
                            string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,vec[i][7]);
                            if (vecLine!=null)
                                array.Add(vecLine);
                            smcpt=vec[i][4];
                            smpart= vec[i][5];
                            sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
                        }//end else
                    }else{//smstxl.Equals(vec[i][3])
                        string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,vec[i][7]);
                        if (vecLine!=null)
                            array.Add(vecLine);
                        smstxl=vec[i][3];
                        smcpt=vec[i][4];
                        smpart= vec[i][5];
                        sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
                    }//end else
                 }else{//smtrpt = vec[i][2]
                    string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,vec[i][7]);
                    if (vecLine!=null)
                        array.Add(vecLine);
                    smtrpt = vec[i][2];
                    smstxl=vec[i][3];
                    smcpt=vec[i][4];
                    smpart= vec[i][5];
                    sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
                }//end else
            }else{//avming.Equals(vec[i][1]
                string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,vec[i][7]);
                if (vecLine!=null)
                    array.Add(vecLine);
                avming=vec[i][1];
                smtrpt = vec[i][2];
                smstxl=vec[i][3];
                smcpt=vec[i][4];
                smpart= vec[i][5];
                sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
            }//end else        
        }else{//avmajg<> vec[i][0]
                 string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,vec[i][7]);
                if (vecLine!=null)
                    array.Add(vecLine);
                avmajg=vec[i][0];
                avming=vec[i][1];
                smtrpt = vec[i][2];
                smstxl=vec[i][3];
                smcpt=vec[i][4];
                smpart= vec[i][5];
                sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet  
        }//end else  
    }
    
    if (!flgChargeVec){
        string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,vec[vec.Length-1][7]);
        if (vecLine!=null)
            array.Add(vecLine);
    }
    
    int index = 0;
    string[][] returnArray = new string[array.Count][];
    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		string[] lineArray = (string[])en.Current;
		returnArray[index] = lineArray;
		index++;
	}
    return returnArray;
}


private  void sumValuesShipSchByWeek(decimal[] acumulate,bool flag,string [][]vec,int position ,DateTime[] dates){
 int week = theWeekIs(vec[position][6],dates);//function that returns the week where we acumulate the record
 if (week < 0){//acumulate in past due
    if (flag)
        acumulate[0]+=decimal.Parse(vec[position][8]);
    else
        acumulate[0]+=decimal.Parse(vec[position][9]);
 }else{
    switch (week.ToString()){
	    case "0": //acumulate in week1
	            if (flag)
                    acumulate[1]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[1]+=decimal.Parse(vec[position][9]);
		        break;
		case "1": //acumulate in week2
		        if (flag)
                    acumulate[2]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[2]+=decimal.Parse(vec[position][9]);
		        break;
		case "2": //acumulate in week3
		        if (flag)
                    acumulate[3]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[3]+=decimal.Parse(vec[position][9]);
		        break;
		case "3": //acumulate in week4
		        if (flag)
                    acumulate[4]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[4]+=decimal.Parse(vec[position][9]);
		        break;
		case "4": //acumulate in week5
		        if (flag)
                    acumulate[5]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[5]+=decimal.Parse(vec[position][9]);
		        break;
		case "5": //acumulate in week6
		        if (flag)
                    acumulate[6]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[6]+=decimal.Parse(vec[position][9]);
		        break;
		case "6": //acumulate in week7
		        if (flag)
                    acumulate[7]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[7]+=decimal.Parse(vec[position][9]);
		        break;
		case "7": //acumulate in week8
		        if (flag)
                    acumulate[8]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[8]+=decimal.Parse(vec[position][9]);
		        break;
		case "8": //acumulate in week9
		        if (flag)
                    acumulate[9]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[9]+=decimal.Parse(vec[position][9]);
                break;
		case "9": //acumulate in week10
		        if (flag)
                    acumulate[10]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[10]+=decimal.Parse(vec[position][9]);
                break;
		case "10": //acumulate in week11
		        if (flag)
                    acumulate[11]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[11]+=decimal.Parse(vec[position][9]);
                break;
		case "11": //acumulate in week12
		        if (flag)
                    acumulate[12]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[12]+=decimal.Parse(vec[position][9]);
                break;
		case "12": //acumulate in week13
		        if (flag)
                    acumulate[13]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[13]+=decimal.Parse(vec[position][9]);
                break;
		case "13": //acumulate in week14
		        if (flag)
                    acumulate[14]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[14]+=decimal.Parse(vec[position][9]);
                break;
		case "14": //acumulate in week15
		        if (flag)
                    acumulate[15]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[15]+=decimal.Parse(vec[position][9]);
                break;
		case "15": //acumulate in week16
		        if (flag)
                    acumulate[16]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[16]+=decimal.Parse(vec[position][9]);
                break;
		case "16": //acumulate in week16
		        if (flag)
                    acumulate[17]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[17]+=decimal.Parse(vec[position][9]);
                break;    
		case "17": //acumulate in week1
	            if (flag)
                    acumulate[18]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[18]+=decimal.Parse(vec[position][9]);
		        break;
		case "18": //acumulate in week2
		        if (flag)
                    acumulate[19]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[19]+=decimal.Parse(vec[position][9]);
		        break;
		case "19": //acumulate in week3
		        if (flag)
                    acumulate[20]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[20]+=decimal.Parse(vec[position][9]);
		        break;
		case "20": //acumulate in week4
		        if (flag)
                    acumulate[21]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[21]+=decimal.Parse(vec[position][9]);
		        break;
		case "21": //acumulate in week5
		        if (flag)
                    acumulate[22]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[22]+=decimal.Parse(vec[position][9]);
		        break;
		case "22": //acumulate in week6
		        if (flag)
                    acumulate[23]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[23]+=decimal.Parse(vec[position][9]);
		        break;
		case "26": //acumulate in week7
		        if (flag)
                    acumulate[24]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[24]+=decimal.Parse(vec[position][9]);
		        break;
		case "27": //acumulate in week8
		        if (flag)
                    acumulate[28]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[28]+=decimal.Parse(vec[position][9]);
		        break;
		case "28": //acumulate in week9
		        if (flag)
                    acumulate[29]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[29]+=decimal.Parse(vec[position][9]);
                break;
		case "29": //acumulate in week10
		        if (flag)
                    acumulate[30]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[30]+=decimal.Parse(vec[position][9]);
                break;
		case "30": //acumulate in week11
		        if (flag)
                    acumulate[31]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[31]+=decimal.Parse(vec[position][9]);
                break;
		case "31": //acumulate in week12
		        if (flag)
                    acumulate[32]+=decimal.Parse(vec[position][8]);
                else
                    acumulate[32]+=decimal.Parse(vec[position][9]);
                break;
		} 
 }
}

private string[] fillVecShipSchByWeek(decimal[] acumulate,string avmajg,string avming,string smtrpt,
                          string smstxl,string smcpt,string smpart,string pyhm){
    string[] v = new String[40];
    v[0] = avmajg;
    v[1] = avming;
    v[2] = smtrpt;
    v[3] = smstxl;
    v[4] = smcpt;
    v[5] = smpart;
    v[6] = formatHour(pyhm);
    v[7] = acumulate[0].ToString();
    v[8] = acumulate[1].ToString();
    v[9] = acumulate[2].ToString();
    v[10] = acumulate[3].ToString();
    v[11] = acumulate[4].ToString();
    v[12] = acumulate[5].ToString();
    v[13] = acumulate[6].ToString();
    v[14] = acumulate[7].ToString();
    v[15] = acumulate[8].ToString();
    v[16] = acumulate[9].ToString();
    v[17] = acumulate[10].ToString();
    v[18] = acumulate[11].ToString();
    v[19] = acumulate[12].ToString();
    v[20] = acumulate[13].ToString();
    v[21] = acumulate[14].ToString();
    v[22] = acumulate[15].ToString();
    v[23] = acumulate[16].ToString();
    v[24] = acumulate[17].ToString();
    v[25] = acumulate[18].ToString();
    v[26] = acumulate[19].ToString();
    v[27] = acumulate[20].ToString();
    v[28] = acumulate[21].ToString();
    v[29] = acumulate[22].ToString();
    v[30] = acumulate[23].ToString();
    v[31] = acumulate[24].ToString();
    v[32] = acumulate[25].ToString();
    v[33] = acumulate[26].ToString();
    v[34] = acumulate[27].ToString();
    v[35] = acumulate[28].ToString();
    v[36] = acumulate[29].ToString();
    v[37] = acumulate[30].ToString();
    v[38] = acumulate[31].ToString();
    decimal sum=0;
    for (int i=0; i<acumulate.Length;i++)
        sum+=acumulate[i];
    v[39] = sum.ToString(); 
       
    return v;
}
private string[] chargeVecShipSchByWeek(bool flagValue0,decimal[] acumulate,string avmajg,string avming,string smtrpt,
                          string smstxl,string smcpt,string smpart,string pyhm){
   
    if (flagValue0){
        string[] v =  fillVecShipSchByWeek(acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
        for (int i=0;i < acumulate.Length ;i++)
                acumulate[i] = 0;
        if (!flgChargeVec)
               flgChargeVec = true;
        return v;
    }else   
        if (!checkValue(acumulate)){
            string[] v =  fillVecShipSchByWeek(acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
            for (int i=0;i < acumulate.Length ;i++)
                acumulate[i] = 0;
            if (!flgChargeVec)
               flgChargeVec = true;
            return v;
        } 
        
     for (int i=0;i < acumulate.Length ;i++)
                acumulate[i] = 0;
     return null;

}

private string[][]processRecordsShippingSchDtlByWeek(string[][] vec,bool flagReq, bool flagValue0){
     
    DateTime[] dates = new DateTime[30];
    loadDates(dates); 
    ArrayList array = new ArrayList();
    string avmajg = vec[0][0];
    string avming = vec[0][1];
    string smtrpt = vec[0][2];
    string smstxl = vec[0][3];
    string smcpt = vec[0][4];
    string smpart = vec[0][5];
    string pyhm = vec[0][7];
    decimal[] acumulate = new decimal[32]; //0 is pastDue, 1 week1 and so on
    for (int i = 0; i<acumulate.Length; i++)
        acumulate[i]= 0;
     for (int i=0; i < vec.Length;i++){
        if (avmajg.Equals(vec[i][0])){
            if (avming.Equals(vec[i][1])){
                if (smtrpt.Equals(vec[i][2])){
                    if (smstxl.Equals(vec[i][3])){
                        if (smcpt.Equals(vec[i][4])){
                            if (smpart.Equals(vec[i][5])){
                                if (pyhm.Equals(vec[i][7]))
                                    sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet
                                else{
                                    string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                                    if (vecLine!=null)
                                        array.Add(vecLine);
                                    pyhm= vec[i][7];
                                    sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet   
                                }//end else
                             }else{//smpart.Equals(vec[i][5])
                                string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                                if (vecLine!=null)
                                    array.Add(vecLine);
                                smpart= vec[i][5];
                                pyhm= vec[i][7];
                                sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet
                             }//end else
                        }else{//smcpt.Equals(vec[i][4]
                            string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                            if (vecLine!=null)
                                array.Add(vecLine);
                            smcpt=vec[i][4];
                            smpart= vec[i][5];
                            pyhm= vec[i][7];
                            sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
                        }//end else
                    }else{//smstxl.Equals(vec[i][3])
                        string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                        if (vecLine!=null)
                            array.Add(vecLine);
                        smstxl=vec[i][3];
                        smcpt=vec[i][4];
                        smpart= vec[i][5];
                        pyhm= vec[i][7];
                        sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
                    }//end else
                 }else{//smtrpt = vec[i][2]
                    string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                    if (vecLine!=null)
                        array.Add(vecLine);
                    smtrpt = vec[i][2];
                    smstxl=vec[i][3];
                    smcpt=vec[i][4];
                    smpart= vec[i][5];
                    pyhm= vec[i][7];
                    sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
                }//end else
            }else{//avming.Equals(vec[i][1]
                string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                if (vecLine!=null)
                    array.Add(vecLine);
                avming=vec[i][1];
                smtrpt = vec[i][2];
                smstxl=vec[i][3];
                smcpt=vec[i][4];
                smpart= vec[i][5];
                pyhm= vec[i][7];
                sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet                      
            }//end else        
        }else{//avmajg<> vec[i][0]
                string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
                if (vecLine!=null)
                    array.Add(vecLine);
                avmajg=vec[i][0];
                avming=vec[i][1];
                smtrpt = vec[i][2];
                smstxl=vec[i][3];
                smcpt=vec[i][4];
                smpart= vec[i][5];
                pyhm= vec[i][7];
                sumValuesShipSchByWeek(acumulate,flagReq,vec,i,dates);//calculate the week and we sum in the correct backet  
        }//end else  
    }
    
    if (!flgChargeVec){
        string[] vecLine =chargeVecShipSchByWeek(flagValue0,acumulate,avmajg,avming,smtrpt,smstxl,smcpt,smpart,pyhm);
        if (vecLine!=null)
           array.Add(vecLine); 
    }
    
    int index = 0;
    string[][] returnArray = new string[array.Count][];
    for(IEnumerator en = array.GetEnumerator(); en.MoveNext(); ){
		string[] lineArray = (string[])en.Current;
		returnArray[index] = lineArray;
		index++;
	}
    return returnArray;
}

}

}
