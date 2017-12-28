using System;
using System.ComponentModel.DataAnnotations;


namespace BackEnd.Controllers
{
    public class ProjectTechnology
    {
        [Key]
        public int Id { get; set; }
        public Project Project { get; set; }
        public Technology Technology { get; set; }
        public bool IsSeeking { get; set; }
        public bool IsUsing { get; set; }

    }
}