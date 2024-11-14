using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Entities
{
    // Uygulama ayarlarını temsil eden entity
    public class SettingEntity : BaseEntity
    {
        // Bakım modu durumu (true ise uygulama bakım modunda)
        public bool MaintenenceMode { get; set; }
    }
}
