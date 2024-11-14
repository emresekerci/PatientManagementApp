using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagementApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    public class AppointmenEntity:BaseEntity
    {
        public int ClinicDoctorPatientId { get; set; }        // Ara tablodan gelen ID
        public ClinicDoctorPatientEntity ClinicDoctorPatient { get; set; } // İlişki

        public DateTime AppointmentDate { get; set; }         // Randevu tarihi
        public string ReasonForVisit { get; set; }            // Ziyaret nedeni
        public AppointmentStatus Status { get; set; }         // Randevu durumu 
    }
    public class AppointmentConfiguration : BaseConfiguration<AppointmenEntity>
    {
        public override void Configure(EntityTypeBuilder<AppointmenEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
