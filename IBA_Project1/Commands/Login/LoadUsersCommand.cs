using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Commands.Login
{
    public class LoadUsersCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly LoginVModel _vModel;
        public LoadUsersCommand(LoginVModel viewModel)
        {
            _vModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vModel.GetDataUsers();

        }
    }
}
