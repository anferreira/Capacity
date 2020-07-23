using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Reflection;
using System.IO;

namespace Nujit_WebService
{
	/// <summary>
	/// Summary description for UpdateService.
	/// </summary>
	[WebService(Namespace="http://www.nujit.com/")]
	public class UpdateService : System.Web.Services.WebService
	{
		public UpdateService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		//*******************************************************************
		// Used to check for updates.  
		// Compares the assembly version of the NujitWms.exe on the
		// client with the one on the server.
		//*******************************************************************
		[WebMethod]
		public void CheckForUpdateWMS(string clientVersion, string companyName, out bool updateAvailable, out string updateUrl)
		{
			try
			{
				string assemblyPath = Context.Request.PhysicalApplicationPath;
				assemblyPath = Path.Combine(assemblyPath,"WMSBuilds");

				if (companyName != null && companyName.Length > 0)
					assemblyPath = Path.Combine(assemblyPath, companyName);

				assemblyPath = Path.Combine(assemblyPath,"NujitWms.exe");

				//Retrieve the assembly information for the assembly on the server
				AssemblyName AN = AssemblyName.GetAssemblyName(assemblyPath);

				//Compare assembly version numbers
				if (AN.Version.CompareTo(new Version(clientVersion)) > 0 )
				{
					updateAvailable = true;
					updateUrl = Context.Request.Url.ToString().Substring(0,Context.Request.Url.ToString().LastIndexOf('/')) + "/WMSBuilds/";

					if (companyName != null && companyName.Length > 0)
						updateUrl += companyName + "/";
				} 
				else
				{
					updateAvailable = false;
					updateUrl = "";
				}
			}
			catch
			{
				updateAvailable = false;
				updateUrl = "";
			}
		}


		//*******************************************************************
		// Used to check for updates.  
		// Compares the assembly version of the NujitERP.exe on the
		// client with the one on the server.
		//*******************************************************************
		[WebMethod]
		public void CheckForUpdateERP(string clientVersion, string companyName, out bool updateAvailable, out string updateUrl)
		{
			try
			{
				string assemblyPath = Context.Request.PhysicalApplicationPath;
				assemblyPath = Path.Combine(assemblyPath,"ERPBuilds");

				if (companyName != null && companyName.Length > 0)
					assemblyPath = Path.Combine(assemblyPath, companyName);

				assemblyPath = Path.Combine(assemblyPath,"NujitERP.exe");

				//Retrieve the assembly information for the assembly on the server
				AssemblyName AN = AssemblyName.GetAssemblyName(assemblyPath);

				//Compare assembly version numbers
				if (AN.Version.CompareTo(new Version(clientVersion)) > 0 )
				{
					updateAvailable = true;
					updateUrl = Context.Request.Url.ToString().Substring(0,Context.Request.Url.ToString().LastIndexOf('/')) + "/ERPBuilds/";
					
					if (companyName != null && companyName.Length > 0)
						updateUrl += companyName + "/";
				} 
				else
				{
					updateAvailable = false;
					updateUrl = "";
				}
			}
			catch
			{
				updateAvailable = false;
				updateUrl = "";
			}
		}
	}
}