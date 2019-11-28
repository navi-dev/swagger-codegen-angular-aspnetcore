using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> users = new List<User>()
        {
                new User(1, "Naveen", "Motwani", "naveen@gmail.com", "developer"),
                new User(2, "Gaurav", "Patel", "Gaurav@gmail.com", "manager"),
                new User(3, "Pavan", "Bandi", "Pavan@gmail.com", "lead"),
                 new User(4, "Lav", "Gupta", "naveen@gmail.com", "Architect")
        };

        [HttpGet("getAllUsers")]
        public List<User> GetUsers()
        {
            return users;
        }

        [HttpGet]
        [Route("getUser/{userId}")]
        public User GetUser(int userId)
        {
            var user = users.FirstOrDefault(elem => elem.Id == userId);
            return user;
        }

        [HttpPost]
        [Route("addUser")]
        public User AddUser(User user)
        {
            users = users.OrderBy(elem => elem.Id).ToList();
            user.Id = users.Last().Id + 1;
            users.Add(user);

            return user;
        }

        [HttpPost]
        [Route("deleteUser")]
        public string DeleteUser(int userId)
        {
            string message = "User not found";
            var user = users.FirstOrDefault(elem => elem.Id == userId);
            if (user != null)
            {
                users.Remove(user);

                message = "Deleted";
            }

            return message;
        }
    }
}