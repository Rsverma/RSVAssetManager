using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;

namespace RAMDesktopUI.Library.Cache
{
    public interface IWatchlistCache
    {
        Dictionary<int, WatchlistTabModel> TabWiseData { get; }

        event EventHandler InitializationCompleted;
        string AddSymbolToTab(string symbol, int tabIndex);
        string RemoveSymbolFromTab(string symbol, int tabIndex);
        string RenameTab(int tabIndex, string tabName);
    }
}