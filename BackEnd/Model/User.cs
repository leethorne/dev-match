using System;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public string ProficiencyLevel { get; set; }
        public string GitHubLink { get; set; }
        public string LinkedIn { get; set; }
        public List<UserProject> UserProjects { get; set; }
        public List<UserTechnology> UserTechnologies { get; set; }
    }
}