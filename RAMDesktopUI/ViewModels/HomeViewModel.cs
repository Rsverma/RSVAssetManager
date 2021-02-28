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
        private bool _isFieldCacheInitialized = false;
        private bool _isOrderCacheInitialized = false;

        public HomeViewModel(IEventAggregator events, IOrderCache orderCache, IOrderFieldsCache fieldsCache)
        {
            orderCache.InitializationCompleted += OrderCache_InitializationCompleted;
            fieldsCache.InitializationCompleted += FieldsCache_InitializationCompleted;
            _events = events;
            _orderCache = orderCache;
            _fieldsCache = fieldsCache;
        }

        private void FieldsCache_InitializationCompleted(object sender, EventArgs e)
        {
            _isFieldCacheInitialized = true;
            _fieldsCache.InitializationCompleted -= FieldsCache_InitializationCompleted;
        }

        private void OrderCache_InitializationCompleted(object sender, EventArgs e)
        {
            _isOrderCacheInitialized = true;
            _orderCache.InitializationCompleted -= OrderCache_InitializationCompleted;
        }

        public bool CanLaunchFundAllocater { get { return false; } }
        public bool CanLaunchImport { get { return false; } }
        public bool CanLaunchPortfolioManager { get { return false; } }
        public bool CanLaunchCreateOrder { get { return _isFieldCacheInitialized; } }
        public bool CanLaunchOrderManager { get { return _isOrderCacheInitialized && _isFieldCacheInitialized; } }
        public bool CanLaunchWatchlist { get { return true; } }
        public async Task LogOut()
        {
            await _events.PublishOnUIThreadAsync(new LogInOutEvent { IsLogin = false });
        }

        public async Task Exit()
        {
            await _events.PublishOnUIThreadAsync(new ExitAppEvent());
        }

        public async Task LaunchCreateOrder()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.CreateOrder));
        }

        public async Task LaunchOrderManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.OrderManager));
        }

        public async Task LaunchPortfolioManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.PortfolioManager));
        }

        public async Task LaunchFundAllocater()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.FundAllocater));
        }

        public async Task LaunchWatchlist()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.Watchlist));
        }

        public async Task LaunchImport()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent(ModuleTypes.Import));
        }
    }
}
