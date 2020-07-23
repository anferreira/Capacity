using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class HotListDataBase : GenericDataBaseElement{

private int HOT_IdAut;
private int HOT_Id;
private string HOT_ProdID;
private string HOT_ActID;
private int HOT_Seq;
private string HOT_Uom;
private string HOT_Dept;
private string HOT_Mach;
private decimal HOT_MachCyc;
private decimal HOT_Qoh;
private decimal HOT_QohCml;
private decimal HOT_PastDue;
private decimal HOT_Day001;
private decimal HOT_Day002;
private decimal HOT_Day003;
private decimal HOT_Day004;
private decimal HOT_Day005;
private decimal HOT_Day006;
private decimal HOT_Day007;
private decimal HOT_Day008;
private decimal HOT_Day009;
private decimal HOT_Day010;
private decimal HOT_Day011;
private decimal HOT_Day012;
private decimal HOT_Day013;
private decimal HOT_Day014;
private decimal HOT_Day015;
private decimal HOT_Day016;
private decimal HOT_Day017;
private decimal HOT_Day018;
private decimal HOT_Day019;
private decimal HOT_Day020;
private decimal HOT_Day021;
private decimal HOT_Day022;
private decimal HOT_Day023;
private decimal HOT_Day024;
private decimal HOT_Day025;
private decimal HOT_Day026;
private decimal HOT_Day027;
private decimal HOT_Day028;
private decimal HOT_Day029;
private decimal HOT_Day030;
private decimal HOT_Day031;
private decimal HOT_Day032;
private decimal HOT_Day033;
private decimal HOT_Day034;
private decimal HOT_Day035;
private decimal HOT_Day036;
private decimal HOT_Day037;
private decimal HOT_Day038;
private decimal HOT_Day039;
private decimal HOT_Day040;
private decimal HOT_Day041;
private decimal HOT_Day042;
private decimal HOT_Day043;
private decimal HOT_Day044;
private decimal HOT_Day045;
private decimal HOT_Day046;
private decimal HOT_Day047;
private decimal HOT_Day048;
private decimal HOT_Day049;
private decimal HOT_Day050;
private decimal HOT_Day051;
private decimal HOT_Day052;
private decimal HOT_Day053;
private decimal HOT_Day054;
private decimal HOT_Day055;
private decimal HOT_Day056;
private decimal HOT_Day057;
private decimal HOT_Day058;
private decimal HOT_Day059;
private decimal HOT_Day060;
private decimal HOT_Day061;
private decimal HOT_Day062;
private decimal HOT_Day063;
private decimal HOT_Day064;
private decimal HOT_Day065;
private decimal HOT_Day066;
private decimal HOT_Day067;
private decimal HOT_Day068;
private decimal HOT_Day069;
private decimal HOT_Day070;
private decimal HOT_Day071;
private decimal HOT_Day072;
private decimal HOT_Day073;
private decimal HOT_Day074;
private decimal HOT_Day075;
private decimal HOT_Day076;
private decimal HOT_Day077;
private decimal HOT_Day078;
private decimal HOT_Day079;
private decimal HOT_Day080;
private decimal HOT_Day081;
private decimal HOT_Day082;
private decimal HOT_Day083;
private decimal HOT_Day084;
private decimal HOT_Day085;
private decimal HOT_Day086;
private decimal HOT_Day087;
private decimal HOT_Day088;
private decimal HOT_Day089;
private decimal HOT_Day090;

private string HOT_MinorGroup;
private string HOT_MajorGroup;
private string HOT_Finalized;
private string HOT_Type;

private string HOT_MainMaterial;
private int HOT_MainMaterialSeq;
private decimal HOT_MainMaterialQoh;
private string HOT_Plt;

private int HOT_Level = 1;


public
HotListDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
HotListDataBase(HotListDataBase hotListDataBase) : base(hotListDataBase.dataBaseAccess){
	this.HOT_Id = hotListDataBase.HOT_Id;
	this.HOT_ProdID = hotListDataBase.HOT_ProdID;
	this.HOT_ActID = hotListDataBase.HOT_ActID;
	this.HOT_Seq = hotListDataBase.HOT_Seq;
	this.HOT_Uom = hotListDataBase.HOT_Uom;
	this.HOT_Dept = hotListDataBase.HOT_Dept;
	this.HOT_Mach = hotListDataBase.HOT_Mach;
	this.HOT_MachCyc = hotListDataBase.HOT_MachCyc;
	this.HOT_Qoh = hotListDataBase.HOT_Qoh;
	this.HOT_QohCml = hotListDataBase.HOT_QohCml;
	this.HOT_PastDue = hotListDataBase.HOT_PastDue;
	this.HOT_Day001 = hotListDataBase.HOT_Day001;
	this.HOT_Day002 = hotListDataBase.HOT_Day002;
	this.HOT_Day003 = hotListDataBase.HOT_Day003;
	this.HOT_Day004 = hotListDataBase.HOT_Day004;
	this.HOT_Day005 = hotListDataBase.HOT_Day005;
	this.HOT_Day006 = hotListDataBase.HOT_Day006;
	this.HOT_Day007 = hotListDataBase.HOT_Day007;
	this.HOT_Day008 = hotListDataBase.HOT_Day008;
	this.HOT_Day009 = hotListDataBase.HOT_Day009;
	this.HOT_Day010 = hotListDataBase.HOT_Day010;
	this.HOT_Day011 = hotListDataBase.HOT_Day011;
	this.HOT_Day012 = hotListDataBase.HOT_Day012;
	this.HOT_Day013 = hotListDataBase.HOT_Day013;
	this.HOT_Day014 = hotListDataBase.HOT_Day014;
	this.HOT_Day015 = hotListDataBase.HOT_Day015;
	this.HOT_Day016 = hotListDataBase.HOT_Day016;
	this.HOT_Day017 = hotListDataBase.HOT_Day017;
	this.HOT_Day018 = hotListDataBase.HOT_Day018;
	this.HOT_Day019 = hotListDataBase.HOT_Day019;
	this.HOT_Day020 = hotListDataBase.HOT_Day020;
	this.HOT_Day021 = hotListDataBase.HOT_Day021;
	this.HOT_Day022 = hotListDataBase.HOT_Day022;
	this.HOT_Day023 = hotListDataBase.HOT_Day023;
	this.HOT_Day024 = hotListDataBase.HOT_Day024;
	this.HOT_Day025 = hotListDataBase.HOT_Day025;
	this.HOT_Day026 = hotListDataBase.HOT_Day026;
	this.HOT_Day027 = hotListDataBase.HOT_Day027;
	this.HOT_Day028 = hotListDataBase.HOT_Day028;
	this.HOT_Day029 = hotListDataBase.HOT_Day029;
	this.HOT_Day030 = hotListDataBase.HOT_Day030;
	this.HOT_Day031 = hotListDataBase.HOT_Day031;
	this.HOT_Day032 = hotListDataBase.HOT_Day032;
	this.HOT_Day033 = hotListDataBase.HOT_Day033;
	this.HOT_Day034 = hotListDataBase.HOT_Day034;
	this.HOT_Day035 = hotListDataBase.HOT_Day035;
	this.HOT_Day036 = hotListDataBase.HOT_Day036;
	this.HOT_Day037 = hotListDataBase.HOT_Day037;
	this.HOT_Day038 = hotListDataBase.HOT_Day038;
	this.HOT_Day039 = hotListDataBase.HOT_Day039;
	this.HOT_Day040 = hotListDataBase.HOT_Day040;
	this.HOT_Day041 = hotListDataBase.HOT_Day041;
	this.HOT_Day042 = hotListDataBase.HOT_Day042;
	this.HOT_Day043 = hotListDataBase.HOT_Day043;
	this.HOT_Day044 = hotListDataBase.HOT_Day044;
	this.HOT_Day045 = hotListDataBase.HOT_Day045;
	this.HOT_Day046 = hotListDataBase.HOT_Day046;
	this.HOT_Day047 = hotListDataBase.HOT_Day047;
	this.HOT_Day048 = hotListDataBase.HOT_Day048;
	this.HOT_Day049 = hotListDataBase.HOT_Day049;
	this.HOT_Day050 = hotListDataBase.HOT_Day050;
	this.HOT_Day051 = hotListDataBase.HOT_Day051;
	this.HOT_Day052 = hotListDataBase.HOT_Day052;
	this.HOT_Day053 = hotListDataBase.HOT_Day053;
	this.HOT_Day054 = hotListDataBase.HOT_Day054;
	this.HOT_Day055 = hotListDataBase.HOT_Day055;
	this.HOT_Day056 = hotListDataBase.HOT_Day056;
	this.HOT_Day057 = hotListDataBase.HOT_Day057;
	this.HOT_Day058 = hotListDataBase.HOT_Day058;
	this.HOT_Day059 = hotListDataBase.HOT_Day059;
	this.HOT_Day060 = hotListDataBase.HOT_Day060;

	this.HOT_Day061 = hotListDataBase.HOT_Day061;
	this.HOT_Day062 = hotListDataBase.HOT_Day062;
	this.HOT_Day063 = hotListDataBase.HOT_Day063;
	this.HOT_Day064 = hotListDataBase.HOT_Day064;
	this.HOT_Day065 = hotListDataBase.HOT_Day065;
	this.HOT_Day066 = hotListDataBase.HOT_Day066;
	this.HOT_Day067 = hotListDataBase.HOT_Day067;
	this.HOT_Day068 = hotListDataBase.HOT_Day068;
	this.HOT_Day069 = hotListDataBase.HOT_Day069;
	this.HOT_Day070 = hotListDataBase.HOT_Day070;
	this.HOT_Day071 = hotListDataBase.HOT_Day071;
	this.HOT_Day072 = hotListDataBase.HOT_Day072;
	this.HOT_Day073 = hotListDataBase.HOT_Day073;
	this.HOT_Day074 = hotListDataBase.HOT_Day074;
	this.HOT_Day075 = hotListDataBase.HOT_Day075;
	this.HOT_Day076 = hotListDataBase.HOT_Day076;
	this.HOT_Day077 = hotListDataBase.HOT_Day077;
	this.HOT_Day078 = hotListDataBase.HOT_Day078;
	this.HOT_Day079 = hotListDataBase.HOT_Day069;
	this.HOT_Day080 = hotListDataBase.HOT_Day080;
	this.HOT_Day081 = hotListDataBase.HOT_Day081;
	this.HOT_Day082 = hotListDataBase.HOT_Day082;
	this.HOT_Day083 = hotListDataBase.HOT_Day083;
	this.HOT_Day084 = hotListDataBase.HOT_Day084;
	this.HOT_Day085 = hotListDataBase.HOT_Day085;
	this.HOT_Day086 = hotListDataBase.HOT_Day086;
	this.HOT_Day087 = hotListDataBase.HOT_Day087;
	this.HOT_Day088 = hotListDataBase.HOT_Day088;
	this.HOT_Day089 = hotListDataBase.HOT_Day089;
	this.HOT_Day090 = hotListDataBase.HOT_Day090;

	this.HOT_MinorGroup = hotListDataBase.HOT_MinorGroup;
	this.HOT_MajorGroup = hotListDataBase.HOT_MajorGroup;
	this.HOT_Finalized = hotListDataBase.HOT_Finalized;
	this.HOT_Type = hotListDataBase.HOT_Type;

	this.HOT_MainMaterial = hotListDataBase.HOT_MainMaterial;
	this.HOT_MainMaterialSeq = hotListDataBase.HOT_MainMaterialSeq;
	this.HOT_MainMaterialQoh = hotListDataBase.HOT_MainMaterialQoh;
    this.HOT_Plt = hotListDataBase.HOT_Plt;
}

public
void addData(HotListDataBase hotListDataBase){
	this.HOT_Id = hotListDataBase.HOT_Id;
	this.HOT_Qoh = hotListDataBase.HOT_Qoh;
	this.HOT_QohCml = hotListDataBase.HOT_QohCml;
	
	if (!this.HOT_Type.Equals(hotListDataBase.HOT_Type))
		this.HOT_Type = "M";
	else
		this.HOT_Type = hotListDataBase.HOT_Type;

	this.HOT_PastDue += hotListDataBase.HOT_PastDue;
	this.HOT_Day001 += hotListDataBase.HOT_Day001;
	this.HOT_Day002 += hotListDataBase.HOT_Day002;
	this.HOT_Day003 += hotListDataBase.HOT_Day003;
	this.HOT_Day004 += hotListDataBase.HOT_Day004;
	this.HOT_Day005 += hotListDataBase.HOT_Day005;
	this.HOT_Day006 += hotListDataBase.HOT_Day006;
	this.HOT_Day007 += hotListDataBase.HOT_Day007;
	this.HOT_Day008 += hotListDataBase.HOT_Day008;
	this.HOT_Day009 += hotListDataBase.HOT_Day009;
	this.HOT_Day010 += hotListDataBase.HOT_Day010;
	this.HOT_Day011 += hotListDataBase.HOT_Day011;
	this.HOT_Day012 += hotListDataBase.HOT_Day012;
	this.HOT_Day013 += hotListDataBase.HOT_Day013;
	this.HOT_Day014 += hotListDataBase.HOT_Day014;
	this.HOT_Day015 += hotListDataBase.HOT_Day015;
	this.HOT_Day016 += hotListDataBase.HOT_Day016;
	this.HOT_Day017 += hotListDataBase.HOT_Day017;
	this.HOT_Day018 += hotListDataBase.HOT_Day018;
	this.HOT_Day019 += hotListDataBase.HOT_Day019;
	this.HOT_Day020 += hotListDataBase.HOT_Day020;
	this.HOT_Day021 += hotListDataBase.HOT_Day021;
	this.HOT_Day022 += hotListDataBase.HOT_Day022;
	this.HOT_Day023 += hotListDataBase.HOT_Day023;
	this.HOT_Day024 += hotListDataBase.HOT_Day024;
	this.HOT_Day025 += hotListDataBase.HOT_Day025;
	this.HOT_Day026 += hotListDataBase.HOT_Day026;
	this.HOT_Day027 += hotListDataBase.HOT_Day027;
	this.HOT_Day028 += hotListDataBase.HOT_Day028;
	this.HOT_Day029 += hotListDataBase.HOT_Day029;
	this.HOT_Day030 += hotListDataBase.HOT_Day030;
	this.HOT_Day031 += hotListDataBase.HOT_Day031;
	this.HOT_Day032 += hotListDataBase.HOT_Day032;
	this.HOT_Day033 += hotListDataBase.HOT_Day033;
	this.HOT_Day034 += hotListDataBase.HOT_Day034;
	this.HOT_Day035 += hotListDataBase.HOT_Day035;
	this.HOT_Day036 += hotListDataBase.HOT_Day036;
	this.HOT_Day037 += hotListDataBase.HOT_Day037;
	this.HOT_Day038 += hotListDataBase.HOT_Day038;
	this.HOT_Day039 += hotListDataBase.HOT_Day039;
	this.HOT_Day040 += hotListDataBase.HOT_Day040;
	this.HOT_Day041 += hotListDataBase.HOT_Day041;
	this.HOT_Day042 += hotListDataBase.HOT_Day042;
	this.HOT_Day043 += hotListDataBase.HOT_Day043;
	this.HOT_Day044 += hotListDataBase.HOT_Day044;
	this.HOT_Day045 += hotListDataBase.HOT_Day045;
	this.HOT_Day046 += hotListDataBase.HOT_Day046;
	this.HOT_Day047 += hotListDataBase.HOT_Day047;
	this.HOT_Day048 += hotListDataBase.HOT_Day048;
	this.HOT_Day049 += hotListDataBase.HOT_Day049;
	this.HOT_Day050 += hotListDataBase.HOT_Day050;
	this.HOT_Day051 += hotListDataBase.HOT_Day051;
	this.HOT_Day052 += hotListDataBase.HOT_Day052;
	this.HOT_Day053 += hotListDataBase.HOT_Day053;
	this.HOT_Day054 += hotListDataBase.HOT_Day054;
	this.HOT_Day055 += hotListDataBase.HOT_Day055;
	this.HOT_Day056 += hotListDataBase.HOT_Day056;
	this.HOT_Day057 += hotListDataBase.HOT_Day057;
	this.HOT_Day058 += hotListDataBase.HOT_Day058;
	this.HOT_Day059 += hotListDataBase.HOT_Day059;
	this.HOT_Day060 += hotListDataBase.HOT_Day060;

	this.HOT_Day061 += hotListDataBase.HOT_Day061;
	this.HOT_Day062 += hotListDataBase.HOT_Day062;
	this.HOT_Day063 += hotListDataBase.HOT_Day063;
	this.HOT_Day064 += hotListDataBase.HOT_Day064;
	this.HOT_Day065 += hotListDataBase.HOT_Day065;
	this.HOT_Day066 += hotListDataBase.HOT_Day066;
	this.HOT_Day067 += hotListDataBase.HOT_Day067;
	this.HOT_Day068 += hotListDataBase.HOT_Day068;
	this.HOT_Day069 += hotListDataBase.HOT_Day069;
	this.HOT_Day070 += hotListDataBase.HOT_Day070;
	this.HOT_Day071 += hotListDataBase.HOT_Day071;
	this.HOT_Day072 += hotListDataBase.HOT_Day072;
	this.HOT_Day073 += hotListDataBase.HOT_Day073;
	this.HOT_Day074 += hotListDataBase.HOT_Day074;
	this.HOT_Day075 += hotListDataBase.HOT_Day075;
	this.HOT_Day076 += hotListDataBase.HOT_Day076;
	this.HOT_Day077 += hotListDataBase.HOT_Day077;
	this.HOT_Day078 += hotListDataBase.HOT_Day078;
	this.HOT_Day079 += hotListDataBase.HOT_Day079;
	this.HOT_Day080 += hotListDataBase.HOT_Day080;
	this.HOT_Day081 += hotListDataBase.HOT_Day081;
	this.HOT_Day082 += hotListDataBase.HOT_Day082;
	this.HOT_Day083 += hotListDataBase.HOT_Day083;
	this.HOT_Day084 += hotListDataBase.HOT_Day084;
	this.HOT_Day085 += hotListDataBase.HOT_Day085;
	this.HOT_Day086 += hotListDataBase.HOT_Day086;
	this.HOT_Day087 += hotListDataBase.HOT_Day087;
	this.HOT_Day088 += hotListDataBase.HOT_Day088;
	this.HOT_Day089 += hotListDataBase.HOT_Day089;
	this.HOT_Day090 += hotListDataBase.HOT_Day090;

	this.HOT_MainMaterial = hotListDataBase.HOT_MainMaterial;
	this.HOT_MainMaterialSeq = hotListDataBase.HOT_MainMaterialSeq;
	this.HOT_MainMaterialQoh = hotListDataBase.HOT_MainMaterialQoh;
    this.HOT_Plt  = hotListDataBase.HOT_Plt;
}

public
void load(NotNullDataReader reader){
    this.HOT_IdAut = reader.GetInt32("HOT_IdAut");
    this.HOT_Id = reader.GetInt32("HOT_Id");
	this.HOT_ProdID = reader.GetString("HOT_ProdID");
	this.HOT_ActID = reader.GetString("HOT_ActID");
	this.HOT_Seq = reader.GetInt32("HOT_Seq");
	this.HOT_Uom = reader.GetString("HOT_Uom");
	this.HOT_Dept = reader.GetString("HOT_Dept");
	this.HOT_Mach = reader.GetString("HOT_Mach");
	this.HOT_MachCyc = reader.GetDecimal("HOT_MachCyc");
	this.HOT_Qoh = reader.GetDecimal("HOT_Qoh");
	this.HOT_QohCml = reader.GetDecimal("HOT_QohCml");
	this.HOT_PastDue = reader.GetDecimal("HOT_PastDue");
	this.HOT_Day001 = reader.GetDecimal("HOT_Day001");
	this.HOT_Day002 = reader.GetDecimal("HOT_Day002");
	this.HOT_Day003 = reader.GetDecimal("HOT_Day003");
	this.HOT_Day004 = reader.GetDecimal("HOT_Day004");
	this.HOT_Day005 = reader.GetDecimal("HOT_Day005");
	this.HOT_Day006 = reader.GetDecimal("HOT_Day006");
	this.HOT_Day007 = reader.GetDecimal("HOT_Day007");
	this.HOT_Day008 = reader.GetDecimal("HOT_Day008");
	this.HOT_Day009 = reader.GetDecimal("HOT_Day009");
	this.HOT_Day010 = reader.GetDecimal("HOT_Day010");
	this.HOT_Day011 = reader.GetDecimal("HOT_Day011");
	this.HOT_Day012 = reader.GetDecimal("HOT_Day012");
	this.HOT_Day013 = reader.GetDecimal("HOT_Day013");
	this.HOT_Day014 = reader.GetDecimal("HOT_Day014");
	this.HOT_Day015 = reader.GetDecimal("HOT_Day015");
	this.HOT_Day016 = reader.GetDecimal("HOT_Day016");
	this.HOT_Day017 = reader.GetDecimal("HOT_Day017");
	this.HOT_Day018 = reader.GetDecimal("HOT_Day018");
	this.HOT_Day019 = reader.GetDecimal("HOT_Day019");
	this.HOT_Day020 = reader.GetDecimal("HOT_Day020");
	this.HOT_Day021 = reader.GetDecimal("HOT_Day021");
	this.HOT_Day022 = reader.GetDecimal("HOT_Day022");
	this.HOT_Day023 = reader.GetDecimal("HOT_Day023");
	this.HOT_Day024 = reader.GetDecimal("HOT_Day024");
	this.HOT_Day025 = reader.GetDecimal("HOT_Day025");
	this.HOT_Day026 = reader.GetDecimal("HOT_Day026");
	this.HOT_Day027 = reader.GetDecimal("HOT_Day027");
	this.HOT_Day028 = reader.GetDecimal("HOT_Day028");
	this.HOT_Day029 = reader.GetDecimal("HOT_Day029");
	this.HOT_Day030 = reader.GetDecimal("HOT_Day030");
	this.HOT_Day031 = reader.GetDecimal("HOT_Day031");
	this.HOT_Day032 = reader.GetDecimal("HOT_Day032");
	this.HOT_Day033 = reader.GetDecimal("HOT_Day033");
	this.HOT_Day034 = reader.GetDecimal("HOT_Day034");
	this.HOT_Day035 = reader.GetDecimal("HOT_Day035");
	this.HOT_Day036 = reader.GetDecimal("HOT_Day036");
	this.HOT_Day037 = reader.GetDecimal("HOT_Day037");
	this.HOT_Day038 = reader.GetDecimal("HOT_Day038");
	this.HOT_Day039 = reader.GetDecimal("HOT_Day039");
	this.HOT_Day040 = reader.GetDecimal("HOT_Day040");
	this.HOT_Day041 = reader.GetDecimal("HOT_Day041");
	this.HOT_Day042 = reader.GetDecimal("HOT_Day042");
	this.HOT_Day043 = reader.GetDecimal("HOT_Day043");
	this.HOT_Day044 = reader.GetDecimal("HOT_Day044");
	this.HOT_Day045 = reader.GetDecimal("HOT_Day045");
	this.HOT_Day046 = reader.GetDecimal("HOT_Day046");
	this.HOT_Day047 = reader.GetDecimal("HOT_Day047");
	this.HOT_Day048 = reader.GetDecimal("HOT_Day048");
	this.HOT_Day049 = reader.GetDecimal("HOT_Day049");
	this.HOT_Day050 = reader.GetDecimal("HOT_Day050");
	this.HOT_Day051 = reader.GetDecimal("HOT_Day051");
	this.HOT_Day052 = reader.GetDecimal("HOT_Day052");
	this.HOT_Day053 = reader.GetDecimal("HOT_Day053");
	this.HOT_Day054 = reader.GetDecimal("HOT_Day054");
	this.HOT_Day055 = reader.GetDecimal("HOT_Day055");
	this.HOT_Day056 = reader.GetDecimal("HOT_Day056");
	this.HOT_Day057 = reader.GetDecimal("HOT_Day057");
	this.HOT_Day058 = reader.GetDecimal("HOT_Day058");
	this.HOT_Day059 = reader.GetDecimal("HOT_Day059");
	this.HOT_Day060 = reader.GetDecimal("HOT_Day060");

	this.HOT_Day061 = reader.GetDecimal("HOT_Day061");
	this.HOT_Day062 = reader.GetDecimal("HOT_Day062");
	this.HOT_Day063 = reader.GetDecimal("HOT_Day063");
	this.HOT_Day064 = reader.GetDecimal("HOT_Day064");
	this.HOT_Day065 = reader.GetDecimal("HOT_Day065");
	this.HOT_Day066 = reader.GetDecimal("HOT_Day066");
	this.HOT_Day067 = reader.GetDecimal("HOT_Day067");
	this.HOT_Day068 = reader.GetDecimal("HOT_Day068");
	this.HOT_Day069 = reader.GetDecimal("HOT_Day069");
	this.HOT_Day070 = reader.GetDecimal("HOT_Day070");
	this.HOT_Day071 = reader.GetDecimal("HOT_Day071");
	this.HOT_Day072 = reader.GetDecimal("HOT_Day072");
	this.HOT_Day073 = reader.GetDecimal("HOT_Day073");
	this.HOT_Day074 = reader.GetDecimal("HOT_Day074");
	this.HOT_Day075 = reader.GetDecimal("HOT_Day075");
	this.HOT_Day076 = reader.GetDecimal("HOT_Day076");
	this.HOT_Day077 = reader.GetDecimal("HOT_Day077");
	this.HOT_Day078 = reader.GetDecimal("HOT_Day078");
	this.HOT_Day079 = reader.GetDecimal("HOT_Day079");
	this.HOT_Day080 = reader.GetDecimal("HOT_Day080");
	this.HOT_Day081 = reader.GetDecimal("HOT_Day081");
	this.HOT_Day082 = reader.GetDecimal("HOT_Day082");
	this.HOT_Day083 = reader.GetDecimal("HOT_Day083");
	this.HOT_Day084 = reader.GetDecimal("HOT_Day084");
	this.HOT_Day085 = reader.GetDecimal("HOT_Day085");
	this.HOT_Day086 = reader.GetDecimal("HOT_Day086");
	this.HOT_Day087 = reader.GetDecimal("HOT_Day087");
	this.HOT_Day088 = reader.GetDecimal("HOT_Day088");
	this.HOT_Day089 = reader.GetDecimal("HOT_Day089");
	this.HOT_Day090 = reader.GetDecimal("HOT_Day090");

	this.HOT_MajorGroup = reader.GetString("HOT_MajorGroup");
	this.HOT_MinorGroup = reader.GetString("HOT_MinorGroup");
	this.HOT_Finalized = reader.GetString("HOT_Finalized");
	this.HOT_Type = reader.GetString("HOT_Type");

	this.HOT_MainMaterial = reader.GetString("HOT_MainMaterial");
	this.HOT_MainMaterialSeq = reader.GetInt32("HOT_MainMaterialSeq");
	this.HOT_MainMaterialQoh = reader.GetDecimal("HOT_MainMaterialQoh");
    this.HOT_Plt = reader.GetString("HOT_Plt");
}

//
public
void loadGridHotList(NotNullDataReader reader){
    this.HOT_IdAut = reader.GetInt32("HOT_IdAut");
    this.HOT_Id = reader.GetInt32("HOT_Id");
	this.HOT_Dept = reader.GetString("HOT_Dept");
	this.HOT_MinorGroup = reader.GetString("HOT_MinorGroup");
	this.HOT_MajorGroup = reader.GetString("HOT_MajorGroup");
	this.HOT_ProdID = reader.GetString("HOT_ProdID");
	this.HOT_Seq = reader.GetInt32("HOT_Seq");
	this.HOT_Uom = reader.GetString("HOT_Uom");
	this.HOT_Mach = reader.GetString("HOT_Mach");
	this.HOT_MachCyc = reader.GetDecimal("HOT_MachCyc");
	this.HOT_Qoh = reader.GetDecimal("HOT_Qoh");
	this.HOT_QohCml = reader.GetDecimal("HOT_QohCml");
	this.HOT_PastDue = reader.GetDecimal("HOT_PastDue");
	this.HOT_Day001 = reader.GetDecimal("HOT_Day001");
	this.HOT_Day002 = reader.GetDecimal("HOT_Day002");
	this.HOT_Day003 = reader.GetDecimal("HOT_Day003");
	this.HOT_Day004 = reader.GetDecimal("HOT_Day004");
	this.HOT_Day005 = reader.GetDecimal("HOT_Day005");
	this.HOT_Day006 = reader.GetDecimal("HOT_Day006");
	this.HOT_Day007 = reader.GetDecimal("HOT_Day007");
	this.HOT_Day008 = reader.GetDecimal("HOT_Day008");
	this.HOT_Day009 = reader.GetDecimal("HOT_Day009");
	this.HOT_Day010 = reader.GetDecimal("HOT_Day010");
	this.HOT_Day011 = reader.GetDecimal("HOT_Day011");
	this.HOT_Day012 = reader.GetDecimal("HOT_Day012");
	this.HOT_Day013 = reader.GetDecimal("HOT_Day013");
	this.HOT_Day014 = reader.GetDecimal("HOT_Day014");
	this.HOT_Day015 = reader.GetDecimal("HOT_Day015");
	this.HOT_Day016 = reader.GetDecimal("HOT_Day016");
	this.HOT_Day017 = reader.GetDecimal("HOT_Day017");
	this.HOT_Day018 = reader.GetDecimal("HOT_Day018");
	this.HOT_Day019 = reader.GetDecimal("HOT_Day019");
	this.HOT_Day020 = reader.GetDecimal("HOT_Day020");
	this.HOT_Day021 = reader.GetDecimal("HOT_Day021");
	this.HOT_Day022 = reader.GetDecimal("HOT_Day022");
	this.HOT_Day023 = reader.GetDecimal("HOT_Day023");
	this.HOT_Day024 = reader.GetDecimal("HOT_Day024");
	this.HOT_Day025 = reader.GetDecimal("HOT_Day025");
	this.HOT_Day026 = reader.GetDecimal("HOT_Day026");
	this.HOT_Day027 = reader.GetDecimal("HOT_Day027");
	this.HOT_Day028 = reader.GetDecimal("HOT_Day028");
	this.HOT_Day029 = reader.GetDecimal("HOT_Day029");
	this.HOT_Day030 = reader.GetDecimal("HOT_Day030");
	this.HOT_Day031 = reader.GetDecimal("HOT_Day031");
	this.HOT_Day032 = reader.GetDecimal("HOT_Day032");
	this.HOT_Day033 = reader.GetDecimal("HOT_Day033");
	this.HOT_Day034 = reader.GetDecimal("HOT_Day034");
	this.HOT_Day035 = reader.GetDecimal("HOT_Day035");
	this.HOT_Day036 = reader.GetDecimal("HOT_Day036");
	this.HOT_Day037 = reader.GetDecimal("HOT_Day037");
	this.HOT_Day038 = reader.GetDecimal("HOT_Day038");
	this.HOT_Day039 = reader.GetDecimal("HOT_Day039");
	this.HOT_Day040 = reader.GetDecimal("HOT_Day040");
	this.HOT_Day041 = reader.GetDecimal("HOT_Day041");
	this.HOT_Day042 = reader.GetDecimal("HOT_Day042");
	this.HOT_Day043 = reader.GetDecimal("HOT_Day043");
	this.HOT_Day044 = reader.GetDecimal("HOT_Day044");
	this.HOT_Day045 = reader.GetDecimal("HOT_Day045");
	this.HOT_Day046 = reader.GetDecimal("HOT_Day046");
	this.HOT_Day047 = reader.GetDecimal("HOT_Day047");
	this.HOT_Day048 = reader.GetDecimal("HOT_Day048");
	this.HOT_Day049 = reader.GetDecimal("HOT_Day049");
	this.HOT_Day050 = reader.GetDecimal("HOT_Day050");
	this.HOT_Day051 = reader.GetDecimal("HOT_Day051");
	this.HOT_Day052 = reader.GetDecimal("HOT_Day052");
	this.HOT_Day053 = reader.GetDecimal("HOT_Day053");
	this.HOT_Day054 = reader.GetDecimal("HOT_Day054");
	this.HOT_Day055 = reader.GetDecimal("HOT_Day055");
	this.HOT_Day056 = reader.GetDecimal("HOT_Day056");
	this.HOT_Day057 = reader.GetDecimal("HOT_Day057");
	this.HOT_Day058 = reader.GetDecimal("HOT_Day058");
	this.HOT_Day059 = reader.GetDecimal("HOT_Day059");
	this.HOT_Day060 = reader.GetDecimal("HOT_Day060");

	this.HOT_Day061 = reader.GetDecimal("HOT_Day061");
	this.HOT_Day062 = reader.GetDecimal("HOT_Day062");
	this.HOT_Day063 = reader.GetDecimal("HOT_Day063");
	this.HOT_Day064 = reader.GetDecimal("HOT_Day064");
	this.HOT_Day065 = reader.GetDecimal("HOT_Day065");
	this.HOT_Day066 = reader.GetDecimal("HOT_Day066");
	this.HOT_Day067 = reader.GetDecimal("HOT_Day067");
	this.HOT_Day068 = reader.GetDecimal("HOT_Day068");
	this.HOT_Day069 = reader.GetDecimal("HOT_Day069");
	this.HOT_Day070 = reader.GetDecimal("HOT_Day070");
	this.HOT_Day071 = reader.GetDecimal("HOT_Day071");
	this.HOT_Day072 = reader.GetDecimal("HOT_Day072");
	this.HOT_Day073 = reader.GetDecimal("HOT_Day073");
	this.HOT_Day074 = reader.GetDecimal("HOT_Day074");
	this.HOT_Day075 = reader.GetDecimal("HOT_Day075");
	this.HOT_Day076 = reader.GetDecimal("HOT_Day076");
	this.HOT_Day077 = reader.GetDecimal("HOT_Day077");
	this.HOT_Day078 = reader.GetDecimal("HOT_Day078");
	this.HOT_Day079 = reader.GetDecimal("HOT_Day079");
	this.HOT_Day080 = reader.GetDecimal("HOT_Day080");
	this.HOT_Day081 = reader.GetDecimal("HOT_Day081");
	this.HOT_Day082 = reader.GetDecimal("HOT_Day082");
	this.HOT_Day083 = reader.GetDecimal("HOT_Day083");
	this.HOT_Day084 = reader.GetDecimal("HOT_Day084");
	this.HOT_Day085 = reader.GetDecimal("HOT_Day085");
	this.HOT_Day086 = reader.GetDecimal("HOT_Day086");
	this.HOT_Day087 = reader.GetDecimal("HOT_Day087");
	this.HOT_Day088 = reader.GetDecimal("HOT_Day088");
	this.HOT_Day089 = reader.GetDecimal("HOT_Day089");
	this.HOT_Day090 = reader.GetDecimal("HOT_Day090");

	this.HOT_Finalized = reader.GetString("HOT_Finalized");
	this.HOT_Type = reader.GetString("HOT_Type");

	this.HOT_MainMaterial = reader.GetString("HOT_MainMaterial");
	this.HOT_MainMaterialSeq = reader.GetInt32("HOT_MainMaterialSeq");
	this.HOT_MainMaterialQoh = reader.GetDecimal("HOT_MainMaterialQoh");
    this.HOT_Plt = reader.GetString("HOT_Plt");
}

public override
void write(){
	try{
		string sql = "insert into hotlist values(" + 
			NumberUtil.toString(HOT_Id) + ", '" + 
			Converter.fixString(HOT_ProdID) + "', '" +
			Converter.fixString(HOT_ActID) + "', " +
			NumberUtil.toString(HOT_Seq) + ", '" +
			Converter.fixString(HOT_Uom) + "', '" +
			Converter.fixString(HOT_Dept) + "', '" +
			Converter.fixString(HOT_Mach) + "', " +
			NumberUtil.toString(HOT_MachCyc) + ", " +
			NumberUtil.toString(HOT_Qoh) + ", " +
			NumberUtil.toString(HOT_QohCml) + ", " +
			NumberUtil.toString(HOT_PastDue) + ", " +
			NumberUtil.toString(HOT_Day001) + ", " +
			NumberUtil.toString(HOT_Day002) + ", " +
			NumberUtil.toString(HOT_Day003) + ", " +
			NumberUtil.toString(HOT_Day004) + ", " +
			NumberUtil.toString(HOT_Day005) + ", " +
			NumberUtil.toString(HOT_Day006) + ", " +
			NumberUtil.toString(HOT_Day007) + ", " +
			NumberUtil.toString(HOT_Day008) + ", " +
			NumberUtil.toString(HOT_Day009) + ", " +
			NumberUtil.toString(HOT_Day010) + ", " +
			NumberUtil.toString(HOT_Day011) + ", " +
			NumberUtil.toString(HOT_Day012) + ", " +
			NumberUtil.toString(HOT_Day013) + ", " +
			NumberUtil.toString(HOT_Day014) + ", " +
			NumberUtil.toString(HOT_Day015) + ", " +
			NumberUtil.toString(HOT_Day016) + ", " +
			NumberUtil.toString(HOT_Day017) + ", " +
			NumberUtil.toString(HOT_Day018) + ", " +
			NumberUtil.toString(HOT_Day019) + ", " +
			NumberUtil.toString(HOT_Day020) + ", " +
			NumberUtil.toString(HOT_Day021) + ", " +
			NumberUtil.toString(HOT_Day022) + ", " +
			NumberUtil.toString(HOT_Day023) + ", " +
			NumberUtil.toString(HOT_Day024) + ", " +
			NumberUtil.toString(HOT_Day025) + ", " +
			NumberUtil.toString(HOT_Day026) + ", " +
			NumberUtil.toString(HOT_Day027) + ", " +
			NumberUtil.toString(HOT_Day028) + ", " +
			NumberUtil.toString(HOT_Day029) + ", " +
			NumberUtil.toString(HOT_Day030) + ", " +
			NumberUtil.toString(HOT_Day031) + ", " +
			NumberUtil.toString(HOT_Day032) + ", " +
			NumberUtil.toString(HOT_Day033) + ", " +
			NumberUtil.toString(HOT_Day034) + ", " +
			NumberUtil.toString(HOT_Day035) + ", " +
			NumberUtil.toString(HOT_Day036) + ", " +
			NumberUtil.toString(HOT_Day037) + ", " +
			NumberUtil.toString(HOT_Day038) + ", " +
			NumberUtil.toString(HOT_Day039) + ", " +
			NumberUtil.toString(HOT_Day040) + ", " +
			NumberUtil.toString(HOT_Day041) + ", " +
			NumberUtil.toString(HOT_Day042) + ", " +
			NumberUtil.toString(HOT_Day043) + ", " +
			NumberUtil.toString(HOT_Day044) + ", " +
			NumberUtil.toString(HOT_Day045) + ", " +
			NumberUtil.toString(HOT_Day046) + ", " +
			NumberUtil.toString(HOT_Day047) + ", " +
			NumberUtil.toString(HOT_Day048) + ", " +
			NumberUtil.toString(HOT_Day049) + ", " +
			NumberUtil.toString(HOT_Day050) + ", " +
			NumberUtil.toString(HOT_Day051) + ", " +
			NumberUtil.toString(HOT_Day052) + ", " +
			NumberUtil.toString(HOT_Day053) + ", " +
			NumberUtil.toString(HOT_Day054) + ", " +
			NumberUtil.toString(HOT_Day055) + ", " +
			NumberUtil.toString(HOT_Day056) + ", " +
			NumberUtil.toString(HOT_Day057) + ", " +
			NumberUtil.toString(HOT_Day058) + ", " +
			NumberUtil.toString(HOT_Day059) + ", " +
			NumberUtil.toString(HOT_Day060) + ", " +

			NumberUtil.toString(HOT_Day061) + ", " +
			NumberUtil.toString(HOT_Day062) + ", " +
			NumberUtil.toString(HOT_Day063) + ", " +
			NumberUtil.toString(HOT_Day064) + ", " +
			NumberUtil.toString(HOT_Day065) + ", " +
			NumberUtil.toString(HOT_Day066) + ", " +
			NumberUtil.toString(HOT_Day067) + ", " +
			NumberUtil.toString(HOT_Day068) + ", " +
			NumberUtil.toString(HOT_Day069) + ", " +
			NumberUtil.toString(HOT_Day070) + ", " +
			NumberUtil.toString(HOT_Day071) + ", " +
			NumberUtil.toString(HOT_Day072) + ", " +
			NumberUtil.toString(HOT_Day073) + ", " +
			NumberUtil.toString(HOT_Day074) + ", " +
			NumberUtil.toString(HOT_Day075) + ", " +
			NumberUtil.toString(HOT_Day076) + ", " +
			NumberUtil.toString(HOT_Day077) + ", " +
			NumberUtil.toString(HOT_Day078) + ", " +
			NumberUtil.toString(HOT_Day079) + ", " +
			NumberUtil.toString(HOT_Day080) + ", " +
			NumberUtil.toString(HOT_Day081) + ", " +
			NumberUtil.toString(HOT_Day082) + ", " +
			NumberUtil.toString(HOT_Day083) + ", " +
			NumberUtil.toString(HOT_Day084) + ", " +
			NumberUtil.toString(HOT_Day085) + ", " +
			NumberUtil.toString(HOT_Day086) + ", " +
			NumberUtil.toString(HOT_Day087) + ", " +
			NumberUtil.toString(HOT_Day088) + ", " +
			NumberUtil.toString(HOT_Day089) + ", " +
			NumberUtil.toString(HOT_Day090) + ", '" +
			
			Converter.fixString(HOT_MajorGroup) + "', '" +
			Converter.fixString(HOT_MinorGroup) + "', '" +
			Converter.fixString(HOT_Finalized) + "', '" +
			Converter.fixString(HOT_Type) + "', '" +

			Converter.fixString(HOT_MainMaterial) + "', " +
			NumberUtil.toString(HOT_MainMaterialSeq) + ", " +
			NumberUtil.toString(HOT_MainMaterialQoh) + ", '" +
            Converter.fixString(HOT_Plt) + "')";

		dataBaseAccess.executeUpdate(sql);
        HOT_IdAut=dataBaseAccess.getLastId();

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	throw new PersistenceException("Error in class HotListDataBase <update>: Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Error in class HotListDataBase <delete>: Method not implemented");
}

public
void multiplyValues(decimal val){
	this.HOT_Qoh *= val;
	this.HOT_QohCml *= val;
	this.HOT_PastDue *= val;
	this.HOT_Day001 *= val;
	this.HOT_Day002 *= val;
	this.HOT_Day003 *= val;
	this.HOT_Day004 *= val;
	this.HOT_Day005 *= val;
	this.HOT_Day006 *= val;
	this.HOT_Day007 *= val;
	this.HOT_Day008 *= val;
	this.HOT_Day009 *= val;
	this.HOT_Day010 *= val;
	this.HOT_Day011 *= val;
	this.HOT_Day012 *= val;
	this.HOT_Day013 *= val;
	this.HOT_Day014 *= val;
	this.HOT_Day015 *= val;
	this.HOT_Day016 *= val;
	this.HOT_Day017 *= val;
	this.HOT_Day018 *= val;
	this.HOT_Day019 *= val;
	this.HOT_Day020 *= val;
	this.HOT_Day021 *= val;
	this.HOT_Day022 *= val;
	this.HOT_Day023 *= val;
	this.HOT_Day024 *= val;
	this.HOT_Day025 *= val;
	this.HOT_Day026 *= val;
	this.HOT_Day027 *= val;
	this.HOT_Day028 *= val;
	this.HOT_Day029 *= val;
	this.HOT_Day030 *= val;
	this.HOT_Day031 *= val;
	this.HOT_Day032 *= val;
	this.HOT_Day033 *= val;
	this.HOT_Day034 *= val;
	this.HOT_Day035 *= val;
	this.HOT_Day036 *= val;
	this.HOT_Day037 *= val;
	this.HOT_Day038 *= val;
	this.HOT_Day039 *= val;
	this.HOT_Day040 *= val;
	this.HOT_Day041 *= val;
	this.HOT_Day042 *= val;
	this.HOT_Day043 *= val;
	this.HOT_Day044 *= val;
	this.HOT_Day045 *= val;
	this.HOT_Day046 *= val;
	this.HOT_Day047 *= val;
	this.HOT_Day048 *= val;
	this.HOT_Day049 *= val;
	this.HOT_Day050 *= val;
	this.HOT_Day051 *= val;
	this.HOT_Day052 *= val;
	this.HOT_Day053 *= val;
	this.HOT_Day054 *= val;
	this.HOT_Day055 *= val;
	this.HOT_Day056 *= val;
	this.HOT_Day057 *= val;
	this.HOT_Day058 *= val;
	this.HOT_Day059 *= val;
	this.HOT_Day060 *= val;

	this.HOT_Day061 *= val;
	this.HOT_Day062 *= val;
	this.HOT_Day063 *= val;
	this.HOT_Day064 *= val;
	this.HOT_Day065 *= val;
	this.HOT_Day066 *= val;
	this.HOT_Day067 *= val;
	this.HOT_Day068 *= val;
	this.HOT_Day069 *= val;
	this.HOT_Day070 *= val;
	this.HOT_Day071 *= val;
	this.HOT_Day072 *= val;
	this.HOT_Day073 *= val;
	this.HOT_Day074 *= val;
	this.HOT_Day075 *= val;
	this.HOT_Day076 *= val;
	this.HOT_Day077 *= val;
	this.HOT_Day078 *= val;
	this.HOT_Day079 *= val;
	this.HOT_Day080 *= val;
	this.HOT_Day081 *= val;
	this.HOT_Day082 *= val;
	this.HOT_Day083 *= val;
	this.HOT_Day084 *= val;
	this.HOT_Day085 *= val;
	this.HOT_Day086 *= val;
	this.HOT_Day087 *= val;
	this.HOT_Day088 *= val;
	this.HOT_Day089 *= val;
	this.HOT_Day090 *= val;

	this.HOT_MainMaterialQoh *= val;
}

public
void setHOT_IdAut(int HOT_IdAut){
	this.HOT_IdAut = HOT_IdAut;
}

public
void setHOT_Id(int HOT_Id){
	this.HOT_Id = HOT_Id;
}

public
void setHOT_ProdID(string HOT_ProdID){
	this.HOT_ProdID = HOT_ProdID;
}

public
void setHOT_ActID(string HOT_ActID){
	this.HOT_ActID = HOT_ActID;
}

public
void setHOT_Seq(int HOT_Seq){
	this.HOT_Seq = HOT_Seq;
}

public
void setHOT_MinorGroup(string HOT_MinorGroup){
	this.HOT_MinorGroup = HOT_MinorGroup;
}

public
void setHOT_MajorGroup(string HOT_MajorGroup){
	this.HOT_MajorGroup = HOT_MajorGroup;
}

public
void setHOT_Uom(string HOT_Uom){
	this.HOT_Uom = HOT_Uom;
}

public
void setHOT_Dept(string HOT_Dept){
	this.HOT_Dept = HOT_Dept;
}

public
void setHOT_Mach(string HOT_Mach){
	this.HOT_Mach = HOT_Mach;
}

public
void setHOT_MachCyc(decimal HOT_MachCyc){
	this.HOT_MachCyc = HOT_MachCyc;
}

public
void setHOT_Qoh(decimal HOT_Qoh){
	this.HOT_Qoh = HOT_Qoh;
}

public
void setHOT_QohCml(decimal HOT_QohCml){
	this.HOT_QohCml = HOT_QohCml;
}

public
void setHOT_PastDue(decimal HOT_PastDue){
	this.HOT_PastDue = HOT_PastDue;
}

public
void setHOT_Day001(decimal HOT_Day001){
	this.HOT_Day001 = HOT_Day001;
}

public
void setHOT_Day002(decimal HOT_Day002){
	this.HOT_Day002 = HOT_Day002;
}

public
void setHOT_Day003(decimal HOT_Day003){
	this.HOT_Day003 = HOT_Day003;
}

public
void setHOT_Day004(decimal HOT_Day004){
	this.HOT_Day004 = HOT_Day004;
}

public
void setHOT_Day005(decimal HOT_Day005){
	this.HOT_Day005 = HOT_Day005;
}

public
void setHOT_Day006(decimal HOT_Day006){
	this.HOT_Day006 = HOT_Day006;
}

public
void setHOT_Day007(decimal HOT_Day007){
	this.HOT_Day007 = HOT_Day007;
}

public
void setHOT_Day008(decimal HOT_Day008){
	this.HOT_Day008 = HOT_Day008;
}

public
void setHOT_Day009(decimal HOT_Day009){
	this.HOT_Day009 = HOT_Day009;
}

public
void setHOT_Day010(decimal HOT_Day010){
	this.HOT_Day010 = HOT_Day010;
}

public
void setHOT_Day011(decimal HOT_Day011){
	this.HOT_Day011 = HOT_Day011;
}

public
void setHOT_Day012(decimal HOT_Day012){
	this.HOT_Day012 = HOT_Day012;
}

public
void setHOT_Day013(decimal HOT_Day013){
	this.HOT_Day013 = HOT_Day013;
}

public
void setHOT_Day014(decimal HOT_Day014){
	this.HOT_Day014 = HOT_Day014;
}

public
void setHOT_Day015(decimal HOT_Day015){
	this.HOT_Day015 = HOT_Day015;
}

public
void setHOT_Day016(decimal HOT_Day016){
	this.HOT_Day016 = HOT_Day016;
}

public
void setHOT_Day017(decimal HOT_Day017){
	this.HOT_Day017 = HOT_Day017;
}

public
void setHOT_Day018(decimal HOT_Day018){
	this.HOT_Day018 = HOT_Day018;
}

public
void setHOT_Day019(decimal HOT_Day019){
	this.HOT_Day019 = HOT_Day019;
}

public
void setHOT_Day020(decimal HOT_Day020){
	this.HOT_Day020 = HOT_Day020;
}

public
void setHOT_Day021(decimal HOT_Day021){
	this.HOT_Day021 = HOT_Day021;
}

public
void setHOT_Day022(decimal HOT_Day022){
	this.HOT_Day022 = HOT_Day022;
}

public
void setHOT_Day023(decimal HOT_Day023){
	this.HOT_Day023 = HOT_Day023;
}

public
void setHOT_Day024(decimal HOT_Day024){
	this.HOT_Day024 = HOT_Day024;
}

public
void setHOT_Day025(decimal HOT_Day025){
	this.HOT_Day025 = HOT_Day025;
}

public
void setHOT_Day026(decimal HOT_Day026){
	this.HOT_Day026 = HOT_Day026;
}

public
void setHOT_Day027(decimal HOT_Day027){
	this.HOT_Day027 = HOT_Day027;
}

public
void setHOT_Day028(decimal HOT_Day028){
	this.HOT_Day028 = HOT_Day028;
}

public
void setHOT_Day029(decimal HOT_Day029){
	this.HOT_Day029 = HOT_Day029;
}

public
void setHOT_Day030(decimal HOT_Day030){
	this.HOT_Day030 = HOT_Day030;
}

public
void setHOT_Day031(decimal HOT_Day031){
	this.HOT_Day031 = HOT_Day031;
}

public
void setHOT_Day032(decimal HOT_Day032){
	this.HOT_Day032 = HOT_Day032;
}

public
void setHOT_Day033(decimal HOT_Day033){
	this.HOT_Day033 = HOT_Day033;
}

public
void setHOT_Day034(decimal HOT_Day034){
	this.HOT_Day034 = HOT_Day034;
}

public
void setHOT_Day035(decimal HOT_Day035){
	this.HOT_Day035 = HOT_Day035;
}

public
void setHOT_Day036(decimal HOT_Day036){
	this.HOT_Day036 = HOT_Day036;
}

public
void setHOT_Day037(decimal HOT_Day037){
	this.HOT_Day037 = HOT_Day037;
}

public
void setHOT_Day038(decimal HOT_Day038){
	this.HOT_Day038 = HOT_Day038;
}

public
void setHOT_Day039(decimal HOT_Day039){
	this.HOT_Day039 = HOT_Day039;
}

public
void setHOT_Day040(decimal HOT_Day040){
	this.HOT_Day040 = HOT_Day040;
}

public
void setHOT_Day041(decimal HOT_Day041){
	this.HOT_Day041 = HOT_Day041;
}

public
void setHOT_Day042(decimal HOT_Day042){
	this.HOT_Day042 = HOT_Day042;
}

public
void setHOT_Day043(decimal HOT_Day043){
	this.HOT_Day043 = HOT_Day043;
}

public
void setHOT_Day044(decimal HOT_Day044){
	this.HOT_Day044 = HOT_Day044;
}

public
void setHOT_Day045(decimal HOT_Day045){
	this.HOT_Day045 = HOT_Day045;
}

public
void setHOT_Day046(decimal HOT_Day046){
	this.HOT_Day046 = HOT_Day046;
}

public
void setHOT_Day047(decimal HOT_Day047){
	this.HOT_Day047 = HOT_Day047;
}

public
void setHOT_Day048(decimal HOT_Day048){
	this.HOT_Day048 = HOT_Day048;
}

public
void setHOT_Day049(decimal HOT_Day049){
	this.HOT_Day049 = HOT_Day049;
}

public
void setHOT_Day050(decimal HOT_Day050){
	this.HOT_Day050 = HOT_Day050;
}

public
void setHOT_Day051(decimal HOT_Day051){
	this.HOT_Day051 = HOT_Day051;
}

public
void setHOT_Day052(decimal HOT_Day052){
	this.HOT_Day052 = HOT_Day052;
}

public
void setHOT_Day053(decimal HOT_Day053){
	this.HOT_Day053 = HOT_Day053;
}

public
void setHOT_Day054(decimal HOT_Day054){
	this.HOT_Day054 = HOT_Day054;
}

public
void setHOT_Day055(decimal HOT_Day055){
	this.HOT_Day055 = HOT_Day055;
}

public
void setHOT_Day056(decimal HOT_Day056){
	this.HOT_Day056 = HOT_Day056;
}

public
void setHOT_Day057(decimal HOT_Day057){
	this.HOT_Day057 = HOT_Day057;
}

public
void setHOT_Day058(decimal HOT_Day058){
	this.HOT_Day058 = HOT_Day058;
}

public
void setHOT_Day059(decimal HOT_Day059){
	this.HOT_Day059 = HOT_Day059;
}

public
void setHOT_Day060(decimal HOT_Day060){
	this.HOT_Day060 = HOT_Day060;
}

public
void setHOT_Day061(decimal HOT_Day061){
	this.HOT_Day061 = HOT_Day061;
}

public
void setHOT_Day062(decimal HOT_Day062){
	this.HOT_Day062 = HOT_Day062;
}

public
void setHOT_Day063(decimal HOT_Day063){
	this.HOT_Day063 = HOT_Day063;
}

public
void setHOT_Day064(decimal HOT_Day064){
	this.HOT_Day064 = HOT_Day064;
}

public
void setHOT_Day065(decimal HOT_Day065){
	this.HOT_Day065 = HOT_Day065;
}

public
void setHOT_Day066(decimal HOT_Day066){
	this.HOT_Day066 = HOT_Day066;
}

public
void setHOT_Day067(decimal HOT_Day067){
	this.HOT_Day067 = HOT_Day067;
}

public
void setHOT_Day068(decimal HOT_Day068){
	this.HOT_Day068 = HOT_Day068;
}

public
void setHOT_Day069(decimal HOT_Day069){
	this.HOT_Day069 = HOT_Day069;
}

public
void setHOT_Day070(decimal HOT_Day070){
	this.HOT_Day070 = HOT_Day070;
}

public
void setHOT_Day071(decimal HOT_Day071){
	this.HOT_Day071 = HOT_Day071;
}

public
void setHOT_Day072(decimal HOT_Day072){
	this.HOT_Day072 = HOT_Day072;
}

public
void setHOT_Day073(decimal HOT_Day073){
	this.HOT_Day073 = HOT_Day073;
}

public
void setHOT_Day074(decimal HOT_Day074){
	this.HOT_Day074 = HOT_Day074;
}

public
void setHOT_Day075(decimal HOT_Day075){
	this.HOT_Day075 = HOT_Day075;
}

public
void setHOT_Day076(decimal HOT_Day076){
	this.HOT_Day076 = HOT_Day076;
}

public
void setHOT_Day077(decimal HOT_Day077){
	this.HOT_Day077 = HOT_Day077;
}

public
void setHOT_Day078(decimal HOT_Day078){
	this.HOT_Day078 = HOT_Day078;
}

public
void setHOT_Day079(decimal HOT_Day079){
	this.HOT_Day079 = HOT_Day079;
}

public
void setHOT_Day080(decimal HOT_Day080){
	this.HOT_Day080 = HOT_Day080;
}

public
void setHOT_Day081(decimal HOT_Day081){
	this.HOT_Day081 = HOT_Day081;
}

public
void setHOT_Day082(decimal HOT_Day082){
	this.HOT_Day082 = HOT_Day082;
}

public
void setHOT_Day083(decimal HOT_Day083){
	this.HOT_Day083 = HOT_Day083;
}

public
void setHOT_Day084(decimal HOT_Day084){
	this.HOT_Day084 = HOT_Day084;
}

public
void setHOT_Day085(decimal HOT_Day085){
	this.HOT_Day085 = HOT_Day085;
}

public
void setHOT_Day086(decimal HOT_Day086){
	this.HOT_Day086 = HOT_Day086;
}

public
void setHOT_Day087(decimal HOT_Day087){
	this.HOT_Day087 = HOT_Day087;
}

public
void setHOT_Day088(decimal HOT_Day088){
	this.HOT_Day088 = HOT_Day088;
}

public
void setHOT_Day089(decimal HOT_Day089){
	this.HOT_Day089 = HOT_Day089;
}

public
void setHOT_Day090(decimal HOT_Day090){
	this.HOT_Day090 = HOT_Day090;
}

public
void setHOT_Finalized(string HOT_Finalized){
	this.HOT_Finalized = HOT_Finalized;
}

public
void setHOT_Type(string HOT_Type){
	this.HOT_Type = HOT_Type;
}

public
void setHOT_MainMaterial(string HOT_MainMaterial){
	this.HOT_MainMaterial = HOT_MainMaterial;
}

public
void setHOT_MainMaterialSeq(int HOT_MainMaterialSeq){
	this.HOT_MainMaterialSeq = HOT_MainMaterialSeq;
}

public
void setHOT_MainMaterialQoh(decimal HOT_MainMaterialQoh){
	this.HOT_MainMaterialQoh = HOT_MainMaterialQoh;
}

public
void setHOT_Plt(string HOT_Plt){
	this.HOT_Plt = HOT_Plt;
}

public
void setHOT_Level(int HOT_Level){
	this.HOT_Level = HOT_Level;
}

public
int getHOT_IdAut(){
    return HOT_IdAut;
}

public
int getHOT_Id(){
	return this.HOT_Id;
}

public
string getHOT_ProdID(){
	return HOT_ProdID;
}

public
string getHOT_ActID(){
	return HOT_ActID;
}

public
string getHOT_MajorGroup(){
	return HOT_MajorGroup;
}

public
string getHOT_MinorGroup(){
	return HOT_MinorGroup;
}

public
int getHOT_Seq(){
	return HOT_Seq;
}

public
string getHOT_Uom(){
	return HOT_Uom;
}

public
string getHOT_Dept(){
	return HOT_Dept;
}

public
string getHOT_Mach(){
	return HOT_Mach;
}

public
decimal getHOT_MachCyc(){
	return HOT_MachCyc;
}

public
decimal getHOT_Qoh(){
	return HOT_Qoh;
}

public
decimal getHOT_QohCml(){
	return HOT_QohCml;
}

public
decimal getHOT_PastDue(){
	return HOT_PastDue;
}

public
decimal getHOT_Day001(){
	return HOT_Day001;
}

public
decimal getHOT_Day002(){
	return HOT_Day002;
}

public
decimal getHOT_Day003(){
	return HOT_Day003;
}

public
decimal getHOT_Day004(){
	return HOT_Day004;
}

public
decimal getHOT_Day005(){
	return HOT_Day005;
}

public
decimal getHOT_Day006(){
	return HOT_Day006;
}

public
decimal getHOT_Day007(){
	return HOT_Day007;
}

public
decimal getHOT_Day008(){
	return HOT_Day008;
}

public
decimal getHOT_Day009(){
	return HOT_Day009;
}

public
decimal getHOT_Day010(){
	return HOT_Day010;
}

public
decimal getHOT_Day011(){
	return HOT_Day011;
}

public
decimal getHOT_Day012(){
	return HOT_Day012;
}

public
decimal getHOT_Day013(){
	return HOT_Day013;
}

public
decimal getHOT_Day014(){
	return HOT_Day014;
}

public
decimal getHOT_Day015(){
	return HOT_Day015;
}

public
decimal getHOT_Day016(){
	return HOT_Day016;
}

public
decimal getHOT_Day017(){
	return HOT_Day017;
}

public
decimal getHOT_Day018(){
	return HOT_Day018;
}

public
decimal getHOT_Day019(){
	return HOT_Day019;
}

public
decimal getHOT_Day020(){
	return HOT_Day020;
}

public
decimal getHOT_Day021(){
	return HOT_Day021;
}

public
decimal getHOT_Day022(){
	return HOT_Day022;
}

public
decimal getHOT_Day023(){
	return HOT_Day023;
}

public
decimal getHOT_Day024(){
	return HOT_Day024;
}

public
decimal getHOT_Day025(){
	return HOT_Day025;
}

public
decimal getHOT_Day026(){
	return HOT_Day026;
}

public
decimal getHOT_Day027(){
	return HOT_Day027;
}

public
decimal getHOT_Day028(){
	return HOT_Day028;
}

public
decimal getHOT_Day029(){
	return HOT_Day029;
}

public
decimal getHOT_Day030(){
	return HOT_Day030;
}

public
decimal getHOT_Day031(){
	return HOT_Day031;
}

public
decimal getHOT_Day032(){
	return HOT_Day032;
}

public
decimal getHOT_Day033(){
	return HOT_Day033;
}

public
decimal getHOT_Day034(){
	return HOT_Day034;
}

public
decimal getHOT_Day035(){
	return HOT_Day035;
}

public
decimal getHOT_Day036(){
	return HOT_Day036;
}

public
decimal getHOT_Day037(){
	return HOT_Day037;
}

public
decimal getHOT_Day038(){
	return HOT_Day038;
}

public
decimal getHOT_Day039(){
	return HOT_Day039;
}

public
decimal getHOT_Day040(){
	return HOT_Day040;
}

public
decimal getHOT_Day041(){
	return HOT_Day041;
}

public
decimal getHOT_Day042(){
	return HOT_Day042;
}

public
decimal getHOT_Day043(){
	return HOT_Day043;
}

public
decimal getHOT_Day044(){
	return HOT_Day044;
}

public
decimal getHOT_Day045(){
	return HOT_Day045;
}

public
decimal getHOT_Day046(){
	return HOT_Day046;
}

public
decimal getHOT_Day047(){
	return HOT_Day047;
}

public
decimal getHOT_Day048(){
	return HOT_Day048;
}

public
decimal getHOT_Day049(){
	return HOT_Day049;
}

public
decimal getHOT_Day050(){
	return HOT_Day050;
}

public
decimal getHOT_Day051(){
	return HOT_Day051;
}

public
decimal getHOT_Day052(){
	return HOT_Day052;
}

public
decimal getHOT_Day053(){
	return HOT_Day053;
}

public
decimal getHOT_Day054(){
	return HOT_Day054;
}

public
decimal getHOT_Day055(){
	return HOT_Day055;
}

public
decimal getHOT_Day056(){
	return HOT_Day056;
}

public
decimal getHOT_Day057(){
	return HOT_Day057;
}

public
decimal getHOT_Day058(){
	return HOT_Day058;
}

public
decimal getHOT_Day059(){
	return HOT_Day059;
}

public
decimal getHOT_Day060(){
	return HOT_Day060;
}

public
decimal getHOT_Day061(){
	return HOT_Day061;
}

public
decimal getHOT_Day062(){
	return HOT_Day062;
}

public
decimal getHOT_Day063(){
	return HOT_Day063;
}

public
decimal getHOT_Day064(){
	return HOT_Day064;
}

public
decimal getHOT_Day065(){
	return HOT_Day065;
}

public
decimal getHOT_Day066(){
	return HOT_Day066;
}

public
decimal getHOT_Day067(){
	return HOT_Day067;
}

public
decimal getHOT_Day068(){
	return HOT_Day068;
}

public
decimal getHOT_Day069(){
	return HOT_Day069;
}

public
decimal getHOT_Day070(){
	return HOT_Day070;
}

public
decimal getHOT_Day071(){
	return HOT_Day071;
}

public
decimal getHOT_Day072(){
	return HOT_Day072;
}

public
decimal getHOT_Day073(){
	return HOT_Day073;
}

public
decimal getHOT_Day074(){
	return HOT_Day074;
}

public
decimal getHOT_Day075(){
	return HOT_Day075;
}

public
decimal getHOT_Day076(){
	return HOT_Day076;
}

public
decimal getHOT_Day077(){
	return HOT_Day077;
}

public
decimal getHOT_Day078(){
	return HOT_Day078;
}

public
decimal getHOT_Day079(){
	return HOT_Day079;
}

public
decimal getHOT_Day080(){
	return HOT_Day080;
}

public
decimal getHOT_Day081(){
	return HOT_Day081;
}

public
decimal getHOT_Day082(){
	return HOT_Day082;
}

public
decimal getHOT_Day083(){
	return HOT_Day083;
}

public
decimal getHOT_Day084(){
	return HOT_Day084;
}

public
decimal getHOT_Day085(){
	return HOT_Day085;
}

public
decimal getHOT_Day086(){
	return HOT_Day086;
}

public
decimal getHOT_Day087(){
	return HOT_Day087;
}

public
decimal getHOT_Day088(){
	return HOT_Day088;
}

public
decimal getHOT_Day089(){
	return HOT_Day089;
}

public
decimal getHOT_Day090(){
	return HOT_Day090;
}

public
string getHOT_Finalized(){
	return HOT_Finalized;
}

public
string getHOT_Type(){
	return HOT_Type;
}

public
string getHOT_MainMaterial(){
	return HOT_MainMaterial;
}

public
int getHOT_MainMaterialSeq(){
	return HOT_MainMaterialSeq;
}

public
decimal getHOT_MainMaterialQoh(){
	return HOT_MainMaterialQoh;
}

public
int getHOT_Level(){
	return HOT_Level;
}

public
string getHOT_Plt(){
	return HOT_Plt;
}


public
string getFieldNameByDate(DateTime runDate,DateTime dateFilter){
    string sfieldName ="";

    if (dateFilter < runDate)
        sfieldName = "PastDue";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate))
        sfieldName = "HOT_Day001";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(1)))
        sfieldName = "HOT_Day002";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(2)))
        sfieldName = "HOT_Day003";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(3)))
        sfieldName = "HOT_Day004";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(4)))
        sfieldName = "HOT_Day005";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(5)))
        sfieldName = "HOT_Day006";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(6)))
        sfieldName = "HOT_Day007";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(7)))
        sfieldName = "HOT_Day008";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(8)))
        sfieldName = "HOT_Day009";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(9)))
        sfieldName = "HOT_Day010";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(10)))
        sfieldName = "HOT_Day011";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(11)))
        sfieldName = "HOT_Day012";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(12)))
        sfieldName = "HOT_Day013";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(13)))
        sfieldName = "HOT_Day014";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(14)))
        sfieldName = "HOT_Day015";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(15)))
        sfieldName = "HOT_Day016";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(16)))
        sfieldName = "HOT_Day017";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(17)))
        sfieldName = "HOT_Day018";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(18)))
        sfieldName = "HOT_Day019";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(19)))
        sfieldName = "HOT_Day020";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(20)))
        sfieldName = "HOT_Day021";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(21)))
        sfieldName = "HOT_Day022";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(22)))
        sfieldName = "HOT_Day023";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(23)))
        sfieldName = "HOT_Day024";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(24)))
        sfieldName = "HOT_Day025";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(25)))
        sfieldName = "HOT_Day026";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(26)))
        sfieldName = "HOT_Day027";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(27)))
        sfieldName = "HOT_Day028";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(28)))
        sfieldName = "HOT_Day029";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(29)))
        sfieldName = "HOT_Day030";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(30)))
        sfieldName = "HOT_Day031";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(31)))
        sfieldName = "HOT_Day032";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(32)))
        sfieldName = "HOT_Day033";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(33)))
        sfieldName = "HOT_Day034";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(34)))
        sfieldName = "HOT_Day035";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(35)))
        sfieldName = "HOT_Day036";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(36)))
        sfieldName = "HOT_Day037";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(37)))
        sfieldName = "HOT_Day038";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(38)))
        sfieldName = "HOT_Day039";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(39)))
        sfieldName = "HOT_Day040";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(40)))
        sfieldName = "HOT_Day041";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(41)))
        sfieldName = "HOT_Day042";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(42)))
        sfieldName = "HOT_Day043";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(43)))
        sfieldName = "HOT_Day044";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(44)))
        sfieldName = "HOT_Day045";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(45)))
        sfieldName = "HOT_Day046";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(46)))
        sfieldName = "HOT_Day047";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(47)))
        sfieldName = "HOT_Day048";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(48)))
        sfieldName = "HOT_Day049";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(49)))
        sfieldName = "HOT_Day050";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(50)))
        sfieldName = "HOT_Day051";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(51)))
        sfieldName = "HOT_Day052";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(52)))
        sfieldName = "HOT_Day053";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(53)))
        sfieldName = "HOT_Day054";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(54)))
        sfieldName = "HOT_Day055";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(55)))
        sfieldName = "HOT_Day056";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(56)))
        sfieldName = "HOT_Day057";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(57)))
        sfieldName = "HOT_Day058";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(58)))
        sfieldName = "HOT_Day059";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(59)))
        sfieldName = "HOT_Day060";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(60)))
        sfieldName = "HOT_Day061";


    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(61)))
        sfieldName = "HOT_Day062";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(62)))
        sfieldName = "HOT_Day063";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(63)))
        sfieldName = "HOT_Day064";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(64)))
        sfieldName = "HOT_Day065";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(65)))
        sfieldName = "HOT_Day066";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(66)))
        sfieldName = "HOT_Day067";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(67)))
        sfieldName = "HOT_Day068";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(68)))
        sfieldName = "HOT_Day069";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(69)))
        sfieldName = "HOT_Day070";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(70)))
        sfieldName = "HOT_Day071";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(71)))
        sfieldName = "HOT_Day072";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(72)))
        sfieldName = "HOT_Day073";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(73)))
        sfieldName = "HOT_Day074";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(74)))
        sfieldName = "HOT_Day075";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(75)))
        sfieldName = "HOT_Day076";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(76)))
        sfieldName = "HOT_Day077";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(77)))
        sfieldName = "HOT_Day078";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(78)))
        sfieldName = "HOT_Day079";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(79)))
        sfieldName = "HOT_Day080";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(80)))
        sfieldName = "HOT_Day081";

    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(81)))
        sfieldName = "HOT_Day082";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(82)))
        sfieldName = "HOT_Day083";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(83)))
        sfieldName = "HOT_Day084";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(84)))
        sfieldName = "HOT_Day085";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(85)))
        sfieldName = "HOT_Day086";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(86)))
        sfieldName = "HOT_Day087";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(87)))
        sfieldName = "HOT_Day088";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(88)))
        sfieldName = "HOT_Day089";
    else if (Nujit.NujitERP.ClassLib.Util.DateUtil.sameDate(dateFilter,runDate.AddDays(89)))
        sfieldName = "HOT_Day090";

    return sfieldName;
}


} // class

} // namespace