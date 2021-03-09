using Caliburn.Micro;
using RAMDesktopUI.EventModels;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RAMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName = "rsverma333@gmail.com";
        private string _password;
        private string _errorMessage;

        private readonly IAPIHelper _apiHelper;
        private readonly IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                return !string.IsNullOrEmpty(ErrorMessage);
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public bool CanLogIn
        {
            get
            {
                return !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password);
            }
        }

        public async Task ExecuteFilterView(KeyEventArgs keyArgs)
        {
            if (keyArgs.Key == Key.Enter && CanLogIn)
            {
                await LogIn();
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = string.Empty;
                var result = await _apiHelper.Authenticate(UserName, Password);

                //Capture more information about the user
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                await _events.PublishOnUIThreadAsync(new LogInOutEvent { IsLogin = true });
            }
            catch (HttpRequestException ex)
            {
                ErrorMessage = "Connection to server failed";
                Logger.LogError(ex, LogAction.LogOnly);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Bad Request"))
                    ErrorMessage = "Wrong Username or Password";
                else
                    ErrorMessage = ex.Message;
                Logger.LogError(ex, LogAction.LogOnly);
            }
        }

        public async Task Exit()
        {
            await _events.PublishOnUIThreadAsync(new ExitAppEvent());
        }
    }
}
