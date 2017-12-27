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

            if(_context.Projects.Count() == 0)
            {
                _context.Projects.Add(new Project() { Id = 1, ProjectName = "Blackjack Game", Description = "Looking to develop a Blackjack game in C# and would love to work with a Front End Dev to make it come alive on the screen!", Status= "Not Started", DesiredTeamSize = 2, CurrentTeamSize = 1, ProjectTechnologies = new List<ProjectTechnology>(){new ProjectTechnology() { Id = 1, Technology = new Technology(){ Id = 51, Name = "CSS"}, IsSeeking = true}}});
                _context.Projects.Add(new Project() { Id = 2, ProjectName = "Pizza Delivery Tracker", Description = "I'd like to create a pizza delivery app with Javascript. Looking for some help from a fellow dev!", Status = "Not Started", DesiredTeamSize = 2, CurrentTeamSize = 1 });
                _context.Projects.Add(new Project() { Id = 3, ProjectName = "Restauraunt Website", Description = "Novice coder - would like to practice my React skills to make a clone of Afters Ice Cream website. Seeking Node devs to make a complete site!", Status = "In Progress", DesiredTeamSize = 3, CurrentTeamSize = 1 });
                _context.Projects.Add(new Project() { Id = 4, ProjectName = "Coffee Cart", Description = "Want to beef up my portfolio with a web & mobile app for a coffee cart that tracks it's location in real time and sends notifications to users in that area", Status = "Not Started", DesiredTeamSize = 5, CurrentTeamSize = 2 });
                _context.Projects.Add(new Project() { Id = 5, ProjectName = "Animal Adoption Site", Description = "Looking to build an adoption site in AngularJS so I can improve - want to end up with a full stack app. BE C# devs preferred!", Status = "Not Started", DesiredTeamSize = 3, CurrentTeamSize = 1 });
                _context.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public List<Project> Get()
        {
            return _context.Projects.Include("ProjectTechnologies").Include("ProjectTechnologies.Technology").ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            foreach (Project p in _context.Projects.Include("ProjectTechnologies").Include("ProjectTechnologies.Technology"))
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
            _context.Projects.Add(p);
            _context.SaveChanges();
            return p;
        }

        [HttpPut("{id}/addtechnology")]
        public void AddTechnology(int id, int techId, bool isSeeking)
        {
            foreach (Project p in _context.Projects.Include("ProjectTechnologies"))
            {
                if (p.Id == id)
                {

                    ProjectTechnology pt = new ProjectTechnology();

                    if (_context.ProjectTechnologies.Count() == 0)
                    {
                        pt.Id = 1;
                    }
                    else
                    {
                        pt.Id = _context.ProjectTechnologies.OrderBy(ptech => ptech.Id).Last().Id + 1;
                    }

                    pt.Project = p;
                    pt.Technology = _context.Technologies.FirstOrDefault(t => t.Id == techId);
                    pt.IsSeeking = isSeeking;

                    if (p.ProjectTechnologies == null) 
                    {
                        p.ProjectTechnologies = new List<ProjectTechnology>();
                    }

                    p.ProjectTechnologies.Add(pt);

                    _context.SaveChanges();
              
                }
            }
    
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
