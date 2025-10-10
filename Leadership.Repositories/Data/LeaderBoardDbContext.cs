using Leadership.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Repositories.Data
{
    public class LeaderBoardDbContext : DbContext
    {
        public LeaderBoardDbContext(DbContextOptions<LeaderBoardDbContext> options) : base(options) { }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Response> Responses { get; set; }
    }
}
