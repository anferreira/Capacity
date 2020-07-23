using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Reports;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Reports;
using Nujit.NujitERP.ClassLib.Common;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;

namespace Nujit.NujitERP.ClassLib.Core.Util{

	
public 
class ReportsCoreFactory : ProductPlanCoreFactory{

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


/*************************************** Report 1268 ***************************************************/
public
RP1268H createRP1268H(){
	return new RP1268H();
}

public
RP1268HContainer createRP1268HContainer(){
	return new RP1268HContainer();
}

public
bool existsRP1268H(int id){
	try{        
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 

		RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);

		rP1268HDataBase.setId(id);

		return rP1268HDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
RP1268H readRP1268H(int id){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 

		RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);
		rP1268HDataBase.setId(id);

		if (!rP1268HDataBase.read())
			return null;

		RP1268H rP1268H = this.objectDataBaseToObject(rP1268HDataBase);

		return rP1268H;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
string[][] getRP1268HByDesc(string searchText, int rows){
	try{
		RP1268HDataBaseContainer rP1268HDataBaseContainer = new RP1268HDataBaseContainer(dataBaseAccess);
		rP1268HDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[rP1268HDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = rP1268HDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			RP1268HDataBase rP1268HDataBase = (RP1268HDataBase) en.Current;
			string[] item = new String[2];
			item[0] = rP1268HDataBase.getId().ToString();
			item[1] = rP1268HDataBase.getDate().ToString();
			items[i] = item;
			i++;
		}
		return items;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateRP1268H(RP1268H rP1268H){
	try{		
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 

		RP1268HDataBase rP1268HDataBase = this.objectToObjectDataBase(rP1268H);
		rP1268HDataBase.update();


	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public 
void writeRP1268H(RP1268H rP1268H){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 

        writeRP1268HInternal(rP1268H);		

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

internal
void writeRP1268HInternal(RP1268H rP1268H){
    RP1268HDataBaseContainer rP1268HDataBaseContainer = new RP1268HDataBaseContainer(dataBaseAccess);
    int ihdr = rP1268HDataBaseContainer.readMAxId() + 1;
    //System.Windows.Forms.MessageBox.Show("New ihdr:" + ihdr.ToString());

    rP1268H.Id = ihdr;            
    RP1268HDataBase rP1268HDataBase = this.objectToObjectDataBase(rP1268H);
    try{
        if (rP1268H.Status.Equals(Constants.STATUS_ACTIVE))
            rP1268HDataBase.setStatus("P"); //set processing
		rP1268HDataBase.write();
    }catch (Exception ex){        
        if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		    throw new NujitException(ex.Message, ex);
    }	

    writeRP1268HChilds(rP1268H);

    if (rP1268H.Status.Equals(Constants.STATUS_ACTIVE)){
        try{		    
            rP1268HDataBase.setStatus(rP1268H.Status);//now we can set it Status=Active, because all child records stored
            rP1268HDataBase.update();
        }catch (Exception ex){        
            if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		        throw new NujitException(ex.Message, ex);
        }
        try{		    
            rP1268HDataBase.updateAllStatusExceptOneId(rP1268HDataBase.getId(),Constants.STATUS_COMPLETE);
        }catch (Exception ex){        
            if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		        throw new NujitException(ex.Message, ex);
        }
    }                	
    
}

public 
void writeRP1268HChilds(RP1268H rP1268H){
    rP1268H.fillRedundances();
    
    for (int i = 0; i < rP1268H.RP1268DContainer.Count; i++){
        RP1268D rP1268D = rP1268H.RP1268DContainer[i];
        RP1268DDataBase rP1268DDataBase = objectToObjectDataBase(rP1268D);

        try{
		    rP1268DDataBase.write();
        }catch (Exception ex){
            if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		        throw new NujitException(ex.Message, ex);
        }
        
        for (int j = 0; j < rP1268D.RP1268SContainer.Count; j++){
            RP1268S rP1268S = rP1268D.RP1268SContainer[j];
            RP1268SDataBase rP1268SDataBase = objectToObjectDataBase(rP1268S);            
            try{
		        rP1268SDataBase.write();
            }catch (Exception ex){
                if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		            throw new NujitException(ex.Message, ex);
            }
        }        
    }    
}

public
void deleteRP1268ExceptID(int id){
    RP1268SDataBaseContainer rP1268SDataBaseContainer =  new RP1268SDataBaseContainer(dataBaseAccess);
    RP1268DDataBaseContainer rP1268DDataBaseContainer =  new RP1268DDataBaseContainer(dataBaseAccess);
    RP1268HDataBaseContainer rP1268HDataBaseContainer =  new RP1268HDataBaseContainer(dataBaseAccess);

    try{
		rP1268SDataBaseContainer.deleteExceptId(id);
    }catch (Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		    throw new NujitException(ex.Message, ex);
    }

    try{
		rP1268DDataBaseContainer.deleteExceptId(id);
    }catch (Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		    throw new NujitException(ex.Message, ex);
    }

    try{
        rP1268HDataBaseContainer.deleteExceptId(id);
    }catch (Exception ex){
        if (ex.Message.ToLower().IndexOf("overflow") < 0)			
		    throw new NujitException(ex.Message, ex);
    }
}

public
void deleteRP1268H(int id){
	try{
		RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);

		rP1268HDataBase.setId(id);
		rP1268HDataBase.delete();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private
ArrayList getReport1268(){
    ArrayList alist = new ArrayList();

    RP1268HDataBaseContainer rP1268HDataBaseContainer = new RP1268HDataBaseContainer(dataBaseAccess);
    alist = rP1268HDataBaseContainer.getReport1268();

    //System.Windows.Forms.MessageBox.Show("Start addWipPartsDemands");
    addWipPartsDemands(alist);
    //System.Windows.Forms.MessageBox.Show("End addWipPartsDemands");

    return alist;
}

public
ArrayList runReport1268(){
    try{
        ArrayList alist= new ArrayList();
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
        
        alist = getReport1268();

        return alist;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
RP1268H runStoreReport1268(out ArrayList alist){
    alist = new ArrayList();
	try{
        RP1268H     rP1268H = new RP1268H();
        RP1268D     rP1268D = null;
        RP1268S     rP1268S = null;
        int         j = 0;
        Hashtable   hashRecQtys = new Hashtable();
        Hashtable   hashDateFirstReceipts = new Hashtable();
                        
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 
        		
        alist = getReport1268();
        //System.Windows.Forms.MessageBox.Show("End Get Query");

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE); 
        
        for (int i=0; i < alist.Count;i++){
            string[]    line = (string[]) alist[i];
            string[]    matItems = null;
            string[]    mtPartItems = null;
            string      smainMaterial = line[1];
            string      smtPart = line[2];

            if (!string.IsNullOrEmpty(smainMaterial) && !string.IsNullOrEmpty(smtPart)){//parse MainMaterial info
                matItems = smainMaterial.Split('\n');
                mtPartItems= smtPart.Split('\n');
            }

            rP1268D = new RP1268D();
            rP1268D.Part = line[0]; //System.Windows.Forms.MessageBox.Show("Dtl Part:" + rP1268D.Part);
            rP1268D.RTPart = Convert.ToDecimal(line[3]);
            rP1268D.Part10 = Convert.ToDecimal(line[4]);
            rP1268D.Part20 = Convert.ToDecimal(line[5]);
            rP1268D.Part30 = Convert.ToDecimal(line[6]);
            rP1268D.Part40 = Convert.ToDecimal(line[7]);
            rP1268D.Part50 = Convert.ToDecimal(line[8]);
            rP1268D.Part60 = Convert.ToDecimal(line[9]);
            rP1268D.Part70 = Convert.ToDecimal(line[10]);
            rP1268D.Part80 = Convert.ToDecimal(line[11]);
            rP1268D.Part90 = Convert.ToDecimal(line[12]);
            rP1268D.Part100 = Convert.ToDecimal(line[13]);
            rP1268D.Part110 = Convert.ToDecimal(line[14]);
            rP1268D.Part120 = Convert.ToDecimal(line[15]);
            rP1268D.Part130 = Convert.ToDecimal(line[16]);
            rP1268D.Part140 = Convert.ToDecimal(line[17]);
            rP1268D.Part150 = Convert.ToDecimal(line[18]);
            rP1268D.Part160 = Convert.ToDecimal(line[19]);

            rP1268D.QtyHold = Convert.ToDecimal(line[20]);
            rP1268D.FinGood = Convert.ToDecimal(line[21]);
            rP1268D.NetQoh = Convert.ToDecimal(line[22]);

            rP1268D.CDPast = Convert.ToDecimal(line[23]);
            rP1268D.CDWeek1 = Convert.ToDecimal(line[24]);
            rP1268D.CDWeek2 = Convert.ToDecimal(line[25]);
            rP1268D.CDWeek3 = Convert.ToDecimal(line[26]);
            rP1268D.CDWeek4 = Convert.ToDecimal(line[27]);
            rP1268D.CDWeek5 = Convert.ToDecimal(line[28]);
            rP1268D.CDWeek6 = Convert.ToDecimal(line[29]);
            rP1268D.CDWeek7 = Convert.ToDecimal(line[30]);
            rP1268D.CDWeek8 = Convert.ToDecimal(line[31]);

            rP1268D.CDWeek9 = Convert.ToDecimal(line[32]);
            rP1268D.CDWeek10 = Convert.ToDecimal(line[33]);
            rP1268D.CDWeek11 = Convert.ToDecimal(line[34]);
            rP1268D.CDWeek12 = Convert.ToDecimal(line[35]);
            rP1268D.CDWeek13 = Convert.ToDecimal(line[36]);
            rP1268D.CDWeek14 = Convert.ToDecimal(line[37]);
            rP1268D.AVMING =  line[38];
            rP1268D.AVMAJG =  line[39];
            rP1268D.ENGCHANGE = line[40];
            rP1268D.QTYG12 = Convert.ToDecimal(line[41]);

            for (j=0; matItems!= null && j < matItems.Length;j++){                
                rP1268S = new RP1268S();
                rP1268S.MainMat = matItems[j];  //main part
                if (mtPartItems!=null && j < mtPartItems.Length)
                    rP1268S.Qty = Convert.ToDecimal(mtPartItems[j]);//qty

                loadQtyReceivedAndFirstDateReceipts(hashRecQtys,hashDateFirstReceipts,rP1268D.Part,rP1268S);
                rP1268D.RP1268SContainer.Add(rP1268S);
            }            
            rP1268H.RP1268DContainer.Add(rP1268D);            
        }

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);//refresh connection

        rP1268H.Status = Constants.STATUS_ACTIVE;
        writeRP1268HInternal(rP1268H);
        deleteRP1268ExceptID(rP1268H.Id); //delete all except last processed

        //System.Windows.Forms.MessageBox.Show("End Write All");

        return rP1268H;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private
void loadQtyReceivedAndFirstDateReceipts(Hashtable hashRecQtys, Hashtable hashDateFirstReceipts,string sparentPart,RP1268S rP1268S){    
    decimal[]               dVecRecQtys = new decimal[4];
    DateTime[]              DateFirstReceipts = new DateTime[2];
    MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
    decimal                 dAQQPPC = metHdmDataBaseContainer.getAQQPPC(sparentPart,rP1268S.MainMat);       
    dAQQPPC = dAQQPPC == 0 ? 1 : dAQQPPC; //just in case, fill 1 if 0, because will be used for divide

    //test qty received
    if (hashRecQtys.ContainsKey(rP1268S.MainMat))    //check if part already found QtyReceived            
        dVecRecQtys = (decimal[])hashRecQtys[rP1268S.MainMat];
    else{                              
        dVecRecQtys = new decimal[4];                                  
        RP1268HDataBaseContainer rP1268HDataBaseContainerAux = new RP1268HDataBaseContainer(dataBaseAccess);
        for (int irecQty = 0; irecQty< dVecRecQtys.Length; irecQty++)
            dVecRecQtys[irecQty] = rP1268HDataBaseContainerAux.getReceivedQtyFromPartWeek(rP1268S.MainMat,irecQty);

        hashRecQtys.Add(rP1268S.MainMat,dVecRecQtys);
    }
    rP1268S.WK1RECQTY= dVecRecQtys[0] / dAQQPPC;
    rP1268S.WK2RECQTY= dVecRecQtys[1] / dAQQPPC;
    rP1268S.WK3RECQTY= dVecRecQtys[2] / dAQQPPC;
    rP1268S.WK4RECQTY= dVecRecQtys[3] / dAQQPPC;

    //date receipts    
    if (hashDateFirstReceipts.ContainsKey(rP1268S.MainMat))    //check if part already found QtyReceived            
        DateFirstReceipts = (DateTime[])hashDateFirstReceipts[rP1268S.MainMat];
    else{                              
        DateFirstReceipts = new DateTime[2];                               
        RP1268HDataBaseContainer rP1268HDataBaseContainerAux = new RP1268HDataBaseContainer(dataBaseAccess);
        for (int irecQty = 0; irecQty< DateFirstReceipts.Length; irecQty++)
            DateFirstReceipts[irecQty] = rP1268HDataBaseContainerAux.getDatesFirstReceipts(rP1268S.MainMat,irecQty);

        hashDateFirstReceipts.Add(rP1268S.MainMat,DateFirstReceipts);
    }  
    rP1268S.WK1RECDAT= DateFirstReceipts[0];
    rP1268S.WK2RECDAT= DateFirstReceipts[1];
}

public
ArrayList getStoredReport1268(int iheaderID,out DateTime dateProcessed){
    dateProcessed = DateUtil.MinValue;
    bool            bresult=false;
    try{
        ArrayList alist= new ArrayList();
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);
        if (iheaderID > 0){
            rP1268HDataBase.setId(iheaderID);
            bresult = rP1268HDataBase.read();
        }else
            bresult = rP1268HDataBase.readLastByStatus(Constants.STATUS_ACTIVE);

        if (bresult){
            dateProcessed = rP1268HDataBase.getDate();

            RP1268HDataBaseContainer rP1268HDataBaseContainer = new RP1268HDataBaseContainer(dataBaseAccess);
            alist = rP1268HDataBaseContainer.getStoredReport1268(iheaderID);
        }
        return alist;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

private
RP1268H objectDataBaseToObject(RP1268HDataBase rP1268HDataBase){
	RP1268H rP1268H = new RP1268H();

	rP1268H.Id=rP1268HDataBase.getId();
	rP1268H.Date=rP1268HDataBase.getDate();
    rP1268H.Time = rP1268HDataBase.getTime();
    rP1268H.Status = rP1268HDataBase.getStatus();

	return rP1268H;
}

private
RP1268HDataBase objectToObjectDataBase(RP1268H rP1268H){
	RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);
	rP1268HDataBase.setId(rP1268H.Id);
	rP1268HDataBase.setDate(rP1268H.Date);
    rP1268HDataBase.setTime(rP1268H.Time);
    rP1268HDataBase.setStatus(rP1268H.Status);

    return rP1268HDataBase;
}

public
RP1268H cloneRP1268H(RP1268H rP1268H){
	RP1268H rP1268HClone = new RP1268H();

	rP1268HClone.Id=rP1268H.Id;
	rP1268HClone.Date=rP1268H.Date;
    rP1268HClone.Time = rP1268H.Time;
    rP1268HClone.Status = rP1268H.Status;

	return rP1268HClone;
}

public
RP1268D createRP1268D(){
	return new RP1268D();
}

public
RP1268DContainer createRP1268DContainer(){
	return new RP1268DContainer();
}


private
RP1268D objectDataBaseToObject(RP1268DDataBase rP1268DDataBase){
	RP1268D rP1268D = new RP1268D();

	rP1268D.HdrId=rP1268DDataBase.getHdrId();
	rP1268D.Detail=rP1268DDataBase.getDetail();
	rP1268D.Part=rP1268DDataBase.getPart();
	rP1268D.RTPart=rP1268DDataBase.getRTPart();
	rP1268D.Part10=rP1268DDataBase.getPart10();
	rP1268D.Part20=rP1268DDataBase.getPart20();
	rP1268D.Part30=rP1268DDataBase.getPart30();
	rP1268D.Part40=rP1268DDataBase.getPart40();
	rP1268D.Part50=rP1268DDataBase.getPart50();
	rP1268D.Part60=rP1268DDataBase.getPart60();
	rP1268D.Part70=rP1268DDataBase.getPart70();
	rP1268D.Part80=rP1268DDataBase.getPart80();
	rP1268D.Part90=rP1268DDataBase.getPart90();
	rP1268D.Part100=rP1268DDataBase.getPart100();
	rP1268D.Part110=rP1268DDataBase.getPart110();
	rP1268D.Part120=rP1268DDataBase.getPart120();
	rP1268D.Part130=rP1268DDataBase.getPart130();
	rP1268D.Part140=rP1268DDataBase.getPart140();
	rP1268D.Part150=rP1268DDataBase.getPart150();
	rP1268D.Part160=rP1268DDataBase.getPart160();
	rP1268D.QtyHold=rP1268DDataBase.getQtyHold();
	rP1268D.FinGood=rP1268DDataBase.getFinGood();
	rP1268D.NetQoh=rP1268DDataBase.getNetQoh();
	rP1268D.CDPast=rP1268DDataBase.getCDPast();
	rP1268D.CDWeek1=rP1268DDataBase.getCDWeek1();
	rP1268D.CDWeek2=rP1268DDataBase.getCDWeek2();
	rP1268D.CDWeek3=rP1268DDataBase.getCDWeek3();
	rP1268D.CDWeek4=rP1268DDataBase.getCDWeek4();
	rP1268D.CDWeek5=rP1268DDataBase.getCDWeek5();
	rP1268D.CDWeek6=rP1268DDataBase.getCDWeek6();
	rP1268D.CDWeek7=rP1268DDataBase.getCDWeek7();
	rP1268D.CDWeek8=rP1268DDataBase.getCDWeek8();

    rP1268D.CDWeek9=rP1268DDataBase.getCDWeek9();
	rP1268D.CDWeek10=rP1268DDataBase.getCDWeek10();
	rP1268D.CDWeek11=rP1268DDataBase.getCDWeek11();
	rP1268D.CDWeek12=rP1268DDataBase.getCDWeek12();
	rP1268D.CDWeek13=rP1268DDataBase.getCDWeek13();
	rP1268D.CDWeek14=rP1268DDataBase.getCDWeek14();

    rP1268D.AVMAJG=rP1268DDataBase.getAVMAJG();
    rP1268D.AVMING=rP1268DDataBase.getAVMING();

    rP1268D.ENGCHANGE = rP1268DDataBase.getENGCHANGE();    
    rP1268D.QTYG12 = rP1268DDataBase.getQTYG12();

    return rP1268D;
}

private
RP1268DDataBase objectToObjectDataBase(RP1268D rP1268D){
	RP1268DDataBase rP1268DDataBase = new RP1268DDataBase(dataBaseAccess);
	rP1268DDataBase.setHdrId(rP1268D.HdrId);
	rP1268DDataBase.setDetail(rP1268D.Detail);
	rP1268DDataBase.setPart(rP1268D.Part);
	rP1268DDataBase.setRTPart(rP1268D.RTPart);
	rP1268DDataBase.setPart10(rP1268D.Part10);
	rP1268DDataBase.setPart20(rP1268D.Part20);
	rP1268DDataBase.setPart30(rP1268D.Part30);
	rP1268DDataBase.setPart40(rP1268D.Part40);
	rP1268DDataBase.setPart50(rP1268D.Part50);
	rP1268DDataBase.setPart60(rP1268D.Part60);
	rP1268DDataBase.setPart70(rP1268D.Part70);
	rP1268DDataBase.setPart80(rP1268D.Part80);
	rP1268DDataBase.setPart90(rP1268D.Part90);
	rP1268DDataBase.setPart100(rP1268D.Part100);
	rP1268DDataBase.setPart110(rP1268D.Part110);
	rP1268DDataBase.setPart120(rP1268D.Part120);
	rP1268DDataBase.setPart130(rP1268D.Part130);
	rP1268DDataBase.setPart140(rP1268D.Part140);
	rP1268DDataBase.setPart150(rP1268D.Part150);
	rP1268DDataBase.setPart160(rP1268D.Part160);
	rP1268DDataBase.setQtyHold(rP1268D.QtyHold);
	rP1268DDataBase.setFinGood(rP1268D.FinGood);
	rP1268DDataBase.setNetQoh(rP1268D.NetQoh);
	rP1268DDataBase.setCDPast(rP1268D.CDPast);
	rP1268DDataBase.setCDWeek1(rP1268D.CDWeek1);
	rP1268DDataBase.setCDWeek2(rP1268D.CDWeek2);
	rP1268DDataBase.setCDWeek3(rP1268D.CDWeek3);
	rP1268DDataBase.setCDWeek4(rP1268D.CDWeek4);
	rP1268DDataBase.setCDWeek5(rP1268D.CDWeek5);
	rP1268DDataBase.setCDWeek6(rP1268D.CDWeek6);
	rP1268DDataBase.setCDWeek7(rP1268D.CDWeek7);
	rP1268DDataBase.setCDWeek8(rP1268D.CDWeek8);

    rP1268DDataBase.setCDWeek9(rP1268D.CDWeek9);
	rP1268DDataBase.setCDWeek10(rP1268D.CDWeek10);
	rP1268DDataBase.setCDWeek11(rP1268D.CDWeek11);
	rP1268DDataBase.setCDWeek12(rP1268D.CDWeek12);
	rP1268DDataBase.setCDWeek13(rP1268D.CDWeek13);
	rP1268DDataBase.setCDWeek14(rP1268D.CDWeek14);

    rP1268DDataBase.setAVMAJG(rP1268D.AVMAJG);
    rP1268DDataBase.setAVMING(rP1268D.AVMING);

    rP1268DDataBase.setENGCHANGE(rP1268D.ENGCHANGE);
    rP1268DDataBase.setQTYG12 (rP1268D.QTYG12);

	return rP1268DDataBase;
}

public
RP1268D cloneRP1268D(RP1268D rP1268D){
	RP1268D rP1268DClone = new RP1268D();

	rP1268DClone.HdrId=rP1268D.HdrId;
	rP1268DClone.Detail=rP1268D.Detail;
	rP1268DClone.Part=rP1268D.Part;
	rP1268DClone.RTPart=rP1268D.RTPart;
	rP1268DClone.Part10=rP1268D.Part10;
	rP1268DClone.Part20=rP1268D.Part20;
	rP1268DClone.Part30=rP1268D.Part30;
	rP1268DClone.Part40=rP1268D.Part40;
	rP1268DClone.Part50=rP1268D.Part50;
	rP1268DClone.Part60=rP1268D.Part60;
	rP1268DClone.Part70=rP1268D.Part70;
	rP1268DClone.Part80=rP1268D.Part80;
	rP1268DClone.Part90=rP1268D.Part90;
	rP1268DClone.Part100=rP1268D.Part100;
	rP1268DClone.Part110=rP1268D.Part110;
	rP1268DClone.Part120=rP1268D.Part120;
	rP1268DClone.Part130=rP1268D.Part130;
	rP1268DClone.Part140=rP1268D.Part140;
	rP1268DClone.Part150=rP1268D.Part150;
	rP1268DClone.Part160=rP1268D.Part160;
	rP1268DClone.QtyHold=rP1268D.QtyHold;
	rP1268DClone.FinGood=rP1268D.FinGood;
	rP1268DClone.NetQoh=rP1268D.NetQoh;
	rP1268DClone.CDPast=rP1268D.CDPast;
	rP1268DClone.CDWeek1=rP1268D.CDWeek1;
	rP1268DClone.CDWeek2=rP1268D.CDWeek2;
	rP1268DClone.CDWeek3=rP1268D.CDWeek3;
	rP1268DClone.CDWeek4=rP1268D.CDWeek4;
	rP1268DClone.CDWeek5=rP1268D.CDWeek5;
	rP1268DClone.CDWeek6=rP1268D.CDWeek6;
	rP1268DClone.CDWeek7=rP1268D.CDWeek7;
	rP1268DClone.CDWeek8=rP1268D.CDWeek8;

    rP1268DClone.CDWeek9=rP1268D.CDWeek9;
	rP1268DClone.CDWeek10=rP1268D.CDWeek10;
	rP1268DClone.CDWeek11=rP1268D.CDWeek11;
	rP1268DClone.CDWeek12=rP1268D.CDWeek12;
	rP1268DClone.CDWeek13=rP1268D.CDWeek13;
	rP1268DClone.CDWeek14=rP1268D.CDWeek14;

    rP1268DClone.AVMAJG = rP1268D.AVMAJG;
    rP1268DClone.AVMING = rP1268D.AVMING;

    rP1268DClone.ENGCHANGE = rP1268D.ENGCHANGE;
    rP1268DClone.QTYG12 = rP1268D.QTYG12;

    return rP1268DClone;
}

private
RP1268S objectDataBaseToObject(RP1268SDataBase rP1268SDataBase){
	RP1268S rP1268S = new RP1268S();

	rP1268S.HdrId=rP1268SDataBase.getHdrId();
	rP1268S.Detail=rP1268SDataBase.getDetail();
	rP1268S.SubDtl=rP1268SDataBase.getSubDtl();
	rP1268S.MainMat=rP1268SDataBase.getMainMat();
	rP1268S.Qty=rP1268SDataBase.getQty();

    rP1268S.WK1RECQTY = rP1268SDataBase.getWK1RECQTY();
    rP1268S.WK2RECQTY = rP1268SDataBase.getWK2RECQTY();
    rP1268S.WK3RECQTY = rP1268SDataBase.getWK3RECQTY();
    rP1268S.WK4RECQTY = rP1268SDataBase.getWK4RECQTY();

    rP1268S.WK1RECDAT = rP1268SDataBase.getWK1RECDAT(); 
    rP1268S.WK2RECDAT = rP1268SDataBase.getWK2RECDAT(); 

    return rP1268S;
}

private
RP1268SDataBase objectToObjectDataBase(RP1268S rP1268S){
	RP1268SDataBase rP1268SDataBase = new RP1268SDataBase(dataBaseAccess);
	rP1268SDataBase.setHdrId(rP1268S.HdrId);
	rP1268SDataBase.setDetail(rP1268S.Detail);
	rP1268SDataBase.setSubDtl(rP1268S.SubDtl);
	rP1268SDataBase.setMainMat(rP1268S.MainMat);
	rP1268SDataBase.setQty(rP1268S.Qty);

    rP1268SDataBase.setWK1RECQTY(rP1268S.WK1RECQTY);
    rP1268SDataBase.setWK2RECQTY(rP1268S.WK2RECQTY);
    rP1268SDataBase.setWK3RECQTY(rP1268S.WK3RECQTY);
    rP1268SDataBase.setWK4RECQTY(rP1268S.WK4RECQTY);

    rP1268SDataBase.setWK1RECDAT(rP1268S.WK1RECDAT);
    rP1268SDataBase.setWK2RECDAT(rP1268S.WK2RECDAT); 

	return rP1268SDataBase;
}

public
RP1268S cloneRP1268S(RP1268S rP1268S){
	RP1268S rP1268SClone = new RP1268S();

	rP1268SClone.HdrId=rP1268S.HdrId;
	rP1268SClone.Detail=rP1268S.Detail;
	rP1268SClone.SubDtl=rP1268S.SubDtl;
	rP1268SClone.MainMat=rP1268S.MainMat;
	rP1268SClone.Qty=rP1268S.Qty;

    rP1268SClone.WK1RECQTY = rP1268S.WK1RECQTY;
    rP1268SClone.WK2RECQTY = rP1268S.WK2RECQTY;
    rP1268SClone.WK3RECQTY = rP1268S.WK3RECQTY;
    rP1268SClone.WK4RECQTY = rP1268S.WK4RECQTY;

    rP1268S.WK1RECDAT = rP1268S.WK1RECDAT; 
    rP1268S.WK2RECDAT = rP1268S.WK2RECDAT;

    return rP1268SClone;
}
  
public
ArrayList getDemandForPart(string spart){
    ArrayList arrayList = new ArrayList();    

    try{        
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        arrayList = getDemandForPartInternal(spart);

        return arrayList;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
ArrayList getDemandForPartInternal(string spart){
    ArrayList arrayList = new ArrayList();    

    decimal materialQty = 1;
    for (int i = 0; i < 15; i++) //14 + PAST
        arrayList.Add((decimal)0);

    getDemandRecursiveForPart(arrayList,spart,spart, materialQty);
    
    string s="";
    for (int i = 0; i < 15; i++) //14 + PAST
        s += i.ToString() + ":" + (decimal)arrayList[i] + "\n";

    //System.Windows.Forms.MessageBox.Show("PArt:" + spart + "\n" + s);

    return arrayList;
}

private
void addWipPartsDemands(ArrayList arrayList){
    string      spart = "";    
    int         indexPastDemand = 23;
    ArrayList   arrayDemand = new ArrayList();
    bool        bhasDemand=false;

    for (int i = 0; i < arrayList.Count; i++){
        string[]    line = (string[])arrayList[i];

        bhasDemand=false;
        spart = line[0];
        arrayDemand = getDemandForPartInternal(spart); //get demand for part/material or wip part

        for (int j = 0; j < arrayDemand.Count; j++){
            if ((decimal)arrayDemand[j] != 0)
                bhasDemand = true;
            line[ j+ indexPastDemand] = Convert.ToString((decimal)arrayDemand[j]);
        }

        arrayList[i] = line;
        if (Configuration.Report1268ShowOnlyWithDemand && !bhasDemand){//if show with demand and that part has no demand, we remove it
            arrayList.RemoveAt(i);
            i--;
         }        
    }
}

private
ArrayList getDemandRecursiveForPart(ArrayList arrayList,string sparentPart,string spart,decimal materialQty){
    ArrayList   aList = new ArrayList();
    decimal     dqty =0 ;

    aList = getShippSchedule(spart);

    if (!sparentPart.Equals(spart)){
        for (int i=0; i < aList.Count && i< arrayList.Count;i++) 
            arrayList[i] = ((decimal)arrayList[i]   +  ((decimal)aList[i] * materialQty));
    }

    MetHdmDataBaseContainer metHdmDataBaseContainer = new MetHdmDataBaseContainer(dataBaseAccess);
    metHdmDataBaseContainer.readByEqualFilters("", spart,0);

    for (int i=0; i < metHdmDataBaseContainer.Count;i++){
        MetHdmDataBase metHdmDataBase = (MetHdmDataBase)metHdmDataBaseContainer[i];
                
        getDemandRecursiveForPart(arrayList,
                                 sparentPart,
                                 metHdmDataBase.getAQPART(),                                  
                                 metHdmDataBase.getAQQPPC() / (metHdmDataBase.getAQQTYM() != 0 ? metHdmDataBase.getAQQTYM() : 1));

        }

    if (sparentPart.Equals(spart)){ //if base part has demand, we might add not multiply
        for (int i=0; i < aList.Count && i< arrayList.Count;i++)        
            arrayList[i] = (decimal)arrayList[i] + (decimal)aList[i];                             
    }

    return arrayList;
}

private
ArrayList getShippSchedule(string spart){
    ArrayList   arrayList = new ArrayList();
    int         iweek=0;
    
    for (int i=0; i < 15;i++) //14 + PAST
        arrayList.Add((decimal)0);

    DateTime firstMonday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
    firstMonday = new DateTime(firstMonday.Year, firstMonday.Month, firstMonday.Day, 0, 0, 0);

    SschDataBaseContainer sschDataBaseContainer = new SschDataBaseContainer(dataBaseAccess);
    sschDataBaseContainer.readByEqualFilters(spart);

    foreach (SschDataBase sschDataBase in sschDataBaseContainer){
        //System.Windows.Forms.MessageBox.Show("Part=" + spart + " Date =" + DateUtil.getDateRepresentation(sschDataBase.getJYDATE(),DateUtil.MMDDYYYY) +  " Qty="+ sschDataBase.getJYSQTY().ToString());
        iweek=-1;
        if (sschDataBase.getJYDATE() < firstMonday)
            iweek = 0;

        for (int j=1; j < 15 && iweek < 0; j++){
            if (sschDataBase.getJYDATE() >= firstMonday.AddDays(7*(j-1)) && sschDataBase.getJYDATE() < firstMonday.AddDays(7*j))
                iweek=j;
        }

        if (iweek >= 0)
            arrayList[iweek] = (decimal)arrayList[iweek] + sschDataBase.getJYSQTY();

    }
    return arrayList;
}

/***************************************************** Bolm *****************************************************************/
public
Bolm createBolm(){
	return new Bolm();
}

public
BolmContainer createBolmContainer(){
	return new BolmContainer();
}

public
bool existsBolm(decimal rAMBOL){
	try{
		BolmDataBase bolmDataBase = new BolmDataBase(dataBaseAccess);

		bolmDataBase.setRAMBOL(rAMBOL);

		return bolmDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
Bolm readBolm(decimal rAMBOL){
	try{
		BolmDataBase bolmDataBase = new BolmDataBase(dataBaseAccess);
		bolmDataBase.setRAMBOL(rAMBOL);

		if (!bolmDataBase.read())
			return null;

		Bolm bolm = this.objectDataBaseToObject(bolmDataBase);

		return bolm;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
string[][] getBolmByDesc(string searchText, int rows){
	try{
		BolmDataBaseContainer bolmDataBaseContainer = new BolmDataBaseContainer(dataBaseAccess);
		bolmDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[bolmDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = bolmDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			BolmDataBase bolmDataBase = (BolmDataBase) en.Current;
			string[] item = new String[28];
			item[0] = bolmDataBase.getRAMBOL().ToString();
			item[1] = bolmDataBase.getRACDAT().ToString();
			item[2] = bolmDataBase.getRAPIND();
			item[3] = bolmDataBase.getRASIND();
			item[4] = bolmDataBase.getRASHPL();
			item[5] = bolmDataBase.getRABNME();
			item[6] = bolmDataBase.getRASDAT().ToString();
			item[7] = bolmDataBase.getRASVIA();
			item[8] = bolmDataBase.getRATKID();
			item[9] = bolmDataBase.getRAROUT();
			item[10] = bolmDataBase.getRANCTN().ToString();
			item[11] = bolmDataBase.getRANETW().ToString();
			item[12] = bolmDataBase.getRAGROW().ToString();
			item[13] = bolmDataBase.getRATARW().ToString();
			item[14] = bolmDataBase.getRADOCD();
			item[15] = bolmDataBase.getRACARC();
			item[16] = bolmDataBase.getRAPRTF();
			item[17] = bolmDataBase.getRAPLNT();
			item[18] = bolmDataBase.getRASTME().ToString();
			item[19] = bolmDataBase.getRASTMZ();
			item[20] = bolmDataBase.getRASBOL();
			item[21] = bolmDataBase.getRABLTR();
			item[22] = bolmDataBase.getRABSTS();
			item[23] = bolmDataBase.getRABLAK();
			item[24] = bolmDataBase.getRABSET();
			item[25] = bolmDataBase.getRABLMD();
			item[26] = bolmDataBase.getRASEAL();
			item[27] = bolmDataBase.getRACPRO();
			items[i] = item;
			i++;
		}
		return items;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateBolm(Bolm bolm){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        BolmDataBase bolmDataBase = this.objectToObjectDataBase(bolm);
		bolmDataBase.update();

		
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeBolm(Bolm bolm){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		BolmDataBase bolmDataBase = this.objectToObjectDataBase(bolm);
		bolmDataBase.write();
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteBolm(decimal rAMBOL){
	try{
		/*
          dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

		BolmDataBase bolmDataBase = new BolmDataBase(dataBaseAccess);

		bolmDataBase.setRAMBOL(rAMBOL);
		bolmDataBase.delete();
        */
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
Bolm objectDataBaseToObject(BolmDataBase bolmDataBase){
	Bolm bolm = new Bolm();

	bolm.RAMBOL=bolmDataBase.getRAMBOL();
	bolm.RACDAT=bolmDataBase.getRACDAT();
	bolm.RAPIND=bolmDataBase.getRAPIND();
	bolm.RASIND=bolmDataBase.getRASIND();
	bolm.RASHPL=bolmDataBase.getRASHPL();
	bolm.RABNME=bolmDataBase.getRABNME();
	bolm.RASDAT=bolmDataBase.getRASDAT();
	bolm.RASVIA=bolmDataBase.getRASVIA();
	bolm.RATKID=bolmDataBase.getRATKID();
	bolm.RAROUT=bolmDataBase.getRAROUT();
	bolm.RANCTN=bolmDataBase.getRANCTN();
	bolm.RANETW=bolmDataBase.getRANETW();
	bolm.RAGROW=bolmDataBase.getRAGROW();
	bolm.RATARW=bolmDataBase.getRATARW();
	bolm.RADOCD=bolmDataBase.getRADOCD();
	bolm.RACARC=bolmDataBase.getRACARC();
	bolm.RAPRTF=bolmDataBase.getRAPRTF();
	bolm.RAPLNT=bolmDataBase.getRAPLNT();
	bolm.RASTME=bolmDataBase.getRASTME();
	bolm.RASTMZ=bolmDataBase.getRASTMZ();
	bolm.RASBOL=bolmDataBase.getRASBOL();
	bolm.RABLTR=bolmDataBase.getRABLTR();
	bolm.RABSTS=bolmDataBase.getRABSTS();
	bolm.RABLAK=bolmDataBase.getRABLAK();
	bolm.RABSET=bolmDataBase.getRABSET();
	bolm.RABLMD=bolmDataBase.getRABLMD();
	bolm.RASEAL=bolmDataBase.getRASEAL();
	bolm.RACPRO=bolmDataBase.getRACPRO();

	return bolm;
}

private
BolmDataBase objectToObjectDataBase(Bolm bolm){
	BolmDataBase bolmDataBase = new BolmDataBase(dataBaseAccess);
	bolmDataBase.setRAMBOL(bolm.RAMBOL);
	bolmDataBase.setRACDAT(bolm.RACDAT);
	bolmDataBase.setRAPIND(bolm.RAPIND);
	bolmDataBase.setRASIND(bolm.RASIND);
	bolmDataBase.setRASHPL(bolm.RASHPL);
	bolmDataBase.setRABNME(bolm.RABNME);
	bolmDataBase.setRASDAT(bolm.RASDAT);
	bolmDataBase.setRASVIA(bolm.RASVIA);
	bolmDataBase.setRATKID(bolm.RATKID);
	bolmDataBase.setRAROUT(bolm.RAROUT);
	bolmDataBase.setRANCTN(bolm.RANCTN);
	bolmDataBase.setRANETW(bolm.RANETW);
	bolmDataBase.setRAGROW(bolm.RAGROW);
	bolmDataBase.setRATARW(bolm.RATARW);
	bolmDataBase.setRADOCD(bolm.RADOCD);
	bolmDataBase.setRACARC(bolm.RACARC);
	bolmDataBase.setRAPRTF(bolm.RAPRTF);
	bolmDataBase.setRAPLNT(bolm.RAPLNT);
	bolmDataBase.setRASTME(bolm.RASTME);
	bolmDataBase.setRASTMZ(bolm.RASTMZ);
	bolmDataBase.setRASBOL(bolm.RASBOL);
	bolmDataBase.setRABLTR(bolm.RABLTR);
	bolmDataBase.setRABSTS(bolm.RABSTS);
	bolmDataBase.setRABLAK(bolm.RABLAK);
	bolmDataBase.setRABSET(bolm.RABSET);
	bolmDataBase.setRABLMD(bolm.RABLMD);
	bolmDataBase.setRASEAL(bolm.RASEAL);
	bolmDataBase.setRACPRO(bolm.RACPRO);

	return bolmDataBase;
}

public
Bolm cloneBolm(Bolm bolm){
	Bolm bolmClone = new Bolm();

	bolmClone.RAMBOL=bolm.RAMBOL;
	bolmClone.RACDAT=bolm.RACDAT;
	bolmClone.RAPIND=bolm.RAPIND;
	bolmClone.RASIND=bolm.RASIND;
	bolmClone.RASHPL=bolm.RASHPL;
	bolmClone.RABNME=bolm.RABNME;
	bolmClone.RASDAT=bolm.RASDAT;
	bolmClone.RASVIA=bolm.RASVIA;
	bolmClone.RATKID=bolm.RATKID;
	bolmClone.RAROUT=bolm.RAROUT;
	bolmClone.RANCTN=bolm.RANCTN;
	bolmClone.RANETW=bolm.RANETW;
	bolmClone.RAGROW=bolm.RAGROW;
	bolmClone.RATARW=bolm.RATARW;
	bolmClone.RADOCD=bolm.RADOCD;
	bolmClone.RACARC=bolm.RACARC;
	bolmClone.RAPRTF=bolm.RAPRTF;
	bolmClone.RAPLNT=bolm.RAPLNT;
	bolmClone.RASTME=bolm.RASTME;
	bolmClone.RASTMZ=bolm.RASTMZ;
	bolmClone.RASBOL=bolm.RASBOL;
	bolmClone.RABLTR=bolm.RABLTR;
	bolmClone.RABSTS=bolm.RABSTS;
	bolmClone.RABLAK=bolm.RABLAK;
	bolmClone.RABSET=bolm.RABSET;
	bolmClone.RABLMD=bolm.RABLMD;
	bolmClone.RASEAL=bolm.RASEAL;
	bolmClone.RACPRO=bolm.RACPRO;

	return bolmClone;
}

public
BolmContainer readBolmByFilters(decimal dbolid,DateTime startDate,DateTime endDate,string status,string shipVia,string struckID,string sroute,int rows){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        BolmContainer bolmContainer = new BolmContainer();

        BolmDataBaseContainer bolmDataBaseContainer = new BolmDataBaseContainer(dataBaseAccess);
        bolmDataBaseContainer.readByFilters(dbolid, startDate, endDate, status, shipVia, struckID, sroute,rows);
	
        for (int i=0; i < bolmDataBaseContainer.Count;i++){
            Bolm bolm = this.objectDataBaseToObject((BolmDataBase)bolmDataBaseContainer[i]);
            bolmContainer.Add(bolm);
        }

		return bolmContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

}

}
