using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Commands.Objectives
{
    public class EditObjectiveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _vModel;
        public EditObjectiveCommand(VModel objectiveViewModel)
        {
            _vModel = objectiveViewModel;
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
                _vModel.UpdateObjective(newName);
                _vModel.GetDataObjectives();
            }
            
        }

    }
}
