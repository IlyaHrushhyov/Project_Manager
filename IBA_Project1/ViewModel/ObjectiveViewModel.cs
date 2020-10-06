using IBA_Project1.Model.Entities;
using IBA_Project1.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.ViewModel
{
    public class ObjectiveViewModel: BaseViewModel
    {
        private readonly IRepository<Objective> _objectiveRepository;


        public ObjectiveViewModel()
        {
            _objectiveRepository = new SQLRepository<Objective>(new Context());
            //LoadProjectsCommand = new LoadProjectsCommand(this);

        }


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

        public ICommand LoadProjectsCommand { get; set; }

        protected void RegisterCollections()
        {
            Objectives = new ObservableCollection<Objective>();
        }
        public void GetData()
        {
            var projects = _objectiveRepository.Get().Result.ToList();
            Objectives = new ObservableCollection<Objective>(objectives);
        }
       /* private void Save()
        {
            _objectiveRepository.Save(Objective);
        }*/

    }
}
