using IBA_Project1.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBA_Project1
{
    public class User: ModelBase
    {

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Login { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
