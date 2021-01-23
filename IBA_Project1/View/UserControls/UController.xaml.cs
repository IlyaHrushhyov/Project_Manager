using IBA_Project1.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IBA_Project1.View.UserControls
{

    public partial class UController : UserControl
    {

        public UController()
        {
            InitializeComponent();
            //DataContext = new VModel();
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
        public ICommand AddCommand
        {
            get
            {
                return (ICommand)GetValue(AddCommandProperty);
            }
            set
            {
                SetValue(AddCommandProperty, value);
            }
        }
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(UController), new PropertyMetadata(null));
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddCommand != null)
            {
                AddCommand.Execute(TextBox.Text);
                
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return (ICommand)GetValue(DeleteCommandProperty);
            }
            set
            {
                SetValue(DeleteCommandProperty, value);
            }
        }

        public static readonly DependencyProperty DeleteCommandProperty =
           DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(UController), new PropertyMetadata(null));
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteCommand != null)
            {
                DeleteCommand.Execute(ListView.SelectedItem);
            }
        }


        public ICommand TextBoxChangedCommand
        {
            get
            {
                return (ICommand)GetValue(TextBoxChangedCommandProperty);
            }
            set
            {
                SetValue(TextBoxChangedCommandProperty, value);
            }
        }

        public static readonly DependencyProperty TextBoxChangedCommandProperty =
           DependencyProperty.Register("TextBoxChangedCommand", typeof(ICommand), typeof(UController), new PropertyMetadata(null));
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxChangedCommand != null)
            {
                TextBoxChangedCommand.Execute(TextBox.Text);
            }
        }
    }
}

