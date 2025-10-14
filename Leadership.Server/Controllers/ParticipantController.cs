using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using Leadership.Domain.Constant;
using Microsoft.AspNetCore.Mvc;

namespace Leadership.Server.Controllers
{
    [Route(RouteMapConstants.BaseControllerRoute)]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var participants = await _participantService.GetAll();
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participants = await _participantService.GetById(id);
            if (participants == null)
            {
                return NotFound(id);
            }
            return Ok(participants);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Participant participant)
        {
            var createParticipant = await _participantService.Create(participant);
            return CreatedAtAction(nameof(GetById), new { id = createParticipant.ParticipantId }, createParticipant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Participant participant)
        {
            if (participant == null || id != participant.ParticipantId)
                return BadRequest("Invalid participant data or ID mismatch.");

            var updated = await _participantService.Update(participant);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _participantService.Delete(id);
            if (deleted == null)
                return NotFound($"Participant with ID {id} not found.");

            return Ok(deleted);
        }
    }
}
