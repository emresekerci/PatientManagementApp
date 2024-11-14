using PatientManagementApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Clinic.Dtos
{
    public interface IClinicService
    {
        Task<ServiceMessage> AddClinic(AddClinicDto clinic);
        Task<ClinicDto> GetClinic(int id);
        Task<List<ClinicDto>> GetClinics();
        Task<ServiceMessage> AdjustClinicLocation(int id,string changeto);
        Task<ServiceMessage> DeleteClinic(int id);
        Task<ServiceMessage> UpdateClinic(UpdateClinicDto clinic);
    }

}
