using IBA_Project1.Model.Repository;

namespace IBA_Project1.Model
{
    public class UnitOfWork
    {
        private Context context = new Context();
        private ProjectRepository projectRepository;
        private ObjectiveRepository objectiveRepository;
        private UserRepository userRepository;

        public ProjectRepository Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(context);
                return projectRepository;
            }
        }
        public ObjectiveRepository Objectives
        {
            get
            {
                if (objectiveRepository == null)
                    objectiveRepository = new ObjectiveRepository(context);
                return objectiveRepository;
            }
        }
        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
