using System.Collections.Generic;
using Quiz.Core;

namespace Quiz.Factories
{
    public class SingleChoiceQuestionFactory : IQuestionFactory
    {
        public IQuestion CreateQuestion(dynamic data)
        {
            return new SingleChoiceQuestion
            {
                Id = data.Id,
                Text = data.Text,
                Category = data.Category,
                Options = data.Options as List<string>,
                CorrectIndex = data.CorrectIndex
            };
        }
    }
}