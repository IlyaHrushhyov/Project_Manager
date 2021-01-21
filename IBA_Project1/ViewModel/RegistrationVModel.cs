using IBA_Project1.Commands.Registration;
using IBA_Project1.Model;
using System;
using System.Collections.Generic;
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
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string secondName;
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand AddUserCommand { get; set; }
        public async void SaveNewUser(object obj)
        {
            
            /*UserForAdding = (User)obj;*/
            
            await unitOfWork.Users.SaveNew((User)obj);
            unitOfWork.Save();

            //CheckForAddInProjects();

        }
    }
}
