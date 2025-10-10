using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        [JsonIgnore]
        public ICollection<Participant> Participants { get; set; } = new List<Participant>(); 


    }
}
