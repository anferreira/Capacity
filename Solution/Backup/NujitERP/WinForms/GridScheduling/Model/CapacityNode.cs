using System;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.Model
{
	public class CapacityNode: DateListNode
	{
		private int wk;
		private DateTime dt;
		private string sh;
		private string tmType;
		private int tmBlkOrd;
		private string tmStart;
		private string tmEnd;
		private decimal hr;
		private decimal hrPr;
		private DateTime dtShf;
		private string tmTypeePr;
		private string shfCod;
		private decimal utilPer;
		private decimal hrClm;
		private decimal hrPrClm;
		private string capType;
		
		public CapacityNode()
		{
			wk = 0;
			dt = DateUtil.MinValue;
			sh = "";
			tmType = "";
			tmBlkOrd = 0;
			tmStart = "";
			tmEnd = "";
			hr = 0M;
			hrPr = 0M;
			dtShf = DateUtil.MinValue;
			tmTypeePr = "";
			shfCod = "";
			utilPer = 0M;
			hrClm = 0M;
			hrPrClm = 0M;
			capType = "";
		}
		
		public CapacityNode(string[] vec)
		{
			wk = int.Parse(vec[0]);
			dt = DateUtil.parseDate(vec[1],DateUtil.MMDDYYYY);
			sh = vec[2];
			tmType = vec[3];
			tmBlkOrd = int.Parse(vec[4]);
			tmStart = vec[5];
			tmEnd = vec[6];
			hr = decimal.Parse(vec[7]);
			hrPr = decimal.Parse(vec[8]);
			dtShf = DateUtil.parseDate(vec[9],DateUtil.MMDDYYYY);
			tmTypeePr = vec[10];
			shfCod = vec[11];
			utilPer = decimal.Parse(vec[12]);
			hrClm = decimal.Parse(vec[13]);
			hrPrClm = decimal.Parse(vec[14]);
			capType = vec[15];
		}

		public int getWk() {
			return wk;
		}

		public DateTime getDt() {
			return dt;
		}

		public string getSh() {
			return sh;
		}

		public string getTmType() {
			return tmType;
		}

		public int getTmBlkOrd() {
			return tmBlkOrd;
		}

		public string getTmStart() {
			return tmStart;
		}

		public string getTmEnd() {
			return tmEnd;
		}

		public decimal getHr() {
			return hr;
		}

		public decimal getHrPr() {
			return hrPr;
		}

		public DateTime getDtShf() {
			return dtShf;
		}

		public string getTmTypeePr() {
			return tmTypeePr;
		}

		public string getShfCod() {
			return shfCod;
		}

		public decimal getUtilPer() {
			return utilPer;
		}

		public decimal getHrClm() {
			return hrClm;
		}

		public decimal getHrPrClm() {
			return hrPrClm;
		}

		public string getCapType() {
			return capType;
		}

		public void setWk(int wk)
		{
			this.wk = wk;
		}

		public void setDt(DateTime dt){
			this.dt = dt;
		}

		public void setSh(string sh){
			this.sh = sh;
		}

		public void setTmType(string tmType){
			this.tmType = tmType;
		}

		public void setTmBlkOrd(int tmBlkOrd){
			this.tmBlkOrd = tmBlkOrd;
		}

		public void setTmStart(string tmStart){
			this.tmStart = tmStart;
			updateHours();
		}

		public void setTmEnd(string tmEnd){
			this.tmEnd = tmEnd;
			updateHours();
		}

		private void updateHours()
		{
			decimal hoursStart = decimal.Parse(tmStart.Substring(0,2)) + (decimal.Parse(tmStart.Substring(3,2)) / 60);
			decimal hoursEnd = decimal.Parse(tmEnd.Substring(0,2)) + (decimal.Parse(tmEnd.Substring(3,2)) / 60);
			hr = hoursEnd - hoursStart;
			hrPr = hr * (utilPer / 100);
		}

		public void setDtShf(DateTime dtShf){
			this.dtShf = dtShf;
		}

		public void setTmTypeePr(string tmTypeePr){
			this.tmTypeePr = tmTypeePr;
		}

		public void setShfCod(string shfCod){
			this.shfCod = shfCod;
		}

		public void setUtilPer(decimal utilPer){
			this.utilPer = utilPer;
		}

		public void setHrClm(decimal hrClm){
			this.hrClm = hrClm;
		}

		public void setHrPrClm(decimal hrPrClm){
			this.hrPrClm = hrPrClm;
		}

		public void setCapType(string capType){
			this.capType = capType;
		}

		public override DateTime getDate()
		{
			return getStartDate();
		}
	
		public DateTime getStartDate()
		{
			return new DateTime (dt.Year, dt.Month, dt.Day, int.Parse(tmStart.Substring(0,2)), int.Parse(tmStart.Substring(3,2)), 0);
		}
	
		public DateTime getEndDate()
		{
			return new DateTime (dt.Year, dt.Month, dt.Day, int.Parse(tmEnd.Substring(0,2)), int.Parse(tmEnd.Substring(3,2)), 0);
		}
	
		public override bool Equals(object obj)
		{
			try {
				return ((dt.Equals(((CapacityNode)obj).getDt())) && (tmStart.Equals(((CapacityNode)obj).getTmStart())) && (tmEnd.Equals(((CapacityNode)obj).getTmEnd())));
			} catch {
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		public CapacityNode clone()
		{
			CapacityNode node = new CapacityNode();

			node.wk = this.wk;
			node.dt = new DateTime(this.dt.Year, this.dt.Month, this.dt.Day, this.dt.Hour, this.dt.Minute, this.dt.Second, this.dt.Millisecond);
			node.sh = this.sh;
			node.tmType = this.tmType;
			node.tmBlkOrd = this.tmBlkOrd;
			node.tmStart = this.tmStart;
			node.tmEnd = this.tmEnd;
			node.hr = this.hr;
			node.hrPr = this.hrPr;
			node.dtShf = new DateTime(this.dtShf.Year, this.dtShf.Month, this.dtShf.Day, this.dtShf.Hour, this.dtShf.Minute, this.dtShf.Second, this.dtShf.Millisecond);
			node.tmTypeePr = this.tmTypeePr;
			node.shfCod = this.shfCod;
			node.utilPer = this.utilPer;
			node.hrClm = this.hrClm;
			node.hrPrClm = this.hrPrClm;
			node.capType = this.capType;

			return node;
		}
	
	}


}
