using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using IBA_Project1.ViewModel;

namespace IBA_Project1.View
{
    /// <summary>
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class UControl : UserControl
    {
        public UControl()
        {
            InitializeComponent();
            DbAccess dbAccess = new DbAccess();
            this.projectsGrid.ItemsSource = dbAccess.GetProjects();
        }
    }
}
