using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using Leadership.Domain.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leadership.Server.Controllers
{
    [Route(RouteMapConstants.BaseControllerRoute)]
    public class OptionController : ControllerBase
    {
        public readonly IOptionService _optionService;
        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _optionService.GetAllOptionsAsync();
            return Ok(options);
        }

        [HttpGet(RouteMapConstants.GetOptionsById)]
        public async Task<IActionResult> GetOptionById(int optionId)
        {
            var option = await _optionService.GetOptionByIdAsync(optionId);
            if (option == null)
            {
                return NotFound();
            }
            return Ok(option);
        }

        [HttpPost("CreateOption")]
        public async Task<IActionResult> CreateOption( [FromBody]Option option)
        {
            if (option == null)
            {
                return BadRequest();
            }
            var createdOption = await _optionService.CreateOptionAsync(option);
            return CreatedAtAction(nameof(GetOptionById), new { optionId = createdOption.OptionId }, createdOption);
        }

        [HttpPut("UpdateOption/{optionId}")]
        public async Task<IActionResult> UpdateOption(int optionId,[FromBody] Option option)
        {
            if (optionId != option.OptionId || option == null)
            {
                return BadRequest();
            }
            var updatedOption = await _optionService.UpdateOptionAsync(option);
            if (updatedOption == null)
            {
                return NotFound();
            }
            return Ok(updatedOption);
        }

        [HttpDelete("DeleteOption/{optionId}")]
        public async Task<IActionResult> DeleteOption(int optionId)
        {
            var deleted = await _optionService.DeleteOptionAsync(optionId);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
