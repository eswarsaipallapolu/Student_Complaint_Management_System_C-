using System.Windows;
using System.Windows.Controls;
using StudentComplaintSystem.ViewModels;

namespace StudentComplaintSystem.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomeViewModel viewModel)
            {
                viewModel.LoginPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}