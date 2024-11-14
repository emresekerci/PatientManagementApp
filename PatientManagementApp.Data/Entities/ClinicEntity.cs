using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    // Klinik bilgilerini tutan entity sınıfı
    public class ClinicEntity : BaseEntity
    {
        // Kliniğin adı (Zorunlu ve maksimum 50 karakter uzunluğunda)
        public string Name { get; set; }

        // Kliniğin konumu (adres veya şehir bilgisi)
        public string Location { get; set; }

        // Kliniğin telefon numarası (Zorunlu ve maksimum 11 karakter uzunluğunda)
        public string PhoneNumber { get; set; }

        // Kliniğin sahip olduğu özellikler (İlişkisel veri için ICollection)
        public ICollection<ClinicFeatureEntity> ClinicFeatures { get; set; }
    }

    // ClinicEntity için konfigürasyon sınıfı
    public class ClinicConfiguration : BaseConfiguration<ClinicEntity>
    {
        // ClinicEntity yapılandırmasını yapan metod
        public override void Configure(EntityTypeBuilder<ClinicEntity> builder)
        {
            // Name özelliğinin zorunlu ve maksimum 50 karakter olmasını sağlıyor
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // PhoneNumber özelliğinin zorunlu ve maksimum 11 karakter olmasını sağlıyor
            builder.Property(x => x.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(11);

            // BaseConfiguration sınıfındaki genel ayarları uyguluyor
            base.Configure(builder);
        }
    }
}
