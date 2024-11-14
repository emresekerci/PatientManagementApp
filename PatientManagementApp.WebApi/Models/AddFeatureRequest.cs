using System.ComponentModel.DataAnnotations;

namespace PatientManagementApp.WebApi.Models
{
    public class AddFeatureRequest
    {
        [Required]
        public string Title { get; set; }
    }
}
