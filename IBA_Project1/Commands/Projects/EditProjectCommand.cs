using IBA_Project1.ViewModel;
using System;
using System.Windows.Input;

namespace IBA_Project1.Commands
{
    public class EditProjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _vModel;
        public EditProjectCommand(VModel projectViewModel)
        {
            _vModel = projectViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

      
        public void Execute(object parameter)
        {
            if(parameter == null)
            {
               
            }
            else
            {
                var newName = (string)parameter;
                _vModel.UpdateProject(newName);
            }
           
        }
    }
}
