using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.Model
{

	public abstract class IDemand
	{
		protected IDemand parent;
		protected DemandWIP firstSon;
		protected DemandWIP brother;
		protected ArrayList machines;
		protected string prodID;
		protected string seq;
		protected string custID;
		protected decimal prodRate;
		protected DateTime startDate;
		protected DateTime actualFinishDate;
		protected ArrayList demands;
		protected decimal orderID;
		protected decimal itemID;
		protected string releaseID;
		protected string department;

		public IDemand()
		{
			machines = new ArrayList();
			startDate = DateUtil.MaxValue;
			actualFinishDate = DateUtil.MinValue;
			demands = new ArrayList();
			prodID = "";
			seq = "";
			custID = "";
		}

		public abstract int getLevel();

		public abstract DateTime getGoalFinishDate();

		public DateTime getActualFinishDate()
		{
			return actualFinishDate;
		}

		public void setActualFinishDate(DateTime finishDate)
		{
			this.actualFinishDate = finishDate;
		}

		public void setStartDate(DateTime startDate)
		{
			this.startDate = startDate;
		}

		public DateTime getStartDate()
		{
			return startDate;
		}

		public DateTime getMinimumStartDate()
		{
			DateTime minStart = DateUtil.MinValue;
			IDemand son = this.getFirstSon();
			while (son != null)
			{
				if (son.getActualFinishDate().Add(DateUtil.getTimeSpanFromHours(getHoursLT())).CompareTo(minStart) > 0)
					minStart = son.getActualFinishDate().Add(DateUtil.getTimeSpanFromHours(getHoursLT()));
				son = son.getBrother();
			}
			if (minStart.Equals(DateUtil.MinValue))
				return DateTime.Now;
			else
				return minStart;
		}

		public abstract void resetDates();

		public abstract decimal getQty();

		public abstract decimal getOriginalQty();

		public string getProdID()
		{
			return prodID;
		}

		public string getSeq()
		{
			return seq;
		}

		public string getCustID()
		{
			return custID;
		}

		public abstract decimal getAssignedQoh();

		public abstract void setAssignedQoh(decimal qoh);

		public void setProdID(string prodID)
		{
			this.prodID = prodID;
		}

		public void setSeq(string seq)
		{
			this.seq = seq;
		}

		public void setCustID(string custID)
		{
			this.custID = custID;
		}

		public abstract decimal getHoursLT();

		public abstract void setHoursLT(decimal days);

		public decimal getOrderID() 
		{
			return orderID;
		}

		public void setOrderID(decimal orderID)
		{
			this.orderID = orderID;
		}

		public decimal getItemID() 
		{
			return itemID;
		}

		public void setItemID(decimal itemID)
		{
			this.itemID = itemID;
		}

		public string getReleaseID() 
		{
			return releaseID;
		}

		public void setReleaseID(string releaseID)
		{
			this.releaseID = releaseID;
		}

		public string getDepartment()
		{
			return department;
		}

		public void setDepartment(string department)
		{
			this.department = department;
		}

		public IDemand getParent()
		{
			return parent;
		}

		public IDemand getBrother()
		{
			return brother;
		}
	
		public IDemand getFirstSon()
		{
			return firstSon;
		}

		protected void addSon(DemandWIP demand)
		{
			if (firstSon == null)
				firstSon = demand;
			else
			{
				demand.brother = firstSon;
				firstSon = demand;
			}
		}

		protected void setParent(IDemand demand)
		{
			parent = demand;
			demand.addSon ((DemandWIP)this);
		}

		public void addMachine (PrioritizedMachine machine)
		{
			machines.Add (machine);
		}

		public decimal getProdRate()
		{
			return prodRate;
		}

		public void setProdRate(decimal prodRate)
		{
			this.prodRate = prodRate;
		}

		public void addOtherMachines (ArrayList machineList)
		{
			if (machineList != null)
			{
				IEnumerator enu = machineList.GetEnumerator();
				while (enu.MoveNext())
				{
					PrioritizedMachine priMachine = new PrioritizedMachine(99, (MachineNode)enu.Current);
					if (!machines.Contains(priMachine))
						machines.Add (priMachine);
				}
			}
		}

		public IEnumerator getMachinesEnumerator()
		{
			return machines.GetEnumerator();
		}

		public decimal getHrPr()
		{
			return getQty() / prodRate;
		}

		public void addTask(TaskNode node)
		{
			if (!demands.Contains(node))
			{
				int index = 0;
				while ((index < demands.Count) && (node.CompareTo(demands[index]) > 0))
					index ++;
				demands.Insert (index, node);
				node.setDemand(this);
			}
		}

		public IEnumerator getTasksEnumerator()
		{
			return demands.GetEnumerator();
		}

		public TaskNode getPreviousTask (TaskNode node)
		{
			int index = demands.IndexOf(node);
			index = index - 1;
			if (index >= 0)
				return (TaskNode)demands[index];
			else
				return null;
		}

		public void removeTask (TaskNode node)
		{
			if (demands.Contains(node))
			{
				demands.Remove(node);
				node.setDemand(null);
			}
		}

		public override bool Equals(object obj)
		{
			try 
			{
				IDemand dem = (IDemand)obj;
				return (orderID.Equals(dem.getOrderID()) && itemID.Equals(dem.getItemID()) && releaseID.Equals(dem.getReleaseID()) && this.getProdID().Equals(dem.getProdID()));
			}
			catch
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return getHashKey().GetHashCode();
		}


		public string getHashKey()
		{
			return orderID.ToString() + "_" + itemID.ToString() + "_" + releaseID;
		}

	}
}
