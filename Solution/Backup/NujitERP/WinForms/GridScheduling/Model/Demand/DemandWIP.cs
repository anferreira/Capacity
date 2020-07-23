using System;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.Model
{

	public class DemandWIP: IDemand
	{
		private decimal qtyRelParent;
		private decimal assignedQoh;
		private decimal hoursLT;
		private int level;

		public DemandWIP(IDemand parent)
		{
			brother = null;
			firstSon = null;
			qtyRelParent = 0;
			assignedQoh = 0;
			hoursLT = 0;
			this.setParent (parent);
			level = parent.getLevel() + 1;
		}

		public override int getLevel()
		{
			return level;
		}


		public void setQtyRelParent (decimal qty)
		{
			qtyRelParent = qty;
		}

		public decimal getQtyRelParent()
		{
			return qtyRelParent;
		}

		public override DateTime getGoalFinishDate()
		{
			if (hoursLT <= 0)
				return parent.getStartDate();
			if (parent.getActualFinishDate().Equals (DateUtil.MinValue))
				return substractDecimalHours(parent.getGoalFinishDate());
			else
				return substractDecimalHours(parent.getActualFinishDate());
		}

		public override void resetDates()
		{
			this.actualFinishDate = DateUtil.MinValue;
			this.startDate = DateUtil.MaxValue;
		}

		public override decimal getQty()
		{
			return (parent.getQty() * qtyRelParent) - assignedQoh;
		}

		public override decimal getOriginalQty()
		{
			return (parent.getOriginalQty() * qtyRelParent);
		}

		public override void setAssignedQoh (decimal qoh)
		{
			this.assignedQoh = qoh;
		}

		public override decimal getAssignedQoh ()
		{
			return assignedQoh;
		}

		public override void setHoursLT(decimal hoursLT)
		{
			this.hoursLT = hoursLT;
		}

		public override decimal getHoursLT()
		{
			return hoursLT;
		}

		private DateTime substractDecimalHours (DateTime originalDate)
		{
			return originalDate.Subtract(DateUtil.getTimeSpanFromHours(hoursLT));			
		}
	}
}
