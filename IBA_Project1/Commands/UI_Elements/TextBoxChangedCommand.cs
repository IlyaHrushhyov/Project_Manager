using IBA_Project1.ViewModel;
using System;
using System.Windows.Input;

namespace IBA_Project1.Commands.UI_Elements
{
    class TextBoxChangedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _vModel;
        public TextBoxChangedCommand(VModel viewModel)
        {
            _vModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            var newName = (string)parameter;
            _vModel.TextBoxValue = newName;
            if (newName == "")
            {
                _vModel.CheckForAddInProjects();
                _vModel.CheckForUpdateСoincidenceInProjects(false);
            }
            else
            {
                
                _vModel.CheckForAddInProjects();
                _vModel.CheckForUpdateСoincidenceInProjects(true);
            }

        }
    }
}
