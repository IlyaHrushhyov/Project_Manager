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
    public class LoadObjectivesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly VModel _vModel;

        public LoadObjectivesCommand(VModel vModel)
        {
            _vModel = vModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
            _vModel.GetDataObjectives();
        }
    }
}
