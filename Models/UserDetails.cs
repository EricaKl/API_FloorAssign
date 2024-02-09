using System.ComponentModel.DataAnnotations;

namespace API_FloorAssign.Models
{
    public class UserDetails
    {
        [Key]
        public int UserDetailID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly DOB { get; set; }   
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string? ProjectName { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; } = null;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? ModifiedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
