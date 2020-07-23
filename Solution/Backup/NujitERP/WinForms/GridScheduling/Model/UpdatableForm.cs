using System;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.Model
{
	public interface UpdatableForm
	{

		void updateStatus (string currentStatus, int progress);
		void processComplete();

	}
}
