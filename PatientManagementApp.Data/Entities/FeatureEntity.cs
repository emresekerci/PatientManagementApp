using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    // Özellik bilgilerini temsil eden entity
    public class FeatureEntity : BaseEntity
    {
        // Özelliğin başlığı (adı)
        public string Title { get; set; }

        // Klinik ile özellik arasındaki ilişkisel özellik
        // Bir özellik birden fazla klinikle ilişkilendirilebilir
        public ICollection<ClinicFeatureEntity> ClinicFeatures { get; set; }
    }

    // FeatureEntity yapılandırması için konfigürasyon sınıfı
    public class FeatureConfiguration : BaseConfiguration<FeatureEntity>
    {
        // Entity yapılandırmasını tanımlar
        public override void Configure(EntityTypeBuilder<FeatureEntity> builder)
        {
            // BaseConfiguration'daki yapılandırmayı uygular
            base.Configure(builder);
        }
    }
}
