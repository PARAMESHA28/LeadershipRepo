using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IRepositories
{
    public interface IQuestionRepository
    {
        public Task<IEnumerable<Question>> GetAllQuestionsAsync();
        public Task<Question> GetQuestionByIdAsync(int questionId);
        public Task<Question> CreateQuestionAsync(Question question);
            
        public Task<Question> UpdateQuestionAsync(Question question);

        public Task<Question> DeleteQuestionAsync(int questionId);
    }
}
