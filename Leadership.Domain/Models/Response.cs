using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public int ParticipantId { get; set; }
        [JsonIgnore]
        public Participant? Participant { get; set; } 
        public int QuestionId { get; set; }
        [JsonIgnore]
        public Question? Question { get; set; } 
        public int? OptionId { get; set; }
        [JsonIgnore]
        public Option? SelectedOption { get; set; }
        public DateTime ResponseTime { get; set; }
    }
}
