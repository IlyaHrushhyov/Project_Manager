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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            DataContext = new RegistrationVModel();
            viewModel = (RegistrationVModel)DataContext;
        }
        RegistrationVModel viewModel;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxSecondName.Text = "";
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }
      
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserControlsHolderPage());
        }

       /* private void textBoxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //viewModel.TextBoxFirstName = textBoxFirstName.Text;
            viewModel.CheckForAdding();
        }

        private void textBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.CheckForAdding();
        }

        private void textBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.CheckForAdding();
        }

        private void textBoxSecondName_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.CheckForAdding();
        }*/

        private void registerPage_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.GetDataUsers();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //if(textBlockFirstname.)
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var patternFirstName = @"[a-zА-Яа-я]{2,20}$";
            var patternSecondName = @"[a-zА-Яа-я]{2,20}$";
            var patternLogin = @"[a-zA-Z_.0-9]{5,20}$";
            var patternPassword = @"[a-zA-Z_.0-9]{5,20}$";

            var regexFirstName = new Regex(@"[a-zА-Яа-я]{2,20}$");
            var regexSecondName = new Regex(@"[a-zА-Яа-я]{2,20}$");
            var regexLogin = new Regex(@"[a-zА-Яа-я_.]{5,20}$");
            var regexPassword = new Regex(@"[a-zА-Яа-я_.0-9]{5,20}$");

            if (Regex.IsMatch(textBoxFirstName.Text, patternFirstName) && Regex.IsMatch(textBoxSecondName.Text, patternSecondName)
                && Regex.IsMatch(textBoxLogin.Text, patternLogin) && Regex.IsMatch(textBoxPassword.Text, patternPassword))
            {
                //viewModel.EnabledToAdd = true;
                viewModel.CheckForAdding(true);
            }
            else
            {
                viewModel.EnabledToAdd = false;
            }
        }

      
    }
}
