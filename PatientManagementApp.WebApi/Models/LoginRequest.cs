using System.ComponentModel.DataAnnotations;

namespace PatientManagementApp.WebApi.Models
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
