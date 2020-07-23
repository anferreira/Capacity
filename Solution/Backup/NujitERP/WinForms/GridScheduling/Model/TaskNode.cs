using System;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.Model
{

	public class TaskNode: DateListNode, IComparable
	{
		private MachineNode machineNode;
		private bool isFamilyPart;
		private string prodId;
		private string seq;
		private decimal qty;
		private decimal pos;
		private decimal prodHours;
		private DateTime startDate;
		private DateTime endDate;
		private string shift;
		private decimal utilPer;
		private string tmType;
		private bool isFromDemand;
		private IDemand demand;

		public TaskNode()
		{
			machineNode = null;
			isFamilyPart = false;
			prodId = "";
			seq = "";
			qty = 0M;
			pos = 0M;
			prodHours = 0M;
			startDate = DateUtil.MinValue;
			endDate = DateUtil.MinValue;
			shift = "";
			utilPer = 0M;
			tmType = "";
			isFromDemand = false;
			demand = null;
		}

		public TaskNode(string[] vec, CoreFactory core)
		{
			machineNode = null;
			isFamilyPart = core.isFamilyPart(vec[2]);
			prodId = vec[2];
			seq = vec[4];
			qty = decimal.Parse(vec[6]);
			pos = decimal.Parse(vec[24]);
			prodHours = decimal.Parse(vec[15]);
			startDate = DateUtil.parseCompleteDate(vec[13],DateUtil.MMDDYYYY);
			endDate = DateUtil.parseCompleteDate(vec[14],DateUtil.MMDDYYYY);
			shift = vec[25];
			utilPer = decimal.Parse(vec[26]);
			tmType = vec[27];
		}

		public MachineNode getMachineNode(){
			return machineNode;
		}

		public bool getIsFamilyPart(){
			return isFamilyPart;
		}

		public string getProdId(){
			return prodId;
		}

		public string getSeq(){
			return seq;
		}

		public decimal getQty(){
			return qty;
		}

		public decimal getPos(){
			return pos;
		}

		public decimal getProdHours(){
			return prodHours;
		}

		public DateTime getStartDate(){
			return startDate;
		}

		public DateTime getEndDate(){
			return endDate;
		}

		public string getShift(){
			return shift;
		}

		public decimal getUtilPer(){
			return utilPer;
		}

		public string getTmType(){
			return tmType;
		}

		public void setMachineNode(MachineNode node)
		{
			this.machineNode = node;
		}

		public void setIsFamilyPart(bool isFamilyPart){
			this.isFamilyPart = isFamilyPart;
		}

		public void setProdId(string prodId){
			this.prodId = prodId;
		}

		public void setSeq(string seq){
			this.seq = seq;
		}

		public void setQty(decimal qty){
			this.qty = qty;
		}

		public void setPos(decimal pos){
			this.pos = pos;
		}

		public void setProdHours(decimal prodHours){
			this.prodHours = prodHours;
		}

		public void setStartDate(DateTime startDate){
			this.startDate = startDate;
		}

		public void setEndDate(DateTime endDate){
			this.endDate = endDate;
		}

		public void setShift(string shift){
			this.shift = shift;
		}

		public void setUtilPer(decimal utilPer){
			this.utilPer = utilPer;
		}

		public void setTmType(string tmType){
			this.tmType = tmType;
		}

		public bool getIsFromDemand()
		{
			return isFromDemand;
		}

		public void makeFromDemand()
		{
			isFromDemand = true;
		}

		public override DateTime getDate()
		{
			return getStartDate();
		}

		public void setDemand(IDemand demand)
		{
			if ((this.demand == null) || !this.demand.Equals(demand))
			{
				if (this.demand != null)
					this.demand.removeTask(this);
				this.demand = demand;
				if (demand != null)
					demand.addTask (this);
			}
		}

		public IDemand getDemand()
		{
			return demand;
		}

		public override bool Equals(object obj)
		{
			try 
			{
				return ((startDate.Equals(((TaskNode)obj).getStartDate())) && (endDate.Equals(((TaskNode)obj).getEndDate()))  && machineNode.Equals(((TaskNode)obj).getMachineNode()));
			} 
			catch 
			{
				return false;
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
				TaskNode node = (TaskNode)obj;
				int result = this.getStartDate().CompareTo(node.getStartDate());
				if (result == 0)
					result = this.getEndDate().CompareTo(node.getEndDate());
				return result;
			}
			catch
			{
				return -1;
			}
		}

	}
}
