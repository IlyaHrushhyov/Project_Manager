using IBA_Project1.Commands.Login;
using IBA_Project1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IBA_Project1.ViewModel
{
    public class LoginVModel: BaseViewModel
    {
        private UnitOfWork unitOfWork;
        public LoginVModel()
        {
            unitOfWork = new UnitOfWork();
            PageLoadedCommand = new LoadUsersCommand(this);
            EnabledToLogin = false;
        }
        public ObservableCollection<User> Users { get; private set; }
        private bool enabledToLogin;
        public bool EnabledToLogin
        {
            get => enabledToLogin;
            set
            {
                enabledToLogin = value;
                OnPropertyChanged(nameof(EnabledToLogin));
            }
        }
        public string TextBoxLogin {private get; set; }
       /* private string textBoxLogin;
        public string TextBoxLogin
        {
            get => textBoxLogin;
            set
            {
                textBoxLogin = value;
                OnPropertyChanged(nameof(TextBoxLogin));
            }
        }*/
        public string TextBoxPassword {private get; set; }
       /* private string textBoxPassword;
        public string TextBoxPassword
        {
            get => textBoxPassword;
            set
            {
                textBoxPassword = value;
                OnPropertyChanged(nameof(TextBoxPassword));
            }
        }*/
        public ICommand PageLoadedCommand { get; set; }
        public void GetDataUsers()
        {
            var users = unitOfWork.Users.Get().Result.ToList();
            Users = new ObservableCollection<User>((IEnumerable<User>)users);
        }
        public void CheckForLogin()
        {
            var user = Users.FirstOrDefault(p => p.Login.Equals(TextBoxLogin));
            if (user != null)
            {
                if (user.Password.Equals(TextBoxPassword))
                {
                    EnabledToLogin = true;
                }
            }
        }
    }
}
