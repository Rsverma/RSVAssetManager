using Caliburn.Micro;
using RAMDesktopUI.Helpers;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Cache;
using RAMDesktopUI.Library.Models;
using RAMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RAMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ConventionManager.AddElementConvention<FrameworkElement>(
         UIElement.IsEnabledProperty,
         "IsEnabled",
         "IsEnabledChanged");
            var baseBindProperties = ViewModelBinder.BindProperties;
            ViewModelBinder.BindProperties =
                (frameWorkElements, viewModels) =>
                {
                    foreach (var frameworkElement in frameWorkElements)
                    {
                        var propertyName = frameworkElement.Name + "Enabled";
                        var property = viewModels
                             .GetPropertyCaseInsensitive(propertyName);
                        if (property != null)
                        {
                            var convention = ConventionManager
                                .GetElementConvention(typeof(FrameworkElement));
                            ConventionManager.SetBindingWithoutBindingOverwrite(
                                viewModels,
                                propertyName,
                                property,
                                frameworkElement,
                                convention,
                                convention.GetBindableProperty(frameworkElement));
                        }
                    }
                    return baseBindProperties(frameWorkElements, viewModels);
                };
            ConventionManager.AddElementConvention<PasswordBox>(
             PasswordBoxHelper.BoundPasswordProperty,
             "Password",
             "PasswordChanged");
        }

        protected override void Configure()
        {
            _ = _container.Instance(_container);

            _container.Instance(_container)
                .PerRequest<IUserEndpoint, UserEndpoint>()
                .PerRequest<IMarketDataEndpoint, MarketDataEndpoint>()
                .PerRequest<IOrderEndpoint, OrderEndpoint>()
                .PerRequest<IFillEndpoint, FillEndpoint>()
                .PerRequest<IOrderFieldsEndpoint, OrderFieldsEndpoint>()
                .PerRequest<IWatchlistDataEndpoint, WatchlistDataEndpoint>();
            _ = _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILoggedInUserModel, LoggedInUserModel>()
                .Singleton<IOrderFieldsCache, OrderFieldsCache>()
                .Singleton<IOrderCache, OrderCache>()
                .Singleton<IWatchlistCache, WatchlistCache>()
                .Singleton<IMarketDataHelper, MarketDataHelper>()
                .Singleton<IAPIHelper, APIHelper>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass && type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
