using System;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public 
class UserContainer : ArrayList{

public 
UserContainer() : base(){
}

public
User get(string loginName){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		User user = (User) en.Current;
		if (user.getLoginName().Equals(loginName))
			return user;
	}
	return null;
}

} // class

} // namespace
