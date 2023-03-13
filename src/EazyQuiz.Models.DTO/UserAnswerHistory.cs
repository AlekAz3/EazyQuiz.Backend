using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyQuiz.Models.DTO
{
    public class UserAnswerHistory
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
