using Leadership.Domain.Models;
using Leadership.Domain.IServices;
using Leadership.Domain.Constant;
using Microsoft.AspNetCore.Mvc;

namespace Leadership.Server.Controllers
{
    [Route(RouteMapConstants.BaseControllerRoute)]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResponses()
        {
            var responses = await _responseService.GetAll();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResponseById(int id)
        {
            var response = await _responseService.GetById(id);
            if (response == null)
                return NotFound($"Response with ID {id} not found.");
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResponse([FromBody] Response response)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdResponse = await _responseService.Create(response);
            return CreatedAtAction(nameof(GetResponseById), new { id = createdResponse.ResponseId }, createdResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResponse(int id,[FromBody] Response response)
        {
            if (id != response.ResponseId)
                return BadRequest("Response ID mismatch.");

            var updatedResponse = await _responseService.Update(response);
            if (updatedResponse == null)
                return NotFound($"Response with ID {id} not found.");

            return Ok(updatedResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            var deletedResponse = await _responseService.DeleteById(id);
            if (deletedResponse == null)
                return NotFound($"Response with ID {id} not found.");

            return Ok(deletedResponse);
        }
    }
}
