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
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Response> Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Response → Question (Restrict instead of Cascade)
            modelBuilder.Entity<Response>()
                .HasOne(r => r.Question)
                .WithMany() 
                .HasForeignKey(r => r.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Response → Participant (Restrict instead of Cascade)
            modelBuilder.Entity<Response>()
                .HasOne(r => r.Participant)
                .WithMany(p => p.Responses)
                .HasForeignKey(r => r.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);

         
            modelBuilder.Entity<Response>()
                .HasOne(r => r.SelectedOption)
                .WithMany()
                .HasForeignKey(r => r.OptionId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<LeaderBoard>()
                .HasOne(lb => lb.Quiz)
                .WithMany()
                .HasForeignKey(lb => lb.QuizId)
                .OnDelete(DeleteBehavior.Restrict);

         
            modelBuilder.Entity<LeaderBoard>()
                .HasOne(lb => lb.Participant)
                .WithMany()
                .HasForeignKey(lb => lb.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
