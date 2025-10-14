using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IRepositories
{
    public interface ILeaderBoardRepository
    {
        Task<IEnumerable<LeaderBoard>> GetAll();
        Task<LeaderBoard> GetById(int Id);
        Task<LeaderBoard> Create(LeaderBoard leaderboard);
        Task<LeaderBoard> Update(LeaderBoard leaderboard);
        Task<LeaderBoard> DeleteById(int Id);
    }
}
