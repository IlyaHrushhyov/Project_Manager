using IBA_Project1.Command;
using IBA_Project1.Commands;
using IBA_Project1.Model.Entities;
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
using System.Windows.Input;

namespace IBA_Project1.ViewModel
{
    public class ProjectViewModel: BaseViewModel
    {
        private readonly IRepository<Project> _projectRepository;
       

        public ProjectViewModel()
        {
            _projectRepository = new SQLRepository<Project>(new Context());
            LoadProjectsCommand = new LoadProjectsCommand(this);
            SelectionProjectChangedCommand = new ProjectSelectionChangedCommand(this);
            UpdateCommand = new EditProjectCommand(this);
        }

       
        private Project project;
        public Project Project
        {
            get => project;
            set
            {
                project = value;
                OnPropertyChanged(nameof(Project));
            }
        }
        private ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        public ICommand LoadProjectsCommand { get; set; }
        public ICommand AddProjectCommand { get; set; }
        public ICommand SelectionProjectChangedCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        
        public void Update(string newName)
        {
            Project.Name = newName;
            _projectRepository.Update(Project);
        }
        // is used for loading all projects
        public void GetData()
        {
            var projects = _projectRepository.Get().Result.ToList();
            Projects = new ObservableCollection<Project>(projects);
        }
        // is used to get a single project
        public void Get(Project obj)
        {
            var project = _projectRepository.Get(obj.Id).Result;
            Project = (Project) project;
        }
        // is used for update element
        public void Save()
        {
            _projectRepository.Save(Project);
        }
      /*  public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }
}
