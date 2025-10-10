using Leadership.Domain.IRepositories;
using Leadership.Domain.Models;
using Leadership.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Repositories.RepositoryImpl
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly LeaderBoardDbContext _dbContext;
        public ParticipantRepository( LeaderBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Participant>> GetAllParticipants()
        {
            return await _dbContext.Participants.ToListAsync();
        }
        public async Task<Participant> GetParticipantById(int id)
        {
            return await _dbContext.Participants.FindAsync(id);
        }
        public async Task<Participant> CreateParticipant(Participant participant)
        {
            var existing = await _dbContext.Participants
               .FirstOrDefaultAsync(p => p.UserId == participant.UserId && p.QuizId == participant.QuizId);

            if (existing != null)
                throw new InvalidOperationException("Participant is already registered for this quiz.");

            await _dbContext.Participants.AddAsync(participant);
            await _dbContext.SaveChangesAsync();

            return participant;
        }
        public async Task<Participant> UpdateParticipant(Participant newParticipant)
        {
            var existing = await _dbContext.Participants
                .FirstOrDefaultAsync(p => p.ParticipantId == newParticipant.ParticipantId);

            if (existing == null)
                throw new KeyNotFoundException($"Participant with ID {newParticipant.ParticipantId} not found.");

            existing.Score = newParticipant.Score;
            existing.QuizId = newParticipant.QuizId;
            existing.UserId = newParticipant.UserId;

            _dbContext.Participants.Update(existing);
            await _dbContext.SaveChangesAsync();

            return existing;
        }
        public async Task<Participant> DeleteParticipant(int id)
        {
            var participant = await _dbContext.Participants
                .FirstOrDefaultAsync(p => p.ParticipantId == id);

            if (participant == null)
                throw new KeyNotFoundException($"Participant with ID {id} not found.");

            _dbContext.Participants.Remove(participant);
            await _dbContext.SaveChangesAsync();

            return participant;
        }
    }
}
