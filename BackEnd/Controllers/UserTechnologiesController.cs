using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/usertechnologies")]
    public class UserTechnologiesController : Controller
    {
        private readonly DevMatchContext _context;

        public UserTechnologiesController(DevMatchContext context)
        {
            _context = context;

            if (_context.UserTechnologies.Count() == 0)
            {
                _context.UserTechnologies.Add(new UserTechnology() { Id = 1, UserId = 1, TechnologyId = 1 });
                _context.UserTechnologies.Add(new UserTechnology() { Id = 2, UserId = 2, TechnologyId = 2 });
                _context.UserTechnologies.Add(new UserTechnology() { Id = 3, UserId = 3, TechnologyId = 3 });
                _context.UserTechnologies.Add(new UserTechnology() { Id = 4, UserId = 4, TechnologyId = 4 });
                _context.UserTechnologies.Add(new UserTechnology() { Id = 5, UserId = 5, TechnologyId = 5 });
                _context.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public List<UserTechnology> Get()
        {
            return _context.UserTechnologies.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserTechnology Get(int id)
        {
            foreach (UserTechnology u in _context.UserTechnologies)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public UserTechnology Post([FromBody]UserTechnology u)
        {
            _context.UserTechnologies.Add(u);
            _context.SaveChanges();
            return u;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public UserTechnology Put(int id, [FromBody]UserTechnology ut)
        {
            foreach (UserTechnology u in _context.UserTechnologies)
            {
                if (u.Id == id)
                {
                    _context.UserTechnologies.Remove(u);
                    _context.SaveChanges();
                    _context.UserTechnologies.Add(ut);
                    _context.SaveChanges();
                    return ut;
                }
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            foreach (UserTechnology u in _context.UserTechnologies)
            {
                if (u.Id == id)
                {
                    _context.UserTechnologies.Remove(u);
                    _context.SaveChanges();
                    return "Deleted";
                }
            }
            return "User's Technologies Not Found";
        }
    }
}