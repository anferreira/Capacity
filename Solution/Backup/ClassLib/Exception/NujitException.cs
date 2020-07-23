using System;


namespace Nujit.NujitERP.ClassLib.ErpException{


public
class NujitException : System.ApplicationException{

public
NujitException(string message) : base(message){
}

public
NujitException(string message, System.Exception innerException) : base(message, innerException){
}

} // class 

} // namespace
