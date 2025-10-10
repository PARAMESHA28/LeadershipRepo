using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int? SelectedOptionId { get; set; } 
        public Option SelectedOption { get; set; }
        public DateTime ResponseTime { get; set; }
    }
}
