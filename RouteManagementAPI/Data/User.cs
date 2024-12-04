// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace RouteManagementAPI.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
