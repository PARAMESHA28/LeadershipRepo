using Leadership.Domain.IRepositories;
using Leadership.Domain.Models;
using Leadership.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Leadership.Repositories.RepositoryImpl
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly LeaderBoardDbContext _context;

        public ResponseRepository(LeaderBoardDbContext context)
        {
            _context = context;
        }

        // Get all responses (with related Participant, Question, Option)
        public async Task<IEnumerable<Response>> GetAllResponses()
        {
            return await _context.Responses
                .Include(r => r.Participant)
                .Include(r => r.Question)
                .Include(r => r.SelectedOption)
                .ToListAsync();
        }

        public async Task<Response> GetResponseById(int id)
        {
            return await _context.Responses
                .Include(r => r.Participant)
                .Include(r => r.Question)
                .Include(r => r.SelectedOption)
                .FirstOrDefaultAsync(r => r.ResponseId == id);
        }
        public async Task<Response> CreateResponses(Response response)
        {
            await _context.Responses.AddAsync(response);
            await _context.SaveChangesAsync();
            return response;
        }
        public async Task<Response> UpdateResponses(Response response)
        {
            var existingResponse = await _context.Responses.FindAsync(response.ResponseId);
            if (existingResponse == null)
                return null;

            // Update fields
            existingResponse.ParticipantId = response.ParticipantId;
            existingResponse.QuestionId = response.QuestionId;
            existingResponse.OptionId = response.OptionId;
            existingResponse.ResponseTime = response.ResponseTime;

            await _context.SaveChangesAsync();
            return existingResponse;
        }
        public async Task<Response> DeleteResponses(int id)
        {
            var response = await _context.Responses.FindAsync(id);
            if (response == null)
                return null;

            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();
            return response;
        }
    }
}
