using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IBA_Project1.ViewModel
{
    class ViewModel: INotifyPropertyChanged
    {
        public ViewModel()
        {
            DbAccess dbAccess = new DbAccess();
            Projects = new ObservableCollection<Project> (dbAccess.GetProjects());
        }
        private ObservableCollection<Project> projects = new ObservableCollection<Project>();
        //public ObservableCollection<string> ProjectsNames { get; set; }
        public ObservableCollection<Project> Projects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
                //OnPropertyChanged("projectsNames");
            }
        }
        /* public string name;
         public string Name
         {
             get { return name; }
             set
             {
                 if (name == value) return;
                 name = value;

             }
         }*/
        public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
