using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public int CourseId { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Paticipant> Paticipants { get; set; }


    }
}
