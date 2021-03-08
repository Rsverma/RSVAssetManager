using Caliburn.Micro;
using RAMDesktopUI.Controls;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RAMDesktopUI.ViewModels
{
    public class WatchlistTabViewModel : Screen
    {
        private readonly IWatchlistCache _watchlistCache;
        private readonly int _tabIndex;
        private ObservableCollection<LiveFeedDataModel> _liveFeedData;

        public ObservableCollection<LiveFeedDataModel> LiveFeedData
        {
            get { return _liveFeedData; }
            set
            {
                _liveFeedData = value;
                NotifyOfPropertyChange(() => LiveFeedData);
            }
        }

        private ICollectionView _marketDataRows;
        public ICollectionView MarketDataRows
        {
            get { return _marketDataRows; }
        }
        public WatchlistTabViewModel(IWatchlistCache watchlistCache, int index)
        {
            _watchlistCache = watchlistCache;
            _tabIndex = index;
            WatchlistTabModel tabData = _watchlistCache.TabWiseData[_tabIndex];
            Header = tabData.TabName;
            var dataList = tabData.Symbols.Select(x => new LiveFeedDataModel { Symbol = x });

            LiveFeedData = new ObservableCollection<LiveFeedDataModel>(dataList);
            _marketDataRows = CollectionViewSource.GetDefaultView(LiveFeedData);
            _marketDataRows.CurrentChanged += _marketDataRows_CurrentChanged;
            _marketDataRows.Filter = _marketDataRows_Filter;
            Index1 = tabData.Index1;
            Index2 = tabData.Index2;
            Index3 = tabData.Index3;
            Index4 = tabData.Index4;
            Index5 = tabData.Index5;
            Index6 = tabData.Index6;
        }

        private bool _marketDataRows_Filter(object obj)
        {
            return true;
            //throw new NotImplementedException();
        }

        private void _marketDataRows_CurrentChanged(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
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

        private string header;
        private string index1;
        private string index2;
        private string index3;
        private string index4;
        private string index5;
        private string index6;

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
                    LiveFeedData.Add(new LiveFeedDataModel { Symbol = Symbol });
                    Symbol = string.Empty;
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
                if (!string.IsNullOrWhiteSpace(popUp.Answer) && !Header.Equals(popUp.Answer))
                {
                    string errMsg = _watchlistCache.RenameTab(_tabIndex, popUp.Answer);
                    if (string.IsNullOrWhiteSpace(errMsg))
                    {
                        Header = popUp.Answer;
                    }
                }
            }
        }

        public async Task UpdateLiveData(IDictionary<string, LiveFeedDataModel> liveFeedDict)
        {
            for (int i = 0; i < LiveFeedData.Count; i++)
            {
                LiveFeedDataModel data = LiveFeedData[i];
                if (liveFeedDict.ContainsKey(data.Symbol))
                    LiveFeedData[i] = liveFeedDict[data.Symbol];
            }
            NotifyOfPropertyChange(() => LiveFeedData);
            await Task.CompletedTask;
        }
    }
}
