﻿using IBA_Project1.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBA_Project1
{
    public class Objective:ModelBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("User")]
        public int? TargetUserId { get; set; }
        public User User { get; set; }
    }
}
