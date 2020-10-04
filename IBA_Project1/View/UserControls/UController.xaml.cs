using IBA_Project1.Repository;
using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Interactivity;

namespace IBA_Project1.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserController.xaml
    /// </summary>
    public partial class UController : UserControl
    {
       
        public UController()
        {
            InitializeComponent();
            
        }

        public string TextBoxBinding
        {
            get { return (string)GetValue(TextBoxBindingProperty); }
            set { SetValue(TextBoxBindingProperty, value); }
        }

        public static readonly DependencyProperty TextBoxBindingProperty =
            DependencyProperty.Register("TextBoxBinding", typeof(string), typeof(UController), new PropertyMetadata(null));

        public ICommand LoadCommand
        {
            get
            {
                return (ICommand)GetValue(LoadCommandProperty);
            }
            set
            {
                SetValue(LoadCommandProperty, value);
            }
        }

        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.Register("LoadCommand", typeof(ICommand), typeof(UController), new PropertyMetadata(null));

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (LoadCommand != null)
            {
                LoadCommand.Execute(null);
            }
               

        }

        public ICommand SelectedChangedCommand
        {
            get
            {
                return (ICommand)GetValue(SelectedChangedCommandProperty);
            }
            set
            {
                SetValue(SelectedChangedCommandProperty, value);
            }

        }

        public static readonly DependencyProperty SelectedChangedCommandProperty =
            DependencyProperty.Register("SelectedChangedCommand", typeof(ICommand), typeof(UController), new PropertyMetadata(null));

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedChangedCommand != null)
            {
                SelectedChangedCommand.Execute(ListView.SelectedItem);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return (ICommand)GetValue(EditCommandProperty);
            }
            set
            {
                SetValue(EditCommandProperty, value);
            }
        }
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(UController), new PropertyMetadata(null));
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditCommand != null)
            {
                EditCommand.Execute(TextBox.Text);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        
    }
}

