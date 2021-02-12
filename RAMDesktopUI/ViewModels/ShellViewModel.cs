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
        private CreateOrderViewModel CreateOrderView = null;
        private OrderManagerViewModel OrderManagerView = null;
        private PortfolioManagerViewModel PortfolioManagerView = null;

        public async Task HandleAsync(LaunchModuleEvent moduleEvent, CancellationToken cancellationToken)
        {
            dynamic settings = new ExpandoObject();
            settings.ShowInTaskbar = false;
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            switch (moduleEvent.ModuleName)
            {
                case "CreateOrder":
                    if (CreateOrderView == null)
                    {
                        CreateOrderView = IoC.Get<CreateOrderViewModel>();
                        CreateOrderView.ActivateWith(this);
                        await _window.ShowWindowAsync(CreateOrderView, null, settings);
                    }
                    else
                    {
                        CreateOrderView.CurWindowState = WindowState.Normal;
                        ((Window)CreateOrderView.GetView()).Activate();
                    }
                    break;
                case "OrderManager":
                    if (OrderManagerView == null)
                    {
                        OrderManagerView = IoC.Get<OrderManagerViewModel>();
                        OrderManagerView.ActivateWith(this);
                        await _window.ShowWindowAsync(OrderManagerView, null, settings);
                    }
                    else
                    {
                        OrderManagerView.CurWindowState = WindowState.Normal;
                        ((Window)OrderManagerView.GetView()).Activate();
                    }
                    break;
                case "PortfolioManager":
                    if (PortfolioManagerView == null)
                    {
                        PortfolioManagerView = IoC.Get<PortfolioManagerViewModel>();
                        PortfolioManagerView.ActivateWith(this);
                        await _window.ShowWindowAsync(PortfolioManagerView, null, settings);
                    }
                    else
                    {
                        PortfolioManagerView.CurWindowState = WindowState.Normal;
                        ((Window)PortfolioManagerView.GetView()).Activate();
                    }
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
