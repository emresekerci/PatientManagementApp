using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagementApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    // Hasta bilgilerini temsil eden entity
    public class PatientEntity : BaseEntity
    {
        // Hastanın e-posta adresi (Email formatı kontrol edilir)
        [EmailAddress]
        public string Email { get; set; }

        // Hastanın şifresi
        public string Password { get; set; }

        // Hastanın adı
        public string FirstName { get; set; }

        // Hastanın soyadı
        public string LastName { get; set; }

        // Hastanın cinsiyeti
        public string Gender { get; set; }

        // İletişim bilgisi (telefon numarası veya adres gibi)
        public string ContactInfo { get; set; }

        // Hastanın doğum tarihi
        public DateTime BirthDate { get; set; }

        // Kullanıcı tipi (hasta türünü belirtir)
        public UserType UserType { get; set; }
    }

    // PatientEntity yapılandırması için konfigürasyon sınıfı
    public class PatientConfiguration : BaseConfiguration<PatientEntity>
    {
        // Entity yapılandırmasını tanımlar
        public override void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            // FirstName alanı gereklidir ve maksimum 40 karakter uzunluğunda olabilir
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(40);

            // LastName alanı gereklidir ve maksimum 40 karakter uzunluğunda olabilir
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(40);

            // Gender alanı gereklidir
            builder.Property(x => x.Gender).IsRequired();

            // BaseConfiguration'daki yapılandırmayı uygular
            base.Configure(builder);
        }
    }
}
