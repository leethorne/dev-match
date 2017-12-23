using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/messages")]
    public class MessagesController : Controller
    {
        private readonly DevMatchContext _context;

        public MessagesController(DevMatchContext context)
        {
            _context = context;

            if(_context.Messages.Count()== 0)
            {
                _context.Messages.Add(new Message() { Id = 1, Content = "Hey - your idea sounds pretty great. I am a C# dev and would love to join the team. When can we get started?", Date = "2017-12-10", UserId1 = 6, UserId2 = 3 });
                _context.Messages.Add(new Message() { Id = 2, Content = "Hello! I'd love to get together to discuss your project in more depth. I think my skills match up with what you want.", Date = "2017-12-20", UserId1 = 10, UserId2 = 14 });
                _context.Messages.Add(new Message() { Id = 3, Content = "Hola! I'm a code newbie and would like to work on my Front End Dev skills. Let me know how you'd like to proceed.", Date = "2017-12-12", UserId1 = 12, UserId2 = 16  });
                _context.Messages.Add(new Message() { Id = 4, Content = "Sounds like an awesome idea, I'd love to get involved.", Date = "2017-12-8", UserId1 = 1, UserId2 = 2  });
                _context.Messages.Add(new Message() { Id = 5, Content = "I'm picking up Node as a new skill. This project sounds like a great way to level up. Count me in!", Date = "2017-12-11", UserId1 = 4, UserId2 = 5  });
                _context.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public List<Message> Get()
        {
            return _context.Messages.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Message Get(int id)
        {
            foreach(Message m in _context.Messages)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public Message Post([FromBody]Message m)
        {
            _context.Messages.Add(m);
            _context.SaveChanges();
            return m;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Message Put(int id, [FromBody]Message msg)
        {
            foreach (Message m in _context.Messages)
            {
                if (m.Id == id)
                {
                    _context.Messages.Remove(m);
                    _context.SaveChanges();
                    _context.Messages.Add(msg);
                    _context.SaveChanges();
                    return msg;
                }
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            foreach(Message m in _context.Messages)
            {
                if (m.Id == id)
                {
                    _context.Messages.Remove(m);
                    _context.SaveChanges();
                    return "Deleted";
                }
            } return "Msg Not Found";
        }
    }
}
