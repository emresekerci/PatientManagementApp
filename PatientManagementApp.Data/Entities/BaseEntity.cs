using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    // Tüm entity sınıflarının temel özelliklerini içeren base sınıf
    public class BaseEntity
    {
        // Her entity için birincil anahtar (Primary Key)
        public int Id { get; set; }

        // Entity'nin oluşturulma tarihi
        public DateTime CreatedDate { get; set; }

        // Entity'nin son değiştirilme tarihi (nullable)
        public DateTime? ModifiedDate { get; set; }

        // Entity'nin silinip silinmediğini belirten bayrak
        public bool IsDeleted { get; set; }
    }

    // Tüm entity konfigurasyonları için temel yapı sağlayan abstract sınıf
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity // TEntity, BaseEntity sınıfından türemiş olmalı
    {
        // Entity'nin yapılandırmasını yapan metod
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Tüm sorgularda IsDeleted = false olan veriler çekilecek
            builder.HasQueryFilter(x => x.IsDeleted == false);

            // ModifiedDate property'si zorunlu bir alan değil
            builder.Property(x => x.ModifiedDate)
                   .IsRequired(false);
        }
    }
}
