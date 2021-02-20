using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public interface IOrderFieldsEndpoint
    {
        Task<List<AccountModel>> GetAccounts();
        Task<List<BrokerModel>> GetBrokers();
        Task<List<SecurityModel>> GetSecurities();
    }
}
