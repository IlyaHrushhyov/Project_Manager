using IBA_Project1.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Model
{
    public class UnitOfWork
    {
        private Context context = new Context();
        private ProjectRepository projectRepository;
        private ObjectiveRepository objectiveRepository;

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
        public void Save()
        {
            //try
            //{
                context.SaveChanges();
           // }
            //catch
            //{

           // }
        }

    }
}
