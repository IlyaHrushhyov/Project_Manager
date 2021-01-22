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
    /// Логика взаимодействия для UserControlsHolderPage.xaml
    /// </summary>
    public partial class UserControlsHolderPage : Page
    {
        public UserControlsHolderPage()
        {
            InitializeComponent();
            DataContext = new VModel();
        }
    }
}
