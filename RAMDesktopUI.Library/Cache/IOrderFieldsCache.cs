using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;

namespace RAMDesktopUI.Library.Cache
{
    public interface IOrderFieldsCache
    {
        event EventHandler InitializationCompleted;
        List<AccountModel> Accounts { get; }
        List<BrokerModel> Brokers { get; }
        List<SecurityModel> Securities { get; }
        List<UserModel> Users { get; }
    }
}