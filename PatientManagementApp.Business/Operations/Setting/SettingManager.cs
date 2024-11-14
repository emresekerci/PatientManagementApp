using PatientManagementApp.Data.Entities;
using PatientManagementApp.Data.Repositories;
using PatientManagementApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Setting
{
    public class SettingManager : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SettingEntity> _settingRepository;
        public SettingManager(IUnitOfWork unitOfWork,IRepository<SettingEntity>settingRepository)
        {
            _unitOfWork = unitOfWork;
            _settingRepository = settingRepository;
        }

        public bool GetMaintenancecState()
        {
            var maintenanceState = _settingRepository.GetById(1).MaintenenceMode;
            return maintenanceState;
        }

        public async Task ToggleMaintenence()
        {
            var setting = _settingRepository.GetById(1);
            setting.MaintenenceMode = !setting.MaintenenceMode;
            _settingRepository.Update(setting);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Bakım durumu güncelleştirilemedi.");
            }
        }
    }
}
