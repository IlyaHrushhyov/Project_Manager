using IBA_Project1.ViewModel;
using System;
using System.Windows.Input;

namespace IBA_Project1.Commands.UI_Elements
{
    class TextBoxChangedCommandUC2 : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _vModel;
        public TextBoxChangedCommandUC2(VModel viewModel)
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
            _vModel.TextBoxValueUC2 = newName;
            if (newName == "")
            {
                _vModel.CheckForAddInObjectives();
                _vModel.CheckForUpdateСoincidenceInObjectives(false);
            }
            else
            {

                _vModel.CheckForAddInObjectives();
                _vModel.CheckForUpdateСoincidenceInObjectives(true);
            }

        }
    }
}
