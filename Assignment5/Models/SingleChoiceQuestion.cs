using System.Collections.Generic;
using System.Text;

namespace Quiz.Core
{
    public class SingleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }

        public override bool CheckAnswer(object userAnswer)
        {
            if (userAnswer is int selectedIndex)
                return selectedIndex == CorrectIndex;
            return false;
        }

        public override string DisplayOptions()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Options.Count; i++)
                sb.AppendLine($"{i + 1}. {Options[i]}");
            return sb.ToString();
        }
    }
}