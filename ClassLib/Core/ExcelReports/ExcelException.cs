using System;

namespace Nujit.NujitERP.ClassLib.Core.ExcelReports{

public
class ExcelException : System.ApplicationException{

public
ExcelException(string message) : base(message){
}

public
ExcelException(string message, System.Exception innerException) : base(message, innerException){
}

} // class 

} // namespace
