﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/projecttechnologies")]
    public class ProjectTechnologiesController : Controller
    {
        private readonly DevMatchContext _context;

        public ProjectTechnologiesController(DevMatchContext context)
        {
            _context = context;

            if (_context.ProjectTechnologies.Count() == 0)
            {
                _context.ProjectTechnologies.Add(new ProjectTechnology() { Id = 1, ProjectId = 1, TechnologyId = 1, IsSeeking = true });
                _context.ProjectTechnologies.Add(new ProjectTechnology() { Id = 2, ProjectId = 2, TechnologyId = 2, IsSeeking = false });
                _context.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public List<ProjectTechnology> Get()
        {
            return _context.ProjectTechnologies.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProjectTechnology Get(int id)
        {
            foreach (ProjectTechnology r in _context.ProjectTechnologies)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public ProjectTechnology Post([FromBody]ProjectTechnology r)
        {
            _context.ProjectTechnologies.Add(r);
            _context.SaveChanges();
            return r;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ProjectTechnology Put(int id, [FromBody]ProjectTechnology pt)
        {
            foreach (ProjectTechnology r in _context.ProjectTechnologies)
            {
                if (r.Id == id)
                {
                    _context.ProjectTechnologies.Remove(r);
                    _context.SaveChanges();
                    _context.ProjectTechnologies.Add(pt);
                    _context.SaveChanges();
                    return pt;
                }
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            foreach (ProjectTechnology r in _context.ProjectTechnologies)
            {
                if (r.Id == id)
                {
                    _context.ProjectTechnologies.Remove(r);
                    _context.SaveChanges();
                    return "Deleted";
                }
            }
            return "Project Technologies Not Found";
        }
    }
}