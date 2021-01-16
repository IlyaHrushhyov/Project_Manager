using IBA_Project1.Command;
using IBA_Project1.Commands;
using IBA_Project1.Commands.Objectives;
using IBA_Project1.Commands.Projects;
using IBA_Project1.Commands.UI_Elements;
using IBA_Project1.Model;
using IBA_Project1.Model.Entities;
using IBA_Project1.View.UserControls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
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

            TextBoxChangedCommand = new TextBoxChangedCommand(this);
            TextBoxChangedCommandUC2 = new TextBoxChangedCommandUC2(this);

            unitOfWork = new UnitOfWork();

            Objective = new Objective();
            Project = new Project();

            ProjectForAdding = new Project();
            ObjectiveForAdding = new Objective();

            
            EnabledForAddProjects = false;
            EnabledForUpdateProjects = false;
            EnabledForDeleteProjects = false;
            TextBoxNotEmptyProjects = false;
            TextBoxNotMatchedProjects = false;
            ProjectIsChoosen = false;

            EnabledForAddObjectives = false;
            EnabledForUpdateObjectives = false;
            EnabledForDeleteObjectives = false;
            TextBoxNotEmptyObjectives = false;
            TextBoxNotMatchedObjectives = false;
            ObjectiveIsChoosen = false;
            ProjectIsChoosenForObjectives = false;
        }
        #region UI_Elements
        #region UserControl1
        public ICommand TextBoxChangedCommand { get; set; }
        
        private string textBoxValue;
        public string TextBoxValue
        {
            get => textBoxValue;
            set
            {
                textBoxValue = value;
                OnPropertyChanged(nameof(TextBoxValue));
            }
        }
        private bool enabledForAddProjects;
        public bool EnabledForAddProjects
        {
            get => enabledForAddProjects;
            set
            {
                enabledForAddProjects = value;
                OnPropertyChanged(nameof(EnabledForAddProjects));
            }
        }
        private bool enabledForUpdateProjects;
        public bool EnabledForUpdateProjects
        {
            get => enabledForUpdateProjects;
            set
            {
                enabledForUpdateProjects = value;
                OnPropertyChanged(nameof(EnabledForUpdateProjects));
            }
        }
        private bool enabledForDeleteProjects;
        public bool EnabledForDeleteProjects
        {
            get => enabledForDeleteProjects;
            set
            {
                enabledForDeleteProjects = value;
                OnPropertyChanged(nameof(EnabledForDeleteProjects));
            }
        }

        private bool textBoxNotEmptyProjects;
        public bool TextBoxNotEmptyProjects
        {
            get => textBoxNotEmptyProjects;
            set
            {
                textBoxNotEmptyProjects = value;
                OnPropertyChanged(nameof(TextBoxNotEmptyProjects));
            }
        }
        private bool textBoxNotMatchedProjects;
        public bool TextBoxNotMatchedProjects
        {
            get => textBoxNotMatchedProjects;
            set
            {
                textBoxNotMatchedProjects = value;
                OnPropertyChanged(nameof(TextBoxNotMatchedProjects));
            }
        }
        private bool projectIsChoosen;
        public bool ProjectIsChoosen
        {
            get => projectIsChoosen;
            set
            {
                projectIsChoosen = value;
                OnPropertyChanged(nameof(ProjectIsChoosen));
            }
        }

        public void CheckForAddInProjects()
        {
            var boolFlagEqual = Projects.Any(p => p.Name.Equals(TextBoxValue));
            var boolFlagEmpty = TextBoxValue.Equals("");
            if (boolFlagEqual == true || boolFlagEmpty == true)
            {
                EnabledForAddProjects = false;
            }
            else
            {
                EnabledForAddProjects = true;
            }
        }
        
        public void CheckForDeleteInProjects(object obj)
        {
            var flag = (bool)obj;
            EnabledForDeleteProjects = flag;
        }
        public void CheckForUpdateChoosenInProjects(object obj)
        {

            TextBoxNotMatchedProjects = Projects.Any(p => p.Name.Equals(TextBoxValue));
            ProjectIsChoosen = (bool)obj;
            if(TextBoxNotMatchedProjects == false && ProjectIsChoosen == true
                && TextBoxNotEmptyProjects == true)
            {
                EnabledForUpdateProjects = true;
            }
            else
            {
                EnabledForUpdateProjects = false;
            }
           
        }
        public void CheckForUpdateСoincidenceInProjects(object obj)
        {
            TextBoxNotMatchedProjects = Projects.Any(p => p.Name.Equals(TextBoxValue));
            TextBoxNotEmptyProjects = (bool)obj;
            if (TextBoxNotMatchedProjects == false && ProjectIsChoosen == true
                && TextBoxNotEmptyProjects == true)
            {
                EnabledForUpdateProjects = true;
            }
            else
            {
                EnabledForUpdateProjects = false;
            }
        }
        #endregion
        #region UserControl2
        public bool ProjectIsChoosenForObjectives { get; set; }
        public ICommand TextBoxChangedCommandUC2 { get; set; }

        private string textBoxValueUC2;
        public string TextBoxValueUC2
        {
            get => textBoxValueUC2;
            set
            {
                textBoxValueUC2 = value;
                OnPropertyChanged(nameof(TextBoxValueUC2));
            }
        }
        private bool enabledForAddObjectives;
        public bool EnabledForAddObjectives
        {
            get => enabledForAddObjectives;
            set
            {
                enabledForAddObjectives = value;
                OnPropertyChanged(nameof(EnabledForAddObjectives));
            }
        }
        private bool enabledForUpdateObjectives;
        public bool EnabledForUpdateObjectives
        {
            get => enabledForUpdateObjectives;
            set
            {
                enabledForUpdateObjectives = value;
                OnPropertyChanged(nameof(EnabledForUpdateObjectives));
            }
        }
        private bool enabledForDeleteObjectives;
        public bool EnabledForDeleteObjectives
        {
            get => enabledForDeleteObjectives;
            set
            {
                enabledForDeleteObjectives = value;
                OnPropertyChanged(nameof(EnabledForDeleteObjectives));
            }
        }

        private bool textBoxNotEmptyObjectives;
        public bool TextBoxNotEmptyObjectives
        {
            get => textBoxNotEmptyObjectives;
            set
            {
                textBoxNotEmptyObjectives = value;
                OnPropertyChanged(nameof(TextBoxNotEmptyObjectives));
            }
        }
        private bool textBoxNotMatchedObjectives;
        public bool TextBoxNotMatchedObjectives
        {
            get => textBoxNotMatchedObjectives;
            set
            {
                textBoxNotMatchedObjectives = value;
                OnPropertyChanged(nameof(TextBoxNotMatchedObjectives));
            }
        }
        private bool objectiveIsChoosen;
        public bool ObjectiveIsChoosen
        {
            get => objectiveIsChoosen;
            set
            {
                objectiveIsChoosen = value;
                OnPropertyChanged(nameof(ObjectiveIsChoosen));
            }
        }

        public void CheckForAddInObjectives()
        {
            var boolFlagEqual = Objectives.Any(p => p.Name.Equals(TextBoxValueUC2));
            var boolFlagEmpty = TextBoxValueUC2.Equals("");
            if (boolFlagEqual == true || boolFlagEmpty == true || ProjectIsChoosenForObjectives == false)
            {
                EnabledForAddObjectives = false;
            }
            else
            {
                EnabledForAddObjectives = true;
            }
        }

        public void CheckForDeleteInObjectives(object obj)
        {
            var flag = (bool)obj;
            EnabledForDeleteObjectives = flag;
        }
        public void CheckForUpdateChoosenInObjectives(object obj)
        {

            TextBoxNotMatchedObjectives = Objectives.Any(p => p.Name.Equals(TextBoxValueUC2));
            ObjectiveIsChoosen = (bool)obj;
            if (TextBoxNotMatchedObjectives == false && ObjectiveIsChoosen == true
                && TextBoxNotEmptyObjectives == true)
            {
                EnabledForUpdateObjectives = true;
            }
            else
            {
                EnabledForUpdateObjectives = false;
            }

        }
        public void CheckForUpdateСoincidenceInObjectives(object obj)
        {
            TextBoxNotMatchedObjectives = Objectives.Any(p => p.Name.Equals(TextBoxValueUC2));
            TextBoxNotEmptyObjectives = (bool)obj;
            if (TextBoxNotMatchedObjectives == false && ObjectiveIsChoosen == true
                && TextBoxNotEmptyObjectives == true)
            {
                EnabledForUpdateObjectives = true;
            }
            else
            {
                EnabledForUpdateObjectives = false;
            }
        }
        #endregion
        #endregion

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

        private Project projectForAdding;
        public Project ProjectForAdding
        {
            get => projectForAdding;
            set
            {
                projectForAdding = value;
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
                ProjectForAdding = new Project();
                ProjectForAdding.Name = newName;
                Projects.Add(ProjectForAdding);
                await unitOfWork.Projects.SaveNew(ProjectForAdding);
                unitOfWork.Save();

           
                ICollectionView view = CollectionViewSource.GetDefaultView(Projects);
                view.Refresh();

                CheckForAddInProjects();
        }
        public async void DeleteProject(int id)
        {
            //
            Projects.Remove(Project);
            //
            await unitOfWork.Projects.Delete(id);
            unitOfWork.Save();

            CheckForAddInProjects();
        }
        public async void UpdateProject(string newName)
        {
          
                Project.Name = newName;
                await unitOfWork.Projects.Update(Project);
                unitOfWork.Save();

               
                ICollectionView view = CollectionViewSource.GetDefaultView(Projects);
                view.Refresh();
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


        private Objective objectiveForAdding;
        public Objective ObjectiveForAdding
        {
            get => objectiveForAdding;
            set
            {
                objectiveForAdding = value;
                
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

            ObjectiveForAdding = new Objective();
            ObjectiveForAdding.Name = newName;
            ObjectiveForAdding.Project = Project;
            Objectives.Add(ObjectiveForAdding);
            await unitOfWork.Objectives.SaveNew(ObjectiveForAdding);
            unitOfWork.Save();

            ICollectionView view = CollectionViewSource.GetDefaultView(Objectives);
            view.Refresh();

            CheckForAddInObjectives();
        }
        public async void UpdateObjective(string newName)
        {
            Objective.Name = newName;
            await unitOfWork.Objectives.Update(Objective);
            unitOfWork.Save();

            ICollectionView view = CollectionViewSource.GetDefaultView(Objectives);
            view.Refresh();
        }
        public async void DeleteObjective(int id)
        {
            //Objectives.Remove(Objectives.Where(o => o.Id == id).First());

            //
            Objectives.Remove(Objective);
            //

            await unitOfWork.Objectives.Delete(id);
            unitOfWork.Save();

            CheckForAddInObjectives();
        }
        
        public void GetDataObjectives()
        {
            var objectives = unitOfWork.Objectives.GetWithInclude(p => p.Project.Id.Equals(Project.Id), o => o.Project);
            Objectives = new ObservableCollection<Objective>(objectives);
        }
        #endregion

    }
}
