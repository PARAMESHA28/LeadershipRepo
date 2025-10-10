using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leadership.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        public readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
                       _quizService = quizService;
        }
        [HttpGet("GetAllQuizzes")]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizzes = await _quizService.GetAllQuizzesAsync();
            return Ok(quizzes);
        }
        [HttpGet("GetQuizById/{quizId}")]
        public async Task<IActionResult> GetQuizById(int quizId)
        {
            var quiz = await _quizService.GetQuizByIdAsync(quizId);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }
        [HttpPost("CreateQuiz")]
        public async Task<IActionResult> CreateQuiz( Quiz quiz)
        {
            if (quiz == null)
            {
                return BadRequest();
            }
            var createdQuiz = await _quizService.CreateQuizAsync(quiz);
            return CreatedAtAction(nameof(GetQuizById), new { quizId = createdQuiz.QuizId }, createdQuiz);
        }
        [HttpPut("UpdateQuiz/{quizId}")]
        public async Task<IActionResult> UpdateQuiz(int quizId, Quiz quiz)
        {
            if (quizId != quiz.QuizId || quiz == null)
            {
                return BadRequest();
            }
            var updatedQuiz = await _quizService.UpdateQuizAsync(quiz);
            if (updatedQuiz == null)
            {
                return NotFound();
            }
            return Ok(updatedQuiz);
        }
        [HttpDelete("DeleteQuiz/{quizId}")]
        public async Task<IActionResult> DeleteQuiz(int quizId)
        {
            var deleted = await _quizService.DeleteQuizAsync(quizId);
            if (deleted== null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
