using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leadership.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly ILeaderBoardService _leaderBoardService;

        public LeaderBoardController(ILeaderBoardService leaderBoardService)
        {
            _leaderBoardService = leaderBoardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _leaderBoardService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _leaderBoardService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"Leaderboard entry with ID {id} not found.");
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeaderBoard leaderboard)
        {
            var created = await _leaderBoardService.CreateAsync(leaderboard);
            return CreatedAtAction(nameof(GetById), new { id = created.LeaderboardId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LeaderBoard leaderboard)
        {
            if (id != leaderboard.LeaderboardId)
                return BadRequest("ID mismatch.");

            var updated = await _leaderBoardService.UpdateAsync(leaderboard);
            if (updated == null)
                return NotFound($"Leaderboard entry with ID {id} not found.");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _leaderBoardService.DeleteAsync(id);
            if (deleted == null)
                return NotFound($"Leaderboard entry with ID {id} not found.");

            return Ok(deleted);
        }
    }
}
