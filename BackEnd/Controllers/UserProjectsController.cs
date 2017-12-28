using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/userprojects")]
    public class UserProjectsController : Controller
    {
        private readonly DevMatchContext _context;

        public UserProjectsController(DevMatchContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public List<UserProject> Get()
        {
            return _context.UserProjects.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserProject Get(int id)
        {
            foreach (UserProject u in _context.UserProjects)
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
        public UserProject Post([FromBody]UserProject u)
        {
            _context.UserProjects.Add(u);
            _context.SaveChanges();
            return u;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public UserProject Put(int id, [FromBody]UserProject up)
        {
            foreach (UserProject u in _context.UserProjects)
            {
                if (u.Id == id)
                {
                    _context.UserProjects.Remove(u);
                    _context.SaveChanges();
                    _context.UserProjects.Add(up);
                    _context.SaveChanges();
                    return up;
                }
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            foreach (UserProject u in _context.UserProjects)
            {
                if (u.Id == id)
                {
                    _context.UserProjects.Remove(u);
                    _context.SaveChanges();
                    return "Deleted";
                }
            }
            return "User's Project Not Found";
        }
    }
}
