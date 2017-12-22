using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/technologies")]
    public class TechnologiesController : Controller
    {
        private readonly DevMatchContext _context;

        public TechnologiesController(DevMatchContext context)
        {
            _context = context;

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
                _context.Technologies.Add(new Technology() { Id = 26, Name = "Javascript" });
                _context.Technologies.Add(new Technology() { Id = 27, Name = "Bootstrap" });
                _context.Technologies.Add(new Technology() { Id = 28, Name = "Objective-C" });
                _context.Technologies.Add(new Technology() { Id = 29, Name = "HTML" });
                _context.Technologies.Add(new Technology() { Id = 30, Name = "CSS" });
                _context.SaveChanges();
            }
        }
        // GET api/values
        [HttpGet]
        public List<Technology> Get()
        {
            return _context.Technologies.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Technology Get(int id)
        {
            foreach(Technology t in _context.Technologies)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public Technology Post([FromBody]Technology t)
        {
            _context.Technologies.Add(t);
            _context.SaveChanges();
            return t;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Technology Put(int id, [FromBody]Technology tech)
        {
            foreach (Technology t in _context.Technologies)
            {
                if (t.Id == id)
                {
                    _context.Technologies.Remove(t);
                    _context.SaveChanges();
                    _context.Technologies.Add(tech);
                    _context.SaveChanges();
                    return tech;

                }
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            foreach(Technology t in _context.Technologies)
            {
                if (t.Id == id)
                {
                    _context.Technologies.Remove(t);
                    _context.SaveChanges();
                    return "Deleted Technology";
                }
            } return "Technology not found";
        }
    }
}
