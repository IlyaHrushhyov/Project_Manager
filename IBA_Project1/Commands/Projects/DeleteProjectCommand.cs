using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Commands.Projects
{
    public class DeleteProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _vModel;
        public DeleteProjectCommand(VModel viewModel)
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
                
            }
            else
            {
                var project = (Project)parameter;
                var id = project.Id;
                _vModel.DeleteProject(id);
                _vModel.GetDataProjects();
                _vModel.GetDataObjectives();
            }
           
        }
    }
}
