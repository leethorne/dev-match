using System;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int DesiredTeamSize { get; set; }
        public int CurrentTeamSize { get; set; }
        public List<ProjectTechnology> ProjectTechnologies { get; set; } 
        public List<UserProject> User { get; set; }
    }
}