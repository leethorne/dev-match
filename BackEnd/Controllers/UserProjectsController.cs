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

            //if (_context.UserProjects.Count() == 0)
            //{
            //    _context.UserProjects.Add(new UserProject() { Id = 1, UserId = 1, ProjectId = 1});
            //    _context.UserProjects.Add(new UserProject() { Id = 2, UserId = 2, ProjectId = 2 });
            //    _context.UserProjects.Add(new UserProject() { Id = 3, UserId = 3, ProjectId = 3 });
            //    _context.UserProjects.Add(new UserProject() { Id = 4, UserId = 4, ProjectId = 4 });
            //    _context.UserProjects.Add(new UserProject() { Id = 5, UserId = 5, ProjectId = 5 });
            //    _context.SaveChanges();
            //}
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
