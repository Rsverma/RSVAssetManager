﻿using RAMDesktopUI.Library.Api;
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

        public string AddSymbolToTab(string symbol, int tabIndex)
        {
            string output = string.Empty;
            try
            {
                if (_tabWiseData[tabIndex].Symbols.Contains(symbol))
                {
                    output = "Symbol already exists in tab";
                }
                else
                {
                    _tabWiseData[tabIndex].Symbols.Add(symbol);
                    _watchlistData.PostTabSymbol(new KeyValuePair<int, string>(tabIndex, symbol));
                }
            }
            catch(Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }

        public string RenameTab(int tabIndex, string tabName)
        {
            string output = string.Empty;
            try
            {
                _tabWiseData[tabIndex].TabName = tabName;
                _watchlistData.PutTabName(new KeyValuePair<int, string>(tabIndex, tabName));
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }

        public string RemoveSymbolFromTab(string symbol, int tabIndex)
        {
            string output = string.Empty;
            try
            {
                if (_tabWiseData[tabIndex].Symbols.Contains(symbol))
                {
                    _tabWiseData[tabIndex].Symbols.Remove(symbol);
                    _watchlistData.DeleteTabSymbol(new KeyValuePair<int, string>(tabIndex, symbol));
                }
                else
                {
                    output = "Symbol not found in tab";
                }
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }
    }
}
