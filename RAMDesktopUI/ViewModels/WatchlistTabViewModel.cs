using Caliburn.Micro;
using HandyControl.Controls;
using RAMDesktopUI.Controls;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RAMDesktopUI.ViewModels
{
    public class WatchlistTabViewModel : Screen
    {
        private readonly IWatchlistCache _watchlistCache;
        private readonly int _tabIndex;

        public WatchlistTabViewModel(IWatchlistCache watchlistCache, int index)
        {
            _watchlistCache = watchlistCache;
            _tabIndex = index;
            WatchlistTabModel tabData = _watchlistCache.TabWiseData[_tabIndex];
            Header = tabData.TabName;
            foreach (string symbol in tabData.Symbols)
            {
                MarketDataRows.Add(new LiveFeedDataModel { Symbol = symbol });
            }
            Index1 = tabData.Index1;
            Index2 = tabData.Index2;
            Index3 = tabData.Index3;
            Index4 = tabData.Index4;
            Index5 = tabData.Index5;
            Index6 = tabData.Index6;
        }

        public string Header
        {
            get => header;
            set
            {
                header = value;
                NotifyOfPropertyChange(() => Header);
            }
        }
        public string Index1
        {
            get => index1; 
            set
            {
                index1 = value;
                NotifyOfPropertyChange(() => Index1);
            }
        }
        public string Index2
        {
            get => index2; 
            set
            {
                index2 = value;
                NotifyOfPropertyChange(() => Index2);
            }
        }
        public string Index3
        {
            get => index3; 
            set
            {
                index3 = value;
                NotifyOfPropertyChange(() => Index3);
            }
        }
        public string Index4
        {
            get => index4; 
            set
            {
                index4 = value;
                NotifyOfPropertyChange(() => Index4);
            }
        }
        public string Index5
        {
            get => index5; 
            set
            {
                index5 = value;
                NotifyOfPropertyChange(() => Index5);
            }
        }
        public string Index6
        {
            get => index6;
            set
            {
                index6 = value;
                NotifyOfPropertyChange(() => Index6);
            }
        }

        private ObservableCollection<LiveFeedDataModel> _marketDataRows = new ObservableCollection<LiveFeedDataModel>() { new LiveFeedDataModel { Symbol = "AAPL" } };
        private string header;
        private string index1;
        private string index2;
        private string index3;
        private string index4;
        private string index5;
        private string index6;

        public ObservableCollection<LiveFeedDataModel> MarketDataRows
        {
            get { return _marketDataRows; }
            set
            {
                _marketDataRows = value;
                NotifyOfPropertyChange(() => MarketDataRows);
            }
        }

        private string _symbol;

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                NotifyOfPropertyChange(() => Symbol);
            }
        }

        public void AddSymbol()
        {
            if(!string.IsNullOrWhiteSpace(Symbol))
            {
                string errMsg = _watchlistCache.AddSymbolToTab(Symbol, _tabIndex);
                if (string.IsNullOrWhiteSpace(errMsg))
                {
                    _marketDataRows.Add(new LiveFeedDataModel { Symbol = Symbol });
                }
            }
        }
        public void ImportSymbols()
        {

        }

        public void RenameTab()
        {
            InputBox popUp = new InputBox("Please enter tab name:", Header);

            if(popUp.ShowDialog() == true)
            {

            }
        }
    }
}
