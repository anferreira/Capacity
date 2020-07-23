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
class HotListStringDays : HotListDays {

protected string  spastDue;
protected string  sday001;
protected string  sday002;
protected string  sday003;
protected string  sday004;
protected string  sday005;
protected string  sday006;
protected string  sday007;
protected string  sday008;
protected string  sday009;
protected string  sday010;
protected string  sday011;
protected string  sday012;
protected string  sday013;
protected string  sday014;
protected string  sday015;
protected string  sday016;
protected string  sday017;
protected string  sday018;
protected string  sday019;
protected string  sday020;
protected string  sday021;
protected string  sday022;
protected string  sday023;
protected string  sday024;
protected string  sday025;
protected string  sday026;
protected string  sday027;
protected string  sday028;
protected string  sday029;
protected string  sday030;
protected string  sday031;
protected string  sday032;
protected string  sday033;
protected string  sday034;
protected string  sday035;
protected string  sday036;
protected string  sday037;
protected string  sday038;
protected string  sday039;
protected string  sday040;
protected string  sday041;
protected string  sday042;
protected string  sday043;
protected string  sday044;
protected string  sday045;
protected string  sday046;
protected string  sday047;
protected string  sday048;
protected string  sday049;
protected string  sday050;
protected string  sday051;
protected string  sday052;
protected string  sday053;
protected string  sday054;
protected string  sday055;
protected string  sday056;
protected string  sday057;
protected string  sday058;
protected string  sday059;
protected string  sday060;
protected string  sday061;
protected string  sday062;
protected string  sday063;
protected string  sday064;
protected string  sday065;
protected string  sday066;
protected string  sday067;
protected string  sday068;
protected string  sday069;
protected string  sday070;
protected string  sday071;
protected string  sday072;
protected string  sday073;
protected string  sday074;
protected string  sday075;
protected string  sday076;
protected string  sday077;
protected string  sday078;
protected string  sday079;
protected string  sday080;
protected string  sday081;
protected string  sday082;
protected string  sday083;
protected string  sday084;
protected string  sday085;
protected string  sday086;
protected string  sday087;
protected string  sday088;
protected string  sday089;
protected string  sday090;


public
HotListStringDays(){	
	initstrings();
}

private
void initstrings(){
    this.spastDue = "";
	this.sday001 = "";
	this.sday002 = "";
	this.sday003 = "";
	this.sday004 = "";
	this.sday005 = "";
	this.sday006 = "";
	this.sday007 = "";
	this.sday008 = "";
	this.sday009 = "";
	this.sday010 = "";
	this.sday011 = "";
	this.sday012 = "";
	this.sday013 = "";
	this.sday014 = "";
	this.sday015 = "";
	this.sday016 = "";
	this.sday017 = "";
	this.sday018 = "";
	this.sday019 = "";
	this.sday020 = "";
	this.sday021 = "";
	this.sday022 = "";
	this.sday023 = "";
	this.sday024 = "";
	this.sday025 = "";
	this.sday026 = "";
	this.sday027 = "";
	this.sday028 = "";
	this.sday029 = "";
	this.sday030 = "";
	this.sday031 = "";
	this.sday032 = "";
	this.sday033 = "";
	this.sday034 = "";
	this.sday035 = "";
	this.sday036 = "";
	this.sday037 = "";
	this.sday038 = "";
	this.sday039 = "";
	this.sday040 = "";
	this.sday041 = "";
	this.sday042 = "";
	this.sday043 = "";
	this.sday044 = "";
	this.sday045 = "";
	this.sday046 = "";
	this.sday047 = "";
	this.sday048 = "";
	this.sday049 = "";
	this.sday050 = "";
	this.sday051 = "";
	this.sday052 = "";
	this.sday053 = "";
	this.sday054 = "";
	this.sday055 = "";
	this.sday056 = "";
	this.sday057 = "";
	this.sday058 = "";
	this.sday059 = "";
	this.sday060 = "";
	this.sday061 = "";
	this.sday062 = "";
	this.sday063 = "";
	this.sday064 = "";
	this.sday065 = "";
	this.sday066 = "";
	this.sday067 = "";
	this.sday068 = "";
	this.sday069 = "";
	this.sday070 = "";
	this.sday071 = "";
	this.sday072 = "";
	this.sday073 = "";
	this.sday074 = "";
	this.sday075 = "";
	this.sday076 = "";
	this.sday077 = "";
	this.sday078 = "";
	this.sday079 = "";
	this.sday080 = "";
	this.sday081 = "";
	this.sday082 = "";
	this.sday083 = "";
	this.sday084 = "";
	this.sday085 = "";
	this.sday086 = "";
	this.sday087 = "";
	this.sday088 = "";
	this.sday089 = "";
	this.sday090 = "";	
}

[System.Runtime.Serialization.DataMember]
public
string SPastDue {
	get { return spastDue; }
	set { if (this.spastDue != value){
			this.spastDue = value;
			Notify("SPastDue");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay001 {
	get { return sday001;}
	set { if (this.sday001 != value){
			this.sday001 = value;
			Notify("SDay001");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay002 {
	get { return sday002;}
	set { if (this.sday002 != value){
			this.sday002 = value;
			Notify("SDay002");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay003 {
	get { return sday003;}
	set { if (this.sday003 != value){
			this.sday003 = value;
			Notify("SDay003");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay004 {
	get { return sday004;}
	set { if (this.sday004 != value){
			this.sday004 = value;
			Notify("SDay004");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay005 {
	get { return sday005;}
	set { if (this.sday005 != value){
			this.sday005 = value;
			Notify("SDay005");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay006 {
	get { return sday006;}
	set { if (this.sday006 != value){
			this.sday006 = value;
			Notify("SDay006");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay007 {
	get { return sday007;}
	set { if (this.sday007 != value){
			this.sday007 = value;
			Notify("SDay007");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay008 {
	get { return sday008;}
	set { if (this.sday008 != value){
			this.sday008 = value;
			Notify("SDay008");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay009 {
	get { return sday009;}
	set { if (this.sday009 != value){
			this.sday009 = value;
			Notify("SDay009");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay010 {
	get { return sday010;}
	set { if (this.sday010 != value){
			this.sday010 = value;
			Notify("SDay010");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay011 {
	get { return sday011;}
	set { if (this.sday011 != value){
			this.sday011 = value;
			Notify("SDay011");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay012 {
	get { return sday012;}
	set { if (this.sday012 != value){
			this.sday012 = value;
			Notify("SDay012");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay013 {
	get { return sday013;}
	set { if (this.sday013 != value){
			this.sday013 = value;
			Notify("SDay013");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay014 {
	get { return sday014;}
	set { if (this.sday014 != value){
			this.sday014 = value;
			Notify("SDay014");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay015 {
	get { return sday015;}
	set { if (this.sday015 != value){
			this.sday015 = value;
			Notify("SDay015");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay016 {
	get { return sday016;}
	set { if (this.sday016 != value){
			this.sday016 = value;
			Notify("SDay016");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay017 {
	get { return sday017;}
	set { if (this.sday017 != value){
			this.sday017 = value;
			Notify("SDay017");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay018 {
	get { return sday018;}
	set { if (this.sday018 != value){
			this.sday018 = value;
			Notify("SDay018");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay019 {
	get { return sday019;}
	set { if (this.sday019 != value){
			this.sday019 = value;
			Notify("SDay019");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay020 {
	get { return sday020;}
	set { if (this.sday020 != value){
			this.sday020 = value;
			Notify("SDay020");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay021 {
	get { return sday021;}
	set { if (this.sday021 != value){
			this.sday021 = value;
			Notify("SDay021");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay022 {
	get { return sday022;}
	set { if (this.sday022 != value){
			this.sday022 = value;
			Notify("SDay022");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay023 {
	get { return sday023;}
	set { if (this.sday023 != value){
			this.sday023 = value;
			Notify("SDay023");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay024 {
	get { return sday024;}
	set { if (this.sday024 != value){
			this.sday024 = value;
			Notify("SDay024");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay025 {
	get { return sday025;}
	set { if (this.sday025 != value){
			this.sday025 = value;
			Notify("SDay025");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay026 {
	get { return sday026;}
	set { if (this.sday026 != value){
			this.sday026 = value;
			Notify("SDay026");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay027 {
	get { return sday027;}
	set { if (this.sday027 != value){
			this.sday027 = value;
			Notify("SDay027");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay028 {
	get { return sday028;}
	set { if (this.sday028 != value){
			this.sday028 = value;
			Notify("SDay028");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay029 {
	get { return sday029;}
	set { if (this.sday029 != value){
			this.sday029 = value;
			Notify("SDay029");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay030 {
	get { return sday030;}
	set { if (this.sday030 != value){
			this.sday030 = value;
			Notify("SDay030");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay031 {
	get { return sday031;}
	set { if (this.sday031 != value){
			this.sday031 = value;
			Notify("SDay031");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay032 {
	get { return sday032;}
	set { if (this.sday032 != value){
			this.sday032 = value;
			Notify("SDay032");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay033 {
	get { return sday033;}
	set { if (this.sday033 != value){
			this.sday033 = value;
			Notify("SDay033");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay034 {
	get { return sday034;}
	set { if (this.sday034 != value){
			this.sday034 = value;
			Notify("SDay034");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay035 {
	get { return sday035;}
	set { if (this.sday035 != value){
			this.sday035 = value;
			Notify("SDay035");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay036 {
	get { return sday036;}
	set { if (this.sday036 != value){
			this.sday036 = value;
			Notify("SDay036");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay037 {
	get { return sday037;}
	set { if (this.sday037 != value){
			this.sday037 = value;
			Notify("SDay037");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay038 {
	get { return sday038;}
	set { if (this.sday038 != value){
			this.sday038 = value;
			Notify("SDay038");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay039 {
	get { return sday039;}
	set { if (this.sday039 != value){
			this.sday039 = value;
			Notify("SDay039");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay040 {
	get { return sday040;}
	set { if (this.sday040 != value){
			this.sday040 = value;
			Notify("SDay040");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay041 {
	get { return sday041;}
	set { if (this.sday041 != value){
			this.sday041 = value;
			Notify("SDay041");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay042 {
	get { return sday042;}
	set { if (this.sday042 != value){
			this.sday042 = value;
			Notify("SDay042");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay043 {
	get { return sday043;}
	set { if (this.sday043 != value){
			this.sday043 = value;
			Notify("SDay043");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay044 {
	get { return sday044;}
	set { if (this.sday044 != value){
			this.sday044 = value;
			Notify("SDay044");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay045 {
	get { return sday045;}
	set { if (this.sday045 != value){
			this.sday045 = value;
			Notify("SDay045");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay046 {
	get { return sday046;}
	set { if (this.sday046 != value){
			this.sday046 = value;
			Notify("SDay046");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay047 {
	get { return sday047;}
	set { if (this.sday047 != value){
			this.sday047 = value;
			Notify("SDay047");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay048 {
	get { return sday048;}
	set { if (this.sday048 != value){
			this.sday048 = value;
			Notify("SDay048");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay049 {
	get { return sday049;}
	set { if (this.sday049 != value){
			this.sday049 = value;
			Notify("SDay049");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay050 {
	get { return sday050;}
	set { if (this.sday050 != value){
			this.sday050 = value;
			Notify("SDay050");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay051 {
	get { return sday051;}
	set { if (this.sday051 != value){
			this.sday051 = value;
			Notify("SDay051");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay052 {
	get { return sday052;}
	set { if (this.sday052 != value){
			this.sday052 = value;
			Notify("SDay052");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay053 {
	get { return sday053;}
	set { if (this.sday053 != value){
			this.sday053 = value;
			Notify("SDay053");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay054 {
	get { return sday054;}
	set { if (this.sday054 != value){
			this.sday054 = value;
			Notify("SDay054");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay055 {
	get { return sday055;}
	set { if (this.sday055 != value){
			this.sday055 = value;
			Notify("SDay055");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay056 {
	get { return sday056;}
	set { if (this.sday056 != value){
			this.sday056 = value;
			Notify("SDay056");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay057 {
	get { return sday057;}
	set { if (this.sday057 != value){
			this.sday057 = value;
			Notify("SDay057");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay058 {
	get { return sday058;}
	set { if (this.sday058 != value){
			this.sday058 = value;
			Notify("SDay058");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay059 {
	get { return sday059;}
	set { if (this.sday059 != value){
			this.sday059 = value;
			Notify("SDay059");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay060 {
	get { return sday060;}
	set { if (this.sday060 != value){
			this.sday060 = value;
			Notify("SDay060");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay061 {
	get { return sday061;}
	set { if (this.sday061 != value){
			this.sday061 = value;
			Notify("SDay061");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay062 {
	get { return sday062;}
	set { if (this.sday062 != value){
			this.sday062 = value;
			Notify("SDay062");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay063 {
	get { return sday063;}
	set { if (this.sday063 != value){
			this.sday063 = value;
			Notify("SDay063");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay064 {
	get { return sday064;}
	set { if (this.sday064 != value){
			this.sday064 = value;
			Notify("SDay064");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay065 {
	get { return sday065;}
	set { if (this.sday065 != value){
			this.sday065 = value;
			Notify("SDay065");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay066 {
	get { return sday066;}
	set { if (this.sday066 != value){
			this.sday066 = value;
			Notify("SDay066");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay067 {
	get { return sday067;}
	set { if (this.sday067 != value){
			this.sday067 = value;
			Notify("SDay067");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay068 {
	get { return sday068;}
	set { if (this.sday068 != value){
			this.sday068 = value;
			Notify("SDay068");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay069 {
	get { return sday069;}
	set { if (this.sday069 != value){
			this.sday069 = value;
			Notify("SDay069");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay070 {
	get { return sday070;}
	set { if (this.sday070 != value){
			this.sday070 = value;
			Notify("SDay070");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay071 {
	get { return sday071;}
	set { if (this.sday071 != value){
			this.sday071 = value;
			Notify("SDay071");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay072 {
	get { return sday072;}
	set { if (this.sday072 != value){
			this.sday072 = value;
			Notify("SDay072");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay073 {
	get { return sday073;}
	set { if (this.sday073 != value){
			this.sday073 = value;
			Notify("SDay073");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay074 {
	get { return sday074;}
	set { if (this.sday074 != value){
			this.sday074 = value;
			Notify("SDay074");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay075 {
	get { return sday075;}
	set { if (this.sday075 != value){
			this.sday075 = value;
			Notify("SDay075");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay076 {
	get { return sday076;}
	set { if (this.sday076 != value){
			this.sday076 = value;
			Notify("SDay076");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay077 {
	get { return sday077;}
	set { if (this.sday077 != value){
			this.sday077 = value;
			Notify("SDay077");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay078 {
	get { return sday078;}
	set { if (this.sday078 != value){
			this.sday078 = value;
			Notify("SDay078");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay079 {
	get { return sday079;}
	set { if (this.sday079 != value){
			this.sday079 = value;
			Notify("SDay079");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay080 {
	get { return sday080;}
	set { if (this.sday080 != value){
			this.sday080 = value;
			Notify("SDay080");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay081 {
	get { return sday081;}
	set { if (this.sday081 != value){
			this.sday081 = value;
			Notify("SDay081");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay082 {
	get { return sday082;}
	set { if (this.sday082 != value){
			this.sday082 = value;
			Notify("SDay082");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay083 {
	get { return sday083;}
	set { if (this.sday083 != value){
			this.sday083 = value;
			Notify("SDay083");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay084 {
	get { return sday084;}
	set { if (this.sday084 != value){
			this.sday084 = value;
			Notify("SDay084");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay085 {
	get { return sday085;}
	set { if (this.sday085 != value){
			this.sday085 = value;
			Notify("SDay085");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay086 {
	get { return sday086;}
	set { if (this.sday086 != value){
			this.sday086 = value;
			Notify("SDay086");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay087 {
	get { return sday087;}
	set { if (this.sday087 != value){
			this.sday087 = value;
			Notify("SDay087");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay088 {
	get { return sday088;}
	set { if (this.sday088 != value){
			this.sday088 = value;
			Notify("SDay088");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay089 {
	get { return sday089;}
	set { if (this.sday089 != value){
			this.sday089 = value;
			Notify("SDay089");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string  SDay090 {
	get { return sday090;}
	set { if (this.sday090 != value){
			this.sday090 = value;
			Notify("SDay090");
		}
	}
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
string getStringByDate(DateTime runDate,DateTime dateFilter){
    string svalue ="";

    if (dateFilter < DateUtil.minorHour(runDate))
        svalue = spastDue;
    else if (DateUtil.sameDate(dateFilter,runDate))
        svalue = sday001;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        svalue = sday002;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        svalue = sday003;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        svalue = sday004;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        svalue = sday005;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        svalue = sday006;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        svalue = sday007;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        svalue = sday008;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        svalue = sday009;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        svalue = sday010;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        svalue = sday011;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        svalue = sday012;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        svalue = sday013;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        svalue = sday014;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        svalue = sday015;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        svalue = sday016;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        svalue = sday017;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        svalue = sday018;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        svalue = sday019;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        svalue = sday020;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        svalue = sday021;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        svalue = sday022;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        svalue = sday023;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        svalue = sday024;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        svalue = sday025;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        svalue = sday026;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        svalue = sday027;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        svalue = sday028;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        svalue = sday029;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        svalue = sday030;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        svalue = sday031;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        svalue = sday032;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        svalue = sday033;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        svalue = sday034;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        svalue = sday035;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        svalue = sday036;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        svalue = sday037;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        svalue = sday038;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        svalue = sday039;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        svalue = sday040;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        svalue = sday041;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        svalue = sday042;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        svalue = sday043;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        svalue = sday044;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        svalue = sday045;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        svalue = sday046;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        svalue = sday047;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        svalue = sday048;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        svalue = sday049;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        svalue = sday050;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        svalue = sday051;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        svalue = sday052;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        svalue = sday053;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        svalue = sday054;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        svalue = sday055;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        svalue = sday056;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        svalue = sday057;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        svalue = sday058;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        svalue = sday059;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        svalue = sday060;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        svalue = sday061;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        svalue = sday062;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        svalue = sday063;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        svalue = sday064;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        svalue = sday065;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        svalue = sday066;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        svalue = sday067;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        svalue = sday068;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        svalue = sday069;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        svalue = sday070;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        svalue = sday071;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        svalue = sday072;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        svalue = sday073;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        svalue = sday074;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        svalue = sday075;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        svalue = sday076;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        svalue = sday077;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        svalue = sday078;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        svalue = sday079;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        svalue = sday080;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        svalue = sday081;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        svalue = sday082;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        svalue = sday083;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        svalue = sday084;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        svalue = sday085;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        svalue = sday086;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        svalue = sday087;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        svalue = sday088;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        svalue = sday089;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        svalue = sday090;

    return svalue;
}

public
void setStringByDate(DateTime runDate,DateTime dateFilter,string svalue){
     
    if (dateFilter < DateUtil.minorHour(runDate))
        spastDue = svalue;
    else if (DateUtil.sameDate(dateFilter,runDate))
        sday001= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        sday002= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        sday003= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        sday004= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        sday005= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        sday006= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        sday007= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        sday008= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        sday009= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        sday010= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        sday011= svalue;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        sday012= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        sday013= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        sday014= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        sday015= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        sday016= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        sday017= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        sday018= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        sday019= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        sday020= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        sday021= svalue;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        sday022= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        sday023= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        sday024= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        sday025= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        sday026= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        sday027= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        sday028= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        sday029= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        sday030= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        sday031= svalue;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        sday032= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        sday033= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        sday034= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        sday035= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        sday036= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        sday037= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        sday038= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        sday039= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        sday040= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        sday041= svalue;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        sday042= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        sday043= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        sday044= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        sday045= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        sday046= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        sday047= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        sday048= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        sday049= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        sday050= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        sday051= svalue;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        sday052= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        sday053= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        sday054= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        sday055= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        sday056= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        sday057= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        sday058= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        sday059= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        sday060= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        sday061= svalue;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        sday062= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        sday063= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        sday064= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        sday065= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        sday066= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        sday067= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        sday068= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        sday069= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        sday070= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        sday071= svalue;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        sday072= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        sday073= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        sday074= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        sday075= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        sday076= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        sday077= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        sday078= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        sday079= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        sday080= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        sday081= svalue;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        sday082= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        sday083= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        sday084= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        sday085= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        sday086= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        sday087= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        sday088= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        sday089= svalue;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        sday090= svalue;    
}

public
void copy(HotListStringDays hotListStringDays){	
	this.SPastDue=hotListStringDays.SPastDue;
	this.SDay001=hotListStringDays.SDay001;
	this.SDay002=hotListStringDays.SDay002;
	this.SDay003=hotListStringDays.SDay003;
	this.SDay004=hotListStringDays.SDay004;
	this.SDay005=hotListStringDays.SDay005;
	this.SDay006=hotListStringDays.SDay006;
	this.SDay007=hotListStringDays.SDay007;
	this.SDay008=hotListStringDays.SDay008;
	this.SDay009=hotListStringDays.SDay009;
	this.SDay010=hotListStringDays.SDay010;
	this.SDay011=hotListStringDays.SDay011;
	this.SDay012=hotListStringDays.SDay012;
	this.SDay013=hotListStringDays.SDay013;
	this.SDay014=hotListStringDays.SDay014;
	this.SDay015=hotListStringDays.SDay015;
	this.SDay016=hotListStringDays.SDay016;
	this.SDay017=hotListStringDays.SDay017;
	this.SDay018=hotListStringDays.SDay018;
	this.SDay019=hotListStringDays.SDay019;
	this.SDay020=hotListStringDays.SDay020;
	this.SDay021=hotListStringDays.SDay021;
	this.SDay022=hotListStringDays.SDay022;
	this.SDay023=hotListStringDays.SDay023;
	this.SDay024=hotListStringDays.SDay024;
	this.SDay025=hotListStringDays.SDay025;
	this.SDay026=hotListStringDays.SDay026;
	this.SDay027=hotListStringDays.SDay027;
	this.SDay028=hotListStringDays.SDay028;
	this.SDay029=hotListStringDays.SDay029;
	this.SDay030=hotListStringDays.SDay030;
	this.SDay031=hotListStringDays.SDay031;
	this.SDay032=hotListStringDays.SDay032;
	this.SDay033=hotListStringDays.SDay033;
	this.SDay034=hotListStringDays.SDay034;
	this.SDay035=hotListStringDays.SDay035;
	this.SDay036=hotListStringDays.SDay036;
	this.SDay037=hotListStringDays.SDay037;
	this.SDay038=hotListStringDays.SDay038;
	this.SDay039=hotListStringDays.SDay039;
	this.SDay040=hotListStringDays.SDay040;
	this.SDay041=hotListStringDays.SDay041;
	this.SDay042=hotListStringDays.SDay042;
	this.SDay043=hotListStringDays.SDay043;
	this.SDay044=hotListStringDays.SDay044;
	this.SDay045=hotListStringDays.SDay045;
	this.SDay046=hotListStringDays.SDay046;
	this.SDay047=hotListStringDays.SDay047;
	this.SDay048=hotListStringDays.SDay048;
	this.SDay049=hotListStringDays.SDay049;
	this.SDay050=hotListStringDays.SDay050;
	this.SDay051=hotListStringDays.SDay051;
	this.SDay052=hotListStringDays.SDay052;
	this.SDay053=hotListStringDays.SDay053;
	this.SDay054=hotListStringDays.SDay054;
	this.SDay055=hotListStringDays.SDay055;
	this.SDay056=hotListStringDays.SDay056;
	this.SDay057=hotListStringDays.SDay057;
	this.SDay058=hotListStringDays.SDay058;
	this.SDay059=hotListStringDays.SDay059;
	this.SDay060=hotListStringDays.SDay060;
	this.SDay061=hotListStringDays.SDay061;
	this.SDay062=hotListStringDays.SDay062;
	this.SDay063=hotListStringDays.SDay063;
	this.SDay064=hotListStringDays.SDay064;
	this.SDay065=hotListStringDays.SDay065;
	this.SDay066=hotListStringDays.SDay066;
	this.SDay067=hotListStringDays.SDay067;
	this.SDay068=hotListStringDays.SDay068;
	this.SDay069=hotListStringDays.SDay069;
	this.SDay070=hotListStringDays.SDay070;
	this.SDay071=hotListStringDays.SDay071;
	this.SDay072=hotListStringDays.SDay072;
	this.SDay073=hotListStringDays.SDay073;
	this.SDay074=hotListStringDays.SDay074;
	this.SDay075=hotListStringDays.SDay075;
	this.SDay076=hotListStringDays.SDay076;
	this.SDay077=hotListStringDays.SDay077;
	this.SDay078=hotListStringDays.SDay078;
	this.SDay079=hotListStringDays.SDay079;
	this.SDay080=hotListStringDays.SDay080;
	this.SDay081=hotListStringDays.SDay081;
	this.SDay082=hotListStringDays.SDay082;
	this.SDay083=hotListStringDays.SDay083;
	this.SDay084=hotListStringDays.SDay084;
	this.SDay085=hotListStringDays.SDay085;
	this.SDay086=hotListStringDays.SDay086;
	this.SDay087=hotListStringDays.SDay087;
	this.SDay088=hotListStringDays.SDay088;
	this.SDay089=hotListStringDays.SDay089;
	this.SDay090=hotListStringDays.SDay090;	

    base.copy(hotListStringDays);
}


} // class
} // package