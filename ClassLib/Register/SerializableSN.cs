using System;
using System.IO;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;

using System.Drawing;
using System.Collections;
using System.ComponentModel;

using System.Data;

using Nujit.NujitERP.ClassLib.Common;
							 
namespace Nujit.NujitERP.ClassLib.Register
{
	
	[Serializable]
	public class SerializableSN
	{
		private const string SERIALIZED_CLASS_FILENAME = @"data.out";
        
		
		public string prodCode   = string.Empty;
		public string sn         = string .Empty;
		public int times         = 0;
		
		public int Times 
		{
			get
			{  
				return	 times;
			}
			set
			{
				times = value;
			
			}
		}
		public string Prodcode 
		{
			get
			{  
				return	 prodCode;
			}
			set
			{
				prodCode = value;
			
			}
		}
		public string SerializedClassFileName
		{
			get
			{
				return SERIALIZED_CLASS_FILENAME ;
			}
		}
		public string SN
		{
			get
			{  
				return	 sn ;
			}
			set
			{
				sn  = value;
			
			}
		}

		public SerializableSN()
		{
		   this.prodCode = "EVAL";
		   this.sn       = "EVAL";
		this.Times      = 0;
		
		}
	 
		public void Store()
		{
			// serialize the current instance
			FileStream fsOutput			= new FileStream(Configuration.DataRoot + @"\" + SERIALIZED_CLASS_FILENAME, FileMode.Create);
			IFormatter formatter        = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			formatter.Serialize(fsOutput,this);
			fsOutput.Close();
		}
		
		
		public static SerializableSN RetrieveSerializedSN()
		{
			try
			{
				SerializableSN	objSerializableSNToReturn ;
			
				// test if file exists.
				if(File.Exists(Configuration.DataRoot + @"\" +  SERIALIZED_CLASS_FILENAME))
				{
					// read back serialized objectinstance
					FileStream fsOutput			= new FileStream(Configuration.DataRoot + @"\" +  SERIALIZED_CLASS_FILENAME, FileMode.Open);
					IFormatter formatter        = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					objSerializableSNToReturn   = (SerializableSN)formatter.Deserialize(fsOutput);

					fsOutput.Close();
				}
				else
				{
								
					objSerializableSNToReturn = new SerializableSN();

				}

				return objSerializableSNToReturn;
			}
			catch
			{
				// General error, bubble
				throw;
				
			}
		}
	}
}

