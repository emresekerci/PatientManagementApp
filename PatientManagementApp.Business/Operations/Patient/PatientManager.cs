using PatientManagementApp.Business.DataProtection;
using PatientManagementApp.Business.Operations.Patient.Dtos;
using PatientManagementApp.Business.Types;
using PatientManagementApp.Data.Entities;
using PatientManagementApp.Data.Enums;
using PatientManagementApp.Data.Repositories;
using PatientManagementApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Patient

{
    public class PatientManager : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PatientEntity> _patientRepository;
        private readonly IDataProtection _protector;

        public PatientManager(IUnitOfWork unitOfWork,IRepository<PatientEntity>patientRepository,IDataProtection protector)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
            _protector = protector;
        }

        public async Task<ServiceMessage> AddPatient(AddPatientDto patient)
        {
            var HasEmail = _patientRepository.GetAll(x => x.Email == patient.Email);
            if (HasEmail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Böyle bir Tc numarası mevcut."
                };
                    
            }

            var patientEntity = new PatientEntity()
            {
                Email = patient.Email,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Gender = patient.Gender,
                ContactInfo = patient.ContactInfo,
                BirthDate = patient.BirthDate,
                Password = _protector.Protect(patient.Password),
                UserType = UserType.Patient,
            };
            _patientRepository.Add(patientEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Hasta kaydı sırasında bir hata oluştu");
            }
            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public ServiceMessage<PatientInfoDto> LoginPatient(LoginPatientDto patient)
        {
            var patientEntity = _patientRepository.Get(x => x.Email == patient.Email);
            if (patientEntity is null)
            {
                return new ServiceMessage<PatientInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı ya da şifre hatalı."
                };
            }
            var unprotectedPassword = _protector.UnProtect(patientEntity.Password);
            if (unprotectedPassword == patient.Password)
            {
                return new ServiceMessage<PatientInfoDto>
                {
                    IsSucceed = true,
                    Data = new PatientInfoDto
                    {
                        Email = patientEntity.Email,
                        FirstName = patientEntity.FirstName,
                        LastName = patientEntity.LastName,
                        Gender = patientEntity.Gender,
                        UserType = patientEntity.UserType,
                    }
                };
            }
            else
            {
                return new ServiceMessage<PatientInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı ya da şifre hatalı."
                };
            }
        }
    }
}
