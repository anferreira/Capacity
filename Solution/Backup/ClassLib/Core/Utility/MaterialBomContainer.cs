using System;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class MaterialBomContainer : ArrayList{

private decimal possible = 0;

public 
MaterialBomContainer() : base(){
}

public 
decimal getPossible(){ 
	return possible; 
}

public 
void setPossible(decimal possible){ 
	this.possible = possible; 
}

} // class

} // namespace
