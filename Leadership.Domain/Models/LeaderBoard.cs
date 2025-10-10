using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class LeaderBoard
    {
        public int LeaderboardId { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int Score { get; set; }
        public int Rank { get; set; }
        //public string ParticipantName { get; set; }
    }
}
