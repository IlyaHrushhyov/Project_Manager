using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IBA_Project1.ViewModel
{
    public class VModel: INotifyPropertyChanged
    {
        public VModel()
        {
            Context context = new Context();
            context.Projects.Load();
            Projects = new ObservableCollection<Project>(context.Projects.Local.ToList());
        }
        private ObservableCollection<Project> projects = new ObservableCollection<Project>();
       
        public ObservableCollection<Project> Projects { get; set; }
            

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler eh = PropertyChanged;
            if (eh != null)
            {
                eh(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
