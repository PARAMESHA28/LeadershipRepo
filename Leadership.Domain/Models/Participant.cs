using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public int UserId { get; set; } 
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int Score { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
