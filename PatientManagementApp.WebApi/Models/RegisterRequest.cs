using System.ComponentModel.DataAnnotations;

namespace PatientManagementApp.WebApi.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ContactInfo { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
