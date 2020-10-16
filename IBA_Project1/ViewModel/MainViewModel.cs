namespace IBA_Project1.ViewModel
{
    public class MainViewModel : BaseViewModel

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
                OnPropertyChanged(nameof(VModel));
            }
        }
      
        public MainViewModel()
        {
            VModel = new VModel();

        }
    }
}
