using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.DataProtection
{
    // Veriyi şifrelemek ve çözmek için kullanılan sınıf
    public class DataProtection : IDataProtection
    {
        // Veri koruma işlemlerini sağlayan bir IDataProtector örneği
        private readonly IDataProtector _protector;

        // Constructor: IDataProtectionProvider kullanarak bir IDataProtector örneği oluşturur
        public DataProtection(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("security"); // "security" amacı ile koruyucu oluşturuluyor
        }

        // Veriyi şifreler
        public string Protect(string text)
        {
            return _protector.Protect(text); // Metni şifreleyip geri döner
        }

        // Şifrelenmiş veriyi çözer
        public string UnProtect(string protectedText)
        {
            return _protector.Unprotect(protectedText); // Şifrelenmiş metni çözüp geri döner
        }
    }
}
