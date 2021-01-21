using IBA_Project1.Commands.Registration;
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
using System.Windows.Shapes;

namespace IBA_Project1.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MainWindow loginWindow;
       
        public Registration(MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = new RegistrationVModel();
            loginWindow = mainWindow;
        }
        
        private void Login_Click(object sender, RoutedEventArgs e)
        {
           
            loginWindow.Show();
            Close();
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
        public ICommand AddCommand
        {
            get
            {
                return (ICommand)GetValue(AddCommandProperty);
            }
            set
            {
                SetValue(AddCommandProperty, value);
            }
        }
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(Registration), new PropertyMetadata(null));
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            /* if (AddCommand != null)
             {
                 var newUser = new User();
                 newUser.FirstName = textBoxFirstName.Text;
                 newUser.SecondName = textBoxSecondName.Text;
                 newUser.Login = textBoxLogin.Text;
                 newUser.Password = textBoxPassword.Password;
                 AddCommand.Execute(newUser);*/

            //}
            
            //
            // Show UserControlsHolder
            //
            Close();
        }

    }
}
