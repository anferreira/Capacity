using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections;

using System.Web;
using System.Web.Mail;

using System.Net;
using System.Diagnostics;

namespace Nujit.NujitERP.ClassLib.Common
{
	sealed public class LogHandler
	{	
		public static void LogError(Exception e, string componentName, string className, string procedureName)
		{			
			try
			{
				if (Configuration.EnableErrorEmail)
				{
					SendEmail("N/A", e.ToString(), componentName, className, procedureName);
				}
			}
			catch
			{
				throw new Exception ("Send error email fail ");
			}
			
			try
			{
				LogEvent("N/A", e.ToString(), componentName, className, procedureName);
			}
			catch
			{
				throw new Exception ("Log error fail ");
			}

		}

		public static void LogError(string errorMsg, string componentName, string className, string procedureName)
		{			
			
			try
			{
				if (Configuration.EnableErrorEmail)
				{
					SendEmail("N/A", errorMsg, componentName, className, procedureName);
				}
			}
			catch
			{
				throw new Exception ("Send error email fail ");
			}
			
			try
			{
				LogEvent("N/A", errorMsg, componentName, className, procedureName);
			}
			catch
			{
				throw new Exception ("Log error fail ");
			}

		}
		
		public static void LogError(int errorNumber, Exception e, string componentName, string className, string procedureName)
		{			
			try
			{
				if (Configuration.EnableErrorEmail)
				{
					SendEmail(errorNumber.ToString(), e.ToString(), componentName, className, procedureName);
				}
			}
			catch
			{
				throw new Exception ("Send error email fail ");
			}
			

			try
			{
				LogEvent(errorNumber.ToString(), e.ToString(), componentName, className, procedureName);
			}
			catch
			{
				throw new Exception ("Log error fail ");
			}

		}
		
		public static void LogError(int errorNumber, Exception e, string componentName, string className, string procedureName, string MessageDetail)
		{			
				try
				{
					if (Configuration.EnableErrorEmail)
					{
						SendEmail(errorNumber.ToString(), e.ToString(), componentName, className, procedureName, MessageDetail);
					}
				}
				catch
				{
					throw new Exception ("Send error email fail ");
				}
				
	
				try
				{
					LogEvent(errorNumber.ToString(), e.ToString(), componentName, className, procedureName, MessageDetail);
				}
				catch
				{
					throw new Exception ("Log error fail ");
				}

		}

		private static void SendEmail(string errorNumber, string messageBody, string componentName, string className, string procedureName)
		{
			MailMessage objMessage = new MailMessage();		
			
			if (Configuration.ErrorEmailFrom == null)					
			{
				throw new Exception("ErrorEmailFrom not set in  Web.Config");
			}
			else
			{
				objMessage.From = Configuration.ErrorEmailFrom;
			}

			if (Configuration.ErrorEmailTo == null)					
			{
				throw new Exception("ErrorEmailTo not set in Web.Config");
			}
			else
			{
				objMessage.To = Configuration.ErrorEmailTo;
			}
				
			objMessage.Subject = "System Error";
			objMessage.BodyFormat = MailFormat.Text;		
				
			objMessage.Body = "Host Name: " + Configuration.HostName + "\n" +
				              "Component Name: " + componentName + "\n" +
				              "Class Name: " + className + "\n" +
				              "Procedure Name: " + procedureName + "\n" +
				              "Error Number: " + errorNumber + "\n\n" +
				              "Error Message: \n------------------------\n" + messageBody;
			
			SmtpMail.Send(objMessage);
		}

		private static void SendEmail(string errorNumber, string messageBody, string componentName, string className, string procedureName, string MessageDetail)
		{
					MailMessage objMessage = new MailMessage();		
					
					if (Configuration.ErrorEmailFrom == null)					
					{
						throw new Exception("ErrorEmailFrom not set in  Web.Config");
					}
					else
					{
						objMessage.From = Configuration.ErrorEmailFrom;
					}
		
					if (Configuration.ErrorEmailTo == null)					
					{
						throw new Exception("ErrorEmailTo not set in Web.Config");
					}
					else
					{
						objMessage.To = Configuration.ErrorEmailTo;
					}
						
					objMessage.Subject = "System Error";
					objMessage.BodyFormat = MailFormat.Text;		
						
					objMessage.Body = "Host Name: " + Configuration.HostName + "\n" +
						              "Component Name: " + componentName + "\n" +
						              "Class Name: " + className + "\n" +
						              "Procedure Name: " + procedureName + "\n" +
						              "Error Number: " + errorNumber + "\n\n" +
						              "Error Message: \n------------------------\n" + messageBody +
						              "Detail Infomation: \n------------------------\n" + MessageDetail;
		
		
					SmtpMail.SmtpServer = "";
					SmtpMail.Send(objMessage);
		}
		private static void LogEvent(string errorNumber, string messageBody, string componentName, string className, string procedureName) 
		{
			string strMessage; 
				
			strMessage = "\n\nHost Name: " + Configuration.HostName + "\n" +
				         "Component Name: " + componentName + "\n" +
				         "Class Name: " + className + "\n" +
				         "Procedure Name: " + procedureName + "\n" +
				         "Error Number: " + errorNumber + "\n\n" +
				         "Error Message: \n------------------------\n" + messageBody;
                
			if (!EventLog.SourceExists("Nujit.NujitERP"))
			{
				EventLog.CreateEventSource("Nujit.NujitERP","Nujit");
			}

			EventLog objEventLog = new EventLog();
			objEventLog.Log = "Nujit";
			objEventLog.Source = "Nujit.NujitERP";
        
			objEventLog.WriteEntry(strMessage,EventLogEntryType.Error);

			return ;
		}

		private static void LogEvent(string errorNumber, string messageBody, string componentName, string className, string procedureName, string MessageDetail)
		{
			string strMessage; 
				
			strMessage = "\n\nHost Name: " + Configuration.HostName + "\n" +
				         "Component Name: " + componentName + "\n" +
						 "Class Name: " + className + "\n" +
						 "Procedure Name: " + procedureName + "\n" +
						 "Error Number: " + errorNumber + "\n\n" +
						 "Error Message: \n------------------------\n" + messageBody +
						 "Detail Infomation: \n------------------------\n" + MessageDetail;
			    
			EventLog objEventLog  = new EventLog();
			objEventLog.Log       = "Nujit";
			objEventLog.Source    = "NujitClass";
		
			objEventLog.WriteEntry(strMessage,EventLogEntryType.Error);

			return ;
		}

	}				
}

