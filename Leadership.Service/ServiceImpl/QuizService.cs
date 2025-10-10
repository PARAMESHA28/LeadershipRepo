using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using Leadership.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Service.ServiceImpl
{
    public class QuizService:IQuizService
    {
        public readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            return await _quizRepository.GetAllQuizzesAsync();
        }
        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            return await _quizRepository.GetQuizByIdAsync(quizId);
        }
        public async Task<Quiz> CreateQuizAsync(Quiz quiz)
        {
            return await _quizRepository.CreateQuizAsync(quiz);
        }
        public async Task<Quiz> UpdateQuizAsync(Quiz quiz)
        {
            return await _quizRepository.UpdateQuizAsync(quiz);
        }
        public async Task<Quiz> DeleteQuizAsync(int quizId)
        {
            return await _quizRepository.DeleteQuizAsync(quizId);
        }
    }
}
