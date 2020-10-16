using IBA_Project1.Model.Entities;
using System.Collections.Generic;

namespace IBA_Project1
{
    public class Project: ModelBase
    {
      
        public string Name { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}
