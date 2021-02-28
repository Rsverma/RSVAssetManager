using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;

namespace RAMDesktopUI.Library.Cache
{
    public interface IOrderCache
    {
        event EventHandler InitializationCompleted;
        List<FillModel> Fills { get; }
        List<OrderModel> StageOrders { get; }
        List<OrderModel> SubOrders { get; }
    }
}