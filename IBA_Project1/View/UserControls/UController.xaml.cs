using IBA_Project1.Repository;
using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IBA_Project1.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserController.xaml
    /// </summary>
    public partial class UController : UserControl
    {
       /* IRepository<Project> context;*/
        public UController()
        {
            InitializeComponent();
            /*context = new SQLProjectRepository();*/
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UController), new PropertyMetadata(null));

    }
}

