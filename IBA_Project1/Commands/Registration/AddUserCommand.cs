﻿using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Commands.Registration
{
    public class AddUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly RegistrationVModel _vModel;
        public AddUserCommand(RegistrationVModel viewModel)
        {
            _vModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /* if (parameter == null)
             {

             }
             else
             {
                 var newUser = parameter;
                 _vModel.SaveNewUser(newUser);

                 //

                 //_vModel.CheckForUpdateСoincidenceInProjects(true);
                 //
             }*/

           
            
                var newUser = new User();

            /* newUser.FirstName = _vModel.TextBoxFirstName;
             newUser.SecondName = _vModel.TextBoxSecondName;
             newUser.Login = _vModel.TextBoxLogin;
             newUser.Password = _vModel.TextBoxPassword;*/
            newUser.FirstName = _vModel.FirstName;
            newUser.SecondName = _vModel.SecondName;
            newUser.Login = _vModel.Login;
            newUser.Password = _vModel.Password;
            _vModel.SaveNewUser(newUser);

        }
    }
}
