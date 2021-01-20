using IBA_Project1.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBA_Project1
{
    public class UserProject: ModelBase
    {

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
