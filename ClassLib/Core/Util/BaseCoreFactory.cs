using System;
using System.Collections;

using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public abstract
class BaseCoreFactory : MarshalByRefObject{

/// <summary>
/// attributes
/// </summary>
protected DataBaseAccess dataBaseAccess;
protected bool userHandleTransaction = false;

/// <summary>
/// Constructor
/// </summary>
protected
BaseCoreFactory() : base(){
	try{
		dataBaseAccess = new DataBaseAccess();
	}catch(System.Exception exc){
		throw new NujitException("Unespected exception " + exc.Message, exc);
	}
}

/// <summary>
/// begin a transaction
/// </summary>
public
void beginTransaction(){
	dataBaseAccess.beginTransaction();
	userHandleTransaction = true;
}

/// <summary>
/// commits an open transaction
/// </summary>
public
void commitTransaction(){
	dataBaseAccess.commitTransaction();
	userHandleTransaction = false;
}

/// <summary>
/// rollbacks a transaction
/// </summary>
public
void rollbackTransaction(){
	dataBaseAccess.rollbackTransaction();
	userHandleTransaction = false;
}

} // class

} // namespace