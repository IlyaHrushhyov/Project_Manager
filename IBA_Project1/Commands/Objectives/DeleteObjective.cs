﻿using IBA_Project1.Model.Entities;
using IBA_Project1.ViewModel;
using System;
using System.Windows.Input;

namespace IBA_Project1.Commands.Objectives
{
    public class DeleteObjectiveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly VModel _vModel;
        public DeleteObjectiveCommand(VModel viewModel)
        {
            _vModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if(parameter == null)
            {
               
            }
            else
            {
                var objective = (Objective)parameter;
                var id = objective.Id;
                _vModel.DeleteObjective(id);
              
            }
            
        }
    }
}
