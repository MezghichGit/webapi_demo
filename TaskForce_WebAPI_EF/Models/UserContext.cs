using Microsoft.EntityFrameworkCore;

namespace TaskForce_WebAPI_EF.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
    }
}
