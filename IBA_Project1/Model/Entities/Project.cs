using IBA_Project1.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1
{
    public class Project: ModelBase
    {
       /* [Key]
        public int Id { get; set; }*/
        public string Name { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}
