using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace GridScheduling.gui.Model
{
	public class MachineNode
	{
		private DateList freeCapacity;
		private DateList capacity;
		private ArrayList removedCapacities;
		private ArrayList addedTasks;
		private DateList tasks;
		private Machine machine;
		private string version;

		public MachineNode(Machine machine, string version)
		{
			this.machine = machine;
			this.version = version;
			capacity = new DateList();
			freeCapacity = new DateList();
			tasks = new DateList();
			removedCapacities = new ArrayList();
			addedTasks = new ArrayList();
		}

		public void loadCapacityList (CoreFactory core)
		{
			Capacity cap = core.readCapacity (version, machine.getPlt(), machine.getDept(), machine.getMach());
			string[][] capHours = cap.getAllHoursAsString();
			IEnumerator enuCap = capHours.GetEnumerator();
			while (enuCap.MoveNext())
				this.addCapacityNode (new CapacityNode((string[])enuCap.Current));
		}

		public void addCapacityNode (CapacityNode node)
		{
			freeCapacity.add (node);
			capacity.add (node.clone());
		}

		public void addTaskNode (TaskNode node)
		{
			addTaskNode (node, true);
		}

		private void addTaskNode (TaskNode node, bool registerUndo)
		{
			tasks.add (node);
			if (registerUndo)
				addedTasks.Add (node);

			CapacityNode capNode = (CapacityNode)freeCapacity.getLastNode(node.getDate());
			if ((capNode != null) && (capNode.getDt().Equals(node.getStartDate().Date)))
			{
				CapacityNode cap1 = capNode.clone();
				CapacityNode cap2 = capNode.clone();
				
				cap1.setTmEnd (node.getStartDate().Hour.ToString("00") + ":" + node.getStartDate().Minute.ToString("00"));
				cap2.setTmStart (node.getEndDate().Hour.ToString("00") + ":" + node.getEndDate().Minute.ToString("00"));

				freeCapacity.remove (capNode);
				if (registerUndo)
					removedCapacities.Add (capNode);

				if (cap1.getTmStart().CompareTo(cap1.getTmEnd()) < 0)
					freeCapacity.add (cap1);

				if (cap2.getTmStart().CompareTo(cap2.getTmEnd()) < 0)
					freeCapacity.add (cap2);
			}	
			node.setMachineNode (this);

			if (node.getDemand().getActualFinishDate().CompareTo(node.getEndDate()) < 0)
				node.getDemand().setActualFinishDate(node.getEndDate());
			if (node.getDemand().getStartDate().CompareTo(node.getStartDate()) > 0)
				node.getDemand().setStartDate(node.getStartDate());
		}

		public void unDo()
		{
			unDo(removedCapacities, addedTasks);
			commit();
		}

		private void unDo(ArrayList capacitiesToAdd, ArrayList tasksToRemove)
		{
			for (int i = capacitiesToAdd.Count - 1; i >= 0; i--)
			{
				CapacityNode node = (CapacityNode)capacitiesToAdd[i];
				CapacityNode previous = (CapacityNode)freeCapacity.getLastNode (node.getDate());
				if ((previous != null) && (!previous.getDt().Equals(node.getDt())))
					previous = (CapacityNode)previous.getNext();
				if (previous == null)
				{
					previous = (CapacityNode)freeCapacity.getLastNode(node.getDt().Add(DateUtil.getTimeSpanFromHours(decimal.Parse(node.getTmEnd().Substring(0,2)) + (decimal.Parse(node.getTmEnd().Substring(0,2)) / 60))));
					if (previous != null)
						while (previous.getPrevious() != null)
							previous = (CapacityNode)previous.getPrevious();
				}
				while ((previous != null) && (previous.getDt().Equals(node.getDt())) && (previous.getTmEnd().CompareTo(node.getTmEnd()) <= 0))
				{
					if (previous.getTmStart().CompareTo(node.getTmStart()) >= 0)
					{
						CapacityNode aux = previous;
						previous = (CapacityNode)previous.getNext();
						if (previous != null)
							previous.setPrevious(aux.getPrevious());
						freeCapacity.remove(aux);
					}
					else
						previous = (CapacityNode)previous.getNext();
				}
				freeCapacity.add (node);
			}

			IEnumerator enu = tasksToRemove.GetEnumerator();
			while (enu.MoveNext())
			{
				tasks.remove ((DateListNode)enu.Current);
				((TaskNode)enu.Current).setDemand(null);
			}
		}

		public void commit()
		{
			removedCapacities.Clear();
			addedTasks.Clear();
		}

		public bool insertDemandFromDeadline(IDemand demand)
		{
			ArrayList auxCapacities = new ArrayList();
			ArrayList auxTasks = new ArrayList();

			DateTime goal = demand.getGoalFinishDate();

			CapacityNode capNode = (CapacityNode)freeCapacity.getLastNode (goal);
			while ((capNode != null) && (capNode.getUtilPer() <= 0))
				capNode = (CapacityNode)capNode.getPrevious();
			decimal hoursLeft = demand.getHrPr();
			while ((hoursLeft > 0) && (capNode != null) && (capNode.getEndDate().CompareTo(DateTime.Now) > 0))
			{
				DateTime endDate = capNode.getDt().Date.AddHours(int.Parse(capNode.getTmEnd().Substring(0,2))).AddMinutes(int.Parse(capNode.getTmEnd().Substring(3,2)));
				if (goal.CompareTo(endDate) <= 0)
					endDate = new DateTime(goal.Year, goal.Month, goal.Day, goal.Hour, goal.Minute, 0);

				TimeSpan time = DateUtil.getTimeSpanFromHours ((hoursLeft * 100) / capNode.getUtilPer());
				if (time.Seconds > 0)
					time = TimeSpan.FromMinutes (Math.Floor(time.TotalMinutes) + 1);
				if ((decimal)time.TotalHours < ((hoursLeft * 100) / capNode.getUtilPer()))
					time = TimeSpan.FromMinutes (Math.Floor(time.TotalMinutes) + 1);

				DateTime startDate = endDate.Subtract(time);
				DateTime capStartDate = capNode.getStartDate();
				if (capStartDate.CompareTo(startDate) > 0)
				{
					startDate = capStartDate;
				}
				if (startDate.CompareTo(DateTime.Now) < 0)
					startDate = DateTime.Today.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute + 1);
				time = endDate.Subtract (startDate);

				if (time.TotalHours > 0)
				{
					TaskNode taskNode = new TaskNode();
					taskNode.setEndDate (endDate);
					taskNode.setStartDate (startDate);

					taskNode.setIsFamilyPart (false);
					taskNode.setMachineNode (this);
					taskNode.setPos (0);
					taskNode.setProdHours ((decimal)time.TotalHours);
					taskNode.setProdId (demand.getProdID());
					taskNode.setQty (((taskNode.getProdHours() * capNode.getUtilPer()) / 100) * demand.getProdRate());
					taskNode.setSeq (demand.getSeq());
					taskNode.setShift (capNode.getSh());
					taskNode.setTmType (capNode.getTmType());
					taskNode.setUtilPer (capNode.getUtilPer());
					taskNode.makeFromDemand();
				
					auxCapacities.Add (capNode);
					auxTasks.Add (taskNode);
					taskNode.setDemand(demand);

					this.addTaskNode (taskNode, false);
			
					hoursLeft -= (taskNode.getProdHours() * taskNode.getUtilPer()) / 100;
				}
				capNode = (CapacityNode)capNode.getPrevious();
				while ((capNode != null) && (capNode.getUtilPer() <= 0))
					capNode = (CapacityNode)capNode.getPrevious();
			}
			if (hoursLeft <= 0)
			{
				removedCapacities.AddRange (auxCapacities);
				addedTasks.AddRange (auxTasks);
				return true;
			}
			else
			{
				unDo (auxCapacities, auxTasks);
				return false;
			}
		}

		public bool insertDemandFromStartPoint(IDemand demand)
		{
			ArrayList auxCapacities = new ArrayList();
			ArrayList auxTasks = new ArrayList();

			DateTime minStart = demand.getMinimumStartDate();

			if ((minStart.Second != 0) || (minStart.Millisecond != 0))
				minStart = minStart.Date.AddHours(minStart.Hour).AddMinutes(minStart.Minute + 1);

			CapacityNode capNode = (CapacityNode)freeCapacity.getFirstNode(minStart);
			while ((capNode != null) && ((capNode.getUtilPer() <= 0) || (capNode.getEndDate().CompareTo(minStart) <= 0)))
				capNode = (CapacityNode)capNode.getNext();
			decimal hoursLeft = demand.getHrPr();
			while ((hoursLeft > 0) && (capNode != null))
			{
				DateTime startDate = capNode.getStartDate();
				if (startDate.CompareTo(minStart) < 0)
					startDate = minStart;

				TimeSpan time = DateUtil.getTimeSpanFromHours ((hoursLeft * 100) / capNode.getUtilPer());
				if (time.Seconds > 0)
					time = TimeSpan.FromMinutes (Math.Floor(time.TotalMinutes) + 1);
				if ((decimal)time.TotalHours < ((hoursLeft * 100) / capNode.getUtilPer()))
					time = TimeSpan.FromMinutes (Math.Floor(time.TotalMinutes) + 1);

				DateTime endDate = startDate.Add(time);
				if (capNode.getEndDate().CompareTo(endDate) < 0)
					endDate = capNode.getEndDate();

				time = endDate.Subtract (startDate);

				if (time.TotalHours > 0)
				{
					TaskNode taskNode = new TaskNode();
					taskNode.setEndDate (endDate);
					taskNode.setStartDate (startDate);

					taskNode.setIsFamilyPart (false);
					taskNode.setMachineNode (this);
					taskNode.setPos (0);
					taskNode.setProdHours ((decimal)time.TotalHours);
					taskNode.setProdId (demand.getProdID());
					taskNode.setQty (((taskNode.getProdHours() * capNode.getUtilPer()) / 100) * demand.getProdRate());
					taskNode.setSeq (demand.getSeq());
					taskNode.setShift (capNode.getSh());
					taskNode.setTmType (capNode.getTmType());
					taskNode.setUtilPer (capNode.getUtilPer());
					taskNode.makeFromDemand();
				
					auxCapacities.Add (capNode);
					auxTasks.Add (taskNode);
					taskNode.setDemand(demand);

					this.addTaskNode (taskNode, false);
			
					hoursLeft -= (taskNode.getProdHours() * taskNode.getUtilPer()) / 100;
				}
				capNode = (CapacityNode)capNode.getNext();
				while ((capNode != null) && (capNode.getUtilPer() <= 0))
					capNode = (CapacityNode)capNode.getNext();
			}
			if (hoursLeft <= 0)
			{
				removedCapacities.AddRange (auxCapacities);
				addedTasks.AddRange (auxTasks);
				return true;
			}
			else
			{
				unDo (auxCapacities, auxTasks);
				return false;
			}
		}

		public override bool Equals(object obj)
		{
			try{
				return (machine.getMach().Equals(((MachineNode)obj).machine.getMach()) && machine.getDept().Equals(((MachineNode)obj).getMachine().getDept()));
			}
			catch{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return (machine.getDept() + "_" + machine.getMach()).GetHashCode();
		}

		public string getHashKey()
		{
			return machine.getDept() + "_" + machine.getMach();
		}

		public IEnumerator getTasksEnumerator()
		{
			return tasks.getEnumerator();
		}

		public CapacityNode getLastCapacity()
		{
			return (CapacityNode)this.freeCapacity.getLastNode();
		}

		public CapacityNode getLastCapacity(DateTime limit)
		{
			return (CapacityNode)this.freeCapacity.getLastNode(limit);
		}

		public TaskNode getLastTask()
		{
			return (TaskNode)this.tasks.getLastNode();
		}

		public TaskNode getLastTask(DateTime limit)
		{
			return (TaskNode)this.tasks.getLastNode(limit);
		}

		public CapacityNode getFirstFreeCapacity()
		{
			return (CapacityNode)this.freeCapacity.getFirstNode();
		}

		public CapacityNode getFirstOriginalCapacity()
		{
			return (CapacityNode)this.capacity.getFirstNode();
		}

		public CapacityNode getFirstFreeCapacity(DateTime minimum)
		{
			return (CapacityNode)this.freeCapacity.getFirstNode(minimum);
		}

		public TaskNode getFirstTask()
		{
			return (TaskNode)this.tasks.getFirstNode();
		}

		public TaskNode getFirstTask(DateTime minimum)
		{
			return (TaskNode)this.tasks.getFirstNode(minimum);
		}

		public Machine getMachine()
		{
			return machine;
		}

		public void setMachine (Machine machine)
		{
			this.machine = machine;
		}

		public void removeTask(TaskNode taskNode)
		{
			if (taskNode.getPrevious() != null)
				taskNode.getPrevious().setNext(taskNode.getNext());

			taskNode.getDemand().resetDates();
			taskNode.getDemand().removeTask(taskNode);
			tasks.remove (taskNode);
			CapacityNode origCapNode = (CapacityNode)capacity.getLastNode (taskNode.getDate());
			CapacityNode newCapNode = origCapNode.clone();
			newCapNode.setTmStart(taskNode.getStartDate().Hour.ToString("00") + ":" + taskNode.getStartDate().Minute.ToString("00"));
			newCapNode.setTmEnd(taskNode.getEndDate().Hour.ToString("00") + ":" + taskNode.getEndDate().Minute.ToString("00"));

			CapacityNode freeCapNode = (CapacityNode)freeCapacity.getLastNode (taskNode.getDate());
			if ((freeCapNode != null) && (newCapNode.getDt().Date.Equals(freeCapNode.getDt().Date)) && (newCapNode.getTmStart().Equals(freeCapNode.getTmEnd()))
				&& (origCapNode.getTmStart().CompareTo(freeCapNode.getTmStart()) <= 0))
			{
				newCapNode.setTmStart (freeCapNode.getTmStart());
				freeCapacity.remove (freeCapNode);
			}

			if (freeCapNode != null)
				freeCapNode = (CapacityNode)freeCapNode.getNext();
			else
				freeCapNode = (CapacityNode)freeCapacity.getFirstNode();

			if ((freeCapNode != null) && (newCapNode.getDt().Date.Equals(freeCapNode.getDt().Date)) && (newCapNode.getTmEnd().Equals(freeCapNode.getTmStart()))
				&& (origCapNode.getTmEnd().CompareTo(freeCapNode.getTmEnd()) >= 0))
			{
				newCapNode.setTmEnd (freeCapNode.getTmEnd());
				freeCapacity.remove (freeCapNode);
			}

			freeCapacity.add (newCapNode);
		}

		public void removeTasksFromDemand()
		{
			TaskNode taskNode = this.getFirstTask();
			while (taskNode != null)
			{
				TaskNode nextTask = (TaskNode)taskNode.getNext();
				if (taskNode.getIsFromDemand())
					this.removeTask(taskNode);
				taskNode = nextTask;
			}
		}

		public void removeAllTasks()
		{
			tasks = new DateList();
			freeCapacity = new DateList();
			CapacityNode node = (CapacityNode)capacity.getFirstNode();
			while (node != null)
			{
				freeCapacity.add (node.clone());
				node = (CapacityNode)node.getNext();
			}
		}
	}
}
