using System.ComponentModel.DataAnnotations;

namespace TaskForce_WebAPI_EF.Models
{
    public class Users
    {
        [Key] 
        public int ID { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
