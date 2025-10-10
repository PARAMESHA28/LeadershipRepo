using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class LeaderBoard
    {
        public int LeaderboardId { get; set; }
        public int QuizId { get; set; }
        [JsonIgnore]
        public Quiz? Quiz { get; set; } 
        public int ParticipantId { get; set; }
        [JsonIgnore]
        public Participant? Participant { get; set; } 
        public int Score { get; set; }
        public int Rank { get; set; }
        //public string ParticipantName { get; set; }
    }
}
