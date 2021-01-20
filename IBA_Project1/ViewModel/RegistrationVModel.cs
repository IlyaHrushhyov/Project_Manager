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
        public ICommand AddUserCommand { get; set; }
        public async void SaveNewUser(object obj)
        {
            UserForAdding = new User();
            UserForAdding = (User)obj;
            
            await unitOfWork.Users.SaveNew(UserForAdding);
            unitOfWork.Save();


            

            //CheckForAddInProjects();

        }
    }
}
