using IBA_Project1.Repository;
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
        private readonly Context _context;
        public VModel(Context context)
        {
            // DbAccess dbAccess = new DbAccess();
            //SQLProjectRepository projectRepository = new SQLProjectRepository();
            //Projects = new ObservableCollection<Project>(dbAccess.GetProjectsAsync().Result);
            //Projects = new ObservableCollection<Project>(projectRepository.GetList());
            _context = context;

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
