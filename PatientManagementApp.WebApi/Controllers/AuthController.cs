using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PatientManagementApp.Business.Operations.Patient;
using PatientManagementApp.Business.Operations.Patient.Dtos;
using PatientManagementApp.WebApi.Jwt;
using PatientManagementApp.WebApi.Models;
using System.Diagnostics.Eventing.Reader;
using LoginRequest = PatientManagementApp.WebApi.Models.LoginRequest;
using RegisterRequest = PatientManagementApp.WebApi.Models.RegisterRequest;

namespace PatientManagementApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public AuthController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //Action Filter olarak kodlanacak
            }
            var addPatientDto = new AddPatientDto
            {

                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Password = request.Password,
                BirthDate = request.BirthDate,
                ContactInfo = request.ContactInfo,
                Email = request.Email,

            };
            var result = await _patientService.AddPatient(addPatientDto);
            if (result.IsSucceed)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }


        }
        [HttpPost("login")]

        public IActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //Action Filter olarak kodlanacak
            }
            var result = _patientService.LoginPatient(new LoginPatientDto { Email = request.Email, Password = request.Password });
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);


            }
            var patient = result.Data;

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwtToken(new JwtDto
            {
                Id = patient.Id,
                Email = patient.Email,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Gender = patient.Gender,
                UserType = patient.UserType,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!),

            });

            return Ok(new LoginResponse
            {
                Message = "Giriş başarıyla tamamlandı.",
                Token = token,
            });

        }
        [HttpGet("me")]
        [Authorize]
        public IActionResult GetMyUser()
        {
            return Ok();
        }

    }
}
