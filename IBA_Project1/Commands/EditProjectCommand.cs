using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Commands
{
    public class EditProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ProjectViewModel _vModel;
        public EditProjectCommand(ProjectViewModel projectViewModel)
        {
            _vModel = projectViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

       /* public void Execute(object newName, object currentProject)
        {
            var project = (Project)currentProject;
            var name = (string)newName;
            _vModel.Project.Id = project.Id;
            _vModel.Project.Name = name;
            _vModel.Update();
        }*/

        public void Execute(object parameter)
        {
            var newName = (string)parameter;
            _vModel.Update(newName);
        }
    }
}
