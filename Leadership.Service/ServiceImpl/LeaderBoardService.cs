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
    public class LeaderBoardService : ILeaderBoardService
    {
        private readonly ILeaderBoardRepository _leaderBoardRepository;
        public LeaderBoardService(ILeaderBoardRepository leaderBoardRepository)
        {
            _leaderBoardRepository = leaderBoardRepository;
        }
        public async Task<IEnumerable<LeaderBoard>> GetAllAsync()
        {
            return await _leaderBoardRepository.GetAll();
        }
        public async Task<LeaderBoard> GetByIdAsync(int id)
        {
            return await _leaderBoardRepository.GetById(id);
        }
        public async Task<LeaderBoard> CreateAsync(LeaderBoard leaderboard)
        {
            return await _leaderBoardRepository.Create(leaderboard);
        }

        public async Task<LeaderBoard> UpdateAsync(LeaderBoard leaderboard)
        {
            return await _leaderBoardRepository.Update(leaderboard);
        }
        public async Task<LeaderBoard> DeleteAsync(int id)
        {
            return await _leaderBoardRepository.DeleteById(id);
        }
    }
}
