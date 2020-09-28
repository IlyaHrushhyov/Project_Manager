using IBA_Project1.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IBA_Project1.ViewModel
{
    public class VModel: INotifyPropertyChanged
    {
        //private readonly Context _context;
        public VModel(Context context)
        {
            
            //_context = context;

        }
        //private ObservableCollection<Project> projects = new ObservableCollection<Project>();

        //public ObservableCollection<Project> Projects { get; set; }

        private Project project;
        public Project Project
        {
            get => project;
            set
            {
                project = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
