using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RAMDesktopUI.EventModels;
using RAMDesktopUI.Library.Cache;
using static RAMDesktopUI.Library.Helpers.AppConstants;

namespace RAMDesktopUI.ViewModels
{
    public class HomeViewModel : Screen
    {
        private readonly IEventAggregator _events;
        private readonly IOrderCache _orderCache;
        private readonly IOrderFieldsCache _fieldsCache;
        private readonly IWatchlistCache _watchlistCache;
        private bool _isFieldCacheInitialized = false;
        private bool _isOrderCacheInitialized = false;
        private bool _isWatchlistCacheInitialized = false;

        public HomeViewModel(IEventAggregator events, IOrderFieldsCache fieldsCache, IOrderCache orderCache, IWatchlistCache watchlistCache)
        {
            fieldsCache.InitializationCompleted += FieldsCache_InitializationCompleted;
            _fieldsCache = fieldsCache;
            orderCache.InitializationCompleted += OrderCache_InitializationCompleted;
            _orderCache = orderCache;
            watchlistCache.InitializationCompleted += WatchlistCache_InitializationCompleted;
            _watchlistCache = watchlistCache;
            _events = events;
        }

        private void WatchlistCache_InitializationCompleted(object sender, EventArgs e)
        {
            _isWatchlistCacheInitialized = true;
            NotifyOfPropertyChange(() => CanLaunchWatchlist);
            _watchlistCache.InitializationCompleted -= WatchlistCache_InitializationCompleted;
        }

        private void FieldsCache_InitializationCompleted(object sender, EventArgs e)
        {
            _isFieldCacheInitialized = true;
            NotifyOfPropertyChange(() => CanLaunchOrderTicket);
            NotifyOfPropertyChange(() => CanLaunchTradeBlotter);
            NotifyOfPropertyChange(() => CanLaunchWatchlist);
            _fieldsCache.InitializationCompleted -= FieldsCache_InitializationCompleted;
        }

        private void OrderCache_InitializationCompleted(object sender, EventArgs e)
        {
            _isOrderCacheInitialized = true;
            NotifyOfPropertyChange(() => CanLaunchOrderTicket);
            NotifyOfPropertyChange(() => CanLaunchTradeBlotter);
            _orderCache.InitializationCompleted -= OrderCache_InitializationCompleted;
        }

        public bool CanLaunchOrderTicket { get { return _isFieldCacheInitialized; } }
        public bool CanLaunchTradeBlotter { get { return _isOrderCacheInitialized && _isFieldCacheInitialized; } }
        public bool CanLaunchPositionManager { get { return false; } }
        public bool CanLaunchPortfolioMonitor { get { return false; } }
        public bool CanLaunchWatchlist { get { return _isWatchlistCacheInitialized && _isFieldCacheInitialized; } }
        public bool CanLaunchImportManager { get { return false; } }
        public bool CanLaunchComplianceManager { get { return false; } }
        public bool CanLaunchTaxLotManager { get { return false; } }
        public bool CanLaunchSecurityMaster { get { return false; } }
        public bool CanLaunchTradeDelivery { get { return false; } }
        public bool CanLaunchAuditTrail { get { return false; } }
        public bool CanLaunchUserPreferences { get { return false; } }
        public async Task LogOut()
        {
            await _events.PublishOnUIThreadAsync(new LogInOutEvent { IsLogin = false });
        }

        public async Task Exit()
        {
            await _events.PublishOnUIThreadAsync(new ExitAppEvent());
        }

        public async Task LaunchOrderTicket()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.OrderTicket));
        }

        public async Task LaunchTradeBlotter()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.TradeBlotter));
        }

        public async Task LaunchPositionManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.PositionManager));
        }

        public async Task LaunchPortfolioMonitor()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.PortfolioMonitor));
        }

        public async Task LaunchWatchlist()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.Watchlist));
        }

        public async Task LaunchImportManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.ImportImportManager));
        }
        public async Task LaunchComplianceManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.ComplianceManager));
        }

        public async Task LaunchTaxLotManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.TaxLotManager));
        }

        public async Task LaunchSecurityMaster()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.SecurityMaster));
        }
        public async Task LaunchTradeDelivery()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.TradeDelivery));
        }

        public async Task LaunchAuditTrail()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.AuditTrail));
        }

        public async Task LaunchUserPreferences()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.UserPreferences));
        }
    }
}
