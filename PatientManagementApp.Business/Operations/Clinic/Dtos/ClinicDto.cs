using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Clinic.Dtos
{
    public class ClinicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        // Klinik özelliklerinin listesi (özellikler ClinicFeatureDto sınıfına ait)
        public List<ClinicFeatureDto> Features { get; set; }
    }
}
