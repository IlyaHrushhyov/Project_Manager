using IBA_Project1.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace IBA_Project1.ViewModel
{
    class DbAccess
    {
        Context context = new Context();
        public List<Project> GetProjects()
        {
            //Context context = new Context();
            context.Projects.Load();
            List<Project> projects = context.Projects.Local.ToList();
            return projects;
        }
        public List<Objective> GetObjectives()
        {
            Context context = new Context();
            context.Projects.Load();
            var objectives = context.Objectives.Local.ToList();
            return objectives;
        }

        public void Add()
        {
            Project project = new Project();

            context.Projects.Add(project);
        }
    }
}
