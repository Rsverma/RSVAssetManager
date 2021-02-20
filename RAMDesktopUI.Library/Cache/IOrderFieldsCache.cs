using RAMDesktopUI.Library.Models;
using System.Collections.Generic;

namespace RAMDesktopUI.Library.Cache
{
    public interface IOrderFieldsCache
    {
        List<AccountModel> Accounts { get; }
        List<BrokerModel> Brokers { get; }
        List<UserModel> Users { get; }
    }
}