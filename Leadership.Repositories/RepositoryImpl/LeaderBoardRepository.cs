using Leadership.Domain.IRepositories;
using Leadership.Domain.Models;
using Leadership.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leadership.Repositories.RepositoryImpl
{
    public class LeaderBoardRepository : ILeaderBoardRepository
    {
        private readonly LeaderBoardDbContext _context;

        public LeaderBoardRepository(LeaderBoardDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaderBoard>> GetAll()
        {
            return await _context.LeaderBoards
                .Include(lb => lb.Participant)
                .Include(lb => lb.Quiz)
                .OrderBy(lb => lb.Rank) 
                .ToListAsync();
        }

        public async Task<LeaderBoard> GetById(int id)
        {
            return await _context.LeaderBoards
                .Include(lb => lb.Participant)
                .Include(lb => lb.Quiz)
                .FirstOrDefaultAsync(lb => lb.LeaderboardId == id);
        }

        public async Task<LeaderBoard> Create(LeaderBoard leaderboard)
        {
            await _context.LeaderBoards.AddAsync(leaderboard);
            await _context.SaveChangesAsync();
            return leaderboard;
        }

        public async Task<LeaderBoard> Update(LeaderBoard leaderboard)
        {
            var existing = await _context.LeaderBoards.FindAsync(leaderboard.LeaderboardId);
            if (existing == null)
                return null;

            existing.QuizId = leaderboard.QuizId;
            existing.ParticipantId = leaderboard.ParticipantId;
            existing.Score = leaderboard.Score;
            existing.Rank = leaderboard.Rank;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<LeaderBoard> DeleteById(int id)
        {
            var leaderboard = await _context.LeaderBoards.FindAsync(id);
            if (leaderboard == null)
                return null;

            _context.LeaderBoards.Remove(leaderboard);
            await _context.SaveChangesAsync();
            return leaderboard;
        }
    }
}
