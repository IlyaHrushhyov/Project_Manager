using IBA_Project1.Model.Entities;
using IBA_Project1.ViewModel;
using System;
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
                _objectiveVModel.CheckForDeleteInObjectives(false);
                _objectiveVModel.CheckForUpdateChoosenInObjectives(false);
            }
            else
            {
                _objectiveVModel.CheckForDeleteInObjectives(true);
                _objectiveVModel.CheckForUpdateChoosenInObjectives(true);

                var objective = (Objective)parameter;
                _objectiveVModel.Objective = objective;
                _objectiveVModel.ObjectiveName = objective.Name;
            }
            
          
        }
    }
}
