using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.Model
{
	public class ScheduleModel
	{
		private Hashtable htMachines;
		private CoreFactory core;
		private Hashtable htConfigurations;
		private Hashtable htAllDemands;
		private DateTime tasksDateFrom;
		private DateTime tasksDateTo;
		private string plant;
		private string version;
		private Schedule schedule;
		private UpdatableForm form = null;

		#region GenerateFromDemandTempAttributes

		private ArrayList demands;
		private ArrayList discardedDemands;
		private ArrayList pastDueDemands;
		private Hashtable htHoursLT;
		private ArrayList usedMachines;
		private Hashtable htQohs;
		private Hashtable htOriginalQohs;
		private bool asignQohToPastDue;

		#endregion

		public ScheduleModel()
		{
			htMachines = new Hashtable();
			htConfigurations = new Hashtable();
			htAllDemands = new Hashtable();
			this.core = UtilCoreFactory.createCoreFactory();
			tasksDateFrom = DateTime.Today;
			tasksDateTo = DateTime.Today.AddMonths(3);
		}

//		public void disposeModel()
//		{
			/////////////////////////////////////////////////////////////////////////
//		}

		public void disposeVersion()
		{
			htMachines = new Hashtable();
			htConfigurations = new Hashtable();
			schedule = null;
		}

		public void loadCapacityAndMachines (string plant, string version)
		{
			this.plant = plant;
			this.version = version;

			loadConfigurationsAndCapacities();
			loadSchedule(plant, version);

			if (form != null)
				form.processComplete();
		}

		public void loadSchedule (string plant, string version)
		{
			int currPos = 0;

			updateStatus ("Adding existing tasks...",0);
			schedule = core.readSchedule(plant, version);
			string[][] vec = schedule.getSchPrMasStr();
			int total = vec.Length;

			IEnumerator enuTasks = vec.GetEnumerator();
			while (enuTasks.MoveNext())
			{
				TaskNode node = new TaskNode((string[])enuTasks.Current, core);
				string ordID = ((string[])enuTasks.Current)[28];
				string itemID = ((string[])enuTasks.Current)[29];
				string relID = ((string[])enuTasks.Current)[30];
				string machine = ((string[])enuTasks.Current)[23];
				string macDept = ((string[])enuTasks.Current)[31];
				string prodID = ((string[])enuTasks.Current)[2];
				string seq = ((string[])enuTasks.Current)[4];
				IDemand dem = (IDemand)htAllDemands[ordID + "_" + itemID + "_" + relID];
				if ((dem != null) && (dem.getProdID().Equals(prodID)))
				{
					node.setDemand(dem);
				}
				else
				{
					DemandWIP demand = new DemandWIP(dem);
					demand.setOrderID(decimal.Parse(ordID));
					demand.setItemID(decimal.Parse(itemID));
					demand.setReleaseID(relID);
					demand.setProdID(prodID);
					demand.setSeq(seq);
					node.setDemand(demand);
				}
				

				this.addTask (node, schedule, macDept, machine);

				currPos++;
				updateStatus ("Adding existing tasks...",(int)((currPos*100) / total));
			}

			IEnumerator enuMachines = htMachines.GetEnumerator();
			while (enuMachines.MoveNext())
				((MachineNode)((DictionaryEntry)enuMachines.Current).Value).commit();
		}

		public bool demandsAreLoaded()
		{
			return (htAllDemands.Count > 0);
		}

		public void loadDemands()
		{
			loadDemands(DateTime.MinValue, DateTime.MaxValue);
		}

		public void loadDemands(DateTime dateFrom, DateTime dateTo)
		{
			updateStatus ("Getting demand from the data base...",0);

			string[][] strDemands = core.getDemandAsStringByDate(dateFrom, dateTo);

			int currPos = 0;
			int total = strDemands.Length;
			
			IEnumerator enu = strDemands.GetEnumerator();
			while (enu.MoveNext())
			{
				string[] item = (string[])enu.Current;
				DemandFG demand = new DemandFG();
				demand.setProdID (item[0]);
				demand.setSeq (item[1]);
				demand.setCustID (item[7]);
				demand.setGoalFinishDate (DateUtil.parseDate(item[2], DateUtil.MMDDYYYY));
				demand.setQty (decimal.Parse(item[3]));
				demand.setOrderID (decimal.Parse(item[4]));
				demand.setItemID (decimal.Parse(item[5]));
				demand.setReleaseID (item[6]);
				demand.setActive (item[8].Equals("A"));

				if (htAllDemands.ContainsKey (demand.getHashKey()))
				{
					if (decimal.Parse(((IDemand)htAllDemands[demand.getHashKey()]).getSeq()) < decimal.Parse(demand.getSeq()))
						htAllDemands[demand.getHashKey()] = demand;
				}
				else
					htAllDemands.Add (demand.getHashKey(), demand);

				currPos++;
				updateStatus ("Getting demand from the data base...",(int)((currPos*100) / total));
			}

			if (form != null)
				form.processComplete();
		}

		private void loadConfigurationsAndCapacities()
		{
			ArrayList machinesList = new ArrayList();
			int currPos = 0;
			updateStatus ("Getting machines...",0);

			DepartamentContainer depContainer = core.readDepartamentsByPlt (plant);
			IEnumerator enuDepts = depContainer.GetEnumerator();
			while (enuDepts.MoveNext())
			{
				string dept = ((Departament)enuDepts.Current).getDept();
				MacConfiguration[] confs = core.readAllConfigurations (plant, dept);
				foreach (MacConfiguration conf in confs)
				{
					Machine[] macsInConf = core.getMachinesFromConfiguration (plant, dept, conf.getCfg());
					foreach (Machine machine in macsInConf)
					{
						machinesList.Add (new DictionaryEntry(conf.getCfg(),machine));
					}
				}
			}
			int total = machinesList.Count;

			IEnumerator enuMachines = machinesList.GetEnumerator();
			while (enuMachines.MoveNext())
			{
				Machine machine = (Machine)((DictionaryEntry)enuMachines.Current).Value;

				MachineNode node = (MachineNode)htMachines[machine.getDept() + "_" + machine.getMach()];
				if (node == null)
				{
					node = new MachineNode (machine, version);
					node.loadCapacityList(core);
					htMachines.Add (node.getHashKey(), node);
				}
				ArrayList list = (ArrayList)htConfigurations[machine.getDept() + "_" + ((DictionaryEntry)enuMachines.Current).Key.ToString()];
				if (list == null)
				{
					list = new ArrayList();
					htConfigurations.Add(machine.getDept() + "_" + ((DictionaryEntry)enuMachines.Current).Key.ToString(), list);
				}
				list.Add (node);

				currPos++;
				updateStatus ("Loading capacities...",(int)((currPos*100) / total));
			}
		}

		private void addTask (TaskNode node, Schedule schedule, string dept, string machine)
		{
			MachineNode macNode = (MachineNode)htMachines[dept + "_" + machine];
			if (macNode == null)
			{
				macNode = new MachineNode(core.readMachine(plant, dept, machine), version);
				macNode.loadCapacityList (core);
				htMachines.Add (macNode.getHashKey(),macNode);
			}
			macNode.addTaskNode (node);
		}

		private void initializeTempAttributes()
		{
			demands = new ArrayList();
			pastDueDemands = new ArrayList();
			htHoursLT = new Hashtable();
			usedMachines = new ArrayList();
			htQohs = new Hashtable();
			htOriginalQohs = new Hashtable();
			discardedDemands = new ArrayList();

			asignQohToPastDue = true;
		}

		public void disposeModel()
		{
			demands = null;
			pastDueDemands = null;
			htHoursLT = null;
			usedMachines = null;
			htQohs = null;
			htOriginalQohs = null;
			discardedDemands = null;
		}

		public void setTimeScope(DateTime dateFrom, DateTime dateTo)
		{
			tasksDateFrom = dateFrom;
			tasksDateTo = dateTo;
		}

		public DateTime getTimeScopeFrom()
		{
			return tasksDateFrom;
		}

		public DateTime getTimeScopeTo()
		{
			return tasksDateTo;
		}

		public void insertTasksFromDemand ()
		{
			initializeTempAttributes();

			updateStatus ("Getting demands...",0);
			fillDemands(tasksDateFrom, tasksDateTo);
			updateStatus ("Generating demands trees...",0);
			explodeDemands();
			updateStatus ("Getting products info...",0);
			getHoursLTCum();
			updateStatus ("Getting current inventory...",0);
			getProdsQohs();
			bool more = true;
			while(more)
			{
				updateStatus ("Scheduling demands...",0);
				more = asignDemands(demands);
				if (more)
				{
					updateStatus ("Assigning qoh to tasks...",0);
					more = asignQohs();
				}
			}

			ArrayList discardedDemandsAux = (ArrayList)discardedDemands.Clone();
			discardedDemands.Clear();

			updateStatus ("Assigning qoh to discarded tasks....",0);
			asignQohToPastDueDemands(ref discardedDemandsAux); //Uses same method, though demands aren't past due
			updateStatus ("Scheduling demands...",0);
			asignDemands(discardedDemandsAux);	

			discardedDemandsAux = (ArrayList)discardedDemands.Clone();
			discardedDemands.Clear();

			updateStatus ("Scheduling out of time demands...",0);
			asignDiscardedDemands(discardedDemandsAux);

			updateStatus ("Complete",0);
			if (form != null)
				form.processComplete();
		}

		private void fillDemands(DateTime dateFrom, DateTime dateTo)
		{
			int currPos = 0;
			int total = htAllDemands.Values.Count;

			IEnumerator enu = htAllDemands.Values.GetEnumerator();
			while (enu.MoveNext())
			{
				DemandFG dem = (DemandFG)enu.Current;
				if (dem.isActive() && (dem.getGoalFinishDate().CompareTo(dateFrom) >= 0) && (dem.getGoalFinishDate().CompareTo(dateTo) <= 0))
				{
					if (dem.getGoalFinishDate().CompareTo(DateTime.Now) <= 0)
						pastDueDemands.Add (enu.Current);
					else
						demands.Add (enu.Current);
				}
				currPos++;
				updateStatus("Getting demands...",(int)((currPos*100) / total));
			}
			demands.Sort();
		}

		private void explodeDemands()
		{
			int currPos = 0;
			int total = demands.Count + pastDueDemands.Count;

			Hashtable htBom = new Hashtable();
			IEnumerator enu = demands.GetEnumerator();
			core.loadInfoForBom();
			bool oneMoreToGo = true;
			bool hasMore = enu.MoveNext();
			while (hasMore || oneMoreToGo)
			{
				if (!hasMore && oneMoreToGo)
				{
					enu = pastDueDemands.GetEnumerator();
					oneMoreToGo = false;
				}
				else
				{
					DemandFG demand = (DemandFG)enu.Current;
					Bom bom = null;

					if (htBom.ContainsKey(demand.getProdID()))
						bom = (Bom)htBom[demand.getProdID()];
					else
					{
						bom = core.makeBomFromProdIDAndSeq (demand.getProdID(), int.Parse(demand.getSeq()));
						htBom.Add (demand.getProdID(), bom);
					}
					
					demand.setProdRate (bom.getProdRate());
					demand.setDepartment (bom.getDepartament());

					explodeDemand (demand, bom);
					currPos++;
					updateStatus ("Generating demands trees...",(int)((currPos*100) / total));
				}
				hasMore = enu.MoveNext();
			}

			core.discardInfoForBom();
			htBom = null;
		}

		private void explodeDemand(IDemand demand, Bom bom)
		{
			IEnumerator enuMachines = bom.getSortedMachinePreferences();
			int i = 0;
			while (enuMachines.MoveNext())
			{
				MachineNode node = (MachineNode)htMachines[enuMachines.Current.ToString()];
				if (node != null)
					demand.addMachine(new PrioritizedMachine(i,node));
				i++;
			}

			demand.addOtherMachines ((ArrayList)htConfigurations[bom.getDepartament() + "_" + bom.getCfg()]);

			IEnumerator enu = bom.getBomContainer().GetEnumerator();
			while (enu.MoveNext())
			{
				Bom bomSon = (Bom)enu.Current;
				if (!bomSon.isPurchased())
				{
					DemandWIP newDemand = new DemandWIP(demand);
					newDemand.setQtyRelParent (bomSon.getQty());
					newDemand.setProdID (bomSon.getProd());
					newDemand.setSeq (NumberUtil.toString(bomSon.getSeq()));
					newDemand.setProdRate (bomSon.getProdRate());
					newDemand.setOrderID (demand.getOrderID());
					newDemand.setItemID (demand.getItemID());
					newDemand.setReleaseID (demand.getReleaseID());
					newDemand.setDepartment (bomSon.getDepartament());
					explodeDemand (newDemand, bomSon);
				}
			}
		}
		
		private void getProdsQohs()
		{
			int currPos = 0;
			int total = demands.Count + pastDueDemands.Count;

			IEnumerator enuDemands = demands.GetEnumerator();
			while (enuDemands.MoveNext())
			{
				loadQohFromDemand ((IDemand)enuDemands.Current);
				currPos++;
				updateStatus ("Getting current inventory...",(int)((currPos*100) / total));
			}

			enuDemands = pastDueDemands.GetEnumerator();
			while (enuDemands.MoveNext())
			{
				loadQohFromDemand ((IDemand)enuDemands.Current);
				currPos++;
				updateStatus ("Getting current inventory...",(int)((currPos*100) / total));
			}

			IEnumerator enuQoh = htQohs.GetEnumerator();
			while (enuQoh.MoveNext())
			{
				DictionaryEntry dEntry = (DictionaryEntry)enuQoh.Current;
				htOriginalQohs.Add (dEntry.Key, dEntry.Value);
			}
		}

		private void loadQohFromDemand (IDemand demand)
		{
			if (demand == null)
				return;
			string hashKey = demand.getProdID() + "_" + demand.getSeq();
			if (!htQohs.ContainsKey(hashKey))
			{
				decimal qoh = 0;
				if (core.existsInventory(demand.getProdID()))
				{
					Inventory inventory = core.readInventory(demand.getProdID());
					string[][] invent = inventory.getInvPltLocAsString();
					if (invent != null)
					{
						for (int i=0; i<invent.Length; i++)
							qoh += decimal.Parse(invent[i][6]);
					}
				}
				if (qoh > 0)
					htQohs.Add (hashKey, qoh);
			}
			loadQohFromDemand(demand.getBrother());
			loadQohFromDemand(demand.getFirstSon());
		}

		private void getHoursLTCum()
		{
			string[][] plan = core.getAllProductPlansAsString();

			int currPos = 0;
			int total = plan.Length;

			IEnumerator enu = plan.GetEnumerator();
			while (enu.MoveNext())
			{
				string[] item = (string[])enu.Current;
				htHoursLT.Add (item[0] + "_" + item[1], (decimal.Parse(item[3]) * 24) + decimal.Parse(item[7]));

				currPos ++;
				updateStatus ("Getting products info...",(int)((currPos*100) / total));
			}
		}

		private bool asignDemands(ArrayList demandsToAsign)
		{
			int currPos = 0;
			int total = demandsToAsign.Count;

			bool demandsAdded = false;
			discardedDemands.Clear();
			IEnumerator enu = demandsToAsign.GetEnumerator();
			while (enu.MoveNext())
			{
				DemandFG demand = (DemandFG)enu.Current;
				bool thisDemandAdded = asignDemand (demand);

				IEnumerator enuMachines = usedMachines.GetEnumerator();
				while (enuMachines.MoveNext())
				{
					MachineNode macNode = (MachineNode)enuMachines.Current;
					if (thisDemandAdded)
						macNode.commit();
					else
						macNode.unDo();
				}
				usedMachines.Clear();

				if (!thisDemandAdded)
				{
					discardedDemands.Add (demand);
					demand.resetDatesFromRoot();
				}
                
				demandsAdded = demandsAdded || thisDemandAdded;

				currPos++;
				updateStatus ("Scheduling demands...",(int)((currPos*100) / total));
			}
			return demandsAdded;
		}

		private bool asignDemand (IDemand demand)
		{
			bool found = false;
			if (htHoursLT.ContainsKey(demand.getProdID() + "_" + demand.getSeq()))
			{
				decimal hours = (decimal)htHoursLT[demand.getProdID() + "_" + demand.getSeq()];
				demand.setHoursLT(hours);
			}
			IEnumerator enu = demand.getMachinesEnumerator();
			while (!found && enu.MoveNext())
			{
				PrioritizedMachine priMachine = (PrioritizedMachine)enu.Current;

				if (priMachine.getPriority() < 99)
				{
					found = priMachine.getMachine().insertDemandFromDeadline (demand);
					if (found && !usedMachines.Contains(priMachine.getMachine()))
						usedMachines.Add (priMachine.getMachine());
				}
				else
				{
					ArrayList newMachineList = new ArrayList();
					do 
					{
						((PrioritizedMachine)enu.Current).setDateLimit(demand.getGoalFinishDate());
						newMachineList.Add (enu.Current); 
					} while (enu.MoveNext());

					newMachineList.Sort();
					enu = newMachineList.GetEnumerator();
					while (!found && enu.MoveNext())
					{
						priMachine = (PrioritizedMachine)enu.Current;

						found = priMachine.getMachine().insertDemandFromDeadline (demand);
						if (found && !usedMachines.Contains(priMachine.getMachine()))
							usedMachines.Add (priMachine.getMachine());
					}
				}
			}

			if (!found)
				return false;
			else
			{
				IDemand newDemand = demand.getFirstSon();
				bool inserted = true;
				while (inserted && (newDemand != null))
				{
					if (newDemand.getQty() > 0)
						inserted = inserted && asignDemand (newDemand);
					newDemand = newDemand.getBrother();
				}
				return inserted;
			}
		}

		private bool asignQohs ()
		{
			bool changes = false;
			if (asignQohToPastDue)
			{
				updateStatus ("Assigning qoh to past due demands...",0);
				asignQohToPastDueDemands(ref pastDueDemands);
			}

			updateStatus ("Assigning qoh to tasks...",0);
			changes = asignQohsToLevel (1) || changes;

			if (changes)
				removeTasksFromDemand();

			return changes;
		}

		private bool asignQohsToLevel (int level)
		{
			ArrayList tasks = getFistLevelsTaks(level);
			if (tasks.Count <= 0)
				return false;

			bool changes = false;

			while (tasks.Count > 0)
			{
				int firstTaskPos = 0;
				
				for (int i = 1; i < tasks.Count; i++)
					if (((TaskNode)tasks[firstTaskPos]).CompareTo(tasks[i]) > 0)
						firstTaskPos = i;

				TaskNode taskNode = (TaskNode)tasks[firstTaskPos];
				tasks.RemoveAt (firstTaskPos);
				TaskNode auxTask = getNextTaskLevel(taskNode,level);
				if (auxTask != null)
					tasks.Add (auxTask);

				decimal qoh = 0;
				if (htQohs.ContainsKey(taskNode.getProdId() + "_" + taskNode.getSeq()))
					qoh = (decimal)htQohs[taskNode.getProdId() + "_" + taskNode.getSeq()];

				decimal qty = taskNode.getDemand().getQty();
				decimal asignation = Math.Min (qoh, qty);
				if (asignation > 0)
				{
					changes = true;

					taskNode.getDemand().setAssignedQoh(taskNode.getDemand().getAssignedQoh() + asignation);

					if ((qoh - asignation) == 0)
						htQohs.Remove (taskNode.getProdId() + "_" + taskNode.getSeq());
					else
						htQohs[taskNode.getProdId() + "_" + taskNode.getSeq()] = qoh - asignation;
				}
			}

			changes = asignQohsToLevel (level + 1) || changes;
			return changes;
		}

		private ArrayList getFistLevelsTaks(int level)
		{
			ArrayList tasks = new ArrayList();
			IEnumerator enuMac = htMachines.Values.GetEnumerator();
			while (enuMac.MoveNext())
			{
				TaskNode task = ((MachineNode)enuMac.Current).getFirstTask();
				if ((task != null) && (!task.getIsFromDemand() || (task.getDemand().getLevel() != level)))
					task = getNextTaskLevel (task, level);
				if (task != null)
					tasks.Add (task);
			}
			return tasks;
		}

		private TaskNode getNextTaskLevel (TaskNode taskNode, int level)
		{
			TaskNode node = (TaskNode)taskNode.getNext();
			while ((node != null) && (!node.getIsFromDemand() || (node.getDemand().getLevel() != level)))
				node = (TaskNode)node.getNext();
			return node;
		}

		private bool asignQohToPastDueDemands(ref ArrayList demandsToAsignQoh)
		{
			asignQohToPastDue = false;
			bool asignation = false;
			ArrayList evaluatedDemands = new ArrayList();
			ArrayList nextDemandsToAsignQoh = new ArrayList();
			int i=0;
			while (i < demandsToAsignQoh.Count)
			{
				IDemand demand = (IDemand)demandsToAsignQoh[i];
				if (!htQohs.ContainsKey(demand.getProdID() + "_" + demand.getSeq()))
				{
					demandsToAsignQoh.RemoveAt (i);
					evaluatedDemands.Add (demand);
					addSons (demand, nextDemandsToAsignQoh);
				}
				else
					i++;
			}

			while (demandsToAsignQoh.Count > 0)
			{
				string prodID = ((IDemand)demandsToAsignQoh[0]).getProdID();
				string seq = ((IDemand)demandsToAsignQoh[0]).getSeq();
				decimal currentQoh = 0;
				if (htQohs.ContainsKey(prodID + "_" + seq))
					currentQoh = (decimal)htQohs[prodID + "_" + seq];
				ArrayList currentDemands = getDemandsOfProductSeq (prodID, seq, demandsToAsignQoh);

				i = 0;
				while ((i < currentDemands.Count) && (currentQoh > 0))
				{
					IDemand demand = (IDemand)currentDemands[i];
					decimal qty = demand.getQty();
					if (qty <= currentQoh)
					{
						demand.setAssignedQoh (demand.getAssignedQoh() + qty);
						currentQoh -= qty;
						asignation = true;
						evaluatedDemands.Add (demand);
						currentDemands.RemoveAt(i);
					}
					else
						i++;
				}
				if ((currentQoh > 0) && (currentDemands.Count > 0))
				{
					IDemand demand = (IDemand)currentDemands[currentDemands.Count - 1];
					demand.setAssignedQoh (demand.getAssignedQoh() + currentQoh);
					currentQoh = 0;
					asignation = true;
				}
				IEnumerator enuDemands = currentDemands.GetEnumerator();
				while (enuDemands.MoveNext())
				{
					evaluatedDemands.Add (enuDemands.Current);
					addSons ((IDemand)enuDemands.Current, nextDemandsToAsignQoh);
				}

				if (currentQoh > 0)
					htQohs[prodID + "_" + seq] = currentQoh;
				else
					htQohs.Remove(prodID + "_" + seq);
			}

			if (nextDemandsToAsignQoh.Count > 0)
				asignation = asignQohToPastDueDemands (ref nextDemandsToAsignQoh) || asignation;
			demandsToAsignQoh = evaluatedDemands;

			return asignation;
		}

		private ArrayList getDemandsOfProductSeq (string prodID, string seq, ArrayList demandsArray)
		{
			ArrayList newArray = new ArrayList();
			int i = 0;
			while (i < demandsArray.Count)
			{
				IDemand demand = (IDemand)demandsArray[i];
				if ((demand.getProdID().Equals(prodID)) && (demand.getSeq().Equals(seq)))
				{
					int j = 0;
					while ((j < newArray.Count) && (demand.getQty() < ((IDemand)newArray[j]).getQty()))
						j++;
					newArray.Insert(j, demand);
					demandsArray.RemoveAt (i);
				}
				else
					i++;
			}
			return newArray;
		}

		private void addSons (IDemand demand, ArrayList newArray)
		{
			IDemand newDemand = demand.getFirstSon();
			while (newDemand != null)
			{
				newArray.Add (newDemand);
				newDemand = newDemand.getBrother();
			}
		}


		private void removeTasksFromDemand()
		{
			IEnumerator enuMac = htMachines.Values.GetEnumerator();
			while (enuMac.MoveNext())
				((MachineNode)enuMac.Current).removeTasksFromDemand();
		}

		private void asignDiscardedDemands(ArrayList demandsToAssign)
		{
			IEnumerator enuDemands = demandsToAssign.GetEnumerator();
			while (enuDemands.MoveNext())
			{
				DemandFG demand = (DemandFG)enuDemands.Current;
				bool thisDemandAdded = asignDiscardedDemand(demand);

				IEnumerator enuMachines = usedMachines.GetEnumerator();
				while (enuMachines.MoveNext())
				{
					MachineNode macNode = (MachineNode)enuMachines.Current;
					if (thisDemandAdded)
						macNode.commit();
					else
						macNode.unDo();
				}
				usedMachines.Clear();

				if (!thisDemandAdded)
				{
					discardedDemands.Add (demand);
					demand.resetDatesFromRoot();
				}
			}
		}

		private bool asignDiscardedDemand(IDemand demand)
		{
			IDemand sonDem = demand.getFirstSon();
			bool inserted = true;
			while (sonDem != null)
			{
				inserted = inserted && asignDiscardedDemand (sonDem);
				sonDem = sonDem.getBrother();
			}

			if (!inserted)
				return false;

			if (htHoursLT.ContainsKey(demand.getProdID() + "_" + demand.getSeq()))
			{
				decimal hours = (decimal)htHoursLT[demand.getProdID() + "_" + demand.getSeq()];
				demand.setHoursLT(hours);
			}

			bool found = false;
			IEnumerator enu = demand.getMachinesEnumerator();
			while (!found && enu.MoveNext())
			{
				PrioritizedMachine priMachine = (PrioritizedMachine)enu.Current;

				if (priMachine.getPriority() < 99)
				{
					found = priMachine.getMachine().insertDemandFromStartPoint (demand);
					if (found && !usedMachines.Contains(priMachine.getMachine()))
						usedMachines.Add (priMachine.getMachine());
				}
				else
				{
					ArrayList newMachineList = new ArrayList();
					do 
					{
						PrioritizedMachine lastMachine = (PrioritizedMachine)enu.Current;
						int i=0;
						while ((i < newMachineList.Count) && (insertMachineAfter(lastMachine,(PrioritizedMachine)newMachineList[i],demand.getMinimumStartDate())))
							i++;
						newMachineList.Insert (i, lastMachine);
					} while (enu.MoveNext());

					enu = newMachineList.GetEnumerator();
					while (!found && enu.MoveNext())
					{
						priMachine = (PrioritizedMachine)enu.Current;

						found = priMachine.getMachine().insertDemandFromStartPoint (demand);
						if (found && !usedMachines.Contains(priMachine.getMachine()))
							usedMachines.Add (priMachine.getMachine());
					}
				}
			}
			return found;
		}

		private bool insertMachineAfter (PrioritizedMachine machineToInsert, PrioritizedMachine currentMachine, DateTime minimumDate)
		{
			CapacityNode capNodeMTI = machineToInsert.getMachine().getFirstFreeCapacity(minimumDate);
			while ((capNodeMTI != null) && ((capNodeMTI.getEndDate().CompareTo(minimumDate) <= 0) || (capNodeMTI.getUtilPer() <= 0)))
				capNodeMTI = (CapacityNode)capNodeMTI.getNext();
			CapacityNode capNodeCM = currentMachine.getMachine().getFirstFreeCapacity(minimumDate);
			while ((capNodeCM != null) && ((capNodeCM.getEndDate().CompareTo(minimumDate) <= 0) || (capNodeCM.getUtilPer() <= 0)))
				capNodeCM = (CapacityNode)capNodeCM.getNext();

			if (capNodeMTI == null)
				return true;

			if (capNodeCM == null)
				return false;

			if (capNodeMTI.getStartDate().Equals(minimumDate))
			{
				if (capNodeCM.getStartDate().Equals(minimumDate))
					return (capNodeMTI.getEndDate().CompareTo(capNodeCM.getEndDate()) < 0);
				else
					return false;
			}
			if (capNodeCM.getStartDate().Equals(minimumDate))
				return true;

			if (capNodeMTI.getStartDate().CompareTo(minimumDate) < 0)
			{
				if (capNodeCM.getStartDate().CompareTo(minimumDate) < 0)
					return (capNodeMTI.getEndDate().CompareTo(capNodeCM.getEndDate()) < 0);
				else
					return false;
			}
			if (capNodeCM.getStartDate().CompareTo(minimumDate) < 0)
				return true;

			return (capNodeMTI.getStartDate().CompareTo(capNodeCM.getStartDate()) > 0);
		}

		public Schedule getSchedule()
		{
			return schedule;
		}

		public ArrayList getTasksAddedFromDemandAsString()
		{
			ArrayList vec = new ArrayList();
			IEnumerator enuMachines = htMachines.Values.GetEnumerator();
			while (enuMachines.MoveNext())
			{
				MachineNode macNode = (MachineNode)enuMachines.Current;
				IEnumerator enuTasksLists = macNode.getTasksEnumerator();
				while (enuTasksLists.MoveNext())
				{
					IEnumerator enuTasks = ((SortedList)enuTasksLists.Current).Values.GetEnumerator();
					while (enuTasks.MoveNext())
					{
						TaskNode taskNode = (TaskNode)enuTasks.Current;

						object[] item = new object [16];

						item[0] = taskNode.getMachineNode().getMachine().getMach();
						item[1] = taskNode.getIsFamilyPart() ? "Family" : "Part";
						item[2] = taskNode.getProdId();
						item[3] = taskNode.getSeq();
						item[4] = taskNode.getQty();
						item[5] = taskNode.getPos();
						item[6] = taskNode.getProdHours();
						item[7] = DateUtil.getCompleteDateRepresentation(taskNode.getStartDate(), DateUtil.MMDDYYYY);
						item[8] = DateUtil.getCompleteDateRepresentation(taskNode.getEndDate(), DateUtil.MMDDYYYY);
						item[9] = taskNode.getShift();
						item[10] = taskNode.getUtilPer();
						item[11] = taskNode.getTmType();
						if (taskNode.getIsFromDemand())
						{
							item[12] = taskNode.getDemand().getOrderID();
							item[13] = taskNode.getDemand().getItemID();
							item[14] = taskNode.getDemand().getReleaseID();
						}
						else
						{
							item[12] = 0;
							item[13] = 0;
							item[14] = "";
						}
						item[15] = taskNode.getDemand().getDepartment();

						vec.Add (item);
					}
				}
			}
			return vec;
		}

		public SchQohAssignation getSchQohAssigations()
		{
			SchQohAssignation schQohAssignation = core.createSchQohAssignation();
			schQohAssignation.setPlant(plant);
			schQohAssignation.setDepartament("54");
			schQohAssignation.setSchVersion(version);
			IEnumerator enu = demands.GetEnumerator();
			while (enu.MoveNext())
				getSchQohAssigations((IDemand)enu.Current, schQohAssignation);

			return schQohAssignation;
		}

		private void getSchQohAssigations(IDemand demand, SchQohAssignation schQohAssignation)
		{
			if (demand != null)
			{
				schQohAssignation.setQohAssignation (demand.getProdID(), int.Parse(demand.getSeq()), demand.getOrderID(), demand.getItemID(), demand.getReleaseID(), demand.getAssignedQoh());
				getSchQohAssigations (demand.getBrother(), schQohAssignation);
				getSchQohAssigations (demand.getFirstSon(), schQohAssignation);
			}
		}

		public string[] getDemandInfo (decimal orderID, decimal itemID, string releaseID)
		{
			IDemand demand = (IDemand)htAllDemands[orderID.ToString() + "_" + itemID.ToString() + "_" + releaseID];

			if (demand == null)
				return null;
			
			string[] item = new string[6];

			item[0] = demand.getProdID();
			item[1] = demand.getSeq();
			item[2] = (demand.getQty() + demand.getAssignedQoh()).ToString();
			item[3] = DateUtil.getDateRepresentation (demand.getGoalFinishDate(), DateUtil.MMDDYYYY);
			item[4] = DateUtil.getDateRepresentation (demand.getActualFinishDate(), DateUtil.MMDDYYYY);
			item[5] = demand.getCustID();

			return item;
		}

		public void setUpdatableForm (UpdatableForm form)
		{
			this.form = form;
		}

		public void updateStatus (string text, int progress)
		{
			if (form != null)
				form.updateStatus (text, progress);
		}

		public SortedList getUsedMachines()
		{
			SortedList sortedMachines = new SortedList();
			IEnumerator enuMac = htMachines.Values.GetEnumerator();
			while (enuMac.MoveNext())
			{
				if (((MachineNode)enuMac.Current).getFirstTask() == null)
					continue;
				string[] deptMac = new string[2];
				deptMac[0] = ((MachineNode)enuMac.Current).getMachine().getDept();
				deptMac[1] = ((MachineNode)enuMac.Current).getMachine().getMach();
				sortedMachines.Add (deptMac[0] + "_" + deptMac[1], deptMac);
			}
			return sortedMachines;
		}

		public CapacityNode getFirstCapacityNode (string dept, string machine)
		{
			MachineNode node = (MachineNode)htMachines[dept + "_" + machine];
			if (node != null)
				return node.getFirstOriginalCapacity();
			else
				return null;
		}

		public TaskNode getFirstTaskNode (string dept, string machine)
		{
			MachineNode node = (MachineNode)htMachines[dept + "_" + machine];
			if (node != null)
				return node.getFirstTask();
			else
				return null;
		}

		public ArrayList getProductsTasks (string dept, string machine)
		{
			ArrayList prodLists = new ArrayList();

			Hashtable productsIndex = new Hashtable();
			MachineNode node = (MachineNode)htMachines[dept + "_" + machine];
			if (node == null)
				return prodLists; 
			TaskNode taskNode = node.getFirstTask();
			while (taskNode != null)
			{
				int index = 0;
				if (!productsIndex.ContainsKey(taskNode.getProdId()))
				{
					index = prodLists.Add (new ArrayList());
					productsIndex.Add(taskNode.getProdId(), index);
				}
				else
					index = (int)productsIndex[taskNode.getProdId()];

				((ArrayList)prodLists[index]).Add (taskNode);

				taskNode = (TaskNode)taskNode.getNext();
			}
			return prodLists;
		}

		public string[][] getSchPrFmHrForMachine (string machineCode, string deptCode)
		{
			return schedule.getSchPrFmHrForMachine (machineCode, deptCode);
		}

		public string[] getSMOInfo (string prodID, string schVersion, string prOrd, int seq)
		{
			return schedule.getSMOInfo (prodID, schVersion, prOrd, seq);
		}

		public bool removeTask (string dept, string machine, DateTime dateStart)
		{
			MachineNode macNode = (MachineNode)htMachines[dept + "_" + machine];
			TaskNode taskNode = macNode.getLastTask(dateStart);

			if (taskNode.getStartDate().Equals(dateStart))
			{
				macNode.removeTask(taskNode);
				macNode.commit();
				return true;
			}
			else
				return false;
		}

		public void removeAllTasks ()
		{
			IEnumerator enuMac = htMachines.Values.GetEnumerator();
			while (enuMac.MoveNext())
				((MachineNode)enuMac.Current).removeAllTasks();
		}

		public DataSet getScheduleInMachineReportDataSet (string department, string machine)
		{
			DataSet ds = new DataSet();

			DataTable dt = new DataTable();
			DataRow dr;
	
			dt.TableName = "scheduleInMachine";
			dt.Columns.Add (new DataColumn("Date",typeof(string)));
			dt.Columns.Add (new DataColumn("ProdID",typeof(string)));
			dt.Columns.Add (new DataColumn("Seq",typeof(string)));
			dt.Columns.Add (new DataColumn("TimeFrom",typeof(string)));
			dt.Columns.Add (new DataColumn("TimeTo",typeof(string)));
			dt.Columns.Add (new DataColumn("Hours",typeof(double)));
			dt.Columns.Add (new DataColumn("QtyProduced",typeof(double)));
			dt.Columns.Add (new DataColumn("QtyAcumulated",typeof(double)));
			dt.Columns.Add (new DataColumn("QtyGoal",typeof(double)));

			Hashtable htProduced = new Hashtable();
			Hashtable htGoals = new Hashtable();
			MachineNode macNode = (MachineNode)htMachines[department + "_" + machine];

			TaskNode node = macNode.getFirstTask (tasksDateFrom);
			while ((node != null) && (node.getEndDate().CompareTo(tasksDateFrom) <= 0))
				node = (TaskNode)node.getNext();

			while ((node != null) && (node.getEndDate().CompareTo(tasksDateTo) <= 0))
			{
				object[] item = new object[9];
				dr = dt.NewRow();

				item[0] = DateUtil.getDateRepresentation(node.getStartDate().Date, DateUtil.MMDDYYYY);
				item[1] = node.getProdId();
				item[2] = node.getSeq();
				item[3] = node.getStartDate().Hour.ToString("00") + ":" + node.getStartDate().Minute.ToString("00");
				item[4] = node.getEndDate().Hour.ToString("00") + ":" + node.getEndDate().Minute.ToString("00");
				item[5] = node.getEndDate().Subtract(node.getStartDate()).TotalHours;
				item[6] = (double)node.getQty();

				double acum = (double)node.getQty();
				string key = node.getProdId() + "_" + node.getSeq();
				if (htProduced.ContainsKey(key))
				{
					acum += (double)htProduced[key];
					htProduced[key] = acum;
				}
				else
				{
					if (htOriginalQohs.ContainsKey(key))
						acum += (double)((decimal)htOriginalQohs[key]);
					htProduced.Add (key, acum);
				}

				item[7] = acum;

				if (htGoals.ContainsKey(key))
					item[8] = (double)htGoals[key];
				else
				{
					double goal = getGoal(node.getProdId(), node.getSeq());
					htGoals.Add (key, goal);
					item[8] = goal;
				}

				dr.ItemArray = item;
				dt.Rows.Add (dr);
				node = (TaskNode)node.getNext();
			}

			ds = new DataSet();
			ds.Tables.Add(dt);

			return ds;
		}

		private double getGoal(string prodID, string seq)
		{
			double result = 0;

			if (demands == null)
				return 0;

			IEnumerator enuDemands = demands.GetEnumerator();
			while (enuDemands.MoveNext())
				result += getGoal (prodID, seq, (IDemand)enuDemands.Current);

			return result;
		}

		private double getGoal(string prodID, string seq, IDemand demand)
		{
			double result = 0;
			if (demand != null)
			{
				result += getGoal (prodID, seq, demand.getFirstSon());
				result += getGoal (prodID, seq, demand.getBrother());
				if (demand.getProdID().Equals(prodID) && demand.getSeq().Equals(seq))
					result += (double)demand.getOriginalQty();
			}
			return result;
		}


		public bool allDemandsAdded()
		{
			return (discardedDemands.Count == 0);
		}

		public DataSet getNotScheuledDemands ()
		{
			DataSet ds = new DataSet();

			DataTable dt = new DataTable();
			DataRow dr;
	
			dt.TableName = "notScheduledDemands";
			dt.Columns.Add (new DataColumn("OrderID",typeof(string)));
			dt.Columns.Add (new DataColumn("ItemID",typeof(string)));
			dt.Columns.Add (new DataColumn("ReleaseID",typeof(string)));
			dt.Columns.Add (new DataColumn("CustomerID",typeof(string)));
			dt.Columns.Add (new DataColumn("CustomerName",typeof(string)));
			dt.Columns.Add (new DataColumn("ProdID",typeof(string)));
			dt.Columns.Add (new DataColumn("Seq",typeof(string)));
			dt.Columns.Add (new DataColumn("Qty",typeof(double)));

			IEnumerator enuDems = discardedDemands.GetEnumerator();

			while (enuDems.MoveNext())
			{
				DemandFG demand = (DemandFG)enuDems.Current;

				object[] item = new object[8];
				dr = dt.NewRow();

				item[0] = NumberUtil.toString(demand.getOrderID());
				item[1] = NumberUtil.toString(demand.getItemID());
				item[2] = demand.getReleaseID();
				item[3] = demand.getCustID();
				item[4] = "Not implemented";
				item[5] = demand.getProdID();
				item[6] = demand.getSeq();
				item[7] = (double)demand.getOriginalQty();

				dr.ItemArray = item;
				dt.Rows.Add (dr);
			}

			ds = new DataSet();
			ds.Tables.Add(dt);

			return ds;
		}

	}
}
