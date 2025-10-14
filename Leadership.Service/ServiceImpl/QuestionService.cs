using Leadership.Domain.IRepositories;
using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Service.ServiceImpl
{
    public class QuestionService:IQuestionService
    {
        public readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllQuestionsAsync();
        }
        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            return await _questionRepository.GetQuestionByIdAsync(questionId);
        }
        public async Task<Question> CreateQuestionAsync(Question question)
        {
            return await _questionRepository.CreateQuestionAsync(question);
        }
        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            return await _questionRepository.UpdateQuestionAsync(question);
        }
        public async Task<Question> DeleteQuestionAsync(int questionId)
        {
            return await _questionRepository.DeleteQuestionAsync(questionId);
        }
    }
}
