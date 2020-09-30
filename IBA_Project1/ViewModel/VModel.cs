using IBA_Project1.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
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
        private readonly IRepository<Project> _projectRepository;

        // projectRepository - dependency
        public VModel(IRepository<Project> projectRepository)
        {

            _projectRepository = projectRepository;
            GetData();
        }

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
        public ObservableCollection<Project> Projects { get; set; }
        protected void RegisterCollections()
        {
            Projects = new ObservableCollection<Project>();
        }
        private void GetData()
        {
            var projects = _projectRepository.Get().ToList();
            Projects = new ObservableCollection<Project>(projects);
        }
        private void Save()
        {
            _projectRepository.Save(Project);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
