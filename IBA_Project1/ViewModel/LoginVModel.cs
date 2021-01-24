using IBA_Project1.Commands.Login;
using IBA_Project1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
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
        
        private string textBoxLogin;
        [Required(ErrorMessage = "Must not be empty")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be 5-20 characters")]
        [RegularExpression(@"[a-zA-Z_.0-9]+$", ErrorMessage = "Unacceptable characters")]
        public string TextBoxLogin
        {
            get => textBoxLogin;
            set
            {
                ValidateProperty(value, "TextBoxLogin");
                textBoxLogin = value;
                OnPropertyChanged(nameof(TextBoxLogin));
            }
        }
       
        private string textBoxPassword;
        [Required(ErrorMessage = "Must not be empty")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be 5-20 characters")]
        [RegularExpression(@"[a-zA-Z_.0-9]+$", ErrorMessage = "Unacceptable characters")]
        public string TextBoxPassword
        {
            get => textBoxPassword;
            set
            {
                ValidateProperty(value, "TextBoxPassword");
                textBoxPassword = value;
                OnPropertyChanged(nameof(TextBoxPassword));
            }
        }
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
                else
                {
                    EnabledToLogin = false;
                }
            }
        }
    }
}
