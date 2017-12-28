using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Controllers
{
    public class UserProject
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }
}