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
    public partial class UControlProjects : UserControl
    {
        public UControlProjects()
        {
            InitializeComponent();
            DbAccess dbAccess = new DbAccess();
            //this.projectsGrid.ItemsSource = dbAccess.GetProjects();
            this.list.ItemsSource = dbAccess.GetProjects();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UControlProjects), new PropertyMetadata(null));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(UControlProjects), new PropertyMetadata(null));
    }
}
