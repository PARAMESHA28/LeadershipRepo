using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int Marks { get; set; }
        public int QuizId { get; set; }
        [JsonIgnore]
        public Quiz? Quiz { get; set; }

        [JsonIgnore]
        public ICollection<Option> options { get; set; }=new List<Option>();


    }
}
