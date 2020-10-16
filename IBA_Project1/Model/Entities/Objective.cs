using System.ComponentModel.DataAnnotations.Schema;

namespace IBA_Project1.Model.Entities
{
    public class Objective:ModelBase
    {
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
    }
}
