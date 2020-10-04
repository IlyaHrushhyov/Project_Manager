using IBA_Project1.ViewModel;
using System;
using System.Windows.Input;

namespace IBA_Project1.Commands
{
    public class ProjectSelectionChangedCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ProjectViewModel _projectVModel;

        public ProjectSelectionChangedCommand(ProjectViewModel vModel)
        {
            _projectVModel = vModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Get todo list items from API.
            var project = (Project)parameter;
            _projectVModel.Get(project);
        }
    }
}
