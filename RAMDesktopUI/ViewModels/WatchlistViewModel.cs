using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
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
        public WatchlistViewModel(IWatchlistCache watchlistCache)
        {
            CurWindowState = WindowState.Maximized;
            _watchlistCache = watchlistCache;
            Tab1Header = watchlistCache.TabWiseData[1].TabName;
            Tab2Header = watchlistCache.TabWiseData[2].TabName;
            Tab3Header = watchlistCache.TabWiseData[3].TabName;
            Tab4Header = watchlistCache.TabWiseData[4].TabName;
            Tab5Header = watchlistCache.TabWiseData[5].TabName;
        }

        private string _tab1Header;
        public string Tab1Header
        {
            get { return _tab1Header; }
            set
            {
                _tab1Header = value;
                NotifyOfPropertyChange(() => Tab1Header);
            }
        }

        private string _tab2Header;
        public string Tab2Header
        {
            get { return _tab2Header; }
            set
            {
                _tab2Header = value;
                NotifyOfPropertyChange(() => Tab2Header);
            }
        }

        private string _tab3Header;
        public string Tab3Header
        {
            get { return _tab3Header; }
            set
            {
                _tab3Header = value;
                NotifyOfPropertyChange(() => Tab3Header);
            }
        }

        private string _tab4Header;
        public string Tab4Header
        {
            get { return _tab4Header; }
            set
            {
                _tab4Header = value;
                NotifyOfPropertyChange(() => Tab4Header);
            }
        }

        private string _tab5Header;
        public string Tab5Header
        {
            get { return _tab5Header; }
            set
            {
                _tab5Header = value;
                NotifyOfPropertyChange(() => Tab5Header);
            }
        }

    }
}