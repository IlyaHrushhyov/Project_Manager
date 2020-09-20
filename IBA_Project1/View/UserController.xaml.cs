using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace IBA_Project1.View
{
    /// <summary>
    /// Логика взаимодействия для UserController.xaml
    /// </summary>
    public partial class UserController : UserControl
    {
        public UserController()
        {
            InitializeComponent();
            DbAccess dbAccess = new DbAccess();
            //this.projectsGrid.ItemsSource = dbAccess.GetProjects();

/*            this.list.ItemsSource = dbAccess.GetProjects();*/

            /*Context context = new Context();
            context.Projects.Load();
            this.DataContext = context;*/
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UserController), new PropertyMetadata(null));

        /*public IEnumerable<T> ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable),
                typeof(ToolboxElementView), new PropertyMetadata(null));*/

        /*public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(UControlProjects), new PropertyMetadata(null));*/
    }
}

