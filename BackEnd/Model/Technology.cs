using System;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectTechnology> Projects { get; set;  }
    }
}