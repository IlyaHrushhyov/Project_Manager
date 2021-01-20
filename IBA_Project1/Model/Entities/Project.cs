using IBA_Project1.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IBA_Project1
{
    public class Project: ModelBase
    {

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
