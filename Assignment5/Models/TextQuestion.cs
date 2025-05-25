using System;

namespace Quiz.Core
{
    public class TextQuestion : Question
    {
        public string CorrectAnswer { get; set; }

        public override bool CheckAnswer(object userAnswer)
        {
            if (userAnswer is string input)
                return string.Equals(input.Trim(), CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);
            return false;
        }

        public override string DisplayOptions()
        {
            return "(Введіть текст відповіді)";
        }
    }
}