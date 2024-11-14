using Microsoft.EntityFrameworkCore;
using PatientManagementApp.Business.Types;
using PatientManagementApp.Data.Entities;
using PatientManagementApp.Data.Repositories;
using PatientManagementApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Clinic.Dtos
{
    public class ClinicManager : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ClinicEntity> _clinicRepository;
        private readonly IRepository<ClinicFeatureEntity> _clinicFeatureRepository;
        public ClinicManager(IUnitOfWork unitOfWork, IRepository<ClinicEntity> clinicRepository, IRepository<ClinicFeatureEntity> clinicFeatureRepository)
        {
            _unitOfWork = unitOfWork;
            _clinicRepository = clinicRepository;
            _clinicFeatureRepository = clinicFeatureRepository;
        }

        public async Task<ServiceMessage> AddClinic(AddClinicDto clinic)
        {
            var hasClinic = _clinicRepository.GetAll(x => x.Name.ToLower()==clinic.Name.ToLower()).Any();
            if (hasClinic)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Klinik zaten mevcut."
                };
            }
            await _unitOfWork.BeginTransAction();
            var clinicEntity = new ClinicEntity
            {
                Name = clinic.Name,
                Location = clinic.Location,
                PhoneNumber = clinic.PhoneNumber,
            };
            _clinicRepository.Add(clinicEntity);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Klinik kaydı sırasında bir sorunla karşılaşıldı.");
            }
            foreach (var featureId in clinic.FeatureIds)
            {
                var clinicFeature = new ClinicFeatureEntity
                {
                    ClinicId = clinicEntity.Id,
                    FeatureId = featureId,
                };
                _clinicFeatureRepository.Add(clinicFeature);
            }
            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransAction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransAction();
                throw new Exception("Klinik özellikleri eklenemedi.");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
            };
        }

        public async Task<ServiceMessage> AdjustClinicLocation(int id, string changeto)
        {
            var clinic = _clinicRepository.GetById(id);
            if (clinic is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu id ile eşleşen klinik bulunamadı."

                };
                
            }
            clinic.Location = changeto;
            _clinicRepository.Update(clinic);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Lokasyon bilgisi değiştirilirken bir hata ile karşılaşıldı.");
            }
            return new ServiceMessage
            { IsSucceed = true };
            
        }

        public async Task<ServiceMessage> DeleteClinic(int id)
        {
            var clinic = _clinicRepository.GetById(id);
            if(clinic is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Silinmek istenen klinik bulunamadı."
                };
            }

            _clinicRepository.Delete(id);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Silme işlemi sırasında bir hata oluştu.");
            }
            return new ServiceMessage { IsSucceed = true };
        }

        public async Task<ClinicDto> GetClinic(int id)
        {
            var clinic =  await _clinicRepository.GetAll(x => x.Id == id)
                .Select(x => new ClinicDto
                {        
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    PhoneNumber = x.PhoneNumber,
                    Features = x.ClinicFeatures.Select(f => new ClinicFeatureDto
                    {
                        Id = f.Id,
                        Title = f.Feature.Title,
                    }).ToList()
                }).FirstOrDefaultAsync();
            return clinic;
        }

        public async Task<List<ClinicDto>> GetClinics()
        {
            var clinics = await _clinicRepository.GetAll()
               .Select(x => new ClinicDto
               {
                   Id = x.Id,
                   Name = x.Name,
                   Location = x.Location,
                   PhoneNumber = x.PhoneNumber,
                   Features = x.ClinicFeatures.Select(f => new ClinicFeatureDto
                   {
                       Id = f.Id,
                       Title = f.Feature.Title,
                   }).ToList()
               }).ToListAsync ();
            return clinics;
        }

        public async Task<ServiceMessage> UpdateClinic(UpdateClinicDto clinic)
        {
            var clinicEntity = _clinicRepository.GetById(clinic.Id);
            if (clinicEntity is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Klinik bulunamadı"
                };
            }

            await _unitOfWork.BeginTransAction();
            clinicEntity.Name = clinic.Name;
            clinicEntity.Location = clinic.Location;
            clinicEntity.PhoneNumber = clinic.PhoneNumber;

            _clinicRepository.Update(clinicEntity);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransAction();
                throw new Exception("Klinik bilgileri güncellenemedi.");
               
            }

               var clinicFeatures = _clinicFeatureRepository.GetAll(x => x.ClinicId == x.ClinicId).ToList();

            foreach (var clinicFeature in clinicFeatures)
            {
                _clinicFeatureRepository.Delete(clinicFeature,false); //Hard Delete işlemi gerçekleştiriyoruz
            }

            foreach (var featureId in clinic.FeatureIds)
            {
                var clinicFeature = new ClinicFeatureEntity
                {
                    ClinicId = clinicEntity.Id,
                    FeatureId = featureId
                };
                _clinicFeatureRepository.Add(clinicFeature);
            }
            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransAction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransAction();
                throw new Exception("Klinik bilgileri güncellenemedi.İşlemler geriye alınıyor.");
            }
            return new ServiceMessage
            { IsSucceed = true };
        }
    }
}
