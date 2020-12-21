using IBA_Project1.ViewModel;
using System;
using System.Windows.Input;

namespace IBA_Project1.Command
{
    public class LoadProjectsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly VModel _vModel;
        //
        private bool firstLoadCalled = false;
        //
        public LoadProjectsCommand(VModel vModel)
        {
            _vModel = vModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //
            if(firstLoadCalled == false)
            {
                _vModel.GetDataProjects();
                firstLoadCalled = true;
            }
            //
            
        }
    }
}
