using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly DevMatchContext _context;

        public UsersController(DevMatchContext context)
        {
            _context = context;

            if(_context.Users.Count() == 0)
            {
                _context.Users.Add(new User() { Id = 1, FirstName = "Bob", LastName = "Smith", Email = "bob@gmail.com", PhoneNumber = "212-332-4433", AddressLine1 = "176 Granada Ave", AddressLine2 = "Apt 10", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/bob.jpg", UserName = "bobbo", Password = "bob", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "", LinkedIn = ""});
                _context.Users.Add(new User() { Id = 2, FirstName = "Jeff", LastName = "Davis", Email = "JD@gmail.com", PhoneNumber = "111-222-2222", AddressLine1 = "102 Rive Alto Canal", AddressLine2 = "", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Jeff.jpg", UserName = "dude", Password = "dude", JobTitle = "Software Engineer", ProficiencyLevel = "Beginner", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 3, FirstName = "Elijah", LastName = "Thomas", Email = "ETphoneHome@gmail.com", PhoneNumber = "800-900-2900", AddressLine1 = "5567 E Saint Irmo Walk", AddressLine2 = "Apt 1", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Elijah.png", UserName = "ET", Password = "ET", JobTitle = "Full Stack Developer", ProficiencyLevel = "Intermediate", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 4, FirstName = "Cole", LastName = "James", Email = "KALE@gmail.com", PhoneNumber = "225-666-4993", AddressLine1 = "52 W Neapolitan Ln", AddressLine2 = "", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Cole.jpg", UserName = "Cole", Password = "ilovekale", JobTitle = "Front End Developer", ProficiencyLevel = "Intermediate", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 5, FirstName = "Max", LastName = "Baker", Email = "baker@gmail.com", PhoneNumber = "245-090-8888", AddressLine1 = "5568 E Saint Irmo Walk", AddressLine2 = "Apt 4", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Max.jpg", UserName = "MrMax", Password = "coolguy", JobTitle = "BackEnd (SQL) Developer", ProficiencyLevel = "Advanced", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 6, FirstName = "Jake", LastName = "Bell", Email = "bell@gmail.com", PhoneNumber = "211-432-6433", AddressLine1 = "29 Geneva Walk", AddressLine2 = "Apt 8", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Jake.png", UserName = "Jake", Password = "Jake", JobTitle = "Front End Developer", ProficiencyLevel = "Beginner", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 7, FirstName = "Thomas", LastName = "Jefferson", Email = "TJ@gmail.com", PhoneNumber = "789-345-7654", AddressLine1 = "162 Savona Walk", AddressLine2 = "Apt 20", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Thomas.jpg", UserName = "Thom", Password = "Thom", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 8, FirstName = "Karen", LastName = "DeLuca", Email = "KD@gmail.com", PhoneNumber = "567-456-9876", AddressLine1 = "5649 E Sorrento Dr", AddressLine2 = "", City = "Long Beach", State = "CA", Zip = 90803, Image = "./Images/Karen.png", UserName = "Karen", Password = "karen", JobTitle = "Front End Developer", ProficiencyLevel = "Intermediate", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 9, FirstName = "Mark", LastName = "Geller", Email = "mar@gmail.com", PhoneNumber = "212-332-4433", AddressLine1 = "2615 Avenue O", AddressLine2 = "Apt 2H", City = "Brooklyn", State = "NY", Zip = 11210, Image = "./Images/Mark.jpg", UserName = "Mark", Password = "marker", JobTitle = "Software Developer", ProficiencyLevel = "Beginner", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 10, FirstName = "Zach", LastName = "Lucas", Email = "zluc@gmail.com", PhoneNumber = "724-787-9345", AddressLine1 = "5409 Avenue L", AddressLine2 = "Apt 4", City = "Brooklyn", State = "NY", Zip = 11234, Image = "./Images/Zach.jpg", UserName = "zach", Password = "zluc", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 11, FirstName = "Jessica", LastName = "Depalma", Email = "jj@gmail.com", PhoneNumber = "212-362-8833", AddressLine1 = "1611 E 36th St", AddressLine2 = "Apt 11", City = "Brooklyn", State = "NY", Zip = 11234, Image = "./Images/Jessica.jpg", UserName = "jessi", Password = "ilovecode", JobTitle = "Front End Developer", ProficiencyLevel = "Intermediate", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 12, FirstName = "Angela", LastName = "Evans", Email = "AEIOU@gmail.com", PhoneNumber = "978-456-7667", AddressLine1 = "3178 Nostrand Ave", AddressLine2 = "Apt 7", City = "Brooklyn", State = "NY", Zip = 11229, Image = "./Images/Angela.jpg", UserName = "angie", Password = "crossfitrules", JobTitle = "Developer", ProficiencyLevel = "Intermediate", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 13, FirstName = "Lexi", LastName = "Johnson", Email = "alexa@gmail.com", PhoneNumber = "433-223-0009", AddressLine1 = "2214 E 29th St", AddressLine2 = "Apt 18", City = "Brooklyn", State = "NY", Zip = 11229, Image = "./Images/lexi.jpg", UserName = "Lexi", Password = "LBJ", JobTitle = "Software Engineer", ProficiencyLevel = "Advanced", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 14, FirstName = "Francis", LastName = "Marx", Email = "MF@gmail.com", PhoneNumber = "312-338-5533", AddressLine1 = "68 Bevy Ct", AddressLine2 = "", City = "Brooklyn", State = "NY", Zip = 11229, Image = "./Images/Francis.jpg", UserName = "frank", Password = "frank", JobTitle = "Software Developer", ProficiencyLevel = "Intermediate", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 15, FirstName = "Derek", LastName = "Kozar", Email = "dk@gmail.com", PhoneNumber = "310-220-2250", AddressLine1 = "2443 Ocean Ave", AddressLine2 = "Apt 13", City = "Brooklyn", State = "NY", Zip = 11229, Image = "./Images/Derek.jpg", UserName = "dman", Password = "ddude", JobTitle = "Front End Developer, UX/UI Designer", ProficiencyLevel = "Intermediate", GitHubLink = "", LinkedIn = "" });
                _context.Users.Add(new User() { Id = 16, FirstName = "Calvin", LastName = "Anderson", Email = "CA@gmail.com", PhoneNumber = "212-332-4433", AddressLine1 = "2220 National Dr", AddressLine2 = "Apt 19", City = "Brooklyn", State = "NY", Zip = 11234, Image = "./Images/Calvin.jpg", UserName = "Calvin", Password = "mandude", JobTitle = "Back End Developer", ProficiencyLevel = "Beginner", GitHubLink = "", LinkedIn = "" });
                _context.SaveChanges();
            }
        }
        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            foreach(User u in _context.Users)
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
            _context.Users.Add(u);
            _context.SaveChanges();
            return u;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody]User user)
        {
            foreach (User u in _context.Users)
            {
                if (u.Id == id)
                {
                    _context.Users.Remove(u);
                    _context.SaveChanges();
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return user;
                }
            }
            return null;
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
