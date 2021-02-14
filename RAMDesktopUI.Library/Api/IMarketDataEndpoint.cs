using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public interface IMarketDataEndpoint
    {
        Task<List<LiveFeedDataModel>> GetSymbolMarketData(List<string> symbols);
        List<string> GetWatchlistSymbols();
        Task PostWatchlistSymbol(String symbol);
    }
}
