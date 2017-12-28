using System;
using Microsoft.EntityFrameworkCore;
using BackEnd.Controllers;

namespace BackEnd
{
    public class DevMatchContext : DbContext
    {
        public DevMatchContext(DbContextOptions<DevMatchContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserTechnology> UserTechnologies { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}