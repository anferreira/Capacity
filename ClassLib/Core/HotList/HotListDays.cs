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
class HotListDays : HotListBoolDays {

protected DateTime pastDueDateSet;

protected decimal pastDue;
protected decimal day001;
protected decimal day002;
protected decimal day003;
protected decimal day004;
protected decimal day005;
protected decimal day006;
protected decimal day007;
protected decimal day008;
protected decimal day009;
protected decimal day010;
protected decimal day011;
protected decimal day012;
protected decimal day013;
protected decimal day014;
protected decimal day015;
protected decimal day016;
protected decimal day017;
protected decimal day018;
protected decimal day019;
protected decimal day020;
protected decimal day021;
protected decimal day022;
protected decimal day023;
protected decimal day024;
protected decimal day025;
protected decimal day026;
protected decimal day027;
protected decimal day028;
protected decimal day029;
protected decimal day030;
protected decimal day031;
protected decimal day032;
protected decimal day033;
protected decimal day034;
protected decimal day035;
protected decimal day036;
protected decimal day037;
protected decimal day038;
protected decimal day039;
protected decimal day040;
protected decimal day041;
protected decimal day042;
protected decimal day043;
protected decimal day044;
protected decimal day045;
protected decimal day046;
protected decimal day047;
protected decimal day048;
protected decimal day049;
protected decimal day050;
protected decimal day051;
protected decimal day052;
protected decimal day053;
protected decimal day054;
protected decimal day055;
protected decimal day056;
protected decimal day057;
protected decimal day058;
protected decimal day059;
protected decimal day060;
protected decimal day061;
protected decimal day062;
protected decimal day063;
protected decimal day064;
protected decimal day065;
protected decimal day066;
protected decimal day067;
protected decimal day068;
protected decimal day069;
protected decimal day070;
protected decimal day071;
protected decimal day072;
protected decimal day073;
protected decimal day074;
protected decimal day075;
protected decimal day076;
protected decimal day077;
protected decimal day078;
protected decimal day079;
protected decimal day080;
protected decimal day081;
protected decimal day082;
protected decimal day083;
protected decimal day084;
protected decimal day085;
protected decimal day086;
protected decimal day087;
protected decimal day088;
protected decimal day089;
protected decimal day090;

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
HotListDays(){	
    this.pastDueDateSet = DateUtil.MinValue;
    this.pastDue = 0;
	this.day001 = 0;
	this.day002 = 0;
	this.day003 = 0;
	this.day004 = 0;
	this.day005 = 0;
	this.day006 = 0;
	this.day007 = 0;
	this.day008 = 0;
	this.day009 = 0;
	this.day010 = 0;
	this.day011 = 0;
	this.day012 = 0;
	this.day013 = 0;
	this.day014 = 0;
	this.day015 = 0;
	this.day016 = 0;
	this.day017 = 0;
	this.day018 = 0;
	this.day019 = 0;
	this.day020 = 0;
	this.day021 = 0;
	this.day022 = 0;
	this.day023 = 0;
	this.day024 = 0;
	this.day025 = 0;
	this.day026 = 0;
	this.day027 = 0;
	this.day028 = 0;
	this.day029 = 0;
	this.day030 = 0;
	this.day031 = 0;
	this.day032 = 0;
	this.day033 = 0;
	this.day034 = 0;
	this.day035 = 0;
	this.day036 = 0;
	this.day037 = 0;
	this.day038 = 0;
	this.day039 = 0;
	this.day040 = 0;
	this.day041 = 0;
	this.day042 = 0;
	this.day043 = 0;
	this.day044 = 0;
	this.day045 = 0;
	this.day046 = 0;
	this.day047 = 0;
	this.day048 = 0;
	this.day049 = 0;
	this.day050 = 0;
	this.day051 = 0;
	this.day052 = 0;
	this.day053 = 0;
	this.day054 = 0;
	this.day055 = 0;
	this.day056 = 0;
	this.day057 = 0;
	this.day058 = 0;
	this.day059 = 0;
	this.day060 = 0;
	this.day061 = 0;
	this.day062 = 0;
	this.day063 = 0;
	this.day064 = 0;
	this.day065 = 0;
	this.day066 = 0;
	this.day067 = 0;
	this.day068 = 0;
	this.day069 = 0;
	this.day070 = 0;
	this.day071 = 0;
	this.day072 = 0;
	this.day073 = 0;
	this.day074 = 0;
	this.day075 = 0;
	this.day076 = 0;
	this.day077 = 0;
	this.day078 = 0;
	this.day079 = 0;
	this.day080 = 0;
	this.day081 = 0;
	this.day082 = 0;
	this.day083 = 0;
	this.day084 = 0;
	this.day085 = 0;
	this.day086 = 0;
	this.day087 = 0;
	this.day088 = 0;
	this.day089 = 0;
	this.day090 = 0;	

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

internal
HotListDays(
	decimal pastDue,
	decimal day001,
	decimal day002,
	decimal day003,
	decimal day004,
	decimal day005,
	decimal day006,
	decimal day007,
	decimal day008,
	decimal day009,
	decimal day010,
	decimal day011,
	decimal day012,
	decimal day013,
	decimal day014,
	decimal day015,
	decimal day016,
	decimal day017,
	decimal day018,
	decimal day019,
	decimal day020,
	decimal day021,
	decimal day022,
	decimal day023,
	decimal day024,
	decimal day025,
	decimal day026,
	decimal day027,
	decimal day028,
	decimal day029,
	decimal day030,
	decimal day031,
	decimal day032,
	decimal day033,
	decimal day034,
	decimal day035,
	decimal day036,
	decimal day037,
	decimal day038,
	decimal day039,
	decimal day040,
	decimal day041,
	decimal day042,
	decimal day043,
	decimal day044,
	decimal day045,
	decimal day046,
	decimal day047,
	decimal day048,
	decimal day049,
	decimal day050,
	decimal day051,
	decimal day052,
	decimal day053,
	decimal day054,
	decimal day055,
	decimal day056,
	decimal day057,
	decimal day058,
	decimal day059,
	decimal day060,
	decimal day061,
	decimal day062,
	decimal day063,
	decimal day064,
	decimal day065,
	decimal day066,
	decimal day067,
	decimal day068,
	decimal day069,
	decimal day070,
	decimal day071,
	decimal day072,
	decimal day073,
	decimal day074,
	decimal day075,
	decimal day076,
	decimal day077,
	decimal day078,
	decimal day079,
	decimal day080,
	decimal day081,
	decimal day082,
	decimal day083,
	decimal day084,
	decimal day085,
	decimal day086,
	decimal day087,
	decimal day088,
	decimal day089,
	decimal day090){	
	this.pastDue = pastDue;
	this.day001 = day001;
	this.day002 = day002;
	this.day003 = day003;
	this.day004 = day004;
	this.day005 = day005;
	this.day006 = day006;
	this.day007 = day007;
	this.day008 = day008;
	this.day009 = day009;
	this.day010 = day010;
	this.day011 = day011;
	this.day012 = day012;
	this.day013 = day013;
	this.day014 = day014;
	this.day015 = day015;
	this.day016 = day016;
	this.day017 = day017;
	this.day018 = day018;
	this.day019 = day019;
	this.day020 = day020;
	this.day021 = day021;
	this.day022 = day022;
	this.day023 = day023;
	this.day024 = day024;
	this.day025 = day025;
	this.day026 = day026;
	this.day027 = day027;
	this.day028 = day028;
	this.day029 = day029;
	this.day030 = day030;
	this.day031 = day031;
	this.day032 = day032;
	this.day033 = day033;
	this.day034 = day034;
	this.day035 = day035;
	this.day036 = day036;
	this.day037 = day037;
	this.day038 = day038;
	this.day039 = day039;
	this.day040 = day040;
	this.day041 = day041;
	this.day042 = day042;
	this.day043 = day043;
	this.day044 = day044;
	this.day045 = day045;
	this.day046 = day046;
	this.day047 = day047;
	this.day048 = day048;
	this.day049 = day049;
	this.day050 = day050;
	this.day051 = day051;
	this.day052 = day052;
	this.day053 = day053;
	this.day054 = day054;
	this.day055 = day055;
	this.day056 = day056;
	this.day057 = day057;
	this.day058 = day058;
	this.day059 = day059;
	this.day060 = day060;
	this.day061 = day061;
	this.day062 = day062;
	this.day063 = day063;
	this.day064 = day064;
	this.day065 = day065;
	this.day066 = day066;
	this.day067 = day067;
	this.day068 = day068;
	this.day069 = day069;
	this.day070 = day070;
	this.day071 = day071;
	this.day072 = day072;
	this.day073 = day073;
	this.day074 = day074;
	this.day075 = day075;
	this.day076 = day076;
	this.day077 = day077;
	this.day078 = day078;
	this.day079 = day079;
	this.day080 = day080;
	this.day081 = day081;
	this.day082 = day082;
	this.day083 = day083;
	this.day084 = day084;
	this.day085 = day085;
	this.day086 = day086;
	this.day087 = day087;
	this.day088 = day088;
	this.day089 = day089;
	this.day090 = day090;	

    initBools();
}

[System.Runtime.Serialization.DataMember]
public
DateTime PastDueDateSet {
	get { return pastDueDateSet; }
	set { if (this.pastDueDateSet != value){
			this.pastDueDateSet = value;
			Notify("PastDueDateSet");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PastDue {
	get { return pastDue;}
	set { if (this.pastDue != value){
			this.pastDue = value;
			Notify("PastDue");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day001 {
	get { return day001;}
	set { if (this.day001 != value){
			this.day001 = value;
			Notify("Day001");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day002 {
	get { return day002;}
	set { if (this.day002 != value){
			this.day002 = value;
			Notify("Day002");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day003 {
	get { return day003;}
	set { if (this.day003 != value){
			this.day003 = value;
			Notify("Day003");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day004 {
	get { return day004;}
	set { if (this.day004 != value){
			this.day004 = value;
			Notify("Day004");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day005 {
	get { return day005;}
	set { if (this.day005 != value){
			this.day005 = value;
			Notify("Day005");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day006 {
	get { return day006;}
	set { if (this.day006 != value){
			this.day006 = value;
			Notify("Day006");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day007 {
	get { return day007;}
	set { if (this.day007 != value){
			this.day007 = value;
			Notify("Day007");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day008 {
	get { return day008;}
	set { if (this.day008 != value){
			this.day008 = value;
			Notify("Day008");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day009 {
	get { return day009;}
	set { if (this.day009 != value){
			this.day009 = value;
			Notify("Day009");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day010 {
	get { return day010;}
	set { if (this.day010 != value){
			this.day010 = value;
			Notify("Day010");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day011 {
	get { return day011;}
	set { if (this.day011 != value){
			this.day011 = value;
			Notify("Day011");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day012 {
	get { return day012;}
	set { if (this.day012 != value){
			this.day012 = value;
			Notify("Day012");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day013 {
	get { return day013;}
	set { if (this.day013 != value){
			this.day013 = value;
			Notify("Day013");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day014 {
	get { return day014;}
	set { if (this.day014 != value){
			this.day014 = value;
			Notify("Day014");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day015 {
	get { return day015;}
	set { if (this.day015 != value){
			this.day015 = value;
			Notify("Day015");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day016 {
	get { return day016;}
	set { if (this.day016 != value){
			this.day016 = value;
			Notify("Day016");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day017 {
	get { return day017;}
	set { if (this.day017 != value){
			this.day017 = value;
			Notify("Day017");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day018 {
	get { return day018;}
	set { if (this.day018 != value){
			this.day018 = value;
			Notify("Day018");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day019 {
	get { return day019;}
	set { if (this.day019 != value){
			this.day019 = value;
			Notify("Day019");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day020 {
	get { return day020;}
	set { if (this.day020 != value){
			this.day020 = value;
			Notify("Day020");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day021 {
	get { return day021;}
	set { if (this.day021 != value){
			this.day021 = value;
			Notify("Day021");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day022 {
	get { return day022;}
	set { if (this.day022 != value){
			this.day022 = value;
			Notify("Day022");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day023 {
	get { return day023;}
	set { if (this.day023 != value){
			this.day023 = value;
			Notify("Day023");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day024 {
	get { return day024;}
	set { if (this.day024 != value){
			this.day024 = value;
			Notify("Day024");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day025 {
	get { return day025;}
	set { if (this.day025 != value){
			this.day025 = value;
			Notify("Day025");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day026 {
	get { return day026;}
	set { if (this.day026 != value){
			this.day026 = value;
			Notify("Day026");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day027 {
	get { return day027;}
	set { if (this.day027 != value){
			this.day027 = value;
			Notify("Day027");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day028 {
	get { return day028;}
	set { if (this.day028 != value){
			this.day028 = value;
			Notify("Day028");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day029 {
	get { return day029;}
	set { if (this.day029 != value){
			this.day029 = value;
			Notify("Day029");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day030 {
	get { return day030;}
	set { if (this.day030 != value){
			this.day030 = value;
			Notify("Day030");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day031 {
	get { return day031;}
	set { if (this.day031 != value){
			this.day031 = value;
			Notify("Day031");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day032 {
	get { return day032;}
	set { if (this.day032 != value){
			this.day032 = value;
			Notify("Day032");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day033 {
	get { return day033;}
	set { if (this.day033 != value){
			this.day033 = value;
			Notify("Day033");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day034 {
	get { return day034;}
	set { if (this.day034 != value){
			this.day034 = value;
			Notify("Day034");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day035 {
	get { return day035;}
	set { if (this.day035 != value){
			this.day035 = value;
			Notify("Day035");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day036 {
	get { return day036;}
	set { if (this.day036 != value){
			this.day036 = value;
			Notify("Day036");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day037 {
	get { return day037;}
	set { if (this.day037 != value){
			this.day037 = value;
			Notify("Day037");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day038 {
	get { return day038;}
	set { if (this.day038 != value){
			this.day038 = value;
			Notify("Day038");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day039 {
	get { return day039;}
	set { if (this.day039 != value){
			this.day039 = value;
			Notify("Day039");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day040 {
	get { return day040;}
	set { if (this.day040 != value){
			this.day040 = value;
			Notify("Day040");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day041 {
	get { return day041;}
	set { if (this.day041 != value){
			this.day041 = value;
			Notify("Day041");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day042 {
	get { return day042;}
	set { if (this.day042 != value){
			this.day042 = value;
			Notify("Day042");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day043 {
	get { return day043;}
	set { if (this.day043 != value){
			this.day043 = value;
			Notify("Day043");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day044 {
	get { return day044;}
	set { if (this.day044 != value){
			this.day044 = value;
			Notify("Day044");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day045 {
	get { return day045;}
	set { if (this.day045 != value){
			this.day045 = value;
			Notify("Day045");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day046 {
	get { return day046;}
	set { if (this.day046 != value){
			this.day046 = value;
			Notify("Day046");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day047 {
	get { return day047;}
	set { if (this.day047 != value){
			this.day047 = value;
			Notify("Day047");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day048 {
	get { return day048;}
	set { if (this.day048 != value){
			this.day048 = value;
			Notify("Day048");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day049 {
	get { return day049;}
	set { if (this.day049 != value){
			this.day049 = value;
			Notify("Day049");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day050 {
	get { return day050;}
	set { if (this.day050 != value){
			this.day050 = value;
			Notify("Day050");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day051 {
	get { return day051;}
	set { if (this.day051 != value){
			this.day051 = value;
			Notify("Day051");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day052 {
	get { return day052;}
	set { if (this.day052 != value){
			this.day052 = value;
			Notify("Day052");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day053 {
	get { return day053;}
	set { if (this.day053 != value){
			this.day053 = value;
			Notify("Day053");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day054 {
	get { return day054;}
	set { if (this.day054 != value){
			this.day054 = value;
			Notify("Day054");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day055 {
	get { return day055;}
	set { if (this.day055 != value){
			this.day055 = value;
			Notify("Day055");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day056 {
	get { return day056;}
	set { if (this.day056 != value){
			this.day056 = value;
			Notify("Day056");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day057 {
	get { return day057;}
	set { if (this.day057 != value){
			this.day057 = value;
			Notify("Day057");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day058 {
	get { return day058;}
	set { if (this.day058 != value){
			this.day058 = value;
			Notify("Day058");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day059 {
	get { return day059;}
	set { if (this.day059 != value){
			this.day059 = value;
			Notify("Day059");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day060 {
	get { return day060;}
	set { if (this.day060 != value){
			this.day060 = value;
			Notify("Day060");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day061 {
	get { return day061;}
	set { if (this.day061 != value){
			this.day061 = value;
			Notify("Day061");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day062 {
	get { return day062;}
	set { if (this.day062 != value){
			this.day062 = value;
			Notify("Day062");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day063 {
	get { return day063;}
	set { if (this.day063 != value){
			this.day063 = value;
			Notify("Day063");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day064 {
	get { return day064;}
	set { if (this.day064 != value){
			this.day064 = value;
			Notify("Day064");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day065 {
	get { return day065;}
	set { if (this.day065 != value){
			this.day065 = value;
			Notify("Day065");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day066 {
	get { return day066;}
	set { if (this.day066 != value){
			this.day066 = value;
			Notify("Day066");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day067 {
	get { return day067;}
	set { if (this.day067 != value){
			this.day067 = value;
			Notify("Day067");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day068 {
	get { return day068;}
	set { if (this.day068 != value){
			this.day068 = value;
			Notify("Day068");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day069 {
	get { return day069;}
	set { if (this.day069 != value){
			this.day069 = value;
			Notify("Day069");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day070 {
	get { return day070;}
	set { if (this.day070 != value){
			this.day070 = value;
			Notify("Day070");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day071 {
	get { return day071;}
	set { if (this.day071 != value){
			this.day071 = value;
			Notify("Day071");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day072 {
	get { return day072;}
	set { if (this.day072 != value){
			this.day072 = value;
			Notify("Day072");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day073 {
	get { return day073;}
	set { if (this.day073 != value){
			this.day073 = value;
			Notify("Day073");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day074 {
	get { return day074;}
	set { if (this.day074 != value){
			this.day074 = value;
			Notify("Day074");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day075 {
	get { return day075;}
	set { if (this.day075 != value){
			this.day075 = value;
			Notify("Day075");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day076 {
	get { return day076;}
	set { if (this.day076 != value){
			this.day076 = value;
			Notify("Day076");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day077 {
	get { return day077;}
	set { if (this.day077 != value){
			this.day077 = value;
			Notify("Day077");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day078 {
	get { return day078;}
	set { if (this.day078 != value){
			this.day078 = value;
			Notify("Day078");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day079 {
	get { return day079;}
	set { if (this.day079 != value){
			this.day079 = value;
			Notify("Day079");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day080 {
	get { return day080;}
	set { if (this.day080 != value){
			this.day080 = value;
			Notify("Day080");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day081 {
	get { return day081;}
	set { if (this.day081 != value){
			this.day081 = value;
			Notify("Day081");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day082 {
	get { return day082;}
	set { if (this.day082 != value){
			this.day082 = value;
			Notify("Day082");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day083 {
	get { return day083;}
	set { if (this.day083 != value){
			this.day083 = value;
			Notify("Day083");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day084 {
	get { return day084;}
	set { if (this.day084 != value){
			this.day084 = value;
			Notify("Day084");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day085 {
	get { return day085;}
	set { if (this.day085 != value){
			this.day085 = value;
			Notify("Day085");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day086 {
	get { return day086;}
	set { if (this.day086 != value){
			this.day086 = value;
			Notify("Day086");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day087 {
	get { return day087;}
	set { if (this.day087 != value){
			this.day087 = value;
			Notify("Day087");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day088 {
	get { return day088;}
	set { if (this.day088 != value){
			this.day088 = value;
			Notify("Day088");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day089 {
	get { return day089;}
	set { if (this.day089 != value){
			this.day089 = value;
			Notify("Day089");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Day090 {
	get { return day090;}
	set { if (this.day090 != value){
			this.day090 = value;
			Notify("Day090");
		}
	}
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
decimal getQtyByDate(DateTime runDate,DateTime dateFilter){
    decimal dqty =0;

    if (dateFilter < DateUtil.minorHour(runDate))
        dqty = pastDue;
    else if (DateUtil.sameDate(dateFilter,runDate))
        dqty = day001;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        dqty = day002;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        dqty = day003;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        dqty = day004;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        dqty = day005;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        dqty = day006;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        dqty = day007;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        dqty = day008;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        dqty = day009;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        dqty = day010;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        dqty = day011;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        dqty = day012;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        dqty = day013;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        dqty = day014;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        dqty = day015;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        dqty = day016;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        dqty = day017;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        dqty = day018;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        dqty = day019;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        dqty = day020;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        dqty = day021;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        dqty = day022;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        dqty = day023;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        dqty = day024;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        dqty = day025;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        dqty = day026;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        dqty = day027;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        dqty = day028;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        dqty = day029;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        dqty = day030;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        dqty = day031;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        dqty = day032;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        dqty = day033;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        dqty = day034;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        dqty = day035;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        dqty = day036;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        dqty = day037;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        dqty = day038;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        dqty = day039;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        dqty = day040;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        dqty = day041;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        dqty = day042;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        dqty = day043;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        dqty = day044;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        dqty = day045;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        dqty = day046;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        dqty = day047;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        dqty = day048;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        dqty = day049;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        dqty = day050;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        dqty = day051;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        dqty = day052;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        dqty = day053;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        dqty = day054;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        dqty = day055;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        dqty = day056;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        dqty = day057;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        dqty = day058;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        dqty = day059;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        dqty = day060;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        dqty = day061;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        dqty = day062;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        dqty = day063;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        dqty = day064;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        dqty = day065;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        dqty = day066;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        dqty = day067;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        dqty = day068;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        dqty = day069;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        dqty = day070;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        dqty = day071;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        dqty = day072;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        dqty = day073;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        dqty = day074;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        dqty = day075;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        dqty = day076;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        dqty = day077;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        dqty = day078;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        dqty = day079;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        dqty = day080;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        dqty = day081;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        dqty = day082;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        dqty = day083;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        dqty = day084;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        dqty = day085;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        dqty = day086;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        dqty = day087;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        dqty = day088;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        dqty = day089;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        dqty = day090;

    return dqty;
}

public
void setQtyByDate(DateTime runDate,DateTime dateFilter,decimal dqty){
     
    if (dateFilter < DateUtil.minorHour(runDate)) { 
        pastDue = dqty;
        pastDueDateSet = dateFilter;
    }else if (DateUtil.sameDate(dateFilter,runDate))
        day001= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        day002= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        day003= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        day004= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        day005= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        day006= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        day007= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        day008= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        day009= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        day010= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        day011= dqty;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        day012= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        day013= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        day014= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        day015= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        day016= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        day017= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        day018= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        day019= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        day020= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        day021= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        day022= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        day023= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        day024= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        day025= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        day026= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        day027= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        day028= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        day029= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        day030= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        day031= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        day032= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        day033= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        day034= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        day035= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        day036= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        day037= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        day038= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        day039= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        day040= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        day041= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        day042= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        day043= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        day044= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        day045= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        day046= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        day047= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        day048= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        day049= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        day050= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        day051= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        day052= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        day053= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        day054= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        day055= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        day056= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        day057= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        day058= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        day059= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        day060= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        day061= dqty;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        day062= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        day063= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        day064= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        day065= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        day066= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        day067= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        day068= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        day069= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        day070= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        day071= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        day072= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        day073= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        day074= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        day075= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        day076= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        day077= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        day078= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        day079= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        day080= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        day081= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        day082= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        day083= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        day084= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        day085= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        day086= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        day087= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        day088= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        day089= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        day090= dqty;    
}

public
void setSummarizeQtyByDate(DateTime runDate,DateTime dateFilter,decimal dqty){
     
    if (dateFilter < DateUtil.minorHour(runDate))
        pastDue += dqty;
    else if (DateUtil.sameDate(dateFilter,runDate))
        day001+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        day002+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        day003+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        day004+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        day005+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        day006+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        day007+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        day008+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        day009+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        day010+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        day011+= dqty;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        day012+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        day013+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        day014+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        day015+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        day016+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        day017+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        day018+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        day019+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        day020+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        day021+= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        day022+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        day023+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        day024+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        day025+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        day026+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        day027+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        day028+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        day029+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        day030+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        day031+= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        day032+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        day033+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        day034+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        day035+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        day036+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        day037+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        day038+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        day039+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        day040+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        day041+= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        day042+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        day043+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        day044+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        day045+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        day046+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        day047+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        day048+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        day049+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        day050+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        day051+= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        day052+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        day053+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        day054+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        day055+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        day056+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        day057+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        day058+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        day059+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        day060+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        day061+= dqty;


    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        day062+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        day063+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        day064+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        day065+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        day066+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        day067+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        day068+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        day069+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        day070+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        day071+= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        day072+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        day073+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        day074+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        day075+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        day076+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        day077+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        day078+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        day079+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        day080+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        day081+= dqty;

    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        day082+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        day083+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        day084+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        day085+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        day086+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        day087+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        day088+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        day089+= dqty;
    else if (DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        day090+= dqty;    
}


public
decimal getQtyByRangeDate(DateTime runDate,DateTime startDate, DateTime endDate){
    decimal     dqty        =0;
    DateTime    date        = DateTime.Now;
    DateTime    runDateAux  = DateUtil.minorHour(runDate);
    DateTime    startDateAux= DateUtil.minorHour(startDate);
    DateTime    endDateAux  = DateUtil.highHour(endDate);
    int         idays       =0;

    date = startDateAux;
    if (runDateAux > startDateAux)
        startDateAux=date = runDateAux.AddDays(-1);//if not will get 'pastdue' value several times

    if  (endDateAux >= startDateAux){                
        do{
            dqty+= getQtyByDate(runDate,date);
            idays++;
            date = startDateAux.AddDays(idays);
        }while(date <= endDateAux);      
    }
    return dqty;
}

public
void calculateNonCumulative(){
    //quantities
    decimal pastDue= PastDue;
    decimal day001 = Day001 - PastDue;
    decimal day002 = Day002 - Day001;
    decimal day003 = Day003 - Day002;
    decimal day004 = Day004 - Day003;
    decimal day005 = Day005 - Day004;
    decimal day006 = Day006 - Day005;
    decimal day007 = Day007 - Day006;
    decimal day008 = Day008 - Day007;
    decimal day009 = Day009 - Day008;
    decimal day010 = Day010 - Day009;
    decimal day011 = Day011 - Day010;
    decimal day012 = Day012 - Day011;
    decimal day013 = Day013 - Day012;
    decimal day014 = Day014 - Day013;
    decimal day015 = Day015 - Day014;

    decimal day016 = Day016 - Day015;
    decimal day017 = Day017 - Day016;
    decimal day018 = Day018 - Day017;
    decimal day019 = Day019 - Day018;
    decimal day020 = Day020 - Day019;
    decimal day021 = Day021 - Day020;
    decimal day022 = Day022 - Day021;
    decimal day023 = Day023 - Day022;
    decimal day024 = Day024 - Day023;
    decimal day025 = Day025 - Day024;
    decimal day026 = Day026 - Day025;
    decimal day027 = Day027 - Day026;
    decimal day028 = Day028 - Day027;
    decimal day029 = Day029 - Day028;
    decimal day030 = Day030 - Day029;

    decimal day031 = Day031 - Day030;
    decimal day032 = Day032 - Day031;
    decimal day033 = Day033 - Day032;
    decimal day034 = Day034 - Day033;
    decimal day035 = Day035 - Day034;
    decimal day036 = Day036 - Day035;
    decimal day037 = Day037 - Day036;
    decimal day038 = Day038 - Day037;
    decimal day039 = Day039 - Day038;
    decimal day040 = Day040 - Day039;
    decimal day041 = Day041 - Day040;
    decimal day042 = Day042 - Day041;
    decimal day043 = Day043 - Day042;
    decimal day044 = Day044 - Day043;
    decimal day045 = Day045 - Day044;

    decimal day046 = Day046 - Day045;
    decimal day047 = Day047 - Day046;
    decimal day048 = Day048 - Day047;
    decimal day049 = Day049 - Day048;
    decimal day050 = Day050 - Day049;
    decimal day051 = Day051 - Day050;
    decimal day052 = Day052 - Day051;
    decimal day053 = Day053 - Day052;
    decimal day054 = Day054 - Day053;
    decimal day055 = Day055 - Day054;
    decimal day056 = Day056 - Day055;
    decimal day057 = Day057 - Day056;
    decimal day058 = Day058 - Day057;
    decimal day059 = Day059 - Day058;
    decimal day060 = Day060 - Day059;

    //AF 061 to 090
    decimal day061 = Day061 - Day060;
    decimal day062 = Day062 - Day061;
    decimal day063 = Day063 - Day062;
    decimal day064 = Day064 - Day063;
    decimal day065 = Day065 - Day064;
    decimal day066 = Day066 - Day065;
    decimal day067 = Day067 - Day066;
    decimal day068 = Day068 - Day067;
    decimal day069 = Day069 - Day068;
    decimal day070 = Day070 - Day069;

    decimal day071 = Day071 - Day070;
    decimal day072 = Day072 - Day071;
    decimal day073 = Day073 - Day072;
    decimal day074 = Day074 - Day073;
    decimal day075 = Day075 - Day074;
    decimal day076 = Day076 - Day075;
    decimal day077 = Day077 - Day076;
    decimal day078 = Day078 - Day077;
    decimal day079 = Day079 - Day078;
    decimal day080 = Day080 - Day079;

    decimal day081 = Day081 - Day080;
    decimal day082 = Day082 - Day081;
    decimal day083 = Day083 - Day082;
    decimal day084 = Day084 - Day083;
    decimal day085 = Day085 - Day084;
    decimal day086 = Day086 - Day085;
    decimal day087 = Day087 - Day086;
    decimal day088 = Day088 - Day087;
    decimal day089 = Day089 - Day088;
    decimal day090 = Day090 - Day089;

    this.pastDue = pastDue;
    this.day001 = day001;
    this.day002 = day002;
    this.day003 = day003;
    this.day004 = day004;
    this.day005 = day005;
    this.day006 = day006;
    this.day007 = day007;
    this.day008 = day008;
    this.day009 = day009;
    this.day010 = day010;

    this.day011 = day011;
    this.day012 = day012;
    this.day013 = day013;
    this.day014 = day014;
    this.day015 = day015;
    this.day016 = day016;
    this.day017 = day017;
    this.day018 = day018;
    this.day019 = day019;
    this.day020 = day020;

    this.day021 = day021;
    this.day022 = day022;
    this.day023 = day023;
    this.day024 = day024;
    this.day025 = day025;
    this.day026 = day026;
    this.day027 = day027;
    this.day028 = day028;
    this.day029 = day029;
    this.day030 = day030;

    this.day031 = day031;
    this.day032 = day032;
    this.day033 = day033;
    this.day034 = day034;
    this.day035 = day035;
    this.day036 = day036;
    this.day037 = day037;
    this.day038 = day038;
    this.day039 = day039;
    this.day040 = day040;
        
    this.day041 = day041;
    this.day042 = day042;
    this.day043 = day043;
    this.day044 = day044;
    this.day045 = day045;
    this.day046 = day046;
    this.day047 = day047;
    this.day048 = day048;
    this.day049 = day049;
    this.day050 = day050;
    
    this.day051 = day051;
    this.day052 = day052;
    this.day053 = day053;
    this.day054 = day054;
    this.day055 = day055;
    this.day056 = day056;
    this.day057 = day057;
    this.day058 = day058;
    this.day059 = day059;
    this.day060 = day060;

    this.day061 = day061;
    this.day062 = day062;
    this.day063 = day063;
    this.day064 = day064;
    this.day065 = day065;
    this.day066 = day066;
    this.day067 = day067;
    this.day068 = day068;
    this.day069 = day069;
    this.day070 = day070;

    this.day071 = day071;
    this.day072 = day072;
    this.day073 = day073;
    this.day074 = day074;
    this.day075 = day075;
    this.day076 = day076;
    this.day077 = day077;
    this.day078 = day078;
    this.day079 = day079;
    this.day080 = day080;

    this.day081 = day081;
    this.day082 = day082;
    this.day083 = day083;
    this.day084 = day084;
    this.day085 = day085;
    this.day086 = day086;
    this.day087 = day087;
    this.day088 = day088;
    this.day089 = day089;
    this.day090 = day090;    
}

public
void copy(HotListDays hotListDays){	
	this.PastDue=hotListDays.PastDue;
	this.Day001=hotListDays.Day001;
	this.Day002=hotListDays.Day002;
	this.Day003=hotListDays.Day003;
	this.Day004=hotListDays.Day004;
	this.Day005=hotListDays.Day005;
	this.Day006=hotListDays.Day006;
	this.Day007=hotListDays.Day007;
	this.Day008=hotListDays.Day008;
	this.Day009=hotListDays.Day009;
	this.Day010=hotListDays.Day010;
	this.Day011=hotListDays.Day011;
	this.Day012=hotListDays.Day012;
	this.Day013=hotListDays.Day013;
	this.Day014=hotListDays.Day014;
	this.Day015=hotListDays.Day015;
	this.Day016=hotListDays.Day016;
	this.Day017=hotListDays.Day017;
	this.Day018=hotListDays.Day018;
	this.Day019=hotListDays.Day019;
	this.Day020=hotListDays.Day020;
	this.Day021=hotListDays.Day021;
	this.Day022=hotListDays.Day022;
	this.Day023=hotListDays.Day023;
	this.Day024=hotListDays.Day024;
	this.Day025=hotListDays.Day025;
	this.Day026=hotListDays.Day026;
	this.Day027=hotListDays.Day027;
	this.Day028=hotListDays.Day028;
	this.Day029=hotListDays.Day029;
	this.Day030=hotListDays.Day030;
	this.Day031=hotListDays.Day031;
	this.Day032=hotListDays.Day032;
	this.Day033=hotListDays.Day033;
	this.Day034=hotListDays.Day034;
	this.Day035=hotListDays.Day035;
	this.Day036=hotListDays.Day036;
	this.Day037=hotListDays.Day037;
	this.Day038=hotListDays.Day038;
	this.Day039=hotListDays.Day039;
	this.Day040=hotListDays.Day040;
	this.Day041=hotListDays.Day041;
	this.Day042=hotListDays.Day042;
	this.Day043=hotListDays.Day043;
	this.Day044=hotListDays.Day044;
	this.Day045=hotListDays.Day045;
	this.Day046=hotListDays.Day046;
	this.Day047=hotListDays.Day047;
	this.Day048=hotListDays.Day048;
	this.Day049=hotListDays.Day049;
	this.Day050=hotListDays.Day050;
	this.Day051=hotListDays.Day051;
	this.Day052=hotListDays.Day052;
	this.Day053=hotListDays.Day053;
	this.Day054=hotListDays.Day054;
	this.Day055=hotListDays.Day055;
	this.Day056=hotListDays.Day056;
	this.Day057=hotListDays.Day057;
	this.Day058=hotListDays.Day058;
	this.Day059=hotListDays.Day059;
	this.Day060=hotListDays.Day060;
	this.Day061=hotListDays.Day061;
	this.Day062=hotListDays.Day062;
	this.Day063=hotListDays.Day063;
	this.Day064=hotListDays.Day064;
	this.Day065=hotListDays.Day065;
	this.Day066=hotListDays.Day066;
	this.Day067=hotListDays.Day067;
	this.Day068=hotListDays.Day068;
	this.Day069=hotListDays.Day069;
	this.Day070=hotListDays.Day070;
	this.Day071=hotListDays.Day071;
	this.Day072=hotListDays.Day072;
	this.Day073=hotListDays.Day073;
	this.Day074=hotListDays.Day074;
	this.Day075=hotListDays.Day075;
	this.Day076=hotListDays.Day076;
	this.Day077=hotListDays.Day077;
	this.Day078=hotListDays.Day078;
	this.Day079=hotListDays.Day079;
	this.Day080=hotListDays.Day080;
	this.Day081=hotListDays.Day081;
	this.Day082=hotListDays.Day082;
	this.Day083=hotListDays.Day083;
	this.Day084=hotListDays.Day084;
	this.Day085=hotListDays.Day085;
	this.Day086=hotListDays.Day086;
	this.Day087=hotListDays.Day087;
	this.Day088=hotListDays.Day088;
	this.Day089=hotListDays.Day089;
	this.Day090=hotListDays.Day090;
            
    base.copy(hotListDays);            	
}

public
void calculateNonCumulativeWeekly(DateTime runDate,ArrayList arrayFieldList){
    decimal     dqty    = 0;
    decimal     dqtyCurrent =0 ;    
    string      sfieldName= "";        
    DateTime    currenDate = runDate;

    for (int i=0; i < arrayFieldList.Count; i++){
        sfieldName = (string) arrayFieldList[i];
        sfieldName = sfieldName.Replace("HOT_","");
           
        dqtyCurrent = getQtyByFieldName(sfieldName);
        dqtyCurrent-= dqty;
        dqty+= dqtyCurrent;
     
        if (sfieldName.Length > 3) { 
            string  sqty = sfieldName.Substring(sfieldName.Length-3);
            int     idays= 0;

            if (sfieldName.ToUpper().Equals("PastDue".ToUpper()))
                idays = -1;
            else 
                idays= Convert.ToInt32(sqty);
            
            currenDate = runDate.AddDays( (idays-1));
            setQtyByDate(runDate,currenDate, dqtyCurrent);                
        }
    }

}

public
string getFieldNameByDate(DateTime runDate,DateTime dateFilter){
    string sfieldName ="";

    if (dateFilter < DateUtil.minorHour(runDate))
        sfieldName = "PastDue";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate))
        sfieldName = "Day001";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        sfieldName = "Day002";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        sfieldName = "Day003";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        sfieldName = "Day004";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        sfieldName = "Day005";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        sfieldName = "Day006";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        sfieldName = "Day007";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        sfieldName = "Day008";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        sfieldName = "Day009";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        sfieldName = "Day010";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        sfieldName = "Day011";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        sfieldName = "Day012";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        sfieldName = "Day013";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        sfieldName = "Day014";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        sfieldName = "Day015";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        sfieldName = "Day016";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        sfieldName = "Day017";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        sfieldName = "Day018";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        sfieldName = "Day019";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        sfieldName = "Day020";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        sfieldName = "Day021";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        sfieldName = "Day022";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        sfieldName = "Day023";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        sfieldName = "Day024";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        sfieldName = "Day025";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        sfieldName = "Day026";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        sfieldName = "Day027";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        sfieldName = "Day028";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        sfieldName = "Day029";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        sfieldName = "Day030";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        sfieldName = "Day031";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        sfieldName = "Day032";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        sfieldName = "Day033";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        sfieldName = "Day034";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        sfieldName = "Day035";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        sfieldName = "Day036";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        sfieldName = "Day037";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        sfieldName = "Day038";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        sfieldName = "Day039";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        sfieldName = "Day040";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        sfieldName = "Day041";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        sfieldName = "Day042";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        sfieldName = "Day043";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        sfieldName = "Day044";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        sfieldName = "Day045";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        sfieldName = "Day046";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        sfieldName = "Day047";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        sfieldName = "Day048";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        sfieldName = "Day049";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        sfieldName = "Day050";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        sfieldName = "Day051";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        sfieldName = "Day052";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        sfieldName = "Day053";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        sfieldName = "Day054";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        sfieldName = "Day055";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        sfieldName = "Day056";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        sfieldName = "Day057";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        sfieldName = "Day058";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        sfieldName = "Day059";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        sfieldName = "Day060";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        sfieldName = "Day061";


    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        sfieldName = "Day062";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        sfieldName = "Day063";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        sfieldName = "Day064";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        sfieldName = "Day065";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        sfieldName = "Day066";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        sfieldName = "Day067";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        sfieldName = "Day068";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        sfieldName = "Day069";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        sfieldName = "Day070";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        sfieldName = "Day071";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        sfieldName = "Day072";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        sfieldName = "Day073";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        sfieldName = "Day074";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        sfieldName = "Day075";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        sfieldName = "Day076";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        sfieldName = "Day077";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        sfieldName = "Day078";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        sfieldName = "Day079";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        sfieldName = "Day080";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        sfieldName = "Day081";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        sfieldName = "Day082";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        sfieldName = "Day083";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        sfieldName = "Day084";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        sfieldName = "Day085";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        sfieldName = "Day086";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        sfieldName = "Day087";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        sfieldName = "Day088";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        sfieldName = "Day089";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        sfieldName = "Day090";

    return sfieldName;
}

public
decimal getQtyByFieldName(string sfieldName){
    decimal dqty=0;
        
    switch (sfieldName){
        case "PastDue": dqty =PastDue;break;
        case "Day001" : dqty =Day001;break;
        case "Day002" : dqty =Day002;break;
        case "Day003" : dqty =Day003;break;
        case "Day004" : dqty =Day004;break;
        case "Day005" : dqty =Day005;break;
        case "Day006" : dqty =Day006;break;
        case "Day007" : dqty =Day007;break;
        case "Day008" : dqty =Day008;break;
        case "Day009" : dqty =Day009;break;
        case "Day010" : dqty =Day010;break;

        case "Day011" : dqty =Day011;break;
        case "Day012" : dqty =Day012;break;
        case "Day013" : dqty =Day013;break;
        case "Day014" : dqty =Day014;break;
        case "Day015" : dqty =Day015;break;
        case "Day016" : dqty =Day016;break;
        case "Day017" : dqty =Day017;break;
        case "Day018" : dqty =Day018;break;
        case "Day019" : dqty =Day019;break;
        case "Day020" : dqty =Day020;break;

        case "Day021" : dqty =Day021;break;
        case "Day022" : dqty =Day022;break;
        case "Day023" : dqty =Day023;break;
        case "Day024" : dqty =Day024;break;
        case "Day025" : dqty =Day025;break;
        case "Day026" : dqty =Day026;break;
        case "Day027" : dqty =Day027;break;
        case "Day028" : dqty =Day028;break;
        case "Day029" : dqty =Day029;break;
        case "Day030" : dqty =Day030;break;

        case "Day031" : dqty =Day031;break;
        case "Day032" : dqty =Day032;break;
        case "Day033" : dqty =Day033;break;
        case "Day034" : dqty =Day034;break;
        case "Day035" : dqty =Day035;break;
        case "Day036" : dqty =Day036;break;
        case "Day037" : dqty =Day037;break;
        case "Day038" : dqty =Day038;break;
        case "Day039" : dqty =Day039;break;
        case "Day040" : dqty =Day040;break;

        case "Day041" : dqty =Day041;break;
        case "Day042" : dqty =Day042;break;
        case "Day043" : dqty =Day043;break;
        case "Day044" : dqty =Day044;break;
        case "Day045" : dqty =Day045;break;
        case "Day046" : dqty =Day046;break;
        case "Day047" : dqty =Day047;break;
        case "Day048" : dqty =Day048;break;
        case "Day049" : dqty =Day049;break;
        case "Day050" : dqty =Day050;break;

        case "Day051" : dqty =Day051;break;
        case "Day052" : dqty =Day052;break;
        case "Day053" : dqty =Day053;break;
        case "Day054" : dqty =Day054;break;
        case "Day055" : dqty =Day055;break;
        case "Day056" : dqty =Day056;break;
        case "Day057" : dqty =Day057;break;
        case "Day058" : dqty =Day058;break;
        case "Day059" : dqty =Day059;break;
        case "Day060" : dqty =Day060;break;
    
        case "Day061" : dqty =Day061;break;
        case "Day062" : dqty =Day062;break;
        case "Day063" : dqty =Day063;break;
        case "Day064" : dqty =Day064;break;
        case "Day065" : dqty =Day065;break;
        case "Day066" : dqty =Day066;break;
        case "Day067" : dqty =Day067;break;
        case "Day068" : dqty =Day068;break;
        case "Day069" : dqty =Day069;break;
        case "Day070" : dqty =Day070;break;

        case "Day071" : dqty =Day071;break;
        case "Day072" : dqty =Day072;break;
        case "Day073" : dqty =Day073;break;
        case "Day074" : dqty =Day074;break;
        case "Day075" : dqty =Day075;break;
        case "Day076" : dqty =Day076;break;
        case "Day077" : dqty =Day077;break;
        case "Day078" : dqty =Day078;break;
        case "Day079" : dqty =Day079;break;
        case "Day080" : dqty =Day080;break;

        case "Day081" : dqty =Day081;break;
        case "Day082" : dqty =Day082;break;
        case "Day083" : dqty =Day083;break;
        case "Day084" : dqty =Day084;break;
        case "Day085" : dqty =Day085;break;
        case "Day086" : dqty =Day086;break;
        case "Day087" : dqty =Day087;break;
        case "Day088" : dqty =Day088;break;
        case "Day089" : dqty =Day089;break;
        case "Day090" : dqty =Day090;break;                                        
    }
    return dqty;
}

public
void setQtyByFieldName(string sfieldName,decimal dqty){                        

    switch (sfieldName){
        case "PastDue": PastDue=dqty;break;
        case "Day001" : Day001=dqty ;break;
        case "Day002" : Day002=dqty ;break;
        case "Day003" : Day003=dqty ;break;
        case "Day004" : Day004=dqty ;break;
        case "Day005" : Day005=dqty ;break;
        case "Day006" : Day006=dqty ;break;
        case "Day007" : Day007=dqty ;break;
        case "Day008" : Day008=dqty ;break;
        case "Day009" : Day009=dqty ;break;
        case "Day010" : Day010=dqty ;break;

        case "Day011" : Day011=dqty;break;
        case "Day012" : Day012=dqty;break;
        case "Day013" : Day013=dqty;break;
        case "Day014" : Day014=dqty;break;
        case "Day015" : Day015=dqty;break;
        case "Day016" : Day016=dqty;break;
        case "Day017" : Day017=dqty;break;
        case "Day018" : Day018=dqty;break;
        case "Day019" : Day019=dqty;break;
        case "Day020" : Day020=dqty;break;

        case "Day021" : Day021=dqty;break;
        case "Day022" : Day022=dqty;break;
        case "Day023" : Day023=dqty;break;
        case "Day024" : Day024=dqty;break;
        case "Day025" : Day025=dqty;break;
        case "Day026" : Day026=dqty;break;
        case "Day027" : Day027=dqty;break;
        case "Day028" : Day028=dqty;break;
        case "Day029" : Day029=dqty;break;
        case "Day030" : Day030=dqty;break;

        case "Day031" : Day031=dqty;break;
        case "Day032" : Day032=dqty;break;
        case "Day033" : Day033=dqty;break;
        case "Day034" : Day034=dqty;break;
        case "Day035" : Day035=dqty;break;
        case "Day036" : Day036=dqty;break;
        case "Day037" : Day037=dqty;break;
        case "Day038" : Day038=dqty;break;
        case "Day039" : Day039=dqty;break;
        case "Day040" : Day040=dqty;break;

        case "Day041" : Day041=dqty;break;
        case "Day042" : Day042=dqty;break;
        case "Day043" : Day043=dqty;break;
        case "Day044" : Day044=dqty;break;
        case "Day045" : Day045=dqty;break;
        case "Day046" : Day046=dqty;break;
        case "Day047" : Day047=dqty;break;
        case "Day048" : Day048=dqty;break;
        case "Day049" : Day049=dqty;break;
        case "Day050" : Day050=dqty;break;

        case "Day051" : Day051=dqty;break;
        case "Day052" : Day052=dqty;break;
        case "Day053" : Day053=dqty;break;
        case "Day054" : Day054=dqty;break;
        case "Day055" : Day055=dqty;break;
        case "Day056" : Day056=dqty;break;
        case "Day057" : Day057=dqty;break;
        case "Day058" : Day058=dqty;break;
        case "Day059" : Day059=dqty;break;
        case "Day060" : Day060=dqty;break;
    
        case "Day061" : Day061=dqty;break;
        case "Day062" : Day062=dqty;break;
        case "Day063" : Day063=dqty;break;
        case "Day064" : Day064=dqty;break;
        case "Day065" : Day065=dqty;break;
        case "Day066" : Day066=dqty;break;
        case "Day067" : Day067=dqty;break;
        case "Day068" : Day068=dqty;break;
        case "Day069" : Day069=dqty;break;
        case "Day070" : Day070=dqty;break;

        case "Day071" : Day071=dqty;break;
        case "Day072" : Day072=dqty;break;
        case "Day073" : Day073=dqty;break;
        case "Day074" : Day074=dqty;break;
        case "Day075" : Day075=dqty;break;
        case "Day076" : Day076=dqty;break;
        case "Day077" : Day077=dqty;break;
        case "Day078" : Day078=dqty;break;
        case "Day079" : Day079=dqty;break;
        case "Day080" : Day080=dqty;break;

        case "Day081" : Day081=dqty;break;
        case "Day082" : Day082=dqty;break;
        case "Day083" : Day083=dqty;break;
        case "Day084" : Day084=dqty;break;
        case "Day085" : Day085=dqty;break;
        case "Day086" : Day086=dqty;break;
        case "Day087" : Day087=dqty;break;
        case "Day088" : Day088=dqty;break;
        case "Day089" : Day089=dqty;break;
        case "Day090" : Day090=dqty;break;
    }    
}

/*
public
System.Collections.Generic.Dictionary<int, decimal> getQtyDatesNonZero(){
            // Hashtable   hashtable = new Hashtable();
   System.Collections.Generic.Dictionary<int,decimal> hashtable = new System.Collections.Generic.Dictionary<int, decimal>();            

//   System.Collections.Generic.List<KeyValuePair<string, string>> hashtable

   if (pastDue!= 0)
        hashtable.Add(0,pastDue);//Pastue on index=0
   if (day001!=0)
        hashtable.Add(1,day001);
   if (day002!= 0)
        hashtable.Add(2,day002);
   if (day003!= 0)
        hashtable.Add(3,day003);
   if (day004!= 0)
        hashtable.Add(4,day004);
   if (day005!= 0)
        hashtable.Add(5,day005);
   if (day006!= 0)
        hashtable.Add(6,day006);
   if (day007!= 0)
        hashtable.Add(7,day007);
   if (day008!= 0)
        hashtable.Add(8,day008);
   if (day009!= 0)
        hashtable.Add(9,day009);
   if (day010!= 0)
        hashtable.Add(10,day010);
		
   if (day011!= 0)
        hashtable.Add(11,day011);
   if (day012!= 0)
        hashtable.Add(12,day012);
   if (day013!= 0)
        hashtable.Add(13,day013);
   if (day014!= 0)
        hashtable.Add(14,day014);
   if (day015!= 0)
        hashtable.Add(15,day015);
   if (day016!= 0)
        hashtable.Add(16,day016);
   if (day017!= 0)
        hashtable.Add(17,day017);
   if (day018!= 0)
        hashtable.Add(18,day018);
   if (day019!= 0)
        hashtable.Add(19,day019);

   if (day020!= 0)
        hashtable.Add(20,day020);		
   if (day021!= 0)
        hashtable.Add(21,day021);
   if (day022!= 0)
        hashtable.Add(22,day022);
   if (day023!= 0)
        hashtable.Add(23,day023);
   if (day024!= 0)
        hashtable.Add(24,day024);
   if (day025!= 0)
        hashtable.Add(25,day025);
   if (day026!= 0)
        hashtable.Add(26,day026);
   if (day027!= 0)
        hashtable.Add(27,day027);
   if (day028!= 0)
        hashtable.Add(28,day028);
   if (day029!= 0)
        hashtable.Add(29,day029);

   if (day030!= 0)
        hashtable.Add(30,day030);		
   if (day031!= 0)
        hashtable.Add(31,day031);
   if (day032!= 0)
        hashtable.Add(32,day032);
   if (day033!= 0)
        hashtable.Add(33,day033);
   if (day034!= 0)
        hashtable.Add(34,day034);
   if (day035!= 0)
        hashtable.Add(35,day035);
   if (day036!= 0)
        hashtable.Add(36,day036);
   if (day037!= 0)
        hashtable.Add(37,day037);
   if (day038!= 0)
        hashtable.Add(38,day038);
   if (day039!= 0)
        hashtable.Add(39,day039);

    if (day040!= 0)
        hashtable.Add(40,day040);		
    if (day041!= 0)
        hashtable.Add(41,day041);
    if (day042!= 0)
        hashtable.Add(42,day042);
    if (day043!= 0)
        hashtable.Add(43,day043);
    if (day044!= 0)
        hashtable.Add(44,day044);
    if (day045!= 0)
        hashtable.Add(45,day045);
    if (day046!= 0)
        hashtable.Add(46,day046);
    if (day047!= 0)
        hashtable.Add(47,day047);
    if (day048!= 0)
        hashtable.Add(48,day048);
    if (day049!= 0)
        hashtable.Add(49,day049);

    if (day050!= 0)
        hashtable.Add(50,day050);		
    if (day051!= 0)
        hashtable.Add(51,day051);
    if (day052!= 0)
        hashtable.Add(52,day052);
    if (day053!= 0)
        hashtable.Add(53,day053);
    if (day054!= 0)
        hashtable.Add(54,day054);
    if (day055!= 0)
        hashtable.Add(55,day055);
    if (day056!= 0)
        hashtable.Add(56,day056);
    if (day057!= 0)
        hashtable.Add(57,day057);
    if (day058!= 0)
        hashtable.Add(58,day058);
    if (day059!= 0)
        hashtable.Add(59,day059);

    if (day060!= 0)
        hashtable.Add(60,day060);		
    if (day061!= 0)
        hashtable.Add(61,day061);
    if (day062!= 0)
        hashtable.Add(62,day062);
    if (day063!= 0)
        hashtable.Add(63,day063);
    if (day064!= 0)
        hashtable.Add(64,day064);
    if (day065!= 0)
        hashtable.Add(65,day065);
    if (day066!= 0)
        hashtable.Add(66,day066);
    if (day067!= 0)
        hashtable.Add(67,day067);
    if (day068!= 0)
        hashtable.Add(68,day068);
    if (day069!= 0)
        hashtable.Add(69,day069);

    if (day070!= 0)
        hashtable.Add(70,day070);		
    if (day071!= 0)
        hashtable.Add(71,day071);
    if (day072!= 0)
        hashtable.Add(72,day072);
    if (day073!= 0)
        hashtable.Add(73,day073);
    if (day074!= 0)
        hashtable.Add(74,day074);
    if (day075!= 0)
        hashtable.Add(75,day075);
    if (day076 != 0)
        hashtable.Add(76,day076);
    if (day077!= 0)
        hashtable.Add(77,day077);
    if (day078!= 0)
        hashtable.Add(78,day078);
    if (day079!= 0)
        hashtable.Add(79,day079);

    if (day080!= 0)
        hashtable.Add(80,day080);		
    if (day081!= 0)
        hashtable.Add(81,day081);
    if (day082!= 0)
        hashtable.Add(82,day082);
    if (day083!= 0)
        hashtable.Add(83,day083);
    if (day084!= 0)
        hashtable.Add(84,day084);
    if (day085!= 0)
        hashtable.Add(85,day085);
    if (day086!= 0)
        hashtable.Add(86,day086);
    if (day087!= 0)
        hashtable.Add(87,day087);
    if (day088!= 0)
        hashtable.Add(88,day088);
    if (day089!= 0)
        hashtable.Add(89,day089);
    if (day090!= 0)
        hashtable.Add(90,day090);

    return hashtable;
}
*/

public
HotListDayContainer getQtyDatesNonZero(DateTime runDate){            
   HotListDayContainer arrayList = new HotListDayContainer();

   if (pastDue!= 0)        
		arrayList.Add(new HotListDay(runDate.AddDays(-1),pastDue));//Pastue on index=0   
   if (day001!=0)
        arrayList.Add(new HotListDay(runDate.AddDays(0),day001));
   if (day002!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(1),day002));
   if (day003!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(2),day003));
   if (day004!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(3),day004));
   if (day005!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(4),day005));
   if (day006!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(5),day006));
   if (day007!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(6),day007));
   if (day008!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(7),day008));
   if (day009!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(8),day009));
   if (day010!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(9),day010));
		
   if (day011!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(10),day011));
   if (day012!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(11),day012));
   if (day013!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(12),day013));
   if (day014!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(13),day014));
   if (day015!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(14),day015));
   if (day016!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(15),day016));
   if (day017!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(16),day017));
   if (day018!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(17),day018));
   if (day019!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(18),day019));
   if (day020!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(19),day020));		

   if (day021!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(20),day021));
   if (day022!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(21),day022));
   if (day023!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(22),day023));
   if (day024!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(23),day024));
   if (day025!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(24),day025));
   if (day026!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(25),day026));
   if (day027!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(26),day027));
   if (day028!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(27),day028));
   if (day029!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(28),day029));
   if (day030!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(29),day030));
   		
   if (day031!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(30),day031));
   if (day032!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(31),day032));
   if (day033!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(32),day033));
   if (day034!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(33),day034));
   if (day035!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(34),day035));
   if (day036!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(35),day036));
   if (day037!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(36),day037));
   if (day038!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(37),day038));
   if (day039!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(38),day039));
    if (day040!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(39),day040));
    		
    if (day041!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(40),day041));
    if (day042!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(41),day042));
    if (day043!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(42),day043));
    if (day044!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(43),day044));
    if (day045!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(44),day045));
    if (day046!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(45),day046));
    if (day047!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(46),day047));
    if (day048!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(47),day048));
    if (day049!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(48),day049));
    if (day050!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(49),day050));
    		
    if (day051!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(50),day051));
    if (day052!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(51),day052));
    if (day053!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(52),day053));
    if (day054!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(53),day054));
    if (day055!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(54),day055));
    if (day056!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(55),day056));
    if (day057!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(56),day057));
    if (day058!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(57),day058));
    if (day059!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(58),day059));
    if (day060!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(59),day060));
    		
    if (day061!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(60),day061));
    if (day062!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(61),day062));
    if (day063!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(62),day063));
    if (day064!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(63),day064));
    if (day065!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(64),day065));
    if (day066!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(65),day066));
    if (day067!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(66),day067));
    if (day068!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(67),day068));
    if (day069!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(68),day069));
    if (day070!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(69),day070));
    		
    if (day071!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(70),day071));
    if (day072!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(71),day072));
    if (day073!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(72),day073));
    if (day074!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(73),day074));
    if (day075!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(74),day075));
    if (day076 != 0)
        arrayList.Add(new HotListDay(runDate.AddDays(75),day076));
    if (day077!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(76),day077));
    if (day078!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(77),day078));
    if (day079!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(78),day079));
    if (day080!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(79),day080));    		
    if (day081!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(80),day081));

    if (day082!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(81),day082));
    if (day083!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(82),day083));
    if (day084!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(83),day084));
    if (day085!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(84),day085));
    if (day086!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(85),day086));
    if (day087!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(86),day087));
    if (day088!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(87),day088));
    if (day089!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(88),day089));
    if (day090!= 0)
        arrayList.Add(new HotListDay(runDate.AddDays(89),day090));
        
    return arrayList;
}

public
HotListDayContainer getQtyDates(DateTime runDate){            
    HotListDayContainer arrayList = new HotListDayContainer();

    arrayList.Add(new HotListDay(runDate.AddDays(-1),pastDue));//Pastue on index=0   
    arrayList.Add(new HotListDay(runDate.AddDays(0),day001));
    arrayList.Add(new HotListDay(runDate.AddDays(1),day002));   
    arrayList.Add(new HotListDay(runDate.AddDays(2),day003));   
    arrayList.Add(new HotListDay(runDate.AddDays(3),day004));   
    arrayList.Add(new HotListDay(runDate.AddDays(4),day005));   
    arrayList.Add(new HotListDay(runDate.AddDays(5),day006));   
    arrayList.Add(new HotListDay(runDate.AddDays(6),day007));   
    arrayList.Add(new HotListDay(runDate.AddDays(7),day008));   
    arrayList.Add(new HotListDay(runDate.AddDays(8),day009));   
    arrayList.Add(new HotListDay(runDate.AddDays(9),day010));
		
    arrayList.Add(new HotListDay(runDate.AddDays(10),day011));   
    arrayList.Add(new HotListDay(runDate.AddDays(11),day012));   
    arrayList.Add(new HotListDay(runDate.AddDays(12),day013));  
    arrayList.Add(new HotListDay(runDate.AddDays(13),day014));   
    arrayList.Add(new HotListDay(runDate.AddDays(14),day015));   
    arrayList.Add(new HotListDay(runDate.AddDays(15),day016));   
    arrayList.Add(new HotListDay(runDate.AddDays(16),day017));   
    arrayList.Add(new HotListDay(runDate.AddDays(17),day018)); 
    arrayList.Add(new HotListDay(runDate.AddDays(18),day019));  
    arrayList.Add(new HotListDay(runDate.AddDays(19),day020));		
  
    arrayList.Add(new HotListDay(runDate.AddDays(20),day021));  
    arrayList.Add(new HotListDay(runDate.AddDays(21),day022));  
    arrayList.Add(new HotListDay(runDate.AddDays(22),day023));  
    arrayList.Add(new HotListDay(runDate.AddDays(23),day024));  
    arrayList.Add(new HotListDay(runDate.AddDays(24),day025));  
    arrayList.Add(new HotListDay(runDate.AddDays(25),day026));   
    arrayList.Add(new HotListDay(runDate.AddDays(26),day027));   
    arrayList.Add(new HotListDay(runDate.AddDays(27),day028));   
    arrayList.Add(new HotListDay(runDate.AddDays(28),day029));   
    arrayList.Add(new HotListDay(runDate.AddDays(29),day030));   		
   
    arrayList.Add(new HotListDay(runDate.AddDays(30),day031));   
    arrayList.Add(new HotListDay(runDate.AddDays(31),day032));   
    arrayList.Add(new HotListDay(runDate.AddDays(32),day033));   
    arrayList.Add(new HotListDay(runDate.AddDays(33),day034));   
    arrayList.Add(new HotListDay(runDate.AddDays(34),day035));   
    arrayList.Add(new HotListDay(runDate.AddDays(35),day036));   
    arrayList.Add(new HotListDay(runDate.AddDays(36),day037));   
    arrayList.Add(new HotListDay(runDate.AddDays(37),day038));   
    arrayList.Add(new HotListDay(runDate.AddDays(38),day039));   
    arrayList.Add(new HotListDay(runDate.AddDays(39),day040));
    		   
    arrayList.Add(new HotListDay(runDate.AddDays(40),day041));   
    arrayList.Add(new HotListDay(runDate.AddDays(41),day042));   
    arrayList.Add(new HotListDay(runDate.AddDays(42),day043));   
    arrayList.Add(new HotListDay(runDate.AddDays(43),day044));   
    arrayList.Add(new HotListDay(runDate.AddDays(44),day045));   
    arrayList.Add(new HotListDay(runDate.AddDays(45),day046));   
    arrayList.Add(new HotListDay(runDate.AddDays(46),day047));   
    arrayList.Add(new HotListDay(runDate.AddDays(47),day048));   
    arrayList.Add(new HotListDay(runDate.AddDays(48),day049));   
    arrayList.Add(new HotListDay(runDate.AddDays(49),day050));
    		
   
    arrayList.Add(new HotListDay(runDate.AddDays(50),day051));   
    arrayList.Add(new HotListDay(runDate.AddDays(51),day052));   
    arrayList.Add(new HotListDay(runDate.AddDays(52),day053));   
    arrayList.Add(new HotListDay(runDate.AddDays(53),day054));   
    arrayList.Add(new HotListDay(runDate.AddDays(54),day055));   
    arrayList.Add(new HotListDay(runDate.AddDays(55),day056));   
    arrayList.Add(new HotListDay(runDate.AddDays(56),day057));   
    arrayList.Add(new HotListDay(runDate.AddDays(57),day058));   
    arrayList.Add(new HotListDay(runDate.AddDays(58),day059));   
    arrayList.Add(new HotListDay(runDate.AddDays(59),day060));    		   

    arrayList.Add(new HotListDay(runDate.AddDays(60),day061));   
    arrayList.Add(new HotListDay(runDate.AddDays(61),day062));   
    arrayList.Add(new HotListDay(runDate.AddDays(62),day063));   
    arrayList.Add(new HotListDay(runDate.AddDays(63),day064));   
    arrayList.Add(new HotListDay(runDate.AddDays(64),day065));   
    arrayList.Add(new HotListDay(runDate.AddDays(65),day066));   
    arrayList.Add(new HotListDay(runDate.AddDays(66),day067));   
    arrayList.Add(new HotListDay(runDate.AddDays(67),day068));   
    arrayList.Add(new HotListDay(runDate.AddDays(68),day069));   
    arrayList.Add(new HotListDay(runDate.AddDays(69),day070));
    		   
    arrayList.Add(new HotListDay(runDate.AddDays(70),day071));   
    arrayList.Add(new HotListDay(runDate.AddDays(71),day072));   
    arrayList.Add(new HotListDay(runDate.AddDays(72),day073));    
    arrayList.Add(new HotListDay(runDate.AddDays(73),day074));    
    arrayList.Add(new HotListDay(runDate.AddDays(74),day075));   
    arrayList.Add(new HotListDay(runDate.AddDays(75),day076));    
    arrayList.Add(new HotListDay(runDate.AddDays(76),day077));    
    arrayList.Add(new HotListDay(runDate.AddDays(77),day078));    
    arrayList.Add(new HotListDay(runDate.AddDays(78),day079));    
    arrayList.Add(new HotListDay(runDate.AddDays(79),day080));    		
    
    arrayList.Add(new HotListDay(runDate.AddDays(80),day081));    
    arrayList.Add(new HotListDay(runDate.AddDays(81),day082));    
    arrayList.Add(new HotListDay(runDate.AddDays(82),day083));    
    arrayList.Add(new HotListDay(runDate.AddDays(83),day084));    
    arrayList.Add(new HotListDay(runDate.AddDays(84),day085));    
    arrayList.Add(new HotListDay(runDate.AddDays(85),day086));    
    arrayList.Add(new HotListDay(runDate.AddDays(86),day087));    
    arrayList.Add(new HotListDay(runDate.AddDays(87),day088));    
    arrayList.Add(new HotListDay(runDate.AddDays(88),day089));    
    arrayList.Add(new HotListDay(runDate.AddDays(89),day090));
        
    return arrayList;
}



} // class
} // package