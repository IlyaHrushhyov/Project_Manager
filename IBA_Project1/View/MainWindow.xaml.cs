using IBA_Project1.ViewModel;
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
    }
}
