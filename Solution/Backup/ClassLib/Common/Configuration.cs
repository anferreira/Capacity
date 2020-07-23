using System;
using System.Collections;
using System.Collections.Specialized;   
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;     
using System.Xml;

namespace Nujit.NujitERP.ClassLib.Common{
	
public 
class Configuration : IConfigurationSectionHandler{

private const string DATA_REPOSITORYTYPE		= "DataBase.RepositoryType";
private const string DATA_DBCONNECTIONSTRING	= "DataBase.DBConnectionstring";

private const string DATA_SQLREPOSITORYTYPE		= "DataBase.SqlRepositoryType";
private const string DATA_SQLDBCONNECTIONSTRING	= "DataBase.SqlDBConnectionstring";

private const string DATA_CMS_REPOSITORY_TYPE	= "DataBase.CMSRepositoryType";
private const string DATA_CMSCONNECTIONSTRING	= "DataBase.CMSConnectionstring";
private const string DATA_CMSLIBRARY	        = "DataBase.CMSLibrary";
private const string DATA_CMSLIBRARY_2nd	    = "DataBase.CMSLibrary_2nd";
private const string DATA_DFT_DATABASE			= "DataBase.DftDataBase";

private const string DATA_CMSPROGRAMLIBRARY     = "DataBase.CMSProgramLibrary";
private const string DATA_CMSTEMPCONNECTIONSTRING	= "DataBase.CMSTEMPConnectionstring";

private const string DATA_SYSTEMNAME	= "DataBase.SystemName";

private const string ERROR_ENABLEERROREMAIL	    = "Error.EnableErrorEmail";
private const string ERROR_ERROREMAILFROM		= "Error.ErrorEmailFrom";
private const string ERROR_ERROREMAILTO			= "Error.ErrorEmailTo";

private const string DATA_REPORT_PATH			= "Report.Path";

private const string DATA_HOTLIST_CONTROLUSERS			= "HotList.ControlUsers";

private const string DATA_HOTLIST_PLANDAYS  			= "HotList.PlanDays";
private const string DATA_HOTLIST_MINPLANDAYS  			= "HotList.MinPlanDays";
private const string DATA_HOTLIST_MAXPLANDAYS  			= "HotList.MaxPlanDays";

private const string DATA_MAIL_SMTPSERVER		= "Mail.SmtpServer";

private const string DATA_REMOTE_RUNMODE		= "Remote.RunMode";
private const string DATA_REMOTE_SERVERIP		= "Remote.ServerIp";
private const string DATA_REMOTE_SERVERPORT		= "Remote.ServerPort";
private const string DATA_REMOTE_SERVICENAME	= "Remote.ServiceName";

private const string DATA_CMS_VERSION           = "Cms.Version";

private const string DATA_SEARCH_DEFAULT_MAX_RECORDS = "Search.DefaultMaxRecords";
private const string DATA_SEARCH_USER_CHANGE_DEFAULT_MAX_RECORDS = "Search.UserChangeDefaultMaxRecords";

private static string	DATA_REPOSITORYTYPE_DEFAULT			 = "Access";
private static string	DATA_DBCONNECTIONSTRING_DEFAULT	     = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Configuration.DataRoot + "\\NujitSample.mdb";

private const string    DATA_SQLREPOSITORYTYPE_DEFAULT		 = "SqlServer";
private const string    DATA_SQLDBCONNECTIONSTRING_DEFAULT	 = "Server=Nujit-server;uid=NujitUser;pwd=User;database=Nujit";

private const string    DATA_COMPANY_NAME	 = "Company.Name";
private const string    DATA_COMPANY_IGNORE_PASTDUE	 = "Company.IgnorePastDue";
private const string    DATA_COMPANY_STKLOCS_MATERIALS = "Company.StkLocsMaterials";

private static bool	    ERROR_ENABLEERROREMAIL_DEFAULT	    = false;
private static string	ERROR_ERROREMAILFROM_DEFAULT		= "support@nujit.com";
private static string	ERROR_ERROREMAILTO_DEFAULT			= "admin@nujit.com";

private const string DATA_DFT_COMPANY	= "Company.DftCompany";
private const string DATA_DFT_PLANT	= "Plant.DftPlant";
private const string DATA_DFT_DEPARTMENT = "Department.DftDepartment";

private static string	repositoryType;
private static string	dbConnectionString;

private static string	sqlRepositoryType;
private static string	sqlDbConnectionString;

private static bool  	enableErrorEmail;
private static string	errorEmailFrom;
private static string	errorEmailTo;

private static string	encryKey = "JZXNTK87-8HBI-899f-I999-M9N9IN90MNLO";

private static string   cmsRepositoryType;
private static string   cMSConnectionstring;
private static string   cMSLibrary;
private static string   cMSLIBRARY_2nd;
private static string   dftDataBase;
private static string   dftCompany;
private static string   dftPlant;
private static string   dftDepartment;

private static string   cmsProgramLibrary;
private static string   cMSTempConnectionstring;
private static string   systemName;

private static string   reportPath;

private static string   hotListControlUsers;

private static string   planDays;
private static string   minPlanDays;
private static string   maxPlanDays;

private static string   smtpServer;		

private static string   runMode;
private static string   serverIp;
private static string   serverPort;
private static string   serviceName;

private static string   cmsVersion;
		
private static string   searchDefaultMaxRecords;
private static string   searchUserChangeDefaultMaxRecords;

private static string   companyName;
private static string   ignorePastDue;

private static string stkLocsMaterials;


public static 
string StkLocsMaterials{
	get{
		return stkLocsMaterials;
	}
}

public static 
string SqlRepositoryType{
	get{
		return sqlRepositoryType	;
	}
}

public static 
string SqlDBConnectionString{
	get{
		return sqlDbConnectionString;
	}
}


public static 
string RepositoryType{
	get{
		return repositoryType;
	}
}

public static 
string DBConnectionString{
	get{
		return dbConnectionString;
	}
}

public static 
bool EnableErrorEmail{
	get{
		return enableErrorEmail;
	}
}

public static 
string ErrorEmailFrom{
	get{
		return errorEmailFrom;
	}
}

public static 
string ErrorEmailTo{
	get{
		return errorEmailTo;
	}
}

public static 
string AppRoot{
	get{
		return Path.GetDirectoryName(Application.ExecutablePath);
	}
}

public static 
string DataRoot{
	get{
		if (Configuration.AppRoot.EndsWith("\\bin\\Debug"))
			return Configuration.AppRoot.Substring(0,Configuration.AppRoot.Length-10) + "\\Data";
		else if (Configuration.AppRoot.EndsWith("\\bin\\Release"))
			return Configuration.AppRoot.Substring(0,Configuration.AppRoot.Length-12) + "\\Data";
		else
			return Configuration.AppRoot + "//Data";
	}
}

public static 
string ConfigRoot{
	get{
		if (Configuration.AppRoot.EndsWith("\\bin\\Debug"))
			return Configuration.AppRoot.Substring(0,Configuration.AppRoot.Length-10) + "\\Config";
		else if (Configuration.AppRoot.EndsWith("\\bin\\Release"))
			return Configuration.AppRoot.Substring(0,Configuration.AppRoot.Length-12) + "\\Config";
		else
//					return Configuration.AppRoot + "//Config";
			return Configuration.AppRoot + "\\Config";
	}
}

public static 
string HostName{
	get{
		return Dns.GetHostName();
	}
}

public static 
string IpAddress{
	get{
		IPAddress ipAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
		return ipAddress.ToString();
	}
}

public static 
string EncryKey{
	get{
		return encryKey;
	}
}

public static 
string CMSRepositoryType{
	get{
		return cmsRepositoryType;
	}
}

public static 
string CMSConnectionstring{
	get{
		return cMSConnectionstring;
	}
}

public static 
string CMSLibrary{
	get{
		return cMSLibrary;
	}
}

public static 
string CMSLibrary_2nd{
	get{
		return cMSLIBRARY_2nd;
	}
}

public static 
string DftDataBase{
	get{
		return dftDataBase;
	}
}

public static 
int DftCompany{
	get{
		try {return int.Parse(dftCompany);}
		catch {return 0;}
	}
}

public static 
string DftPlant{
	get{
		try {return dftPlant;}
		catch {return "";}
	}
}

public static 
string DftDepartment{
	get{
		try {return dftDepartment;}
		catch {return "";}
	}
}

public static 
string CMSProgramLibrary{
	get{
		return cmsProgramLibrary;
	}
}

public static 
string CMSTempConnectionstring{
	get{
		return cMSTempConnectionstring;
	}
}

public static 
string SystemName{
	get{
		return systemName;
	}
}

public static 
string ReportPath{
	get{
		return reportPath;
	}
}

public static 
string ControlUsers{
	get{
		return hotListControlUsers;
	}
}

public static 
string PlanDays{
	get{
		return planDays;
	}
}

public static 
string MinPlanDays{
	get{
		return minPlanDays;
	}
}

public static 
string MaxPlanDays{
	get{
		return maxPlanDays;
	}
}

public static 
string SmtpServer{
	get{
		return smtpServer;
	}
}


public static 
string RunMode{
	get{
		return runMode;
	}
}

public static 
string ServerIp{
	get{
		return serverIp;
	}
}

public static 
string ServerPort{
	get{
		return serverPort;
	}
}

public static 
string ServiceName{
	get{
		return serviceName;
	}
}

public static 
string CmsVersion{
	get{
		return cmsVersion;
	}
}

public static 
string SearchDefaultMaxRecords{
	get{
		return searchDefaultMaxRecords;
	}
}

public static 
string SearchUserChangeDefaultMaxRecords{
	get{
		return searchUserChangeDefaultMaxRecords;
	}
}

public static 
string CompanyName{
	get{
		return companyName;
	}
}

public static 
bool IgnorePastDue{
	get{
		if (ignorePastDue.Equals("Y"))
			return true;
		return false;
	}
}

public 
Object Create(Object parent, object configContext, XmlNode section){
	NameValueCollection settings;
    
	try{
		NameValueSectionHandler baseHandler = new NameValueSectionHandler();
		settings = (NameValueCollection)baseHandler.Create(parent, configContext, section);
	}catch{
		settings = null;
	}
    
	if ( settings == null ){
		repositoryType			    = DATA_REPOSITORYTYPE_DEFAULT;
		dbConnectionString		    = DATA_DBCONNECTIONSTRING_DEFAULT;

		sqlRepositoryType		    = DATA_SQLREPOSITORYTYPE_DEFAULT;
		sqlDbConnectionString		= DATA_SQLDBCONNECTIONSTRING_DEFAULT;
    
		enableErrorEmail			= ERROR_ENABLEERROREMAIL_DEFAULT;
		errorEmailFrom				= ERROR_ERROREMAILFROM_DEFAULT;
		errorEmailTo				= ERROR_ERROREMAILTO_DEFAULT;
				
	}else{
		repositoryType				= ReadSetting(settings, DATA_REPOSITORYTYPE,DATA_REPOSITORYTYPE_DEFAULT);
		dbConnectionString  		= ReadSetting(settings, DATA_DBCONNECTIONSTRING,DATA_DBCONNECTIONSTRING_DEFAULT);

		sqlRepositoryType			= ReadSetting(settings, DATA_SQLREPOSITORYTYPE,DATA_SQLREPOSITORYTYPE_DEFAULT);
		sqlDbConnectionString  		= ReadSetting(settings, DATA_SQLDBCONNECTIONSTRING, DATA_SQLDBCONNECTIONSTRING_DEFAULT);

		enableErrorEmail			= ReadSetting(settings, ERROR_ENABLEERROREMAIL,ERROR_ENABLEERROREMAIL_DEFAULT);
		errorEmailFrom				= ReadSetting(settings, ERROR_ERROREMAILFROM,ERROR_ERROREMAILFROM_DEFAULT);
		errorEmailTo				= ReadSetting(settings, ERROR_ERROREMAILTO,ERROR_ERROREMAILTO_DEFAULT);
	}
	return settings;
}
    	
private static 
string ReadSetting(NameValueCollection settings, String key, String defaultValue){
	try{
		Object setting = settings[key];
		return (setting == null) ? defaultValue : (String)setting;
	}catch{
		return defaultValue;
	}
}

private static 
bool ReadSetting(NameValueCollection settings, String key, bool defaultValue){
	try{
		Object setting = settings[key];
		return (setting == null) ? defaultValue : Convert.ToBoolean((String)setting);
	}catch{
		return defaultValue;
	}
}

private static 
int ReadSetting(NameValueCollection settings, String key, int defaultValue){
	try{
		Object setting = settings[key];
        
		return (setting == null) ? defaultValue : Convert.ToInt32((String)setting);
	}catch{
		return defaultValue;
	}
}

private static 
string ReadXmlSetting(XmlNode root, XmlNamespaceManager nsmgr, String key, string defaultValue){
	try{
		XmlNode node = root.SelectSingleNode(key,nsmgr);
		String setting = node.Attributes["value"].InnerText;   
		return (setting == null) ? defaultValue : Convert.ToString(setting);
	}catch{
		return defaultValue;
	}
}

private static 
bool ReadXmlSetting(XmlNode root, XmlNamespaceManager nsmgr, String key, bool defaultValue){
	try{
		XmlNode node = root.SelectSingleNode(key,nsmgr);
		String setting = node.Attributes["value"].InnerText;   
		return (setting == null) ? defaultValue : Convert.ToBoolean(setting);
	}catch{
		return defaultValue;
	}
}

private static 
int ReadXmlSetting(XmlNode root, XmlNamespaceManager nsmgr, String key, int defaultValue){
	try{
		XmlNode node = root.SelectSingleNode(key,nsmgr);
		String setting = node.Attributes["value"].InnerText;   
		return (setting == null) ? defaultValue : Convert.ToInt32(setting);
	}catch{
		return defaultValue;
	}
}
			
public static 
void OnApplicationStart(){	
	#if __MonoCS__
		string strFilePath = "./Config/setting.xml";
	#else
		string strFilePath = Configuration.ConfigRoot + "\\setting.xml";
	#endif
	
	bool blnDefault = false;

	if (!blnDefault && File.Exists(strFilePath)){
		try{
			XmlDocument objDoc = new XmlDocument();	
			objDoc.Load(strFilePath);

			XmlElement root = objDoc.DocumentElement;
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(objDoc.NameTable);
			
			repositoryType = ReadXmlSetting(root,nsmgr,"DataBase.RepositoryType",DATA_REPOSITORYTYPE_DEFAULT);
			dbConnectionString = ReadXmlSetting(root,nsmgr,"DataBase.DBConnectionstring",DATA_DBCONNECTIONSTRING_DEFAULT);

			sqlRepositoryType = ReadXmlSetting(root,nsmgr,"DataBase.SqlRepositoryType",DATA_SQLREPOSITORYTYPE_DEFAULT);
			sqlDbConnectionString = ReadXmlSetting(root,nsmgr,"DataBase.SqlDBConnectionstring",DATA_SQLDBCONNECTIONSTRING_DEFAULT);

			enableErrorEmail = ReadXmlSetting(root,nsmgr,"Error.EnableErrorEmail",ERROR_ENABLEERROREMAIL_DEFAULT);
			errorEmailFrom = ReadXmlSetting(root,nsmgr,"Error.ErrorEmailFrom",ERROR_ERROREMAILFROM_DEFAULT);
			errorEmailTo = ReadXmlSetting(root,nsmgr,"Error.ErrorEmailTo",ERROR_ERROREMAILTO_DEFAULT);
			
			cmsRepositoryType = ReadXmlSetting(root,nsmgr,"DataBase.CMSRepositoryType",DATA_CMS_REPOSITORY_TYPE);
			cMSConnectionstring = ReadXmlSetting(root,nsmgr,"DataBase.CMSConnectionstring",DATA_CMSCONNECTIONSTRING);
			cMSTempConnectionstring = ReadXmlSetting(root,nsmgr,"DataBase.CMSTEMPConnectionstring",DATA_CMSTEMPCONNECTIONSTRING);
			cMSLibrary = ReadXmlSetting(root,nsmgr,"DataBase.CMSLibrary",DATA_CMSLIBRARY);
			cMSLIBRARY_2nd = ReadXmlSetting(root,nsmgr,"DataBase.CMSLibrary_2nd",DATA_CMSLIBRARY_2nd);
			dftDataBase =  ReadXmlSetting(root,nsmgr,"DataBase.DftDataBase",DATA_DFT_DATABASE);
			dftCompany =  ReadXmlSetting(root,nsmgr,"Company.DftCompany",DATA_DFT_COMPANY);
			dftPlant =  ReadXmlSetting(root,nsmgr,"Plant.DftPlant",DATA_DFT_PLANT);
			dftDepartment =  ReadXmlSetting(root,nsmgr,"Department.DftDepartment",DATA_DFT_DEPARTMENT);
			
			cmsProgramLibrary = ReadXmlSetting(root,nsmgr,"DataBase.CMSProgramLibrary",DATA_CMSPROGRAMLIBRARY);

			systemName = ReadXmlSetting(root,nsmgr,"DataBase.SystemName",DATA_SYSTEMNAME);
			
			reportPath = ReadXmlSetting(root,nsmgr,"Report.Path",DATA_REPORT_PATH);
			hotListControlUsers = ReadXmlSetting(root, nsmgr, "HotList.ControlUsers", DATA_HOTLIST_CONTROLUSERS);
			
			planDays = ReadXmlSetting(root, nsmgr, "HotList.PlanDays", DATA_HOTLIST_PLANDAYS);
			minPlanDays = ReadXmlSetting(root, nsmgr, "HotList.MinPlanDays", DATA_HOTLIST_MINPLANDAYS);
			maxPlanDays = ReadXmlSetting(root, nsmgr, "HotList.MaxPlanDays", DATA_HOTLIST_MAXPLANDAYS);

			smtpServer = ReadXmlSetting(root, nsmgr, "Mail.SmtpServer", DATA_MAIL_SMTPSERVER);					

			runMode = ReadXmlSetting(root, nsmgr, "Remote.RunMode", DATA_REMOTE_RUNMODE);
			serverIp = ReadXmlSetting(root, nsmgr, "Remote.ServerIp", DATA_REMOTE_SERVERIP);
			serverPort = ReadXmlSetting(root, nsmgr, "Remote.ServerPort", DATA_REMOTE_SERVERPORT);
			serviceName = ReadXmlSetting(root, nsmgr, "Remote.ServiceName", DATA_REMOTE_SERVICENAME);
			cmsVersion = ReadXmlSetting(root, nsmgr, "Cms.Version", DATA_CMS_VERSION);

			searchDefaultMaxRecords = ReadXmlSetting(root, nsmgr, "Search.DefaultMaxRecords", DATA_SEARCH_DEFAULT_MAX_RECORDS);
			searchUserChangeDefaultMaxRecords = ReadXmlSetting(root, nsmgr, "Search.UserChangeDefaultMaxRecords", DATA_SEARCH_USER_CHANGE_DEFAULT_MAX_RECORDS);
			
			companyName = ReadXmlSetting(root, nsmgr, "Company.Name", DATA_COMPANY_NAME);
			ignorePastDue = ReadXmlSetting(root, nsmgr, "Company.IgnorePastDue", DATA_COMPANY_IGNORE_PASTDUE);

			stkLocsMaterials = ReadXmlSetting(root, nsmgr, "Company.StkLocsMaterials", DATA_COMPANY_STKLOCS_MATERIALS);
		}catch(Exception e){
			System.Console.WriteLine("----" + e.Message);
			LogHandler.LogError(e,"UtilityClassLib.Common","Configuration","OnApplicationStart"); 
			throw new Exception("Problems with the file : " + strFilePath);
		}
	}else{
		throw new Exception("The file : " + strFilePath + " was not found !!!");
	}
}

} // class

} // namespace
