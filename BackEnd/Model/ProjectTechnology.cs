using System;

namespace BackEnd.Controllers
{
    public class ProjectTechnology
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TechnologyId { get; set; }
        public bool IsSeeking { get; set; }
    }
}