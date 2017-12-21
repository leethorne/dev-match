using System;
using Microsoft.EntityFrameworkCore;
using BackEnd.Controllers;
namespace API_Review
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
    }
}