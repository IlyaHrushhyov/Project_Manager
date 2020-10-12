using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Commands
{
    public class AddProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _vModel;
        public AddProjectCommand(VModel viewModel)
        {
            _vModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if(parameter == null)
            {
                throw new ArgumentNullException();
            }
            var newName = (string)parameter;
            _vModel.SaveNewProject(newName);
            _vModel.GetDataProjects();
        }
    }
}
