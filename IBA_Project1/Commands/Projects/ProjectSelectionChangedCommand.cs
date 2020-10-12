using IBA_Project1.ViewModel;
using System;
using System.Windows.Input;

namespace IBA_Project1.Commands
{
    public class ProjectSelectionChangedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _VModel;

        public ProjectSelectionChangedCommand(VModel vModel)
        {
            _VModel = vModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException();
            }
            
            var project = (Project)parameter;
            _VModel.Project = project;
            _VModel.ProjectName = project.Name;

            
            _VModel.GetDataObjectives();
        }
    }
}
