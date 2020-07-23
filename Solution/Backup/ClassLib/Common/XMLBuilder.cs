using System;
using System.Data;
using System.IO; 
using System.Xml;

namespace Nujit.NujitERP.ClassLib.Common
{
	public class XMLBuilder
	{
		#region Varibles
		private string mstrExportFolder;
		private string mstrFileName;
		private string mstrMessage;
		private string mblnFullFilePath;
        #endregion Varibles

		#region Properties
		public string FullFilePath
		{
			get
			{
				return mblnFullFilePath;
			}
			set
			{
				mblnFullFilePath = value;
			}
		}

		public string ExportFolder
		{
			get
			{
				return mstrExportFolder;
			}
			set
			{
				mstrExportFolder = value;
			}
		}

		public string FileName
		{
			get
			{
				return mstrFileName;
			}
			set
			{
				mstrFileName = value;
			}
		}

		public string FilePath
		{
			get
			{
				if (this.FullFilePath != null && this.FullFilePath != string.Empty)
				{ 
					return this.FullFilePath;
				}

				if(this.mstrExportFolder == null || this.mstrExportFolder == string.Empty)
				{
					this.mstrExportFolder = Configuration.AppRoot + "\\export";
				}
				if(this.mstrFileName == null || this.mstrFileName == string.Empty)
				{
					this.mstrFileName = Utils.GetLogFileName() + ".xml"; 
				}
				return(this.mstrExportFolder+"\\"+this.mstrFileName);
			}
		}

		public string Message
		{
			get
			{
				return mstrMessage;
			}
			set
			{
				mstrMessage = value;
			}
		}

		#endregion Properties

		#region Constructors
		public XMLBuilder(){}

		public XMLBuilder(string strExportFolder, string strFileName)
		{
			this.mstrExportFolder = strExportFolder;
			this.mstrFileName = strFileName;
		}

		public XMLBuilder(string strExportFullFilePath)
		{
			this.FullFilePath = strExportFullFilePath;
		}

        #endregion Constructors

		#region Methods
		public bool ExportXML(DataSet objDS)
		{
			//check if dataset contains tables
			if(objDS != null && objDS.Tables.Count > 0)
			{
				string strFilePath = this.FilePath;
				try
				{
					if(File.Exists(strFilePath))
					{
						File.SetAttributes(strFilePath, FileAttributes.Normal);
						File.Delete(strFilePath);
					}
					objDS.WriteXml(strFilePath);
				}
				catch(Exception e)
				{
					this.mstrMessage = "Source:" + e.Source + "\nMessage:" + e.Message; 
					return false;
				}
				return true;
			}

			return false;
		}

		public static XmlElement AddElement(XmlDocument objDoc, 
			                                XmlNode		objNodeParent,
			                                XmlNodeType objNodeType, 
			                                string		strElementName, 
			                                string		strElementValue)
		{	
			XmlElement objElem = objDoc.CreateElement(strElementName);
			switch(objNodeType)
			{
				case XmlNodeType.CDATA : 
					XmlCDataSection objCData = objDoc.CreateCDataSection(strElementValue);
					objElem.AppendChild(objCData);
					break;
				case XmlNodeType.Element : 
					objElem.InnerText = strElementValue;
					break;
			}
			objNodeParent.AppendChild(objElem); 
			return objElem;
		}
		
		public static XmlAttribute AddAttribute(XmlDocument   objDoc, 
			                                    XmlNode       objNode, 
			                                    string        strAttributeName, 
			                                    string        strAttributeValue)
		{
			XmlAttribute objAttr = objDoc.CreateAttribute(strAttributeName);
			objAttr.InnerText = strAttributeValue;
			objNode.Attributes.Append(objAttr); 
			return objAttr;
		}

		public static string ReadAttribute(XmlNode objNode, string strAttributeName)
		{
			return objNode.Attributes["strAttributeName"].InnerText;
		}
		#endregion Methods
			
	}
}
