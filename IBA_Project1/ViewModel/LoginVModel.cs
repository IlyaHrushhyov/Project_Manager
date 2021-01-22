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
            Page_Loaded = new LoadUsersCommand(this);
            EnabledToLogin = false;
        }
        public ObservableCollection<User> Users { get; private set; }
        public bool EnabledToLogin { get; private set; }
        public string TextBoxLogin { get; private set; }
        public string TextBoxPassword { get; private set; }
        public ICommand Page_Loaded { get; set; }
        public void GetDataUsers()
        {
            var users = unitOfWork.Users.Get().Result.ToList();
            Users = new ObservableCollection<User>((IEnumerable<User>)users);
        }
        private void CheckForLogin()
        {
            var user = Users.First(p => p.Login.Equals(TextBoxLogin));
            if (user?.Password == TextBoxPassword)
            {
                EnabledToLogin = true;
            }
        }
    }
}
