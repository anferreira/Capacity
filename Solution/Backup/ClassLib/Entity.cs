using System;

using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess;

namespace Nujit.NujitERP.ClassLib
{
	public class Entity
	{ 
		private int mintEntityID;
		private string mstrEntityCode;

		public Entity(){}

		public Entity(string code)
		{
			this.mstrEntityCode = code;
		}

		public Entity(int id,string code)
		{
			this.mintEntityID	= id;
			this.mstrEntityCode = code;
		}

		public int EntityID
		{
			get
			{
				return mintEntityID;
			}
			set
			{
				mintEntityID = value;
			}
		}

		public string EntityCode
		{
			get
			{
				return mstrEntityCode;
			}
			set
			{
				mstrEntityCode = value;
			}
		}
	}
}
