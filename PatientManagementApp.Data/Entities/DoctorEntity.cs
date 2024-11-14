using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    public class DoctorEntity : BaseEntity
    {
        // Doktorun ilk adı
        public string FirstName { get; set; }

        // Doktorun soyadı
        public string LastName { get; set; }

        // Doktorun branşı (uzmanlık alanı)
        public string Branch { get; set; }

        // Doktorun iletişim numarası
        public string ContactNumber { get; set; }

        // Doktorun bağlı olduğu klinik ID'si
        public int ClinicId { get; set; }
    }

    // DoctorEntity yapılandırması için konfigürasyon sınıfı
    public class DoctorConfiguration : BaseConfiguration<DoctorEntity>
    {
        // Entity yapılandırmasını tanımlar
        public override void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            // FirstName özelliğini zorunlu yapar ve maksimum uzunluğunu 40 karakter olarak belirler
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(40);

            // LastName özelliğini zorunlu yapar ve maksimum uzunluğunu 40 karakter olarak belirler
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(40);

            // Branch özelliğini zorunlu yapar
            builder.Property(x => x.Branch).IsRequired();

            // BaseConfiguration'daki yapılandırmayı uygular
            base.Configure(builder);
        }
    }
}
