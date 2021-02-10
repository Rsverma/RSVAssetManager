using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RAMDesktopUI.EventModels;

namespace RAMDesktopUI.ViewModels
{
    public class HomeViewModel : Screen
    {
        private readonly IEventAggregator _events;

        public HomeViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public async Task LaunchCreateOrder()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent("CreateOrder"));
        }

        public async Task LaunchOrderManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent("OrderManager"));
        }

        public async Task LaunchPortfolioManager()
        {
            await _events.PublishOnUIThreadAsync(new LaunchModuleEvent("PortfolioManager"));
        }
    }
}
