using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RAMDesktopUI.EventModels;
using static RAMDesktopUI.Library.Helpers.AppConstants;

namespace RAMDesktopUI.ViewModels
{
    public class HomeViewModel : Screen
    {
        private readonly IEventAggregator _events;

        public HomeViewModel(IEventAggregator events)
        {
            _events = events;
        }
        public bool CanLaunchFundAllocater { get { return false; } }
        public bool CanLaunchImport { get { return false; } }
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
