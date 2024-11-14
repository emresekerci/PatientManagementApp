using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Enums
{
    public enum AppointmentStatus
    {
        Scheduled,      // Planlandı, onaylandı
        Completed,      // Tamamlandı
        Canceled,       // İptal Edildi
        Rescheduled     // Yeniden planlandı
    }
}
