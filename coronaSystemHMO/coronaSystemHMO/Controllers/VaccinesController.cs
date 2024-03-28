using coronaSystemHMO_BL;
using coronaSystemHMO_DAL.Models;
using coronaSystemHMO_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coronaSystemHMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly IVaccineBL _vaccineBL;

        public VaccinesController(IVaccineBL vaccineBL)
        {
            _vaccineBL = vaccineBL ?? throw new ArgumentNullException(nameof(vaccineBL));
        } 

        [HttpGet("{memberId}")]
        public async Task<IActionResult> GetVaccineByMemberId(int memberId)
        {
            try
            {
                var vaccines = await _vaccineBL.GetVaccinesByMemberIdAsync(memberId);
                if (vaccines == null || !vaccines.Any())
                {
                    return NotFound();
                }
                return Ok(vaccines);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVaccineByMemberId([FromBody] VaccineDTO vaccineDTO)
        {
            try
            {
                await _vaccineBL.AddVaccineByMemberIdAsync(vaccineDTO);
                return CreatedAtAction(nameof(GetVaccineByMemberId), new { MemberId = vaccineDTO.MemberId }, vaccineDTO);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        
    }
}
