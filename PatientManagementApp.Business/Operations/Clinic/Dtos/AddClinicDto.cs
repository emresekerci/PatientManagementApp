using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Clinic.Dtos
{
    public class AddClinicDto
    {
       
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        // Klinik özelliklerini belirten FeatureId'lerin listesi
        public List<int> FeatureIds { get; set; }
    }
}

