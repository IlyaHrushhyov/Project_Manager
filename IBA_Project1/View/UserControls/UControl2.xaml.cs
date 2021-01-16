using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IBA_Project1.View.UserControls
{
    public partial class UControl2 : UserControl
    {
        public UControl2()
        {
            InitializeComponent();
        }

        public string TextBoxBindingUC2
        {
            get { return (string)GetValue(TextBoxBindingProperty); }
            set { SetValue(TextBoxBindingProperty, value); }
        }

        public static readonly DependencyProperty TextBoxBindingProperty =
            DependencyProperty.Register("TextBoxBindingUC2", typeof(string), typeof(UControl2), new PropertyMetadata(null));

        public ICommand LoadCommandUC2
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
            DependencyProperty.Register("LoadCommandUC2", typeof(ICommand), typeof(UControl2), new PropertyMetadata(null));

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (LoadCommandUC2 != null)
            {
                LoadCommandUC2.Execute(null);
              
            }


        }

        public ICommand SelectedChangedCommandUC2
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
            DependencyProperty.Register("SelectedChangedCommandUC2", typeof(ICommand), typeof(UControl2), new PropertyMetadata(null));

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedChangedCommandUC2 != null)
            {
                SelectedChangedCommandUC2.Execute(ListView.SelectedItem);
            }
        }

        public ICommand EditCommandUC2
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
            DependencyProperty.Register("EditCommandUC2", typeof(ICommand), typeof(UControl2), new PropertyMetadata(null));
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditCommandUC2 != null)
            {
                EditCommandUC2.Execute(TextBox.Text);


            }
        }
        public ICommand AddCommandUC2
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
            DependencyProperty.Register("AddCommandUC2", typeof(ICommand), typeof(UControl2), new PropertyMetadata(null));
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddCommandUC2 != null)
            {
                AddCommandUC2.Execute(TextBox.Text);
            }
        }


        public ICommand DeleteCommandUC2
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
            DependencyProperty.Register("DeleteCommandUC2", typeof(ICommand), typeof(UControl2), new PropertyMetadata(null));
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteCommandUC2 != null)
            {
                DeleteCommandUC2.Execute(ListView.SelectedItem);
            }
        }
        public ICommand TextBoxChangedCommandUC2
        {
            get
            {
                return (ICommand)GetValue(TextBoxChangedCommandPropertyUC2);
            }
            set
            {
                SetValue(TextBoxChangedCommandPropertyUC2, value);
            }
        }

        public static readonly DependencyProperty TextBoxChangedCommandPropertyUC2 =
           DependencyProperty.Register("TextBoxChangedCommandUC2", typeof(ICommand), typeof(UControl2), new PropertyMetadata(null));
        private void TextBox_TextChangedUC2(object sender, TextChangedEventArgs e)
        {
            if (TextBoxChangedCommandUC2 != null)
            {
                TextBoxChangedCommandUC2.Execute(TextBox.Text);
            }
        }
    }
}
