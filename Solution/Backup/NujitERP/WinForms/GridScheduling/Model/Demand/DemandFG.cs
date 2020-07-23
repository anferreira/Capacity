using System;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.Model
{

	public class DemandFG: IDemand, IComparable
	{

		private DateTime goalFinishDate;
		private decimal qty;
		private decimal assignedQoh;
		private bool active;

		public DemandFG()
		{
			active = false;
			firstSon = null;
			goalFinishDate = DateUtil.MinValue;
			qty = 0;
		}

		public override int getLevel()
		{
			return 1;
		}

		public void setGoalFinishDate(DateTime date)
		{
			this.goalFinishDate = date;
		}

		public override DateTime getGoalFinishDate()
		{
			return goalFinishDate;
		}

		public override void resetDates()
		{
			this.actualFinishDate = DateUtil.MinValue;
			this.startDate = DateUtil.MaxValue;
		}

		public void resetDatesFromRoot()
		{
			this.actualFinishDate = DateUtil.MinValue;
			this.startDate = DateUtil.MaxValue;
			resetDatesRecursively (getFirstSon());
		}

		private void resetDatesRecursively (IDemand demand)
		{
			if (demand == null)
				return;
			demand.resetDates();
			resetDatesRecursively (demand.getFirstSon());
			resetDatesRecursively (demand.getBrother());
		}

		public void setQty (decimal qty)
		{
			this.qty = qty;
		}

		public override decimal getQty()
		{
			return qty - assignedQoh;
		}

		public override decimal getOriginalQty()
		{
			return qty;
		}

		public override void setAssignedQoh (decimal qoh)
		{
			this.assignedQoh = qoh;
		}

		public override decimal getAssignedQoh ()
		{
			return assignedQoh;
		}

		public bool isActive()
		{
			return active;
		}

		public void setActive (bool isActive)
		{
			this.active = isActive;
		}

		public override void setHoursLT(decimal hoursLT){}
		public override decimal getHoursLT(){return 0;}

		public int CompareTo(object obj)
		{
			try
			{
				IDemand dem = (IDemand)obj;
				int result = this.getGoalFinishDate().CompareTo(dem.getGoalFinishDate());
				if (result == 0)
					result = this.getProdID().CompareTo(dem.getProdID());
				if (result == 0)
					result = this.getQty().CompareTo(dem.getQty()) * -1;
				return result;
			}
			catch
			{
				return -1;
			}
		}
	}
}
