using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //DataContext = new MainViewModel - try this
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

        /*private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.Page_Loaded.Execute(null);
        }*/

        private void textBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.TextBoxLogin = textBoxLogin.Text;
            viewModel.CheckForLogin();
        }

        private void textBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.TextBoxPassword = textBoxPassword.Text;
            viewModel.CheckForLogin();
        }

        
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
          
            viewModel.GetDataUsers();
        }
    }
}
