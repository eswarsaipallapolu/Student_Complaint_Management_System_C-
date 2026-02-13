using System;
using System.Windows;
using StudentComplaintSystem.Services;
using StudentComplaintSystem.ViewModels;
using StudentComplaintSystem.Views;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem
{
    public partial class MainWindow : Window
    {
        private readonly HomeViewModel _homeViewModel;
        private ComplaintViewModel _complaintViewModel;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                _homeViewModel = new HomeViewModel();
                _homeViewModel.LoginSuccessful += HomeViewModel_LoginSuccessful;
                var homeView = new HomeView { DataContext = _homeViewModel };
                MainContent.Content = homeView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during initialization: {ex.Message}", "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void HomeViewModel_LoginSuccessful(object sender, UserRole role)
        {
            try
            {
                _complaintViewModel = new ComplaintViewModel(role);
                _complaintViewModel.LogoutRequested += ComplaintViewModel_LogoutRequested;
                MainContent.Content = new ComplaintView { DataContext = _complaintViewModel };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login navigation: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComplaintViewModel_LogoutRequested(object sender, EventArgs e)
        {
            try
            {
                _homeViewModel.CurrentRole = UserRole.None;
                MainContent.Content = new HomeView { DataContext = _homeViewModel };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout navigation: {ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}