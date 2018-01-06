using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly DevMatchContext _context;

        public ProjectsController(DevMatchContext context)
        {
            _context = context;

            if (_context.Projects.Count() == 0)
            {
                _context.Projects.Add(new Project() { Id = 1, ProjectName = "Blackjack Game", Description = "Looking to develop a Blackjack game in C# and would love to work with a Front End Dev to make it come alive on the screen!", Status = "Not Started", DesiredTeamSize = "2", CurrentTeamSize = "1" });
                _context.Projects.Add(new Project() { Id = 2, ProjectName = "Pizza Delivery Tracker", Description = "I'd like to create a pizza delivery app with Javascript. Looking for some help from a fellow dev!", Status = "Not Started", DesiredTeamSize = "3", CurrentTeamSize = "1" });
                _context.Projects.Add(new Project() { Id = 3, ProjectName = "Restauraunt Website", Description = "Novice coder - would like to practice my React skills to make a clone of Afters Ice Cream website. Seeking Node devs to make a complete site!", Status = "In Progress", DesiredTeamSize = "3", CurrentTeamSize = "2" });
                _context.Projects.Add(new Project() { Id = 4, ProjectName = "Coffee Cart", Description = "Want to beef up my portfolio with a web & mobile app for a coffee cart that tracks it's location in real time and sends notifications to users in that area", Status = "Not Started", DesiredTeamSize = "5", CurrentTeamSize = "2" });
                _context.Projects.Add(new Project() { Id = 5, ProjectName = "Animal Adoption Site", Description = "Looking to build an adoption site in AngularJS so I can improve - want to end up with a full stack app. Backend C# devs preferred, becuase I need a refresher in .Net Core!", Status = "Not Started", DesiredTeamSize = "3", CurrentTeamSize = "1" });
                _context.SaveChanges();
            }

            if (_context.Technologies.Count() == 0)
            {
                _context.Technologies.Add(new Technology() { Id = 1, Name = "Python" });
                _context.Technologies.Add(new Technology() { Id = 2, Name = "Ajax" });
                _context.Technologies.Add(new Technology() { Id = 3, Name = "jQuery" });
                _context.Technologies.Add(new Technology() { Id = 4, Name = "Django" });
                _context.Technologies.Add(new Technology() { Id = 5, Name = "MySQL" });
                _context.Technologies.Add(new Technology() { Id = 6, Name = "MongoDB" });
                _context.Technologies.Add(new Technology() { Id = 7, Name = "AngularJS" });
                _context.Technologies.Add(new Technology() { Id = 8, Name = "React" });
                _context.Technologies.Add(new Technology() { Id = 9, Name = "Node.js" });
                _context.Technologies.Add(new Technology() { Id = 10, Name = "Swift" });
                _context.Technologies.Add(new Technology() { Id = 11, Name = "Xcode" });
                _context.Technologies.Add(new Technology() { Id = 12, Name = "C#" });
                _context.Technologies.Add(new Technology() { Id = 13, Name = ".NET Core" });
                _context.Technologies.Add(new Technology() { Id = 14, Name = "NancyFX" });
                _context.Technologies.Add(new Technology() { Id = 15, Name = "ASP.NET Core" });
                _context.Technologies.Add(new Technology() { Id = 16, Name = "SQL Server" });
                _context.Technologies.Add(new Technology() { Id = 17, Name = "Dapper" });
                _context.Technologies.Add(new Technology() { Id = 18, Name = "Entity Framework Core" });
                _context.Technologies.Add(new Technology() { Id = 19, Name = "Azure" });
                _context.Technologies.Add(new Technology() { Id = 20, Name = "AWS" });
                _context.Technologies.Add(new Technology() { Id = 21, Name = "PHP" });
                _context.Technologies.Add(new Technology() { Id = 22, Name = "Java" });
                _context.Technologies.Add(new Technology() { Id = 23, Name = "SpringMVC" });
                _context.Technologies.Add(new Technology() { Id = 24, Name = "Ruby" });
                _context.Technologies.Add(new Technology() { Id = 25, Name = "C / C++" });
                _context.Technologies.Add(new Technology() { Id = 26, Name = "JavaScript" });
                _context.Technologies.Add(new Technology() { Id = 27, Name = "BootStrap" });
                _context.Technologies.Add(new Technology() { Id = 28, Name = "Objective-C" });
                _context.Technologies.Add(new Technology() { Id = 29, Name = "HTML" });
                _context.Technologies.Add(new Technology() { Id = 30, Name = "CSS" });
                _context.SaveChanges();
            }

            if (_context.ProjectTechnologies.Count() == 0)
            {

                ProjectTechnology pt = new ProjectTechnology();

                pt.Project = _context.Projects.FirstOrDefault(p => p.Id == 1);
                pt.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "C#");
                pt.IsUsing = true;


                _context.ProjectTechnologies.Add(pt);
                _context.SaveChanges();

                ProjectTechnology pt2 = new ProjectTechnology();

                pt2.Project = _context.Projects.FirstOrDefault(p => p.Id == 2);
                pt2.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "Javascript");
                pt2.IsUsing = true;


                _context.ProjectTechnologies.Add(pt2);
                _context.SaveChanges();

                ProjectTechnology pt3 = new ProjectTechnology();

                pt3.Project = _context.Projects.FirstOrDefault(p => p.Id == 3);
                pt3.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "React");
                pt3.IsSeeking = true;

                _context.ProjectTechnologies.Add(pt3);
                _context.SaveChanges();

                ProjectTechnology pt4 = new ProjectTechnology();

                pt4.Project = _context.Projects.FirstOrDefault(p => p.Id == 4);
                pt4.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "Swift");
                pt4.IsUsing = true;

                _context.ProjectTechnologies.Add(pt4);
                _context.SaveChanges();

                ProjectTechnology pt5 = new ProjectTechnology();

                pt5.Project = _context.Projects.FirstOrDefault(p => p.Id == 5);
                pt5.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "AngularJS");
                pt5.IsSeeking = true;
                pt5.IsUsing = true;

                _context.ProjectTechnologies.Add(pt5);
                _context.SaveChanges();

            }
        }

        // GET api/values
        [HttpGet]
        public IQueryable<Project> Get()
        {
            return _context.Projects.Include("ProjectTechnologies").Include("ProjectTechnologies.Technology").Include("ProjectTechnologies.Project").Include("ProjectTechnologies.Project.Users");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            foreach (Project p in _context.Projects.Include("ProjectTechnologies").Include("ProjectTechnologies.Technology").Include("ProjectTechnologies.Project").Include("ProjectTechnologies.Project.Users"))
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public Project Post([FromBody]Project p)
        {
            p.Id = _context.Projects.Count() + 1;
            _context.Projects.Add(p);
            _context.SaveChanges();
            return p;
        }

        [HttpPut("{id}/addtechnology")]
        public Project AddTechnology(int id, string techName, bool isSeeking, bool isUsing)
        {
            foreach (Project p in _context.Projects.Include("ProjectTechnologies").Include("ProjectTechnologies.Technology"))
            {
                if (p.Id == id)
                {
                    ProjectTechnology pt = new ProjectTechnology();

                    pt.Project = p;
                    pt.Technology = _context.Technologies.FirstOrDefault(t => t.Name == techName);
                    pt.IsSeeking = isSeeking;
                    pt.IsUsing = isUsing;

                    if (p.ProjectTechnologies == null) 
                    {
                        p.ProjectTechnologies = new List<ProjectTechnology>();
                    }

                    p.ProjectTechnologies.Add(pt);
                    _context.SaveChanges();

                    return p;

                }
            }
            return null;
    
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Project Put(int id, [FromBody]Project proj)
        {
            _context.Projects.Update(proj);
            _context.SaveChanges();
            return proj;      
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            foreach (Project p in _context.Projects)
            {
                if (p.Id == id)
                {
                    _context.Projects.Remove(p);
                    _context.SaveChanges();
                    return "Deleted";
                }
            }
            return "Project Not Found";
        }
    }
}
