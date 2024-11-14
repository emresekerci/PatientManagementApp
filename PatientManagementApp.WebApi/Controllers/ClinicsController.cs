using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementApp.Business.Operations.Clinic.Dtos;
using PatientManagementApp.WebApi.Filters;
using PatientManagementApp.WebApi.Models;

namespace PatientManagementApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        public ClinicsController(IClinicService clinicService)
        {
            _clinicService = clinicService;

        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetClinic(int id)
        {
            var clinic = await _clinicService.GetClinic(id);
            if (clinic is null )
                return NotFound();
            else 
                return Ok(clinic);
        }

        [HttpGet]
        public async Task<IActionResult> GetClinics()
        {
            var clinics = await _clinicService.GetClinics();
            return Ok(clinics);
        }


        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddClinic(AddClinicRequest request)
        {
            var addClinicDto = new AddClinicDto
            {
                Name = request.Name,
                Location = request.Location,
                PhoneNumber = request.PhoneNumber,
                FeatureIds = request.FeatureIds,
            };
            var result = await _clinicService.AddClinic(addClinicDto);
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok();
            }
        }
        [HttpPatch("{id}/location")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdjustClinicLocation(int id,string changeto)
        {
            var result = await _clinicService.AdjustClinicLocation(id, changeto);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);

            }
            else
            {
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            var result = await _clinicService.DeleteClinic(id);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);

            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Admin")]
        
        public async Task<IActionResult>UpdateClinic(int id,UpdateClinicRequest request)
        {
            var updateClinicDto = new UpdateClinicDto
            {
                Id = id,
                Name = request.Name,
                Location = request.Location,
                PhoneNumber = request.PhoneNumber,
                FeatureIds = request.FeatureIds,
            };
            var result = await _clinicService.UpdateClinic(updateClinicDto);

            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            else
            { 
                return await GetClinic(id);
            }

        }


    }
}
