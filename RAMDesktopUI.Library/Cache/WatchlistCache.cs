using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Cache
{
    public class WatchlistCache : IWatchlistCache
    {
        private readonly IWatchlistDataEndpoint _watchlistData;
        public event EventHandler InitializationCompleted;

        public WatchlistCache(IWatchlistDataEndpoint watchlistData)
        {
            _watchlistData = watchlistData;
            _ = InitializeCache();
        }

        private async Task InitializeCache()
        {
            _tabWiseData = await _watchlistData.GetAllTabsData();
            InitializationCompleted?.Invoke(this, null);
        }

        private Dictionary<int, WatchlistTabModel> _tabWiseData;

        public Dictionary<int, WatchlistTabModel> TabWiseData
        {
            get { return _tabWiseData; }
        }

    }
}
