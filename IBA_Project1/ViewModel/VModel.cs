using IBA_Project1.Command;
using IBA_Project1.Commands;
using IBA_Project1.Commands.Objectives;
using IBA_Project1.Commands.Projects;
using IBA_Project1.Model;
using IBA_Project1.Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace IBA_Project1.ViewModel
{
    public class VModel : BaseViewModel
    {
        private UnitOfWork unitOfWork;

        public VModel()
        {

            LoadProjectsCommand = new LoadProjectsCommand(this);
            SelectionProjectChangedCommand = new ProjectSelectionChangedCommand(this);
            UpdateProjectCommand = new EditProjectCommand(this);
            AddProjectCommand = new AddProjectCommand(this);
            DeleteProjectCommand = new DeleteProjectCommand(this);


            LoadObjectivesCommand = new LoadObjectivesCommand(this);
            SelectionObjectiveChangedCommand = new ObjectiveSelectionChangedCommand(this);
            UpdateObjectiveCommand = new EditObjectiveCommand(this);
            AddObjectiveCommand = new AddObjectiveCommand(this);
            DeleteObjectiveCommand = new DeleteObjectiveCommand(this);

            unitOfWork = new UnitOfWork();

            Objective = new Objective();
            Project = new Project();
        }

        #region Projects
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
        private string projectName;
        public string ProjectName
        {
            get => projectName;
            set
            {
                projectName = value;
                OnPropertyChanged(nameof(ProjectName));
            }
        }
        public ICommand LoadProjectsCommand { get; set; }
        public ICommand AddProjectCommand { get; set; }
        public ICommand SelectionProjectChangedCommand { get; set; }
        public ICommand UpdateProjectCommand { get; set; }
        public ICommand DeleteProjectCommand { get; set; }

        public async void SaveNewProject(string newName)
        {
            var boolFlagEqual = Projects.Any(p => p.Name.Equals(newName));
            var boolFlagEmpty = newName.Equals("");
            if (boolFlagEqual == false && boolFlagEmpty == false)
            {

                Project.Name = newName;
                Projects.Add(Project);
                await unitOfWork.Projects.SaveNew(Project);
                unitOfWork.Save();
            }
            else if (boolFlagEqual == true)
            {
                MessageBox.Show("Such project already exists");
            }
            else if (boolFlagEmpty == true)
            {
                MessageBox.Show("Incorrect input, please, try again");
            }

        }
        public async void DeleteProject(int id)
        {
            Projects.Remove(Projects.Where(p => p.Id == id).First());
            await unitOfWork.Projects.Delete(id);
            unitOfWork.Save();
        }
        public async void UpdateProject(string newName)
        {
            var boolFlagEqual = Projects.Any(p => p.Name.Equals(newName));
            var boolFlagEmpty = newName.Equals("");
            if (boolFlagEqual == false && boolFlagEmpty == false)
            {
                Project.Name = newName;
                await unitOfWork.Projects.Update(Project);
                unitOfWork.Save();
            }
            else if (boolFlagEqual == true)
            {
                MessageBox.Show("Such project already exists");
            }
            else if (boolFlagEmpty == true)
            {
                MessageBox.Show("Incorrect input, please, try again");
            }
        }
        
        public void GetDataProjects()
        {
            var projects = unitOfWork.Projects.Get().Result.ToList();
            Projects = new ObservableCollection<Project>((IEnumerable<Project>)projects);
        }
       
        public async void GetProject(Project obj)
        {
            var project = await unitOfWork.Projects.Get(obj.Id);
            Project = (Project)project;
        }
        #endregion

        #region Objectives
        private Objective objective;
        public Objective Objective
        {
            get => objective;
            set
            {
                objective = value;
                OnPropertyChanged(nameof(Objective));
            }
        }
        private ObservableCollection<Objective> objectives;
        public ObservableCollection<Objective> Objectives
        {
            get
            {
                return objectives;
            }
            set
            {
                objectives = value;
                OnPropertyChanged(nameof(Objectives));
            }
        }
        private string objectiveName;
        public string ObjectiveName
        {
            get => objectiveName;
            set
            {
                objectiveName = value;
                OnPropertyChanged(nameof(ObjectiveName));
            }
        }
        public ICommand LoadObjectivesCommand { get; set; }
        public ICommand AddObjectiveCommand { get; set; }
        public ICommand SelectionObjectiveChangedCommand { get; set; }
        public ICommand UpdateObjectiveCommand { get; set; }
        public ICommand DeleteObjectiveCommand { get; set; }

        public async void SaveNewObjective(string newName)
        {

            bool boolFlagEqual = false;
            bool boolFlagChoosenProject = false;
            if (Objectives != null)
            {
                boolFlagEqual = Objectives.Any(p => p.Name.Equals(newName));

            }
            if(Project.Id == 0)
            {
                boolFlagChoosenProject = true;
            }
            var boolFlagEmpty = newName.Equals("");
            if (boolFlagEqual == false && boolFlagEmpty == false
                && boolFlagChoosenProject == false)
            {
                
                Objective.Name = newName;
                Objective.Project = Project;
                Objectives.Add(Objective);
                await unitOfWork.Objectives.SaveNew(Objective);
                unitOfWork.Save();
            }
            else if (boolFlagEqual == true)
            {
                MessageBox.Show("Such objective already exists");
            }
            else if (boolFlagEmpty == true)
            {
                MessageBox.Show("Incorrect input, please, try again");
            }
            else if (boolFlagChoosenProject == true)
            {
                MessageBox.Show("No choosen project");
            }
            else
            {
                MessageBox.Show("The collection of objectives is empty");
            }
        }
        public async void UpdateObjective(string newName)
        {

            var boolFlagEqual = Objectives.Any(p => p.Name.Equals(newName));
            var boolFlagEmpty = newName.Equals("");
            if (boolFlagEqual == false && boolFlagEmpty == false)
            {
                Objective.Name = newName;
                await unitOfWork.Objectives.Update(Objective);
                unitOfWork.Save();
            }
            else if (boolFlagEqual == true)
            {
                MessageBox.Show("Such project already exists");
            }
            else if (boolFlagEmpty == true)
            {
                MessageBox.Show("Incorrect input, please, try again");
            }
        }
        public async void DeleteObjective(int id)
        {
            Objectives.Remove(Objectives.Where(o => o.Id == id).First());
            await unitOfWork.Objectives.Delete(id);
            unitOfWork.Save();
        }
        
        public void GetDataObjectives()
        {
            var objectives = unitOfWork.Objectives.GetWithInclude(p => p.Project.Id.Equals(Project.Id), o => o.Project);
            Objectives = new ObservableCollection<Objective>(objectives);
        }
        #endregion

    }
}
