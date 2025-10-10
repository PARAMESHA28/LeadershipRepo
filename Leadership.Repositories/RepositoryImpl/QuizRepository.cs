using Leadership.Domain.IRepositories;
using Leadership.Domain.Models;
using Leadership.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Repositories.RepositoryImpl
{
    public class QuizRepository: IQuizRepository
    {
        public readonly LeaderBoardDbContext _context;
        public QuizRepository(LeaderBoardDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            return await Task.FromResult(_context.Quizzes.ToList());
        }
        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.QuizId == quizId);
            return await Task.FromResult(quiz);
        }
        public async Task<Quiz> CreateQuizAsync(Quiz quiz)
        {
            _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }
        public async Task<Quiz> UpdateQuizAsync(Quiz quiz)
        {
            var existingQuiz = _context.Quizzes.FirstOrDefault(q => q.QuizId == quiz.QuizId);
            if (existingQuiz == null)
            {
                return null;
            }
            existingQuiz.QuizTitle = quiz.QuizTitle;
            existingQuiz.CourseId = quiz.CourseId;
            await _context.SaveChangesAsync();
            return existingQuiz;
        }
        public async Task<Quiz> DeleteQuizAsync(int quizId)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.QuizId == quizId);
            if (quiz == null)
            {
                return null;
            }
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }
       

    }
}
