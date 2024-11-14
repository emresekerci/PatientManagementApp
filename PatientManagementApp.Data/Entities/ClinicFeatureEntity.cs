using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    // Klinik özelliklerini temsil eden entity
    public class ClinicFeatureEntity : BaseEntity
    {
        // Klinik ID'si - ClinicEntity ile ilişkiyi belirtir
        public int ClinicId { get; set; }

        // Özellik ID'si - FeatureEntity ile ilişkiyi belirtir
        public int FeatureId { get; set; }

        // Klinik ile ilişkisel özellik
        public ClinicEntity Clinic { get; set; }

        // Özellik ile ilişkisel özellik
        public FeatureEntity Feature { get; set; }
    }

    // ClinicFeatureEntity yapılandırması için konfigürasyon sınıfı
    public class ClinicFeatureConfiguration : BaseConfiguration<ClinicFeatureEntity>
    {
        // Entity yapılandırmasını tanımlar
        public override void Configure(EntityTypeBuilder<ClinicFeatureEntity> builder)
        {
            // Id özelliğini veritabanında görmezden gelir
            builder.Ignore(x => x.Id);

            // ClinicId ve FeatureId'yi birleştirerek birincil anahtar oluşturur
            builder.HasKey("ClinicId", "FeatureId");

            // BaseConfiguration'daki yapılandırmayı uygular
            base.Configure(builder);
        }
    }
}
