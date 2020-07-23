using System;
using System.Collections;


namespace Nujit.NujitERP.ClassLib.Core{

public 
class Bom{

private BomContainer bomContainer;
private int level;
private bool purchased;
private string prod;
private string act;
private int seq;
private decimal qty;
private string dept;
private string cfg;
private decimal prodRate;
private ArrayList prefList;

public 
Bom(BomContainer bomContainer, int level, bool purchased, string prod, string act, 
		int seq, decimal qty, string dept, string cfg, decimal prodRate){
	this.bomContainer = bomContainer;
	this.level = level;
	this.purchased = purchased;
	this.prod = prod;
	this.act = act;
	this.seq = seq;
	this.qty = qty;
	this.dept = dept;
	this.cfg = cfg;
	this.prodRate = prodRate;
	this.prefList = new ArrayList();
}

public
BomContainer getBomContainer(){
	return bomContainer;
}

public
void setBomContainer(BomContainer bomContainer){
	this.bomContainer = bomContainer;
}

public
void addToBomContainer(Bom bom){
	this.bomContainer.Add(bom);
}

public
int getLevel(){
	return level;
}

public
bool isPurchased(){
	return purchased;
}

public
string getProd(){
	return prod;
}

public
string getAct(){
	return act;
}

public
int getSeq(){
	return seq;
}

public
decimal getQty(){
	return qty;
}

public
string getDepartament(){
	return dept;
}

public
string getCfg(){
	return cfg;
}

public
decimal getProdRate(){
	return prodRate;
}

public
void seeBom(Bom bom, string parent){
	BomContainer bomContainer = bom.getBomContainer();
	for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		Bom bomAux = (Bom) en.Current;
		seeBom(bomAux, bom.getProd());
	}
}

private
int getSize(Bom bom, int size){
	size += bom.bomContainer.Count;
	
	BomContainer bomContainer = bom.getBomContainer();
	for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		Bom bomAux = (Bom) en.Current;
		
		size = getSize(bomAux, size);
	}

//	size++;
	return size;
}

private
string[][] toArray(Bom bom, string[][] defVec, int init){
	BomContainer bomContainer = bom.getBomContainer();

	for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		Bom bomAux = (Bom) en.Current;
		
		string[] lineN = new string[4];
		lineN[0] = bomAux.level.ToString();
		lineN[1] = bomAux.prod;
		lineN[2] = bomAux.seq.ToString();
		lineN[3] = decimal.Round(bomAux.qty, 3).ToString();
		defVec[init] = lineN;
		init++;
	}

	for(IEnumerator en = bomContainer.GetEnumerator(); en.MoveNext(); ){
		Bom bomAux = (Bom) en.Current;
		defVec = toArray(bomAux, defVec, init);
	}

	return defVec;
}

public
string[][] toArray(){
	string[][] v = new string[getSize(this, 0)][];
	v = toArray(this, v, 0);
	return v;
}

public void addPreference (string machine, int pref)
{
	int i = 0;
	while ((i < prefList.Count) && (((Preference)prefList[i]).getPreference() < pref))
		i ++;
	prefList.Insert (i, new Preference(dept, machine, pref));
}

public IEnumerator getSortedMachinePreferences()
{
	return prefList.GetEnumerator();
}


public
int Level {
	get { return level;}
	set { if (this.level != value){
			this.level = value;			
		}
	}
}

public
bool Purchased {
	get { return purchased;}
	set { if (this.purchased != value){
			this.purchased = value;		
		}
	}
}

public
string Prod {
	get { return prod;}
	set { if (this.prod != value){
			this.prod = value;
		}
	}
}

public
string Act {
	get { return act;}
	set { if (this.act != value){
			this.act = value;
		}
	}
}

public
int Seq {
	get { return seq;}
	set { if (this.seq != value){
			this.seq = value;
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Qty {
	get { return qty;}
	set { if (this.qty != value){
			this.qty = value;			
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Dept {
	get { return dept;}
	set { if (this.dept != value){
			this.dept = value;			
		}
	}
}

public
string Cfg {
	get { return cfg;}
	set { if (this.cfg != value){
			this.cfg = value;			
		}
	}
}

public
decimal ProdRate {
	get { return prodRate;}
	set { if (this.prodRate != value){
			this.prodRate = value;			
		}
	}
}


public
void getMaxLevel(Bom bomAux,ref int imax){
                
    foreach (Bom b in bomAux.getBomContainer()){    
        if (b.Level > imax)
            imax = b.Level;

        if (b.getBomContainer().Count > 0)
             getMaxLevel(b,ref imax);
    }       
}


public
void getFromLevel(Bom bomAux, int ilevel,BomContainer bomCurrLevel){
    
    foreach (Bom b in bomAux.getBomContainer()){    
        if (b.Level  == ilevel)
            bomCurrLevel.Add(b);            

        if (b.getBomContainer().Count > 0)
             getFromLevel(b,ilevel, bomCurrLevel);
    }       
}

private class Preference
{
private string dept;
private string machine;
private int pref;

public Preference()
{
	dept = "";
	machine = "";
	pref = 0;
}

public Preference(string dept, string machine, int preference)
{
	this.dept = dept;
	this.machine = machine;
	this.pref = preference;
}

public string getDept()
{
	return dept;
}

public string getMachine() 
{
	return machine;
}

public int getPreference()
{
	return pref;
}

public override string ToString()
{
	return dept + "_" + machine;
}


} // Preference Class

} // class

} // namespace
