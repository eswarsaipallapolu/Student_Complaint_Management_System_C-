using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using StudentComplaintSystem.Models;
using StudentComplaintSystem.Services;

namespace StudentComplaintSystem.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private readonly AuthService _authService;
        private bool _isRoleSelected;
        private string _selectedRole;
        private string _loginId;
        private string _loginPassword;
        private bool _isLoginFailed;
        private UserRole _currentRole;

        public HomeViewModel()
        {
            _authService = new AuthService();
            SelectRoleCommand = new RelayCommand(SelectRole);
            LoginCommand = new RelayCommand(Login);
            BackCommand = new RelayCommand(Back);
        }

        public bool IsRoleSelected
        {
            get => _isRoleSelected;
            set
            {
                _isRoleSelected = value;
                OnPropertyChanged();
            }
        }

        public string SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged();
            }
        }

        public string LoginId
        {
            get => _loginId;
            set
            {
                _loginId = value;
                OnPropertyChanged();
            }
        }

        public string LoginPassword
        {
            get => _loginPassword;
            set
            {
                _loginPassword = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoginFailed
        {
            get => _isLoginFailed;
            set
            {
                _isLoginFailed = value;
                OnPropertyChanged();
            }
        }

        public UserRole CurrentRole
        {
            get => _currentRole;
            set
            {
                _currentRole = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectRoleCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand BackCommand { get; }

        private void SelectRole(object parameter)
        {
            SelectedRole = parameter?.ToString();
            IsRoleSelected = true;
            IsLoginFailed = false;
            LoginId = string.Empty;
            LoginPassword = string.Empty;
        }

        private void Login(object parameter)
        {
            var role = SelectedRole == "Student" ? UserRole.Student : UserRole.Admin;
            var (isAuthenticated, userRole) = _authService.Authenticate(LoginId, LoginPassword, role);
            if (isAuthenticated)
            {
                CurrentRole = userRole;
                IsLoginFailed = false;
                LoginSuccessful?.Invoke(this, userRole);
            }
            else
            {
                IsLoginFailed = true;
            }
        }

        private void Back(object parameter)
        {
            IsRoleSelected = false;
            SelectedRole = string.Empty;
            IsLoginFailed = false;
            LoginId = string.Empty;
            LoginPassword = string.Empty;
        }

        public event EventHandler<UserRole> LoginSuccessful;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}