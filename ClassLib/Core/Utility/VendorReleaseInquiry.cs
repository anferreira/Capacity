using System;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class VendorReleaseInquiry : CumulativeInventory{

private string releaseNum;

public
VendorReleaseInquiry(string supplier, string product, int seq, string description,
		string releaseNum, decimal pastDue, decimal ent1,
		decimal ent2, decimal ent3, decimal ent4, decimal ent5,
		decimal ent6, decimal ent7) : base(supplier, product, seq, description, pastDue, 
			ent1, ent2, ent3, ent4, ent5, ent6, ent7){
	
	this.releaseNum = releaseNum;
}

public
void setReleaseNum(string releaseNum){
	this.releaseNum = releaseNum;
}

public
string getReleaseNum(){
	return releaseNum;
}

} // class

} // namespace
