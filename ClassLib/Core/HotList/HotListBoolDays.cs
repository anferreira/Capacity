/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class HotListBoolDays : BusinessObject {

protected bool bpastDue;
protected bool bday001;
protected bool bday002;
protected bool bday003;
protected bool bday004;
protected bool bday005;
protected bool bday006;
protected bool bday007;
protected bool bday008;
protected bool bday009;
protected bool bday010;
protected bool bday011;
protected bool bday012;
protected bool bday013;
protected bool bday014;
protected bool bday015;
protected bool bday016;
protected bool bday017;
protected bool bday018;
protected bool bday019;
protected bool bday020;
protected bool bday021;
protected bool bday022;
protected bool bday023;
protected bool bday024;
protected bool bday025;
protected bool bday026;
protected bool bday027;
protected bool bday028;
protected bool bday029;
protected bool bday030;
protected bool bday031;
protected bool bday032;
protected bool bday033;
protected bool bday034;
protected bool bday035;
protected bool bday036;
protected bool bday037;
protected bool bday038;
protected bool bday039;
protected bool bday040;
protected bool bday041;
protected bool bday042;
protected bool bday043;
protected bool bday044;
protected bool bday045;
protected bool bday046;
protected bool bday047;
protected bool bday048;
protected bool bday049;
protected bool bday050;
protected bool bday051;
protected bool bday052;
protected bool bday053;
protected bool bday054;
protected bool bday055;
protected bool bday056;
protected bool bday057;
protected bool bday058;
protected bool bday059;
protected bool bday060;
protected bool bday061;
protected bool bday062;
protected bool bday063;
protected bool bday064;
protected bool bday065;
protected bool bday066;
protected bool bday067;
protected bool bday068;
protected bool bday069;
protected bool bday070;
protected bool bday071;
protected bool bday072;
protected bool bday073;
protected bool bday074;
protected bool bday075;
protected bool bday076;
protected bool bday077;
protected bool bday078;
protected bool bday079;
protected bool bday080;
protected bool bday081;
protected bool bday082;
protected bool bday083;
protected bool bday084;
protected bool bday085;
protected bool bday086;
protected bool bday087;
protected bool bday088;
protected bool bday089;
protected bool bday090;

#if !WEB
internal
#else
public
#endif
HotListBoolDays(){	
	initBools();
}

private
void initBools(){
    this.bpastDue = false;
	this.bday001 = false;
	this.bday002 = false;
	this.bday003 = false;
	this.bday004 = false;
	this.bday005 = false;
	this.bday006 = false;
	this.bday007 = false;
	this.bday008 = false;
	this.bday009 = false;
	this.bday010 = false;
	this.bday011 = false;
	this.bday012 = false;
	this.bday013 = false;
	this.bday014 = false;
	this.bday015 = false;
	this.bday016 = false;
	this.bday017 = false;
	this.bday018 = false;
	this.bday019 = false;
	this.bday020 = false;
	this.bday021 = false;
	this.bday022 = false;
	this.bday023 = false;
	this.bday024 = false;
	this.bday025 = false;
	this.bday026 = false;
	this.bday027 = false;
	this.bday028 = false;
	this.bday029 = false;
	this.bday030 = false;
	this.bday031 = false;
	this.bday032 = false;
	this.bday033 = false;
	this.bday034 = false;
	this.bday035 = false;
	this.bday036 = false;
	this.bday037 = false;
	this.bday038 = false;
	this.bday039 = false;
	this.bday040 = false;
	this.bday041 = false;
	this.bday042 = false;
	this.bday043 = false;
	this.bday044 = false;
	this.bday045 = false;
	this.bday046 = false;
	this.bday047 = false;
	this.bday048 = false;
	this.bday049 = false;
	this.bday050 = false;
	this.bday051 = false;
	this.bday052 = false;
	this.bday053 = false;
	this.bday054 = false;
	this.bday055 = false;
	this.bday056 = false;
	this.bday057 = false;
	this.bday058 = false;
	this.bday059 = false;
	this.bday060 = false;
	this.bday061 = false;
	this.bday062 = false;
	this.bday063 = false;
	this.bday064 = false;
	this.bday065 = false;
	this.bday066 = false;
	this.bday067 = false;
	this.bday068 = false;
	this.bday069 = false;
	this.bday070 = false;
	this.bday071 = false;
	this.bday072 = false;
	this.bday073 = false;
	this.bday074 = false;
	this.bday075 = false;
	this.bday076 = false;
	this.bday077 = false;
	this.bday078 = false;
	this.bday079 = false;
	this.bday080 = false;
	this.bday081 = false;
	this.bday082 = false;
	this.bday083 = false;
	this.bday084 = false;
	this.bday085 = false;
	this.bday086 = false;
	this.bday087 = false;
	this.bday088 = false;
	this.bday089 = false;
	this.bday090 = false;	
}

[System.Runtime.Serialization.DataMember]
public
bool BPastDue {
	get { return bpastDue;}
	set { if (this.bpastDue != value){
			this.bpastDue = value;
			Notify("BPastDue");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool  BDay001 {
	get { return bday001;}
	set { if (this.bday001 != value){
			this.bday001 = value;
			Notify("BDay001");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay002 {
	get { return bday002;}
	set { if (this.bday002 != value){
			this.bday002 = value;
			Notify("BDay002");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay003 {
	get { return bday003;}
	set { if (this.bday003 != value){
			this.bday003 = value;
			Notify("BDay003");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay004 {
	get { return bday004;}
	set { if (this.bday004 != value){
			this.bday004 = value;
			Notify("BDay004");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay005 {
	get { return bday005;}
	set { if (this.bday005 != value){
			this.bday005 = value;
			Notify("BDay005");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay006 {
	get { return bday006;}
	set { if (this.bday006 != value){
			this.bday006 = value;
			Notify("BDay006");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay007 {
	get { return bday007;}
	set { if (this.bday007 != value){
			this.bday007 = value;
			Notify("BDay007");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay008 {
	get { return bday008;}
	set { if (this.bday008 != value){
			this.bday008 = value;
			Notify("BDay008");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay009 {
	get { return bday009;}
	set { if (this.bday009 != value){
			this.bday009 = value;
			Notify("BDay009");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay010 {
	get { return bday010;}
	set { if (this.bday010 != value){
			this.bday010 = value;
			Notify("BDay010");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay011 {
	get { return bday011;}
	set { if (this.bday011 != value){
			this.bday011 = value;
			Notify("BDay011");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay012 {
	get { return bday012;}
	set { if (this.bday012 != value){
			this.bday012 = value;
			Notify("BDay012");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay013 {
	get { return bday013;}
	set { if (this.bday013 != value){
			this.bday013 = value;
			Notify("BDay013");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay014 {
	get { return bday014;}
	set { if (this.bday014 != value){
			this.bday014 = value;
			Notify("BDay014");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay015 {
	get { return bday015;}
	set { if (this.bday015 != value){
			this.bday015 = value;
			Notify("BDay015");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay016 {
	get { return bday016;}
	set { if (this.bday016 != value){
			this.bday016 = value;
			Notify("BDay016");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay017 {
	get { return bday017;}
	set { if (this.bday017 != value){
			this.bday017 = value;
			Notify("BDay017");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay018 {
	get { return bday018;}
	set { if (this.bday018 != value){
			this.bday018 = value;
			Notify("BDay018");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay019 {
	get { return bday019;}
	set { if (this.bday019 != value){
			this.bday019 = value;
			Notify("BDay019");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay020 {
	get { return bday020;}
	set { if (this.bday020 != value){
			this.bday020 = value;
			Notify("BDay020");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay021 {
	get { return bday021;}
	set { if (this.bday021 != value){
			this.bday021 = value;
			Notify("BDay021");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay022 {
	get { return bday022;}
	set { if (this.bday022 != value){
			this.bday022 = value;
			Notify("BDay022");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay023 {
	get { return bday023;}
	set { if (this.bday023 != value){
			this.bday023 = value;
			Notify("BDay023");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay024 {
	get { return bday024;}
	set { if (this.bday024 != value){
			this.bday024 = value;
			Notify("BDay024");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay025 {
	get { return bday025;}
	set { if (this.bday025 != value){
			this.bday025 = value;
			Notify("BDay025");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay026 {
	get { return bday026;}
	set { if (this.bday026 != value){
			this.bday026 = value;
			Notify("BDay026");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay027 {
	get { return bday027;}
	set { if (this.bday027 != value){
			this.bday027 = value;
			Notify("BDay027");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay028 {
	get { return bday028;}
	set { if (this.bday028 != value){
			this.bday028 = value;
			Notify("BDay028");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay029 {
	get { return bday029;}
	set { if (this.bday029 != value){
			this.bday029 = value;
			Notify("BDay029");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay030 {
	get { return bday030;}
	set { if (this.bday030 != value){
			this.bday030 = value;
			Notify("BDay030");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay031 {
	get { return bday031;}
	set { if (this.bday031 != value){
			this.bday031 = value;
			Notify("BDay031");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay032 {
	get { return bday032;}
	set { if (this.bday032 != value){
			this.bday032 = value;
			Notify("BDay032");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay033 {
	get { return bday033;}
	set { if (this.bday033 != value){
			this.bday033 = value;
			Notify("BDay033");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay034 {
	get { return bday034;}
	set { if (this.bday034 != value){
			this.bday034 = value;
			Notify("BDay034");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay035 {
	get { return bday035;}
	set { if (this.bday035 != value){
			this.bday035 = value;
			Notify("BDay035");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay036 {
	get { return bday036;}
	set { if (this.bday036 != value){
			this.bday036 = value;
			Notify("BDay036");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay037 {
	get { return bday037;}
	set { if (this.bday037 != value){
			this.bday037 = value;
			Notify("BDay037");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay038 {
	get { return bday038;}
	set { if (this.bday038 != value){
			this.bday038 = value;
			Notify("BDay038");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay039 {
	get { return bday039;}
	set { if (this.bday039 != value){
			this.bday039 = value;
			Notify("BDay039");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay040 {
	get { return bday040;}
	set { if (this.bday040 != value){
			this.bday040 = value;
			Notify("BDay040");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay041 {
	get { return bday041;}
	set { if (this.bday041 != value){
			this.bday041 = value;
			Notify("BDay041");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay042 {
	get { return bday042;}
	set { if (this.bday042 != value){
			this.bday042 = value;
			Notify("BDay042");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay043 {
	get { return bday043;}
	set { if (this.bday043 != value){
			this.bday043 = value;
			Notify("BDay043");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay044 {
	get { return bday044;}
	set { if (this.bday044 != value){
			this.bday044 = value;
			Notify("BDay044");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay045 {
	get { return bday045;}
	set { if (this.bday045 != value){
			this.bday045 = value;
			Notify("BDay045");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay046 {
	get { return bday046;}
	set { if (this.bday046 != value){
			this.bday046 = value;
			Notify("BDay046");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay047 {
	get { return bday047;}
	set { if (this.bday047 != value){
			this.bday047 = value;
			Notify("BDay047");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay048 {
	get { return bday048;}
	set { if (this.bday048 != value){
			this.bday048 = value;
			Notify("BDay048");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay049 {
	get { return bday049;}
	set { if (this.bday049 != value){
			this.bday049 = value;
			Notify("BDay049");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay050 {
	get { return bday050;}
	set { if (this.bday050 != value){
			this.bday050 = value;
			Notify("BDay050");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay051 {
	get { return bday051;}
	set { if (this.bday051 != value){
			this.bday051 = value;
			Notify("BDay051");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay052 {
	get { return bday052;}
	set { if (this.bday052 != value){
			this.bday052 = value;
			Notify("BDay052");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay053 {
	get { return bday053;}
	set { if (this.bday053 != value){
			this.bday053 = value;
			Notify("BDay053");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay054 {
	get { return bday054;}
	set { if (this.bday054 != value){
			this.bday054 = value;
			Notify("BDay054");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay055 {
	get { return bday055;}
	set { if (this.bday055 != value){
			this.bday055 = value;
			Notify("BDay055");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay056 {
	get { return bday056;}
	set { if (this.bday056 != value){
			this.bday056 = value;
			Notify("BDay056");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay057 {
	get { return bday057;}
	set { if (this.bday057 != value){
			this.bday057 = value;
			Notify("BDay057");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay058 {
	get { return bday058;}
	set { if (this.bday058 != value){
			this.bday058 = value;
			Notify("BDay058");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay059 {
	get { return bday059;}
	set { if (this.bday059 != value){
			this.bday059 = value;
			Notify("BDay059");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay060 {
	get { return bday060;}
	set { if (this.bday060 != value){
			this.bday060 = value;
			Notify("BDay060");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay061 {
	get { return bday061;}
	set { if (this.bday061 != value){
			this.bday061 = value;
			Notify("BDay061");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay062 {
	get { return bday062;}
	set { if (this.bday062 != value){
			this.bday062 = value;
			Notify("BDay062");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay063 {
	get { return bday063;}
	set { if (this.bday063 != value){
			this.bday063 = value;
			Notify("BDay063");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay064 {
	get { return bday064;}
	set { if (this.bday064 != value){
			this.bday064 = value;
			Notify("BDay064");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay065 {
	get { return bday065;}
	set { if (this.bday065 != value){
			this.bday065 = value;
			Notify("BDay065");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay066 {
	get { return bday066;}
	set { if (this.bday066 != value){
			this.bday066 = value;
			Notify("BDay066");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay067 {
	get { return bday067;}
	set { if (this.bday067 != value){
			this.bday067 = value;
			Notify("BDay067");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay068 {
	get { return bday068;}
	set { if (this.bday068 != value){
			this.bday068 = value;
			Notify("BDay068");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay069 {
	get { return bday069;}
	set { if (this.bday069 != value){
			this.bday069 = value;
			Notify("BDay069");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay070 {
	get { return bday070;}
	set { if (this.bday070 != value){
			this.bday070 = value;
			Notify("BDay070");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay071 {
	get { return bday071;}
	set { if (this.bday071 != value){
			this.bday071 = value;
			Notify("BDay071");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay072 {
	get { return bday072;}
	set { if (this.bday072 != value){
			this.bday072 = value;
			Notify("BDay072");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay073 {
	get { return bday073;}
	set { if (this.bday073 != value){
			this.bday073 = value;
			Notify("BDay073");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay074 {
	get { return bday074;}
	set { if (this.bday074 != value){
			this.bday074 = value;
			Notify("BDay074");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay075 {
	get { return bday075;}
	set { if (this.bday075 != value){
			this.bday075 = value;
			Notify("BDay075");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay076 {
	get { return bday076;}
	set { if (this.bday076 != value){
			this.bday076 = value;
			Notify("BDay076");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay077 {
	get { return bday077;}
	set { if (this.bday077 != value){
			this.bday077 = value;
			Notify("BDay077");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay078 {
	get { return bday078;}
	set { if (this.bday078 != value){
			this.bday078 = value;
			Notify("BDay078");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay079 {
	get { return bday079;}
	set { if (this.bday079 != value){
			this.bday079 = value;
			Notify("BDay079");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay080 {
	get { return bday080;}
	set { if (this.bday080 != value){
			this.bday080 = value;
			Notify("BDay080");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay081 {
	get { return bday081;}
	set { if (this.bday081 != value){
			this.bday081 = value;
			Notify("BDay081");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay082 {
	get { return bday082;}
	set { if (this.bday082 != value){
			this.bday082 = value;
			Notify("BDay082");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay083 {
	get { return bday083;}
	set { if (this.bday083 != value){
			this.bday083 = value;
			Notify("BDay083");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay084 {
	get { return bday084;}
	set { if (this.bday084 != value){
			this.bday084 = value;
			Notify("BDay084");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay085 {
	get { return bday085;}
	set { if (this.bday085 != value){
			this.bday085 = value;
			Notify("BDay085");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay086 {
	get { return bday086;}
	set { if (this.bday086 != value){
			this.bday086 = value;
			Notify("BDay086");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay087 {
	get { return bday087;}
	set { if (this.bday087 != value){
			this.bday087 = value;
			Notify("BDay087");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay088 {
	get { return bday088;}
	set { if (this.bday088 != value){
			this.bday088 = value;
			Notify("BDay088");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay089 {
	get { return bday089;}
	set { if (this.bday089 != value){
			this.bday089 = value;
			Notify("BDay089");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDay090 {
	get { return bday090;}
	set { if (this.bday090 != value){
			this.bday090 = value;
			Notify("BDay090");
		}
	}
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
bool getBoolByDate(DateTime runDate,DateTime dateFilter){
    bool bqty =false;

    if (dateFilter < DateUtil.minorHour(runDate))
        bqty = bpastDue;
    else if (DateUtil.sameDate(dateFilter,runDate))
        bqty = bday001;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        bqty = bday002;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        bqty = bday003;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        bqty = bday004;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        bqty = bday005;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        bqty = bday006;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        bqty = bday007;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        bqty = bday008;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        bqty = bday009;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        bqty = bday010;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        bqty = bday011;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        bqty = bday012;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        bqty = bday013;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        bqty = bday014;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        bqty = bday015;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        bqty = bday016;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        bqty = bday017;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        bqty = bday018;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        bqty = bday019;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        bqty = bday020;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        bqty = bday021;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        bqty = bday022;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        bqty = bday023;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        bqty = bday024;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        bqty = bday025;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        bqty = bday026;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        bqty = bday027;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        bqty = bday028;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        bqty = bday029;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        bqty = bday030;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        bqty = bday031;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        bqty = bday032;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        bqty = bday033;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        bqty = bday034;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        bqty = bday035;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        bqty = bday036;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        bqty = bday037;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        bqty = bday038;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        bqty = bday039;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        bqty = bday040;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        bqty = bday041;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        bqty = bday042;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        bqty = bday043;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        bqty = bday044;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        bqty = bday045;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        bqty = bday046;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        bqty = bday047;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        bqty = bday048;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        bqty = bday049;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        bqty = bday050;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        bqty = bday051;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        bqty = bday052;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        bqty = bday053;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        bqty = bday054;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        bqty = bday055;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        bqty = bday056;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        bqty = bday057;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        bqty = bday058;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        bqty = bday059;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        bqty = bday060;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        bqty = bday061;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        bqty = bday062;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        bqty = bday063;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        bqty = bday064;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        bqty = bday065;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        bqty = bday066;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        bqty = bday067;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        bqty = bday068;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        bqty = bday069;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        bqty = bday070;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        bqty = bday071;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        bqty = bday072;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        bqty = bday073;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        bqty = bday074;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        bqty = bday075;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        bqty = bday076;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        bqty = bday077;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        bqty = bday078;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        bqty = bday079;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        bqty = bday080;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        bqty = bday081;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        bqty = bday082;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        bqty = bday083;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        bqty = bday084;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        bqty = bday085;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        bqty = bday086;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        bqty = bday087;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        bqty = bday088;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        bqty = bday089;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        bqty = bday090;

    return bqty;
}

public
void setBoolByDate(DateTime runDate,DateTime dateFilter,bool bqty){
     
    if (dateFilter < DateUtil.minorHour(runDate))
        bpastDue = bqty;
    else if (DateUtil.sameDate(dateFilter,runDate))
        bday001= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        bday002= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        bday003= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        bday004= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        bday005= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        bday006= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        bday007= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        bday008= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        bday009= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        bday010= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        bday011= bqty;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        bday012= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        bday013= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        bday014= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        bday015= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        bday016= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        bday017= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        bday018= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        bday019= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        bday020= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        bday021= bqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        bday022= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        bday023= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        bday024= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        bday025= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        bday026= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        bday027= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        bday028= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        bday029= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        bday030= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        bday031= bqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        bday032= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        bday033= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        bday034= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        bday035= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        bday036= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        bday037= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        bday038= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        bday039= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        bday040= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        bday041= bqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        bday042= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        bday043= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        bday044= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        bday045= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        bday046= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        bday047= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        bday048= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        bday049= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        bday050= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        bday051= bqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        bday052= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        bday053= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        bday054= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        bday055= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        bday056= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        bday057= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        bday058= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        bday059= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        bday060= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        bday061= bqty;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        bday062= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        bday063= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        bday064= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        bday065= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        bday066= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        bday067= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        bday068= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        bday069= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        bday070= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        bday071= bqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        bday072= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        bday073= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        bday074= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        bday075= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        bday076= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        bday077= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        bday078= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        bday079= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        bday080= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        bday081= bqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        bday082= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        bday083= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        bday084= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        bday085= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        bday086= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        bday087= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        bday088= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        bday089= bqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        bday090= bqty;    
}

public
void copy(HotListDays hotListDays){	
	this.BPastDue=hotListDays.BPastDue;
	this.BDay001=hotListDays.BDay001;
	this.BDay002=hotListDays.BDay002;
	this.BDay003=hotListDays.BDay003;
	this.BDay004=hotListDays.BDay004;
	this.BDay005=hotListDays.BDay005;
	this.BDay006=hotListDays.BDay006;
	this.BDay007=hotListDays.BDay007;
	this.BDay008=hotListDays.BDay008;
	this.BDay009=hotListDays.BDay009;
	this.BDay010=hotListDays.BDay010;
	this.BDay011=hotListDays.BDay011;
	this.BDay012=hotListDays.BDay012;
	this.BDay013=hotListDays.BDay013;
	this.BDay014=hotListDays.BDay014;
	this.BDay015=hotListDays.BDay015;
	this.BDay016=hotListDays.BDay016;
	this.BDay017=hotListDays.BDay017;
	this.BDay018=hotListDays.BDay018;
	this.BDay019=hotListDays.BDay019;
	this.BDay020=hotListDays.BDay020;
	this.BDay021=hotListDays.BDay021;
	this.BDay022=hotListDays.BDay022;
	this.BDay023=hotListDays.BDay023;
	this.BDay024=hotListDays.BDay024;
	this.BDay025=hotListDays.BDay025;
	this.BDay026=hotListDays.BDay026;
	this.BDay027=hotListDays.BDay027;
	this.BDay028=hotListDays.BDay028;
	this.BDay029=hotListDays.BDay029;
	this.BDay030=hotListDays.BDay030;
	this.BDay031=hotListDays.BDay031;
	this.BDay032=hotListDays.BDay032;
	this.BDay033=hotListDays.BDay033;
	this.BDay034=hotListDays.BDay034;
	this.BDay035=hotListDays.BDay035;
	this.BDay036=hotListDays.BDay036;
	this.BDay037=hotListDays.BDay037;
	this.BDay038=hotListDays.BDay038;
	this.BDay039=hotListDays.BDay039;
	this.BDay040=hotListDays.BDay040;
	this.BDay041=hotListDays.BDay041;
	this.BDay042=hotListDays.BDay042;
	this.BDay043=hotListDays.BDay043;
	this.BDay044=hotListDays.BDay044;
	this.BDay045=hotListDays.BDay045;
	this.BDay046=hotListDays.BDay046;
	this.BDay047=hotListDays.BDay047;
	this.BDay048=hotListDays.BDay048;
	this.BDay049=hotListDays.BDay049;
	this.BDay050=hotListDays.BDay050;
	this.BDay051=hotListDays.BDay051;
	this.BDay052=hotListDays.BDay052;
	this.BDay053=hotListDays.BDay053;
	this.BDay054=hotListDays.BDay054;
	this.BDay055=hotListDays.BDay055;
	this.BDay056=hotListDays.BDay056;
	this.BDay057=hotListDays.BDay057;
	this.BDay058=hotListDays.BDay058;
	this.BDay059=hotListDays.BDay059;
	this.BDay060=hotListDays.BDay060;
	this.BDay061=hotListDays.BDay061;
	this.BDay062=hotListDays.BDay062;
	this.BDay063=hotListDays.BDay063;
	this.BDay064=hotListDays.BDay064;
	this.BDay065=hotListDays.BDay065;
	this.BDay066=hotListDays.BDay066;
	this.BDay067=hotListDays.BDay067;
	this.BDay068=hotListDays.BDay068;
	this.BDay069=hotListDays.BDay069;
	this.BDay070=hotListDays.BDay070;
	this.BDay071=hotListDays.BDay071;
	this.BDay072=hotListDays.BDay072;
	this.BDay073=hotListDays.BDay073;
	this.BDay074=hotListDays.BDay074;
	this.BDay075=hotListDays.BDay075;
	this.BDay076=hotListDays.BDay076;
	this.BDay077=hotListDays.BDay077;
	this.BDay078=hotListDays.BDay078;
	this.BDay079=hotListDays.BDay079;
	this.BDay080=hotListDays.BDay080;
	this.BDay081=hotListDays.BDay081;
	this.BDay082=hotListDays.BDay082;
	this.BDay083=hotListDays.BDay083;
	this.BDay084=hotListDays.BDay084;
	this.BDay085=hotListDays.BDay085;
	this.BDay086=hotListDays.BDay086;
	this.BDay087=hotListDays.BDay087;
	this.BDay088=hotListDays.BDay088;
	this.BDay089=hotListDays.BDay089;
	this.BDay090=hotListDays.BDay090;	
}


} // class
} // package