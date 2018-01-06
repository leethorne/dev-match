using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly DevMatchContext _context;

        public UsersController(DevMatchContext context)
        {
            _context = context;

            if (_context.Projects.Count() == 0)
            {
                _context.Projects.Add(new Project() { Id = 1, ProjectName = "Blackjack Game", Description = "Looking to develop a Blackjack game in C# and would love to work with a Front End Dev to make it come alive on the screen!", Status = "Not Started", DesiredTeamSize = "2", CurrentTeamSize = "1" });
                _context.Projects.Add(new Project() { Id = 2, ProjectName = "Pizza Delivery Tracker", Description = "I'd like to create a pizza delivery app with Javascript. Looking for some help from a fellow dev!", Status = "Not Started", DesiredTeamSize = "3", CurrentTeamSize = "1" });
                _context.Projects.Add(new Project() { Id = 3, ProjectName = "Restauraunt Website", Description = "Novice coder - would like to practice my React skills to make a clone of Afters Ice Cream website. Seeking Node devs to make a complete site!", Status = "In Progress", DesiredTeamSize = "3", CurrentTeamSize = "2" });
                _context.Projects.Add(new Project() { Id = 4, ProjectName = "Coffee Cart", Description = "Want to beef up my portfolio with a web & mobile app for a coffee cart that tracks it's location in real time and sends notifications to users in that area", Status = "Not Started", DesiredTeamSize = "5", CurrentTeamSize = "2" });
                _context.Projects.Add(new Project() { Id = 5, ProjectName = "Animal Adoption Site", Description = "Looking to build an adoption site in AngularJS so I can improve - want to end up with a full stack app. Backend C# devs preferred, becuase I need a refresher in .Net Core!", Status = "Not Started", DesiredTeamSize = "3", CurrentTeamSize = "1" });
                _context.SaveChanges();
            }

            if(_context.Users.Count() == 0)
            {
                _context.Users.Add(new User() { Id = 1, FirstName = "Bob", LastName = "Smith", Email = "bob@gmail.com", PhoneNumber = "212-332-4433", AddressLine1 = "176 Granada Ave", AddressLine2 = "Apt 10", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/bob.jpg", UserName = "bobbo", Password = "bob", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "https://github.com/bobbysmith", LinkedIn = "https://www.linkedin.com/in/drrobertmsmith/"});
                _context.Users.Add(new User() { Id = 2, FirstName = "Jeff", LastName = "Davis", Email = "JD@gmail.com", PhoneNumber = "111-222-2222", AddressLine1 = "102 Rive Alto Canal", AddressLine2 = "", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Jeff.jpg", UserName = "dude", Password = "dude", JobTitle = "Software Engineer", ProficiencyLevel = "Beginner", GitHubLink = "https://github.com/dajevu", LinkedIn = "https://www.linkedin.com/in/jeffdavis/" });
                _context.Users.Add(new User() { Id = 3, FirstName = "Elijah", LastName = "Thomas", Email = "ETphoneHome@gmail.com", PhoneNumber = "800-900-2900", AddressLine1 = "5567 E Saint Irmo Walk", AddressLine2 = "Apt 1", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Elijah.png", UserName = "ET", Password = "ET", JobTitle = "Full Stack Developer", ProficiencyLevel = "Intermediate", GitHubLink = "https://github.com/elijh", LinkedIn = "https://www.linkedin.com/in/elijahthomas/" });
                _context.Users.Add(new User() { Id = 4, FirstName = "Cole", LastName = "James", Email = "KALE@gmail.com", PhoneNumber = "225-666-4993", AddressLine1 = "52 W Neapolitan Ln", AddressLine2 = "", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Cole.jpg", UserName = "Cole", Password = "ilovekale", JobTitle = "Front End Developer", ProficiencyLevel = "Intermediate", GitHubLink = "https://github.com/JC5", LinkedIn = "https://www.linkedin.com/in/colejames/" });
                _context.Users.Add(new User() { Id = 5, FirstName = "Max", LastName = "Baker", Email = "baker@gmail.com", PhoneNumber = "245-090-8888", AddressLine1 = "5568 E Saint Irmo Walk", AddressLine2 = "Apt 4", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Max.jpg", UserName = "MrMax", Password = "coolguy", JobTitle = "BackEnd (SQL) Developer", ProficiencyLevel = "Advanced", GitHubLink = "https://github.com/maxslug", LinkedIn = "https://www.linkedin.com/maxbaker/" });
                _context.Users.Add(new User() { Id = 6, FirstName = "Jake", LastName = "Bell", Email = "bell@gmail.com", PhoneNumber = "211-432-6433", AddressLine1 = "29 Geneva Walk", AddressLine2 = "Apt 8", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Jake.png", UserName = "Jake", Password = "Jake", JobTitle = "Front End Developer", ProficiencyLevel = "Beginner", GitHubLink = "https://github.com/JakeBell", LinkedIn = "https://www.linkedin.com/in/jakebell/" });
                _context.Users.Add(new User() { Id = 7, FirstName = "Thomas", LastName = "Jefferson", Email = "TJ@gmail.com", PhoneNumber = "789-345-7654", AddressLine1 = "162 Savona Walk", AddressLine2 = "Apt 20", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Thomas.jpg", UserName = "Thom", Password = "Thom", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "https://github.com/1600", LinkedIn = "https://www.linkedin.com/in/thomasJ/" });
                _context.Users.Add(new User() { Id = 8, FirstName = "Karen", LastName = "DeLuca", Email = "KD@gmail.com", PhoneNumber = "567-456-9876", AddressLine1 = "5649 E Sorrento Dr", AddressLine2 = "", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Karen.png", UserName = "Karen", Password = "karen", JobTitle = "Front End Developer", ProficiencyLevel = "Intermediate", GitHubLink = "https://github.com/karen", LinkedIn = "https://www.linkedin.com/in/karen/" });
                _context.Users.Add(new User() { Id = 9, FirstName = "Mark", LastName = "Geller", Email = "mar@gmail.com", PhoneNumber = "212-332-4433", AddressLine1 = "1250 Jefferson Ave", AddressLine2 = "Apt 2H", City = "Brooklyn", State = "NY", Zip = 11221, Image = "./Images/Mark.jpg", UserName = "Mark", Password = "marker", JobTitle = "Software Developer", ProficiencyLevel = "Beginner", GitHubLink = "https://github.com/mageller", LinkedIn = "https://www.linkedin.com/in/mgeller/" });
                _context.Users.Add(new User() { Id = 10, FirstName = "Zach", LastName = "Lucas", Email = "zluc@gmail.com", PhoneNumber = "724-787-9345", AddressLine1 = "151 Weirfield St", AddressLine2 = "Apt 4", City = "Brooklyn", State = "NY", Zip = 11221, Image = "./Images/zach2.jpg", UserName = "zach", Password = "zluc", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "https://github.com/zachlucas", LinkedIn = "https://www.linkedin.com/in/zachthomaslucas/" });
                _context.Users.Add(new User() { Id = 11, FirstName = "Jessica", LastName = "Depalma", Email = "jj@gmail.com", PhoneNumber = "212-362-8833", AddressLine1 = "71 Cornelia St", AddressLine2 = "Apt 11", City = "Brooklyn", State = "NY", Zip = 11221, Image = "./Images/Jessica.jpg", UserName = "jessi", Password = "ilovecode", JobTitle = "Front End Developer", ProficiencyLevel = "Intermediate", GitHubLink = "https://github.com/jessica", LinkedIn = "https://www.linkedin.com/in/jessica/" });
                _context.Users.Add(new User() { Id = 12, FirstName = "Angela", LastName = "Evans", Email = "AEIOU@gmail.com", PhoneNumber = "978-456-7667", AddressLine1 = "1255 Bushwick Ave", AddressLine2 = "Apt 7", City = "Brooklyn", State = "NY", Zip = 11221, Image = "./Images/Angela.jpg", UserName = "angie", Password = "crossfitrules", JobTitle = "Developer", ProficiencyLevel = "Intermediate", GitHubLink = "https://github.com/angelaevans", LinkedIn = "https://www.linkedin.com/in/angelaevans/" });
                _context.Users.Add(new User() { Id = 13, FirstName = "Lexi", LastName = "Johnson", Email = "alexa@gmail.com", PhoneNumber = "433-223-0009", AddressLine1 = "37 Weirfield St", AddressLine2 = "Apt 18", City = "Brooklyn", State = "NY", Zip = 11221, Image = "./Images/lexi.jpg", UserName = "Lexi", Password = "LBJ", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "https://github.com/lexie", LinkedIn = "https://www.linkedin.com/in/alexa/" });
                _context.Users.Add(new User() { Id = 14, FirstName = "Francis", LastName = "Marx", Email = "MF@gmail.com", PhoneNumber = "312-338-5533", AddressLine1 = "1282 Putnam Ave", AddressLine2 = "", City = "Brooklyn", State = "NY", Zip = 11221, Image = "./Images/Francis.jpg", UserName = "frank", Password = "frank", JobTitle = "Software Developer", ProficiencyLevel = "Intermediate", GitHubLink = "https://github.com/francis", LinkedIn = "https://www.linkedin.com/in/francis/" });
                _context.Users.Add(new User() { Id = 15, FirstName = "Derek", LastName = "Kozar", Email = "dk@gmail.com", PhoneNumber = "310-220-2250", AddressLine1 = "1132 Greene Ave", AddressLine2 = "Apt 13", City = "Brooklyn", State = "NY", Zip = 11221, Image = "./Images/Derek.jpg", UserName = "dman", Password = "ddude", JobTitle = "Front End Developer, UX/UI Designer", ProficiencyLevel = "Intermediate", GitHubLink = "https://github.com/domenkozar", LinkedIn = "https://www.linkedin.com/in/derekkozar/" });
                _context.Users.Add(new User() { Id = 16, FirstName = "Calvin", LastName = "Anderson", Email = "CA@gmail.com", PhoneNumber = "212-332-4433", AddressLine1 = "735 Chauncey St", AddressLine2 = "Apt 19", City = "Brooklyn", State = "NY", Zip = 11207, Image = "./Images/Calvin.jpg", UserName = "Calvin", Password = "mandude", JobTitle = "Back End Developer", ProficiencyLevel = "Beginner", GitHubLink = "https://github.com/calvinanderson", LinkedIn = "https://www.linkedin.com/in/calvin/" });
              
                _context.SaveChanges();

                UserProject up = new UserProject();

                up.User = _context.Users.FirstOrDefault(u => u.Id == 1);
                up.Project = _context.Projects.FirstOrDefault(p => p.Id == 1);

                _context.UserProjects.Add(up);
                _context.SaveChanges();

                UserProject up2 = new UserProject();

                up2.User = _context.Users.FirstOrDefault(u => u.Id == 2);
                up2.Project = _context.Projects.FirstOrDefault(p => p.Id == 2);

                _context.UserProjects.Add(up2);
                _context.SaveChanges();

                UserProject up3 = new UserProject();

                up3.User = _context.Users.FirstOrDefault(u => u.Id == 3);
                up3.Project = _context.Projects.FirstOrDefault(p => p.Id == 3);

                _context.UserProjects.Add(up3);
                _context.SaveChanges();

                UserProject up4 = new UserProject();

                up4.User = _context.Users.FirstOrDefault(u => u.Id == 4);
                up4.Project = _context.Projects.FirstOrDefault(p => p.Id == 4);

                _context.UserProjects.Add(up4);
                _context.SaveChanges();

                UserProject up5 = new UserProject();

                up5.User = _context.Users.FirstOrDefault(u => u.Id == 10);
                up5.Project = _context.Projects.FirstOrDefault(p => p.Id == 5);

                _context.UserProjects.Add(up5);
                _context.SaveChanges();

            }

            if (_context.Technologies.Count() == 0)
            {
                _context.Technologies.Add(new Technology() { Id = 1, Name = "Python" });
                _context.Technologies.Add(new Technology() { Id = 2, Name = "Ajax" });
                _context.Technologies.Add(new Technology() { Id = 3, Name = "jQuery" });
                _context.Technologies.Add(new Technology() { Id = 4, Name = "Django" });
                _context.Technologies.Add(new Technology() { Id = 5, Name = "MySQL" });
                _context.Technologies.Add(new Technology() { Id = 6, Name = "MongoDB" });
                _context.Technologies.Add(new Technology() { Id = 7, Name = "AngularJS" });
                _context.Technologies.Add(new Technology() { Id = 8, Name = "React" });
                _context.Technologies.Add(new Technology() { Id = 9, Name = "Node.js" });
                _context.Technologies.Add(new Technology() { Id = 10, Name = "Swift" });
                _context.Technologies.Add(new Technology() { Id = 11, Name = "Xcode" });
                _context.Technologies.Add(new Technology() { Id = 12, Name = "C#" });
                _context.Technologies.Add(new Technology() { Id = 13, Name = ".NET Core" });
                _context.Technologies.Add(new Technology() { Id = 14, Name = "NancyFX" });
                _context.Technologies.Add(new Technology() { Id = 15, Name = "ASP.NET Core" });
                _context.Technologies.Add(new Technology() { Id = 16, Name = "SQL Server" });
                _context.Technologies.Add(new Technology() { Id = 17, Name = "Dapper" });
                _context.Technologies.Add(new Technology() { Id = 18, Name = "Entity Framework Core" });
                _context.Technologies.Add(new Technology() { Id = 19, Name = "Azure" });
                _context.Technologies.Add(new Technology() { Id = 20, Name = "AWS" });
                _context.Technologies.Add(new Technology() { Id = 21, Name = "PHP" });
                _context.Technologies.Add(new Technology() { Id = 22, Name = "Java" });
                _context.Technologies.Add(new Technology() { Id = 23, Name = "SpringMVC" });
                _context.Technologies.Add(new Technology() { Id = 24, Name = "Ruby" });
                _context.Technologies.Add(new Technology() { Id = 25, Name = "C / C++" });
                _context.Technologies.Add(new Technology() { Id = 26, Name = "JavaScript" });
                _context.Technologies.Add(new Technology() { Id = 27, Name = "BootStrap" });
                _context.Technologies.Add(new Technology() { Id = 28, Name = "Objective-C" });
                _context.Technologies.Add(new Technology() { Id = 29, Name = "HTML" });
                _context.Technologies.Add(new Technology() { Id = 30, Name = "CSS" });
                _context.SaveChanges();
            

                UserTechnology ut = new UserTechnology();

                ut.User = _context.Users.FirstOrDefault(u => u.Id == 1);
                ut.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "Entity Framework Core");

                _context.UserTechnologies.Add(ut);
                _context.SaveChanges();

                UserTechnology ut1 = new UserTechnology();

                ut1.User = _context.Users.FirstOrDefault(u => u.Id == 10);
                ut1.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "Objective-C");

                _context.UserTechnologies.Add(ut1);
                _context.SaveChanges();

                UserTechnology ut2 = new UserTechnology();

                ut2.User = _context.Users.FirstOrDefault(u => u.Id == 2);
                ut2.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "JavaScript");

                _context.UserTechnologies.Add(ut2);
                _context.SaveChanges();

                UserTechnology ut3 = new UserTechnology();

                ut3.User = _context.Users.FirstOrDefault(u => u.Id == 3);
                ut3.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "Python");

                _context.UserTechnologies.Add(ut3);
                _context.SaveChanges();

                UserTechnology ut4 = new UserTechnology();

                ut4.User = _context.Users.FirstOrDefault(u => u.Id == 4);
                ut4.Technology = _context.Technologies.FirstOrDefault(t => t.Name == "Node.js");

                _context.UserTechnologies.Add(ut4);
                _context.SaveChanges();
     
            }

        }
        // GET api/users
        [HttpGet]
        public List<User> Get(string username, string password)
        {
            Console.WriteLine("it works");

            if(username == null || password == null)
            {
                return _context.Users.Include("UserProjects").Include("UserProjects.Project").Include("UserProjects.Project.ProjectTechnologies").Include("UserProjects.Project.ProjectTechnologies.Technology").Include("UserTechnologies").Include("UserTechnologies.Technology").Include("UserTechnologies.User").ToList();
            }

            foreach (User u in _context.Users)
            {
                if (u.UserName == username && u.Password == password)
                {
                    var x = new List<User>();
                    x.Add(u);
                    return x;
                }

            }
            return null;    
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            foreach(User u in _context.Users.Include("UserProjects").Include("UserProjects.Project").Include("UserProjects.Project.ProjectTechnologies").Include("UserProjects.Project.ProjectTechnologies.Technology").Include("UserTechnologies").Include("UserTechnologies.Technology").Include("UserTechnologies.User"))
            {
                if(u.Id == id)
                {
                    return u;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public User Post([FromBody]User u)
        {
            u.Id = _context.Users.Count() + 1;
            _context.Users.Add(u);
            _context.SaveChanges();
            return u;
        }


        [HttpPut("{id}/addproject")]
        public User AddProject(int id, int projId )
        {
            foreach (User u in _context.Users.Include("UserProjects").Include("Users"))
            {
                if (u.Id == id)
                {
                    UserProject up = new UserProject();

                    up.User = u;
                    up.Project = _context.Projects.FirstOrDefault(p => p.Id == projId);

                    if (u.UserProjects == null)
                    {
                        u.UserProjects = new List<UserProject>();
                    }

                    u.UserProjects.Add(up);
                    _context.SaveChanges();

                    return u;
                }
            }
            return null;
        }

        [HttpPut("{id}/addtechnology")]
        public User AddTechnology(int id, string techName)
        {
            foreach (User u in _context.Users.Include("UserTechnologies").Include("UserTechnologies.Technology").Include("UserTechnologies.Technology.Technology").Include("UserTechnologies.User").Include("UserTechnologies.Technology.Project"))
            {
                if (u.Id == id)
                {
                    UserTechnology ut = new UserTechnology();

                    ut.User = u;
                    ut.Technology = _context.Technologies.FirstOrDefault(t => t.Name == techName);

                    if (u.UserTechnologies == null)
                    {
                        u.UserTechnologies = new List<UserTechnology>();
                    }

                    u.UserTechnologies.Add(ut);
                    _context.SaveChanges();

                    return u;
                }
            }
            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody]User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            foreach (User u in _context.Users)
            {
                if (u.Id == id)
                {
                    _context.Users.Remove(u);
                    _context.SaveChanges();
                    return "Deleted";
                }
            }
            return "No User Found";
        }
    }
}
