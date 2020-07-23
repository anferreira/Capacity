using System;
using MySql.Data;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class UserDataBaseContainer : GenericDataBaseContainer{

public
UserDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
	while(reader.Read()){
		UserDataBase userDataBase = new UserDataBase(dataBaseAccess);
		userDataBase.load(reader);
		this.Add(userDataBase);
	}
}

public
void read(){
    string sql = "select * from users";
    read(sql);
}

} // class

} // namespace