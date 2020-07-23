using System;
using System.Collections;
using System.Drawing;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.CapacityModule
{
	/// <summary>
	/// Summary description for TimeCodes.
	/// </summary>
	public class TimeCodes
	{
		private static TimeCodes instance = null;

		private Hashtable macHrPrPorcentages = null;
		private Hashtable timeCodes = null;
		private CoreFactory coreFactory = null;
		private TimeCode[] machineTimeCodes = null;
		private TimeCode[] labourTimeCodes = null;

        private TimeCodes()
		{
			coreFactory = UtilCoreFactory.createCoreFactory();
			TimeCode[] auxTimeCodes = coreFactory.getTimeCodeObjects();
			this.timeCodes = new Hashtable(auxTimeCodes.Length);
			for (int i=0; i<auxTimeCodes.Length; i++)
				timeCodes.Add (auxTimeCodes[i].getTmType(),auxTimeCodes[i]);

			macHrPrPorcentages = new Hashtable();
		}

		public static TimeCodes getInstance()
		{
			if (instance == null)
				instance = new TimeCodes();
			return instance;
		}

		public Color getColor (TimeCode timeCode)
		{
			return Color.FromArgb (int.Parse(timeCode.getColor().Substring(0,3)),int.Parse(timeCode.getColor().Substring(4,3)),int.Parse(timeCode.getColor().Substring(8,3)));
		}

		public TimeCode getTimeCode (string code)
		{
			if (this.timeCodes.ContainsKey (code))
				return (TimeCode)this.timeCodes[code];
			else
				return null;
		}

		public string getEquivalentCode (string labourCode)
		{
			return labourCode;
		}

		public TimeCode[] getMachinesCodes()
		{
			if (this.machineTimeCodes == null)
			{
				this.machineTimeCodes = new TimeCode[this.timeCodes.Count];
				IDictionaryEnumerator enu = this.timeCodes.GetEnumerator();
				int i = 0;
				while (enu.MoveNext())
				{
					this.machineTimeCodes[i] = (TimeCode)enu.Value;
					i++;
				}
			}
			return this.machineTimeCodes;
		}

		public TimeCode[] getLabourCodes()
		{
			if (this.labourTimeCodes == null)
			{
				this.labourTimeCodes = new TimeCode[this.timeCodes.Count];
				IDictionaryEnumerator enu = this.timeCodes.GetEnumerator();
				int i = 0;
				while (enu.MoveNext())
				{
					this.labourTimeCodes[i] = (TimeCode)enu.Value;
					i++;
				}
			}
			return this.labourTimeCodes;
		}

		public decimal getMachineProductionHoursPorcentage (TimeCode timeCode, string plt, string dept, string machine)
		{
			decimal porc = -1M;
			if (this.macHrPrPorcentages.ContainsKey(plt + "/" + dept + "/" + machine + "/" + timeCode.getTmType()))
				porc = (decimal)this.macHrPrPorcentages[plt + "/" + dept + "/" + machine + "/" + timeCode.getTmType()];
			else
			{
				porc = this.coreFactory.getMachineTimeCodePorc (plt, dept, machine, timeCode.getTmType());
				this.macHrPrPorcentages.Add (plt + "/" + dept + "/" + machine + "/" + timeCode.getTmType(), porc);
			}
			if (porc >= 0M)
				return porc;
			else
				return timeCode.getHrPrPorc();
		}
	}
}
