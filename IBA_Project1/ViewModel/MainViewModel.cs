using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        private ProjectViewModel _vModel;
        public ProjectViewModel VModel
        {
            get
            {
                return _vModel;
            }
            set
            {
                _vModel = value;
                OnPropertyChanged(nameof(VModel));
            }
        }
        public MainViewModel()
        {
            VModel = new ProjectViewModel();
        }
    }
}
