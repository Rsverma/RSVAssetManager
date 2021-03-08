using RAMApi.Library.Models;
using System.Collections.Generic;

namespace RAMApi.Library.DataAccess
{
    public interface IWatchlistData
    {
        Dictionary<int, WatchlistTabModel> GetAllTabsData();
        void SaveTabSymbol(KeyValuePair<int, string> tabSymbol);
        void UpdateTabIndices(KeyValuePair<int, List<string>> tabIndices);
        void UpdateTabName(KeyValuePair<int, string> tabName);
        void DeleteTabSymbol(KeyValuePair<int, string> tabSymbol);
    }
}