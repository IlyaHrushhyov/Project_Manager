using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1
{
    class Project
    {
        public Project(string name)
        {
            Name = name;
            Check = false;
        }

        // PK
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Check { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
