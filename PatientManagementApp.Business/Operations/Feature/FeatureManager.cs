using PatientManagementApp.Business.Operations.Feature.Dtos;
using PatientManagementApp.Business.Types;
using PatientManagementApp.Data.Entities;
using PatientManagementApp.Data.Repositories;
using PatientManagementApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Feature
{
    public class FeatureManager : IFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<FeatureEntity> _repository;
        public FeatureManager(IUnitOfWork unitOfWork,IRepository<FeatureEntity>repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            
        }
        public async Task<ServiceMessage> AddFeature(AddFeatureDto feature)
        {
            var hasFeature = _repository.GetAll(x => x.Title.ToLower() == feature.Title.ToLower()).Any();
            if (hasFeature)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Zaten bulunuyor."
                };
            }
            var featureEntity = new FeatureEntity
            {
                Title = feature.Title,
            };
            _repository.Add(featureEntity);
            try
            { 
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw new Exception("Kayıt sırasında bir hata oluştu");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
            };
        }
    }
}
