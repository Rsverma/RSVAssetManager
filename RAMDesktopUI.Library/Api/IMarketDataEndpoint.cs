using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public interface IMarketDataEndpoint
    {
        Task<List<LiveFeedDataModel>> GetSymbolMarketData(ICollection<string> symbols);
    }
}
