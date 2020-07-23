using System;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class PersistenceException : System.ApplicationException{

public
PersistenceException(string message) : base(message){
}

public
PersistenceException(string message, System.Exception innerException) : base(message, innerException){
}

} // class

} // namespace
