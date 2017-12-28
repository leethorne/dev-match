using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Controllers
{
    public class UserTechnology
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Technology Technology { get; set; }
    }
}