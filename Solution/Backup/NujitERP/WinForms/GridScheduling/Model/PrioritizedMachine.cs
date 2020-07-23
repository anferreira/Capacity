using System;

namespace GridScheduling.gui.Model
{
	public class PrioritizedMachine: IComparable
	{

		private MachineNode machine;
		private int priority;
		private DateTime dateLimit;

		public PrioritizedMachine(int priority, MachineNode machine)
		{
			this.machine = machine;
			this.priority = priority;
			dateLimit = DateTime.MinValue;
		}

		public MachineNode getMachine()
		{
			return machine;
		}

		public int getPriority()
		{
			return priority;
		}

		public void setDateLimit (DateTime limit)
		{
			dateLimit = limit;
		}

		public void removeDateLimit ()
		{
			dateLimit = DateTime.MinValue;
		}

		public override bool Equals(object obj)
		{
			try 
			{
				return this.machine.Equals(((PrioritizedMachine)obj).getMachine());
			}
			catch 
			{
				return base.Equals (obj);
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		public int CompareTo(object obj)
		{
			try 
			{
				MachineNode macNode = ((PrioritizedMachine)obj).getMachine();
				DateTime limit = ((PrioritizedMachine)obj).dateLimit;
				CapacityNode node1 = null;
				CapacityNode node2 = null;
				if (limit.CompareTo(DateTime.MinValue) > 0)
					node1 = macNode.getLastCapacity(limit);
				else
					node1 = macNode.getLastCapacity();
				while (node1.getUtilPer() <= 0)
					node1 = (CapacityNode)node1.getPrevious();
				if (dateLimit.CompareTo(DateTime.MinValue) > 0)
					node2 = machine.getLastCapacity(dateLimit);
				else
					node2 = machine.getLastCapacity();
				while (node2.getUtilPer() <= 0)
					node2 = (CapacityNode)node2.getPrevious();
				int result = node1.getDt().CompareTo(node2.getDt());
				if (result == 0)
				{
					string time = dateLimit.Hour.ToString("00") + ":" + dateLimit.Minute.ToString("00");
					if (dateLimit.Date.CompareTo(node1.getDt().Date) != 0)
						time = "24:00";
					string tm1 = node1.getTmEnd();
					string tm2 = node2.getTmEnd();
					if (tm1.CompareTo(time) > 0)
						tm1 = time;
					if (tm2.CompareTo(time) > 0)
						tm2 = time;
					result = tm1.CompareTo(tm2);
				}
				return result;
			}
			catch
			{
				return -1;
			}
		}

	}
}
