using System;
#if OE_SYNC
using Comunications;
using Messages;
#endif
using System.Xml;
using System.IO;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;
using System.Drawing;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
#if !POCKET_PC && OE_SYNC
//	using Gui.Print;
#endif


namespace Nujit.NujitERP.ClassLib.Core.Print
{
	
public abstract class PrintServer
{	
	#if POCKET_PC
		protected CoreFactory	coreFactory= CoreFactory.getInstance();
	#else
		protected CoreFactory	coreFactory= UtilCoreFactory.createCoreFactory();
	#endif

	protected string sbody="";			
	protected string stitle="";			
	protected string sfooter="";
	protected int	 iorderPrintCopies=1;
	

	protected const string COPIES		= "f1";
	protected const string FIELD_TITLE	= "f2";
	protected const string FIELD_BODY	= "f3";
	protected const string FIELD_FOOTER	= "f4";
	

public PrintServer()
{
	sbody="";			
	stitle="";			
	sfooter="";
	iorderPrintCopies=1;
}

public void setDataToPrint(	string	stitle,
							string	sbody,							
							string	sfooter,
							int		iorderPrintCopies)
{

	this.stitle = stitle;
	this.sbody	= sbody;
	this.sfooter= sfooter;
	this.iorderPrintCopies = iorderPrintCopies;
}

public void setTitle(string stitle)
{
	this.stitle = stitle;
}
public void setBody(string sbody)
{
	this.sbody = sbody;
}
public void setFooter(string sfooter)
{
	this.sfooter = sfooter;
}

public void setOrderPrintCopies(int iorderPrintCopies)
{
	this.iorderPrintCopies = iorderPrintCopies;
}
	
public string getTitle()
{
	return this.stitle;
}
public string getBody()
{
	return this.sbody;
}
public string getFooter()
{
	return this.sfooter;
}
public int getOrderPrintCopies()
{
	return this.iorderPrintCopies;
}
public XmlDocument toXml()
{ 
	string			sxml;
	XmlDocument		xmlDoc = new XmlDocument();
	XmlElement		xmlElement = xmlDoc.DocumentElement;
	XmlAttribute	xmlAttribute=null;
					
	try{				
		sxml = "<" + getXmlHeader() + "></" + getXmlHeader() + ">";
		xmlDoc.LoadXml(sxml); 						 	

		xmlAttribute = xmlDoc.CreateAttribute(COPIES);
		xmlAttribute.Value = this.iorderPrintCopies.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FIELD_TITLE);
		xmlAttribute.Value = this.stitle;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FIELD_BODY);
		xmlAttribute.Value = this.sbody;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FIELD_FOOTER);
		xmlAttribute.Value = this.sfooter;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
		
	}catch (XmlException ex){
		xmlDoc=null;//error
		throw new NujitException("Error in class PrintServerOrderReport  <toXml> : " + ex.Message);		
	}
			
	return xmlDoc;

}//document to print

public 
bool parse(XmlDocument xmlDocument){
	bool	bresult=false;

	try{		
		XmlAttributeCollection xmlAttribCollection = xmlDocument.DocumentElement.Attributes;
		//read all of the attribute
		for (int i=0; i < xmlAttribCollection.Count; i++){
			bresult=true;
					
			if (xmlAttribCollection[i].Name.Equals(COPIES))
				this.iorderPrintCopies = int.Parse(xmlAttribCollection[i].Value);
			if (xmlAttribCollection[i].Name.Equals(FIELD_TITLE))
				this.stitle = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FIELD_BODY))
				this.sbody = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FIELD_FOOTER))
				this.sfooter = xmlAttribCollection[i].Value;			
		}
	}catch (XmlException ex){
		bresult=false;
		throw new NujitException("Error in class PrintServerOrderReport  <toXml> : " + ex.Message);		
	}   

	return bresult;
}

