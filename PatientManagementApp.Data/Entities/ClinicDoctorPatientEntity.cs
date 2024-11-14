using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    public class ClinicDoctorPatientEntity : BaseEntity
    {
        // Hangi hasta hangi klinikten hangi doktordan randevu aldı
        public int ClinicId { get; set; }
        public ClinicEntity Clinic { get; set; }

        public int DoctorId { get; set; }
        public DoctorEntity Doctor { get; set; }

        public int PatientId { get; set; }
        public PatientEntity Patient { get; set; }

        // İlişki kurmak için gereken alanlar
        public ICollection<AppointmenEntity> Appointments { get; set; }  // Randevular
    }
    public class ClinicDoctorPatientConfiguration : BaseConfiguration<ClinicDoctorPatientEntity>
    {
        public override void Configure(EntityTypeBuilder<ClinicDoctorPatientEntity> builder)
        {
            builder.Ignore(x => x.Id); // Id property tabloya aktarılmayacak(Ignore)
                builder.HasKey("ClinicId","DoctorId","PatientId");  //composite key oluşturup yeni "primary key" olarak atadık.
            base.Configure(builder);
        }
    }
}
