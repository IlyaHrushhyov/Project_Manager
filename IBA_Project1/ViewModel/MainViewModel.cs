﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.ViewModel
{
    public class MainViewModel
    {
        private VModel _vModel;
        public VModel VModel
        {
            get
            {
                return _vModel;
            }
            set
            {
                _vModel = value;
                
            }
        }
        public MainViewModel()
        {
            VModel = new VModel();
        }
    }
}
