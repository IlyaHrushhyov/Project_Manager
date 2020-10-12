using IBA_Project1.Model.Entities;
using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Commands.Objectives
{
    public class ObjectiveSelectionChangedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _objectiveVModel;

        public ObjectiveSelectionChangedCommand(VModel vModel)
        {
            _objectiveVModel = vModel;
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
                var objective = (Objective)parameter;
                _objectiveVModel.Objective = objective;
                _objectiveVModel.ObjectiveName = objective.Name;
            }
            
          
        }
    }
}
