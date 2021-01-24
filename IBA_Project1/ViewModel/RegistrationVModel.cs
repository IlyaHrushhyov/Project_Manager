using IBA_Project1.Commands.Registration;
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
    public class RegistrationVModel:BaseViewModel
    {
        private UnitOfWork unitOfWork;
        public RegistrationVModel()
        {
            unitOfWork = new UnitOfWork();
            AddUserCommand = new AddUserCommand(this);
        }
        public User UserForAdding { get; set; }
        public ObservableCollection<User> Users { get; private set; }
        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
        //public string TextBoxFirstName { get; set; }
        private string firstName;
        [Required(ErrorMessage = "Must not be empty")]
        [StringLength(20, MinimumLength =2, ErrorMessage = "Must be 2-20 characters")]
        [RegularExpression(@"[a-zA-ZА-Яа-я]+$", ErrorMessage = "Unacceptable characters")]
        public string FirstName
        {
            get => firstName;
            set
            {
                ValidateProperty(value, "FirstName");
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        //public string TextBoxSecondName {get; set; }
        private string secondName;
        [Required(ErrorMessage = "Must not be empty")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be 2-20 characters")]
        [RegularExpression(@"[a-zA-ZА-Яа-я]+$", ErrorMessage = "Unacceptable characters")]
        public string SecondName
        {
            get => secondName;
            set
            {
                ValidateProperty(value, "SecondName");
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        //public string TextBoxLogin { get; set; }
        private string login;
        [Required(ErrorMessage = "Must not be empty")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be 5-20 characters")]
        [RegularExpression(@"[a-zA-Z_.0-9]+$", ErrorMessage = "Unacceptable characters")]
        public string Login
        {
            get => login;
            set
            {
                ValidateProperty(value, "Login");
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        //public string TextBoxPassword { get; set; }
        private string password;
        [Required(ErrorMessage = "Must not be empty")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be 5-20 characters")]
        [RegularExpression(@"[a-zA-Z_.0-9]+$", ErrorMessage = "Unacceptable characters")]
        public string Password
        {
            get => password;
            set
            {
                ValidateProperty(value, "Password");
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private bool enabledToAdd;
        public bool EnabledToAdd
        {
            get => enabledToAdd;
            set
            {
                enabledToAdd = value;
                OnPropertyChanged(nameof(EnabledToAdd));
            }
        }
        public ICommand AddUserCommand { get; set; }
        public async void SaveNewUser(object obj)
        {
            await unitOfWork.Users.SaveNew((User)obj);
            unitOfWork.Save();

            //CheckForAddInProjects();

        }
        public void GetDataUsers()
        {
            var users = unitOfWork.Users.Get().Result.ToList();
            Users = new ObservableCollection<User>((IEnumerable<User>)users);
        }
        public void CheckForAdding(bool flag)
        {
            EnabledToAdd = flag;
            var user = Users.FirstOrDefault(p => p.Login.Equals(Login));
            if (user != null)
            {
                EnabledToAdd = false;
            }
            else
            {
                EnabledToAdd = true;
            }
        }
    }
}
