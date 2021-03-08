using RAMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public interface IWatchlistDataEndpoint
    {
        Task<Dictionary<int, WatchlistTabModel>> GetAllTabsData();
        Task PostTabSymbol(KeyValuePair<int, string> tabSymbol);
        Task DeleteTabSymbol(KeyValuePair<int, string> tabSymbol);
        Task PutTabIndices(KeyValuePair<int, List<string>> tabIndices);
        Task PutTabName(KeyValuePair<int, string> tabName);
    }
}