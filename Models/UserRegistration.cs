using System.ComponentModel.DataAnnotations;

namespace API_FloorAssign.Models
{
    public class UserRegistration
    {
        [Key]
        public int UserRegId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateOnly DOB { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
