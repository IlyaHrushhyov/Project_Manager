﻿using IBA_Project1.Repository;
using IBA_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.Command
{
    public class LoadProjectsCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ProjectViewModel _vModel;
        
        public LoadProjectsCommand(ProjectViewModel vModel)
        {
            _vModel = vModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Get todo list items from API.
            _vModel.GetData();
        }
    }
}
