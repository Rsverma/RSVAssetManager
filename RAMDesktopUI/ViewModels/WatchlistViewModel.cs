using Caliburn.Micro;
using RAMDesktopUI.Helpers;
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
        private readonly IMarketDataHelper _dataHelper;

        public WatchlistTabViewModel Tab1 { get; set; }
        public WatchlistTabViewModel Tab2 { get; set; }
        public WatchlistTabViewModel Tab3 { get; set; }
        public WatchlistTabViewModel Tab4 { get; set; }
        public WatchlistTabViewModel Tab5 { get; set; }
        public WatchlistViewModel(IWatchlistCache watchlistCache, IMarketDataHelper dataHelper)
        {
            CurWindowState = WindowState.Maximized;
            _watchlistCache = watchlistCache;
            _dataHelper = dataHelper;
            ;
            IEnumerable<string> symbols = _watchlistCache.TabWiseData.SelectMany(x => x.Value.Symbols);
            _dataHelper.AddSymbols(symbols);
            Tab1 = new WatchlistTabViewModel(watchlistCache, 1);
            Tab2 = new WatchlistTabViewModel(watchlistCache, 2);
            Tab3 = new WatchlistTabViewModel(watchlistCache, 3);
            Tab4 = new WatchlistTabViewModel(watchlistCache, 4);
            Tab5 = new WatchlistTabViewModel(watchlistCache, 5);
            Tab1Checked = true;
        }

        private bool _tab1Checked;
        public bool Tab1Checked
        {
            get { return _tab1Checked; }
            set
            {
                _tab1Checked = value;
                NotifyOfPropertyChange(() => Tab1Checked);
            }
        }

        private bool _tab2Checked;
        public bool Tab2Checked
        {
            get { return _tab2Checked; }
            set
            {
                _tab2Checked = value;
                NotifyOfPropertyChange(() => Tab2Checked);
            }
        }

        private bool _tab3Checked;
        public bool Tab3Checked
        {
            get { return _tab3Checked; }
            set
            {
                _tab3Checked = value;
                NotifyOfPropertyChange(() => Tab3Checked);
            }
        }

        private bool _tab4Checked;
        public bool Tab4Checked
        {
            get { return _tab4Checked; }
            set
            {
                _tab4Checked = value;
                NotifyOfPropertyChange(() => Tab4Checked);
            }
        }

        private bool _tab5Checked;
        public bool Tab5Checked
        {
            get { return _tab5Checked; }
            set
            {
                _tab5Checked = value;
                NotifyOfPropertyChange(() => Tab5Checked);
            }
        }

    }
}