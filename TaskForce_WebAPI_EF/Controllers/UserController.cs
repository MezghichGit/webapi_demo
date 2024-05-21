using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using TaskForce_WebAPI_EF.Models;

namespace TaskForce_WebAPI_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext userContext;

        public UserController(UserContext userContext)
        {
            this.userContext = userContext;
        }

        // GET: api/GetUsers
        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return userContext.Users.ToList();
        }

        // Post: api/PostUsers
        [HttpPost]
        [Route("AddUsers")]
        public string AddUsers(Users user)
        {
             userContext.Users.Add(user);
            userContext.SaveChanges();
            return "User added successfully";
        }

        // GET: api/GetOneUser
        [HttpGet]
        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return userContext.Users.Where(x => x.ID == id).FirstOrDefault();
        }
        // PUT: api/UpdateOneUser
        [HttpPut]
        [Route("UpdateUser")]
        public string updateUser(Users user)
        {
            userContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            userContext.SaveChanges();
            return "User updated successfully";
        }
        // Delete: api/DeleteOneUser
        [HttpDelete]
        [Route("DeleteUser")]
        public string deleteUser(int id)
        {
            Users user = userContext.Users.Where(x => x.ID == id).FirstOrDefault();

            if(user != null) {
                userContext.Users.Remove(user);
                userContext.SaveChanges();
                return "User deleted successfully";
            }
            else
                return "User not found";

        }
    }
}
