using IBA_Project1.ViewModel;
using IBA_Project1.View;

using System.Windows;

namespace IBA_Project1.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        UserControlsHolder userControlsHolder = new UserControlsHolder();
        Registration registration = new Registration();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            userControlsHolder.Show();
            Close();
        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
    }
}
