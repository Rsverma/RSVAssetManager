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
using static RAMDesktopUI.Library.Helpers.AppConstants;

namespace RAMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogInOutEvent>, IHandle<LaunchModuleEvent>,IHandle<ExitAppEvent>
    {
        private readonly IEventAggregator _events;
        private readonly IWindowManager _window;
        private readonly ILoggedInUserModel _user;
        private readonly IAPIHelper _apiHelper;
        private readonly Dictionary<ModuleTypes, ModuleBase> _modules = new Dictionary<ModuleTypes, ModuleBase>();

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

        public void ModuleClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window moduleWindow = sender as Window;
            if(Enum.TryParse(moduleWindow.Name, out ModuleTypes modType))
                _modules.Remove(modType);
            moduleWindow.Closing -= ModuleClosing;
        }

        public async Task HandleAsync(LaunchModuleEvent moduleEvent, CancellationToken cancellationToken)
        {
            if (!_modules.ContainsKey(moduleEvent.ModuleType))
            {
                dynamic settings = new ExpandoObject();
                settings.ShowInTaskbar = false;
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                ModuleBase viewModel = null;
                switch (moduleEvent.ModuleType)
                {
                    case ModuleTypes.CreateOrder:
                        viewModel = IoC.Get<CreateOrderViewModel>();
                        break;
                    case ModuleTypes.OrderManager:
                        viewModel = IoC.Get<OrderManagerViewModel>();
                        break;
                    case ModuleTypes.PortfolioManager:
                        viewModel = IoC.Get<PortfolioManagerViewModel>();
                        break;
                }
                viewModel.ActivateWith(this);
                _modules.Add(moduleEvent.ModuleType, viewModel);
                await _window.ShowWindowAsync(viewModel, null, settings);
                ((Window)viewModel.GetView()).Closing += ModuleClosing;
            }
            else
            {
                ModuleBase viewModel = _modules[moduleEvent.ModuleType];
                if (viewModel.CurWindowState == WindowState.Minimized)
                    viewModel.CurWindowState = WindowState.Normal;
                ((Window)viewModel.GetView()).Activate();
            }

        }

        public async Task HandleAsync(LogInOutEvent message, CancellationToken cancellationToken)
        {
            if (message.IsLogin)
                await ActivateItemAsync(IoC.Get<HomeViewModel>(), cancellationToken);
            else
            {
                _user.ResetUserModel();
                _apiHelper.LogOffUser();
                await ActivateItemAsync(IoC.Get<LoginViewModel>(), cancellationToken);
            }
        }
        
        public async Task HandleAsync(ExitAppEvent message, CancellationToken cancellationToken)
        {
            await TryCloseAsync();
        }
    }
}
