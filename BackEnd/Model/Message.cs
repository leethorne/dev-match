using System;

namespace BackEnd.Controllers
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
    }
}