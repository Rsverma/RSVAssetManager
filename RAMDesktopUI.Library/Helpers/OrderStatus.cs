﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RAMDesktopUI.Library.Helpers
{
	public enum OrderStatus
	{
		New = '0',
		PartiallyFilled = '1',
		Filled = '2',
		DoneForDay = '3',
		Canceled = '4',
		PendingCancel = '6',
		Stopped = '7',
		Rejected = '8',
		Suspended = '9',
		PendingNew = 'A',
		Calculated = 'B',
		Expired = 'C',
		AcceptedForBidding = 'D',
		PendingReplace = 'E'
	}
}
