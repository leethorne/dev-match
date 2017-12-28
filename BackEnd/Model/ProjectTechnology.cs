using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Controllers
{
    public class ProjectTechnology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Project Project { get; set; }
        public Technology Technology { get; set; }
        public bool IsSeeking { get; set; }
        public bool IsUsing { get; set; }

    }
}