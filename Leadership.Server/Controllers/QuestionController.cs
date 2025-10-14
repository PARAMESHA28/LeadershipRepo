using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leadership.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("GetQuestionById/{questionId}")]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var question = await _questionService.GetQuestionByIdAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion( Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            var createdQuestion = await _questionService.CreateQuestionAsync(question);
            return CreatedAtAction(nameof(GetQuestionById), new { questionId = createdQuestion.QuestionId }, createdQuestion);
        }

        [HttpPut("UpdateQuestion/{questionId}")]
        public async Task<IActionResult> UpdateQuestion(int questionId, Question question)
        {
            if (questionId != question.QuestionId || question == null)
            {
                return BadRequest();
            }
            var updatedQuestion = await _questionService.UpdateQuestionAsync(question);
            if (updatedQuestion == null)
            {
                return NotFound();
            }
            return Ok(updatedQuestion);
        }

        [HttpDelete("DeleteQuestion/{questionId}")]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            var deleted = await _questionService.DeleteQuestionAsync(questionId);
            if (deleted==null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
