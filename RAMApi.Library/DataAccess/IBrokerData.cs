using RAMApi.Library.Models;
using System.Collections.Generic;

namespace RAMApi.Library.DataAccess
{
    public interface IBrokerData
    {
        List<BrokerModel> GetAllBrokers();
    }
}