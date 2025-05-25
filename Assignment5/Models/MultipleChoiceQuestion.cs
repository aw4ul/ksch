using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.Core
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public List<int> CorrectIndexes { get; set; }

        public override bool CheckAnswer(object userAnswer)
        {
            if (userAnswer is List<int> selectedIndexes)
                return !CorrectIndexes.Except(selectedIndexes).Any() && !selectedIndexes.Except(CorrectIndexes).Any();
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