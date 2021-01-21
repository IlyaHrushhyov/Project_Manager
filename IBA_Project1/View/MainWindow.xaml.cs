using IBA_Project1.ViewModel;
using IBA_Project1.View;

using System.Windows;

namespace IBA_Project1.View
{
    public partial class MainWindow : Window
    {
        UserControlsHolder userControlsHolder;
        Registration registration;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); 
            userControlsHolder = new UserControlsHolder();
            registration = new Registration(this);
            //Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            userControlsHolder.Show();
            //Hide();
            Close();
        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            //Hide();
            Close();
        }
    }
}
