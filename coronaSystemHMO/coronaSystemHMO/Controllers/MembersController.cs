using coronaSystemHMO_BL;
using coronaSystemHMO_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coronaSystemHMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberBL _memberBL;

        public MembersController(IMemberBL memberBL)
        {
            _memberBL = memberBL ?? throw new ArgumentNullException(nameof(memberBL));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            try
            {
                var members = await _memberBL.GetAllMembersAsync();
                return Ok(members);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{memberId}")]
        public async Task<IActionResult> GetMemberById(int memberId)
        {
            try
            {
                var member = await _memberBL.GetMemberByIdAsync(memberId);
                if (member == null)
                {
                    return NotFound();
                }
                return Ok(member);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] MemberDTO memberDTO)
        {
            try
            {
                await _memberBL.AddMemberAsync(memberDTO);
                return CreatedAtAction(nameof(GetMemberById), new { memberId = memberDTO.MemberId }, memberDTO);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{memberId}")]
        public async Task<IActionResult> UpdateMember(int memberId, [FromBody] MemberDTO memberDTO)
        {
            try
            {
                if (memberId != memberDTO.MemberId)
                {
                    return BadRequest();
                }
                await _memberBL.UpdateMemberAsync(memberDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{memberId}")]
        public async Task<IActionResult> DeleteMember(int memberId)
        {
            try
            {
                await _memberBL.DeleteMemberAsync(memberId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
