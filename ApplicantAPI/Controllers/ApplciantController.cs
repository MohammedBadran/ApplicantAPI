using Applicant.Domain;
using Applicant.DTO;
using Applicant.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Applicant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplciantController : ControllerBase
    {
        private readonly IApplciantAppService _applciantAppService;
        public ApplciantController(IApplciantAppService applciantAppService)
        {
            _applciantAppService = applciantAppService;
        }
        [HttpGet]
        public IActionResult GetApplicantList()
        {
            return Ok(_applciantAppService.GetApplicantList());
        }
        [HttpDelete]
        public IActionResult DeleteApplciant(int id)
        {
            _applciantAppService.DeleteApplciant(id);
            return Ok();// todo handle reponse 
        }
        [HttpPut]
        public IActionResult UpdateApplciant(ApplicantDto applicant)
        {
            _applciantAppService.UpdateApplciant(applicant);
            return Ok();// todo .. handle reponse 
        }
        [HttpPost]
        public IActionResult AddApplciant(ApplicantDto applicant)
        {
            _applciantAppService.AddApplciant(applicant);
            return Ok();// todo .. handle reponse 
        }
        [HttpGet("ValidateCountryName")]
        public async Task<IActionResult> ValidateCountryName(string countryName)
        {
           
            return Ok(await _applciantAppService.ValidateCountryName(countryName));
            // todo .. handle reponse 
        }
    }
}
