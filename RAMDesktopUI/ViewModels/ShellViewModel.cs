using Caliburn.Micro;
using RAMDesktopUI.EventModels;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>, IHandle<LaunchModuleEvent>
    {
        private readonly IEventAggregator _events;
        private readonly IWindowManager _window;
        private readonly ILoggedInUserModel _user;
        private readonly IAPIHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, IWindowManager window,
            ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            _events = events;
            _window = window;
            _user = user;
            _apiHelper = apiHelper;
            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public bool IsLoggedIn
        {
            get
            {
                return !string.IsNullOrEmpty(_user.Token);
            }
        }

        public void ExitApplication()
        {
            TryCloseAsync();
        }
        public async Task LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public async Task UserManagement()
        {
            await ActivateItemAsync(IoC.Get<UserDisplayViewModel>());
        }


        public async Task HandleAsync(LaunchModuleEvent moduleEvent, CancellationToken cancellationToken)
        {
            dynamic settings = new ExpandoObject();
            settings.ShowInTaskbar = false;
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            switch (moduleEvent.ModuleName)
            {
                case "CreateOrder":
                    await _window.ShowWindowAsync(IoC.Get<CreateOrderViewModel>(), null, settings);
                    break;
                case "OrderManager":
                    await _window.ShowWindowAsync(IoC.Get<OrderManagerViewModel>(), null, settings);
                    break;
                case "PortfolioManager":
                    await _window.ShowWindowAsync(IoC.Get<PortfolioManagerViewModel>(), null, settings);
                    break;

            }
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<HomeViewModel>(), cancellationToken);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
