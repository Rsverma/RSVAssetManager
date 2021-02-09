using Caliburn.Micro;
using RAMDesktopUI.Library.Api;
using RAMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class UserDisplayViewModel :Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private BindingList<UserModel> _users;
        private List<string> _allRoles;

        public UserDisplayViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
        }

        public BindingList<UserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }

        private UserModel _selectedUser;

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                UserRoles = new BindingList<string>(value.Roles.Select(x => x.Value).ToList());
                AvailableRoles = new BindingList<string>(_allRoles.Where(x => !UserRoles.Contains(x)).ToList());
                NotifyOfPropertyChange(() => SelectedUser);
                NotifyOfPropertyChange(() => SelectedUserName);
            }
        }

        private string _selectedUserRole;

        public string SelectedUserRole
        {
            get { return _selectedUserRole; }
            set
            {
                _selectedUserRole = value;
                NotifyOfPropertyChange(() => SelectedUserRole);
            }
        }

        private string _selectedAvailableRole;

        public string SelectedAvailableRole
        {
            get { return _selectedAvailableRole; }
            set
            {
                _selectedAvailableRole = value;
                NotifyOfPropertyChange(() => SelectedAvailableRole);
            }
        }


        public string SelectedUserName
        {
            get
            {
                return SelectedUser?.Email;
            }
        }

        private BindingList<string> _userRoles = new BindingList<string>();

        public BindingList<string> UserRoles
        {
            get { return _userRoles; }
            set
            {
                _userRoles = value;
                NotifyOfPropertyChange(() => UserRoles);
            }
        }

        private BindingList<string> _availableRoles = new BindingList<string>();

        public BindingList<string> AvailableRoles
        {
            get { return _availableRoles; }
            set
            {
                _availableRoles = value;
                NotifyOfPropertyChange(() => AvailableRoles);
            }
        }


        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadUsersAndRoles();
        }

        private async Task LoadUsersAndRoles()
        {
            try
            {
                var userList = await _userEndpoint.GetAll();
                Users = new BindingList<UserModel>(userList);
                var roles = await _userEndpoint.GetAllRoles();
                _allRoles = roles.Values.ToList();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";
                if (ex.Message.Equals("Unauthorized"))
                {
                    _status.UpdateMessage("Unauthorized Exception", "You do not have permission to interact with the sales form.");
                    await _window.ShowDialogAsync(_status, null, settings);
                }
                else
                {
                    _status.UpdateMessage("Fatal Exception", ex.Message);
                    await _window.ShowDialogAsync(_status, null, settings);
                }
                await TryCloseAsync();
            }
        }

        public async void AddSelectedRole()
        {
            if (!string.IsNullOrEmpty(SelectedAvailableRole))
            {
                await _userEndpoint.AddUserToRole(SelectedUser.Id, SelectedAvailableRole);
                UserRoles.Add(SelectedAvailableRole);
                AvailableRoles.Remove(SelectedAvailableRole);
            }
        }
        public async void RemoveSelectedRole()
        {
            if (!string.IsNullOrEmpty(SelectedUserRole))
            {
                await _userEndpoint.RemoveUserFromRole(SelectedUser.Id, SelectedUserRole);
                AvailableRoles.Add(SelectedUserRole);
                UserRoles.Remove(SelectedUserRole);
            }
        }
    }
}
