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
        private readonly ProjectViewModel _vModel;
        public AddProjectCommand(ProjectViewModel viewModel)
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
            _vModel.SaveNew(newName);
            _vModel.GetData();
        }
    }
}
