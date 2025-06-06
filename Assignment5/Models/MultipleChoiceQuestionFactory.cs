﻿using System.Collections.Generic;
using Quiz.Core;

namespace Quiz.Factories
{
    public class MultipleChoiceQuestionFactory : IQuestionFactory
    {
        public IQuestion CreateQuestion(dynamic data)
        {
            return new MultipleChoiceQuestion
            {
                Id = data.Id,
                Text = data.Text,
                Category = data.Category,
                Options = data.Options as List<string>,
                CorrectIndexes = data.CorrectIndexes as List<int>
            };
        }
    }
}