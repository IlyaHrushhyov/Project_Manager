using IBA_Project1.ViewModel;
using IBA_Project1.View;

using System.Windows;
using IBA_Project1.View.Pages;

namespace IBA_Project1.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MainFrame.Content = new LoginPage();
           
            
        }
        
     
    }
}
