using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Model.Entities
{
    class Task
    {
        // PK
        public int Id { get; set; }
        // FK
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public bool Check { get; set; }

        public Project Project { get; set; }
    }
}
