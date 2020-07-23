using System;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class VendorReleaseInquiryContainer : CumulativeInventoryContainer{

public 
VendorReleaseInquiryContainer() : base(){
}

public 
VendorReleaseInquiry getVendorReleaseInquiry(string supplier, string product,
			int seq, string releaseNum){

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		VendorReleaseInquiry vendorReleaseInquiry = (VendorReleaseInquiry)en.Current;

		if ((vendorReleaseInquiry.getSupplier().Equals(supplier)) &&
				(vendorReleaseInquiry.getProduct().Equals(product)) &&
				(vendorReleaseInquiry.getSeq() == seq) &&
				(vendorReleaseInquiry.getReleaseNum().Equals(releaseNum))){

			return vendorReleaseInquiry;
		}
	}
	return null;
}

} // class

} // namespace
