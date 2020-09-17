using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace IBA_Project1.ViewModel
{
    class DbAccess
    {
        public List<Project> GetProjects()
        {
            Context context = new Context();
            context.Projects.Load();
            List<Project> projects = context.Projects.Local.ToList();
            return projects;
        }
    }
}
