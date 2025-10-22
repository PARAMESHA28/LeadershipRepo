using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IServices
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync(int quizId);
        Task<Question> GetQuestionByIdAsync(int questionId);
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);
        Task<Question> DeleteQuestionAsync(int questionId);
    }
}
