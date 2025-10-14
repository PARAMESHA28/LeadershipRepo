using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IServices
{
    public interface ILeaderBoardService
    {
        Task<IEnumerable<LeaderBoard>> GetAllAsync();
        Task<LeaderBoard> GetByIdAsync(int Id);
        Task<LeaderBoard> CreateAsync(LeaderBoard leaderboard);
        Task<LeaderBoard> UpdateAsync(LeaderBoard leaderboard);
        Task<LeaderBoard> DeleteAsync(int Id);
    }
}
