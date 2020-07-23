using System;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class HotListHour{

private string configuration;
private Hashtable days; 
	// vector of double[61][3]
	// 61 = days from past due to day 60, pos 0 = past due, pos 1 = day 1 (today), pos 2 = day 2
	// pos 0 of 61 = demand
	// pos 1 of 61 = capacity
	// pos 2 of 61 = remaining = demand - capacity, if remaining is greater than 0 -> becomes 0

private int MAX_DAYS = 91;

public const int FOR_DAYS = 0;

private const int DEMAND = 0;
private const int CAPACITY = 1;
private const int REMAINING = 2;

public 
HotListHour(string configuration, int constant){
	this.configuration = configuration;

	days = new Hashtable();
	if (constant == FOR_DAYS){
		for(int i = 0; i < MAX_DAYS; i++){
			decimal[] v = new decimal[3];
			v[0] = 0;
			v[1] = 0;
			v[2] = 0;
			days.Add(i.ToString(), v);
		}
	}
}

private
void addHourDemand(decimal demand, string key){
	decimal[] v = null;
	
	if (days.ContainsKey(key)){
		v = (decimal[])days[key];
	}else{
		v = new decimal[3];
		v[0] = 0;
		v[1] = 0;
		v[2] = 0;
		
		days.Add(key, v);
	}

	v[DEMAND] += demand;
	v[REMAINING] = v[DEMAND] + v[CAPACITY];

	if (v[REMAINING] > 0)
		v[REMAINING] = 0;
}

private
void addHourCapacity(decimal capacity, string key){
	decimal[] v = null;
	
	if (days.ContainsKey(key)){
		v = (decimal[])days[key];
	}else{
		v = new decimal[3];
		v[0] = 0;
		v[1] = 0;
		v[2] = 0;
		
		days.Add(key, v);
	}

	v[CAPACITY] += capacity;
	v[REMAINING] = v[DEMAND] + v[CAPACITY];

	if (v[REMAINING] > 0)
		v[REMAINING] = 0;
}

public 
void addHourDemand(decimal demand, int day){
	addHourDemand(demand, day.ToString());
}

public 
void addHourDemand(decimal demand, DateTime date, string shift){
	string key = "";
	if (!date.Equals(DateTime.MinValue))
		key = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + shift;
	else
		key = "PastDue" + shift;
	addHourDemand(demand, key);
}

public 
void addHourCapacity(decimal capacity, int day){
	addHourCapacity(capacity, day.ToString());
}

public 
void addHourCapacity(decimal capacity, DateTime date, string shift){
	string key = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + shift;
	addHourCapacity(capacity, key);
}

public 
decimal getHourDemand(int day){
	decimal[] v = null;
	if (days.ContainsKey(day.ToString())){
		v = (decimal[])days[day.ToString()];
	}else{
		return 0;
	}
	return v[DEMAND];
}

public 
decimal getHourCapacity(int day){
	decimal[] v = null;
	if (days.ContainsKey(day.ToString())){
		v = (decimal[])days[day.ToString()];
	}else{
		return 0;
	}
	return v[CAPACITY];
}

public 
decimal getHourRemaining(int day){
	decimal[] v = null;
	if (days.ContainsKey(day.ToString())){
		v = (decimal[])days[day.ToString()];
	}else{
		return 0;
	}
	
	decimal rem = v[DEMAND] + v[CAPACITY];
	if (rem < 0)
		return rem;
	else
		return 0;
}

public
string getConfiguration(){
	return configuration;
}

public
void setConfiguration(string configuration){
	this.configuration = configuration;
}

public
void optimizeDays(){
	for(int day = MAX_DAYS - 1; day > 0 ; day--){
		decimal[] v;
		if (days.ContainsKey(day.ToString())){
			v = (decimal[])days[day.ToString()];
		}else{
			v = new decimal[3];
			v[0] = 0;
			v[1] = 0;
			v[2] = 0;
		}
		
		decimal demand = v[DEMAND] * -1;
		if (demand > v[CAPACITY]){
			v[DEMAND] = v[CAPACITY] * -1;
			demand -= v[CAPACITY];

			int dayAnt = day - 1;
			string keyAnt = dayAnt.ToString();
			decimal[] vAnt;
			if (days.ContainsKey(keyAnt)){
				vAnt = (decimal[])days[keyAnt];
			}else{
				vAnt = new decimal[3];
				vAnt[0] = 0;
				vAnt[1] = 0;
				vAnt[2] = 0;
				days.Add(keyAnt, vAnt);
			}
			vAnt[DEMAND] += demand * -1;
		}
	}
}

public
decimal[] getDemandDays(){
	decimal[] demand = new decimal[days.Count];
	int x = 0;

	try{
	for(x = 0; x < days.Count; x++){
		decimal[] v = (decimal[])days[x.ToString()];
		demand[x] = v[DEMAND];
	}
	}catch(System.Exception lll){
		System.Console.WriteLine("k : " + lll.Message) ;
	}

	return demand;
}

public
decimal[] getCapacityDays(){
	decimal[] capacity = new decimal[days.Count];
	for(int x = 0; x < days.Count; x++){
		decimal[] v = (decimal[])days[x.ToString()];
		capacity[x] = v[CAPACITY];
	}

	return capacity;
}

} // class

} // namespace
