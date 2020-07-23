using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Core.Engine;

namespace Nujit.NujitERP.ClassLib.Core.Remote{

/// <summary>
/// This class is the access point to the data and other core classes 
/// This contains funtionallity for manage all data in this system
/// </summary>
public
class LocalCoreFactory : SchLogCoreFactory, CoreFactory{

/// <summary>
/// Constructor
/// </summary>
public
LocalCoreFactory(){
}

/// <summary>
/// Destructor
/// </summary>
~LocalCoreFactory(){
	this.dataBaseAccess = null;
}


} // class
} // namespace