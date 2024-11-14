using System.ComponentModel.DataAnnotations;

namespace PatientManagementApp.WebApi.Models
{
    public class AddClinicRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public List<int>FeatureIds { get; set; }
    }
}
