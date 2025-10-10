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
    public class QuestionRepository:IQuestionRepository
    {
        public readonly LeaderBoardDbContext _context;
        public QuestionRepository(LeaderBoardDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await Task.FromResult(_context.Questions.ToList());
        }
        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            var question = _context.Questions.FirstOrDefault(q => q.QuestionId == questionId);
            return await Task.FromResult(question);
        }
        public async Task<Question> CreateQuestionAsync(Question question)
        {
            _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }
        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            var existingQuestion = _context.Questions.FirstOrDefault(q => q.QuestionId == question.QuestionId);
            if (existingQuestion == null)
            {
                return null;
            }
            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.QuizId = question.QuizId;
            await _context.SaveChangesAsync();
            return existingQuestion;
        }
        public async Task<Question> DeleteQuestionAsync(int questionId)
        {
            var question = _context.Questions.FirstOrDefault(q => q.QuestionId == questionId);
            if (question == null)
            {
                return null;
            }
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return question;
        }

    }
}
