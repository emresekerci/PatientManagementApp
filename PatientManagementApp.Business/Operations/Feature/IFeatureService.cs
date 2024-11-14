using PatientManagementApp.Business.Operations.Feature.Dtos;
using PatientManagementApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Business.Operations.Feature
{
    public interface IFeatureService
    {
        Task<ServiceMessage> AddFeature(AddFeatureDto feature); 
    }
}
