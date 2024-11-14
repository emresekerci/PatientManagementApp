using PatientManagementApp.Business.Operations.Patient.Dtos;
using PatientManagementApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Patient
{
    public interface IPatientService
    {
        Task<ServiceMessage> AddPatient(AddPatientDto patient); //async çünkü unit of work kullanılacak.
        ServiceMessage<PatientInfoDto> LoginPatient(LoginPatientDto patient);
    }
}
