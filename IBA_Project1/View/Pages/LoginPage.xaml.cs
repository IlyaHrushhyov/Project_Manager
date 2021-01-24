using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IBA_Project1.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        
        public LoginPage()
        {
            InitializeComponent();
            DataContext = new LoginVModel();
            viewModel = (LoginVModel)DataContext;
        }
        LoginVModel viewModel;
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserControlsHolderPage());
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            var patternLogin = @"[a-zA-Z_.0-9]{5,20}$";
            var patternPassword = @"[a-zA-Z_.0-9]{5,20}$";

            if (Regex.IsMatch(textBoxLogin.Text, patternLogin) && Regex.IsMatch(textBoxPassword.Text, patternPassword))
            {
         
                viewModel.CheckForLogin();
            }
            else
            {
                viewModel.EnabledToLogin = false;
            }
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            viewModel.GetDataUsers();
        }
    }
}
