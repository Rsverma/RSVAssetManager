using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class WatchlistViewModel : ModuleBase
    {
        private readonly IWatchlistCache _watchlistCache;
        public ObservableCollection<WatchlistTabViewModel> Tabs { get; set; }
        public WatchlistViewModel(IWatchlistCache watchlistCache)
        {
            CurWindowState = WindowState.Maximized;
            _watchlistCache = watchlistCache;
            Tabs = new ObservableCollection<WatchlistTabViewModel>();
            Tabs.Add(new WatchlistTabViewModel(watchlistCache, 1));
            Tabs.Add(new WatchlistTabViewModel(watchlistCache, 2));
            Tabs.Add(new WatchlistTabViewModel(watchlistCache, 3));
            Tabs.Add(new WatchlistTabViewModel(watchlistCache, 4));
            Tabs.Add(new WatchlistTabViewModel(watchlistCache, 5));
        }
    }
}