#if POCKET_PC
public bool printDirectly(out mPrint.MPRINT_RESULT retVal)
{
	bool					bresult=true;
	
	retVal =  mPrint.MPRINT_RESULT.MPRINT_SUCCESS;
	// jobID and docID are "out" parameters for CreateJob() and AddContent(),
	// so they must be StringBuilder objects, not strings.
	System.Text.StringBuilder jobID = new System.Text.StringBuilder(mPrint.mPrintControlWrapper.MPRINT_ID_LENGTH);
	System.Text.StringBuilder docID = new System.Text.StringBuilder(mPrint.mPrintControlWrapper.MPRINT_ID_LENGTH);

	// Create a new print job
	retVal = mPrint.mPrintControlWrapper.CreateJob(jobID, jobID.Capacity);
	if ( retVal != mPrint.MPRINT_RESULT.MPRINT_SUCCESS )
	{
		mPrint.mPrintWrapper.displayErrorMessage();
		return false;
	}

	// Create a "document" in a buffer and add it to the job.
	string strPrintBuffer = this.stitle + this.sbody + this.sfooter;

	System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
	byte[] charPrintBuffer = asciiEncoding.GetBytes( strPrintBuffer );
	
	// Add the document to the job
	retVal = mPrint.mPrintControlWrapper.AddContent(jobID, docID, docID.Capacity, charPrintBuffer, (UInt32) charPrintBuffer.Length, "txt");
	if ( retVal != mPrint.MPRINT_RESULT.MPRINT_SUCCESS )
	{
		mPrint.mPrintWrapper.displayErrorMessage();
		mPrint.mPrintControlWrapper.CloseJob(jobID);
		return false;
	}

	// Close and submit the job.
	retVal = mPrint.mPrintControlWrapper.CloseJob(jobID, true);
	if ( retVal != mPrint.MPRINT_RESULT.MPRINT_SUCCESS )
	{
		mPrint.mPrintWrapper.displayErrorMessage();
		return false;
	}

	return bresult;
}
public bool print()
{		
	bool					bresult		=false;
	SocketCom				socketCom	= new SocketCom();			
	try
	{		
		
		CoreFactory				coreFactory			= CoreFactory.getInstance();
		int						iTotReceive=1024;
		string					sdata="",smessage="",serror="";
		XmlDocument				xmlDocument=null;
		MessageHeader			messHeader			= new MessageHeader("Message");
		MessageIdentification	messIdentification	= new MessageIdentification();
		string					smessIdentification="";
				
		messIdentification.send(out smessIdentification);//message identification

		bresult=false;
		try {
			bresult = socketCom.connect(Configuration.getServerIp(),Constants.TCP_PORT);//connect
		}catch (ComunicationException){
			MessageBox.Show("Sorry, can not connect to the server.");
		}

		if (bresult)//connect
		{				
			xmlDocument = toXml();

			smessage = messHeader.getStartTag() + smessIdentification + xmlDocument.InnerXml + messHeader.getEndTag();			

			if (socketCom.send(smessage)) 				
			{
				bresult=false;
				try {
					bresult = socketCom.receive(out sdata,iTotReceive);//receive result
				}catch (ComunicationException){
					MessageBox.Show("Sorry, can not receive the response from the server.");
				}

				if (bresult)//receive result
				{
					//process the result
					if (processConfirm(sdata,out serror))
					{
						bresult=true;						
					}						
					else
					{
						bresult=false;		
						MessageBox.Show(serror);
					}
				}
			}						
		}		
	}
	catch (ComunicationException Cex)
	{
		MessageBox.Show(Cex.Message);
		bresult =false;
	}	
	catch (XmlException Xex)
	{
		MessageBox.Show(Xex.Message);
		bresult =false;
	}
	catch (Exception ex)
	{
		MessageBox.Show(ex.Message);
		bresult =false;	
	}finally{
		if (socketCom != null){
			socketCom.disconnect();
			socketCom = null; 
		}
	}
	return bresult;
}		
public 
bool processConfirm(string sdata,out string serror)
{
	bool			bresult=false;
	string			sxmlTag="";
	StringReader	stream;
	XmlTextReader	reader = null;	
	MessageConfirm  messConfirm	= new MessageConfirm();
	MessageError	messError	= new MessageError();
	XmlUtil2			xmlUtil= new XmlUtil2();
				
	serror="";
	try
	{
		XmlDocument		xmlDocument=null;
			
		stream = new StringReader(sdata);

		// Load the XmlTextReader from the stream
		reader = new XmlTextReader (stream);

		while (reader.Read())
		{						
			switch (reader.NodeType)
			{
				case XmlNodeType.Element: // a tag
			
					//reader.Name = type of tag
					sxmlTag= reader.Name;

					xmlDocument =	xmlUtil.readAttributes(reader);
					if (xmlDocument != null)
					{					
						if (messConfirm.getXmlHeader().Equals(sxmlTag))//confirm
						{							
							bresult=true;//ok, received							
						}						
						else if (messError.getXmlHeader().Equals(sxmlTag))//error
						{
							if (messError.receive(xmlDocument))
								serror = messError.getError();
						}
					}
					break;				
			}
		}

	}
	catch (Exception ex)
	{
		bresult=false;
		throw new NujitException(ex.Message);
	}
	finally
	{
		// finished with XmlTextReader
		if (reader != null)
			reader.Close();
	}
	return bresult;
}	
#else
public bool print(string spathPrintFile, out string serror)
{		
	bool			bresult=true;
	
	serror="";
	try	
	{
		PrintManager	printManager= new PrintManager(spathPrintFile);		
		for (int i=0; bresult && i < iorderPrintCopies;i++)
			bresult = printManager.print(out serror);					
	}	
	catch (System.Exception)
	{
		bresult =false;
	}
	return bresult;
}	
#endif	
public
bool createPrintFile(string spath)
{	
	bool	bresult=false;
	try
	{		
			FileStream outputFile = new FileStream(spath, FileMode.Create, FileAccess.Write);
			BinaryWriter writer = new BinaryWriter(outputFile);		

			if (stitle.Length > 0)
				writer.Write(this.stitle);

			if (sbody.Length > 0)
				writer.Write(this.sbody);

			if (sfooter.Length > 0)
				writer.Write(this.sfooter);
			
			writer.Close();
			outputFile.Close();

			bresult=true;		
	}	
	catch (IOException)
	{

		bresult=false;
	}	
	return bresult;
}	



public virtual string getXmlHeader(){ return "";}//Header




	}
}
	