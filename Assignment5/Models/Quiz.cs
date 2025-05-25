using System.Collections.Generic;
using System.Linq;

namespace Quiz.Core
{
    public class Quiz
    {
        public List<IQuestion> Questions { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int PointsPerCorrect { get; set; } = 10;

        public int TotalScore => Answers.Count(a => a.IsCorrect) * PointsPerCorrect;

        public string GetFinalGrade()
        {
            int score = TotalScore;
            if (score >= 45) return "Відмінно";
            if (score >= 30) return "Добре";
            return "Задовільно";
        }
    }
}